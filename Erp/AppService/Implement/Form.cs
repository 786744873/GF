using AppService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Implement
{
    /// <summary>
    /// 表单服务
    /// </summary>
    public class Form : IForm
    {
        /// <summary>
        /// 表单审核业务逻辑层
        /// </summary>
        CommonService.BLL.CustomerForm.F_FormCheck formCheckBLL = new CommonService.BLL.CustomerForm.F_FormCheck();
        /// <summary>
        /// 虚拟用户业务逻辑层
        /// </summary>
        CommonService.BLL.Customer.V_User vUserBLL = new CommonService.BLL.Customer.V_User();

        #region App专用 添加审核信息 审核表单

        /// <summary>
        /// 根据表单GUID获取该表单下所有的历史纪要
        /// </summary>
        /// <param name="guid">表单GUID</param>
        /// <returns>历史纪要列表</returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> AppGetHistoricalSummary(string guid)
        {
            return formCheckBLL.GetListByBusinessflowformCode(Guid.Parse(guid));
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="lst">需要提交的表单集合</param>
        /// <returns>状态：1成功 0不成功</returns>
        public int AppAddAuditInfo(List<CommonService.Model.CustomerForm.F_FormCheck> lst)
        {
            return formCheckBLL.SubmitForm(lst, "153");
        }

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="lst">审核表单集合</param>
        /// <returns>状态：1成功 0不成功</returns>
        public int AppCheckList(List<CommonService.Model.CustomerForm.F_FormCheck> lst)
        {
            return formCheckBLL.CheckForm(lst, "153");
        }

        /// <summary>
        /// 获取可以保存自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetSaveOwnFormUsers(string businessFlowFormCode)
        {
            return vUserBLL.GetSaveOwnFormUsers(new Guid(businessFlowFormCode));
        }

        /// <summary>
        /// 获取当前用户可以审核的表单集合
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="loginChildrenUserCode">当前登录子用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetCheckOwnFormsByUser(string businessFlowCode, string loginChildrenUserCode)
        {
            return vUserBLL.GetCheckOwnFormsByUser(new Guid(businessFlowCode), new Guid(loginChildrenUserCode));
        }

        #endregion

    }
}