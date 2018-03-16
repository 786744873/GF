using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:角色表
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Roles
    {
        public C_Roles()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Roles_id", "C_Roles");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Roles_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Roles");
            strSql.Append(" where C_Roles_id=@C_Roles_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Roles_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Roles(");
            strSql.Append("C_Roles_name,C_Roles_isDelete,C_Roles_creator,C_Roles_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Roles_name,@C_Roles_isDelete,@C_Roles_creator,@C_Roles_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Roles_isDelete", SqlDbType.Bit,1),
                    new SqlParameter("@C_Roles_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Roles_createTime",SqlDbType.DateTime)};
            parameters[0].Value = model.C_Roles_name;
            parameters[1].Value = model.C_Roles_isDelete;
            parameters[2].Value = model.C_Roles_creator;
            parameters[3].Value = model.C_Roles_createTime;

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
        public bool Update(CommonService.Model.SysManager.C_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Roles set ");
            strSql.Append("C_Roles_name=@C_Roles_name,");
            strSql.Append("C_Roles_isDelete=@C_Roles_isDelete,");
            strSql.Append("C_Roles_creator=@C_Roles_creator,");
            strSql.Append("C_Roles_createTime=@C_Roles_createTime");
            strSql.Append(" where C_Roles_id=@C_Roles_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Roles_isDelete", SqlDbType.Bit,1),
                    new SqlParameter("@C_Roles_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Roles_createTime",SqlDbType.DateTime),
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_name;
            parameters[1].Value = model.C_Roles_isDelete;
            parameters[2].Value = model.C_Roles_creator;
            parameters[3].Value = model.C_Roles_createTime;
            parameters[4].Value = model.C_Roles_id;

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
        public bool Delete(int C_Roles_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Roles set C_Roles_isDelete=1 ");
            strSql.Append(" where C_Roles_id=@C_Roles_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Roles_id;

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
        public bool DeleteList(string C_Roles_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Roles ");
            strSql.Append(" where C_Roles_id in (" + C_Roles_idlist + ")  ");
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
        public CommonService.Model.SysManager.C_Roles GetModel(int C_Roles_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Roles_id,C_Roles_name,C_Roles_isDelete,C_Roles_creator,C_Roles_createTime from C_Roles ");
            strSql.Append(" where C_Roles_id=@C_Roles_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Roles_id;

            CommonService.Model.SysManager.C_Roles model = new CommonService.Model.SysManager.C_Roles();
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
        public CommonService.Model.SysManager.C_Roles DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Roles model = new CommonService.Model.SysManager.C_Roles();
            if (row != null)
            {
                if (row["C_Roles_id"] != null && row["C_Roles_id"].ToString() != "")
                {
                    model.C_Roles_id = int.Parse(row["C_Roles_id"].ToString());
                }
                if (row["C_Roles_name"] != null)
                {
                    model.C_Roles_name = row["C_Roles_name"].ToString();
                }
                if (row["C_Roles_isDelete"] != null && row["C_Roles_isDelete"].ToString() != "")
                {
                    if ((row["C_Roles_isDelete"].ToString() == "1") || (row["C_Roles_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Roles_isDelete = true;
                    }
                    else
                    {
                        model.C_Roles_isDelete = false;
                    }
                }
                if (row["C_Roles_creator"] != null && row["C_Roles_creator"].ToString() != "")
                {
                    model.C_Roles_creator =new Guid(row["C_Roles_creator"].ToString());
                }
                if (row["C_Roles_createTime"] != null && row["C_Roles_createTime"].ToString() != "")
                {
                    model.C_Roles_createTime = DateTime.Parse(row["C_Roles_createTime"].ToString());
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
            strSql.Append("select C_Roles_id,C_Roles_name,C_Roles_isDelete,C_Roles_creator,C_Roles_createTime ");
            strSql.Append(" FROM C_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Roles_id,C_Roles_name,C_Roles_isDelete,C_Roles_creator,C_Roles_createTime ");
            strSql.Append(" FROM C_Roles where C_Roles_isDelete=0 ");
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
            strSql.Append(" C_Roles_id,C_Roles_name,C_Roles_isDelete,C_Roles_creator,C_Roles_createTime ");
            strSql.Append(" FROM C_Roles ");
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
        public int GetRecordCount(Model.SysManager.C_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Roles ");
            strSql.Append(" where 1=1 and C_Roles_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Roles_name != null && model.C_Roles_name != "")
                {
                    strSql.Append("and C_Roles_name like N'%'+@C_Roles_name+'%' ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Roles_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_name;
            parameters[1].Value = model.C_Roles_isDelete;
            parameters[2].Value = model.C_Roles_id;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
        public DataSet GetListByPage(Model.SysManager.C_Roles model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Roles_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Roles T ");
            strSql.Append(" where 1=1 and C_Roles_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Roles_name != null && model.C_Roles_name != "")
                {
                    strSql.Append("and C_Roles_name like N'%'+@C_Roles_name+'%' ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Roles_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Roles_name;
            parameters[1].Value = model.C_Roles_isDelete;
            parameters[2].Value = model.C_Roles_id;
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
            parameters[0].Value = "C_Roles";
            parameters[1].Value = "C_Roles_id";
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

