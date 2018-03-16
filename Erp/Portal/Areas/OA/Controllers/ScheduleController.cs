using CommonService.Common;
using Maticsoft.Common;
using Microsoft.AspNet.SignalR;
using Portal.Controllers;
using Portal.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.OA.IO_Schedule _scheduleWCF;
        private readonly ICommonService.OA.IO_Schedule_user _scheduleUserWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.IC_Messages _messageWCF;

        public ScheduleController()
        {
            #region 服务初始化
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _scheduleWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Schedule>("scheduleWCF");
            _scheduleUserWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Schedule_user>("schedule_userWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            #endregion
        }

        //
        // GET: /OA/Schedule/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DefaultLayout()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            CommonService.Model.OA.O_Schedule schedule = new CommonService.Model.OA.O_Schedule();
            schedule.O_Schedule_code = Guid.NewGuid();
            schedule.O_Schedule_creator = Context.UIContext.Current.RootUserCode;
            schedule.O_Schedule_isDelete = false;
            schedule.O_Schedule_endShiJian = "";
            schedule.O_Schedule_startShiJian = "";
            schedule.O_Schedule_isAllDay = true;
            schedule.O_Schedule_isRepeat = false;
            schedule.O_Schedule_startRiQi = DateTime.Now.ToString("yyyy-MM-dd");
            schedule.O_Schedule_endRiQi = DateTime.Now.ToString("yyyy-MM-dd");

            InitializationPageParameter();
            this.SetAllJoiners();
            ViewBag.ScheduleUsers = Context.UIContext.Current.RootUserCode.ToString();//默认参与人，赋值为当前登录人

            return View(schedule);
        }

        /// <summary>
        /// 通过指定日期创建日程
        /// </summary>
        /// <param name="datepara">指定日期</param>
        /// <returns></returns>
        public ActionResult CreateByDate(string datepara, string calendarid)
        {
            DateTime setDate = DateTime.Parse(datepara);

            CommonService.Model.OA.O_Schedule schedule = new CommonService.Model.OA.O_Schedule();
            schedule.O_Schedule_code = Guid.NewGuid();
            schedule.O_Schedule_creator = Context.UIContext.Current.RootUserCode;
            schedule.O_Schedule_isDelete = false;
            schedule.O_Schedule_isAllDay = true;
            schedule.O_Schedule_isRepeat = false;
            schedule.O_Schedule_startRiQi = setDate.ToString("yyyy-MM-dd");
            schedule.O_Schedule_endRiQi = setDate.ToString("yyyy-MM-dd");
            schedule.O_Schedule_startShiJian = setDate.Hour + ":" + setDate.Minute;
            schedule.O_Schedule_endShiJian = setDate.Hour + ":" + setDate.Minute;
            schedule.O_Schedule_calendarid = calendarid;
            InitializationPageParameter();
            this.SetAllJoiners();
            ViewBag.ScheduleUsers = Context.UIContext.Current.RootUserCode.ToString();//默认参与人，赋值为当前登录人

            return View("Create", schedule);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        /// <returns></returns>
        public ActionResult Edit(string scheduleCode)
        {
            CommonService.Model.OA.O_Schedule schedule = _scheduleWCF.GetModel(new Guid(scheduleCode));

            #region 如果日程为部门日程，则跳转到详细Action
            if (schedule.O_Schedule_creator != Context.UIContext.Current.RootUserCode)
            {
                return RedirectToAction("Details", new { scheduleCode = scheduleCode });
            }
            #endregion

            //重新设置日期
            schedule.O_Schedule_startRiQi = schedule.O_Schedule_startTime.Value.ToString("yyyy-MM-dd");
            schedule.O_Schedule_endRiQi = schedule.O_Schedule_endTime.Value.ToString("yyyy-MM-dd");
            if (!schedule.O_Schedule_isAllDay)
            {//非全天事件，则设置对应时间
                schedule.O_Schedule_startShiJian = schedule.O_Schedule_startTime.Value.Hour + ":" + schedule.O_Schedule_startTime.Value.Minute;
                schedule.O_Schedule_endShiJian = schedule.O_Schedule_endTime.Value.Hour + ":" + schedule.O_Schedule_endTime.Value.Minute;
            }

            InitializationPageParameter();
            this.SetAllJoiners();
            this.SetScheduleUser(new Guid(scheduleCode));

            return View("Create", schedule);
        }

        /// <summary>
        /// 日程时间拖动实时保存Action
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        /// <param name="daydiff">天数差</param>
        /// <param name="millidiff">毫秒差</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Drop(string scheduleCode, string daydiff, string millidiff)
        {
            Dictionary<string, string> jsonData = new Dictionary<string, string>();
            jsonData.Add("calendarId", "calendar_schedule");//日历控件Id
            CommonService.Model.OA.O_Schedule schedule = _scheduleWCF.GetModel(new Guid(scheduleCode));

            #region 加入限制，如果创建人用当前登录人不一致时，不允许执行拖动实时保存
            if (schedule.O_Schedule_creator != Context.UIContext.Current.RootUserCode)
            {
                jsonData.Add("isSuccess", "0");//失败
                return Json(jsonData);
            }
            #endregion

            double daydiffDouble = Convert.ToDouble(daydiff) * 24 * 60 * 60;//天数转化为妙
            double milldiffDouble = Convert.ToDouble(millidiff) / 1000;//毫秒转化为妙

            double diffTimeDouble = daydiffDouble + milldiffDouble;
            schedule.O_Schedule_startTime = schedule.O_Schedule_startTime.Value.AddSeconds(diffTimeDouble);
            schedule.O_Schedule_endTime = schedule.O_Schedule_endTime.Value.AddSeconds(diffTimeDouble);

            bool isSuccess = _scheduleWCF.Update(schedule);

            if (isSuccess)
            {
                MSMQ.SendScheduleMessage();//发送日程消息
                jsonData.Add("isSuccess", "1");//成功
            }
            else
            {
                jsonData.Add("isSuccess", "0");//失败
            }

            return Json(jsonData);
        }

        /// <summary>
        /// 日程时间缩放实时保存Action
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        /// <param name="daydiff">天数差</param>
        /// <param name="millidiff">毫秒差</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Resize(string scheduleCode, string daydiff, string millidiff)
        {
            Dictionary<string, string> jsonData = new Dictionary<string, string>();
            jsonData.Add("calendarId", "calendar_schedule");//日历控件Id
            CommonService.Model.OA.O_Schedule schedule = _scheduleWCF.GetModel(new Guid(scheduleCode));

            #region 加入限制，如果创建人用当前登录人不一致时，不允许执行缩放实时保存
            if (schedule.O_Schedule_creator != Context.UIContext.Current.RootUserCode)
            {
                jsonData.Add("isSuccess", "0");//失败
                return Json(jsonData);
            }
            #endregion

            double daydiffDouble = Convert.ToDouble(daydiff) * 24 * 60 * 60;//天数转化为妙
            double milldiffDouble = Convert.ToDouble(millidiff) / 1000;//毫秒转化为妙

            double diffTimeDouble = daydiffDouble + milldiffDouble;
            schedule.O_Schedule_endTime = schedule.O_Schedule_endTime.Value.AddSeconds(diffTimeDouble);

            bool isSuccess = _scheduleWCF.Update(schedule);

            if (isSuccess)
            {
                MSMQ.SendScheduleMessage();//发送日程消息
                jsonData.Add("isSuccess", "1");//成功
            }
            else
            {
                jsonData.Add("isSuccess", "0");//失败
            }

            return Json(jsonData);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string scheduleCode, string msgID)
        {
            CommonService.Model.OA.O_Schedule schedule = _scheduleWCF.GetModel(new Guid(scheduleCode));
            //提醒类型名称
            if (schedule.O_Schedule_remindType != null)
                schedule.O_Schedule_remindTypename = _parameterWCF.GetModel(Convert.ToInt32(schedule.O_Schedule_remindType)).C_Parameters_name;
            else
                schedule.O_Schedule_remindTypename = String.Empty;
            //重复类型名称
            if (schedule.O_Schedule_repeatType != null)
                schedule.O_Schedule_repeatTypename = _parameterWCF.GetModel(Convert.ToInt32(schedule.O_Schedule_repeatType)).C_Parameters_name;
            else
                schedule.O_Schedule_repeatTypename = String.Empty;
            //结束条件名称
            if (schedule.O_Schedule_endCondition != null)
                schedule.O_Schedule_endConditionname = _parameterWCF.GetModel(Convert.ToInt32(schedule.O_Schedule_endCondition)).C_Parameters_name;
            else
                schedule.O_Schedule_endConditionname = String.Empty;
            //参与人
            List<CommonService.Model.OA.O_Schedule_user> userlists = _scheduleUserWCF.GetUserList(new Guid(scheduleCode));
            foreach (var item in userlists)
            {
                schedule.C_Userinfo_name = schedule.C_Userinfo_name + item.C_Userinfo_name + ',';
            }
            if (!String.IsNullOrEmpty(schedule.C_Userinfo_name))
            {
                schedule.C_Userinfo_name = schedule.C_Userinfo_name.Substring(0, schedule.C_Userinfo_name.Length - 1);
            }
            if (!string.IsNullOrEmpty(msgID))
            {
                CommonService.Model.C_Messages msgModel = _messageWCF.GetModel(Convert.ToInt32(msgID));//得到此条日程的提醒消息实体
                if (msgModel != null)
                { //存在此条日程的消息提醒
                    if (msgModel.C_Messages_isRead == 0)
                    {
                        msgModel.C_Messages_isRead = 1;
                        _messageWCF.Update(msgModel);
                    }
                }
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == msgModel.C_Messages_person.ToString());//查询消息人信息
                context.Clients.Client(touser.ConnectionId).removeScheduleSubMsg(msgID);//接收消息人的数据集合
            }
            return View(schedule);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string scheduleCode)
        {
            bool isSuccess = _scheduleWCF.Delete(new Guid(scheduleCode));
            if (isSuccess)
            {//删除关联日程用户
                _scheduleUserWCF.DeleteByScheduleCode(new Guid(scheduleCode));
            }
            if (isSuccess)
            {//成功(这里可以给一个日历的id，目的是操作日历后，刷新日历)(日历Id + 弹出Dialog Id)
                MSMQ.SendScheduleMessage();//发送日程消息
                return Json(TipHelper.JsonData("删除日程信息成功！", "calendar_schedule|baseLargeModal", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除日程信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 异步加载日程事件数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCalendarEventData()
        {
            DateTime start = new DateTime(1970, 1, 1);
            DateTime end = new DateTime(1970, 1, 1);

            // start = start.AddSeconds(double.Parse(Request["start"]));
            //  end = end.AddSeconds(double.Parse(Request["end"]));

            List<CommonService.Model.OA.O_Schedule> Schedules = _scheduleWCF.GetListByRootUserCode(Context.UIContext.Current.RootUserCode.Value);
            var calendarEvents = from e in Schedules
                                 select new
                                 {
                                     id = e.O_Schedule_code,
                                     title = e.O_Schedule_title,
                                     start = e.O_Schedule_startTime.Value.ToString("s"),
                                     end = e.O_Schedule_isAllDay ? e.O_Schedule_endTime.Value.AddDays(1).ToString("s") : e.O_Schedule_endTime.Value.ToString("s"),
                                     allDay = e.O_Schedule_isAllDay,
                                     backgroundColor = e.ScheduleBelongType == 1 ? "#9b59b6" : "#1bbc9b"//个人日程和部门日程设置不同的事件背景色
                                 };

            var calendarJsonDatas = calendarEvents.ToArray();
            return Json(calendarJsonDatas, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.OA.O_Schedule schedule)
        {
            DateTime now = DateTime.Now;
            schedule.O_Schedule_createTime = now;

            #region 保存时，重新处理相关数据
            if (schedule.O_Schedule_isAllDay)
            {//全天事件
                schedule.O_Schedule_startTime = DateTime.Parse(schedule.O_Schedule_startRiQi);
                schedule.O_Schedule_endTime = DateTime.Parse(schedule.O_Schedule_endRiQi);
            }
            else
            {//非全天事件
                schedule.O_Schedule_startTime = DateTime.Parse(schedule.O_Schedule_startRiQi + " " + schedule.O_Schedule_startShiJian);
                schedule.O_Schedule_endTime = DateTime.Parse(schedule.O_Schedule_endRiQi + " " + schedule.O_Schedule_endShiJian);
            }
            if (schedule.O_Schedule_isRepeat)
            {//重复事件
                if (schedule.O_Schedule_endCondition == Convert.ToInt32(EndConditionEnum.永不结束))
                {
                    schedule.O_Schedule_endRepeatDate = null;
                }
            }
            else
            {//非重复事件
                schedule.O_Schedule_repeatType = null;
                schedule.O_Schedule_endCondition = null;
                schedule.O_Schedule_endCondition = null;
            }
            #endregion

            #region 日程用户处理
            string joiners = form["hd_joiners"];
            List<CommonService.Model.OA.O_Schedule_user> scheduleUsers = new List<CommonService.Model.OA.O_Schedule_user>();
            if (!String.IsNullOrEmpty(joiners))
            {
                string[] joinerGroup = joiners.Split(',');
                for (int i = 0; i < joinerGroup.Length; i++)
                {
                    CommonService.Model.OA.O_Schedule_user user = new CommonService.Model.OA.O_Schedule_user();
                    user.O_Schedule_code = schedule.O_Schedule_code;
                    user.C_userinfo_code = new Guid(joinerGroup[i]);
                    user.O_Schedule_creator = Context.UIContext.Current.RootUserCode;
                    user.O_Schedule_createTime = now;
                    user.O_Schedule_isDelete = false;

                    scheduleUsers.Add(user);
                }
            }
            #endregion

            //服务方法调用
            bool isSuccess = false;
            if (schedule.O_Schedule_id > 0)
            {//修改
                isSuccess = _scheduleWCF.UpdateHeadAndItems(schedule, scheduleUsers);
            }
            else
            {//添加

                isSuccess = _scheduleWCF.AddHeadAndItems(schedule, scheduleUsers);
            }

            if (isSuccess)
            {
                MSMQ.SendScheduleMessage();//发送日程消息
                //表单提交成功固定写法(日历 id + 模式 dialog id)
                /*
                 * description:日程这个页面比较特殊，因为它不是列表形式，所以这里要在对应ajaxdone.js里单独处理，来刷新日历,并且日历插件 Id 应该以 "calendar_" 字符串开头
                 * author:hety
                 * date:2015-07-30
                 **/
                if (schedule.O_Schedule_calendarid == "calendar_schedule")
                    return Json(TipHelper.JsonData("保存日程信息成功！", "calendar_schedule|baseLargeModal", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshThisPage));
                else
                    return Json(TipHelper.JsonData("保存日程信息成功！", "calendar_schedule2|baseLargeModal", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshThisPage));
            }
            else
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("保存日程信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }


        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //提醒类型参数集合
            List<CommonService.Model.C_Parameters> remindTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ScheduleEnum.提醒类型));
            ViewBag.RemindTypes = remindTypes;
            //结束条件参数集合
            List<CommonService.Model.C_Parameters> endConditions = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ScheduleEnum.结束条件));
            ViewBag.EndConditions = endConditions;
            //重复类型参数集合
            List<CommonService.Model.C_Parameters> repeatTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ScheduleEnum.重复类型));
            ViewBag.RepeatTypes = repeatTypes;

        }

        /// <summary>
        /// 修改时，设置已关联日程用户
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        private void SetScheduleUser(Guid scheduleCode)
        {
            string scheduleUsersStr = "";
            List<CommonService.Model.OA.O_Schedule_user> scheduleUsers = _scheduleUserWCF.GetScheduleUsersByScheduleCode(scheduleCode);
            foreach (var user in scheduleUsers)
            {
                scheduleUsersStr += user.C_userinfo_code.Value.ToString() + ",";
            }
            if (scheduleUsersStr != "")
            {
                scheduleUsersStr = scheduleUsersStr.Substring(0, scheduleUsersStr.Length - 1);
            }
            ViewBag.ScheduleUsers = scheduleUsersStr;
        }

        /// <summary>
        /// 设置全部参与人
        /// </summary>
        private void SetAllJoiners()
        {
            List<CommonService.Model.SysManager.C_Userinfo> userLists = _userinfoWCF.GetParentList();
            string userHtml = "";
            foreach (var user in userLists)
            {
                userHtml += "<option value=" + user.C_Userinfo_code + ">" + user.C_Userinfo_name + "</option>";
            }
            ViewBag.userhtml = userHtml;
        }
    }
}