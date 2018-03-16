using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:客户变更记录表
    /// 作者：崔慧栋
    /// 日期：2015/11/24
    /// </summary>
	public partial class C_Customer_ChangHistory
	{
		public C_Customer_ChangHistory()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("C_Customer_ChangHistory_id", "C_Customer_ChangHistory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int C_Customer_ChangHistory_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Customer_ChangHistory");
			strSql.Append(" where C_Customer_ChangHistory_id=@C_Customer_ChangHistory_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Customer_ChangHistory_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Customer_ChangHistory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Customer_ChangHistory(");
            strSql.Append("C_Customer_ChangHistory_code,C_Customer_ChangHistory_customer,C_Customer_ChangHistory_field,C_Customer_ChangHistory_fieldName,C_Customer_ChangHistory_oldValue,C_Customer_ChangHistory_newValue,C_Customer_ChangHistory_submitPerson,C_Customer_ChangHistory_submitDate,C_Customer_ChangHistory_checkPerson,C_Customer_ChangHistory_checkDate,C_Customer_ChangHistory_state,C_Customer_ChangHistory_isDelete,C_Customer_ChangHistory_creator,C_Customer_ChangHistory_createTime,C_Customer_ChangHistory_oldLdentification,C_Customer_ChangHistory_newLdentification,C_Customer_ChangHistory_type)");
			strSql.Append(" values (");
            strSql.Append("@C_Customer_ChangHistory_code,@C_Customer_ChangHistory_customer,@C_Customer_ChangHistory_field,@C_Customer_ChangHistory_fieldName,@C_Customer_ChangHistory_oldValue,@C_Customer_ChangHistory_newValue,@C_Customer_ChangHistory_submitPerson,@C_Customer_ChangHistory_submitDate,@C_Customer_ChangHistory_checkPerson,@C_Customer_ChangHistory_checkDate,@C_Customer_ChangHistory_state,@C_Customer_ChangHistory_isDelete,@C_Customer_ChangHistory_creator,@C_Customer_ChangHistory_createTime,@C_Customer_ChangHistory_oldLdentification,@C_Customer_ChangHistory_newLdentification,@C_Customer_ChangHistory_type)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_field", SqlDbType.VarChar,50),
					new SqlParameter("@C_Customer_ChangHistory_fieldName", SqlDbType.VarChar,50),
					new SqlParameter("@C_Customer_ChangHistory_oldValue", SqlDbType.VarChar,500),
					new SqlParameter("@C_Customer_ChangHistory_newValue", SqlDbType.VarChar,500),
					new SqlParameter("@C_Customer_ChangHistory_submitPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_submitDate", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_ChangHistory_checkPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_checkDate", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_ChangHistory_state", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_ChangHistory_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Customer_ChangHistory_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_createTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_ChangHistory_oldLdentification",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_ChangHistory_newLdentification",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_ChangHistory_type",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.C_Customer_ChangHistory_code;
            parameters[1].Value = model.C_Customer_ChangHistory_customer;
            parameters[2].Value = model.C_Customer_ChangHistory_field;
			parameters[3].Value = model.C_Customer_ChangHistory_fieldName;
			parameters[4].Value = model.C_Customer_ChangHistory_oldValue;
			parameters[5].Value = model.C_Customer_ChangHistory_newValue;
            parameters[6].Value = model.C_Customer_ChangHistory_submitPerson;
			parameters[7].Value = model.C_Customer_ChangHistory_submitDate;
            parameters[8].Value = model.C_Customer_ChangHistory_checkPerson;
			parameters[9].Value = model.C_Customer_ChangHistory_checkDate;
			parameters[10].Value = model.C_Customer_ChangHistory_state;
			parameters[11].Value = model.C_Customer_ChangHistory_isDelete;
            parameters[12].Value = model.C_Customer_ChangHistory_creator;
			parameters[13].Value = model.C_Customer_ChangHistory_createTime;
            parameters[14].Value = model.C_Customer_ChangHistory_oldLdentification;
            parameters[15].Value = model.C_Customer_ChangHistory_newLdentification;
            parameters[16].Value = model.C_Customer_ChangHistory_type;

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
        public bool Update(CommonService.Model.C_Customer_ChangHistory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Customer_ChangHistory set ");
			strSql.Append("C_Customer_ChangHistory_code=@C_Customer_ChangHistory_code,");
			strSql.Append("C_Customer_ChangHistory_customer=@C_Customer_ChangHistory_customer,");
			strSql.Append("C_Customer_ChangHistory_field=@C_Customer_ChangHistory_field,");
			strSql.Append("C_Customer_ChangHistory_fieldName=@C_Customer_ChangHistory_fieldName,");
			strSql.Append("C_Customer_ChangHistory_oldValue=@C_Customer_ChangHistory_oldValue,");
			strSql.Append("C_Customer_ChangHistory_newValue=@C_Customer_ChangHistory_newValue,");
			strSql.Append("C_Customer_ChangHistory_submitPerson=@C_Customer_ChangHistory_submitPerson,");
			strSql.Append("C_Customer_ChangHistory_submitDate=@C_Customer_ChangHistory_submitDate,");
			strSql.Append("C_Customer_ChangHistory_checkPerson=@C_Customer_ChangHistory_checkPerson,");
			strSql.Append("C_Customer_ChangHistory_checkDate=@C_Customer_ChangHistory_checkDate,");
			strSql.Append("C_Customer_ChangHistory_state=@C_Customer_ChangHistory_state,");
			strSql.Append("C_Customer_ChangHistory_isDelete=@C_Customer_ChangHistory_isDelete,");
			strSql.Append("C_Customer_ChangHistory_creator=@C_Customer_ChangHistory_creator,");
			strSql.Append("C_Customer_ChangHistory_createTime=@C_Customer_ChangHistory_createTime,");
            strSql.Append("C_Customer_ChangHistory_oldLdentification=@C_Customer_ChangHistory_oldLdentification,");
            strSql.Append("C_Customer_ChangHistory_newLdentification=@C_Customer_ChangHistory_newLdentification,");
            strSql.Append("C_Customer_ChangHistory_type=@C_Customer_ChangHistory_type ");
			strSql.Append(" where C_Customer_ChangHistory_id=@C_Customer_ChangHistory_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_field", SqlDbType.VarChar,50),
					new SqlParameter("@C_Customer_ChangHistory_fieldName", SqlDbType.VarChar,50),
					new SqlParameter("@C_Customer_ChangHistory_oldValue", SqlDbType.VarChar,500),
					new SqlParameter("@C_Customer_ChangHistory_newValue", SqlDbType.VarChar,500),
					new SqlParameter("@C_Customer_ChangHistory_submitPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_submitDate", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_ChangHistory_checkPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_checkDate", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_ChangHistory_state", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_ChangHistory_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Customer_ChangHistory_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_ChangHistory_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_ChangHistory_oldLdentification",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_ChangHistory_newLdentification",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_ChangHistory_type",SqlDbType.Int,4)
                                        };
			parameters[0].Value = model.C_Customer_ChangHistory_code;
			parameters[1].Value = model.C_Customer_ChangHistory_customer;
			parameters[2].Value = model.C_Customer_ChangHistory_field;
			parameters[3].Value = model.C_Customer_ChangHistory_fieldName;
			parameters[4].Value = model.C_Customer_ChangHistory_oldValue;
			parameters[5].Value = model.C_Customer_ChangHistory_newValue;
			parameters[6].Value = model.C_Customer_ChangHistory_submitPerson;
			parameters[7].Value = model.C_Customer_ChangHistory_submitDate;
			parameters[8].Value = model.C_Customer_ChangHistory_checkPerson;
			parameters[9].Value = model.C_Customer_ChangHistory_checkDate;
			parameters[10].Value = model.C_Customer_ChangHistory_state;
			parameters[11].Value = model.C_Customer_ChangHistory_isDelete;
			parameters[12].Value = model.C_Customer_ChangHistory_creator;
			parameters[13].Value = model.C_Customer_ChangHistory_createTime;
			parameters[14].Value = model.C_Customer_ChangHistory_id;
            parameters[15].Value = model.C_Customer_ChangHistory_oldLdentification;
            parameters[16].Value = model.C_Customer_ChangHistory_newLdentification;
            parameters[17].Value = model.C_Customer_ChangHistory_type;

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
		public bool Delete(int C_Customer_ChangHistory_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Customer_ChangHistory set C_Customer_ChangHistory_isDelete=1 ");
			strSql.Append(" where C_Customer_ChangHistory_id=@C_Customer_ChangHistory_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Customer_ChangHistory_id;

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
        public bool Delete(Guid C_Customer_ChangHistory_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer_ChangHistory set C_Customer_ChangHistory_isDelete=1 ");
            strSql.Append(" where C_Customer_ChangHistory_code=@C_Customer_ChangHistory_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Customer_ChangHistory_code;

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
        /// 审核操作
        /// </summary>
        /// <param name="CustomerChangHistoryCode">变更Guid</param>
        /// <param name="stateId">审核状态</param>
        /// <returns></returns>
        public bool CheckOpreate(Guid CustomerChangHistoryCode, int? stateId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer_ChangHistory set C_Customer_ChangHistory_state=@C_Customer_ChangHistory_state ");
            strSql.Append(" where C_Customer_ChangHistory_code=@C_Customer_ChangHistory_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_ChangHistory_state",SqlDbType.Int,4)
			};
            parameters[0].Value = CustomerChangHistoryCode;
            parameters[1].Value = stateId;

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
		public bool DeleteList(string C_Customer_ChangHistory_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Customer_ChangHistory ");
			strSql.Append(" where C_Customer_ChangHistory_id in ("+C_Customer_ChangHistory_idlist + ")  ");
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
        public CommonService.Model.C_Customer_ChangHistory GetModel(int C_Customer_ChangHistory_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 C_Customer_ChangHistory_id,C_Customer_ChangHistory_code,C_Customer_ChangHistory_customer,C_Customer_ChangHistory_field,C_Customer_ChangHistory_fieldName,C_Customer_ChangHistory_oldValue,C_Customer_ChangHistory_newValue,C_Customer_ChangHistory_submitPerson,C_Customer_ChangHistory_submitDate,C_Customer_ChangHistory_checkPerson,C_Customer_ChangHistory_checkDate,C_Customer_ChangHistory_state,C_Customer_ChangHistory_isDelete,C_Customer_ChangHistory_creator,C_Customer_ChangHistory_createTime,C_Customer_ChangHistory_oldLdentification,C_Customer_ChangHistory_newLdentification,C_Customer_ChangHistory_type from C_Customer_ChangHistory ");
			strSql.Append(" where C_Customer_ChangHistory_id=@C_Customer_ChangHistory_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Customer_ChangHistory_id;

            CommonService.Model.C_Customer_ChangHistory model = new CommonService.Model.C_Customer_ChangHistory();
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
        /// 根据Guid得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Customer_ChangHistory GetModelByCode(Guid C_Customer_ChangHistory_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Customer_ChangHistory_id,C_Customer_ChangHistory_code,C_Customer_ChangHistory_customer,C_Customer_ChangHistory_field,C_Customer_ChangHistory_fieldName,C_Customer_ChangHistory_oldValue,C_Customer_ChangHistory_newValue,C_Customer_ChangHistory_submitPerson,C_Customer_ChangHistory_submitDate,C_Customer_ChangHistory_checkPerson,C_Customer_ChangHistory_checkDate,C_Customer_ChangHistory_state,C_Customer_ChangHistory_isDelete,C_Customer_ChangHistory_creator,C_Customer_ChangHistory_createTime,C_Customer_ChangHistory_oldLdentification,C_Customer_ChangHistory_newLdentification,C_Customer_ChangHistory_type from C_Customer_ChangHistory ");
            strSql.Append(" where C_Customer_ChangHistory_code=@C_Customer_ChangHistory_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Customer_ChangHistory_code;

            CommonService.Model.C_Customer_ChangHistory model = new CommonService.Model.C_Customer_ChangHistory();
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
        public CommonService.Model.C_Customer_ChangHistory DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Customer_ChangHistory model = new CommonService.Model.C_Customer_ChangHistory();
			if (row != null)
			{
				if(row["C_Customer_ChangHistory_id"]!=null && row["C_Customer_ChangHistory_id"].ToString()!="")
				{
					model.C_Customer_ChangHistory_id=int.Parse(row["C_Customer_ChangHistory_id"].ToString());
				}
				if(row["C_Customer_ChangHistory_code"]!=null && row["C_Customer_ChangHistory_code"].ToString()!="")
				{
					model.C_Customer_ChangHistory_code= new Guid(row["C_Customer_ChangHistory_code"].ToString());
				}
				if(row["C_Customer_ChangHistory_customer"]!=null && row["C_Customer_ChangHistory_customer"].ToString()!="")
				{
					model.C_Customer_ChangHistory_customer= new Guid(row["C_Customer_ChangHistory_customer"].ToString());
				}
				if(row["C_Customer_ChangHistory_field"]!=null && row["C_Customer_ChangHistory_field"].ToString()!="")
				{
					model.C_Customer_ChangHistory_field= row["C_Customer_ChangHistory_field"].ToString();
				}
				if(row["C_Customer_ChangHistory_fieldName"]!=null)
				{
					model.C_Customer_ChangHistory_fieldName=row["C_Customer_ChangHistory_fieldName"].ToString();
				}
				if(row["C_Customer_ChangHistory_oldValue"]!=null)
				{
					model.C_Customer_ChangHistory_oldValue=row["C_Customer_ChangHistory_oldValue"].ToString();
				}
                if (row["C_Customer_ChangHistory_oldLdentification"] != null)
                {
                    model.C_Customer_ChangHistory_oldLdentification = row["C_Customer_ChangHistory_oldLdentification"].ToString();
                }
				if(row["C_Customer_ChangHistory_newValue"]!=null)
				{
					model.C_Customer_ChangHistory_newValue=row["C_Customer_ChangHistory_newValue"].ToString();
				}
                if (row["C_Customer_ChangHistory_newLdentification"] != null)
                {
                    model.C_Customer_ChangHistory_newLdentification = row["C_Customer_ChangHistory_newLdentification"].ToString();
                }
				if(row["C_Customer_ChangHistory_submitPerson"]!=null && row["C_Customer_ChangHistory_submitPerson"].ToString()!="")
				{
					model.C_Customer_ChangHistory_submitPerson= new Guid(row["C_Customer_ChangHistory_submitPerson"].ToString());
				}
				if(row["C_Customer_ChangHistory_submitDate"]!=null && row["C_Customer_ChangHistory_submitDate"].ToString()!="")
				{
					model.C_Customer_ChangHistory_submitDate=DateTime.Parse(row["C_Customer_ChangHistory_submitDate"].ToString());
				}
				if(row["C_Customer_ChangHistory_checkPerson"]!=null && row["C_Customer_ChangHistory_checkPerson"].ToString()!="")
				{
					model.C_Customer_ChangHistory_checkPerson= new Guid(row["C_Customer_ChangHistory_checkPerson"].ToString());
				}
				if(row["C_Customer_ChangHistory_checkDate"]!=null && row["C_Customer_ChangHistory_checkDate"].ToString()!="")
				{
					model.C_Customer_ChangHistory_checkDate=DateTime.Parse(row["C_Customer_ChangHistory_checkDate"].ToString());
				}
				if(row["C_Customer_ChangHistory_state"]!=null && row["C_Customer_ChangHistory_state"].ToString()!="")
				{
					model.C_Customer_ChangHistory_state=int.Parse(row["C_Customer_ChangHistory_state"].ToString());
				}
				if(row["C_Customer_ChangHistory_isDelete"]!=null && row["C_Customer_ChangHistory_isDelete"].ToString()!="")
				{
					if((row["C_Customer_ChangHistory_isDelete"].ToString()=="1")||(row["C_Customer_ChangHistory_isDelete"].ToString().ToLower()=="true"))
					{
						model.C_Customer_ChangHistory_isDelete=true;
					}
					else
					{
						model.C_Customer_ChangHistory_isDelete=false;
					}
				}
				if(row["C_Customer_ChangHistory_creator"]!=null && row["C_Customer_ChangHistory_creator"].ToString()!="")
				{
					model.C_Customer_ChangHistory_creator= new Guid(row["C_Customer_ChangHistory_creator"].ToString());
				}
				if(row["C_Customer_ChangHistory_createTime"]!=null && row["C_Customer_ChangHistory_createTime"].ToString()!="")
				{
					model.C_Customer_ChangHistory_createTime=DateTime.Parse(row["C_Customer_ChangHistory_createTime"].ToString());
				}
                if (row.Table.Columns.Contains("C_Customer_ChangHistory_customerName"))
                {
                    if (row["C_Customer_ChangHistory_customerName"] != null && row["C_Customer_ChangHistory_customerName"].ToString() != "")
                    {
                        model.C_Customer_ChangHistory_customerName = row["C_Customer_ChangHistory_customerName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_ChangHistory_stateName"))
                {
                    if (row["C_Customer_ChangHistory_stateName"] != null && row["C_Customer_ChangHistory_stateName"].ToString() != "")
                    {
                        model.C_Customer_ChangHistory_stateName = row["C_Customer_ChangHistory_stateName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_ChangHistory_submitpersonName"))
                {
                    if (row["C_Customer_ChangHistory_submitpersonName"] != null && row["C_Customer_ChangHistory_submitpersonName"].ToString() != "")
                    {
                        model.C_Customer_ChangHistory_submitpersonName = row["C_Customer_ChangHistory_submitpersonName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_ChangHistory_checkpersonName"))
                {
                    if (row["C_Customer_ChangHistory_checkpersonName"] != null && row["C_Customer_ChangHistory_checkpersonName"].ToString() != "")
                    {
                        model.C_Customer_ChangHistory_checkpersonName = row["C_Customer_ChangHistory_checkpersonName"].ToString();
                    }
                }
                if(row["C_Customer_ChangHistory_type"]!=null && row["C_Customer_ChangHistory_type"].ToString()!="")
                {
                    model.C_Customer_ChangHistory_type = Convert.ToInt32(row["C_Customer_ChangHistory_type"].ToString());
                }
                if (row.Table.Columns.Contains("C_Customer_changhistory_typeName"))
                {
                    if (row["C_Customer_changhistory_typeName"] != null && row["C_Customer_changhistory_typeName"].ToString() != "")
                    {
                        model.C_Customer_changhistory_typeName = row["C_Customer_changhistory_typeName"].ToString();
                    }
                }
			}
			return model;
		}

        /// <summary>
        /// 根据客户Guid获得数据列表
        /// </summary>
        public DataSet GetListByCustomer(Guid C_Customer_ChangHistory_customer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.C_Customer_ChangHistory_id,T.C_Customer_ChangHistory_code,T.C_Customer_ChangHistory_customer,T.C_Customer_ChangHistory_field,T.C_Customer_ChangHistory_fieldName,T.C_Customer_ChangHistory_oldValue,T.C_Customer_ChangHistory_newValue,T.C_Customer_ChangHistory_submitPerson,T.C_Customer_ChangHistory_submitDate,T.C_Customer_ChangHistory_checkPerson,T.C_Customer_ChangHistory_checkDate,T.C_Customer_ChangHistory_state,T.C_Customer_ChangHistory_isDelete,T.C_Customer_ChangHistory_creator,T.C_Customer_ChangHistory_createTime,T.C_Customer_ChangHistory_oldLdentification,T.C_Customer_ChangHistory_newLdentification,T.C_Customer_ChangHistory_type ");
            strSql.Append(",C.C_Customer_name as 'C_Customer_ChangHistory_customerName',P.C_Parameters_name as 'C_Customer_ChangHistory_stateName',U1.C_Userinfo_name as 'C_Customer_ChangHistory_submitpersonName',U2.C_Userinfo_name as 'C_Customer_ChangHistory_checkpersonName' ");
            strSql.Append(" FROM C_Customer_ChangHistory as T ");
            strSql.Append(" left join C_Customer as C on T.C_Customer_ChangHistory_customer = C.C_Customer_code ");
            strSql.Append(" left join C_Parameters as P on T.C_Customer_ChangHistory_state = P.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U1 on T.C_Customer_ChangHistory_submitPerson = U1.C_Userinfo_code ");
            strSql.Append(" left join C_Userinfo as U2 on T.C_Customer_ChangHistory_checkPerson = U2.C_Userinfo_code ");
            strSql.Append(" where C_Customer_ChangHistory_isDelete=0 ");
            strSql.Append(" and C_Customer_ChangHistory_customer=@C_Customer_ChangHistory_customer ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_ChangHistory_customer", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Customer_ChangHistory_customer;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select C_Customer_ChangHistory_id,C_Customer_ChangHistory_code,C_Customer_ChangHistory_customer,C_Customer_ChangHistory_field,C_Customer_ChangHistory_fieldName,C_Customer_ChangHistory_oldValue,C_Customer_ChangHistory_newValue,C_Customer_ChangHistory_submitPerson,C_Customer_ChangHistory_submitDate,C_Customer_ChangHistory_checkPerson,C_Customer_ChangHistory_checkDate,C_Customer_ChangHistory_state,C_Customer_ChangHistory_isDelete,C_Customer_ChangHistory_creator,C_Customer_ChangHistory_createTime,C_Customer_ChangHistory_oldLdentification,C_Customer_ChangHistory_newLdentification,C_Customer_ChangHistory_type ");
			strSql.Append(" FROM C_Customer_ChangHistory ");
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
            strSql.Append(" C_Customer_ChangHistory_id,C_Customer_ChangHistory_code,C_Customer_ChangHistory_customer,C_Customer_ChangHistory_field,C_Customer_ChangHistory_fieldName,C_Customer_ChangHistory_oldValue,C_Customer_ChangHistory_newValue,C_Customer_ChangHistory_submitPerson,C_Customer_ChangHistory_submitDate,C_Customer_ChangHistory_checkPerson,C_Customer_ChangHistory_checkDate,C_Customer_ChangHistory_state,C_Customer_ChangHistory_isDelete,C_Customer_ChangHistory_creator,C_Customer_ChangHistory_createTime,C_Customer_ChangHistory_oldLdentification,C_Customer_ChangHistory_newLdentification,C_Customer_ChangHistory_type ");
			strSql.Append(" FROM C_Customer_ChangHistory ");
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
		public int GetRecordCount(CommonService.Model.C_Customer_ChangHistory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Customer_ChangHistory ");
            strSql.Append(" where 1=1 and C_Customer_ChangHistory_isDelete=0 ");
            if (model != null)
			{
                if (model.C_Customer_ChangHistory_submitPerson != null && model.C_Customer_ChangHistory_submitPerson.ToString() != "")
                {
                    strSql.Append(" and C_Customer_ChangHistory_submitPerson=@C_Customer_ChangHistory_submitPerson ");
                }
				if(model.C_Customer_ChangHistory_checkPerson!=null && model.C_Customer_ChangHistory_checkPerson.ToString()!="")
                {
                    strSql.Append(" and C_Customer_ChangHistory_checkPerson=@C_Customer_ChangHistory_checkPerson ");
                }
                if(model.C_Customer_ChangHistory_type!=null && model.C_Customer_ChangHistory_type.ToString()!="")
                {
                    strSql.Append(" and C_Customer_ChangHistory_type=@C_Customer_ChangHistory_type ");
                }
			}
            SqlParameter[] parameters = {					 
                    new SqlParameter("@C_Customer_ChangHistory_submitPerson",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_checkPerson",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_ChangHistory_type",SqlDbType.Int,4)
				 };
            parameters[0].Value = model.C_Customer_ChangHistory_submitPerson;
            parameters[1].Value = model.C_Customer_ChangHistory_checkPerson;
            parameters[2].Value = model.C_Customer_ChangHistory_type;
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
        public DataSet GetListByPage(CommonService.Model.C_Customer_ChangHistory model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Customer_ChangHistory_id desc");
			}
            strSql.Append(")AS Row, T.*,");
            strSql.Append(" case when T.C_Customer_ChangHistory_type=930 then (select C.C_Customer_name from C_Customer as C where C.C_Customer_code=T.C_Customer_ChangHistory_customer)");
            strSql.Append(" when T.C_Customer_ChangHistory_type=931 then (select BC.B_BusinessChance_name from B_BusinessChance as BC where BC.B_BusinessChance_code=T.C_Customer_ChangHistory_customer)");
            strSql.Append(" end as C_Customer_ChangHistory_customerName");
            strSql.Append(",P.C_Parameters_name as 'C_Customer_ChangHistory_stateName',U1.C_Userinfo_name as 'C_Customer_ChangHistory_submitpersonName',U2.C_Userinfo_name as 'C_Customer_ChangHistory_checkpersonName',P1.C_Parameters_name as 'C_Customer_changhistory_typeName'");
            strSql.Append(" from C_Customer_ChangHistory T");
            //strSql.Append(" left join C_Customer as C on T.C_Customer_ChangHistory_customer = C.C_Customer_code ");
            strSql.Append(" left join C_Parameters as P on T.C_Customer_ChangHistory_state = P.C_Parameters_id ");
            strSql.Append(" left join C_Parameters as P1 on T.C_Customer_ChangHistory_type = P1.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U1 on T.C_Customer_ChangHistory_submitPerson = U1.C_Userinfo_code ");
            strSql.Append(" left join C_Userinfo as U2 on T.C_Customer_ChangHistory_checkPerson = U2.C_Userinfo_code ");
            strSql.Append(" where 1=1 and C_Customer_ChangHistory_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Customer_ChangHistory_submitPerson != null && model.C_Customer_ChangHistory_submitPerson.ToString() != "")
                {
                    strSql.Append(" and C_Customer_ChangHistory_submitPerson=@C_Customer_ChangHistory_submitPerson ");
                }
                if (model.C_Customer_ChangHistory_checkPerson != null && model.C_Customer_ChangHistory_checkPerson.ToString() != "")
                {
                    strSql.Append(" and C_Customer_ChangHistory_checkPerson=@C_Customer_ChangHistory_checkPerson ");
                }
                if (model.C_Customer_ChangHistory_type != null && model.C_Customer_ChangHistory_type.ToString() != "")
                {
                    strSql.Append(" and C_Customer_ChangHistory_type=@C_Customer_ChangHistory_type ");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					 
                    new SqlParameter("@C_Customer_ChangHistory_submitPerson",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_ChangHistory_checkPerson",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_ChangHistory_type",SqlDbType.Int,4)
				 };
            parameters[0].Value = model.C_Customer_ChangHistory_submitPerson;
            parameters[1].Value = model.C_Customer_ChangHistory_checkPerson;
            parameters[2].Value = model.C_Customer_ChangHistory_type;
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
			parameters[0].Value = "C_Customer_ChangHistory";
			parameters[1].Value = "C_Customer_ChangHistory_id";
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

