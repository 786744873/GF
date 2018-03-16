using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:成本信息表
    /// 作者：崔慧栋
    /// 日期：2015/06/23
    /// </summary>
	public partial class B_CaseCost
	{
		public B_CaseCost()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("B_CaseCost_id", "B_CaseCost"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int B_CaseCost_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_CaseCost");
			strSql.Append(" where B_CaseCost_id=@B_CaseCost_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseCost_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseCost_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_CaseCost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_CaseCost(");
			strSql.Append("B_CaseCost_code,B_Case_code,B_CaseCost_type,B_CaseCost_amount,B_CaseCost_Time,B_CaseCost_remarks,B_CaseCost_creator,B_CaseCost_createTime,B_CaseCost_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_CaseCost_code,@B_Case_code,@B_CaseCost_type,@B_CaseCost_amount,@B_CaseCost_Time,@B_CaseCost_remarks,@B_CaseCost_creator,@B_CaseCost_createTime,@B_CaseCost_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseCost_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseCost_type", SqlDbType.Int,4),
					new SqlParameter("@B_CaseCost_amount", SqlDbType.Decimal,9),
					new SqlParameter("@B_CaseCost_Time", SqlDbType.DateTime),
					new SqlParameter("@B_CaseCost_remarks", SqlDbType.VarChar,500),
					new SqlParameter("@B_CaseCost_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseCost_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseCost_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.B_CaseCost_code;
            parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_CaseCost_type;
			parameters[3].Value = model.B_CaseCost_amount;
			parameters[4].Value = model.B_CaseCost_Time;
			parameters[5].Value = model.B_CaseCost_remarks;
            parameters[6].Value = model.B_CaseCost_creator;
			parameters[7].Value = model.B_CaseCost_createTime;
			parameters[8].Value = model.B_CaseCost_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_CaseCost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_CaseCost set ");
			strSql.Append("B_CaseCost_code=@B_CaseCost_code,");
			strSql.Append("B_Case_code=@B_Case_code,");
			strSql.Append("B_CaseCost_type=@B_CaseCost_type,");
			strSql.Append("B_CaseCost_amount=@B_CaseCost_amount,");
			strSql.Append("B_CaseCost_Time=@B_CaseCost_Time,");
			strSql.Append("B_CaseCost_remarks=@B_CaseCost_remarks,");
			strSql.Append("B_CaseCost_creator=@B_CaseCost_creator,");
			strSql.Append("B_CaseCost_createTime=@B_CaseCost_createTime,");
			strSql.Append("B_CaseCost_isDelete=@B_CaseCost_isDelete");
			strSql.Append(" where B_CaseCost_id=@B_CaseCost_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseCost_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseCost_type", SqlDbType.Int,4),
					new SqlParameter("@B_CaseCost_amount", SqlDbType.Decimal,9),
					new SqlParameter("@B_CaseCost_Time", SqlDbType.DateTime),
					new SqlParameter("@B_CaseCost_remarks", SqlDbType.VarChar,500),
					new SqlParameter("@B_CaseCost_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseCost_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseCost_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_CaseCost_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_CaseCost_code;
			parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_CaseCost_type;
			parameters[3].Value = model.B_CaseCost_amount;
			parameters[4].Value = model.B_CaseCost_Time;
			parameters[5].Value = model.B_CaseCost_remarks;
			parameters[6].Value = model.B_CaseCost_creator;
			parameters[7].Value = model.B_CaseCost_createTime;
			parameters[8].Value = model.B_CaseCost_isDelete;
			parameters[9].Value = model.B_CaseCost_id;

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
		public bool Delete(int B_CaseCost_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_CaseCost set B_CaseRevenue_isDelete=1 ");
			strSql.Append(" where B_CaseCost_id=@B_CaseCost_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseCost_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseCost_id;

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
		public bool DeleteList(string B_CaseCost_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_CaseCost ");
			strSql.Append(" where B_CaseCost_id in ("+B_CaseCost_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_CaseCost GetModel(int B_CaseCost_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_CaseCost_id,B_CaseCost_code,B_Case_code,B_CaseCost_type,B_CaseCost_amount,B_CaseCost_Time,B_CaseCost_remarks,B_CaseCost_creator,B_CaseCost_createTime,B_CaseCost_isDelete from B_CaseCost ");
            strSql.Append(" where B_CaseCost_id=@B_CaseCost_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@B_CaseCost_id",SqlDbType.Int,4)
			};
            parameters[0].Value = B_CaseCost_id;

            CommonService.Model.CaseManager.B_CaseCost model = new CommonService.Model.CaseManager.B_CaseCost();
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
        public CommonService.Model.CaseManager.B_CaseCost GetModel(Guid B_Case_code, int B_CaseCost_type)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 T.*,P.C_Parameters_id as 'B_CaseCost_type_id',P.C_Parameters_name as 'B_CaseCost_type_name' ");
            strSql.Append("from (select * from B_CaseCost where B_Case_code=@B_Case_code and B_CaseCost_type=@B_CaseCost_type and B_CaseCost_isDelete=0) as T ");
            strSql.Append("right join C_Parameters as P on T.B_CaseCost_type=P.C_Parameters_id ");
            strSql.Append("where 1=1 and P.C_Parameters_id=@B_CaseCost_type_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_CaseCost_type",SqlDbType.Int,4),
                    new SqlParameter("@B_CaseCost_type_id",SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_code;
            parameters[1].Value = B_CaseCost_type;
            parameters[2].Value = B_CaseCost_type;

            CommonService.Model.CaseManager.B_CaseCost model = new CommonService.Model.CaseManager.B_CaseCost();
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
        public CommonService.Model.CaseManager.B_CaseCost DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_CaseCost model = new CommonService.Model.CaseManager.B_CaseCost();
			if (row != null)
			{
				if(row["B_CaseCost_id"]!=null && row["B_CaseCost_id"].ToString()!="")
				{
					model.B_CaseCost_id=int.Parse(row["B_CaseCost_id"].ToString());
				}
				if(row["B_CaseCost_code"]!=null && row["B_CaseCost_code"].ToString()!="")
				{
					model.B_CaseCost_code= new Guid(row["B_CaseCost_code"].ToString());
				}
				if(row["B_Case_code"]!=null && row["B_Case_code"].ToString()!="")
				{
					model.B_Case_code= new Guid(row["B_Case_code"].ToString());
				}
				if(row["B_CaseCost_type"]!=null && row["B_CaseCost_type"].ToString()!="")
				{
					model.B_CaseCost_type=int.Parse(row["B_CaseCost_type"].ToString());
				}
                //判断成本类型ID（虚拟字段）是否存在
                if (row.Table.Columns.Contains("B_CaseCost_type_id"))
                {
                    if (row["B_CaseCost_type_id"] != null && row["B_CaseCost_type_id"].ToString() != "")
                    {
                        model.B_CaseCost_type_id = int.Parse(row["B_CaseCost_type_id"].ToString());
                    }
                }
                //判断成本类型名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("B_CaseCost_type_name"))
                {
                    if (row["B_CaseCost_type_name"] != null && row["B_CaseCost_type_name"].ToString() != "")
                    {
                        model.B_CaseCost_type_name = row["B_CaseCost_type_name"].ToString();
                    }
                }
				if(row["B_CaseCost_amount"]!=null && row["B_CaseCost_amount"].ToString()!="")
				{
					model.B_CaseCost_amount=decimal.Parse(row["B_CaseCost_amount"].ToString());
				}
				if(row["B_CaseCost_Time"]!=null && row["B_CaseCost_Time"].ToString()!="")
				{
					model.B_CaseCost_Time=DateTime.Parse(row["B_CaseCost_Time"].ToString());
				}
				if(row["B_CaseCost_remarks"]!=null)
				{
					model.B_CaseCost_remarks=row["B_CaseCost_remarks"].ToString();
				}
				if(row["B_CaseCost_creator"]!=null && row["B_CaseCost_creator"].ToString()!="")
				{
					model.B_CaseCost_creator= new Guid(row["B_CaseCost_creator"].ToString());
				}
				if(row["B_CaseCost_createTime"]!=null && row["B_CaseCost_createTime"].ToString()!="")
				{
					model.B_CaseCost_createTime=DateTime.Parse(row["B_CaseCost_createTime"].ToString());
				}
				if(row["B_CaseCost_isDelete"]!=null && row["B_CaseCost_isDelete"].ToString()!="")
				{
					model.B_CaseCost_isDelete=int.Parse(row["B_CaseCost_isDelete"].ToString());
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
			strSql.Append("select B_CaseCost_id,B_CaseCost_code,B_Case_code,B_CaseCost_type,B_CaseCost_amount,B_CaseCost_Time,B_CaseCost_remarks,B_CaseCost_creator,B_CaseCost_createTime,B_CaseCost_isDelete ");
			strSql.Append(" FROM B_CaseCost ");
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
			strSql.Append(" B_CaseCost_id,B_CaseCost_code,B_Case_code,B_CaseCost_type,B_CaseCost_amount,B_CaseCost_Time,B_CaseCost_remarks,B_CaseCost_creator,B_CaseCost_createTime,B_CaseCost_isDelete ");
			strSql.Append(" FROM B_CaseCost ");
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_CaseCost model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM (select * from B_CaseCost where B_Case_code=@B_Case_code and B_CaseCost_isDelete=0) T ");
            strSql.Append("right join C_Parameters as P on T.B_CaseCost_type=P.C_Parameters_id ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.B_CaseCost_type_id != null && model.B_CaseCost_type_id.ToString() != "")
                {
                    strSql.Append("and P.C_Parameters_parent=@B_CaseCost_type_id ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseCost_type_id", SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_code;
            parameters[1].Value = model.B_CaseCost_type_id;
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
		public DataSet GetListByPage(CommonService.Model.CaseManager.B_CaseCost model, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by P." + orderby );
			}
			else
			{
				strSql.Append("order by T.B_CaseCost_id desc");
			}
            strSql.Append(")AS Row, T.*,P.C_Parameters_id as 'B_CaseCost_type_id',P.C_Parameters_name as 'B_CaseCost_type_name' ");
            strSql.Append("from (select * from B_CaseCost where B_Case_code=@B_Case_code and B_CaseCost_isDelete=0) T ");
            strSql.Append("right join C_Parameters as P on T.B_CaseCost_type=P.C_Parameters_id ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.B_CaseCost_type_id != null && model.B_CaseCost_type_id.ToString() != "")
                {
                    strSql.Append("and P.C_Parameters_parent=@B_CaseCost_type_id ");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseCost_type_id", SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_code;
            parameters[1].Value = model.B_CaseCost_type_id;
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
			parameters[0].Value = "B_CaseCost";
			parameters[1].Value = "B_CaseCost_id";
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

