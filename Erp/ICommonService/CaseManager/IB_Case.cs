using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Case
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
        bool Exists(int B_Case_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Case model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Case model);

        /// <summary>
        /// 首席确认案件时操作
        /// </summary>
        [OperationContract]
        bool ChiefUpdate(CommonService.Model.CaseManager.B_Case model);

        /// <summary>
        /// 修改案件进行状态
        /// </summary>
        [OperationContract]
        bool UpdateState(Guid B_Case_code,Guid startPersonCode);

        /// <summary>
        /// 修改预期收益金额
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="expectedGrant">预期收益金额</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateExpectedGrant(Guid caseCode, Decimal expectedGrant);

        /// <summary>
        /// 获取所有案件
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case> GetModelList(string str);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid B_Case_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case GetModel(Guid B_Case_code);
        /// <summary>
        /// 得到一条案件数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case GetModelNo(Guid B_Case_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case> GetListByPage(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetListByPageByCount(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode);

        /// <summary>
        /// 分页获取权限数据总记录
        /// </summary>
        [OperationContract]
        int GetPowerRecordCount(CommonService.Model.Customer.V_LawyerCondition lawyerCond, CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode);
        /// <summary>
        /// 过滤维护案件
        /// </summary>

        [OperationContract]
        int GetPowerRecordCaseMainCount(CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj);
        
        /// <summary>
        /// 分页获取权限数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case> GetPowerListByPage(CommonService.Model.Customer.V_LawyerCondition lawyerCond, CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager,Guid? userCode, Guid? postCode, Guid? deptCode);

        /// <summary>
        /// 导出关联权限的案件数据(hety,2016-03-10)
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case> ExportPowerListByPage(CommonService.Model.Customer.V_LawyerCondition lawyerCond, CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode);


        /// <summary>
        /// 分页获取数据过滤列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="IsPreSetManager"></param>
        /// <param name="RoleId"></param>
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case> GetPowerListB_caseMainByPage(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager,Guid? userCode, Guid? postCode, Guid? deptCode, string tj);
        /// <summary>
        /// 根据表单guid得到一个对象实体
        /// </summary>
        [OperationContract]

        CommonService.Model.CaseManager.B_Case GetModelbyFormcode(Guid formCode);
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="F_FormPropertyValue_BusinessFlowFormCode"></param>
        /// <param name="F_Form_chineseName"></param>
        /// <param name="F_Form_code"></param>
        /// <returns></returns>
        [OperationContract]
        string GetFormValue(string F_FormPropertyValue_BusinessFlowFormCode, string F_Form_chineseName, string F_Form_code);


        /// <summary>
        /// 根据年份统计
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetReportByYear();

        /// <summary>
        /// 案件转移
        /// </summary>
        /// <param name="lawyer">在办律师</param>
        /// <param name="TransferTo">转移给</param>
        /// <param name="transferType">转移类型</param>
        /// <param name="courtCodes">法院Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool CaseTransfer(Guid lawyer, Guid TransferTo, string transferType, string courtCodes);
       /// <summary>
        /// 案件转化
       /// </summary>
       /// <param name="caseCode">案件Guid</param>
       /// <param name="applicationPerson">申请人</param>
       /// <param name="TransformationType">转化类型</param>
        /// <param name="Reason">理由</param>
        /// <param name="IsPreSetManager">是否内置管理员</param>
        /// <param name="roleId">角色Id</param>
       /// <returns></returns>
        [OperationContract]
        bool CaseTransformation(Guid caseCode, Guid applicationPerson, string TransformationType, string Reason, bool IsPreSetManager, bool isChiefExpert);
        /// <summary>
        /// 转化审核
        /// </summary>
        /// <param name="CaseLevelchangeCodeStr">案件级别变更Guid</param>
        /// <param name="auditPerson">审核人</param>
        /// <param name="CaseLevelchangeRecord">案件级别变更记录Guid</param>
        /// <param name="ConversionReasons">审核理由</param>
        /// <param name="IsPreSetManager">是否内置管理员</param>
        /// <param name="caseLevelChangeState">状态</param>
        /// <returns></returns>
        [OperationContract]
        bool CaseTransformationCheck(string CaseLevelchangeCodeStr, Guid auditPerson, Guid CaseLevelchangeRecord, string ConversionReasons, bool IsPreSetManager, int? caseLevelChangeState);

        #region 报表
        /// <summary>
        /// 客户团队收案类型统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        int GetReportByCaseTypeCount(CommonService.Model.Reporting.R_CaseType_Reporting model);
        /// <summary>
        /// 客户团队收案类型统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Reporting.R_CaseType_Reporting> GetReportByCaseType(CommonService.Model.Reporting.R_CaseType_Reporting model, int startIndex, int endIndex);
         /// <summary>
        /// 区域收案统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        int GetReportByAreaCount(CommonService.Model.Reporting.R_CaseArea_Reporting model);
         /// <summary>
        /// 区域收案统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Reporting.R_CaseArea_Reporting> GetReportByArea(CommonService.Model.Reporting.R_CaseArea_Reporting model, int startIndex, int endIndex);
         /// <summary>
        /// 部门收案统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        int GetReportByOrganCount(CommonService.Model.Reporting.R_CaseOrgan_Reporting model);
         /// <summary>
        /// 部门收案统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Reporting.R_CaseOrgan_Reporting> GetReportByOrgan(CommonService.Model.Reporting.R_CaseOrgan_Reporting model, int startIndex, int endIndex);
        #endregion
    }
}
