using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件级别变更记录表
    /// 作者：崔慧栋
    /// 日期：2015/12/16
    /// </summary>
	public partial class B_CaseLevelChangeRecords
	{
		public B_CaseLevelChangeRecords()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("B_CaseLevelChangeRecords_id", "B_CaseLevelChangeRecords"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int B_CaseLevelChangeRecords_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_CaseLevelChangeRecords");
			strSql.Append(" where B_CaseLevelChangeRecords_id=@B_CaseLevelChangeRecords_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelChangeRecords_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseLevelChangeRecords_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_CaseLevelChangeRecords(");
			strSql.Append("B_CaseLevelChangeRecords_code,B_Case_code,B_CaseLevelChangeRecords_type,B_CaseLevelChangeRecords_applicationData,B_CaseLevelChangeRecords_actualChangeDate,B_CaseLevelChangeRecords_applicationPerson,B_CaseLevelChangeRecords_auditor,B_CaseLevelChangeRecords_conversionReasons,B_CaseLevelChangeRecords_isAudit,B_CaseLevelChangeRecords_auditOpinion,B_CaseLevelChangeRecords_creator,B_CaseLevelChangeRecords_createTime,B_CaseLevelChangeRecords_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_CaseLevelChangeRecords_code,@B_Case_code,@B_CaseLevelChangeRecords_type,@B_CaseLevelChangeRecords_applicationData,@B_CaseLevelChangeRecords_actualChangeDate,@B_CaseLevelChangeRecords_applicationPerson,@B_CaseLevelChangeRecords_auditor,@B_CaseLevelChangeRecords_conversionReasons,@B_CaseLevelChangeRecords_isAudit,@B_CaseLevelChangeRecords_auditOpinion,@B_CaseLevelChangeRecords_creator,@B_CaseLevelChangeRecords_createTime,@B_CaseLevelChangeRecords_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelChangeRecords_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelChangeRecords_type", SqlDbType.Int,4),
					new SqlParameter("@B_CaseLevelChangeRecords_applicationData", SqlDbType.DateTime),
					new SqlParameter("@B_CaseLevelChangeRecords_actualChangeDate", SqlDbType.DateTime),
					new SqlParameter("@B_CaseLevelChangeRecords_applicationPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelChangeRecords_auditor", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelChangeRecords_conversionReasons", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseLevelChangeRecords_isAudit", SqlDbType.Bit,1),
					new SqlParameter("@B_CaseLevelChangeRecords_auditOpinion", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseLevelChangeRecords_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelChangeRecords_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseLevelChangeRecords_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.B_CaseLevelChangeRecords_code;
            parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_CaseLevelChangeRecords_type;
			parameters[3].Value = model.B_CaseLevelChangeRecords_applicationData;
			parameters[4].Value = model.B_CaseLevelChangeRecords_actualChangeDate;
            parameters[5].Value = model.B_CaseLevelChangeRecords_applicationPerson;
            parameters[6].Value = model.B_CaseLevelChangeRecords_auditor;
			parameters[7].Value = model.B_CaseLevelChangeRecords_conversionReasons;
			parameters[8].Value = model.B_CaseLevelChangeRecords_isAudit;
			parameters[9].Value = model.B_CaseLevelChangeRecords_auditOpinion;
            parameters[10].Value = model.B_CaseLevelChangeRecords_creator;
			parameters[11].Value = model.B_CaseLevelChangeRecords_createTime;
			parameters[12].Value = model.B_CaseLevelChangeRecords_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_CaseLevelChangeRecords set ");
			strSql.Append("B_CaseLevelChangeRecords_code=@B_CaseLevelChangeRecords_code,");
			strSql.Append("B_Case_code=@B_Case_code,");
			strSql.Append("B_CaseLevelChangeRecords_type=@B_CaseLevelChangeRecords_type,");
			strSql.Append("B_CaseLevelChangeRecords_applicationData=@B_CaseLevelChangeRecords_applicationData,");
			strSql.Append("B_CaseLevelChangeRecords_actualChangeDate=@B_CaseLevelChangeRecords_actualChangeDate,");
			strSql.Append("B_CaseLevelChangeRecords_applicationPerson=@B_CaseLevelChangeRecords_applicationPerson,");
			strSql.Append("B_CaseLevelChangeRecords_auditor=@B_CaseLevelChangeRecords_auditor,");
			strSql.Append("B_CaseLevelChangeRecords_conversionReasons=@B_CaseLevelChangeRecords_conversionReasons,");
			strSql.Append("B_CaseLevelChangeRecords_isAudit=@B_CaseLevelChangeRecords_isAudit,");
			strSql.Append("B_CaseLevelChangeRecords_auditOpinion=@B_CaseLevelChangeRecords_auditOpinion,");
			strSql.Append("B_CaseLevelChangeRecords_creator=@B_CaseLevelChangeRecords_creator,");
			strSql.Append("B_CaseLevelChangeRecords_createTime=@B_CaseLevelChangeRecords_createTime,");
			strSql.Append("B_CaseLevelChangeRecords_isDelete=@B_CaseLevelChangeRecords_isDelete");
			strSql.Append(" where B_CaseLevelChangeRecords_id=@B_CaseLevelChangeRecords_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelChangeRecords_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelChangeRecords_type", SqlDbType.Int,4),
					new SqlParameter("@B_CaseLevelChangeRecords_applicationData", SqlDbType.DateTime),
					new SqlParameter("@B_CaseLevelChangeRecords_actualChangeDate", SqlDbType.DateTime),
					new SqlParameter("@B_CaseLevelChangeRecords_applicationPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelChangeRecords_auditor", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelChangeRecords_conversionReasons", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseLevelChangeRecords_isAudit", SqlDbType.Bit,1),
					new SqlParameter("@B_CaseLevelChangeRecords_auditOpinion", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseLevelChangeRecords_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelChangeRecords_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseLevelChangeRecords_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@B_CaseLevelChangeRecords_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_CaseLevelChangeRecords_code;
			parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_CaseLevelChangeRecords_type;
			parameters[3].Value = model.B_CaseLevelChangeRecords_applicationData;
			parameters[4].Value = model.B_CaseLevelChangeRecords_actualChangeDate;
			parameters[5].Value = model.B_CaseLevelChangeRecords_applicationPerson;
			parameters[6].Value = model.B_CaseLevelChangeRecords_auditor;
			parameters[7].Value = model.B_CaseLevelChangeRecords_conversionReasons;
			parameters[8].Value = model.B_CaseLevelChangeRecords_isAudit;
			parameters[9].Value = model.B_CaseLevelChangeRecords_auditOpinion;
			parameters[10].Value = model.B_CaseLevelChangeRecords_creator;
			parameters[11].Value = model.B_CaseLevelChangeRecords_createTime;
			parameters[12].Value = model.B_CaseLevelChangeRecords_isDelete;
			parameters[13].Value = model.B_CaseLevelChangeRecords_id;

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
		public bool Delete(int B_CaseLevelChangeRecords_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_CaseLevelChangeRecords set B_CaseLevelChangeRecords_isDelete=1 ");
			strSql.Append(" where B_CaseLevelChangeRecords_id=@B_CaseLevelChangeRecords_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelChangeRecords_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseLevelChangeRecords_id;

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
        public bool Delete(Guid B_CaseLevelChangeRecords_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_CaseLevelChangeRecords set B_CaseLevelChangeRecords_isDelete=1 ");
            strSql.Append(" where B_CaseLevelChangeRecords_code=@B_CaseLevelChangeRecords_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelChangeRecords_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_CaseLevelChangeRecords_code;

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
		public bool DeleteList(string B_CaseLevelChangeRecords_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_CaseLevelChangeRecords ");
			strSql.Append(" where B_CaseLevelChangeRecords_id in ("+B_CaseLevelChangeRecords_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_CaseLevelChangeRecords GetModel(int B_CaseLevelChangeRecords_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 B_CaseLevelChangeRecords_id,B_CaseLevelChangeRecords_code,B_Case_code,B_CaseLevelChangeRecords_type,B_CaseLevelChangeRecords_applicationData,B_CaseLevelChangeRecords_actualChangeDate,B_CaseLevelChangeRecords_applicationPerson,B_CaseLevelChangeRecords_auditor,B_CaseLevelChangeRecords_conversionReasons,B_CaseLevelChangeRecords_isAudit,B_CaseLevelChangeRecords_auditOpinion,B_CaseLevelChangeRecords_creator,B_CaseLevelChangeRecords_createTime,B_CaseLevelChangeRecords_isDelete from B_CaseLevelChangeRecords ");
			strSql.Append(" where B_CaseLevelChangeRecords_id=@B_CaseLevelChangeRecords_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelChangeRecords_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseLevelChangeRecords_id;

            CommonService.Model.CaseManager.B_CaseLevelChangeRecords model = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
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
        public CommonService.Model.CaseManager.B_CaseLevelChangeRecords GetModel(Guid B_CaseLevelChangeRecords_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_CaseLevelChangeRecords_id,B_CaseLevelChangeRecords_code,B_Case_code,B_CaseLevelChangeRecords_type,B_CaseLevelChangeRecords_applicationData,B_CaseLevelChangeRecords_actualChangeDate,B_CaseLevelChangeRecords_applicationPerson,B_CaseLevelChangeRecords_auditor,B_CaseLevelChangeRecords_conversionReasons,B_CaseLevelChangeRecords_isAudit,B_CaseLevelChangeRecords_auditOpinion,B_CaseLevelChangeRecords_creator,B_CaseLevelChangeRecords_createTime,B_CaseLevelChangeRecords_isDelete from B_CaseLevelChangeRecords ");
            strSql.Append(" where B_CaseLevelChangeRecords_code=@B_CaseLevelChangeRecords_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelChangeRecords_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_CaseLevelChangeRecords_code;

            CommonService.Model.CaseManager.B_CaseLevelChangeRecords model = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
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
        /// 根据案件Guid获得记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseLevelChangeRecords GetModelByCaseCode(Guid caseCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_CaseLevelChangeRecords_id,B_CaseLevelChangeRecords_code,B_Case_code,B_CaseLevelChangeRecords_type,B_CaseLevelChangeRecords_applicationData,B_CaseLevelChangeRecords_actualChangeDate,B_CaseLevelChangeRecords_applicationPerson,B_CaseLevelChangeRecords_auditor,B_CaseLevelChangeRecords_conversionReasons,B_CaseLevelChangeRecords_isAudit,B_CaseLevelChangeRecords_auditOpinion,B_CaseLevelChangeRecords_creator,B_CaseLevelChangeRecords_createTime,B_CaseLevelChangeRecords_isDelete from B_CaseLevelChangeRecords ");
            strSql.Append(" where B_Case_code=@B_Case_code and B_CaseLevelChangeRecords_isDelete=0 and B_CaseLevelChangeRecords_isAudit=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = caseCode;

            CommonService.Model.CaseManager.B_CaseLevelChangeRecords model = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
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
        /// 根据案件Guid获得未审核的记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseLevelChangeRecords GetModelByCaseCodeIsNotAudit(Guid caseCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_CaseLevelChangeRecords_id,B_CaseLevelChangeRecords_code,B_Case_code,B_CaseLevelChangeRecords_type,B_CaseLevelChangeRecords_applicationData,B_CaseLevelChangeRecords_actualChangeDate,B_CaseLevelChangeRecords_applicationPerson,B_CaseLevelChangeRecords_auditor,B_CaseLevelChangeRecords_conversionReasons,B_CaseLevelChangeRecords_isAudit,B_CaseLevelChangeRecords_auditOpinion,B_CaseLevelChangeRecords_creator,B_CaseLevelChangeRecords_createTime,B_CaseLevelChangeRecords_isDelete from B_CaseLevelChangeRecords ");
            strSql.Append(" where B_Case_code=@B_Case_code and B_CaseLevelChangeRecords_isAudit=0 and B_CaseLevelChangeRecords_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = caseCode;

            CommonService.Model.CaseManager.B_CaseLevelChangeRecords model = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
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
        public CommonService.Model.CaseManager.B_CaseLevelChangeRecords DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_CaseLevelChangeRecords model = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
			if (row != null)
			{
				if(row["B_CaseLevelChangeRecords_id"]!=null && row["B_CaseLevelChangeRecords_id"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_id=int.Parse(row["B_CaseLevelChangeRecords_id"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_code"]!=null && row["B_CaseLevelChangeRecords_code"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_code= new Guid(row["B_CaseLevelChangeRecords_code"].ToString());
				}
				if(row["B_Case_code"]!=null && row["B_Case_code"].ToString()!="")
				{
					model.B_Case_code= new Guid(row["B_Case_code"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_type"]!=null && row["B_CaseLevelChangeRecords_type"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_type=int.Parse(row["B_CaseLevelChangeRecords_type"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_applicationData"]!=null && row["B_CaseLevelChangeRecords_applicationData"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_applicationData=DateTime.Parse(row["B_CaseLevelChangeRecords_applicationData"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_actualChangeDate"]!=null && row["B_CaseLevelChangeRecords_actualChangeDate"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_actualChangeDate=DateTime.Parse(row["B_CaseLevelChangeRecords_actualChangeDate"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_applicationPerson"]!=null && row["B_CaseLevelChangeRecords_applicationPerson"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_applicationPerson= new Guid(row["B_CaseLevelChangeRecords_applicationPerson"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_auditor"]!=null && row["B_CaseLevelChangeRecords_auditor"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_auditor= new Guid(row["B_CaseLevelChangeRecords_auditor"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_conversionReasons"]!=null)
				{
					model.B_CaseLevelChangeRecords_conversionReasons=row["B_CaseLevelChangeRecords_conversionReasons"].ToString();
				}
				if(row["B_CaseLevelChangeRecords_isAudit"]!=null && row["B_CaseLevelChangeRecords_isAudit"].ToString()!="")
				{
					if((row["B_CaseLevelChangeRecords_isAudit"].ToString()=="1")||(row["B_CaseLevelChangeRecords_isAudit"].ToString().ToLower()=="true"))
					{
						model.B_CaseLevelChangeRecords_isAudit=true;
					}
					else
					{
						model.B_CaseLevelChangeRecords_isAudit=false;
					}
				}
				if(row["B_CaseLevelChangeRecords_auditOpinion"]!=null)
				{
					model.B_CaseLevelChangeRecords_auditOpinion=row["B_CaseLevelChangeRecords_auditOpinion"].ToString();
				}
				if(row["B_CaseLevelChangeRecords_creator"]!=null && row["B_CaseLevelChangeRecords_creator"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_creator= new Guid(row["B_CaseLevelChangeRecords_creator"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_createTime"]!=null && row["B_CaseLevelChangeRecords_createTime"].ToString()!="")
				{
					model.B_CaseLevelChangeRecords_createTime=DateTime.Parse(row["B_CaseLevelChangeRecords_createTime"].ToString());
				}
				if(row["B_CaseLevelChangeRecords_isDelete"]!=null && row["B_CaseLevelChangeRecords_isDelete"].ToString()!="")
				{
					if((row["B_CaseLevelChangeRecords_isDelete"].ToString()=="1")||(row["B_CaseLevelChangeRecords_isDelete"].ToString().ToLower()=="true"))
					{
						model.B_CaseLevelChangeRecords_isDelete=true;
					}
					else
					{
						model.B_CaseLevelChangeRecords_isDelete=false;
					}
				}
                if (row.Table.Columns.Contains("B_CaseLevelChangeRecords_applicationPersonName"))
                {
                    if (row["B_CaseLevelChangeRecords_applicationPersonName"] != null && row["B_CaseLevelChangeRecords_applicationPersonName"].ToString() != "")
                    {
                        model.B_CaseLevelChangeRecords_applicationPersonName = row["B_CaseLevelChangeRecords_applicationPersonName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_CaseLevelChangeRecords_auditorName"))
                {
                    if (row["B_CaseLevelChangeRecords_auditorName"] != null && row["B_CaseLevelChangeRecords_auditorName"].ToString() != "")
                    {
                        model.B_CaseLevelChangeRecords_auditorName = row["B_CaseLevelChangeRecords_auditorName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_CaseLevelChangeRecords_typeName"))
                {
                    if (row["B_CaseLevelChangeRecords_typeName"] != null && row["B_CaseLevelChangeRecords_typeName"].ToString() != "")
                    {
                        model.B_CaseLevelChangeRecords_typeName = row["B_CaseLevelChangeRecords_typeName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_CaseLevelchange_typeName"))
                {
                    if (row["B_CaseLevelchange_typeName"] != null && row["B_CaseLevelchange_typeName"].ToString() != "")
                    {
                        model.B_CaseLevelchange_typeName = row["B_CaseLevelchange_typeName"].ToString();
                    }
                }
			}
			return model;
		}
        /// <summary>
        /// 根据案件Guid获得数据
        /// </summary>
        /// <param name="CaseCode"></param>
        /// <returns></returns>
        public DataSet GetListByCaseCode(Guid CaseCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.B_CaseLevelChangeRecords_id,T.B_CaseLevelChangeRecords_code,T.B_Case_code,T.B_CaseLevelChangeRecords_type,T.B_CaseLevelChangeRecords_applicationData,T.B_CaseLevelChangeRecords_actualChangeDate,T.B_CaseLevelChangeRecords_applicationPerson,T.B_CaseLevelChangeRecords_auditor,T.B_CaseLevelChangeRecords_conversionReasons,T.B_CaseLevelChangeRecords_isAudit,T.B_CaseLevelChangeRecords_auditOpinion,T.B_CaseLevelChangeRecords_creator,T.B_CaseLevelChangeRecords_createTime,T.B_CaseLevelChangeRecords_isDelete,");
            strSql.Append("U.C_Userinfo_name as B_CaseLevelChangeRecords_applicationPersonName,P.C_Parameters_name as B_CaseLevelChangeRecords_typeName,dbo.getCaseLevelByRecords(T.B_CaseLevelChangeRecords_code) As 'B_CaseLevelchange_typeName'");
            strSql.Append(" FROM B_CaseLevelChangeRecords as T ");
            strSql.Append("left join C_Parameters as P on T.B_CaseLevelChangeRecords_type=P.C_Parameters_id ");
            strSql.Append("left join C_Userinfo as U on T.B_CaseLevelChangeRecords_applicationPerson=U.C_Userinfo_code ");
            strSql.Append("where T.B_CaseLevelChangeRecords_isDelete=0 and T.B_CaseLevelChangeRecords_isAudit=1 and T.B_Case_code=@B_Case_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = CaseCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select B_CaseLevelChangeRecords_id,B_CaseLevelChangeRecords_code,B_Case_code,B_CaseLevelChangeRecords_type,B_CaseLevelChangeRecords_applicationData,B_CaseLevelChangeRecords_actualChangeDate,B_CaseLevelChangeRecords_applicationPerson,B_CaseLevelChangeRecords_auditor,B_CaseLevelChangeRecords_conversionReasons,B_CaseLevelChangeRecords_isAudit,B_CaseLevelChangeRecords_auditOpinion,B_CaseLevelChangeRecords_creator,B_CaseLevelChangeRecords_createTime,B_CaseLevelChangeRecords_isDelete ");
			strSql.Append(" FROM B_CaseLevelChangeRecords ");
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
			strSql.Append(" B_CaseLevelChangeRecords_id,B_CaseLevelChangeRecords_code,B_Case_code,B_CaseLevelChangeRecords_type,B_CaseLevelChangeRecords_applicationData,B_CaseLevelChangeRecords_actualChangeDate,B_CaseLevelChangeRecords_applicationPerson,B_CaseLevelChangeRecords_auditor,B_CaseLevelChangeRecords_conversionReasons,B_CaseLevelChangeRecords_isAudit,B_CaseLevelChangeRecords_auditOpinion,B_CaseLevelChangeRecords_creator,B_CaseLevelChangeRecords_createTime,B_CaseLevelChangeRecords_isDelete ");
			strSql.Append(" FROM B_CaseLevelChangeRecords ");
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM B_CaseLevelChangeRecords ");
            strSql.Append("where 1=1 and B_CaseLevelChangeRecords_isDelete=0 ");
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
		public DataSet GetListByPage(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.B_CaseLevelChangeRecords_id desc");
			}
            strSql.Append(")AS Row, T.*  from B_CaseLevelChangeRecords T ");
            strSql.Append("where 1=1 and B_CaseLevelChangeRecords_isDelete=0 ");

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
			parameters[0].Value = "B_CaseLevelChangeRecords";
			parameters[1].Value = "B_CaseLevelChangeRecords_id";
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

