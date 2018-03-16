using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:岗位表
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class C_Post
	{
		public C_Post()
        { }
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Post_id", "C_Post");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Post_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Post");
            strSql.Append(" where C_Post_id=@C_Post_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Post_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.SysManager.C_Post model)
		{
            StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into C_Post(");
            strSql.Append("C_Post_code,C_Post_group,C_Post_name,C_Post_creator,C_Post_createTime,C_Post_isDelete)");
			strSql.Append(" values (");
            strSql.Append("@C_Post_code,@C_Post_group,@C_Post_name,@C_Post_creator,@C_Post_createTime,@C_Post_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_group", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Post_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Post_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Post_code;
            parameters[1].Value = model.C_Post_group;
			parameters[2].Value = model.C_Post_name;
            parameters[3].Value = model.C_Post_creator;
			parameters[4].Value = model.C_Post_createTime;
			parameters[5].Value = model.C_Post_isDelete;

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
        public bool Update(CommonService.Model.SysManager.C_Post model)
		{
            StringBuilder strSql = new StringBuilder();
			strSql.Append("update C_Post set ");
			strSql.Append("C_Post_code=@C_Post_code,");
            strSql.Append("C_Post_group=@C_Post_group,");
			strSql.Append("C_Post_name=@C_Post_name,");
			strSql.Append("C_Post_creator=@C_Post_creator,");
			strSql.Append("C_Post_createTime=@C_Post_createTime,");
			strSql.Append("C_Post_isDelete=@C_Post_isDelete");
			strSql.Append(" where C_Post_id=@C_Post_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_group", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Post_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Post_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Post_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Post_code;
            parameters[1].Value = model.C_Post_group;
			parameters[2].Value = model.C_Post_name;
			parameters[3].Value = model.C_Post_creator;
			parameters[4].Value = model.C_Post_createTime;
			parameters[5].Value = model.C_Post_isDelete;
			parameters[6].Value = model.C_Post_id;

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
		public bool Delete(int C_Post_id)
		{
			
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Post set C_Post_isDelete=1 ");
			strSql.Append(" where C_Post_id=@C_Post_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Post_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Post_id;

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
        public bool DeleteList(string C_Post_idlist)
		{
            StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from C_Post ");
            strSql.Append(" where C_Post_id in (" + C_Post_idlist + ")  ");
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
		/// 根据岗位code得到一个对象实体 链接分组表
		/// </summary>
        public CommonService.Model.SysManager.C_Post GetLinkRolesModel(Guid C_Post_code)
		{
			
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 1 C_Post_id,C_Post_code,C_Post_group,C_Post_name,C_Post_creator,C_Post_createTime, C_Post_isDelete,G.C_Roles_id As C_Post_Roles_id from C_Post As P left join C_Group As G on  P.C_Post_group=G.C_Group_code ");
            strSql.Append(" where P.C_Post_code=@C_Post_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Post_code;

            CommonService.Model.SysManager.C_Post model = new CommonService.Model.SysManager.C_Post();
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
        public CommonService.Model.SysManager.C_Post GetModel(int C_Post_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Post_id,C_Post_code,C_Post_group,C_Post_name,C_Post_creator,C_Post_createTime,C_Post_isDelete from C_Post ");
            strSql.Append(" where C_Post_id=@C_Post_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Post_id;

            CommonService.Model.SysManager.C_Post model = new CommonService.Model.SysManager.C_Post();
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
        /// 通过岗位Guid，得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Post GetModelByPostCode(Guid postCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Post_id,C_Post_code,C_Post_group,C_Post_name,C_Post_creator,C_Post_createTime,C_Post_isDelete from C_Post ");
            strSql.Append(" where C_Post_code=@C_Post_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = postCode;

            CommonService.Model.SysManager.C_Post model = new CommonService.Model.SysManager.C_Post();
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
        public CommonService.Model.SysManager.C_Post DataRowToModel(DataRow row)
		{
            CommonService.Model.SysManager.C_Post model = new CommonService.Model.SysManager.C_Post();
			if (row != null)
			{
                if (row["C_Post_id"] != null && row["C_Post_id"].ToString() != "")
				{
                    model.C_Post_id = int.Parse(row["C_Post_id"].ToString());
				}
                if (row["C_Post_code"] != null && row["C_Post_code"].ToString() != "")
				{
                    model.C_Post_code = new Guid(row["C_Post_code"].ToString());
				}
                if (row["C_Post_group"] != null && row["C_Post_group"].ToString() != "")
				{
                    model.C_Post_group = new Guid(row["C_Post_group"].ToString());
				}
                if (row["C_Post_name"] != null)
				{
                    model.C_Post_name = row["C_Post_name"].ToString();
				}
                if (row["C_Post_creator"] != null && row["C_Post_creator"].ToString() != "")
				{
                    model.C_Post_creator = new Guid(row["C_Post_creator"].ToString());
				}
                if (row["C_Post_createTime"] != null && row["C_Post_createTime"].ToString() != "")
				{
                    model.C_Post_createTime = DateTime.Parse(row["C_Post_createTime"].ToString());
				}
                if (row["C_Post_isDelete"] != null && row["C_Post_isDelete"].ToString() != "")
				{
                    model.C_Post_isDelete = int.Parse(row["C_Post_isDelete"].ToString());
				}
                //检查角色是否存在表中
                if (row.Table.Columns.Contains("C_Post_Roles_id"))
                {
                    if (row["C_Post_Roles_id"] != null && row["C_Post_Roles_id"].ToString() != "")
                    {
                        model.C_Post_Roles_id = int.Parse(row["C_Post_Roles_id"].ToString());
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
            strSql.Append("select C_Post_id,C_Post_code,C_Post_group,C_Post_name,C_Post_creator,C_Post_createTime,C_Post_isDelete ");
            strSql.Append(" FROM C_Post ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Post_id,C_Post_code,C_Post_group,C_Post_name,C_Post_creator,C_Post_createTime,C_Post_isDelete ");
            strSql.Append(" FROM C_Post where C_Post_isDelete=0 ");

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
            strSql.Append(" C_Post_id,C_Post_code,C_Post_group,C_Post_name,C_Post_creator,C_Post_createTime,C_Post_isDelete ");
			strSql.Append(" FROM C_Post ");
            if (strWhere.Trim() != "")
			{
                strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 得到所有岗位集合
        /// </summary>
        /// <returns></returns>        
        public DataSet GetAllPosts()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM C_Post with(nolock) ");
            strSql.Append("where C_Post_isDelete=0 ");

            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
        public int GetRecordCount(Model.SysManager.C_Post model)
		{
            StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM C_Post ");
            strSql.Append(" where 1=1 and C_Post_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Post_code != null && model.C_Post_code.ToString() != "")
                {
                    strSql.Append(" and C_Post_code=@C_Post_code ");
                }
                if (model.C_Post_name != null && model.C_Post_name != "")
                {
                    strSql.Append(" and C_Post_name like N'%'+@C_Post_name+'%' ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_name", SqlDbType.VarChar,50)};
            parameters[0].Value = model.C_Post_code;
            parameters[1].Value = model.C_Post_name;
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
        public DataSet GetListByPage(Model.SysManager.C_Post model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Post_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_Post T ");
            strSql.Append(" where 1=1 and C_Post_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Post_code != null && model.C_Post_code.ToString() != "")
                {
                    strSql.Append(" and C_Post_code=@C_Post_code ");
                }
                if (model.C_Post_name != null && model.C_Post_name != "")
                {
                    strSql.Append(" and C_Post_name like N'%'+@C_Post_name+'%' ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_name", SqlDbType.VarChar,50)};
            parameters[0].Value = model.C_Post_code;
            parameters[1].Value = model.C_Post_name;
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
			parameters[0].Value = "C_Post";
			parameters[1].Value = "C_Post_id";
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

