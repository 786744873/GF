using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.FlowManager
{
    /// <summary>
    /// 数据访问类:流程表
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	public partial class P_Flow
	{
		public P_Flow()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("P_Flow_id", "P_Flow");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Flow_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Flow");
            strSql.Append(" where P_Flow_id=@P_Flow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Flow_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FlowManager.P_Flow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into P_Flow(");
            strSql.Append("P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor )");
			strSql.Append(" values (");
            strSql.Append("@P_Flow_code,@P_Flow_name,@P_Flow_type,@P_Flow_parent,@P_Flow_level,@P_Flow_creator,@P_Flow_createTime,@P_Flow_isDelete,@P_Flow_require,@P_Flow_order,@P_Flow_defaultDuration,@P_Flow_IsCrossForm,@P_Flow_ManagerType,@P_Flow_IsChiefCheck,@P_Flow_IsMonitor )");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_name", SqlDbType.VarChar,50),
					new SqlParameter("@P_Flow_type", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_level", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_createTime", SqlDbType.DateTime),
					new SqlParameter("@P_Flow_isDelete", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_require", SqlDbType.VarChar,500),
					new SqlParameter("@P_Flow_order", SqlDbType.Int,4),
                    new SqlParameter("@P_Flow_defaultDuration",SqlDbType.Int,4),
                    new SqlParameter("@P_Flow_IsCrossForm",SqlDbType.Bit,1),
                    new SqlParameter("@P_Flow_ManagerType",SqlDbType.Int,4),
                    new SqlParameter("@P_Flow_IsChiefCheck",SqlDbType.Bit),
                    new SqlParameter("@P_Flow_IsMonitor",SqlDbType.Bit)
                                        };
            parameters[0].Value = model.P_Flow_code;
			parameters[1].Value = model.P_Flow_name;
			parameters[2].Value = model.P_Flow_type;
            parameters[3].Value = model.P_Flow_parent;
			parameters[4].Value = model.P_Flow_level;
            parameters[5].Value = model.P_Flow_creator;
			parameters[6].Value = model.P_Flow_createTime;
			parameters[7].Value = model.P_Flow_isDelete;
			parameters[8].Value = model.P_Flow_require;
			parameters[9].Value = model.P_Flow_order;
            parameters[10].Value = model.P_Flow_defaultDuration;
            parameters[11].Value = model.P_Flow_IsCrossForm;
            parameters[12].Value = model.P_Flow_ManagerType;
            parameters[13].Value = model.P_Flow_IsChiefCheck;
            parameters[14].Value = model.P_Flow_IsMonitor;

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
        public bool Update(CommonService.Model.FlowManager.P_Flow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update P_Flow set ");
			strSql.Append("P_Flow_code=@P_Flow_code,");
			strSql.Append("P_Flow_name=@P_Flow_name,");
			strSql.Append("P_Flow_type=@P_Flow_type,");
			strSql.Append("P_Flow_parent=@P_Flow_parent,");
			strSql.Append("P_Flow_level=@P_Flow_level,");
			strSql.Append("P_Flow_creator=@P_Flow_creator,");
			strSql.Append("P_Flow_createTime=@P_Flow_createTime,");
			strSql.Append("P_Flow_isDelete=@P_Flow_isDelete,");
			strSql.Append("P_Flow_require=@P_Flow_require,");
			strSql.Append("P_Flow_order=@P_Flow_order,");
            strSql.Append("P_Flow_defaultDuration=@P_Flow_defaultDuration,");
            strSql.Append("P_Flow_IsCrossForm=@P_Flow_IsCrossForm, ");
            strSql.Append("P_Flow_ManagerType=@P_Flow_ManagerType, ");
            strSql.Append("P_Flow_IsChiefCheck=@P_Flow_IsChiefCheck, ");
            strSql.Append("P_Flow_IsMonitor=@P_Flow_IsMonitor ");
			strSql.Append(" where P_Flow_id=@P_Flow_id");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_name", SqlDbType.VarChar,50),
					new SqlParameter("@P_Flow_type", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_level", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_createTime", SqlDbType.DateTime),
					new SqlParameter("@P_Flow_isDelete", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_require", SqlDbType.VarChar,500),
					new SqlParameter("@P_Flow_order", SqlDbType.Int,4),
                    new SqlParameter("@P_Flow_defaultDuration",SqlDbType.Int,4),
                    new SqlParameter("@P_Flow_IsCrossForm",SqlDbType.Bit,1),
                    new SqlParameter("@P_Flow_ManagerType",SqlDbType.Int,4),
					new SqlParameter("@P_Flow_id", SqlDbType.Int,4),
                    new SqlParameter("@P_Flow_IsChiefCheck",SqlDbType.Bit),
                    new SqlParameter("@P_Flow_IsMonitor",SqlDbType.Bit)
                                        };
			parameters[0].Value = model.P_Flow_code;
			parameters[1].Value = model.P_Flow_name;
			parameters[2].Value = model.P_Flow_type;
			parameters[3].Value = model.P_Flow_parent;
			parameters[4].Value = model.P_Flow_level;
			parameters[5].Value = model.P_Flow_creator;
			parameters[6].Value = model.P_Flow_createTime;
			parameters[7].Value = model.P_Flow_isDelete;
			parameters[8].Value = model.P_Flow_require;
			parameters[9].Value = model.P_Flow_order;
            parameters[10].Value = model.P_Flow_defaultDuration;
            parameters[11].Value = model.P_Flow_IsCrossForm;
            parameters[12].Value = model.P_Flow_ManagerType;
			parameters[13].Value = model.P_Flow_id;
            parameters[14].Value = model.P_Flow_IsChiefCheck;
            parameters[15].Value = model.P_Flow_IsMonitor;

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
        public bool Delete(Guid P_Flow_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update P_Flow set P_Flow_isDelete=1 ");
            strSql.Append(" where P_Flow_code=@P_Flow_code");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Flow_code;

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
		public bool DeleteList(string P_Flow_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from P_Flow ");
			strSql.Append(" where P_Flow_id in ("+P_Flow_idlist + ")  ");
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
        public CommonService.Model.FlowManager.P_Flow GetModel(Guid P_Flow_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor from P_Flow ");
            strSql.Append(" where P_Flow_code=@P_Flow_code");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Flow_code;

            CommonService.Model.FlowManager.P_Flow model = new CommonService.Model.FlowManager.P_Flow();
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
        public CommonService.Model.FlowManager.P_Flow GetModel(int P_Flow_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck from,P_Flow_IsMonitor P_Flow ");
            strSql.Append(" where P_Flow_id=@P_Flow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Flow_id;

            CommonService.Model.FlowManager.P_Flow model = new CommonService.Model.FlowManager.P_Flow();
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
        /// 通过级别获取级别下排序列最大的实体对象
        /// </summary>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Flow GetMaxOrderModelByLevel(int level)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor from P_Flow ");
            strSql.Append(" where P_Flow_level=@P_Flow_level ");
            strSql.Append("order by P_Flow_order Desc");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_level", SqlDbType.Int,4)
			};
            parameters[0].Value = level;

            CommonService.Model.FlowManager.P_Flow model = new CommonService.Model.FlowManager.P_Flow();
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
        /// 通过父亲Guid获取父亲下排序列最大的实体对象
        /// </summary>
        /// <param name="parentCode">父亲Guid</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Flow GetMaxOrderModelByParent(Guid parentCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor ");
            strSql.Append("from P_Flow WITH(NOLOCK) ");
            strSql.Append("where P_Flow_parent=@P_Flow_parent ");
            strSql.Append("order by P_Flow_order Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parentCode;

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
        /// 通过父亲业务流程Guid，获取子集业务流程集合
        /// </summary>
        /// <param name="parentCode">父亲业务流程Guid</param>
        /// <returns></returns>
        public DataSet GetListByParentCode(Guid parentCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor ");
            strSql.Append("from P_Flow WITH(NOLOCK) ");
            strSql.Append("where P_Flow_parent=@P_Flow_parent and P_Flow_isDelete = 0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parentCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FlowManager.P_Flow DataRowToModel(DataRow row)
		{
            CommonService.Model.FlowManager.P_Flow model = new CommonService.Model.FlowManager.P_Flow();
			if (row != null)
			{
				if(row["P_Flow_id"]!=null && row["P_Flow_id"].ToString()!="")
				{
					model.P_Flow_id=int.Parse(row["P_Flow_id"].ToString());
				}
				if(row["P_Flow_code"]!=null && row["P_Flow_code"].ToString()!="")
				{
					model.P_Flow_code= new Guid(row["P_Flow_code"].ToString());
				}
				if(row["P_Flow_name"]!=null)
				{
					model.P_Flow_name=row["P_Flow_name"].ToString();
				}
				if(row["P_Flow_type"]!=null && row["P_Flow_type"].ToString()!="")
				{
					model.P_Flow_type=int.Parse(row["P_Flow_type"].ToString());
				}
				if(row["P_Flow_parent"]!=null && row["P_Flow_parent"].ToString()!="")
				{
					model.P_Flow_parent= new Guid(row["P_Flow_parent"].ToString());
				}
                //判断父级流程名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("P_Flow_parent_name"))
                {
                    if (row.Table.Columns.Contains("P_Flow_parent_name"))
                    {
                        model.P_Flow_parent_name = row["P_Flow_parent_name"].ToString();
                    }
                }
				if(row["P_Flow_level"]!=null && row["P_Flow_level"].ToString()!="")
				{
					model.P_Flow_level=int.Parse(row["P_Flow_level"].ToString());
				}
				if(row["P_Flow_creator"]!=null && row["P_Flow_creator"].ToString()!="")
				{
					model.P_Flow_creator= new Guid(row["P_Flow_creator"].ToString());
				}
				if(row["P_Flow_createTime"]!=null && row["P_Flow_createTime"].ToString()!="")
				{
					model.P_Flow_createTime=DateTime.Parse(row["P_Flow_createTime"].ToString());
				}
				if(row["P_Flow_isDelete"]!=null && row["P_Flow_isDelete"].ToString()!="")
				{
					model.P_Flow_isDelete=int.Parse(row["P_Flow_isDelete"].ToString());
				}
				if(row["P_Flow_require"]!=null)
				{
					model.P_Flow_require=row["P_Flow_require"].ToString();
				}
				if(row["P_Flow_order"]!=null && row["P_Flow_order"].ToString()!="")
				{
					model.P_Flow_order=int.Parse(row["P_Flow_order"].ToString());
				}
                if(row["P_Flow_defaultDuration"]!=null && row["P_Flow_defaultDuration"].ToString()!="")
                {
                    model.P_Flow_defaultDuration =int.Parse(row["P_Flow_defaultDuration"].ToString());
                }
                if (row["P_Flow_ManagerType"] != null && row["P_Flow_ManagerType"].ToString() != "")
                {
                    model.P_Flow_ManagerType = int.Parse(row["P_Flow_ManagerType"].ToString());
                }
                
                if(row["P_Flow_IsCrossForm"]!=null && row["P_Flow_IsCrossForm"].ToString()!="")
                {
                    if (row["P_Flow_IsCrossForm"].ToString() == "1" || row["P_Flow_IsCrossForm"].ToString().ToLower()=="true")
                    {
                        model.P_Flow_IsCrossForm = true;
                    }else
                    {
                        model.P_Flow_IsCrossForm = false;
                    }
                }
                if (row["P_Flow_IsChiefCheck"] != null && row["P_Flow_IsChiefCheck"].ToString() != "")
                {
                    if (row["P_Flow_IsChiefCheck"].ToString() == "1" || row["P_Flow_IsChiefCheck"].ToString().ToLower() == "true")
                    {
                        model.P_Flow_IsChiefCheck = true;
                    }else
                    {
                        model.P_Flow_IsChiefCheck = false;
                    }
                }
                if (row["P_Flow_IsMonitor"] != null && row["P_Flow_IsMonitor"].ToString() != "")
                {
                    if (row["P_Flow_IsMonitor"].ToString() == "1" || row["P_Flow_IsMonitor"].ToString().ToLower() == "true")
                    {
                        model.P_Flow_IsMonitor = true;
                    }
                    else
                    {
                        model.P_Flow_IsMonitor = false;
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor ");
			strSql.Append(" FROM P_Flow ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor ");
            strSql.Append("FROM P_Flow WITH(NOLOCK) ");
            strSql.Append("where P_Flow_isDelete=0 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取所有“是否监控”为“是”的数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllListByIsMonitor()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor ");
            strSql.Append("FROM P_Flow WITH(NOLOCK) ");
            strSql.Append("where P_Flow_isDelete=0 ");
            strSql.Append("and P_Flow_IsMonitor=1 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="type">流程类型</param>
        /// <returns></returns>
        public DataSet GetListByFlowType(int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor ");
            strSql.Append("FROM P_Flow WITH(NOLOCK) ");
            strSql.Append("where P_Flow_isDelete=0 ");
            strSql.Append("and P_Flow_type=@P_Flow_type order by P_Flow_order ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_type", SqlDbType.Int,4)};
            parameters[0].Value = type;
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
            strSql.Append(" P_Flow_id,P_Flow_code,P_Flow_name,P_Flow_type,P_Flow_parent,P_Flow_level,P_Flow_creator,P_Flow_createTime,P_Flow_isDelete,P_Flow_require,P_Flow_order,P_Flow_defaultDuration,P_Flow_IsCrossForm,P_Flow_ManagerType,P_Flow_IsChiefCheck,P_Flow_IsMonitor ");
			strSql.Append(" FROM P_Flow ");
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
		public int GetRecordCount(Model.FlowManager.P_Flow model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM P_Flow ");
            strSql.Append(" where 1=1 and P_Flow_isDelete=0 ");
            if (model != null)
            {
                if (model.P_Flow_name != null && model.P_Flow_name != "")
                {
                    strSql.Append(" and P_Flow_name=@P_Flow_name");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_name", SqlDbType.VarChar,50)};
            parameters[0].Value = model.P_Flow_name;
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
		public DataSet GetListByPage(Model.FlowManager.P_Flow model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.P_Flow_id desc");
			}
            strSql.Append(")AS Row, T.*,P.P_Flow_name AS P_Flow_parent_name from P_Flow T ");
            strSql.Append("left join P_Flow AS P with(nolock) on T.P_Flow_parent = P.P_Flow_code ");
            strSql.Append(" where 1=1 and T.P_Flow_isDelete=0 ");
            if (model != null)
            {
                if (model.P_Flow_name != null && model.P_Flow_name != "")
                {
                    strSql.Append(" and T.P_Flow_name=@P_Flow_name");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_name", SqlDbType.VarChar,50)};
            parameters[0].Value = model.P_Flow_name;
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
			parameters[0].Value = "P_Flow";
			parameters[1].Value = "P_Flow_id";
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

