using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:法院法官关联表
    /// 作者：崔慧栋
    /// 日期：2015/05/08
    /// </summary>
	public partial class C_Court_Judge
	{
		public C_Court_Judge()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Court_Judge_id", "C_Court_Judge");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Court_Judge_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Court_Judge");
            strSql.Append(" where C_Court_Judge_id=@C_Court_Judge_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_Judge_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Court_Judge_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Court_Judge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Court_Judge(");
			strSql.Append("C_Court_code,C_Judge_code,C_Court_Judge_name,C_Court_Judge_duty,C_Court_Judge_type,C_Court_Judge_isdelete,C_Court_Judge_creator,C_Court_Judge_createTime)");
			strSql.Append(" values (");
			strSql.Append("@C_Court_code,@C_Judge_code,@C_Court_Judge_name,@C_Court_Judge_duty,@C_Court_Judge_type,@C_Court_Judge_isdelete,@C_Court_Judge_creator,@C_Court_Judge_createTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Judge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Judge_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_Judge_duty", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_Judge_type", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_Judge_isdelete", SqlDbType.Int,4),
					new SqlParameter("@C_Court_Judge_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Judge_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Judge_code;
			parameters[2].Value = model.C_Court_Judge_name;
			parameters[3].Value = model.C_Court_Judge_duty;
			parameters[4].Value = model.C_Court_Judge_type;
			parameters[5].Value = model.C_Court_Judge_isdelete;
			parameters[6].Value =model.C_Court_Judge_creator;
			parameters[7].Value = model.C_Court_Judge_createTime;

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
        public bool Update(CommonService.Model.C_Court_Judge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Court_Judge set ");
			strSql.Append("C_Court_code=@C_Court_code,");
			strSql.Append("C_Judge_code=@C_Judge_code,");
			strSql.Append("C_Court_Judge_name=@C_Court_Judge_name,");
			strSql.Append("C_Court_Judge_duty=@C_Court_Judge_duty,");
			strSql.Append("C_Court_Judge_type=@C_Court_Judge_type,");
			strSql.Append("C_Court_Judge_isdelete=@C_Court_Judge_isdelete,");
			strSql.Append("C_Court_Judge_creator=@C_Court_Judge_creator,");
			strSql.Append("C_Court_Judge_createTime=@C_Court_Judge_createTime");
			strSql.Append(" where C_Court_Judge_id=@C_Court_Judge_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Judge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Judge_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_Judge_duty", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_Judge_type", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_Judge_isdelete", SqlDbType.Int,4),
					new SqlParameter("@C_Court_Judge_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Judge_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Court_Judge_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Court_code;
			parameters[1].Value = model.C_Judge_code;
			parameters[2].Value = model.C_Court_Judge_name;
			parameters[3].Value = model.C_Court_Judge_duty;
			parameters[4].Value = model.C_Court_Judge_type;
			parameters[5].Value = model.C_Court_Judge_isdelete;
			parameters[6].Value = model.C_Court_Judge_creator;
			parameters[7].Value = model.C_Court_Judge_createTime;
			parameters[8].Value = model.C_Court_Judge_id;

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
		public bool Delete(Model.C_Court_Judge model)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Court_Judge set C_Court_Judge_isdelete=1");
            strSql.Append(" where C_Court_code=@C_Court_code and C_Court_Judge_type=@C_Court_Judge_type and C_Court_Judge_duty=@C_Court_Judge_duty and C_Judge_code=@C_Judge_code");
			SqlParameter[] parameters = {
                    new SqlParameter("@C_Court_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Court_Judge_type",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Court_Judge_duty",SqlDbType.VarChar,200),
					new SqlParameter("@C_Judge_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Court_Judge_type;
            parameters[2].Value = model.C_Court_Judge_duty;
            parameters[3].Value =model.C_Judge_code;

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
		public bool DeleteList(string C_Court_Judge_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Court_Judge ");
			strSql.Append(" where C_Court_Judge_id in ("+C_Court_Judge_idlist + ")  ");
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
        public CommonService.Model.C_Court_Judge GetModel(int C_Court_Judge_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_Court_Judge_id,C_Court_code,C_Judge_code,C_Court_Judge_name,C_Court_Judge_duty,C_Court_Judge_type,C_Court_Judge_isdelete,C_Court_Judge_creator,C_Court_Judge_createTime from C_Court_Judge ");
			strSql.Append(" where C_Court_Judge_id=@C_Court_Judge_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Court_Judge_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Court_Judge_id;

            CommonService.Model.C_Court_Judge model = new CommonService.Model.C_Court_Judge();
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
        public CommonService.Model.C_Court_Judge DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Court_Judge model = new CommonService.Model.C_Court_Judge();
			if (row != null)
			{
				if(row["C_Court_Judge_id"]!=null && row["C_Court_Judge_id"].ToString()!="")
				{
					model.C_Court_Judge_id=int.Parse(row["C_Court_Judge_id"].ToString());
				}
				if(row["C_Court_code"]!=null && row["C_Court_code"].ToString()!="")
				{
					model.C_Court_code= new Guid(row["C_Court_code"].ToString());
				}
				if(row["C_Judge_code"]!=null && row["C_Judge_code"].ToString()!="")
				{
					model.C_Judge_code= new Guid(row["C_Judge_code"].ToString());
				}
                //判断法官姓名（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Contacts_name"))
                {
                    if (row["C_Contacts_name"] != null)
                    {
                        model.C_Contacts_name = row["C_Contacts_name"].ToString();
                    }
                }
				if(row["C_Court_Judge_name"]!=null)
				{
					model.C_Court_Judge_name=row["C_Court_Judge_name"].ToString();
				}
				if(row["C_Court_Judge_duty"]!=null)
				{
					model.C_Court_Judge_duty=row["C_Court_Judge_duty"].ToString();
				}
				if(row["C_Court_Judge_type"]!=null)
				{
					model.C_Court_Judge_type=row["C_Court_Judge_type"].ToString();
				}
				if(row["C_Court_Judge_isdelete"]!=null && row["C_Court_Judge_isdelete"].ToString()!="")
				{
					model.C_Court_Judge_isdelete=int.Parse(row["C_Court_Judge_isdelete"].ToString());
				}
				if(row["C_Court_Judge_creator"]!=null && row["C_Court_Judge_creator"].ToString()!="")
				{
					model.C_Court_Judge_creator= new Guid(row["C_Court_Judge_creator"].ToString());
				}
				if(row["C_Court_Judge_createTime"]!=null && row["C_Court_Judge_createTime"].ToString()!="")
				{
					model.C_Court_Judge_createTime=DateTime.Parse(row["C_Court_Judge_createTime"].ToString());
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
			strSql.Append("select C_Court_Judge_id,C_Court_code,C_Judge_code,C_Court_Judge_name,C_Court_Judge_duty,C_Court_Judge_type,C_Court_Judge_isdelete,C_Court_Judge_creator,C_Court_Judge_createTime ");
			strSql.Append(" FROM C_Court_Judge ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据职务获得数据列表
        /// </summary>
        public DataSet GetListByDuty(Model.C_Court_Judge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Court_Judge_id,C_Court_code,C_Judge_code,C_Court_Judge_name,C_Court_Judge_duty,C_Court_Judge_type,C_Court_Judge_isdelete,C_Court_Judge_creator,C_Court_Judge_createTime ");
            strSql.Append(" FROM C_Court_Judge ");
            strSql.Append("where C_Court_code=@C_Court_code and C_Court_Judge_type=@C_Court_Judge_type and C_Court_Judge_duty=@C_Court_Judge_duty ");
            strSql.Append("and C_Court_Judge_isdelete=0 ");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Court_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Court_Judge_type",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Court_Judge_duty",SqlDbType.VarChar,200)
			};
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Court_Judge_type;
            parameters[2].Value = model.C_Court_Judge_duty;

            return DbHelperSQL.Query(strSql.ToString(),parameters);
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
			strSql.Append(" C_Court_Judge_id,C_Court_code,C_Judge_code,C_Court_Judge_name,C_Court_Judge_duty,C_Court_Judge_type,C_Court_Judge_isdelete,C_Court_Judge_creator,C_Court_Judge_createTime ");
			strSql.Append(" FROM C_Court_Judge ");
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
		public int GetRecordCount(Model.C_Court_Judge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Court_Judge ");
            strSql.Append(" where 1=1 and C_Court_Judge_isdelete=0 ");
            if (model != null)
            {

                if (model.C_Court_code != null )
                {
                    strSql.Append(" and C_Court_code=@C_Court_code");
                }
                if (model.C_Judge_code != null)
                {
                    strSql.Append(" and C_Judge_code=@C_Judge_code");
                }
                if (model.C_Court_Judge_name != null && model.C_Court_Judge_name!="")
                {
                    strSql.Append(" and C_Court_Judge_name=@C_Court_Judge_name");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Judge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Judge_name", SqlDbType.VarChar,100)};
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Judge_code;
            parameters[2].Value = model.C_Court_Judge_name;
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
		public DataSet GetListByPage(Model.C_Court_Judge model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_Court_Judge_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_Court_Judge T ");
            strSql.Append(" where 1=1 and C_Court_Judge_isdelete=0 ");
            if (model != null)
            {

                if (model.C_Court_code != null)
                {
                    strSql.Append(" and C_Court_code=@C_Court_code");
                }
                if (model.C_Judge_code != null)
                {
                    strSql.Append(" and C_Judge_code=@C_Judge_code");
                }
                if (model.C_Court_Judge_name != null && model.C_Court_Judge_name != "")
                {
                    strSql.Append(" and C_Court_Judge_name=@C_Court_Judge_name");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Judge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Judge_name", SqlDbType.VarChar,100)};
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Judge_code;
            parameters[2].Value = model.C_Court_Judge_name;
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据法院Code获取，法院关联法官集合
        /// </summary>
        /// <param name="courtCode">法院Code</param>
        /// <returns></returns>
        public DataSet GetListByCourt(Guid courtCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CJ.C_Court_Judge_id,CJ.C_Court_code,CJ.C_Judge_code,CJ.C_Court_Judge_name,CJ.C_Court_Judge_duty,CJ.C_Court_Judge_type,CJ.C_Court_Judge_isdelete,CJ.C_Court_Judge_creator,CJ.C_Court_Judge_createTime,J.C_Contacts_name ");
            strSql.Append("from C_Court_Judge as CJ left join ");
            strSql.Append("(select b.C_Contacts_name,a.C_Judge_code FROM C_Judge as a left join C_Contacts as b on a.C_Judge_contactscode=b.C_Contacts_code where a.C_Judge_isdelete=0 ) as J on CJ.C_Judge_code=J.C_Judge_code ");
            strSql.Append("where CJ.C_Court_code=@C_Court_code and CJ.C_Court_Judge_isdelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = courtCode;
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
			parameters[0].Value = "C_Court_Judge";
			parameters[1].Value = "C_Court_Judge_id";
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

