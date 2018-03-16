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
    /// 虚拟稽查表数据访问类
    /// 作者：贺太玉
    /// 日期：2015/11/19
    /// </summary>
    public partial class V_CheckAuthority
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.Customer.V_CheckAuthority DataRowToModel(DataRow row)
        {
            CommonService.Model.Customer.V_CheckAuthority model = new CommonService.Model.Customer.V_CheckAuthority();
            if (row != null)
            {
                //检查"名称"是否存在于列集合中
                if (row.Table.Columns.Contains("AuthorityName"))
                {
                    if (row["AuthorityName"] != null)
                    {
                        model.AuthorityName = row["AuthorityName"].ToString();
                    }
                }
                //检查"类型"是否存在于列集合中
                if (row.Table.Columns.Contains("AuthorityType"))
                {
                    if (row["AuthorityType"] != null && row["AuthorityType"].ToString() != "")
                    {
                        model.AuthorityType = int.Parse(row["AuthorityType"].ToString());
                    }
                }
                //检查"次数"是否存在于列集合中
                if (row.Table.Columns.Contains("AuthorityTime"))
                {
                    if (row["AuthorityTime"] != null && row["AuthorityTime"].ToString() != "")
                    {
                        model.AuthorityTime = int.Parse(row["AuthorityTime"].ToString());
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 根据业务Guid，获取简要稽查信息
        /// </summary>
        /// <param name="pkCode">业务Guid,比如案件Guid</param>
        /// <returns></returns>
        public DataSet GetBriefCheckAuthorityByPkCode(Guid pkCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@pkCode", SqlDbType.UniqueIdentifier,16)                    
				 };
            parameters[0].Value = pkCode;

            DataSet ds = DbHelperSQL.RunProcedure("proc_GetBriefCheckAuthorityStatistics", parameters, "CheckAuthorityStatistics");
            return ds;
        }
    }
}
