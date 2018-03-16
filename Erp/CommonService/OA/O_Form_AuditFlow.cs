using ICommonService.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.OA
{
    /// <summary>
    /// 表单审批流程服务
    /// </summary>
    public class O_Form_AuditFlow : IO_Form_AuditFlow
    {
        CommonService.BLL.OA.O_Form_AuditFlow oBLL = new CommonService.BLL.OA.O_Form_AuditFlow();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Form_AuditFlow model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Form_AuditFlow model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_Form_AuditFlow_code)
        {
            return oBLL.Delete(O_Form_AuditFlow_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_Form_code"></param>
        /// <returns></returns>
        public CommonService.Model.OA.O_Form_AuditFlow Get(Guid O_Form_AuditFlow_code)
        {
            return oBLL.GetModel(O_Form_AuditFlow_code);
        }

        /// <summary>
        /// 得到一个顺序最大的对象实体
        /// </summary>
        public int GetMaxOrderModel(Guid O_Form_AuditFlow_code)
        {
            return oBLL.GetMaxOrderModel(O_Form_AuditFlow_code);
        }

        /// <summary>
        /// 非自由流程驳回审核
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <param name="userCode">子用户Guid</param>
        /// <param name="auditContent">审批内容</param>
        /// <returns></returns>
        public bool NotFreeFlowRejectCheck(Guid oFormCode, Guid formAuditFlowCode, Guid userCode, string auditContent)
        {
            return oBLL.NotFreeFlowRejectCheck(oFormCode, formAuditFlowCode, userCode, auditContent);
        }

        /// <summary>
        /// 非自由流程通过审核
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <param name="userCode">子用户Guid</param>
        /// <param name="auditContent">审批内容</param>
        /// <param name="notShowFormAuditFlowCodes">不满足规则的表单审批流程Guid串</param>
        /// <returns></returns>
        public int NotFreeFlowPassCheck(Guid oFormCode, Guid formAuditFlowCode, Guid userCode, string auditContent, string notShowFormAuditFlowCodes)
        {
            return oBLL.NotFreeFlowPassCheck(oFormCode, formAuditFlowCode, userCode, auditContent, notShowFormAuditFlowCodes);
        }

        /// <summary>
        /// 通过表单Guid，获取表单审批流程集合
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetFormAuditFlowsByFormCode(Guid formCode)
        {
            return oBLL.GetFormAuditFlowsByFormCode(formCode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.OA.O_Form_AuditFlow model)
        {
            return oBLL.GetRecordCount(model);
        }
        /// <summary>
        /// 通过表单guid获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetListByFormCode(Guid formCode)
        {
            return oBLL.GetListByFormCode(formCode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetListByPage(CommonService.Model.OA.O_Form_AuditFlow model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 通过审核人guid获得未审核的数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetListStatusByuserCode(Guid userCode)
        {
            return oBLL.GetListStatusByuserCode(userCode);
        }
        /// <summary>
        /// 通过流程预设guid获得数据信息
        /// </summary>
        public CommonService.Model.OA.O_Form_AuditFlow GetModelByAuditFlowcode(Guid flowCode, int type)
        {
            return oBLL.GetModelByAuditFlowcode(flowCode, type);
        }
        /// <summary>
        /// 通过流程预设guid和表单guid和流程顺序获得数据列表获得数据信息
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetModelByAuditFlowcodeAndformCodeAndOrder(int type, Guid formCode, int order)
        {
            return oBLL.GetModelByAuditFlowcodeAndformCodeAndOrder(type, formCode, order);
        }
        /// <summary>
        /// 通过审核人guid获得未审核的数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetListByuserCode(Guid userCode)
        {
            return oBLL.GetListByuserCode(userCode);
        }
    }
}
