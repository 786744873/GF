using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:联系人教育背景表
    /// 作者：崔慧栋
    /// 日期：2015/04/29
    /// </summary>
	public partial class C_Contacts_education
	{
		public C_Contacts_education()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Contacts_education_id", "C_Contacts_education");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Contacts_education_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Contacts_education");
            strSql.Append(" where C_Contacts_education_id=@C_Contacts_education_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_education_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Contacts_education_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Contacts_education model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Contacts_education(");
			strSql.Append("C_Contacts_code,C_Contacts_education_number,C_Contacts_education_degree,C_Contacts_education_graduation_date,C_Contacts_education_school,C_Contacts_education_science,C_Contacts_education_creator,C_Contacts_education_createTime,C_Contacts_education_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@C_Contacts_code,@C_Contacts_education_number,@C_Contacts_education_degree,@C_Contacts_education_graduation_date,@C_Contacts_education_school,@C_Contacts_education_science,@C_Contacts_education_creator,@C_Contacts_education_createTime,@C_Contacts_education_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Contacts_education_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_education_degree", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_education_graduation_date", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_education_school", SqlDbType.VarChar,100),
					new SqlParameter("@C_Contacts_education_science", SqlDbType.VarChar,100),
					new SqlParameter("@C_Contacts_education_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Contacts_education_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_education_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Contacts_code;
			parameters[1].Value = model.C_Contacts_education_number;
			parameters[2].Value = model.C_Contacts_education_degree;
			parameters[3].Value = model.C_Contacts_education_graduation_date;
			parameters[4].Value = model.C_Contacts_education_school;
			parameters[5].Value = model.C_Contacts_education_science;
			parameters[6].Value = model.C_Contacts_education_creator;
			parameters[7].Value = model.C_Contacts_education_createTime;
			parameters[8].Value = model.C_Contacts_education_isDelete;

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
        public bool Update(CommonService.Model.C_Contacts_education model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Contacts_education set ");
			strSql.Append("C_Contacts_code=@C_Contacts_code,");
			strSql.Append("C_Contacts_education_number=@C_Contacts_education_number,");
			strSql.Append("C_Contacts_education_degree=@C_Contacts_education_degree,");
			strSql.Append("C_Contacts_education_graduation_date=@C_Contacts_education_graduation_date,");
			strSql.Append("C_Contacts_education_school=@C_Contacts_education_school,");
			strSql.Append("C_Contacts_education_science=@C_Contacts_education_science,");
			strSql.Append("C_Contacts_education_creator=@C_Contacts_education_creator,");
			strSql.Append("C_Contacts_education_createTime=@C_Contacts_education_createTime,");
			strSql.Append("C_Contacts_education_isDelete=@C_Contacts_education_isDelete");
			strSql.Append(" where C_Contacts_education_id=@C_Contacts_education_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Contacts_education_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_education_degree", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_education_graduation_date", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_education_school", SqlDbType.VarChar,100),
					new SqlParameter("@C_Contacts_education_science", SqlDbType.VarChar,100),
					new SqlParameter("@C_Contacts_education_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Contacts_education_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_education_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_education_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Contacts_code;
			parameters[1].Value = model.C_Contacts_education_number;
			parameters[2].Value = model.C_Contacts_education_degree;
			parameters[3].Value = model.C_Contacts_education_graduation_date;
			parameters[4].Value = model.C_Contacts_education_school;
			parameters[5].Value = model.C_Contacts_education_science;
			parameters[6].Value = model.C_Contacts_education_creator;
			parameters[7].Value = model.C_Contacts_education_createTime;
			parameters[8].Value = model.C_Contacts_education_isDelete;
			parameters[9].Value = model.C_Contacts_education_id;

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
        public bool Delete(int C_Contacts_education_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Contacts_education set C_Contacts_education_isDelete=1");
            strSql.Append(" where C_Contacts_education_id=@C_Contacts_education_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_education_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Contacts_education_id;

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
		public bool DeleteList(string C_Contacts_education_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Contacts_education ");
			strSql.Append(" where C_Contacts_education_id in ("+C_Contacts_education_idlist + ")  ");
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
        public CommonService.Model.C_Contacts_education GetModel(int C_Contacts_education_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_Contacts_education_id,C_Contacts_code,C_Contacts_education_number,C_Contacts_education_degree,C_Contacts_education_graduation_date,C_Contacts_education_school,C_Contacts_education_science,C_Contacts_education_creator,C_Contacts_education_createTime,C_Contacts_education_isDelete from C_Contacts_education ");
			strSql.Append(" where C_Contacts_education_id=@C_Contacts_education_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_education_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Contacts_education_id;

            CommonService.Model.C_Contacts_education model = new CommonService.Model.C_Contacts_education();
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
        public CommonService.Model.C_Contacts_education GetModel(Guid C_Contacts_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Contacts_education_id,C_Contacts_code,C_Contacts_education_number,C_Contacts_education_degree,C_Contacts_education_graduation_date,C_Contacts_education_school,C_Contacts_education_science,C_Contacts_education_creator,C_Contacts_education_createTime,C_Contacts_education_isDelete from C_Contacts_education ");
            strSql.Append(" where C_Contacts_code=@C_Contacts_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Contacts_code;

            CommonService.Model.C_Contacts_education model = new CommonService.Model.C_Contacts_education();
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
        public CommonService.Model.C_Contacts_education DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Contacts_education model = new CommonService.Model.C_Contacts_education();
			if (row != null)
			{
				if(row["C_Contacts_education_id"]!=null && row["C_Contacts_education_id"].ToString()!="")
				{
					model.C_Contacts_education_id=int.Parse(row["C_Contacts_education_id"].ToString());
				}
				if(row["C_Contacts_code"]!=null && row["C_Contacts_code"].ToString()!="")
				{
					model.C_Contacts_code= new Guid(row["C_Contacts_code"].ToString());
				}
				if(row["C_Contacts_education_number"]!=null)
				{
					model.C_Contacts_education_number=row["C_Contacts_education_number"].ToString();
				}
				if(row["C_Contacts_education_degree"]!=null)
				{
					model.C_Contacts_education_degree=row["C_Contacts_education_degree"].ToString();
				}
				if(row["C_Contacts_education_graduation_date"]!=null && row["C_Contacts_education_graduation_date"].ToString()!="")
				{
					model.C_Contacts_education_graduation_date=DateTime.Parse(row["C_Contacts_education_graduation_date"].ToString());
				}
				if(row["C_Contacts_education_school"]!=null)
				{
					model.C_Contacts_education_school=row["C_Contacts_education_school"].ToString();
				}
				if(row["C_Contacts_education_science"]!=null)
				{
					model.C_Contacts_education_science=row["C_Contacts_education_science"].ToString();
				}
                if (row["C_Contacts_education_creator"] != null && row["C_Contacts_education_creator"].ToString() != "")
				{
					model.C_Contacts_education_creator=new Guid(row["C_Contacts_education_creator"].ToString());
				}
				if(row["C_Contacts_education_createTime"]!=null && row["C_Contacts_education_createTime"].ToString()!="")
				{
					model.C_Contacts_education_createTime=DateTime.Parse(row["C_Contacts_education_createTime"].ToString());
				}
				if(row["C_Contacts_education_isDelete"]!=null && row["C_Contacts_education_isDelete"].ToString()!="")
				{
					model.C_Contacts_education_isDelete=int.Parse(row["C_Contacts_education_isDelete"].ToString());
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
			strSql.Append("select C_Contacts_education_id,C_Contacts_code,C_Contacts_education_number,C_Contacts_education_degree,C_Contacts_education_graduation_date,C_Contacts_education_school,C_Contacts_education_science,C_Contacts_education_creator,C_Contacts_education_createTime,C_Contacts_education_isDelete ");
			strSql.Append(" FROM C_Contacts_education ");
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
			strSql.Append(" C_Contacts_education_id,C_Contacts_code,C_Contacts_education_number,C_Contacts_education_degree,C_Contacts_education_graduation_date,C_Contacts_education_school,C_Contacts_education_science,C_Contacts_education_creator,C_Contacts_education_createTime,C_Contacts_education_isDelete ");
			strSql.Append(" FROM C_Contacts_education ");
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
		public int GetRecordCount(CommonService.Model.C_Contacts_education model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM C_Contacts_education ");
            strSql.Append(" where 1=1 and C_Contacts_education_isDelete=0 ");
            if (model != null)
            {

                if (model.C_Contacts_code != null)
                {
                    strSql.Append(" and C_Contacts_code=@C_Contacts_code");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Contacts_code;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
		public DataSet GetListByPage(CommonService.Model.C_Contacts_education model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Contacts_education_id desc");
			}
			strSql.Append(")AS Row, T.*  from C_Contacts_education T ");
            strSql.Append(" where 1=1 and C_Contacts_education_isDelete=0 ");
            if (model != null)
            {

                if (model.C_Contacts_code != null)
                {
                    strSql.Append(" and C_Contacts_code=@C_Contacts_code");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Contacts_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
			parameters[0].Value = "C_Contacts_education";
			parameters[1].Value = "C_Contacts_education_id";
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

