using CommonService.Common;
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
    /// 实体控制器
    /// </summary>
    public class EntityController : BaseController
    {
        private readonly ICommonService.IC_Entity _entityWCF;
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;

        public EntityController()
        {
            #region 服务初始化
            _entityWCF = ServiceProxyFactory.Create<ICommonService.IC_Entity>("EntityWCF");
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            #endregion
        }

        //
        // GET: /BaseData/C_Entity/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 单一实体选择Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relationCode">关联Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleRefList(FormCollection form, string relationCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //参数查询模型
            CommonService.Model.C_Entity entityConditon = new CommonService.Model.C_Entity();

            if (!String.IsNullOrEmpty(form["C_Entity_showName"]))
            {//显示名称查询条件
                entityConditon.C_Entity_showName = form["C_Entity_showName"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["RelationCode"]))
            {//参数名称查询条件
                relationCode = form["RelationCode"].Trim(); ;
            }
            this.AddressUrlParameters = "?relationCode=" + relationCode;           

            //参数查询模型传递到前端视图中
            ViewBag.EntityConditon = entityConditon;
            ViewBag.RelationCode = relationCode;

            #endregion

            this.PageSize = 11;

            //获取实体总记录数
            this.TotalRecordCount = _entityWCF.GetRecordCount(entityConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Entity> parameters = _entityWCF.GetListByPage(entityConditon, "C_Entity_Id Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(parameters);
        }

        /// <summary>
        /// 确认关联实体
        /// </summary>
        /// <param name="relationCode">关联Guid</param>
        /// <returns></returns>
        public ActionResult RelationEntity(string entityCode, string relationCode)
        {
            /***
             * hety,2015-06-03
             * 业务说明：自定义表单属性设置(UI控件关联了实体表)
             * ***/
            bool isSuccess = false;
            CommonService.Model.CustomerForm.F_FormProperty formProperty = _formPropertyWCF.Get(new Guid(relationCode));
            CommonService.Model.C_Entity entity = _entityWCF.Get(new Guid(entityCode));
            if (formProperty != null)
            {
                formProperty.F_FormProperty_dataSource_type = Convert.ToInt32(CustomerFormDataSourceType.资料库表);
                formProperty.F_FormProperty_dataSource = entity.C_Entity_tableName;
                formProperty.F_FormProperty_dataSource_mappingField = entity.C_Entity_business_relFieldName;
                formProperty.F_FormProperty_dataSource_mappingFieldName = entity.C_Entity_business_showFieldName;

                isSuccess = _formPropertyWCF.Update(formProperty);
            }

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联选中实体成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联选中实体失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

	}
}