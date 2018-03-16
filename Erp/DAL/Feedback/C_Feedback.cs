using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.Feedback
{
    /// <summary>
    /// 数据访问类:意见反馈表
    /// 作者：崔慧栋
    /// 日期：2015/10/14
    /// </summary>
	public partial class C_Feedback
	{
		public C_Feedback()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("C_Feedback_id", "C_Feedback"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int C_Feedback_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Feedback");
			strSql.Append(" where C_Feedback_id=@C_Feedback_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Feedback_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.Feedback.C_Feedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Feedback(");
            strSql.Append("C_Feedback_code,C_Feedback_thePage,C_Feedback_wantFunction,C_Feedback_Description,C_Feedback_state,C_Feedback_applicant,C_Feedback_dateTime,C_Feedback_audiPerson,C_Feedback_audiTime,C_Feedback_replyContent,C_Feedback_Integral)");
			strSql.Append(" values (");
            strSql.Append("@C_Feedback_code,@C_Feedback_thePage,@C_Feedback_wantFunction,@C_Feedback_Description,@C_Feedback_state,@C_Feedback_applicant,@C_Feedback_dateTime,@C_Feedback_audiPerson,@C_Feedback_audiTime,@C_Feedback_replyContent,@C_Feedback_Integral)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Feedback_thePage", SqlDbType.VarChar,50),
					new SqlParameter("@C_Feedback_wantFunction", SqlDbType.Int,4),
					new SqlParameter("@C_Feedback_Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@C_Feedback_state", SqlDbType.Int,4),
					new SqlParameter("@C_Feedback_applicant", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Feedback_dateTime", SqlDbType.DateTime),
					new SqlParameter("@C_Feedback_audiPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Feedback_audiTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Feedback_replyContent",SqlDbType.NVarChar,1000),
                    new SqlParameter("@C_Feedback_Integral",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.C_Feedback_code;
			parameters[1].Value = model.C_Feedback_thePage;
			parameters[2].Value = model.C_Feedback_wantFunction;
			parameters[3].Value = model.C_Feedback_Description;
			parameters[4].Value = model.C_Feedback_state;
            parameters[5].Value = model.C_Feedback_applicant;
			parameters[6].Value = model.C_Feedback_dateTime;
            parameters[7].Value = model.C_Feedback_audiPerson;
			parameters[8].Value = model.C_Feedback_audiTime;
            parameters[9].Value = model.C_Feedback_replyContent;
            parameters[10].Value = model.C_Feedback_Integral;

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
        public bool Update(CommonService.Model.Feedback.C_Feedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Feedback set ");
			strSql.Append("C_Feedback_code=@C_Feedback_code,");
			strSql.Append("C_Feedback_thePage=@C_Feedback_thePage,");
			strSql.Append("C_Feedback_wantFunction=@C_Feedback_wantFunction,");
			strSql.Append("C_Feedback_Description=@C_Feedback_Description,");
			strSql.Append("C_Feedback_state=@C_Feedback_state,");
			strSql.Append("C_Feedback_applicant=@C_Feedback_applicant,");
			strSql.Append("C_Feedback_dateTime=@C_Feedback_dateTime,");
			strSql.Append("C_Feedback_audiPerson=@C_Feedback_audiPerson,");
			strSql.Append("C_Feedback_audiTime=@C_Feedback_audiTime,");
            strSql.Append("C_Feedback_replyContent=@C_Feedback_replyContent,");
            strSql.Append("C_Feedback_Integral=@C_Feedback_Integral ");
			strSql.Append(" where C_Feedback_id=@C_Feedback_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Feedback_thePage", SqlDbType.VarChar,50),
					new SqlParameter("@C_Feedback_wantFunction", SqlDbType.Int,4),
					new SqlParameter("@C_Feedback_Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@C_Feedback_state", SqlDbType.Int,4),
					new SqlParameter("@C_Feedback_applicant", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Feedback_dateTime", SqlDbType.DateTime),
					new SqlParameter("@C_Feedback_audiPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Feedback_audiTime", SqlDbType.DateTime),
					new SqlParameter("@C_Feedback_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Feedback_replyContent",SqlDbType.NVarChar,1000),
                    new SqlParameter("@C_Feedback_Integral",SqlDbType.Int,4)
                                        };
			parameters[0].Value = model.C_Feedback_code;
			parameters[1].Value = model.C_Feedback_thePage;
			parameters[2].Value = model.C_Feedback_wantFunction;
			parameters[3].Value = model.C_Feedback_Description;
			parameters[4].Value = model.C_Feedback_state;
			parameters[5].Value = model.C_Feedback_applicant;
			parameters[6].Value = model.C_Feedback_dateTime;
			parameters[7].Value = model.C_Feedback_audiPerson;
			parameters[8].Value = model.C_Feedback_audiTime;
			parameters[9].Value = model.C_Feedback_id;
            parameters[10].Value = model.C_Feedback_replyContent;
            parameters[11].Value = model.C_Feedback_Integral;

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
		public bool Delete(int C_Feedback_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Feedback ");
			strSql.Append(" where C_Feedback_id=@C_Feedback_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Feedback_id;

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
		public bool DeleteList(string C_Feedback_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Feedback ");
			strSql.Append(" where C_Feedback_id in ("+C_Feedback_idlist + ")  ");
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
        public CommonService.Model.Feedback.C_Feedback GetModel(int C_Feedback_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 C_Feedback_id,C_Feedback_code,C_Feedback_thePage,C_Feedback_wantFunction,C_Feedback_Description,C_Feedback_state,C_Feedback_applicant,C_Feedback_dateTime,C_Feedback_audiPerson,C_Feedback_audiTime,C_Feedback_replyContent,C_Feedback_Integral from C_Feedback ");
			strSql.Append(" where C_Feedback_id=@C_Feedback_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Feedback_id;

            CommonService.Model.Feedback.C_Feedback model = new CommonService.Model.Feedback.C_Feedback();
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
        public CommonService.Model.Feedback.C_Feedback GetModel(Guid C_Feedback_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Feedback_id,C_Feedback_code,C_Feedback_thePage,C_Feedback_wantFunction,C_Feedback_Description,C_Feedback_state,C_Feedback_applicant,C_Feedback_dateTime,C_Feedback_audiPerson,C_Feedback_audiTime,C_Feedback_replyContent,C_Feedback_Integral from C_Feedback ");
            strSql.Append(" where C_Feedback_code=@C_Feedback_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Feedback_code;

            CommonService.Model.Feedback.C_Feedback model = new CommonService.Model.Feedback.C_Feedback();
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
        public CommonService.Model.Feedback.C_Feedback DataRowToModel(DataRow row)
		{
            CommonService.Model.Feedback.C_Feedback model = new CommonService.Model.Feedback.C_Feedback();
			if (row != null)
			{
				if(row["C_Feedback_id"]!=null && row["C_Feedback_id"].ToString()!="")
				{
					model.C_Feedback_id=int.Parse(row["C_Feedback_id"].ToString());
				}
				if(row["C_Feedback_code"]!=null && row["C_Feedback_code"].ToString()!="")
				{
					model.C_Feedback_code= new Guid(row["C_Feedback_code"].ToString());
				}
				if(row["C_Feedback_thePage"]!=null)
				{
					model.C_Feedback_thePage=row["C_Feedback_thePage"].ToString();
				}
				if(row["C_Feedback_wantFunction"]!=null && row["C_Feedback_wantFunction"].ToString()!="")
				{
					model.C_Feedback_wantFunction=int.Parse(row["C_Feedback_wantFunction"].ToString());
				}
				if(row["C_Feedback_Description"]!=null)
				{
					model.C_Feedback_Description=row["C_Feedback_Description"].ToString();
				}
				if(row["C_Feedback_state"]!=null && row["C_Feedback_state"].ToString()!="")
				{
					model.C_Feedback_state=int.Parse(row["C_Feedback_state"].ToString());
				}
				if(row["C_Feedback_applicant"]!=null && row["C_Feedback_applicant"].ToString()!="")
				{
					model.C_Feedback_applicant= new Guid(row["C_Feedback_applicant"].ToString());
				}
				if(row["C_Feedback_dateTime"]!=null && row["C_Feedback_dateTime"].ToString()!="")
				{
					model.C_Feedback_dateTime=DateTime.Parse(row["C_Feedback_dateTime"].ToString());
				}
				if(row["C_Feedback_audiPerson"]!=null && row["C_Feedback_audiPerson"].ToString()!="")
				{
					model.C_Feedback_audiPerson= new Guid(row["C_Feedback_audiPerson"].ToString());
				}
				if(row["C_Feedback_audiTime"]!=null && row["C_Feedback_audiTime"].ToString()!="")
				{
					model.C_Feedback_audiTime=DateTime.Parse(row["C_Feedback_audiTime"].ToString());
				}
                if(row["C_Feedback_replyContent"]!=null && row["C_Feedback_replyContent"].ToString()!="")
                {
                    model.C_Feedback_replyContent = row["C_Feedback_replyContent"].ToString();
                }
                if(row.Table.Columns.Contains("C_Feedback_wantfunctionName"))
                {
                    if(row["C_Feedback_wantfunctionName"]!=null && row["C_Feedback_wantfunctionName"].ToString()!="")
                    {
                        model.C_Feedback_wantfunctionName = row["C_Feedback_wantfunctionName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Feedback_stateName"))
                {
                    if (row["C_Feedback_stateName"] != null && row["C_Feedback_stateName"].ToString() != "")
                    {
                        model.C_Feedback_stateName = row["C_Feedback_stateName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Feedback_applicantName"))
                {
                    if (row["C_Feedback_applicantName"] != null && row["C_Feedback_applicantName"].ToString() != "")
                    {
                        model.C_Feedback_applicantName = row["C_Feedback_applicantName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Feedback_audipersonName"))
                {
                    if (row["C_Feedback_audipersonName"] != null && row["C_Feedback_audipersonName"].ToString() != "")
                    {
                        model.C_Feedback_audipersonName = row["C_Feedback_audipersonName"].ToString();
                    }
                }
                if(row["C_Feedback_Integral"]!=null && row["C_Feedback_Integral"].ToString()!="")
                {
                    model.C_Feedback_Integral = Convert.ToInt32(row["C_Feedback_Integral"].ToString());
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
            strSql.Append("select C_Feedback_id,C_Feedback_code,C_Feedback_thePage,C_Feedback_wantFunction,C_Feedback_Description,C_Feedback_state,C_Feedback_applicant,C_Feedback_dateTime,C_Feedback_audiPerson,C_Feedback_audiTime,C_Feedback_replyContent,C_Feedback_Integral ");
			strSql.Append(" FROM C_Feedback ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Feedback_id,C_Feedback_code,C_Feedback_thePage,C_Feedback_wantFunction,C_Feedback_Description,C_Feedback_state,C_Feedback_applicant,C_Feedback_dateTime,C_Feedback_audiPerson,C_Feedback_audiTime,C_Feedback_replyContent,C_Feedback_Integral ");
            strSql.Append(" FROM C_Feedback ");
            return DbHelperSQL.Query(strSql.ToString());
        }

              /// <summary>
        /// 根据申请人获得数据
        /// </summary>
        /// <param name="C_Feedback_applicant"></param>
        /// <returns></returns>
        public DataSet GetListByApplicant(Guid C_Feedback_applicant)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Feedback_id,C_Feedback_code,C_Feedback_thePage,C_Feedback_wantFunction,C_Feedback_Description,C_Feedback_state,C_Feedback_applicant,C_Feedback_dateTime,C_Feedback_audiPerson,C_Feedback_audiTime,C_Feedback_replyContent,C_Feedback_Integral ");
            strSql.Append(" FROM C_Feedback ");
            strSql.Append(" where 1=1 and C_Feedback_applicant=@C_Feedback_applicant ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_applicant", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Feedback_applicant;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            strSql.Append(" C_Feedback_id,C_Feedback_code,C_Feedback_thePage,C_Feedback_wantFunction,C_Feedback_Description,C_Feedback_state,C_Feedback_applicant,C_Feedback_dateTime,C_Feedback_audiPerson,C_Feedback_audiTime,C_Feedback_replyContent,C_Feedback_Integral ");
			strSql.Append(" FROM C_Feedback ");
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
        public int GetRecordCount(CommonService.Model.Feedback.C_Feedback model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM C_Feedback as T ");
            strSql.Append(" left join C_Userinfo as U1 on T.C_Feedback_applicant=U1.C_Userinfo_code ");
            strSql.Append(" left join C_Userinfo as U2 on T.C_Feedback_audiPerson=U2.C_Userinfo_code ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.C_Feedback_thePage != null)
                {
                    strSql.Append(" and C_Feedback_thePage like N'%'+@C_Feedback_thePage+'%' ");
                }
                if (model.C_Feedback_applicantName != null)
                {
                    strSql.Append(" and U1.C_Userinfo_name like N'%'+@C_Feedback_applicantName+'%' ");
                }
                if (model.C_Feedback_state != null)
                {
                    strSql.Append(" and C_Feedback_state=@C_Feedback_state ");
                }
                if (model.C_Feedback_applicant != null)
                {
                    strSql.Append(" and C_Feedback_applicant=@C_Feedback_applicant ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_thePage", SqlDbType.VarChar),
                    new SqlParameter("@C_Feedback_applicantName",SqlDbType.VarChar),
                    new SqlParameter("@C_Feedback_state",SqlDbType.Int,4),
                    new SqlParameter("@C_Feedback_applicant",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_Feedback_thePage;
            parameters[1].Value = model.C_Feedback_applicantName;
            parameters[2].Value = model.C_Feedback_state;
            parameters[3].Value = model.C_Feedback_applicant;
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
		public DataSet GetListByPage(CommonService.Model.Feedback.C_Feedback model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Feedback_id desc");
			}
            strSql.Append(")AS Row, T.*,P1.C_Parameters_name as 'C_Feedback_wantfunctionName',P2.C_Parameters_name as 'C_Feedback_stateName',U1.C_Userinfo_name as 'C_Feedback_applicantName',U2.C_Userinfo_name as 'C_Feedback_audipersonName'  from C_Feedback T ");
            strSql.Append(" left join C_Parameters as P1 on T.C_Feedback_wantFunction=P1.C_Parameters_id ");
            strSql.Append(" left join C_Parameters as P2 on T.C_Feedback_state=P2.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U1 on T.C_Feedback_applicant=U1.C_Userinfo_code ");
            strSql.Append(" left join C_Userinfo as U2 on T.C_Feedback_audiPerson=U2.C_Userinfo_code ");
            strSql.Append(" where 1=1 ");
            if(model!=null)
            {
                if(model.C_Feedback_thePage!=null)
                {
                    strSql.Append(" and C_Feedback_thePage like N'%'+@C_Feedback_thePage+'%' ");
                }
                if(model.C_Feedback_applicantName!=null)
                {
                    strSql.Append(" and U1.C_Userinfo_name like N'%'+@C_Feedback_applicantName+'%' ");
                }
                if(model.C_Feedback_state!=null)
                {
                    strSql.Append(" and C_Feedback_state=@C_Feedback_state ");
                }
                if(model.C_Feedback_applicant!=null)
                {
                    strSql.Append(" and C_Feedback_applicant=@C_Feedback_applicant ");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Feedback_thePage", SqlDbType.VarChar),
                    new SqlParameter("@C_Feedback_applicantName",SqlDbType.VarChar),
                    new SqlParameter("@C_Feedback_state",SqlDbType.Int,4),
                    new SqlParameter("@C_Feedback_applicant",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_Feedback_thePage;
            parameters[1].Value = model.C_Feedback_applicantName;
            parameters[2].Value = model.C_Feedback_state;
            parameters[3].Value = model.C_Feedback_applicant;
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
			parameters[0].Value = "C_Feedback";
			parameters[1].Value = "C_Feedback_id";
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

