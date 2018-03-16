using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:组织架构--岗位中间表
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
    public partial class C_Organization_post
    {
        public C_Organization_post()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Organization_post_id", "C_Organization_post");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Organization_post_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Organization_post");
            strSql.Append(" where C_Organization_post_id=@C_Organization_post_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_post_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Organization_post_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Organization_post model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Organization_post(");
            strSql.Append("C_Organization_post_code,C_Post_code,C_Organization_code,C_Organization_post_creator,C_Organization_post_createTime,C_Organization_post_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@C_Organization_post_code,@C_Post_code,@C_Organization_code,@C_Organization_post_creator,@C_Organization_post_createTime,@C_Organization_post_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Organization_post_code",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_post_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Organization_post_code;
            parameters[1].Value = model.C_Post_code;
            parameters[2].Value = model.C_Organization_code;
            parameters[3].Value = model.C_Organization_post_creator;
            parameters[4].Value = model.C_Organization_post_createTime;
            parameters[5].Value = model.C_Organization_post_isDelete;

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
        public bool Update(CommonService.Model.SysManager.C_Organization_post model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization_post set ");
            strSql.Append("C_Post_code=@C_Post_code,");
            strSql.Append("C_Organization_code=@C_Organization_code,");
            strSql.Append("C_Organization_post_creator=@C_Organization_post_creator,");
            strSql.Append("C_Organization_post_createTime=@C_Organization_post_createTime,");
            strSql.Append("C_Organization_post_isDelete=@C_Organization_post_isDelete");
            strSql.Append(" where C_Organization_post_id=@C_Organization_post_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_post_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_post_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Post_code;
            parameters[1].Value = model.C_Organization_code;
            parameters[2].Value = model.C_Organization_post_creator;
            parameters[3].Value = model.C_Organization_post_createTime;
            parameters[4].Value = model.C_Organization_post_isDelete;
            parameters[5].Value = model.C_Organization_post_id;

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
        public bool Delete(int C_Organization_post_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization_post set C_Organization_post_isDelete=1 ");
            strSql.Append(" where C_Organization_post_id=@C_Organization_post_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_post_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Organization_post_id;

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
        public bool DeleteByPostCode(Guid C_post_code, Guid C_Organization_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization_post set C_Organization_post_isDelete=1 ");
            strSql.Append(" where C_Post_code=@C_Post_code ");
            strSql.Append("and C_Organization_code=@C_Organization_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Organization_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_post_code;
            parameters[1].Value = C_Organization_code;

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
        public bool DeleteList(string C_Organization_post_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Organization_post ");
            strSql.Append(" where C_Organization_post_id in (" + C_Organization_post_idlist + ")  ");
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
        public CommonService.Model.SysManager.C_Organization_post GetModel(int C_Organization_post_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Organization_post_id,C_Organization_post_code,C_Post_code,C_Organization_code,C_Organization_post_creator,C_Organization_post_createTime,C_Organization_post_isDelete from C_Organization_post ");
            strSql.Append(" where C_Organization_post_id=@C_Organization_post_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_post_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Organization_post_id;

            CommonService.Model.SysManager.C_Organization_post model = new CommonService.Model.SysManager.C_Organization_post();
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
        public CommonService.Model.SysManager.C_Organization_post DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Organization_post model = new CommonService.Model.SysManager.C_Organization_post();
            if (row != null)
            {
                if (row["C_Organization_post_id"] != null && row["C_Organization_post_id"].ToString() != "")
                {
                    model.C_Organization_post_id = int.Parse(row["C_Organization_post_id"].ToString());
                }
                if (row["C_Organization_post_code"] != null && row["C_Organization_post_code"].ToString() != "")
                {
                    model.C_Organization_post_code = new Guid(row["C_Organization_post_code"].ToString());
                }
                if (row["C_Post_code"] != null && row["C_Post_code"].ToString() != "")
                {
                    model.C_Post_code = new Guid(row["C_Post_code"].ToString());
                }
                if (row["C_Organization_code"] != null && row["C_Organization_code"].ToString() != "")
                {
                    model.C_Organization_code = new Guid(row["C_Organization_code"].ToString());
                }
                if (row["C_Organization_post_creator"] != null && row["C_Organization_post_creator"].ToString() != "")
                {
                    model.C_Organization_post_creator = new Guid(row["C_Organization_post_creator"].ToString());
                }
                if (row["C_Organization_post_createTime"] != null && row["C_Organization_post_createTime"].ToString() != "")
                {
                    model.C_Organization_post_createTime = DateTime.Parse(row["C_Organization_post_createTime"].ToString());
                }
                if (row["C_Organization_post_isDelete"] != null && row["C_Organization_post_isDelete"].ToString() != "")
                {
                    model.C_Organization_post_isDelete = int.Parse(row["C_Organization_post_isDelete"].ToString());
                }
                //检查岗位名称列，是否存在于table中
                if (row.Table.Columns.Contains("C_Post_name"))
                {
                    if (row["C_Post_name"] != null)
                    {
                        model.C_Post_name = row["C_Post_name"].ToString();
                    }
                }
                //检查组织机构名称列，是否存在于table中
                if (row.Table.Columns.Contains("C_Organization_name"))
                {
                    if (row["C_Organization_name"] != null)
                    {
                        model.C_Organization_name = row["C_Organization_name"].ToString();
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
            strSql.Append("select C_Organization_post_id,C_Organization_post_code,C_Post_code,C_Organization_code,C_Organization_post_creator,C_Organization_post_createTime,C_Organization_post_isDelete ");
            strSql.Append(" FROM C_Organization_post ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByOrgCode(Guid C_Organization_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Organization_post_id,C_Organization_post_code,C_Post_code,C_Organization_code,C_Organization_post_creator,C_Organization_post_createTime,C_Organization_post_isDelete ");
            strSql.Append(" FROM C_Organization_post ");
            strSql.Append("where C_Organization_code=@C_Organization_code ");
            strSql.Append("and C_Organization_post_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Organization_code;

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
            strSql.Append(" C_Organization_post_id,C_Organization_post_code,C_Post_code,C_Organization_code,C_Organization_post_creator,C_Organization_post_createTime,C_Organization_post_isDelete ");
            strSql.Append(" FROM C_Organization_post ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 通过组织机构Guid，获取关联岗位集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <returns></returns>
        public DataSet GetRelationPostsByOrg(Guid? orgCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OP.C_Organization_post_id,OP.C_Organization_post_code,OP.C_Post_code,OP.C_Organization_code,OP.C_Organization_post_creator,OP.C_Organization_post_createTime,OP.C_Organization_post_isDelete,");
            strSql.Append("O.C_Organization_name As C_Organization_name,P.C_Post_name AS C_Post_name ");
            strSql.Append("from C_Organization_post AS OP WITH(NOLOCK) ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on OP.C_Organization_code=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on OP.C_Post_code=P.C_Post_code ");
            strSql.Append("where OP.C_Organization_post_isDelete=0 ");
            strSql.Append("and O.C_Organization_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            //strSql.Append("and P.C_Post_code in(select C_Userinfo_post from C_Userinfo where C_Userinfo_roleID in(select C_Roles_id from C_Role_Role_Power where C_Role_Power_id=18))");
            if (orgCode != null)
            {
                strSql.Append("and OP.C_Organization_code=@C_Organization_code");
            }

            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = orgCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters); ;
        }



        /// <summary>
        /// 通过组织机构以及子级组织架构Guid，获取关联岗位集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <returns></returns>
        public DataSet GetRelationPostsByOrgList(List<Guid> orgCode)
        {

            string zzgw = "";
            foreach (Guid item in orgCode) {
                if (item.ToString() == "00000000-0000-0000-0000-000000000000") continue;
                zzgw += item + ",";
            
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OP.C_Organization_post_id,OP.C_Organization_post_code,OP.C_Post_code,OP.C_Organization_code,OP.C_Organization_post_creator,OP.C_Organization_post_createTime,OP.C_Organization_post_isDelete,");
            strSql.Append("O.C_Organization_name As C_Organization_name,P.C_Post_name AS C_Post_name ");
            strSql.Append("from C_Organization_post AS OP WITH(NOLOCK) ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on OP.C_Organization_code=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on OP.C_Post_code=P.C_Post_code ");
            strSql.Append("where OP.C_Organization_post_isDelete=0 ");
            strSql.Append("and O.C_Organization_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            //strSql.Append("and P.C_Post_code in(select C_Userinfo_post from C_Userinfo where C_Userinfo_roleID in(select C_Roles_id from C_Role_Role_Power where C_Role_Power_id=18))");
            if (zzgw != "")
            {
                strSql.Append("and '" + zzgw + "' like '%'+convert(varchar(500),OP.C_Organization_code)+'%'");
           
            }

       
            return DbHelperSQL.Query(strSql.ToString(), null); ;
        }
        /// <summary>
        /// 通过岗位Guid集合，获取集合
        /// </summary>
        /// <param name="orgCode">岗位集合</param>
        /// <returns></returns>
        public DataSet GetRelationPostsByPostStr(string postStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OP.C_Organization_post_id,OP.C_Organization_post_code,OP.C_Post_code,OP.C_Organization_code,OP.C_Organization_post_creator,OP.C_Organization_post_createTime,OP.C_Organization_post_isDelete,");
            strSql.Append("O.C_Organization_name As C_Organization_name,P.C_Post_name AS C_Post_name ");
            strSql.Append("from C_Organization_post AS OP WITH(NOLOCK) ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on OP.C_Organization_code=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on OP.C_Post_code=P.C_Post_code ");
            strSql.Append("where OP.C_Organization_post_isDelete=0 ");
            strSql.Append("and O.C_Organization_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            if (!string.IsNullOrEmpty(postStr))
            {
                strSql.Append("and P.C_Post_code in (" + postStr + ")");
            }
            return DbHelperSQL.Query(strSql.ToString()); ;
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(Model.SysManager.C_Organization_post model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Organization_post ");
            strSql.Append(" where 1=1 and C_Organization_post_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Post_code != null && model.C_Post_code.ToString() != "")
                {
                    strSql.Append("and C_Post_code=@C_Post_code ");
                }
                if (model.C_Organization_code != null && model.C_Organization_code.ToString() != "")
                {
                    strSql.Append("and C_Organization_code=@C_Organization_code ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Post_code;
            parameters[1].Value = model.C_Organization_code;
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
        public DataSet GetListByPage(Model.SysManager.C_Organization_post model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Organization_post_id desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Post_name  from C_Organization_post T left join C_Post as P on T.C_Post_code=P.C_Post_code ");
            strSql.Append(" where 1=1 and T.C_Organization_post_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Post_code != null && model.C_Post_code.ToString() != "")
                {
                    strSql.Append("and T.C_Post_code=@C_Post_code ");
                }
                if (model.C_Organization_code != null && model.C_Organization_code.ToString() != "")
                {
                    strSql.Append("and T.C_Organization_code=@C_Organization_code ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Post_code;
            parameters[1].Value = model.C_Organization_code;
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
            parameters[0].Value = "C_Organization_post";
            parameters[1].Value = "C_Organization_post_id";
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

