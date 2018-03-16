using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:关键字表
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Keyword
    {
        public K_Keyword()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("K_Keyword_id", "K_Keyword");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Keyword_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Keyword");
            strSql.Append(" where K_Keyword_id=@K_Keyword_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Keyword_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Keyword model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Keyword(");
            strSql.Append("K_Keyword_code,K_Keyword_name,K_Keyword_createTime,K_Keyword_creator,K_Keyword_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@K_Keyword_code,@K_Keyword_name,@K_Keyword_createTime,@K_Keyword_creator,@K_Keyword_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Keyword_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Keyword_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Keyword_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Keyword_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.K_Keyword_code;
            parameters[1].Value = model.K_Keyword_name;
            parameters[2].Value = model.K_Keyword_createTime;
            parameters[3].Value = model.K_Keyword_creator;
            parameters[4].Value = model.K_Keyword_isDelete;

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
        public bool Update(CommonService.Model.KMS.K_Keyword model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Keyword set ");
            strSql.Append("K_Keyword_code=@K_Keyword_code,");
            strSql.Append("K_Keyword_name=@K_Keyword_name,");
            strSql.Append("K_Keyword_createTime=@K_Keyword_createTime,");
            strSql.Append("K_Keyword_creator=@K_Keyword_creator,");
            strSql.Append("K_Keyword_isDelete=@K_Keyword_isDelete");
            strSql.Append(" where K_Keyword_id=@K_Keyword_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Keyword_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Keyword_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Keyword_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Keyword_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Keyword_id", SqlDbType.Int,4)};
            parameters[0].Value = model.K_Keyword_code;
            parameters[1].Value = model.K_Keyword_name;
            parameters[2].Value = model.K_Keyword_createTime;
            parameters[3].Value = model.K_Keyword_creator;
            parameters[4].Value = model.K_Keyword_isDelete;
            parameters[5].Value = model.K_Keyword_id;

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
        public bool Delete(Guid K_Keyword_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Keyword set K_Keyword_isDelete=1 ");
            strSql.Append(" where K_Keyword_code=@K_Keyword_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Keyword_code;

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
        public bool DeleteList(string K_Keyword_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Keyword ");
            strSql.Append(" where K_Keyword_id in (" + K_Keyword_idlist + ")  ");
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
        public CommonService.Model.KMS.K_Keyword GetModel(int K_Keyword_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Keyword_id,K_Keyword_code,K_Keyword_name,K_Keyword_createTime,K_Keyword_creator,K_Keyword_isDelete from K_Keyword ");
            strSql.Append(" where K_Keyword_id=@K_Keyword_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Keyword_id;

            CommonService.Model.KMS.K_Keyword model = new CommonService.Model.KMS.K_Keyword();
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
        public CommonService.Model.KMS.K_Keyword GetModel(Guid K_Keyword_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Keyword_id,K_Keyword_code,K_Keyword_name,K_Keyword_createTime,K_Keyword_creator,K_Keyword_isDelete from K_Keyword ");
            strSql.Append(" where K_Keyword_isDelete=0 ");
            strSql.Append(" and K_Keyword_code=@K_Keyword_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Keyword_code;

            CommonService.Model.KMS.K_Keyword model = new CommonService.Model.KMS.K_Keyword();
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
        public CommonService.Model.KMS.K_Keyword DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Keyword model = new CommonService.Model.KMS.K_Keyword();
            if (row != null)
            {
                if (row.Table.Columns.Contains("K_Keyword_id"))
                {
                    if (row["K_Keyword_id"] != null && row["K_Keyword_id"].ToString() != "")
                    {
                        model.K_Keyword_id = int.Parse(row["K_Keyword_id"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Keyword_code"))
                {
                    if (row["K_Keyword_code"] != null && row["K_Keyword_code"].ToString() != "")
                    {
                        model.K_Keyword_code = new Guid(row["K_Keyword_code"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Keyword_name"))
                {
                    if (row["K_Keyword_name"] != null)
                    {
                        model.K_Keyword_name = row["K_Keyword_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Keyword_createTime"))
                {
                    if (row["K_Keyword_createTime"] != null && row["K_Keyword_createTime"].ToString() != "")
                    {
                        model.K_Keyword_createTime = DateTime.Parse(row["K_Keyword_createTime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Keyword_creator"))
                {
                    if (row["K_Keyword_creator"] != null && row["K_Keyword_creator"].ToString() != "")
                    {
                        model.K_Keyword_creator = new Guid(row["K_Keyword_creator"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Keyword_isDelete"))
                {
                    if (row["K_Keyword_isDelete"] != null && row["K_Keyword_isDelete"].ToString() != "")
                    {
                        if ((row["K_Keyword_isDelete"].ToString() == "1") || (row["K_Keyword_isDelete"].ToString().ToLower() == "true"))
                        {
                            model.K_Keyword_isDelete = true;
                        }
                        else
                        {
                            model.K_Keyword_isDelete = false;
                        }
                    }
                }

                if (row.Table.Columns.Contains("K_Keyword_counts"))
                {
                    if (row["K_Keyword_counts"] != null && row["K_Keyword_counts"].ToString() != "")
                    {
                        model.K_Keyword_counts = Convert.ToInt32(row["K_Keyword_counts"].ToString());
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 根据关键字得到一个对象Guid
        /// </summary>
        public string GetModelByKey(string K_Keyword_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 K_Keyword_code FROM K_Keyword ");
            strSql.Append(" where K_Keyword_isDelete=0 and K_Keyword_name='" + K_Keyword_name + "' ");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
                obj = "";


            return obj.ToString();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Keyword_id,K_Keyword_code,K_Keyword_name,K_Keyword_createTime,K_Keyword_creator,K_Keyword_isDelete ");
            strSql.Append(" FROM K_Keyword ");
            strSql.Append(" where K_Keyword_isDelete=0 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Keyword_id,K_Keyword_code,K_Keyword_name,K_Keyword_createTime,K_Keyword_creator,K_Keyword_isDelete ");
            strSql.Append(" FROM K_Keyword ");
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
            strSql.Append(" K_Keyword_id,K_Keyword_code,K_Keyword_name,K_Keyword_createTime,K_Keyword_creator,K_Keyword_isDelete ");
            strSql.Append(" FROM K_Keyword ");
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
        public int GetRecordCount(CommonService.Model.KMS.K_Keyword model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Keyword ");
            strSql.Append(" where 1=1 and K_Keyword_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Keyword_name != null && model.K_Keyword_name.ToString() != "")
                {
                    strSql.Append(" and K_Keyword_name=@K_Keyword_name ");
                }
                if (model.K_Keyword_creator != null && model.K_Keyword_creator.ToString() != "")
                {
                    strSql.Append(" and K_Keyword_creator=@K_Keyword_creator");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_name", SqlDbType.NVarChar),
					new SqlParameter("@K_Keyword_creator", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.K_Keyword_name;
            parameters[1].Value = model.K_Keyword_creator;
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
        public DataSet GetListByPage(CommonService.Model.KMS.K_Keyword model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.K_Keyword_id desc");
            }
            strSql.Append(")AS Row, T.*  from K_Keyword T ");
            strSql.Append(" where 1=1 and T.K_Keyword_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Keyword_name != null && model.K_Keyword_name.ToString() != "")
                {
                    strSql.Append(" and K_Keyword_name=@K_Keyword_name ");
                }
                if (model.K_Keyword_creator != null && model.K_Keyword_creator.ToString() != "")
                {
                    strSql.Append(" and K_Keyword_creator=@K_Keyword_creator");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Keyword_name", SqlDbType.NVarChar),
					new SqlParameter("@K_Keyword_creator", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.K_Keyword_name;
            parameters[1].Value = model.K_Keyword_creator;
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
            parameters[0].Value = "K_Keyword";
            parameters[1].Value = "K_Keyword_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        /// <summary>
        /// 根据资源guid获得资源的关键字列表
        /// </summary>
        public DataSet GetKeywordList(Guid K_Resources_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" K_Keyword_id,K_Keyword_code,K_Keyword_name,K_Keyword_createTime,K_Keyword_creator,K_Keyword_isDelete ");
            strSql.Append(" FROM K_Keyword  ");
            strSql.Append(" where 1=1 and exits(select 1 from K_Keyword_Resources where K_Resources_code=" + K_Resources_code + ")");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得热门标签前10条数据列表
        /// </summary>
        public DataSet GetTagList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 10 K_Keyword_name,count(1) as 'K_Keyword_counts' from K_Keyword group by K_Keyword_name order by 'K_Keyword_counts'desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

