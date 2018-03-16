using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CustomerForm
{
    /// <summary>
    /// 表单审核契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IF_FormCheck
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
        bool Exists(int F_FormCheck_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CustomerForm.F_FormCheck model);

        /// <summary>
        /// 提交表单审核
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        [OperationContract]
        int SubmitForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks,string fkType);

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        [OperationContract]
        int CheckForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks,string fkType);

        /// <summary>
        /// 个性化表单直接审核
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="operateUserCode">当前操作人Guid</param>
        /// <returns></returns>
        [OperationContract]
        int IndividuationCheckForm(Guid businessFlowFormCode, Guid operateUserCode);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CustomerForm.F_FormCheck model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid F_FormCheck_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_FormCheck_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CustomerForm.F_FormCheck Get(Guid F_FormCheck_code);
        /// <summary>
        /// 根据业务流程表单关联GUID，获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormCheck> GetListByBusinessflowformCode(Guid F_FormCheck_business_flow_form_code);
        
        /// <summary>
        /// 根据业务流程表单关联Guid，获取首次表单提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormCheck> GetFirstTimeFormCheckRecord(Guid businessFlowFormCode);
               /// <summary>
        /// 根据流程guid 获取全部提交记录
        /// </summary>
        /// <param name="flowcode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormCheck> GetFirstTimeFormCheckRecordForflowcode(Guid flowcode);
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CustomerForm.F_FormCheck model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormCheck> GetListByPage(CommonService.Model.CustomerForm.F_FormCheck model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 表单值中是否包含必填项未填写的
        /// </summary>
        /// <param name="businessFlowFormCodes">业务流程表单guid</param>
        /// <returns></returns>
        [OperationContract]
        bool IsValidate(string businessFlowFormCodes);
        #region App专用
        /// <summary>
        /// 根据表单GUID获取该表单下所有的历史纪要
        /// </summary>
        /// <param name="guid">表单GUID</param>
        /// <returns>历史纪要列表</returns>
        [WebInvoke(UriTemplate = "AppGetHistoricalSummary", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomerForm.F_FormCheck> AppGetHistoricalSummary(Guid? guid);

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="lst">需要提交的表单集合</param>
        /// <returns>状态：1成功 0不成功</returns>
        [WebInvoke(UriTemplate = "AppAddAuditInfo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AppAddAuditInfo(List<CommonService.Model.CustomerForm.F_FormCheck> lst);

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="lst">审核表单集合</param>
        /// <returns>状态：1成功 0不成功</returns>
        [WebInvoke(UriTemplate = "AppCheckList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AppCheckList(List<CommonService.Model.CustomerForm.F_FormCheck> lst);
        #endregion
    }
}
