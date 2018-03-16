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
using System.Web;
namespace OAService
{
    partial class OAScheduleService : ServiceBase
    {
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        private readonly CommonService.BLL.OA.O_Schedule schbll = new CommonService.BLL.OA.O_Schedule();
        private readonly CommonService.BLL.OA.O_Schedule_user schubll = new CommonService.BLL.OA.O_Schedule_user();

        bool isQuery = false;
        public OAScheduleService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                //监听消息
                ThreadStart threadStart = new ThreadStart(ReadMessage);
                Thread thread = new Thread(threadStart);
                thread.Start();

                //发送消息
                ThreadStart changeData = new ThreadStart(SelectChange);
                Thread changeDataThread = new Thread(changeData);
                changeDataThread.Start();
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("服务启动：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "");
                }
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：OnStart");
                }
            }

        }

        protected override void OnStop()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
            {
                sw.WriteLine("服务停止：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "");
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
                    if (msg.Body.ToString() == "clacScheduleMessage")
                    {
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
        /// 查询此时间段需要发送的通知消息
        /// </summary>
        private void SelectChange()
        {
            try
            {   //日程数据集合
                List<CommonService.Model.OA.O_Schedule> selectScheduleList = new List<CommonService.Model.OA.O_Schedule>();
                while (true)
                {
                    if (selectScheduleList.Count == 0)
                    {
                        selectScheduleList = schbll.GetAllremindList();//获得需要提醒的数据，并且当前时间在开始时间结束时间中间
                    }
                    if (isQuery)
                    { //查询
                        selectScheduleList = schbll.GetAllremindList();//更新内存中的数据
                        //EachList(selectScheduleList);
                        isQuery = false;
                    }
                    EachList(selectScheduleList);
                    Thread.Sleep(2000);//间隔2秒    
                }
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：SelectChange");
                }
            }
        }
        /// <summary>
        /// 遍历数据
        /// </summary>
        /// <param name="selectScheduleList"></param>
        private void EachList(List<CommonService.Model.OA.O_Schedule> selectScheduleList)
        {
            foreach (var item in selectScheduleList)
            { //遍历查询到的数据
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(item.O_Schedule_startTime);
                if (!item.O_Schedule_isAllDay)
                {
                    #region  不是全天的日程
                    switch (item.O_Schedule_remindType)
                    {
                        case 476://准时
                            if (dt.ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                            {
                                //给对应的人发送消息
                                SendMessage(item, DateTime.Now);
                            }
                            break;
                        case 477://提前10分钟
                            if (dt.AddMinutes(-10).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                            {
                                //给对应的人发送消息
                                SendMessage(item, DateTime.Now);
                            }
                            break;
                        case 478://提前30分钟
                            if (dt.AddMinutes(-30).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                            {
                                //给对应的人发送消息
                                SendMessage(item, DateTime.Now);
                            }
                            break;
                        case 479://提前1小时
                            if (dt.AddHours(-1).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                            {
                                //给对应的人发送消息
                                SendMessage(item, DateTime.Now);
                            }
                            break;
                        case 480://提前2小时
                            if (dt.AddHours(-2).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                            {
                                //给对应的人发送消息
                                SendMessage(item, DateTime.Now);
                            }
                            break;
                        case 481://提前3小时
                            if (dt.AddHours(-3).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                            {
                                //给对应的人发送消息
                                SendMessage(item, DateTime.Now);
                            }
                            break;
                        case 482://提前一天
                            if (dt.AddDays(-1).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                            {
                                //给对应的人发送消息
                                SendMessage(item, DateTime.Now);
                            }
                            break;
                    }
                    #endregion
                }
                else
                {
                    #region   是全天的日程
                    //switch (item.O_Schedule_remindType)
                    //{
                    //    case 476://准时
                    //        if (dt.ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                    //        {
                    //            //给对应的人发送消息
                    //            SendMessage(item, DateTime.Now);
                    //        }
                    //        break;
                    //    case 477://提前10分钟
                    //        if (dt.AddMinutes(-10d).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                    //        {
                    //            //给对应的人发送消息
                    //            SendMessage(item, DateTime.Now);
                    //        }
                    //        break;
                    //    case 478://提前30分钟
                    //        if (dt.AddMinutes(-30d).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                    //        {
                    //            //给对应的人发送消息
                    //            SendMessage(item, DateTime.Now);
                    //        }
                    //        break;
                    //    case 479://提前1小时
                    //        if (dt.AddHours(-1d).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                    //        {
                    //            //给对应的人发送消息
                    //            SendMessage(item, DateTime.Now);
                    //        }
                    //        break;
                    //    case 480://提前2小时
                    //        if (dt.AddHours(-2d).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                    //        {
                    //            //给对应的人发送消息
                    //            SendMessage(item, DateTime.Now);
                    //        }
                    //        break;
                    //    case 481://提前3小时
                    //        if (dt.AddHours(-3d).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                    //        {
                    //            //给对应的人发送消息
                    //            SendMessage(item, DateTime.Now);
                    //        }
                    //        break;
                    //    case 482://提前一天
                    //        if (dt.AddDays(-1d).ToString("yyyy-MM-dd HH:mm").Trim() == DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim())
                    //        {
                    //            //给对应的人发送消息
                    //            SendMessage(item, DateTime.Now);
                    //        }
                    //        break;
                    //}
                    #endregion
                }
            }
        }
        /// <summary>
        /// 给日程负责人发送消息
        /// </summary>
        /// <param name="caseCode">日程用户中间表实体</param>
        /// <param name="now">当前时间</param>
        private void SendMessage(CommonService.Model.OA.O_Schedule model, DateTime now)
        {
            try
            {
                List<CommonService.Model.OA.O_Schedule_user> userLists = schubll.GetScheduleUsersByScheduleCode(new Guid(model.O_Schedule_code.ToString()));

                foreach (CommonService.Model.OA.O_Schedule_user item in userLists)
                {
                    if (item.C_userinfo_code != null && !(messageDAL.ExistsBylinkCodeAnduserCode(new Guid(item.O_Schedule_code.ToString()), new Guid(item.C_userinfo_code.ToString()))))
                    {
                        CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.日程);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.日程提醒);
                        message.C_Messages_link = item.O_Schedule_code;
                        message.C_Messages_createTime = now;
                        message.C_Messages_person = item.C_userinfo_code;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;
                        messageDAL.Add(message);
                        //发送消息  调用webservice 
                        ServiceReference1.OAWebServiceSoapClient aa = new ServiceReference1.OAWebServiceSoapClient();
                        aa.OASchedule(item.O_Schedule_code.ToString(), item.C_userinfo_code.ToString());
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                        {
                            sw.WriteLine("插入时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "" + "插入信息：" + "" + message.C_Messages_link + "");
                        }
                    }
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
