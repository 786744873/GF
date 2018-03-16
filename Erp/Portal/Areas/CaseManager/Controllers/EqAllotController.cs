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
    /// 案件--涉案合同权益分配控制器
    /// 作者:崔慧栋
    /// 日期:2015/06/04
    /// </summary>
    public class EqAllotController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_EqAllot _eqAllotWCF;
        public EqAllotController()
        {
            #region 服务初始化
            _eqAllotWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_EqAllot>("EqAllotWCF");
            #endregion
        }
        //
        // GET: /CaseManager/EqAllot/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(string caseCode, int B_EqAllot_pright)
        {
            //创建初始化实体
            CommonService.Model.CaseManager.B_EqAllot eqallot = _eqAllotWCF.GetModel(new Guid(caseCode), B_EqAllot_pright);
            if(eqallot.B_EqAllot_code==null)
            {
                eqallot.B_EqAllot_code = Guid.NewGuid();
                eqallot.B_Case_code = new Guid(caseCode);
                eqallot.B_EqAllot_isDelete = 0;
                eqallot.B_EqAllot_creator = Context.UIContext.Current.UserCode;
                eqallot.B_EqAllot_createTime = DateTime.Now;
            }
            return View(eqallot);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,string caseCode,int type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //权益分配查询模型
            CommonService.Model.CaseManager.B_EqAllot Conditon = new CommonService.Model.CaseManager.B_EqAllot();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            Conditon.B_EqAllot_relationid = 1;
            //权益分配查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion
            this.AddressUrlParameters = "?caseCode=" + caseCode+"&type="+type;
            //获取权益分配记录数
            this.TotalRecordCount = _eqAllotWCF.GetRecordCount(Conditon,type);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取权益分配数据信息
            List<CommonService.Model.CaseManager.B_EqAllot> banks = _eqAllotWCF.GetListByPage(Conditon,
                "C_Parameters_id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize,type);

            return View(banks);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string caseCode, int type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.CaseManager.B_EqAllot Conditon = new CommonService.Model.CaseManager.B_EqAllot();

            if (!String.IsNullOrEmpty(caseCode))
            {//案件GUID查询条件
                Conditon.B_Case_code = new Guid(caseCode);
            }
            Conditon.B_EqAllot_relationid = 1;
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion
            this.AddressUrlParameters = "?caseCode=" + caseCode;
            //获取总记录数
            this.TotalRecordCount = _eqAllotWCF.GetRecordCount(Conditon,type);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CaseManager.B_EqAllot> change = _eqAllotWCF.GetListByPage(Conditon,
                "C_Parameters_id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize,type);

            return View(change);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_EqAllot eqallot)
        {
            int caseId = 0;
            if (eqallot.B_EqAllot_id > 0)
            {//修改
                bool isUpdateSuccess = _eqAllotWCF.Update(eqallot);
                if (isUpdateSuccess)
                {
                    caseId = eqallot.B_EqAllot_id;
                }
            }
            else
            {//新增
                caseId = _eqAllotWCF.Add(eqallot);
            }

            if (caseId > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存权益分配信息成功", "", IsAlertTip.No,TipType.Success,AlertTipPageType.ThisPage,OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存权益分配信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}