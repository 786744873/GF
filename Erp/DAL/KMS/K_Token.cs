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
    /// 数据访问类:获取视频Token表
    /// 作者：陈盼盼
    /// 日期：2015/11/11
    /// </summary>
    public partial class K_Token
    {
        public K_Token()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("K_Token_id", "K_Token");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Token_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Token");
            strSql.Append(" where K_Token_id=@K_Token_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Token_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Token_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.KMS.K_Token model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Token(");
            strSql.Append("K_Token_Access_Token,K_Token_expires_in,K_Token_refresh_token,K_Token_zambia_createTime,K_Token_zambia_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@K_Token_Access_Token,@K_Token_expires_in,@K_Token_refresh_token,@K_Token_zambia_createTime,@K_Token_zambia_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Token_Access_Token", SqlDbType.VarChar,50),
					new SqlParameter("@K_Token_expires_in", SqlDbType.Int,4),
					new SqlParameter("@K_Token_refresh_token", SqlDbType.VarChar,50),
					new SqlParameter("@K_Token_zambia_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Token_zambia_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.K_Token_Access_Token;
            parameters[1].Value = model.K_Token_expires_in;
            parameters[2].Value = model.K_Token_refresh_token;
            parameters[3].Value = model.K_Token_zambia_createTime;
            parameters[4].Value = model.K_Token_zambia_isDelete;

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
        public bool Update(Model.KMS.K_Token model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Token set ");
            strSql.Append("K_Token_Access_Token=@K_Token_Access_Token,");
            strSql.Append("K_Token_expires_in=@K_Token_expires_in,");
            strSql.Append("K_Token_refresh_token=@K_Token_refresh_token,");
            strSql.Append("K_Token_zambia_createTime=@K_Token_zambia_createTime,");
            strSql.Append("K_Token_zambia_isDelete=@K_Token_zambia_isDelete");
            strSql.Append(" where K_Token_id=@K_Token_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Token_Access_Token", SqlDbType.VarChar,50),
					new SqlParameter("@K_Token_expires_in", SqlDbType.Int,4),
					new SqlParameter("@K_Token_refresh_token", SqlDbType.VarChar,50),
					new SqlParameter("@K_Token_zambia_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Token_zambia_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Token_id", SqlDbType.Int,4)};
            parameters[0].Value = model.K_Token_Access_Token;
            parameters[1].Value = model.K_Token_expires_in;
            parameters[2].Value = model.K_Token_refresh_token;
            parameters[3].Value = model.K_Token_zambia_createTime;
            parameters[4].Value = model.K_Token_zambia_isDelete;
            parameters[5].Value = model.K_Token_id;

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
        public bool Delete(int K_Token_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Token ");
            strSql.Append(" where K_Token_id=@K_Token_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Token_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Token_id;

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
        public bool DeleteList(string K_Token_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Token ");
            strSql.Append(" where K_Token_id in (" + K_Token_idlist + ")  ");
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
        public Model.KMS.K_Token GetModel(int K_Token_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Token_id,K_Token_Access_Token,K_Token_expires_in,K_Token_refresh_token,K_Token_zambia_createTime,K_Token_zambia_isDelete from K_Token ");
            strSql.Append(" where K_Token_id=@K_Token_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Token_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Token_id;

            Model.KMS.K_Token model = new Model.KMS.K_Token();
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
        /// 得到一个对象实体（获取一条最新时间数据）
        /// </summary>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public Model.KMS.K_Token GetDateModel(string filedOrder)
        {
            DataSet ds = GetList(1, "", filedOrder);
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
        public Model.KMS.K_Token DataRowToModel(DataRow row)
        {
            Model.KMS.K_Token model = new Model.KMS.K_Token();
            if (row != null)
            {
                if (row["K_Token_id"] != null && row["K_Token_id"].ToString() != "")
                {
                    model.K_Token_id = int.Parse(row["K_Token_id"].ToString());
                }
                if (row["K_Token_Access_Token"] != null)
                {
                    model.K_Token_Access_Token = row["K_Token_Access_Token"].ToString();
                }
                if (row["K_Token_expires_in"] != null && row["K_Token_expires_in"].ToString() != "")
                {
                    model.K_Token_expires_in = int.Parse(row["K_Token_expires_in"].ToString());
                }
                if (row["K_Token_refresh_token"] != null)
                {
                    model.K_Token_refresh_token = row["K_Token_refresh_token"].ToString();
                }
                if (row["K_Token_zambia_createTime"] != null && row["K_Token_zambia_createTime"].ToString() != "")
                {
                    model.K_Token_zambia_createTime = DateTime.Parse(row["K_Token_zambia_createTime"].ToString());
                }
                if (row["K_Token_zambia_isDelete"] != null && row["K_Token_zambia_isDelete"].ToString() != "")
                {
                    if ((row["K_Token_zambia_isDelete"].ToString() == "1") || (row["K_Token_zambia_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.K_Token_zambia_isDelete = true;
                    }
                    else
                    {
                        model.K_Token_zambia_isDelete = false;
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
            strSql.Append("select K_Token_id,K_Token_Access_Token,K_Token_expires_in,K_Token_refresh_token,K_Token_zambia_createTime,K_Token_zambia_isDelete ");
            strSql.Append(" FROM K_Token ");
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
            strSql.Append(" K_Token_id,K_Token_Access_Token,K_Token_expires_in,K_Token_refresh_token,K_Token_zambia_createTime,K_Token_zambia_isDelete ");
            strSql.Append(" FROM K_Token ");
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
            strSql.Append("select count(1) FROM K_Token ");
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
                strSql.Append("order by T.K_Token_id desc");
            }
            strSql.Append(")AS Row, T.*  from K_Token T ");
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
            parameters[0].Value = "K_Token";
            parameters[1].Value = "K_Token_id";
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
