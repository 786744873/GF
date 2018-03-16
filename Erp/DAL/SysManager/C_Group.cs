using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:分组表
    /// 作者：崔慧栋
    /// 日期：2015/05/28
    /// </summary>
	public partial class C_Group
	{
		public C_Group()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Group_id", "C_Group");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Group_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Group");
            strSql.Append(" where C_Group_id=@C_Group_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Group_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Group_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.SysManager.C_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Group(");
            strSql.Append("C_Roles_id,C_Group_code,C_Group_name,C_Group_parent,C_Group_isDelete,C_Group_creator,C_Group_createTime)");
			strSql.Append(" values (");
            strSql.Append("@C_Roles_id,@C_Group_code,@C_Group_name,@C_Group_parent,@C_Group_isDelete,@C_Group_creator,@C_Group_createTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Group_code",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Group_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Group_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Group_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Group_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Group_createTime", SqlDbType.DateTime)};
			parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Group_code;
			parameters[2].Value = model.C_Group_name;
			parameters[3].Value = model.C_Group_parent;
			parameters[4].Value = model.C_Group_isDelete;
            parameters[5].Value = model.C_Group_creator;
			parameters[6].Value = model.C_Group_createTime;

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
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.SysManager.C_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Group set ");
			strSql.Append("C_Roles_id=@C_Roles_id,");
            strSql.Append("C_Group_code=@C_Group_code,");
			strSql.Append("C_Group_name=@C_Group_name,");
			strSql.Append("C_Group_parent=@C_Group_parent,");
			strSql.Append("C_Group_isDelete=@C_Group_isDelete,");
			strSql.Append("C_Group_creator=@C_Group_creator,");
			strSql.Append("C_Group_createTime=@C_Group_createTime");
			strSql.Append(" where C_Group_id=@C_Group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Roles_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Group_code",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Group_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Group_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Group_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Group_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Group_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Group_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Roles_id;
            parameters[1].Value = model.C_Group_code;
			parameters[2].Value = model.C_Group_name;
			parameters[3].Value = model.C_Group_parent;
			parameters[4].Value = model.C_Group_isDelete;
			parameters[5].Value = model.C_Group_creator;
			parameters[6].Value = model.C_Group_createTime;
			parameters[7].Value = model.C_Group_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(Guid C_Group_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Group set C_Group_isDelete=1 ");
            strSql.Append(" where C_Group_code=@C_Group_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Group_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Group_code;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string C_Group_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Group ");
			strSql.Append(" where C_Group_id in ("+C_Group_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public CommonService.Model.SysManager.C_Group GetModel(Guid C_Group_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 C_Group_id,C_Group_code,C_Roles_id,C_Group_name,C_Group_parent,C_Group_isDelete,C_Group_creator,C_Group_createTime from C_Group ");
            strSql.Append(" where C_Group_code=@C_Group_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Group_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Group_code;

            CommonService.Model.SysManager.C_Group model = new CommonService.Model.SysManager.C_Group();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public CommonService.Model.SysManager.C_Group GetModel(int C_Group_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Group_id,C_Group_code,C_Roles_id,C_Group_name,C_Group_parent,C_Group_isDelete,C_Group_creator,C_Group_createTime from C_Group ");
            strSql.Append(" where C_Group_id=@C_Group_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Group_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Group_id;

            CommonService.Model.SysManager.C_Group model = new CommonService.Model.SysManager.C_Group();
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
        public CommonService.Model.SysManager.C_Group GetModelByCode(Guid C_Group_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Group_id,C_Group_code,C_Roles_id,C_Group_name,C_Group_parent,C_Group_isDelete,C_Group_creator,C_Group_createTime from C_Group ");
            strSql.Append(" where C_Group_code=@C_Group_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Group_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Group_code;

            CommonService.Model.SysManager.C_Group model = new CommonService.Model.SysManager.C_Group();
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
        public CommonService.Model.SysManager.C_Group DataRowToModel(DataRow row)
		{
            CommonService.Model.SysManager.C_Group model = new CommonService.Model.SysManager.C_Group();
			if (row != null)
			{
				if(row["C_Group_id"]!=null && row["C_Group_id"].ToString()!="")
				{
					model.C_Group_id=int.Parse(row["C_Group_id"].ToString());
				}
                if (row["C_Group_code"] != null && row["C_Group_code"].ToString() != "")
                {
                    model.C_Group_code = new Guid(row["C_Group_code"].ToString());
                }
				if(row["C_Roles_id"]!=null && row["C_Roles_id"].ToString()!="")
				{
					model.C_Roles_id=int.Parse(row["C_Roles_id"].ToString());
				}
				if(row["C_Group_name"]!=null)
				{
					model.C_Group_name=row["C_Group_name"].ToString();
				}
				if(row["C_Group_parent"]!=null && row["C_Group_parent"].ToString()!="")
				{
					model.C_Group_parent=new Guid(row["C_Group_parent"].ToString());
				}
				if(row["C_Group_isDelete"]!=null && row["C_Group_isDelete"].ToString()!="")
				{
					model.C_Group_isDelete=int.Parse(row["C_Group_isDelete"].ToString());
				}
				if(row["C_Group_creator"]!=null && row["C_Group_creator"].ToString()!="")
				{
					model.C_Group_creator= new Guid(row["C_Group_creator"].ToString());
				}
				if(row["C_Group_createTime"]!=null && row["C_Group_createTime"].ToString()!="")
				{
					model.C_Group_createTime=DateTime.Parse(row["C_Group_createTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select C_Group_id,C_Group_code,C_Roles_id,C_Group_name,C_Group_parent,C_Group_isDelete,C_Group_creator,C_Group_createTime ");
			strSql.Append(" FROM C_Group ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据父级分组获得子集数据集合
        /// </summary>
        public DataSet GetListByParentCode(Guid C_Group_parent)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Group_id,C_Group_code,C_Roles_id,C_Group_name,C_Group_parent,C_Group_isDelete,C_Group_creator,C_Group_createTime ");
            strSql.Append(" FROM C_Group ");
            strSql.Append("where C_Group_parent=@C_Group_parent ");
            strSql.Append("and C_Group_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Group_parent", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = C_Group_parent;

            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Group_id,C_Group_code,C_Roles_id,C_Group_name,C_Group_parent,C_Group_isDelete,C_Group_creator,C_Group_createTime ");
            strSql.Append(" FROM C_Group where C_Group_isDelete=0 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

         /// <summary>
        /// 根据用户Guid获得用户关联岗位的所属分组
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public DataSet GetListByUserCode(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.C_Group_id,T.C_Group_code,T.C_Roles_id,T.C_Group_name,T.C_Group_parent,T.C_Group_isDelete,T.C_Group_creator,T.C_Group_createTime ");
            strSql.Append(" FROM C_Group as T where ");
            strSql.Append("T.C_Group_isDelete=0 ");
            strSql.Append("and exists(select 1 from C_Organization_post_user as OPU,C_Post as P where OPU.C_Organization_post_user_isDelete=0 and P.C_Post_isDelete=0 and P.C_Post_group=T.C_Group_code and OPU.C_Post_code=P.C_Post_code and OPU.C_User_code=@C_User_code)");
            SqlParameter[] parameters = {
					new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" C_Group_id,C_Group_code,C_Roles_id,C_Group_name,C_Group_parent,C_Group_isDelete,C_Group_creator,C_Group_createTime ");
			strSql.Append(" FROM C_Group ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(CommonService.Model.SysManager.C_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Group ");
            strSql.Append(" where 1=1 and C_Group_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Group_name != null && model.C_Group_name != "")
                {
                    strSql.Append(" and C_Group_name=@C_Group_name");
                }
                if (model.C_Group_parent != null && model.C_Group_parent.ToString() != "")
                {
                    strSql.Append(" and C_Group_parent=@C_Group_parent");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Group_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Group_parent", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Group_name;
            parameters[1].Value = model.C_Group_parent;
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
		public DataSet GetListByPage(CommonService.Model.SysManager.C_Group model, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.C_Group_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_Group T ");
            strSql.Append(" where 1=1 and C_Group_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Group_name != null && model.C_Group_name != "")
                {
                    strSql.Append(" and C_Group_name=@C_Group_name");
                }
                if (model.C_Group_parent != null && model.C_Group_parent.ToString() != "")
                {
                    strSql.Append(" and C_Group_parent=@C_Group_parent");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Group_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Group_parent", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Group_name;
            parameters[1].Value = model.C_Group_parent;
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
			parameters[0].Value = "C_Group";
			parameters[1].Value = "C_Group_id";
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

