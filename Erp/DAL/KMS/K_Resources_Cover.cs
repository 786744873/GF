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
    /// 数据访问类:K_Resources_Cover
    /// 作者：陈盼盼
    /// 日期：2015/11/19
    /// </summary>
    public partial class K_Resources_Cover
    {
        public K_Resources_Cover()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Resources_cover_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Resources_Cover");
            strSql.Append(" where K_Resources_cover_id=@K_Resources_cover_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_cover_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Resources_cover_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Resources_Cover model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Resources_Cover(");
            strSql.Append("K_Resources_cover_code,K_Resources_cover_url,K_Resources_cover_state,K_Resources_cover_createTime,K_Resources_cover_isDelete,K_Resources_cover_creater)");
            strSql.Append(" values (");
            strSql.Append("@K_Resources_cover_code,@K_Resources_cover_url,@K_Resources_cover_state,@K_Resources_cover_createTime,@K_Resources_cover_isDelete,@K_Resources_cover_creater)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_cover_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_cover_url", SqlDbType.VarChar,50),
					new SqlParameter("@K_Resources_cover_state", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_cover_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Resources_cover_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_cover_creater", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.K_Resources_cover_url;
            parameters[2].Value = model.K_Resources_cover_state;
            parameters[3].Value = model.K_Resources_cover_createTime;
            parameters[4].Value = model.K_Resources_cover_isDelete;
            parameters[5].Value = Guid.NewGuid();

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
        public bool Update(CommonService.Model.KMS.K_Resources_Cover model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Resources_Cover set ");
            strSql.Append("K_Resources_cover_code=@K_Resources_cover_code,");
            strSql.Append("K_Resources_cover_url=@K_Resources_cover_url,");
            strSql.Append("K_Resources_cover_state=@K_Resources_cover_state,");
            strSql.Append("K_Resources_cover_createTime=@K_Resources_cover_createTime,");
            strSql.Append("K_Resources_cover_isDelete=@K_Resources_cover_isDelete,");
            strSql.Append("K_Resources_cover_creater=@K_Resources_cover_creater");
            strSql.Append(" where K_Resources_cover_id=@K_Resources_cover_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_cover_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_cover_url", SqlDbType.VarChar,50),
					new SqlParameter("@K_Resources_cover_state", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_cover_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Resources_cover_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_cover_creater", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_cover_id", SqlDbType.Int,4)};
            parameters[0].Value = model.K_Resources_cover_code;
            parameters[1].Value = model.K_Resources_cover_url;
            parameters[2].Value = model.K_Resources_cover_state;
            parameters[3].Value = model.K_Resources_cover_createTime;
            parameters[4].Value = model.K_Resources_cover_isDelete;
            parameters[5].Value = model.K_Resources_cover_creater;
            parameters[6].Value = model.K_Resources_cover_id;

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
        public bool Delete(int K_Resources_cover_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Resources_Cover ");
            strSql.Append(" set K_Resources_cover_isDelete=1 ");
            strSql.Append(" where K_Resources_cover_id=@K_Resources_cover_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_cover_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Resources_cover_id;

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
        public bool DeleteList(string K_Resources_cover_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Resources_Cover ");
            strSql.Append(" where K_Resources_cover_id in (" + K_Resources_cover_idlist + ")  ");
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
        public CommonService.Model.KMS.K_Resources_Cover GetModel(int K_Resources_cover_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Resources_cover_id,K_Resources_cover_code,K_Resources_cover_url,K_Resources_cover_state,K_Resources_cover_createTime,K_Resources_cover_isDelete,K_Resources_cover_creater from K_Resources_Cover ");
            strSql.Append(" where K_Resources_cover_id=@K_Resources_cover_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_cover_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Resources_cover_id;

            CommonService.Model.KMS.K_Resources_Cover model = new CommonService.Model.KMS.K_Resources_Cover();
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
        public CommonService.Model.KMS.K_Resources_Cover DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Resources_Cover model = new CommonService.Model.KMS.K_Resources_Cover();
            if (row != null)
            {
                if (row["K_Resources_cover_id"] != null && row["K_Resources_cover_id"].ToString() != "")
                {
                    model.K_Resources_cover_id = int.Parse(row["K_Resources_cover_id"].ToString());
                }
                if (row["K_Resources_cover_code"] != null && row["K_Resources_cover_code"].ToString() != "")
                {
                    model.K_Resources_cover_code = new Guid(row["K_Resources_cover_code"].ToString());
                }
                if (row["K_Resources_cover_url"] != null)
                {
                    model.K_Resources_cover_url = row["K_Resources_cover_url"].ToString();
                }
                if (row["K_Resources_cover_state"] != null && row["K_Resources_cover_state"].ToString() != "")
                {
                    if ((row["K_Resources_cover_state"].ToString() == "1") || (row["K_Resources_cover_state"].ToString().ToLower() == "true"))
                    {
                        model.K_Resources_cover_state = true;
                    }
                    else
                    {
                        model.K_Resources_cover_state = false;
                    }
                }
                if (row["K_Resources_cover_createTime"] != null && row["K_Resources_cover_createTime"].ToString() != "")
                {
                    model.K_Resources_cover_createTime = DateTime.Parse(row["K_Resources_cover_createTime"].ToString());
                }
                if (row["K_Resources_cover_isDelete"] != null && row["K_Resources_cover_isDelete"].ToString() != "")
                {
                    if ((row["K_Resources_cover_isDelete"].ToString() == "1") || (row["K_Resources_cover_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.K_Resources_cover_isDelete = true;
                    }
                    else
                    {
                        model.K_Resources_cover_isDelete = false;
                    }
                }
                if (row["K_Resources_cover_creater"] != null && row["K_Resources_cover_creater"].ToString() != "")
                {
                    model.K_Resources_cover_creater = new Guid(row["K_Resources_cover_creater"].ToString());
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
            strSql.Append("select K_Resources_cover_id,K_Resources_cover_code,K_Resources_cover_url,K_Resources_cover_state,K_Resources_cover_createTime,K_Resources_cover_isDelete,K_Resources_cover_creater ");
            strSql.Append(" FROM K_Resources_Cover ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Resources_cover_id,K_Resources_cover_code,K_Resources_cover_url,K_Resources_cover_state,K_Resources_cover_createTime,K_Resources_cover_isDelete,K_Resources_cover_creater ");
            strSql.Append(" FROM K_Resources_Cover ");
            strSql.Append(" where K_Resources_cover_isDelete=0 order by K_Resources_cover_createTime desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表(已启用)
        /// </summary>
        public DataSet GetStartList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Resources_cover_id,K_Resources_cover_code,K_Resources_cover_url,K_Resources_cover_state,K_Resources_cover_createTime,K_Resources_cover_isDelete,K_Resources_cover_creater ");
            strSql.Append(" FROM K_Resources_Cover ");
            strSql.Append(" where K_Resources_cover_isDelete=0 and K_Resources_cover_state = 'true' order by K_Resources_cover_createTime desc ");
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
            strSql.Append(" K_Resources_cover_id,K_Resources_cover_code,K_Resources_cover_url,K_Resources_cover_state,K_Resources_cover_createTime,K_Resources_cover_isDelete,K_Resources_cover_creater ");
            strSql.Append(" FROM K_Resources_Cover ");
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
            strSql.Append("select count(1) FROM K_Resources_Cover ");
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
                strSql.Append("order by T.K_Resources_cover_id desc");
            }
            strSql.Append(")AS Row, T.*  from K_Resources_Cover T ");
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
            parameters[0].Value = "K_Resources_Cover";
            parameters[1].Value = "K_Resources_cover_id";
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
