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
    /// 成本信息控制器
    /// 作者：崔慧栋
    /// 日期：2015/06/23
    /// </summary>
    public class CaseCostController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_CaseCost _caseCostWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public CaseCostController()
        {
            #region 服务初始化
            _caseCostWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_CaseCost>("CaseCostWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /CaseManager/CaseCost/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(string caseCode, int B_CaseCost_type)
        {
            //创建初始化实体
            CommonService.Model.CaseManager.B_CaseCost cost = _caseCostWCF.GetModel(new Guid(caseCode), B_CaseCost_type);
            if (cost.B_CaseCost_code == null)
            {
                cost.B_CaseCost_code = Guid.NewGuid();
                cost.B_Case_code = new Guid(caseCode);
                cost.B_CaseCost_isDelete = 0;
                cost.B_CaseCost_creator = Context.UIContext.Current.UserCode;
                cost.B_CaseCost_createTime = DateTime.Now;
            }
            return View(cost);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string caseCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //权益分配查询模型
            CommonService.Model.CaseManager.B_CaseCost Conditon = new CommonService.Model.CaseManager.B_CaseCost();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            //权益分配查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;
            Conditon.B_CaseCost_type_id = 366;
            #endregion
            this.AddressUrlParameters = "?caseCode=" + caseCode;
            //获取权益分配记录数
            this.TotalRecordCount = _caseCostWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取权益分配数据信息
            List<CommonService.Model.CaseManager.B_CaseCost> costs = _caseCostWCF.GetListByPage(Conditon,
                "C_Parameters_id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(costs);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string caseCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.CaseManager.B_CaseCost Conditon = new CommonService.Model.CaseManager.B_CaseCost();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion
            this.AddressUrlParameters = "?caseCode=" + caseCode;
            //获取总记录数
            this.TotalRecordCount = _caseCostWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CaseManager.B_CaseCost> change = _caseCostWCF.GetListByPage(Conditon,
                "C_Parameters_id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(change);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_CaseCost cost)
        {
            int costId = 0;
            if (cost.B_CaseCost_id > 0)
            {//修改
                bool isUpdateSuccess = _caseCostWCF.Update(cost);
                if (isUpdateSuccess)
                {
                    costId = cost.B_CaseCost_id;
                }
            }
            else
            {//新增
                costId = _caseCostWCF.Add(cost);
            }

            if (costId > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存案件成本信息成功", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存案件成本信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}