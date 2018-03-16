using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 消息控制器
    /// </summary>
    public class MessageController : BaseController
    {
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.IC_Messages_Category _messagesCategoryWCF;

        public MessageController()
        {
            #region 服务初始化
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _messagesCategoryWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages_Category>("MessagesCategoryWCF");
            #endregion
        }

        //
        // GET: /BaseData/Message/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 消息tab布局
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails()
        {
            return View();
        }

        /// <summary>
        /// 消息小类型tab布局
        /// </summary>
        /// <param name="messageBigType">消息大类型</param>
        /// <returns></returns>
        public ActionResult CaseTabDetails(int messageBigType)
        {
            List<CommonService.Model.C_Messages_Category> C_Messages_Categorys = _messagesCategoryWCF.GetMessageHeads(messageBigType, 1,
                UIContext.Current.IsPreSetManager,UIContext.Current.UserCode);
            return View(C_Messages_Categorys);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="messageBigClass">消息大类</param>
        /// <param name="messageCategoryType">消息分类类型</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string messageBigClass, string messageCategoryType, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //消息查询模型
            CommonService.Model.C_Messages messageConditon = new CommonService.Model.C_Messages();
            //消息大类(url参数)
            if (!String.IsNullOrEmpty(messageBigClass))
            {
                messageConditon.C_Messages_fType = Convert.ToInt32(messageBigClass);
            }
            if (!String.IsNullOrEmpty(messageCategoryType))
            {
                messageConditon.C_Messages_Category_type = Convert.ToInt32(messageCategoryType);
            }
            if (messageConditon.C_Messages_fType != null)
            {//url参数到地址栏
                this.AddressUrlParameters = "?messageBigClass=" + messageConditon.C_Messages_fType;
            }
            if (messageConditon.C_Messages_Category_type!=null)
            {
                this.AddressUrlParameters += "&messageCategoryType=" + messageConditon.C_Messages_Category_type;
            }
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                messageConditon.C_Messages_person = Context.UIContext.Current.UserCode;
            }
            
            this.PageSize = 13;

            #endregion

            ViewBag.messageBigClass = messageBigClass;
            ViewBag.messagesCategoryType = messageCategoryType;
    
            //获取消息总记录数
            this.TotalRecordCount = _messageWCF.GetRecordCount(messageConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取消息数据信息
            List<CommonService.Model.C_Messages> Messages = _messageWCF.GetListByPage(messageConditon,
                "C_Messages_isRead Asc,C_Messages_createTime Desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(Messages);
        }


        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="messageBigType">消息大类型</param>        
        /// <returns></returns>
        public string viewlist_ByCount(string messageBigType)
        {

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //消息查询模型
            CommonService.Model.C_Messages messageConditon = new CommonService.Model.C_Messages();
            //消息大类
            if (!String.IsNullOrEmpty(messageBigType))
            {
                messageConditon.C_Messages_fType = Convert.ToInt32(messageBigType);
            }

            if (!UIContext.Current.IsPreSetManager)
            {
                messageConditon.C_Messages_person = Context.UIContext.Current.UserCode;
            }
            messageConditon.C_Messages_isRead = 0;

            #endregion

            //获取消息总记录数
            this.TotalRecordCount = _messageWCF.GetRecordCount(messageConditon);
            return TotalRecordCount.ToString();
        }

        /// <summary>
        /// 读消息
        /// </summary>
        /// <param name="messageId">消息Id</param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ReadMessage(int messageId)
        {
            bool isSuccess = false;
            if (!Context.UIContext.Current.IsPreSetManager)
            {//如果当前登录用户为内置系统管理员，则不允许读消息
                isSuccess = _messageWCF.ReadMessage(messageId);
            }
            return Content(isSuccess == true ? "1" : "0");
        }

    }
}