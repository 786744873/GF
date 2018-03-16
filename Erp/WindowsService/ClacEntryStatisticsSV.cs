using CommonService.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Messaging;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class ClacEntryStatisticsSV : ServiceBase
    {
        private readonly CommonService.DAL.MonitorManager.M_Entry_Statistics dal = new CommonService.DAL.MonitorManager.M_Entry_Statistics();
        private readonly CommonService.BLL.MonitorManager.M_Entry_Statistics bll = new CommonService.BLL.MonitorManager.M_Entry_Statistics();
        private readonly CommonService.DAL.CaseManager.B_Case caseDal = new CommonService.DAL.CaseManager.B_Case();
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        bool isQuery = false;
        public ClacEntryStatisticsSV()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //监听消息
            ThreadStart threadStart = new ThreadStart(ReadMessage);
            Thread thread = new Thread(threadStart);
            thread.Start();

            //更改数据
            ThreadStart changeData = new ThreadStart(ChangeData);
            Thread changeDataThread = new Thread(changeData);
            changeDataThread.Start();

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
            {
                sw.WriteLine("条目服务启动：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "");
            }
        }

        protected override void OnStop()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
            {
                sw.WriteLine("条目服务启动：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "");
            }
        }

        /// <summary>
        /// 监听消息
        /// </summary>
        private void ReadMessage()
        {
            try
            {
                string queueName = @".\Private$\SampleQueue";
                MessageQueue mq = null;

                if (!MessageQueue.Exists(queueName))
                    mq = MessageQueue.Create(queueName);
                else
                    mq = new MessageQueue(queueName);

                while (true)
                {
                    mq.Formatter = new XmlMessageFormatter(new[] { "System.String" });
                    Message msg = mq.Receive();
                    if (msg.Body.ToString() == "clacEntryStatisticsTime")
                    {
                        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                        //{
                        //    sw.WriteLine("有新消息：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + "" + "     异常地点：ReadMessage");
                        //}
                        isQuery = true;
                    }
                }
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：ReadMessage");
                }
            }

        }

        /// <summary>
        /// 更改数据
        /// </summary>
        private void ChangeData()
        {
            try
            {
                //数据集合
                List<CommonService.Model.MonitorManager.M_Entry_Statistics> warningSituationList = new List<CommonService.Model.MonitorManager.M_Entry_Statistics>();
                List<CommonService.Model.MonitorManager.M_Entry_Statistics> handlingStateList = new List<CommonService.Model.MonitorManager.M_Entry_Statistics>();

                while (true)
                {
                    if (warningSituationList.Count() == 0)
                    {//获取预警情况为’非预警‘的数据列表
                        dal.UpdateWarningSituation();
                        warningSituationList = bll.GetListByWarningSituation();
                    }
                    if (handlingStateList.Count() == 0)
                    {//获取办案状态为非’已结束‘的数据列表
                        handlingStateList = bll.GetListByHandlingState();
                    }

                    if (isQuery)
                    {
                        #region 更改预警情况
                        dal.UpdateWarningSituation();
                        warningSituationList = bll.GetListByWarningSituation();

                        ChangeWarningSituation(warningSituationList);

                        #endregion

                        #region 更改办案状态

                        handlingStateList = bll.GetListByHandlingState();
                        ChangeHandlingState(handlingStateList);

                        #endregion
                        isQuery = false;
                    }
                    else
                    {
                        ChangeWarningSituation(warningSituationList);//更改预警情况
                        ChangeHandlingState(handlingStateList);//更改办案状态
                    }

                    Thread.Sleep(20000);//间隔20秒
                }
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：ChangeData");
                }
            }
        }

        /// <summary>
        /// 更改预警情况
        /// </summary>
        /// <param name="entryStatisticsList">条目集合</param>
        private void ChangeWarningSituation(List<CommonService.Model.MonitorManager.M_Entry_Statistics> warningSituationList)
        {
            try
            {
                warningSituationList = warningSituationList.Where(p => p.M_Entry_Statistics_warningSituation == Convert.ToInt32(Entry_WarningSituationlEnum.非预警)).ToList();
                foreach (CommonService.Model.MonitorManager.M_Entry_Statistics entryStatistics in warningSituationList)
                {
                    if (entryStatistics.M_Entry_Statistics_entrySTime == null)
                    {
                        continue;
                    }
                    DateTime startTime = (DateTime)entryStatistics.M_Entry_Statistics_entrySTime;//开始时间
                    int warningDuration = (int)entryStatistics.M_Entry_warningDuration;//预警时长
                    int Duration = (int)entryStatistics.M_Entry_Duration;//标准时长
                    DateTime now = DateTime.Now;
                    if (entryStatistics.M_Entry_warningType == Convert.ToInt32(Entry_ChildlEnum.条目发生前))
                    {//条目发生前
                        DateTime timeDifference = startTime.AddHours(-warningDuration);
                        if (timeDifference <= now)
                        {
                            entryStatistics.M_Entry_Statistics_warningSituation = Convert.ToInt32(Entry_WarningSituationlEnum.预警);
                            dal.UpdateByWarningSituation(entryStatistics);
                            //给案件负责人发送预警消息
                            SendMessage(entryStatistics.M_Case_code.Value.ToString(), 1, now);
                        }
                    }
                    else if (entryStatistics.M_Entry_warningType == Convert.ToInt32(Entry_ChildlEnum.条目发生后))
                    {//条目发生后
                        DateTime timeDifference = startTime.AddHours(warningDuration);
                        if (timeDifference <= now)
                        {
                            entryStatistics.M_Entry_Statistics_warningSituation = Convert.ToInt32(Entry_WarningSituationlEnum.预警);
                            dal.UpdateByWarningSituation(entryStatistics);
                            //给案件负责人发送预警消息
                            SendMessage(entryStatistics.M_Case_code.Value.ToString(), 1, now);
                        }
                    }
                    else if (entryStatistics.M_Entry_warningType == Convert.ToInt32(Entry_ChildlEnum.条目标准时长结束前))
                    {//标准时长结束前
                        DateTime timeDifference = startTime.AddHours(Duration - warningDuration);
                        if (timeDifference <= now)
                        {
                            entryStatistics.M_Entry_Statistics_warningSituation = Convert.ToInt32(Entry_WarningSituationlEnum.预警);
                            dal.UpdateByWarningSituation(entryStatistics);
                            //给案件负责人发送预警消息
                            SendMessage(entryStatistics.M_Case_code.Value.ToString(), 1, now);
                        }
                    }
                    else if (entryStatistics.M_Entry_warningType == Convert.ToInt32(Entry_ChildlEnum.条目标准时长结束后))
                    {//标准时长结束后
                        DateTime timeDifference = startTime.AddHours(Duration + warningDuration);
                        if (timeDifference <= now)
                        {
                            entryStatistics.M_Entry_Statistics_warningSituation = Convert.ToInt32(Entry_WarningSituationlEnum.预警);
                            dal.UpdateByWarningSituation(entryStatistics);
                            //给案件负责人发送预警消息
                            SendMessage(entryStatistics.M_Case_code.Value.ToString(), 1, now);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：ChangeWarningSituation");
                }
            }
        }

        /// <summary>
        /// 更改办案状态
        /// </summary>
        /// <param name="entryStatisticsList"></param>
        private void ChangeHandlingState(List<CommonService.Model.MonitorManager.M_Entry_Statistics> handlingStateList)
        {
            try
            {
                foreach (CommonService.Model.MonitorManager.M_Entry_Statistics entryStatistics in handlingStateList)
                {
                    #region 局部变量
                    if (entryStatistics.M_Entry_Statistics_entrySTime == null)
                    {//条目开始时间没有值时
                        entryStatistics.M_Entry_Statistics_HandlingState = Convert.ToInt32(Entry_HandlingStatelEnum.未开始);
                        dal.UpdateByHandlingState(entryStatistics);//更改条目办理状态为“未开始”

                        continue;
                    }
                    else if (entryStatistics.M_Entry_Statistics_entryETime == null && entryStatistics.M_Entry_Statistics_HandlingState == Convert.ToInt32(Entry_HandlingStatelEnum.未开始)) //如果开始时间不为空，结束时间为空，先改为正在进行
                    {
                        entryStatistics.M_Entry_Statistics_HandlingState = Convert.ToInt32(Entry_HandlingStatelEnum.正进行);
                        dal.UpdateByHandlingState(entryStatistics);//更改条目办理状态为“未开始”
                    }

                    DateTime startTime = (DateTime)entryStatistics.M_Entry_Statistics_entrySTime;//条目开始时间
                    int Duration = (int)entryStatistics.M_Entry_Duration;//标准时长
                    int changeDuration = 0;//变更时长
                    if (entryStatistics.M_Entry_Statistics_changeDuration != null)
                    {
                        changeDuration = (int)entryStatistics.M_Entry_Statistics_changeDuration;
                    }
                    DateTime CurrentTime = DateTime.Now;//当前时间

                    #endregion

                    if (entryStatistics.M_Entry_Statistics_entryETime != null && entryStatistics.M_Entry_Statistics_HandlingState != Convert.ToInt32(Entry_HandlingStatelEnum.已结束))
                    {//条目结束时间有值时

                        #region 计算（条目开始时间加上标准时长，变更时长）减去条目结束时间的小时差

                        DateTime timeDiff = startTime.AddHours(Duration + changeDuration);
                        TimeSpan TS = timeDiff - Convert.ToDateTime(entryStatistics.M_Entry_Statistics_entryETime);
                        int hoursDifference = (int)TS.TotalHours;

                        #endregion

                        if (hoursDifference > 0)
                        {
                            entryStatistics.M_Entry_Statistics_HandlingState = Convert.ToInt32(Entry_HandlingStatelEnum.提前完成);
                        }else if(hoursDifference < 0)
                        {
                            entryStatistics.M_Entry_Statistics_HandlingState = Convert.ToInt32(Entry_HandlingStatelEnum.超时完成);
                        }else
                        {
                            entryStatistics.M_Entry_Statistics_HandlingState = Convert.ToInt32(Entry_HandlingStatelEnum.已结束);
                        }
                        entryStatistics.M_Entry_Statistics_Management = hoursDifference;//修改办理情况
                        dal.UpdateByHandlingState(entryStatistics);//更改条目办理状态为“已结束”

                        continue;
                    }

                    if (entryStatistics.M_Entry_Statistics_HandlingState == Convert.ToInt32(Entry_HandlingStatelEnum.正进行) || entryStatistics.M_Entry_Statistics_HandlingState == Convert.ToInt32(Entry_HandlingStatelEnum.已超时) || entryStatistics.M_Entry_Statistics_HandlingState == null)
                    {//条目办理状态为“正进行”或者“已超时”时

                        #region 计算（条目开始时间加上标准时长，变更时长）减去当前时间的小时差

                        DateTime timeDiff = startTime.AddHours(Duration + changeDuration);
                        TimeSpan TS = timeDiff - CurrentTime;
                        int hoursDifference = (int)TS.TotalHours;

                        #endregion

                        DateTime timeDifference = startTime.AddHours(Duration + changeDuration);
                        if (timeDifference >= CurrentTime)
                        {//小于或等于当前时间
                            entryStatistics.M_Entry_Statistics_HandlingState = Convert.ToInt32(Entry_HandlingStatelEnum.正进行);
                            entryStatistics.M_Entry_Statistics_Management = hoursDifference;//修改办理情况
                            dal.UpdateByHandlingState(entryStatistics);//修改办案状态为“正进行”
                        }
                        else
                        {
                            bool flag = true;
                            if (entryStatistics.M_Entry_Statistics_HandlingState == Convert.ToInt32(Entry_HandlingStatelEnum.已超时))
                            {
                                flag = false;
                            }
                            entryStatistics.M_Entry_Statistics_HandlingState = Convert.ToInt32(Entry_HandlingStatelEnum.已超时);
                            entryStatistics.M_Entry_Statistics_Management = hoursDifference;//修改办理情况
                            dal.UpdateByHandlingState(entryStatistics);//修改办案状态为“已超时”
                            if (flag)
                            {
                                //给案件负责人发送超时消息
                                SendMessage(entryStatistics.M_Case_code.Value.ToString(), 2, CurrentTime);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)                                  
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：ChangeHandlingState");
                }
            }
        }

        /// <summary>
        /// 给案件负责人发送消息
        /// </summary>
        /// <param name="caseCode">案件Code</param>
        /// <param name="type">1、预警消息  2、超时消息</param>
        /// <param name="now">当前时间</param>
        private void SendMessage(string caseCode, int type, DateTime now)
        {
            try
            {
                CommonService.Model.CaseManager.B_Case bcase = caseDal.GetModel(new Guid(caseCode));
                if (bcase!=null&&bcase.B_Case_person != null)
                {
                    CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.进程管理);
                    message.C_Messages_type = type == 1 ? Convert.ToInt32(MessageTinyTypeEnum.预警消息) : Convert.ToInt32(MessageTinyTypeEnum.超时消息);
                    message.C_Messages_link = new Guid(caseCode);
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = bcase.B_Case_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：SendMessage");
                }
            }
        }
    }
}
