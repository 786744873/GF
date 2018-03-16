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
    /// 数据访问类:业务流程--表单--用户中间表
    /// 作者：贺太玉
    /// 日期：2015/05/28
    /// </summary>
    public partial class P_Business_flow_form_user
    {
        public P_Business_flow_form_user()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("P_Business_flow_form_user_id", "P_Business_flow_form_user");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Business_flow_form_user_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Business_flow_form_user");
            strSql.Append(" where P_Business_flow_form_user_id=@P_Business_flow_form_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Business_flow_form_user_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.FlowManager.P_Business_flow_form_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into P_Business_flow_form_user(");
            strSql.Append("P_Business_flow_form_user_code,P_Business_flow_form_code,P_Business_flow_form_user_user,P_Business_flow_form_user_isdelete,P_Business_flow_form_user_creator,P_Business_flow_form_user_createTime)");
            strSql.Append(" values (");
            strSql.Append("@P_Business_flow_form_user_code,@P_Business_flow_form_code,@P_Business_flow_form_user_user,@P_Business_flow_form_user_isdelete,@P_Business_flow_form_user_creator,@P_Business_flow_form_user_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_user_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_user_user", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_user_isdelete", SqlDbType.Bit,1),
					new SqlParameter("@P_Business_flow_form_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_user_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.P_Business_flow_form_user_code;
            parameters[1].Value = model.P_Business_flow_form_code;
            parameters[2].Value = model.P_Business_flow_form_user_user;
            parameters[3].Value = model.P_Business_flow_form_user_isdelete;
            parameters[4].Value = model.P_Business_flow_form_user_creator;
            parameters[5].Value = model.P_Business_flow_form_user_createTime;

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
        public bool Update(CommonService.Model.FlowManager.P_Business_flow_form_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_form_user set ");
            strSql.Append("P_Business_flow_form_user_code=@P_Business_flow_form_user_code,");
            strSql.Append("P_Business_flow_form_code=@P_Business_flow_form_code,");
            strSql.Append("P_Business_flow_form_user_user=@P_Business_flow_form_user_user,");
            strSql.Append("P_Business_flow_form_user_isdelete=@P_Business_flow_form_user_isdelete,");
            strSql.Append("P_Business_flow_form_user_creator=@P_Business_flow_form_user_creator,");
            strSql.Append("P_Business_flow_form_user_createTime=@P_Business_flow_form_user_createTime");
            strSql.Append(" where P_Business_flow_form_user_id=@P_Business_flow_form_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_user_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_user_user", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_user_isdelete", SqlDbType.Bit,1),
					new SqlParameter("@P_Business_flow_form_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@P_Business_flow_form_user_id", SqlDbType.Int,4)};
            parameters[0].Value = model.P_Business_flow_form_user_code;
            parameters[1].Value = model.P_Business_flow_form_code;
            parameters[2].Value = model.P_Business_flow_form_user_user;
            parameters[3].Value = model.P_Business_flow_form_user_isdelete;
            parameters[4].Value = model.P_Business_flow_form_user_creator;
            parameters[5].Value = model.P_Business_flow_form_user_createTime;
            parameters[6].Value = model.P_Business_flow_form_user_id;

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
        /// 根据业务流程关联表单Guid删除人员
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public bool DeleteByBusinessFlowFormCode(Guid businessFlowFormCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_form_user set ");
            strSql.Append("P_Business_flow_form_user_isdelete=1 ");
            strSql.Append("where P_Business_flow_form_code=@P_Business_flow_form_code");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowFormCode;

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
        public bool Delete(Guid P_Business_flow_form_user_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Business_flow_form_user set P_Business_flow_form_user_isdelete=1 ");
            strSql.Append("where P_Business_flow_form_user_code=@P_Business_flow_form_user_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_user_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Business_flow_form_user_code;

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
        public bool DeleteList(string P_Business_flow_form_user_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from P_Business_flow_form_user ");
            strSql.Append(" where P_Business_flow_form_user_id in (" + P_Business_flow_form_user_idlist + ")  ");
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
        public CommonService.Model.FlowManager.P_Business_flow_form_user GetModel(int P_Business_flow_form_user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 P_Business_flow_form_user_id,P_Business_flow_form_user_code,P_Business_flow_form_code,P_Business_flow_form_user_user,P_Business_flow_form_user_isdelete,P_Business_flow_form_user_creator,P_Business_flow_form_user_createTime from P_Business_flow_form_user ");
            strSql.Append(" where P_Business_flow_form_user_id=@P_Business_flow_form_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Business_flow_form_user_id;

            CommonService.Model.FlowManager.P_Business_flow_form_user model = new CommonService.Model.FlowManager.P_Business_flow_form_user();
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
        public CommonService.Model.FlowManager.P_Business_flow_form_user DataRowToModel(DataRow row)
        {
            CommonService.Model.FlowManager.P_Business_flow_form_user model = new CommonService.Model.FlowManager.P_Business_flow_form_user();
            if (row != null)
            {
                if (row["P_Business_flow_form_user_id"] != null && row["P_Business_flow_form_user_id"].ToString() != "")
                {
                    model.P_Business_flow_form_user_id = int.Parse(row["P_Business_flow_form_user_id"].ToString());
                }
                if (row["P_Business_flow_form_user_code"] != null && row["P_Business_flow_form_user_code"].ToString() != "")
                {
                    model.P_Business_flow_form_user_code = new Guid(row["P_Business_flow_form_user_code"].ToString());
                }
                if (row["P_Business_flow_form_code"] != null && row["P_Business_flow_form_code"].ToString() != "")
                {
                    model.P_Business_flow_form_code = new Guid(row["P_Business_flow_form_code"].ToString());
                }
                if (row["P_Business_flow_form_user_user"] != null && row["P_Business_flow_form_user_user"].ToString() != "")
                {
                    model.P_Business_flow_form_user_user = new Guid(row["P_Business_flow_form_user_user"].ToString());
                }
                if (row["P_Business_flow_form_user_isdelete"] != null && row["P_Business_flow_form_user_isdelete"].ToString() != "")
                {
                    if ((row["P_Business_flow_form_user_isdelete"].ToString() == "1") || (row["P_Business_flow_form_user_isdelete"].ToString().ToLower() == "true"))
                    {
                        model.P_Business_flow_form_user_isdelete = true;
                    }
                    else
                    {
                        model.P_Business_flow_form_user_isdelete = false;
                    }
                }
                if (row["P_Business_flow_form_user_creator"] != null && row["P_Business_flow_form_user_creator"].ToString() != "")
                {
                    model.P_Business_flow_form_user_creator = new Guid(row["P_Business_flow_form_user_creator"].ToString());
                }
                if (row["P_Business_flow_form_user_createTime"] != null && row["P_Business_flow_form_user_createTime"].ToString() != "")
                {
                    model.P_Business_flow_form_user_createTime = DateTime.Parse(row["P_Business_flow_form_user_createTime"].ToString());
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
            strSql.Append("select P_Business_flow_form_user_id,P_Business_flow_form_user_code,P_Business_flow_form_code,P_Business_flow_form_user_user,P_Business_flow_form_user_isdelete,P_Business_flow_form_user_creator,P_Business_flow_form_user_createTime ");
            strSql.Append(" FROM P_Business_flow_form_user ");
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
            strSql.Append(" P_Business_flow_form_user_id,P_Business_flow_form_user_code,P_Business_flow_form_code,P_Business_flow_form_user_user,P_Business_flow_form_user_isdelete,P_Business_flow_form_user_creator,P_Business_flow_form_user_createTime ");
            strSql.Append(" FROM P_Business_flow_form_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取所有协办律师集合
        /// </summary>
        public DataSet GetListByBusinessFlowFormCode(Guid businessFlowFormCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Business_flow_form_user_id,P_Business_flow_form_user_code,P_Business_flow_form_code,P_Business_flow_form_user_user,P_Business_flow_form_user_isdelete,P_Business_flow_form_user_creator,P_Business_flow_form_user_createTime from P_Business_flow_form_user ");
            strSql.Append("where P_Business_flow_form_code=@P_Business_flow_form_code ");
            strSql.Append("and P_Business_flow_form_user_isdelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = businessFlowFormCode;

            CommonService.Model.FlowManager.P_Business_flow_form_user model = new CommonService.Model.FlowManager.P_Business_flow_form_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM P_Business_flow_form_user ");
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
                strSql.Append("order by T.P_Business_flow_form_user_id desc");
            }
            strSql.Append(")AS Row, T.*  from P_Business_flow_form_user T ");
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
            parameters[0].Value = "P_Business_flow_form_user";
            parameters[1].Value = "P_Business_flow_form_user_id";
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
