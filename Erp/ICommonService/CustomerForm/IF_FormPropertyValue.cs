using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CustomerForm
{
    /// <summary>
    /// 自定义表单属性值契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IF_FormPropertyValue
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int F_FormPropertyValue_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CustomerForm.F_FormPropertyValue model);

        /// <summary>
        /// 初始化表单属性值
        /// </summary>
        /// <param name="formCode"></param>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool InitializationFormPropertyValue(Guid formCode, Guid businessFlowFormCode, Guid userCode);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CustomerForm.F_FormPropertyValue model);

        /// <summary>
        /// 根据表单属性值Guid，更改表单属性值
        /// </summary>
        /// <param name="V_FormPropertyValues">表单属性值(虚拟实体)</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateFormPropertyValueByPropertyCode(List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues);

        /// <summary>
        /// 根据表单属性值Id，更改表单属性值
        /// </summary>
        /// <param name="V_FormPropertyValues">表单属性值(虚拟实体)</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateFormPropertyValueByPropertyId(List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues);

        /// <summary>
        /// 处理ERP主子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        ///  <param name="V_HeadFormPropertyValues">主表表单属性值集合</param>
        /// <param name="ItemFormPropertyValues">子表表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>     
        [OperationContract]
        bool SaveHeadItemsFormPropertyValue(List<CommonService.Model.Customer.V_FormPropertyValue> V_HeadFormPropertyValues, List<CommonService.Model.CustomerForm.F_FormPropertyValue> ItemFormPropertyValues, Guid fFormCode, Guid relCode);

        /// <summary>
        /// 处理OA普通子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        /// <param name="FormPropertyValues">表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <param name="type">1代表普通子表子属性值；2代表主子表中普通子表子属性值</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveOAItemsFormPropertyValue(List<CommonService.Model.CustomerForm.F_FormPropertyValue> FormPropertyValues, Guid fFormCode, Guid relCode, int type);

        /// <summary>
        /// 处理OA主子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        ///  <param name="V_HeadFormPropertyValues">主表表单属性值集合</param>
        /// <param name="ItemFormPropertyValues">子表表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveOAHeadItemsFormPropertyValue(List<CommonService.Model.Customer.V_FormPropertyValue> V_HeadFormPropertyValues, List<CommonService.Model.CustomerForm.F_FormPropertyValue> ItemFormPropertyValues, Guid fFormCode, Guid relCode);

        /// <summary>
        /// 动态加载自定义表单普通子表属性值集合(DataSet中允许包含多个table)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>
        [OperationContract]
        DataSet DynamicLoadCustmerFormListValues(Guid fFormCode, Guid relCode);


        /// <summary>
        /// 动态加载自定义表单普通子表属性值总记录数(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [OperationContract]
        int DynamicLoadFeeFormListCount(Guid fFormCode, string condition);
        /// <summary>
        /// 动态加载oa自定义表单普通子表属性值总记录数(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [OperationContract]

        int DynamicLoadOAFeeFormListCount(Guid fFormCode, string condition);
        /// <summary>
        /// 动态加载自定义表单普通子表属性值集合(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [OperationContract]
        DataSet DynamicLoadFeeFormListValues(Guid fFormCode, int startIndex, int endIndex, string condition);
        /// <summary>
        /// 动态加载OA自定义表单普通子表属性值集合(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [OperationContract]
        DataSet DynamicLoadOAFeeFormListValues(Guid fFormCode, int startIndex, int endIndex, string condition);
        /// <summary>
        /// 通过业务条件，获取关联自定义表单属性值列表(只针对自定义表单的某一属性关联了另外一个自定义表单的某一属性)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetCustFormPropertyValues(Guid formCode, Guid formPropertyCode, Guid businessFlowFormCode);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid F_FormPropertyValue_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_FormPropertyValue_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CustomerForm.F_FormPropertyValue Get(Guid F_FormPropertyValue_code);

        /// <summary>
        /// 根据表单属性获取最大值
        /// </summary>
        /// <param name="FormCode">表单Guid</param>
        /// <param name="FormPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CustomerForm.F_FormPropertyValue GetMaxModelByFormAndFormProperty(Guid FormCode, Guid FormPropertyCode);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_FormPropertyValue_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CustomerForm.F_FormPropertyValue GetModelByFormPropertyValueGroupAndFormProperty(Guid F_FormPropertyValue_group, Guid F_FormPropertyValue_formProperty);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="F_FormPropertyValues"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateUpdate(List<CommonService.Model.CustomerForm.F_FormPropertyValue> F_FormPropertyValues);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="F_FormPropertyValue_group"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetListByFormPropertyValueGroup(Guid F_FormPropertyValue_group);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CustomerForm.F_FormPropertyValue model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetListByPage(CommonService.Model.CustomerForm.F_FormPropertyValue model, string orderby, int startIndex, int endIndex);

        [OperationContract]
        CommonService.Model.CustomerForm.F_FormPropertyValue GetModel(Guid formCode, Guid businessFlowFormCode, Guid formPropertyCode);
    }
}
