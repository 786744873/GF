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
    /// 案件--收款明细控制器
    /// 作者:崔慧栋
    /// 日期:2015/06/06
    /// </summary>
    public class RDetailController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_RDetail _rdetailWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public RDetailController()
        {
            #region 服务初始化
            _rdetailWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_RDetail>("RDetailWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /CaseManager/RDetail/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string caseCode,int type)
        {
            CommonService.Model.C_Parameters par = _rdetailWCF.GetModelByCaseCode(new Guid(caseCode), type);
            InitializationPageParameter(par.C_Parameters_id);

            //创建初始化收款明细实体
            CommonService.Model.CaseManager.B_RDetail oppint = new CommonService.Model.CaseManager.B_RDetail();
            oppint.B_RDetail_code = Guid.NewGuid();
            if (!String.IsNullOrEmpty(caseCode))
            {
                oppint.B_Case_code = new Guid(caseCode);
            }
            oppint.B_RDetail_isDelete = 0;
            oppint.B_RDetail_creator = Context.UIContext.Current.UserCode;
            oppint.B_RDetail_createTime = DateTime.Now;

            return View(oppint);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int rdetailId, string caseCode,int type)
        {
            CommonService.Model.C_Parameters par = _rdetailWCF.GetModelByCaseCode(new Guid(caseCode),type);
            InitializationPageParameter(par.C_Parameters_id);
            CommonService.Model.CaseManager.B_RDetail oppint = _rdetailWCF.GetModel(rdetailId);
            return View("Create", oppint);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string caseCode,int type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            CommonService.Model.C_Parameters par = _rdetailWCF.GetModelByCaseCode(new Guid(caseCode),type);
            InitializationPageParameter(par.C_Parameters_id);

            //查询模型
            CommonService.Model.CaseManager.B_RDetail Conditon = new CommonService.Model.CaseManager.B_RDetail();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;
            ViewBag.Type = type;

            #endregion

            this.AddressUrlParameters="?caseCode="+caseCode;

            //获取总记录数
            this.TotalRecordCount = _rdetailWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CaseManager.B_RDetail> oppints = _rdetailWCF.GetListByPage(Conditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(oppints);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string caseCode,int type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            CommonService.Model.C_Parameters par = _rdetailWCF.GetModelByCaseCode(new Guid(caseCode),type);
            InitializationPageParameter(par.C_Parameters_id);

            //银行查询模型
            CommonService.Model.CaseManager.B_RDetail Conditon = new CommonService.Model.CaseManager.B_RDetail();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion

            this.AddressUrlParameters = "?caseCode=" + caseCode;

            //获取总记录数
            this.TotalRecordCount = _rdetailWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CaseManager.B_RDetail> change = _rdetailWCF.GetListByPage(Conditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(change);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_RDetail rdetail)
        {
            int rdetailId = 0;
            if (rdetail.B_RDetail_id > 0)
            {//修改
                bool isUpdateSuccess = _rdetailWCF.Update(rdetail);
                if (isUpdateSuccess)
                {
                    rdetailId = rdetail.B_RDetail_id;
                }
            }
            else
            {//新增
                rdetailId = _rdetailWCF.Add(rdetail);
            }

            if (rdetailId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存收款明细信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存收款明细信息成功", "/casemanager/rdetail/create?caseCode="+rdetail.B_Case_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存收款明细信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存收款明细信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int rdetailId)
        {
            bool isSuccess = _rdetailWCF.Delete(rdetailId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除收款明细信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除收款明细信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter(int C_Parameters_id)
        {
            //收款分类参数集合
            List<CommonService.Model.C_Parameters> RTypes = _parameterWCF.GetChildrenByParentId(C_Parameters_id);
            ViewBag.RTypes = RTypes;
            //付款方式参数集合
            List<CommonService.Model.C_Parameters> PTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(RDetailEnum.付款方式));
            ViewBag.PTypes = PTypes;
        }
	}
}