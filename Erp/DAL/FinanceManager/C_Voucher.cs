using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.FinanceManager
{
    /// <summary>
    /// 数据访问类:凭证信息表
    /// 作者：崔慧栋
    /// 日期：2015/08/25
    /// </summary>
	public partial class C_Voucher
	{
		public C_Voucher()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("C_Voucher_id", "C_Voucher"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int C_Voucher_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Voucher");
			strSql.Append(" where C_Voucher_id=@C_Voucher_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Voucher_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Voucher_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FinanceManager.C_Voucher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Voucher(");
            strSql.Append("C_Voucher_code,C_Voucher_number,C_Voucher_state,C_Voucher_applicationTime,C_Voucher_applicationPerson,C_Voucher_documentType,C_Voucher_department,C_Voucher_amounts,C_Voucher_superiorAuditPerson,C_Voucher_financeConfirmPerson,C_Voucher_confirmTime,C_Voucher_dismissedReasons,C_Voucher_auditStatus,C_Voucher_paymentMethod,C_Voucher_isDelete,C_Voucher_creator,C_Voucher_createTime,C_Voucher_region,C_Voucher_type)");
			strSql.Append(" values (");
            strSql.Append("@C_Voucher_code,@C_Voucher_number,@C_Voucher_state,@C_Voucher_applicationTime,@C_Voucher_applicationPerson,@C_Voucher_documentType,@C_Voucher_department,@C_Voucher_amounts,@C_Voucher_superiorAuditPerson,@C_Voucher_financeConfirmPerson,@C_Voucher_confirmTime,@C_Voucher_dismissedReasons,@C_Voucher_auditStatus,@C_Voucher_paymentMethod,@C_Voucher_isDelete,@C_Voucher_creator,@C_Voucher_createTime,@C_Voucher_region,@C_Voucher_type)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_number", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Voucher_state", SqlDbType.Int,4),
					new SqlParameter("@C_Voucher_applicationTime", SqlDbType.DateTime),
					new SqlParameter("@C_Voucher_applicationPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_documentType", SqlDbType.Int,4),
					new SqlParameter("@C_Voucher_department", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_amounts", SqlDbType.Decimal,9),
					new SqlParameter("@C_Voucher_superiorAuditPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_financeConfirmPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_confirmTime", SqlDbType.DateTime),
					new SqlParameter("@C_Voucher_dismissedReasons", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Voucher_auditStatus", SqlDbType.Int,4),
					new SqlParameter("@C_Voucher_paymentMethod", SqlDbType.Int,4),
					new SqlParameter("@C_Voucher_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Voucher_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_createTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_region",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Voucher_type",SqlDbType.Int,4),                    };
            parameters[0].Value = model.C_Voucher_code;
			parameters[1].Value = model.C_Voucher_number;
			parameters[2].Value = model.C_Voucher_state;
			parameters[3].Value = model.C_Voucher_applicationTime;
            parameters[4].Value = model.C_Voucher_applicationPerson;
			parameters[5].Value = model.C_Voucher_documentType;
			parameters[6].Value = model.C_Voucher_department;
			parameters[7].Value = model.C_Voucher_amounts;
            parameters[8].Value = model.C_Voucher_superiorAuditPerson;
            parameters[9].Value = model.C_Voucher_financeConfirmPerson;
			parameters[10].Value = model.C_Voucher_confirmTime;
			parameters[11].Value = model.C_Voucher_dismissedReasons;
			parameters[12].Value = model.C_Voucher_auditStatus;
			parameters[13].Value = model.C_Voucher_paymentMethod;
			parameters[14].Value = model.C_Voucher_isDelete;
            parameters[15].Value = model.C_Voucher_creator;
			parameters[16].Value = model.C_Voucher_createTime;
            parameters[17].Value = model.C_Voucher_region;
            parameters[18].Value = model.C_Voucher_type;
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
        public void UpdateState() {
            string sql = "update C_Voucher set C_Voucher_state=2 where C_Voucher_state=0 and exists(select 1 from C_Voucher_Form b where C_Voucher.C_Voucher_code=b.C_Voucher_code and exists(select 1 from F_FormPropertyValue where (F_FormPropertyValue_formProperty='0EACB483-D8EF-4141-A767-229DCD71F55A' or F_FormPropertyValue_formProperty='8A8A572F-66FC-4399-9DEB-C3107E085E3C') and F_FormPropertyValue_group=b.F_Form_code and F_FormPropertyValue_value='598'))";
            DbHelperSQL.ExecuteSql(sql);
           
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.FinanceManager.C_Voucher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Voucher set ");
			strSql.Append("C_Voucher_code=@C_Voucher_code,");
			strSql.Append("C_Voucher_number=@C_Voucher_number,");
			strSql.Append("C_Voucher_state=@C_Voucher_state,");
			strSql.Append("C_Voucher_applicationTime=@C_Voucher_applicationTime,");
			strSql.Append("C_Voucher_applicationPerson=@C_Voucher_applicationPerson,");
			strSql.Append("C_Voucher_documentType=@C_Voucher_documentType,");
			strSql.Append("C_Voucher_department=@C_Voucher_department,");
			strSql.Append("C_Voucher_amounts=@C_Voucher_amounts,");
			strSql.Append("C_Voucher_superiorAuditPerson=@C_Voucher_superiorAuditPerson,");
			strSql.Append("C_Voucher_financeConfirmPerson=@C_Voucher_financeConfirmPerson,");
			strSql.Append("C_Voucher_confirmTime=@C_Voucher_confirmTime,");
			strSql.Append("C_Voucher_dismissedReasons=@C_Voucher_dismissedReasons,");
			strSql.Append("C_Voucher_auditStatus=@C_Voucher_auditStatus,");
			strSql.Append("C_Voucher_paymentMethod=@C_Voucher_paymentMethod,");
			strSql.Append("C_Voucher_isDelete=@C_Voucher_isDelete,");
			strSql.Append("C_Voucher_creator=@C_Voucher_creator,");
			strSql.Append("C_Voucher_createTime=@C_Voucher_createTime,");
            strSql.Append("C_Voucher_region=@C_Voucher_region, ");
            strSql.Append("C_Voucher_type=@C_Voucher_type ");
			strSql.Append(" where C_Voucher_id=@C_Voucher_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_number", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Voucher_state", SqlDbType.Int,4),
					new SqlParameter("@C_Voucher_applicationTime", SqlDbType.DateTime),
					new SqlParameter("@C_Voucher_applicationPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_documentType", SqlDbType.Int,4),
					new SqlParameter("@C_Voucher_department", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_amounts", SqlDbType.Decimal,9),
					new SqlParameter("@C_Voucher_superiorAuditPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_financeConfirmPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_confirmTime", SqlDbType.DateTime),
					new SqlParameter("@C_Voucher_dismissedReasons", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Voucher_auditStatus", SqlDbType.Int,4),
					new SqlParameter("@C_Voucher_paymentMethod", SqlDbType.Int,4),
					new SqlParameter("@C_Voucher_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Voucher_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Voucher_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Voucher_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Voucher_region",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Voucher_type",SqlDbType.Int,4)                    };
			parameters[0].Value = model.C_Voucher_code;
			parameters[1].Value = model.C_Voucher_number;
			parameters[2].Value = model.C_Voucher_state;
			parameters[3].Value = model.C_Voucher_applicationTime;
			parameters[4].Value = model.C_Voucher_applicationPerson;
			parameters[5].Value = model.C_Voucher_documentType;
			parameters[6].Value = model.C_Voucher_department;
			parameters[7].Value = model.C_Voucher_amounts;
			parameters[8].Value = model.C_Voucher_superiorAuditPerson;
			parameters[9].Value = model.C_Voucher_financeConfirmPerson;
			parameters[10].Value = model.C_Voucher_confirmTime;
			parameters[11].Value = model.C_Voucher_dismissedReasons;
			parameters[12].Value = model.C_Voucher_auditStatus;
			parameters[13].Value = model.C_Voucher_paymentMethod;
			parameters[14].Value = model.C_Voucher_isDelete;
			parameters[15].Value = model.C_Voucher_creator;
			parameters[16].Value = model.C_Voucher_createTime;
			parameters[17].Value = model.C_Voucher_id;
            parameters[18].Value = model.C_Voucher_region;
            parameters[19].Value = model.C_Voucher_type;
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
		public bool Delete(Guid C_Voucher_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Voucher set C_Voucher_isDelete=1 ");
            strSql.Append(" where C_Voucher_code=@C_Voucher_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Voucher_code;

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
		public bool DeleteList(string C_Voucher_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Voucher ");
			strSql.Append(" where C_Voucher_id in ("+C_Voucher_idlist + ")  ");
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
        public CommonService.Model.FinanceManager.C_Voucher GetModel(int C_Voucher_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Voucher_id,C_Voucher_code,C_Voucher_number,C_Voucher_state,C_Voucher_applicationTime,C_Voucher_applicationPerson,C_Voucher_documentType,C_Voucher_department,C_Voucher_amounts,C_Voucher_superiorAuditPerson,C_Voucher_financeConfirmPerson,C_Voucher_confirmTime,C_Voucher_dismissedReasons,C_Voucher_auditStatus,C_Voucher_paymentMethod,C_Voucher_isDelete,C_Voucher_creator,C_Voucher_createTime,C_Voucher_region,C_Voucher_type from C_Voucher ");
            strSql.Append(" where C_Voucher_id=@C_Voucher_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Voucher_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Voucher_id;

            CommonService.Model.FinanceManager.C_Voucher model = new CommonService.Model.FinanceManager.C_Voucher();
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
        public CommonService.Model.FinanceManager.C_Voucher GetModel(Guid C_Voucher_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 V.*,R.C_Region_name as 'C_Voucher_regionName',Org.C_Organization_name as 'C_Voucher_departmentName' from C_Voucher as V ");
            strSql.Append("left join C_Region as R on R.C_Region_code=V.C_Voucher_region ");
            strSql.Append("left join C_Organization as Org on Org.C_Organization_code=V.C_Voucher_department ");
            strSql.Append(" where V.C_Voucher_code=@C_Voucher_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Voucher_code;

            CommonService.Model.FinanceManager.C_Voucher model = new CommonService.Model.FinanceManager.C_Voucher();
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
        /// 获取最新的一条数据
        /// </summary>
        public CommonService.Model.FinanceManager.C_Voucher GetNewestModel(Guid creatorCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Voucher_id,C_Voucher_code,C_Voucher_number,C_Voucher_state,C_Voucher_applicationTime,C_Voucher_applicationPerson,C_Voucher_documentType,C_Voucher_department,C_Voucher_amounts,C_Voucher_superiorAuditPerson,C_Voucher_financeConfirmPerson,C_Voucher_confirmTime,C_Voucher_dismissedReasons,C_Voucher_auditStatus,C_Voucher_paymentMethod,C_Voucher_isDelete,C_Voucher_creator,C_Voucher_createTime,C_Voucher_region,C_Voucher_type from C_Voucher ");
            strSql.Append(" where C_Voucher_isDelete=0 and C_Voucher_creator=@C_Voucher_creator order by C_Voucher_id desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Voucher_creator", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = creatorCode;
            CommonService.Model.FinanceManager.C_Voucher model = new CommonService.Model.FinanceManager.C_Voucher();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
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
        public CommonService.Model.FinanceManager.C_Voucher DataRowToModel(DataRow row)
		{
            CommonService.Model.FinanceManager.C_Voucher model = new CommonService.Model.FinanceManager.C_Voucher();
			if (row != null)
			{
				if(row["C_Voucher_id"]!=null && row["C_Voucher_id"].ToString()!="")
				{
					model.C_Voucher_id=int.Parse(row["C_Voucher_id"].ToString());
				}
				if(row["C_Voucher_code"]!=null && row["C_Voucher_code"].ToString()!="")
				{
					model.C_Voucher_code= new Guid(row["C_Voucher_code"].ToString());
				}
				if(row["C_Voucher_number"]!=null)
				{
					model.C_Voucher_number=row["C_Voucher_number"].ToString();
				}
				if(row["C_Voucher_state"]!=null && row["C_Voucher_state"].ToString()!="")
				{
                    model.C_Voucher_state = Convert.ToInt32(row["C_Voucher_state"].ToString());
				}
				if(row["C_Voucher_applicationTime"]!=null && row["C_Voucher_applicationTime"].ToString()!="")
				{
					model.C_Voucher_applicationTime=DateTime.Parse(row["C_Voucher_applicationTime"].ToString());
				}
				if(row["C_Voucher_applicationPerson"]!=null && row["C_Voucher_applicationPerson"].ToString()!="")
				{
					model.C_Voucher_applicationPerson= new Guid(row["C_Voucher_applicationPerson"].ToString());
				}
				if(row["C_Voucher_documentType"]!=null && row["C_Voucher_documentType"].ToString()!="")
				{
					model.C_Voucher_documentType=int.Parse(row["C_Voucher_documentType"].ToString());
				}
				if(row["C_Voucher_department"]!=null && row["C_Voucher_department"].ToString()!="")
				{
					model.C_Voucher_department= new Guid(row["C_Voucher_department"].ToString());
				}
				if(row["C_Voucher_amounts"]!=null && row["C_Voucher_amounts"].ToString()!="")
				{
					model.C_Voucher_amounts=decimal.Parse(row["C_Voucher_amounts"].ToString());
				}
				if(row["C_Voucher_superiorAuditPerson"]!=null && row["C_Voucher_superiorAuditPerson"].ToString()!="")
				{
					model.C_Voucher_superiorAuditPerson= new Guid(row["C_Voucher_superiorAuditPerson"].ToString());
				}
				if(row["C_Voucher_financeConfirmPerson"]!=null && row["C_Voucher_financeConfirmPerson"].ToString()!="")
				{
					model.C_Voucher_financeConfirmPerson= new Guid(row["C_Voucher_financeConfirmPerson"].ToString());
				}
				if(row["C_Voucher_confirmTime"]!=null && row["C_Voucher_confirmTime"].ToString()!="")
				{
					model.C_Voucher_confirmTime=DateTime.Parse(row["C_Voucher_confirmTime"].ToString());
				}
				if(row["C_Voucher_dismissedReasons"]!=null)
				{
					model.C_Voucher_dismissedReasons=row["C_Voucher_dismissedReasons"].ToString();
				}
				if(row["C_Voucher_auditStatus"]!=null && row["C_Voucher_auditStatus"].ToString()!="")
				{
					model.C_Voucher_auditStatus=int.Parse(row["C_Voucher_auditStatus"].ToString());
				}
				if(row["C_Voucher_paymentMethod"]!=null && row["C_Voucher_paymentMethod"].ToString()!="")
				{
					model.C_Voucher_paymentMethod=int.Parse(row["C_Voucher_paymentMethod"].ToString());
				}
				if(row["C_Voucher_isDelete"]!=null && row["C_Voucher_isDelete"].ToString()!="")
				{
					if((row["C_Voucher_isDelete"].ToString()=="1")||(row["C_Voucher_isDelete"].ToString().ToLower()=="true"))
					{
						model.C_Voucher_isDelete=true;
					}
					else
					{
						model.C_Voucher_isDelete=false;
					}
				}
				if(row["C_Voucher_creator"]!=null && row["C_Voucher_creator"].ToString()!="")
				{
					model.C_Voucher_creator= new Guid(row["C_Voucher_creator"].ToString());
				}
				if(row["C_Voucher_createTime"]!=null && row["C_Voucher_createTime"].ToString()!="")
				{
					model.C_Voucher_createTime=DateTime.Parse(row["C_Voucher_createTime"].ToString());
				}
                if (row["C_Voucher_region"] != null && row["C_Voucher_region"].ToString()!="")
                {
                    model.C_Voucher_region = new Guid(row["C_Voucher_region"].ToString());
                }
                if (row["C_Voucher_type"] != null && row["C_Voucher_type"].ToString() != "")
                {
                    model.C_Voucher_type = Convert.ToInt32(row["C_Voucher_type"].ToString());
                }
                if(row.Table.Columns.Contains("C_Voucher_applicationPersonName"))
                {
                    if(row["C_Voucher_applicationPersonName"]!=null && row["C_Voucher_applicationPersonName"].ToString()!="")
                    {
                        model.C_Voucher_applicationPersonName = row["C_Voucher_applicationPersonName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Voucher_departmentName"))
                {
                    if (row["C_Voucher_departmentName"] != null && row["C_Voucher_departmentName"].ToString() != "")
                    {
                        model.C_Voucher_departmentName = row["C_Voucher_departmentName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Voucher_financeConfirmPersonName"))
                {
                    if (row["C_Voucher_financeConfirmPersonName"] != null && row["C_Voucher_financeConfirmPersonName"].ToString() != "")
                    {
                        model.C_Voucher_financeConfirmPersonName = row["C_Voucher_financeConfirmPersonName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Voucher_regionName"))
                {
                    if (row["C_Voucher_regionName"] != null && row["C_Voucher_regionName"].ToString()!="")
                    {
                        model.C_Voucher_regionName = row["C_Voucher_regionName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Voucher_superiorAuditPersonName"))
                {
                    if (row["C_Voucher_superiorAuditPersonName"] != null && row["C_Voucher_superiorAuditPersonName"].ToString() != "")
                    {
                        model.C_Voucher_superiorAuditPersonName = row["C_Voucher_superiorAuditPersonName"].ToString();
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
            strSql.Append("select C_Voucher_id,C_Voucher_code,C_Voucher_number,C_Voucher_state,C_Voucher_applicationTime,C_Voucher_applicationPerson,C_Voucher_documentType,C_Voucher_department,C_Voucher_amounts,C_Voucher_superiorAuditPerson,C_Voucher_financeConfirmPerson,C_Voucher_confirmTime,C_Voucher_dismissedReasons,C_Voucher_auditStatus,C_Voucher_paymentMethod,C_Voucher_isDelete,C_Voucher_creator,C_Voucher_createTime,C_Voucher_region,C_Voucher_type ");
			strSql.Append(" FROM C_Voucher ");
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
            strSql.Append("select C_Voucher_id,C_Voucher_code,C_Voucher_number,C_Voucher_state,C_Voucher_applicationTime,C_Voucher_applicationPerson,C_Voucher_documentType,C_Voucher_department,C_Voucher_amounts,C_Voucher_superiorAuditPerson,C_Voucher_financeConfirmPerson,C_Voucher_confirmTime,C_Voucher_dismissedReasons,C_Voucher_auditStatus,C_Voucher_paymentMethod,C_Voucher_isDelete,C_Voucher_creator,C_Voucher_createTime,C_Voucher_region,C_Voucher_type ");
            strSql.Append(" FROM C_Voucher order by C_Voucher_id desc");
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
            strSql.Append(" C_Voucher_id,C_Voucher_code,C_Voucher_number,C_Voucher_state,C_Voucher_applicationTime,C_Voucher_applicationPerson,C_Voucher_documentType,C_Voucher_department,C_Voucher_amounts,C_Voucher_superiorAuditPerson,C_Voucher_financeConfirmPerson,C_Voucher_confirmTime,C_Voucher_dismissedReasons,C_Voucher_auditStatus,C_Voucher_paymentMethod,C_Voucher_isDelete,C_Voucher_creator,C_Voucher_createTime,C_Voucher_region,C_Voucher_type ");
			strSql.Append(" FROM C_Voucher ");
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
        public int GetRecordCount(CommonService.Model.FinanceManager.C_Voucher model, string rolePowerIds)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM C_Voucher as T ");
            strSql.Append(" where 1=1 and C_Voucher_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Voucher_code != null)
                {
                    strSql.Append("and C_Voucher_code=@C_Voucher_code ");
                }
                if (model.C_Voucher_applicationPerson != null)
                {
                    StringBuilder strPowerSql = new StringBuilder();
                    strPowerSql.Append(" and (1<>1 ");
                    if (rolePowerIds.Contains(",6,"))
                    {
                        strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region as OPUR with(nolock) ");
                        strPowerSql.Append("where OPUR.C_Organization_post_user_region_isDelete=0 ");
                        strPowerSql.Append("and OPUR.C_region_code=T.C_Voucher_region ");
                        strPowerSql.Append("and OPUR.C_User_code=@C_Voucher_applicationPerson) ");
                    }else
                    {
                        strPowerSql.Append("or T.C_Voucher_applicationPerson=@C_Voucher_applicationPerson ");
                    }
                    strPowerSql.Append(") ");
                    strSql.Append(strPowerSql.ToString());
                }
                if (model.C_Voucher_applicationPersonName != null)
                {
                    strSql.Append("and exists(select * from C_Userinfo as U2 where U2.C_Userinfo_code=T.C_Voucher_applicationPerson and U2.C_Userinfo_name like N'%'+@C_Voucher_applicationPersonName+'%') ");
                }
                if (model.C_Voucher_number != null)
                {
                    strSql.Append("and C_Voucher_number like N'%'+@C_Voucher_number+'%' ");
                }
                if (model.C_Voucher_applicationTime != null && model.C_Voucher_applicationTime1 != null)
                {
                    strSql.Append("and C_Voucher_applicationTime between convert(datetime,@C_Voucher_applicationTime,120) and convert(datetime,@C_Voucher_applicationTime1,120) ");
                }
                if (model.C_Voucher_amounts != null && model.C_Voucher_amounts1 != null)
                {
                    strSql.Append("and C_Voucher_amounts between @C_Voucher_amounts and @C_Voucher_amounts1 ");
                }
                if (model.C_Voucher_confirmTime != null && model.C_Voucher_confirmTime1 != null)
                {
                    strSql.Append("and C_Voucher_confirmTime  between convert(datetime,@C_Voucher_confirmTime,120) and convert(datetime,@C_Voucher_confirmTime1,120) ");
                }
                if (model.C_Voucher_type != null)
                {
                    strSql.Append("and C_Voucher_type=@C_Voucher_type ");
                }
                #region 按案号和案件名称查询
                StringBuilder sql = new StringBuilder();
                sql.Append(" and exists( ");
                sql.Append(" select 1 from ");
                sql.Append(" ( ");
                sql.Append(" select C_Voucher_code,B.B_Case_number,B.B_Case_name ");
                sql.Append(" from( ");
                sql.Append(" select VF.C_Voucher_code,FPV.F_FormPropertyValue_group as pGroup,FPV.F_FormPropertyValue_BusinessFlowFormCode As oForm ");
                sql.Append(" from C_Voucher_Form As VF with(nolock) ");
                sql.Append(" left join F_FormPropertyValue As FPV with(nolock) on VF.F_Form_code=FPV.F_FormPropertyValue_group ");
                sql.Append(" where FPV.F_FormPropertyValue_isDelete=0 ");
                sql.Append(" group by VF.C_Voucher_code,FPV.F_FormPropertyValue_group,FPV.F_FormPropertyValue_BusinessFlowFormCode ");
                sql.Append(" ) As a ");
                sql.Append(" left join O_Form As o with(nolock) on a.oForm=o.O_Form_code ");
                sql.Append(" left join P_Business_flow_form As PBF with(nolock) on o.O_Form_businessFlowform=PBF.P_Business_flow_form_code ");
                sql.Append(" left join P_Business_flow As PB with(nolock) on PBF.P_Business_flow_code=PB.P_Business_flow_code ");
                sql.Append(" left join B_Case As B with(nolock) on PB.P_Fk_code=B.B_Case_code ");
                sql.Append(" where o.O_Form_isDelete=0 and PBF.P_Business_flow_form_isdelete=0 and PB.P_Business_isdelete=0 and B.B_Case_isDelete=0 ");
                sql.Append(" ) As z ");
                sql.Append(" where z.C_Voucher_code=T.C_Voucher_code ");
                if (model.C_Voucher_CaseNumber != null && model.C_Voucher_CaseName == null)
                {
                    sql.Append(" and (z.B_Case_number like N'%'+@C_Voucher_CaseNumber+'%') ");
                    sql.Append(" ) ");
                    strSql.Append(sql);
                }
                if (model.C_Voucher_CaseName != null && model.C_Voucher_CaseNumber == null)
                {
                    sql.Append(" and (z.B_Case_name like N'%'+@C_Voucher_CaseName+'%') ");
                    sql.Append(" ) ");
                    strSql.Append(sql);
                }
                if (model.C_Voucher_CaseNumber != null && model.C_Voucher_CaseName != null)
                {
                    sql.Append(" and (z.B_Case_number like N'%'+@C_Voucher_CaseNumber+'%' and z.B_Case_name like N'%'+@C_Voucher_CaseName+'%') ");
                    sql.Append(" ) ");
                    strSql.Append(sql);
                }
                #endregion

                #region 借款或报销编号查询
                if (!String.IsNullOrEmpty(model.C_Voucher_FeeLoanOrFeeReimbursementNumber))
                {
                    StringBuilder feeLoanOrFeeReimbursementNumberSql = new StringBuilder();
                    feeLoanOrFeeReimbursementNumberSql.Append(" and exists(");
                    feeLoanOrFeeReimbursementNumberSql.Append("select 1 from C_Voucher_Form As VF with(nolock),F_FormPropertyValue As FPV with(nolock) ");
                    feeLoanOrFeeReimbursementNumberSql.Append("where VF.F_Form_code=FPV.F_FormPropertyValue_group and VF.C_Voucher_code=T.C_Voucher_code and FPV.F_FormPropertyValue_isDelete=0 ");
                    feeLoanOrFeeReimbursementNumberSql.Append("and FPV.F_FormPropertyValue_value like N'%'+@C_Voucher_FeeLoanOrFeeReimbursementNumber+'%') ");

                    strSql.Append(feeLoanOrFeeReimbursementNumberSql);
                }

                #endregion 
            }
            SqlParameter[] parameters = {					
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Voucher_applicationPersonName",SqlDbType.VarChar),
                    new SqlParameter("@C_Voucher_number",SqlDbType.VarChar),
                    new SqlParameter("@C_Voucher_applicationTime",SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_applicationTime1",SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_amounts",SqlDbType.Decimal),
                    new SqlParameter("@C_Voucher_amounts1",SqlDbType.Decimal),
                    new SqlParameter("@C_Voucher_confirmTime",SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_confirmTime1",SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_applicationPerson",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Voucher_type",SqlDbType.Int,4),
                    new SqlParameter("@C_Voucher_CaseNumber",SqlDbType.VarChar),
                    new SqlParameter("@C_Voucher_CaseName",SqlDbType.VarChar),
                    new SqlParameter("@C_Voucher_FeeLoanOrFeeReimbursementNumber",SqlDbType.VarChar)
            };
            parameters[0].Value = model.C_Voucher_code;
            parameters[1].Value = model.C_Voucher_applicationPersonName;
            parameters[2].Value = model.C_Voucher_number;
            parameters[3].Value = model.C_Voucher_applicationTime;
            parameters[4].Value = model.C_Voucher_applicationTime1;
            parameters[5].Value = model.C_Voucher_amounts;
            parameters[6].Value = model.C_Voucher_amounts1;
            parameters[7].Value = model.C_Voucher_confirmTime;
            parameters[8].Value = model.C_Voucher_confirmTime1;
            parameters[9].Value = model.C_Voucher_applicationPerson;
            parameters[10].Value = model.C_Voucher_type;
            parameters[11].Value = model.C_Voucher_CaseNumber;
            parameters[12].Value = model.C_Voucher_CaseName;
            parameters[13].Value = model.C_Voucher_FeeLoanOrFeeReimbursementNumber;
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
		public DataSet GetListByPage(CommonService.Model.FinanceManager.C_Voucher model,string rolePowerIds, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Voucher_id desc");
			}
            strSql.Append(")AS Row, T.*,U.C_Userinfo_name as 'C_Voucher_applicationPersonName',Org.C_Organization_name as 'C_Voucher_departmentName',U1.C_Userinfo_name as 'C_Voucher_financeConfirmPersonName',U2.C_Userinfo_name as 'C_Voucher_superiorAuditPersonName' ");
            strSql.Append("from C_Voucher T left join C_Userinfo as U on T.C_Voucher_applicationPerson=U.C_Userinfo_code ");
            strSql.Append("left join C_Organization as Org on T.C_Voucher_department=Org.C_Organization_code ");
            strSql.Append("left join C_Userinfo as U1 on T.C_Voucher_financeConfirmPerson=U1.C_Userinfo_code ");
            strSql.Append("left join C_Userinfo as U2 on T.C_Voucher_superiorAuditPerson=U2.C_Userinfo_code ");
            strSql.Append(" where 1=1 and C_Voucher_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Voucher_code != null)
                {
                    strSql.Append("and C_Voucher_code=@C_Voucher_code ");
                }
                if(model.C_Voucher_applicationPerson!=null)
                {
                    StringBuilder strPowerSql = new StringBuilder();
                    strPowerSql.Append(" and (1<>1 ");
                    if (rolePowerIds.Contains(",6,"))
                    {
                        strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region as OPUR with(nolock) ");
                        strPowerSql.Append("where OPUR.C_Organization_post_user_region_isDelete=0 ");
                        strPowerSql.Append("and OPUR.C_region_code=T.C_Voucher_region ");
                        strPowerSql.Append("and OPUR.C_User_code=@C_Voucher_applicationPerson) ");
                    }
                    else
                    {
                        strPowerSql.Append("or T.C_Voucher_applicationPerson=@C_Voucher_applicationPerson ");
                    }
                    strPowerSql.Append(") ");
                    strSql.Append(strPowerSql.ToString());
                }
                if (model.C_Voucher_applicationPersonName != null)
                {
                    strSql.Append("and exists(select * from C_Userinfo as U2 where U2.C_Userinfo_code=T.C_Voucher_applicationPerson and U2.C_Userinfo_name like N'%'+@C_Voucher_applicationPersonName+'%') ");
                }
                if(model.C_Voucher_number!=null)
                {
                    strSql.Append("and C_Voucher_number like N'%'+@C_Voucher_number+'%' ");
                }
                if(model.C_Voucher_applicationTime!=null && model.C_Voucher_applicationTime1!=null)
                {
                    strSql.Append("and C_Voucher_applicationTime between convert(datetime,@C_Voucher_applicationTime,120) and convert(datetime,@C_Voucher_applicationTime1,120) ");
                }
                if(model.C_Voucher_amounts!=null && model.C_Voucher_amounts1!=null)
                {
                    strSql.Append("and C_Voucher_amounts between @C_Voucher_amounts and @C_Voucher_amounts1 ");
                }
                if(model.C_Voucher_confirmTime!=null && model.C_Voucher_confirmTime1!=null)
                {
                    strSql.Append("and C_Voucher_confirmTime  between convert(datetime,@C_Voucher_confirmTime,120) and convert(datetime,@C_Voucher_confirmTime1,120) ");
                }
                if (model.C_Voucher_type != null)
                {
                    strSql.Append("and C_Voucher_type=@C_Voucher_type ");
                }

                #region 按案号和案件名称查询
                StringBuilder sql = new StringBuilder();
                sql.Append(" and exists( ");
                sql.Append(" select 1 from ");
                sql.Append(" ( ");
                sql.Append(" select C_Voucher_code,B.B_Case_number,B.B_Case_name "); 
                sql.Append(" from( ");
                sql.Append(" select VF.C_Voucher_code,FPV.F_FormPropertyValue_group as pGroup,FPV.F_FormPropertyValue_BusinessFlowFormCode As oForm ");
                sql.Append(" from C_Voucher_Form As VF with(nolock) ");
                sql.Append(" left join F_FormPropertyValue As FPV with(nolock) on VF.F_Form_code=FPV.F_FormPropertyValue_group ");
                sql.Append(" where FPV.F_FormPropertyValue_isDelete=0 ");
                sql.Append(" group by VF.C_Voucher_code,FPV.F_FormPropertyValue_group,FPV.F_FormPropertyValue_BusinessFlowFormCode ");
                sql.Append(" ) As a ");
                sql.Append(" left join O_Form As o with(nolock) on a.oForm=o.O_Form_code ");
                sql.Append(" left join P_Business_flow_form As PBF with(nolock) on o.O_Form_businessFlowform=PBF.P_Business_flow_form_code ");  
                sql.Append(" left join P_Business_flow As PB with(nolock) on PBF.P_Business_flow_code=PB.P_Business_flow_code ");
                sql.Append(" left join B_Case As B with(nolock) on PB.P_Fk_code=B.B_Case_code ");
                sql.Append(" where o.O_Form_isDelete=0 and PBF.P_Business_flow_form_isdelete=0 and PB.P_Business_isdelete=0 and B.B_Case_isDelete=0 ");
                sql.Append(" ) As z ");
                sql.Append(" where z.C_Voucher_code=T.C_Voucher_code ");
                if(model.C_Voucher_CaseNumber!=null && model.C_Voucher_CaseName==null)
                {
                    sql.Append(" and (z.B_Case_number like N'%'+@C_Voucher_CaseNumber+'%') ");
                    sql.Append(" ) ");
                    strSql.Append(sql);
                }
                if(model.C_Voucher_CaseName!=null && model.C_Voucher_CaseNumber==null)
                {
                    sql.Append(" and (z.B_Case_name like N'%'+@C_Voucher_CaseName+'%') ");
                    sql.Append(" ) ");
                    strSql.Append(sql);
                }
                if(model.C_Voucher_CaseNumber!=null && model.C_Voucher_CaseName!=null)
                {
                    sql.Append(" and (z.B_Case_number like N'%'+@C_Voucher_CaseNumber+'%' and z.B_Case_name like N'%'+@C_Voucher_CaseName+'%') ");
                    sql.Append(" ) ");
                    strSql.Append(sql);
                }
                #endregion

                #region 借款或报销编号查询
                if (!String.IsNullOrEmpty(model.C_Voucher_FeeLoanOrFeeReimbursementNumber))
                {
                    StringBuilder feeLoanOrFeeReimbursementNumberSql = new StringBuilder();
                    feeLoanOrFeeReimbursementNumberSql.Append(" and exists(");
                    feeLoanOrFeeReimbursementNumberSql.Append("select 1 from C_Voucher_Form As VF with(nolock),F_FormPropertyValue As FPV with(nolock) ");
                    feeLoanOrFeeReimbursementNumberSql.Append("where VF.F_Form_code=FPV.F_FormPropertyValue_group and VF.C_Voucher_code=T.C_Voucher_code and FPV.F_FormPropertyValue_isDelete=0 ");
                    feeLoanOrFeeReimbursementNumberSql.Append("and FPV.F_FormPropertyValue_value like N'%'+@C_Voucher_FeeLoanOrFeeReimbursementNumber+'%') ");

                    strSql.Append(feeLoanOrFeeReimbursementNumberSql);
                }
                #endregion
            }  
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					
					new SqlParameter("@C_Voucher_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Voucher_applicationPersonName",SqlDbType.VarChar),
                    new SqlParameter("@C_Voucher_number",SqlDbType.VarChar),
                    new SqlParameter("@C_Voucher_applicationTime",SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_applicationTime1",SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_amounts",SqlDbType.Decimal),
                    new SqlParameter("@C_Voucher_amounts1",SqlDbType.Decimal),
                    new SqlParameter("@C_Voucher_confirmTime",SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_confirmTime1",SqlDbType.DateTime),
                    new SqlParameter("@C_Voucher_applicationPerson",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Voucher_type",SqlDbType.Int,4),
                    new SqlParameter("@C_Voucher_CaseNumber",SqlDbType.VarChar),
                    new SqlParameter("@C_Voucher_CaseName",SqlDbType.VarChar),
                    new SqlParameter("@C_Voucher_FeeLoanOrFeeReimbursementNumber",SqlDbType.VarChar)
            };
            parameters[0].Value = model.C_Voucher_code;
            parameters[1].Value = model.C_Voucher_applicationPersonName;
            parameters[2].Value = model.C_Voucher_number;
            parameters[3].Value = model.C_Voucher_applicationTime;
            parameters[4].Value = model.C_Voucher_applicationTime1;
            parameters[5].Value = model.C_Voucher_amounts;
            parameters[6].Value = model.C_Voucher_amounts1;
            parameters[7].Value = model.C_Voucher_confirmTime;
            parameters[8].Value = model.C_Voucher_confirmTime1;
            parameters[9].Value = model.C_Voucher_applicationPerson;
            parameters[10].Value = model.C_Voucher_type;
            parameters[11].Value = model.C_Voucher_CaseNumber;
            parameters[12].Value = model.C_Voucher_CaseName;
            parameters[13].Value = model.C_Voucher_FeeLoanOrFeeReimbursementNumber;
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
			parameters[0].Value = "C_Voucher";
			parameters[1].Value = "C_Voucher_id";
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

