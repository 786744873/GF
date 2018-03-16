using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 案件服务
    /// </summary>
    public class B_Case : IB_Case
    {
        CommonService.BLL.CaseManager.B_Case bll = new CommonService.BLL.CaseManager.B_Case();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_id)
        {
            return bll.Exists(B_Case_id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.CaseManager.B_Case model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CaseManager.B_Case model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 修改案件进行状态
        /// </summary>
        public bool UpdateState(Guid B_Case_code, Guid startPersonCode)
        {
            return bll.UpdateState(B_Case_code, startPersonCode);
        }

        /// <summary>
        /// 修改预期收益金额
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="expectedGrant">预期收益金额</param>
        /// <returns></returns>
        public bool UpdateExpectedGrant(Guid caseCode, Decimal expectedGrant)
        {
            return bll.UpdateExpectedGrant(caseCode, expectedGrant);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_Case_code)
        {
            return bll.Delete(B_Case_code);
        }
        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        public Model.CaseManager.B_Case GetModel(Guid B_Case_code)
        {
            return bll.GetModel(B_Case_code);
        }
        /// <summary>
        /// 得到一个案件对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case GetModelNo(Guid B_Case_code)
        {
            return bll.GetModelNo(B_Case_code);
        }
        public List<CommonService.Model.CaseManager.B_Case> GetList(string str)
        {
            return bll.GetModelList(str);
        }
        /// <summary>
        /// 分页获取数据总记录
        /// </summary>
        public int GetRecordCount(Model.CaseManager.B_Case model, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.GetRecordCount(model, IsPreSetManager, RoleId, userCode, postCode, deptCode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetListByPageByCount(Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.GetListByPageByCount(model, orderby, startIndex, endIndex, IsPreSetManager, RoleId, userCode, postCode, deptCode);
        }

        public List<Model.CaseManager.B_Case> GetListByPage(Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, RoleId, userCode, postCode, deptCode);
        }

        /// <summary>
        /// 分页获取权限数据总记录
        /// </summary>
        public int GetPowerRecordCount(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, Model.CaseManager.B_Case model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.GetPowerRecordCount(vLawyerCond, model, IsPreSetManager, userCode, postCode, deptCode);
        }
        /// <summary>
        /// 分页获取权限数据过滤总记录
        /// </summary>
        public int GetPowerRecordCaseMainCount(Model.CaseManager.B_Case model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            return bll.GetPowerRecordCaseMainCount(model, IsPreSetManager, userCode, postCode, deptCode, tj);
        }

        /// <summary>
        /// 分页获取权限数据列表
        /// </summary>
        public List<Model.CaseManager.B_Case> GetPowerListByPage(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.GetPowerListByPage(vLawyerCond, model, orderby, startIndex, endIndex, IsPreSetManager, userCode, postCode, deptCode);
        }

        /// <summary>
        /// 导出关联权限的案件数据(hety,2016-03-10)
        /// </summary>
        public List<Model.CaseManager.B_Case> ExportPowerListByPage(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.ExportPowerListByPage(vLawyerCond, model, orderby, startIndex, endIndex, IsPreSetManager, userCode, postCode, deptCode);
        }

        /// <summary>
        /// 分页获取权限数据列表
        /// </summary>
        public List<Model.CaseManager.B_Case> GetPowerListB_caseMainByPage(Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager,Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            return bll.GetPowerListB_caseMainByPage(model, orderby, startIndex, endIndex, IsPreSetManager, userCode, postCode, deptCode, tj);
        }



        public List<Model.CaseManager.B_Case> GetModelList(string str)
        {
            return bll.GetModelList(str);
        }
        /// <summary>
        /// 根据表单guid得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case GetModelbyFormcode(Guid formCode)
        {
            return bll.GetModelbyFormcode(formCode);
        }
        public string GetFormValue(string F_FormPropertyValue_BusinessFlowFormCode, string F_Form_chineseName, string F_Form_code)
        {
            return bll.GetFormValue(F_FormPropertyValue_BusinessFlowFormCode, F_Form_chineseName, F_Form_code);
        }


        /// <summary>
        /// 首席确认案件时操作
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isShouxi"></param>
        /// <returns></returns>
        public bool ChiefUpdate(Model.CaseManager.B_Case model)
        {
            return bll.ChiefUpdate(model);
        }


        public System.Data.DataSet GetReportByYear()
        {
            return bll.GetReportByYear();
        }
        /// <summary>
        /// 案件转移
        /// </summary>
        /// <param name="lawyer">在办律师</param>
        /// <param name="TransferTo">转移给</param>
        /// <param name="transferType">转移类型</param>
        /// <param name="courtCodes">法院Guid</param>
        /// <returns></returns>
        public bool CaseTransfer(Guid lawyer, Guid TransferTo, string transferType, string courtCodes)
        {
            return bll.CaseTransfer(lawyer,TransferTo,transferType,courtCodes);
        }

        /// <summary>
        /// 案件转化
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="applicationPerson">申请人</param>
        /// <param name="TransformationType">转化类型</param>
        /// <param name="Reason">理由</param>
        /// <returns></returns>
        public bool CaseTransformation(Guid caseCode, Guid applicationPerson, string TransformationType, string Reason, bool IsPreSetManager, bool isChiefExpert)
        {
            return bll.CaseTransformation(caseCode, applicationPerson, TransformationType, Reason, IsPreSetManager,isChiefExpert);
        }

        /// <summary>
        /// 转化审核
        /// </summary>
        /// <param name="CaseLevelchangeCodeStr">案件级别变更Guid</param>
        /// <param name="auditPerson">审核人</param>
        /// <param name="CaseLevelchangeRecord">案件级别变更记录Guid</param>
        /// <param name="ConversionReasons">审核理由</param>
        /// <returns></returns>
        public bool CaseTransformationCheck(string CaseLevelchangeCodeStr, Guid auditPerson, Guid CaseLevelchangeRecord, string ConversionReasons, bool IsPreSetManager, int? caseLevelChangeState)
        {
            return bll.CaseTransformationCheck(CaseLevelchangeCodeStr, auditPerson, CaseLevelchangeRecord, ConversionReasons, IsPreSetManager, caseLevelChangeState);
        }

        #region 报表
        /// <summary>
        /// 客户团队收案类型统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByCaseTypeCount(Model.Reporting.R_CaseType_Reporting model)
        {
            return bll.GetReportByCaseTypeCount(model);
        }
        /// <summary>
        /// 客户团队收案类型统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.Reporting.R_CaseType_Reporting> GetReportByCaseType(Model.Reporting.R_CaseType_Reporting model, int startIndex, int endIndex)
        {
            return bll.GetReportByCaseType(model,startIndex,endIndex);
        }
        /// <summary>
        /// 区域收案统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByAreaCount(Model.Reporting.R_CaseArea_Reporting model)
        {
            return bll.GetReportByAreaCount(model);
        }
        /// <summary>
        /// 区域收案统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.Reporting.R_CaseArea_Reporting> GetReportByArea(Model.Reporting.R_CaseArea_Reporting model, int startIndex, int endIndex)
        {
            return bll.GetReportByArea(model,startIndex,endIndex);
        }
        /// <summary>
        /// 部门收案统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByOrganCount(Model.Reporting.R_CaseOrgan_Reporting model)
        {
            return bll.GetReportByOrganCount(model);
        }
        /// <summary>
        /// 部门收案统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.Reporting.R_CaseOrgan_Reporting> GetReportByOrgan(Model.Reporting.R_CaseOrgan_Reporting model, int startIndex, int endIndex)
        {
            return bll.GetReportByArea(model,startIndex,endIndex);
        }
        #endregion
    }
}
