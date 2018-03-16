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
    /// 案件--担保物约定控制器
    /// 作者:崔慧栋
    /// 日期:2015/06/06
    /// </summary>
    public class OppintController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_Oppint _oppintWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
         public OppintController()
        {
            #region 服务初始化
            _oppintWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Oppint>("OppintWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /CaseManager/Oppint/
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
            //创建初始化担保物约定实体
            CommonService.Model.CaseManager.B_Oppint oppint = new CommonService.Model.CaseManager.B_Oppint();
            oppint.B_Oppint_code = Guid.NewGuid();
            if(!String.IsNullOrEmpty(caseCode))
            {
                oppint.B_Case_code =new Guid(caseCode);
            }
            oppint.B_Oppint_isDelete = 0;
            oppint.B_Oppint_creator = Context.UIContext.Current.UserCode;
            oppint.B_Oppint_createTime = DateTime.Now;

            return View(oppint);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int oppintId)
        {
            InitializationPageParameter();
            CommonService.Model.CaseManager.B_Oppint oppint = _oppintWCF.GetModel(oppintId);
            return View("Create", oppint);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,string caseCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.CaseManager.B_Oppint Conditon = new CommonService.Model.CaseManager.B_Oppint();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion

            //获取总记录数
            this.TotalRecordCount = _oppintWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CaseManager.B_Oppint> oppints = _oppintWCF.GetListByPage(Conditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(oppints);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string caseCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //银行查询模型
            CommonService.Model.CaseManager.B_Oppint Conditon = new CommonService.Model.CaseManager.B_Oppint();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion
            
            //获取总记录数
            this.TotalRecordCount = _oppintWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CaseManager.B_Oppint> change = _oppintWCF.GetListByPage(Conditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(change);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_Oppint oppint)
        {
            int oppintId = 0;
            if (oppint.B_Oppint_id > 0)
            {//修改
                bool isUpdateSuccess = _oppintWCF.Update(oppint);
                if (isUpdateSuccess)
                {
                    oppintId = oppint.B_Oppint_id;
                }
            }
            else
            {//新增
                oppintId = _oppintWCF.Add(oppint);
            }

            if (oppintId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存担保物约定信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存担保物约定信息成功", "/casemanager/oppint/create?caseCode="+oppint.B_Case_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存担保物约定信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存担保物约定信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int oppintId)
        {
            bool isSuccess = _oppintWCF.Delete(oppintId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除担保物约定信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除担保物约定信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Guarantys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(OppintEnum.担保物));
            ViewBag.Guarantys = Guarantys;
        }
	}
}