using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using CommonService.Common;//Please add references
namespace CommonService.DAL.FlowManager
{
    /// <summary>
    /// 数据访问类:业务流程表
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class P_Business_flow
	{
		public P_Business_flow()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("P_Business_flow_id", "P_Business_flow");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Business_flow_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Business_flow");
            strSql.Append(" where P_Business_flow_id=@P_Business_flow_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Business_flow_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByFkCodeAndFlowCode(Guid P_Fk_code, Guid P_Flow_code,int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Business_flow");
            strSql.Append(" where P_Business_isdelete=0 and P_Fk_code=@P_Fk_code ");
            strSql.Append("and P_Flow_code=@P_Flow_code ");
            if (type == 2)
            {//商机中如果流程申请未通过，那么流程中还应该存在次流程
                strSql.Append(" and P_Business_flow_applicationStatus !=814");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Flow_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Fk_code;
            parameters[1].Value = P_Flow_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FlowManager.P_Business_flow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into P_Business_flow(");
            strSql.Append("P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus) ");
			strSql.Append(" values (");
            strSql.Append("@P_Business_flow_code,@P_Fk_code,@P_Flow_code,@P_Business_flow_level,@P_Flow_parent,@P_Business_flow_name,@P_Business_flow_auditType,@P_Business_flow_require,@P_Business_order,@P_Business_remark,@P_Business_isdelete,@P_Business_state,@P_Business_startPerson,@P_Business_startReason,@P_Business_startTime,@P_Business_person,");
            strSql.Append("@P_Business_flow_planStartTime,@P_Business_flow_planEndTime,@P_Business_flow_factStartTime,@P_Business_flow_factEndTime,@P_Business_flow_standardTimeLength,@P_Business_flow_fixPrice,@P_Business_creator,@P_Business_createTime,@P_Business_flow_applicationStatus) ");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_level", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_name", SqlDbType.NVarChar,50),
					new SqlParameter("@P_Business_flow_auditType", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_require", SqlDbType.NVarChar,500),
                    new SqlParameter("@P_Business_order", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@P_Business_isdelete", SqlDbType.Bit),
					new SqlParameter("@P_Business_state", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_startPerson", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_startReason", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Business_startTime", SqlDbType.DateTime),
					new SqlParameter("@P_Business_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_planStartTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_planEndTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_factStartTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_factEndTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_standardTimeLength", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_flow_fixPrice", SqlDbType.Decimal,9),
					new SqlParameter("@P_Business_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_createTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_applicationStatus",SqlDbType.Int,4)};
            parameters[0].Value = model.P_Business_flow_code;
            parameters[1].Value = model.P_Fk_code;
            parameters[2].Value = model.P_Flow_code;
			parameters[3].Value = model.P_Business_flow_level;
            parameters[4].Value = model.P_Flow_parent;
			parameters[5].Value = model.P_Business_flow_name;
			parameters[6].Value = model.P_Business_flow_auditType;
			parameters[7].Value = model.P_Business_flow_require;
            parameters[8].Value = model.P_Business_order;
            parameters[9].Value = model.P_Business_remark;
            parameters[10].Value = model.P_Business_isdelete;
			parameters[11].Value = model.P_Business_state;
            parameters[12].Value = model.P_Business_startPerson;
            parameters[13].Value = model.P_Business_startReason;
			parameters[14].Value = model.P_Business_startTime;
            parameters[15].Value = model.P_Business_person;
            parameters[16].Value = model.P_Business_flow_planStartTime;
            parameters[17].Value = model.P_Business_flow_planEndTime;
            parameters[18].Value = model.P_Business_flow_factStartTime;
            parameters[19].Value = model.P_Business_flow_factEndTime;
            parameters[20].Value = model.P_Business_flow_standardTimeLength;
            parameters[21].Value = model.P_Business_flow_fixPrice;
            parameters[22].Value = model.P_Business_creator;
			parameters[23].Value = model.P_Business_createTime;
            parameters[24].Value = model.P_Business_flow_applicationStatus;

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
        public bool Update(CommonService.Model.FlowManager.P_Business_flow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update P_Business_flow set ");
			strSql.Append("P_Business_flow_code=@P_Business_flow_code,");
			strSql.Append("P_Fk_code=@P_Fk_code,");
			strSql.Append("P_Flow_code=@P_Flow_code,");
			strSql.Append("P_Business_flow_level=@P_Business_flow_level,");
			strSql.Append("P_Flow_parent=@P_Flow_parent,");
			strSql.Append("P_Business_flow_name=@P_Business_flow_name,");
			strSql.Append("P_Business_flow_auditType=@P_Business_flow_auditType,");
			strSql.Append("P_Business_flow_require=@P_Business_flow_require,");
            strSql.Append("P_Business_order=@P_Business_order,");
            strSql.Append("P_Business_remark=@P_Business_remark,");
            strSql.Append("P_Business_isdelete=@P_Business_isdelete,");
			strSql.Append("P_Business_state=@P_Business_state,");
            strSql.Append("P_Business_startPerson=@P_Business_startPerson,");
            strSql.Append("P_Business_startReason=@P_Business_startReason,");
			strSql.Append("P_Business_startTime=@P_Business_startTime,");
			strSql.Append("P_Business_person=@P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime=@P_Business_flow_planStartTime,");
            strSql.Append("P_Business_flow_planEndTime=@P_Business_flow_planEndTime,");
            strSql.Append("P_Business_flow_factStartTime=@P_Business_flow_factStartTime,");
            strSql.Append("P_Business_flow_factEndTime=@P_Business_flow_factEndTime,");
            strSql.Append("P_Business_flow_standardTimeLength=@P_Business_flow_standardTimeLength,");
            strSql.Append("P_Business_flow_fixPrice=@P_Business_flow_fixPrice,");
			strSql.Append("P_Business_creator=@P_Business_creator,");
			strSql.Append("P_Business_createTime=@P_Business_createTime,");
            strSql.Append("P_Business_flow_applicationStatus=@P_Business_flow_applicationStatus ");
			strSql.Append(" where P_Business_flow_id=@P_Business_flow_id");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_level", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_name", SqlDbType.VarChar,50),
					new SqlParameter("@P_Business_flow_auditType", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_require", SqlDbType.VarChar,500),
                    new SqlParameter("@P_Business_order", SqlDbType.Int,4),
					new SqlParameter("@P_Business_remark", SqlDbType.VarChar,500),
                    new SqlParameter("@P_Business_isdelete", SqlDbType.Bit),
					new SqlParameter("@P_Business_state", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_startPerson", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_startReason", SqlDbType.VarChar,500),
					new SqlParameter("@P_Business_startTime", SqlDbType.DateTime),
					new SqlParameter("@P_Business_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_planStartTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_planEndTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_factStartTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_factEndTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_standardTimeLength", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_flow_fixPrice", SqlDbType.Decimal,9),
					new SqlParameter("@P_Business_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_createTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_applicationStatus",SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_id", SqlDbType.Int,4)};
			parameters[0].Value = model.P_Business_flow_code;
			parameters[1].Value = model.P_Fk_code;
			parameters[2].Value = model.P_Flow_code;
			parameters[3].Value = model.P_Business_flow_level;
			parameters[4].Value = model.P_Flow_parent;
			parameters[5].Value = model.P_Business_flow_name;
			parameters[6].Value = model.P_Business_flow_auditType;
			parameters[7].Value = model.P_Business_flow_require;
            parameters[8].Value = model.P_Business_order;
            parameters[9].Value = model.P_Business_remark;
            parameters[10].Value = model.P_Business_isdelete;
			parameters[11].Value = model.P_Business_state;
            parameters[12].Value = model.P_Business_startPerson;
            parameters[13].Value = model.P_Business_startReason;
			parameters[14].Value = model.P_Business_startTime;
			parameters[15].Value = model.P_Business_person;
            parameters[16].Value = model.P_Business_flow_planStartTime;
            parameters[17].Value = model.P_Business_flow_planEndTime;
            parameters[18].Value = model.P_Business_flow_factStartTime;
            parameters[19].Value = model.P_Business_flow_factEndTime;
            parameters[20].Value = model.P_Business_flow_standardTimeLength;
            parameters[21].Value = model.P_Business_flow_fixPrice;
			parameters[22].Value = model.P_Business_creator;
			parameters[23].Value = model.P_Business_createTime;
            parameters[24].Value = model.P_Business_flow_applicationStatus;
			parameters[25].Value = model.P_Business_flow_id;

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
        public bool Delete(Guid businessFlowCode)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update P_Business_flow set ");
            strSql.Append("P_Business_isdelete=1 ");
            strSql.Append(" where P_Business_flow_code=@P_Business_flow_code");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;

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
        /// 根据业务流程Guid，更新任务要求值
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="require">任务要求值</param>
        /// <returns></returns>
        public bool UpdateRequire(Guid businessFlowCode,string require)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow set ");
            strSql.Append("P_Business_flow_require=@P_Business_flow_require ");
            strSql.Append(" where P_Business_flow_code=@P_Business_flow_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_flow_require", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = require;
            parameters[1].Value = businessFlowCode;

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
        /// 更改负责人
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessPersonCode">负责人Guid</param>
        /// <returns></returns>
        public bool UpdatePerson(Guid businessFlowCode, Guid businessPersonCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow set ");
            strSql.Append("P_Business_person=@P_Business_person ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessPersonCode;
            parameters[1].Value = businessFlowCode;

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
        /// 更改申请状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="applicationStatus">申请状态值</param>
        /// <returns></returns>
        public bool UpdateApplicationStatus(Guid businessFlowCode, int applicationStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow set ");
            strSql.Append("P_Business_flow_applicationStatus=@P_Business_flow_applicationStatus ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_flow_applicationStatus", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = applicationStatus;
            parameters[1].Value = businessFlowCode;

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
        /// 更改进行状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="carryingStatus">进行状态值</param>
        /// <returns></returns>
        public bool UpdateCarryingStatus(Guid businessFlowCode, int carryingStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow set ");
            strSql.Append("P_Business_state=@P_Business_state ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_state", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = carryingStatus;
            parameters[1].Value = businessFlowCode;

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
		public bool DeleteList(string P_Business_flow_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from P_Business_flow ");
			strSql.Append(" where P_Business_flow_id in ("+P_Business_flow_idlist + ")  ");
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
        /// 新增业务流程时，生成条目统计信息
        /// </summary>
        /// <param name="businessCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="flowType">流程类型</param>
        /// <param name="startFlow">流程Guid</param>
        /// <param name="creatorCode">操作人</param>
        public void GenerateEntryStatisticsByAddBusinessFlow(Guid businessCode, int flowType, Guid startFlow,Guid creatorCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessCode", SqlDbType.UniqueIdentifier,16),                    
                    new SqlParameter("@flowType", SqlDbType.Int,4),
                    new SqlParameter("@startFlow", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@creatorCode", SqlDbType.UniqueIdentifier,16)
				 };
            parameters[0].Value = businessCode;
            parameters[1].Value = flowType;
            parameters[2].Value = startFlow;
            parameters[3].Value = creatorCode;

            DbHelperSQL.RunNoVoidProcedure("proc_GenerateEntryStatisticsByAddBusinessFlow", parameters);

        }

        /// <summary>
        /// 业务流程时间改变时，修改关联条目统计信息中"开始时间"和"结束时间"的值
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        public void UpdateEntryStatisticsByBusinessFlowTime(Guid businessFlowCode, string fieldName, DateTime fieldValue)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowCode", SqlDbType.UniqueIdentifier,16),                    
                    new SqlParameter("@fieldName", SqlDbType.NVarChar,50),
                    new SqlParameter("@fieldValue", SqlDbType.DateTime,30)
				 };
            parameters[0].Value = businessFlowCode;
            parameters[1].Value = fieldName;
            parameters[2].Value = fieldValue;
         
            DbHelperSQL.RunNoVoidProcedure("proc_UpdateEntryStatisticsByBusinessFlowTime", parameters);
        }

		/// <summary>
        /// 根据业务流程Guid，删除关联条目统计信息
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        public void DeleteEntryStatisticsByBusinessFlowCode(Guid businessFlowCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowCode", SqlDbType.UniqueIdentifier,16)                    
				 };
            parameters[0].Value = businessFlowCode;

            DbHelperSQL.RunNoVoidProcedure("proc_DeleteEntryStatisticsByBusinessFlowCode", parameters);

        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FlowManager.P_Business_flow GetModel(Guid P_Business_flow_code)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 BF.P_Business_flow_id,BF.P_Business_flow_code,BF.P_Fk_code,BF.P_Flow_code,BF.P_Business_flow_level,BF.P_Flow_parent,BF.P_Business_flow_name,BF.P_Business_flow_auditType,BF.P_Business_flow_require,BF.P_Business_order,BF.P_Business_remark,BF.P_Business_isdelete,BF.P_Business_state,BF.P_Business_startPerson,BF.P_Business_startReason,BF.P_Business_startTime,BF.P_Business_person,");
            strSql.Append("BF.P_Business_flow_planStartTime,BF.P_Business_flow_planEndTime,BF.P_Business_flow_factStartTime,BF.P_Business_flow_factEndTime,BF.P_Business_flow_standardTimeLength,BF.P_Business_flow_fixPrice,BF.P_Business_creator,BF.P_Business_createTime,BF.P_Business_flow_applicationStatus,U.C_Userinfo_name as 'P_Business_person_name',");
            strSql.Append("SP.C_Userinfo_name as 'P_Business_startPerson_name' ");
            strSql.Append("from P_Business_flow as BF ");
            strSql.Append("left join C_Userinfo as U on BF.P_Business_person=U.C_Userinfo_code ");
            strSql.Append("left join C_Userinfo as SP on BF.P_Business_startPerson=SP.C_Userinfo_code ");
            
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code ");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Business_flow_code;

            CommonService.Model.FlowManager.P_Business_flow model = new CommonService.Model.FlowManager.P_Business_flow();
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
        /// 根据案件Guid和用户Guid获得结案业务流程
        /// </summary>
        /// <param name="CaseCode">案件Guid</param>
        /// <param name="businessFlowPerson">当前用户Guid</param>
        /// <returns></returns>
        public Model.FlowManager.P_Business_flow GetModelIsCrossForm(Guid CaseCode, Guid businessFlowPerson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.P_Business_flow_id,T.P_Business_flow_code,T.P_Fk_code,T.P_Flow_code,T.P_Business_flow_level,T.P_Flow_parent,T.P_Business_flow_name,T.P_Business_flow_auditType,T.P_Business_flow_require,T.P_Business_order,T.P_Business_remark,T.P_Business_isdelete,T.P_Business_state,T.P_Business_startPerson,T.P_Business_startReason,T.P_Business_startTime,T.P_Business_person,");
            strSql.Append("T.P_Business_flow_planStartTime,T.P_Business_flow_planEndTime,T.P_Business_flow_factStartTime,T.P_Business_flow_factEndTime,T.P_Business_flow_standardTimeLength,T.P_Business_flow_fixPrice,T.P_Business_creator,T.P_Business_createTime,T.P_Business_flow_applicationStatus ");
            strSql.Append("from P_Business_flow as T ");
            strSql.Append("left join P_Flow as PF on T.P_Flow_code=PF.P_Flow_code ");
            strSql.Append("left join B_Case as C on T.P_Fk_code=C.B_Case_code ");
            strSql.Append("where T.P_Business_isdelete=0 ");
            strSql.Append("and T.P_Business_state=200 ");
            strSql.Append("and PF.P_Flow_IsCrossForm=1 ");
            strSql.Append("and C.B_Case_code=@B_Case_code ");
            strSql.Append("and T.P_Business_person=@P_Business_person");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_person",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = CaseCode;
            parameters[1].Value = businessFlowPerson;

            CommonService.Model.FlowManager.P_Business_flow model = new CommonService.Model.FlowManager.P_Business_flow();
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
        /// 得到一个对象实体(不包含已删除的)
        /// </summary>
        /// <param name="fkCode">业务外键Guid</param>
        /// <param name="orderBy">显示顺序号</param>
        /// /// <param name="level">级别</param>
        /// <param name="parentBusinessFlowCode">父亲业务流程Guid</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow GetModel(Guid fkCode, ConditonType conditionType, int orderBy,int level, Guid? parentBusinessFlowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
            strSql.Append("from P_Business_flow WITH(NOLOCK) ");
            strSql.Append("where P_Fk_code=@P_Fk_code ");
            if (parentBusinessFlowCode != null)
            {
                strSql.Append("and P_Flow_parent=@P_Flow_parent ");   //加入可能存在的父亲流程Guid       
            }            
            strSql.Append("and P_Business_isdelete=0 ");
            strSql.Append("and P_Business_flow_level=@P_Business_flow_level ");
            switch (conditionType)
            {
                case ConditonType.小于:
                    strSql.Append("and P_Business_order<@P_Business_order ");
                    strSql.Append("order by P_Business_order Desc ");
                    break;
                case ConditonType.大于:
                    strSql.Append("and P_Business_order>@P_Business_order ");
                    strSql.Append("order by P_Business_order Asc ");
                    break;
            }

            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16),
                     new SqlParameter("@P_Business_flow_level", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_order", SqlDbType.Int,4)
			};
            parameters[0].Value = fkCode;
            parameters[1].Value = parentBusinessFlowCode;
            parameters[2].Value = level;
            parameters[3].Value = orderBy;
            
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
        /// 通过业务Guid和级别获取级别下排序列最大的实体对象
        /// </summary>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow GetMaxOrderModelByLevel(int level,Guid fkCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
            strSql.Append("from P_Business_flow WITH(NOLOCK) " );
            strSql.Append("where P_Business_flow_level=@P_Business_flow_level and P_Fk_code=@P_Fk_code ");
            strSql.Append("order by P_Business_order Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_level", SqlDbType.Int,4),
                    new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = level;
            parameters[1].Value = fkCode;
       
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
        /// 通过业务Guid和级别获取级别下排序列最大的实体对象
        /// </summary>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow GetNextOrderModelByPkcode(Guid fkCode,int nextOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
            strSql.Append("from P_Business_flow WITH(NOLOCK) ");
            strSql.Append("where P_Business_order=@P_Business_order and P_Fk_code=@P_Fk_code ");
            strSql.Append("order by P_Business_order Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_order", SqlDbType.Int,4)
			};
            parameters[0].Value = fkCode;
            parameters[1].Value = nextOrder;

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
        /// 获取案件或商机下的一个交单业务流程
        /// </summary>
        /// <param name="flowType">流程类型(案件或者商机)</param>
        /// <param name="pkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow GetCrossFormBusinessFlow(int flowType, Guid pkCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 BF.* ");
            strSql.Append("from P_Business_flow as BF with(nolock) ");
            strSql.Append("where BF.P_Fk_code=@P_Fk_code ");
            strSql.Append("and BF.P_Business_isdelete=0 ");
            strSql.Append("and exists(select 1 from P_Flow as P with(nolock) where P.P_Flow_isDelete=0 and P.P_Flow_IsCrossForm=1 and P.P_Flow_type=@P_Flow_type and BF.P_Flow_code=P.P_Flow_code) ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Flow_type", SqlDbType.Int,4)
			};
            parameters[0].Value = pkCode;
            parameters[1].Value = flowType;

            CommonService.Model.FlowManager.P_Business_flow model = new CommonService.Model.FlowManager.P_Business_flow();
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
        /// 获取客户正在进行的流程
        /// </summary>
        /// <param name="flowType">流程类型(案件或者商机或者客户)</param>
        /// <param name="pkCode">案件Guid或者商机Guid或者客户guid</param>
        /// <param name="pkCode">流程状态</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow GetCustomerIngBusinessFlow(int flowType, Guid pkCode, int P_Business_state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 BF.* ");
            strSql.Append("from P_Business_flow as BF with(nolock) ");
            strSql.Append("where BF.P_Fk_code=@P_Fk_code ");
            strSql.Append("and BF.P_Business_isdelete=0 ");
            strSql.Append("and P_Business_state=@P_Business_state ");
            strSql.Append("and exists(select 1 from P_Flow as P with(nolock) where P.P_Flow_isDelete=0 and P.P_Flow_IsCrossForm=1 and P.P_Flow_type=@P_Flow_type and BF.P_Flow_code=P.P_Flow_code) ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Flow_type", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_state", SqlDbType.Int,4)
			};
            parameters[0].Value = pkCode;
            parameters[1].Value = flowType;
            parameters[1].Value = P_Business_state;
            CommonService.Model.FlowManager.P_Business_flow model = new CommonService.Model.FlowManager.P_Business_flow();
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
        /// 通过父亲Guid获取父亲下排序列最大的实体对象
        /// </summary>
        /// <param name="parentCode">父亲Guid</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow GetMaxOrderModelByParent(Guid parentCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
            strSql.Append("from P_Business_flow WITH(NOLOCK) ");
            strSql.Append("where P_Flow_parent=@P_Flow_parent ");
            strSql.Append("order by P_Business_order Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parentCode;

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
        public CommonService.Model.FlowManager.P_Business_flow DataRowToModel(DataRow row)
		{
            CommonService.Model.FlowManager.P_Business_flow model = new CommonService.Model.FlowManager.P_Business_flow();
			if (row != null)
			{
				if(row["P_Business_flow_id"]!=null && row["P_Business_flow_id"].ToString()!="")
				{
					model.P_Business_flow_id=int.Parse(row["P_Business_flow_id"].ToString());
				}
				if(row["P_Business_flow_code"]!=null && row["P_Business_flow_code"].ToString()!="")
				{
					model.P_Business_flow_code= new Guid(row["P_Business_flow_code"].ToString());
				}
				if(row["P_Fk_code"]!=null && row["P_Fk_code"].ToString()!="")
				{
					model.P_Fk_code= new Guid(row["P_Fk_code"].ToString());
				}
				if(row["P_Flow_code"]!=null && row["P_Flow_code"].ToString()!="")
				{
					model.P_Flow_code= new Guid(row["P_Flow_code"].ToString());
				}
				if(row["P_Business_flow_level"]!=null && row["P_Business_flow_level"].ToString()!="")
				{
					model.P_Business_flow_level=int.Parse(row["P_Business_flow_level"].ToString());
				}
				if(row["P_Flow_parent"]!=null && row["P_Flow_parent"].ToString()!="")
				{
					model.P_Flow_parent= new Guid(row["P_Flow_parent"].ToString());
				}
				if(row["P_Business_flow_name"]!=null)
				{
					model.P_Business_flow_name=row["P_Business_flow_name"].ToString();
				}
				if(row["P_Business_flow_auditType"]!=null && row["P_Business_flow_auditType"].ToString()!="")
				{
					model.P_Business_flow_auditType=int.Parse(row["P_Business_flow_auditType"].ToString());
				}
				if(row["P_Business_flow_require"]!=null)
				{
					model.P_Business_flow_require=row["P_Business_flow_require"].ToString();
				}
                if (row["P_Business_order"] != null && row["P_Business_order"].ToString() != "")
                {
                    model.P_Business_order = int.Parse(row["P_Business_order"].ToString());
                }
                if (row["P_Business_remark"] != null)
                {
                    model.P_Business_remark = row["P_Business_remark"].ToString();
                }
                if (row["P_Business_isdelete"] != null && row["P_Business_isdelete"].ToString() != "")
                {
                    if ((row["P_Business_isdelete"].ToString() == "1") || (row["P_Business_isdelete"].ToString().ToLower() == "true"))
                    {
                        model.P_Business_isdelete = true;
                    }
                    else
                    {
                        model.P_Business_isdelete = false;
                    }
                }
				if(row["P_Business_state"]!=null && row["P_Business_state"].ToString()!="")
				{
					model.P_Business_state=int.Parse(row["P_Business_state"].ToString());
				}
                //检查状态名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_state_name"))
                {
                    if (row["P_Business_state_name"] != null)
                    {
                        model.P_Business_state_name = row["P_Business_state_name"].ToString();
                    }
                }
                if (row["P_Business_startPerson"] != null && row["P_Business_startPerson"].ToString() != "")
                {
                    model.P_Business_startPerson = new Guid(row["P_Business_startPerson"].ToString());
                }
                //检查启动人名称（虚拟字段）是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_startPerson_name"))
                {
                    if(row["P_Business_startPerson_name"]!=null && row["P_Business_startPerson_name"].ToString()!="")
                    {
                        model.P_Business_startPerson_name = row["P_Business_startPerson_name"].ToString();
                    }
                }
                if (row["P_Business_startReason"] != null)
                {
                    model.P_Business_startReason = row["P_Business_startReason"].ToString();
                }
				if(row["P_Business_startTime"]!=null && row["P_Business_startTime"].ToString()!="")
				{
					model.P_Business_startTime=DateTime.Parse(row["P_Business_startTime"].ToString());
				}
				if(row["P_Business_person"]!=null && row["P_Business_person"].ToString()!="")
				{
					model.P_Business_person= new Guid(row["P_Business_person"].ToString());
				}
                //检查负责人名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_person_name"))
                {
                    if (row["P_Business_person_name"] != null)
                    {
                        model.P_Business_person_name = row["P_Business_person_name"].ToString();
                    }
                }
                 //检查部门名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_personDepName"))
                {
                    if (row["P_Business_personDepName"] != null)
                    {
                        model.P_Business_personDepName = row["P_Business_personDepName"].ToString();
                    }
                }

                

                //检查流程名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Flow_name"))
                {
                    if (row["P_Flow_name"] != null)
                    {
                        model.P_Flow_name = row["P_Flow_name"].ToString();
                    }
                }
                if (row["P_Business_flow_planStartTime"] != null && row["P_Business_flow_planStartTime"].ToString() != "")
                {
                    model.P_Business_flow_planStartTime = DateTime.Parse(row["P_Business_flow_planStartTime"].ToString());
                }
                if (row["P_Business_flow_planEndTime"] != null && row["P_Business_flow_planEndTime"].ToString() != "")
                {
                    model.P_Business_flow_planEndTime = DateTime.Parse(row["P_Business_flow_planEndTime"].ToString());
                }
                if (row["P_Business_flow_factStartTime"] != null && row["P_Business_flow_factStartTime"].ToString() != "")
                {
                    model.P_Business_flow_factStartTime = DateTime.Parse(row["P_Business_flow_factStartTime"].ToString());
                }
                if (row["P_Business_flow_factEndTime"] != null && row["P_Business_flow_factEndTime"].ToString() != "")
                {
                    model.P_Business_flow_factEndTime = DateTime.Parse(row["P_Business_flow_factEndTime"].ToString());
                }
                if (row["P_Business_flow_standardTimeLength"] != null && row["P_Business_flow_standardTimeLength"].ToString() != "")
                {
                    model.P_Business_flow_standardTimeLength = int.Parse(row["P_Business_flow_standardTimeLength"].ToString());
                }
                if (row["P_Business_flow_fixPrice"] != null && row["P_Business_flow_fixPrice"].ToString() != "")
                {
                    model.P_Business_flow_fixPrice = decimal.Parse(row["P_Business_flow_fixPrice"].ToString());
                }
				if(row["P_Business_creator"]!=null && row["P_Business_creator"].ToString()!="")
				{
					model.P_Business_creator= new Guid(row["P_Business_creator"].ToString());
				}
				if(row["P_Business_createTime"]!=null && row["P_Business_createTime"].ToString()!="")
				{
					model.P_Business_createTime=DateTime.Parse(row["P_Business_createTime"].ToString());
				}
                if(row["P_Business_flow_applicationStatus"]!=null && row["P_Business_flow_applicationStatus"].ToString()!="")
                {
                    model.P_Business_flow_applicationStatus = int.Parse(row["P_Business_flow_applicationStatus"].ToString());
                }
                //判断申请状态名称是否存在
                if(row.Table.Columns.Contains("P_Business_flow_applicationStatusName"))
                {
                    if(row["P_Business_flow_applicationStatusName"]!=null && row["P_Business_flow_applicationStatusName"].ToString()!="")
                    {
                        model.P_Business_flow_applicationStatusName = row["P_Business_flow_applicationStatusName"].ToString();
                    }
                }
                if(row.Table.Columns.Contains("P_Flow_defaultDuration"))
                {
                    if(row["P_Flow_defaultDuration"]!=null && row["P_Flow_defaultDuration"].ToString()!="")
                    {
                        model.P_Flow_defaultDuration = Convert.ToInt32(row["P_Flow_defaultDuration"].ToString());
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
            strSql.Append("select P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
			strSql.Append(" FROM P_Business_flow ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
        
        }

        /// <summary>
        /// 根据流程Guid获得数据列表
        /// </summary>
        public DataSet GetListByFlowCode(Guid P_Flow_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ,( select  C_Userinfo_name from C_Userinfo where C_Userinfo_code=P_Business_flow.P_Business_person) as P_Business_person_name ");
            strSql.Append(" FROM P_Business_flow where P_Business_state=200 and P_Business_isdelete=0 ");
            strSql.Append("and P_Flow_code=@P_Flow_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Flow_code;

            return DbHelperSQL.Query(strSql.ToString(),parameters);
        
        }

        /// <summary>
        /// 根据流程"是否监控"为"是"获得数据列表
        /// </summary>
        public DataSet GetAllListByFlowIsMonitor()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.P_Business_flow_id,T.P_Business_flow_code,T.P_Fk_code,T.P_Flow_code,T.P_Business_flow_level,T.P_Flow_parent,T.P_Business_flow_name,T.P_Business_flow_auditType,T.P_Business_flow_require,T.P_Business_order,T.P_Business_remark,T.P_Business_isdelete,T.P_Business_state,T.P_Business_startPerson,T.P_Business_startReason,T.P_Business_startTime,T.P_Business_person,");
            strSql.Append("T.P_Business_flow_planStartTime,T.P_Business_flow_planEndTime,T.P_Business_flow_factStartTime,T.P_Business_flow_factEndTime,T.P_Business_flow_standardTimeLength,T.P_Business_flow_fixPrice,T.P_Business_creator,T.P_Business_createTime,T.P_Business_flow_applicationStatus,PF.P_Flow_defaultDuration as P_Flow_defaultDuration ");
            strSql.Append(" FROM P_Business_flow as T ");
            strSql.Append("left join P_Flow as PF on PF.P_Flow_code=T.P_Flow_code ");
            strSql.Append("where 1=1 ");
            strSql.Append("and T.P_Business_isdelete=0 and T.P_Business_state=200 ");
            strSql.Append("and PF.P_Flow_isDelete=0 and PF.P_Flow_IsMonitor=1");

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
            strSql.Append(" P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
			strSql.Append(" FROM P_Business_flow ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 根据负责人获得未开始和正在进行数据
        /// </summary>
        /// <param name="P_Business_person"></param>
        /// <returns></returns>
        public DataSet GetListByPerson(Guid P_Business_person)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
            strSql.Append(" FROM P_Business_flow ");
            strSql.Append(" where P_Business_isdelete = 0 and P_Business_person=@P_Business_person ");
            strSql.Append("and (P_Business_state=199 or P_Business_state=200) ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_person", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Business_person;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 关联获取数据
        /// </summary>
        /// <param name="fkCode">关联业务Guid，比如商机Guid，案件Guid</param>
        /// <returns></returns>
        public DataSet GetListByFkCode(Guid fkCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PBF.P_Business_flow_id,PBF.P_Business_flow_code,PBF.P_Fk_code,PBF.P_Flow_code,PBF.P_Business_flow_level,PBF.P_Flow_parent,PBF.P_Business_flow_name,PBF.P_Business_flow_auditType,PBF.P_Business_flow_require,PBF.P_Business_order,PBF.P_Business_remark,PBF.P_Business_isdelete,PBF.P_Business_state,PBF.P_Business_startPerson,PBF.P_Business_startReason,PBF.P_Business_startTime,PBF.P_Business_person,");
            strSql.Append("PBF.P_Business_flow_planStartTime,PBF.P_Business_flow_planEndTime,PBF.P_Business_flow_factStartTime,PBF.P_Business_flow_factEndTime,PBF.P_Business_flow_standardTimeLength,PBF.P_Business_flow_fixPrice,PBF.P_Business_creator,PBF.P_Business_createTime,PBF.P_Business_flow_applicationStatus,");
            strSql.Append("U.C_Userinfo_name As P_Business_person_name,PF.P_Flow_name As P_Flow_name,P.C_Parameters_name As P_Business_state_name,P1.C_Parameters_name as P_Business_flow_applicationStatusName ");
            strSql.Append("from P_Business_flow AS PBF WITH(NOLOCK) ");
            strSql.Append("left join C_Userinfo AS U WITH(NOLOCK) on P_Business_person = U.C_Userinfo_code ");
            strSql.Append("left join P_Flow AS PF WITH(NOLOCK) on PBF.P_Flow_code = PF.P_Flow_code ");
            strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on PBF.P_Business_state=P.C_Parameters_id ");
            strSql.Append("left join C_Parameters AS P1 WITH(NOLOCK) on PBF.P_Business_flow_applicationStatus=P1.C_Parameters_id ");
            strSql.Append("where P_Fk_code=@P_Fk_code and P_Business_isdelete = 0 ");           
            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = fkCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据业务Guid(案件Guid或者商机Guid)，获取所有存粹的业务流程集合
        /// </summary>
        /// <param name="fkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        public DataSet GetPureListByFkCode(Guid fkCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PBF.* "); 
            strSql.Append("from P_Business_flow AS PBF WITH(NOLOCK) ");           
            strSql.Append("where P_Fk_code=@P_Fk_code and P_Business_isdelete = 0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = fkCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 通过父亲业务流程Guid，获取子集业务流程集合
        /// </summary>
        /// <param name="parentCode">父亲业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetListByParentCode(Guid parentCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
            strSql.Append("from P_Business_flow WITH(NOLOCK) ");
            strSql.Append("where P_Flow_parent=@P_Flow_parent and P_Business_isdelete = 0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parentCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 通过案件Guid或商机Guid，业务流程级别获取集合
        /// </summary>
        /// <param name="fkCode">案件Guid或商机Guid</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public DataSet GetListByFkCodeAndLevel(Guid fkCode,int level)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Business_flow_id,P_Business_flow_code,P_Fk_code,P_Flow_code,P_Business_flow_level,P_Flow_parent,P_Business_flow_name,P_Business_flow_auditType,P_Business_flow_require,P_Business_order,P_Business_remark,P_Business_isdelete,P_Business_state,P_Business_startPerson,P_Business_startReason,P_Business_startTime,P_Business_person,(select C_Userinfo_name from C_userinfo where C_Userinfo_code=P_Business_flow.P_Business_person) as P_Business_person_name,(select C_Organization_name from C_Organization where C_Organization_code=(select C_Userinfo_Organization from C_userinfo where C_Userinfo_code=P_Business_flow.P_Business_person)) as P_Business_personDepName,");
            strSql.Append("P_Business_flow_planStartTime,P_Business_flow_planEndTime,P_Business_flow_factStartTime,P_Business_flow_factEndTime,P_Business_flow_standardTimeLength,P_Business_flow_fixPrice,P_Business_creator,P_Business_createTime,P_Business_flow_applicationStatus ");
            strSql.Append("from P_Business_flow WITH(NOLOCK) ");
            strSql.Append("where P_Business_isdelete = 0 ");
            strSql.Append("and P_Fk_code=@P_Fk_code ");
            strSql.Append("and P_Business_flow_level=@P_Business_flow_level ");
            strSql.Append("order by P_Business_order Asc ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_level", SqlDbType.Int,4)
			};
            parameters[0].Value = fkCode;
            parameters[1].Value = level;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(CommonService.Model.FlowManager.P_Business_flow model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM P_Business_flow ");
            if (model != null)
            {
                if (model.P_Business_flow_code != null && model.P_Business_flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Business_flow_code=@P_Business_flow_code");
                }
                if (model.P_Fk_code != null && model.P_Fk_code.ToString() != "")
                {
                    strSql.Append(" and P_Fk_code=@P_Fk_code");
                }
                if (model.P_Business_flow_code != null && model.P_Business_flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Business_flow_code=@P_Business_flow_code");
                }
                if (model.P_Business_flow_name != null && model.P_Business_flow_name != "")
                {
                    strSql.Append(" and P_Business_flow_name=@P_Business_flow_name");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_name", SqlDbType.VarChar,50)};
            parameters[0].Value = model.P_Business_flow_code;
            parameters[1].Value = model.P_Fk_code;
            parameters[2].Value = model.P_Flow_code;
            parameters[3].Value = model.P_Business_flow_name;
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
		public DataSet GetListByPage(CommonService.Model.FlowManager.P_Business_flow model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.P_Business_flow_id desc");
			}
			strSql.Append(")AS Row, T.*  from P_Business_flow T ");
            if (model != null)
            {
                if (model.P_Business_flow_code != null && model.P_Business_flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Business_flow_code=@P_Business_flow_code");
                }
                if (model.P_Fk_code != null && model.P_Fk_code.ToString() != "")
                {
                    strSql.Append(" and P_Fk_code=@P_Fk_code");
                }
                if (model.P_Business_flow_code != null && model.P_Business_flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Business_flow_code=@P_Business_flow_code");
                }
                if (model.P_Business_flow_name != null && model.P_Business_flow_name != "")
                {
                    strSql.Append(" and P_Business_flow_name=@P_Business_flow_name");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_name", SqlDbType.VarChar,50)};
            parameters[0].Value = model.P_Business_flow_code;
            parameters[1].Value = model.P_Fk_code;
            parameters[2].Value = model.P_Flow_code;
            parameters[3].Value = model.P_Business_flow_name;
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
			parameters[0].Value = "P_Business_flow";
			parameters[1].Value = "P_Business_flow_id";
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
        /// 根据案件编号获取流程
        /// </summary>
        /// <param name="caseNumber"></param>
        /// <returns></returns>
        public DataSet GetListByCaseNumber(string caseNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PBF.P_Business_flow_id,PBF.P_Business_flow_code,PBF.P_Fk_code,PBF.P_Flow_code,PBF.P_Business_flow_level,PBF.P_Flow_parent,PBF.P_Business_flow_name,PBF.P_Business_flow_auditType,PBF.P_Business_flow_require,PBF.P_Business_order,PBF.P_Business_remark,PBF.P_Business_isdelete,PBF.P_Business_state,PBF.P_Business_startPerson,PBF.P_Business_startReason,PBF.P_Business_startTime,PBF.P_Business_person,");
            strSql.Append("PBF.P_Business_flow_planStartTime,PBF.P_Business_flow_planEndTime,PBF.P_Business_flow_factStartTime,PBF.P_Business_flow_factEndTime,PBF.P_Business_flow_standardTimeLength,PBF.P_Business_flow_fixPrice,PBF.P_Business_creator,PBF.P_Business_createTime,PBF.P_Business_flow_applicationStatus,");
            strSql.Append("U.C_Userinfo_name As P_Business_person_name,PF.P_Flow_name As P_Flow_name,P.C_Parameters_name As P_Business_state_name,P1.C_Parameters_name as P_Business_flow_applicationStatusName ");
            strSql.Append("from P_Business_flow AS PBF WITH(NOLOCK) ");
            strSql.Append("left join C_Userinfo AS U WITH(NOLOCK) on P_Business_person = U.C_Userinfo_code ");
            strSql.Append("left join P_Flow AS PF WITH(NOLOCK) on PBF.P_Flow_code = PF.P_Flow_code ");
            strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on PBF.P_Business_state=P.C_Parameters_id ");
            strSql.Append("left join C_Parameters AS P1 WITH(NOLOCK) on PBF.P_Business_flow_applicationStatus=P1.C_Parameters_id ");
            strSql.Append("where P_Fk_code=(select B_Case_code from B_Case where B_Case_number=@B_Case_number and B_Case_isDelete=0) and P_Business_isdelete = 0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_number", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = caseNumber;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
		#endregion  ExtensionMethod
	}
}

