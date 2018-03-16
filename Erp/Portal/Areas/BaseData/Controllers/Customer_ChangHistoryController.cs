using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 客户变更记录控制器
    /// </summary>
    public class Customer_ChangHistoryController : BaseController
    {
        private readonly ICommonService.IC_Customer_ChangHistory _customer_ChangHistoryWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        public Customer_ChangHistoryController()
        {
            #region 服务初始化
            _customer_ChangHistoryWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_ChangHistory>("Customer_ChangHistoryWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            #endregion
        }
        //
        // GET: /BaseData/Customer_ChangHistory/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="type">1、待审核 2、提交审核</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,int? type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer_ChangHistory customerConditon = new CommonService.Model.C_Customer_ChangHistory();

            if (!Context.UIContext.Current.IsPreSetManager)
            {
                if(type==1)
                {
                    customerConditon.C_Customer_ChangHistory_checkPerson = Context.UIContext.Current.UserCode;
                }else
                {
                    customerConditon.C_Customer_ChangHistory_submitPerson = Context.UIContext.Current.UserCode;
                }
            }
            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;
            ViewBag.type = type;
            #endregion

            this.AddressUrlParameters = "?type=" + type;
            //获取客户总记录数
            this.TotalRecordCount = _customer_ChangHistoryWCF.GetRecordCount(customerConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer_ChangHistory> customers = _customer_ChangHistoryWCF.GetListByPage(customerConditon,
                "C_Customer_ChangHistory_state Asc,T.C_Customer_ChangHistory_id desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(customers);
        }
        /// <summary>
        /// 审核变更数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckOpreate(string CustomerChangHistoryCode, int? stateId)
        {
            bool isSuccess = _customer_ChangHistoryWCF.CheckOpreate(CustomerChangHistoryCode,Context.UIContext.Current.UserCode.Value,stateId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("审核变更信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("审核变更信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 客户变更记录
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public ActionResult HistoryList(string customerCode)
        {
            List<CommonService.Model.C_Customer_ChangHistory> customerChangHistory = _customer_ChangHistoryWCF.GetListByCustomer(new Guid(customerCode));
            return View(customerChangHistory);
        }
	}
}