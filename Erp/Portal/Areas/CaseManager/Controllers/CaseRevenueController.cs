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
    /// 收入信息控制器
    /// 作者：崔慧栋
    /// 日期：2015/06/19
    /// </summary>
    public class CaseRevenueController : BaseController 
    {
        private readonly ICommonService.CaseManager.IB_CaseRevenue _caseRevenueWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
         public CaseRevenueController()
        {
            #region 服务初始化
            _caseRevenueWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_CaseRevenue>("CaseRevenueWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /CaseManager/CaseRevenue/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string caseCode)
        {
            InitializationPageParameter();
            //创建初始化实体
            CommonService.Model.CaseManager.B_CaseRevenue revenue = new CommonService.Model.CaseManager.B_CaseRevenue();
            revenue.B_CaseRevenue_code = Guid.NewGuid();
            if(!String.IsNullOrEmpty(caseCode))
            {
                revenue.B_Case_code = new Guid(caseCode);
            }
            revenue.B_CaseRevenue_isDelete = 0;
            revenue.B_CaseRevenue_creator = Context.UIContext.Current.UserCode;
            revenue.B_CaseRevenue_createTime = DateTime.Now;
            
            return View(revenue);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int B_CaseRevenue_id)
        {
            InitializationPageParameter();
            CommonService.Model.CaseManager.B_CaseRevenue revenue = _caseRevenueWCF.GetModel(B_CaseRevenue_id);
            return View("Create", revenue);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,string caseCode, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.CaseManager.B_CaseRevenue Conditon = new CommonService.Model.CaseManager.B_CaseRevenue();

            if(caseCode!=null)
            {//案件GUID
                Conditon.B_Case_code = new Guid(caseCode);
            }
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion

            //获取总记录数
            this.TotalRecordCount = _caseRevenueWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CaseManager.B_CaseRevenue> revenue = _caseRevenueWCF.GetListByPage(Conditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(revenue);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_CaseRevenue revenue)
        {
            int revenueId = 0;

            if (revenue.B_CaseRevenue_id > 0)
            {//修改
                bool isUpdateSuccess = _caseRevenueWCF.Update(revenue);
                if (isUpdateSuccess)
                {
                    revenueId = revenue.B_CaseRevenue_id;
                }
            }
            else
            {//新增
                revenueId = _caseRevenueWCF.Add(revenue);
            }

            if (revenueId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存案件收入信息成功", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存案件收入信息成功", "/casemanager/caserevenue/create?caseCode="+revenue.B_Case_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存案件收入信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存案件收入信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int B_CaseRevenue_id)
        {
            bool isSuccess = _caseRevenueWCF.Delete(B_CaseRevenue_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除案件收入信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除案件收入信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //案件收入类型参数集合
            List<CommonService.Model.C_Parameters> CaseRevenuetype = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseRevenuelEnum.收入类型));
            ViewBag.CaseRevenuetype = CaseRevenuetype;
        }
	}
}