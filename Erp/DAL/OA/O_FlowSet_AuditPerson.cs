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
    /// 数据访问类:流程预设审批人表
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_FlowSet_AuditPerson
    {
        public O_FlowSet_AuditPerson()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("O_FlowSet_auditPerson_id", "O_FlowSet_AuditPerson");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_FlowSet_auditPerson_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_FlowSet_AuditPerson");
            strSql.Append(" where O_FlowSet_auditPerson_id=@O_FlowSet_auditPerson_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_auditPerson_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_FlowSet_auditPerson_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_FlowSet_AuditPerson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_FlowSet_AuditPerson(");
            strSql.Append("O_FlowSet_auditPerson_code,O_FlowSet_auditPerson_flowSet,O_FlowSet_auditPerson_auditPerson,O_FlowSet_auditPerson_isDelete,O_FlowSet_auditPerson_creator,O_FlowSet_auditPerson_createTime)");
            strSql.Append(" values (");
            strSql.Append("@O_FlowSet_auditPerson_code,@O_FlowSet_auditPerson_flowSet,@O_FlowSet_auditPerson_auditPerson,@O_FlowSet_auditPerson_isDelete,@O_FlowSet_auditPerson_creator,@O_FlowSet_auditPerson_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_auditPerson_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_auditPerson_flowSet", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_auditPerson_auditPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_auditPerson_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_FlowSet_auditPerson_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_auditPerson_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.O_FlowSet_auditPerson_code;
            parameters[1].Value = model.O_FlowSet_auditPerson_flowSet;
            parameters[2].Value = model.O_FlowSet_auditPerson_auditPerson;
            parameters[3].Value = model.O_FlowSet_auditPerson_isDelete;
            parameters[4].Value = model.O_FlowSet_auditPerson_creator;
            parameters[5].Value = model.O_FlowSet_auditPerson_createTime;

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
        public bool Update(CommonService.Model.OA.O_FlowSet_AuditPerson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_FlowSet_AuditPerson set ");
            strSql.Append("O_FlowSet_auditPerson_code=@O_FlowSet_auditPerson_code,");
            strSql.Append("O_FlowSet_auditPerson_flowSet=@O_FlowSet_auditPerson_flowSet,");
            strSql.Append("O_FlowSet_auditPerson_auditPerson=@O_FlowSet_auditPerson_auditPerson,");
            strSql.Append("O_FlowSet_auditPerson_isDelete=@O_FlowSet_auditPerson_isDelete,");
            strSql.Append("O_FlowSet_auditPerson_creator=@O_FlowSet_auditPerson_creator,");
            strSql.Append("O_FlowSet_auditPerson_createTime=@O_FlowSet_auditPerson_createTime");
            strSql.Append(" where O_FlowSet_auditPerson_id=@O_FlowSet_auditPerson_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_auditPerson_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_auditPerson_flowSet", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_auditPerson_auditPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_auditPerson_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_FlowSet_auditPerson_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_FlowSet_auditPerson_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_FlowSet_auditPerson_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_FlowSet_auditPerson_code;
            parameters[1].Value = model.O_FlowSet_auditPerson_flowSet;
            parameters[2].Value = model.O_FlowSet_auditPerson_auditPerson;
            parameters[3].Value = model.O_FlowSet_auditPerson_isDelete;
            parameters[4].Value = model.O_FlowSet_auditPerson_creator;
            parameters[5].Value = model.O_FlowSet_auditPerson_createTime;
            parameters[6].Value = model.O_FlowSet_auditPerson_id;

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
        /// 修改某个流程预设的审核人为删除
        /// </summary>
        public bool UpdateList(Guid? O_FlowSet_auditPerson_flowSet)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_FlowSet_AuditPerson set ");
            strSql.Append("O_FlowSet_auditPerson_isDelete=1 ");
            strSql.Append(" where O_FlowSet_auditPerson_flowSet=@O_FlowSet_auditPerson_flowSet");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_auditPerson_flowSet", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = O_FlowSet_auditPerson_flowSet;
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
        public bool Delete(Guid O_FlowSet_auditPerson_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_FlowSet_AuditPerson set O_FlowSet_auditPerson_isDelete = 1 ");
            strSql.Append(" where O_FlowSet_auditPerson_code=@O_FlowSet_auditPerson_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_auditPerson_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_FlowSet_auditPerson_code;

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
        public bool DeleteList(string O_FlowSet_auditPerson_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_FlowSet_AuditPerson ");
            strSql.Append(" where O_FlowSet_auditPerson_id in (" + O_FlowSet_auditPerson_idlist + ")  ");
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
        public CommonService.Model.OA.O_FlowSet_AuditPerson GetModel(Guid O_FlowSet_auditPerson_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_FlowSet_auditPerson_id,O_FlowSet_auditPerson_code,O_FlowSet_auditPerson_flowSet,O_FlowSet_auditPerson_auditPerson,O_FlowSet_auditPerson_isDelete,O_FlowSet_auditPerson_creator,O_FlowSet_auditPerson_createTime from O_FlowSet_AuditPerson ");
            strSql.Append(" where O_FlowSet_auditPerson_id=@O_FlowSet_auditPerson_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_FlowSet_auditPerson_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_FlowSet_auditPerson_code;

            CommonService.Model.OA.O_FlowSet_AuditPerson model = new CommonService.Model.OA.O_FlowSet_AuditPerson();
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
        public CommonService.Model.OA.O_FlowSet_AuditPerson DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_FlowSet_AuditPerson model = new CommonService.Model.OA.O_FlowSet_AuditPerson();
            if (row != null)
            {
                if (row["O_FlowSet_auditPerson_id"] != null && row["O_FlowSet_auditPerson_id"].ToString() != "")
                {
                    model.O_FlowSet_auditPerson_id = int.Parse(row["O_FlowSet_auditPerson_id"].ToString());
                }
                if (row["O_FlowSet_auditPerson_code"] != null && row["O_FlowSet_auditPerson_code"].ToString() != "")
                {
                    model.O_FlowSet_auditPerson_code = new Guid(row["O_FlowSet_auditPerson_code"].ToString());
                }
                if (row["O_FlowSet_auditPerson_flowSet"] != null && row["O_FlowSet_auditPerson_flowSet"].ToString() != "")
                {
                    model.O_FlowSet_auditPerson_flowSet = new Guid(row["O_FlowSet_auditPerson_flowSet"].ToString());
                }
                if (row["O_FlowSet_auditPerson_auditPerson"] != null && row["O_FlowSet_auditPerson_auditPerson"].ToString() != "")
                {
                    model.O_FlowSet_auditPerson_auditPerson = new Guid(row["O_FlowSet_auditPerson_auditPerson"].ToString());
                }
                if (row["O_FlowSet_auditPerson_isDelete"] != null && row["O_FlowSet_auditPerson_isDelete"].ToString() != "")
                {
                    if ((row["O_FlowSet_auditPerson_isDelete"].ToString() == "1") || (row["O_FlowSet_auditPerson_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_FlowSet_auditPerson_isDelete = true;
                    }
                    else
                    {
                        model.O_FlowSet_auditPerson_isDelete = false;
                    }
                }
                if (row["O_FlowSet_auditPerson_creator"] != null && row["O_FlowSet_auditPerson_creator"].ToString() != "")
                {
                    model.O_FlowSet_auditPerson_creator = new Guid(row["O_FlowSet_auditPerson_creator"].ToString());
                }
                if (row["O_FlowSet_auditPerson_createTime"] != null && row["O_FlowSet_auditPerson_createTime"].ToString() != "")
                {
                    model.O_FlowSet_auditPerson_createTime = DateTime.Parse(row["O_FlowSet_auditPerson_createTime"].ToString());
                }
                //虚拟字段是否存在于集合中（表单审批流程表guid）
                if (row.Table.Columns.Contains("O_Form_AuditFlow_code"))
                {
                    if (row["O_Form_AuditFlow_code"] != null && row["O_Form_AuditFlow_code"].ToString() != "")
                    {
                        model.O_Form_AuditFlow_code = new Guid(row["O_Form_AuditFlow_code"].ToString());
                    }
                }
                //虚拟字段是否存在于集合中（顺序）
                if (row.Table.Columns.Contains("O_FlowSet_order"))
                {
                    if (row["O_FlowSet_order"] != null && row["O_FlowSet_order"].ToString() != "")
                    {
                        model.O_FlowSet_order = Convert.ToInt32(row["O_FlowSet_order"].ToString());
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
            strSql.Append("select O_FlowSet_auditPerson_id,O_FlowSet_auditPerson_code,O_FlowSet_auditPerson_flowSet,O_FlowSet_auditPerson_auditPerson,O_FlowSet_auditPerson_isDelete,O_FlowSet_auditPerson_creator,O_FlowSet_auditPerson_createTime ");
            strSql.Append(" FROM O_FlowSet_AuditPerson ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据预设流程GUID获得数据列表
        /// </summary>
        public DataSet GetListByflowSetCode(Guid flowsetCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_FlowSet_auditPerson_id,O_FlowSet_auditPerson_code,O_FlowSet_auditPerson_flowSet,O_FlowSet_auditPerson_auditPerson,O_FlowSet_auditPerson_isDelete,O_FlowSet_auditPerson_creator,O_FlowSet_auditPerson_createTime ");
            strSql.Append(" FROM O_FlowSet_AuditPerson where O_FlowSet_auditPerson_flowSet=@O_FlowSet_auditPerson_flowSet and O_FlowSet_auditPerson_isDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_FlowSet_auditPerson_flowSet", SqlDbType.UniqueIdentifier, 16)
                    };
            parameters[0].Value = flowsetCode;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 根据所属流程GUID获得数据列表
        /// </summary>
        public DataSet GetListByflowCode(Guid flowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_FlowSet_auditPerson_id,O_FlowSet_auditPerson_code,O_FlowSet_auditPerson_flowSet,O_FlowSet_auditPerson_auditPerson,O_FlowSet_auditPerson_isDelete,O_FlowSet_auditPerson_creator,O_FlowSet_auditPerson_createTime,C.O_Form_AuditFlow_code As O_Form_AuditFlow_code,A.O_FlowSet_order As O_FlowSet_order ");
            strSql.Append(" FROM O_FlowSet As A left join O_FlowSet_AuditPerson As B on A.O_FlowSet_code=B.O_FlowSet_auditPerson_flowSet left join O_Form_AuditFlow As C on C.O_Form_AuditFlow_flowSet=B.O_FlowSet_auditPerson_flowSet where O_FlowSet_flow=@O_FlowSet_flow and C.O_Form_AuditFlow_flowSet=@O_FlowSet_flow and O_FlowSet_auditPerson_isDelete=0 and O_FlowSet_isDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_FlowSet_flow", SqlDbType.UniqueIdentifier, 16)
                    };
            parameters[0].Value = flowCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据预设审批GUID获得流程审批人数据列表
        /// </summary>
        public DataSet GetApplyListByflowCode(Guid flowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_FlowSet_auditPerson_id,O_FlowSet_auditPerson_code,O_FlowSet_auditPerson_flowSet,O_FlowSet_auditPerson_auditPerson,O_FlowSet_auditPerson_isDelete,O_FlowSet_auditPerson_creator,O_FlowSet_auditPerson_createTime,A.O_FlowSet_order As O_FlowSet_order ");
            strSql.Append(" FROM O_FlowSet As A left join O_FlowSet_AuditPerson As B on A.O_FlowSet_code=B.O_FlowSet_auditPerson_flowSet  where O_FlowSet_code=@O_FlowSet_flow and O_FlowSet_auditPerson_isDelete=0 and O_FlowSet_isDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_FlowSet_flow", SqlDbType.UniqueIdentifier, 16)
                    };
            parameters[0].Value = flowCode;
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
            strSql.Append(" O_FlowSet_auditPerson_id,O_FlowSet_auditPerson_code,O_FlowSet_auditPerson_flowSet,O_FlowSet_auditPerson_auditPerson,O_FlowSet_auditPerson_isDelete,O_FlowSet_auditPerson_creator,O_FlowSet_auditPerson_createTime ");
            strSql.Append(" FROM O_FlowSet_AuditPerson ");
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
            strSql.Append("select count(1) FROM O_FlowSet_AuditPerson ");
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
                strSql.Append("order by T.O_FlowSet_auditPerson_id desc");
            }
            strSql.Append(")AS Row, T.*  from O_FlowSet_AuditPerson T ");
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
            parameters[0].Value = "O_FlowSet_AuditPerson";
            parameters[1].Value = "O_FlowSet_auditPerson_id";
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
