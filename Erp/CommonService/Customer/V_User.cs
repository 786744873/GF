using ICommonService.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Customer
{
    /// <summary>
    /// 虚拟用户服务
    /// </summary>
    public class V_User : IV_User
    {
        CommonService.BLL.Customer.V_User oBLL = new CommonService.BLL.Customer.V_User();

        /// <summary>
        /// 获取可以打开自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="pkType">pk类型,1代表案件;2代表商机</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetOpenOwnFormUsers(Guid businessFlowCode, int pkType)
        {
            return oBLL.GetOpenOwnFormUsers(businessFlowCode, pkType);
        }

        /// <summary>
        /// 获取可以保存自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetSaveOwnFormUsers(Guid businessFlowFormCode)
        {
            return oBLL.GetSaveOwnFormUsers(businessFlowFormCode);
        }

        /// <summary>
        /// 获取可以提交自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetSubmitOwnFormUsers(Guid businessFlowCode)
        {
            return oBLL.GetSubmitOwnFormUsers(businessFlowCode);
        }

        /// <summary>
        /// 获取可以审核自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetCheckOwnFormUsers(Guid businessFlowCode)
        {
            return oBLL.GetCheckOwnFormUsers(businessFlowCode);
        }

        /// <summary>
        /// 根据用户Guid，获取可以审核自定义表单的集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetCheckOwnFormsByUser(Guid businessFlowCode, Guid userCode)
        {
            return oBLL.GetCheckOwnFormsByUser(businessFlowCode, userCode);
        }

    }
}
