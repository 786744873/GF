using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:角色----按钮中间表
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Role_button
    {
        public C_Role_button()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Role_button model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Role_button(");
            strSql.Append("C_Roles_id,C_Menu_buttons_id)");
            strSql.Append(" values (");
            strSql.Append("@C_Roles_id,@C_Menu_buttons_id)");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Menu_buttons_id;

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
        public bool Update(CommonService.Model.SysManager.C_Role_button model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Role_button set ");
            strSql.Append("C_Roles_id=@C_Roles_id,");
            strSql.Append("C_Menu_buttons_id=@C_Menu_buttons_id");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Menu_buttons_id;

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
        public bool Delete(int C_Roles_id, int C_Menu_buttons_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Role_button ");
            strSql.Append(" where C_Roles_id=@C_Roles_id ");
            strSql.Append("and C_Menu_buttons_id=@C_Menu_buttons_id");

            SqlParameter[] parameters = {new SqlParameter("@C_Roles_id",SqlDbType.Int,4),
                                         new SqlParameter("@C_Menu_buttons_id",SqlDbType.Int,4)
			};
            parameters[0].Value = C_Roles_id;
            parameters[1].Value = C_Menu_buttons_id;

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
        public bool DeleteByMenuId(int C_Roles_id, int C_Menu_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Role_button where C_Menu_buttons_id in (select C_Menu_buttons_id from C_Menu_buttons where C_Menu_id=@C_Menu_id) ");
            strSql.Append("and C_Roles_id=@C_Roles_id ");

            SqlParameter[] parameters = {new SqlParameter("@C_Roles_id",SqlDbType.Int,4),
                                         new SqlParameter("@C_Menu_id",SqlDbType.Int,4)
			};
            parameters[0].Value = C_Roles_id;
            parameters[1].Value = C_Menu_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows >= 0)
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
        public CommonService.Model.SysManager.C_Role_button GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Roles_id,C_Menu_buttons_id from C_Role_button ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            CommonService.Model.SysManager.C_Role_button model = new CommonService.Model.SysManager.C_Role_button();
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
        public CommonService.Model.SysManager.C_Role_button DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Role_button model = new CommonService.Model.SysManager.C_Role_button();
            if (row != null)
            {
                if (row["C_Roles_id"] != null && row["C_Roles_id"].ToString() != "")
                {
                    model.C_Roles_id = int.Parse(row["C_Roles_id"].ToString());
                }
                if (row["C_Menu_buttons_id"] != null && row["C_Menu_buttons_id"].ToString() != "")
                {
                    model.C_Menu_buttons_id = int.Parse(row["C_Menu_buttons_id"].ToString());
                }
                //判断按钮名称(虚拟属性)是否存在
                if (row.Table.Columns.Contains("C_Menu_buttons_name"))
                {
                    if (row["C_Menu_buttons_name"] != null && row["C_Menu_buttons_name"].ToString() != "")
                    {
                        model.C_Menu_buttons_name = row["C_Menu_buttons_name"].ToString();
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
            strSql.Append("select C_Roles_id,C_Menu_buttons_id ");
            strSql.Append(" FROM C_Role_button ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据角色Id，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataSet GetButtonsByRoleId(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("from C_Role_button ");
            strSql.Append("where C_Roles_id=@C_Roles_id ");

            SqlParameter[] parameters = {new SqlParameter("@C_Roles_id",SqlDbType.Int,4)                                      
			};
            parameters[0].Value = roleId;
       
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户Code，获取用户关联按钮集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public DataSet GetButtonsByUserCode(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RB.* ");
            strSql.Append("from C_Role_button As RB with(nolock) ");
            strSql.Append("where exists(select 1 from C_Organization_post_user_role As OPUR with(nolock) where OPUR.C_Role_id=RB.C_Roles_id and OPUR.C_User_code=@C_User_code) ");

            SqlParameter[] parameters = {new SqlParameter("@C_User_code",SqlDbType.UniqueIdentifier,16)                                      
			};

            parameters[0].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据角色Id集合，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataSet GetButtonsListByRolesId(string  rolesId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("from C_Role_button ");
            strSql.Append("where C_Roles_id in ("+rolesId+") ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        // <summary>
        /// 根据组织机构Guid、用户Guid、岗位Guid，获取关联角色关联按钮集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>    
        public DataSet GetButtonsListByOrgUserPostCode(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RB.* ");
            strSql.Append("from C_Role_button As RB with(nolock) ");
            strSql.Append("where ");
            strSql.Append("exists(select 1 from C_Organization_post_user_role As OPUR with(nolock),C_Roles As R with(nolock) ");
            strSql.Append("where OPUR.C_Role_id=R.C_Roles_id and OPUR.C_Organization_post_user_role_isDelete=0 and R.C_Roles_isDelete=0 ");
            strSql.Append("and RB.C_Roles_id=OPUR.C_Role_id ");
            strSql.Append("and OPUR.C_Organization_code=@C_Organization_code ");
            strSql.Append("and OPUR.C_User_code=@C_User_code ");
            strSql.Append("and OPUR.C_Post_code=@C_Post_code) ");

            SqlParameter[] parameters = {
                                            new SqlParameter("@C_Organization_code",SqlDbType.UniqueIdentifier,16),
                                            new SqlParameter("@C_User_code",SqlDbType.UniqueIdentifier,16),
                                            new SqlParameter("@C_Post_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = userCode;
            parameters[2].Value = postCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByMenuId(int C_Roles_id, int C_Menu_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RB.*,MB.C_Menu_buttons_name ");
            strSql.Append("from C_Role_button as RB left join C_Menu_buttons as MB on RB.C_Menu_buttons_id=MB.C_Menu_buttons_id ");
            strSql.Append("where RB.C_Roles_id=@C_Roles_id ");
            strSql.Append("and MB.C_Menu_id=@C_Menu_id and MB.C_Menu_buttons_isdelete=0");

            SqlParameter[] parameters = {new SqlParameter("@C_Roles_id",SqlDbType.Int,4),
                                         new SqlParameter("@C_Menu_id",SqlDbType.Int,4)
			};
            parameters[0].Value = C_Roles_id;
            parameters[1].Value = C_Menu_id;

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
            strSql.Append(" C_Roles_id,C_Menu_buttons_id ");
            strSql.Append(" FROM C_Role_button ");
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
        public int GetRecordCount(Model.SysManager.C_Role_button model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Role_button ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.C_Roles_id != null)
                {
                    strSql.Append(" and C_Roles_id=@C_Roles_id");
                }
                if (model.C_Menu_buttons_id != null)
                {
                    strSql.Append(" and C_Roles_id=@C_Roles_id");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Menu_buttons_id;
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(Model.SysManager.C_Role_button model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Roles_id desc");
            }
            strSql.Append(")AS Row, T.*,B.C_Menu_buttons_name from C_Role_button T left join C_Menu_buttons as B on T.C_Menu_buttons_id=B.C_Menu_buttons_id ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.C_Roles_id != null)
                {
                    strSql.Append("and T.C_Roles_id=@C_Roles_id ");
                }
                if (model.C_Menu_buttons_id != null)
                {
                    strSql.Append("and T.C_Menu_buttons_id=@C_Menu_buttons_id ");
                }
            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Menu_buttons_id;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            parameters[0].Value = "C_Role_button";
            parameters[1].Value = "C_Parameters_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 根据角色ID删除所有角色与按钮之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>是否成功</returns>
        public bool DeleteRoleButtonByRoleID(int roleID)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Role_button ");
            strSql.Append(" where C_Roles_id=@C_Roles_id");
            SqlParameter[] parameters = {
                new SqlParameter("@C_Roles_id",SqlDbType.Int)
			};
            parameters[0].Value = roleID;

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
        #endregion  ExtensionMethod
    }
}

