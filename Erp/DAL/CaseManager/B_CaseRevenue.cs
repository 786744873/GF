using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:收入信息表
    /// 作者：崔慧栋
    /// 日期：2015/06/19
    /// </summary>
	public partial class B_CaseRevenue
	{
		public B_CaseRevenue()
		{}
		#region  BasicMethod


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("B_CaseRevenue_id", "B_CaseRevenue"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int B_CaseRevenue_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_CaseRevenue");
			strSql.Append(" where B_CaseRevenue_id=@B_CaseRevenue_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseRevenue_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseRevenue_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_CaseRevenue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_CaseRevenue(");
            strSql.Append("B_CaseRevenue_code,B_Case_code,B_CaseRevenue_type,B_CaseRevenue_amount,B_CaseRevenue_incomeTime,B_CaseRevenue_remarks,B_CaseRevenue_creator,B_CaseRevenue_createTime,B_CaseRevenue_isDelete)");
			strSql.Append(" values (");
            strSql.Append("@B_CaseRevenue_code,@B_Case_code,@B_CaseRevenue_type,@B_CaseRevenue_amount,@B_CaseRevenue_incomeTime,@B_CaseRevenue_remarks,@B_CaseRevenue_creator,@B_CaseRevenue_createTime,@B_CaseRevenue_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseRevenue_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_code",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseRevenue_type", SqlDbType.Int,4),
					new SqlParameter("@B_CaseRevenue_amount", SqlDbType.Decimal,9),
					new SqlParameter("@B_CaseRevenue_incomeTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseRevenue_remarks", SqlDbType.VarChar,500),
					new SqlParameter("@B_CaseRevenue_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseRevenue_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseRevenue_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.B_CaseRevenue_code;
            parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_CaseRevenue_type;
			parameters[3].Value = model.B_CaseRevenue_amount;
			parameters[4].Value = model.B_CaseRevenue_incomeTime;
			parameters[5].Value = model.B_CaseRevenue_remarks;
            parameters[6].Value = model.B_CaseRevenue_creator;
			parameters[7].Value = model.B_CaseRevenue_createTime;
			parameters[8].Value = model.B_CaseRevenue_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_CaseRevenue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_CaseRevenue set ");
			strSql.Append("B_CaseRevenue_code=@B_CaseRevenue_code,");
            strSql.Append("B_Case_code=B_Case_code,");
			strSql.Append("B_CaseRevenue_type=@B_CaseRevenue_type,");
			strSql.Append("B_CaseRevenue_amount=@B_CaseRevenue_amount,");
			strSql.Append("B_CaseRevenue_incomeTime=@B_CaseRevenue_incomeTime,");
			strSql.Append("B_CaseRevenue_remarks=@B_CaseRevenue_remarks,");
			strSql.Append("B_CaseRevenue_creator=@B_CaseRevenue_creator,");
			strSql.Append("B_CaseRevenue_createTime=@B_CaseRevenue_createTime,");
			strSql.Append("B_CaseRevenue_isDelete=@B_CaseRevenue_isDelete");
			strSql.Append(" where B_CaseRevenue_id=@B_CaseRevenue_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseRevenue_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_code",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseRevenue_type", SqlDbType.Int,4),
					new SqlParameter("@B_CaseRevenue_amount", SqlDbType.Decimal,9),
					new SqlParameter("@B_CaseRevenue_incomeTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseRevenue_remarks", SqlDbType.VarChar,500),
					new SqlParameter("@B_CaseRevenue_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseRevenue_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseRevenue_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_CaseRevenue_id", SqlDbType.Int,4)};
            parameters[0].Value = model.B_CaseRevenue_code;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_CaseRevenue_type;
            parameters[3].Value = model.B_CaseRevenue_amount;
            parameters[4].Value = model.B_CaseRevenue_incomeTime;
            parameters[5].Value = model.B_CaseRevenue_remarks;
            parameters[6].Value = model.B_CaseRevenue_creator;
            parameters[7].Value = model.B_CaseRevenue_createTime;
            parameters[8].Value = model.B_CaseRevenue_isDelete;
			parameters[9].Value = model.B_CaseRevenue_id;

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
		public bool Delete(int B_CaseRevenue_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_CaseRevenue set B_CaseRevenue_isDelete=1 ");
			strSql.Append(" where B_CaseRevenue_id=@B_CaseRevenue_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseRevenue_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseRevenue_id;

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
		public bool DeleteList(string B_CaseRevenue_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_CaseRevenue ");
			strSql.Append(" where B_CaseRevenue_id in ("+B_CaseRevenue_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_CaseRevenue GetModel(int B_CaseRevenue_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 B_CaseRevenue_id,B_CaseRevenue_code,B_Case_code,B_CaseRevenue_type,B_CaseRevenue_amount,B_CaseRevenue_incomeTime,B_CaseRevenue_remarks,B_CaseRevenue_creator,B_CaseRevenue_createTime,B_CaseRevenue_isDelete from B_CaseRevenue ");
			strSql.Append(" where B_CaseRevenue_id=@B_CaseRevenue_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseRevenue_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseRevenue_id;

            CommonService.Model.CaseManager.B_CaseRevenue model = new CommonService.Model.CaseManager.B_CaseRevenue();
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
        public CommonService.Model.CaseManager.B_CaseRevenue DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_CaseRevenue model = new CommonService.Model.CaseManager.B_CaseRevenue();
			if (row != null)
			{
				if(row["B_CaseRevenue_id"]!=null && row["B_CaseRevenue_id"].ToString()!="")
				{
					model.B_CaseRevenue_id=int.Parse(row["B_CaseRevenue_id"].ToString());
				}
				if(row["B_CaseRevenue_code"]!=null && row["B_CaseRevenue_code"].ToString()!="")
				{
					model.B_CaseRevenue_code= new Guid(row["B_CaseRevenue_code"].ToString());
				}
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString()!="")
                {
                    model.B_Case_code = new Guid(row["B_Case_code"].ToString());
                }
				if(row["B_CaseRevenue_type"]!=null && row["B_CaseRevenue_type"].ToString()!="")
				{
					model.B_CaseRevenue_type=int.Parse(row["B_CaseRevenue_type"].ToString());
				}
                //判断案件类型名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("B_CaseRevenue_type_name"))
                {
                    if (row["B_CaseRevenue_type_name"] != null && row["B_CaseRevenue_type_name"].ToString() != "")
                    {
                        model.B_CaseRevenue_type_name = row["B_CaseRevenue_type_name"].ToString();
                    }
                }
				if(row["B_CaseRevenue_amount"]!=null && row["B_CaseRevenue_amount"].ToString()!="")
				{
					model.B_CaseRevenue_amount=decimal.Parse(row["B_CaseRevenue_amount"].ToString());
				}
				if(row["B_CaseRevenue_incomeTime"]!=null && row["B_CaseRevenue_incomeTime"].ToString()!="")
				{
					model.B_CaseRevenue_incomeTime=DateTime.Parse(row["B_CaseRevenue_incomeTime"].ToString());
				}
				if(row["B_CaseRevenue_remarks"]!=null)
				{
					model.B_CaseRevenue_remarks=row["B_CaseRevenue_remarks"].ToString();
				}
				if(row["B_CaseRevenue_creator"]!=null && row["B_CaseRevenue_creator"].ToString()!="")
				{
					model.B_CaseRevenue_creator= new Guid(row["B_CaseRevenue_creator"].ToString());
				}
				if(row["B_CaseRevenue_createTime"]!=null && row["B_CaseRevenue_createTime"].ToString()!="")
				{
					model.B_CaseRevenue_createTime=DateTime.Parse(row["B_CaseRevenue_createTime"].ToString());
				}
				if(row["B_CaseRevenue_isDelete"]!=null && row["B_CaseRevenue_isDelete"].ToString()!="")
				{
					model.B_CaseRevenue_isDelete=int.Parse(row["B_CaseRevenue_isDelete"].ToString());
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
            strSql.Append("select B_CaseRevenue_id,B_CaseRevenue_code,B_Case_code,B_CaseRevenue_type,B_CaseRevenue_amount,B_CaseRevenue_incomeTime,B_CaseRevenue_remarks,B_CaseRevenue_creator,B_CaseRevenue_createTime,B_CaseRevenue_isDelete ");
			strSql.Append(" FROM B_CaseRevenue ");
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
            strSql.Append(" B_CaseRevenue_id,B_CaseRevenue_code,B_Case_code,B_CaseRevenue_type,B_CaseRevenue_amount,B_CaseRevenue_incomeTime,B_CaseRevenue_remarks,B_CaseRevenue_creator,B_CaseRevenue_createTime,B_CaseRevenue_isDelete ");
			strSql.Append(" FROM B_CaseRevenue ");
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_CaseRevenue model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM B_CaseRevenue ");
            strSql.Append(" where 1=1 and B_CaseRevenue_isDelete=0 ");
            if (model != null)
            {
                if (model.B_CaseRevenue_code != null && model.B_CaseRevenue_code.ToString() != "")
                {
                    strSql.Append("and B_CaseRevenue_code=@B_CaseRevenue_code ");
                }
                if(model.B_Case_code!=null && model.B_Case_code.ToString()!="")
                {
                    strSql.Append("and B_Case_code=@B_Case_code ");
                }
                if (model.B_CaseRevenue_type != null && model.B_CaseRevenue_type.ToString() != "")
                {
                    strSql.Append("and B_CaseRevenue_type=@B_CaseRevenue_type ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseRevenue_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_code",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseRevenue_type", SqlDbType.Int,4)};
            parameters[0].Value = model.B_CaseRevenue_code;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_CaseRevenue_type;
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
		public DataSet GetListByPage(CommonService.Model.CaseManager.B_CaseRevenue model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.B_CaseRevenue_id desc");
			}
            strSql.Append(")AS Row, T.*,P.C_Parameters_name as B_CaseRevenue_type_name  from B_CaseRevenue T left join C_Parameters as P on T.B_CaseRevenue_type=P.C_Parameters_id ");
            strSql.Append(" where 1=1 and B_CaseRevenue_isDelete=0 ");
            if (model != null)
            {
                if (model.B_CaseRevenue_code != null && model.B_CaseRevenue_code.ToString() != "")
                {
                    strSql.Append("and B_CaseRevenue_code=@B_CaseRevenue_code ");
                }
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and B_Case_code=@B_Case_code ");
                }
                if (model.B_CaseRevenue_type != null && model.B_CaseRevenue_type.ToString() != "")
                {
                    strSql.Append("and B_CaseRevenue_type=@B_CaseRevenue_type ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseRevenue_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_code",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseRevenue_type", SqlDbType.Int,4)};
            parameters[0].Value = model.B_CaseRevenue_code;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_CaseRevenue_type;
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
			parameters[0].Value = "B_CaseRevenue";
			parameters[1].Value = "B_CaseRevenue_id";
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

