using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:K_Kms_Log
    /// </summary>
    public partial class K_Kms_Log
    {
        public K_Kms_Log()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Kms_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Kms_Log(");
            strSql.Append("K_Kms_Log_usercode,K_Kms_Log_datetime,K_Kms_Log_ip,K_Kms_Log_type)");
            strSql.Append(" values (");
            strSql.Append("@K_Kms_Log_usercode,@K_Kms_Log_datetime,@K_Kms_Log_ip,@K_Kms_Log_type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Kms_Log_usercode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Kms_Log_datetime", SqlDbType.DateTime),
					new SqlParameter("@K_Kms_Log_ip", SqlDbType.NVarChar,50),
                    new SqlParameter("@K_Kms_Log_type",SqlDbType.NVarChar,50)};
            parameters[0].Value = model.K_Kms_Log_usercode;
            parameters[1].Value = model.K_Kms_Log_datetime;
            parameters[2].Value = model.K_Kms_Log_ip;
            parameters[3].Value = model.K_Kms_Log_type;

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
        public bool Update(CommonService.Model.KMS.K_Kms_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Kms_Log set ");
            strSql.Append("K_Kms_Log_usercode=@K_Kms_Log_usercode,");
            strSql.Append("K_Kms_Log_datetime=@K_Kms_Log_datetime,");
            strSql.Append("K_Kms_Log_ip=@K_Kms_Log_ip");
            strSql.Append("K_Kms_Log_type=@K_Kms_Log_type");
            strSql.Append(" where K_Kms_Log_id=@K_Kms_Log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Kms_Log_usercode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Kms_Log_datetime", SqlDbType.DateTime),
					new SqlParameter("@K_Kms_Log_ip", SqlDbType.NVarChar,50),
                    new SqlParameter("@K_Kms_Log_type", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Kms_Log_id", SqlDbType.Int,4)};
            parameters[0].Value = model.K_Kms_Log_usercode;
            parameters[1].Value = model.K_Kms_Log_datetime;
            parameters[2].Value = model.K_Kms_Log_ip;
            parameters[3].Value = model.K_Kms_Log_type;
            parameters[4].Value = model.K_Kms_Log_id;

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
        public bool Delete(int K_Kms_Log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Kms_Log ");
            strSql.Append(" where K_Kms_Log_id=@K_Kms_Log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Kms_Log_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Kms_Log_id;

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
        public bool DeleteList(string K_Kms_Log_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Kms_Log ");
            strSql.Append(" where K_Kms_Log_id in (" + K_Kms_Log_idlist + ")  ");
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
        public CommonService.Model.KMS.K_Kms_Log GetModel(int K_Kms_Log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Kms_Log_id,K_Kms_Log_usercode,K_Kms_Log_datetime,K_Kms_Log_ip,K_Kms_Log_type from K_Kms_Log ");
            strSql.Append(" where K_Kms_Log_id=@K_Kms_Log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Kms_Log_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Kms_Log_id;

            CommonService.Model.KMS.K_Kms_Log model = new CommonService.Model.KMS.K_Kms_Log();
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
        public CommonService.Model.KMS.K_Kms_Log DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Kms_Log model = new CommonService.Model.KMS.K_Kms_Log();
            if (row != null)
            {
                if (row.Table.Columns.Contains("K_Kms_Log_id"))
                {
                    if (row["K_Kms_Log_id"] != null && row["K_Kms_Log_id"].ToString() != "")
                    {
                        model.K_Kms_Log_id = int.Parse(row["K_Kms_Log_id"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Kms_Log_usercode"))
                {
                    if (row["K_Kms_Log_usercode"] != null && row["K_Kms_Log_usercode"].ToString() != "")
                    {
                        model.K_Kms_Log_usercode = new Guid(row["K_Kms_Log_usercode"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Kms_Log_datetime"))
                {
                    if (row["K_Kms_Log_datetime"] != null && row["K_Kms_Log_datetime"].ToString() != "")
                    {
                        model.K_Kms_Log_datetime = DateTime.Parse(row["K_Kms_Log_datetime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Kms_Log_ip"))
                {
                    if (row["K_Kms_Log_ip"] != null && row["K_Kms_Log_ip"].ToString() != "")
                    {
                        model.K_Kms_Log_ip = row["K_Kms_Log_ip"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Kms_Log_type"))
                {
                    if (row["K_Kms_Log_type"] != null && row["K_Kms_Log_type"].ToString() != "")
                    {
                        model.K_Kms_Log_type = row["K_Kms_Log_type"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Kms_Log_username"))
                {
                    if (row["K_Kms_Log_username"] != null && row["K_Kms_Log_username"].ToString() != "")
                    {
                        model.K_Kms_Log_username = row["K_Kms_Log_username"].ToString();
                    } 
                }
            }
            return model;
        }
        /// <summary>
        /// 获取日志类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetLogType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Kms_Log_type from K_Kms_Log where K_Kms_Log_type is not null group by K_Kms_Log_type");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Kms_Log_id,K_Kms_Log_usercode,K_Kms_Log_datetime,K_Kms_Log_ip,K_Kms_Log_type ");
            strSql.Append(" FROM K_Kms_Log ");
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
            strSql.Append(" K_Kms_Log_id,K_Kms_Log_usercode,K_Kms_Log_datetime,K_Kms_Log_ip,K_Kms_Log_type ");
            strSql.Append(" FROM K_Kms_Log ");
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
        public int GetRecordCount(CommonService.Model.KMS.K_Kms_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Kms_Log where 1=1 ");
            if (model != null)
            {
                if (model.K_Kms_Log_type != null && model.K_Kms_Log_type.ToString() != "")
                {
                    strSql.Append(" and K_Kms_Log_type=@K_Kms_Log_type ");
                }
                if (model.K_Kms_Log_usercode != null && model.K_Kms_Log_usercode.ToString() != "")
                {
                    strSql.Append(" and K_Kms_Log_usercode=@K_Kms_Log_usercode");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Kms_Log_type", SqlDbType.NVarChar),
					new SqlParameter("@K_Kms_Log_usercode", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.K_Kms_Log_type;
            parameters[1].Value = model.K_Kms_Log_usercode;
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
        public DataSet GetListByPage(CommonService.Model.KMS.K_Kms_Log model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.K_Kms_Log_id desc");
            }
            strSql.Append(")AS Row, T.*,C.C_Userinfo_name as K_Kms_Log_username from K_Kms_Log T ");
            strSql.Append(" left join C_Userinfo as C on C.C_Userinfo_code=T.K_Kms_Log_usercode ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.K_Kms_Log_type != null && model.K_Kms_Log_type.ToString() != "")
                {
                    strSql.Append(" and K_Kms_Log_type=@K_Kms_Log_type ");
                }
                if (model.K_Kms_Log_usercode != null && model.K_Kms_Log_usercode.ToString() != "")
                {
                    strSql.Append(" and K_Kms_Log_usercode=@K_Kms_Log_usercode");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Kms_Log_type", SqlDbType.NVarChar),
					new SqlParameter("@K_Kms_Log_usercode", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.K_Kms_Log_type;
            parameters[1].Value = model.K_Kms_Log_usercode;
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
            parameters[0].Value = "K_Kms_Log";
            parameters[1].Value = "K_Kms_Log_id";
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


