using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:资源表
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Resources
    {
        public K_Resources()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("K_Resources_id", "K_Resources");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Resources_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Resources");
            strSql.Append(" where K_Resources_id=@K_Resources_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Resources_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Resources model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Resources(");
            strSql.Append("K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions)");
            strSql.Append(" values (");
            strSql.Append("@K_Resources_code,@K_Resources_name,@K_Resources_url,@K_Resources_type,@K_Resources_Extension,@K_Resources_description,@K_Resources_createTime,@K_Resources_creator,@K_Resources_isDelete,@K_Resources_state,@K_Resources_author,@K_Resources_zambiaCount,@K_Resources_collectionCount,@K_Resources_browseCount,@K_Resources_downloadCount,@K_Resources_coverImage,@K_Resources_nouserCount,@K_Resources_Permissions)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Resources_url", SqlDbType.NVarChar,500),
					new SqlParameter("@K_Resources_type", SqlDbType.Int,4),
					new SqlParameter("@K_Resources_Extension", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Resources_description", SqlDbType.Text),
					new SqlParameter("@K_Resources_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Resources_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_state", SqlDbType.Int,4),
					new SqlParameter("@K_Resources_author", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Resources_zambiaCount", SqlDbType.Int,4),
					new SqlParameter("@K_Resources_collectionCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_browseCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_downloadCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_coverImage",SqlDbType.NVarChar,100),
                    new SqlParameter("@K_Resources_nouserCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_Permissions", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.K_Resources_code;
            parameters[1].Value = model.K_Resources_name;
            parameters[2].Value = model.K_Resources_url;
            parameters[3].Value = model.K_Resources_type;
            parameters[4].Value = model.K_Resources_Extension;
            parameters[5].Value = model.K_Resources_description;
            parameters[6].Value = model.K_Resources_createTime;
            parameters[7].Value = model.K_Resources_creator;
            parameters[8].Value = model.K_Resources_isDelete;
            parameters[9].Value = model.K_Resources_state;
            parameters[10].Value = model.K_Resources_author;
            parameters[11].Value = model.K_Resources_zambiaCount;
            parameters[12].Value = model.K_Resources_collectionCount;
            parameters[13].Value = model.K_Resources_browseCount;
            parameters[14].Value = model.K_Resources_downloadCount;
            parameters[15].Value = model.K_Resources_coverImage;
            parameters[16].Value = model.K_Resources_nouserCount;
            parameters[17].Value = model.K_Resources_Permissions;

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
        public bool Update(CommonService.Model.KMS.K_Resources model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Resources set ");
            strSql.Append("K_Resources_code=@K_Resources_code,");
            strSql.Append("K_Resources_name=@K_Resources_name,");
            strSql.Append("K_Resources_url=@K_Resources_url,");
            strSql.Append("K_Resources_type=@K_Resources_type,");
            strSql.Append("K_Resources_Extension=@K_Resources_Extension,");
            strSql.Append("K_Resources_description=@K_Resources_description,");
            strSql.Append("K_Resources_createTime=@K_Resources_createTime,");
            strSql.Append("K_Resources_creator=@K_Resources_creator,");
            strSql.Append("K_Resources_isDelete=@K_Resources_isDelete,");
            strSql.Append("K_Resources_state=@K_Resources_state,");
            strSql.Append("K_Resources_author=@K_Resources_author,");
            strSql.Append("K_Resources_zambiaCount=@K_Resources_zambiaCount,");
            strSql.Append("K_Resources_collectionCount=@K_Resources_collectionCount,");
            strSql.Append("K_Resources_browseCount=@K_Resources_browseCount,");
            strSql.Append("K_Resources_downloadCount=@K_Resources_downloadCount,");
            strSql.Append("K_Resources_coverImage=@K_Resources_coverImage,");
            strSql.Append("K_Resources_nouserCount=@K_Resources_nouserCount, ");
            strSql.Append("K_Resources_Permissions=@K_Resources_Permissions ");
            strSql.Append(" where K_Resources_id=@K_Resources_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Resources_url", SqlDbType.NVarChar,500),
					new SqlParameter("@K_Resources_type", SqlDbType.Int,4),
					new SqlParameter("@K_Resources_Extension", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Resources_description", SqlDbType.Text),
					new SqlParameter("@K_Resources_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Resources_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_state", SqlDbType.Int,4),
					new SqlParameter("@K_Resources_author", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Resources_zambiaCount", SqlDbType.Int,4),
					new SqlParameter("@K_Resources_collectionCount", SqlDbType.Int,4),
					new SqlParameter("@K_Resources_id", SqlDbType.Int,4),
               		new SqlParameter("@K_Resources_browseCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_downloadCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_coverImage",SqlDbType.NVarChar,100),
                    new SqlParameter("@K_Resources_nouserCount", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_Permissions",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.K_Resources_code;
            parameters[1].Value = model.K_Resources_name;
            parameters[2].Value = model.K_Resources_url;
            parameters[3].Value = model.K_Resources_type;
            parameters[4].Value = model.K_Resources_Extension;
            parameters[5].Value = model.K_Resources_description;
            parameters[6].Value = model.K_Resources_createTime;
            parameters[7].Value = model.K_Resources_creator;
            parameters[8].Value = model.K_Resources_isDelete;
            parameters[9].Value = model.K_Resources_state;
            parameters[10].Value = model.K_Resources_author;
            parameters[11].Value = model.K_Resources_zambiaCount;
            parameters[12].Value = model.K_Resources_collectionCount;
            parameters[13].Value = model.K_Resources_id;
            parameters[14].Value = model.K_Resources_browseCount;
            parameters[15].Value = model.K_Resources_downloadCount;
            parameters[16].Value = model.K_Resources_coverImage;
            parameters[17].Value = model.K_Resources_nouserCount;
            parameters[18].Value = model.K_Resources_Permissions;

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
        public bool Delete(Guid K_Resources_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Resources set K_Resources_isDelete=1 ");
            strSql.Append(" where K_Resources_code=@K_Resources_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Resources_code;

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
        public bool DeleteList(string K_Resources_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Resources set K_Resources_isDelete=1 ");
            strSql.Append(" where K_Resources_code in (" + K_Resources_idlist + ") ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@K_Resources_code", SqlDbType.NVarChar)
            //};
            //parameters[0].Value = K_Resources_idlist;
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
        /// 资源审核
        /// </summary>
        /// <param name="resourcesCode">资源Guid(以逗号隔开，多个处理)</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public bool ResourcesAudit(string resourcesCode, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Resources set ");
            strSql.Append("K_Resources_state=" + state + " ");
            strSql.Append(" where K_Resources_code in (" + resourcesCode + ")");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@K_Resources_code", SqlDbType.NVarChar),
            //        new SqlParameter("@K_Resources_state", SqlDbType.Int,4)
            //                            };
            //parameters[0].Value = resourcesCode;
            //parameters[1].Value = state;

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
        /// 资源下载权限
        /// </summary>
        /// <param name="resourcesCode">资源Guid(以逗号隔开，多个处理)</param>
        /// <returns></returns>
        public bool ResourcesPermissions(string resourcesCode, int permissions)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Resources set ");
            strSql.Append("K_Resources_Permissions=" + permissions + " ");
            strSql.Append(" where K_Resources_code in (" + resourcesCode + ")");

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
        public CommonService.Model.KMS.K_Resources GetModel(int K_Resources_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions,dbo.getKeywordlist(K_Resources_code) as K_Resources_Keyword,U.C_Userinfo_name as K_Resources_creatorName from K_Resources ");
            strSql.Append(" left join C_Userinfo as U on K_Resources_creator=U.C_Userinfo_code ");
            strSql.Append(" where K_Resources_id=@K_Resources_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Resources_id;

            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
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
        /// 根据Url得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Resources GetModelByUrl(string K_Resources_url)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions,dbo.getKeywordlist(K_Resources_code) as K_Resources_Keyword,U.C_Userinfo_name as K_Resources_creatorName,K.K_Knowledge_name as 'K_Resources_Knowledge_name' from K_Resources ");
            strSql.Append(" left join C_Userinfo as U on K_Resources_creator=U.C_Userinfo_code ");
            strSql.Append(" left join K_Knowledge_Resources as KK on KK.P_FK_code = K_Resources_code ");
            strSql.Append(" left join K_Knowledge as K on K.K_Knowledge_code = KK.K_Knowledge_code ");
            strSql.Append(" where K_Resources_isDelete=0 ");
            strSql.Append(" and K_Resources_url=@K_Resources_url ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_url", SqlDbType.NVarChar)
			};
            parameters[0].Value = K_Resources_url;

            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
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
        public CommonService.Model.KMS.K_Resources GetModel(Guid K_Resources_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions,U.C_Userinfo_name as K_Resources_creatorName,K.K_Knowledge_name as 'K_Resources_Knowledge_name',K.K_Knowledge_code as 'K_Resources_Knowledge_code'  from K_Resources ");
            strSql.Append(" left join C_Userinfo as U on K_Resources_creator=U.C_Userinfo_code ");
            strSql.Append(" left join K_Knowledge_Resources as KK on KK.P_FK_code = K_Resources_code ");
            strSql.Append(" left join K_Knowledge as K on K.K_Knowledge_code = KK.K_Knowledge_code ");
            strSql.Append(" where 1=1 ");
            strSql.Append(" and K_Resources_code=@K_Resources_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Resources_code;

            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
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
        public CommonService.Model.KMS.K_Resources DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
            if (row != null)
            {
                if (row["K_Resources_id"] != null && row["K_Resources_id"].ToString() != "")
                {
                    model.K_Resources_id = int.Parse(row["K_Resources_id"].ToString());
                }
                if (row["K_Resources_code"] != null && row["K_Resources_code"].ToString() != "")
                {
                    model.K_Resources_code = new Guid(row["K_Resources_code"].ToString());
                }
                if (row["K_Resources_name"] != null)
                {
                    model.K_Resources_name = row["K_Resources_name"].ToString();
                }
                if (row["K_Resources_url"] != null)
                {
                    model.K_Resources_url = row["K_Resources_url"].ToString();
                }
                if (row["K_Resources_type"] != null && row["K_Resources_type"].ToString() != "")
                {
                    model.K_Resources_type = int.Parse(row["K_Resources_type"].ToString());
                }
                if (row.Table.Columns.Contains("K_Resources_typeName"))
                {
                    if (row["K_Resources_typeName"] != null && row["K_Resources_typeName"].ToString() != "")
                    {
                        model.K_Resources_typeName = row["K_Resources_typeName"].ToString();
                    }
                }
                if (row["K_Resources_Extension"] != null)
                {
                    model.K_Resources_Extension = row["K_Resources_Extension"].ToString();
                }
                if (row["K_Resources_description"] != null)
                {
                    model.K_Resources_description = row["K_Resources_description"].ToString();
                }
                if (row["K_Resources_createTime"] != null && row["K_Resources_createTime"].ToString() != "")
                {
                    model.K_Resources_createTime = DateTime.Parse(row["K_Resources_createTime"].ToString());
                }
                if (row["K_Resources_creator"] != null && row["K_Resources_creator"].ToString() != "")
                {
                    model.K_Resources_creator = new Guid(row["K_Resources_creator"].ToString());
                }
                if (row.Table.Columns.Contains("K_Resources_creatorName"))
                {
                    if (row["K_Resources_creatorName"] != null && row["K_Resources_creatorName"].ToString() != "")
                    {
                        model.K_Resources_creatorName = row["K_Resources_creatorName"].ToString();
                    }
                }
                if (row["K_Resources_isDelete"] != null && row["K_Resources_isDelete"].ToString() != "")
                {
                    if ((row["K_Resources_isDelete"].ToString() == "1") || (row["K_Resources_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.K_Resources_isDelete = true;
                    }
                    else
                    {
                        model.K_Resources_isDelete = false;
                    }
                }
                if (row["K_Resources_state"] != null && row["K_Resources_state"].ToString() != "")
                {
                    model.K_Resources_state = int.Parse(row["K_Resources_state"].ToString());
                }
                if (row["K_Resources_author"] != null)
                {
                    model.K_Resources_author = row["K_Resources_author"].ToString();
                }
                if (row["K_Resources_zambiaCount"] != null && row["K_Resources_zambiaCount"].ToString() != "")
                {
                    model.K_Resources_zambiaCount = int.Parse(row["K_Resources_zambiaCount"].ToString());
                }
                if (row["K_Resources_collectionCount"] != null && row["K_Resources_collectionCount"].ToString() != "")
                {
                    model.K_Resources_collectionCount = int.Parse(row["K_Resources_collectionCount"].ToString());
                }
                if (row["K_Resources_browseCount"] != null && row["K_Resources_browseCount"].ToString() != "")
                {
                    model.K_Resources_browseCount = int.Parse(row["K_Resources_browseCount"].ToString());
                }
                if (row.Table.Columns.Contains("K_Resources_stateName"))
                {
                    if (row["K_Resources_stateName"] != null && row["K_Resources_stateName"].ToString() != "")
                    {
                        model.K_Resources_stateName = row["K_Resources_stateName"].ToString();
                    }
                }
                if (row["K_Resources_downloadCount"] != null && row["K_Resources_downloadCount"].ToString() != "")
                {
                    model.K_Resources_downloadCount = int.Parse(row["K_Resources_downloadCount"].ToString());
                }
                if (row["K_Resources_coverImage"] != null && row["K_Resources_coverImage"].ToString() != "")
                {
                    model.K_Resources_coverImage = row["K_Resources_coverImage"].ToString();
                }
                if (row.Table.Columns.Contains("K_Resources_Knowledge_code"))
                {
                    if (row["K_Resources_Knowledge_code"] != null && row["K_Resources_Knowledge_code"].ToString() != "")
                    {
                        model.K_Resources_Knowledge_code = row["K_Resources_Knowledge_code"].ToString();
                    }
                }
                if (row["K_Resources_nouserCount"] != null && row["K_Resources_nouserCount"].ToString() != "")
                {
                    model.K_Resources_nouserCount = int.Parse(row["K_Resources_nouserCount"].ToString());
                }
                if (row.Table.Columns.Contains("K_Resources_Keyword"))
                {
                    if (row["K_Resources_Keyword"] != null && row["K_Resources_Keyword"].ToString() != "")
                    {
                        model.K_Resources_Keyword = row["K_Resources_Keyword"].ToString();
                    }
                }
                if (row["K_Resources_Permissions"] != null && row["K_Resources_Permissions"].ToString() != "")
                {
                    if ((row["K_Resources_Permissions"].ToString() == "1") || (row["K_Resources_Permissions"].ToString().ToLower() == "true"))
                    {
                        model.K_Resources_Permissions = true;
                    }
                    else
                    {
                        model.K_Resources_Permissions = false;
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_Knowledge_name"))
                {
                    if (row["K_Resources_Knowledge_name"] != null && row["K_Resources_Knowledge_name"].ToString() != "")
                    {
                        model.K_Resources_Knowledge_name = row["K_Resources_Knowledge_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_Knowledge_person"))
                {
                    if (row["K_Resources_Knowledge_person"] != null && row["K_Resources_Knowledge_person"].ToString() != "")
                    {
                        model.K_Resources_Knowledge_person = new Guid(row["K_Resources_Knowledge_person"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Browse_LogCount"))
                {
                    if (row["K_Browse_LogCount"] != null && row["K_Browse_LogCount"].ToString() != "")
                    {
                        model.K_Browse_LogCount = Convert.ToInt32(row["K_Browse_LogCount"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("P_Flow_name"))
                {
                    if (row["P_Flow_name"] != null && row["P_Flow_name"].ToString() != "")
                    {
                        model.P_Flow_name = row["P_Flow_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("F_Form_chineseName"))
                {
                    if (row["F_Form_chineseName"] != null && row["F_Form_chineseName"].ToString() != "")
                    {
                        model.F_Form_chineseName = row["F_Form_chineseName"].ToString();
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获取最近上传的几条数据
        /// </summary>
        /// <param name="K_Resources_creator">用户Guid</param>
        /// <param name="pageSize">获取条数</param>
        /// <returns></returns>
        public DataSet GetListByRecentUpload(Guid K_Resources_creator, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (pageSize > 0)
            {
                strSql.Append(" top " + pageSize.ToString());
            }
            strSql.Append(" K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions ");
            strSql.Append(" FROM K_Resources where 1=1 and K_Resources_isDelete=0 ");
            strSql.Append(" and K_Resources_creator=@K_Resources_creator ");
            strSql.Append(" order by K_Resources_createTime desc ");
            SqlParameter[] parameters = {
                    new SqlParameter("@K_Resources_creator",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = K_Resources_creator;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions ");
            strSql.Append(" FROM K_Resources ");
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
            strSql.Append(" K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions ");
            strSql.Append(" FROM K_Resources ");
            strSql.Append(" where K_Resources_isDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(CommonService.Model.KMS.K_Resources model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Resources as T ");
            strSql.Append(" left join K_Knowledge_Resources as KR on T.K_Resources_code=KR.P_FK_code ");
            strSql.Append(" left join K_Knowledge as K on KR.K_Knowledge_code=K.K_Knowledge_code ");
            strSql.Append(" where 1=1 and K_Resources_isDelete=0 and KR.K_Knowledge_Resources_isDelete=0 and K.K_Knowledge_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and K_Resources_name like N'%'+@K_Resources_name+'%' ");
                }
                if (model.K_Resources_type == 1)
                {//获取文档：资源类型为word、pdf、excel、ppt
                    strSql.Append(" and K_Resources_type not in (825,827,829)");
                }
                else if (model.K_Resources_type != null && model.K_Resources_type.ToString() != "")
                {
                    strSql.Append(" and K_Resources_type=@K_Resources_type ");
                }
                if (model.K_Resources_state != null && model.K_Resources_state.ToString() != "")
                {
                    strSql.Append(" and K_Resources_state=@K_Resources_state ");
                }
                if (model.K_Resources_creator != null && model.K_Resources_creator.ToString() != "")
                {
                    strSql.Append(" and K_Resources_creator=@K_Resources_creator ");
                }
                if (model.K_Resources_codeItems != null && model.K_Resources_codeItems.ToString() != "")
                {
                    strSql.Append(" and K_Resources_code in (" + model.K_Resources_codeItems + ")");
                }
                if (model.K_Resources_Knowledge_code != null && model.K_Resources_Knowledge_code.ToString() != "")
                {
                    strSql.Append(" and (KR.K_Knowledge_code=@K_Knowledge_code or K.K_Knowledge_parent=@K_Knowledge_code) ");
                    //strSql.Append(" and exists(select KR.K_Knowledge_code from K_Knowledge_Resources as KR where T.K_Resources_code=KR.P_FK_code and KR.K_Knowledge_code in (@K_Knowledge_code) and K_Resources_isDelete=0) ");
                }
                if (model.K_Resources_Knowledge_person != null && model.K_Resources_Knowledge_person.ToString() != "")
                {
                    //strSql.Append(" and K.K_Knowledge_Person=@K_Knowledge_Person ");
                    strSql.Append(@" and K.K_Knowledge_code in (select K_Knowledge_code from K_Knowledge as KZ 
where KZ.K_Knowledge_parent in ( select K_Knowledge_code from K_Knowledge as K where K.K_Knowledge_Person=@K_Knowledge_Person and K.K_Knowledge_isDelete=0 and K.K_Knowledge_parent is null)
or KZ.K_Knowledge_code in ( select K_Knowledge_code from K_Knowledge as K where K.K_Knowledge_Person=@K_Knowledge_Person and K.K_Knowledge_isDelete=0))
 ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_name", SqlDbType.NVarChar),
                    new SqlParameter("@K_Resources_type", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_state", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Knowledge_code",SqlDbType.NVarChar),
                    new SqlParameter("@K_Knowledge_Person",SqlDbType.UniqueIdentifier,16)
                    //new SqlParameter("@K_Resources_codeItems",SqlDbType.NVarChar),
                                        };
            parameters[0].Value = model.K_Resources_name;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_state;
            parameters[3].Value = model.K_Resources_creator;
            parameters[4].Value = model.K_Resources_Knowledge_code;
            parameters[5].Value = model.K_Resources_Knowledge_person;
            //parameters[5].Value = model.K_Resources_codeItems;
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
        public DataSet GetListByPage(CommonService.Model.KMS.K_Resources model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.K_Resources_id desc");
            }
            strSql.Append(")AS Row, T.*,dbo.getBrowseCountByUser(T.K_Resources_code) as 'K_Browse_LogCount',P.C_Parameters_name as 'K_Resources_stateName',U.C_Userinfo_name as 'K_Resources_creatorName',P1.C_Parameters_name as 'K_Resources_typeName',K.K_Knowledge_name as 'K_Resources_Knowledge_name',KR.P_FK_code as 'K_Resources_Knowledge_code'  from K_Resources T ");
            strSql.Append(" left join C_Parameters as P on T.K_Resources_state=P.C_Parameters_id ");
            strSql.Append(" left join C_Parameters as P1 on T.K_Resources_type=P1.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U on T.K_Resources_creator=U.C_Userinfo_code ");
            strSql.Append(" left join K_Knowledge_Resources as KR on T.K_Resources_code=KR.P_FK_code ");
            strSql.Append(" left join K_Knowledge as K on KR.K_Knowledge_code=K.K_Knowledge_code ");
            strSql.Append(" where 1=1 and T.K_Resources_isDelete=0 and KR.K_Knowledge_Resources_isDelete=0 and K.K_Knowledge_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and K_Resources_name like N'%'+@K_Resources_name+'%' ");
                }
                if (model.K_Resources_type == 1)
                {//获取文档：资源类型为word、pdf、excel、ppt
                    strSql.Append(" and K_Resources_type not in (825,827,829)");
                }
                else if (model.K_Resources_type != null && model.K_Resources_type.ToString() != "")
                {
                    strSql.Append(" and K_Resources_type=@K_Resources_type ");
                }
                if (model.K_Resources_state != null && model.K_Resources_state.ToString() != "")
                {
                    strSql.Append(" and K_Resources_state=@K_Resources_state ");
                }
                if (model.K_Resources_creator != null && model.K_Resources_creator.ToString() != "")
                {
                    strSql.Append(" and K_Resources_creator=@K_Resources_creator ");
                }
                if (model.K_Resources_codeItems != null && model.K_Resources_codeItems.ToString() != "")
                {
                    strSql.Append(" and ltrim(K_Resources_code) in (" + model.K_Resources_codeItems + ")");
                }
                if (model.K_Resources_Knowledge_code != null && model.K_Resources_Knowledge_code.ToString() != "")
                {
                    strSql.Append(" and (KR.K_Knowledge_code=@K_Knowledge_code or K.K_Knowledge_parent=@K_Knowledge_code) ");
                    //strSql.Append(" and exists(select KR.K_Knowledge_code from K_Knowledge_Resources as KR where T.K_Resources_code=KR.P_FK_code and KR.K_Knowledge_code in (@K_Knowledge_code) and K_Resources_isDelete=0) ");
                }
                if (model.K_Resources_Knowledge_person != null && model.K_Resources_Knowledge_person.ToString() != "")
                {
                    //strSql.Append(" and K.K_Knowledge_Person=@K_Knowledge_Person ");
                    strSql.Append(@" and K.K_Knowledge_code in (select K_Knowledge_code from K_Knowledge as KZ 
where KZ.K_Knowledge_parent in ( select K_Knowledge_code from K_Knowledge as K where K.K_Knowledge_Person=@K_Knowledge_Person and K.K_Knowledge_isDelete=0 and K.K_Knowledge_parent is null)
or KZ.K_Knowledge_code in ( select K_Knowledge_code from K_Knowledge as K where K.K_Knowledge_Person=@K_Knowledge_Person and K.K_Knowledge_isDelete=0))
 ");
                }
            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_name", SqlDbType.NVarChar),
                    new SqlParameter("@K_Resources_type", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_state", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Knowledge_code",SqlDbType.NVarChar),
                    new SqlParameter("@K_Knowledge_Person",SqlDbType.UniqueIdentifier,16)
                    //new SqlParameter("@K_Resources_codeItems",SqlDbType.NVarChar)
                                        };
            parameters[0].Value = model.K_Resources_name;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_state;
            parameters[3].Value = model.K_Resources_creator;
            parameters[4].Value = model.K_Resources_Knowledge_code;
            parameters[5].Value = model.K_Resources_Knowledge_person;
            //parameters[5].Value = model.K_Resources_codeItems;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 我的文档/视频数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int MyDocumentAndVideoListCount(Model.KMS.K_Resources model, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Resources ");
            strSql.Append(" where 1=1 and K_Resources_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and K_Resources_name like N'%'+@K_Resources_name+'%' ");
                }
                if (model.K_Resources_state != null && model.K_Resources_state.ToString() != "")
                {
                    strSql.Append(" and K_Resources_state=@K_Resources_state ");
                }
                if (model.K_Resources_creator != null && model.K_Resources_creator.ToString() != "")
                {
                    strSql.Append(" and K_Resources_creator=@K_Resources_creator ");
                }
            }
            if (type == 1)
            {//文档
                strSql.Append(" and K_Resources_type not in (827,829,825) ");
            }
            else if (type == 2)
            {//视频
                strSql.Append(" and K_Resources_type = 827 ");
            }
            else if (type == 3)
            {//文章
                strSql.Append(" and K_Resources_type = 829 ");
            }
            else if (type == 4)
            {
                strSql.Append(" and K_Resources_type = 825 ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_name", SqlDbType.NVarChar),
                    new SqlParameter("@K_Resources_type", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_state", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_creator",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.K_Resources_name;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_state;
            parameters[3].Value = model.K_Resources_creator;
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
        /// 我的文档/视频
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet MyDocumentAndVideoList(CommonService.Model.KMS.K_Resources model, string orderby, int startIndex, int endIndex, int type)
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
                strSql.Append("order by T.K_Resources_id desc");
            }
            strSql.Append(")AS Row, T.*,dbo.getBrowseCountByUser(T.K_Resources_code) as 'K_Browse_LogCount',P.C_Parameters_name as 'K_Resources_stateName'  from K_Resources T ");
            strSql.Append(" left join C_Parameters as P on T.K_Resources_state=P.C_Parameters_id ");
            strSql.Append(" where 1=1 and T.K_Resources_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and K_Resources_name like N'%'+@K_Resources_name+'%' ");
                }
                if (model.K_Resources_state != null && model.K_Resources_state.ToString() != "")
                {
                    strSql.Append(" and K_Resources_state=@K_Resources_state ");
                }
                if (model.K_Resources_creator != null && model.K_Resources_creator.ToString() != "")
                {
                    strSql.Append(" and K_Resources_creator=@K_Resources_creator ");
                }
            }
            if (type == 1)
            {
                strSql.Append(" and K_Resources_type not in (827,829,825) ");
            }
            else if (type == 2)
            {
                strSql.Append(" and K_Resources_type = 827 ");
            }
            else if (type == 3)
            {
                strSql.Append(" and K_Resources_type = 829 ");
            }
            else
            {

            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_name", SqlDbType.NVarChar),
                    new SqlParameter("@K_Resources_type", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_state", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_creator",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.K_Resources_name;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_state;
            parameters[3].Value = model.K_Resources_creator;
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
            parameters[0].Value = "K_Resources";
            parameters[1].Value = "K_Resources_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        /// <summary>
        /// 根据浏览次数资源类型获取前几条最热的数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="K_Knowledge_name">分类名称 如果分类名称前加putoff，则为去掉改分类项</param>
        /// <param name="K_Knowledge_Resources_type"></param>
        /// <returns></returns>
        public DataSet GetListByzambiaCount(int count, string K_Knowledge_name, int? K_Knowledge_Resources_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + count + "");
            strSql.Append(" K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(KR.K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions,K.K_Knowledge_code as 'K_Resources_Knowledge_code' ");
            strSql.Append(" FROM K_Resources as KR");
            strSql.Append(" left join K_Knowledge_Resources as KK on KR.K_Resources_code = KK.P_FK_code ");
            strSql.Append(" left join K_Knowledge as K on KK.K_Knowledge_code = K.K_Knowledge_code ");
            strSql.Append(" left join K_Knowledge as K2 on K2.K_Knowledge_code = K.K_Knowledge_parent ");
            strSql.Append(" where 1=1 and K_Resources_isDelete=0 and KK.K_Knowledge_Resources_isDelete=0 and K_Resources_state = 834 and K.K_Knowledge_isDelete=0 ");
            strSql.Append(" and KK.K_Knowledge_Resources_type=@K_Knowledge_Resources_type ");
            if (K_Knowledge_name != null && !K_Knowledge_name.Contains("putoff"))
            {
                strSql.Append(" and (K.K_Knowledge_name=@K_Knowledge_name or K2.K_Knowledge_name=@K_Knowledge_name) ");
                //strSql.Append(" and K.K_Knowledge_name=@K_Knowledge_name ");
            }
            else if (K_Knowledge_name.Contains("putoff"))
            {
                string[] name = K_Knowledge_name.Split('/');
                K_Knowledge_name = name[1].ToString();
                strSql.Append(" and (K.K_Knowledge_name!=@K_Knowledge_name and (K2.K_Knowledge_name!=@K_Knowledge_name or K2.K_Knowledge_name is null)) ");
            }
            strSql.Append(" order by dbo.getBrowseCountByUser(KR.K_Resources_code) desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_name", SqlDbType.NVarChar),
                    new SqlParameter("@K_Knowledge_Resources_type", SqlDbType.Int, 4),
					};
            parameters[0].Value = K_Knowledge_name;
            parameters[1].Value = K_Knowledge_Resources_type;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取当月记录总数
        /// </summary>
        public int GetRecordCountByMonth(CommonService.Model.KMS.K_Resources model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Resources ");
            strSql.Append(" where 1=1 and K_Resources_isDelete=0 and datediff(Month,K_Resources_createTime,getdate())=0");
            if (model != null)
            {
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and K_Resources_name=@K_Resources_name ");
                }
                if (model.K_Resources_type != null && model.K_Resources_type.ToString() != "")
                {
                    strSql.Append(" and K_Resources_type=@K_Resources_type ");
                }
                if (model.K_Resources_state != null && model.K_Resources_state.ToString() != "")
                {
                    strSql.Append(" and K_Resources_state=@K_Resources_state ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_name", SqlDbType.NVarChar),
                    new SqlParameter("@K_Resources_type", SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_state", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.K_Resources_name;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_state;
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
        /// 根据浏览量和资源类型获取前几条数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="K_Knowledge_code"></param>
        /// <param name="K_Knowledge_Resources_type"></param>
        /// <returns></returns>
        public DataSet GetListByBrowseCount(int count, Guid? K_Knowledge_code, int? K_Resources_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + count + "");
            strSql.Append(" K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions ");
            strSql.Append(" FROM K_Resources  where 1=1 and K_Resources_isDelete=0 and K_Resources_state = 834");
            if (K_Resources_type != null)
            {
                strSql.Append(" and K_Resources_type=@K_Resources_type");
            }
            else
            {
                strSql.Append(" and K_Resources_type!=829 ");
            }
            if (K_Knowledge_code != null)
            {
                strSql.Append(" and exists(select 1 from K_Knowledge_Resources as a where  a.P_FK_code=@K_Knowledge_code)");
            }
            strSql.Append(" order by dbo.getBrowseCountByUser(K_Resources_code) desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@K_Resources_type", SqlDbType.Int, 4)
					};
            parameters[0].Value = K_Knowledge_code;
            parameters[1].Value = K_Resources_type;
            return DbHelperSQL.Query(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public DataSet GetSearchList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions,dbo.getKeywordlist(K_Resources_code) as K_Resources_Keyword,e.P_Flow_name as P_Flow_name,e.F_Form_chineseName as F_Form_chineseName");
            strSql.Append(" FROM K_Resources as a ");
            strSql.Append(" left join (select b.C_FK_code as C_FK_code,c.P_Flow_name as P_Flow_name,d.F_Form_chineseName as F_Form_chineseName from K_PorblemAndResources_LinkCase as b ");
            strSql.Append(" left join P_Flow as c on b.K_ProblemAndResources_LinkCase_BusinessFlowcode=c.P_Flow_code");
            strSql.Append(" left join F_Form as d on b.K_ProblemAndResources_LinkCase_Formcode=d.F_Form_code) as e on a.K_Resources_code=e.C_FK_code");
            strSql.Append(" where K_Resources_isDelete=0 and K_Resources_state = 834");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据资源code集合获得资源集合
        /// </summary>
        /// <param name="codeList"></param>
        /// <returns></returns>
        public DataSet GetListByCodeList(string codeList, string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Resources_id,K_Resources_code,K_Resources_name,K_Resources_url,K_Resources_type,K_Resources_Extension,K_Resources_description,K_Resources_createTime,K_Resources_creator,K_Resources_isDelete,K_Resources_state,K_Resources_author,K_Resources_zambiaCount,K_Resources_collectionCount,K_Resources_browseCount,dbo.getBrowseCountByUser(K_Resources_code) as 'K_Browse_LogCount',K_Resources_downloadCount,K_Resources_coverImage,K_Resources_nouserCount,K_Resources_Permissions,dbo.getKeywordlist(K_Resources_code) as K_Resources_Keyword");
            strSql.Append(" FROM K_Resources where K_Resources_isDelete=0 and K_Resources_state = 834 and K_Resources_type in (" + type + ")  and K_Resources_code in (" + codeList + ")");

            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

