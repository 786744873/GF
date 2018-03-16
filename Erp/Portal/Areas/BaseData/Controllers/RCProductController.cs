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
    /// 竞争对手_竞争产品表控制器
    /// 作者：崔慧栋
    /// 日期：2015/04/24
    /// </summary>
    public class RCProductController : BaseController
    {
        private readonly ICommonService.IC_RCProduct _rcproductWCF;

        public RCProductController()
        {
            #region 服务初始化
            _rcproductWCF = ServiceProxyFactory.Create<ICommonService.IC_RCProduct>("RCProductWCF");
            #endregion
        }
        //
        // GET: /BaseData/RCProduct/
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            //创建初始化竞争对手_竞争产品实体
            CommonService.Model.C_RCProduct rcproduct = new CommonService.Model.C_RCProduct();
            rcproduct.C_RCProduct_code = Guid.NewGuid();
            rcproduct.C_RCProduct_number = "";
            rcproduct.C_RCProduct_competitorCode = Guid.NewGuid();
            rcproduct.C_RCProduct_name = "";
            rcproduct.C_RCProduct_cTime = DateTime.Now;
            rcproduct.C_RCProduct_cUserID = Context.UIContext.Current.UserCode;
            rcproduct.C_RCProduct_isdelete = 0;
            
            return View(rcproduct);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int rcproductID)
        {
            CommonService.Model.C_RCProduct rcproduct = _rcproductWCF.GetModel(rcproductID);
            return View("Create", rcproduct);
        }

        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //竞争对手_竞争产品查询模型
            CommonService.Model.C_RCProduct rcpConditon = new CommonService.Model.C_RCProduct();

            if (!String.IsNullOrEmpty(form["C_RCProduct_name"]))
            {//产品名称查询条件
                rcpConditon.C_RCProduct_name = form["C_RCProduct_name"].Trim();
            }

            //竞争对手_竞争产品查询模型传递到前端视图中
            ViewBag.RcpConditon = rcpConditon;

            #endregion

            //获取竞争对手_竞争产品总记录数
            this.TotalRecordCount = _rcproductWCF.GetRecordCount(rcpConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_RCProduct> rcproduct = _rcproductWCF.GetListByPage(rcpConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(rcproduct);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_RCProduct rcproduct)
        {
            //服务方法调用
            int rcproductId = 0;
            if (rcproduct.C_RCProduct_id > 0)
            {//修改
                bool isUpdateSuccess = _rcproductWCF.Update(rcproduct);
                if (isUpdateSuccess)
                {
                    rcproductId = rcproduct.C_RCProduct_id;
                }
            }
            else
            {//添加
                rcproduct.C_RCProduct_cTime = DateTime.Now;
                rcproductId = _rcproductWCF.Add(rcproduct);
            } 
            
            if (rcproductId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存竞争对手_竞争产品信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存竞争对手_竞争产品信息成功", "/basedata/rcproduct/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存竞争对手_竞争产品信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存竞争对手_竞争产品信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int rcproductID)
        {
            bool isSuccess = _rcproductWCF.Delete(rcproductID);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除竞争对手_竞争产品信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除竞争对手_竞争产品信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}