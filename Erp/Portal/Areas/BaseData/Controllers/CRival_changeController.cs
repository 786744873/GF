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
    /// 对手公司变更表控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/05
    /// </summary>
    public class CRival_changeController : BaseController
    {
        private readonly ICommonService.IC_CRival_change _crival_changeWCF;

        public CRival_changeController()
        {
            #region 服务初始化
            _crival_changeWCF = ServiceProxyFactory.Create<ICommonService.IC_CRival_change>("CRival_changeWCF");
            #endregion
        }
        //
        // GET: /BaseData/CRival_change/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string C_CRival_code)
        {
            //创建初始化公司变更实体
            CommonService.Model.C_CRival_change crival_change = new CommonService.Model.C_CRival_change();
            if (!String.IsNullOrEmpty(C_CRival_code))
            {
                crival_change.C_CRival_code =new Guid(C_CRival_code);
            }
            crival_change.C_CRival_change_date = DateTime.Now;
            crival_change.C_CRival_change_isDelete = 0;
            crival_change.C_CRival_change_createTime = DateTime.Now;
            crival_change.C_CRival_change_creator = Context.UIContext.Current.UserCode;

            return View(crival_change);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int crivalchangeID)
        {
            CommonService.Model.C_CRival_change crival = _crival_changeWCF.GetModel(crivalchangeID);
            return View("Create", crival);
        }

        public ActionResult List(FormCollection form,string C_CRival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //公司变更查询模型
            CommonService.Model.C_CRival_change crConditon = new CommonService.Model.C_CRival_change();
            if (!String.IsNullOrEmpty(C_CRival_code))
            {//公司名称查询条件
                crConditon.C_CRival_code =new Guid(C_CRival_code);
            }
            this.AddressUrlParameters = "?C_CRival_code=" + C_CRival_code;

            //公司变更模型传递到前端视图中
            ViewBag.CrChangeConditon = crConditon;

            #endregion

            //获取法律对手总记录数
            this.TotalRecordCount = _crival_changeWCF.GetRecordCount(crConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;

            List<CommonService.Model.C_CRival_change> crival = _crival_changeWCF.GetListByPage(crConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string C_CRival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_CRival_change changeConditon = new CommonService.Model.C_CRival_change();

            if (!String.IsNullOrEmpty(C_CRival_code))
            {//公司名称查询条件
                changeConditon.C_CRival_code = new Guid(C_CRival_code);
            }

            //公司变更模型传递到前端视图中
            ViewBag.CrChangeConditon = changeConditon;

            #endregion

            //获取公司变更总记录数
            this.TotalRecordCount = _crival_changeWCF.GetRecordCount(changeConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取公司变更数据信息
            List<CommonService.Model.C_CRival_change> change = _crival_changeWCF.GetListByPage(changeConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(change);
        }



        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_CRival_change crivalchange)
        {
            //服务方法调用
            int crivalId = 0;

            if (crivalchange.C_CRival_change_id > 0)
            {//修改
                bool isUpdateSuccess = _crival_changeWCF.Update(crivalchange);
                if (isUpdateSuccess)
                {
                    crivalId = crivalchange.C_CRival_change_id;
                }
            }
            else
            {//添加
                crivalchange.C_CRival_change_createTime = DateTime.Now;
                crivalId = _crival_changeWCF.Add(crivalchange);
            }

            if (crivalId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存公司变更信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存公司变更信息成功", "/basedata/CRival_change/create?C_CRival_code=" + crivalchange.C_CRival_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存公司变更信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存公司变更信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int crivalchangeID)
        {
            bool isSuccess = _crival_changeWCF.Delete(crivalchangeID);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除公司变更信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除公司变更信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}