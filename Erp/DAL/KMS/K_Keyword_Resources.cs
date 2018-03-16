using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:关键字和资源中间表
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
	public partial class K_Keyword_Resources
	{
		public K_Keyword_Resources()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.KMS.K_Keyword_Resources model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into K_Keyword_Resources(");
			strSql.Append("K_Keyword_code,K_Resources_code)");
			strSql.Append(" values (");
			strSql.Append("@K_Keyword_code,@K_Resources_code)");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.K_Keyword_code;
			parameters[1].Value = model.K_Resources_code;

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
        public bool Update(CommonService.Model.KMS.K_Keyword_Resources model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update K_Keyword_Resources set ");
			strSql.Append("K_Keyword_code=@K_Keyword_code,");
			strSql.Append("K_Resources_code=@K_Resources_code");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.K_Keyword_code;
			parameters[1].Value = model.K_Resources_code;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from K_Keyword_Resources ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
        /// 根据资源Guid删除关联关键字
        /// </summary>
        /// <param name="resourcesCode">资源Guid</param>
        /// <returns></returns>
        public bool DeleteByResourcesCode(Guid resourcesCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Keyword_Resources ");
            strSql.Append(" where K_Resources_code=@K_Resources_code ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@K_Resources_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = resourcesCode;

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
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.KMS.K_Keyword_Resources GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 K_Keyword_code,K_Resources_code from K_Keyword_Resources ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

            CommonService.Model.KMS.K_Keyword_Resources model = new CommonService.Model.KMS.K_Keyword_Resources();
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
        public CommonService.Model.KMS.K_Keyword_Resources DataRowToModel(DataRow row)
		{
            CommonService.Model.KMS.K_Keyword_Resources model = new CommonService.Model.KMS.K_Keyword_Resources();
			if (row != null)
			{
				if(row["K_Keyword_code"]!=null && row["K_Keyword_code"].ToString()!="")
				{
					model.K_Keyword_code= new Guid(row["K_Keyword_code"].ToString());
				}
				if(row["K_Resources_code"]!=null && row["K_Resources_code"].ToString()!="")
				{
					model.K_Resources_code= new Guid(row["K_Resources_code"].ToString());
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
			strSql.Append("select K_Keyword_code,K_Resources_code ");
			strSql.Append(" FROM K_Keyword_Resources ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据资源Guid获得关联关键字
        /// </summary>
        /// <param name="K_Resources_code"></param>
        /// <returns></returns>
        public DataSet GetListByResourcesCode(Guid K_Resources_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Keyword_code,K_Resources_code ");
            strSql.Append(" FROM K_Keyword_Resources ");
            strSql.Append(" where K_Resources_code=@K_Resources_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = K_Resources_code;
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
			strSql.Append(" K_Keyword_code,K_Resources_code ");
			strSql.Append(" FROM K_Keyword_Resources ");
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
			strSql.Append("select count(1) FROM K_Keyword_Resources ");
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
				strSql.Append("order by T.K_Keyword_id desc");
			}
			strSql.Append(")AS Row, T.*  from K_Keyword_Resources T ");
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
			parameters[0].Value = "K_Keyword_Resources";
			parameters[1].Value = "K_Keyword_id";
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

