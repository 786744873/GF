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
    /// 数据访问类:B_Case_plan办案方案表
    /// </summary>
    public partial class B_Case_plan
    {
        public B_Case_plan()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid? B_Case_plan_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Case_plan");
            strSql.Append(" where B_Case_plan_code=@B_Case_plan_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_plan_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_plan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Case_plan(");
            strSql.Append("B_Case_plan_code,B_Case_code,B_Case_plan_evidence,B_Case_plan_plaintiffReason,B_Case_plan_defendantReason,B_Case_plan_qualityControl,B_Case_plan_scheduleControl,B_Case_plan_incomecControl,B_Case_plan_costControl,B_Case_plan_creator,B_Case_plan_createTime,B_Case_plan_isDelete,B_Case_plan_Court_code)");
            strSql.Append(" values (");
            strSql.Append("@B_Case_plan_code,@B_Case_code,@B_Case_plan_evidence,@B_Case_plan_plaintiffReason,@B_Case_plan_defendantReason,@B_Case_plan_qualityControl,@B_Case_plan_scheduleControl,@B_Case_plan_incomecControl,@B_Case_plan_costControl,@B_Case_plan_creator,@B_Case_plan_createTime,@B_Case_plan_isDelete,@B_Case_plan_Court_code)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_evidence", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_plan_plaintiffReason", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_plan_defendantReason", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_plan_qualityControl", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_plan_scheduleControl", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_plan_incomecControl", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_plan_costControl", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_plan_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_plan_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_plan_Court_code", SqlDbType.UniqueIdentifier,16),    
                                        };

            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Case_plan_evidence;
            parameters[3].Value = model.B_Case_plan_plaintiffReason;
            parameters[4].Value = model.B_Case_plan_defendantReason;
            parameters[5].Value = model.B_Case_plan_qualityControl;
            parameters[6].Value = model.B_Case_plan_scheduleControl;
            parameters[7].Value = model.B_Case_plan_incomecControl;
            parameters[8].Value = model.B_Case_plan_costControl;
            parameters[9].Value = Guid.NewGuid();
            parameters[10].Value = model.B_Case_plan_createTime;
            parameters[11].Value = model.B_Case_plan_isDelete;
            parameters[12].Value = model.B_Case_plan_Court_code;
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
        public bool Update(CommonService.Model.CaseManager.B_Case_plan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case_plan set ");
            strSql.Append("B_Case_code=@B_Case_code,");
            strSql.Append("B_Case_plan_evidence=@B_Case_plan_evidence,");
            strSql.Append("B_Case_plan_plaintiffReason=@B_Case_plan_plaintiffReason,");
            strSql.Append("B_Case_plan_defendantReason=@B_Case_plan_defendantReason,");
            strSql.Append("B_Case_plan_qualityControl=@B_Case_plan_qualityControl,");
            strSql.Append("B_Case_plan_scheduleControl=@B_Case_plan_scheduleControl,");
            strSql.Append("B_Case_plan_incomecControl=@B_Case_plan_incomecControl,");
            strSql.Append("B_Case_plan_costControl=@B_Case_plan_costControl,");
            strSql.Append("B_Case_plan_creator=@B_Case_plan_creator,");
            strSql.Append("B_Case_plan_createTime=@B_Case_plan_createTime,");
            strSql.Append("B_Case_plan_isDelete=@B_Case_plan_isDelete,");
            strSql.Append("B_Case_plan_Court_code=@B_Case_plan_Court_code ");
            strSql.Append(" where B_Case_plan_code=@B_Case_plan_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_evidence", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_plan_plaintiffReason", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_plan_defendantReason", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_plan_qualityControl", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_plan_scheduleControl", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_plan_incomecControl", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_plan_costControl", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_plan_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_plan_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_plan_Court_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_plan_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.B_Case_code;
            parameters[1].Value = model.B_Case_plan_evidence;
            parameters[2].Value = model.B_Case_plan_plaintiffReason;
            parameters[3].Value = model.B_Case_plan_defendantReason;
            parameters[4].Value = model.B_Case_plan_qualityControl;
            parameters[5].Value = model.B_Case_plan_scheduleControl;
            parameters[6].Value = model.B_Case_plan_incomecControl;
            parameters[7].Value = model.B_Case_plan_costControl;
            parameters[8].Value = model.B_Case_plan_creator;
            parameters[9].Value = model.B_Case_plan_createTime;
            parameters[10].Value = model.B_Case_plan_isDelete;
            parameters[11].Value = model.B_Case_plan_Court_code;
            parameters[12].Value = model.B_Case_plan_code;
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
        public bool Delete(int B_Case_plan_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_plan ");
            strSql.Append(" where B_Case_plan_id=@B_Case_plan_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_plan_id;

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
        public bool DeleteList(string B_Case_plan_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_plan ");
            strSql.Append(" where B_Case_plan_id in (" + B_Case_plan_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_Case_plan GetModel(int B_Case_plan_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_plan_id,B_Case_plan_code,B_Case_code,B_Case_plan_evidence,B_Case_plan_plaintiffReason,B_Case_plan_defendantReason,B_Case_plan_qualityControl,B_Case_plan_scheduleControl,B_Case_plan_incomecControl,B_Case_plan_costControl,B_Case_plan_creator,B_Case_plan_createTime,B_Case_plan_isDelete,B_Case_plan_Court_code from B_Case_plan ");
            strSql.Append(" where B_Case_plan_id=@B_Case_plan_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_plan_id;

            CommonService.Model.CaseManager.B_Case_plan model = new CommonService.Model.CaseManager.B_Case_plan();
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
        /// 得到一个对象实体 通过案件GUID
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan GetModelByCode(Guid B_Case_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_plan_id,B_Case_plan_code,B_Case_code,B_Case_plan_evidence,B_Case_plan_plaintiffReason,B_Case_plan_defendantReason,B_Case_plan_qualityControl,B_Case_plan_scheduleControl,B_Case_plan_incomecControl,B_Case_plan_costControl,B_Case_plan_creator,B_Case_plan_createTime,B_Case_plan_isDelete,B_Case_plan_Court_code,C.C_Court_name As B_Case_plan_Court_name from B_Case_plan As B");
            strSql.Append(" left join C_Court As C on B.B_Case_plan_Court_code=C.C_Court_code");
            strSql.Append(" where B_Case_code=@B_Case_code and B_Case_plan_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_code;

            CommonService.Model.CaseManager.B_Case_plan model = new CommonService.Model.CaseManager.B_Case_plan();
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
        public CommonService.Model.CaseManager.B_Case_plan DataRowToModel(DataRow row)
        {
            CommonService.Model.CaseManager.B_Case_plan model = new CommonService.Model.CaseManager.B_Case_plan();
            if (row != null)
            {
                if (row["B_Case_plan_id"] != null && row["B_Case_plan_id"].ToString() != "")
                {
                    model.B_Case_plan_id = int.Parse(row["B_Case_plan_id"].ToString());
                }
                if (row["B_Case_plan_code"] != null && row["B_Case_plan_code"].ToString() != "")
                {
                    model.B_Case_plan_code = new Guid(row["B_Case_plan_code"].ToString());
                }
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString() != "")
                {
                    model.B_Case_code = new Guid(row["B_Case_code"].ToString());
                }
                if (row["B_Case_plan_evidence"] != null)
                {
                    model.B_Case_plan_evidence = row["B_Case_plan_evidence"].ToString();
                }
                if (row["B_Case_plan_plaintiffReason"] != null)
                {
                    model.B_Case_plan_plaintiffReason = row["B_Case_plan_plaintiffReason"].ToString();
                }
                if (row["B_Case_plan_defendantReason"] != null)
                {
                    model.B_Case_plan_defendantReason = row["B_Case_plan_defendantReason"].ToString();
                }
                if (row["B_Case_plan_qualityControl"] != null)
                {
                    model.B_Case_plan_qualityControl = row["B_Case_plan_qualityControl"].ToString();
                }
                if (row["B_Case_plan_scheduleControl"] != null)
                {
                    model.B_Case_plan_scheduleControl = row["B_Case_plan_scheduleControl"].ToString();
                }
                if (row["B_Case_plan_incomecControl"] != null)
                {
                    model.B_Case_plan_incomecControl = row["B_Case_plan_incomecControl"].ToString();
                }
                if (row["B_Case_plan_costControl"] != null)
                {
                    model.B_Case_plan_costControl = row["B_Case_plan_costControl"].ToString();
                }
                if (row["B_Case_plan_creator"] != null && row["B_Case_plan_creator"].ToString() != "")
                {
                    model.B_Case_plan_creator = new Guid(row["B_Case_plan_creator"].ToString());
                }
                if (row["B_Case_plan_createTime"] != null && row["B_Case_plan_createTime"].ToString() != "")
                {
                    model.B_Case_plan_createTime = DateTime.Parse(row["B_Case_plan_createTime"].ToString());
                }
                if (row["B_Case_plan_isDelete"] != null && row["B_Case_plan_isDelete"].ToString() != "")
                {
                    model.B_Case_plan_isDelete = int.Parse(row["B_Case_plan_isDelete"].ToString());
                }
                if (row["B_Case_plan_Court_code"] != null && row["B_Case_plan_Court_code"].ToString() != "")
                {
                    model.B_Case_plan_Court_code = new Guid(row["B_Case_plan_Court_code"].ToString());
                }
                if (row.Table.Columns.Contains("B_Case_plan_Court_name"))
                {
                    if (row["B_Case_plan_Court_name"] != null && row["B_Case_plan_Court_code"].ToString() != "")
                    {
                        model.B_Case_plan_Court_name = row["B_Case_plan_Court_name"].ToString();
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
            strSql.Append("select B_Case_plan_id,B_Case_plan_code,B_Case_code,B_Case_plan_evidence,B_Case_plan_plaintiffReason,B_Case_plan_defendantReason,B_Case_plan_qualityControl,B_Case_plan_scheduleControl,B_Case_plan_incomecControl,B_Case_plan_costControl,B_Case_plan_creator,B_Case_plan_createTime,B_Case_plan_isDelete,B_Case_plan_Court_code ");
            strSql.Append(" FROM B_Case_plan ");
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
            strSql.Append(" B_Case_plan_id,B_Case_plan_code,B_Case_code,B_Case_plan_evidence,B_Case_plan_plaintiffReason,B_Case_plan_defendantReason,B_Case_plan_qualityControl,B_Case_plan_scheduleControl,B_Case_plan_incomecControl,B_Case_plan_costControl,B_Case_plan_creator,B_Case_plan_createTime,B_Case_plan_isDelete,B_Case_plan_Court_code ");
            strSql.Append(" FROM B_Case_plan ");
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
            strSql.Append("select count(1) FROM B_Case_plan ");
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
                strSql.Append("order by T.B_Case_plan_id desc");
            }
            strSql.Append(")AS Row, T.*  from B_Case_plan T ");
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
            parameters[0].Value = "B_Case_plan";
            parameters[1].Value = "B_Case_plan_id";
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
