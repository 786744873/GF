using CommonService.Common;
using Maticsoft.Common;
using Microsoft.AspNet.SignalR;
using Portal.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Portal.WebService
{
    /// <summary>
    /// OAWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://localhost:2695/WebService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class OAWebService : System.Web.Services.WebService
    {
        private readonly ICommonService.OA.IO_Schedule _scheduleWCF;
        public OAWebService()
        {
            #region 服务初始化
            _scheduleWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Schedule>("scheduleWCF");
            #endregion
        }
        /// <summary>
        /// 日程消息提醒接口
        /// </summary>
        /// <param name="scheduleCode"></param>
        /// <returns></returns>
        [WebMethod(Description="OA日程提醒接收")]
        public string OASchedule(string O_Schedule_code,string C_userinfo_code)
        {
            CommonService.Model.OA.O_Schedule model = _scheduleWCF.GetModel(new Guid(O_Schedule_code));
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == C_userinfo_code);//查询日程提醒人是否在线
            if (touser != null)
            {
                JsonHelper a=new JsonHelper();
                context.Clients.Client(touser.ConnectionId).sendScheduleMsg(a.EntityToJson(model));//接收消息人的数据集合
            }
            return "aa";
        }
    }
}
