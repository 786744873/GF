using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:参数表
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Parameters
    {
        public C_Parameters()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Parameters_id", "C_Parameters");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Parameters_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Parameters");
            strSql.Append(" where C_Parameters_id=@C_Parameters_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Parameters_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Parameters model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Parameters(");
            strSql.Append("C_Parameters_name,C_Parameters_abbreviation,C_Parameters_order,C_Parameters_parent,C_Parameters_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@C_Parameters_name,@C_Parameters_abbreviation,@C_Parameters_order,@C_Parameters_parent,@C_Parameters_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Parameters_abbreviation",SqlDbType.VarChar,50),
					new SqlParameter("@C_Parameters_order", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_parent", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Parameters_name;
            parameters[1].Value = model.C_Parameters_abbreviation;
            parameters[2].Value = model.C_Parameters_order;
            parameters[3].Value = model.C_Parameters_parent;
            parameters[4].Value = model.C_Parameters_isDelete;

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
        public bool Update(CommonService.Model.C_Parameters model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Parameters set ");
            strSql.Append("C_Parameters_name=@C_Parameters_name,");
            strSql.Append("C_Parameters_abbreviation=@C_Parameters_abbreviation,");
            strSql.Append("C_Parameters_order=@C_Parameters_order,");
            strSql.Append("C_Parameters_parent=@C_Parameters_parent,");
            strSql.Append("C_Parameters_isDelete=@C_Parameters_isDelete");
            strSql.Append(" where C_Parameters_id=@C_Parameters_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Parameters_abbreviation",SqlDbType.VarChar,50),
					new SqlParameter("@C_Parameters_order", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_parent", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Parameters_name;
            parameters[1].Value = model.C_Parameters_abbreviation;
            parameters[2].Value = model.C_Parameters_order;
            parameters[3].Value = model.C_Parameters_parent;
            parameters[4].Value = model.C_Parameters_isDelete;
            parameters[5].Value = model.C_Parameters_id;

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
        public bool Delete(int C_Parameters_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Parameters set C_Parameters_isDelete=1 ");
            strSql.Append(" where C_Parameters_id=@C_Parameters_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Parameters_id;

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
        public bool DeleteList(string C_Parameters_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Parameters ");
            strSql.Append(" where C_Parameters_id in (" + C_Parameters_idlist + ")  ");
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
        public CommonService.Model.C_Parameters GetModel(int C_Parameters_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Parameters_id,C_Parameters_name,C_Parameters_abbreviation,C_Parameters_order,C_Parameters_parent,C_Parameters_isDelete,'' AS C_Parameters_parent_name from C_Parameters ");
            strSql.Append(" where C_Parameters_id=@C_Parameters_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Parameters_id;

            CommonService.Model.C_Parameters model = new CommonService.Model.C_Parameters();
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
        /// 得到一个对象实体,
        /// <param name="relationId">1，财产权利  2，收款分类</param>
        /// </summary>
        public CommonService.Model.C_Parameters GetModelByRelationId(int C_Parameters_id, int relationId)
        {

            StringBuilder strSql = new StringBuilder();
            if (relationId == 1)
            {//财产权利
                strSql.Append("select  top 1 C_Parameters_id,C_Parameters_name,C_Parameters_abbreviation,C_Parameters_order,C_Parameters_parent,C_Parameters_isDelete,'' as C_Parameters_parent_name ");
                strSql.Append("from C_Parameters ");
                strSql.Append("where C_Parameters_parent=@C_Parameters_id and C_Parameters_name like '%财产权利%' ");
            }
            else if (relationId == 2)
            {//收款分类
                strSql.Append("select  top 1 C_Parameters_id,C_Parameters_name,C_Parameters_abbreviation,C_Parameters_order,C_Parameters_parent,C_Parameters_isDelete,'' as C_Parameters_parent_name ");
                strSql.Append("from C_Parameters ");
                strSql.Append("where C_Parameters_parent=@C_Parameters_id and C_Parameters_name like '%收款分类%' ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Parameters_id;

            CommonService.Model.C_Parameters model = new CommonService.Model.C_Parameters();
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
        /// 得到一个对象实体,
        /// <param name="relationId">根据父级ID和名称会的对象实体</param>
        /// </summary>
        public CommonService.Model.C_Parameters GetModelByParmentname(int C_Parameters_id, string C_parmeters_name)
        {

            StringBuilder strSql = new StringBuilder();
            //诉讼请求
            strSql.Append("select  top 1 C_Parameters_id,C_Parameters_name,C_Parameters_abbreviation,C_Parameters_order,C_Parameters_parent,C_Parameters_isDelete,'' as C_Parameters_parent_name ");
            strSql.Append("from C_Parameters ");
            strSql.Append("where C_Parameters_parent=@C_Parameters_id and C_Parameters_name like '%" + C_parmeters_name + "--诉讼请求%'");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Parameters_id;

            CommonService.Model.C_Parameters model = new CommonService.Model.C_Parameters();
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
        public CommonService.Model.C_Parameters DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Parameters model = new CommonService.Model.C_Parameters();
            if (row != null)
            {
                if (row["C_Parameters_id"] != null && row["C_Parameters_id"].ToString() != "")
                {
                    model.C_Parameters_id = int.Parse(row["C_Parameters_id"].ToString());
                }
                if (row["C_Parameters_name"] != null)
                {
                    model.C_Parameters_name = row["C_Parameters_name"].ToString();
                }
                if (row["C_Parameters_abbreviation"] != null)
                {
                    model.C_Parameters_abbreviation = row["C_Parameters_abbreviation"].ToString();
                }
                if (row["C_Parameters_order"] != null && row["C_Parameters_order"].ToString() != "")
                {
                    model.C_Parameters_order = int.Parse(row["C_Parameters_order"].ToString());
                }
                if (row["C_Parameters_parent"] != null && row["C_Parameters_parent"].ToString() != "")
                {
                    model.C_Parameters_parent = int.Parse(row["C_Parameters_parent"].ToString());
                }
                //检查父级参数名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Parameters_parent_name"))
                {
                    if (row["C_Parameters_parent_name"] != null)
                    {
                        model.C_Parameters_parent_name = row["C_Parameters_parent_name"].ToString();
                    }
                }
                if (row["C_Parameters_isDelete"] != null && row["C_Parameters_isDelete"].ToString() != "")
                {
                    model.C_Parameters_isDelete = int.Parse(row["C_Parameters_isDelete"].ToString());
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
            strSql.Append("select C_Parameters_id,C_Parameters_name,C_Parameters_abbreviation,C_Parameters_order,C_Parameters_parent,C_Parameters_isDelete ");
            strSql.Append(" FROM C_Parameters ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 通过父级ID，获取子集集合
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        public DataSet GetChildrenByParentId(int parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.*,'' AS C_Parameters_parent_name ");
            strSql.Append(" FROM C_Parameters AS T with(nolock) ");
            strSql.Append(" Where T.C_Parameters_isDelete=0 and C_Parameters_parent=@C_Parameters_parent ");
            strSql.Append(" Order By T.C_Parameters_order Asc");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Parameters_parent", SqlDbType.Int,4)
                                        };
            parameters[0].Value = parentId;

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
            strSql.Append(" C_Parameters_id,C_Parameters_name,C_Parameters_abbreviation,C_Parameters_order,C_Parameters_parent,C_Parameters_isDelete ");
            strSql.Append(" FROM C_Parameters ");
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
        public int GetRecordCount(Model.C_Parameters model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Parameters ");
            strSql.Append(" where 1=1 and C_Parameters_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Parameters_name != null && model.C_Parameters_name != "")
                {
                    strSql.Append(" and C_Parameters_name like N'%'+@C_Parameters_name+'%' ");
                }
                if (model.C_Parameters_parent != null)
                {
                    strSql.Append(" and C_Parameters_parent=@C_Parameters_parent");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Parameters_order", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_parent", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Parameters_name;
            parameters[1].Value = model.C_Parameters_order;
            parameters[2].Value = model.C_Parameters_parent;
            parameters[3].Value = model.C_Parameters_isDelete;
            parameters[4].Value = model.C_Parameters_id;
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
        public DataSet GetListByPage(Model.C_Parameters model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Parameters_id desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name AS C_Parameters_parent_name from C_Parameters T ");
            strSql.Append("left join C_Parameters as P with(nolock) on T.C_Parameters_parent=P.C_Parameters_id");
            strSql.Append(" where 1=1 and T.C_Parameters_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Parameters_name != null && model.C_Parameters_name != "")
                {
                    strSql.Append(" and T.C_Parameters_name like N'%'+@C_Parameters_name+'%' ");
                }
                if (model.C_Parameters_parent != null)
                {
                    strSql.Append(" and T.C_Parameters_parent=@C_Parameters_parent");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Parameters_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Parameters_order", SqlDbType.Int,4),
					new SqlParameter("@C_Parameters_parent", SqlDbType.Int,4),
                    new SqlParameter("@C_Parameters_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@C_Parameters_id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.C_Parameters_name;
            parameters[1].Value = model.C_Parameters_order;
            parameters[2].Value = model.C_Parameters_parent;
            parameters[3].Value = model.C_Parameters_isDelete;
            parameters[4].Value = model.C_Parameters_id;
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
            parameters[0].Value = "C_Parameters";
            parameters[1].Value = "C_Parameters_id";
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
        /// 根据父级ID获取所有子集参数
        /// </summary>
        /// <param name="parentID">父级ID</param>
        /// <returns>所有子集参数</returns>
        public DataSet GetParametersByParentID(int parentID)
        {
            string sql = "select * from C_Parameters where C_Parameters_parent=@parentID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@parentID",SqlDbType.Int,8)
            };
            para[0].Value = parentID;

            return DbHelperSQL.Query(sql, para);
        }

        #endregion  ExtensionMethod
    }
}

