using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:评论（回答）表
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Comments
    {
        public K_Comments()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("K_Comments_id", "K_Comments");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Comments_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Comments");
            strSql.Append(" where K_Comments_id=@K_Comments_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Comments_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Comments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Comments(");
            strSql.Append("K_Comments_code,K_Comments_type,K_Comments_content,K_Comments_score,K_Comments_parent,K_Comments_createTime,K_Comments_creator,K_Comments_isDelete,K_Comments_helpfulCount,K_Comments_uselessCount,K_Comments_floors,P_FK_code)");
            strSql.Append(" values (");
            strSql.Append("@K_Comments_code,@K_Comments_type,@K_Comments_content,@K_Comments_score,@K_Comments_parent,@K_Comments_createTime,@K_Comments_creator,@K_Comments_isDelete,@K_Comments_helpfulCount,@K_Comments_uselessCount,@K_Comments_floors,@P_FK_code)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Comments_type", SqlDbType.Int,4),
					new SqlParameter("@K_Comments_content", SqlDbType.Text),
					new SqlParameter("@K_Comments_score", SqlDbType.Int,4),
					new SqlParameter("@K_Comments_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Comments_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Comments_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Comments_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Comments_helpfulCount", SqlDbType.Int,4),
					new SqlParameter("@K_Comments_uselessCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Comments_floors", SqlDbType.Int,4),
                    new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.K_Comments_code;
            parameters[1].Value = model.K_Comments_type;
            parameters[2].Value = model.K_Comments_content;
            parameters[3].Value = model.K_Comments_score;
            parameters[4].Value = model.K_Comments_parent;
            parameters[5].Value = model.K_Comments_createTime;
            parameters[6].Value = model.K_Comments_creator;
            parameters[7].Value = model.K_Comments_isDelete;
            parameters[8].Value = model.K_Comments_helpfulCount;
            parameters[9].Value = model.K_Comments_uselessCount;
            parameters[10].Value = model.K_Comments_floors;
            parameters[11].Value = model.P_FK_code;

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
        public bool Update(CommonService.Model.KMS.K_Comments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Comments set ");
            strSql.Append("K_Comments_code=@K_Comments_code,");
            strSql.Append("K_Comments_type=@K_Comments_type,");
            strSql.Append("K_Comments_content=@K_Comments_content,");
            strSql.Append("K_Comments_score=@K_Comments_score,");
            strSql.Append("K_Comments_parent=@K_Comments_parent,");
            strSql.Append("K_Comments_createTime=@K_Comments_createTime,");
            strSql.Append("K_Comments_creator=@K_Comments_creator,");
            strSql.Append("K_Comments_isDelete=@K_Comments_isDelete,");
            strSql.Append("K_Comments_helpfulCount=@K_Comments_helpfulCount,");
            strSql.Append("K_Comments_uselessCount=@K_Comments_uselessCount,");
            strSql.Append("K_Comments_floors=@K_Comments_floors,");
            strSql.Append("P_FK_code=@P_FK_code");
            strSql.Append(" where K_Comments_id=@K_Comments_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Comments_type", SqlDbType.Int,4),
					new SqlParameter("@K_Comments_content", SqlDbType.Text),
					new SqlParameter("@K_Comments_score", SqlDbType.Int,4),
					new SqlParameter("@K_Comments_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Comments_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Comments_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Comments_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Comments_helpfulCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Comments_uselessCount", SqlDbType.Int,4),
					new SqlParameter("@K_Comments_floors", SqlDbType.Int,4),
					new SqlParameter("@K_Comments_id", SqlDbType.Int,4),
                    new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16) };
            parameters[0].Value = model.K_Comments_code;
            parameters[1].Value = model.K_Comments_type;
            parameters[2].Value = model.K_Comments_content;
            parameters[3].Value = model.K_Comments_score;
            parameters[4].Value = model.K_Comments_parent;
            parameters[5].Value = model.K_Comments_createTime;
            parameters[6].Value = model.K_Comments_creator;
            parameters[7].Value = model.K_Comments_isDelete;
            parameters[8].Value = model.K_Comments_helpfulCount;
            parameters[9].Value = model.K_Comments_uselessCount;
            parameters[10].Value = model.K_Comments_floors;
            parameters[11].Value = model.K_Comments_id;
            parameters[12].Value = model.P_FK_code;

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
        /// 根据关联Guid删除数据
        /// </summary>
        public bool DeleteByFkCode(Guid P_FK_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Comments set K_Comments_isDelete=1 ");
            strSql.Append(" where P_FK_code=@P_FK_code");
            SqlParameter[] parameters = {
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_FK_code;

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
        public bool Delete(Guid K_Comments_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Comments set K_Comments_isDelete=1 ");
            strSql.Append(" where K_Comments_code=@K_Comments_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Comments_code;

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
        /// 删除子集评论
        /// </summary>
        public bool DeleteChild(Guid K_Comments_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Comments set K_Comments_isDelete=1 ");
            strSql.Append(" where K_Comments_parent=@K_Comments_parent");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Comments_code;

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
        public bool DeleteList(string K_Comments_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Comments set K_Comments_isDelete=1 ");
            strSql.Append(" where K_Comments_code in (" + K_Comments_idlist + ")  ");
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
        public CommonService.Model.KMS.K_Comments GetModel(int K_Comments_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Comments_id,K_Comments_code,K_Comments_type,K_Comments_content,K_Comments_score,K_Comments_parent,K_Comments_createTime,K_Comments_creator,K_Comments_isDelete,K_Comments_helpfulCount,K_Comments_uselessCount,K_Comments_floors,P_FK_code from K_Comments ");
            strSql.Append(" where K_Comments_id=@K_Comments_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Comments_id;

            CommonService.Model.KMS.K_Comments model = new CommonService.Model.KMS.K_Comments();
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
        public CommonService.Model.KMS.K_Comments GetModel(Guid K_Comments_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Comments_id,K_Comments_code,K_Comments_type,K_Comments_content,K_Comments_score,K_Comments_parent,K_Comments_createTime,K_Comments_creator,K_Comments_isDelete,K_Comments_helpfulCount,K_Comments_uselessCount,K_Comments_floors,P_FK_code from K_Comments ");
            strSql.Append(" where K_Comments_isDelete=0 ");
            strSql.Append(" and K_Comments_code=@K_Comments_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Comments_code;

            CommonService.Model.KMS.K_Comments model = new CommonService.Model.KMS.K_Comments();
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
        /// 根据资源(问题)id，获取评论最高楼层数
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public int GetFloors(Guid P_FK_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top(1)K_Comments_floors from K_Comments ");
            strSql.Append(" where P_FK_code=@P_FK_code and K_Comments_isDelete=0 ");
            strSql.Append(" order by K_Comments_floors desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_FK_code;

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
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Comments DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Comments model = new CommonService.Model.KMS.K_Comments();
            if (row != null)
            {
                if (row.Table.Columns.Contains("K_Comments_id"))
                {
                    if (row["K_Comments_id"] != null && row["K_Comments_id"].ToString() != "")
                    {
                        model.K_Comments_id = int.Parse(row["K_Comments_id"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_code"))
                {
                    if (row["K_Comments_code"] != null && row["K_Comments_code"].ToString() != "")
                    {
                        model.K_Comments_code = new Guid(row["K_Comments_code"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_type"))
                {
                    if (row["K_Comments_type"] != null && row["K_Comments_type"].ToString() != "")
                    {
                        model.K_Comments_type = int.Parse(row["K_Comments_type"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_typeName"))
                {
                    if (row["K_Comments_typeName"] != null && row["K_Comments_typeName"].ToString() != "")
                    {
                        model.K_Comments_typeName = row["K_Comments_typeName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_content"))
                {
                    if (row["K_Comments_content"] != null)
                    {
                        model.K_Comments_content = row["K_Comments_content"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_score"))
                {
                    if (row["K_Comments_score"] != null && row["K_Comments_score"].ToString() != "")
                    {
                        model.K_Comments_score = int.Parse(row["K_Comments_score"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_parent"))
                {
                    if (row["K_Comments_parent"] != null && row["K_Comments_parent"].ToString() != "")
                    {
                        model.K_Comments_parent = new Guid(row["K_Comments_parent"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_parentName"))
                {
                    if (row["K_Comments_parentName"] != null && row["K_Comments_parentName"].ToString() != "")
                    {
                        model.K_Comments_parentName = row["K_Comments_parentName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_parentTime"))
                {
                    if (row["K_Comments_parentTime"] != null && row["K_Comments_parentTime"].ToString() != "")
                    {
                        model.K_Comments_parentTime = DateTime.Parse(row["K_Comments_parentTime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_createTime"))
                {
                    if (row["K_Comments_createTime"] != null && row["K_Comments_createTime"].ToString() != "")
                    {
                        model.K_Comments_createTime = DateTime.Parse(row["K_Comments_createTime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_creator"))
                {
                    if (row["K_Comments_creator"] != null && row["K_Comments_creator"].ToString() != "")
                    {
                        model.K_Comments_creator = new Guid(row["K_Comments_creator"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_isDelete"))
                {
                    if (row["K_Comments_isDelete"] != null && row["K_Comments_isDelete"].ToString() != "")
                    {
                        if ((row["K_Comments_isDelete"].ToString() == "1") || (row["K_Comments_isDelete"].ToString().ToLower() == "true"))
                        {
                            model.K_Comments_isDelete = true;
                        }
                        else
                        {
                            model.K_Comments_isDelete = false;
                        }
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_helpfulCount"))
                {
                    if (row["K_Comments_helpfulCount"] != null && row["K_Comments_helpfulCount"].ToString() != "")
                    {
                        if ((row["K_Comments_helpfulCount"].ToString() == "1") || (row["K_Comments_helpfulCount"].ToString().ToLower() == "true"))
                        {
                            model.K_Comments_helpfulCount = true;
                        }
                        else
                        {
                            model.K_Comments_helpfulCount = false;
                        }
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_uselessCount"))
                {
                    if (row["K_Comments_uselessCount"] != null && row["K_Comments_uselessCount"].ToString() != "")
                    {
                        model.K_Comments_uselessCount = int.Parse(row["K_Comments_uselessCount"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_floors"))
                {
                    if (row["K_Comments_floors"] != null && row["K_Comments_floors"].ToString() != "")
                    {
                        model.K_Comments_floors = int.Parse(row["K_Comments_floors"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_parentFloors"))
                {
                    if (row["K_Comments_parentFloors"] != null && row["K_Comments_parentFloors"].ToString() != "")
                    {
                        model.K_Comments_parentFloors = int.Parse(row["K_Comments_parentFloors"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("P_FK_code"))
                {
                    if (row["P_FK_code"] != null && row["P_FK_code"].ToString() != "")
                    {
                        model.P_FK_code = new Guid(row["P_FK_code"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("C_Userinfo_name"))
                {
                    if (row["C_Userinfo_name"] != null && row["C_Userinfo_name"].ToString() != "")
                    {
                        model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Userinfo_parentname"))
                {
                    if (row["C_Userinfo_parentname"] != null && row["C_Userinfo_parentname"].ToString() != "")
                    {
                        model.C_Userinfo_parentname = row["C_Userinfo_parentname"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Comments_adoptCount"))
                {
                    if (row["K_Comments_adoptCount"] != null && row["K_Comments_adoptCount"].ToString() != "")
                    {
                        model.K_Comments_adoptCount = Convert.ToInt32(row["K_Comments_adoptCount"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("P_FK_name"))
                {
                    if (row["P_FK_name"] != null && row["P_FK_name"].ToString() != "")
                    {
                        model.P_FK_name = row["P_FK_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_url"))
                {
                    if (row["K_Resources_url"] != null && row["K_Resources_url"].ToString() != "")
                    {
                        model.K_Resources_url = row["K_Resources_url"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_type"))
                {
                    if (row["K_Resources_type"] != null && row["K_Resources_type"].ToString() != "")
                    {
                        model.K_Resources_type = Convert.ToInt32(row["K_Resources_type"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("C_Messages_id"))
                {
                    if (row["C_Messages_id"] != null && row["C_Messages_id"].ToString() != "")
                    {
                        model.C_Messages_id = Convert.ToInt32(row["C_Messages_id"].ToString());
                    }
                }
            }
            return model;
        }
        /// <summary>
        /// 获得子集数据列表
        /// </summary>
        public DataSet GetListByParent(Guid K_Comments_parent)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Comments_id,K_Comments_code,K_Comments_type,K_Comments_content,K_Comments_score,K_Comments_parent,K_Comments_createTime,K_Comments_creator,K_Comments_isDelete,K_Comments_helpfulCount,K_Comments_uselessCount,K_Comments_floors,P_FK_code ");
            strSql.Append(" FROM K_Comments ");
            strSql.Append(" where K_Comments_parent=@K_Comments_parent ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_parent", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = K_Comments_parent;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByHelpfulCount(int K_Comments_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 5 (select C_Userinfo_name from C_Userinfo where C_Userinfo_code=K_Comments_creator) as 'C_Userinfo_name',count(*) as 'K_Comments_adoptCount' from K_Comments ");
            strSql.Append(" where K_Comments_type=@K_Comments_type and K_Comments_helpfulCount = 1 ");
            strSql.Append(" group by K_Comments_creator order by K_Comments_adoptCount desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_type", SqlDbType.Int,4)
                                        };
            parameters[0].Value = K_Comments_type;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 用户未读评论列表
        /// </summary>
        /// <param name="K_Comments_creator">用户Guid</param>
        /// <param name="K_Comments_type">评论类型</param>
        /// <returns></returns>
        public DataSet GetUnreadList(Guid K_Comments_creator, int K_Comments_type)
        {
            StringBuilder strSql = new StringBuilder();
            string username = "";
            if (K_Comments_type == 875)
            {
                username = ",R.K_Resources_url,R.K_Resources_type ";
            }
            strSql.Append("select C.K_Comments_id,C.K_Comments_code,C.K_Comments_type,C.K_Comments_content,C.K_Comments_score,C.K_Comments_parent,C.K_Comments_createTime,C.K_Comments_creator,C.K_Comments_isDelete,C.K_Comments_helpfulCount,C.K_Comments_uselessCount,C.K_Comments_floors,C.P_FK_code,M.C_Messages_id" + username + " from K_Comments as C ");
            strSql.Append(" left join C_Messages as M on C.K_Comments_code=M.C_Messages_link ");
            if (K_Comments_type == 875)
            {//资源评论
                strSql.Append(" left join K_Resources as R on C.P_FK_code=R.K_Resources_code ");
            }
            strSql.Append(" where 1=1 ");
            //else
            //{//问吧回答
            //    strSql.Append(" left join K_Problem as P on C.P_FK_code=P.K_Problem_code ");
            //    strSql.Append(" where P.K_Problem_isDelete=0 ");
            //}
            strSql.Append(" and C.K_Comments_isDelete=0 ");
            strSql.Append(" and M.C_Messages_isRead=0 and C.K_Comments_type=@K_Comments_type ");
            strSql.Append(" and M.C_Messages_person=@C_Messages_person ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_type", SqlDbType.Int,4),
                    new SqlParameter("@C_Messages_person",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = K_Comments_type;
            parameters[1].Value = K_Comments_creator;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Comments_id,K_Comments_code,K_Comments_type,K_Comments_content,K_Comments_score,K_Comments_parent,K_Comments_createTime,K_Comments_creator,K_Comments_isDelete,K_Comments_helpfulCount,K_Comments_uselessCount,K_Comments_floors,P_FK_code ");
            strSql.Append(" FROM K_Comments ");
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
            strSql.Append(" K_Comments_id,K_Comments_code,K_Comments_type,K_Comments_content,K_Comments_score,K_Comments_parent,K_Comments_createTime,K_Comments_creator,K_Comments_isDelete,K_Comments_helpfulCount,K_Comments_uselessCount,K_Comments_floors,P_FK_code ");
            strSql.Append(" FROM K_Comments ");
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
        public int GetRecordCount(CommonService.Model.KMS.K_Comments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Comments C ");
            if (model.K_Comments_type == 875)
            {
                strSql.Append(" left join K_Resources as R on R.K_Resources_code=C.P_FK_code ");
                strSql.Append(" where 1=1 and C.K_Comments_isDelete=0 and R.K_Resources_isDelete=0 ");
            }
            else if (model.K_Comments_type == 876)
            {
                strSql.Append(" left join K_Problem as P on P.K_Problem_code=C.P_FK_code ");
                strSql.Append(" where 1=1 and C.K_Comments_isDelete=0 and P.K_Problem_isDelete=0 ");
            }
            else
            {
                strSql.Append(" where 1=1 and C.K_Comments_isDelete=0 ");
            }
            if (model != null)
            {
                if (model.K_Comments_content != null && model.K_Comments_content.ToString() != "")
                {
                    strSql.Append(" and cast(K_Comments_content as nvarchar) like N'%'+@K_Comments_content+'%' ");
                }
                if (model.K_Comments_creator != null && model.K_Comments_creator.ToString() != "")
                {
                    strSql.Append(" and K_Comments_creator=@K_Comments_creator");
                }
                if (model.K_Comments_type != null && model.K_Comments_type.ToString() != "")
                {
                    strSql.Append(" and K_Comments_type=@K_Comments_type");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_content", SqlDbType.NVarChar),
					new SqlParameter("@K_Comments_creator", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Comments_type",SqlDbType.Int,4)                  
                                        };
            parameters[0].Value = model.K_Comments_content;
            parameters[1].Value = model.K_Comments_creator;
            parameters[2].Value = model.K_Comments_type;
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
        public DataSet GetListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.K_Comments_id desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name as 'K_Comments_typeName',U.C_Userinfo_name as 'C_Userinfo_name',C.K_Comments_content as 'K_Comments_parentName'  from K_Comments T ");
            strSql.Append(" left join C_Parameters as P on T.K_Comments_type=P.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U on T.K_Comments_creator=U.C_Userinfo_code ");
            strSql.Append(" left join K_Comments as C on T.K_Comments_parent=C.K_Comments_code ");
            strSql.Append(" where 1=1 and T.K_Comments_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Comments_content != null && model.K_Comments_content.ToString() != "")
                {
                    strSql.Append(" and cast(T.K_Comments_content as nvarchar) like N'%'+@K_Comments_content+'%' ");
                }
                if (model.K_Comments_creator != null && model.K_Comments_creator.ToString() != "")
                {
                    strSql.Append(" and T.K_Comments_creator=@K_Comments_creator");
                }
                if (model.K_Comments_type != null && model.K_Comments_type.ToString() != "")
                {
                    strSql.Append(" and T.K_Comments_type=@K_Comments_type");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_content", SqlDbType.NVarChar),
					new SqlParameter("@K_Comments_creator", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Comments_type",SqlDbType.Int,4)                    
                                        };
            parameters[0].Value = model.K_Comments_content;
            parameters[1].Value = model.K_Comments_creator;
            parameters[2].Value = model.K_Comments_type;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 分页获取资源评论列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetResourcesCommentListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.K_Comments_id desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name as 'K_Comments_typeName',U.C_Userinfo_name as 'C_Userinfo_name',R.K_Resources_name as 'K_Comments_parentName',R.K_Resources_url as 'K_Resources_url',R.K_Resources_type as 'K_Resources_type'  from K_Comments T ");
            strSql.Append(" left join C_Parameters as P on T.K_Comments_type=P.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U on T.K_Comments_creator=U.C_Userinfo_code ");
            strSql.Append(" left join K_Comments as C on T.K_Comments_parent=C.K_Comments_code ");
            strSql.Append(" left join K_Resources as R on T.P_FK_code = R.K_Resources_code ");
            strSql.Append(" where 1=1 and T.K_Comments_isDelete=0 and R.K_Resources_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Comments_content != null && model.K_Comments_content.ToString() != "")
                {
                    strSql.Append(" and cast(T.K_Comments_content as nvarchar) like N'%'+@K_Comments_content+'%' ");
                }
                if (model.K_Comments_creator != null && model.K_Comments_creator.ToString() != "")
                {
                    strSql.Append(" and T.K_Comments_creator=@K_Comments_creator");
                }
                if (model.K_Comments_type != null && model.K_Comments_type.ToString() != "")
                {
                    strSql.Append(" and T.K_Comments_type=@K_Comments_type");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_content", SqlDbType.NVarChar),
					new SqlParameter("@K_Comments_creator", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Comments_type",SqlDbType.Int,4)                    
                                        };
            parameters[0].Value = model.K_Comments_content;
            parameters[1].Value = model.K_Comments_creator;
            parameters[2].Value = model.K_Comments_type;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 分页获取问答回答列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetProblemCommentListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.K_Comments_id desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name as 'K_Comments_typeName',U.C_Userinfo_name as 'C_Userinfo_name',KP.K_Problem_content as 'K_Comments_parentName'  from K_Comments T ");
            strSql.Append(" left join C_Parameters as P on T.K_Comments_type=P.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U on T.K_Comments_creator=U.C_Userinfo_code ");
            strSql.Append(" left join K_Comments as C on T.K_Comments_parent=C.K_Comments_code ");
            strSql.Append(" left join K_Problem as KP on T.P_FK_code = KP.K_Problem_code ");
            strSql.Append(" where 1=1 and T.K_Comments_isDelete=0 and KP.K_Problem_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Comments_content != null && model.K_Comments_content.ToString() != "")
                {
                    strSql.Append(" and cast(T.K_Comments_content as nvarchar) like N'%'+@K_Comments_content+'%' ");
                }
                if (model.K_Comments_creator != null && model.K_Comments_creator.ToString() != "")
                {
                    strSql.Append(" and T.K_Comments_creator=@K_Comments_creator");
                }
                if (model.K_Comments_type != null && model.K_Comments_type.ToString() != "")
                {
                    strSql.Append(" and T.K_Comments_type=@K_Comments_type");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Comments_content", SqlDbType.NVarChar),
					new SqlParameter("@K_Comments_creator", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Comments_type",SqlDbType.Int,4)                    
                                        };
            parameters[0].Value = model.K_Comments_content;
            parameters[1].Value = model.K_Comments_creator;
            parameters[2].Value = model.K_Comments_type;
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
            parameters[0].Value = "K_Comments";
            parameters[1].Value = "K_Comments_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        /// <summary>
        /// 根据外键guid获得评论列表
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public DataSet GetCommentsListByCode(Guid P_FK_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" *,b.C_Userinfo_name,dbo.getCommentsName(a.K_Comments_parent) as C_Userinfo_parentname,C.K_Comments_content as K_Comments_parentName,C.K_Comments_createTime as K_Comments_parentTime,C.K_Comments_floors as K_Comments_parentFloors ");
            strSql.Append(" FROM K_Comments as a left join C_Userinfo as b on a.K_Comments_creator=b.C_Userinfo_code ");
            strSql.Append(" left join K_Comments as C on a.K_Comments_parent=C.K_Comments_code ");
            strSql.Append(" where a.P_FK_code='" + P_FK_code + "'");
            strSql.Append(" and a.K_Comments_isDelete=0 ");
            strSql.Append(" order by a.K_Comments_createTime asc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

