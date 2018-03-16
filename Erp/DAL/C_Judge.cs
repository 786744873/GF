using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
	/// <summary>
	/// 数据访问类:C_Judge
	/// </summary>
	public partial class C_Judge
	{
		public C_Judge()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Judge_id", "C_Judge");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid C_Judge_contactscode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Judge");
            strSql.Append(" where C_Judge_contactscode=@C_Judge_contactscode and C_Judge_isdelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Judge_contactscode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Judge_contactscode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Judge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Judge(");
            strSql.Append("C_Judge_code,C_Judge_number,C_Judge_contactscode,C_Judge_isdelete,C_Judge_creator,C_Judge_createTime)");
			strSql.Append(" values (");
            strSql.Append("@C_Judge_code,@C_Judge_number,@C_Judge_contactscode,@C_Judge_isdelete,@C_Judge_creator,@C_Judge_createTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Judge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Judge_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_Judge_contactscode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Judge_isdelete",SqlDbType.Bit),
                    new SqlParameter("@C_Judge_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Judge_createTime",SqlDbType.DateTime)};
            parameters[0].Value = model.C_Judge_code;
			parameters[1].Value = model.C_Judge_number;
			parameters[2].Value =model.C_Judge_contactscode;
            parameters[3].Value = model.C_Judge_isdelete;
            parameters[4].Value = model.C_Judge_creator;
            parameters[5].Value = model.C_Judge_createTime;

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
        public bool Update(CommonService.Model.C_Judge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Judge set ");
			strSql.Append("C_Judge_code=@C_Judge_code,");
			strSql.Append("C_Judge_number=@C_Judge_number,");
			strSql.Append("C_Judge_contactscode=@C_Judge_contactscode");
            strSql.Append("C_Judge_isdelete=@C_Judge_isdelete,");
            strSql.Append("C_Judge_creator=@C_Judge_creator,");
            strSql.Append("C_Judge_createTime=@C_Judge_createTime");
			strSql.Append(" where C_Judge_id=@C_Judge_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Judge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Judge_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_Judge_contactscode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Judge_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Judge_isdelete",SqlDbType.Bit),
                    new SqlParameter("@C_Judge_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Judge_createTime",SqlDbType.DateTime)};
			parameters[0].Value = model.C_Judge_code;
			parameters[1].Value = model.C_Judge_number;
			parameters[2].Value = model.C_Judge_contactscode;
			parameters[3].Value = model.C_Judge_id;
            parameters[4].Value = model.C_Judge_isdelete;
            parameters[5].Value = model.C_Judge_creator;
            parameters[6].Value = model.C_Judge_createTime;

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
        public bool Delete(Guid C_Judge_contactscode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Judge set C_Judge_isdelete=1");
            strSql.Append(" where C_Judge_contactscode=@C_Judge_contactscode");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Judge_contactscode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Judge_contactscode;

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
		public bool DeleteList(string C_Judge_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Judge ");
			strSql.Append(" where C_Judge_id in ("+C_Judge_idlist + ")  ");
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
        /// 根据法官Code得到一个对象实体
		/// </summary>
        public CommonService.Model.C_Judge GetModelByJudgeCode(Guid judge_code)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 a.C_Judge_id,a.C_Judge_code,a.C_Judge_number,a.C_Judge_contactscode,a.C_Judge_isdelete,a.C_Judge_creator,a.C_Judge_createTime,b.C_Contacts_name FROM C_Judge as a left join C_Contacts as b on a.C_Judge_contactscode=b.C_Contacts_code where a.C_Judge_isdelete=0");
            strSql.Append(" and a.C_Judge_code=@C_Judge_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Judge_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = judge_code;

            CommonService.Model.C_Judge model = new CommonService.Model.C_Judge();
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
        public CommonService.Model.C_Judge GetModel(int C_Judge_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Judge_id,C_Judge_code,C_Judge_number,C_Judge_contactscode,C_Judge_isdelete,C_Judge_creator,C_Judge_createTime from C_Judge");
            strSql.Append(" where C_Judge_id=@C_Judge_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Judge_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Judge_id;

            CommonService.Model.C_Judge model = new CommonService.Model.C_Judge();
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
        public CommonService.Model.C_Judge DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Judge model = new CommonService.Model.C_Judge();
			if (row != null)
			{
				if(row["C_Judge_id"]!=null && row["C_Judge_id"].ToString()!="")
				{
					model.C_Judge_id=int.Parse(row["C_Judge_id"].ToString());
				}
				if(row["C_Judge_code"]!=null && row["C_Judge_code"].ToString()!="")
				{
					model.C_Judge_code= new Guid(row["C_Judge_code"].ToString());
				}
                if (row["C_Contacts_name"] != null)
                {
                    model.C_Contacts_name = row["C_Contacts_name"].ToString();
                }
				if(row["C_Judge_number"]!=null)
				{
					model.C_Judge_number=row["C_Judge_number"].ToString();
				}
				if(row["C_Judge_contactscode"]!=null && row["C_Judge_contactscode"].ToString()!="")
				{
					model.C_Judge_contactscode= new Guid(row["C_Judge_contactscode"].ToString());
				}
                if (row["C_Judge_isdelete"] != null && row["C_Judge_isdelete"].ToString() != "")
                {
                    if ((row["C_Judge_isdelete"].ToString() == "1") || (row["C_Judge_isdelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Judge_isdelete = true;
                    }
                    else
                    {
                        model.C_Judge_isdelete = false;
                    }
                }
                if (row["C_Judge_creator"] != null && row["C_Judge_creator"].ToString() != "")
                {
                    model.C_Judge_creator = new Guid(row["C_Judge_creator"].ToString());
                }
                if (row["C_Judge_createTime"] != null && row["C_Judge_createTime"].ToString() != "")
                {
                    model.C_Judge_createTime = DateTime.Parse(row["C_Judge_createTime"].ToString());
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
            strSql.Append("select  top 1 C_Judge_id,C_Judge_code,C_Judge_number,C_Judge_contactscode,C_Judge_isdelete,C_Judge_creator,C_Judge_createTime from C_Judge");
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
            strSql.Append(" C_Judge_id,C_Judge_code,C_Judge_number,C_Judge_contactscode,C_Judge_isdelete,C_Judge_creator,C_Judge_createTime from C_Judge");
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
        public int GetRecordCount(Model.C_Judge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Judge");
			
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
        public DataSet GetListByPage(Model.C_Judge model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Judge_id desc");
			}
			strSql.Append(")AS Row, T.* from C_Judge T ");
            strSql.Append(" with(nolock) where 1=1");
			
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
			parameters[0].Value = "C_Judge";
			parameters[1].Value = "C_Judge_id";
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

