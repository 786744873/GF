using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.CustomerForm
{
    /// <summary>
    /// 数据访问类:表单审核表
    /// 作者：贺太玉
    /// 日期：2015/06/06
    /// </summary>
    public partial class F_FormCheck
    {
        public F_FormCheck()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("F_FormCheck_id", "F_FormCheck");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_FormCheck_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from F_FormCheck");
            strSql.Append(" where F_FormCheck_id=@F_FormCheck_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_id", SqlDbType.Int,4)
			};
            parameters[0].Value = F_FormCheck_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into F_FormCheck(");
            strSql.Append("F_FormCheck_code,F_FormCheck_business_flow_form_code,F_FormCheck_isFirstSubmit,F_FormCheck_submitInfo,F_FormCheck_checkBusinessCode,F_FormCheck_checkPerson,F_FormCheck_checkDate,F_FormCheck_state,F_FormCheck_content,F_FormCheck_isDelete,F_FormCheck_creator,F_FormCheck_createTime)");
            strSql.Append(" values (");
            strSql.Append("@F_FormCheck_code,@F_FormCheck_business_flow_form_code,@F_FormCheck_isFirstSubmit,@F_FormCheck_submitInfo,@F_FormCheck_checkBusinessCode,@F_FormCheck_checkPerson,@F_FormCheck_checkDate,@F_FormCheck_state,@F_FormCheck_content,@F_FormCheck_isDelete,@F_FormCheck_creator,@F_FormCheck_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_business_flow_form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_isFirstSubmit", SqlDbType.Bit,1),
					new SqlParameter("@F_FormCheck_submitInfo", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormCheck_checkBusinessCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_checkPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_checkDate", SqlDbType.DateTime),
					new SqlParameter("@F_FormCheck_state", SqlDbType.Int,4),
					new SqlParameter("@F_FormCheck_content", SqlDbType.NVarChar,500),
					new SqlParameter("@F_FormCheck_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_FormCheck_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.F_FormCheck_code;
            parameters[1].Value = model.F_FormCheck_business_flow_form_code;
            parameters[2].Value = model.F_FormCheck_isFirstSubmit;
            parameters[3].Value = model.F_FormCheck_submitInfo;
            parameters[4].Value = model.F_FormCheck_checkBusinessCode;
            parameters[5].Value = model.F_FormCheck_checkPerson;
            parameters[6].Value = model.F_FormCheck_checkDate;
            parameters[7].Value = model.F_FormCheck_state;
            parameters[8].Value = model.F_FormCheck_content;
            parameters[9].Value = model.F_FormCheck_isDelete;
            parameters[10].Value = model.F_FormCheck_creator;
            parameters[11].Value = model.F_FormCheck_createTime;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormCheck set ");
            strSql.Append("F_FormCheck_code=@F_FormCheck_code,");
            strSql.Append("F_FormCheck_business_flow_form_code=@F_FormCheck_business_flow_form_code,");
            strSql.Append("F_FormCheck_isFirstSubmit=@F_FormCheck_isFirstSubmit,");
            strSql.Append("F_FormCheck_submitInfo=@F_FormCheck_submitInfo,");
            strSql.Append("F_FormCheck_checkBusinessCode=@F_FormCheck_checkBusinessCode,");
            strSql.Append("F_FormCheck_checkPerson=@F_FormCheck_checkPerson,");
            strSql.Append("F_FormCheck_checkDate=@F_FormCheck_checkDate,");
            strSql.Append("F_FormCheck_state=@F_FormCheck_state,");
            strSql.Append("F_FormCheck_content=@F_FormCheck_content,");
            strSql.Append("F_FormCheck_isDelete=@F_FormCheck_isDelete,");
            strSql.Append("F_FormCheck_creator=@F_FormCheck_creator,");
            strSql.Append("F_FormCheck_createTime=@F_FormCheck_createTime");
            strSql.Append(" where F_FormCheck_id=@F_FormCheck_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_business_flow_form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_isFirstSubmit", SqlDbType.Bit,1),
					new SqlParameter("@F_FormCheck_submitInfo", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormCheck_checkBusinessCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_checkPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_checkDate", SqlDbType.DateTime),
					new SqlParameter("@F_FormCheck_state", SqlDbType.Int,4),
					new SqlParameter("@F_FormCheck_content", SqlDbType.NVarChar,500),
					new SqlParameter("@F_FormCheck_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_FormCheck_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormCheck_createTime", SqlDbType.DateTime),
					new SqlParameter("@F_FormCheck_id", SqlDbType.Int,4)};
            parameters[0].Value = model.F_FormCheck_code;
            parameters[1].Value = model.F_FormCheck_business_flow_form_code;
            parameters[2].Value = model.F_FormCheck_isFirstSubmit;
            parameters[3].Value = model.F_FormCheck_submitInfo;
            parameters[4].Value = model.F_FormCheck_checkBusinessCode;
            parameters[5].Value = model.F_FormCheck_checkPerson;
            parameters[6].Value = model.F_FormCheck_checkDate;
            parameters[7].Value = model.F_FormCheck_state;
            parameters[8].Value = model.F_FormCheck_content;
            parameters[9].Value = model.F_FormCheck_isDelete;
            parameters[10].Value = model.F_FormCheck_creator;
            parameters[11].Value = model.F_FormCheck_createTime;
            parameters[12].Value = model.F_FormCheck_id;

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
        public bool Delete(Guid F_FormCheck_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormCheck set F_FormCheck_isDelete =1 ");
            strSql.Append(" where F_FormCheck_code=@F_FormCheck_code");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_FormCheck_code;

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
        public bool DeleteList(string F_FormCheck_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from F_FormCheck ");
            strSql.Append(" where F_FormCheck_id in (" + F_FormCheck_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public CommonService.Model.CustomerForm.F_FormCheck GetModel(Guid F_FormCheck_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_FormCheck_id,F_FormCheck_code,F_FormCheck_business_flow_form_code,F_FormCheck_isFirstSubmit,F_FormCheck_submitInfo,F_FormCheck_checkBusinessCode,F_FormCheck_checkPerson,F_FormCheck_checkDate,F_FormCheck_state,F_FormCheck_content,F_FormCheck_isDelete,F_FormCheck_creator,F_FormCheck_createTime from F_FormCheck ");
            strSql.Append(" where F_FormCheck_code=@F_FormCheck_code");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_FormCheck_code;

            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
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
        public CommonService.Model.CustomerForm.F_FormCheck GetModelByFormCodeAndPersonAndCheckDate(Guid business_flow_form_code, Guid checkPerson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_FormCheck_id,F_FormCheck_code,F_FormCheck_business_flow_form_code,F_FormCheck_isFirstSubmit,F_FormCheck_submitInfo,F_FormCheck_checkBusinessCode,F_FormCheck_checkPerson,F_FormCheck_checkDate,F_FormCheck_state,F_FormCheck_content,F_FormCheck_isDelete,F_FormCheck_creator,F_FormCheck_createTime from F_FormCheck ");
            strSql.Append("where F_FormCheck_business_flow_form_code=@F_FormCheck_business_flow_form_code ");
            strSql.Append("and F_FormCheck_checkPerson=@F_FormCheck_checkPerson ");
            strSql.Append("and F_FormCheck_checkDate is null ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_business_flow_form_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormCheck_checkPerson",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = business_flow_form_code;
            parameters[1].Value = checkPerson;

            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
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
        /// 根据业务流程表单关联Guid，获取最近表单提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormCheck GetRecentySubmitCheck(Guid businessFlowFormCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_FormCheck_id,F_FormCheck_code,F_FormCheck_business_flow_form_code,F_FormCheck_isFirstSubmit,F_FormCheck_submitInfo,F_FormCheck_checkBusinessCode,F_FormCheck_checkPerson,F_FormCheck_checkDate,F_FormCheck_state,F_FormCheck_content,F_FormCheck_isDelete,F_FormCheck_creator,F_FormCheck_createTime from F_FormCheck ");
            strSql.Append(" where F_FormCheck_business_flow_form_code=@F_FormCheck_business_flow_form_code and F_FormCheck_isDelete=0 and F_FormCheck_isFirstSubmit=1 ");
            strSql.Append("order by F_FormCheck_createTime Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowFormCode;

            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
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
        /// 根据业务流程表单关联Guid，获取最近的一条审核记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单Guid</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormCheck GetMaxTimeModelByBusinessFlowFormCode(Guid businessFlowFormCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 F_FormCheck_id,F_FormCheck_code,F_FormCheck_business_flow_form_code,F_FormCheck_isFirstSubmit,F_FormCheck_submitInfo,F_FormCheck_checkBusinessCode,F_FormCheck_checkPerson,F_FormCheck_checkDate,F_FormCheck_state,F_FormCheck_content,F_FormCheck_isDelete,F_FormCheck_creator,F_FormCheck_createTime ");
            strSql.Append("from F_FormCheck ");
            strSql.Append("where F_FormCheck_business_flow_form_code=@F_FormCheck_business_flow_form_code ");
            strSql.Append("and F_FormCheck_isDelete=0 ");
            strSql.Append("order by F_FormCheck_id Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowFormCode;

            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
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
        /// 根据审核当前业务Guid和审核人Guid获得一条记录
        /// </summary>
        /// <param name="checkBusinessCode">审核当前业务Guid</param>
        /// <param name="checkPerson">审核人Guid</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormCheck GetModelByCheckBusinessCodeAndCheckPerson(Guid checkBusinessCode, Guid checkPerson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 F_FormCheck_id,F_FormCheck_code,F_FormCheck_business_flow_form_code,F_FormCheck_isFirstSubmit,F_FormCheck_submitInfo,F_FormCheck_checkBusinessCode,F_FormCheck_checkPerson,F_FormCheck_checkDate,F_FormCheck_state,F_FormCheck_content,F_FormCheck_isDelete,F_FormCheck_creator,F_FormCheck_createTime ");
            strSql.Append("from F_FormCheck ");
            strSql.Append("where F_FormCheck_checkBusinessCode=@F_FormCheck_checkBusinessCode ");
            strSql.Append(" and F_FormCheck_checkPerson=@F_FormCheck_checkPerson ");
            strSql.Append(" and F_FormCheck_isDelete=0 ");
            strSql.Append(" and F_FormCheck_state=315 ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_checkBusinessCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormCheck_checkPerson",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = checkBusinessCode;
            parameters[1].Value = checkPerson;

            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
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
        /// 根据业务流程表单关联Guid，获取首次表单提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public DataSet GetFirstTimeFormCheckRecord(Guid businessFlowFormCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FC.F_FormCheck_id,FC.F_FormCheck_code,FC.F_FormCheck_business_flow_form_code,FC.F_FormCheck_isFirstSubmit,FC.F_FormCheck_submitInfo,FC.F_FormCheck_checkBusinessCode,FC.F_FormCheck_checkPerson,");
            strSql.Append("FC.F_FormCheck_checkDate,FC.F_FormCheck_state,FC.F_FormCheck_content,FC.F_FormCheck_isDelete,FC.F_FormCheck_creator,FC.F_FormCheck_createTime,");
            strSql.Append("U.C_Userinfo_name As F_FormCheck_creator_name,");
            strSql.Append("(select F_Form_chineseName from F_Form where F_Form_code=(select top 1 F_Form_code from P_Business_flow_form where P_Business_flow_form_code=FC.F_FormCheck_business_flow_form_code))As F_Form_chineseName ");
            strSql.Append("from F_FormCheck As FC with(nolock) ");
            strSql.Append("left join C_Userinfo As u with(nolock) on FC.F_FormCheck_creator=U.C_Userinfo_code ");

            strSql.Append("where 1=1  ");

            strSql.Append(" and FC.F_FormCheck_business_flow_form_code=@F_FormCheck_business_flow_form_code ");

            strSql.Append("and FC.F_FormCheck_isDelete=0 ");
            strSql.Append("and FC.F_FormCheck_isFirstSubmit=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowFormCode;

            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return ds;
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取审核记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public DataSet GetFormCheckRecord(Guid businessFlowFormCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FC.F_FormCheck_id,FC.F_FormCheck_code,FC.F_FormCheck_business_flow_form_code,FC.F_FormCheck_isFirstSubmit,FC.F_FormCheck_submitInfo,FC.F_FormCheck_checkBusinessCode,FC.F_FormCheck_checkPerson,");
            strSql.Append("FC.F_FormCheck_checkDate,FC.F_FormCheck_state,FC.F_FormCheck_content,FC.F_FormCheck_isDelete,FC.F_FormCheck_creator,FC.F_FormCheck_createTime,");
            strSql.Append("U.C_Userinfo_name As F_FormCheck_creator_name,");
            strSql.Append("(select F_Form_chineseName from F_Form where F_Form_code=(select top 1 F_Form_code from P_Business_flow_form where P_Business_flow_form_code=FC.F_FormCheck_business_flow_form_code))As F_Form_chineseName ");
            strSql.Append("from F_FormCheck As FC with(nolock) ");
            strSql.Append("left join C_Userinfo As u with(nolock) on FC.F_FormCheck_creator=U.C_Userinfo_code ");

            strSql.Append("where 1=1  ");

            strSql.Append(" and FC.F_FormCheck_business_flow_form_code=@F_FormCheck_business_flow_form_code ");

            strSql.Append("and FC.F_FormCheck_isDelete=0 ");
            strSql.Append("and FC.F_FormCheck_state<>315 "); //不要未审核的记录
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowFormCode;

            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return ds;
        }

        /// <summary>
        /// 根据案件Guid或者商机Guid，获取表单尚未审核记录
        /// </summary>
        /// <param name="fkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        public DataSet GetUnCheckRecordByFkCode(Guid fkCode)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * ");
            strSql.Append("from F_FormCheck ");
            strSql.Append("where F_FormCheck_checkBusinessCode=@F_FormCheck_checkBusinessCode ");
            strSql.Append("and F_FormCheck_isDelete=0 and F_FormCheck_state=315 ");
            strSql.Append("order by F_FormCheck_id Asc ");

            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_checkBusinessCode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = fkCode;

            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return ds;
        }


        /// <summary>
        /// 根据业务流程Guid，获取全部表单提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetFirstTimeFormCheckRecordForflowcode(Guid businessCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FC.F_FormCheck_id,FC.F_FormCheck_code,FC.F_FormCheck_business_flow_form_code,FC.F_FormCheck_isFirstSubmit,FC.F_FormCheck_submitInfo,FC.F_FormCheck_checkBusinessCode,FC.F_FormCheck_checkPerson,");
            strSql.Append("FC.F_FormCheck_checkDate,FC.F_FormCheck_state,FC.F_FormCheck_content,FC.F_FormCheck_isDelete,FC.F_FormCheck_creator,FC.F_FormCheck_createTime,");
            strSql.Append("U.C_Userinfo_name As F_FormCheck_creator_name,");

            strSql.Append("(select F_Form_chineseName from F_Form where F_Form_code=(select top 1 F_Form_code from P_Business_flow_form where P_Business_flow_form_code=FC.F_FormCheck_business_flow_form_code))As F_Form_chineseName, ");
            strSql.Append("(select C_Userinfo_name from C_Userinfo as CU where CU.C_Userinfo_code=FC.F_FormCheck_checkPerson) as F_FormCheck_checkPerson_name ");

            strSql.Append("from F_FormCheck As FC with(nolock),C_Userinfo As u with(nolock),P_Business_flow_form As pp with(nolock) ");
            strSql.Append("where 1=1  ");
            strSql.Append("and FC.F_FormCheck_creator=U.C_Userinfo_code ");
            strSql.Append("and FC.F_FormCheck_business_flow_form_code=pp.P_Business_flow_form_code ");
            strSql.Append("and FC.F_FormCheck_isDelete=0 ");
            strSql.Append("and FC.F_FormCheck_isFirstSubmit=1 ");
            strSql.Append("and pp.P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and pp.P_Business_flow_form_status<>766 ");
            strSql.Append("and pp.P_Business_flow_form_isdelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessCode;
            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return ds;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormCheck DataRowToModel(DataRow row)
        {
            CommonService.Model.CustomerForm.F_FormCheck model = new CommonService.Model.CustomerForm.F_FormCheck();
            if (row != null)
            {
                if (row["F_FormCheck_id"] != null && row["F_FormCheck_id"].ToString() != "")
                {
                    model.F_FormCheck_id = int.Parse(row["F_FormCheck_id"].ToString());
                }
                if (row["F_FormCheck_code"] != null && row["F_FormCheck_code"].ToString() != "")
                {
                    model.F_FormCheck_code = new Guid(row["F_FormCheck_code"].ToString());
                }
                if (row["F_FormCheck_business_flow_form_code"] != null && row["F_FormCheck_business_flow_form_code"].ToString() != "")
                {
                    model.F_FormCheck_business_flow_form_code = new Guid(row["F_FormCheck_business_flow_form_code"].ToString());
                }
                //判断关联业务流程表单名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("F_FormCheck_business_flow_form_name"))
                {
                    if (row["F_FormCheck_business_flow_form_name"] != null && row["F_FormCheck_business_flow_form_name"].ToString() != "")
                    {
                        model.F_FormCheck_business_flow_form_name = row["F_FormCheck_business_flow_form_name"].ToString();
                    }
                }
                if (row["F_FormCheck_isFirstSubmit"] != null && row["F_FormCheck_isFirstSubmit"].ToString() != "")
                {
                    if ((row["F_FormCheck_isFirstSubmit"].ToString() == "1") || (row["F_FormCheck_isFirstSubmit"].ToString().ToLower() == "true"))
                    {
                        model.F_FormCheck_isFirstSubmit = true;
                    }
                    else
                    {
                        model.F_FormCheck_isFirstSubmit = false;
                    }
                }
                if (row["F_FormCheck_submitInfo"] != null)
                {
                    model.F_FormCheck_submitInfo = row["F_FormCheck_submitInfo"].ToString();
                }
                if (row["F_FormCheck_checkBusinessCode"] != null && row["F_FormCheck_checkBusinessCode"].ToString() != "")
                {
                    model.F_FormCheck_checkBusinessCode = new Guid(row["F_FormCheck_checkBusinessCode"].ToString());
                }
                if (row["F_FormCheck_checkPerson"] != null && row["F_FormCheck_checkPerson"].ToString() != "")
                {
                    model.F_FormCheck_checkPerson = new Guid(row["F_FormCheck_checkPerson"].ToString());
                }
                //判断审核人名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("F_FormCheck_checkPerson_name"))
                {
                    if (row["F_FormCheck_checkPerson_name"] != null && row["F_FormCheck_checkPerson_name"].ToString() != "")
                    {
                        model.F_FormCheck_checkPerson_name = row["F_FormCheck_checkPerson_name"].ToString();
                    }
                }
                if (row["F_FormCheck_checkDate"] != null && row["F_FormCheck_checkDate"].ToString() != "")
                {
                    model.F_FormCheck_checkDate = DateTime.Parse(row["F_FormCheck_checkDate"].ToString());
                }
                if (row["F_FormCheck_state"] != null && row["F_FormCheck_state"].ToString() != "")
                {
                    model.F_FormCheck_state = int.Parse(row["F_FormCheck_state"].ToString());
                }
                if (row["F_FormCheck_content"] != null)
                {
                    model.F_FormCheck_content = row["F_FormCheck_content"].ToString();
                }
                if (row["F_FormCheck_isDelete"] != null && row["F_FormCheck_isDelete"].ToString() != "")
                {
                    if ((row["F_FormCheck_isDelete"].ToString() == "1") || (row["F_FormCheck_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.F_FormCheck_isDelete = true;
                    }
                    else
                    {
                        model.F_FormCheck_isDelete = false;
                    }
                }
                if (row["F_FormCheck_creator"] != null && row["F_FormCheck_creator"].ToString() != "")
                {
                    model.F_FormCheck_creator = new Guid(row["F_FormCheck_creator"].ToString());
                }
                // 创建人(提交人)名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("F_FormCheck_creator_name"))
                {
                    if (row["F_FormCheck_creator_name"] != null)
                    {
                        model.F_FormCheck_creator_name = row["F_FormCheck_creator_name"].ToString();
                    }
                }
                if (row["F_FormCheck_createTime"] != null && row["F_FormCheck_createTime"].ToString() != "")
                {
                    model.F_FormCheck_createTime = DateTime.Parse(row["F_FormCheck_createTime"].ToString());
                }
                if (row.Table.Columns.Contains("F_Form_chineseName"))
                {
                    ///
                    if (row["F_Form_chineseName"] != null && row["F_Form_chineseName"].ToString() != "")
                    {
                        model.F_Form_chineseName = row["F_Form_chineseName"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_FormCheck_id,F_FormCheck_code,F_FormCheck_business_flow_form_code,F_FormCheck_isFirstSubmit,F_FormCheck_submitInfo,F_FormCheck_checkBusinessCode,F_FormCheck_checkPerson,F_FormCheck_checkDate,F_FormCheck_state,F_FormCheck_content,F_FormCheck_isDelete,F_FormCheck_creator,F_FormCheck_createTime ");
            strSql.Append(" FROM F_FormCheck ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据业务流程表单关联GUID，获得数据列表
        /// </summary>
        public DataSet GetListByBusinessflowformCode(Guid F_FormCheck_business_flow_form_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FC.F_FormCheck_id,FC.F_FormCheck_code,FC.F_FormCheck_business_flow_form_code,FC.F_FormCheck_isFirstSubmit,FC.F_FormCheck_submitInfo,FC.F_FormCheck_checkBusinessCode,FC.F_FormCheck_checkPerson,FC.F_FormCheck_checkDate,");
            strSql.Append("FC.F_FormCheck_state,FC.F_FormCheck_content,FC.F_FormCheck_isDelete,FC.F_FormCheck_creator,FC.F_FormCheck_createTime,U.C_Userinfo_name as 'F_FormCheck_checkPerson_name',U1.C_Userinfo_name as 'F_FormCheck_creator_name',F.F_Form_chineseName as 'F_FormCheck_business_flow_form_name' ");
            strSql.Append(" FROM F_FormCheck as FC left join C_Userinfo as U on FC.F_FormCheck_checkPerson=U.C_Userinfo_code ");
            strSql.Append("left join C_Userinfo as U1 on FC.F_FormCheck_creator=U1.C_Userinfo_code ");
            strSql.Append("left join P_Business_flow_form as BFF on FC.F_FormCheck_business_flow_form_code=BFF.P_Business_flow_form_code ");
            strSql.Append("left join F_Form as F on BFF.F_Form_code=F.F_Form_code ");
            strSql.Append("where FC.F_FormCheck_business_flow_form_code=@F_FormCheck_business_flow_form_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormCheck_business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_FormCheck_business_flow_form_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" F_FormCheck_id,F_FormCheck_code,F_FormCheck_business_flow_form_code,F_FormCheck_isFirstSubmit,F_FormCheck_submitInfo,F_FormCheck_checkBusinessCode,F_FormCheck_checkPerson,F_FormCheck_checkDate,F_FormCheck_state,F_FormCheck_content,F_FormCheck_isDelete,F_FormCheck_creator,F_FormCheck_createTime ");
            strSql.Append(" FROM F_FormCheck ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM F_FormCheck ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.F_FormCheck_id desc");
            }
            strSql.Append(")AS Row, T.*  from F_FormCheck T ");
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
            parameters[0].Value = "F_FormCheck";
            parameters[1].Value = "F_FormCheck_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  App专用

        /// <summary>
        /// 获取最后一次提交的审核列表
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public DataSet AppGetCheckList(Guid guid)
        {
            string sql = "select *,(select C_Userinfo_name from C_Userinfo where C_Userinfo_code=F_FormCheck_creator) as F_FormCheck_creator_name,(select C_userinfo_name from C_Userinfo where C_Userinfo_code=F_FormCheck_checkPerson) as F_FormCheck_checkPerson_name from F_FormCheck a where ";
            sql += " a.F_FormCheck_business_flow_form_code=@guid and a.F_FormCheck_isDelete=0";
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = guid ;
            return DbHelperSQL.Query(sql, parameters);
        }
        #endregion
    }
}
