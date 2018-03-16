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
    /// 财产线索房产控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
    public class Property_trail_estateController : BaseController
    {
        private readonly ICommonService.IC_Property_trail_estate _property_trail_estateWCF;

         public Property_trail_estateController()
        {
            #region 服务初始化
            _property_trail_estateWCF = ServiceProxyFactory.Create<ICommonService.IC_Property_trail_estate>("Property_trail_estateWCF");
            #endregion
        }
        //
        // GET: /BaseData/Property_trail_estate/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string property_trail_estate_belongs, int? property_trail_estate_type)
        {
            //创建初始化财产线索房产实体
            CommonService.Model.C_Property_trail_estate estate = new CommonService.Model.C_Property_trail_estate();
            if (property_trail_estate_type != null)
            {
                estate.C_Property_trail_estate_type = property_trail_estate_type;
            }
            if (!String.IsNullOrEmpty(property_trail_estate_belongs))
            {
                estate.C_Property_trail_estate_belongs = new Guid(property_trail_estate_belongs);
            }
            estate.C_Property_trail_estate_code = "";
            estate.C_Property_trail_estate_creator = Context.UIContext.Current.UserCode;
            estate.C_Property_trail_estate_createTime = DateTime.Now;
            estate.C_Property_trail_estate_isDelete = 0;

            return View(estate);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int property_trail_estate_id)
        {
            CommonService.Model.C_Property_trail_estate estate = _property_trail_estateWCF.GetModel(property_trail_estate_id);
            return View("Create", estate);
        }

        public ActionResult List(FormCollection form, string property_trail_estate_belongs, int? property_trail_estate_type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //财产线索房产查询模型
            CommonService.Model.C_Property_trail_estate estateConditon = new CommonService.Model.C_Property_trail_estate();

            if (!String.IsNullOrEmpty(property_trail_estate_belongs))
            {//财产线索房产所属查询条件
                estateConditon.C_Property_trail_estate_belongs = new Guid(property_trail_estate_belongs);
            }
            if (property_trail_estate_type != null)
            {//财产线索房产所属查询条件
                estateConditon.C_Property_trail_estate_type = property_trail_estate_type;
            }

            //财产线索房产索查询模型传递到前端视图中
            ViewBag.EstateConditon = estateConditon;

            #endregion

            //获取财产线索房产总记录数
            this.TotalRecordCount = _property_trail_estateWCF.GetRecordCount(estateConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 9;


            List<CommonService.Model.C_Property_trail_estate> crival = _property_trail_estateWCF.GetListByPage(estateConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string property_trail_estate_belongs, int? property_trail_estate_type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //财产线索房产查询模型
            CommonService.Model.C_Property_trail_estate estateConditon = new CommonService.Model.C_Property_trail_estate();

            if (!String.IsNullOrEmpty(property_trail_estate_belongs))
            {//财产线索房产所属查询条件
                estateConditon.C_Property_trail_estate_belongs = new Guid(property_trail_estate_belongs);
            }
            if (property_trail_estate_type != null)
            {//财产线索房产所属查询条件
                estateConditon.C_Property_trail_estate_type = property_trail_estate_type;
            }

            this.AddressUrlParameters = "?property_trail_estate_belongs=" + property_trail_estate_belongs + "&property_trail_estate_type=" + property_trail_estate_type;
            //财产线索房产索查询模型传递到前端视图中
            ViewBag.EstateConditon = estateConditon;

            #endregion

            //获取财产线索房产总记录数
            this.TotalRecordCount = _property_trail_estateWCF.GetRecordCount(estateConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 8;

            //获取财产线索房产数据信息
            List<CommonService.Model.C_Property_trail_estate> car = _property_trail_estateWCF.GetListByPage(estateConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(car);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Property_trail_estate estate)
        {
            //服务方法调用
            int estateId = 0;

            if (estate.C_Property_trail_estate_id > 0)
            {//修改
                bool isUpdateSuccess = _property_trail_estateWCF.Update(estate);
                if (isUpdateSuccess)
                {
                    estateId = estate.C_Property_trail_estate_id;
                }
            }
            else
            {//添加
                estate.C_Property_trail_estate_createTime = DateTime.Now;
                estateId = _property_trail_estateWCF.Add(estate);
            }

            if (estateId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存房产信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存房产信息成功", "/basedata/Property_trail_estate/create?property_trail_estate_belongs="+estate.C_Property_trail_estate_belongs+"&property_trail_estate_type="+estate.C_Property_trail_estate_type, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存房产信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存房产信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int property_trail_estate_id)
        {
            bool isSuccess = _property_trail_estateWCF.Delete(property_trail_estate_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除房产信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除房产信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}