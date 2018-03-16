using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件--收款明细表
    /// 作者：崔慧栋
    /// 日期：2015/06/06
    /// </summary>
	public partial class B_RDetail
	{
		public B_RDetail()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("B_RDetail_id", "B_RDetail");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_RDetail_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_RDetail");
            strSql.Append(" where B_RDetail_id=@B_RDetail_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_RDetail_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_RDetail_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_RDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_RDetail(");
			strSql.Append("B_RDetail_code,B_Case_code,B_RDetail_data,B_RDetail_limit,B_RDetail_rtype,B_RDetail_ptype,B_RDetail_creator,B_RDetail_createTime,B_RDetail_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_RDetail_code,@B_Case_code,@B_RDetail_data,@B_RDetail_limit,@B_RDetail_rtype,@B_RDetail_ptype,@B_RDetail_creator,@B_RDetail_createTime,@B_RDetail_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_RDetail_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_RDetail_data", SqlDbType.DateTime),
					new SqlParameter("@B_RDetail_limit", SqlDbType.Decimal,9),
					new SqlParameter("@B_RDetail_rtype", SqlDbType.Int,4),
					new SqlParameter("@B_RDetail_ptype", SqlDbType.Int,4),
					new SqlParameter("@B_RDetail_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_RDetail_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_RDetail_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.B_RDetail_code;
            parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_RDetail_data;
			parameters[3].Value = model.B_RDetail_limit;
			parameters[4].Value = model.B_RDetail_rtype;
			parameters[5].Value = model.B_RDetail_ptype;
            parameters[6].Value = model.B_RDetail_creator;
			parameters[7].Value = model.B_RDetail_createTime;
			parameters[8].Value = model.B_RDetail_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_RDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_RDetail set ");
			strSql.Append("B_RDetail_code=@B_RDetail_code,");
			strSql.Append("B_Case_code=@B_Case_code,");
			strSql.Append("B_RDetail_data=@B_RDetail_data,");
			strSql.Append("B_RDetail_limit=@B_RDetail_limit,");
			strSql.Append("B_RDetail_rtype=@B_RDetail_rtype,");
			strSql.Append("B_RDetail_ptype=@B_RDetail_ptype,");
			strSql.Append("B_RDetail_creator=@B_RDetail_creator,");
			strSql.Append("B_RDetail_createTime=@B_RDetail_createTime,");
			strSql.Append("B_RDetail_isDelete=@B_RDetail_isDelete");
			strSql.Append(" where B_RDetail_id=@B_RDetail_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_RDetail_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_RDetail_data", SqlDbType.DateTime),
					new SqlParameter("@B_RDetail_limit", SqlDbType.Decimal,9),
					new SqlParameter("@B_RDetail_rtype", SqlDbType.Int,4),
					new SqlParameter("@B_RDetail_ptype", SqlDbType.Int,4),
					new SqlParameter("@B_RDetail_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_RDetail_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_RDetail_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_RDetail_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_RDetail_code;
			parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_RDetail_data;
			parameters[3].Value = model.B_RDetail_limit;
			parameters[4].Value = model.B_RDetail_rtype;
			parameters[5].Value = model.B_RDetail_ptype;
			parameters[6].Value = model.B_RDetail_creator;
			parameters[7].Value = model.B_RDetail_createTime;
			parameters[8].Value = model.B_RDetail_isDelete;
			parameters[9].Value = model.B_RDetail_id;

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
		public bool Delete(int B_RDetail_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_RDetail set B_RDetail_isDelete=1 ");
			strSql.Append(" where B_RDetail_id=@B_RDetail_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_RDetail_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_RDetail_id;

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
		public bool DeleteList(string B_RDetail_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_RDetail ");
			strSql.Append(" where B_RDetail_id in ("+B_RDetail_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_RDetail GetModel(int B_RDetail_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 B_RDetail_id,B_RDetail_code,B_Case_code,B_RDetail_data,B_RDetail_limit,B_RDetail_rtype,B_RDetail_ptype,B_RDetail_creator,B_RDetail_createTime,B_RDetail_isDelete from B_RDetail ");
			strSql.Append(" where B_RDetail_id=@B_RDetail_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_RDetail_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_RDetail_id;

            CommonService.Model.CaseManager.B_RDetail model = new CommonService.Model.CaseManager.B_RDetail();
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
        public CommonService.Model.CaseManager.B_RDetail DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_RDetail model = new CommonService.Model.CaseManager.B_RDetail();
			if (row != null)
			{
				if(row["B_RDetail_id"]!=null && row["B_RDetail_id"].ToString()!="")
				{
					model.B_RDetail_id=int.Parse(row["B_RDetail_id"].ToString());
				}
				if(row["B_RDetail_code"]!=null && row["B_RDetail_code"].ToString()!="")
				{
					model.B_RDetail_code= new Guid(row["B_RDetail_code"].ToString());
				}
				if(row["B_Case_code"]!=null && row["B_Case_code"].ToString()!="")
				{
					model.B_Case_code= new Guid(row["B_Case_code"].ToString());
				}
				if(row["B_RDetail_data"]!=null && row["B_RDetail_data"].ToString()!="")
				{
					model.B_RDetail_data=DateTime.Parse(row["B_RDetail_data"].ToString());
				}
				if(row["B_RDetail_limit"]!=null && row["B_RDetail_limit"].ToString()!="")
				{
					model.B_RDetail_limit=decimal.Parse(row["B_RDetail_limit"].ToString());
				}
				if(row["B_RDetail_rtype"]!=null && row["B_RDetail_rtype"].ToString()!="")
				{
					model.B_RDetail_rtype=int.Parse(row["B_RDetail_rtype"].ToString());
				}
				if(row["B_RDetail_ptype"]!=null && row["B_RDetail_ptype"].ToString()!="")
				{
					model.B_RDetail_ptype=int.Parse(row["B_RDetail_ptype"].ToString());
				}
				if(row["B_RDetail_creator"]!=null && row["B_RDetail_creator"].ToString()!="")
				{
					model.B_RDetail_creator= new Guid(row["B_RDetail_creator"].ToString());
				}
				if(row["B_RDetail_createTime"]!=null && row["B_RDetail_createTime"].ToString()!="")
				{
					model.B_RDetail_createTime=DateTime.Parse(row["B_RDetail_createTime"].ToString());
				}
				if(row["B_RDetail_isDelete"]!=null && row["B_RDetail_isDelete"].ToString()!="")
				{
					model.B_RDetail_isDelete=int.Parse(row["B_RDetail_isDelete"].ToString());
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
			strSql.Append("select B_RDetail_id,B_RDetail_code,B_Case_code,B_RDetail_data,B_RDetail_limit,B_RDetail_rtype,B_RDetail_ptype,B_RDetail_creator,B_RDetail_createTime,B_RDetail_isDelete ");
			strSql.Append(" FROM B_RDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据关联Guid获得数据列表
        /// </summary>
        public DataSet GetListByRelationCode(Guid relationCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select B_RDetail_id,B_RDetail_code,B_Case_code,B_RDetail_data,B_RDetail_limit,B_RDetail_rtype,B_RDetail_ptype,B_RDetail_creator,B_RDetail_createTime,B_RDetail_isDelete ");
            strSql.Append(" FROM B_RDetail ");
            strSql.Append("where B_Case_code=@B_Case_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = relationCode;
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
			strSql.Append(" B_RDetail_id,B_RDetail_code,B_Case_code,B_RDetail_data,B_RDetail_limit,B_RDetail_rtype,B_RDetail_ptype,B_RDetail_creator,B_RDetail_createTime,B_RDetail_isDelete ");
			strSql.Append(" FROM B_RDetail ");
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_RDetail model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM B_RDetail ");
            strSql.Append(" where 1=1 and B_RDetail_isDelete=0 ");
            if (model != null)
            {
                if (model.B_RDetail_code != null && model.B_RDetail_code.ToString() != "")
                {
                    strSql.Append("and B_RDetail_code=@B_RDetail_code ");
                }
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and B_Case_code=@B_Case_code ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_RDetail_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.B_RDetail_code;
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
		public DataSet GetListByPage(CommonService.Model.CaseManager.B_RDetail model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.B_RDetail_id desc");
			}
            strSql.Append(")AS Row, T.*  from B_RDetail T ");
            strSql.Append(" where 1=1 and B_RDetail_isDelete=0 ");
            if (model != null)
            {
                if (model.B_RDetail_code != null && model.B_RDetail_code.ToString() != "")
                {
                    strSql.Append("and B_RDetail_code=@B_RDetail_code ");
                }
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and B_Case_code=@B_Case_code ");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@B_RDetail_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.B_RDetail_code;
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
			parameters[0].Value = "B_RDetail";
			parameters[1].Value = "B_RDetail_id";
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

