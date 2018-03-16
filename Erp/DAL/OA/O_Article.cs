using cn.jpush.api;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonService.DAL.OA
{
    /// <summary>
    /// 数据访问类:O_Article文章表
    /// cyj
    /// 2015年7月14日16:44:14
    /// </summary>
    public partial class O_Article
    {
        public O_Article()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Article_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Article");
            strSql.Append(" where O_Article_id=@O_Article_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Article_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Article(");
            strSql.Append("O_Article_code,O_Article_title,O_Article_content,O_Article_publisher,O_Article_publishTime,O_Article_state,O_Article_creator,O_Article_createTime,O_Article_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@O_Article_code,@O_Article_title,@O_Article_content,@O_Article_publisher,@O_Article_publishTime,@O_Article_state,@O_Article_creator,@O_Article_createTime,@O_Article_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_title", SqlDbType.NVarChar,200),
					new SqlParameter("@O_Article_content", SqlDbType.Text),
					new SqlParameter("@O_Article_publisher", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_publishTime", SqlDbType.DateTime),
					new SqlParameter("@O_Article_state", SqlDbType.Int,4),
					new SqlParameter("@O_Article_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Article_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.O_Article_code;
            parameters[1].Value = model.O_Article_title;
            parameters[2].Value = model.O_Article_content;
            parameters[3].Value = model.O_Article_publisher;
            parameters[4].Value = model.O_Article_publishTime;
            parameters[5].Value = model.O_Article_state;
            parameters[6].Value = model.O_Article_creator;
            parameters[7].Value = model.O_Article_createTime;
            parameters[8].Value = model.O_Article_isDelete;

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
        public bool Update(CommonService.Model.OA.O_Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Article set ");
            strSql.Append("O_Article_code=@O_Article_code,");
            strSql.Append("O_Article_title=@O_Article_title,");
            strSql.Append("O_Article_content=@O_Article_content,");
            strSql.Append("O_Article_publisher=@O_Article_publisher,");
            strSql.Append("O_Article_publishTime=@O_Article_publishTime,");
            strSql.Append("O_Article_state=@O_Article_state,");
            strSql.Append("O_Article_creator=@O_Article_creator,");
            strSql.Append("O_Article_createTime=@O_Article_createTime,");
            strSql.Append("O_Article_isDelete=@O_Article_isDelete");
            strSql.Append(" where O_Article_id=@O_Article_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_title", SqlDbType.NVarChar,200),
					new SqlParameter("@O_Article_content", SqlDbType.Text),
					new SqlParameter("@O_Article_publisher", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_publishTime", SqlDbType.DateTime),
					new SqlParameter("@O_Article_state", SqlDbType.Int,4),
					new SqlParameter("@O_Article_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Article_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Article_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Article_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Article_code;
            parameters[1].Value = model.O_Article_title;
            parameters[2].Value = model.O_Article_content;
            parameters[3].Value = model.O_Article_publisher;
            parameters[4].Value = model.O_Article_publishTime;
            parameters[5].Value = model.O_Article_state;
            parameters[6].Value = model.O_Article_creator;
            parameters[7].Value = model.O_Article_createTime;
            parameters[8].Value = model.O_Article_isDelete;
            parameters[9].Value = model.O_Article_id;

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
        public bool Delete(Guid articleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Article set O_Article_isDelete =1 ");
            strSql.Append(" where O_Article_code=@O_Article_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = articleCode;

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
        public bool DeleteList(string O_Article_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Article ");
            strSql.Append(" where O_Article_id in (" + O_Article_idlist + ")  ");
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
        public CommonService.Model.OA.O_Article GetModel(Guid O_Article_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Article_id,O_Article_code,O_Article_title,O_Article_content,O_Article_publisher,O_Article_publishTime,O_Article_state,O_Article_creator,O_Article_createTime,O_Article_isDelete,B.C_Userinfo_name As C_Userinfo_name from O_Article As A ");
            strSql.Append(" left join C_Userinfo As B on A.O_Article_creator=B.C_Userinfo_code");
            strSql.Append(" where O_Article_code=@O_Article_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Article_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Article_code;

            CommonService.Model.OA.O_Article model = new CommonService.Model.OA.O_Article();
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
        public CommonService.Model.OA.O_Article DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Article model = new CommonService.Model.OA.O_Article();
            if (row != null)
            {
                if (row["O_Article_id"] != null && row["O_Article_id"].ToString() != "")
                {
                    model.O_Article_id = int.Parse(row["O_Article_id"].ToString());
                }
                if (row["O_Article_code"] != null && row["O_Article_code"].ToString() != "")
                {
                    model.O_Article_code = new Guid(row["O_Article_code"].ToString());
                }
                if (row["O_Article_title"] != null)
                {
                    model.O_Article_title = row["O_Article_title"].ToString();
                }
                if (row["O_Article_content"] != null)
                {
                    model.O_Article_content = row["O_Article_content"].ToString();
                }
                if (row["O_Article_publisher"] != null && row["O_Article_publisher"].ToString() != "")
                {
                    model.O_Article_publisher = new Guid(row["O_Article_publisher"].ToString());
                }
                //发布人名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("O_Article_publisher_name"))
                {
                    if (row["O_Article_publisher_name"] != null)
                    {
                        model.O_Article_publisher_name = row["O_Article_publisher_name"].ToString();
                    }
                }
                if (row["O_Article_publishTime"] != null && row["O_Article_publishTime"].ToString() != "")
                {
                    model.O_Article_publishTime = DateTime.Parse(row["O_Article_publishTime"].ToString());
                }
                if (row.Table.Columns.Contains("o_article_isread"))
                {
                    if (row["o_article_isread"] != null && row["o_article_isread"].ToString() != "")
                    {
                        model.O_article_isread = Boolean.Parse(row["o_article_isread"].ToString());
                    }
                }               
                if (row["O_Article_state"] != null && row["O_Article_state"].ToString() != "")
                {
                    model.O_Article_state = int.Parse(row["O_Article_state"].ToString());
                }
                //文章状态中文名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("O_Article_state_name"))
                {
                    if (row["O_Article_state_name"] != null)
                    {
                        model.O_Article_state_name = row["O_Article_state_name"].ToString();
                    }
                }
                if (row["O_Article_creator"] != null && row["O_Article_creator"].ToString() != "")
                {
                    model.O_Article_creator = new Guid(row["O_Article_creator"].ToString());
                }
                if (row["O_Article_createTime"] != null && row["O_Article_createTime"].ToString() != "")
                {
                    model.O_Article_createTime = DateTime.Parse(row["O_Article_createTime"].ToString());
                }
                if (row["O_Article_isDelete"] != null && row["O_Article_isDelete"].ToString() != "")
                {
                    if ((row["O_Article_isDelete"].ToString() == "1") || (row["O_Article_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Article_isDelete = true;
                    }
                    else
                    {
                        model.O_Article_isDelete = false;
                    }
                }
                //文章状态中文名称(虚拟属性)是否存在于列集合中
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
            strSql.Append("select O_Article_id,O_Article_code,O_Article_title,O_Article_content,O_Article_publisher,O_Article_publishTime,O_Article_state,O_Article_creator,O_Article_createTime,O_Article_isDelete ");
            strSql.Append(" FROM O_Article ");
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
            strSql.Append(" O_Article_id,O_Article_code,O_Article_title,O_Article_content,O_Article_publisher,O_Article_publishTime,O_Article_state,O_Article_creator,O_Article_createTime,O_Article_isDelete ");
            strSql.Append(" FROM O_Article ");
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
        public int GetRecordCount(CommonService.Model.OA.O_Article model)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM O_Article With(nolock) ");
            strSql.Append(" where 1=1 and O_Article_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Article_title != null)
                {
                    strSql.Append("and O_Article_title like N'%'+@O_Article_title+'%'");
                }
                if (model.O_Article_state != null)
                {
                    strSql.Append("and O_Article_state=@O_Article_state ");
                } 
            }
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Article_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@O_Article_state", SqlDbType.Int,4)
		    };
            parameters[0].Value = model.O_Article_title;
            parameters[1].Value = model.O_Article_state;
           
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
        /// 获取个人文章记录总数
        /// </summary>
        public int GetRecordCount2(CommonService.Model.OA.O_Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM O_Article As T With(nolock) ");
            strSql.Append("left join O_Article_user As O on O.O_Article_code=T.O_Article_code ");
            strSql.Append(" where 1=1 and O_Article_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Article_title != null)
                {
                    strSql.Append("and O_Article_title like N'%'+@O_Article_title+'%' ");
                }
                if (model.O_Article_state != null)
                {
                    strSql.Append("and O_Article_state=@O_Article_state ");
                }
                if (model.C_Userinfo_code != null)
                {
                    strSql.Append("and O.C_Userinfo_code=@C_Userinfo_code");
                }
            }
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Article_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@O_Article_state", SqlDbType.Int,4),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
		    };
            parameters[0].Value = model.O_Article_title;
            parameters[1].Value = model.O_Article_state;
            parameters[2].Value = model.C_Userinfo_code;
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
        public DataSet GetListByPage(CommonService.Model.OA.O_Article model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.O_Article_createTime desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name AS O_Article_state_name,U.C_Userinfo_name As O_Article_publisher_name ");
            strSql.Append("from O_Article AS T With(nolock) ");
            strSql.Append("left join C_Parameters AS P With(nolock) on T.O_Article_state=P.C_Parameters_id ");
            strSql.Append("left join C_Userinfo AS U With(nolock) on T.O_Article_publisher=U.C_Userinfo_code ");
            strSql.Append(" where 1=1 and T.O_Article_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Article_title != null)
                {
                    strSql.Append("and O_Article_title like N'%'+@O_Article_title+'%'");
                }
                if (model.O_Article_state != null)
                {
                    strSql.Append("and O_Article_state=@O_Article_state ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Article_title", SqlDbType.NVarChar,50),
				    new SqlParameter("@O_Article_state", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.O_Article_title;
            parameters[1].Value = model.O_Article_state;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 我的文章分页获取数据列表
        /// </summary>
        public DataSet GetListByPage2(CommonService.Model.OA.O_Article model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by O.O_Article_user_isRead,T.O_Article_createTime desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name AS O_Article_state_name,U.C_Userinfo_name As O_Article_publisher_name,O.C_Userinfo_code As C_Userinfo_code,O.O_Article_user_isRead As o_article_isread ");
            strSql.Append("from O_Article AS T With(nolock) ");
            strSql.Append("left join C_Parameters AS P With(nolock) on T.O_Article_state=P.C_Parameters_id ");
            strSql.Append("left join C_Userinfo AS U With(nolock) on T.O_Article_publisher=U.C_Userinfo_code ");
            strSql.Append("left join O_Article_user As O on O.O_Article_code=T.O_Article_code ");
            strSql.Append(" where 1=1 and T.O_Article_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Article_title != null)
                {
                    strSql.Append("and O_Article_title like N'%'+@O_Article_title+'%' ");
                }
                if (model.O_Article_state != null)
                {
                    strSql.Append("and O_Article_state=@O_Article_state ");
                }
                if (model.C_Userinfo_code != null)
                {
                    strSql.Append("and O.C_Userinfo_code=@C_Userinfo_code");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            
                SqlParameter[] parameters = {					 
					new SqlParameter("@O_Article_title", SqlDbType.NVarChar,50),
				    new SqlParameter("@O_Article_state", SqlDbType.Int,4),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
                                        };
                if (model != null)
                {
                    parameters[0].Value = model.O_Article_title;
                    parameters[1].Value = model.O_Article_state;
                    parameters[2].Value = model.C_Userinfo_code;
                }
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
            parameters[0].Value = "O_Article";
            parameters[1].Value = "O_Article_id";
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

        #region App专用

        /// <summary>
        /// 根据用户GUID获取该用户未读的公告
        /// </summary>
        /// <param name="guid">主用户GUID</param>
        /// <returns>未读数量</returns>
        public int GetUnReadCount(Guid? guid)
        {
            string sql = "select count(1) from O_Article_user As OU,O_Article As A where A.O_Article_code=OU.O_Article_code and OU.C_Userinfo_code=@guid and A.O_Article_isDelete=0 and OU.O_Article_user_isDelete=0 and OU.O_Article_user_isRead=0";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@guid",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = guid;

            object obj = DbHelperSQL.GetSingle(sql,para);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            } 
        }

        #endregion
    }
}
