using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:查询条件记录表
    /// 作者：崔慧栋
    /// 日期：2015/12/03
    /// </summary>
	public partial class C_SearchConditionRecord
	{
		public C_SearchConditionRecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("C_SearchConditionRecord_id", "C_SearchConditionRecord"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int C_SearchConditionRecord_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_SearchConditionRecord");
			strSql.Append(" where C_SearchConditionRecord_id=@C_SearchConditionRecord_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_SearchConditionRecord_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_SearchConditionRecord_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_SearchConditionRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_SearchConditionRecord(");
			strSql.Append("C_SearchConditionRecord_belonging,C_SearchConditionRecord_group,C_SearchConditionRecord_key,C_SearchConditionRecord_value)");
			strSql.Append(" values (");
			strSql.Append("@C_SearchConditionRecord_belonging,@C_SearchConditionRecord_group,@C_SearchConditionRecord_key,@C_SearchConditionRecord_value)");
			SqlParameter[] parameters = {
					new SqlParameter("@C_SearchConditionRecord_belonging", SqlDbType.Int,4),
					new SqlParameter("@C_SearchConditionRecord_group", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_SearchConditionRecord_key", SqlDbType.NVarChar,500),
					new SqlParameter("@C_SearchConditionRecord_value", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.C_SearchConditionRecord_belonging;
            parameters[1].Value = model.C_SearchConditionRecord_group;
			parameters[2].Value = model.C_SearchConditionRecord_key;
			parameters[3].Value = model.C_SearchConditionRecord_value;

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
		public bool Update(CommonService.Model.C_SearchConditionRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_SearchConditionRecord set ");
			strSql.Append("C_SearchConditionRecord_belonging=@C_SearchConditionRecord_belonging,");
			strSql.Append("C_SearchConditionRecord_group=@C_SearchConditionRecord_group,");
			strSql.Append("C_SearchConditionRecord_key=@C_SearchConditionRecord_key,");
			strSql.Append("C_SearchConditionRecord_value=@C_SearchConditionRecord_value");
			strSql.Append(" where C_SearchConditionRecord_id=@C_SearchConditionRecord_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_SearchConditionRecord_belonging", SqlDbType.Int,4),
					new SqlParameter("@C_SearchConditionRecord_group", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_SearchConditionRecord_key", SqlDbType.NVarChar,500),
					new SqlParameter("@C_SearchConditionRecord_value", SqlDbType.NVarChar,500),
					new SqlParameter("@C_SearchConditionRecord_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_SearchConditionRecord_belonging;
			parameters[1].Value = model.C_SearchConditionRecord_group;
			parameters[2].Value = model.C_SearchConditionRecord_key;
			parameters[3].Value = model.C_SearchConditionRecord_value;
			parameters[4].Value = model.C_SearchConditionRecord_id;

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
		public bool Delete(int C_SearchConditionRecord_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_SearchConditionRecord ");
			strSql.Append(" where C_SearchConditionRecord_id=@C_SearchConditionRecord_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_SearchConditionRecord_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_SearchConditionRecord_id;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string C_SearchConditionRecord_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_SearchConditionRecord ");
			strSql.Append(" where C_SearchConditionRecord_id in ("+C_SearchConditionRecord_idlist + ")  ");
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
        public CommonService.Model.C_SearchConditionRecord GetModel(int C_SearchConditionRecord_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_SearchConditionRecord_id,C_SearchConditionRecord_belonging,C_SearchConditionRecord_group,C_SearchConditionRecord_key,C_SearchConditionRecord_value from C_SearchConditionRecord ");
			strSql.Append(" where C_SearchConditionRecord_id=@C_SearchConditionRecord_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_SearchConditionRecord_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_SearchConditionRecord_id;

            CommonService.Model.C_SearchConditionRecord model = new CommonService.Model.C_SearchConditionRecord();
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
        public CommonService.Model.C_SearchConditionRecord DataRowToModel(DataRow row)
		{
            CommonService.Model.C_SearchConditionRecord model = new CommonService.Model.C_SearchConditionRecord();
			if (row != null)
			{
				if(row["C_SearchConditionRecord_id"]!=null && row["C_SearchConditionRecord_id"].ToString()!="")
				{
					model.C_SearchConditionRecord_id=int.Parse(row["C_SearchConditionRecord_id"].ToString());
				}
				if(row["C_SearchConditionRecord_belonging"]!=null && row["C_SearchConditionRecord_belonging"].ToString()!="")
				{
					model.C_SearchConditionRecord_belonging=int.Parse(row["C_SearchConditionRecord_belonging"].ToString());
				}
				if(row["C_SearchConditionRecord_group"]!=null && row["C_SearchConditionRecord_group"].ToString()!="")
				{
					model.C_SearchConditionRecord_group= new Guid(row["C_SearchConditionRecord_group"].ToString());
				}
				if(row["C_SearchConditionRecord_key"]!=null)
				{
					model.C_SearchConditionRecord_key=row["C_SearchConditionRecord_key"].ToString();
				}
				if(row["C_SearchConditionRecord_value"]!=null)
				{
					model.C_SearchConditionRecord_value=row["C_SearchConditionRecord_value"].ToString();
				}
			}
			return model;
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByGroup(Guid C_SearchConditionRecord_group)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_SearchConditionRecord_id,C_SearchConditionRecord_belonging,C_SearchConditionRecord_group,C_SearchConditionRecord_key,C_SearchConditionRecord_value ");
            strSql.Append(" FROM C_SearchConditionRecord ");
            strSql.Append(" where C_SearchConditionRecord_group=@C_SearchConditionRecord_group");
            SqlParameter[] parameters = {
					new SqlParameter("@C_SearchConditionRecord_group", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_SearchConditionRecord_group;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_SearchConditionRecord_id,C_SearchConditionRecord_belonging,C_SearchConditionRecord_group,C_SearchConditionRecord_key,C_SearchConditionRecord_value ");
			strSql.Append(" FROM C_SearchConditionRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" C_SearchConditionRecord_id,C_SearchConditionRecord_belonging,C_SearchConditionRecord_group,C_SearchConditionRecord_key,C_SearchConditionRecord_value ");
			strSql.Append(" FROM C_SearchConditionRecord ");
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
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_SearchConditionRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.C_SearchConditionRecord_id desc");
			}
			strSql.Append(")AS Row, T.*  from C_SearchConditionRecord T ");
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
			parameters[0].Value = "C_SearchConditionRecord";
			parameters[1].Value = "C_SearchConditionRecord_id";
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

