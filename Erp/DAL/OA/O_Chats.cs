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
    /// 数据访问类:O_Chats
    /// 聊天表
    /// cyj
    /// 2015年7月14日17:10:193
    /// </summary>
    public partial class O_Chats
    {
        public O_Chats()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Chats_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Chats");
            strSql.Append(" where O_Chats_id=@O_Chats_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Chats_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Chats_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Chats model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Chats(");
            strSql.Append("O_Chats_code,O_Chats_content,O_Chats_from,O_Chats_to,O_Chats_isBulk,O_Chats_date,O_Chats_isRead,O_Chats_creator,O_Chats_createTime,O_Chats_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@O_Chats_code,@O_Chats_content,@O_Chats_from,@O_Chats_to,@O_Chats_isBulk,@O_Chats_date,@O_Chats_isRead,@O_Chats_creator,@O_Chats_createTime,@O_Chats_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Chats_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Chats_content", SqlDbType.NVarChar,500),
					new SqlParameter("@O_Chats_from", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Chats_to", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Chats_isBulk", SqlDbType.Bit,1),
					new SqlParameter("@O_Chats_date", SqlDbType.DateTime),
					new SqlParameter("@O_Chats_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Chats_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Chats_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Chats_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.O_Chats_content;
            parameters[2].Value = Guid.NewGuid();
            parameters[3].Value = Guid.NewGuid();
            parameters[4].Value = model.O_Chats_isBulk;
            parameters[5].Value = model.O_Chats_date;
            parameters[6].Value = model.O_Chats_isRead;
            parameters[7].Value = Guid.NewGuid();
            parameters[8].Value = model.O_Chats_createTime;
            parameters[9].Value = model.O_Chats_isDelete;

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
        public bool Update(CommonService.Model.OA.O_Chats model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Chats set ");
            strSql.Append("O_Chats_code=@O_Chats_code,");
            strSql.Append("O_Chats_content=@O_Chats_content,");
            strSql.Append("O_Chats_from=@O_Chats_from,");
            strSql.Append("O_Chats_to=@O_Chats_to,");
            strSql.Append("O_Chats_isBulk=@O_Chats_isBulk,");
            strSql.Append("O_Chats_date=@O_Chats_date,");
            strSql.Append("O_Chats_isRead=@O_Chats_isRead,");
            strSql.Append("O_Chats_creator=@O_Chats_creator,");
            strSql.Append("O_Chats_createTime=@O_Chats_createTime,");
            strSql.Append("O_Chats_isDelete=@O_Chats_isDelete");
            strSql.Append(" where O_Chats_id=@O_Chats_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Chats_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Chats_content", SqlDbType.NVarChar,500),
					new SqlParameter("@O_Chats_from", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Chats_to", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Chats_isBulk", SqlDbType.Bit,1),
					new SqlParameter("@O_Chats_date", SqlDbType.DateTime),
					new SqlParameter("@O_Chats_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Chats_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Chats_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Chats_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Chats_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Chats_code;
            parameters[1].Value = model.O_Chats_content;
            parameters[2].Value = model.O_Chats_from;
            parameters[3].Value = model.O_Chats_to;
            parameters[4].Value = model.O_Chats_isBulk;
            parameters[5].Value = model.O_Chats_date;
            parameters[6].Value = model.O_Chats_isRead;
            parameters[7].Value = model.O_Chats_creator;
            parameters[8].Value = model.O_Chats_createTime;
            parameters[9].Value = model.O_Chats_isDelete;
            parameters[10].Value = model.O_Chats_id;

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
        public bool Delete(int O_Chats_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Chats ");
            strSql.Append(" where O_Chats_id=@O_Chats_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Chats_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Chats_id;

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
        public bool DeleteList(string O_Chats_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Chats ");
            strSql.Append(" where O_Chats_id in (" + O_Chats_idlist + ")  ");
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
        public CommonService.Model.OA.O_Chats GetModel(int O_Chats_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Chats_id,O_Chats_code,O_Chats_content,O_Chats_from,O_Chats_to,O_Chats_isBulk,O_Chats_date,O_Chats_isRead,O_Chats_creator,O_Chats_createTime,O_Chats_isDelete from O_Chats ");
            strSql.Append(" where O_Chats_id=@O_Chats_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Chats_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Chats_id;

            CommonService.Model.OA.O_Chats model = new CommonService.Model.OA.O_Chats();
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
        public CommonService.Model.OA.O_Chats DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Chats model = new CommonService.Model.OA.O_Chats();
            if (row != null)
            {
                if (row["O_Chats_id"] != null && row["O_Chats_id"].ToString() != "")
                {
                    model.O_Chats_id = int.Parse(row["O_Chats_id"].ToString());
                }
                if (row["O_Chats_code"] != null && row["O_Chats_code"].ToString() != "")
                {
                    model.O_Chats_code = new Guid(row["O_Chats_code"].ToString());
                }
                if (row["O_Chats_content"] != null)
                {
                    model.O_Chats_content = row["O_Chats_content"].ToString();
                }
                if (row["O_Chats_from"] != null && row["O_Chats_from"].ToString() != "")
                {
                    model.O_Chats_from = new Guid(row["O_Chats_from"].ToString());
                }
                if (row["O_Chats_to"] != null && row["O_Chats_to"].ToString() != "")
                {
                    model.O_Chats_to = new Guid(row["O_Chats_to"].ToString());
                }
                if (row["O_Chats_isBulk"] != null && row["O_Chats_isBulk"].ToString() != "")
                {
                    if ((row["O_Chats_isBulk"].ToString() == "1") || (row["O_Chats_isBulk"].ToString().ToLower() == "true"))
                    {
                        model.O_Chats_isBulk = true;
                    }
                    else
                    {
                        model.O_Chats_isBulk = false;
                    }
                }
                if (row["O_Chats_date"] != null && row["O_Chats_date"].ToString() != "")
                {
                    model.O_Chats_date = DateTime.Parse(row["O_Chats_date"].ToString());
                }
                if (row["O_Chats_isRead"] != null && row["O_Chats_isRead"].ToString() != "")
                {
                    if ((row["O_Chats_isRead"].ToString() == "1") || (row["O_Chats_isRead"].ToString().ToLower() == "true"))
                    {
                        model.O_Chats_isRead = true;
                    }
                    else
                    {
                        model.O_Chats_isRead = false;
                    }
                }
                if (row["O_Chats_creator"] != null && row["O_Chats_creator"].ToString() != "")
                {
                    model.O_Chats_creator = new Guid(row["O_Chats_creator"].ToString());
                }
                if (row["O_Chats_createTime"] != null && row["O_Chats_createTime"].ToString() != "")
                {
                    model.O_Chats_createTime = DateTime.Parse(row["O_Chats_createTime"].ToString());
                }
                if (row["O_Chats_isDelete"] != null && row["O_Chats_isDelete"].ToString() != "")
                {
                    if ((row["O_Chats_isDelete"].ToString() == "1") || (row["O_Chats_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Chats_isDelete = true;
                    }
                    else
                    {
                        model.O_Chats_isDelete = false;
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
            strSql.Append("select O_Chats_id,O_Chats_code,O_Chats_content,O_Chats_from,O_Chats_to,O_Chats_isBulk,O_Chats_date,O_Chats_isRead,O_Chats_creator,O_Chats_createTime,O_Chats_isDelete ");
            strSql.Append(" FROM O_Chats ");
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
            strSql.Append(" O_Chats_id,O_Chats_code,O_Chats_content,O_Chats_from,O_Chats_to,O_Chats_isBulk,O_Chats_date,O_Chats_isRead,O_Chats_creator,O_Chats_createTime,O_Chats_isDelete ");
            strSql.Append(" FROM O_Chats ");
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
            strSql.Append("select count(1) FROM O_Chats ");
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
                strSql.Append("order by T.O_Chats_id desc");
            }
            strSql.Append(")AS Row, T.*  from O_Chats T ");
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
            parameters[0].Value = "O_Chats";
            parameters[1].Value = "O_Chats_id";
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
