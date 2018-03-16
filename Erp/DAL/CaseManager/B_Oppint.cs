using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件--担保物约定表
    /// 作者：崔慧栋
    /// 日期：2015/06/06
    /// </summary>
	public partial class B_Oppint
	{
		public B_Oppint()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("B_Oppint_id", "B_Oppint");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Oppint_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Oppint");
            strSql.Append(" where B_Oppint_id=@B_Oppint_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Oppint_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Oppint_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_Oppint model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_Oppint(");
			strSql.Append("B_Oppint_code,B_Case_code,B_Oppint_guaranty,B_Oppint_guarantyvalue,B_Oppint_coneed,B_Oppint_creator,B_Oppint_createTime,B_Oppint_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_Oppint_code,@B_Case_code,@B_Oppint_guaranty,@B_Oppint_guarantyvalue,@B_Oppint_coneed,@B_Oppint_creator,@B_Oppint_createTime,@B_Oppint_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Oppint_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Oppint_guaranty", SqlDbType.Int,4),
					new SqlParameter("@B_Oppint_guarantyvalue", SqlDbType.Decimal,9),
					new SqlParameter("@B_Oppint_coneed", SqlDbType.VarChar,500),
					new SqlParameter("@B_Oppint_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Oppint_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Oppint_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.B_Oppint_code;
            parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_Oppint_guaranty;
			parameters[3].Value = model.B_Oppint_guarantyvalue;
			parameters[4].Value = model.B_Oppint_coneed;
            parameters[5].Value = model.B_Oppint_creator;
			parameters[6].Value = model.B_Oppint_createTime;
			parameters[7].Value = model.B_Oppint_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_Oppint model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_Oppint set ");
			strSql.Append("B_Oppint_code=@B_Oppint_code,");
			strSql.Append("B_Case_code=@B_Case_code,");
			strSql.Append("B_Oppint_guaranty=@B_Oppint_guaranty,");
			strSql.Append("B_Oppint_guarantyvalue=@B_Oppint_guarantyvalue,");
			strSql.Append("B_Oppint_coneed=@B_Oppint_coneed,");
			strSql.Append("B_Oppint_creator=@B_Oppint_creator,");
			strSql.Append("B_Oppint_createTime=@B_Oppint_createTime,");
			strSql.Append("B_Oppint_isDelete=@B_Oppint_isDelete");
			strSql.Append(" where B_Oppint_id=@B_Oppint_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Oppint_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Oppint_guaranty", SqlDbType.Int,4),
					new SqlParameter("@B_Oppint_guarantyvalue", SqlDbType.Decimal,9),
					new SqlParameter("@B_Oppint_coneed", SqlDbType.VarChar,500),
					new SqlParameter("@B_Oppint_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Oppint_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Oppint_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_Oppint_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_Oppint_code;
			parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_Oppint_guaranty;
			parameters[3].Value = model.B_Oppint_guarantyvalue;
			parameters[4].Value = model.B_Oppint_coneed;
			parameters[5].Value = model.B_Oppint_creator;
			parameters[6].Value = model.B_Oppint_createTime;
			parameters[7].Value = model.B_Oppint_isDelete;
			parameters[8].Value = model.B_Oppint_id;

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
		public bool Delete(int B_Oppint_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_Oppint set B_Oppint_isDelete=1 ");
			strSql.Append(" where B_Oppint_id=@B_Oppint_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Oppint_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_Oppint_id;

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
		public bool DeleteList(string B_Oppint_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_Oppint ");
			strSql.Append(" where B_Oppint_id in ("+B_Oppint_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_Oppint GetModel(int B_Oppint_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 B_Oppint_id,B_Oppint_code,B_Case_code,B_Oppint_guaranty,B_Oppint_guarantyvalue,B_Oppint_coneed,B_Oppint_creator,B_Oppint_createTime,B_Oppint_isDelete from B_Oppint ");
			strSql.Append(" where B_Oppint_id=@B_Oppint_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Oppint_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_Oppint_id;

            CommonService.Model.CaseManager.B_Oppint model = new CommonService.Model.CaseManager.B_Oppint();
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
        public CommonService.Model.CaseManager.B_Oppint DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_Oppint model = new CommonService.Model.CaseManager.B_Oppint();
			if (row != null)
			{
				if(row["B_Oppint_id"]!=null && row["B_Oppint_id"].ToString()!="")
				{
					model.B_Oppint_id=int.Parse(row["B_Oppint_id"].ToString());
				}
				if(row["B_Oppint_code"]!=null && row["B_Oppint_code"].ToString()!="")
				{
					model.B_Oppint_code= new Guid(row["B_Oppint_code"].ToString());
				}
				if(row["B_Case_code"]!=null && row["B_Case_code"].ToString()!="")
				{
					model.B_Case_code= new Guid(row["B_Case_code"].ToString());
				}
                if (row["B_Oppint_guaranty"] != null && row["B_Oppint_guaranty"].ToString()!="")
				{
					model.B_Oppint_guaranty=int.Parse(row["B_Oppint_guaranty"].ToString());
				}
				if(row["B_Oppint_guarantyvalue"]!=null && row["B_Oppint_guarantyvalue"].ToString()!="")
				{
					model.B_Oppint_guarantyvalue=decimal.Parse(row["B_Oppint_guarantyvalue"].ToString());
				}
				if(row["B_Oppint_coneed"]!=null)
				{
					model.B_Oppint_coneed=row["B_Oppint_coneed"].ToString();
				}
				if(row["B_Oppint_creator"]!=null && row["B_Oppint_creator"].ToString()!="")
				{
					model.B_Oppint_creator= new Guid(row["B_Oppint_creator"].ToString());
				}
				if(row["B_Oppint_createTime"]!=null && row["B_Oppint_createTime"].ToString()!="")
				{
					model.B_Oppint_createTime=DateTime.Parse(row["B_Oppint_createTime"].ToString());
				}
				if(row["B_Oppint_isDelete"]!=null && row["B_Oppint_isDelete"].ToString()!="")
				{
					model.B_Oppint_isDelete=int.Parse(row["B_Oppint_isDelete"].ToString());
				}
                //判断担保物名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("B_Oppint_guaranty_name"))
                { 
                    if(row["B_Oppint_guaranty_name"]!=null && row["B_Oppint_guaranty_name"].ToString()!="")
                    {
                        model.B_Oppint_guaranty_name = row["B_Oppint_guaranty_name"].ToString();
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
			strSql.Append("select B_Oppint_id,B_Oppint_code,B_Case_code,B_Oppint_guaranty,B_Oppint_guarantyvalue,B_Oppint_coneed,B_Oppint_creator,B_Oppint_createTime,B_Oppint_isDelete ");
			strSql.Append(" FROM B_Oppint ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCaseCode(Guid B_Case_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select B_Oppint_id,B_Oppint_code,B_Case_code,B_Oppint_guaranty,B_Oppint_guarantyvalue,B_Oppint_coneed,B_Oppint_creator,B_Oppint_createTime,B_Oppint_isDelete ");
            strSql.Append(" FROM B_Oppint ");
            strSql.Append("where B_Case_code=@B_Case_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = B_Case_code;
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
			strSql.Append(" B_Oppint_id,B_Oppint_code,B_Case_code,B_Oppint_guaranty,B_Oppint_guarantyvalue,B_Oppint_coneed,B_Oppint_creator,B_Oppint_createTime,B_Oppint_isDelete ");
			strSql.Append(" FROM B_Oppint ");
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_Oppint model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM B_Oppint ");
            strSql.Append(" where 1=1 and B_Oppint_isDelete=0 ");
            if (model != null)
            {
                if (model.B_Oppint_code != null && model.B_Oppint_code.ToString() != "")
                {
                    strSql.Append("and B_Oppint_code=@B_Oppint_code ");
                }
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and B_Case_code=@B_Case_code ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_Oppint_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.B_Oppint_code;
            parameters[1].Value = model.B_Case_code;

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
		public DataSet GetListByPage(CommonService.Model.CaseManager.B_Oppint model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.B_Oppint_id desc");
			}
            strSql.Append(")AS Row, T.*,P.C_Parameters_name as 'B_Oppint_guaranty_name' from B_Oppint T left join C_Parameters as P on T.B_Oppint_guaranty=P.C_Parameters_id ");
            strSql.Append(" where 1=1 and B_Oppint_isDelete=0 ");
            if (model != null)
            {
                if (model.B_Oppint_code != null && model.B_Oppint_code.ToString() != "")
                {
                    strSql.Append("and B_Oppint_code=@B_Oppint_code ");
                }
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and B_Case_code=@B_Case_code ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@B_Oppint_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.B_Oppint_code;
            parameters[1].Value = model.B_Case_code;

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
			parameters[0].Value = "B_Oppint";
			parameters[1].Value = "B_Oppint_id";
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

