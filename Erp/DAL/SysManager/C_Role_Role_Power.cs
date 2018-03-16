using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:角色-角色权限关联表
    /// 作者：贺太玉
    /// 日期：2015/07/09
    /// </summary>
    public partial class C_Role_Role_Power
    {
        public C_Role_Role_Power()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Role_Role_Power_id", "C_Role_Role_Power");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int roleId, int rolePowerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Role_Role_Power ");
            strSql.Append("where C_Roles_id=@C_Roles_id ");
            strSql.Append("and C_Role_Power_id=@C_Role_Power_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Role_Power_id", SqlDbType.Int,4)
			};
            parameters[0].Value = roleId;
            parameters[1].Value = rolePowerId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Role_Role_Power model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Role_Role_Power(");
            strSql.Append("C_Roles_id,C_Role_Power_id)");
            strSql.Append(" values (");
            strSql.Append("@C_Roles_id,@C_Role_Power_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Role_Power_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Role_Power_id;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Role_Role_Power model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Role_Role_Power set ");
            strSql.Append("C_Roles_id=@C_Roles_id,");
            strSql.Append("C_Role_Power_id=@C_Role_Power_id");
            strSql.Append(" where C_Role_Role_Power_id=@C_Role_Role_Power_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Role_Power_id", SqlDbType.Int,4),
					new SqlParameter("@C_Role_Role_Power_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Role_Power_id;
            parameters[2].Value = model.C_Role_Role_Power_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Role_Role_Power_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Role_Role_Power ");
            strSql.Append(" where C_Role_Role_Power_id=@C_Role_Role_Power_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Role_Role_Power_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Role_Role_Power_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_Role_Role_Power_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Role_Role_Power ");
            strSql.Append(" where C_Role_Role_Power_id in (" + C_Role_Role_Power_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Role_Role_Power GetModel(int C_Role_Role_Power_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Role_Power_id,C_Roles_id,C_Role_Power_id from C_Role_Role_Power ");
            strSql.Append(" where C_Role_Power_id=@C_Role_Role_Power_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Role_Role_Power_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Role_Role_Power_id;

            CommonService.Model.SysManager.C_Role_Role_Power model = new CommonService.Model.SysManager.C_Role_Role_Power();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过角色ID，获取关联所有权限集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public DataSet GetRolePowersByRoleId(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CRRP.C_Role_Role_Power_id,CRRP.C_Roles_id,CRRP.C_Role_Power_id,CRP.C_Role_Power_name As C_Role_Power_name ");
            strSql.Append("from C_Role_Role_Power As CRRP ");
            strSql.Append("left join C_Role_Power As CRP on CRRP.C_Role_Power_id =CRP.C_Role_Power_id ");
            strSql.Append("where C_Roles_id=@C_Roles_id ");
            strSql.Append("and CRP.C_Role_Power_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4)
			};
            parameters[0].Value = roleId;
             
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 根据部门Guid、用户Guid、岗位Guid，获取关联所有权限集合
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>       
        public DataSet GetRolePowersByOrgPostUserCode(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CRRP.C_Role_Role_Power_id,CRRP.C_Roles_id,CRRP.C_Role_Power_id,CRP.C_Role_Power_name As C_Role_Power_name ");
            strSql.Append("from C_Role_Role_Power As CRRP ");
            strSql.Append("inner join C_Role_Power As CRP on CRRP.C_Role_Power_id =CRP.C_Role_Power_id ");
            strSql.Append("where ");
            strSql.Append("CRP.C_Role_Power_isDelete=0 ");
            strSql.Append("and exists(");
            strSql.Append("select 1 from C_Organization_post_user_role As OPUR with(nolock) where OPUR.C_Organization_post_user_role_isDelete=0 ");
            strSql.Append("and OPUR.C_Role_id=CRRP.C_Roles_id ");
            strSql.Append("and OPUR.C_Organization_code=@C_Organization_code ");
            strSql.Append("and OPUR.C_User_code=@C_User_code ");
            strSql.Append("and OPUR.C_Post_code=@C_Post_code ");           
            strSql.Append(")");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = userCode;
            parameters[2].Value = postCode;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        
        /// <summary>
        /// 根据用户Guid，获取关联所有权限集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>      
        public DataSet GetRolePowersByUserCode(Guid? userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CRRP.C_Role_Role_Power_id,CRRP.C_Roles_id,CRRP.C_Role_Power_id,CRP.C_Role_Power_name As C_Role_Power_name ");
            strSql.Append("from C_Role_Role_Power As CRRP ");
            strSql.Append("inner join C_Role_Power As CRP on CRRP.C_Role_Power_id =CRP.C_Role_Power_id ");
            strSql.Append("where ");
            strSql.Append("CRP.C_Role_Power_isDelete=0 ");
            strSql.Append("and exists(");
            strSql.Append("select 1 from C_Organization_post_user_role As OPUR with(nolock) where OPUR.C_Organization_post_user_role_isDelete=0 ");
            strSql.Append("and OPUR.C_Role_id=CRRP.C_Roles_id ");           
            strSql.Append("and OPUR.C_User_code=@C_User_code ");        
            strSql.Append(")");
            SqlParameter[] parameters = {				 
                    new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16)                  
			};
            parameters[0].Value = userCode;        

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 通过组织机构Guid、用户Guid、岗位Guid，获取关联角色，关联数据权限集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public DataSet GetRolePowersOrgUserPostCode(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CRRP.C_Role_Role_Power_id,CRRP.C_Roles_id,CRRP.C_Role_Power_id,CRP.C_Role_Power_name As C_Role_Power_name ");
            strSql.Append("from C_Role_Role_Power As CRRP,C_Role_Power As CRP  ");
            strSql.Append("where CRRP.C_Role_Power_id =CRP.C_Role_Power_id ");            
            strSql.Append("and CRP.C_Role_Power_isDelete=0 ");
            strSql.Append("and exists(");
            strSql.Append("select 1 from C_Organization_post_user_role As OPUR with(nolock) ");
            strSql.Append("where OPUR.C_Organization_post_user_role_isDelete=0 ");
            strSql.Append("and OPUR.C_Role_id=CRRP.C_Roles_id ");
            strSql.Append("and OPUR.C_Organization_code=@C_Organization_code ");
            strSql.Append("and OPUR.C_User_code=@C_User_code ");
            strSql.Append("and OPUR.C_Post_code=@C_Post_code");
            strSql.Append(")");

            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = userCode;
            parameters[2].Value = postCode;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Role_Role_Power DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Role_Role_Power model = new CommonService.Model.SysManager.C_Role_Role_Power();
            if (row != null)
            {
                if (row["C_Role_Role_Power_id"] != null && row["C_Role_Role_Power_id"].ToString() != "")
                {
                    model.C_Role_Role_Power_id = int.Parse(row["C_Role_Role_Power_id"].ToString());
                }
                if (row["C_Roles_id"] != null && row["C_Roles_id"].ToString() != "")
                {
                    model.C_Roles_id = int.Parse(row["C_Roles_id"].ToString());
                }
                if (row["C_Role_Power_id"] != null && row["C_Role_Power_id"].ToString() != "")
                {
                    model.C_Role_Power_id = int.Parse(row["C_Role_Power_id"].ToString());
                }
                //角色权限名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Role_Power_name"))
                {
                    if (row["C_Role_Power_name"] != null)
                    {
                        model.C_Role_Power_name = row["C_Role_Power_name"].ToString();
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Role_Role_Power_id,C_Roles_id,C_Role_Power_id ");
            strSql.Append(" FROM C_Role_Role_Power ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据首席专家获得关联部长权限数据列表
        /// </summary>
        public DataSet GetListByChiefExpertCode(Guid C_ChiefExpert_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RRP.C_Role_Role_Power_id,RRP.C_Roles_id,RRP.C_Role_Power_id from C_Role_Role_Power as RRP ");
            strSql.Append(" where exists(select * from C_Userinfo as U,C_ChiefExpert_Minister as CM where U.C_Userinfo_code=CM.C_Minister_Code and U.C_Userinfo_roleID=RRP.C_Roles_id and CM.C_ChiefExpert_Code=@C_ChiefExpert_Code)");
            SqlParameter[] parameters = {
					new SqlParameter("@C_ChiefExpert_Code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_ChiefExpert_Code;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" C_Role_Role_Power_id,C_Roles_id,C_Role_Power_id ");
            strSql.Append(" FROM C_Role_Role_Power ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Role_Role_Power ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.C_Role_Role_Power_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Role_Role_Power T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "C_Role_Role_Power";
            parameters[1].Value = "C_Role_Role_Power_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
