using ICommonService.CustomerForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CustomerForm
{
    /// <summary>
    ///表单属性值服务
    /// </summary>
    public class F_FormPropertyValue : IF_FormPropertyValue
    {
        CommonService.BLL.CustomerForm.F_FormPropertyValue oBLL = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return oBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_FormPropertyValue_id)
        {
            return oBLL.Exists(F_FormPropertyValue_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormPropertyValue model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 初始化表单属性值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关系Guid</param>
        /// <param name="userCode">操作人Guid</param>
        /// <returns></returns>
        public bool InitializationFormPropertyValue(Guid formCode, Guid businessFlowFormCode, Guid userCode)
        {
            return oBLL.InitializationFormPropertyValue(formCode, businessFlowFormCode, userCode);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormPropertyValue model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 根据表单属性值Guid，更改表单属性值
        /// </summary>
        /// <param name="V_FormPropertyValues">表单属性值(虚拟实体)</param>
        /// <returns></returns>        
        public bool UpdateFormPropertyValueByPropertyCode(List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues)
        {
            return oBLL.UpdateFormPropertyValueByPropertyCode(V_FormPropertyValues);
        }

        /// <summary>
        /// 根据表单属性值Id，更改表单属性值
        /// </summary>
        /// <param name="V_FormPropertyValues">表单属性值(虚拟实体)</param>
        /// <returns></returns>        
        public bool UpdateFormPropertyValueByPropertyId(List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues)
        {
            return oBLL.UpdateFormPropertyValueByPropertyId(V_FormPropertyValues);
        }

        /// <summary>
        /// 处理ERP主子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        ///  <param name="V_HeadFormPropertyValues">主表表单属性值集合</param>
        /// <param name="ItemFormPropertyValues">子表表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>       
        public bool SaveHeadItemsFormPropertyValue(List<CommonService.Model.Customer.V_FormPropertyValue> V_HeadFormPropertyValues, List<CommonService.Model.CustomerForm.F_FormPropertyValue> ItemFormPropertyValues, Guid fFormCode, Guid relCode)
        {
            return oBLL.SaveHeadItemsFormPropertyValue(V_HeadFormPropertyValues, ItemFormPropertyValues, fFormCode, relCode);
        }

        /// <summary>
        /// 处理OA普通子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        /// <param name="FormPropertyValues">表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <param name="type">1代表普通子表子属性值；2代表主子表中普通子表子属性值</param>
        /// <returns></returns>
        public bool SaveOAItemsFormPropertyValue(List<CommonService.Model.CustomerForm.F_FormPropertyValue> FormPropertyValues, Guid fFormCode, Guid relCode, int type)
        {
            return oBLL.SaveOAItemsFormPropertyValue(FormPropertyValues, fFormCode, relCode, type);
        }

        /// <summary>
        /// 处理OA主子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        ///  <param name="V_HeadFormPropertyValues">主表表单属性值集合</param>
        /// <param name="ItemFormPropertyValues">子表表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>       
        public bool SaveOAHeadItemsFormPropertyValue(List<CommonService.Model.Customer.V_FormPropertyValue> V_HeadFormPropertyValues, List<CommonService.Model.CustomerForm.F_FormPropertyValue> ItemFormPropertyValues, Guid fFormCode, Guid relCode)
        {
            return oBLL.SaveOAHeadItemsFormPropertyValue(V_HeadFormPropertyValues, ItemFormPropertyValues, fFormCode, relCode);
        }

        /// <summary>
        /// 动态加载自定义表单普通子表属性值集合(DataSet中允许包含多个table)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>
        public DataSet DynamicLoadCustmerFormListValues(Guid fFormCode, Guid relCode)
        {
            return oBLL.DynamicLoadCustmerFormListValues(fFormCode, relCode);
        }

        /// <summary>
        /// 动态加载自定义表单普通子表属性值总记录数(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int DynamicLoadFeeFormListCount(Guid fFormCode, string condition)
        {
            return oBLL.DynamicLoadFeeFormListCount(fFormCode, condition);
        }
        /// <summary>
        /// 动态加载oa自定义表单普通子表属性值总记录数(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int DynamicLoadOAFeeFormListCount(Guid fFormCode, string condition)
        {
            return oBLL.DynamicLoadOAFeeFormListCount(fFormCode, condition);
        }
        /// <summary>
        /// 动态加载自定义表单普通子表属性值集合(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public DataSet DynamicLoadFeeFormListValues(Guid fFormCode, int startIndex, int endIndex, string condition)
        {
            return oBLL.DynamicLoadFeeFormListValues(fFormCode, startIndex, endIndex, condition);
        }
        /// <summary>
        /// 动态加载OA自定义表单普通子表属性值集合(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public DataSet DynamicLoadOAFeeFormListValues(Guid fFormCode, int startIndex, int endIndex, string condition)
        {
            return oBLL.DynamicLoadOAFeeFormListValues(fFormCode, startIndex, endIndex, condition);
        }
        /// <summary>
        /// 通过业务条件，获取关联自定义表单属性值列表(只针对自定义表单的某一属性关联了另外一个自定义表单的某一属性)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetCustFormPropertyValues(Guid formCode, Guid formPropertyCode, Guid businessFlowFormCode)
        {
            return oBLL.GetCustFormPropertyValues(formCode, formPropertyCode, businessFlowFormCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid F_FormPropertyValue_code)
        {
            //return oBLL.Delete(F_FormPropertyValue_code);
            return true;
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_Form_code"></param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormPropertyValue Get(Guid F_FormPropertyValue_code)
        {
            return oBLL.GetModelByCode(F_FormPropertyValue_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="F_FormPropertyValue_group"></param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetListByFormPropertyValueGroup(Guid F_FormPropertyValue_group)
        {
            return oBLL.GetListByFormPropertyValueGroup(F_FormPropertyValue_group);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CustomerForm.F_FormPropertyValue model)
        {
            // return oBLL.GetRecordCount(model);
            return 0;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetListByPage(CommonService.Model.CustomerForm.F_FormPropertyValue model, string orderby, int startIndex, int endIndex)
        {
            //return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
            return null;
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_FormPropertyValue_group"></param>
        /// <param name="F_FormPropertyValue_formProperty"></param>
        /// <returns></returns>
        public Model.CustomerForm.F_FormPropertyValue GetModelByFormPropertyValueGroupAndFormProperty(Guid F_FormPropertyValue_group, Guid F_FormPropertyValue_formProperty)
        {
            return oBLL.GetModelByFormPropertyValueGroupAndFormProperty(F_FormPropertyValue_group, F_FormPropertyValue_formProperty);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="F_FormPropertyValues"></param>
        /// <returns></returns>
        public bool OperateUpdate(List<Model.CustomerForm.F_FormPropertyValue> F_FormPropertyValues)
        {
            return oBLL.OperateUpdate(F_FormPropertyValues);
        }

        /// <summary>
        /// 根据表单属性获取最大值
        /// </summary>
        /// <param name="FormCode">表单Guid</param>
        /// <param name="FormPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetMaxModelByFormAndFormProperty(Guid FormCode, Guid FormPropertyCode)
        {
            return oBLL.GetMaxModelByFormAndFormProperty(FormCode, FormPropertyCode);
        }
            /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModel(Guid formCode, Guid businessFlowFormCode, Guid formPropertyCode)
        {
            return oBLL.GetModel(formCode, businessFlowFormCode, formPropertyCode);
        }
    }
}
