using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.CustomerForm
{
    /// <summary>
    /// 数据访问类:表单重做
    /// 作者：贺太玉
    /// 日期：2015/10/09
    /// </summary>
    public partial class F_FormReDone
    {
        /// <summary>
        /// 确认重做表单
        /// </summary>
        /// <param name="fkType">流程类型(案件或商机)</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="newBusinessFlowFormCode">新生成的业务流程表单关联Guid</param>
        /// <param name="operateUserCode">操作人Guid</param>
        /// <returns></returns>
        public void ReDoneForm(int fkType, Guid formCode, Guid businessFlowCode, Guid businessFlowFormCode, Guid newBusinessFlowFormCode, Guid operateUserCode)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@fkType", SqlDbType.Int,4),
					new SqlParameter("@formCode", SqlDbType.UniqueIdentifier,16),                   
                    new SqlParameter("@businessFlowCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@businessFlowFormCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@newBusinessFlowFormCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@operateUserCode", SqlDbType.UniqueIdentifier,16)
				 };
            parameters[0].Value = fkType;
            parameters[1].Value = formCode;
            parameters[2].Value = businessFlowCode;
            parameters[3].Value = businessFlowFormCode;
            parameters[4].Value = newBusinessFlowFormCode;
            parameters[5].Value = operateUserCode;

            DbHelperSQL.RunNoVoidProcedure("proc_ReDoneForm", parameters); 
        }
    }
}
