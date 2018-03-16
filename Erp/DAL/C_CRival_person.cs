using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:企业负责人表
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	public partial class C_CRival_person
	{
		public C_CRival_person()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_CRival_person_id", "C_CRival_person");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_CRival_person_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_CRival_person");
            strSql.Append(" where C_CRival_person_id=@C_CRival_person_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_person_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_CRival_person_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_CRival_person model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_CRival_person(");
			strSql.Append("C_CRival_code,C_CRival_person_sex,C_CRival_person_name,C_CRival_person_birthday,C_CRival_person_ptime,C_CRival_person_contact,C_CRival_person_education,C_CRival_person_post,C_CRival_person_experience,C_CRival_person_story,C_CRival_person_url,C_CRival_person_other_person,C_CRival_person_craeteTime,C_CRival_person_creator,C_CRival_person_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@C_CRival_code,@C_CRival_person_sex,@C_CRival_person_name,@C_CRival_person_birthday,@C_CRival_person_ptime,@C_CRival_person_contact,@C_CRival_person_education,@C_CRival_person_post,@C_CRival_person_experience,@C_CRival_person_story,@C_CRival_person_url,@C_CRival_person_other_person,@C_CRival_person_craeteTime,@C_CRival_person_creator,@C_CRival_person_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_person_sex", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_person_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_person_birthday", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_person_ptime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_person_contact", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_person_education", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_person_post", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_person_experience", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_person_story", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_person_url", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_person_other_person", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_person_craeteTime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_person_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_person_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_CRival_code;
			parameters[1].Value = model.C_CRival_person_sex;
			parameters[2].Value = model.C_CRival_person_name;
			parameters[3].Value = model.C_CRival_person_birthday;
			parameters[4].Value = model.C_CRival_person_ptime;
			parameters[5].Value = model.C_CRival_person_contact;
			parameters[6].Value = model.C_CRival_person_education;
			parameters[7].Value = model.C_CRival_person_post;
			parameters[8].Value = model.C_CRival_person_experience;
			parameters[9].Value = model.C_CRival_person_story;
			parameters[10].Value = model.C_CRival_person_url;
			parameters[11].Value = model.C_CRival_person_other_person;
			parameters[12].Value = model.C_CRival_person_craeteTime;
            parameters[13].Value = model.C_CRival_person_creator;
			parameters[14].Value = model.C_CRival_person_isDelete;

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
        public bool Update(CommonService.Model.C_CRival_person model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_CRival_person set ");
			strSql.Append("C_CRival_code=@C_CRival_code,");
			strSql.Append("C_CRival_person_sex=@C_CRival_person_sex,");
			strSql.Append("C_CRival_person_name=@C_CRival_person_name,");
			strSql.Append("C_CRival_person_birthday=@C_CRival_person_birthday,");
			strSql.Append("C_CRival_person_ptime=@C_CRival_person_ptime,");
			strSql.Append("C_CRival_person_contact=@C_CRival_person_contact,");
			strSql.Append("C_CRival_person_education=@C_CRival_person_education,");
			strSql.Append("C_CRival_person_post=@C_CRival_person_post,");
			strSql.Append("C_CRival_person_experience=@C_CRival_person_experience,");
			strSql.Append("C_CRival_person_story=@C_CRival_person_story,");
			strSql.Append("C_CRival_person_url=@C_CRival_person_url,");
			strSql.Append("C_CRival_person_other_person=@C_CRival_person_other_person,");
			strSql.Append("C_CRival_person_craeteTime=@C_CRival_person_craeteTime,");
			strSql.Append("C_CRival_person_creator=@C_CRival_person_creator,");
			strSql.Append("C_CRival_person_isDelete=@C_CRival_person_isDelete");
			strSql.Append(" where C_CRival_person_id=@C_CRival_person_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_person_sex", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_person_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_person_birthday", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_person_ptime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_person_contact", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_person_education", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_person_post", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_person_experience", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_person_story", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_person_url", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_person_other_person", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_person_craeteTime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_person_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_person_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_person_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_CRival_code;
			parameters[1].Value = model.C_CRival_person_sex;
			parameters[2].Value = model.C_CRival_person_name;
			parameters[3].Value = model.C_CRival_person_birthday;
			parameters[4].Value = model.C_CRival_person_ptime;
			parameters[5].Value = model.C_CRival_person_contact;
			parameters[6].Value = model.C_CRival_person_education;
			parameters[7].Value = model.C_CRival_person_post;
			parameters[8].Value = model.C_CRival_person_experience;
			parameters[9].Value = model.C_CRival_person_story;
			parameters[10].Value = model.C_CRival_person_url;
			parameters[11].Value = model.C_CRival_person_other_person;
			parameters[12].Value = model.C_CRival_person_craeteTime;
			parameters[13].Value = model.C_CRival_person_creator;
			parameters[14].Value = model.C_CRival_person_isDelete;
			parameters[15].Value = model.C_CRival_person_id;

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
		public bool Delete(int C_CRival_person_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_CRival_person set C_CRival_person_isDelete=1");
			strSql.Append(" where C_CRival_person_id=@C_CRival_person_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_person_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_CRival_person_id;

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
		public bool DeleteList(string C_CRival_person_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_CRival_person ");
			strSql.Append(" where C_CRival_person_id in ("+C_CRival_person_idlist + ")  ");
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
        public CommonService.Model.C_CRival_person GetModel(int C_CRival_person_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_CRival_person_id,C_CRival_code,C_CRival_person_sex,C_CRival_person_name,C_CRival_person_birthday,C_CRival_person_ptime,C_CRival_person_contact,C_CRival_person_education,C_CRival_person_post,C_CRival_person_experience,C_CRival_person_story,C_CRival_person_url,C_CRival_person_other_person,C_CRival_person_craeteTime,C_CRival_person_creator,C_CRival_person_isDelete from C_CRival_person ");
			strSql.Append(" where C_CRival_person_id=@C_CRival_person_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_person_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_CRival_person_id;

            CommonService.Model.C_CRival_person model = new CommonService.Model.C_CRival_person();
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
        public CommonService.Model.C_CRival_person DataRowToModel(DataRow row)
		{
            CommonService.Model.C_CRival_person model = new CommonService.Model.C_CRival_person();
			if (row != null)
			{
				if(row["C_CRival_person_id"]!=null && row["C_CRival_person_id"].ToString()!="")
				{
					model.C_CRival_person_id=int.Parse(row["C_CRival_person_id"].ToString());
				}
				if(row["C_CRival_code"]!=null && row["C_CRival_code"].ToString()!="")
				{
					model.C_CRival_code= new Guid(row["C_CRival_code"].ToString());
				}
				if(row["C_CRival_person_sex"]!=null && row["C_CRival_person_sex"].ToString()!="")
				{
					model.C_CRival_person_sex=int.Parse(row["C_CRival_person_sex"].ToString());
				}
				if(row["C_CRival_person_name"]!=null)
				{
					model.C_CRival_person_name=row["C_CRival_person_name"].ToString();
				}
				if(row["C_CRival_person_birthday"]!=null && row["C_CRival_person_birthday"].ToString()!="")
				{
					model.C_CRival_person_birthday=DateTime.Parse(row["C_CRival_person_birthday"].ToString());
				}
				if(row["C_CRival_person_ptime"]!=null && row["C_CRival_person_ptime"].ToString()!="")
				{
					model.C_CRival_person_ptime=DateTime.Parse(row["C_CRival_person_ptime"].ToString());
				}
				if(row["C_CRival_person_contact"]!=null)
				{
					model.C_CRival_person_contact=row["C_CRival_person_contact"].ToString();
				}
				if(row["C_CRival_person_education"]!=null)
				{
					model.C_CRival_person_education=row["C_CRival_person_education"].ToString();
				}
				if(row["C_CRival_person_post"]!=null)
				{
					model.C_CRival_person_post=row["C_CRival_person_post"].ToString();
				}
				if(row["C_CRival_person_experience"]!=null)
				{
					model.C_CRival_person_experience=row["C_CRival_person_experience"].ToString();
				}
				if(row["C_CRival_person_story"]!=null)
				{
					model.C_CRival_person_story=row["C_CRival_person_story"].ToString();
				}
				if(row["C_CRival_person_url"]!=null)
				{
					model.C_CRival_person_url=row["C_CRival_person_url"].ToString();
				}
				if(row["C_CRival_person_other_person"]!=null)
				{
					model.C_CRival_person_other_person=row["C_CRival_person_other_person"].ToString();
				}
				if(row["C_CRival_person_craeteTime"]!=null && row["C_CRival_person_craeteTime"].ToString()!="")
				{
					model.C_CRival_person_craeteTime=DateTime.Parse(row["C_CRival_person_craeteTime"].ToString());
				}
				if(row["C_CRival_person_creator"]!=null && row["C_CRival_person_creator"].ToString()!="")
				{
					model.C_CRival_person_creator= new Guid(row["C_CRival_person_creator"].ToString());
				}
				if(row["C_CRival_person_isDelete"]!=null && row["C_CRival_person_isDelete"].ToString()!="")
				{
					model.C_CRival_person_isDelete=int.Parse(row["C_CRival_person_isDelete"].ToString());
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
			strSql.Append("select C_CRival_person_id,C_CRival_code,C_CRival_person_sex,C_CRival_person_name,C_CRival_person_birthday,C_CRival_person_ptime,C_CRival_person_contact,C_CRival_person_education,C_CRival_person_post,C_CRival_person_experience,C_CRival_person_story,C_CRival_person_url,C_CRival_person_other_person,C_CRival_person_craeteTime,C_CRival_person_creator,C_CRival_person_isDelete ");
			strSql.Append(" FROM C_CRival_person ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" C_CRival_person_id,C_CRival_code,C_CRival_person_sex,C_CRival_person_name,C_CRival_person_birthday,C_CRival_person_ptime,C_CRival_person_contact,C_CRival_person_education,C_CRival_person_post,C_CRival_person_experience,C_CRival_person_story,C_CRival_person_url,C_CRival_person_other_person,C_CRival_person_craeteTime,C_CRival_person_creator,C_CRival_person_isDelete ");
			strSql.Append(" FROM C_CRival_person ");
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
		public int GetRecordCount(Model.C_CRival_person model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_CRival_person ");
            strSql.Append(" where 1=1 and C_CRival_person_isDelete=0 ");
            if (model != null)
            {
                if (model.C_CRival_code != null)
                {
                    strSql.Append("and C_CRival_code=@C_CRival_code");
                }
            }

            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_CRival_code;
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
		public DataSet GetListByPage(Model.C_CRival_person model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_CRival_person_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_CRival_person T ");
            strSql.Append(" where 1=1 and C_CRival_person_isDelete=0 ");
            if (model != null)
            {
                if (model.C_CRival_code != null)
                {
                    strSql.Append("and C_CRival_code=@C_CRival_code");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_CRival_code;

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
			parameters[0].Value = "C_CRival_person";
			parameters[1].Value = "C_CRival_person_id";
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

