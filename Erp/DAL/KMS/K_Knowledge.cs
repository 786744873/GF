using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:知识分类表
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Knowledge
    {
        public K_Knowledge()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("K_Knowledge_id", "K_Knowledge");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Knowledge_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Knowledge");
            strSql.Append(" where K_Knowledge_id=@K_Knowledge_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Knowledge_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Knowledge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Knowledge(");
            strSql.Append("K_Knowledge_code,K_Knowledge_name,K_Knowledge_parent,K_Knowledge_createTime,K_Knowledge_creator,K_Knowledge_isDelete,K_Knowledge_Person)");
            strSql.Append(" values (");
            strSql.Append("@K_Knowledge_code,@K_Knowledge_name,@K_Knowledge_parent,@K_Knowledge_createTime,@K_Knowledge_creator,@K_Knowledge_isDelete,@K_Knowledge_Person)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Knowledge_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Knowledge_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_isDelete", SqlDbType.Bit,1),
                    new SqlParameter("@K_Knowledge_Person",SqlDbType.UniqueIdentifier,16)                    
                                        };
            parameters[0].Value = model.K_Knowledge_code;
            parameters[1].Value = model.K_Knowledge_name;
            parameters[2].Value = model.K_Knowledge_parent;
            parameters[3].Value = model.K_Knowledge_createTime;
            parameters[4].Value = model.K_Knowledge_creator;
            parameters[5].Value = model.K_Knowledge_isDelete;
            parameters[6].Value = model.K_Knowledge_Person;

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
        public bool Update(CommonService.Model.KMS.K_Knowledge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Knowledge set ");
            strSql.Append("K_Knowledge_code=@K_Knowledge_code,");
            strSql.Append("K_Knowledge_name=@K_Knowledge_name,");
            strSql.Append("K_Knowledge_parent=@K_Knowledge_parent,");
            strSql.Append("K_Knowledge_createTime=@K_Knowledge_createTime,");
            strSql.Append("K_Knowledge_creator=@K_Knowledge_creator,");
            strSql.Append("K_Knowledge_isDelete=@K_Knowledge_isDelete,");
            strSql.Append("K_Knowledge_Person=@K_Knowledge_Person ");
            strSql.Append(" where K_Knowledge_id=@K_Knowledge_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Knowledge_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Knowledge_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Knowledge_id", SqlDbType.Int,4),
                    new SqlParameter("@K_Knowledge_Person",SqlDbType.UniqueIdentifier,16)                    
                                        };
            parameters[0].Value = model.K_Knowledge_code;
            parameters[1].Value = model.K_Knowledge_name;
            parameters[2].Value = model.K_Knowledge_parent;
            parameters[3].Value = model.K_Knowledge_createTime;
            parameters[4].Value = model.K_Knowledge_creator;
            parameters[5].Value = model.K_Knowledge_isDelete;
            parameters[6].Value = model.K_Knowledge_id;
            parameters[7].Value = model.K_Knowledge_Person;

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
        public bool Delete(Guid K_Knowledge_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Knowledge set K_Knowledge_isDelete=1 ");
            strSql.Append(" where K_Knowledge_code=@K_Knowledge_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Knowledge_code;

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
        public bool DeleteList(string K_Knowledge_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Knowledge ");
            strSql.Append(" where K_Knowledge_id in (" + K_Knowledge_idlist + ")  ");
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
        public CommonService.Model.KMS.K_Knowledge GetModel(int K_Knowledge_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Knowledge_id,K_Knowledge_code,K_Knowledge_name,K_Knowledge_parent,K_Knowledge_createTime,K_Knowledge_creator,K_Knowledge_isDelete,K_Knowledge_Person from K_Knowledge ");
            strSql.Append(" where K_Knowledge_id=@K_Knowledge_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Knowledge_id;

            CommonService.Model.KMS.K_Knowledge model = new CommonService.Model.KMS.K_Knowledge();
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
        public CommonService.Model.KMS.K_Knowledge GetModel(Guid K_Knowledge_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Knowledge_id,K_Knowledge_code,K_Knowledge_name,K_Knowledge_parent,K_Knowledge_createTime,K_Knowledge_creator,K_Knowledge_isDelete,K_Knowledge_Person from K_Knowledge ");
            strSql.Append(" where K_Knowledge_isDelete=0 ");
            strSql.Append(" and K_Knowledge_code=@K_Knowledge_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Knowledge_code;

            CommonService.Model.KMS.K_Knowledge model = new CommonService.Model.KMS.K_Knowledge();
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
        public CommonService.Model.KMS.K_Knowledge DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Knowledge model = new CommonService.Model.KMS.K_Knowledge();
            if (row != null)
            {
                if (row["K_Knowledge_id"] != null && row["K_Knowledge_id"].ToString() != "")
                {
                    model.K_Knowledge_id = int.Parse(row["K_Knowledge_id"].ToString());
                }
                if (row["K_Knowledge_code"] != null && row["K_Knowledge_code"].ToString() != "")
                {
                    model.K_Knowledge_code = new Guid(row["K_Knowledge_code"].ToString());
                }
                if (row["K_Knowledge_name"] != null)
                {
                    model.K_Knowledge_name = row["K_Knowledge_name"].ToString();
                }
                if (row["K_Knowledge_parent"] != null && row["K_Knowledge_parent"].ToString() != "")
                {
                    model.K_Knowledge_parent = new Guid(row["K_Knowledge_parent"].ToString());
                }
                if (row["K_Knowledge_createTime"] != null && row["K_Knowledge_createTime"].ToString() != "")
                {
                    model.K_Knowledge_createTime = DateTime.Parse(row["K_Knowledge_createTime"].ToString());
                }
                if (row["K_Knowledge_creator"] != null && row["K_Knowledge_creator"].ToString() != "")
                {
                    model.K_Knowledge_creator = new Guid(row["K_Knowledge_creator"].ToString());
                }
                if (row["K_Knowledge_isDelete"] != null && row["K_Knowledge_isDelete"].ToString() != "")
                {
                    if ((row["K_Knowledge_isDelete"].ToString() == "1") || (row["K_Knowledge_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.K_Knowledge_isDelete = true;
                    }
                    else
                    {
                        model.K_Knowledge_isDelete = false;
                    }
                }
                if (row.Table.Columns.Contains("K_Knowledge_parentName"))
                {
                    if (row["K_Knowledge_parentName"] != null && row["K_Knowledge_parentName"].ToString() != "")
                    {
                        model.K_Knowledge_parentName = row["K_Knowledge_parentName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Knowledge_creatorName"))
                {
                    if (row["K_Knowledge_creatorName"] != null && row["K_Knowledge_creatorName"].ToString() != "")
                    {
                        model.K_Knowledge_creatorName = row["K_Knowledge_creatorName"].ToString();
                    }
                }
                if (row["K_Knowledge_Person"] != null && row["K_Knowledge_Person"].ToString() != "")
                {
                    model.K_Knowledge_Person = new Guid(row["K_Knowledge_Person"].ToString());
                }
                if (row.Table.Columns.Contains("K_Knowledge_PersonName"))
                {
                    if (row["K_Knowledge_PersonName"] != null && row["K_Knowledge_PersonName"].ToString() != "")
                    {
                        model.K_Knowledge_PersonName = row["K_Knowledge_PersonName"].ToString();
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Knowledge_id,K_Knowledge_code,K_Knowledge_name,K_Knowledge_parent,K_Knowledge_createTime,K_Knowledge_creator,K_Knowledge_isDelete,K_Knowledge_Person ");
            strSql.Append(" FROM K_Knowledge ");
            strSql.Append(" where K_Knowledge_isDelete=0 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllListByPerson(Guid K_Knowledge_Person)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Knowledge_id,K_Knowledge_code,K_Knowledge_name,K_Knowledge_parent,K_Knowledge_createTime,K_Knowledge_creator,K_Knowledge_isDelete,K_Knowledge_Person ");
            strSql.Append(" FROM K_Knowledge as KZ ");
            strSql.Append(" where K_Knowledge_isDelete=0 ");
            strSql.Append(@" and KZ.K_Knowledge_parent in ( select K_Knowledge_code from K_Knowledge as K where K.K_Knowledge_Person=@K_Knowledge_Person and K.K_Knowledge_isDelete=0 and K.K_Knowledge_parent is null)
or KZ.K_Knowledge_code in ( select K_Knowledge_code from K_Knowledge as K where K.K_Knowledge_Person=@K_Knowledge_Person and K.K_Knowledge_isDelete=0) ");
            //strSql.Append(" and K_Knowledge_Person=@K_Knowledge_Person ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_Person", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = K_Knowledge_Person;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Knowledge_id,K_Knowledge_code,K_Knowledge_name,K_Knowledge_parent,K_Knowledge_createTime,K_Knowledge_creator,K_Knowledge_isDelete,K_Knowledge_Person ");
            strSql.Append(" FROM K_Knowledge ");
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
            strSql.Append(" K_Knowledge_id,K_Knowledge_code,K_Knowledge_name,K_Knowledge_parent,K_Knowledge_createTime,K_Knowledge_creator,K_Knowledge_isDelete,K_Knowledge_Person ");
            strSql.Append(" FROM K_Knowledge ");
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
        public int GetRecordCount(CommonService.Model.KMS.K_Knowledge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Knowledge ");
            strSql.Append(" where 1=1 and K_Knowledge_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Knowledge_name != null && model.K_Knowledge_name.ToString() != "")
                {
                    strSql.Append(" and K_Knowledge_name like N'%'+@K_Knowledge_name+'%' ");
                }
                if (model.K_Knowledge_code != null && model.K_Knowledge_code.ToString() != "")
                {
                    strSql.Append(" and (K_Knowledge_code=@K_Knowledge_code or K_Knowledge_parent=@K_Knowledge_code) ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_name", SqlDbType.NVarChar),
                    new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = model.K_Knowledge_name;
            parameters[1].Value = model.K_Knowledge_code;
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
        public DataSet GetListByPage(CommonService.Model.KMS.K_Knowledge model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.K_Knowledge_id desc");
            }
            strSql.Append(")AS Row, T.*,K.K_Knowledge_name as 'K_Knowledge_parentName',U.C_Userinfo_name as 'K_Knowledge_creatorName',U1.C_Userinfo_name as 'K_Knowledge_PersonName'  from K_Knowledge T ");
            strSql.Append(" left join K_Knowledge as K on T.K_Knowledge_parent=K.K_Knowledge_code ");
            strSql.Append(" left join C_Userinfo as U on T.K_Knowledge_creator=U.C_Userinfo_code ");
            strSql.Append(" left join C_Userinfo as U1 on T.K_Knowledge_Person=U1.C_Userinfo_code ");
            strSql.Append(" where 1=1 and T.K_Knowledge_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Knowledge_name != null && model.K_Knowledge_name.ToString() != "")
                {
                    strSql.Append(" and T.K_Knowledge_name like N'%'+@K_Knowledge_name+'%' ");
                }
                if (model.K_Knowledge_code != null && model.K_Knowledge_code.ToString() != "")
                {
                    strSql.Append(" and (T.K_Knowledge_code=@K_Knowledge_code or T.K_Knowledge_parent=@K_Knowledge_code) ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_name", SqlDbType.NVarChar),
                    new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = model.K_Knowledge_name;
            parameters[1].Value = model.K_Knowledge_code;
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
            parameters[0].Value = "K_Knowledge";
            parameters[1].Value = "K_Knowledge_id";
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

