using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.Customer
{
    /// <summary>
    /// 数据访问类:虚拟用户表
    /// 作者：贺太玉
    /// 日期：2015/06/17
    /// </summary>
    public partial class V_User
    {
        /// <summary>
        /// 获取可以打开自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="pkType">pk类型,1代表案件;2代表商机</param>
        /// <returns></returns>
        public DataSet GetOpenOwnFormUsers(Guid businessFlowCode,int pkType)
        {
           SqlParameter[] parameters = {
					new SqlParameter("@businessFlowCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@pkType", SqlDbType.Int,4)
				 };
           parameters[0].Value = businessFlowCode;
           parameters[1].Value = pkType;

           DataSet ds = DbHelperSQL.RunProcedure("proc_GetOpenOwnDefineFormUsers", parameters, "PowerUser");
           return ds;
        }

        /// <summary>
        /// 获取可以保存自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public DataSet GetSaveOwnFormUsers(Guid businessFlowFormCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowFormCode", SqlDbType.UniqueIdentifier,16)                
				 };
            parameters[0].Value = businessFlowFormCode;

            DataSet ds = DbHelperSQL.RunProcedure("proc_GetSaveOwnDefineFormUsers", parameters, "PowerUser");
            return ds;
        }

        /// <summary>
        /// 获取可以提交自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetSubmitOwnFormUsers(Guid businessFlowCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowCode", SqlDbType.UniqueIdentifier,16)                
				 };
            parameters[0].Value = businessFlowCode;

            DataSet ds = DbHelperSQL.RunProcedure("proc_GetSubmitOwnDefineFormUsers", parameters, "PowerUser");
            return ds;
        }

        /// <summary>
        /// 获取可以审核自定义表单的用户集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetCheckOwnFormUsers(Guid businessFlowCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowCode", SqlDbType.UniqueIdentifier,16)                
				 };
            parameters[0].Value = businessFlowCode;

            DataSet ds = DbHelperSQL.RunProcedure("proc_GetCheckOwnDefineFormUsers", parameters, "PowerUser");
            return ds;
        }

        /// <summary>
        /// 根据用户Guid，获取可以审核自定义表单的集合(执行存储过程)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public DataSet GetCheckOwnFormsByUser(Guid businessFlowCode,Guid userCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@userCode", SqlDbType.UniqueIdentifier,16)
				 };
            parameters[0].Value = businessFlowCode;
            parameters[1].Value = userCode;

            DataSet ds = DbHelperSQL.RunProcedure("proc_GetCheckOwnDefineFormsByUser", parameters, "PowerUser");
            return ds;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.Customer.V_User DataRowToModel(DataRow row)
        {
            CommonService.Model.Customer.V_User model = new CommonService.Model.Customer.V_User();
            if (row != null)
            {
                if (row["UserCode"] != null && row["UserCode"].ToString() != "")
                {
                    model.UserCode = new Guid(row["UserCode"].ToString());
                }               
                //检查"业务流程表单关联Guid"是否存在于列集合中
                if (row.Table.Columns.Contains("BusinessFlowFormCode"))
                {
                    if (row["BusinessFlowFormCode"] != null && row["BusinessFlowFormCode"].ToString() != "")
                    {
                        model.BusinessFlowFormCode = new Guid(row["BusinessFlowFormCode"].ToString());
                    }
                }
            }
            return model;
        }


    }
}
