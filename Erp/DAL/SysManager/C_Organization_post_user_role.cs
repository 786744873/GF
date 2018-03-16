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
    /// 数据访问类:组织机构—岗位—人员-角色中间表
    /// 作者：贺太玉
    /// 日期：2016/01/20
    /// </summary>
    public partial class C_Organization_post_user_role
    {
        public C_Organization_post_user_role()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Organization_post_user_role_id", "C_Organization_post_user_role");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Organization_post_user_role_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Organization_post_user_role");
            strSql.Append(" where C_Organization_post_user_role_id=@C_Organization_post_user_role_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_post_user_role_id", SqlDbType.Int,4)			};
            parameters[0].Value = C_Organization_post_user_role_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Organization_post_user_role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Organization_post_user_role(");
            strSql.Append("C_Organization_code,C_Post_code,C_User_code,C_Role_id,C_Organization_post_user_role_isDelete,C_Organization_post_user_role_deleteTime,C_Organization_post_user_role_creator,C_Organization_post_user_role_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Organization_code,@C_Post_code,@C_User_code,@C_Role_id,@C_Organization_post_user_role_isDelete,@C_Organization_post_user_role_deleteTime,@C_Organization_post_user_role_creator,@C_Organization_post_user_role_createTime)");
            SqlParameter[] parameters = {				 
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Role_id", SqlDbType.Int),
					new SqlParameter("@C_Organization_post_user_role_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_post_user_role_deleteTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_post_user_role_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_user_role_createTime", SqlDbType.DateTime)};
         
            parameters[0].Value = model.C_Organization_code;
            parameters[1].Value = model.C_Post_code;
            parameters[2].Value = model.C_User_code;
            parameters[3].Value = model.C_Role_id;
            parameters[4].Value = model.C_Organization_post_user_role_isDelete;
            parameters[5].Value = model.C_Organization_post_user_role_deleteTime;
            parameters[6].Value = model.C_Organization_post_user_role_creator;
            parameters[7].Value = model.C_Organization_post_user_role_createTime;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Organization_post_user_role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization_post_user_role set ");
            strSql.Append("C_Organization_code=@C_Organization_code,");
            strSql.Append("C_Post_code=@C_Post_code,");
            strSql.Append("C_User_code=@C_User_code,");
            strSql.Append("C_Role_id=@C_Role_id,");
            strSql.Append("C_Organization_post_user_role_isDelete=@C_Organization_post_user_role_isDelete,");
            strSql.Append("C_Organization_post_user_role_deleteTime=@C_Organization_post_user_role_deleteTime,");
            strSql.Append("C_Organization_post_user_role_creator=@C_Organization_post_user_role_creator,");
            strSql.Append("C_Organization_post_user_role_createTime=@C_Organization_post_user_role_createTime");
            strSql.Append(" where C_Organization_post_user_role_id=@C_Organization_post_user_role_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Role_id", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_post_user_role_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_post_user_role_deleteTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_post_user_role_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_user_role_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_post_user_role_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Organization_code;
            parameters[1].Value = model.C_Post_code;
            parameters[2].Value = model.C_User_code;
            parameters[3].Value = model.C_Role_id;
            parameters[4].Value = model.C_Organization_post_user_role_isDelete;
            parameters[5].Value = model.C_Organization_post_user_role_deleteTime;
            parameters[6].Value = model.C_Organization_post_user_role_creator;
            parameters[7].Value = model.C_Organization_post_user_role_createTime;
            parameters[8].Value = model.C_Organization_post_user_role_id;

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
        /// 删除关联组织机构-用户-岗位-角色数据
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public bool Delete(Guid orgCode, Guid userCode, Guid postCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization_post_user_role set ");
            strSql.Append("C_Organization_post_user_role_isDelete=1,C_Organization_post_user_role_deleteTime=getdate() ");
            strSql.Append("where C_Organization_code=@C_Organization_code and C_User_code=@C_User_code and C_Post_code=@C_Post_code ");
            strSql.Append("and C_Organization_post_user_role_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),		
	                new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),		
                    new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = orgCode;
            parameters[1].Value = userCode;
            parameters[2].Value = postCode;

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
        public bool Delete(int C_Organization_post_user_role_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Organization_post_user_role ");
            strSql.Append(" where C_Organization_post_user_role_id=@C_Organization_post_user_role_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_post_user_role_id", SqlDbType.Int,4)			};
            parameters[0].Value = C_Organization_post_user_role_id;

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
        public bool DeleteList(string C_Organization_post_user_role_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Organization_post_user_role ");
            strSql.Append(" where C_Organization_post_user_role_id in (" + C_Organization_post_user_role_idlist + ")  ");
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
        public CommonService.Model.SysManager.C_Organization_post_user_role GetModel(int C_Organization_post_user_role_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Organization_post_user_role_id,C_Organization_code,C_Post_code,C_User_code,C_Role_id,C_Organization_post_user_role_isDelete,C_Organization_post_user_role_deleteTime,C_Organization_post_user_role_creator,C_Organization_post_user_role_createTime from C_Organization_post_user_role ");
            strSql.Append(" where C_Organization_post_user_role_id=@C_Organization_post_user_role_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_post_user_role_id", SqlDbType.Int,4)			};
            parameters[0].Value = C_Organization_post_user_role_id;

            CommonService.Model.SysManager.C_Organization_post_user_role model = new CommonService.Model.SysManager.C_Organization_post_user_role();
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
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post_user_role GetModelByOrgAndPostAndUser(Guid orgCode,Guid postCode,Guid userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Organization_post_user_role_id,C_Organization_code,C_Post_code,C_User_code,C_Role_id,C_Organization_post_user_role_isDelete,C_Organization_post_user_role_deleteTime,C_Organization_post_user_role_creator,C_Organization_post_user_role_createTime from C_Organization_post_user_role ");
            strSql.Append(" where C_Organization_post_user_role_isDelete=0");
            strSql.Append(" and C_Organization_code=@C_Organization_code");
            strSql.Append(" and C_Post_code=@C_Post_code");
            strSql.Append(" and C_User_code=@C_User_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Post_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_User_code",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = orgCode;
            parameters[1].Value = postCode;
            parameters[2].Value = userCode;

            CommonService.Model.SysManager.C_Organization_post_user_role model = new CommonService.Model.SysManager.C_Organization_post_user_role();
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
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post_user_role DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Organization_post_user_role model = new CommonService.Model.SysManager.C_Organization_post_user_role();
            if (row != null)
            {
                if (row["C_Organization_post_user_role_id"] != null && row["C_Organization_post_user_role_id"].ToString() != "")
                {
                    model.C_Organization_post_user_role_id = int.Parse(row["C_Organization_post_user_role_id"].ToString());
                }
                if (row["C_Organization_code"] != null && row["C_Organization_code"].ToString() != "")
                {
                    model.C_Organization_code = new Guid(row["C_Organization_code"].ToString());
                }
                if (row["C_Post_code"] != null && row["C_Post_code"].ToString() != "")
                {
                    model.C_Post_code = new Guid(row["C_Post_code"].ToString());
                }
                if (row["C_User_code"] != null && row["C_User_code"].ToString() != "")
                {
                    model.C_User_code = new Guid(row["C_User_code"].ToString());
                }
                if (row["C_Role_id"] != null && row["C_Role_id"].ToString() != "")
                {
                    model.C_Role_id = int.Parse(row["C_Role_id"].ToString());
                }
                if (row["C_Organization_post_user_role_isDelete"] != null && row["C_Organization_post_user_role_isDelete"].ToString() != "")
                {
                    if ((row["C_Organization_post_user_role_isDelete"].ToString() == "1") || (row["C_Organization_post_user_role_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Organization_post_user_role_isDelete = true;
                    }
                    else
                    {
                        model.C_Organization_post_user_role_isDelete = false;
                    }
                }
                if (row["C_Organization_post_user_role_deleteTime"] != null && row["C_Organization_post_user_role_deleteTime"].ToString() != "")
                {
                    model.C_Organization_post_user_role_deleteTime = DateTime.Parse(row["C_Organization_post_user_role_deleteTime"].ToString());
                }
                if (row["C_Organization_post_user_role_creator"] != null && row["C_Organization_post_user_role_creator"].ToString() != "")
                {
                    model.C_Organization_post_user_role_creator = new Guid(row["C_Organization_post_user_role_creator"].ToString());
                }
                if (row["C_Organization_post_user_role_createTime"] != null && row["C_Organization_post_user_role_createTime"].ToString() != "")
                {
                    model.C_Organization_post_user_role_createTime = DateTime.Parse(row["C_Organization_post_user_role_createTime"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        /// 根据组织机构Guid，用户Guid，岗位Guid,获取关联角色关系数据集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public DataSet GetOrgUserPostRoles(Guid orgCode, Guid userCode, Guid postCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OPUR.* ");
            strSql.Append("from C_Organization_post_user_role As OPUR with(nolock) ");
            strSql.Append("where OPUR.C_Organization_post_user_role_isDelete=0 ");
            strSql.Append("and OPUR.C_Organization_code=@C_Organization_code ");
            strSql.Append("and OPUR.C_User_code=@C_User_code ");
            strSql.Append("and OPUR.C_Post_code=@C_Post_code ");

            SqlParameter[] parameters = {					
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),  
                    new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = orgCode;
            parameters[1].Value = userCode;
            parameters[2].Value = postCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据用户code获得集合
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public DataSet GetListByUserCode(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OPUR.* ");
            strSql.Append("from C_Organization_post_user_role As OPUR with(nolock) ");
            strSql.Append("where OPUR.C_Organization_post_user_role_isDelete=0 ");
            strSql.Append("and OPUR.C_User_code=@C_User_code ");
            SqlParameter[] parameters = {					
                    new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Organization_post_user_role_id,C_Organization_code,C_Post_code,C_User_code,C_Role_id,C_Organization_post_user_role_isDelete,C_Organization_post_user_role_deleteTime,C_Organization_post_user_role_creator,C_Organization_post_user_role_createTime ");
            strSql.Append(" FROM C_Organization_post_user_role ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" C_Organization_post_user_role_id,C_Organization_code,C_Post_code,C_User_code,C_Role_id,C_Organization_post_user_role_isDelete,C_Organization_post_user_role_deleteTime,C_Organization_post_user_role_creator,C_Organization_post_user_role_createTime ");
            strSql.Append(" FROM C_Organization_post_user_role ");
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
            strSql.Append("select count(1) FROM C_Organization_post_user_role ");
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
                strSql.Append("order by T.C_Organization_post_user_role_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Organization_post_user_role T ");
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
            parameters[0].Value = "C_Organization_post_user_role";
            parameters[1].Value = "C_Organization_post_user_role_id";
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
