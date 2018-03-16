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
    /// 数据访问类:O_Email_user8.	邮件----收件人中间表
    /// cyj 
    /// 2015年7月14日16:32:24
    /// </summary>
    public partial class O_Email_user
    {
        public O_Email_user()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Email_user");
            strSql.Append(" where O_Email_user_id=@O_Email_user_id and O_Email_code=@O_Email_code and C_Userinfo_code=@C_Userinfo_code and O_Email_user_isRead=@O_Email_user_isRead and O_Email_user_type=@O_Email_user_type and O_Email_creator=@O_Email_creator and O_Email_createTime=@O_Email_createTime and O_Email_isDelete=@O_Email_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_user_id", SqlDbType.Int,4),
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_user_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Email_user_type", SqlDbType.Int,4),
					new SqlParameter("@O_Email_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Email_user_id;
            parameters[1].Value = O_Email_code;
            parameters[2].Value = C_Userinfo_code;
            parameters[3].Value = O_Email_user_isRead;
            parameters[4].Value = O_Email_user_type;
            parameters[5].Value = O_Email_creator;
            parameters[6].Value = O_Email_createTime;
            parameters[7].Value = O_Email_isDelete;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.OA.O_Email_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Email_user(");
            strSql.Append("O_Email_code,C_Userinfo_code,O_Email_user_isRead,O_Email_user_type,O_Email_creator,O_Email_createTime,O_Email_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@O_Email_code,@C_Userinfo_code,@O_Email_user_isRead,@O_Email_user_type,@O_Email_creator,@O_Email_createTime,@O_Email_isDelete)");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_user_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Email_user_type", SqlDbType.Int,4),
					new SqlParameter("@O_Email_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.O_Email_code;
            parameters[1].Value = model.C_Userinfo_code;
            parameters[2].Value = model.O_Email_user_isRead;
            parameters[3].Value = model.O_Email_user_type;
            parameters[4].Value = model.O_Email_creator;
            parameters[5].Value = model.O_Email_createTime;
            parameters[6].Value = model.O_Email_isDelete;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Email_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Email_user set ");
            strSql.Append("O_Email_code=@O_Email_code,");
            strSql.Append("C_Userinfo_code=@C_Userinfo_code,");
            strSql.Append("O_Email_user_isRead=@O_Email_user_isRead,");
            strSql.Append("O_Email_user_type=@O_Email_user_type,");
            strSql.Append("O_Email_creator=@O_Email_creator,");
            strSql.Append("O_Email_createTime=@O_Email_createTime,");
            strSql.Append("O_Email_isDelete=@O_Email_isDelete");
            strSql.Append(" where O_Email_code=@O_Email_code and C_Userinfo_code=@C_Userinfo_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_user_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Email_user_type", SqlDbType.Int,4),
					new SqlParameter("@O_Email_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.O_Email_code;
            parameters[1].Value = model.C_Userinfo_code;
            parameters[2].Value = model.O_Email_user_isRead;
            parameters[3].Value = model.O_Email_user_type;
            parameters[4].Value = model.O_Email_creator;
            parameters[5].Value = model.O_Email_createTime;
            parameters[6].Value = model.O_Email_isDelete;

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
        public bool Delete(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Email_user ");
            strSql.Append(" where O_Email_user_id=@O_Email_user_id and O_Email_code=@O_Email_code and C_Userinfo_code=@C_Userinfo_code and O_Email_user_isRead=@O_Email_user_isRead and O_Email_user_type=@O_Email_user_type and O_Email_creator=@O_Email_creator and O_Email_createTime=@O_Email_createTime and O_Email_isDelete=@O_Email_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_user_id", SqlDbType.Int,4),
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_user_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Email_user_type", SqlDbType.Int,4),
					new SqlParameter("@O_Email_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Email_user_id;
            parameters[1].Value = O_Email_code;
            parameters[2].Value = C_Userinfo_code;
            parameters[3].Value = O_Email_user_isRead;
            parameters[4].Value = O_Email_user_type;
            parameters[5].Value = O_Email_creator;
            parameters[6].Value = O_Email_createTime;
            parameters[7].Value = O_Email_isDelete;

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
        /// 根据邮件的code和收件人code删除一条数据
        /// </summary>
        public bool DeleteByCode(Guid O_Email_code, Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Email_user set  O_Email_isDelete=1 ");
            strSql.Append(" where O_Email_code=@O_Email_code and C_Userinfo_code=@C_Userinfo_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Email_code;
            parameters[1].Value = userCode;
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
        /// 根据邮件的code删除多条收件人数据
        /// </summary>
        public bool DeleteByEmailCodeD(Guid O_Email_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  O_Email_user ");
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
        /// 根据邮件的code删除一条数据
        /// </summary>
        public bool DeleteByemailCode(Guid O_Email_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Email_user set  O_Email_isDelete=1 ");
            strSql.Append(" where O_Email_code=@O_Email_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
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
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Email_user GetModel(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Email_user_id,O_Email_code,C_Userinfo_code,O_Email_user_isRead,O_Email_user_type,O_Email_creator,O_Email_createTime,O_Email_isDelete from O_Email_user ");
            strSql.Append(" where O_Email_user_id=@O_Email_user_id and O_Email_code=@O_Email_code and C_Userinfo_code=@C_Userinfo_code and O_Email_user_isRead=@O_Email_user_isRead and O_Email_user_type=@O_Email_user_type and O_Email_creator=@O_Email_creator and O_Email_createTime=@O_Email_createTime and O_Email_isDelete=@O_Email_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Email_user_id", SqlDbType.Int,4),
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_user_isRead", SqlDbType.Bit,1),
					new SqlParameter("@O_Email_user_type", SqlDbType.Int,4),
					new SqlParameter("@O_Email_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Email_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Email_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Email_user_id;
            parameters[1].Value = O_Email_code;
            parameters[2].Value = C_Userinfo_code;
            parameters[3].Value = O_Email_user_isRead;
            parameters[4].Value = O_Email_user_type;
            parameters[5].Value = O_Email_creator;
            parameters[6].Value = O_Email_createTime;
            parameters[7].Value = O_Email_isDelete;

            CommonService.Model.OA.O_Email_user model = new CommonService.Model.OA.O_Email_user();
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
        /// 根据邮件guid和收件人guid获取数据
        /// </summary>
        public CommonService.Model.OA.O_Email_user GetModelByEcodeAndUcode(Guid O_Email_code, Guid C_Userinfo_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.O_Email_user_id,A.O_Email_code,A.C_Userinfo_code,A.O_Email_user_isRead,O_Email_user_type,A.O_Email_creator,A.O_Email_createTime,A.O_Email_isDelete,B.O_Email_title As O_Email_title,B.O_Email_sender As O_Email_sender,C.C_Userinfo_name As C_Userinfo_name ,D.C_Messages_id As C_Messages_id ");
            strSql.Append(" FROM O_Email_user As A left join O_Email As B on A.O_Email_code=B.O_Email_code left join C_Userinfo As C on B.O_Email_sender=C.C_Userinfo_code left join C_Messages As D on D.C_Messages_link=A.O_Email_code");
            strSql.Append(" where A.O_Email_code=@O_Email_code and A.C_Userinfo_code=@C_Userinfo_code  and A.O_Email_isDelete=0 and O_Email_user_isRead=0 ");
            strSql.Append(" and A.O_Email_user_isRead=0 ");
            strSql.Append(" and A.O_Email_user_type=503 ");
            strSql.Append(" order by A.O_Email_createTime desc ");
            SqlParameter[] parameters = {					 
                    new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = O_Email_code;
            parameters[1].Value = C_Userinfo_code;

            CommonService.Model.OA.O_Email_user model = new CommonService.Model.OA.O_Email_user();
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
        public CommonService.Model.OA.O_Email_user DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Email_user model = new CommonService.Model.OA.O_Email_user();
            if (row != null)
            {
                if (row["O_Email_user_id"] != null && row["O_Email_user_id"].ToString() != "")
                {
                    model.O_Email_user_id = int.Parse(row["O_Email_user_id"].ToString());
                }
                if (row["O_Email_code"] != null && row["O_Email_code"].ToString() != "")
                {
                    model.O_Email_code = new Guid(row["O_Email_code"].ToString());
                }
                if (row["C_Userinfo_code"] != null && row["C_Userinfo_code"].ToString() != "")
                {
                    model.C_Userinfo_code = new Guid(row["C_Userinfo_code"].ToString());
                }
                if (row["O_Email_user_isRead"] != null && row["O_Email_user_isRead"].ToString() != "")
                {
                    if ((row["O_Email_user_isRead"].ToString() == "1") || (row["O_Email_user_isRead"].ToString().ToLower() == "true"))
                    {
                        model.O_Email_user_isRead = true;
                    }
                    else
                    {
                        model.O_Email_user_isRead = false;
                    }
                }
                if (row["O_Email_user_type"] != null && row["O_Email_user_type"].ToString() != "")
                {
                    model.O_Email_user_type = int.Parse(row["O_Email_user_type"].ToString());
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
                //虚拟字段是否存在于集合中（邮件标题）
                if (row.Table.Columns.Contains("O_Email_title"))
                {
                    if (row["O_Email_title"] != null && row["O_Email_title"].ToString() != "")
                    {
                        model.O_Email_title = row["O_Email_title"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（邮件内容）
                if (row.Table.Columns.Contains("O_Email_content"))
                {
                    if (row["O_Email_content"] != null && row["O_Email_content"].ToString() != "")
                    {
                        model.O_Email_content = row["O_Email_content"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（邮件的创建时间）
                if (row.Table.Columns.Contains("O_Email_createTime2"))
                {
                    if (row["O_Email_createTime2"] != null && row["O_Email_createTime2"].ToString() != "")
                    {
                        model.O_Email_createTime2 = DateTime.Parse(row["O_Email_createTime2"].ToString());
                    }
                }
                //虚拟字段是否存在于集合中（邮件的创建时间）
                if (row.Table.Columns.Contains("O_Email_sender"))
                {
                    if (row["O_Email_sender"] != null && row["O_Email_sender"].ToString() != "")
                    {
                        model.O_Email_sender = new Guid(row["O_Email_sender"].ToString());
                    }
                }
                //虚拟字段是否存在于集合中（发送人名称）
                if (row.Table.Columns.Contains("C_Userinfo_name"))
                {
                    if (row["C_Userinfo_name"] != null && row["C_Userinfo_name"].ToString() != "")
                    {
                        model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（收件人名称）
                if (row.Table.Columns.Contains("C_Userinfo_name2"))
                {
                    if (row["C_Userinfo_name2"] != null && row["C_Userinfo_name2"].ToString() != "")
                    {
                        model.C_Userinfo_name2 = row["C_Userinfo_name2"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（收件人名称）
                if (row.Table.Columns.Contains("Listname"))
                {
                    if (row["Listname"] != null && row["Listname"].ToString() != "")
                    {
                        model.Listname = row["Listname"].ToString();
                    }
                }
                //虚拟字段是否存在于集合中（消息id）
                if (row.Table.Columns.Contains("C_Messages_id"))
                {
                    if (row["C_Messages_id"] != null && row["C_Messages_id"].ToString() != "")
                    {
                        model.C_Messages_id = int.Parse(row["C_Messages_id"].ToString());
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
            strSql.Append("select O_Email_user_id,O_Email_code,C_Userinfo_code,O_Email_user_isRead,O_Email_user_type,O_Email_creator,O_Email_createTime,O_Email_isDelete ");
            strSql.Append(" FROM O_Email_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据邮件code获得数据列表
        /// </summary>
        public DataSet GetListByEmailCode(Guid emailCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Email_user_id,O_Email_code,C_Userinfo_code,O_Email_user_isRead,O_Email_user_type,O_Email_creator,O_Email_createTime,O_Email_isDelete ");
            strSql.Append(" FROM O_Email_user where O_Email_code=@O_Email_code ");
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Email_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = emailCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            strSql.Append(" O_Email_user_id,O_Email_code,C_Userinfo_code,O_Email_user_isRead,O_Email_user_type,O_Email_creator,O_Email_createTime,O_Email_isDelete ");
            strSql.Append(" FROM O_Email_user ");
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
        public int GetRecordCount(CommonService.Model.OA.O_Email_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM O_Email_user As A  left join O_Email As B on A.O_Email_code=B.O_Email_code ");
            strSql.Append(" where 1=1 and B.O_Email_isDelete=0 and A.O_Email_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Email_state != null)
                {
                    strSql.Append("and B.O_Email_state=@O_Email_state ");
                }
                if (model.O_Email_user_type != null)
                {
                    strSql.Append("and A.O_Email_user_type=@O_Email_user_type ");
                }
                if (model.C_Userinfo_code != null)
                {
                    strSql.Append("and A.C_Userinfo_code=@C_Userinfo_code ");
                }
                if (model.O_Email_sender != null)
                {
                    strSql.Append("and B.O_Email_sender=@O_Email_sender ");
                }
                if (model.O_Email_title != null)
                {
                    strSql.Append("and O_Email_title like N'%'+@O_Email_title+'%' ");
                }
            }
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Email_state", SqlDbType.Int,4),
                    new SqlParameter("@O_Email_user_type", SqlDbType.Int,4),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@O_Email_sender", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@O_Email_title", SqlDbType.VarChar,200),
		    };
            parameters[0].Value = model.O_Email_state;
            parameters[1].Value = model.O_Email_user_type;
            parameters[2].Value = model.C_Userinfo_code;
            parameters[3].Value = model.O_Email_sender;
            parameters[4].Value = model.O_Email_title;
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
        public DataSet GetListByPage(CommonService.Model.OA.O_Email_user model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.O_Email_createTime desc");
            }
            strSql.Append(")AS Row, dbo.getEmailUserlists(O.O_Email_code) As Listname,T.*,O.O_Email_title As O_Email_title,O.O_Email_content As O_Email_content, O.O_Email_createTime As O_Email_createTime2,O.O_Email_sender As O_Email_sender, O.C_Userinfo_name As C_Userinfo_name,T.C_Userinfo_name3 As C_Userinfo_name2 ");
            strSql.Append("from (select M.*,C.C_Userinfo_name As C_Userinfo_name3 from O_Email_user AS M left join C_Userinfo As C on M.C_Userinfo_code=C.C_Userinfo_code) As T  ");
            strSql.Append("left join  (select * from O_Email AS E left join C_Userinfo As U on E.O_Email_sender=U.C_Userinfo_code ) As O on T.O_Email_code=O.O_Email_code ");
            strSql.Append(" where 1=1 and T.O_Email_isDelete=0 And O.O_Email_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Email_state != null)
                {
                    strSql.Append("and  O.O_Email_state=@O_Email_state ");
                }
                if (model.O_Email_user_type != null)
                {
                    strSql.Append("and T.O_Email_user_type=@O_Email_user_type ");
                }
                if (model.C_Userinfo_code != null)
                {
                    strSql.Append("and T.C_Userinfo_code=@C_Userinfo_code ");
                }
                if (model.O_Email_sender != null)
                {
                    strSql.Append("and O.O_Email_sender=@O_Email_sender ");
                }
                if (model.O_Email_title != null)
                {
                    strSql.Append("and O_Email_title like N'%'+@O_Email_title+'%' ");
                }

            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Email_state", SqlDbType.Int,4),
                    new SqlParameter("@O_Email_user_type", SqlDbType.Int,4),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@O_Email_sender", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@O_Email_title", SqlDbType.VarChar,200),
		    };
            parameters[0].Value = model.O_Email_state;
            parameters[1].Value = model.O_Email_user_type;
            parameters[2].Value = model.C_Userinfo_code;
            parameters[3].Value = model.O_Email_sender;
            parameters[4].Value = model.O_Email_title;
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
            parameters[0].Value = "O_Email_user";
            parameters[1].Value = "O_Email_isDelete";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        /// <summary>
        /// 根据收件人code获得未读邮件的数据列表
        /// </summary>
        public DataSet GetNoReadListUserCode(Guid C_Userinfo_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  A.O_Email_user_id,A.O_Email_code,A.C_Userinfo_code,A.O_Email_user_isRead,O_Email_user_type,A.O_Email_creator,A.O_Email_createTime,A.O_Email_isDelete,B.O_Email_title As O_Email_title,B.O_Email_sender As O_Email_sender,C.C_Userinfo_name As C_Userinfo_name,D.C_Messages_id As C_Messages_id  ");
            strSql.Append(" FROM O_Email_user As A left join O_Email As B on A.O_Email_code=B.O_Email_code left join C_Userinfo As C on B.O_Email_sender=C.C_Userinfo_code left join C_Messages As D on D.C_Messages_link=A.O_Email_code");
            strSql.Append(" where  A.C_Userinfo_code=@C_Userinfo_code and A.O_Email_isDelete=0 and O_Email_user_isRead=0 ");
            strSql.Append(" and A.O_Email_user_isRead=0 ");
            strSql.Append(" and A.O_Email_user_type=503 and B.O_Email_state=489 ");
            strSql.Append(" and d.C_Messages_person=@C_Userinfo_code ");
            strSql.Append(" order by A.O_Email_createTime desc ");
            SqlParameter[] parameters = {					 
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = C_Userinfo_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据收件人code获得所有的邮件数据列表以及邮件的消息信息
        /// </summary>
        public DataSet GetListByUserCode(Guid C_Userinfo_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  A.O_Email_user_id,A.O_Email_code,A.C_Userinfo_code,A.O_Email_user_isRead,O_Email_user_type,A.O_Email_creator,A.O_Email_createTime,A.O_Email_isDelete,B.O_Email_title As O_Email_title,B.O_Email_sender As O_Email_sender,C.C_Userinfo_name As C_Userinfo_name,D.C_Messages_id As C_Messages_id  ");
            strSql.Append(" FROM O_Email_user As A left join O_Email As B on A.O_Email_code=B.O_Email_code left join C_Userinfo As C on B.O_Email_sender=C.C_Userinfo_code left join C_Messages As D on D.C_Messages_link=A.O_Email_code");
            strSql.Append(" where  A.C_Userinfo_code=@C_Userinfo_code and A.O_Email_isDelete=0 and B.O_Email_state=489 ");
            strSql.Append(" and A.O_Email_user_type=503 ");
            strSql.Append(" order by A.O_Email_createTime desc ");
            SqlParameter[] parameters = {					 
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = C_Userinfo_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
