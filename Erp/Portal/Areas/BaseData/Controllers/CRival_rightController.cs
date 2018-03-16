﻿using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 对手权利关联表控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
    public class CRival_rightController : BaseController
    {
        private readonly ICommonService.IC_CRival_right _crival_rightWCF;

        public CRival_rightController()
        {
            #region 服务初始化
            _crival_rightWCF = ServiceProxyFactory.Create<ICommonService.IC_CRival_right>("CRival_rightWCF");
            #endregion
        }
        //
        // GET: /BaseData/CRival_right/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string crival_code)
        {
            //创建初始化权利关联实体
            CommonService.Model.C_CRival_right crival_change = new CommonService.Model.C_CRival_right();
            if (!String.IsNullOrEmpty(crival_code))
            {
                crival_change.C_CRival_code = new Guid(crival_code);
            }
            crival_change.C_CRival_right_isDelete = 0;
            crival_change.C_CRival_right_createTime = DateTime.Now;
            crival_change.C_CRival_right_creator = Context.UIContext.Current.UserCode;

            return View(crival_change);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int crivalrightID)
        {
            CommonService.Model.C_CRival_right crival = _crival_rightWCF.GetModel(crivalrightID);
            return View("Create", crival);
        }

        public ActionResult List(FormCollection form, string crival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //权利关联查询模型
            CommonService.Model.C_CRival_right crConditon = new CommonService.Model.C_CRival_right();
            if (!String.IsNullOrEmpty(crival_code))
            {//公司名称查询条件
                crConditon.C_CRival_code = new Guid(crival_code);
            }
            this.AddressUrlParameters = "?crival_code=" + crival_code;

            //权利关联查询模型传递到前端视图中
            ViewBag.CrRightConditon = crConditon;

            #endregion

            //获取权利关联总记录数
            this.TotalRecordCount = _crival_rightWCF.GetRecordCount(crConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;

            List<CommonService.Model.C_CRival_right> crival = _crival_rightWCF.GetListByPage(crConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string crival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //权利关联查询模型
            CommonService.Model.C_CRival_right rightConditon = new CommonService.Model.C_CRival_right();

            if (!String.IsNullOrEmpty(crival_code))
            {//公司名称查询条件
                rightConditon.C_CRival_code = new Guid(crival_code);
            }

            //权利关联查询模型传递到前端视图中
            ViewBag.CrRightConditon = rightConditon;

            #endregion

            //获取权利关联总记录数
            this.TotalRecordCount = _crival_rightWCF.GetRecordCount(rightConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取权利关联数据信息
            List<CommonService.Model.C_CRival_right> right = _crival_rightWCF.GetListByPage(rightConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(right);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_CRival_right crivalchange)
        {
            //服务方法调用
            int crivalId = 0;

            if (crivalchange.C_CRival_right_id > 0)
            {//修改
                bool isUpdateSuccess = _crival_rightWCF.Update(crivalchange);
                if (isUpdateSuccess)
                {
                    crivalId = crivalchange.C_CRival_right_id;
                }
            }
            else
            {//添加
                crivalchange.C_CRival_right_createTime = DateTime.Now;
                crivalId = _crival_rightWCF.Add(crivalchange);
            }

            if (crivalId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存权力关联信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存权力关联信息成功", "/basedata/CRival_right/create?crival_code="+crivalchange.C_CRival_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存权力关联信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存权力关联信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int crivalrightID)
        {
            bool isSuccess = _crival_rightWCF.Delete(crivalrightID);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除权力关联信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除权力关联信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}