using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    /// <summary>
    /// 案件--费用承担控制器
    /// 作者:崔慧栋
    /// 日期:2015/06/05
    /// </summary>
    public class BearToPayController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_BearToPay _bearToPayWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public BearToPayController()
        {
            #region 服务初始化
            _bearToPayWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_BearToPay>("BearToPayWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /CaseManager/BearToPay/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(string caseCode, int B_BearToPay_ctypes)
        {
            InitializationPageParameter();
            //创建初始化实体
            CommonService.Model.CaseManager.B_BearToPay eqallot = _bearToPayWCF.GetModel(new Guid(caseCode), B_BearToPay_ctypes);
            if (eqallot.B_BearToPay_code == null)
            {
                eqallot.B_BearToPay_code = Guid.NewGuid();
                eqallot.B_Case_code = new Guid(caseCode);
                eqallot.B_BearToPay_isDelete = 0;
                eqallot.B_BearToPay_creator = Context.UIContext.Current.UserCode;
                eqallot.B_BearToPay_createTime = DateTime.Now;
            }
            return View(eqallot);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string caseCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //费用承担查询模型
            CommonService.Model.CaseManager.B_BearToPay Conditon = new CommonService.Model.CaseManager.B_BearToPay();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            Conditon.B_BearToPay_ctypes_id = Convert.ToInt32(BearToPayCtypesEnum.费用类型);
            //费用承担查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion
            this.AddressUrlParameters = "?caseCode=" + caseCode;
            //获取费用承担总记录数
            this.TotalRecordCount = _bearToPayWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取费用承担数据信息
            List<CommonService.Model.CaseManager.B_BearToPay> beartopay = _bearToPayWCF.GetListByPage(Conditon,
                "C_Parameters_id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(beartopay);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string caseCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.CaseManager.B_BearToPay Conditon = new CommonService.Model.CaseManager.B_BearToPay();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            Conditon.B_BearToPay_ctypes_id = Convert.ToInt32(BearToPayCtypesEnum.费用类型);
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion
            this.AddressUrlParameters = "?caseCode=" + caseCode;
            //获取总记录数
            this.TotalRecordCount = _bearToPayWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CaseManager.B_BearToPay> change = _bearToPayWCF.GetListByPage(Conditon,
                "C_Parameters_id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(change);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_BearToPay beartopay)
        {
            int beartopayId = 0;
            if (beartopay.B_BearToPay_id > 0)
            {//修改
                bool isUpdateSuccess = _bearToPayWCF.Update(beartopay);
                if (isUpdateSuccess)
                {
                    beartopayId = beartopay.B_BearToPay_id;
                }
            }
            else
            {//新增
                beartopayId = _bearToPayWCF.Add(beartopay);
            }

            if (beartopayId > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存费用承担信息成功", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存费用承担信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //支付方式参数集合
            List<CommonService.Model.C_Parameters> CTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(BearToPayEnum.支付方式));
            ViewBag.CTypes = CTypes;
        }
	}
}