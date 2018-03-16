using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件结案确认表
    /// 作者：贺太玉
    /// 日期：2015/09/22
    /// </summary>
    public partial class B_Case_Confirm
    {
        public B_Case_Confirm()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("B_Case_Confirm_id", "B_Case_Confirm");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_Confirm_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Case_Confirm");
            strSql.Append(" where B_Case_Confirm_id=@B_Case_Confirm_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Confirm_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_Confirm_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_Confirm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Case_Confirm(");
            strSql.Append("B_Case_Confirm_code,B_Case_code,P_Business_Flow_code,B_Case_Confirm_checkState,B_Case_Confirm_SuggestContent,B_Case_Confirm_remarks,B_Case_Confirm_creator,B_Case_Confirm_createTime,B_Case_Confirm_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@B_Case_Confirm_code,@B_Case_code,@P_Business_Flow_code,@B_Case_Confirm_checkState,@B_Case_Confirm_SuggestContent,@B_Case_Confirm_remarks,@B_Case_Confirm_creator,@B_Case_Confirm_createTime,@B_Case_Confirm_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Confirm_checkState", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Confirm_SuggestContent", SqlDbType.NVarChar,500),
					new SqlParameter("@B_Case_Confirm_remarks", SqlDbType.NVarChar,500),
					new SqlParameter("@B_Case_Confirm_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Confirm_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_Confirm_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.B_Case_Confirm_code;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.P_Business_Flow_code;
            parameters[3].Value = model.B_Case_Confirm_checkState;
            parameters[4].Value = model.B_Case_Confirm_SuggestContent;
            parameters[5].Value = model.B_Case_Confirm_remarks;
            parameters[6].Value = model.B_Case_Confirm_creator;
            parameters[7].Value = model.B_Case_Confirm_createTime;
            parameters[8].Value = model.B_Case_Confirm_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_Case_Confirm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case_Confirm set "); 
            strSql.Append("B_Case_code=@B_Case_code,");
            strSql.Append("P_Business_Flow_code=@P_Business_Flow_code,");
            strSql.Append("B_Case_Confirm_checkState=@B_Case_Confirm_checkState,");
            strSql.Append("B_Case_Confirm_SuggestContent=@B_Case_Confirm_SuggestContent,");
            strSql.Append("B_Case_Confirm_remarks=@B_Case_Confirm_remarks,");
            strSql.Append("B_Case_Confirm_creator=@B_Case_Confirm_creator,");
            strSql.Append("B_Case_Confirm_createTime=@B_Case_Confirm_createTime,");
            strSql.Append("B_Case_Confirm_isDelete=@B_Case_Confirm_isDelete");
            strSql.Append(" where B_Case_Confirm_code=@B_Case_Confirm_code");
            SqlParameter[] parameters = {					
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Confirm_checkState", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Confirm_SuggestContent", SqlDbType.NVarChar,500),
					new SqlParameter("@B_Case_Confirm_remarks", SqlDbType.NVarChar,500),
					new SqlParameter("@B_Case_Confirm_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Confirm_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_Confirm_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16)};           
            parameters[0].Value = model.B_Case_code;
            parameters[1].Value = model.P_Business_Flow_code;
            parameters[2].Value = model.B_Case_Confirm_checkState;
            parameters[3].Value = model.B_Case_Confirm_SuggestContent;
            parameters[4].Value = model.B_Case_Confirm_remarks;
            parameters[5].Value = model.B_Case_Confirm_creator;
            parameters[6].Value = model.B_Case_Confirm_createTime;
            parameters[7].Value = model.B_Case_Confirm_isDelete;

            parameters[8].Value = model.B_Case_Confirm_code;

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
        public bool Delete(Guid B_Case_Confirm_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case_Confirm set B_Case_Confirm_isDelete=1");
            strSql.Append(" where B_Case_Confirm_code=@B_Case_Confirm_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Confirm_code;

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
        public bool DeleteList(string B_Case_Confirm_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_Confirm ");
            strSql.Append(" where B_Case_Confirm_id in (" + B_Case_Confirm_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_Case_Confirm GetModel(Guid B_Case_Confirm_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 B_Case_Confirm_id,B_Case_Confirm_code,B_Case_code,P_Business_Flow_code,B_Case_Confirm_checkState,B_Case_Confirm_SuggestContent,B_Case_Confirm_remarks,B_Case_Confirm_creator,B_Case_Confirm_createTime,B_Case_Confirm_isDelete from B_Case_Confirm ");
            strSql.Append(" where B_Case_Confirm_code=@B_Case_Confirm_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Confirm_code;

            CommonService.Model.CaseManager.B_Case_Confirm model = new CommonService.Model.CaseManager.B_Case_Confirm();
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
        /// 当前用户是否有“确认结案”按钮权限
        /// </summary>
        /// <param name="B_Case_code">案件Guid</param>
        /// <param name="personCode">当前用户Guid</param>
        /// <returns></returns>
        public CommonService.Model.CaseManager.B_Case_Confirm GetModelByCaseAndPerson(Guid B_Case_code, Guid personCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 T.B_Case_Confirm_id,T.B_Case_Confirm_code,T.B_Case_code,T.P_Business_Flow_code,T.B_Case_Confirm_checkState,T.B_Case_Confirm_SuggestContent,T.B_Case_Confirm_remarks,T.B_Case_Confirm_creator,T.B_Case_Confirm_createTime,T.B_Case_Confirm_isDelete ");
            strSql.Append("from B_Case_Confirm as T ");
            strSql.Append("where T.B_Case_Confirm_isDelete=0 ");
            strSql.Append("and T.B_Case_code=@B_Case_code ");
            strSql.Append("and T.B_Case_Confirm_checkState <> 956 ");
            strSql.Append("and exists(select top 1 * from B_Case_Check as CC where CC.B_Case_Confirm_code=T.B_Case_Confirm_code and CC.B_Case_Check_State=967 and CC.B_Case_Check_checkPerson=@B_Case_Check_checkPerson)");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Check_checkPerson",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_code;
            parameters[1].Value = personCode;

            CommonService.Model.CaseManager.B_Case_Confirm model = new CommonService.Model.CaseManager.B_Case_Confirm();
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
        /// 根据案件Guid和业务流程Guid得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Confirm GetModelByCaseAndBusinessFlow(Guid B_Case_code, Guid P_Business_Flow_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 B_Case_Confirm_id,B_Case_Confirm_code,B_Case_code,P_Business_Flow_code,B_Case_Confirm_checkState,B_Case_Confirm_SuggestContent,B_Case_Confirm_remarks,B_Case_Confirm_creator,B_Case_Confirm_createTime,B_Case_Confirm_isDelete from B_Case_Confirm ");
            strSql.Append(" where B_Case_code=@B_Case_code ");
            strSql.Append("and P_Business_Flow_code=@P_Business_Flow_code ");
            strSql.Append("and B_Case_Confirm_isDelete=0 ");
            strSql.Append("order by B_Case_Confirm_id desc");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_Flow_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_code;
            parameters[1].Value = P_Business_Flow_code;

            CommonService.Model.CaseManager.B_Case_Confirm model = new CommonService.Model.CaseManager.B_Case_Confirm();
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
        public CommonService.Model.CaseManager.B_Case_Confirm DataRowToModel(DataRow row)
        {
            CommonService.Model.CaseManager.B_Case_Confirm model = new CommonService.Model.CaseManager.B_Case_Confirm();
            if (row != null)
            {
                if (row["B_Case_Confirm_id"] != null && row["B_Case_Confirm_id"].ToString() != "")
                {
                    model.B_Case_Confirm_id = int.Parse(row["B_Case_Confirm_id"].ToString());
                }
                if (row["B_Case_Confirm_code"] != null && row["B_Case_Confirm_code"].ToString() != "")
                {
                    model.B_Case_Confirm_code = new Guid(row["B_Case_Confirm_code"].ToString());
                }
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString() != "")
                {
                    model.B_Case_code = new Guid(row["B_Case_code"].ToString());
                }
                if (row["P_Business_Flow_code"] != null && row["P_Business_Flow_code"].ToString() != "")
                {
                    model.P_Business_Flow_code = new Guid(row["P_Business_Flow_code"].ToString());
                }
                if (row["B_Case_Confirm_checkState"] != null && row["B_Case_Confirm_checkState"].ToString() != "")
                {
                    model.B_Case_Confirm_checkState = int.Parse(row["B_Case_Confirm_checkState"].ToString());
                }
                if (row["B_Case_Confirm_SuggestContent"] != null)
                {
                    model.B_Case_Confirm_SuggestContent = row["B_Case_Confirm_SuggestContent"].ToString();
                }
                if (row["B_Case_Confirm_remarks"] != null)
                {
                    model.B_Case_Confirm_remarks = row["B_Case_Confirm_remarks"].ToString();
                }
                if (row["B_Case_Confirm_creator"] != null && row["B_Case_Confirm_creator"].ToString() != "")
                {
                    model.B_Case_Confirm_creator = new Guid(row["B_Case_Confirm_creator"].ToString());
                }
                //创建人(操作人)名称(虚拟属性)，(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_Confirm_creator_name"))
                {
                    if (row["B_Case_Confirm_creator_name"] != null)
                    {
                        model.B_Case_Confirm_creator_name = row["B_Case_Confirm_creator_name"].ToString();
                    }
                }
                if (row["B_Case_Confirm_createTime"] != null && row["B_Case_Confirm_createTime"].ToString() != "")
                {
                    model.B_Case_Confirm_createTime = DateTime.Parse(row["B_Case_Confirm_createTime"].ToString());
                }
                if (row["B_Case_Confirm_isDelete"] != null && row["B_Case_Confirm_isDelete"].ToString() != "")
                {
                    if ((row["B_Case_Confirm_isDelete"].ToString() == "1") || (row["B_Case_Confirm_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.B_Case_Confirm_isDelete = true;
                    }
                    else
                    {
                        model.B_Case_Confirm_isDelete = false;
                    }
                }
                if (row.Table.Columns.Contains("P_Business_Flow_name"))
                {
                    if (row["P_Business_Flow_name"] != null && row["P_Business_Flow_name"].ToString() != "")
                    {
                        model.P_Business_Flow_name = row["P_Business_Flow_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_Case_Confirm_checkStateName"))
                {
                    if (row["B_Case_Confirm_checkStateName"] != null && row["B_Case_Confirm_checkStateName"].ToString() != "")
                    {
                        model.B_Case_Confirm_checkStateName = row["B_Case_Confirm_checkStateName"].ToString();
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 根据案件Guid和业务流程Guid获取数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetListByCaseAndBusinessFlow(Guid caseCode,Guid businessFlowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BC.*,C.C_Userinfo_name As B_Case_Confirm_creator_name ");
            strSql.Append("FROM B_Case_Confirm As BC with(nolock) ");
            strSql.Append("left join C_Userinfo As C with(nolock) on BC.B_Case_Confirm_creator=C.C_Userinfo_code ");
            strSql.Append("where BC.B_Case_code=@B_Case_code and BC.P_Business_Flow_code = @P_Business_Flow_code and BC.B_Case_Confirm_isDelete=0 ");
            strSql.Append("order by BC.B_Case_Confirm_id desc");
           
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_Flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = caseCode;
            parameters[1].Value = businessFlowCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

         /// <summary>
        /// 根据案件Guid获取数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public DataSet GetListByCaseCode(Guid caseCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BC.*,C.C_Userinfo_name As B_Case_Confirm_creator_name,PBF.P_Business_flow_name As P_Business_Flow_name,P.C_Parameters_name as B_Case_Confirm_checkStateName ");
            strSql.Append("FROM B_Case_Confirm As BC with(nolock) ");
            strSql.Append("left join C_Userinfo As C with(nolock) on BC.B_Case_Confirm_creator=C.C_Userinfo_code ");
            strSql.Append("left join P_Business_flow as PBF on BC.P_Business_Flow_code=PBF.P_Business_flow_code ");
            strSql.Append("left join C_Parameters as P on BC.B_Case_Confirm_checkState=P.C_Parameters_id ");
            strSql.Append("where BC.B_Case_code=@B_Case_code and BC.B_Case_Confirm_isDelete=0 ");
            strSql.Append("order by BC.B_Case_Confirm_id desc");

            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = caseCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select B_Case_Confirm_id,B_Case_Confirm_code,B_Case_code,P_Business_Flow_code,B_Case_Confirm_checkState,B_Case_Confirm_SuggestContent,B_Case_Confirm_remarks,B_Case_Confirm_creator,B_Case_Confirm_createTime,B_Case_Confirm_isDelete ");
            strSql.Append(" FROM B_Case_Confirm ");
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
            strSql.Append(" B_Case_Confirm_id,B_Case_Confirm_code,B_Case_code,P_Business_Flow_code,B_Case_Confirm_checkState,B_Case_Confirm_SuggestContent,B_Case_Confirm_remarks,B_Case_Confirm_creator,B_Case_Confirm_createTime,B_Case_Confirm_isDelete ");
            strSql.Append(" FROM B_Case_Confirm ");
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
            strSql.Append("select count(1) FROM B_Case_Confirm ");
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
                strSql.Append("order by T.B_Case_Confirm_id desc");
            }
            strSql.Append(")AS Row, T.*  from B_Case_Confirm T ");
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
            parameters[0].Value = "B_Case_Confirm";
            parameters[1].Value = "B_Case_Confirm_id";
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
