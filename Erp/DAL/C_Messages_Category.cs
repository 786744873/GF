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
    /// 数据访问类:消息--分类中间表
    /// 作者：贺太玉
    /// 日期：2015/12/07
    /// </summary>
    public partial class C_Messages_Category
    {
        public C_Messages_Category()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Messages_Category_id", "C_Messages_Category");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Messages_Category_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Messages_Category");
            strSql.Append(" where C_Messages_Category_id=@C_Messages_Category_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_Category_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Messages_Category_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Messages_Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Messages_Category(");
            strSql.Append("C_Messages_Category_code,C_Messages_Category_bigClass,C_Messages_Category_smallClass,C_Messages_Category_type,C_Messages_Category_level,C_Messages_Category_isLeaf,C_Messages_Category_parent,C_Messages_Category_sort,C_Messages_Category_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@C_Messages_Category_code,@C_Messages_Category_bigClass,@C_Messages_Category_smallClass,@C_Messages_Category_type,@C_Messages_Category_level,@C_Messages_Category_isLeaf,@C_Messages_Category_parent,@C_Messages_Category_sort,@C_Messages_Category_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_Category_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Messages_Category_bigClass", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_smallClass", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_type", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_level", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_isLeaf", SqlDbType.Bit,1),
					new SqlParameter("@C_Messages_Category_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Messages_Category_sort", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.C_Messages_Category_code;
            parameters[1].Value = model.C_Messages_Category_bigClass;
            parameters[2].Value = model.C_Messages_Category_smallClass;
            parameters[3].Value = model.C_Messages_Category_type;
            parameters[4].Value = model.C_Messages_Category_level;
            parameters[5].Value = model.C_Messages_Category_isLeaf;
            parameters[6].Value = model.C_Messages_Category_parent;
            parameters[7].Value = model.C_Messages_Category_sort;
            parameters[8].Value = model.C_Messages_Category_isDelete;

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
        public bool Update(CommonService.Model.C_Messages_Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Messages_Category set ");         
            strSql.Append("C_Messages_Category_bigClass=@C_Messages_Category_bigClass,");
            strSql.Append("C_Messages_Category_smallClass=@C_Messages_Category_smallClass,");
            strSql.Append("C_Messages_Category_type=@C_Messages_Category_type,");
            strSql.Append("C_Messages_Category_level=@C_Messages_Category_level,");
            strSql.Append("C_Messages_Category_isLeaf=@C_Messages_Category_isLeaf,");
            strSql.Append("C_Messages_Category_parent=@C_Messages_Category_parent,");
            strSql.Append("C_Messages_Category_sort=@C_Messages_Category_sort,");
            strSql.Append("C_Messages_Category_isDelete=@C_Messages_Category_isDelete ");
            strSql.Append("where C_Messages_Category_code=@C_Messages_Category_code");
            SqlParameter[] parameters = {					
					new SqlParameter("@C_Messages_Category_bigClass", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_smallClass", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_type", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_level", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_isLeaf", SqlDbType.Bit,1),
					new SqlParameter("@C_Messages_Category_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Messages_Category_sort", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_Category_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Messages_Category_code", SqlDbType.UniqueIdentifier,16)
                                        };
           
            parameters[0].Value = model.C_Messages_Category_bigClass;
            parameters[1].Value = model.C_Messages_Category_smallClass;
            parameters[2].Value = model.C_Messages_Category_type;
            parameters[3].Value = model.C_Messages_Category_level;
            parameters[4].Value = model.C_Messages_Category_isLeaf;
            parameters[5].Value = model.C_Messages_Category_parent;
            parameters[6].Value = model.C_Messages_Category_sort;
            parameters[7].Value = model.C_Messages_Category_isDelete;
            parameters[8].Value = model.C_Messages_Category_code;

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
        public bool Delete(int C_Messages_Category_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Messages_Category ");
            strSql.Append(" where C_Messages_Category_id=@C_Messages_Category_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_Category_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Messages_Category_id;

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
        public bool DeleteList(string C_Messages_Category_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Messages_Category ");
            strSql.Append(" where C_Messages_Category_id in (" + C_Messages_Category_idlist + ")  ");
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
        public CommonService.Model.C_Messages_Category GetModel(int C_Messages_Category_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Messages_Category_id,C_Messages_Category_code,C_Messages_Category_bigClass,C_Messages_Category_smallClass,C_Messages_Category_type,C_Messages_Category_level,C_Messages_Category_isLeaf,C_Messages_Category_parent,C_Messages_Category_sort,C_Messages_Category_isDelete from C_Messages_Category ");
            strSql.Append(" where C_Messages_Category_id=@C_Messages_Category_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_Category_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Messages_Category_id;

            CommonService.Model.C_Messages_Category model = new CommonService.Model.C_Messages_Category();
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
        public CommonService.Model.C_Messages_Category DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Messages_Category model = new CommonService.Model.C_Messages_Category();
            if (row != null)
            {
                if (row["C_Messages_Category_id"] != null && row["C_Messages_Category_id"].ToString() != "")
                {
                    model.C_Messages_Category_id = int.Parse(row["C_Messages_Category_id"].ToString());
                }
                if (row["C_Messages_Category_code"] != null && row["C_Messages_Category_code"].ToString() != "")
                {
                    model.C_Messages_Category_code = new Guid(row["C_Messages_Category_code"].ToString());
                }
                if (row["C_Messages_Category_bigClass"] != null && row["C_Messages_Category_bigClass"].ToString() != "")
                {
                    model.C_Messages_Category_bigClass = int.Parse(row["C_Messages_Category_bigClass"].ToString());
                }
                if (row["C_Messages_Category_smallClass"] != null && row["C_Messages_Category_smallClass"].ToString() != "")
                {
                    model.C_Messages_Category_smallClass = int.Parse(row["C_Messages_Category_smallClass"].ToString());
                }
                if (row["C_Messages_Category_type"] != null && row["C_Messages_Category_type"].ToString() != "")
                {
                    model.C_Messages_Category_type = int.Parse(row["C_Messages_Category_type"].ToString());
                }
                //消息类型名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Messages_Category_type_name"))
                {
                    if (row["C_Messages_Category_type_name"] != null)
                    {
                        model.C_Messages_Category_type_name = row["C_Messages_Category_type_name"].ToString();
                    }
                }
                if (row["C_Messages_Category_level"] != null && row["C_Messages_Category_level"].ToString() != "")
                {
                    model.C_Messages_Category_level = int.Parse(row["C_Messages_Category_level"].ToString());
                }
                if (row["C_Messages_Category_isLeaf"] != null && row["C_Messages_Category_isLeaf"].ToString() != "")
                {
                    if ((row["C_Messages_Category_isLeaf"].ToString() == "1") || (row["C_Messages_Category_isLeaf"].ToString().ToLower() == "true"))
                    {
                        model.C_Messages_Category_isLeaf = true;
                    }
                    else
                    {
                        model.C_Messages_Category_isLeaf = false;
                    }
                }
                if (row["C_Messages_Category_parent"] != null && row["C_Messages_Category_parent"].ToString() != "")
                {
                    model.C_Messages_Category_parent = new Guid(row["C_Messages_Category_parent"].ToString());
                }
                if (row["C_Messages_Category_sort"] != null && row["C_Messages_Category_sort"].ToString() != "")
                {
                    model.C_Messages_Category_sort = int.Parse(row["C_Messages_Category_sort"].ToString());
                }
                if (row["C_Messages_Category_isDelete"] != null && row["C_Messages_Category_isDelete"].ToString() != "")
                {
                    if ((row["C_Messages_Category_isDelete"].ToString() == "1") || (row["C_Messages_Category_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Messages_Category_isDelete = true;
                    }
                    else
                    {
                        model.C_Messages_Category_isDelete = false;
                    }
                }
                //消息数量(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Messages_Category_unreadcount"))
                {
                    model.C_Messages_Category_unreadcount = int.Parse(row["C_Messages_Category_unreadcount"].ToString());
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
            strSql.Append("select C_Messages_Category_id,C_Messages_Category_code,C_Messages_Category_bigClass,C_Messages_Category_smallClass,C_Messages_Category_type,C_Messages_Category_level,C_Messages_Category_isLeaf,C_Messages_Category_parent,C_Messages_Category_sort,C_Messages_Category_isDelete ");
            strSql.Append(" FROM C_Messages_Category ");
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
            strSql.Append(" C_Messages_Category_id,C_Messages_Category_code,C_Messages_Category_bigClass,C_Messages_Category_smallClass,C_Messages_Category_type,C_Messages_Category_level,C_Messages_Category_isLeaf,C_Messages_Category_parent,C_Messages_Category_sort,C_Messages_Category_isDelete ");
            strSql.Append(" FROM C_Messages_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据消息大类型，消息级别，获取消息头集合
        /// </summary>
        /// <param name="messageCategoryBigClass">消息大类型</param>
        /// <param name="messageCategoryLevel">消息级别</param>
        /// <param name="isPreSetManager">是否内置系统管理员</param>
        /// <param name="loginChildrenUser">当前登录子用户Guid</param>
        /// <returns></returns>
        public DataSet GetMessageHeads(int messageCategoryBigClass,int messageCategoryLevel,bool isPreSetManager, Guid? loginChildrenUser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MC.*,CategoryType.C_Parameters_name As C_Messages_Category_type_name,dbo.getUnReadMessageCount(@isPreSetManager,@loginChildrenUser,MC.C_Messages_Category_code) As C_Messages_Category_unreadcount ");  
            strSql.Append("from C_Messages_Category As MC with(nolock) ");
            strSql.Append("left join C_Parameters As CategoryType with(nolock) on MC.C_Messages_Category_type=CategoryType.C_Parameters_id ");
            strSql.Append("where MC.C_Messages_Category_isDelete=0 and MC.C_Messages_Category_bigClass=@C_Messages_Category_bigClass and MC.C_Messages_Category_level=@C_Messages_Category_level ");
            strSql.Append("order by MC.C_Messages_Category_sort Asc");
            SqlParameter[] parameters = {
                    new SqlParameter("@isPreSetManager", SqlDbType.Bit,1),
                    new SqlParameter("@loginChildrenUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Messages_Category_bigClass", SqlDbType.Int),
                    new SqlParameter("@C_Messages_Category_level", SqlDbType.Int)
            };
            parameters[0].Value = isPreSetManager;
            parameters[1].Value = loginChildrenUser;
            parameters[2].Value = messageCategoryBigClass;
            parameters[3].Value = messageCategoryLevel;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Messages_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Messages_Category_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Messages_Category T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "C_Messages_Category";
            parameters[1].Value = "C_Messages_Category_id";
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
