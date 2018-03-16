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
    /// 数据访问类:流程预设表
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_FlowSet
    {
        public O_FlowSet()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("O_FlowSet_id", "O_FlowSet");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_FlowSet_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_FlowSet");
            strSql.Append(" where O_FlowSet_id=@O_FlowSet_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_FlowSet_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_FlowSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_FlowSet(");
            strSql.Append("O_FlowSet_code,O_FlowSet_name,O_FlowSet_flow,O_FlowSet_order,O_FlowSet_auditType,O_FlowSet_rule,O_FlowSet_isDelete,O_FlowSet_creator,O_FlowSet_createTime)");
            strSql.Append(" values (");
            strSql.Append("@O_FlowSet_code,@O_FlowSet_name,@O_FlowSet_flow,@O_FlowSet_order,@O_FlowSet_auditType,@O_FlowSet_rule,@O_FlowSet_isDelete,@O_FlowSet_creator,@O_FlowSet_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_name", SqlDbType.VarChar,100),
					new SqlParameter("@O_FlowSet_flow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_order", SqlDbType.Int,4),
					new SqlParameter("@O_FlowSet_auditType", SqlDbType.Int,4),
					new SqlParameter("@O_FlowSet_rule", SqlDbType.NVarChar,500),
					new SqlParameter("@O_FlowSet_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_FlowSet_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.O_FlowSet_code;
            parameters[1].Value = model.O_FlowSet_name;
            parameters[2].Value = model.O_FlowSet_flow;
            parameters[3].Value = model.O_FlowSet_order;
            parameters[4].Value = model.O_FlowSet_auditType;
            parameters[5].Value = model.O_FlowSet_rule;
            parameters[6].Value = model.O_FlowSet_isDelete;
            parameters[7].Value = model.O_FlowSet_creator;
            parameters[8].Value = model.O_FlowSet_createTime;

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
        public bool Update(CommonService.Model.OA.O_FlowSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_FlowSet set ");
            strSql.Append("O_FlowSet_code=@O_FlowSet_code,");
            strSql.Append("O_FlowSet_name=@O_FlowSet_name,");
            strSql.Append("O_FlowSet_flow=@O_FlowSet_flow,");
            strSql.Append("O_FlowSet_order=@O_FlowSet_order,");
            strSql.Append("O_FlowSet_auditType=@O_FlowSet_auditType,");
            strSql.Append("O_FlowSet_rule=@O_FlowSet_rule,");
            strSql.Append("O_FlowSet_isDelete=@O_FlowSet_isDelete,");
            strSql.Append("O_FlowSet_creator=@O_FlowSet_creator,");
            strSql.Append("O_FlowSet_createTime=@O_FlowSet_createTime");
            strSql.Append(" where O_FlowSet_id=@O_FlowSet_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_name", SqlDbType.VarChar,100),
					new SqlParameter("@O_FlowSet_flow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_order", SqlDbType.Int,4),
					new SqlParameter("@O_FlowSet_auditType", SqlDbType.Int,4),
					new SqlParameter("@O_FlowSet_rule", SqlDbType.NVarChar,500),
					new SqlParameter("@O_FlowSet_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_FlowSet_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_FlowSet_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_FlowSet_code;
            parameters[1].Value = model.O_FlowSet_name;
            parameters[2].Value = model.O_FlowSet_flow;
            parameters[3].Value = model.O_FlowSet_order;
            parameters[4].Value = model.O_FlowSet_auditType;
            parameters[5].Value = model.O_FlowSet_rule;
            parameters[6].Value = model.O_FlowSet_isDelete;
            parameters[7].Value = model.O_FlowSet_creator;
            parameters[8].Value = model.O_FlowSet_createTime;
            parameters[9].Value = model.O_FlowSet_id;

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
        public bool Delete(Guid O_FlowSet_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_FlowSet set O_FlowSet_isDelete = 1 ");
            strSql.Append(" where O_FlowSet_code=@O_FlowSet_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_FlowSet_code;

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
        public bool DeleteList(string O_FlowSet_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_FlowSet ");
            strSql.Append(" where O_FlowSet_id in (" + O_FlowSet_idlist + ")  ");
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
        public CommonService.Model.OA.O_FlowSet GetModel(Guid O_FlowSet_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_FlowSet_id,O_FlowSet_code,O_FlowSet_name,O_FlowSet_flow,O_FlowSet_order,O_FlowSet_auditType,O_FlowSet_rule,O_FlowSet_isDelete,O_FlowSet_creator,O_FlowSet_createTime,dbo.getFlowsetUserlists(O_FlowSet_code) As O_Flowset_personNames_Lists from O_FlowSet ");
            strSql.Append(" where O_FlowSet_code=@O_FlowSet_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_FlowSet_code;

            CommonService.Model.OA.O_FlowSet model = new CommonService.Model.OA.O_FlowSet();
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
        /// 根据流程guid得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_FlowSet GetModelByFlowCode(Guid O_FlowSet_flow)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_FlowSet_id,O_FlowSet_code,O_FlowSet_name,O_FlowSet_flow,O_FlowSet_order,O_FlowSet_auditType,O_FlowSet_rule,O_FlowSet_isDelete,O_FlowSet_creator,O_FlowSet_createTime,dbo.getFlowsetUserlists(O_FlowSet_code) As O_Flowset_personNames_Lists from O_FlowSet ");
            strSql.Append(" where O_FlowSet_flow=@O_FlowSet_flow ");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_FlowSet_flow", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = O_FlowSet_flow;

            CommonService.Model.OA.O_FlowSet model = new CommonService.Model.OA.O_FlowSet();
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
        public CommonService.Model.OA.O_FlowSet DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_FlowSet model = new CommonService.Model.OA.O_FlowSet();
            if (row != null)
            {
                if (row["O_FlowSet_id"] != null && row["O_FlowSet_id"].ToString() != "")
                {
                    model.O_FlowSet_id = int.Parse(row["O_FlowSet_id"].ToString());
                }
                if (row["O_FlowSet_code"] != null && row["O_FlowSet_code"].ToString() != "")
                {
                    model.O_FlowSet_code = new Guid(row["O_FlowSet_code"].ToString());
                }
                if (row["O_FlowSet_name"] != null)
                {
                    model.O_FlowSet_name = row["O_FlowSet_name"].ToString();
                }
                if (row["O_FlowSet_flow"] != null && row["O_FlowSet_flow"].ToString() != "")
                {
                    model.O_FlowSet_flow = new Guid(row["O_FlowSet_flow"].ToString());
                }
                if (row["O_FlowSet_order"] != null && row["O_FlowSet_order"].ToString() != "")
                {
                    model.O_FlowSet_order = int.Parse(row["O_FlowSet_order"].ToString());
                }
                if (row["O_FlowSet_auditType"] != null && row["O_FlowSet_auditType"].ToString() != "")
                {
                    model.O_FlowSet_auditType = int.Parse(row["O_FlowSet_auditType"].ToString());
                }
                if (row["O_FlowSet_rule"] != null)
                {
                    model.O_FlowSet_rule = row["O_FlowSet_rule"].ToString();
                }
                if (row["O_FlowSet_isDelete"] != null && row["O_FlowSet_isDelete"].ToString() != "")
                {
                    if ((row["O_FlowSet_isDelete"].ToString() == "1") || (row["O_FlowSet_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_FlowSet_isDelete = true;
                    }
                    else
                    {
                        model.O_FlowSet_isDelete = false;
                    }
                }
                if (row["O_FlowSet_creator"] != null && row["O_FlowSet_creator"].ToString() != "")
                {
                    model.O_FlowSet_creator = new Guid(row["O_FlowSet_creator"].ToString());
                }
                if (row["O_FlowSet_createTime"] != null && row["O_FlowSet_createTime"].ToString() != "")
                {
                    model.O_FlowSet_createTime = DateTime.Parse(row["O_FlowSet_createTime"].ToString());
                }
                //虚拟字段(审核类型名称)是否存在
                if (row.Table.Columns.Contains("O_FlowSet_auditTypename"))
                {
                    if (row["O_FlowSet_auditTypename"] != null && row["O_FlowSet_auditTypename"].ToString() != "")
                    {
                        model.O_FlowSet_auditTypename = row["O_FlowSet_auditTypename"].ToString();
                    }
                }
                //虚拟字段(审核人名称)是否存在
                if (row.Table.Columns.Contains("O_FlowSet_audit_personNames"))
                {
                    if (row["O_FlowSet_audit_personNames"] != null && row["O_FlowSet_audit_personNames"].ToString() != "")
                    {
                        model.O_FlowSet_audit_personNames = row["O_FlowSet_audit_personNames"].ToString();
                    }
                }
                //虚拟字段(审核人名称集合)是否存在
                if (row.Table.Columns.Contains("O_Flowset_personNames_Lists"))
                {
                    if (row["O_Flowset_personNames_Lists"] != null && row["O_Flowset_personNames_Lists"].ToString() != "")
                    {
                        model.O_Flowset_personNames_Lists = row["O_Flowset_personNames_Lists"].ToString();
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
            strSql.Append("select O_FlowSet_id,O_FlowSet_code,O_FlowSet_name,O_FlowSet_flow,O_FlowSet_order,O_FlowSet_auditType,O_FlowSet_rule,O_FlowSet_isDelete,O_FlowSet_creator,O_FlowSet_createTime ");
            strSql.Append(" FROM O_FlowSet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据所属流程guid获得数据列表
        /// </summary>
        public DataSet GetListByFlowCode(Guid? flowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_FlowSet_id,O_FlowSet_code,O_FlowSet_name,O_FlowSet_flow,O_FlowSet_order,O_FlowSet_auditType,O_FlowSet_rule,O_FlowSet_isDelete,O_FlowSet_creator,O_FlowSet_createTime ");
            strSql.Append(" FROM O_FlowSet ");
            strSql.Append(" where 1=1 ");
            if (flowCode != null)
            {
                strSql.Append(" and O_FlowSet_flow=@O_FlowSet_flow ");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@O_FlowSet_flow", SqlDbType.UniqueIdentifier, 16)
                    };
            parameters[0].Value = flowCode;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
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
            strSql.Append(" O_FlowSet_id,O_FlowSet_code,O_FlowSet_name,O_FlowSet_flow,O_FlowSet_order,O_FlowSet_auditType,O_FlowSet_rule,O_FlowSet_isDelete,O_FlowSet_creator,O_FlowSet_createTime ");
            strSql.Append(" FROM O_FlowSet ");
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
        public int GetRecordCount(CommonService.Model.OA.O_FlowSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM O_FlowSet ");
            strSql.Append(" where 1=1 and  O_FlowSet_isDelete=0 ");
            if (model != null)
            {
                if (model.O_FlowSet_flow != null)
                {
                    strSql.Append(" and O_FlowSet_flow=@O_FlowSet_flow ");
                }
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@O_FlowSet_flow", SqlDbType.UniqueIdentifier, 16),};
            parameters[0].Value = model.O_FlowSet_flow;
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
        public DataSet GetListByPage(CommonService.Model.OA.O_FlowSet model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.O_FlowSet_createTime desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name As O_FlowSet_auditTypename,dbo.getFlowsetUserlists(T.O_FlowSet_code) As O_Flowset_personNames_Lists  from O_FlowSet T ");
            strSql.Append(" left join C_Parameters As P on P.C_Parameters_id= T.O_FlowSet_auditType");
            strSql.Append(" where 1=1 and O_FlowSet_isDelete=0 ");
            if (model != null)
            {
                if (model.O_FlowSet_flow != null)
                {
                    strSql.Append(" and O_FlowSet_flow=@O_FlowSet_flow ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
                    new SqlParameter("@O_FlowSet_flow", SqlDbType.UniqueIdentifier, 16),};
            parameters[0].Value = model.O_FlowSet_flow;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            parameters[0].Value = "O_FlowSet";
            parameters[1].Value = "O_FlowSet_id";
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
