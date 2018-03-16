using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly ICommonService.OA.IO_Article _articleWCF;
        private readonly ICommonService.OA.IO_Email_user _emailUserWCF;
        private readonly ICommonService.OA.IO_Form_AuditFlow _oformAuditFlowWCF;
        //
        // GET: /OA/Dashboard/
        public DashboardController()
        {
            #region 服务初始化
            _articleWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Article>("articleWCF");
            _emailUserWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Email_user>("email_userWCF");
            _oformAuditFlowWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form_AuditFlow>("oForm_AuditFlowWCF");
            #endregion
        }
        public override ActionResult Index()
        {
            return View();
        }



        public ActionResult DefaultLayout()
        {
            return View();
        }

        /// <summary>
        /// 导航Action(主要用于ERP请求过来的导航处理，即异步加载对应的页面)
        /// </summary>
        /// <returns></returns>
        public ActionResult Navigation()
        {
            string id = Request["id"];
            string nav = Request["nav"];

            ViewBag.Id = id;
            ViewBag.Nav = nav;

            return View();
        }
        /// <summary>
        /// 通知公告---局部视图
        /// </summary>
        /// <returns></returns>
        public PartialViewResult PartArticleList()
        {
            CommonService.Model.OA.O_Article articleConditon = new CommonService.Model.OA.O_Article();
            articleConditon.C_Userinfo_code = Context.UIContext.Current.RootUserCode;//用户guid
            List<CommonService.Model.OA.O_Article> articles = _articleWCF.GetListByPage2(articleConditon,
            "O_Article_createTime Desc", 0, 1000);
            ViewBag.articles = articles;
            return PartialView();
        }
        /// <summary>
        /// 消息 ---局部视图(暂时只读取收件箱邮件)
        /// </summary>
        /// <returns></returns>
        public PartialViewResult PartMsgList()
        {
            CommonService.Model.OA.O_Email_user emailUserConditon = new CommonService.Model.OA.O_Email_user();
            emailUserConditon.O_Email_state = Convert.ToInt32(EmailStateEnum.已发送);
            emailUserConditon.O_Email_user_type = Convert.ToInt32(EmailSendTypeEnum.收件人);
            emailUserConditon.C_Userinfo_code = Context.UIContext.Current.RootUserCode;
            //List<CommonService.Model.OA.O_Email_user> emails = _emailUserWCF.GetListByUserCode(new Guid(emailUserConditon.C_Userinfo_code.ToString()));
            List<CommonService.Model.OA.O_Email_user> emails = _emailUserWCF.GetListByPage(emailUserConditon,"O_Email_createTime Desc", 0, 1000);
            ViewBag.emails = emails;
            return PartialView();
        }
        /// <summary>
        /// 日程 ---局部视图
        /// </summary>
        /// <returns></returns>
        public PartialViewResult PartScheduleList()
        {
            return PartialView();
        }
        /// <summary>
        /// 待办事项 ---局部视图
        /// </summary>
        /// <returns></returns>
        public PartialViewResult PartWeChatList()
        {
            List<CommonService.Model.OA.O_Form_AuditFlow> FAFLists = _oformAuditFlowWCF.GetListByuserCode(new Guid(Context.UIContext.Current.UserCode.ToString()));//获得登录人表单信息
            ViewBag.FAFLists = FAFLists;
            return PartialView();
        }
    }
}