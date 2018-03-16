using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using CommonService.Common;//Please add references
namespace CommonService.DAL.FlowManager
{
    /// <summary>
    /// 数据访问类:业务流程----表单中间表
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class P_Business_flow_form
	{
		public P_Business_flow_form()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("P_Business_flow_form_id", "P_Business_flow_form");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Business_flow_form_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Business_flow_form");
            strSql.Append(" where P_Business_flow_form_id=@P_Business_flow_form_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Business_flow_form_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByBusinessflowCodeAndFormCode(Guid P_Business_flow_code, Guid F_Form_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Business_flow_form");
            strSql.Append(" where P_Business_flow_form_isdelete=0 and P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and F_Form_code=@F_Form_code and P_Business_flow_form_status<>766  ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Business_flow_code;
            parameters[1].Value = F_Form_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查当前业务流程，表单是否存在重做记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>如果存在，返回true;不存在，返回false</returns>   
        public bool ExistsRelDoneFormByBusinessflowCodeAndFormCode(Guid businessFlowCode, Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Business_flow_form");
            strSql.Append(" where P_Business_flow_form_isdelete=0 and P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and F_Form_code=@F_Form_code and P_Business_flow_form_status=766  ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;
            parameters[1].Value = formCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据业务流程guid和表单guid，获取有效的业务流程表单关联Guid及其状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回有效业务流程表单关联Guid</returns>       
        public string GetEffectBusinessFlowFormCode(Guid businessFlowCode, Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 cast(P_Business_flow_form_code as varchar(50))+','+cast(P_Business_flow_form_status as varchar(4)) from P_Business_flow_form ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and F_Form_code=@F_Form_code ");
            strSql.Append("and P_Business_flow_form_isdelete=0 ");
            strSql.Append("and P_Business_flow_form_status<>766 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;
            parameters[1].Value = formCode;

           object returnValue = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

           if (returnValue == null)
           {
               return String.Empty;
           }
           else
           {
               return returnValue.ToString();
           }
        }



        /// <summary>
        /// 根据业务流程guid和表单guid，获取有效的业务流程表单状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回有效业务流程表单关联Guid</returns>       
        public string GetEffectBusinessFlowFormCodeStatus(Guid businessFlowCode, Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 cast(P_Business_flow_form_status as varchar(4)) from P_Business_flow_form ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and F_Form_code=@F_Form_code ");
            strSql.Append("and P_Business_flow_form_isdelete=0 ");
            strSql.Append("and P_Business_flow_form_status<>766 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;
            parameters[1].Value = formCode;

            object returnValue = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (returnValue == null)
            {
                return String.Empty;
            }
            else
            {
                return returnValue.ToString();
            }
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FlowManager.P_Business_flow_form model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into P_Business_flow_form(");
            strSql.Append("P_Business_flow_form_code,P_Business_flow_code,F_Form_code,P_Business_flow_form_order,P_Business_flow_form_person,P_Business_flow_form_isDefault,P_Business_flow_form_state,P_Business_flow_form_status,P_Business_flow_form_isdelete,P_Business_flow_form_creator,P_Business_flow_form_createTime,P_Business_flow_form_isPlan)");
			strSql.Append(" values (");
            strSql.Append("@P_Business_flow_form_code,@P_Business_flow_code,@F_Form_code,@P_Business_flow_form_order,@P_Business_flow_form_person,@P_Business_flow_form_isDefault,@P_Business_flow_form_state,@P_Business_flow_form_status,@P_Business_flow_form_isdelete,@P_Business_flow_form_creator,@P_Business_flow_form_createTime,@P_Business_flow_form_isPlan)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_order", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_isDefault", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_flow_form_state",SqlDbType.Int,4),
                    new SqlParameter("@P_Business_flow_form_status", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_form_isdelete", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_form_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_createTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_form_isPlan",SqlDbType.Bit,1)};
            parameters[0].Value = model.P_Business_flow_form_code;
            parameters[1].Value = model.P_Business_flow_code;
            parameters[2].Value = model.F_Form_code;
            parameters[3].Value = model.P_Business_flow_form_order;
            parameters[4].Value = model.P_Business_flow_form_person;
            parameters[5].Value = model.P_Business_flow_form_isDefault;
            parameters[6].Value = model.P_Business_flow_form_state;
            parameters[7].Value = model.P_Business_flow_form_status;
			parameters[8].Value = model.P_Business_flow_form_isdelete;
            parameters[9].Value = model.P_Business_flow_form_creator;
			parameters[10].Value = model.P_Business_flow_form_createTime;
            parameters[11].Value = model.P_Business_flow_form_isPlan;

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
        public bool Update(CommonService.Model.FlowManager.P_Business_flow_form model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update P_Business_flow_form set ");
            strSql.Append("P_Business_flow_form_code=@P_Business_flow_form_code,");
			strSql.Append("P_Business_flow_code=@P_Business_flow_code,");
			strSql.Append("F_Form_code=@F_Form_code,");
            strSql.Append("P_Business_flow_form_order=@P_Business_flow_form_order,");
            strSql.Append("P_Business_flow_form_person=@P_Business_flow_form_person,");
            strSql.Append("P_Business_flow_form_isDefault=@P_Business_flow_form_isDefault,");
            strSql.Append("P_Business_flow_form_state=@P_Business_flow_form_state,");
            strSql.Append("P_Business_flow_form_status=@P_Business_flow_form_status,");
			strSql.Append("P_Business_flow_form_isdelete=@P_Business_flow_form_isdelete,");
			strSql.Append("P_Business_flow_form_creator=@P_Business_flow_form_creator,");
			strSql.Append("P_Business_flow_form_createTime=@P_Business_flow_form_createTime,");
            strSql.Append("P_Business_flow_form_isPlan=@P_Business_flow_form_isPlan ");
			strSql.Append(" where P_Business_flow_form_id=@P_Business_flow_form_id");
			SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_order", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_isDefault", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_flow_form_state",SqlDbType.Int,4),
                    new SqlParameter("@P_Business_flow_form_status", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_form_isdelete", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_form_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_createTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Business_flow_form_isPlan",SqlDbType.Bit,1),
					new SqlParameter("@P_Business_flow_form_id", SqlDbType.Int)
                    };
            parameters[0].Value = model.P_Business_flow_form_code;
			parameters[1].Value = model.P_Business_flow_code;
			parameters[2].Value = model.F_Form_code;
            parameters[3].Value = model.P_Business_flow_form_order;
            parameters[4].Value = model.P_Business_flow_form_person;
            parameters[5].Value = model.P_Business_flow_form_isDefault;
            parameters[6].Value = model.P_Business_flow_form_state;
            parameters[7].Value = model.P_Business_flow_form_status;
			parameters[8].Value = model.P_Business_flow_form_isdelete;
			parameters[9].Value = model.P_Business_flow_form_creator;
			parameters[10].Value = model.P_Business_flow_form_createTime;
            parameters[11].Value = model.P_Business_flow_form_isPlan;
			parameters[12].Value = model.P_Business_flow_form_id;
           

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
        /// 根据业务流程表单关联Guid，更新主办律师
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="person">主办律师Guid</param>
        /// <returns></returns>
        public bool UpdatePerson(Guid businessFlowFormCode, Guid person)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_form set P_Business_flow_form_person=@P_Business_flow_form_person ");
            strSql.Append("where P_Business_flow_form_code=@P_Business_flow_form_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = person;
            parameters[1].Value = businessFlowFormCode;

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
        /// 更新数据排列顺序
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程Guid</param>
        /// <param name="order">顺序号</param>
        /// <returns></returns>
        public bool UpdateOrder(Guid guid, int order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_form set P_Business_flow_form_order=@P_Business_flow_form_order ");
            strSql.Append("where F_Form_code=@F_Form_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_flow_form_order", SqlDbType.Int,5),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = order;
            parameters[1].Value = guid;

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
        /// 根据业务流程表单关联Guid，更新未设定的表单主办律师
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程Guid</param>
        /// <param name="person">主办律师Guid</param>
        /// <returns></returns>
        public bool UpdatePersonisPlanNo(Guid businessFlowCode, Guid person)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_form set P_Business_flow_form_person=@P_Business_flow_form_person ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code and (P_Business_flow_form_isPlan=0 or P_Business_flow_form_isPlan is null )");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = person;
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
        /// 更改计划设定状态
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="isPlan">是否设定</param>
        /// <returns></returns>
        public bool UpdateIsPlan(Guid businessFlowFormCode, bool isPlan)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_form set P_Business_flow_form_isPlan=@P_Business_flow_form_isPlan ");
            strSql.Append("where P_Business_flow_form_code=@P_Business_flow_form_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Business_flow_form_isPlan", SqlDbType.Bit,1),
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            if (isPlan == true)
            {
                parameters[0].Value = 1;
            }
            else {
                parameters[0].Value = 0;
            }
           
            parameters[1].Value = businessFlowFormCode;

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
        /// 根据业务流程Guid删除关联表单数据
        /// </summary>
        /// <param name="businessFlowCode">流程Guid</param>
        /// <returns></returns>
        public bool DeleteByBusinessFlowCode(Guid businessFlowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_form set P_Business_flow_form_isdelete=1 ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code;");

            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;

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
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid businessFlowFormCode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update P_Business_flow_form set P_Business_flow_form_isdelete=1 ");
            strSql.Append(" where P_Business_flow_form_code=@P_Business_flow_form_code");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowFormCode;

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
		public bool DeleteList(string P_Business_flow_form_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from P_Business_flow_form ");
			strSql.Append(" where P_Business_flow_form_id in ("+P_Business_flow_form_idlist + ")  ");
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
        /// 新增业务流程表单时，生成条目统计信息
        /// </summary>
        /// <param name="businessCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="flowType">流程类型</param>
        /// <param name="startFlow">流程Guid</param>
        /// <param name="startFlow">表单Guid</param>
        /// <param name="creatorCode">操作人</param>
        public void GenerateEntryStatisticsByAddForm(Guid businessCode, int flowType, Guid startFlow, Guid startForm, Guid creatorCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessCode", SqlDbType.UniqueIdentifier,16),                    
                    new SqlParameter("@flowType", SqlDbType.Int,4),
                    new SqlParameter("@startFlow", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@startForm", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@creatorCode", SqlDbType.UniqueIdentifier,16)
				 };
            parameters[0].Value = businessCode;
            parameters[1].Value = flowType;
            parameters[2].Value = startFlow;
            parameters[3].Value = startForm;
            parameters[4].Value = creatorCode;

            DbHelperSQL.RunNoVoidProcedure("proc_GenerateEntryStatisticsByAddForm", parameters);

        }
        /// <summary>
        /// 根据业务流程表单关联Guid，删除关联条目统计信息
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        public void DeleteEntryStatisticsByBusinessFlowFormCode(Guid businessFlowFormCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowFormCode", SqlDbType.UniqueIdentifier,16)               
				 };
            parameters[0].Value = businessFlowFormCode;

            DbHelperSQL.RunNoVoidProcedure("proc_DeleteEntryStatisticsByBusinessFlowFormCode", parameters);

        }

        /// <summary>
        /// 业务流程表单时间改变时，修改关联条目统计信息中"开始时间"和"结束时间"的值
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        public void UpdateEntryStatisticsByFormTime(Guid businessFlowFormCode, string fieldName, DateTime fieldValue)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowFormCode", SqlDbType.UniqueIdentifier,16),                    
                    new SqlParameter("@fieldName", SqlDbType.NVarChar,50),
                    new SqlParameter("@fieldValue", SqlDbType.DateTime,30)
				 };
            parameters[0].Value = businessFlowFormCode;
            parameters[1].Value = fieldName;
            parameters[2].Value = fieldValue;
             
            DbHelperSQL.RunNoVoidProcedure("proc_UpdateEntryStatisticsByFormTime", parameters);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FlowManager.P_Business_flow_form GetModel(Guid P_Business_flow_form_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 P_Business_flow_form_id,P_Business_flow_form_code,P_Business_flow_code,a.F_Form_code,P_Business_flow_form_order,P_Business_flow_form_person,P_Business_flow_form_isDefault,P_Business_flow_form_state,P_Business_flow_form_status,P_Business_flow_form_isdelete,P_Business_flow_form_creator,P_Business_flow_form_createTime,P_Business_flow_form_isPlan,b.F_Form_chineseName as F_Form_chineseName from P_Business_flow_form as a");
            strSql.Append(" left join F_Form as b on b.F_Form_code=a.F_Form_code");
            strSql.Append(" where P_Business_flow_form_code=@P_Business_flow_form_code");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Business_flow_form_code;

            CommonService.Model.FlowManager.P_Business_flow_form model = new CommonService.Model.FlowManager.P_Business_flow_form();
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
        /// 根据GUID得到关联用户对象实体
        /// </summary>
        public CommonService.Model.FlowManager.P_Business_flow_form GetPersonModelByCode(Guid P_Business_flow_form_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 BF.P_Business_flow_form_id,BF.P_Business_flow_form_code,BF.P_Business_flow_code,BF.F_Form_code,BF.P_Business_flow_form_order,BF.P_Business_flow_form_person,BF.P_Business_flow_form_isDefault,BF.P_Business_flow_form_state,BF.P_Business_flow_form_status,BF.P_Business_flow_form_isdelete,BF.P_Business_flow_form_creator,BF.P_Business_flow_form_createTime,");
            strSql.Append("U.C_Userinfo_name as P_Business_flow_form_person_name ");
            strSql.Append("from P_Business_flow_form as BF ");
            strSql.Append("left join C_Userinfo as U on BF.P_Business_flow_form_person=U.C_Userinfo_code ");
            strSql.Append(" where BF.P_Business_flow_form_code=@P_Business_flow_form_code");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Business_flow_form_code;

            CommonService.Model.FlowManager.P_Business_flow_form model = new CommonService.Model.FlowManager.P_Business_flow_form();
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
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="orderBy">显示顺序号</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow_form GetModel(Guid businessFlowCode, ConditonType conditionType, int orderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 P_Business_flow_form_id,P_Business_flow_form_code,P_Business_flow_code,F_Form_code,P_Business_flow_form_order,P_Business_flow_form_person,P_Business_flow_form_isDefault,P_Business_flow_form_state,P_Business_flow_form_status,P_Business_flow_form_isdelete,P_Business_flow_form_creator,P_Business_flow_form_createTime from P_Business_flow_form WITH(NOLOCK) ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and P_Business_flow_form_isdelete=0 ");
            switch (conditionType)
            {
                case ConditonType.小于:
                    strSql.Append("and P_Business_flow_form_order<@P_Business_flow_form_order ");
                    strSql.Append("order by P_Business_flow_form_order Desc ");
                    break;
                case ConditonType.大于:
                    strSql.Append("and P_Business_flow_form_order>@P_Business_flow_form_order ");
                    strSql.Append("order by P_Business_flow_form_order Asc ");
                    break;
            }

            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),            
                    new SqlParameter("@P_Business_flow_form_order", SqlDbType.Int,4)
			};
            parameters[0].Value = businessFlowCode;          
            parameters[1].Value = orderBy;
 
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
        /// 根据业务流程Guid，获取排序列值最大的一条记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow_form GetMaxOrderModel(Guid businessFlowCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 P_Business_flow_form_id,P_Business_flow_form_code,P_Business_flow_code,F_Form_code,P_Business_flow_form_order,P_Business_flow_form_person,P_Business_flow_form_isDefault,P_Business_flow_form_state,P_Business_flow_form_status,P_Business_flow_form_isdelete,P_Business_flow_form_creator,P_Business_flow_form_createTime from P_Business_flow_form ");
            strSql.Append("where P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("order by P_Business_flow_form_order Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;

            CommonService.Model.FlowManager.P_Business_flow_form model = new CommonService.Model.FlowManager.P_Business_flow_form();
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
        /// 根据业务流程Guid获取所有关联表单数据
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetBusinessFlowForms(Guid businessFlowCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BFF.P_Business_flow_form_id,BFF.P_Business_flow_form_code,BFF.P_Business_flow_code,BFF.F_Form_code,BFF.P_Business_flow_form_order,BFF.P_Business_flow_form_person,BFF.P_Business_flow_form_isDefault,BFF.P_Business_flow_form_state,BFF.P_Business_flow_form_status,BFF.P_Business_flow_form_isdelete,BFF.P_Business_flow_form_creator,BFF.P_Business_flow_form_createTime,BFF.P_Business_flow_form_isPlan,");
            strSql.Append("F.F_Form_chineseName As F_Form_chineseName, ");
            strSql.Append("cu.C_Userinfo_name as P_Business_flow_form_person_name, ");

            strSql.Append("PP.F_FormPropertyValue_value as P_Business_flow_planStartTime   ");
         

            strSql.Append("from P_Business_flow_form AS BFF WITH(NOLOCK) ");
            strSql.Append("left join F_Form AS F WITH(NOLOCK) on BFF.F_Form_code=F.F_Form_code ");
            strSql.Append("left join C_Userinfo as cu on BFF.P_Business_flow_form_person=cu.C_Userinfo_code ");

            strSql.Append("left join F_FormPropertyValue as PP  on BFF.P_Business_flow_form_code=PP.F_FormPropertyValue_BusinessFlowFormCode and (select count(*) from F_FormProperty where F_FormProperty_code=PP.F_FormPropertyValue_formProperty and  F_FormProperty_fieldName='planStartTime')>0 ");
            strSql.Append("where BFF.P_Business_flow_code=@P_Business_flow_code and BFF.P_Business_flow_form_isdelete=0 ");
            strSql.Append("order by BFF.P_Business_flow_form_order ASC ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据业务流程Guid获取有效关联表单数据(去掉已作废的表单)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetEffectiveBusinessFlowForms(Guid businessFlowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BFF.P_Business_flow_form_id,BFF.P_Business_flow_form_code,C_Userinfo_name as P_Business_flow_form_person_name,BFF.P_Business_flow_code,BFF.F_Form_code,BFF.P_Business_flow_form_order,BFF.P_Business_flow_form_person,BFF.P_Business_flow_form_isDefault,BFF.P_Business_flow_form_state,BFF.P_Business_flow_form_status,BFF.P_Business_flow_form_isdelete,BFF.P_Business_flow_form_creator,BFF.P_Business_flow_form_createTime,BFF.P_Business_flow_form_isPlan,");
            strSql.Append("F.F_Form_chineseName As F_Form_chineseName ");            
            strSql.Append("from P_Business_flow_form AS BFF WITH(NOLOCK) ");
            strSql.Append("left join F_Form AS F WITH(NOLOCK) on BFF.F_Form_code=F.F_Form_code,C_Userinfo U ");

            strSql.Append("where BFF.P_Business_flow_form_person=U.C_Userinfo_code and BFF.P_Business_flow_code=@P_Business_flow_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766  ");
            strSql.Append("order by BFF.P_Business_flow_form_order ASC ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据业务流程Guid获取所有关联表单数据(含有表单类型),只针对根级表单属性做处理
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetBusinessFlowFormsWithFormType(Guid businessFlowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BFF.P_Business_flow_form_id,BFF.P_Business_flow_form_code,BFF.P_Business_flow_code,BFF.F_Form_code,BFF.P_Business_flow_form_order,BFF.P_Business_flow_form_person,BFF.P_Business_flow_form_isDefault,BFF.P_Business_flow_form_state,BFF.P_Business_flow_form_status,BFF.P_Business_flow_form_isdelete,BFF.P_Business_flow_form_creator,BFF.P_Business_flow_form_createTime,");
            strSql.Append("F.F_Form_chineseName As F_Form_chineseName,");
            strSql.Append("case ");
            strSql.Append("when exists(select 1 from F_FormProperty As FP WITH(NOLOCK) where FP.F_FormProperty_form = BFF.F_Form_code and FP.F_FormProperty_isDelete=0 and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and FP.F_FormProperty_uiType=208) then 2 ");
            strSql.Append("when exists(select 1 from F_FormProperty As FP WITH(NOLOCK) where FP.F_FormProperty_form = BFF.F_Form_code and FP.F_FormProperty_isDelete=0 and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and FP.F_FormProperty_uiType=527) then 3 ");
            strSql.Append("when exists(select 1 from F_FormProperty As FP WITH(NOLOCK) where FP.F_FormProperty_form = BFF.F_Form_code and FP.F_FormProperty_isDelete=0 and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and FP.F_FormProperty_uiType=207) then 4 ");
            strSql.Append("else 1 ");
            strSql.Append("end as P_Business_flow_form_type,dbo.getResponsiblePersonByBusinessFlowFormCode(BFF.P_Business_flow_form_code) as ResponsiblePersonGuids ");
            strSql.Append("from P_Business_flow_form AS BFF WITH(NOLOCK) ");
            strSql.Append("left join F_Form AS F WITH(NOLOCK) on BFF.F_Form_code=F.F_Form_code ");
            strSql.Append("where BFF.P_Business_flow_code=@P_Business_flow_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 ");
            strSql.Append("order by BFF.P_Business_flow_form_order ASC ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 根据业务流程Guid获取所有关联表单数据(仅为业务流程关联表单表)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public DataSet OnlyGetBusinessFlowForms(Guid businessFlowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BFF.P_Business_flow_form_id,BFF.P_Business_flow_form_code,BFF.P_Business_flow_code,BFF.F_Form_code,BFF.P_Business_flow_form_order,BFF.P_Business_flow_form_person,BFF.P_Business_flow_form_isDefault,BFF.P_Business_flow_form_state,BFF.P_Business_flow_form_status,BFF.P_Business_flow_form_isdelete,BFF.P_Business_flow_form_creator,BFF.P_Business_flow_form_createTime ");          
            strSql.Append("from P_Business_flow_form AS BFF WITH(NOLOCK) ");
            strSql.Append("where BFF.P_Business_flow_form_isdelete=0 ");
            strSql.Append("and BFF.P_Business_flow_code=@P_Business_flow_code and BFF.P_Business_flow_form_status<>766 ");
      
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FlowManager.P_Business_flow_form DataRowToModel(DataRow row)
		{
            CommonService.Model.FlowManager.P_Business_flow_form model = new CommonService.Model.FlowManager.P_Business_flow_form();
			if (row != null)
			{
				if(row["P_Business_flow_form_id"]!=null && row["P_Business_flow_form_id"].ToString()!="")
				{
					model.P_Business_flow_form_id=int.Parse(row["P_Business_flow_form_id"].ToString());
				}
                if (row["P_Business_flow_form_code"] != null && row["P_Business_flow_form_code"].ToString() != "")
                {
                    model.P_Business_flow_form_code = new Guid(row["P_Business_flow_form_code"].ToString());
                }
				if(row["P_Business_flow_code"]!=null && row["P_Business_flow_code"].ToString()!="")
				{
					model.P_Business_flow_code= new Guid(row["P_Business_flow_code"].ToString());
				}
				if(row["F_Form_code"]!=null && row["F_Form_code"].ToString()!="")
				{
					model.F_Form_code= new Guid(row["F_Form_code"].ToString());
				}
                if (row["P_Business_flow_form_order"] != null && row["P_Business_flow_form_order"].ToString() != "")
                {
                    model.P_Business_flow_form_order = int.Parse(row["P_Business_flow_form_order"].ToString());
                }
                if (row["P_Business_flow_form_person"] != null && row["P_Business_flow_form_person"].ToString() != "")
                {
                    model.P_Business_flow_form_person = new Guid(row["P_Business_flow_form_person"].ToString());
                }
                if (row["P_Business_flow_form_isDefault"] != null && row["P_Business_flow_form_isDefault"].ToString() != "")
                {
                    model.P_Business_flow_form_isDefault = int.Parse(row["P_Business_flow_form_isDefault"].ToString());
                }
                if (row["P_Business_flow_form_state"] != null && row["P_Business_flow_form_state"].ToString() != "")
                {
                    model.P_Business_flow_form_state = int.Parse(row["P_Business_flow_form_state"].ToString());
                }
                if (row["P_Business_flow_form_status"] != null && row["P_Business_flow_form_status"].ToString() != "")
                {
                    model.P_Business_flow_form_status = int.Parse(row["P_Business_flow_form_status"].ToString());
                }
                //协办律师名称(虚拟属性)检查是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_flow_form_person_name"))
                {
                    if (row["P_Business_flow_form_person_name"] != null)
                    {
                        model.P_Business_flow_form_person_name = row["P_Business_flow_form_person_name"].ToString();
                    }
                }
				if(row["P_Business_flow_form_isdelete"]!=null && row["P_Business_flow_form_isdelete"].ToString()!="")
				{
					model.P_Business_flow_form_isdelete=int.Parse(row["P_Business_flow_form_isdelete"].ToString());
				}
				if(row["P_Business_flow_form_creator"]!=null && row["P_Business_flow_form_creator"].ToString()!="")
				{
					model.P_Business_flow_form_creator= new Guid(row["P_Business_flow_form_creator"].ToString());
				}
				if(row["P_Business_flow_form_createTime"]!=null && row["P_Business_flow_form_createTime"].ToString()!="")
				{
					model.P_Business_flow_form_createTime=DateTime.Parse(row["P_Business_flow_form_createTime"].ToString());
				}
                if (row.Table.Columns.Contains("P_Business_flow_planStartTime")){
                    if (row["P_Business_flow_planStartTime"] != null && row["P_Business_flow_planStartTime"].ToString()!="")
                    {                     
                        model.P_Business_flow_planStartTime=Convert.ToDateTime(row["P_Business_flow_planStartTime"]);
                    }
                }
                if (row.Table.Columns.Contains("P_Business_flow_planEndTime"))
                {
                    if (row["P_Business_flow_planEndTime"] != null && row["P_Business_flow_planEndTime"].ToString() != "")
                    {
                        model.P_Business_flow_planEndTime = Convert.ToDateTime(row["P_Business_flow_planEndTime"]);
                    }
                }
                //表单中文名称(虚拟属性)检查是否存在于列集合中
                if (row.Table.Columns.Contains("F_Form_chineseName"))
                {
                    if (row["F_Form_chineseName"] != null)
                    {
                        model.F_Form_chineseName = row["F_Form_chineseName"].ToString();
                    }
                }
                //表单类型(虚拟属性)检查是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_flow_form_type"))
                {
                    if (row["P_Business_flow_form_type"] != null)
                    {
                        model.P_Business_flow_form_type = Convert.ToInt32(row["P_Business_flow_form_type"].ToString());
                    }
                }
                //单一复合属性Guid(虚拟属性)检查是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_flow_form_propertyCode"))
                {
                    if (row["P_Business_flow_form_propertyCode"] != null && row["P_Business_flow_form_propertyCode"]!="")
                    {
                        model.P_Business_flow_form_propertyCode = new Guid(row["P_Business_flow_form_propertyCode"].ToString());
                    }
                }

                //表单负责人Guid串(虚拟属性)检查是否存在于列集合中
                if (row.Table.Columns.Contains("ResponsiblePersonGuids"))
                {
                    if (row["ResponsiblePersonGuids"] != null)
                    {
                        model.ResponsiblePersonGuids = row["ResponsiblePersonGuids"].ToString();
                    }
                }
                //此字段(是否计划设定)并非虚拟属性，这里是为了防止某些sql语句中漏掉此字段的查询时，会出错
                if (row.Table.Columns.Contains("P_Business_flow_form_isPlan"))
                {
                    if (row["P_Business_flow_form_isPlan"] != null && row["P_Business_flow_form_isPlan"].ToString() != "")
                    {
                        if ((row["P_Business_flow_form_isPlan"].ToString() == "1") || (row["P_Business_flow_form_isPlan"].ToString().ToLower() == "true"))
                        {
                            model.P_Business_flow_form_isPlan = true;
                        }
                        else
                        {
                            model.P_Business_flow_form_isPlan = false;
                        }
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
            strSql.Append("select P_Business_flow_form_id,P_Business_flow_form_code,P_Business_flow_code,F_Form_code,P_Business_flow_form_person,P_Business_flow_form_isDefault,P_Business_flow_form_state,P_Business_flow_form_status,P_Business_flow_form_isdelete,P_Business_flow_form_creator,P_Business_flow_form_createTime ");
			strSql.Append(" FROM P_Business_flow_form ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 根据负责人获得数据列表
        /// </summary>
        public DataSet GetListByPerson(Guid P_Business_flow_form_person)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Business_flow_form_id,P_Business_flow_form_code,P_Business_flow_code,F_Form_code,P_Business_flow_form_order,P_Business_flow_form_person,P_Business_flow_form_isDefault,P_Business_flow_form_state,P_Business_flow_form_status,P_Business_flow_form_isdelete,P_Business_flow_form_creator,P_Business_flow_form_createTime,P_Business_flow_form_isPlan ");
            strSql.Append(" FROM P_Business_flow_form ");
            strSql.Append(" where P_Business_flow_form_isdelete=0 and P_Business_flow_form_person=@P_Business_flow_form_person "); 
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = P_Business_flow_form_person;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据负责人获得数据列表(关联业务流程状态为“未开始”和“正在进行”)
        /// </summary>
        public DataSet GetListByPersonAndBusinessFlowState(Guid P_Business_flow_form_person)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Business_flow_form_id,P_Business_flow_form_code,P_Business_flow_code,F_Form_code,P_Business_flow_form_order,P_Business_flow_form_person,P_Business_flow_form_isDefault,P_Business_flow_form_state,P_Business_flow_form_status,P_Business_flow_form_isdelete,P_Business_flow_form_creator,P_Business_flow_form_createTime,P_Business_flow_form_isPlan ");
            strSql.Append(" FROM P_Business_flow_form as BFF");
            strSql.Append(" where BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_person=@P_Business_flow_form_person ");
            strSql.Append("and exists(select top 1 * from P_Business_flow as BF where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and (BF.P_Business_state=199 or BF.P_Business_state=200)) ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = P_Business_flow_form_person;
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
            strSql.Append(" P_Business_flow_form_id,P_Business_flow_code,F_Form_code,P_Business_flow_form_person,P_Business_flow_form_isDefault,P_Business_flow_form_state,P_Business_flow_form_status,P_Business_flow_form_isdelete,P_Business_flow_form_creator,P_Business_flow_form_createTime ");
			strSql.Append(" FROM P_Business_flow_form ");
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
		public int GetRecordCount(CommonService.Model.FlowManager.P_Business_flow_form model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM P_Business_flow_form ");
            strSql.Append(" where 1=1 and P_Business_flow_form_isdelete=0 ");
            if (model != null)
            {
                if (model.P_Business_flow_code != null && model.P_Business_flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Business_flow_code=@P_Business_flow_code");
                }
                if (model.F_Form_code != null && model.F_Form_code.ToString() != "")
                {
                    strSql.Append(" and F_Form_code=@F_Form_code");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.P_Business_flow_code;
            parameters[1].Value = model.F_Form_code;
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
		public DataSet GetListByPage(CommonService.Model.FlowManager.P_Business_flow_form model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.P_Business_flow_form_id desc");
			}
            strSql.Append(")AS Row, T.*  from P_Business_flow_form T ");
            strSql.Append(" where 1=1 and P_Business_flow_form_isdelete=0 ");
            if (model != null)
            {
                if (model.P_Business_flow_code != null && model.P_Business_flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Business_flow_code=@P_Business_flow_code");
                }
                if (model.F_Form_code != null && model.F_Form_code.ToString() != "")
                {
                    strSql.Append(" and F_Form_code=@F_Form_code");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.P_Business_flow_code;
            parameters[1].Value = model.F_Form_code;
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
			parameters[0].Value = "P_Business_flow_form";
			parameters[1].Value = "P_Business_flow_form_id";
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

