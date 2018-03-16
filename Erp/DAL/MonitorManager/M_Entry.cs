using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.MonitorManager
{
    /// <summary>
    /// 数据访问类:条目表
    /// 作者：崔慧栋
    /// 日期：2015/06/08
    /// </summary>
	public partial class M_Entry
	{
		public M_Entry()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("M_Entry_id", "M_Entry");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int M_Entry_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from M_Entry");
            strSql.Append(" where M_Entry_id=@M_Entry_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_id", SqlDbType.Int,4)
			};
            parameters[0].Value = M_Entry_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.MonitorManager.M_Entry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into M_Entry(");
            strSql.Append("M_Entry_code,M_Entry_name,M_Entry_sname,M_Entry_ename,M_Entry_sFlow,M_Entry_eFlow,M_Entry_sForm,M_Entry_eForm,M_Entry_sTime,M_Entry_eTime,M_Entry_Duration,M_Entry_warningType,M_Entry_warningDuration,M_Entry_parent,M_Entry_isDelete,M_Entry_creator,M_Entry_createTime,M_Entry_court,M_Entry_processType)");
			strSql.Append(" values (");
            strSql.Append("@M_Entry_code,@M_Entry_name,@M_Entry_sname,@M_Entry_ename,@M_Entry_sFlow,@M_Entry_eFlow,@M_Entry_sForm,@M_Entry_eForm,@M_Entry_sTime,@M_Entry_eTime,@M_Entry_Duration,@M_Entry_warningType,@M_Entry_warningDuration,@M_Entry_parent,@M_Entry_isDelete,@M_Entry_creator,@M_Entry_createTime,@M_Entry_court,@M_Entry_processType)");
			SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_name", SqlDbType.NVarChar,50),
					new SqlParameter("@M_Entry_sname", SqlDbType.NVarChar,100),
					new SqlParameter("@M_Entry_ename", SqlDbType.NVarChar,100),
					new SqlParameter("@M_Entry_sFlow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_eFlow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_sForm", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_eForm", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_sTime", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_eTime", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Duration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_warningType", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_warningDuration", SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_isDelete", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_createTime", SqlDbType.DateTime),
                    new SqlParameter("@M_Entry_court",SqlDbType.VarChar,5000),
                    new SqlParameter("@M_Entry_processType",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.M_Entry_code;
			parameters[1].Value = model.M_Entry_name;
			parameters[2].Value = model.M_Entry_sname;
			parameters[3].Value = model.M_Entry_ename;
            parameters[4].Value = model.M_Entry_sFlow;
            parameters[5].Value = model.M_Entry_eFlow;
            parameters[6].Value = model.M_Entry_sForm;
            parameters[7].Value = model.M_Entry_eForm;
            parameters[8].Value = model.M_Entry_sTime;
            parameters[9].Value = model.M_Entry_eTime;
			parameters[10].Value = model.M_Entry_Duration;
			parameters[11].Value = model.M_Entry_warningType;
			parameters[12].Value = model.M_Entry_warningDuration;
            parameters[13].Value = model.M_Entry_parent;
			parameters[14].Value = model.M_Entry_isDelete;
            parameters[15].Value = model.M_Entry_creator;
			parameters[16].Value = model.M_Entry_createTime;
            parameters[17].Value = model.M_Entry_court;
            parameters[18].Value = model.M_Entry_processType;

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
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.MonitorManager.M_Entry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update M_Entry set ");
			strSql.Append("M_Entry_code=@M_Entry_code,");
			strSql.Append("M_Entry_name=@M_Entry_name,");
			strSql.Append("M_Entry_sname=@M_Entry_sname,");
			strSql.Append("M_Entry_ename=@M_Entry_ename,");
			strSql.Append("M_Entry_sFlow=@M_Entry_sFlow,");
			strSql.Append("M_Entry_eFlow=@M_Entry_eFlow,");
			strSql.Append("M_Entry_sForm=@M_Entry_sForm,");
			strSql.Append("M_Entry_eForm=@M_Entry_eForm,");
			strSql.Append("M_Entry_sTime=@M_Entry_sTime,");
			strSql.Append("M_Entry_eTime=@M_Entry_eTime,");
			strSql.Append("M_Entry_Duration=@M_Entry_Duration,");
			strSql.Append("M_Entry_warningType=@M_Entry_warningType,");
			strSql.Append("M_Entry_warningDuration=@M_Entry_warningDuration,");
            strSql.Append("M_Entry_parent=@M_Entry_parent,");
			strSql.Append("M_Entry_isDelete=@M_Entry_isDelete,");
			strSql.Append("M_Entry_creator=@M_Entry_creator,");
			strSql.Append("M_Entry_createTime=@M_Entry_createTime,");
            strSql.Append("M_Entry_court=@M_Entry_court,");
            strSql.Append("M_Entry_processType=@M_Entry_processType ");
            strSql.Append(" where M_Entry_id=@M_Entry_id");
			SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_id", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_name", SqlDbType.NVarChar,50),
					new SqlParameter("@M_Entry_sname", SqlDbType.NVarChar,100),
					new SqlParameter("@M_Entry_ename", SqlDbType.NVarChar,100),
					new SqlParameter("@M_Entry_sFlow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_eFlow", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_sForm", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_eForm", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_sTime", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_eTime", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Duration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_warningType", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_warningDuration", SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_isDelete", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_createTime", SqlDbType.DateTime),
                    new SqlParameter("@M_Entry_court",SqlDbType.VarChar,5000),
                    new SqlParameter("@M_Entry_processType",SqlDbType.Int,4)
                                        };
			parameters[0].Value = model.M_Entry_id;
			parameters[1].Value = model.M_Entry_code;
			parameters[2].Value = model.M_Entry_name;
			parameters[3].Value = model.M_Entry_sname;
			parameters[4].Value = model.M_Entry_ename;
			parameters[5].Value = model.M_Entry_sFlow;
			parameters[6].Value = model.M_Entry_eFlow;
			parameters[7].Value = model.M_Entry_sForm;
			parameters[8].Value = model.M_Entry_eForm;
			parameters[9].Value = model.M_Entry_sTime;
			parameters[10].Value = model.M_Entry_eTime;
			parameters[11].Value = model.M_Entry_Duration;
			parameters[12].Value = model.M_Entry_warningType;
			parameters[13].Value = model.M_Entry_warningDuration;
            parameters[14].Value = model.M_Entry_parent;
			parameters[15].Value = model.M_Entry_isDelete;
			parameters[16].Value = model.M_Entry_creator;
			parameters[17].Value = model.M_Entry_createTime;
            parameters[18].Value = model.M_Entry_court;
            parameters[19].Value = model.M_Entry_processType;

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
        public bool Delete(int M_Entry_id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update M_Entry set M_Entry_isDelete =1 ");
            strSql.Append(" where M_Entry_id=@M_Entry_id");
            SqlParameter[] parameters = {new SqlParameter("@M_Entry_id",SqlDbType.Int,4)
			};
            parameters[0].Value = M_Entry_id;

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
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.MonitorManager.M_Entry GetModel(int M_Entry_id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 M_Entry_id,M_Entry_code,M_Entry_name,M_Entry_sname,M_Entry_ename,M_Entry_sFlow,M_Entry_eFlow,M_Entry_sForm,M_Entry_eForm,M_Entry_sTime,M_Entry_eTime,M_Entry_Duration,M_Entry_warningType,M_Entry_warningDuration,M_Entry_parent,M_Entry_isDelete,M_Entry_creator,M_Entry_createTime,M_Entry_court,M_Entry_processType from M_Entry ");
			strSql.Append(" where M_Entry_id=@M_Entry_id");
            SqlParameter[] parameters = {new SqlParameter("@M_Entry_id",SqlDbType.Int,4)
			};
            parameters[0].Value=M_Entry_id;

            CommonService.Model.MonitorManager.M_Entry model = new CommonService.Model.MonitorManager.M_Entry();
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
        public CommonService.Model.MonitorManager.M_Entry GetModelByCode(Guid M_Entry_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 M_Entry_id,M_Entry_code,M_Entry_name,M_Entry_sname,M_Entry_ename,M_Entry_sFlow,M_Entry_eFlow,M_Entry_sForm,M_Entry_eForm,M_Entry_sTime,M_Entry_eTime,M_Entry_Duration,M_Entry_warningType,M_Entry_warningDuration,M_Entry_parent,M_Entry_isDelete,M_Entry_creator,M_Entry_createTime,M_Entry_court,M_Entry_processType from M_Entry ");
            strSql.Append(" where M_Entry_code=@M_Entry_code");
            SqlParameter[] parameters = {new SqlParameter("@M_Entry_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = M_Entry_code;

            CommonService.Model.MonitorManager.M_Entry model = new CommonService.Model.MonitorManager.M_Entry();
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
        public CommonService.Model.MonitorManager.M_Entry DataRowToModel(DataRow row)
		{
            CommonService.Model.MonitorManager.M_Entry model = new CommonService.Model.MonitorManager.M_Entry();
			if (row != null)
			{
				if(row["M_Entry_id"]!=null && row["M_Entry_id"].ToString()!="")
				{
					model.M_Entry_id=int.Parse(row["M_Entry_id"].ToString());
				}
				if(row["M_Entry_code"]!=null && row["M_Entry_code"].ToString()!="")
				{
					model.M_Entry_code= new Guid(row["M_Entry_code"].ToString());
				}
				if(row["M_Entry_name"]!=null)
				{
					model.M_Entry_name=row["M_Entry_name"].ToString();
				}
				if(row["M_Entry_sname"]!=null)
				{
					model.M_Entry_sname=row["M_Entry_sname"].ToString();
				}
				if(row["M_Entry_ename"]!=null)
				{
					model.M_Entry_ename=row["M_Entry_ename"].ToString();
				}
				if(row["M_Entry_sFlow"]!=null && row["M_Entry_sFlow"].ToString()!="")
				{
					model.M_Entry_sFlow= new Guid(row["M_Entry_sFlow"].ToString());
				}
				if(row["M_Entry_eFlow"]!=null && row["M_Entry_eFlow"].ToString()!="")
				{
					model.M_Entry_eFlow= new Guid(row["M_Entry_eFlow"].ToString());
				}
				if(row["M_Entry_sForm"]!=null && row["M_Entry_sForm"].ToString()!="")
				{
					model.M_Entry_sForm= new Guid(row["M_Entry_sForm"].ToString());
				}
				if(row["M_Entry_eForm"]!=null && row["M_Entry_eForm"].ToString()!="")
				{
					model.M_Entry_eForm= new Guid(row["M_Entry_eForm"].ToString());
				}
				if(row["M_Entry_sTime"]!=null && row["M_Entry_sTime"].ToString()!="")
				{
					model.M_Entry_sTime= new Guid(row["M_Entry_sTime"].ToString());
				}
				if(row["M_Entry_eTime"]!=null && row["M_Entry_eTime"].ToString()!="")
				{
					model.M_Entry_eTime= new Guid(row["M_Entry_eTime"].ToString());
				}
				if(row["M_Entry_Duration"]!=null && row["M_Entry_Duration"].ToString()!="")
				{
					model.M_Entry_Duration=int.Parse(row["M_Entry_Duration"].ToString());
				}
				if(row["M_Entry_warningType"]!=null && row["M_Entry_warningType"].ToString()!="")
				{
					model.M_Entry_warningType=int.Parse(row["M_Entry_warningType"].ToString());
				}
				if(row["M_Entry_warningDuration"]!=null && row["M_Entry_warningDuration"].ToString()!="")
				{
					model.M_Entry_warningDuration=int.Parse(row["M_Entry_warningDuration"].ToString());
				}
                if (row["M_Entry_parent"] != null && row["M_Entry_parent"].ToString() != "")
                {
                    model.M_Entry_parent = new Guid(row["M_Entry_parent"].ToString());
                }
				if(row["M_Entry_isDelete"]!=null && row["M_Entry_isDelete"].ToString()!="")
				{
					model.M_Entry_isDelete=int.Parse(row["M_Entry_isDelete"].ToString());
				}
				if(row["M_Entry_creator"]!=null && row["M_Entry_creator"].ToString()!="")
				{
					model.M_Entry_creator= new Guid(row["M_Entry_creator"].ToString());
				}
				if(row["M_Entry_createTime"]!=null && row["M_Entry_createTime"].ToString()!="")
				{
					model.M_Entry_createTime=DateTime.Parse(row["M_Entry_createTime"].ToString());
				}
                if(row["M_Entry_court"]!=null && row["M_Entry_court"].ToString()!="")
                {
                    model.M_Entry_court = row["M_Entry_court"].ToString();
                }
                if(row["M_Entry_processType"]!=null && row["M_Entry_processType"].ToString()!="")
                {
                    model.M_Entry_processType = Convert.ToInt32(row["M_Entry_processType"].ToString());
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
            strSql.Append("select M_Entry_id,M_Entry_code,M_Entry_name,M_Entry_sname,M_Entry_ename,M_Entry_sFlow,M_Entry_eFlow,M_Entry_sForm,M_Entry_eForm,M_Entry_sTime,M_Entry_eTime,M_Entry_Duration,M_Entry_warningType,M_Entry_warningDuration,M_Entry_parent,M_Entry_isDelete,M_Entry_creator,M_Entry_createTime,M_Entry_court,M_Entry_processType ");
			strSql.Append(" FROM M_Entry ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select M_Entry_id,M_Entry_code,M_Entry_name,M_Entry_sname,M_Entry_ename,M_Entry_sFlow,M_Entry_eFlow,M_Entry_sForm,M_Entry_eForm,M_Entry_sTime,M_Entry_eTime,M_Entry_Duration,M_Entry_warningType,M_Entry_warningDuration,M_Entry_parent,M_Entry_isDelete,M_Entry_creator,M_Entry_createTime,M_Entry_court,M_Entry_processType ");
            strSql.Append(" FROM M_Entry ");
            strSql.Append(" where M_Entry_isDelete=0 ");
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" M_Entry_id,M_Entry_code,M_Entry_name,M_Entry_sname,M_Entry_ename,M_Entry_sFlow,M_Entry_eFlow,M_Entry_sForm,M_Entry_eForm,M_Entry_sTime,M_Entry_eTime,M_Entry_Duration,M_Entry_warningType,M_Entry_warningDuration,M_Entry_parent,M_Entry_isDelete,M_Entry_creator,M_Entry_createTime,M_Entry_court,M_Entry_processType ");
			strSql.Append(" FROM M_Entry ");
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
		public int GetRecordCount(CommonService.Model.MonitorManager.M_Entry model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM M_Entry ");
            strSql.Append(" where 1=1 and M_Entry_isDelete=0 ");
            if (model != null)
            {
                if (model.M_Entry_name != null)
                {
                    strSql.Append("and M_Entry_name like N'%'+@M_Entry_name+'%' ");
                }
                if (model.M_Entry_code != null && model.M_Entry_code.ToString()!="")
                {
                    strSql.Append("and M_Entry_code=@M_Entry_code ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_name", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.M_Entry_code;
            parameters[1].Value = model.M_Entry_name;
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
		public DataSet GetListByPage(CommonService.Model.MonitorManager.M_Entry model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.M_Entry_id desc");
			}
            strSql.Append(")AS Row, T.*  from M_Entry T ");
            strSql.Append(" where 1=1 and M_Entry_isDelete=0 ");
            if (model != null)
            {
                if (model.M_Entry_name != null)
                {
                    strSql.Append("and M_Entry_name like N'%'+@M_Entry_name+'%' ");
                }
                if (model.M_Entry_code != null && model.M_Entry_code.ToString() != "")
                {
                    strSql.Append("and M_Entry_code=@M_Entry_code ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_name", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.M_Entry_code;
            parameters[1].Value = model.M_Entry_name;
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
			parameters[0].Value = "M_Entry";
			parameters[1].Value = "";
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

