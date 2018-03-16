using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace CommonService.DAL.SysManager
{
	/// <summary>
	/// 数据访问类:菜单按钮表
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	public partial class C_Menu_buttons
	{
		public C_Menu_buttons()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("C_Menu_buttons_id", "C_Menu_buttons"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int C_Menu_buttons_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Menu_buttons");
			strSql.Append(" where C_Menu_buttons_id=@C_Menu_buttons_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Menu_buttons_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.SysManager.C_Menu_buttons model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Menu_buttons(");
            strSql.Append("C_Menu_buttons_name,C_Menu_id,C_Menu_buttons_order,C_Menu_Buttons_url,C_Menu_buttons_isdelete,C_Menu_buttons_creator,C_Menu_buttons_createTime )");
			strSql.Append(" values (");
            strSql.Append("@C_Menu_buttons_name,@C_Menu_id,@C_Menu_buttons_order,@C_Menu_Buttons_url,@C_Menu_buttons_isdelete,@C_Menu_buttons_creator,@C_Menu_buttons_createTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_buttons_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_order", SqlDbType.Int,4),
                    new SqlParameter("@C_Menu_Buttons_url", SqlDbType.VarChar,500),
                    new SqlParameter("@C_Menu_buttons_isdelete",SqlDbType.Int,4),
                    new SqlParameter("@C_Menu_buttons_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Menu_buttons_createTime",SqlDbType.DateTime)};
			parameters[0].Value = model.C_Menu_buttons_name;
			parameters[1].Value = model.C_Menu_id;
			parameters[2].Value = model.C_Menu_buttons_order;
            parameters[3].Value = model.C_Menu_Buttons_url;
            parameters[4].Value = model.C_Menu_buttons_isdelete;
            parameters[5].Value = model.C_Menu_buttons_creator;
            parameters[6].Value = model.C_Menu_buttons_createTime;

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
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.SysManager.C_Menu_buttons model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Menu_buttons set ");
			strSql.Append("C_Menu_buttons_name=@C_Menu_buttons_name,");
			strSql.Append("C_Menu_id=@C_Menu_id,");
			strSql.Append("C_Menu_buttons_order=@C_Menu_buttons_order,");
            strSql.Append("C_Menu_Buttons_url=@C_Menu_Buttons_url,");
            strSql.Append("C_Menu_buttons_isdelete=@C_Menu_buttons_isdelete,");
            strSql.Append("C_Menu_buttons_creator=@C_Menu_buttons_creator,");
            strSql.Append("C_Menu_buttons_createTime=@C_Menu_buttons_createTime");
			strSql.Append(" where C_Menu_buttons_id=@C_Menu_buttons_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_buttons_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_order", SqlDbType.Int,4),
                    new SqlParameter("@C_Menu_Buttons_url", SqlDbType.VarChar,500),
                    new SqlParameter("@C_Menu_buttons_isdelete",SqlDbType.Int,4),
                    new SqlParameter("@C_Menu_buttons_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Menu_buttons_createTime",SqlDbType.DateTime),
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Menu_buttons_name;
			parameters[1].Value = model.C_Menu_id;
            parameters[2].Value = model.C_Menu_buttons_order;
            parameters[3].Value = model.C_Menu_Buttons_url;
            parameters[4].Value = model.C_Menu_buttons_isdelete;
            parameters[5].Value = model.C_Menu_buttons_creator;
            parameters[6].Value = model.C_Menu_buttons_createTime;
			parameters[7].Value = model.C_Menu_buttons_id;

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
		public bool Delete(int C_Menu_buttons_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Menu_buttons set ");
            strSql.Append("C_Menu_buttons_isdelete=1 ");
			strSql.Append(" where C_Menu_buttons_id=@C_Menu_buttons_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Menu_buttons_id;

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
        /// 根据菜单ID删除所关联菜单按钮
        /// </summary>
        public bool DeleteByMenuId(int C_Menu_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Menu_buttons set ");
            strSql.Append("C_Menu_buttons_isdelete=1 ");
            strSql.Append(" where C_Menu_id=@C_Menu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Menu_id;

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
		public bool DeleteList(string C_Menu_buttons_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Menu_buttons ");
			strSql.Append(" where C_Menu_buttons_id in ("+C_Menu_buttons_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public CommonService.Model.SysManager.C_Menu_buttons GetModel(int C_Menu_buttons_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 C_Menu_buttons_id,C_Menu_buttons_name,C_Menu_id,C_Menu_buttons_order,C_Menu_Buttons_url,C_Menu_buttons_isdelete,C_Menu_buttons_creator,C_Menu_buttons_createTime from C_Menu_buttons ");
			strSql.Append(" where C_Menu_buttons_id=@C_Menu_buttons_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Menu_buttons_id;

            CommonService.Model.SysManager.C_Menu_buttons model = new CommonService.Model.SysManager.C_Menu_buttons();
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
        /// 通过菜单ID获取菜单下菜单按钮排序列最大的实体对象
		/// </summary>
        public CommonService.Model.SysManager.C_Menu_buttons GetMaxOrderModelByMenuId(int C_Menu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 C_Menu_buttons_id,C_Menu_buttons_name,C_Menu_id,C_Menu_buttons_order,C_Menu_Buttons_url,C_Menu_buttons_isdelete,C_Menu_buttons_creator,C_Menu_buttons_createTime from C_Menu_buttons ");
            strSql.Append(" where C_Menu_id=@C_Menu_id ");
            strSql.Append("order by C_Menu_buttons_order desc ");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Menu_id;

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
        public CommonService.Model.SysManager.C_Menu_buttons DataRowToModel(DataRow row)
		{
            CommonService.Model.SysManager.C_Menu_buttons model = new CommonService.Model.SysManager.C_Menu_buttons();
			if (row != null)
			{
				if(row["C_Menu_buttons_id"]!=null && row["C_Menu_buttons_id"].ToString()!="")
				{
					model.C_Menu_buttons_id=int.Parse(row["C_Menu_buttons_id"].ToString());
				}
				if(row["C_Menu_buttons_name"]!=null)
				{
					model.C_Menu_buttons_name=row["C_Menu_buttons_name"].ToString();
				}
				if(row["C_Menu_id"]!=null && row["C_Menu_id"].ToString()!="")
				{
					model.C_Menu_id=int.Parse(row["C_Menu_id"].ToString());
				}
				if(row["C_Menu_buttons_order"]!=null && row["C_Menu_buttons_order"].ToString()!="")
				{
					model.C_Menu_buttons_order=int.Parse(row["C_Menu_buttons_order"].ToString());
				}
                if (row["C_Menu_Buttons_url"] != null)
                {
                    model.C_Menu_Buttons_url = row["C_Menu_Buttons_url"].ToString();
                }
                if (row["C_Menu_buttons_isdelete"] != null && row["C_Menu_buttons_isdelete"].ToString() != "")
                {
                    model.C_Menu_buttons_isdelete = int.Parse(row["C_Menu_buttons_isdelete"].ToString());
                }
                if (row["C_Menu_buttons_creator"] != null && row["C_Menu_buttons_creator"].ToString() != "")
                {
                    model.C_Menu_buttons_creator = new Guid(row["C_Menu_buttons_creator"].ToString());
                }
                if (row["C_Menu_buttons_createTime"] != null && row["C_Menu_buttons_createTime"].ToString() != "")
                {
                    model.C_Menu_buttons_createTime = DateTime.Parse(row["C_Menu_buttons_createTime"].ToString());
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
            strSql.Append("select C_Menu_buttons_id,C_Menu_buttons_name,C_Menu_id,C_Menu_buttons_order,C_Menu_Buttons_url,C_Menu_buttons_isdelete,C_Menu_buttons_creator,C_Menu_buttons_createTime ");
			strSql.Append(" FROM C_Menu_buttons ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByMenuId(int menuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Menu_buttons_id,C_Menu_buttons_name,C_Menu_id,C_Menu_buttons_order,C_Menu_Buttons_url,C_Menu_buttons_isdelete,C_Menu_buttons_creator,C_Menu_buttons_createTime ");
            strSql.Append("FROM C_Menu_buttons ");
            strSql.Append("where 1=1 and C_Menu_buttons_isdelete=0 ");
            if(menuId!=null)
            {
                strSql.Append("and C_Menu_id=@C_Menu_id ");
            }
            strSql.Append("order by C_Menu_buttons_order asc");

            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)};
            parameters[0].Value = menuId;

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
            strSql.Append(" C_Menu_buttons_id,C_Menu_buttons_name,C_Menu_id,C_Menu_buttons_order,C_Menu_Buttons_url,C_Menu_buttons_isdelete,C_Menu_buttons_creator,C_Menu_buttons_createTime ");
			strSql.Append(" FROM C_Menu_buttons ");
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
        public int GetRecordCount(Model.SysManager.C_Menu_buttons model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Menu_buttons ");
            strSql.Append(" where 1=1 and C_Menu_buttons_isdelete=0 ");
            if (model != null)
            {
                if (model.C_Menu_buttons_name != null && model.C_Menu_buttons_name != "")
                {
                    strSql.Append(" and C_Menu_buttons_name=@C_Menu_buttons_name");
                }
                if (model.C_Menu_id != null)
                {
                    strSql.Append(" and C_Menu_id=@C_Menu_id");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_buttons_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_order", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Menu_buttons_name;
            parameters[1].Value = model.C_Menu_id;
            parameters[2].Value = model.C_Menu_buttons_order;
            parameters[3].Value = model.C_Menu_buttons_id;
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
        public DataSet GetListByPage(Model.SysManager.C_Menu_buttons model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Menu_buttons_id desc");
			}
			strSql.Append(")AS Row, T.*  from C_Menu_buttons T ");
            strSql.Append(" where 1=1 and C_Menu_buttons_isdelete=0 ");
			if(model!=null)
            {
                if (model.C_Menu_buttons_name!=null&&model.C_Menu_buttons_name != "")
                {
                    strSql.Append(" and C_Menu_buttons_name=@C_Menu_buttons_name");
                }
                if(model.C_Menu_id!=null)
                {
                    strSql.Append(" and C_Menu_id=@C_Menu_id");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_buttons_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_order", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_buttons_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Menu_buttons_name;
            parameters[1].Value = model.C_Menu_id;
            parameters[2].Value = model.C_Menu_buttons_order;
            parameters[3].Value = model.C_Menu_buttons_id;
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
			parameters[0].Value = "C_Menu_buttons";
			parameters[1].Value = "C_Menu_buttons_id";
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

