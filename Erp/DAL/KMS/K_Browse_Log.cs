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
    /// 数据访问类:K_Browse_Log(资源/问题浏览记录表)
    /// 陈盼盼
    /// </summary>
    public partial class K_Browse_Log
    {
        public K_Browse_Log()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Browse_Log_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Browse_Log");
            strSql.Append(" where K_Browse_Log_id=@K_Browse_Log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Browse_Log_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Browse_Log_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool IsExists(CommonService.Model.KMS.K_Browse_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Browse_Log");
            strSql.Append(" where K_Browse_Log_usercode=@K_Browse_Log_usercode");
            strSql.Append(" and P_FK_code=@P_FK_code");
            strSql.Append(" and K_Browse_Log_ip=@K_Browse_Log_ip");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Browse_Log_usercode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Browse_Log_ip", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = model.K_Browse_Log_usercode;
            parameters[1].Value = model.P_FK_code;
            parameters[2].Value = model.K_Browse_Log_ip;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Browse_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Browse_Log(");
            strSql.Append("K_Browse_Log_usercode,P_FK_code,K_Browse_Log_datetime,K_Browse_Log_ip)");
            strSql.Append(" values (");
            strSql.Append("@K_Browse_Log_usercode,@P_FK_code,@K_Browse_Log_datetime,@K_Browse_Log_ip)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Browse_Log_usercode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Browse_Log_datetime", SqlDbType.DateTime),
                    new SqlParameter("@K_Browse_Log_ip", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.K_Browse_Log_usercode;
            parameters[1].Value = model.P_FK_code;
            parameters[2].Value = model.K_Browse_Log_datetime;
            parameters[3].Value = model.K_Browse_Log_ip;

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
        public bool Update(CommonService.Model.KMS.K_Browse_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Browse_Log set ");
            strSql.Append("K_Browse_Log_usercode=@K_Browse_Log_usercode,");
            strSql.Append("P_FK_code=@P_FK_code,");
            strSql.Append("K_Browse_Log_datetime=@K_Browse_Log_datetime,");
            strSql.Append("K_Browse_Log_ip=@K_Browse_Log_ip");
            strSql.Append(" where K_Browse_Log_id=@K_Browse_Log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Browse_Log_usercode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Browse_Log_datetime", SqlDbType.DateTime),
                    new SqlParameter("@K_Browse_Log_ip", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Browse_Log_id", SqlDbType.Int,4)};
            parameters[0].Value = model.K_Browse_Log_usercode;
            parameters[1].Value = model.P_FK_code;
            parameters[2].Value = model.K_Browse_Log_datetime;
            parameters[3].Value = model.K_Browse_Log_ip;
            parameters[4].Value = model.K_Browse_Log_id;

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
        public bool Delete(int K_Browse_Log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Browse_Log ");
            strSql.Append(" where K_Browse_Log_id=@K_Browse_Log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Browse_Log_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Browse_Log_id;

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
        public bool DeleteList(string K_Browse_Log_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Browse_Log ");
            strSql.Append(" where K_Browse_Log_id in (" + K_Browse_Log_idlist + ")  ");
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
        public CommonService.Model.KMS.K_Browse_Log GetModel(int K_Browse_Log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Browse_Log_id,K_Browse_Log_usercode,P_FK_code,K_Browse_Log_datetime,K_Browse_Log_ip from K_Browse_Log ");
            strSql.Append(" where K_Browse_Log_id=@K_Browse_Log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Browse_Log_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Browse_Log_id;

            CommonService.Model.KMS.K_Browse_Log model = new CommonService.Model.KMS.K_Browse_Log();
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
        public CommonService.Model.KMS.K_Browse_Log DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Browse_Log model = new CommonService.Model.KMS.K_Browse_Log();
            if (row != null)
            {
                if (row["K_Browse_Log_id"] != null && row["K_Browse_Log_id"].ToString() != "")
                {
                    model.K_Browse_Log_id = int.Parse(row["K_Browse_Log_id"].ToString());
                }
                if (row["K_Browse_Log_usercode"] != null && row["K_Browse_Log_usercode"].ToString() != "")
                {
                    model.K_Browse_Log_usercode = new Guid(row["K_Browse_Log_usercode"].ToString());
                }
                if (row["P_FK_code"] != null && row["P_FK_code"].ToString() != "")
                {
                    model.P_FK_code = new Guid(row["P_FK_code"].ToString());
                }
                if (row["K_Browse_Log_datetime"] != null && row["K_Browse_Log_datetime"].ToString() != "")
                {
                    model.K_Browse_Log_datetime = DateTime.Parse(row["K_Browse_Log_datetime"].ToString());
                }
                if (row["K_Browse_Log_ip"] != null && row["K_Browse_Log_ip"].ToString() != "")
                {
                    model.K_Browse_Log_ip = row["K_Browse_Log_ip"].ToString();
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
            strSql.Append("select K_Browse_Log_id,K_Browse_Log_usercode,P_FK_code,K_Browse_Log_datetime,K_Browse_Log_ip ");
            strSql.Append(" FROM K_Browse_Log ");
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
            strSql.Append(" K_Browse_Log_id,K_Browse_Log_usercode,P_FK_code,K_Browse_Log_datetime,K_Browse_Log_ip ");
            strSql.Append(" FROM K_Browse_Log ");
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
            strSql.Append("select count(1) FROM K_Browse_Log ");
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
        /// 根据ip或用户获取资源浏览量
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <param name="groupBy">参数为K_Browse_Log_ip或K_Browse_Log_usercode</param>
        /// <returns></returns>
        public int GetBrowseCount(Guid P_FK_code, string groupBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ");
            strSql.Append("(select " + groupBy + " from K_Browse_Log ");
            strSql.Append("where P_FK_code='" + P_FK_code + "' ");
            strSql.Append("group by " + groupBy + ") as KB");
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
                strSql.Append("order by T.K_Browse_Log_id desc");
            }
            strSql.Append(")AS Row, T.*  from K_Browse_Log T ");
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
            parameters[0].Value = "K_Browse_Log";
            parameters[1].Value = "K_Browse_Log_id";
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
