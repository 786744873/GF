using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.SysManager
{
	/// <summary>
	/// 数据访问类:用户----案件类型中间表
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	public partial class C_Userinfo_case_type
	{
        public C_Userinfo_case_type()
		{}
		#region  BasicMethod

        /// <summary>
        /// 查找是否存在实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exits(CommonService.Model.SysManager.C_Userinfo_case_type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Userinfo_case_type");
            strSql.Append(" where C_Userinfo_code=@C_Userinfo_code");
            strSql.Append(" and C_Parameters_id=@C_Parameters_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)
			};
            parameters[0].Value = model.C_Userinfo_code;
            parameters[1].Value = model.C_Parameters_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.SysManager.C_Userinfo_case_type model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into C_Userinfo_case_type(");
            strSql.Append("C_Userinfo_code,C_Parameters_id)");
			strSql.Append(" values (");
            strSql.Append("@C_Userinfo_code,@C_Parameters_id)");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Userinfo_code;
			parameters[1].Value = model.C_Parameters_id;

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
        public bool Update(CommonService.Model.SysManager.C_Userinfo_case_type model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Userinfo_case_type set ");
            strSql.Append("C_Userinfo_code=@C_Userinfo_code,");
            strSql.Append("C_Parameters_id=@C_Parameters_id");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Userinfo_code;
			parameters[1].Value = model.C_Parameters_id;

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
        public bool Delete(Guid userCode, int parametersId)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from C_Userinfo_case_type ");
            strSql.Append(" where C_Userinfo_code=@C_Userinfo_code ");
            strSql.Append("and C_Parameters_id=@C_Parameters_id ");
            SqlParameter[] parameters = {new SqlParameter("@C_Userinfo_code",SqlDbType.UniqueIdentifier,16),
                                         new SqlParameter("@C_Parameters_id",SqlDbType.Int,4)
			};
            parameters[0].Value = userCode;
            parameters[1].Value = parametersId;

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
        public CommonService.Model.SysManager.C_Userinfo_case_type GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 C_Userinfo_code,C_Parameters_id from C_Userinfo_case_type ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

            CommonService.Model.SysManager.C_Userinfo_case_type model = new CommonService.Model.SysManager.C_Userinfo_case_type();
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
        public CommonService.Model.SysManager.C_Userinfo_case_type DataRowToModel(DataRow row)
		{
            CommonService.Model.SysManager.C_Userinfo_case_type model = new CommonService.Model.SysManager.C_Userinfo_case_type();
			if (row != null)
			{
                if (row["C_Userinfo_code"] != null && row["C_Userinfo_code"].ToString() != "")
				{
                    model.C_Userinfo_code = new Guid(row["C_Userinfo_code"].ToString());
				}
				if(row["C_Parameters_id"]!=null && row["C_Parameters_id"].ToString()!="")
				{
					model.C_Parameters_id=int.Parse(row["C_Parameters_id"].ToString());
				}
                if(row.Table.Columns.Contains("C_Userinfo_name"))
                {
                    if(row["C_Userinfo_name"]!=null && row["C_Userinfo_name"].ToString()!="")
                    {
                        model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Parameters_name"))
                {
                    if (row["C_Parameters_name"] != null && row["C_Parameters_name"].ToString() != "")
                    {
                        model.C_Parameters_name = row["C_Parameters_name"].ToString();
                    }
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
            strSql.Append("select C_Userinfo_code,C_Parameters_id ");
			strSql.Append(" FROM C_Userinfo_case_type ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByRoleId(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Userinfo_code,C_Parameters_id ");
            strSql.Append(" FROM C_Userinfo_case_type ");
            strSql.Append("where C_Userinfo_code=@C_Userinfo_code ");
            SqlParameter[] parameters = {new SqlParameter("@C_Userinfo_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = roleId;

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
            strSql.Append(" C_Userinfo_code,C_Parameters_id ");
            strSql.Append(" FROM C_Userinfo_case_type ");
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
        public int GetRecordCount(Model.SysManager.C_Userinfo_case_type model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM C_Userinfo_case_type ");
            strSql.Append(" where 1=1");
            if (model != null)
            {
                if (model.C_Userinfo_code != null)
                {
                    strSql.Append(" and C_Userinfo_code=@C_Userinfo_code");
                }
                if (model.C_Parameters_id != null)
                {
                    strSql.Append(" and C_Parameters_id=@C_Parameters_id");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Userinfo_code;
            parameters[1].Value = model.C_Parameters_id;
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
        public DataSet GetListByPage(Model.SysManager.C_Userinfo_case_type model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Userinfo_code desc");
			}
            strSql.Append(")AS Row, T.*,r.C_Userinfo_name,p.C_Parameters_name from C_Userinfo_case_type T left join C_Userinfo as r on T.C_Userinfo_code=r.C_Userinfo_code  left join C_Parameters as p on T.C_Parameters_id=p.C_Parameters_id ");
            strSql.Append(" where 1=1 ");
            if(model!=null)
            {
                if(model.C_Userinfo_code!=null)
                {
                    strSql.Append(" and T.C_Userinfo_code=@C_Userinfo_code");
                }
                if (model.C_Parameters_id != null)
                {
                    strSql.Append(" and T.C_Parameters_id=@C_Parameters_id");
                }
            }

			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Userinfo_code;
            parameters[1].Value = model.C_Parameters_id;
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
			parameters[0].Value = "C_Userinfo_case_type";
			parameters[1].Value = "C_Userinfo_code";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 根据用户编码删除用户和案件类型之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>是否成功</returns>
        public bool DeleteUserinfoCaseTypeByUserCode(Guid userCode)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Userinfo_case_type ");
            strSql.Append(" where C_Userinfo_code=@C_Userinfo_code");
            SqlParameter[] parameters = {
                new SqlParameter("@C_Userinfo_code",SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = userCode;

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
		#endregion  ExtensionMethod
	}
}

