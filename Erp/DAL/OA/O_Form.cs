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
    /// 数据访问类:表单表
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_Form
    {
        public O_Form()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("O_Form_id", "O_Form");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Form_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Form");
            strSql.Append(" where O_Form_id=@O_Form_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Form_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Form(");
            strSql.Append("O_Form_code,O_Form_f_form,O_Form_flow,O_Form_businessFlowform,O_Form_applyPerson,O_Form_applyTime,O_Form_applyStatus,O_Form_isDelete,O_Form_creator,O_Form_createTime)");
            strSql.Append(" values (");
            strSql.Append("@O_Form_code,@O_Form_f_form,@O_Form_flow,@O_Form_businessFlowform,@O_Form_applyPerson,@O_Form_applyTime,@O_Form_applyStatus,@O_Form_isDelete,@O_Form_creator,@O_Form_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_f_form", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_flow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_businessFlowform", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_applyPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_applyTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_applyStatus", SqlDbType.Int,4),
					new SqlParameter("@O_Form_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Form_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.O_Form_code;
            parameters[1].Value = model.O_Form_f_form;
            parameters[2].Value = model.O_Form_flow;
            parameters[3].Value = model.O_Form_businessFlowform;
            parameters[4].Value = model.O_Form_applyPerson;
            parameters[5].Value = model.O_Form_applyTime;
            parameters[6].Value = model.O_Form_applyStatus;
            parameters[7].Value = model.O_Form_isDelete;
            parameters[8].Value = model.O_Form_creator;
            parameters[9].Value = model.O_Form_createTime;

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
        public bool Update(CommonService.Model.OA.O_Form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Form set ");
            strSql.Append("O_Form_code=@O_Form_code,");
            strSql.Append("O_Form_f_form=@O_Form_f_form,");
            strSql.Append("O_Form_flow=@O_Form_flow,");
            strSql.Append("O_Form_businessFlowform=@O_Form_businessFlowform,");
            strSql.Append("O_Form_applyPerson=@O_Form_applyPerson,");
            strSql.Append("O_Form_applyTime=@O_Form_applyTime,");
            strSql.Append("O_Form_applyStatus=@O_Form_applyStatus,");
            strSql.Append("O_Form_isDelete=@O_Form_isDelete,");
            strSql.Append("O_Form_creator=@O_Form_creator,");
            strSql.Append("O_Form_createTime=@O_Form_createTime");
            strSql.Append(" where O_Form_id=@O_Form_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_f_form", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_flow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_businessFlowform", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_applyPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_applyTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_applyStatus", SqlDbType.Int,4),
					new SqlParameter("@O_Form_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Form_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Form_code;
            parameters[1].Value = model.O_Form_f_form;
            parameters[2].Value = model.O_Form_flow;
            parameters[3].Value = model.O_Form_businessFlowform;
            parameters[4].Value = model.O_Form_applyPerson;
            parameters[5].Value = model.O_Form_applyTime;
            parameters[6].Value = model.O_Form_applyStatus;
            parameters[7].Value = model.O_Form_isDelete;
            parameters[8].Value = model.O_Form_creator;
            parameters[9].Value = model.O_Form_createTime;
            parameters[10].Value = model.O_Form_id;

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
        public bool Delete(Guid O_Form_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Form set O_Form_isDelete = 1 ");
            strSql.Append(" where O_Form_code=@O_Form_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Form_code;

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
        /// 更改表单状态
        /// </summary>
        /// <param name="oFormCode">表单Guid</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateState(Guid oFormCode,int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Form set O_Form_applyStatus = @O_Form_applyStatus ");
            strSql.Append("where O_Form_code=@O_Form_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_applyStatus", SqlDbType.Int,4),
                    new SqlParameter("@O_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = state;
            parameters[1].Value = oFormCode;

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
        public bool DeleteList(string O_Form_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Form ");
            strSql.Append(" where O_Form_id in (" + O_Form_idlist + ")  ");
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
        public CommonService.Model.OA.O_Form GetModel(Guid O_Form_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Form_id,O_Form_code,O_Form_f_form,O_Form_flow,O_Form_businessFlowform,O_Form_applyPerson,O_Form_applyTime,O_Form_applyStatus,O_Form_isDelete,O_Form_creator,O_Form_createTime,C_Userinfo_name as O_Form_applyPerson_name from O_Form As A left join C_Userinfo As B on A.O_Form_applyPerson=B.C_Userinfo_code ");
            strSql.Append(" where O_Form_code=@O_Form_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Form_code;

            CommonService.Model.OA.O_Form model = new CommonService.Model.OA.O_Form();
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
        /// 通过业务流程表单关联Guid，得到一条数据
        /// </summary>
        /// <param name="businessFlowform">业务流程表单关联Guid</param>
        /// <returns></returns> 
        public CommonService.Model.OA.O_Form GetByBusinessFlowformCode(Guid businessFlowform)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 O_Form_id,O_Form_code,O_Form_f_form,O_Form_flow,O_Form_businessFlowform,O_Form_applyPerson,O_Form_applyTime,O_Form_applyStatus,O_Form_isDelete,O_Form_creator,O_Form_createTime from O_Form ");
            strSql.Append(" where O_Form_businessFlowform=@O_Form_businessFlowform ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_businessFlowform", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowform;

            CommonService.Model.OA.O_Form model = new CommonService.Model.OA.O_Form();
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
        /// 根据表单Guid，获取表单自定义类型(如普通编辑表单，单头明细行表单，明细行表单)(返回1代表普通编辑表单;2代表主子表单;3代表明细子表)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回1代表普通编辑表单;2代表主子表单;3代表明细子表</returns>
        public int GetFormCustomerType(Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");             
            strSql.Append("case ");
            strSql.Append("when exists(select 1 from F_FormProperty As FP WITH(NOLOCK) where FP.F_FormProperty_form = F.F_Form_code and FP.F_FormProperty_isDelete=0 and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and FP.F_FormProperty_uiType=527) then 2 ");
            strSql.Append("when exists(select 1 from F_FormProperty As FP WITH(NOLOCK) where FP.F_FormProperty_form =F.F_Form_code and FP.F_FormProperty_isDelete=0 and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and FP.F_FormProperty_uiType=207) then 3 ");
            strSql.Append("else 1 ");
            strSql.Append("end ");
            strSql.Append("from F_Form AS F WITH(NOLOCK) ");
            strSql.Append("where F.F_Form_code = @F_Form_code ");
 
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = formCode;

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
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Form DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Form model = new CommonService.Model.OA.O_Form();
            if (row != null)
            {
                if (row["O_Form_id"] != null && row["O_Form_id"].ToString() != "")
                {
                    model.O_Form_id = int.Parse(row["O_Form_id"].ToString());
                }
                if (row["O_Form_code"] != null && row["O_Form_code"].ToString() != "")
                {
                    model.O_Form_code = new Guid(row["O_Form_code"].ToString());
                }
                if (row["O_Form_f_form"] != null && row["O_Form_f_form"].ToString() != "")
                {
                    model.O_Form_f_form = new Guid(row["O_Form_f_form"].ToString());
                }
                if (row["O_Form_flow"] != null && row["O_Form_flow"].ToString() != "")
                {
                    model.O_Form_flow = new Guid(row["O_Form_flow"].ToString());
                }
                if (row["O_Form_businessFlowform"] != null && row["O_Form_businessFlowform"].ToString() != "")
                {
                    model.O_Form_businessFlowform = new Guid(row["O_Form_businessFlowform"].ToString());
                }
                if (row["O_Form_applyPerson"] != null && row["O_Form_applyPerson"].ToString() != "")
                {
                    model.O_Form_applyPerson = new Guid(row["O_Form_applyPerson"].ToString());
                }
                if (row["O_Form_applyTime"] != null && row["O_Form_applyTime"].ToString() != "")
                {
                    model.O_Form_applyTime = DateTime.Parse(row["O_Form_applyTime"].ToString());
                }
                if (row["O_Form_applyStatus"] != null && row["O_Form_applyStatus"].ToString() != "")
                {
                    model.O_Form_applyStatus = int.Parse(row["O_Form_applyStatus"].ToString());
                }
                if (row["O_Form_isDelete"] != null && row["O_Form_isDelete"].ToString() != "")
                {
                    if ((row["O_Form_isDelete"].ToString() == "1") || (row["O_Form_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Form_isDelete = true;
                    }
                    else
                    {
                        model.O_Form_isDelete = false;
                    }
                }
                if (row["O_Form_creator"] != null && row["O_Form_creator"].ToString() != "")
                {
                    model.O_Form_creator = new Guid(row["O_Form_creator"].ToString());
                }
                if (row["O_Form_createTime"] != null && row["O_Form_createTime"].ToString() != "")
                {
                    model.O_Form_createTime = DateTime.Parse(row["O_Form_createTime"].ToString());
                }
                //虚拟字段(表单名称)是否存在
                if (row.Table.Columns.Contains("O_Form_f_form_name"))
                {
                    if (row["O_Form_f_form_name"] != null && row["O_Form_f_form_name"].ToString() != "")
                    {
                        model.O_Form_f_form_name = row["O_Form_f_form_name"].ToString();
                    }
                }
                //虚拟字段(所属流程名称)是否存在
                if (row.Table.Columns.Contains("O_Form_flow_name"))
                {
                    if (row["O_Form_flow_name"] != null && row["O_Form_flow_name"].ToString() != "")
                    {
                        model.O_Form_flow_name = row["O_Form_flow_name"].ToString();
                    }
                }
                //虚拟字段(申请人名称)是否存在
                if (row.Table.Columns.Contains("O_Form_applyPerson_name"))
                {
                    if (row["O_Form_applyPerson_name"] != null && row["O_Form_applyPerson_name"].ToString() != "")
                    {
                        model.O_Form_applyPerson_name = row["O_Form_applyPerson_name"].ToString();
                    }
                }
                //虚拟字段(申请状态名称)是否存在
                if (row.Table.Columns.Contains("O_Form_applyStatus_name"))
                {
                    if (row["O_Form_applyStatus_name"] != null && row["O_Form_applyStatus_name"].ToString() != "")
                    {
                        model.O_Form_applyStatus_name = row["O_Form_applyStatus_name"].ToString();
                    }
                }
                //虚拟字段(所属表单名称)是否存在
                if(row.Table.Columns.Contains("O_Form_businessFlowform_name"))
                {
                    if(row["O_Form_businessFlowform_name"]!=null && row["O_Form_businessFlowform_name"].ToString()!="")
                    {
                        model.O_Form_businessFlowform_name = row["O_Form_businessFlowform_name"].ToString();
                    }
                }
                //虚拟字段(所属流程名称)是否存在
                if (row.Table.Columns.Contains("O_Form_businessFlow_name"))
                {
                    if (row["O_Form_businessFlow_name"] != null && row["O_Form_businessFlow_name"].ToString() != "")
                    {
                        model.O_Form_businessFlow_name = row["O_Form_businessFlow_name"].ToString();
                    }
                }
                //虚拟字段(所属案件名称)是否存在
                if (row.Table.Columns.Contains("O_Form_relation_name"))
                {
                    if (row["O_Form_relation_name"] != null && row["O_Form_relation_name"].ToString() != "")
                    {
                        model.O_Form_relation_name = row["O_Form_relation_name"].ToString();
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
            strSql.Append("select O_Form_id,O_Form_code,O_Form_f_form,O_Form_flow,O_Form_businessFlowform,O_Form_applyPerson,O_Form_applyTime,O_Form_applyStatus,O_Form_isDelete,O_Form_creator,O_Form_createTime ");
            strSql.Append(" FROM O_Form ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" O_Form_id,O_Form_code,O_Form_f_form,O_Form_flow,O_Form_businessFlowform,O_Form_applyPerson,O_Form_applyTime,O_Form_applyStatus,O_Form_isDelete,O_Form_creator,O_Form_createTime ");
            strSql.Append(" FROM O_Form ");
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
        public int GetRecordCount(CommonService.Model.OA.O_Form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM O_Form As O");
            strSql.Append(" left join F_Form as F on O.O_Form_f_form=F.F_Form_code ");
            strSql.Append(" where 1=1 and O_Form_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Form_f_form_name != null)
                {
                    strSql.Append(" and F_Form_chineseName like N'%'+@F_Form_chineseName+'%'");
                }
                if (model.O_Form_businessFlowform != null)
                {
                    strSql.Append(" and O_Form_businessFlowform is not null");
                }
                else
                {
                    strSql.Append(" and O_Form_businessFlowform is null");
                }
                if (model.O_Form_applyPerson != null)
                {
                    strSql.Append(" and O_Form_applyPerson=@O_Form_applyPerson");
                }
                if (model.O_Form_creator != null)
                {
                    strSql.Append(" and O_Form_creator=@O_Form_creator");
                }
                if (model.O_Form_f_form != null)
                {
                    strSql.Append(" and O_Form_f_form=@O_Form_f_form ");
                }
            }
            SqlParameter[] parameters = { 
                 new SqlParameter("@F_Form_chineseName", SqlDbType.VarChar, 200),
                 new SqlParameter("@O_Form_applyPerson", SqlDbType.UniqueIdentifier, 16),
                 new SqlParameter("@O_Form_creator", SqlDbType.UniqueIdentifier, 16),
                 new SqlParameter("@O_Form_f_form", SqlDbType.UniqueIdentifier, 16)
            };
            parameters[0].Value = model.O_Form_f_form_name;
            parameters[1].Value = model.O_Form_applyPerson;
            parameters[2].Value = model.O_Form_creator;
            parameters[2].Value = model.O_Form_f_form;
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
        ///  获取待办任务总记录数
        /// </summary>
        /// <param name="model">查询模型数据</param>
        /// <param name="isPreSetManager">是否为内置系统管理员账号</param>
        /// <param name="userCode">当前登录子用户</param>
        /// <returns></returns>
        public int GetMyTaskRecordCount(CommonService.Model.OA.O_Form model,bool isPreSetManager, Guid? userCode)
        {
            /**
              * author:hety
              * date:2015-09-01
              * description:
              * (1)、内置系统管理员可以查看所有待办任务，否则只能查看当前登录子用户关联的待办任务
              * (2)、只可查看已提交并且未删除的
            ***/
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM O_Form As O");
            strSql.Append(" left join F_Form as F on O.O_Form_f_form=F.F_Form_code ");
            strSql.Append(" where 1=1 and O.O_Form_isDelete=0 and O.O_Form_applyStatus<>534 ");
            if (model != null)
            {
                if (model.O_Form_f_form_name != null)
                {
                    strSql.Append(" and F.F_Form_chineseName like N'%'+@F_Form_chineseName+'%'");
                }
                if (model.O_Form_applyPerson != null)
                {
                    strSql.Append(" and O.O_Form_applyPerson=@O_Form_applyPerson");
                }
                if (model.O_Form_creator != null)
                {
                    strSql.Append(" and O.O_Form_creator=@O_Form_creator");
                }
            }

            if (!isPreSetManager)
            {//非内置系统管理员，查看自己待办
                strSql.Append(" and exists(");
                strSql.Append(" select 1 from O_Form_AuditFlow As FAF with(nolock),O_Form_AuditPerson As FAP with(nolock)");
                strSql.Append(" where FAF.O_Form_AuditFlow_o_form=O.O_Form_code and FAF.O_Form_AuditFlow_isDelete=0");
                strSql.Append(" and FAF.O_Form_AuditFlow_code=FAP.O_Form_AuditPerson_formAuditFlow and FAP.O_Form_AuditPerson_isDelete=0 and FAP.O_Form_AuditPerson_auditPerson=@O_Form_AuditPerson_auditPerson");
                strSql.Append(")");
            }

            SqlParameter[] parameters = { 
                 new SqlParameter("@F_Form_chineseName", SqlDbType.VarChar, 200),
                 new SqlParameter("@O_Form_applyPerson", SqlDbType.UniqueIdentifier, 16),
                 new SqlParameter("@O_Form_creator", SqlDbType.UniqueIdentifier, 16),
                 new SqlParameter("@O_Form_AuditPerson_auditPerson", SqlDbType.UniqueIdentifier, 16)
            };
            parameters[0].Value = model.O_Form_f_form_name;
            parameters[1].Value = model.O_Form_applyPerson;
            parameters[2].Value = model.O_Form_creator;
            parameters[3].Value = userCode;
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
        public DataSet GetListByPage(CommonService.Model.OA.O_Form model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.O_Form_applyTime desc");
            }
            strSql.Append(")AS Row, T.*,F.F_Form_chineseName As O_Form_f_form_name,FL.O_Flow_name As O_Form_flow_name,U.C_Userinfo_name As O_Form_applyPerson_name,P.C_Parameters_name As O_Form_applyStatus_name,F1.F_Form_chineseName as O_Form_businessFlowform_name,BF.P_Business_flow_name as O_Form_businessFlow_name,C.B_Case_number as O_Form_relation_name from O_Form T ");
            strSql.Append(" left join  F_Form as F on T.O_Form_f_form=F.F_Form_code ");
            strSql.Append(" left join  O_Flow as FL on FL.O_Flow_code=T.O_Form_flow ");
            strSql.Append(" left join  C_Userinfo as U on U.C_Userinfo_code=T.O_Form_applyPerson ");
            strSql.Append(" left join  C_Parameters as P on P.C_Parameters_id=T.O_Form_applyStatus ");
            strSql.Append(" left join  P_Business_flow_form as BFF on T.O_Form_businessFlowform=BFF.P_Business_flow_form_code ");
            strSql.Append(" left join  F_Form as F1 on BFF.F_Form_code=F1.F_Form_code ");
            strSql.Append(" left join  P_Business_flow as BF on BFF.P_Business_flow_code=BF.P_Business_flow_code ");
            strSql.Append(" left join  B_Case as C on C.B_Case_code=BF.P_Fk_code ");
            strSql.Append(" where 1=1 and O_Form_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Form_f_form_name != null)
                {
                    strSql.Append(" and F_Form_chineseName like N'%'+@F_Form_chineseName+'%'");
                }
                if(model.O_Form_businessFlowform!=null)
                {
                    strSql.Append(" and O_Form_businessFlowform is not null");
                }else
                {
                    strSql.Append(" and O_Form_businessFlowform is null");
                }
                if (model.O_Form_applyPerson != null)
                {
                    strSql.Append(" and O_Form_applyPerson=@O_Form_applyPerson");
                }
                if (model.O_Form_creator != null)
                {
                    strSql.Append(" and O_Form_creator=@O_Form_creator");
                }
                if (model.O_Form_f_form != null)
                {
                    strSql.Append(" and O_Form_f_form=@O_Form_f_form ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = { 
                 new SqlParameter("@F_Form_chineseName", SqlDbType.VarChar, 200),
                 new SqlParameter("@O_Form_applyPerson", SqlDbType.UniqueIdentifier, 16),
                 new SqlParameter("@O_Form_creator", SqlDbType.UniqueIdentifier, 16),
                 new SqlParameter("@O_Form_f_form", SqlDbType.UniqueIdentifier, 16)
            };
            parameters[0].Value = model.O_Form_f_form_name;
            parameters[1].Value = model.O_Form_applyPerson;
            parameters[2].Value = model.O_Form_creator;
            parameters[3].Value = model.O_Form_f_form;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取代办任务数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="isPreSetManager">是否为内置系统管理员账号</param>
        /// <param name="userCode">当前登录子用户</param>
        /// <returns></returns>
        public DataSet GetMyTaskListByPage(CommonService.Model.OA.O_Form model, string orderby, int startIndex, int endIndex, bool isPreSetManager, Guid? userCode)
        {
            /**
             * author:hety
             * date:2015-09-01
             * description:
             * (1)、内置系统管理员可以查看所有待办任务，否则只能查看当前登录子用户关联的待办任务
             * (2)、只可查看已提交并且未删除的
             ***/

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.O_Form_applyTime desc");
            }
            strSql.Append(")AS Row, T.*,F.F_Form_chineseName As O_Form_f_form_name,FL.O_Flow_name As O_Form_flow_name,U.C_Userinfo_name As O_Form_applyPerson_name,P.C_Parameters_name As O_Form_applyStatus_name from O_Form T ");
            strSql.Append(" left join  F_Form as F on T.O_Form_f_form=F.F_Form_code ");
            strSql.Append(" left join  O_Flow as FL on FL.O_Flow_code=T.O_Form_flow ");
            strSql.Append(" left join  C_Userinfo as U on U.C_Userinfo_code=T.O_Form_applyPerson ");
            strSql.Append(" left join  C_Parameters as P on P.C_Parameters_id=T.O_Form_applyStatus ");
            strSql.Append(" where 1=1 and T.O_Form_isDelete=0 and T.O_Form_applyStatus<>534 ");

            if (model != null)
            {
                if (model.O_Form_f_form_name != null)
                {
                    strSql.Append(" and F.F_Form_chineseName like N'%'+@F_Form_chineseName+'%'");
                }
                if (model.O_Form_applyPerson != null)
                {
                    strSql.Append(" and T.O_Form_applyPerson=@O_Form_applyPerson");
                }
                if (model.O_Form_creator != null)
                {
                    strSql.Append(" and T.O_Form_creator=@O_Form_creator");
                }
            }

            if (!isPreSetManager)
            {//非内置系统管理员，查看自己待办
                strSql.Append(" and exists(");
                strSql.Append(" select 1 from O_Form_AuditFlow As FAF with(nolock),O_Form_AuditPerson As FAP with(nolock)");
                strSql.Append(" where FAF.O_Form_AuditFlow_o_form=T.O_Form_code and FAF.O_Form_AuditFlow_isDelete=0");
                strSql.Append(" and FAF.O_Form_AuditFlow_code=FAP.O_Form_AuditPerson_formAuditFlow and FAP.O_Form_AuditPerson_isDelete=0 and FAP.O_Form_AuditPerson_auditPerson=@O_Form_AuditPerson_auditPerson");
                strSql.Append(")");
            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = { 
                 new SqlParameter("@F_Form_chineseName", SqlDbType.VarChar, 200),
                 new SqlParameter("@O_Form_applyPerson", SqlDbType.UniqueIdentifier, 16),
                 new SqlParameter("@O_Form_creator", SqlDbType.UniqueIdentifier, 16),
                 new SqlParameter("@O_Form_AuditPerson_auditPerson", SqlDbType.UniqueIdentifier, 16)
            };
            parameters[0].Value = model.O_Form_f_form_name;
            parameters[1].Value = model.O_Form_applyPerson;
            parameters[2].Value = model.O_Form_creator;
            parameters[3].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 通过业务流程表单关联Guid，得到未提交的数据
        /// </summary>
        /// <param name="businessFlowform">业务流程表单关联Guid</param>
        /// <returns></returns> 
        public CommonService.Model.OA.O_Form GetModelByBusinessFlowformCode(Guid businessFlowform, Guid fForm, Guid O_Form_creator)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  O_Form_id,O_Form_code,O_Form_f_form,O_Form_flow,O_Form_businessFlowform,O_Form_applyPerson,O_Form_applyTime,O_Form_applyStatus,O_Form_isDelete,O_Form_creator,O_Form_createTime from O_Form ");
            strSql.Append(" where O_Form_businessFlowform=@O_Form_businessFlowform and O_Form_applyStatus=534 and O_Form_f_form=@O_Form_f_form and O_Form_creator=@O_Form_creator and O_Form_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_businessFlowform", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@O_Form_f_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@O_Form_creator", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowform;
            parameters[1].Value = fForm;
            parameters[2].Value = O_Form_creator;
            CommonService.Model.OA.O_Form model = new CommonService.Model.OA.O_Form();
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
        #endregion  BasicMethod
    }
}
