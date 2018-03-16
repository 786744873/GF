using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:财产线索车辆表
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	public partial class C_Property_trail_cars
	{
		public C_Property_trail_cars()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Property_trail_bank_id", "C_Property_trail_cars");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Property_trail_cars_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Property_trail_cars");
            strSql.Append(" where C_Property_trail_cars_id=@C_Property_trail_cars_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_cars_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Property_trail_cars_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Property_trail_cars model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Property_trail_cars(");
			strSql.Append("C_Property_trail_cars_type,C_Property_trail_cars_belongs,C_Property_trail_cars_code,C_Property_trail_cars_models,C_Property_trail_cars_reCode,C_Property_trail_cars_price,C_Property_trail_cars_license,C_Property_trail_cars_buyDate,C_Property_trail_cars_creator,C_Property_trail_cars_createTime,C_Property_trail_cars_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@C_Property_trail_cars_type,@C_Property_trail_cars_belongs,@C_Property_trail_cars_code,@C_Property_trail_cars_models,@C_Property_trail_cars_reCode,@C_Property_trail_cars_price,@C_Property_trail_cars_license,@C_Property_trail_cars_buyDate,@C_Property_trail_cars_creator,@C_Property_trail_cars_createTime,@C_Property_trail_cars_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_cars_type", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_cars_belongs", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Property_trail_cars_code", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_cars_models", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_cars_reCode", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_cars_price", SqlDbType.Decimal,9),
					new SqlParameter("@C_Property_trail_cars_license", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_cars_buyDate", SqlDbType.DateTime),
					new SqlParameter("@C_Property_trail_cars_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Property_trail_cars_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Property_trail_cars_isDelete", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Property_trail_cars_type;
            parameters[1].Value = model.C_Property_trail_cars_belongs;
			parameters[2].Value = model.C_Property_trail_cars_code;
			parameters[3].Value = model.C_Property_trail_cars_models;
			parameters[4].Value = model.C_Property_trail_cars_reCode;
			parameters[5].Value = model.C_Property_trail_cars_price;
			parameters[6].Value = model.C_Property_trail_cars_license;
			parameters[7].Value = model.C_Property_trail_cars_buyDate;
            parameters[8].Value = model.C_Property_trail_cars_creator;
			parameters[9].Value = model.C_Property_trail_cars_createTime;
			parameters[10].Value = model.C_Property_trail_cars_isDelete;

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
        public bool Update(CommonService.Model.C_Property_trail_cars model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Property_trail_cars set ");
			strSql.Append("C_Property_trail_cars_type=@C_Property_trail_cars_type,");
			strSql.Append("C_Property_trail_cars_belongs=@C_Property_trail_cars_belongs,");
			strSql.Append("C_Property_trail_cars_code=@C_Property_trail_cars_code,");
			strSql.Append("C_Property_trail_cars_models=@C_Property_trail_cars_models,");
			strSql.Append("C_Property_trail_cars_reCode=@C_Property_trail_cars_reCode,");
			strSql.Append("C_Property_trail_cars_price=@C_Property_trail_cars_price,");
			strSql.Append("C_Property_trail_cars_license=@C_Property_trail_cars_license,");
			strSql.Append("C_Property_trail_cars_buyDate=@C_Property_trail_cars_buyDate,");
			strSql.Append("C_Property_trail_cars_creator=@C_Property_trail_cars_creator,");
			strSql.Append("C_Property_trail_cars_createTime=@C_Property_trail_cars_createTime,");
			strSql.Append("C_Property_trail_cars_isDelete=@C_Property_trail_cars_isDelete");
			strSql.Append(" where C_Property_trail_cars_id=@C_Property_trail_cars_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_cars_type", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_cars_belongs", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Property_trail_cars_code", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_cars_models", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_cars_reCode", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_cars_price", SqlDbType.Decimal,9),
					new SqlParameter("@C_Property_trail_cars_license", SqlDbType.VarChar,50),
					new SqlParameter("@C_Property_trail_cars_buyDate", SqlDbType.DateTime),
					new SqlParameter("@C_Property_trail_cars_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Property_trail_cars_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Property_trail_cars_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_cars_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Property_trail_cars_type;
			parameters[1].Value = model.C_Property_trail_cars_belongs;
			parameters[2].Value = model.C_Property_trail_cars_code;
			parameters[3].Value = model.C_Property_trail_cars_models;
			parameters[4].Value = model.C_Property_trail_cars_reCode;
			parameters[5].Value = model.C_Property_trail_cars_price;
			parameters[6].Value = model.C_Property_trail_cars_license;
			parameters[7].Value = model.C_Property_trail_cars_buyDate;
			parameters[8].Value = model.C_Property_trail_cars_creator;
			parameters[9].Value = model.C_Property_trail_cars_createTime;
			parameters[10].Value = model.C_Property_trail_cars_isDelete;
			parameters[11].Value = model.C_Property_trail_cars_id;

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
		public bool Delete(int C_Property_trail_cars_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Property_trail_cars set C_Property_trail_cars_isDelete=1 ");
			strSql.Append(" where C_Property_trail_cars_id=@C_Property_trail_cars_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_cars_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Property_trail_cars_id;

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
		public bool DeleteList(string C_Property_trail_cars_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Property_trail_cars ");
			strSql.Append(" where C_Property_trail_cars_id in ("+C_Property_trail_cars_idlist + ")  ");
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
        public CommonService.Model.C_Property_trail_cars GetModel(int C_Property_trail_cars_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_Property_trail_cars_id,C_Property_trail_cars_type,C_Property_trail_cars_belongs,C_Property_trail_cars_code,C_Property_trail_cars_models,C_Property_trail_cars_reCode,C_Property_trail_cars_price,C_Property_trail_cars_license,C_Property_trail_cars_buyDate,C_Property_trail_cars_creator,C_Property_trail_cars_createTime,C_Property_trail_cars_isDelete from C_Property_trail_cars ");
			strSql.Append(" where C_Property_trail_cars_id=@C_Property_trail_cars_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_cars_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Property_trail_cars_id;

            CommonService.Model.C_Property_trail_cars model = new CommonService.Model.C_Property_trail_cars();
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
        public CommonService.Model.C_Property_trail_cars DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Property_trail_cars model = new CommonService.Model.C_Property_trail_cars();
			if (row != null)
			{
				if(row["C_Property_trail_cars_id"]!=null && row["C_Property_trail_cars_id"].ToString()!="")
				{
					model.C_Property_trail_cars_id=int.Parse(row["C_Property_trail_cars_id"].ToString());
				}
				if(row["C_Property_trail_cars_type"]!=null && row["C_Property_trail_cars_type"].ToString()!="")
				{
					model.C_Property_trail_cars_type=int.Parse(row["C_Property_trail_cars_type"].ToString());
				}
				if(row["C_Property_trail_cars_belongs"]!=null && row["C_Property_trail_cars_belongs"].ToString()!="")
				{
					model.C_Property_trail_cars_belongs= new Guid(row["C_Property_trail_cars_belongs"].ToString());
				}
				if(row["C_Property_trail_cars_code"]!=null)
				{
					model.C_Property_trail_cars_code=row["C_Property_trail_cars_code"].ToString();
				}
				if(row["C_Property_trail_cars_models"]!=null)
				{
					model.C_Property_trail_cars_models=row["C_Property_trail_cars_models"].ToString();
				}
				if(row["C_Property_trail_cars_reCode"]!=null)
				{
					model.C_Property_trail_cars_reCode=row["C_Property_trail_cars_reCode"].ToString();
				}
				if(row["C_Property_trail_cars_price"]!=null && row["C_Property_trail_cars_price"].ToString()!="")
				{
					model.C_Property_trail_cars_price=decimal.Parse(row["C_Property_trail_cars_price"].ToString());
				}
				if(row["C_Property_trail_cars_license"]!=null)
				{
					model.C_Property_trail_cars_license=row["C_Property_trail_cars_license"].ToString();
				}
				if(row["C_Property_trail_cars_buyDate"]!=null && row["C_Property_trail_cars_buyDate"].ToString()!="")
				{
					model.C_Property_trail_cars_buyDate=DateTime.Parse(row["C_Property_trail_cars_buyDate"].ToString());
				}
				if(row["C_Property_trail_cars_creator"]!=null && row["C_Property_trail_cars_creator"].ToString()!="")
				{
					model.C_Property_trail_cars_creator= new Guid(row["C_Property_trail_cars_creator"].ToString());
				}
				if(row["C_Property_trail_cars_createTime"]!=null && row["C_Property_trail_cars_createTime"].ToString()!="")
				{
					model.C_Property_trail_cars_createTime=DateTime.Parse(row["C_Property_trail_cars_createTime"].ToString());
				}
				if(row["C_Property_trail_cars_isDelete"]!=null && row["C_Property_trail_cars_isDelete"].ToString()!="")
				{
					model.C_Property_trail_cars_isDelete=int.Parse(row["C_Property_trail_cars_isDelete"].ToString());
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
			strSql.Append("select C_Property_trail_cars_id,C_Property_trail_cars_type,C_Property_trail_cars_belongs,C_Property_trail_cars_code,C_Property_trail_cars_models,C_Property_trail_cars_reCode,C_Property_trail_cars_price,C_Property_trail_cars_license,C_Property_trail_cars_buyDate,C_Property_trail_cars_creator,C_Property_trail_cars_createTime,C_Property_trail_cars_isDelete ");
			strSql.Append(" FROM C_Property_trail_cars ");
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
			strSql.Append(" C_Property_trail_cars_id,C_Property_trail_cars_type,C_Property_trail_cars_belongs,C_Property_trail_cars_code,C_Property_trail_cars_models,C_Property_trail_cars_reCode,C_Property_trail_cars_price,C_Property_trail_cars_license,C_Property_trail_cars_buyDate,C_Property_trail_cars_creator,C_Property_trail_cars_createTime,C_Property_trail_cars_isDelete ");
			strSql.Append(" FROM C_Property_trail_cars ");
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
		public int GetRecordCount(Model.C_Property_trail_cars model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM C_Property_trail_cars ");
            strSql.Append(" where 1=1 and C_Property_trail_cars_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Property_trail_cars_type != null)
                {
                    strSql.Append("and C_Property_trail_cars_type=@C_Property_trail_cars_type ");
                }
                if (model.C_Property_trail_cars_belongs != null)
                {
                    strSql.Append("and C_Property_trail_cars_belongs=@C_Property_trail_cars_belongs ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_cars_type", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_cars_belongs", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Property_trail_cars_type;
            parameters[1].Value = model.C_Property_trail_cars_belongs;
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
		public DataSet GetListByPage(Model.C_Property_trail_cars model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Property_trail_cars_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_Property_trail_cars T ");
            strSql.Append(" where 1=1 and C_Property_trail_cars_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Property_trail_cars_type != null)
                {
                    strSql.Append("and C_Property_trail_cars_type=@C_Property_trail_cars_type ");
                }
                if (model.C_Property_trail_cars_belongs != null)
                {
                    strSql.Append("and C_Property_trail_cars_belongs=@C_Property_trail_cars_belongs ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Property_trail_cars_type", SqlDbType.Int,4),
					new SqlParameter("@C_Property_trail_cars_belongs", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Property_trail_cars_type;
            parameters[1].Value = model.C_Property_trail_cars_belongs;
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
			parameters[0].Value = "C_Property_trail_cars";
			parameters[1].Value = "C_Property_trail_cars_id";
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

