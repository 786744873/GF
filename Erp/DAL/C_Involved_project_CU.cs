using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:涉案项目----建设单位关联表
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	public partial class C_Involved_project_CU
	{
		public C_Involved_project_CU()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Involved_project_CU_id", "C_Involved_project_CU");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Involved_project_CU_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Involved_project_CU");
            strSql.Append(" where C_Involved_project_CU_id=@C_Involved_project_CU_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_CU_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Involved_project_CU_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Involved_project_CU model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Involved_project_CU(");
			strSql.Append("C_Involved_project_code,C_Rival_code,C_Rival_type,C_Involved_project_CU_situation,C_Involved_project_CU_bagStyle,C_Involved_project_CU_fundsSource,C_Involved_project_CU_isDelete,C_Involved_project_CU_creator,C_Involved_project_CU_createTime)");
			strSql.Append(" values (");
			strSql.Append("@C_Involved_project_code,@C_Rival_code,@C_Rival_type,@C_Involved_project_CU_situation,@C_Involved_project_CU_bagStyle,@C_Involved_project_CU_fundsSource,@C_Involved_project_CU_isDelete,@C_Involved_project_CU_creator,@C_Involved_project_CU_createTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Rival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Rival_type", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_situation", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_bagStyle", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_fundsSource", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_CU_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Involved_project_code;
            parameters[1].Value = model.C_Rival_code;
			parameters[2].Value = model.C_Rival_type;
			parameters[3].Value = model.C_Involved_project_CU_situation;
			parameters[4].Value = model.C_Involved_project_CU_bagStyle;
			parameters[5].Value = model.C_Involved_project_CU_fundsSource;
			parameters[6].Value = model.C_Involved_project_CU_isDelete;
            parameters[7].Value = model.C_Involved_project_CU_creator;
			parameters[8].Value = model.C_Involved_project_CU_createTime;

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
        public bool Update(CommonService.Model.C_Involved_project_CU model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Involved_project_CU set ");
			strSql.Append("C_Involved_project_code=@C_Involved_project_code,");
			strSql.Append("C_Rival_code=@C_Rival_code,");
			strSql.Append("C_Rival_type=@C_Rival_type,");
			strSql.Append("C_Involved_project_CU_situation=@C_Involved_project_CU_situation,");
			strSql.Append("C_Involved_project_CU_bagStyle=@C_Involved_project_CU_bagStyle,");
			strSql.Append("C_Involved_project_CU_fundsSource=@C_Involved_project_CU_fundsSource,");
			strSql.Append("C_Involved_project_CU_isDelete=@C_Involved_project_CU_isDelete,");
			strSql.Append("C_Involved_project_CU_creator=@C_Involved_project_CU_creator,");
			strSql.Append("C_Involved_project_CU_createTime=@C_Involved_project_CU_createTime");
			strSql.Append(" where C_Involved_project_CU_id=@C_Involved_project_CU_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Rival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Rival_type", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_situation", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_bagStyle", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_fundsSource", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_CU_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_CU_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_project_CU_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Involved_project_code;
			parameters[1].Value = model.C_Rival_code;
			parameters[2].Value = model.C_Rival_type;
			parameters[3].Value = model.C_Involved_project_CU_situation;
			parameters[4].Value = model.C_Involved_project_CU_bagStyle;
			parameters[5].Value = model.C_Involved_project_CU_fundsSource;
			parameters[6].Value = model.C_Involved_project_CU_isDelete;
			parameters[7].Value = model.C_Involved_project_CU_creator;
			parameters[8].Value = model.C_Involved_project_CU_createTime;
			parameters[9].Value = model.C_Involved_project_CU_id;

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
		public bool Delete(int C_Involved_project_CU_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Involved_project_CU set C_Involved_project_CU_isDelete=1 ");
			strSql.Append(" where C_Involved_project_CU_id=@C_Involved_project_CU_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_CU_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Involved_project_CU_id;

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
        ///根据建设单位Code删除一条数据
        /// </summary>
        public bool DeleteByRivalcode(Guid C_Involved_project_code,Guid C_Rival_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Involved_project_CU set C_Involved_project_CU_isDelete=1 ");
            strSql.Append(" where C_Rival_code=@C_Rival_code ");
            strSql.Append("and C_Involved_project_code=@C_Involved_project_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Rival_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Involved_project_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Rival_code;
            parameters[1].Value = C_Involved_project_code;

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
		public bool DeleteList(string C_Involved_project_CU_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Involved_project_CU ");
			strSql.Append(" where C_Involved_project_CU_id in ("+C_Involved_project_CU_idlist + ")  ");
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
        public CommonService.Model.C_Involved_project_CU GetModel(int C_Involved_project_CU_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 *,");
            strSql.Append("case when C_Rival_type=0 then (select C_CRival_name from C_CRival where C_CRival_code=C_Rival_code) ");
            strSql.Append("when C_Rival_type=1 then (select C_PRival_name from C_PRival where C_PRival_code=C_Rival_code) ");
            strSql.Append("end as Rival_name ");
            strSql.Append("from C_Involved_project_CU ");  
            strSql.Append(" where C_Involved_project_CU_id=@C_Involved_project_CU_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_CU_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Involved_project_CU_id;

            CommonService.Model.C_Involved_project_CU model = new CommonService.Model.C_Involved_project_CU();
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
        public CommonService.Model.C_Involved_project_CU DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Involved_project_CU model = new CommonService.Model.C_Involved_project_CU();
			if (row != null)
			{
				if(row["C_Involved_project_CU_id"]!=null && row["C_Involved_project_CU_id"].ToString()!="")
				{
					model.C_Involved_project_CU_id=int.Parse(row["C_Involved_project_CU_id"].ToString());
				}
				if(row["C_Involved_project_code"]!=null && row["C_Involved_project_code"].ToString()!="")
				{
					model.C_Involved_project_code= new Guid(row["C_Involved_project_code"].ToString());
				}
				if(row["C_Rival_code"]!=null && row["C_Rival_code"].ToString()!="")
				{
					model.C_Rival_code= new Guid(row["C_Rival_code"].ToString());
				}
                //判断单位名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("Rival_name"))
                {
                    if (row["Rival_name"] != null && row["Rival_name"].ToString() != "")
                    {
                        model.Rival_name = row["Rival_name"].ToString();
                    }
                }               
				if(row["C_Rival_type"]!=null && row["C_Rival_type"].ToString()!="")
				{
					model.C_Rival_type=int.Parse(row["C_Rival_type"].ToString());
				}
				if(row["C_Involved_project_CU_situation"]!=null && row["C_Involved_project_CU_situation"].ToString()!="")
				{
					model.C_Involved_project_CU_situation=int.Parse(row["C_Involved_project_CU_situation"].ToString());
				}
				if(row["C_Involved_project_CU_bagStyle"]!=null && row["C_Involved_project_CU_bagStyle"].ToString()!="")
				{
					model.C_Involved_project_CU_bagStyle=int.Parse(row["C_Involved_project_CU_bagStyle"].ToString());
				}
				if(row["C_Involved_project_CU_fundsSource"]!=null && row["C_Involved_project_CU_fundsSource"].ToString()!="")
				{
					model.C_Involved_project_CU_fundsSource=int.Parse(row["C_Involved_project_CU_fundsSource"].ToString());
				}
				if(row["C_Involved_project_CU_isDelete"]!=null && row["C_Involved_project_CU_isDelete"].ToString()!="")
				{
					model.C_Involved_project_CU_isDelete=int.Parse(row["C_Involved_project_CU_isDelete"].ToString());
				}
				if(row["C_Involved_project_CU_creator"]!=null && row["C_Involved_project_CU_creator"].ToString()!="")
				{
					model.C_Involved_project_CU_creator= new Guid(row["C_Involved_project_CU_creator"].ToString());
				}
				if(row["C_Involved_project_CU_createTime"]!=null && row["C_Involved_project_CU_createTime"].ToString()!="")
				{
					model.C_Involved_project_CU_createTime=DateTime.Parse(row["C_Involved_project_CU_createTime"].ToString());
				}
			}
			return model;
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
			strSql.Append(" C_Involved_project_CU_id,C_Involved_project_code,C_Rival_code,C_Rival_type,C_Involved_project_CU_situation,C_Involved_project_CU_bagStyle,C_Involved_project_CU_fundsSource,C_Involved_project_CU_isDelete,C_Involved_project_CU_creator,C_Involved_project_CU_createTime ");
			strSql.Append(" FROM C_Involved_project_CU ");
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
		public int GetRecordCount(Model.C_Involved_project_CU model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM C_Involved_project_CU ");
            strSql.Append(" where 1=1 and C_Involved_project_CU_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Involved_project_code != null)
                {
                    strSql.Append("and C_Involved_project_code=@C_Involved_project_code");
                }
                if (model.C_Rival_code != null)
                {
                    strSql.Append("and C_Rival_code=@C_Rival_code");
                } 
                if (model.C_Rival_type != null)
                {
                    strSql.Append("and C_Rival_type=@C_Rival_type");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Rival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Rival_type", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Involved_project_code;
            parameters[1].Value = model.C_Rival_code;
            parameters[2].Value = model.C_Rival_type;
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
		public DataSet GetListByPage(Model.C_Involved_project_CU model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Involved_project_CU_id desc");
			}
            strSql.Append(")AS Row, T.*,");
            strSql.Append("case when C_Rival_type=0 then (select C_CRival_name from C_CRival where C_CRival_code=C_Rival_code) ");
            strSql.Append("when C_Rival_type=1 then (select C_PRival_name from C_PRival where C_PRival_code=C_Rival_code) ");
            strSql.Append("end as Rival_name ");
            strSql.Append("from C_Involved_project_CU T ");
            strSql.Append(" where 1=1 and C_Involved_project_CU_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Involved_project_code != null)
                {
                    strSql.Append("and C_Involved_project_code=@C_Involved_project_code");
                }
                if (model.C_Rival_code != null)
                {
                    strSql.Append("and C_Rival_code=@C_Rival_code");
                }
                if (model.C_Rival_type != null)
                {
                    strSql.Append("and C_Rival_type=@C_Rival_type");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Rival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Rival_type", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Involved_project_code;
            parameters[1].Value = model.C_Rival_code;
            parameters[2].Value = model.C_Rival_type;
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
			parameters[0].Value = "C_Involved_project_CU";
			parameters[1].Value = "C_Involved_project_CU_id";
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

