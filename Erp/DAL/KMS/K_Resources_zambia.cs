using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// 数据访问类:K_Resources_zambia
    /// 作者：崔慧栋
    /// 日期：2015/11/2
    /// </summary>
	public partial class K_Resources_zambia
	{
		public K_Resources_zambia()
		{}
		#region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid K_Resources_code, Guid C_Userinfo_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Resources_zambia");
            strSql.Append(" where K_Resources_code=@K_Resources_code ");
            strSql.Append(" and C_Userinfo_code=@C_Userinfo_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Resources_code;
            parameters[1].Value = C_Userinfo_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.KMS.K_Resources_zambia model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into K_Resources_zambia(");
			strSql.Append("K_Resources_code,C_Userinfo_code,K_Resources_zambia_createTime,K_Resources_zambia_isDelete,K_Resources_zambia_type)");
			strSql.Append(" values (");
			strSql.Append("@K_Resources_code,@C_Userinfo_code,@K_Resources_zambia_createTime,@K_Resources_zambia_isDelete,@K_Resources_zambia_type)");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_zambia_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Resources_zambia_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_zambia_type", SqlDbType.Int,4)};
            parameters[0].Value = model.K_Resources_code;
            parameters[1].Value = model.C_Userinfo_code;
			parameters[2].Value = model.K_Resources_zambia_createTime;
			parameters[3].Value = model.K_Resources_zambia_isDelete;
			parameters[4].Value = model.K_Resources_zambia_type;

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
        public bool Update(CommonService.Model.KMS.K_Resources_zambia model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update K_Resources_zambia set ");
			strSql.Append("K_Resources_code=@K_Resources_code,");
			strSql.Append("C_Userinfo_code=@C_Userinfo_code,");
			strSql.Append("K_Resources_zambia_createTime=@K_Resources_zambia_createTime,");
			strSql.Append("K_Resources_zambia_isDelete=@K_Resources_zambia_isDelete,");
			strSql.Append("K_Resources_zambia_type=@K_Resources_zambia_type");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_zambia_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Resources_zambia_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_zambia_type", SqlDbType.Int,4)};
			parameters[0].Value = model.K_Resources_code;
			parameters[1].Value = model.C_Userinfo_code;
			parameters[2].Value = model.K_Resources_zambia_createTime;
			parameters[3].Value = model.K_Resources_zambia_isDelete;
			parameters[4].Value = model.K_Resources_zambia_type;

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
			strSql.Append("delete from K_Resources_zambia ");
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
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.KMS.K_Resources_zambia GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 K_Resources_code,C_Userinfo_code,K_Resources_zambia_createTime,K_Resources_zambia_isDelete,K_Resources_zambia_type from K_Resources_zambia ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

            CommonService.Model.KMS.K_Resources_zambia model = new CommonService.Model.KMS.K_Resources_zambia();
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
        /// 根据条件得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Resources_zambia GetModelByModel(CommonService.Model.KMS.K_Resources_zambia model)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Resources_code,C_Userinfo_code,K_Resources_zambia_createTime,K_Resources_zambia_isDelete,K_Resources_zambia_type from K_Resources_zambia ");
            strSql.Append(" where 1=1");
            if (model != null)
            {
                if (model.K_Resources_code != null)
                    strSql.Append(" and K_Resources_code=@K_Resources_code");
                if (model.C_Userinfo_code != null)
                    strSql.Append(" and C_Userinfo_code=@C_Userinfo_code");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier, 16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier, 16)
					};
            parameters[0].Value = model.K_Resources_code;
            parameters[1].Value = model.C_Userinfo_code;
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
        public CommonService.Model.KMS.K_Resources_zambia DataRowToModel(DataRow row)
		{
            CommonService.Model.KMS.K_Resources_zambia model = new CommonService.Model.KMS.K_Resources_zambia();
			if (row != null)
			{
				if(row["K_Resources_code"]!=null && row["K_Resources_code"].ToString()!="")
				{
					model.K_Resources_code= new Guid(row["K_Resources_code"].ToString());
				}
				if(row["C_Userinfo_code"]!=null && row["C_Userinfo_code"].ToString()!="")
				{
					model.C_Userinfo_code= new Guid(row["C_Userinfo_code"].ToString());
				}
				if(row["K_Resources_zambia_createTime"]!=null && row["K_Resources_zambia_createTime"].ToString()!="")
				{
					model.K_Resources_zambia_createTime=DateTime.Parse(row["K_Resources_zambia_createTime"].ToString());
				}
				if(row["K_Resources_zambia_isDelete"]!=null && row["K_Resources_zambia_isDelete"].ToString()!="")
				{
					if((row["K_Resources_zambia_isDelete"].ToString()=="1")||(row["K_Resources_zambia_isDelete"].ToString().ToLower()=="true"))
					{
						model.K_Resources_zambia_isDelete=true;
					}
					else
					{
						model.K_Resources_zambia_isDelete=false;
					}
				}
				if(row["K_Resources_zambia_type"]!=null && row["K_Resources_zambia_type"].ToString()!="")
				{
					model.K_Resources_zambia_type=int.Parse(row["K_Resources_zambia_type"].ToString());
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
			strSql.Append("select K_Resources_code,C_Userinfo_code,K_Resources_zambia_createTime,K_Resources_zambia_isDelete,K_Resources_zambia_type ");
			strSql.Append(" FROM K_Resources_zambia ");
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
			strSql.Append(" K_Resources_code,C_Userinfo_code,K_Resources_zambia_createTime,K_Resources_zambia_isDelete,K_Resources_zambia_type ");
			strSql.Append(" FROM K_Resources_zambia ");
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
		public int GetRecordCount(CommonService.Model.KMS.K_Resources_zambia model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM K_Resources_zambia ");

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
        public DataSet GetListByPage(CommonService.Model.KMS.K_Resources_zambia model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from K_Resources_zambia T ");

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
			parameters[0].Value = "K_Resources_zambia";
			parameters[1].Value = "";
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

