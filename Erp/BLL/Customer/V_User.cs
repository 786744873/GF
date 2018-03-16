using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Customer
{
    /// <summary>
    /// 虚拟用户表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/06/17
    /// </summary>
    public partial class V_User
    {
        private readonly CommonService.DAL.Customer.V_User dal = new CommonService.DAL.Customer.V_User();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.Customer.V_User> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.Customer.V_User> modelList = new List<CommonService.Model.Customer.V_User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.Customer.V_User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取可以打开自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="pkType">pk类型,1代表案件;2代表商机</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetOpenOwnFormUsers(Guid businessFlowCode, int pkType)
        {
            return DataTableToList(dal.GetOpenOwnFormUsers(businessFlowCode, pkType).Tables[0]);
        }

        /// <summary>
        /// 获取可以保存自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetSaveOwnFormUsers(Guid businessFlowFormCode)
        {
            return DataTableToList(dal.GetSaveOwnFormUsers(businessFlowFormCode).Tables[0]);
        }

        /// <summary>
        /// 获取可以提交自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetSubmitOwnFormUsers(Guid businessFlowCode)
        {
            return DataTableToList(dal.GetSubmitOwnFormUsers(businessFlowCode).Tables[0]);
        }

        /// <summary>
        /// 获取可以审核自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetCheckOwnFormUsers(Guid businessFlowCode)
        {
            return DataTableToList(dal.GetCheckOwnFormUsers(businessFlowCode).Tables[0]);
        }

        /// <summary>
        /// 根据用户Guid，获取可以审核自定义表单的集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_User> GetCheckOwnFormsByUser(Guid businessFlowCode, Guid userCode)
        {
            return DataTableToList(dal.GetCheckOwnFormsByUser(businessFlowCode, userCode).Tables[0]);
        }

    }
}
