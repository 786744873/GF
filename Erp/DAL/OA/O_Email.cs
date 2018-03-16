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
    /// 数据访问类:O_Email
    /// 邮件表
    /// cyj
    /// 2015年7月14日17:10:10
    /// </summary>
    public partial class O_Email
    {
        public O_Email()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Email_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Email");
            strSql.Append(" where O_Email_id=@O_Email_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Email_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Email model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Email(");
            strSql.Append("O_Email_code,O_Email_title,O_Email_content,O_Email_sender,O_Email_sendTime,O_Email_state,O_Email_creator,O_Email_createTime,O_Email_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@O_Email_code,@O_Email_title,@O_Email_content,@O_Email_sender,@O_Email_sendTime,@O_Email_state,@O_Email_creator,@O_Email_createTime,@O_Email_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_title", SqlDbType.NVarChar,100),
					new SqlParameter("@O_Email_content", SqlDbType.Text),
					new SqlParameter("@O_Email_sender", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_sendTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_state", SqlDbType.Int,4),
					new SqlParameter("@O_Email_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.O_Email_code;
            parameters[1].Value = model.O_Email_title;
            parameters[2].Value = model.O_Email_content;
            parameters[3].Value = model.O_Email_sender;
            parameters[4].Value = model.O_Email_sendTime;
            parameters[5].Value = model.O_Email_state;
            parameters[6].Value = model.O_Email_sender;
            parameters[7].Value = model.O_Email_createTime;
            parameters[8].Value = model.O_Email_isDelete;

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
        public bool Update(CommonService.Model.OA.O_Email model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Email set ");
            strSql.Append("O_Email_title=@O_Email_title,");
            strSql.Append("O_Email_content=@O_Email_content,");
            strSql.Append("O_Email_sender=@O_Email_sender,");
            strSql.Append("O_Email_sendTime=@O_Email_sendTime,");
            strSql.Append("O_Email_state=@O_Email_state,");
            strSql.Append("O_Email_creator=@O_Email_creator,");
            strSql.Append("O_Email_createTime=@O_Email_createTime,");
            strSql.Append("O_Email_isDelete=@O_Email_isDelete");
            strSql.Append(" where O_Email_code=@O_Email_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_title", SqlDbType.NVarChar,100),
					new SqlParameter("@O_Email_content", SqlDbType.Text),
					new SqlParameter("@O_Email_sender", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_sendTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_state", SqlDbType.Int,4),
					new SqlParameter("@O_Email_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_isDelete", SqlDbType.Bit,1),
  					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16)
                                        };

            parameters[0].Value = model.O_Email_title;
            parameters[1].Value = model.O_Email_content;
            parameters[2].Value = model.O_Email_sender;
            parameters[3].Value = model.O_Email_sendTime;
            parameters[4].Value = model.O_Email_state;
            parameters[5].Value = model.O_Email_creator;
            parameters[6].Value = model.O_Email_createTime;
            parameters[7].Value = model.O_Email_isDelete;
            parameters[8].Value = model.O_Email_code;
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
        public bool Delete(int O_Email_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Email ");
            strSql.Append(" where O_Email_id=@O_Email_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Email_id;

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
        public bool UpdateStateByEmail(Guid O_Email_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Email set  O_Email_state=@O_Email_state ");
            strSql.Append(" where O_Email_code=@O_Email_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Email_code;

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
        /// 根据邮件的code删除一条数据
        /// </summary>
        public bool DeleteByCode(Guid O_Email_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Email set  O_Email_isDelete=1 ");
            strSql.Append(" where O_Email_code=@O_Email_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Email_code;

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
        public bool DeleteList(string O_Email_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Email ");
            strSql.Append(" where O_Email_id in (" + O_Email_idlist + ")  ");
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
        public CommonService.Model.OA.O_Email GetModel(int O_Email_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Email_id,O_Email_code,O_Email_title,O_Email_content,O_Email_sender,O_Email_sendTime,O_Email_state,O_Email_creator,O_Email_createTime,O_Email_isDelete from O_Email ");
            strSql.Append(" where O_Email_id=@O_Email_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Email_id;

            CommonService.Model.OA.O_Email model = new CommonService.Model.OA.O_Email();
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
        /// 根据emailcode得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Email GetModelByCode(Guid emailCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Email_id,A.O_Email_code As O_Email_code,O_Email_title,O_Email_content,O_Email_sender,O_Email_sendTime,O_Email_state,A.O_Email_creator As O_Email_creator,A.O_Email_createTime As O_Email_createTime,O_Email_isDelete,B.C_Userinfo_name As O_Email_sendername, dbo.getEmailUserlists(A.O_Email_code) As O_Email_userListname  ");
            strSql.Append("from O_Email As A left join C_Userinfo As B on A.O_Email_sender=B.C_Userinfo_code");
            strSql.Append(" where O_Email_code=@O_Email_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = emailCode;

            CommonService.Model.OA.O_Email model = new CommonService.Model.OA.O_Email();
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
        public CommonService.Model.OA.O_Email DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Email model = new CommonService.Model.OA.O_Email();
            if (row != null)
            {
                if (row["O_Email_id"] != null && row["O_Email_id"].ToString() != "")
                {
                    model.O_Email_id = int.Parse(row["O_Email_id"].ToString());
                }
                if (row["O_Email_code"] != null && row["O_Email_code"].ToString() != "")
                {
                    model.O_Email_code = new Guid(row["O_Email_code"].ToString());
                }
                if (row["O_Email_title"] != null)
                {
                    model.O_Email_title = row["O_Email_title"].ToString();
                }
                if (row["O_Email_content"] != null)
                {
                    model.O_Email_content = row["O_Email_content"].ToString();
                }
                if (row["O_Email_sender"] != null && row["O_Email_sender"].ToString() != "")
                {
                    model.O_Email_sender = new Guid(row["O_Email_sender"].ToString());
                }
                if (row["O_Email_sendTime"] != null && row["O_Email_sendTime"].ToString() != "")
                {
                    model.O_Email_sendTime = DateTime.Parse(row["O_Email_sendTime"].ToString());
                }
                if (row["O_Email_state"] != null && row["O_Email_state"].ToString() != "")
                {
                    model.O_Email_state = int.Parse(row["O_Email_state"].ToString());
                }
                if (row["O_Email_creator"] != null && row["O_Email_creator"].ToString() != "")
                {
                    model.O_Email_creator = new Guid(row["O_Email_creator"].ToString());
                }
                if (row["O_Email_createTime"] != null && row["O_Email_createTime"].ToString() != "")
                {
                    model.O_Email_createTime = DateTime.Parse(row["O_Email_createTime"].ToString());
                }
                if (row["O_Email_isDelete"] != null && row["O_Email_isDelete"].ToString() != "")
                {
                    if ((row["O_Email_isDelete"].ToString() == "1") || (row["O_Email_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Email_isDelete = true;
                    }
                    else
                    {
                        model.O_Email_isDelete = false;
                    }
                }
                //虚拟字段是否存在于集合中（收件人名称）
                if (row.Table.Columns.Contains("O_Email_userListname"))
                {
                    if (row["O_Email_userListname"] != null)
                    {
                        model.O_Email_userListname = row["O_Email_userListname"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（发送人名称）
                if (row.Table.Columns.Contains("O_Email_sendername"))
                {
                    if (row["O_Email_sendername"] != null)
                    {
                        model.O_Email_sendername = row["O_Email_sendername"].ToString();
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
            strSql.Append("select O_Email_id,O_Email_code,O_Email_title,O_Email_content,O_Email_sender,O_Email_sendTime,O_Email_state,O_Email_creator,O_Email_createTime,O_Email_isDelete ");
            strSql.Append(" FROM O_Email ");
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
            strSql.Append(" O_Email_id,O_Email_code,O_Email_title,O_Email_content,O_Email_sender,O_Email_sendTime,O_Email_state,O_Email_creator,O_Email_createTime,O_Email_isDelete ");
            strSql.Append(" FROM O_Email ");
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
        public int GetRecordCount(CommonService.Model.OA.O_Email model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM O_Email where 1=1 ");
            if (model != null)
            {
                if (model.O_Email_sender != null)
                    strSql.Append(" and O_Email_sender=@O_Email_sender");
                if (model.O_Email_state != null)
                    strSql.Append(" and O_Email_state=@O_Email_state");
                if (model.O_Email_title != null)
                    strSql.Append(" and O_Email_title like N'%'+@O_Email_title+'%' ");
            }

            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Email_sender", SqlDbType.UniqueIdentifier,16),
                      new SqlParameter("@O_Email_state", SqlDbType.Int,4),
                      new SqlParameter("@O_Email_title", SqlDbType.VarChar,200) ,
                                        };
            parameters[0].Value = model.O_Email_sender;
            parameters[1].Value = model.O_Email_state;
            parameters[2].Value = model.O_Email_title;
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
        public DataSet GetListByPage(CommonService.Model.OA.O_Email model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.O_Email_id desc");
            }
            strSql.Append(")AS Row, T.*,dbo.getEmailUserlists(T.O_Email_code) As O_Email_userListname  from O_Email T ");
            strSql.Append(" where 1=1 and O_Email_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Email_sender != null)
                    strSql.Append(" and O_Email_sender=@O_Email_sender");
                if (model.O_Email_state != null)
                    strSql.Append(" and O_Email_state=@O_Email_state");
                if (model.O_Email_title != null)
                    strSql.Append(" and O_Email_title like N'%'+@O_Email_title+'%'");
            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Email_sender", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@O_Email_state", SqlDbType.Int,4) ,
                    new SqlParameter("@O_Email_title", SqlDbType.VarChar,200) ,
                                        };
            parameters[0].Value = model.O_Email_sender;
            parameters[1].Value = model.O_Email_state;
            parameters[2].Value = model.O_Email_title;
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
            parameters[0].Value = "O_Email";
            parameters[1].Value = "O_Email_id";
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
