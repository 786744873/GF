using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:实体表
    /// 作者：贺太玉
    /// 日期：2015/06/03
    /// </summary>
    public partial class C_Entity
    {
        public C_Entity()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Entity_Id", "C_Entity");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Entity_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Entity");
            strSql.Append(" where C_Entity_Id=@C_Entity_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Entity_Id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Entity_Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Entity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Entity(");
            strSql.Append("C_Entity_code,C_Entity_identityName,C_Entity_showName,C_Entity_tableName,C_Entity_business_relFieldName,C_Entity_business_showFieldName,C_Entity_isDelete,C_Entity_creator,C_Entity_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Entity_code,@C_Entity_identityName,@C_Entity_showName,@C_Entity_tableName,@C_Entity_business_relFieldName,@C_Entity_business_showFieldName,@C_Entity_isDelete,@C_Entity_creator,@C_Entity_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Entity_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Entity_identityName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Entity_showName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Entity_tableName", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Entity_business_relFieldName", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Entity_business_showFieldName", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Entity_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Entity_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Entity_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Entity_code;
            parameters[1].Value = model.C_Entity_identityName;
            parameters[2].Value = model.C_Entity_showName;
            parameters[3].Value = model.C_Entity_tableName;
            parameters[4].Value = model.C_Entity_business_relFieldName;
            parameters[5].Value = model.C_Entity_business_showFieldName;
            parameters[6].Value = model.C_Entity_isDelete;
            parameters[7].Value = model.C_Entity_creator;
            parameters[8].Value = model.C_Entity_createTime;

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
        public bool Update(CommonService.Model.C_Entity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Entity set ");
            strSql.Append("C_Entity_code=@C_Entity_code,");
            strSql.Append("C_Entity_identityName=@C_Entity_identityName,");
            strSql.Append("C_Entity_showName=@C_Entity_showName,");
            strSql.Append("C_Entity_tableName=@C_Entity_tableName,");
            strSql.Append("C_Entity_business_relFieldName=@C_Entity_business_relFieldName,");
            strSql.Append("C_Entity_business_showFieldName=@C_Entity_business_showFieldName,");
            strSql.Append("C_Entity_isDelete=@C_Entity_isDelete,");
            strSql.Append("C_Entity_creator=@C_Entity_creator,");
            strSql.Append("C_Entity_createTime=@C_Entity_createTime");
            strSql.Append(" where C_Entity_Id=@C_Entity_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Entity_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Entity_identityName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Entity_showName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Entity_tableName", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Entity_business_relFieldName", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Entity_business_showFieldName", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Entity_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Entity_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Entity_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Entity_Id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Entity_code;
            parameters[1].Value = model.C_Entity_identityName;
            parameters[2].Value = model.C_Entity_showName;
            parameters[3].Value = model.C_Entity_tableName;
            parameters[4].Value = model.C_Entity_business_relFieldName;
            parameters[5].Value = model.C_Entity_business_showFieldName;
            parameters[6].Value = model.C_Entity_isDelete;
            parameters[7].Value = model.C_Entity_creator;
            parameters[8].Value = model.C_Entity_createTime;
            parameters[9].Value = model.C_Entity_Id;

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
        public bool Delete(Guid C_Entity_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Entity set C_Entity_isDelete=1 ");
            strSql.Append(" where C_Entity_code=@C_Entity_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Entity_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Entity_code;

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
        public bool DeleteList(string C_Entity_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Entity ");
            strSql.Append(" where C_Entity_Id in (" + C_Entity_Idlist + ")  ");
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
        public CommonService.Model.C_Entity GetModel(Guid C_Entity_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Entity_Id,C_Entity_code,C_Entity_identityName,C_Entity_showName,C_Entity_tableName,C_Entity_business_relFieldName,C_Entity_business_showFieldName,C_Entity_isDelete,C_Entity_creator,C_Entity_createTime from C_Entity ");
            strSql.Append(" where C_Entity_code=@C_Entity_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Entity_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Entity_code;

            CommonService.Model.C_Entity model = new CommonService.Model.C_Entity();
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
        public CommonService.Model.C_Entity DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Entity model = new CommonService.Model.C_Entity();
            if (row != null)
            {
                if (row["C_Entity_Id"] != null && row["C_Entity_Id"].ToString() != "")
                {
                    model.C_Entity_Id = int.Parse(row["C_Entity_Id"].ToString());
                }
                if (row["C_Entity_code"] != null && row["C_Entity_code"].ToString() != "")
                {
                    model.C_Entity_code = new Guid(row["C_Entity_code"].ToString());
                }
                if (row["C_Entity_identityName"] != null)
                {
                    model.C_Entity_identityName = row["C_Entity_identityName"].ToString();
                }
                if (row["C_Entity_showName"] != null)
                {
                    model.C_Entity_showName = row["C_Entity_showName"].ToString();
                }
                if (row["C_Entity_tableName"] != null)
                {
                    model.C_Entity_tableName = row["C_Entity_tableName"].ToString();
                }
                if (row["C_Entity_business_relFieldName"] != null)
                {
                    model.C_Entity_business_relFieldName = row["C_Entity_business_relFieldName"].ToString();
                }
                if (row["C_Entity_business_showFieldName"] != null)
                {
                    model.C_Entity_business_showFieldName = row["C_Entity_business_showFieldName"].ToString();
                }
                if (row["C_Entity_isDelete"] != null && row["C_Entity_isDelete"].ToString() != "")
                {
                    if ((row["C_Entity_isDelete"].ToString() == "1") || (row["C_Entity_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Entity_isDelete = true;
                    }
                    else
                    {
                        model.C_Entity_isDelete = false;
                    }
                }
                if (row["C_Entity_creator"] != null && row["C_Entity_creator"].ToString() != "")
                {
                    model.C_Entity_creator = new Guid(row["C_Entity_creator"].ToString());
                }
                if (row["C_Entity_createTime"] != null && row["C_Entity_createTime"].ToString() != "")
                {
                    model.C_Entity_createTime = DateTime.Parse(row["C_Entity_createTime"].ToString());
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
            strSql.Append("select C_Entity_Id,C_Entity_code,C_Entity_identityName,C_Entity_showName,C_Entity_tableName,C_Entity_business_relFieldName,C_Entity_business_showFieldName,C_Entity_isDelete,C_Entity_creator,C_Entity_createTime ");
            strSql.Append(" FROM C_Entity ");
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
            strSql.Append(" C_Entity_Id,C_Entity_code,C_Entity_identityName,C_Entity_showName,C_Entity_tableName,C_Entity_business_relFieldName,C_Entity_business_showFieldName,C_Entity_isDelete,C_Entity_creator,C_Entity_createTime ");
            strSql.Append(" FROM C_Entity ");
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
        public int GetRecordCount(CommonService.Model.C_Entity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Entity With(nolock) ");
            strSql.Append("where 1=1 and C_Entity_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Entity_identityName != null)
                {
                    strSql.Append("and C_Entity_identityName=@C_Entity_identityName ");
                }
                if (model.C_Entity_showName != null)
                {
                    strSql.Append(" and C_Entity_showName=@C_Entity_showName ");
                }
                if (model.C_Entity_tableName != null)
                {
                    strSql.Append("and C_Entity_tableName=@C_Entity_tableName ");
                }
            }
            SqlParameter[] parameters = {				 
					new SqlParameter("@C_Entity_identityName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Entity_showName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Entity_tableName", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.C_Entity_identityName;
            parameters[1].Value = model.C_Entity_showName;
            parameters[2].Value = model.C_Entity_tableName;

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
        public DataSet GetListByPage(CommonService.Model.C_Entity model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Entity_Id asc ");
            }
            strSql.Append(")AS Row, T.* from C_Entity AS T With(nolock) ");

            strSql.Append(" where 1=1 and T.C_Entity_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Entity_identityName != null)
                {
                    strSql.Append("and C_Entity_identityName=@C_Entity_identityName ");
                }
                if (model.C_Entity_showName != null)
                {
                    strSql.Append(" and C_Entity_showName=@C_Entity_showName ");
                }
                if (model.C_Entity_tableName != null)
                {
                    strSql.Append("and C_Entity_tableName=@C_Entity_tableName ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {				 
					new SqlParameter("@C_Entity_identityName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Entity_showName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Entity_tableName", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.C_Entity_identityName;
            parameters[1].Value = model.C_Entity_showName;
            parameters[2].Value = model.C_Entity_tableName;
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
            parameters[0].Value = "C_Entity";
            parameters[1].Value = "C_Entity_Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 根据名称得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Entity GetModelByName(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Entity_Id,C_Entity_code,C_Entity_identityName,C_Entity_showName,C_Entity_tableName,C_Entity_business_relFieldName,C_Entity_business_showFieldName,C_Entity_isDelete,C_Entity_creator,C_Entity_createTime from C_Entity ");
            strSql.Append(" where C_Entity_tableName=@C_Entity_tableName");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Entity_tableName", SqlDbType.VarChar)
			};
            parameters[0].Value = tableName;

            CommonService.Model.C_Entity model = new CommonService.Model.C_Entity();
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
        /// 获取自定义数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetCustomTable(string id, string name, string tableName, string searchName, int startIndex, int endIndex)
        {
            StringBuilder sql = new StringBuilder();
            if (tableName.ToLower() == "c_userinfo")
            {
                sql.Append("select C_Userinfo_code,C_Userinfo_name  from C_Userinfo  where C_Userinfo_isDelete=0 and C_Userinfo_state=1  ");
            }
            else if (tableName.ToLower() == "c_userinfo_main_lawyer")
            {
                sql.Append("select C_Userinfo_code,C_Userinfo_name  from C_Userinfo  where C_Userinfo_isDelete=0 and C_Userinfo_state=1 ");
            }
            else
            {
                sql.Append("select " + id + "," + name + " from " + tableName + " where 1=1 ");
            }
            if (searchName != "1=1")
            {
                sql.Append("and " + name + " like N'%'+@searchName+'%' ");
            }

            #region 根据不同的实体表名，处理不同的固定条件；目前采用写死的做法
            if (tableName.ToLower() == "c_judge")
            {//法官实体
                sql.Append("and C_Judge_isdelete=0 ");
            }
            else if (tableName.ToLower() == "c_court")
            {//法院实体
                sql.Append("and C_Court_isdelete=0 ");
            }
            else if (tableName.ToLower() == "c_region")
            {//区域实体
                sql.Append("and C_Region_isDelete=0 and C_Region_isSpecial=0 ");
            }
            else if (tableName.ToLower() == "c_involved_project")
            {//工程实体
                sql.Append("and C_Involved_project_isDelete=0 ");
            }
            else if (tableName.ToLower() == "c_organization")
            {//组织机构实体
                sql.Append("and C_Organization_isDelete=0 and C_Organization_state=1 ");
            }
            else if (tableName.ToLower() == "c_userinfo")
            {//人员实体
                sql.Append("and C_Userinfo_isDelete=0 and C_Userinfo_state=1 ");
            }
            else if (tableName.ToLower() == "c_userinfo_main_lawyer")
            {//人员实体
                sql.Append("and C_Userinfo_isDelete=0 and C_Userinfo_state=1 ");
            }
            else if (tableName.ToLower() == "c_parameters")
            {//参数实体
                sql.Append("and C_Parameters_isDelete=0 ");
            }

            #endregion

            sql.Append(" order by " + name);
            sql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);

            SqlParameter[] parameters = {
                    new SqlParameter("@searchName",SqlDbType.VarChar)
			};
            parameters[0].Value = searchName;
            return DbHelperSQL.Query(sql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}
