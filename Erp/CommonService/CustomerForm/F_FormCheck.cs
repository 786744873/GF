using ICommonService.CustomerForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CustomerForm
{
    /// <summary>
    /// 表单审核服务
    /// </summary>
    public class F_FormCheck : IF_FormCheck
    {
        CommonService.BLL.CustomerForm.F_FormCheck oBLL = new CommonService.BLL.CustomerForm.F_FormCheck();
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
        public bool Exists(int F_FormCheck_id)
        {
            return oBLL.Exists(F_FormCheck_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 提交表单审核
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        public int SubmitForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks, string fkType)
        {
            return oBLL.SubmitForm(formChecks,fkType);
        }

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        public int CheckForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks, string fkType)
        {
            return oBLL.CheckForm(formChecks,fkType);
        }

        /// <summary>
        /// 个性化表单直接审核
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="operateUserCode">当前操作人Guid</param>
        /// <returns></returns>
        public int IndividuationCheckForm(Guid businessFlowFormCode, Guid operateUserCode)
        {
            return oBLL.IndividuationCheckForm(businessFlowFormCode, operateUserCode);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid F_FormCheck_code)
        {
            return oBLL.Delete(F_FormCheck_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_FormCheck_code"></param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormCheck Get(Guid F_FormCheck_code)
        {
            return oBLL.GetModel(F_FormCheck_code);
        }
        /// <summary>
        /// 根据业务流程表单关联GUID，获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetListByBusinessflowformCode(Guid F_FormCheck_business_flow_form_code)
        {
            return oBLL.GetListByBusinessflowformCode(F_FormCheck_business_flow_form_code);
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取首次表单提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetFirstTimeFormCheckRecord(Guid businessFlowFormCode)
        {
            return oBLL.GetFirstTimeFormCheckRecord(businessFlowFormCode);
        }
        /// <summary>
        /// 根据流程guid 获取全部提交记录
        /// </summary>
        /// <param name="flowcode"></param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetFirstTimeFormCheckRecordForflowcode(Guid flowcode)
        {
            return oBLL.GetFirstTimeFormCheckRecordForflowcode(flowcode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetListByPage(CommonService.Model.CustomerForm.F_FormCheck model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 表单值中是否包含必填项未填写的
        /// </summary>
        /// <param name="businessFlowFormCodes">业务流程表单guid</param>
        /// <returns></returns>
        public bool IsValidate(string businessFlowFormCodes)
        {
            return oBLL.IsValidate(businessFlowFormCodes);
        }
        #region App专用
        /// <summary>
        /// 根据表单GUID获取该表单下所有的历史纪要
        /// </summary>
        /// <param name="guid">表单GUID</param>
        /// <returns>历史纪要列表</returns>
        public List<Model.CustomerForm.F_FormCheck> AppGetHistoricalSummary(Guid? guid)
        {
            return oBLL.GetListByBusinessflowformCode(guid.Value);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="lst">需要提交的表单集合</param>
        /// <returns>状态：1成功 0不成功</returns>
        public int AppAddAuditInfo(List<Model.CustomerForm.F_FormCheck> lst)
        {
            return oBLL.SubmitForm(lst, "153");
        }

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="lst">审核表单集合</param>
        /// <returns>状态：1成功 0不成功</returns>
        public int AppCheckList(List<Model.CustomerForm.F_FormCheck> lst)
        {
            return oBLL.CheckForm(lst, "153");
        }
        #endregion

    }
}
