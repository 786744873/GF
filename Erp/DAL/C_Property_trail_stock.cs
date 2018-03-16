using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:财产线索股票表
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	public partial class C_Property_trail_stock
	{
		public C_Property_trail_stock()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Property_trail_stock_id", "C_Property_trail_stock");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Property_trail_stock_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Property_trail_stock");
            strSql.Append(" where C_Property_trail_stock_id=@C_Property_trail_stock_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_stock_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Property_trail_stock_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Property_trail_stock model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Property_trail_stock(");
			strSql.Append("C_Property_trail_stock_type,C_Property_trail_stock_belongs,C_Property_trail_stock_code,C_Property_trail_stock_name,C_Property_trail_stock_count,C_Property_trail_stock_price,C_Property_trail_stock_creator,C_Property_trail_stock_createTime,C_Property_trail_stock_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@C_Property_trail_stock_type,@C_Property_trail_stock_belongs,@C_Property_trail_stock_code,@C_Property_trail_stock_name,@C_Property_trail_stock_count,@C_Property_trail_stock_price,@C_Property_trail_stock_creator,@C_Property_trail_stock_createTime,@C_Property_trail_stock_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_stock_type", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_stock_belongs", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Property_trail_stock_code", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_stock_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_stock_count", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_stock_price", SqlDbType.Decimal,9),
					new SqlParameter("@C_Property_trail_stock_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Property_trail_stock_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Property_trail_stock_isDelete", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Property_trail_stock_type;
            parameters[1].Value = model.C_Property_trail_stock_belongs;
			parameters[2].Value = model.C_Property_trail_stock_code;
			parameters[3].Value = model.C_Property_trail_stock_name;
			parameters[4].Value = model.C_Property_trail_stock_count;
			parameters[5].Value = model.C_Property_trail_stock_price;
            parameters[6].Value = model.C_Property_trail_stock_creator;
			parameters[7].Value = model.C_Property_trail_stock_createTime;
			parameters[8].Value = model.C_Property_trail_stock_isDelete;

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
        public bool Update(CommonService.Model.C_Property_trail_stock model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Property_trail_stock set ");
			strSql.Append("C_Property_trail_stock_type=@C_Property_trail_stock_type,");
			strSql.Append("C_Property_trail_stock_belongs=@C_Property_trail_stock_belongs,");
			strSql.Append("C_Property_trail_stock_code=@C_Property_trail_stock_code,");
			strSql.Append("C_Property_trail_stock_name=@C_Property_trail_stock_name,");
			strSql.Append("C_Property_trail_stock_count=@C_Property_trail_stock_count,");
			strSql.Append("C_Property_trail_stock_price=@C_Property_trail_stock_price,");
			strSql.Append("C_Property_trail_stock_creator=@C_Property_trail_stock_creator,");
			strSql.Append("C_Property_trail_stock_createTime=@C_Property_trail_stock_createTime,");
			strSql.Append("C_Property_trail_stock_isDelete=@C_Property_trail_stock_isDelete");
			strSql.Append(" where C_Property_trail_stock_id=@C_Property_trail_stock_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_stock_type", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_stock_belongs", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Property_trail_stock_code", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_stock_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_stock_count", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_stock_price", SqlDbType.Decimal,9),
					new SqlParameter("@C_Property_trail_stock_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Property_trail_stock_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Property_trail_stock_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_stock_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Property_trail_stock_type;
			parameters[1].Value = model.C_Property_trail_stock_belongs;
			parameters[2].Value = model.C_Property_trail_stock_code;
			parameters[3].Value = model.C_Property_trail_stock_name;
			parameters[4].Value = model.C_Property_trail_stock_count;
			parameters[5].Value = model.C_Property_trail_stock_price;
			parameters[6].Value = model.C_Property_trail_stock_creator;
			parameters[7].Value = model.C_Property_trail_stock_createTime;
			parameters[8].Value = model.C_Property_trail_stock_isDelete;
			parameters[9].Value = model.C_Property_trail_stock_id;

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
		public bool Delete(int C_Property_trail_stock_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Property_trail_stock set C_Property_trail_stock_isDelete=1 ");
			strSql.Append(" where C_Property_trail_stock_id=@C_Property_trail_stock_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_stock_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Property_trail_stock_id;

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
		public bool DeleteList(string C_Property_trail_stock_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Property_trail_stock ");
			strSql.Append(" where C_Property_trail_stock_id in ("+C_Property_trail_stock_idlist + ")  ");
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
        public CommonService.Model.C_Property_trail_stock GetModel(int C_Property_trail_stock_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_Property_trail_stock_id,C_Property_trail_stock_type,C_Property_trail_stock_belongs,C_Property_trail_stock_code,C_Property_trail_stock_name,C_Property_trail_stock_count,C_Property_trail_stock_price,C_Property_trail_stock_creator,C_Property_trail_stock_createTime,C_Property_trail_stock_isDelete from C_Property_trail_stock ");
			strSql.Append(" where C_Property_trail_stock_id=@C_Property_trail_stock_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_stock_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Property_trail_stock_id;

            CommonService.Model.C_Property_trail_stock model = new CommonService.Model.C_Property_trail_stock();
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
        public CommonService.Model.C_Property_trail_stock DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Property_trail_stock model = new CommonService.Model.C_Property_trail_stock();
			if (row != null)
			{
				if(row["C_Property_trail_stock_id"]!=null && row["C_Property_trail_stock_id"].ToString()!="")
				{
					model.C_Property_trail_stock_id=int.Parse(row["C_Property_trail_stock_id"].ToString());
				}
				if(row["C_Property_trail_stock_type"]!=null && row["C_Property_trail_stock_type"].ToString()!="")
				{
					model.C_Property_trail_stock_type=int.Parse(row["C_Property_trail_stock_type"].ToString());
				}
				if(row["C_Property_trail_stock_belongs"]!=null && row["C_Property_trail_stock_belongs"].ToString()!="")
				{
					model.C_Property_trail_stock_belongs= new Guid(row["C_Property_trail_stock_belongs"].ToString());
				}
				if(row["C_Property_trail_stock_code"]!=null)
				{
					model.C_Property_trail_stock_code=row["C_Property_trail_stock_code"].ToString();
				}
				if(row["C_Property_trail_stock_name"]!=null)
				{
					model.C_Property_trail_stock_name=row["C_Property_trail_stock_name"].ToString();
				}
				if(row["C_Property_trail_stock_count"]!=null && row["C_Property_trail_stock_count"].ToString()!="")
				{
					model.C_Property_trail_stock_count=int.Parse(row["C_Property_trail_stock_count"].ToString());
				}
				if(row["C_Property_trail_stock_price"]!=null && row["C_Property_trail_stock_price"].ToString()!="")
				{
					model.C_Property_trail_stock_price=decimal.Parse(row["C_Property_trail_stock_price"].ToString());
				}
				if(row["C_Property_trail_stock_creator"]!=null && row["C_Property_trail_stock_creator"].ToString()!="")
				{
					model.C_Property_trail_stock_creator= new Guid(row["C_Property_trail_stock_creator"].ToString());
				}
				if(row["C_Property_trail_stock_createTime"]!=null && row["C_Property_trail_stock_createTime"].ToString()!="")
				{
					model.C_Property_trail_stock_createTime=DateTime.Parse(row["C_Property_trail_stock_createTime"].ToString());
				}
				if(row["C_Property_trail_stock_isDelete"]!=null && row["C_Property_trail_stock_isDelete"].ToString()!="")
				{
					model.C_Property_trail_stock_isDelete=int.Parse(row["C_Property_trail_stock_isDelete"].ToString());
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
			strSql.Append("select C_Property_trail_stock_id,C_Property_trail_stock_type,C_Property_trail_stock_belongs,C_Property_trail_stock_code,C_Property_trail_stock_name,C_Property_trail_stock_count,C_Property_trail_stock_price,C_Property_trail_stock_creator,C_Property_trail_stock_createTime,C_Property_trail_stock_isDelete ");
			strSql.Append(" FROM C_Property_trail_stock ");
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
			strSql.Append(" C_Property_trail_stock_id,C_Property_trail_stock_type,C_Property_trail_stock_belongs,C_Property_trail_stock_code,C_Property_trail_stock_name,C_Property_trail_stock_count,C_Property_trail_stock_price,C_Property_trail_stock_creator,C_Property_trail_stock_createTime,C_Property_trail_stock_isDelete ");
			strSql.Append(" FROM C_Property_trail_stock ");
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
		public int GetRecordCount(Model.C_Property_trail_stock model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM C_Property_trail_stock ");
            strSql.Append(" where 1=1 and C_Property_trail_stock_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Property_trail_stock_type != null)
                {
                    strSql.Append("and C_Property_trail_stock_type=@C_Property_trail_stock_type ");
                }
                if (model.C_Property_trail_stock_belongs != null)
                {
                    strSql.Append("and C_Property_trail_stock_belongs=@C_Property_trail_stock_belongs ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_stock_type", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_stock_belongs", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Property_trail_stock_type;
            parameters[1].Value = model.C_Property_trail_stock_belongs;
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
		public DataSet GetListByPage(Model.C_Property_trail_stock model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Property_trail_stock_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_Property_trail_stock T ");
            strSql.Append(" where 1=1 and C_Property_trail_stock_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Property_trail_stock_type != null)
                {
                    strSql.Append("and C_Property_trail_stock_type=@C_Property_trail_stock_type ");
                }
                if (model.C_Property_trail_stock_belongs != null)
                {
                    strSql.Append("and C_Property_trail_stock_belongs=@C_Property_trail_stock_belongs ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_stock_type", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_stock_belongs", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Property_trail_stock_type;
            parameters[1].Value = model.C_Property_trail_stock_belongs;

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
			parameters[0].Value = "C_Property_trail_stock";
			parameters[1].Value = "C_Property_trail_stock_id";
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

