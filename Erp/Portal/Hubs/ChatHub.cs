using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using CommonService.SysManager;
using Maticsoft.Common;
namespace Portal.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        public ChatHub()
        {
            #region 服务初始化
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            #endregion
        }
        //声明静态变量存储当前在线用户
        public class UserHandler
        {
            public string ConnectionId { get; set; }
            public string userCode { get; set; }
        }
        public static List<UserHandler> userlist = new List<UserHandler>();
        public void Send(string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(message);
        }
        /// <summary>
        /// 用户登录时向内存中添加用户信息
        /// </summary>
        /// <param name="userCode">用户guid</param>
        public void Connect(string userCode)
        {
            var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == userCode);
            if (touser == null)
                userlist.Add(new UserHandler { ConnectionId = Context.ConnectionId, userCode = userCode });
            else
            {
                userlist.Remove(userlist.FirstOrDefault(x => x.userCode == userCode));
                userlist.Add(new UserHandler { ConnectionId = Context.ConnectionId, userCode = userCode });
            }
        }
        /// <summary>
        /// 退出时删除
        /// </summary>
        /// <returns></returns>
        public override System.Threading.Tasks.Task OnDisconnected(bool flag)
        {
            var item = ChatHub.userlist.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ChatHub.userlist.Remove(item);
            }

            return base.OnDisconnected(true);
        }
        /// <summary>
        /// 邮件小提示数目
        /// </summary>
        /// <param name="ReceiveUser"></param>
        /// <param name="count"></param>
        public void SendEmailMsg(string ReceiveUser)
        {
            Clients.Caller.sendEmailMsg(ReceiveUser);
        }
    }
}