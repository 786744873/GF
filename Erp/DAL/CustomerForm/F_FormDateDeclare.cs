using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CustomerForm
{
    /// <summary>
    /// 数据访问类:表单时间声明表
    /// 作者：崔慧栋
    /// 日期：2015/06/08
    /// </summary>
	public partial class F_FormDateDeclare
	{
		public F_FormDateDeclare()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("F_FormDateDeclare_id", "F_FormDateDeclare");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_FormDateDeclare_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from F_FormDateDeclare");
            strSql.Append(" where F_FormDateDeclare_id=@F_FormDateDeclare_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormDateDeclare_id", SqlDbType.Int,4)			
            };
            parameters[0].Value = F_FormDateDeclare_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.CustomerForm.F_FormDateDeclare model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into F_FormDateDeclare(");
            strSql.Append("F_FormDateDeclare_code,F_FormDateDeclare_formCode,F_FormDateDeclare_column,F_FormDateDeclare_name,F_FormDateDeclare_type)");
			strSql.Append(" values (");
            strSql.Append("@F_FormDateDeclare_code,@F_FormDateDeclare_formCode,@F_FormDateDeclare_column,@F_FormDateDeclare_name,@F_FormDateDeclare_type)");
			SqlParameter[] parameters = {
					new SqlParameter("@F_FormDateDeclare_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormDateDeclare_formCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormDateDeclare_column", SqlDbType.VarChar,50),
					new SqlParameter("@F_FormDateDeclare_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_FormDateDeclare_type",SqlDbType.Int,4)};
            parameters[0].Value = model.F_FormDateDeclare_code;
            parameters[1].Value = model.F_FormDateDeclare_formCode;
			parameters[2].Value = model.F_FormDateDeclare_column;
			parameters[3].Value = model.F_FormDateDeclare_name;
            parameters[4].Value = model.F_FormDateDeclare_type;

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
        public bool Update(CommonService.Model.CustomerForm.F_FormDateDeclare model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update F_FormDateDeclare set ");
			strSql.Append("F_FormDateDeclare_code=@F_FormDateDeclare_code,");
			strSql.Append("F_FormDateDeclare_formCode=@F_FormDateDeclare_formCode,");
			strSql.Append("F_FormDateDeclare_column=@F_FormDateDeclare_column,");
			strSql.Append("F_FormDateDeclare_name=@F_FormDateDeclare_name,");
            strSql.Append("F_FormDateDeclare_type=@F_FormDateDeclare_type");
            strSql.Append(" where F_FormDateDeclare_id=@F_FormDateDeclare_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_FormDateDeclare_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormDateDeclare_formCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormDateDeclare_column", SqlDbType.VarChar,50),
					new SqlParameter("@F_FormDateDeclare_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_FormDateDeclare_type",SqlDbType.Int,4),
					new SqlParameter("@F_FormDateDeclare_id", SqlDbType.Int,4)};
			parameters[0].Value = model.F_FormDateDeclare_code;
			parameters[1].Value = model.F_FormDateDeclare_formCode;
			parameters[2].Value = model.F_FormDateDeclare_column;
            parameters[3].Value = model.F_FormDateDeclare_name;
            parameters[4].Value = model.F_FormDateDeclare_type;
            parameters[5].Value = model.F_FormDateDeclare_id;

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
        public bool Delete(int F_FormDateDeclare_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from F_FormDateDeclare ");
            strSql.Append(" where F_FormDateDeclare_id=@F_FormDateDeclare_id");
			SqlParameter[] parameters = {
                           new SqlParameter("@F_FormDateDeclare_id",SqlDbType.Int,4)
			};
            parameters[0].Value = F_FormDateDeclare_id;

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
        public CommonService.Model.CustomerForm.F_FormDateDeclare GetModel(int F_FormDateDeclare_id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 F_FormDateDeclare_id,F_FormDateDeclare_code,F_FormDateDeclare_formCode,F_FormDateDeclare_column,F_FormDateDeclare_name,F_FormDateDeclare_type from F_FormDateDeclare ");
            strSql.Append(" where F_FormDateDeclare_id=@F_FormDateDeclare_id");
			SqlParameter[] parameters = {
                           new SqlParameter("@F_FormDateDeclare_id",SqlDbType.Int,4)
			};
            parameters[0].Value = F_FormDateDeclare_id;

            CommonService.Model.CustomerForm.F_FormDateDeclare model = new CommonService.Model.CustomerForm.F_FormDateDeclare();
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
        public CommonService.Model.CustomerForm.F_FormDateDeclare DataRowToModel(DataRow row)
		{
            CommonService.Model.CustomerForm.F_FormDateDeclare model = new CommonService.Model.CustomerForm.F_FormDateDeclare();
			if (row != null)
			{
				if(row["F_FormDateDeclare_id"]!=null && row["F_FormDateDeclare_id"].ToString()!="")
				{
					model.F_FormDateDeclare_id=int.Parse(row["F_FormDateDeclare_id"].ToString());
				}
				if(row["F_FormDateDeclare_code"]!=null && row["F_FormDateDeclare_code"].ToString()!="")
				{
					model.F_FormDateDeclare_code= new Guid(row["F_FormDateDeclare_code"].ToString());
				}
				if(row["F_FormDateDeclare_formCode"]!=null && row["F_FormDateDeclare_formCode"].ToString()!="")
				{
					model.F_FormDateDeclare_formCode= new Guid(row["F_FormDateDeclare_formCode"].ToString());
				}
				if(row["F_FormDateDeclare_column"]!=null)
				{
					model.F_FormDateDeclare_column=row["F_FormDateDeclare_column"].ToString();
				}
				if(row["F_FormDateDeclare_name"]!=null)
				{
					model.F_FormDateDeclare_name=row["F_FormDateDeclare_name"].ToString();
				}
                if (row["F_FormDateDeclare_type"] != null && row["F_FormDateDeclare_type"].ToString() != "")
                {
                    model.F_FormDateDeclare_type = int.Parse(row["F_FormDateDeclare_type"].ToString());
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
            strSql.Append("select F_FormDateDeclare_id,F_FormDateDeclare_code,F_FormDateDeclare_formCode,F_FormDateDeclare_column,F_FormDateDeclare_name,F_FormDateDeclare_type ");
			strSql.Append(" FROM F_FormDateDeclare ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据表单GUID获得数据列表
        /// </summary>
        public DataSet GetListByFormCode(Guid F_FormDateDeclare_formCode, int F_FormDateDeclare_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_FormDateDeclare_id,F_FormDateDeclare_code,F_FormDateDeclare_formCode,F_FormDateDeclare_column,F_FormDateDeclare_name,F_FormDateDeclare_type ");
            strSql.Append(" FROM F_FormDateDeclare ");
            strSql.Append("where F_FormDateDeclare_formCode=@F_FormDateDeclare_formCode ");
            strSql.Append("and F_FormDateDeclare_type=@F_FormDateDeclare_type ");
            SqlParameter[] parameters = {
                           new SqlParameter("@F_FormDateDeclare_formCode",SqlDbType.UniqueIdentifier,16),
                           new SqlParameter("@F_FormDateDeclare_type",SqlDbType.Int,4)
			};
            parameters[0].Value = F_FormDateDeclare_formCode;
            parameters[1].Value = F_FormDateDeclare_type;

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
            strSql.Append(" F_FormDateDeclare_id,F_FormDateDeclare_code,F_FormDateDeclare_formCode,F_FormDateDeclare_column,F_FormDateDeclare_name,F_FormDateDeclare_type ");
			strSql.Append(" FROM F_FormDateDeclare ");
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
		public int GetRecordCount(CommonService.Model.CustomerForm.F_FormDateDeclare model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM F_FormDateDeclare ");
            if (model != null)
            {
                if (model.F_FormDateDeclare_code != null && model.F_FormDateDeclare_code.ToString()!="")
                {
                    strSql.Append("and F_FormDateDeclare_code=@F_FormDateDeclare_code ");
                }
                if (model.F_FormDateDeclare_formCode != null && model.F_FormDateDeclare_formCode.ToString()!="")
                {
                    strSql.Append(" and F_FormDateDeclare_formCode=@F_FormDateDeclare_formCode ");
                }
                if (model.F_FormDateDeclare_name != null)
                {
                    strSql.Append("and F_FormDateDeclare_name=@F_FormDateDeclare_name ");
                }
                if (model.F_FormDateDeclare_type != null && model.F_FormDateDeclare_type.ToString() != "")
                {
                    strSql.Append("and F_FormDateDeclare_type=@F_FormDateDeclare_type ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormDateDeclare_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormDateDeclare_formCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormDateDeclare_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_FormDateDeclare_type",SqlDbType.Int,4)};
            parameters[0].Value = model.F_FormDateDeclare_code;
            parameters[1].Value = model.F_FormDateDeclare_formCode;
            parameters[2].Value = model.F_FormDateDeclare_name;
            parameters[3].Value = model.F_FormDateDeclare_type;

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
		public DataSet GetListByPage(CommonService.Model.CustomerForm.F_FormDateDeclare model, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.*  from F_FormDateDeclare T ");
            if (model != null)
            {
                if (model.F_FormDateDeclare_code != null && model.F_FormDateDeclare_code.ToString() != "")
                {
                    strSql.Append("and F_FormDateDeclare_code=@F_FormDateDeclare_code ");
                }
                if (model.F_FormDateDeclare_formCode != null && model.F_FormDateDeclare_formCode.ToString() != "")
                {
                    strSql.Append(" and F_FormDateDeclare_formCode=@F_FormDateDeclare_formCode ");
                }
                if (model.F_FormDateDeclare_name != null)
                {
                    strSql.Append("and F_FormDateDeclare_name=@F_FormDateDeclare_name ");
                }
                if (model.F_FormDateDeclare_type != null && model.F_FormDateDeclare_type.ToString() != "")
                {
                    strSql.Append("and F_FormDateDeclare_type=@F_FormDateDeclare_type ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormDateDeclare_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormDateDeclare_formCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormDateDeclare_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_FormDateDeclare_type",SqlDbType.Int,4)};
            parameters[0].Value = model.F_FormDateDeclare_code;
            parameters[1].Value = model.F_FormDateDeclare_formCode;
            parameters[2].Value = model.F_FormDateDeclare_name;
            parameters[3].Value = model.F_FormDateDeclare_type;

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
			parameters[0].Value = "F_FormDateDeclare";
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

