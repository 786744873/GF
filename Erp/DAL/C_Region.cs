using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:区域表
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class C_Region
	{
		public C_Region()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Region_Id", "C_Region");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Region_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Region");
            strSql.Append(" where C_Region_Id=@C_Region_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Region_Id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Region_Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Region model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Region(");
            strSql.Append("C_Region_code,C_Region_name,C_Region_abbreviation,C_Region_parent,C_Region_level,C_Region_creator,C_Region_createTime,C_Region_isDelete,C_Region_isSpecial)");
			strSql.Append(" values (");
            strSql.Append("@C_Region_code,@C_Region_name,@C_Region_abbreviation,@C_Region_parent,@C_Region_level,@C_Region_creator,@C_Region_createTime,@C_Region_isDelete,@C_Region_isSpecial)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Region_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Region_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Region_abbreviation",SqlDbType.VarChar,50),
					new SqlParameter("@C_Region_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Region_level", SqlDbType.Int,4),
					new SqlParameter("@C_Region_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Region_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Region_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@C_Region_isSpecial",SqlDbType.Int,4)};
            parameters[0].Value = model.C_Region_code;
			parameters[1].Value = model.C_Region_name;
            parameters[2].Value = model.C_Region_abbreviation;
            parameters[3].Value = model.C_Region_parent;
			parameters[4].Value = model.C_Region_level;
            parameters[5].Value = model.C_Region_creator;
			parameters[6].Value = model.C_Region_createTime;
			parameters[7].Value = model.C_Region_isDelete;
            parameters[8].Value = model.C_Region_isSpecial;

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
        public bool Update(CommonService.Model.C_Region model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Region set ");
			strSql.Append("C_Region_code=@C_Region_code,");
			strSql.Append("C_Region_name=@C_Region_name,");
            strSql.Append("C_Region_abbreviation=@C_Region_abbreviation,");
			strSql.Append("C_Region_parent=@C_Region_parent,");
			strSql.Append("C_Region_level=@C_Region_level,");
			strSql.Append("C_Region_creator=@C_Region_creator,");
			strSql.Append("C_Region_createTime=@C_Region_createTime,");
			strSql.Append("C_Region_isDelete=@C_Region_isDelete,");
            strSql.Append("C_Region_isSpecial=@C_Region_isSpecial");
			strSql.Append(" where C_Region_Id=@C_Region_Id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Region_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Region_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Region_abbreviation",SqlDbType.VarChar,50),
					new SqlParameter("@C_Region_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Region_level", SqlDbType.Int,4),
					new SqlParameter("@C_Region_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Region_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Region_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@C_Region_isSpecial",SqlDbType.Int,4),
					new SqlParameter("@C_Region_Id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Region_code;
			parameters[1].Value = model.C_Region_name;
            parameters[2].Value = model.C_Region_abbreviation;
			parameters[3].Value = model.C_Region_parent;
			parameters[4].Value = model.C_Region_level;
			parameters[5].Value = model.C_Region_creator;
			parameters[6].Value = model.C_Region_createTime;
			parameters[7].Value = model.C_Region_isDelete;
            parameters[8].Value = model.C_Region_isSpecial;
			parameters[9].Value = model.C_Region_Id;

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
        public bool Delete(Guid C_Region_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Region set C_Region_isDelete=1 ");
            strSql.Append(" where C_Region_code=@C_Region_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Region_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Region_code;

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
		public bool DeleteList(string C_Region_Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Region ");
			strSql.Append(" where C_Region_Id in ("+C_Region_Idlist + ")  ");
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
        public CommonService.Model.C_Region GetModel(int C_Region_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 C_Region_Id,C_Region_code,C_Region_name,C_Region_abbreviation,C_Region_parent,C_Region_level,C_Region_creator,C_Region_createTime,C_Region_isDelete,C_Region_isSpecial from C_Region ");
			strSql.Append(" where C_Region_Id=@C_Region_Id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Region_Id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Region_Id;

            CommonService.Model.C_Region model = new CommonService.Model.C_Region();
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
        /// 根据GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Region GetModelByCode(Guid C_Region_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Region_Id,C_Region_code,C_Region_name,C_Region_abbreviation,C_Region_parent,C_Region_level,C_Region_creator,C_Region_createTime,C_Region_isDelete,C_Region_isSpecial from C_Region ");
            strSql.Append(" where C_Region_code=@C_Region_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Region_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Region_code;

            CommonService.Model.C_Region model = new CommonService.Model.C_Region();
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
        public CommonService.Model.C_Region DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Region model = new CommonService.Model.C_Region();
			if (row != null)
			{
				if(row["C_Region_Id"]!=null && row["C_Region_Id"].ToString()!="")
				{
					model.C_Region_Id=int.Parse(row["C_Region_Id"].ToString());
				}
				if(row["C_Region_code"]!=null && row["C_Region_code"].ToString()!="")
				{
					model.C_Region_code= new Guid(row["C_Region_code"].ToString());
				}
				if(row["C_Region_name"]!=null)
				{
					model.C_Region_name=row["C_Region_name"].ToString();
				}
                if (row["C_Region_abbreviation"] != null)
                {
                    model.C_Region_abbreviation = row["C_Region_abbreviation"].ToString();
                }
				if(row["C_Region_parent"]!=null && row["C_Region_parent"].ToString()!="")
				{
					model.C_Region_parent= new Guid(row["C_Region_parent"].ToString());
				}
				if(row["C_Region_level"]!=null && row["C_Region_level"].ToString()!="")
				{
					model.C_Region_level=int.Parse(row["C_Region_level"].ToString());
				}
				if(row["C_Region_creator"]!=null && row["C_Region_creator"].ToString()!="")
				{
					model.C_Region_creator= new Guid(row["C_Region_creator"].ToString());
				}
				if(row["C_Region_createTime"]!=null && row["C_Region_createTime"].ToString()!="")
				{
					model.C_Region_createTime=DateTime.Parse(row["C_Region_createTime"].ToString());
				}
				if(row["C_Region_isDelete"]!=null && row["C_Region_isDelete"].ToString()!="")
				{
					model.C_Region_isDelete=int.Parse(row["C_Region_isDelete"].ToString());
				}
                if (row["C_Region_isSpecial"] != null && row["C_Region_isSpecial"].ToString() != "")
                {
                    model.C_Region_isSpecial = int.Parse(row["C_Region_isSpecial"].ToString());
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
            strSql.Append("select C_Region_Id,C_Region_code,C_Region_name,C_Region_abbreviation,C_Region_parent,C_Region_level,C_Region_creator,C_Region_createTime,C_Region_isDelete,C_Region_isSpecial ");
			strSql.Append(" FROM C_Region ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}



        /// <summary>
        /// 通过父级GUID获取子集集合
        /// </summary>
        public DataSet GetModelByParent(Guid C_Region_parent)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Region_Id,C_Region_code,C_Region_name,C_Region_abbreviation,C_Region_parent,C_Region_level,C_Region_creator,C_Region_createTime,C_Region_isDelete,C_Region_isSpecial from C_Region ");
            strSql.Append(" where C_Region_parent=@C_Region_parent ");
            strSql.Append("and C_Region_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Region_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Region_parent;

            CommonService.Model.C_Region model = new CommonService.Model.C_Region();
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Region_Id,C_Region_code,C_Region_name,C_Region_abbreviation,C_Region_parent,C_Region_level,C_Region_creator,C_Region_createTime,C_Region_isDelete,C_Region_isSpecial ");
            strSql.Append(" FROM C_Region ");
            strSql.Append("where C_Region_isDelete=0 ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得全部特殊区域数据列表
        /// </summary>
        public DataSet GetAllSpecialList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Region_Id,C_Region_code,C_Region_name,C_Region_abbreviation,C_Region_parent,C_Region_level,C_Region_creator,C_Region_createTime,C_Region_isDelete,C_Region_isSpecial ");
            strSql.Append(" FROM C_Region ");
            strSql.Append("where C_Region_isDelete=0 and C_Region_isSpecial=0 ");

            return DbHelperSQL.Query(strSql.ToString());
        }
         /// <summary>
        /// 获得全部特殊区域数据列表
        /// </summary>
        public Guid GetRegionCodeByUsercode(Guid guid)
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Region_code from C_Organization_post_user_region where C_User_code=@C_Userinfo_code");//strSql.Append("select C_Region_code from [dbo].[C_Userinfo_region] where C_Userinfo_code=@C_Userinfo_code");      
              
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
				};
            parameters[0].Value = guid;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return new Guid(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return Guid.Empty;
            }
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
            strSql.Append(" C_Region_Id,C_Region_code,C_Region_name,C_Region_abbreviation,C_Region_parent,C_Region_level,C_Region_creator,C_Region_createTime,C_Region_isDelete,C_Region_isSpecial ");
			strSql.Append(" FROM C_Region ");
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
		public int GetRecordCount(Model.C_Region model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Region ");
            strSql.Append(" where 1=1 and C_Region_isDelete=0");
            if (model != null)
            {
                if (model.C_Region_code != null)
                {
                    strSql.Append(" and C_Region_code=@C_Region_code ");
                }
                if (model.C_Region_name != null && model.C_Region_name.ToString() != "")
                {
                    strSql.Append(" and C_Region_name=@C_Region_name ");
                }
                if (model.C_Region_isSpecial != null && model.C_Region_isSpecial.ToString() != "")
                {
                    strSql.Append(" and C_Region_isSpecial=@C_Region_isSpecial ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Region_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Region_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Region_isSpecial",SqlDbType.Int,4)};
            parameters[0].Value = model.C_Region_code;
            parameters[1].Value = model.C_Region_name;
            parameters[2].Value = model.C_Region_isSpecial;
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
		public DataSet GetListByPage(Model.C_Region model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Region_Id desc");
			}
            strSql.Append(")AS Row, T.*  from C_Region T ");
            strSql.Append(" where 1=1 and C_Region_isDelete=0");
            if (model != null)
            {
                if (model.C_Region_code != null)
                {
                    strSql.Append(" and C_Region_code=@C_Region_code ");
                }
                if (model.C_Region_name != null && model.C_Region_name.ToString() != "")
                {
                    strSql.Append(" and C_Region_name=@C_Region_name ");
                }
                if (model.C_Region_isSpecial != null && model.C_Region_isSpecial.ToString() != "")
                {
                    strSql.Append(" and C_Region_isSpecial=@C_Region_isSpecial ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Region_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Region_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Region_isSpecial",SqlDbType.Int,4)};
            parameters[0].Value = model.C_Region_code;
            parameters[1].Value = model.C_Region_name;
            parameters[2].Value = model.C_Region_isSpecial;
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
			parameters[0].Value = "C_Region";
			parameters[1].Value = "C_Region_Id";
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

