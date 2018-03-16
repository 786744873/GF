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
    /// 数据访问类:表单审批人表
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_Form_AuditPerson
    {
        public O_Form_AuditPerson()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("O_Form_AuditPerson_id", "O_Form_AuditPerson");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Form_AuditPerson_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Form_AuditPerson");
            strSql.Append(" where O_Form_AuditPerson_id=@O_Form_AuditPerson_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditPerson_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Form_AuditPerson_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Form_AuditPerson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Form_AuditPerson(");
            strSql.Append("O_Form_AuditPerson_code,O_Form_AuditPerson_auditPerson,O_Form_AuditPerson_auditTime,O_Form_AuditPerson_status,O_Form_AuditPerson_content,O_Form_AuditPerson_formAuditFlow,O_Form_AuditPerson_isDelete,O_Form_AuditPerson_creator,O_Form_AuditPerson_createTime)");
            strSql.Append(" values (");
            strSql.Append("@O_Form_AuditPerson_code,@O_Form_AuditPerson_auditPerson,@O_Form_AuditPerson_auditTime,@O_Form_AuditPerson_status,@O_Form_AuditPerson_content,@O_Form_AuditPerson_formAuditFlow,@O_Form_AuditPerson_isDelete,@O_Form_AuditPerson_creator,@O_Form_AuditPerson_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditPerson_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditPerson_auditPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditPerson_auditTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_AuditPerson_status", SqlDbType.Int,4),
					new SqlParameter("@O_Form_AuditPerson_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@O_Form_AuditPerson_formAuditFlow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditPerson_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Form_AuditPerson_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditPerson_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.O_Form_AuditPerson_code;
            parameters[1].Value = model.O_Form_AuditPerson_auditPerson;
            parameters[2].Value = model.O_Form_AuditPerson_auditTime;
            parameters[3].Value = model.O_Form_AuditPerson_status;
            parameters[4].Value = model.O_Form_AuditPerson_content;
            parameters[5].Value = model.O_Form_AuditPerson_formAuditFlow;
            parameters[6].Value = model.O_Form_AuditPerson_isDelete;
            parameters[7].Value = model.O_Form_AuditPerson_creator;
            parameters[8].Value = model.O_Form_AuditPerson_createTime;

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
        public bool Update(CommonService.Model.OA.O_Form_AuditPerson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Form_AuditPerson set ");
            strSql.Append("O_Form_AuditPerson_code=@O_Form_AuditPerson_code,");
            strSql.Append("O_Form_AuditPerson_auditPerson=@O_Form_AuditPerson_auditPerson,");
            strSql.Append("O_Form_AuditPerson_auditTime=@O_Form_AuditPerson_auditTime,");
            strSql.Append("O_Form_AuditPerson_status=@O_Form_AuditPerson_status,");
            strSql.Append("O_Form_AuditPerson_content=@O_Form_AuditPerson_content,");
            strSql.Append("O_Form_AuditPerson_formAuditFlow=@O_Form_AuditPerson_formAuditFlow,");
            strSql.Append("O_Form_AuditPerson_isDelete=@O_Form_AuditPerson_isDelete,");
            strSql.Append("O_Form_AuditPerson_creator=@O_Form_AuditPerson_creator,");
            strSql.Append("O_Form_AuditPerson_createTime=@O_Form_AuditPerson_createTime");
            strSql.Append(" where O_Form_AuditPerson_id=@O_Form_AuditPerson_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditPerson_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditPerson_auditPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditPerson_auditTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_AuditPerson_status", SqlDbType.Int,4),
					new SqlParameter("@O_Form_AuditPerson_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@O_Form_AuditPerson_formAuditFlow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditPerson_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Form_AuditPerson_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Form_AuditPerson_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Form_AuditPerson_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Form_AuditPerson_code;
            parameters[1].Value = model.O_Form_AuditPerson_auditPerson;
            parameters[2].Value = model.O_Form_AuditPerson_auditTime;
            parameters[3].Value = model.O_Form_AuditPerson_status;
            parameters[4].Value = model.O_Form_AuditPerson_content;
            parameters[5].Value = model.O_Form_AuditPerson_formAuditFlow;
            parameters[6].Value = model.O_Form_AuditPerson_isDelete;
            parameters[7].Value = model.O_Form_AuditPerson_creator;
            parameters[8].Value = model.O_Form_AuditPerson_createTime;
            parameters[9].Value = model.O_Form_AuditPerson_id;

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
        public bool Delete(Guid O_Form_AuditPerson_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Form_AuditPerson set O_Form_AuditPerson_isDelete =1 ");
            strSql.Append(" where O_Form_AuditPerson_code=@O_Form_AuditPerson_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditPerson_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Form_AuditPerson_code;

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
        public bool DeleteList(string O_Form_AuditPerson_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Form_AuditPerson ");
            strSql.Append(" where O_Form_AuditPerson_id in (" + O_Form_AuditPerson_idlist + ")  ");
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
        public CommonService.Model.OA.O_Form_AuditPerson GetModel(Guid O_Form_AuditPerson_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Form_AuditPerson_id,O_Form_AuditPerson_code,O_Form_AuditPerson_auditPerson,O_Form_AuditPerson_auditTime,O_Form_AuditPerson_status,O_Form_AuditPerson_content,O_Form_AuditPerson_formAuditFlow,O_Form_AuditPerson_isDelete,O_Form_AuditPerson_creator,O_Form_AuditPerson_createTime from O_Form_AuditPerson ");
            strSql.Append(" where O_Form_AuditPerson_code=@O_Form_AuditPerson_code  ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditPerson_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Form_AuditPerson_code;

            CommonService.Model.OA.O_Form_AuditPerson model = new CommonService.Model.OA.O_Form_AuditPerson();
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
        /// 通过所属表单审批流程Guid,得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Form_AuditPerson GetModelByFlowCode(Guid O_Form_AuditPerson_formAuditFlow)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Form_AuditPerson_id,O_Form_AuditPerson_code,O_Form_AuditPerson_auditPerson,O_Form_AuditPerson_auditTime,O_Form_AuditPerson_status,O_Form_AuditPerson_content,O_Form_AuditPerson_formAuditFlow,O_Form_AuditPerson_isDelete,O_Form_AuditPerson_creator,O_Form_AuditPerson_createTime from O_Form_AuditPerson ");
            strSql.Append(" where O_Form_AuditPerson_formAuditFlow=@O_Form_AuditPerson_formAuditFlow  ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Form_AuditPerson_formAuditFlow", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Form_AuditPerson_formAuditFlow;

            CommonService.Model.OA.O_Form_AuditPerson model = new CommonService.Model.OA.O_Form_AuditPerson();
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
        public CommonService.Model.OA.O_Form_AuditPerson DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Form_AuditPerson model = new CommonService.Model.OA.O_Form_AuditPerson();
            if (row != null)
            {
                if (row["O_Form_AuditPerson_id"] != null && row["O_Form_AuditPerson_id"].ToString() != "")
                {
                    model.O_Form_AuditPerson_id = int.Parse(row["O_Form_AuditPerson_id"].ToString());
                }
                if (row["O_Form_AuditPerson_code"] != null && row["O_Form_AuditPerson_code"].ToString() != "")
                {
                    model.O_Form_AuditPerson_code = new Guid(row["O_Form_AuditPerson_code"].ToString());
                }
                if (row["O_Form_AuditPerson_auditPerson"] != null && row["O_Form_AuditPerson_auditPerson"].ToString() != "")
                {
                    model.O_Form_AuditPerson_auditPerson = new Guid(row["O_Form_AuditPerson_auditPerson"].ToString());
                }
                if (row["O_Form_AuditPerson_auditTime"] != null && row["O_Form_AuditPerson_auditTime"].ToString() != "")
                {
                    model.O_Form_AuditPerson_auditTime = DateTime.Parse(row["O_Form_AuditPerson_auditTime"].ToString());
                }
                if (row["O_Form_AuditPerson_status"] != null && row["O_Form_AuditPerson_status"].ToString() != "")
                {
                    model.O_Form_AuditPerson_status = int.Parse(row["O_Form_AuditPerson_status"].ToString());
                }
                if (row["O_Form_AuditPerson_content"] != null)
                {
                    model.O_Form_AuditPerson_content = row["O_Form_AuditPerson_content"].ToString();
                }
                if (row["O_Form_AuditPerson_formAuditFlow"] != null && row["O_Form_AuditPerson_formAuditFlow"].ToString() != "")
                {
                    model.O_Form_AuditPerson_formAuditFlow = new Guid(row["O_Form_AuditPerson_formAuditFlow"].ToString());
                }
                if (row["O_Form_AuditPerson_isDelete"] != null && row["O_Form_AuditPerson_isDelete"].ToString() != "")
                {
                    if ((row["O_Form_AuditPerson_isDelete"].ToString() == "1") || (row["O_Form_AuditPerson_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Form_AuditPerson_isDelete = true;
                    }
                    else
                    {
                        model.O_Form_AuditPerson_isDelete = false;
                    }
                }
                if (row["O_Form_AuditPerson_creator"] != null && row["O_Form_AuditPerson_creator"].ToString() != "")
                {
                    model.O_Form_AuditPerson_creator = new Guid(row["O_Form_AuditPerson_creator"].ToString());
                }
                if (row["O_Form_AuditPerson_createTime"] != null && row["O_Form_AuditPerson_createTime"].ToString() != "")
                {
                    model.O_Form_AuditPerson_createTime = DateTime.Parse(row["O_Form_AuditPerson_createTime"].ToString());
                }
                //审批人名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("O_Form_AuditPerson_auditPerson_name"))
                {
                    if (row["O_Form_AuditPerson_auditPerson_name"] != null)
                    {
                        model.O_Form_AuditPerson_auditPerson_name = row["O_Form_AuditPerson_auditPerson_name"].ToString();
                    }
                }
                //状态名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("O_Form_AuditPerson_status_name"))
                {
                    if (row["O_Form_AuditPerson_status_name"] != null)
                    {
                        model.O_Form_AuditPerson_status_name = row["O_Form_AuditPerson_status_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("O_Form_AuditPerson_auditPerson_job"))
                {
                    if (row["O_Form_AuditPerson_auditPerson_job"] != null && row["O_Form_AuditPerson_auditPerson_job"].ToString() != "")
                    {
                        model.O_Form_AuditPerson_auditPerson_job = row["O_Form_AuditPerson_auditPerson_job"].ToString();
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
            strSql.Append("select O_Form_AuditPerson_id,O_Form_AuditPerson_code,O_Form_AuditPerson_auditPerson,O_Form_AuditPerson_auditTime,O_Form_AuditPerson_status,O_Form_AuditPerson_content,O_Form_AuditPerson_formAuditFlow,O_Form_AuditPerson_isDelete,O_Form_AuditPerson_creator,O_Form_AuditPerson_createTime ");
            strSql.Append(" FROM O_Form_AuditPerson ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 通过表单Guid，获取表单审批人集合
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public DataSet GetFormAuditPersonsByFormCode(Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AP.*,U.C_Userinfo_name As O_Form_AuditPerson_auditPerson_name,P.C_Parameters_name As O_Form_AuditPerson_status_name,dbo.getUserPostNamesByUserCode(U.C_Userinfo_code) As O_Form_AuditPerson_auditPerson_job ");
            strSql.Append("FROM O_Form_AuditPerson As AP with(nolock)  ");
            strSql.Append("left join O_Form_AuditFlow As FAF with(nolock) on AP.O_Form_AuditPerson_formAuditFlow=FAF.O_Form_AuditFlow_code ");
            strSql.Append("left join C_Userinfo As U with(nolock) on AP.O_Form_AuditPerson_auditPerson=U.C_Userinfo_code ");
            strSql.Append("left join C_Parameters As P with(nolock) on P.C_Parameters_id=AP.O_Form_AuditPerson_status ");    
            strSql.Append("where FAF.O_Form_AuditFlow_isDelete=0 ");
            strSql.Append("and AP.O_Form_AuditPerson_isDelete=0 ");
            strSql.Append("and FAF.O_Form_AuditFlow_o_form=@O_Form_AuditFlow_o_form ");
            strSql.Append("order by FAF.O_Form_AuditFlow_flowSet_order Asc ");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditFlow_o_form", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = formCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 通过表单审批流程Guid，获取表单审批人集合
        /// </summary>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <returns></returns>
        public DataSet GetFormAuditPersonsByFormAuditFlowCode(Guid formAuditFlowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AP.* ");
            strSql.Append("FROM O_Form_AuditPerson As AP with(nolock) ");
            strSql.Append("where AP.O_Form_AuditPerson_isDelete=0 ");
            strSql.Append("and AP.O_Form_AuditPerson_formAuditFlow=@O_Form_AuditPerson_formAuditFlow ");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Form_AuditPerson_formAuditFlow", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = formAuditFlowCode;
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
            strSql.Append(" O_Form_AuditPerson_id,O_Form_AuditPerson_code,O_Form_AuditPerson_auditPerson,O_Form_AuditPerson_auditTime,O_Form_AuditPerson_status,O_Form_AuditPerson_content,O_Form_AuditPerson_formAuditFlow,O_Form_AuditPerson_isDelete,O_Form_AuditPerson_creator,O_Form_AuditPerson_createTime ");
            strSql.Append(" FROM O_Form_AuditPerson ");
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
            strSql.Append("select count(1) FROM O_Form_AuditPerson ");
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
                strSql.Append("order by T.O_Form_AuditPerson_id desc");
            }
            strSql.Append(")AS Row, T.*  from O_Form_AuditPerson T ");
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
            parameters[0].Value = "O_Form_AuditPerson";
            parameters[1].Value = "O_Form_AuditPerson_id";
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
