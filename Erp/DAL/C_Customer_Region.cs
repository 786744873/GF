using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:客户区域关系表
    /// 作者：崔慧栋
    /// 日期：2015/06/24
    /// </summary>
	public partial class C_Customer_Region
	{
		public C_Customer_Region()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("C_Customer_Region_Id", "C_Customer_Region"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int C_Customer_Region_Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Customer_Region");
			strSql.Append(" where C_Customer_Region_Id=@C_Customer_Region_Id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_Id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Customer_Region_Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Customer_Region model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Customer_Region(");
			strSql.Append("C_Customer_Region_customer,C_Customer_Region_relRegion,C_Customer_Region_isDelete,C_Customer_Region_creator,C_Customer_Region_createTime)");
			strSql.Append(" values (");
			strSql.Append("@C_Customer_Region_customer,@C_Customer_Region_relRegion,@C_Customer_Region_isDelete,@C_Customer_Region_creator,@C_Customer_Region_createTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Region_relRegion", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Region_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_Region_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Region_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Customer_Region_customer;
            parameters[1].Value = model.C_Customer_Region_relRegion;
			parameters[2].Value = model.C_Customer_Region_isDelete;
            parameters[3].Value = model.C_Customer_Region_creator;
			parameters[4].Value = model.C_Customer_Region_createTime;

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
        public bool Update(CommonService.Model.C_Customer_Region model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Customer_Region set ");
			strSql.Append("C_Customer_Region_customer=@C_Customer_Region_customer,");
			strSql.Append("C_Customer_Region_relRegion=@C_Customer_Region_relRegion,");
			strSql.Append("C_Customer_Region_isDelete=@C_Customer_Region_isDelete,");
			strSql.Append("C_Customer_Region_creator=@C_Customer_Region_creator,");
			strSql.Append("C_Customer_Region_createTime=@C_Customer_Region_createTime");
			strSql.Append(" where C_Customer_Region_Id=@C_Customer_Region_Id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Region_relRegion", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Region_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_Region_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Region_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_Region_Id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Customer_Region_customer;
			parameters[1].Value = model.C_Customer_Region_relRegion;
			parameters[2].Value = model.C_Customer_Region_isDelete;
			parameters[3].Value = model.C_Customer_Region_creator;
			parameters[4].Value = model.C_Customer_Region_createTime;
			parameters[5].Value = model.C_Customer_Region_Id;

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
        public bool Delete(Guid C_Customer_Region_customer, Guid C_Customer_Region_relRegion)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from C_Customer_Region ");
            strSql.Append(" where C_Customer_Region_customer=@C_Customer_Region_customer ");
            strSql.Append("and C_Customer_Region_relRegion=@C_Customer_Region_relRegion ");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_customer", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_Region_relRegion",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Customer_Region_customer;
            parameters[1].Value = C_Customer_Region_relRegion;

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
        /// 根据客户Guid删除数据
        /// </summary>
        public bool DeleteByCustomerCode(Guid C_Customer_Region_customer)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Customer_Region ");
            strSql.Append(" where C_Customer_Region_customer=@C_Customer_Region_customer ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_customer", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Customer_Region_customer;

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
		public bool DeleteList(string C_Customer_Region_Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Customer_Region ");
			strSql.Append(" where C_Customer_Region_Id in ("+C_Customer_Region_Idlist + ")  ");
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
        public CommonService.Model.C_Customer_Region GetModel(int C_Customer_Region_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_Customer_Region_Id,C_Customer_Region_customer,C_Customer_Region_relRegion,C_Customer_Region_isDelete,C_Customer_Region_creator,C_Customer_Region_createTime from C_Customer_Region ");
			strSql.Append(" where C_Customer_Region_Id=@C_Customer_Region_Id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_Id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Customer_Region_Id;

            CommonService.Model.C_Customer_Region model = new CommonService.Model.C_Customer_Region();
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
        public CommonService.Model.C_Customer_Region DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Customer_Region model = new CommonService.Model.C_Customer_Region();
			if (row != null)
			{
				if(row["C_Customer_Region_Id"]!=null && row["C_Customer_Region_Id"].ToString()!="")
				{
					model.C_Customer_Region_Id=int.Parse(row["C_Customer_Region_Id"].ToString());
				}
				if(row["C_Customer_Region_customer"]!=null && row["C_Customer_Region_customer"].ToString()!="")
				{
					model.C_Customer_Region_customer= new Guid(row["C_Customer_Region_customer"].ToString());
				}
				if(row["C_Customer_Region_relRegion"]!=null && row["C_Customer_Region_relRegion"].ToString()!="")
				{
					model.C_Customer_Region_relRegion= new Guid(row["C_Customer_Region_relRegion"].ToString());
				}
				if(row["C_Customer_Region_isDelete"]!=null && row["C_Customer_Region_isDelete"].ToString()!="")
				{
					model.C_Customer_Region_isDelete=int.Parse(row["C_Customer_Region_isDelete"].ToString());
				}
				if(row["C_Customer_Region_creator"]!=null && row["C_Customer_Region_creator"].ToString()!="")
				{
					model.C_Customer_Region_creator= new Guid(row["C_Customer_Region_creator"].ToString());
				}
				if(row["C_Customer_Region_createTime"]!=null && row["C_Customer_Region_createTime"].ToString()!="")
				{
					model.C_Customer_Region_createTime=DateTime.Parse(row["C_Customer_Region_createTime"].ToString());
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
			strSql.Append("select C_Customer_Region_Id,C_Customer_Region_customer,C_Customer_Region_relRegion,C_Customer_Region_isDelete,C_Customer_Region_creator,C_Customer_Region_createTime ");
			strSql.Append(" FROM C_Customer_Region ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据客户GUID获得数据列表
        /// </summary>
        public DataSet GetListByCustomerCode(Guid C_Customer_Region_customer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Customer_Region_Id,C_Customer_Region_customer,C_Customer_Region_relRegion,C_Customer_Region_isDelete,C_Customer_Region_creator,C_Customer_Region_createTime ");
            strSql.Append(" FROM C_Customer_Region ");
            strSql.Append("where C_Customer_Region_customer=@C_Customer_Region_customer ");
            strSql.Append("and C_Customer_Region_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_customer", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = C_Customer_Region_customer;

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
			strSql.Append(" C_Customer_Region_Id,C_Customer_Region_customer,C_Customer_Region_relRegion,C_Customer_Region_isDelete,C_Customer_Region_creator,C_Customer_Region_createTime ");
			strSql.Append(" FROM C_Customer_Region ");
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
		public int GetRecordCount(CommonService.Model.C_Customer_Region model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Customer_Region ");
            strSql.Append(" where 1=1 and C_Customer_Region_isDelete=0 ");

            if (model != null)
            {
                if (model.C_Customer_Region_customer != null && model.C_Customer_Region_customer.ToString()!="")
                {
                    strSql.Append("and C_Customer_Region_customer=@C_Customer_Region_customer ");
                }
                if (model.C_Customer_Region_relRegion != null && model.C_Customer_Region_relRegion.ToString()!="")
                {
                    strSql.Append("and C_Customer_Region_relRegion=@C_Customer_Region_relRegion ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Region_relRegion", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Customer_Region_customer;
            parameters[1].Value = model.C_Customer_Region_relRegion;
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
        public DataSet GetListByPage(CommonService.Model.C_Customer_Region model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Customer_Region_Id desc");
			}
            strSql.Append(")AS Row, T.*  from C_Customer_Region T ");
            strSql.Append(" where 1=1 and C_Customer_Region_isDelete=0 ");

            if (model != null)
            {
                if (model.C_Customer_Region_customer != null && model.C_Customer_Region_customer.ToString() != "")
                {
                    strSql.Append("and C_Customer_Region_customer=@C_Customer_Region_customer ");
                }
                if (model.C_Customer_Region_relRegion != null && model.C_Customer_Region_relRegion.ToString() != "")
                {
                    strSql.Append("and C_Customer_Region_relRegion=@C_Customer_Region_relRegion ");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Region_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Region_relRegion", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Customer_Region_customer;
            parameters[1].Value = model.C_Customer_Region_relRegion;
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
			parameters[0].Value = "C_Customer_Region";
			parameters[1].Value = "C_Customer_Region_Id";
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

