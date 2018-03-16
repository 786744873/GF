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
    /// 数据访问类:K_Resources_Browse
    /// </summary>
    public partial class K_Resources_Browse
    {
        public K_Resources_Browse()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Resources_Browse_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Resources_Browse");
            strSql.Append(" where K_Resources_Browse_id=@K_Resources_Browse_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_Browse_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Resources_Browse_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Resources_Browse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Resources_Browse(");
            strSql.Append("K_Resources_code,Userinfo_code,K_Resources_Browse_createTime,K_Resources_Browse_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@K_Resources_code,@Userinfo_code,@K_Resources_Browse_createTime,@K_Resources_Browse_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_Browse_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Resources_Browse_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.K_Resources_code;
            parameters[1].Value = model.Userinfo_code;
            parameters[2].Value = model.K_Resources_Browse_createTime;
            parameters[3].Value = model.K_Resources_Browse_isDelete;

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
        public bool Update(CommonService.Model.KMS.K_Resources_Browse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Resources_Browse set ");
            strSql.Append("K_Resources_code=@K_Resources_code,");
            strSql.Append("Userinfo_code=@Userinfo_code,");
            strSql.Append("K_Resources_Browse_createTime=@K_Resources_Browse_createTime,");
            strSql.Append("K_Resources_Browse_isDelete=@K_Resources_Browse_isDelete");
            strSql.Append(" where K_Resources_Browse_id=@K_Resources_Browse_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_Browse_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Resources_Browse_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Resources_Browse_id", SqlDbType.Int,4)};
            parameters[0].Value = model.K_Resources_code;
            parameters[1].Value = model.Userinfo_code;
            parameters[2].Value = model.K_Resources_Browse_createTime;
            parameters[3].Value = model.K_Resources_Browse_isDelete;
            parameters[4].Value = model.K_Resources_Browse_id;

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
        public bool Delete(int K_Resources_Browse_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Resources_Browse ");
            strSql.Append(" where K_Resources_Browse_id=@K_Resources_Browse_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_Browse_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Resources_Browse_id;

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
        public bool DeleteList(string K_Resources_Browse_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Resources_Browse ");
            strSql.Append(" where K_Resources_Browse_id in (" + K_Resources_Browse_idlist + ")  ");
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
        public CommonService.Model.KMS.K_Resources_Browse GetModel(int K_Resources_Browse_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Resources_Browse_id,K_Resources_code,Userinfo_code,K_Resources_Browse_createTime,K_Resources_Browse_isDelete from K_Resources_Browse ");
            strSql.Append(" where K_Resources_Browse_id=@K_Resources_Browse_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_Browse_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Resources_Browse_id;

            CommonService.Model.KMS.K_Resources_Browse model = new CommonService.Model.KMS.K_Resources_Browse();
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
        /// 根据用户和资源获取浏览记录
        /// </summary>
        public CommonService.Model.KMS.K_Resources_Browse ExistsBrowse(Guid Userinfo_code, Guid K_Resources_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top(1)* from K_Resources_Browse");
            strSql.Append(" where K_Resources_Browse_isDelete=0 and K_Resources_code=@K_Resources_code ");
            strSql.Append(" and Userinfo_code=@Userinfo_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Userinfo_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Resources_code;
            parameters[1].Value = Userinfo_code;

            CommonService.Model.KMS.K_Resources_Browse model = new CommonService.Model.KMS.K_Resources_Browse();
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
        public CommonService.Model.KMS.K_Resources_Browse DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Resources_Browse model = new CommonService.Model.KMS.K_Resources_Browse();
            if (row != null)
            {
                if (row["K_Resources_Browse_id"] != null && row["K_Resources_Browse_id"].ToString() != "")
                {
                    model.K_Resources_Browse_id = int.Parse(row["K_Resources_Browse_id"].ToString());
                }
                if (row["K_Resources_code"] != null && row["K_Resources_code"].ToString() != "")
                {
                    model.K_Resources_code = new Guid(row["K_Resources_code"].ToString());
                }
                if (row["Userinfo_code"] != null && row["Userinfo_code"].ToString() != "")
                {
                    model.Userinfo_code = new Guid(row["Userinfo_code"].ToString());
                }
                if (row["K_Resources_Browse_createTime"] != null && row["K_Resources_Browse_createTime"].ToString() != "")
                {
                    model.K_Resources_Browse_createTime = DateTime.Parse(row["K_Resources_Browse_createTime"].ToString());
                }
                if (row.Table.Columns.Contains("K_Resources_coverImage"))
                {
                    if (row["K_Resources_coverImage"] != null && row["K_Resources_coverImage"].ToString() != "")
                    {
                        model.K_Resources_coverImage = row["K_Resources_coverImage"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_url"))
                {
                    if (row["K_Resources_url"] != null && row["K_Resources_url"].ToString() != "")
                    {
                        model.K_Resources_url = row["K_Resources_url"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_name"))
                {
                    if (row["K_Resources_name"] != null && row["K_Resources_name"].ToString() != "")
                    {
                        model.K_Resources_name = row["K_Resources_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_type"))
                {
                    if (row["K_Resources_type"] != null && row["K_Resources_type"].ToString() != "")
                    {
                        model.K_Resources_type = int.Parse(row["K_Resources_type"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_typeName"))
                {
                    if (row["K_Resources_typeName"] != null && row["K_Resources_typeName"].ToString() != "")
                    {
                        model.K_Resources_typeName = row["K_Resources_typeName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_KnowledgeName"))
                {
                    if (row["K_Resources_KnowledgeName"] != null && row["K_Resources_KnowledgeName"].ToString() != "")
                    {
                        model.K_Resources_KnowledgeName = row["K_Resources_KnowledgeName"].ToString();
                    }
                }
                if (row["K_Resources_Browse_isDelete"] != null && row["K_Resources_Browse_isDelete"].ToString() != "")
                {
                    if ((row["K_Resources_Browse_isDelete"].ToString() == "1") || (row["K_Resources_Browse_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.K_Resources_Browse_isDelete = true;
                    }
                    else
                    {
                        model.K_Resources_Browse_isDelete = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 最近浏览
        /// </summary>
        /// <param name="K_study_creator">用户Guid</param>
        /// <param name="pageSize">展示数量</param>
        /// <returns></returns>
        public DataSet GetListByCreatorTime(Guid Userinfo_code, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize.ToString());
            strSql.Append(" B.K_Resources_Browse_id,B.K_Resources_code,B.Userinfo_code,B.K_Resources_Browse_createTime,B.K_Resources_Browse_isDelete,R.K_Resources_name as 'K_Resources_name',R.K_Resources_type as 'K_Resources_type',R.K_Resources_url as 'K_Resources_url',R.K_Resources_coverImage as 'K_Resources_coverImage'  ");
            strSql.Append("  FROM K_Resources_Browse as B");
            strSql.Append(" left join K_Resources as R on B.K_Resources_code=R.K_Resources_code ");
            strSql.Append(" where B.K_Resources_Browse_isDelete=0 and B.Userinfo_code=@Userinfo_code order by B.K_Resources_Browse_createTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = Userinfo_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Resources_Browse_id,K_Resources_code,Userinfo_code,K_Resources_Browse_createTime,K_Resources_Browse_isDelete ");
            strSql.Append(" FROM K_Resources_Browse ");
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
            strSql.Append(" K_Resources_Browse_id,K_Resources_code,Userinfo_code,K_Resources_Browse_createTime,K_Resources_Browse_isDelete ");
            strSql.Append(" FROM K_Resources_Browse ");
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
        public int GetRecordCount(CommonService.Model.KMS.K_Resources_Browse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Resources_Browse as B");
            strSql.Append(" left join K_Resources as R on B.K_Resources_code=R.K_Resources_code ");
            strSql.Append(" where 1=1 and B.K_Resources_Browse_isDelete=0 and R.K_Resources_isDelete=0 ");
            if (model != null)
            {
                if (model.Userinfo_code != null && model.Userinfo_code.ToString() != "")
                {
                    strSql.Append(" and B.Userinfo_code=@Userinfo_code ");
                }
                if (model.K_Resources_type == 1)
                {//获取文档：资源类型为word、pdf、excel、ppt
                    strSql.Append(" and R.K_Resources_type not in (825,827,829)");
                }
                else if (model.K_Resources_type != null && model.K_Resources_type.ToString() != "")
                {
                    strSql.Append(" and R.K_Resources_type=@K_Resources_type ");
                }
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and R.K_Resources_name like N'%'+@K_Resources_name+'%' ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@Userinfo_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Resources_type",SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_name",SqlDbType.NVarChar)
			};
            parameters[0].Value = model.Userinfo_code;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_name;
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
        public DataSet GetListByPage(CommonService.Model.KMS.K_Resources_Browse model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by B.K_Resources_Browse_createTime desc");
            }
            strSql.Append(")AS Row, B.*,R.K_Resources_name as 'K_Resources_name',R.K_Resources_type as 'K_Resources_type',R.K_Resources_url as 'K_Resources_url',P.C_Parameters_name as 'K_Resources_typeName',K.K_Knowledge_name as 'K_Resources_KnowledgeName'  from K_Resources_Browse B ");
            strSql.Append(" left join K_Resources as R on B.K_Resources_code=R.K_Resources_code ");
            strSql.Append(" left join C_Parameters as P on R.K_Resources_type=P.C_Parameters_id ");
            strSql.Append(" left join K_Knowledge_Resources as KR on R.K_Resources_code=KR.P_FK_code ");
            strSql.Append(" left join K_Knowledge as K on KR.K_Knowledge_code=K.K_Knowledge_code ");
            strSql.Append(" where 1=1 and B.K_Resources_Browse_isDelete=0 and R.K_Resources_isDelete=0 and KR.K_Knowledge_Resources_isDelete=0 ");
            if (model != null)
            {
                if (model.Userinfo_code != null && model.Userinfo_code.ToString() != "")
                {
                    strSql.Append(" and B.Userinfo_code=@Userinfo_code ");
                }
                if (model.K_Resources_type == 1)
                {//获取文档：资源类型为word、pdf、excel、ppt
                    strSql.Append(" and R.K_Resources_type not in (825,827,829)");
                }
                else if (model.K_Resources_type != null && model.K_Resources_type.ToString() != "")
                {
                    strSql.Append(" and R.K_Resources_type=@K_Resources_type ");
                }
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and R.K_Resources_name like N'%'+@K_Resources_name+'%' ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@Userinfo_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Resources_type",SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_name",SqlDbType.NVarChar)
			};
            parameters[0].Value = model.Userinfo_code;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_name;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
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
            parameters[0].Value = "K_Resources_Browse";
            parameters[1].Value = "K_Resources_Browse_id";
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
