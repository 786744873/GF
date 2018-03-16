using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CustomerForm
{
    /// <summary>
    /// 自定义表单属性契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IF_FormProperty
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
        bool Exists(int F_FormProperty_id);

        /// <summary>
        /// 根据表单Code检查字段名称是否存在
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool ExistsFieldNameByFormCode(string fieldName, Guid formCode);

        /// <summary>
        /// 根据表单Code,表单属性Code检查字段名称是否存在
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool ExistsFieldNameByFormCodeAndPropertyCode(string fieldName, Guid formCode, Guid formPropertyCode);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CustomerForm.F_FormProperty model);

        /// <summary>
        /// 向前移动顺序号
        /// </summary>
        /// <param name="formCode"></param>
        /// <param name="formPropertyCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool MoveForward(Guid formCode, Guid formPropertyCode);

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="formCode"></param>
        /// <param name="formPropertyCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool MoveBackward(Guid formCode, Guid formPropertyCode);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CustomerForm.F_FormProperty model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid F_FormProperty_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_FormProperty_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CustomerForm.F_FormProperty Get(Guid F_FormProperty_code);

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="formCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetList(Guid formCode);

        /// <summary>
        /// 根据业务流程表单关联Guid，获取编辑自定义表单属性及其值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetEditFormPropertyValueList(Guid formCode, Guid businessFlowFormCode);

        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单自定义属性值历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetEditFormHistorRecord(Guid businessFlowCode, Guid formCode);

        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetHeadEditFormHistoryRecord(Guid businessFlowCode, Guid formCode);

        /// <summary>
        /// 根据协同办公表单Guid，获取编辑协同办公表单属性及其值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetOAEditFormPropertyValueList(Guid fFormCode, Guid oFormCode);

        /// <summary>
        /// 根据协同办公表单Guid，获取主子表协同办公表单编辑属性及其值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetOAHeadEditFormPropertyValueList(Guid fFormCode, Guid oFormCode);

        /// <summary>
        /// 根据业务流程表单关联Guid，获取tab编辑自定义表单属性及其值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="parentFormPropertyCode">父亲表单属性Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetTabEditFormPropertyValueList(Guid formCode, Guid businessFlowFormCode, Guid parentFormPropertyCode);

        /// <summary>
        /// 根据表单Guid和父亲表单属性Guid，获取子级表单属性
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="parentFormPropertyCode">父亲表单属性Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetFormPropertysByFormCodeAndParentPropertyCode(Guid formCode, Guid parentFormPropertyCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CustomerForm.F_FormProperty model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetListByPage(CommonService.Model.CustomerForm.F_FormProperty model, string orderby, int startIndex, int endIndex);
    }
}
