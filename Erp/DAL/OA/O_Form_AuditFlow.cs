using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.OA
{
    /// <summary>
    /// 数据访问类:表单审批流程表
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_Form_AuditFlow
    {
        public O_Form_AuditFlow()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("O_Form_AuditFlow_id", "O_Form_AuditFlow");
        }

        /// <summary>
        /// 根据表单Guid，获取表单审批流程最大顺序号
        /// </summary>
        /// <param name="oFormCode">表单Guid</param>
        /// <returns></returns>
        public int GetMaxOrder(Guid oFormCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(O_Form_AuditFlow_flowSet_order) from O_Form_AuditFlow ");
            strSql.Append(" where O_Form_AuditFlow_o_form=@O_Form_AuditFlow_o_form and O_Form_AuditFlow_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditFlow_o_form", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = oFormCode;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            } 
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Form_AuditFlow_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Form_AuditFlow");
            strSql.Append(" where O_Form_AuditFlow_id=@O_Form_AuditFlow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditFlow_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Form_AuditFlow_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Form_AuditFlow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Form_AuditFlow(");
            strSql.Append("O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime)");
            strSql.Append(" values (");
            strSql.Append("@O_Form_AuditFlow_code,@O_Form_AuditFlow_o_form,@O_Form_AuditFlow_flowSet,@O_Form_AuditFlow_flowSet_name,@O_Form_AuditFlow_flowSet_order,@O_Form_AuditFlow_flowSet_auditType,@O_Form_AuditFlow_flowSet_rule,@O_Form_AuditFlow_auditStatus,@O_Form_AuditFlow_auditTime,@O_Form_AuditFlow_isDelete,@O_Form_AuditFlow_creator,@O_Form_AuditFlow_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditFlow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditFlow_o_form", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditFlow_flowSet", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditFlow_flowSet_name", SqlDbType.NVarChar,100),
					new SqlParameter("@O_Form_AuditFlow_flowSet_order", SqlDbType.Int,4),
					new SqlParameter("@O_Form_AuditFlow_flowSet_auditType", SqlDbType.Int,4),
					new SqlParameter("@O_Form_AuditFlow_flowSet_rule", SqlDbType.NVarChar,500),
					new SqlParameter("@O_Form_AuditFlow_auditStatus", SqlDbType.Int,4),
					new SqlParameter("@O_Form_AuditFlow_auditTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_AuditFlow_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Form_AuditFlow_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditFlow_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.O_Form_AuditFlow_code;
            parameters[1].Value = model.O_Form_AuditFlow_o_form;
            parameters[2].Value = model.O_Form_AuditFlow_flowSet;
            parameters[3].Value = model.O_Form_AuditFlow_flowSet_name;
            parameters[4].Value = model.O_Form_AuditFlow_flowSet_order;
            parameters[5].Value = model.O_Form_AuditFlow_flowSet_auditType;
            parameters[6].Value = model.O_Form_AuditFlow_flowSet_rule;
            parameters[7].Value = model.O_Form_AuditFlow_auditStatus;
            parameters[8].Value = model.O_Form_AuditFlow_auditTime;
            parameters[9].Value = model.O_Form_AuditFlow_isDelete;
            parameters[10].Value = model.O_Form_AuditFlow_creator;
            parameters[11].Value = model.O_Form_AuditFlow_createTime;

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
        public bool Update(CommonService.Model.OA.O_Form_AuditFlow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Form_AuditFlow set ");
            strSql.Append("O_Form_AuditFlow_o_form=@O_Form_AuditFlow_o_form,");
            strSql.Append("O_Form_AuditFlow_flowSet=@O_Form_AuditFlow_flowSet,");
            strSql.Append("O_Form_AuditFlow_flowSet_name=@O_Form_AuditFlow_flowSet_name,");
            strSql.Append("O_Form_AuditFlow_flowSet_order=@O_Form_AuditFlow_flowSet_order,");
            strSql.Append("O_Form_AuditFlow_flowSet_auditType=@O_Form_AuditFlow_flowSet_auditType,");
            strSql.Append("O_Form_AuditFlow_flowSet_rule=@O_Form_AuditFlow_flowSet_rule,");
            strSql.Append("O_Form_AuditFlow_auditStatus=@O_Form_AuditFlow_auditStatus,");
            strSql.Append("O_Form_AuditFlow_auditTime=@O_Form_AuditFlow_auditTime,");
            strSql.Append("O_Form_AuditFlow_isDelete=@O_Form_AuditFlow_isDelete,");
            strSql.Append("O_Form_AuditFlow_creator=@O_Form_AuditFlow_creator,");
            strSql.Append("O_Form_AuditFlow_createTime=@O_Form_AuditFlow_createTime");
            strSql.Append(" where O_Form_AuditFlow_code=@O_Form_AuditFlow_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditFlow_o_form", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditFlow_flowSet", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditFlow_flowSet_name", SqlDbType.NVarChar,100),
					new SqlParameter("@O_Form_AuditFlow_flowSet_order", SqlDbType.Int,4),
					new SqlParameter("@O_Form_AuditFlow_flowSet_auditType", SqlDbType.Int,4),
					new SqlParameter("@O_Form_AuditFlow_flowSet_rule", SqlDbType.NVarChar,500),
					new SqlParameter("@O_Form_AuditFlow_auditStatus", SqlDbType.Int,4),
					new SqlParameter("@O_Form_AuditFlow_auditTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_AuditFlow_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Form_AuditFlow_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditFlow_createTime", SqlDbType.DateTime),
	     			new SqlParameter("@O_Form_AuditFlow_code", SqlDbType.UniqueIdentifier,16),};
            parameters[0].Value = model.O_Form_AuditFlow_o_form;
            parameters[1].Value = model.O_Form_AuditFlow_flowSet;
            parameters[2].Value = model.O_Form_AuditFlow_flowSet_name;
            parameters[3].Value = model.O_Form_AuditFlow_flowSet_order;
            parameters[4].Value = model.O_Form_AuditFlow_flowSet_auditType;
            parameters[5].Value = model.O_Form_AuditFlow_flowSet_rule;
            parameters[6].Value = model.O_Form_AuditFlow_auditStatus;
            parameters[7].Value = model.O_Form_AuditFlow_auditTime;
            parameters[8].Value = model.O_Form_AuditFlow_isDelete;
            parameters[9].Value = model.O_Form_AuditFlow_creator;
            parameters[10].Value = model.O_Form_AuditFlow_createTime;
            parameters[11].Value = model.O_Form_AuditFlow_code;
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
        public bool Delete(Guid O_Form_AuditFlow_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Form_AuditFlow set O_Form_AuditFlow_isDelete = 1 ");
            strSql.Append(" where O_Form_AuditFlow_code=@O_Form_AuditFlow_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditFlow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Form_AuditFlow_code;

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
        /// 根据表单审批流程Guid，更改状态和审批时间
        /// </summary>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <param name="state">状态</param>
        /// <param name="time">审批时间</param>
        /// <returns></returns>
        public bool UpdateStateAndTime(Guid formAuditFlowCode,int state,DateTime time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Form_AuditFlow set ");
            strSql.Append("O_Form_AuditFlow_auditStatus = @O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime=@O_Form_AuditFlow_auditTime ");
            strSql.Append("where O_Form_AuditFlow_code=@O_Form_AuditFlow_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditFlow_auditStatus", SqlDbType.Int,4),
                    new SqlParameter("@O_Form_AuditFlow_auditTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_AuditFlow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = state;
            parameters[1].Value = time;
            parameters[2].Value = formAuditFlowCode;

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
        public bool DeleteList(string O_Form_AuditFlow_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Form_AuditFlow ");
            strSql.Append(" where O_Form_AuditFlow_id in (" + O_Form_AuditFlow_idlist + ")  ");
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
        public CommonService.Model.OA.O_Form_AuditFlow GetModel(Guid O_Form_AuditFlow_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Form_AuditFlow_id,O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime,B.O_Form_applyPerson As O_Form_applyPerson from O_Form_AuditFlow ");
            strSql.Append(" As A left join O_Form As B on A.O_Form_AuditFlow_o_form=B.O_Form_code where O_Form_AuditFlow_code=@O_Form_AuditFlow_code and O_Form_AuditFlow_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditFlow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Form_AuditFlow_code;

            CommonService.Model.OA.O_Form_AuditFlow model = new CommonService.Model.OA.O_Form_AuditFlow();
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
        /// 得到一个顺序最大的对象实体
        /// </summary>
        public int GetMaxOrderModel(Guid O_Form_AuditFlow_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  max(O_Form_AuditFlow_flowSet_order) from O_Form_AuditFlow ");
            strSql.Append(" where O_Form_AuditFlow_code=@O_Form_AuditFlow_code and O_Form_AuditFlow_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditFlow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Form_AuditFlow_code;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }

        }
        /// <summary>
        /// 通过流程预设guid获得数据信息
        /// </summary>
        public CommonService.Model.OA.O_Form_AuditFlow GetModelByAuditFlowcode(Guid flowCode,int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Form_AuditFlow_id,O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime,C.C_Userinfo_name As O_Form_AuditPerson_auditPersonname,D.C_Parameters_name As O_Form_AuditPerson_statusname,B.O_Form_AuditPerson_content As O_Form_AuditPerson_content,B.O_Form_AuditPerson_auditTime As O_Form_AuditPerson_auditTime,C.C_Userinfo_code As O_Form_AuditPerson_auditPerson,E.O_Form_code As O_Form_code,E.O_Form_applyPerson As O_Form_applyPerson,F.C_Messages_id As C_Messages_id ");
            strSql.Append(" FROM O_Form_AuditFlow As A left join O_Form_AuditPerson As B  on A.O_Form_AuditFlow_code=B.O_Form_AuditPerson_formAuditFlow left join C_Userinfo As C on C.C_Userinfo_code=B.O_Form_AuditPerson_auditPerson left join C_Parameters As D on D.C_Parameters_id=B.O_Form_AuditPerson_status left join O_Form As E on E.O_Form_code=A.O_Form_AuditFlow_o_form left join C_Messages As F on A.O_Form_AuditFlow_code=F.C_Messages_link where O_Form_AuditFlow_code=@O_Form_AuditFlow_code and O_Form_AuditFlow_isDelete=0 and B.O_Form_AuditPerson_isDelete=0 and F.C_Messages_isRead=0 ");
            if (type == 1)
            {
                strSql.Append(" and O_Form_AuditPerson_status=539");
            }
            else
            {
                strSql.Append(" and (O_Form_AuditPerson_status=540 or O_Form_AuditPerson_status=541)"); 
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditFlow_code", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = flowCode;
            CommonService.Model.OA.O_Form_AuditFlow model = new CommonService.Model.OA.O_Form_AuditFlow();
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
        public CommonService.Model.OA.O_Form_AuditFlow DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Form_AuditFlow model = new CommonService.Model.OA.O_Form_AuditFlow();
            if (row != null)
            {
                if (row["O_Form_AuditFlow_id"] != null && row["O_Form_AuditFlow_id"].ToString() != "")
                {
                    model.O_Form_AuditFlow_id = int.Parse(row["O_Form_AuditFlow_id"].ToString());
                }
                if (row["O_Form_AuditFlow_code"] != null && row["O_Form_AuditFlow_code"].ToString() != "")
                {
                    model.O_Form_AuditFlow_code = new Guid(row["O_Form_AuditFlow_code"].ToString());
                }
                if (row["O_Form_AuditFlow_o_form"] != null && row["O_Form_AuditFlow_o_form"].ToString() != "")
                {
                    model.O_Form_AuditFlow_o_form = new Guid(row["O_Form_AuditFlow_o_form"].ToString());
                }
                if (row["O_Form_AuditFlow_flowSet"] != null && row["O_Form_AuditFlow_flowSet"].ToString() != "")
                {
                    model.O_Form_AuditFlow_flowSet = new Guid(row["O_Form_AuditFlow_flowSet"].ToString());
                }
                if (row["O_Form_AuditFlow_flowSet_name"] != null)
                {
                    model.O_Form_AuditFlow_flowSet_name = row["O_Form_AuditFlow_flowSet_name"].ToString();
                }
                if (row["O_Form_AuditFlow_flowSet_order"] != null && row["O_Form_AuditFlow_flowSet_order"].ToString() != "")
                {
                    model.O_Form_AuditFlow_flowSet_order = int.Parse(row["O_Form_AuditFlow_flowSet_order"].ToString());
                }
                if (row["O_Form_AuditFlow_flowSet_auditType"] != null && row["O_Form_AuditFlow_flowSet_auditType"].ToString() != "")
                {
                    model.O_Form_AuditFlow_flowSet_auditType = int.Parse(row["O_Form_AuditFlow_flowSet_auditType"].ToString());
                }
                if (row["O_Form_AuditFlow_flowSet_rule"] != null)
                {
                    model.O_Form_AuditFlow_flowSet_rule = row["O_Form_AuditFlow_flowSet_rule"].ToString();
                }
                if (row["O_Form_AuditFlow_auditStatus"] != null && row["O_Form_AuditFlow_auditStatus"].ToString() != "")
                {
                    model.O_Form_AuditFlow_auditStatus = int.Parse(row["O_Form_AuditFlow_auditStatus"].ToString());
                }
                if (row["O_Form_AuditFlow_auditTime"] != null && row["O_Form_AuditFlow_auditTime"].ToString() != "")
                {
                    model.O_Form_AuditFlow_auditTime = DateTime.Parse(row["O_Form_AuditFlow_auditTime"].ToString());
                }
                if (row["O_Form_AuditFlow_isDelete"] != null && row["O_Form_AuditFlow_isDelete"].ToString() != "")
                {
                    if ((row["O_Form_AuditFlow_isDelete"].ToString() == "1") || (row["O_Form_AuditFlow_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Form_AuditFlow_isDelete = true;
                    }
                    else
                    {
                        model.O_Form_AuditFlow_isDelete = false;
                    }
                }
                if (row["O_Form_AuditFlow_creator"] != null && row["O_Form_AuditFlow_creator"].ToString() != "")
                {
                    model.O_Form_AuditFlow_creator = new Guid(row["O_Form_AuditFlow_creator"].ToString());
                }
                if (row["O_Form_AuditFlow_createTime"] != null && row["O_Form_AuditFlow_createTime"].ToString() != "")
                {
                    model.O_Form_AuditFlow_createTime = DateTime.Parse(row["O_Form_AuditFlow_createTime"].ToString());
                }
                //虚拟字段是否存在于集合中（审核人名称）
                if (row.Table.Columns.Contains("O_Form_AuditPerson_auditPersonname"))
                {
                    if (row["O_Form_AuditPerson_auditPersonname"] != null)
                    {
                        model.O_Form_AuditPerson_auditPersonname = row["O_Form_AuditPerson_auditPersonname"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（审核状态名称）
                if (row.Table.Columns.Contains("O_Form_AuditPerson_statusname"))
                {
                    if (row["O_Form_AuditPerson_statusname"] != null)
                    {
                        model.O_Form_AuditPerson_statusname = row["O_Form_AuditPerson_statusname"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（审批内容）
                if (row.Table.Columns.Contains("O_Form_AuditPerson_content"))
                {
                    if (row["O_Form_AuditPerson_content"] != null)
                    {
                        model.O_Form_AuditPerson_content = row["O_Form_AuditPerson_content"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（审批内容）
                if (row.Table.Columns.Contains("O_Form_AuditPerson_auditTime"))
                {
                    if (row["O_Form_AuditPerson_auditTime"] != null && row["O_Form_AuditPerson_auditTime"].ToString()!="")
                    {
                        model.O_Form_AuditPerson_auditTime = DateTime.Parse(row["O_Form_AuditPerson_auditTime"].ToString());
                 
                    }
                }
                //虚拟字段是否存在于集合中（审批人guid）
                if (row.Table.Columns.Contains("O_Form_AuditPerson_auditPerson"))
                {
                    if (row["O_Form_AuditPerson_auditPerson"] != null && row["O_Form_AuditPerson_auditPerson"].ToString() != "")
                    {
                        model.O_Form_AuditPerson_auditPerson = new Guid(row["O_Form_AuditPerson_auditPerson"].ToString());
                    }
                }
                //虚拟字段,审批状态，是否存在于集合中
                if (row.Table.Columns.Contains("O_Form_AuditFlow_auditStatus_name"))
                {
                    if (row["O_Form_AuditFlow_auditStatus_name"] != null)
                    {
                        model.O_Form_AuditFlow_auditStatus_name = row["O_Form_AuditFlow_auditStatus_name"].ToString();
                    }
                }
                //虚拟字段,表单code，是否存在于集合中
                if (row.Table.Columns.Contains("O_Form_code"))
                {
                    if (row["O_Form_code"] != null && row["O_Form_code"].ToString() != "")
                    {
                        model.O_Form_code = new Guid(row["O_Form_code"].ToString());
                    }
                }
                //虚拟字段,申请人guid，是否存在于集合中
                if (row.Table.Columns.Contains("O_Form_applyPerson"))
                {
                    if (row["O_Form_applyPerson"] != null && row["O_Form_applyPerson"].ToString() != "")
                    {
                        model.O_Form_applyPerson = new Guid(row["O_Form_applyPerson"].ToString());
                    }
                }
                //虚拟字段,消息id，是否存在于集合中 
                if (row.Table.Columns.Contains("C_Messages_id"))
                {
                    if (row["C_Messages_id"] != null && row["C_Messages_id"].ToString() != "")
                    {
                        model.C_Messages_id = Convert.ToInt32(row["C_Messages_id"].ToString());
                    }
                }
                //虚拟字段,表单名称，是否存在于集合中 
                if (row.Table.Columns.Contains("O_Form_name"))
                {
                    if (row["O_Form_name"] != null && row["O_Form_name"].ToString() != "")
                    {
                        model.O_Form_name = row["O_Form_name"].ToString();
                    }
                }
                //虚拟字段,审批人状态，是否存在于集合中 
                if (row.Table.Columns.Contains("O_Form_AuditPerson_status"))
                {
                    if (row["O_Form_AuditPerson_status"] != null && row["O_Form_AuditPerson_status"].ToString() != "")
                    {
                        model.O_Form_AuditPerson_status = Convert.ToInt32(row["O_Form_AuditPerson_status"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("O_Form_AuditPerson_auditPersonjob"))
                {
                    if (row["O_Form_AuditPerson_auditPersonjob"] != null && row["O_Form_AuditPerson_auditPersonjob"].ToString() != "")
                    { model.O_Form_AuditPerson_auditPersonjob = row["O_Form_AuditPerson_auditPersonjob"].ToString(); }
                }
            }
            return model;
        }
        /// <summary>
        /// 通过表单guid和流程顺序获得数据列表获得数据信息
        /// </summary>
        public DataSet GetModelByAuditFlowcodeAndformCodeAndOrder( int type, Guid formCode, int order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Form_AuditFlow_id,O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime,C.C_Userinfo_name As O_Form_AuditPerson_auditPersonname,D.C_Parameters_name As O_Form_AuditPerson_statusname,B.O_Form_AuditPerson_content As O_Form_AuditPerson_content,B.O_Form_AuditPerson_auditTime As O_Form_AuditPerson_auditTime,E.O_Form_code As O_Form_code,E.O_Form_applyPerson As O_Form_applyPerson ,B.O_Form_AuditPerson_auditPerson As O_Form_AuditPerson_auditPerson");
            strSql.Append(" FROM O_Form_AuditFlow As A left join O_Form_AuditPerson As B  on A.O_Form_AuditFlow_code=B.O_Form_AuditPerson_formAuditFlow left join C_Userinfo As C on C.C_Userinfo_code=B.O_Form_AuditPerson_auditPerson left join C_Parameters As D on D.C_Parameters_id=B.O_Form_AuditPerson_status left join O_Form As E on E.O_Form_code=A.O_Form_AuditFlow_o_form  where O_Form_AuditFlow_isDelete=0 and B.O_Form_AuditPerson_isDelete=0 and  A.O_Form_AuditFlow_o_form=@O_Form_AuditFlow_o_form and A.O_Form_AuditFlow_flowSet_order=@O_Form_AuditFlow_flowSet_order ");
            if (type == 1)
            {
                strSql.Append(" and O_Form_AuditPerson_status=539");
            }
            else
            {
                strSql.Append(" and (O_Form_AuditPerson_status=540 or O_Form_AuditPerson_status=541)");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditFlow_o_form", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@O_Form_AuditFlow_flowSet_order", SqlDbType.Int, 14),
                    };
            parameters[0].Value = formCode;
            parameters[1].Value = order;
            CommonService.Model.OA.O_Form_AuditFlow model = new CommonService.Model.OA.O_Form_AuditFlow();
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Form_AuditFlow_id,O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime ");
            strSql.Append(" FROM O_Form_AuditFlow ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 通过表单guid获得数据列表
        /// </summary>
        public DataSet GetListByFormCode(Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Form_AuditFlow_id,O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime,C.C_Userinfo_name As O_Form_AuditPerson_auditPersonname,D.C_Parameters_name As O_Form_AuditPerson_statusname,B.O_Form_AuditPerson_content As O_Form_AuditPerson_content,B.O_Form_AuditPerson_auditTime As O_Form_AuditPerson_auditTime,B.O_Form_AuditPerson_status As O_Form_AuditPerson_status,C.C_Userinfo_code As O_Form_AuditPerson_auditPerson,dbo.getUserPostNamesByUserCode(C.C_Userinfo_code) As O_Form_AuditPerson_auditPersonjob ");
            strSql.Append(" FROM O_Form_AuditFlow As A ");
            strSql.Append("left join O_Form_AuditPerson As B on A.O_Form_AuditFlow_code=B.O_Form_AuditPerson_formAuditFlow ");
            strSql.Append("left join C_Userinfo As C on C.C_Userinfo_code=B.O_Form_AuditPerson_auditPerson ");
            strSql.Append("left join C_Parameters As D on D.C_Parameters_id=B.O_Form_AuditPerson_status ");    
            strSql.Append("where O_Form_AuditFlow_o_form=@O_Form_AuditFlow_o_form and O_Form_AuditFlow_isDelete=0 and B.O_Form_AuditPerson_isDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditFlow_o_form", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = formCode;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 通过审核人guid获得未读取的消息数据列表
        /// </summary>
        public DataSet GetListStatusByuserCode(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Form_AuditFlow_id,O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime,C.C_Userinfo_name As O_Form_AuditPerson_auditPersonname,D.C_Parameters_name As O_Form_AuditPerson_statusname,B.O_Form_AuditPerson_content As O_Form_AuditPerson_content,B.O_Form_AuditPerson_auditTime As O_Form_AuditPerson_auditTime,C.C_Userinfo_code As O_Form_AuditPerson_auditPerson,E.O_Form_code As O_Form_code,F.C_Messages_id As C_Messages_id,K.O_Form_name As O_Form_name ");
            strSql.Append(" FROM O_Form_AuditFlow As A left join O_Form_AuditPerson As B  on A.O_Form_AuditFlow_code=B.O_Form_AuditPerson_formAuditFlow left join C_Userinfo As C on C.C_Userinfo_code=B.O_Form_AuditPerson_auditPerson left join C_Parameters As D on D.C_Parameters_id=B.O_Form_AuditPerson_status left join O_Form As E on E.O_Form_code=A.O_Form_AuditFlow_o_form left join C_Messages As F on A.O_Form_AuditFlow_code=F.C_Messages_link left join (select O_Form_code,M.F_Form_chineseName As O_Form_name from O_Form As G left join F_Form As M on G.O_Form_f_form=M.F_Form_code) As K on A.O_Form_AuditFlow_o_form=K.O_Form_code where O_Form_AuditPerson_auditPerson=@O_Form_AuditPerson_auditPerson and O_Form_AuditFlow_isDelete=0 and B.O_Form_AuditPerson_isDelete=0  and F.C_Messages_isRead=0 and F.C_Messages_person=@O_Form_AuditPerson_auditPerson order by O_Form_AuditFlow_createTime desc");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditPerson_auditPerson", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = userCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 通过审核人guid获得未审核的数据列表
        /// </summary>
        public DataSet GetListByuserCode(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Form_AuditFlow_id,O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime,C.C_Userinfo_name As O_Form_AuditPerson_auditPersonname,D.C_Parameters_name As O_Form_AuditPerson_statusname,B.O_Form_AuditPerson_content As O_Form_AuditPerson_content,B.O_Form_AuditPerson_auditTime As O_Form_AuditPerson_auditTime,C.C_Userinfo_code As O_Form_AuditPerson_auditPerson,E.O_Form_code As O_Form_code,F.C_Messages_id As C_Messages_id,K.O_Form_name As O_Form_name ");
            strSql.Append(" FROM O_Form_AuditFlow As A left join O_Form_AuditPerson As B  on A.O_Form_AuditFlow_code=B.O_Form_AuditPerson_formAuditFlow left join C_Userinfo As C on C.C_Userinfo_code=B.O_Form_AuditPerson_auditPerson left join C_Parameters As D on D.C_Parameters_id=B.O_Form_AuditPerson_status left join O_Form As E on E.O_Form_code=A.O_Form_AuditFlow_o_form left join C_Messages As F on A.O_Form_AuditFlow_code=F.C_Messages_link left join (select O_Form_code,M.F_Form_chineseName As O_Form_name from O_Form As G left join F_Form As M on G.O_Form_f_form=M.F_Form_code) As K on A.O_Form_AuditFlow_o_form=K.O_Form_code where O_Form_AuditPerson_auditPerson=@O_Form_AuditPerson_auditPerson and O_Form_AuditFlow_isDelete=0 and B.O_Form_AuditPerson_isDelete=0  and B.O_Form_AuditPerson_status=539 and F.C_Messages_person=@O_Form_AuditPerson_auditPerson");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditPerson_auditPerson", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = userCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 通过表单Guid，获取表单审批流程集合
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public DataSet GetFormAuditFlowsByFormCode(Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FAF.*,P.C_Parameters_name As O_Form_AuditFlow_auditStatus_name ");
            strSql.Append("FROM O_Form_AuditFlow As FAF with(nolock) ");
            strSql.Append("left join C_Parameters As P with(nolock) on P.C_Parameters_id=FAF.O_Form_AuditFlow_auditStatus ");
            strSql.Append("where FAF.O_Form_AuditFlow_isDelete=0 ");
            strSql.Append("and FAF.O_Form_AuditFlow_o_form=@O_Form_AuditFlow_o_form ");
            strSql.Append("order by FAF.O_Form_AuditFlow_flowSet_order Asc ");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditFlow_o_form", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = formCode;
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
            strSql.Append(" O_Form_AuditFlow_id,O_Form_AuditFlow_code,O_Form_AuditFlow_o_form,O_Form_AuditFlow_flowSet,O_Form_AuditFlow_flowSet_name,O_Form_AuditFlow_flowSet_order,O_Form_AuditFlow_flowSet_auditType,O_Form_AuditFlow_flowSet_rule,O_Form_AuditFlow_auditStatus,O_Form_AuditFlow_auditTime,O_Form_AuditFlow_isDelete,O_Form_AuditFlow_creator,O_Form_AuditFlow_createTime ");
            strSql.Append(" FROM O_Form_AuditFlow ");
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
            strSql.Append("select count(1) FROM O_Form_AuditFlow ");
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
                strSql.Append("order by T.O_Form_AuditFlow_id desc");
            }
            strSql.Append(")AS Row, T.*  from O_Form_AuditFlow T ");
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
            parameters[0].Value = "O_Form_AuditFlow";
            parameters[1].Value = "O_Form_AuditFlow_id";
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
