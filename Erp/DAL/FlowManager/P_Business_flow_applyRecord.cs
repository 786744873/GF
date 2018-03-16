using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.FlowManager
{

    /// <summary>
    /// 数据访问类:业务流程申请记录表
    /// 作者：贺太玉
    /// 日期：2015/10/22
    /// </summary>
    public partial class P_Business_flow_applyRecord
    {
        public P_Business_flow_applyRecord()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("P_Business_flow_applyRecord_id", "P_Business_flow_applyRecord");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Business_flow_applyRecord_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Business_flow_applyRecord");
            strSql.Append(" where P_Business_flow_applyRecord_id=@P_Business_flow_applyRecord_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_applyRecord_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Business_flow_applyRecord_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.FlowManager.P_Business_flow_applyRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into P_Business_flow_applyRecord(");
            strSql.Append("P_Business_flow_applyRecord_code,P_Business_flow_applyRecord_applyUser,P_Business_flow_applyRecord_applyTime,P_Business_flow_applyRecord_applyDetail,P_Business_flow_applyRecord_auditUser,P_Business_flow_applyRecord_auditTime,P_Business_flow_applyRecord_auditDetail,P_Business_flow_applyRecord_recordType,P_Business_flow_applyRecord_businessFlow,P_Business_flow_applyRecord_isDelete,P_Business_flow_applyRecord_creator,P_Business_flow_applyRecord_createTime)");
            strSql.Append(" values (");
            strSql.Append("@P_Business_flow_applyRecord_code,@P_Business_flow_applyRecord_applyUser,@P_Business_flow_applyRecord_applyTime,@P_Business_flow_applyRecord_applyDetail,@P_Business_flow_applyRecord_auditUser,@P_Business_flow_applyRecord_auditTime,@P_Business_flow_applyRecord_auditDetail,@P_Business_flow_applyRecord_recordType,@P_Business_flow_applyRecord_businessFlow,@P_Business_flow_applyRecord_isDelete,@P_Business_flow_applyRecord_creator,@P_Business_flow_applyRecord_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_applyRecord_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_applyUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_applyTime", SqlDbType.DateTime),
					new SqlParameter("@P_Business_flow_applyRecord_applyDetail", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Business_flow_applyRecord_auditUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_auditTime", SqlDbType.DateTime),
					new SqlParameter("@P_Business_flow_applyRecord_auditDetail", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Business_flow_applyRecord_recordType", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_applyRecord_businessFlow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@P_Business_flow_applyRecord_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.P_Business_flow_applyRecord_code;
            parameters[1].Value = model.P_Business_flow_applyRecord_applyUser;
            parameters[2].Value = model.P_Business_flow_applyRecord_applyTime;
            parameters[3].Value = model.P_Business_flow_applyRecord_applyDetail;
            parameters[4].Value = model.P_Business_flow_applyRecord_auditUser;
            parameters[5].Value = model.P_Business_flow_applyRecord_auditTime;
            parameters[6].Value = model.P_Business_flow_applyRecord_auditDetail;
            parameters[7].Value = model.P_Business_flow_applyRecord_recordType;
            parameters[8].Value = model.P_Business_flow_applyRecord_businessFlow;
            parameters[9].Value = model.P_Business_flow_applyRecord_isDelete;
            parameters[10].Value = model.P_Business_flow_applyRecord_creator;
            parameters[11].Value = model.P_Business_flow_applyRecord_createTime;

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
        public bool Update(CommonService.Model.FlowManager.P_Business_flow_applyRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_applyRecord set ");            
            strSql.Append("P_Business_flow_applyRecord_applyUser=@P_Business_flow_applyRecord_applyUser,");
            strSql.Append("P_Business_flow_applyRecord_applyTime=@P_Business_flow_applyRecord_applyTime,");
            strSql.Append("P_Business_flow_applyRecord_applyDetail=@P_Business_flow_applyRecord_applyDetail,");
            strSql.Append("P_Business_flow_applyRecord_auditUser=@P_Business_flow_applyRecord_auditUser,");
            strSql.Append("P_Business_flow_applyRecord_auditTime=@P_Business_flow_applyRecord_auditTime,");
            strSql.Append("P_Business_flow_applyRecord_auditDetail=@P_Business_flow_applyRecord_auditDetail,");
            strSql.Append("P_Business_flow_applyRecord_recordType=@P_Business_flow_applyRecord_recordType,");
            strSql.Append("P_Business_flow_applyRecord_businessFlow=@P_Business_flow_applyRecord_businessFlow,");
            strSql.Append("P_Business_flow_applyRecord_isDelete=@P_Business_flow_applyRecord_isDelete,");
            strSql.Append("P_Business_flow_applyRecord_creator=@P_Business_flow_applyRecord_creator,");
            strSql.Append("P_Business_flow_applyRecord_createTime=@P_Business_flow_applyRecord_createTime ");
            strSql.Append("where P_Business_flow_applyRecord_code=@P_Business_flow_applyRecord_code");
            SqlParameter[] parameters = {					 
					new SqlParameter("@P_Business_flow_applyRecord_applyUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_applyTime", SqlDbType.DateTime),
					new SqlParameter("@P_Business_flow_applyRecord_applyDetail", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Business_flow_applyRecord_auditUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_auditTime", SqlDbType.DateTime),
					new SqlParameter("@P_Business_flow_applyRecord_auditDetail", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Business_flow_applyRecord_recordType", SqlDbType.Int,4),
					new SqlParameter("@P_Business_flow_applyRecord_businessFlow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@P_Business_flow_applyRecord_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_applyRecord_createTime", SqlDbType.DateTime),
					new SqlParameter("@P_Business_flow_applyRecord_code", SqlDbType.UniqueIdentifier,16)};
         
            parameters[0].Value = model.P_Business_flow_applyRecord_applyUser;
            parameters[1].Value = model.P_Business_flow_applyRecord_applyTime;
            parameters[2].Value = model.P_Business_flow_applyRecord_applyDetail;
            parameters[3].Value = model.P_Business_flow_applyRecord_auditUser;
            parameters[4].Value = model.P_Business_flow_applyRecord_auditTime;
            parameters[5].Value = model.P_Business_flow_applyRecord_auditDetail;
            parameters[6].Value = model.P_Business_flow_applyRecord_recordType;
            parameters[7].Value = model.P_Business_flow_applyRecord_businessFlow;
            parameters[8].Value = model.P_Business_flow_applyRecord_isDelete;
            parameters[9].Value = model.P_Business_flow_applyRecord_creator;
            parameters[10].Value = model.P_Business_flow_applyRecord_createTime;
            parameters[11].Value = model.P_Business_flow_applyRecord_code;

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
        public bool Delete(Guid businessFlowApplyRecordCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_applyRecord set P_Business_flow_applyRecord_isDelete =1 ");
            strSql.Append("where P_Business_flow_applyRecord_code=@P_Business_flow_applyRecord_code");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_applyRecord_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowApplyRecordCode;

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
        public bool DeleteList(string P_Business_flow_applyRecord_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from P_Business_flow_applyRecord ");
            strSql.Append(" where P_Business_flow_applyRecord_id in (" + P_Business_flow_applyRecord_idlist + ")  ");
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
        public CommonService.Model.FlowManager.P_Business_flow_applyRecord GetModel(Guid businessFlowApplyRecordCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 P_Business_flow_applyRecord_id,P_Business_flow_applyRecord_code,P_Business_flow_applyRecord_applyUser,P_Business_flow_applyRecord_applyTime,P_Business_flow_applyRecord_applyDetail,P_Business_flow_applyRecord_auditUser,P_Business_flow_applyRecord_auditTime,P_Business_flow_applyRecord_auditDetail,P_Business_flow_applyRecord_recordType,P_Business_flow_applyRecord_businessFlow,P_Business_flow_applyRecord_isDelete,P_Business_flow_applyRecord_creator,P_Business_flow_applyRecord_createTime ");
            strSql.Append("from P_Business_flow_applyRecord with(nolock) ");
            strSql.Append("where P_Business_flow_applyRecord_code=@P_Business_flow_applyRecord_code");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_applyRecord_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowApplyRecordCode;

            CommonService.Model.FlowManager.P_Business_flow_applyRecord model = new CommonService.Model.FlowManager.P_Business_flow_applyRecord();
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
        public CommonService.Model.FlowManager.P_Business_flow_applyRecord DataRowToModel(DataRow row)
        {
            CommonService.Model.FlowManager.P_Business_flow_applyRecord model = new CommonService.Model.FlowManager.P_Business_flow_applyRecord();
            if (row != null)
            {
                if (row["P_Business_flow_applyRecord_id"] != null && row["P_Business_flow_applyRecord_id"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_id = int.Parse(row["P_Business_flow_applyRecord_id"].ToString());
                }
                if (row["P_Business_flow_applyRecord_code"] != null && row["P_Business_flow_applyRecord_code"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_code = new Guid(row["P_Business_flow_applyRecord_code"].ToString());
                }
                if (row["P_Business_flow_applyRecord_applyUser"] != null && row["P_Business_flow_applyRecord_applyUser"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_applyUser = new Guid(row["P_Business_flow_applyRecord_applyUser"].ToString());
                }

                //检查申请人名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_flow_applyRecord_applyUser_name"))
                {
                    if (row["P_Business_flow_applyRecord_applyUser_name"] != null)
                    {
                        model.P_Business_flow_applyRecord_applyUser_name = row["P_Business_flow_applyRecord_applyUser_name"].ToString();
                    }
                }

                if (row["P_Business_flow_applyRecord_applyTime"] != null && row["P_Business_flow_applyRecord_applyTime"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_applyTime = DateTime.Parse(row["P_Business_flow_applyRecord_applyTime"].ToString());
                }
                if (row["P_Business_flow_applyRecord_applyDetail"] != null)
                {
                    model.P_Business_flow_applyRecord_applyDetail = row["P_Business_flow_applyRecord_applyDetail"].ToString();
                }
                if (row["P_Business_flow_applyRecord_auditUser"] != null && row["P_Business_flow_applyRecord_auditUser"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_auditUser = new Guid(row["P_Business_flow_applyRecord_auditUser"].ToString());
                }

                //检查审查人名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Business_flow_applyRecord_auditUser_name"))
                {
                    if (row["P_Business_flow_applyRecord_auditUser_name"] != null)
                    {
                        model.P_Business_flow_applyRecord_auditUser_name = row["P_Business_flow_applyRecord_auditUser_name"].ToString();
                    }
                }

                if (row["P_Business_flow_applyRecord_auditTime"] != null && row["P_Business_flow_applyRecord_auditTime"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_auditTime = DateTime.Parse(row["P_Business_flow_applyRecord_auditTime"].ToString());
                }
                if (row["P_Business_flow_applyRecord_auditDetail"] != null)
                {
                    model.P_Business_flow_applyRecord_auditDetail = row["P_Business_flow_applyRecord_auditDetail"].ToString();
                }
                if (row["P_Business_flow_applyRecord_recordType"] != null && row["P_Business_flow_applyRecord_recordType"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_recordType = int.Parse(row["P_Business_flow_applyRecord_recordType"].ToString());
                }
                if (row["P_Business_flow_applyRecord_businessFlow"] != null && row["P_Business_flow_applyRecord_businessFlow"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_businessFlow = new Guid(row["P_Business_flow_applyRecord_businessFlow"].ToString());
                }
                if (row["P_Business_flow_applyRecord_isDelete"] != null && row["P_Business_flow_applyRecord_isDelete"].ToString() != "")
                {
                    if ((row["P_Business_flow_applyRecord_isDelete"].ToString() == "1") || (row["P_Business_flow_applyRecord_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.P_Business_flow_applyRecord_isDelete = true;
                    }
                    else
                    {
                        model.P_Business_flow_applyRecord_isDelete = false;
                    }
                }
                if (row["P_Business_flow_applyRecord_creator"] != null && row["P_Business_flow_applyRecord_creator"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_creator = new Guid(row["P_Business_flow_applyRecord_creator"].ToString());
                }
                if (row["P_Business_flow_applyRecord_createTime"] != null && row["P_Business_flow_applyRecord_createTime"].ToString() != "")
                {
                    model.P_Business_flow_applyRecord_createTime = DateTime.Parse(row["P_Business_flow_applyRecord_createTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 根据业务Guid(商机Guid)，获取业务流程申请记录集合
        /// </summary>
        public DataSet GetListByKpCode(Guid pkCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BFAR.*,APPLY.C_Userinfo_name As P_Business_flow_applyRecord_applyUser_name,AUDIT.C_Userinfo_name As P_Business_flow_applyRecord_auditUser_name ");           
            strSql.Append("FROM P_Business_flow_applyRecord As BFAR with(nolock) ");
            strSql.Append("left join C_Userinfo As APPLY on BFAR.P_Business_flow_applyRecord_applyUser=APPLY.C_Userinfo_code ");
            strSql.Append("left join C_Userinfo As AUDIT on BFAR.P_Business_flow_applyRecord_auditUser=AUDIT.C_Userinfo_code ");
            strSql.Append("where BFAR.P_Business_flow_applyRecord_isDelete=0 ");
            strSql.Append("and exists(");
            strSql.Append("select 1 from P_Business_flow As BF with(nolock) where BF.P_Fk_code=@P_Fk_code and BF.P_Business_flow_code=BFAR.P_Business_flow_applyRecord_businessFlow");
            strSql.Append(")");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Fk_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = pkCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 根据业务流程Guid和记录类型，获取尚未审查的业务流程申请记录集合
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="recordType">记录类型</param>
        /// <returns></returns>
        public DataSet GetUnAuditList(Guid businessFlowCode, int recordType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BFAR.* ");
            strSql.Append("FROM P_Business_flow_applyRecord As BFAR with(nolock) ");
            strSql.Append("where BFAR.P_Business_flow_applyRecord_isDelete=0 and BFAR.P_Business_flow_applyRecord_auditUser IS NULL ");
            strSql.Append("and BFAR.P_Business_flow_applyRecord_businessFlow=@businessFlowCode ");
            strSql.Append("and BFAR.P_Business_flow_applyRecord_recordType=@recordType ");
           
            SqlParameter[] parameters = {
					new SqlParameter("@businessFlowCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@recordType", SqlDbType.Int,4)
			};
            parameters[0].Value = businessFlowCode;
            parameters[1].Value = recordType;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Business_flow_applyRecord_id,P_Business_flow_applyRecord_code,P_Business_flow_applyRecord_applyUser,P_Business_flow_applyRecord_applyTime,P_Business_flow_applyRecord_applyDetail,P_Business_flow_applyRecord_auditUser,P_Business_flow_applyRecord_auditTime,P_Business_flow_applyRecord_auditDetail,P_Business_flow_applyRecord_recordType,P_Business_flow_applyRecord_businessFlow,P_Business_flow_applyRecord_isDelete,P_Business_flow_applyRecord_creator,P_Business_flow_applyRecord_createTime ");
            strSql.Append(" FROM P_Business_flow_applyRecord ");
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
            strSql.Append(" P_Business_flow_applyRecord_id,P_Business_flow_applyRecord_code,P_Business_flow_applyRecord_applyUser,P_Business_flow_applyRecord_applyTime,P_Business_flow_applyRecord_applyDetail,P_Business_flow_applyRecord_auditUser,P_Business_flow_applyRecord_auditTime,P_Business_flow_applyRecord_auditDetail,P_Business_flow_applyRecord_recordType,P_Business_flow_applyRecord_businessFlow,P_Business_flow_applyRecord_isDelete,P_Business_flow_applyRecord_creator,P_Business_flow_applyRecord_createTime ");
            strSql.Append(" FROM P_Business_flow_applyRecord ");
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
            strSql.Append("select count(1) FROM P_Business_flow_applyRecord ");
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
                strSql.Append("order by T.P_Business_flow_applyRecord_id desc");
            }
            strSql.Append(")AS Row, T.*  from P_Business_flow_applyRecord T ");
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
            parameters[0].Value = "P_Business_flow_applyRecord";
            parameters[1].Value = "P_Business_flow_applyRecord_id";
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
