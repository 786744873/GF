using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:涉案项目表
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	public partial class C_Involved_project
	{
		public C_Involved_project()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Involved_project_id", "C_Involved_project");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Involved_project_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Involved_project");
            strSql.Append(" where C_Involved_project_id=@C_Involved_project_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Involved_project_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

         /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(Model.C_Involved_project model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Involved_project");
            strSql.Append(" where C_Involved_project_name=@C_Involved_project_name");
            strSql.Append(" and C_Involved_project_isDelete=0");
            if(model.C_Involved_project_id > 0)
            {
                strSql.Append(" and C_Involved_project_code<>@C_Involved_project_code");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_name", SqlDbType.NVarChar),
                    new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_Involved_project_name;
            parameters[1].Value = model.C_Involved_project_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Involved_project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Involved_project(");
			strSql.Append("C_Involved_project_code,C_Involved_project_number,C_Involved_project_name,C_Involved_project_address,C_Involved_project_type,C_Involved_project_scale,C_Involved_project_Investment,C_Involved_project_creator,C_Involved_project_createTime,C_Involved_project_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@C_Involved_project_code,@C_Involved_project_number,@C_Involved_project_name,@C_Involved_project_address,@C_Involved_project_type,@C_Involved_project_scale,@C_Involved_project_Investment,@C_Involved_project_creator,@C_Involved_project_createTime,@C_Involved_project_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_project_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_project_address", SqlDbType.VarChar,100),
					new SqlParameter("@C_Involved_project_type", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_project_scale", SqlDbType.Decimal,9),
					new SqlParameter("@C_Involved_project_Investment", SqlDbType.Decimal,9),
					new SqlParameter("@C_Involved_project_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_project_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Involved_project_code;
			parameters[1].Value = model.C_Involved_project_number;
			parameters[2].Value = model.C_Involved_project_name;
			parameters[3].Value = model.C_Involved_project_address;
			parameters[4].Value = model.C_Involved_project_type;
			parameters[5].Value = model.C_Involved_project_scale;
			parameters[6].Value = model.C_Involved_project_Investment;
            parameters[7].Value = model.C_Involved_project_creator;
			parameters[8].Value = model.C_Involved_project_createTime;
			parameters[9].Value = model.C_Involved_project_isDelete;

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
        public bool Update(CommonService.Model.C_Involved_project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Involved_project set ");
			strSql.Append("C_Involved_project_code=@C_Involved_project_code,");
			strSql.Append("C_Involved_project_number=@C_Involved_project_number,");
			strSql.Append("C_Involved_project_name=@C_Involved_project_name,");
			strSql.Append("C_Involved_project_address=@C_Involved_project_address,");
			strSql.Append("C_Involved_project_type=@C_Involved_project_type,");
			strSql.Append("C_Involved_project_scale=@C_Involved_project_scale,");
			strSql.Append("C_Involved_project_Investment=@C_Involved_project_Investment,");
			strSql.Append("C_Involved_project_creator=@C_Involved_project_creator,");
			strSql.Append("C_Involved_project_createTime=@C_Involved_project_createTime,");
			strSql.Append("C_Involved_project_isDelete=@C_Involved_project_isDelete");
			strSql.Append(" where C_Involved_project_id=@C_Involved_project_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_project_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_project_address", SqlDbType.VarChar,100),
					new SqlParameter("@C_Involved_project_type", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_project_scale", SqlDbType.Decimal,9),
					new SqlParameter("@C_Involved_project_Investment", SqlDbType.Decimal,9),
					new SqlParameter("@C_Involved_project_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_project_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_project_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Involved_project_code;
			parameters[1].Value = model.C_Involved_project_number;
			parameters[2].Value = model.C_Involved_project_name;
			parameters[3].Value = model.C_Involved_project_address;
			parameters[4].Value = model.C_Involved_project_type;
			parameters[5].Value = model.C_Involved_project_scale;
			parameters[6].Value = model.C_Involved_project_Investment;
			parameters[7].Value = model.C_Involved_project_creator;
			parameters[8].Value = model.C_Involved_project_createTime;
			parameters[9].Value = model.C_Involved_project_isDelete;
			parameters[10].Value = model.C_Involved_project_id;

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
        public bool Delete(Guid C_Involved_project_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Involved_project set C_Involved_project_isDelete=1 ");
            strSql.Append(" where C_Involved_project_code=@C_Involved_project_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Involved_project_code;

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
		public bool DeleteList(string C_Involved_project_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Involved_project ");
			strSql.Append(" where C_Involved_project_id in ("+C_Involved_project_idlist + ")  ");
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
        public CommonService.Model.C_Involved_project GetModel(int C_Involved_project_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_Involved_project_id,C_Involved_project_code,C_Involved_project_number,C_Involved_project_name,C_Involved_project_address,C_Involved_project_type,C_Involved_project_scale,C_Involved_project_Investment,C_Involved_project_creator,C_Involved_project_createTime,C_Involved_project_isDelete from C_Involved_project ");
			strSql.Append(" where C_Involved_project_id=@C_Involved_project_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Involved_project_id;

            CommonService.Model.C_Involved_project model = new CommonService.Model.C_Involved_project();
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
        public CommonService.Model.C_Involved_project GetModel(Guid C_Involved_project_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Involved_project_id,C_Involved_project_code,C_Involved_project_number,C_Involved_project_name,C_Involved_project_address,C_Involved_project_type,C_Involved_project_scale,C_Involved_project_Investment,C_Involved_project_creator,C_Involved_project_createTime,C_Involved_project_isDelete from C_Involved_project ");
            strSql.Append(" where C_Involved_project_code=@C_Involved_project_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Involved_project_code;

            CommonService.Model.C_Involved_project model = new CommonService.Model.C_Involved_project();
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
        public CommonService.Model.C_Involved_project DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Involved_project model = new CommonService.Model.C_Involved_project();
			if (row != null)
			{
				if(row["C_Involved_project_id"]!=null && row["C_Involved_project_id"].ToString()!="")
				{
					model.C_Involved_project_id=int.Parse(row["C_Involved_project_id"].ToString());
				}
				if(row["C_Involved_project_code"]!=null && row["C_Involved_project_code"].ToString()!="")
				{
					model.C_Involved_project_code= new Guid(row["C_Involved_project_code"].ToString());
				}
				if(row["C_Involved_project_number"]!=null)
				{
					model.C_Involved_project_number=row["C_Involved_project_number"].ToString();
				}
				if(row["C_Involved_project_name"]!=null)
				{
					model.C_Involved_project_name=row["C_Involved_project_name"].ToString();
				}
				if(row["C_Involved_project_address"]!=null)
				{
					model.C_Involved_project_address=row["C_Involved_project_address"].ToString();
				}
				if(row["C_Involved_project_type"]!=null)
				{
					model.C_Involved_project_type=row["C_Involved_project_type"].ToString();
				}
				if(row["C_Involved_project_scale"]!=null && row["C_Involved_project_scale"].ToString()!="")
				{
					model.C_Involved_project_scale=decimal.Parse(row["C_Involved_project_scale"].ToString());
				}
				if(row["C_Involved_project_Investment"]!=null && row["C_Involved_project_Investment"].ToString()!="")
				{
					model.C_Involved_project_Investment=decimal.Parse(row["C_Involved_project_Investment"].ToString());
				}
				if(row["C_Involved_project_creator"]!=null && row["C_Involved_project_creator"].ToString()!="")
				{
					model.C_Involved_project_creator= new Guid(row["C_Involved_project_creator"].ToString());
				}
				if(row["C_Involved_project_createTime"]!=null && row["C_Involved_project_createTime"].ToString()!="")
				{
					model.C_Involved_project_createTime=DateTime.Parse(row["C_Involved_project_createTime"].ToString());
				}
				if(row["C_Involved_project_isDelete"]!=null && row["C_Involved_project_isDelete"].ToString()!="")
				{
					model.C_Involved_project_isDelete=int.Parse(row["C_Involved_project_isDelete"].ToString());
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
			strSql.Append("select C_Involved_project_id,C_Involved_project_code,C_Involved_project_number,C_Involved_project_name,C_Involved_project_address,C_Involved_project_type,C_Involved_project_scale,C_Involved_project_Investment,C_Involved_project_creator,C_Involved_project_createTime,C_Involved_project_isDelete ");
			strSql.Append(" FROM C_Involved_project ");
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
            strSql.Append("select C_Involved_project_id,C_Involved_project_code,C_Involved_project_number,C_Involved_project_name,C_Involved_project_address,C_Involved_project_type,C_Involved_project_scale,C_Involved_project_Investment,C_Involved_project_creator,C_Involved_project_createTime,C_Involved_project_isDelete ");
            strSql.Append(" FROM C_Involved_project where 1=1 and C_Involved_project_isDelete=0 ");
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
			strSql.Append(" C_Involved_project_id,C_Involved_project_code,C_Involved_project_number,C_Involved_project_name,C_Involved_project_address,C_Involved_project_type,C_Involved_project_scale,C_Involved_project_Investment,C_Involved_project_creator,C_Involved_project_createTime,C_Involved_project_isDelete ");
			strSql.Append(" FROM C_Involved_project ");
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
		public int GetRecordCount(Model.C_Involved_project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Involved_project ");
            strSql.Append(" where 1=1 and C_Involved_project_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Involved_project_code != null)
                {
                    strSql.Append("and C_Involved_project_code=@C_Involved_project_code");
                }
                if (model.C_Involved_project_name != null)
                {
                    strSql.Append("and C_Involved_project_name like N'%'+@C_Involved_project_name+'%' ");
                }
                if (model.C_Involved_project_address != null) {
                    strSql.Append(" and C_Involved_project_address like N'%'+@C_Involved_project_address+'%'");
                }
                if (model.C_Involved_project_type != null) {
                    strSql.Append(" and C_Involved_project_type like N'%'+@C_Involved_project_type+'%'");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Involved_project_address", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Involved_project_type", SqlDbType.VarChar,50)};
            parameters[0].Value = model.C_Involved_project_code;
            parameters[1].Value = model.C_Involved_project_name;
            parameters[2].Value = model.C_Involved_project_address;
            parameters[3].Value = model.C_Involved_project_type;
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
		public DataSet GetListByPage(Model.C_Involved_project model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Involved_project_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_Involved_project T ");
            strSql.Append(" where 1=1 and C_Involved_project_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Involved_project_code != null)
                {
                    strSql.Append("and C_Involved_project_code=@C_Involved_project_code");
                }
                if (model.C_Involved_project_name != null)
                {
                    strSql.Append("and C_Involved_project_name like N'%'+@C_Involved_project_name+'%' ");
                }
                if (model.C_Involved_project_address != null)
                {
                    strSql.Append(" and C_Involved_project_address like N'%'+@C_Involved_project_address+'%'");
                }
                if (model.C_Involved_project_type != null)
                {
                    strSql.Append(" and C_Involved_project_type like N'%'+@C_Involved_project_type+'%'");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Involved_project_address", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Involved_project_type", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.C_Involved_project_code;
            parameters[1].Value = model.C_Involved_project_name;
            parameters[2].Value = model.C_Involved_project_address;
            parameters[3].Value = model.C_Involved_project_type;
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
			parameters[0].Value = "C_Involved_project";
			parameters[1].Value = "C_Involved_project_id";
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

