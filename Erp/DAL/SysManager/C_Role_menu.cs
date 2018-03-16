using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.SysManager
{
	/// <summary>
	/// 数据访问类:角色---菜单中间表
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	public partial class C_Role_menu
	{
		public C_Role_menu()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.SysManager.C_Role_menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Role_menu(");
			strSql.Append("C_Roles_id,C_Menu_id)");
			strSql.Append(" values (");
			strSql.Append("@C_Roles_id,@C_Menu_id)");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Roles_id;
			parameters[1].Value = model.C_Menu_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Update(CommonService.Model.SysManager.C_Role_menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Role_menu set ");
			strSql.Append("C_Roles_id=@C_Roles_id,");
			strSql.Append("C_Menu_id=@C_Menu_id");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Roles_id;
			parameters[1].Value = model.C_Menu_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Delete(int C_Roles_id, int C_Menu_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Role_menu ");
            strSql.Append(" where C_Roles_id=@C_Roles_id ");
            strSql.Append("and C_Menu_id=@C_Menu_id ");
            SqlParameter[] parameters = {new SqlParameter("@C_Roles_id",SqlDbType.Int,4),
                                         new SqlParameter("@C_Menu_id",SqlDbType.Int,4)
			};
            parameters[0].Value = C_Roles_id;
            parameters[1].Value = C_Menu_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public CommonService.Model.SysManager.C_Role_menu GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_Roles_id,C_Menu_id from C_Role_menu ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

            CommonService.Model.SysManager.C_Role_menu model = new CommonService.Model.SysManager.C_Role_menu();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public CommonService.Model.SysManager.C_Role_menu DataRowToModel(DataRow row)
		{
            CommonService.Model.SysManager.C_Role_menu model = new CommonService.Model.SysManager.C_Role_menu();
			if (row != null)
			{
				if(row["C_Roles_id"]!=null && row["C_Roles_id"].ToString()!="")
				{
					model.C_Roles_id=int.Parse(row["C_Roles_id"].ToString());
				}
				if(row["C_Menu_id"]!=null && row["C_Menu_id"].ToString()!="")
				{
					model.C_Menu_id=int.Parse(row["C_Menu_id"].ToString());
				}
                //判断菜单名称(虚拟属性)是否存在
                if(row.Table.Columns.Contains("C_Menu_name"))
                {
                    if (row["C_Menu_name"] != null && row["C_Menu_name"].ToString() != "")
                    {
                        model.C_Menu_name = row["C_Menu_name"].ToString();
                    }
                }
                //判断父级菜单(虚拟属性)是否存在
                if(row.Table.Columns.Contains("C_Menu_parent"))
                {
                    if (row["C_Menu_parent"] != null && row["C_Menu_parent"].ToString() != "")
                    {
                        model.C_Menu_parent =int.Parse(row["C_Menu_parent"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_Roles_id,C_Menu_id ");
			strSql.Append(" FROM C_Role_menu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByRoleId(int C_Roles_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RM.*,M.C_Menu_name,M.C_Menu_parent ");
            strSql.Append("from C_Role_menu as RM left join C_Menu as M on RM.C_Menu_id=M.C_Menu_id ");
            strSql.Append("where RM.C_Roles_id=@C_Roles_id ");
            SqlParameter[] parameters = {new SqlParameter("@C_Roles_id",SqlDbType.Int,4)
			};
            parameters[0].Value = C_Roles_id;

            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" C_Roles_id,C_Menu_id ");
			strSql.Append(" FROM C_Role_menu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
        public int GetRecordCount(Model.SysManager.C_Role_menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Role_menu ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.C_Roles_id != null)
                {
                    strSql.Append(" and C_Roles_id=@C_Roles_id");
                }
                if (model.C_Menu_id != null)
                {
                    strSql.Append(" and C_Menu_id=@C_Menu_id");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Menu_id;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
        public DataSet GetListByPage(Model.SysManager.C_Role_menu model, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
                strSql.Append("order by T.C_Roles_id desc");
			}
            strSql.Append(")AS Row, T.*,M.C_Menu_name  from C_Role_menu T left join C_Menu as M on T.C_Menu_id=M.C_Menu_id ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            { 
                if(model.C_Menu_id!=null)
                {
                    strSql.Append(" and T.C_Menu_id=@C_Menu_id");
                }
                if(model.C_Roles_id!=null)
                {
                    strSql.Append(" and T.C_Roles_id=@C_Roles_id");
                }
            }
			
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Menu_id;
			return DbHelperSQL.Query(strSql.ToString(),parameters);
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
			parameters[0].Value = "C_Role_menu";
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
        /// 根据角色ID删除所有角色与菜单之间的关系
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool DeleteRoleMenuByRoleID(int roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Role_menu ");
            strSql.Append(" where C_Roles_id=@C_Roles_id");
            SqlParameter[] parameters = {
                        new SqlParameter("@C_Roles_id",SqlDbType.Int,4)
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

