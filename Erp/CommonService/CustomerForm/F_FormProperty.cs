using ICommonService.CustomerForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CustomerForm
{
    /// <summary>
    /// 自定义表单属性服务
    /// </summary>
    public class F_FormProperty : IF_FormProperty
    {
        CommonService.BLL.CustomerForm.F_FormProperty oBLL = new CommonService.BLL.CustomerForm.F_FormProperty();
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
        public bool Exists(int F_FormProperty_id)
        {
            return oBLL.Exists(F_FormProperty_id);
        }

        /// <summary>
        /// 根据表单Code检查字段名称是否存在
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>       
        public bool ExistsFieldNameByFormCode(string fieldName, Guid formCode)
        {
            return oBLL.ExistsFieldName(fieldName, formCode);
        }

        /// <summary>
        /// 根据表单Code,表单属性Code检查字段名称是否存在
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public bool ExistsFieldNameByFormCodeAndPropertyCode(string fieldName, Guid formCode, Guid formPropertyCode)
        {
            return oBLL.ExistsFieldName(fieldName, formCode, formPropertyCode);
        }

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public bool MoveForward(Guid formCode, Guid formPropertyCode)
        {
            return oBLL.MoveForward(formCode, formPropertyCode);
        }

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public bool MoveBackward(Guid formCode, Guid formPropertyCode)
        {
            return oBLL.MoveBackward(formCode, formPropertyCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormProperty model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormProperty model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid F_FormProperty_code)
        {
            return oBLL.Delete(F_FormProperty_code);         
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_Form_code"></param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormProperty Get(Guid F_FormProperty_code)
        {
             return oBLL.GetModel(F_FormProperty_code);        
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetList(Guid formCode)
        {
            return oBLL.GetModelList(formCode);
        }

        /// <summary>
        /// 根据表单Guid和父亲表单属性Guid，获取子级表单属性
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="parentFormPropertyCode">父亲表单属性Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetFormPropertysByFormCodeAndParentPropertyCode(Guid formCode,Guid parentFormPropertyCode)
        {
            return oBLL.GetModelList(formCode,parentFormPropertyCode);
        }
        /// <summary>
        /// 根据业务流程表单关联Guid，获取编辑自定义表单属性及其值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>       
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetEditFormPropertyValueList(Guid formCode, Guid businessFlowFormCode)
        {
            return oBLL.GetEditFormPropertyValueList(formCode, businessFlowFormCode);
        }

        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单自定义属性值历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetEditFormHistorRecord(Guid businessFlowCode, Guid formCode)
        {
            return oBLL.GetEditFormHistorRecord(businessFlowCode, formCode);
        }

        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetHeadEditFormHistoryRecord(Guid businessFlowCode, Guid formCode)
        {
            return oBLL.GetHeadEditFormHistoryRecord(businessFlowCode, formCode);
        }

        /// <summary>
        /// 根据协同办公表单Guid，获取编辑协同办公表单属性及其值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetOAEditFormPropertyValueList(Guid fFormCode, Guid oFormCode)
        {
            return oBLL.GetOAEditFormPropertyValueList(fFormCode, oFormCode);
        }

        /// <summary>
        /// 根据协同办公表单Guid，获取主子表协同办公表单编辑属性及其值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetOAHeadEditFormPropertyValueList(Guid fFormCode, Guid oFormCode)
        {
            return oBLL.GetOAHeadEditFormPropertyValueList(fFormCode, oFormCode);
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取tab编辑自定义表单属性及其值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="parentFormPropertyCode">父亲表单属性Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetTabEditFormPropertyValueList(Guid formCode, Guid businessFlowFormCode, Guid parentFormPropertyCode)
        {
            return oBLL.GetTabEditFormPropertyValueList(formCode, businessFlowFormCode, parentFormPropertyCode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CustomerForm.F_FormProperty model)
        {
             return oBLL.GetRecordCount(model);         
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetListByPage(CommonService.Model.CustomerForm.F_FormProperty model, string orderby, int startIndex, int endIndex)
        {            
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);           
        }
    }
}
