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
    /// 数据访问类:O_Article_user文章用户中间表
    /// cyj
    /// 2015年7月24日15:40:42
    /// </summary>
    public partial class O_Article_user
    {
        public O_Article_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Article_user_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Article_user");
            strSql.Append(" where O_Article_user_id=@O_Article_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Article_user_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Article_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Article_user(");
            strSql.Append("O_Article_code,C_Userinfo_code,O_Article_user_isRead,O_Article_user_readTime,O_Article_user_creator,O_Article_user_createTime,O_Article_user_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@O_Article_code,@C_Userinfo_code,@O_Article_user_isRead,@O_Article_user_readTime,@O_Article_user_creator,@O_Article_user_createTime,@O_Article_user_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_user_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Article_user_readTime", SqlDbType.DateTime),
					new SqlParameter("@O_Article_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Article_user_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Article_code;
            parameters[1].Value = model.C_Userinfo_code;
            parameters[2].Value = model.O_Article_user_isRead;
            parameters[3].Value = model.O_Article_user_readTime;
            parameters[4].Value = model.O_Article_user_creator;
            parameters[5].Value = model.O_Article_user_createTime;
            parameters[6].Value = model.O_Article_user_isDelete;

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
        public bool Update(CommonService.Model.OA.O_Article_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Article_user set ");
            strSql.Append("O_Article_code=@O_Article_code,");
            strSql.Append("C_Userinfo_code=@C_Userinfo_code,");
            strSql.Append("O_Article_user_isRead=@O_Article_user_isRead,");
            strSql.Append("O_Article_user_readTime=@O_Article_user_readTime,");
            strSql.Append("O_Article_user_creator=@O_Article_user_creator,");
            strSql.Append("O_Article_user_createTime=@O_Article_user_createTime,");
            strSql.Append("O_Article_user_isDelete=@O_Article_user_isDelete");
            strSql.Append(" where O_Article_user_id=@O_Article_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_user_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Article_user_readTime", SqlDbType.DateTime),
					new SqlParameter("@O_Article_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Article_user_isDelete", SqlDbType.Int,4),
					new SqlParameter("@O_Article_user_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Article_code;
            parameters[1].Value = model.C_Userinfo_code;
            parameters[2].Value = model.O_Article_user_isRead;
            parameters[3].Value = model.O_Article_user_readTime;
            parameters[4].Value = model.O_Article_user_creator;
            parameters[5].Value = model.O_Article_user_createTime;
            parameters[6].Value = model.O_Article_user_isDelete;
            parameters[7].Value = model.O_Article_user_id;

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
        /// 删除一条新闻的关联
        /// </summary>
        public bool DeleteByACode(Guid O_Article_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Article_user ");
            strSql.Append(" where O_Article_code=@O_Article_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Article_code;

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
        public bool Delete(int O_Article_user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Article_user ");
            strSql.Append(" where O_Article_user_id=@O_Article_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Article_user_id;

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
        public bool DeleteList(string O_Article_user_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Article_user ");
            strSql.Append(" where O_Article_user_id in (" + O_Article_user_idlist + ")  ");
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
        public CommonService.Model.OA.O_Article_user GetModel(int O_Article_user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Article_user_id,O_Article_code,C_Userinfo_code,O_Article_user_isRead,O_Article_user_readTime,O_Article_user_creator,O_Article_user_createTime,O_Article_user_isDelete from O_Article_user ");
            strSql.Append(" where O_Article_user_id=@O_Article_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Article_user_id;

            CommonService.Model.OA.O_Article_user model = new CommonService.Model.OA.O_Article_user();
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
        /// 根据文章guid和用户guid得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Article_user GetModelByAcodeAndCcode(Guid O_Article_code, Guid C_Userinfo_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Article_user_id,O_Article_code,C_Userinfo_code,O_Article_user_isRead,O_Article_user_readTime,O_Article_user_creator,O_Article_user_createTime,O_Article_user_isDelete from O_Article_user ");
            strSql.Append(" where O_Article_code=@O_Article_code and C_Userinfo_code=@C_Userinfo_code and O_Article_user_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Article_code;
            parameters[1].Value = C_Userinfo_code;

            CommonService.Model.OA.O_Article_user model = new CommonService.Model.OA.O_Article_user();
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
        public CommonService.Model.OA.O_Article_user DataRowToModel(DataRow row)
        {
           
            CommonService.Model.OA.O_Article_user model = new CommonService.Model.OA.O_Article_user();
            if (row != null)
            {
                if (row["O_Article_user_id"] != null && row["O_Article_user_id"].ToString() != "")
                {
                    model.O_Article_user_id = int.Parse(row["O_Article_user_id"].ToString());
                }
                if (row["O_Article_code"] != null && row["O_Article_code"].ToString() != "")
                {
                    model.O_Article_code = new Guid(row["O_Article_code"].ToString());
                }
                if (row["C_Userinfo_code"] != null && row["C_Userinfo_code"].ToString() != "")
                {
                    model.C_Userinfo_code = new Guid(row["C_Userinfo_code"].ToString());
                }
                if (row["O_Article_user_isRead"] != null && row["O_Article_user_isRead"].ToString() != "")
                {
                    if ((row["O_Article_user_isRead"].ToString() == "1") || (row["O_Article_user_isRead"].ToString().ToLower() == "true"))
                    {
                        model.O_Article_user_isRead = true;
                    }
                    else
                    {
                        model.O_Article_user_isRead = false;
                    }
                }
                if (row["O_Article_user_readTime"] != null && row["O_Article_user_readTime"].ToString() != "")
                {
                    model.O_Article_user_readTime = DateTime.Parse(row["O_Article_user_readTime"].ToString());
                }
                if (row["O_Article_user_creator"] != null && row["O_Article_user_creator"].ToString() != "")
                {
                    model.O_Article_user_creator = new Guid(row["O_Article_user_creator"].ToString());
                }
                if (row["O_Article_user_createTime"] != null && row["O_Article_user_createTime"].ToString() != "")
                {
                    model.O_Article_user_createTime = DateTime.Parse(row["O_Article_user_createTime"].ToString());
                }
                if (row["O_Article_user_isDelete"] != null && row["O_Article_user_isDelete"].ToString() != "")
                {
                    model.O_Article_user_isDelete = int.Parse(row["O_Article_user_isDelete"].ToString());
                }
                //文章接收人名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Userinfo_name"))
                {
                    if (row["C_Userinfo_name"] != null && row["C_Userinfo_name"].ToString() != "")
                    {
                        model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
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
            strSql.Append("select O_Article_user_id,O_Article_code,C_Userinfo_code,O_Article_user_isRead,O_Article_user_readTime,O_Article_user_creator,O_Article_user_createTime,O_Article_user_isDelete ");
            strSql.Append(" FROM O_Article_user ");
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
            strSql.Append(" O_Article_user_id,O_Article_code,C_Userinfo_code,O_Article_user_isRead,O_Article_user_readTime,O_Article_user_creator,O_Article_user_createTime,O_Article_user_isDelete ");
            strSql.Append(" FROM O_Article_user ");
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
            strSql.Append("select count(1) FROM O_Article_user ");
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
                strSql.Append("order by T.O_Article_user_id desc");
            }
            strSql.Append(")AS Row, T.*  from O_Article_user T ");
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
            parameters[0].Value = "O_Article_user";
            parameters[1].Value = "O_Article_user_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        /// <summary>
        /// 根据文章guid获得已经读取该文章的用户集合获得数据列表
        /// </summary>
        public DataSet GetListByCode(Guid O_Article_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Article_user_id,O_Article_code,a.C_Userinfo_code,O_Article_user_isRead,O_Article_user_readTime,O_Article_user_creator,O_Article_user_createTime,O_Article_user_isDelete,b.C_Userinfo_name as C_Userinfo_name");
            strSql.Append(" FROM O_Article_user as a left join C_Userinfo as b on a.C_Userinfo_code=b.C_Userinfo_code");
            strSql.Append(" where 1=1  and O_Article_code=@O_Article_code and O_Article_user_isRead=1 and O_Article_user_isDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = O_Article_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据文章guid获得未读取该文章的用户集合获得数据列表
        /// </summary>
        public DataSet GetNoreadListByCode(Guid O_Article_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Article_user_id,O_Article_code,a.C_Userinfo_code,O_Article_user_isRead,O_Article_user_readTime,O_Article_user_creator,O_Article_user_createTime,O_Article_user_isDelete,b.C_Userinfo_name as C_Userinfo_name ");
            strSql.Append(" FROM O_Article_user as a left join C_Userinfo as b on a.C_Userinfo_code=b.C_Userinfo_code ");
            strSql.Append(" where 1=1  and O_Article_code=@O_Article_code and O_Article_user_isRead=0 and O_Article_user_isDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = O_Article_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
