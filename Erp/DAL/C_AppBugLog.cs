using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:C_AppBugLog
    /// </summary>
    public partial class C_AppBugLog
    {
        public C_AppBugLog()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_AppBugLog_id", "C_AppBugLog");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_AppBugLog_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_AppBugLog");
            strSql.Append(" where C_AppBugLog_id=@C_AppBugLog_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_AppBugLog_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_AppBugLog_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_AppBugLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_AppBugLog(");
            strSql.Append("C_AppBugLog_userCode,C_AppBugLog_userName,C_AppBugLog_crashContent,C_AppBugLog_createTime,C_AppBugLog_phoneModel,C_AppBugLog_androidVersions,C_AppBugLog_sdk)");
            strSql.Append(" values (");
            strSql.Append("@C_AppBugLog_userCode,@C_AppBugLog_userName,@C_AppBugLog_crashContent,@C_AppBugLog_createTime,@C_AppBugLog_phoneModel,@C_AppBugLog_androidVersions,@C_AppBugLog_sdk)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_AppBugLog_userCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_AppBugLog_userName", SqlDbType.NVarChar,100),
					new SqlParameter("@C_AppBugLog_crashContent", SqlDbType.NVarChar,500),
					new SqlParameter("@C_AppBugLog_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_AppBugLog_phoneModel", SqlDbType.NVarChar,500),
					new SqlParameter("@C_AppBugLog_androidVersions", SqlDbType.NVarChar,500),
					new SqlParameter("@C_AppBugLog_sdk", SqlDbType.NVarChar,500)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.C_AppBugLog_userName;
            parameters[2].Value = model.C_AppBugLog_crashContent;
            parameters[3].Value = model.C_AppBugLog_createTime;
            parameters[4].Value = model.C_AppBugLog_phoneModel;
            parameters[5].Value = model.C_AppBugLog_androidVersions;
            parameters[6].Value = model.C_AppBugLog_sdk;

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
        public bool Update(CommonService.Model.C_AppBugLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_AppBugLog set ");
            strSql.Append("C_AppBugLog_userCode=@C_AppBugLog_userCode,");
            strSql.Append("C_AppBugLog_userName=@C_AppBugLog_userName,");
            strSql.Append("C_AppBugLog_crashContent=@C_AppBugLog_crashContent,");
            strSql.Append("C_AppBugLog_createTime=@C_AppBugLog_createTime,");
            strSql.Append("C_AppBugLog_phoneModel=@C_AppBugLog_phoneModel,");
            strSql.Append("C_AppBugLog_androidVersions=@C_AppBugLog_androidVersions,");
            strSql.Append("C_AppBugLog_sdk=@C_AppBugLog_sdk");
            strSql.Append(" where C_AppBugLog_id=@C_AppBugLog_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_AppBugLog_userCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_AppBugLog_userName", SqlDbType.NVarChar,100),
					new SqlParameter("@C_AppBugLog_crashContent", SqlDbType.NVarChar,500),
					new SqlParameter("@C_AppBugLog_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_AppBugLog_phoneModel", SqlDbType.NVarChar,500),
					new SqlParameter("@C_AppBugLog_androidVersions", SqlDbType.NVarChar,500),
					new SqlParameter("@C_AppBugLog_sdk", SqlDbType.NVarChar,500),
					new SqlParameter("@C_AppBugLog_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_AppBugLog_userCode;
            parameters[1].Value = model.C_AppBugLog_userName;
            parameters[2].Value = model.C_AppBugLog_crashContent;
            parameters[3].Value = model.C_AppBugLog_createTime;
            parameters[4].Value = model.C_AppBugLog_phoneModel;
            parameters[5].Value = model.C_AppBugLog_androidVersions;
            parameters[6].Value = model.C_AppBugLog_sdk;
            parameters[7].Value = model.C_AppBugLog_id;

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
        public bool Delete(int C_AppBugLog_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_AppBugLog ");
            strSql.Append(" where C_AppBugLog_id=@C_AppBugLog_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_AppBugLog_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_AppBugLog_id;

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
        public bool DeleteList(string C_AppBugLog_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_AppBugLog ");
            strSql.Append(" where C_AppBugLog_id in (" + C_AppBugLog_idlist + ")  ");
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
        public CommonService.Model.C_AppBugLog GetModel(int C_AppBugLog_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_AppBugLog_id,C_AppBugLog_userCode,C_AppBugLog_userName,C_AppBugLog_crashContent,C_AppBugLog_createTime,C_AppBugLog_phoneModel,C_AppBugLog_androidVersions,C_AppBugLog_sdk from C_AppBugLog ");
            strSql.Append(" where C_AppBugLog_id=@C_AppBugLog_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_AppBugLog_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_AppBugLog_id;

            CommonService.Model.C_AppBugLog model = new CommonService.Model.C_AppBugLog();
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
        public CommonService.Model.C_AppBugLog DataRowToModel(DataRow row)
        {
            CommonService.Model.C_AppBugLog model = new CommonService.Model.C_AppBugLog();
            if (row != null)
            {
                if (row["C_AppBugLog_id"] != null && row["C_AppBugLog_id"].ToString() != "")
                {
                    model.C_AppBugLog_id = int.Parse(row["C_AppBugLog_id"].ToString());
                }
                if (row["C_AppBugLog_userCode"] != null && row["C_AppBugLog_userCode"].ToString() != "")
                {
                    model.C_AppBugLog_userCode = new Guid(row["C_AppBugLog_userCode"].ToString());
                }
                if (row["C_AppBugLog_userName"] != null)
                {
                    model.C_AppBugLog_userName = row["C_AppBugLog_userName"].ToString();
                }
                if (row["C_AppBugLog_crashContent"] != null)
                {
                    model.C_AppBugLog_crashContent = row["C_AppBugLog_crashContent"].ToString();
                }
                if (row["C_AppBugLog_createTime"] != null && row["C_AppBugLog_createTime"].ToString() != "")
                {
                    model.C_AppBugLog_createTime = DateTime.Parse(row["C_AppBugLog_createTime"].ToString());
                }
                if (row["C_AppBugLog_phoneModel"] != null)
                {
                    model.C_AppBugLog_phoneModel = row["C_AppBugLog_phoneModel"].ToString();
                }
                if (row["C_AppBugLog_androidVersions"] != null)
                {
                    model.C_AppBugLog_androidVersions = row["C_AppBugLog_androidVersions"].ToString();
                }
                if (row["C_AppBugLog_sdk"] != null)
                {
                    model.C_AppBugLog_sdk = row["C_AppBugLog_sdk"].ToString();
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
            strSql.Append("select C_AppBugLog_id,C_AppBugLog_userCode,C_AppBugLog_userName,C_AppBugLog_crashContent,C_AppBugLog_createTime,C_AppBugLog_phoneModel,C_AppBugLog_androidVersions,C_AppBugLog_sdk ");
            strSql.Append(" FROM C_AppBugLog ");
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
            strSql.Append(" C_AppBugLog_id,C_AppBugLog_userCode,C_AppBugLog_userName,C_AppBugLog_crashContent,C_AppBugLog_createTime,C_AppBugLog_phoneModel,C_AppBugLog_androidVersions,C_AppBugLog_sdk ");
            strSql.Append(" FROM C_AppBugLog ");
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
            strSql.Append("select count(1) FROM C_AppBugLog ");
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
                strSql.Append("order by T.C_AppBugLog_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_AppBugLog T ");
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
            parameters[0].Value = "C_AppBugLog";
            parameters[1].Value = "C_AppBugLog_id";
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
