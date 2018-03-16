using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.IndividuationForm.Controllers
{
    /// <summary>
    /// 收款监督表单(个性化)
    /// </summary>
    public class CollectSupervisionFormController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;

        public CollectSupervisionFormController()
        {
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
        }

        //
        // GET: /IndividuationForm/CollectSupervisionForm/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 动态生成收款监督表单(Table Edit List 中)下拉框(html串)
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>GenerateIndividDropDownHtmls
        public string GenerateCollectSupervisionDropDownHtmls(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string businessFlowFormCode, string businessFlowCode)
        {
            int parentId = -1;
            string dropItems = String.Empty;

            /**
             * author:hety
             * date:2015-09-06
             * description:如果下拉框为列表中的"权益名称"字段，则需要关联案件类型进行动态取值
             ***/

            if (formPropertyValue.F_FormProperty_dataSource_type == Convert.ToInt32(CustomerFormDataSourceType.参数表))
            {
                #region
                if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
                {
                    parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
                }

                #region 如果下拉框为列表中的"权益名称"字段，则需要关联案件类型进行动态取值
                if (formPropertyValue.F_FormProperty_code.Value.ToString().ToUpper() == "9F804B87-05D4-431E-8C58-B2D5B0E0C33A")
                {
                    CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
                    if (businessFlow != null)
                    {
                        CommonService.Model.CaseManager.B_Case bCase = _caseWCF.GetModel(businessFlow.P_Fk_code.Value);
                        if (bCase != null)
                        {
                            if (bCase.B_Case_type.Value == Convert.ToInt32(CaseTypeEnum.钢材))
                            {
                                parentId = Convert.ToInt32(CaseEnum.钢材财产权利);
                            }else if(bCase.B_Case_type.Value == Convert.ToInt32(CaseTypeEnum.混凝土))
                            {
                                parentId = Convert.ToInt32(CaseEnum.混凝土财产权利);
                            }
                            else if (bCase.B_Case_type.Value == Convert.ToInt32(CaseTypeEnum.架管))
                            {
                                parentId = Convert.ToInt32(CaseEnum.架管财产权利);
                            }
                            else if (bCase.B_Case_type.Value == Convert.ToInt32(CaseTypeEnum.其它))
                            {
                                parentId = Convert.ToInt32(CaseEnum.其它财产权利);
                            }
                        }
                    }
                }
                #endregion

                List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
                foreach (CommonService.Model.C_Parameters p in childrenParameters)
                {
                    if (String.IsNullOrEmpty(formPropertyValue.V_FormPropertyValue_Value))
                    {
                        dropItems += "<option value=" + p.C_Parameters_id + ">" + p.C_Parameters_name + "</option>";
                    }
                    else
                    {
                        if (p.C_Parameters_id.ToString().Equals(formPropertyValue.V_FormPropertyValue_Value))
                        {
                            dropItems += "<option selected=selected value=" + p.C_Parameters_id + ">" + p.C_Parameters_name + "</option>";
                        }
                        else
                        {
                            dropItems += "<option value=" + p.C_Parameters_id + ">" + p.C_Parameters_name + "</option>";
                        }
                    }
                }
                #endregion
            }
            return dropItems;
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        private List<CommonService.Model.C_Parameters> InitializationParameter(int parentId)
        {
            //参数集合
            List<CommonService.Model.C_Parameters> childrenParameters = _parameterWCF.GetChildrenByParentId(parentId);
            if (childrenParameters.Count == 0)
            {
                childrenParameters = new List<CommonService.Model.C_Parameters>();
            }
            return childrenParameters;
        }
	}
}