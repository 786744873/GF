using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.FinanceManager
{
    /// <summary>
    /// 数据访问类:凭证信息-子表单中间表
    /// 作者：崔慧栋
    /// 日期：2015/08/25
    /// </summary>
	public partial class C_Voucher_Form
	{
		public C_Voucher_Form()
		{}
		#region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid F_Form_code, Guid C_Voucher_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Voucher_Form");
            strSql.Append(" where F_Form_code=@F_Form_code ");
            strSql.Append("and C_Voucher_code=@C_Voucher_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Voucher_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_Form_code;
            parameters[1].Value = C_Voucher_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.FinanceManager.C_Voucher_Form model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Voucher_Form(");
			strSql.Append("F_Form_code,C_Voucher_code)");
			strSql.Append(" values (");
			strSql.Append("@F_Form_code,@C_Voucher_code)");
			SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.F_Form_code;
			parameters[1].Value = model.C_Voucher_code;

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
        public bool Update(CommonService.Model.FinanceManager.C_Voucher_Form model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Voucher_Form set ");
			strSql.Append("F_Form_code=@F_Form_code,");
			strSql.Append("C_Voucher_code=@C_Voucher_code");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.F_Form_code;
			parameters[1].Value = model.C_Voucher_code;

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
        public bool Delete(Guid F_Form_code, Guid C_Voucher_code)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Voucher_Form ");
            strSql.Append(" where F_Form_code=@F_Form_code ");
            strSql.Append("and C_Voucher_code=@C_Voucher_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_Form_code;
            parameters[1].Value = C_Voucher_code;

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
        public CommonService.Model.FinanceManager.C_Voucher_Form GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_Form_code,C_Voucher_code from C_Voucher_Form ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

            CommonService.Model.FinanceManager.C_Voucher_Form model = new CommonService.Model.FinanceManager.C_Voucher_Form();
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
        public CommonService.Model.FinanceManager.C_Voucher_Form DataRowToModel(DataRow row)
		{
            CommonService.Model.FinanceManager.C_Voucher_Form model = new CommonService.Model.FinanceManager.C_Voucher_Form();
			if (row != null)
			{
				if(row["F_Form_code"]!=null && row["F_Form_code"].ToString()!="")
				{
					model.F_Form_code= new Guid(row["F_Form_code"].ToString());
				}
				if(row["C_Voucher_code"]!=null && row["C_Voucher_code"].ToString()!="")
				{
					model.C_Voucher_code= new Guid(row["C_Voucher_code"].ToString());
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
			strSql.Append("select F_Form_code,C_Voucher_code ");
			strSql.Append(" FROM C_Voucher_Form ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据凭证信息Code获得数据列表
        /// </summary>
        public DataSet GetListByVoucherCode(Guid C_Voucher_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_Form_code,C_Voucher_code ");
            strSql.Append(" FROM C_Voucher_Form ");
            strSql.Append("where C_Voucher_code=@C_Voucher_code ");
            SqlParameter[] parameters = {
                            new SqlParameter("@C_Voucher_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Voucher_code;
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
			strSql.Append(" F_Form_code,C_Voucher_code ");
			strSql.Append(" FROM C_Voucher_Form ");
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
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Voucher_Form ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
			strSql.Append(")AS Row, T.*  from C_Voucher_Form T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
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
			parameters[0].Value = "C_Voucher_Form";
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

