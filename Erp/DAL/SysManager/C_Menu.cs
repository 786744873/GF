using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using CommonService.Common;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:菜单表
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Menu
    {
        public C_Menu()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Menu_id", "C_Menu");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Menu_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Menu");
            strSql.Append(" where C_Menu_id=@C_Menu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Menu_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Menu(");
            strSql.Append("C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Menu_name,@C_Menu_isDelete,@C_Menu_parent,@C_Menu_state,@C_Menu_image,@C_Menu_type,@C_Menu_order,@C_Menu_url,@C_Menu_creator,@C_Menu_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Menu_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Menu_parent", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_state", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_image", SqlDbType.VarChar,100),
					new SqlParameter("@C_Menu_type", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_order", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_url", SqlDbType.VarChar,100),
                    new SqlParameter("@C_Menu_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Menu_createTime",SqlDbType.DateTime)};
            parameters[0].Value = model.C_Menu_name;
            parameters[1].Value = model.C_Menu_isDelete;
            parameters[2].Value = model.C_Menu_parent;
            parameters[3].Value = model.C_Menu_state;
            parameters[4].Value = model.C_Menu_image;
            parameters[5].Value = model.C_Menu_type;
            parameters[6].Value = model.C_Menu_order;
            parameters[7].Value = model.C_Menu_url;
            parameters[8].Value = model.C_Menu_creator;
            parameters[9].Value = model.C_Menu_createTime;

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
        public bool Update(CommonService.Model.SysManager.C_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Menu set ");
            strSql.Append("C_Menu_name=@C_Menu_name,");
            strSql.Append("C_Menu_isDelete=@C_Menu_isDelete,");
            strSql.Append("C_Menu_parent=@C_Menu_parent,");
            strSql.Append("C_Menu_state=@C_Menu_state,");
            strSql.Append("C_Menu_image=@C_Menu_image,");
            strSql.Append("C_Menu_type=@C_Menu_type,");
            strSql.Append("C_Menu_order=@C_Menu_order,");
            strSql.Append("C_Menu_url=@C_Menu_url,");
            strSql.Append("C_Menu_creator=@C_Menu_creator,");
            strSql.Append("C_Menu_createTime=@C_Menu_createTime");
            strSql.Append(" where C_Menu_id=@C_Menu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Menu_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Menu_parent", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_state", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_image", SqlDbType.VarChar,100),
					new SqlParameter("@C_Menu_type", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_order", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_url", SqlDbType.VarChar,100),
                    new SqlParameter("@C_Menu_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Menu_createTime",SqlDbType.DateTime),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Menu_name;
            parameters[1].Value = model.C_Menu_isDelete;
            parameters[2].Value = model.C_Menu_parent;
            parameters[3].Value = model.C_Menu_state;
            parameters[4].Value = model.C_Menu_image;
            parameters[5].Value = model.C_Menu_type;
            parameters[6].Value = model.C_Menu_order;
            parameters[7].Value = model.C_Menu_url;
            parameters[8].Value = model.C_Menu_creator;
            parameters[9].Value = model.C_Menu_createTime;
            parameters[10].Value = model.C_Menu_id;

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
        public bool Delete(int C_Menu_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Menu set C_Menu_isDelete=1 ");
            strSql.Append(" where C_Menu_id=@C_Menu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Menu_id;

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
        public bool DeleteList(string C_Menu_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Menu ");
            strSql.Append(" where C_Menu_id in (" + C_Menu_idlist + ")  ");
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
        public CommonService.Model.SysManager.C_Menu GetModel(int C_Menu_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime from C_Menu ");
            strSql.Append(" where C_Menu_id=@C_Menu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Menu_id;

            CommonService.Model.SysManager.C_Menu model = new CommonService.Model.SysManager.C_Menu();
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
        public CommonService.Model.SysManager.C_Menu GetModel(ConditonType conditionType,int orderBy,int? parentMenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime from C_Menu ");
            strSql.Append(" where 1=1 ");
            if (parentMenuId != null)
            {
                strSql.Append("and C_Menu_parent=@C_Menu_parent "); 
            }
            strSql.Append("and C_Menu_isDelete=0 ");
            switch (conditionType)
            {
                case ConditonType.小于:
                    strSql.Append("and C_Menu_order<@C_Menu_order ");
                    strSql.Append("order by C_Menu_order Desc ");
                    break;
                case ConditonType.大于:
                    strSql.Append("and C_Menu_order>@C_Menu_order ");
                    strSql.Append("order by C_Menu_order Asc ");
                    break;
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_parent", SqlDbType.Int,4),
                    new SqlParameter("@C_Menu_order",SqlDbType.Int,4)
			};
            parameters[0].Value = parentMenuId;
            parameters[1].Value = orderBy;

            CommonService.Model.SysManager.C_Menu model = new CommonService.Model.SysManager.C_Menu();
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
        /// 获取父级排序列最大的实体对象
        /// </summary>
        public CommonService.Model.SysManager.C_Menu GetMaxOrderModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime from C_Menu ");
            strSql.Append(" where C_Menu_parent=0 ");
            strSql.Append(" order by C_Menu_order desc");

            CommonService.Model.SysManager.C_Menu model = new CommonService.Model.SysManager.C_Menu();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        /// 通过父亲获取父亲下排序列最大的实体对象
        /// </summary>
        public CommonService.Model.SysManager.C_Menu GetMaxOrderModelByParent(int parent_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime from C_Menu ");
            strSql.Append(" where C_Menu_parent=@C_Menu_parent ");
            strSql.Append(" order by C_Menu_order desc");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_parent", SqlDbType.Int,4)
			};
            parameters[0].Value = parent_Id;

            CommonService.Model.SysManager.C_Menu model = new CommonService.Model.SysManager.C_Menu();
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
        public CommonService.Model.SysManager.C_Menu DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Menu model = new CommonService.Model.SysManager.C_Menu();
            if (row != null)
            {
                if (row["C_Menu_id"] != null && row["C_Menu_id"].ToString() != "")
                {
                    model.C_Menu_id = int.Parse(row["C_Menu_id"].ToString());
                }
                if (row["C_Menu_name"] != null)
                {
                    model.C_Menu_name = row["C_Menu_name"].ToString();
                }
                if (row["C_Menu_isDelete"] != null && row["C_Menu_isDelete"].ToString() != "")
                {
                    if ((row["C_Menu_isDelete"].ToString() == "1") || (row["C_Menu_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Menu_isDelete = true;
                    }
                    else
                    {
                        model.C_Menu_isDelete = false;
                    }
                }
                if (row["C_Menu_parent"] != null && row["C_Menu_parent"].ToString() != "")
                {
                    model.C_Menu_parent = int.Parse(row["C_Menu_parent"].ToString());
                }
                if (row["C_Menu_state"] != null && row["C_Menu_state"].ToString() != "")
                {
                    model.C_Menu_state = int.Parse(row["C_Menu_state"].ToString());
                }
                if (row["C_Menu_image"] != null)
                {
                    model.C_Menu_image = row["C_Menu_image"].ToString();
                }
                if (row["C_Menu_type"] != null && row["C_Menu_type"].ToString() != "")
                {
                    model.C_Menu_type = int.Parse(row["C_Menu_type"].ToString());
                }
                if (row["C_Menu_order"] != null && row["C_Menu_order"].ToString() != "")
                {
                    model.C_Menu_order = int.Parse(row["C_Menu_order"].ToString());
                }
                if (row["C_Menu_url"] != null)
                {
                    model.C_Menu_url = row["C_Menu_url"].ToString();
                }
                if (row["C_Menu_creator"] != null && row["C_Menu_creator"].ToString() != "")
                {
                    model.C_Menu_creator=new Guid(row["C_Menu_creator"].ToString());
                }
                if (row["C_Menu_createTime"] != null && row["C_Menu_createTime"].ToString() != "")
                {
                    model.C_Menu_createTime = DateTime.Parse(row["C_Menu_createTime"].ToString());
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
            strSql.Append("select C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime ");
            strSql.Append(" FROM C_Menu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 通过父级机构Id，获取子集机构集合
        /// </summary>
        /// <returns></returns>
        public DataSet GetModelByParent(int parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime ");
            strSql.Append("from C_Menu WITH(NOLOCK) ");
            strSql.Append("where C_Menu_parent=@C_Menu_parent ");
            strSql.Append("and C_Menu_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_parent", SqlDbType.Int,4)
			};
            parameters[0].Value = parentId;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 通过角色，获取角色管理所有菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="isSysManager">是否内置系统管理员</param>
        /// <returns></returns>
        public DataSet GetModelListByRole(int? roleId, bool isSysManager)
        {
            /*
             * author:hety
             * date:2015-06-15
             * description:
             * (1)、如果当前登录用户为"内置系统管理员"账号时，加载所有菜单；否则按角色关联的菜单进行加载
             * */
            StringBuilder strSql = new StringBuilder();

            if (!isSysManager)
            {
                strSql.Append("select M.* ");
                strSql.Append("from C_Menu As M WITH(NOLOCK),C_Role_menu As RM WITH(NOLOCK) ");
                strSql.Append("where M.C_Menu_id=RM.C_Menu_id ");
                strSql.Append("and RM.C_Roles_id=@C_Roles_id ");
                strSql.Append("and M.C_Menu_isDelete=0 ");
                strSql.Append("and M.C_Menu_state=1 ");
            }
            else
            {
                strSql.Append("select M.* ");
                strSql.Append("from C_Menu As M WITH(NOLOCK) ");
                strSql.Append("where M.C_Menu_isDelete=0 ");
                strSql.Append("and M.C_Menu_state=1 ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4)
			    };
            parameters[0].Value = roleId;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
        /// <summary>
        /// 根据用户角色获得用户菜单集合
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="isSysManager"></param>
        /// <returns></returns>
        public DataSet GetMenuListByRoles(Guid userCode, bool isSysManager)
        {
            StringBuilder strSql = new StringBuilder();
            /***
             * 如果是管理员加载所用菜单
             * 如果不是管理员，则根据用户角色来获得对应的菜单，并去掉重复项
             * cyj
             * **/
            if (!isSysManager)
            {
                strSql.Append("select C.* from C_Menu As C ");
                strSql.Append("where exists(select 1 from C_Organization_post_user_role OPUS,C_Role_menu As RM where OPUS.C_Organization_post_user_role_isDelete= 0 and OPUS.C_User_code=@C_User_code  ");
                strSql.Append("and OPUS.C_Role_id=RM.C_Roles_id and C.C_Menu_id=RM.C_Menu_id) ");
            }
            else
            {
                strSql.Append("select M.* ");
                strSql.Append("from C_Menu As M WITH(NOLOCK) ");
                strSql.Append("where M.C_Menu_isDelete=0 ");
                strSql.Append("and M.C_Menu_state=1 ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = userCode;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            return ds;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime ");
            strSql.Append(" FROM C_Menu ");
            strSql.Append("where C_Menu_isDelete=0 ");
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
            strSql.Append(" C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url,C_Menu_creator,C_Menu_createTime ");
            strSql.Append(" FROM C_Menu ");
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
        public int GetRecordCount(Model.SysManager.C_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Menu ");
            strSql.Append(" where 1=1 and C_Menu_isDelete=0 ");
            if (model != null)
            {

                if (model.C_Menu_name != null && model.C_Menu_name != "")
                {
                    strSql.Append(" and C_Menu_name=@C_Menu_name");
                }
                if (model.C_Menu_parent != null)
                {
                    strSql.Append(" and C_Menu_parent=@C_Menu_parent");
                }
                if (model.C_Menu_state != null)
                {
                    strSql.Append(" and C_Menu_state=@C_Menu_state");
                }
                if (model.C_Menu_type != null)
                {
                    strSql.Append(" and C_Menu_type=@C_Menu_type");
                }

            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Menu_parent", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_state", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_type", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Menu_name;
            parameters[1].Value = model.C_Menu_parent;
            parameters[2].Value = model.C_Menu_state;
            parameters[3].Value = model.C_Menu_type;
            parameters[4].Value = model.C_Menu_id;
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
        public DataSet GetListByPage(Model.SysManager.C_Menu model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Menu_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Menu T ");
            strSql.Append(" where 1=1 and C_Menu_isDelete=0 ");
            if (model != null)
            {

                if (model.C_Menu_name != null && model.C_Menu_name != "")
                {
                    strSql.Append(" and C_Menu_name=@C_Menu_name");
                }
                if (model.C_Menu_parent != null)
                {
                    strSql.Append(" and C_Menu_parent=@C_Menu_parent");
                }
                if (model.C_Menu_state != null)
                {
                    strSql.Append(" and C_Menu_state=@C_Menu_state");
                }
                if (model.C_Menu_type != null)
                {
                    strSql.Append(" and C_Menu_type=@C_Menu_type");
                }

            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Menu_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Menu_parent", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_state", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_type", SqlDbType.Int,4),
					new SqlParameter("@C_Menu_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Menu_name;
            parameters[1].Value = model.C_Menu_parent;
            parameters[2].Value = model.C_Menu_state;
            parameters[3].Value = model.C_Menu_type;
            parameters[4].Value = model.C_Menu_id;
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
            parameters[0].Value = "C_Menu";
            parameters[1].Value = "C_Menu_id";
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
        /// 根据角色获取菜单
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>菜单列表</returns>
        public DataSet GetMenusByRoleID(int roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Menu_id,C_Menu_name,C_Menu_isDelete,C_Menu_parent,C_Menu_state,C_Menu_image,C_Menu_type,C_Menu_order,C_Menu_url ");
            strSql.Append(" FROM C_Menu where C_Menu_id in(select C_Menu_id from C_Role_menu where C_Roles_id=@C_Roles_id)");
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@C_Roles_id",SqlDbType.Int,4)
            };
            return DbHelperSQL.Query(strSql.ToString(), para);
        }
        #endregion  ExtensionMethod
    }
}

