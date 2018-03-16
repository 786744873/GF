using CommonService.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitoringService
{
    public partial class MonitorHardService : ServiceBase
    {
        private readonly CommonService.BLL.FlowManager.P_Flow flowBLL = new CommonService.BLL.FlowManager.P_Flow();
        private readonly CommonService.BLL.FlowManager.P_Business_flow businessFlowBLL = new CommonService.BLL.FlowManager.P_Business_flow();
        private readonly CommonService.DAL.CaseManager.B_CaseLevelchange caseLevelChangeDAL = new CommonService.DAL.CaseManager.B_CaseLevelchange();
        private readonly CommonService.DAL.CaseManager.B_CaseLevelChangeRecords caseLevelChangeRecordsDAL = new CommonService.DAL.CaseManager.B_CaseLevelChangeRecords();
        public MonitorHardService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(HardChange);
            Thread thread = new Thread(threadStart);
            thread.Start();

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
            {
                sw.WriteLine("监控(难案)服务启动：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "");
            }
        }

        protected override void OnStop()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
            {
                sw.WriteLine("监控(难案)服务启动：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "");
            }
        }

        private void HardChange()
        {
            try
            {
                while (true)
                {
                    List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList = businessFlowBLL.GetAllListByFlowIsMonitor();//根据流程"是否监控"为"是"获得关联业务流程
                    foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlowList)
                    {
                        bool IsHard = false;
                        if (businessFlow.P_Fk_code != null && businessFlow.P_Fk_code != Guid.Empty)
                            IsHard = caseLevelChangeDAL.IsHardToAdjust(businessFlow.P_Fk_code.Value, Convert.ToInt32(CaseLevelEnum.难案));//案件是否进行难案调整
                        else
                            continue;
                        if (!IsHard)
                        {
                            if (businessFlow.P_Business_flow_factStartTime == null)//业务流程的实际开始时间为空
                                continue;
                            DateTime now = DateTime.Now;//当前时间
                            DateTime businessFlowFactStartTime = businessFlow.P_Business_flow_factStartTime.Value;//业务流程的实际开始时间
                            TimeSpan timeDifference = now.Subtract(businessFlowFactStartTime);
                            int day = timeDifference.Days;
                            int hours = timeDifference.Hours;
                            int timeDifferenceHours = (day * 24) + hours;
                            if (businessFlow.P_Flow_defaultDuration == null)
                                continue;
                            if (timeDifferenceHours > businessFlow.P_Flow_defaultDuration)
                            {//大于流程预设默认时长
                                #region 变更记录表中插入数据
                                CommonService.Model.CaseManager.B_CaseLevelChangeRecords caseLevelChangeRecords = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
                                caseLevelChangeRecords.B_CaseLevelChangeRecords_code = Guid.NewGuid();
                                caseLevelChangeRecords.B_Case_code = businessFlow.P_Fk_code.Value;
                                caseLevelChangeRecords.B_CaseLevelChangeRecords_type = Convert.ToInt32(CaseLevelChangeRecordTypeEnum.自动);
                                caseLevelChangeRecords.B_CaseLevelChangeRecords_applicationData = DateTime.Now;
                                caseLevelChangeRecords.B_CaseLevelChangeRecords_actualChangeDate = DateTime.Now;
                                caseLevelChangeRecords.B_CaseLevelChangeRecords_createTime = DateTime.Now;
                                caseLevelChangeRecords.B_CaseLevelChangeRecords_isDelete = false;
                                caseLevelChangeRecords.B_CaseLevelChangeRecords_isAudit = true;
                                string defaultDurationStr = Convert.ToDouble(businessFlow.P_Flow_defaultDuration / 24).ToString("0.00");
                                string reasonStr = Convert.ToDouble(defaultDurationStr) > 1 ? defaultDurationStr + "天" : defaultDurationStr + "小时";
                                caseLevelChangeRecords.B_CaseLevelChangeRecords_conversionReasons = businessFlow.P_Business_flow_name + "时间>" + reasonStr + "，转为‘难案’";

                                caseLevelChangeRecordsDAL.Add(caseLevelChangeRecords);
                                #endregion

                                #region 案件级别变更表插入数据
                                CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange = new CommonService.Model.CaseManager.B_CaseLevelchange();
                                caseLevelChange.B_CaseLevelchange_code = Guid.NewGuid();
                                caseLevelChange.B_Case_code = businessFlow.P_Fk_code.Value;
                                caseLevelChange.B_CaseLevelchange_type = Convert.ToInt32(CaseLevelEnum.难案);
                                caseLevelChange.B_CaseLevelchange_changeRecord = caseLevelChangeRecords.B_CaseLevelChangeRecords_code.Value;
                                caseLevelChange.B_CaseLevelchange_state = Convert.ToInt32(CaseLevelChangeStateEnum.通过);
                                caseLevelChange.B_CaseLevelchange_IsValid = true;
                                caseLevelChange.B_CaseLevelchange_createTime = DateTime.Now;
                                caseLevelChange.B_CaseLevelchange_isDelete = false;

                                caseLevelChangeDAL.Add(caseLevelChange);
                                #endregion
                            }
                        }
                    }

                    Thread.Sleep(20000);//间隔20秒
                }
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Exception.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：HardChange");
                }
            }
        }
    }
}
