using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:法院律师关联表
    /// 作者：崔慧栋
    /// 日期：2015/08/22
    /// </summary>
	public partial class C_Court_Lawyer
	{
		public C_Court_Lawyer()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("C_Court_Lawyer_id", "C_Court_Lawyer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(Guid lawyerCode, Guid courtCodes)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Court_Lawyer");
            strSql.Append(" where C_Court_Lawyer_isDelete=0 ");
            strSql.Append("and C_Lawyer=@C_Lawyer ");
            strSql.Append("and C_Court=@C_Court ");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Lawyer", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Court",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = lawyerCode;
            parameters[1].Value = courtCodes;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Court_Lawyer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Court_Lawyer(");
			strSql.Append("C_Court_Lawyer_code,C_Lawyer,C_Court,C_Court_Lawyer_isDelete,C_Court_Lawyer_creator,C_Court_Lawyer_creatTime)");
			strSql.Append(" values (");
			strSql.Append("@C_Court_Lawyer_code,@C_Lawyer,@C_Court,@C_Court_Lawyer_isDelete,@C_Court_Lawyer_creator,@C_Court_Lawyer_creatTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Court_Lawyer_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Lawyer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Lawyer_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Court_Lawyer_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Lawyer_creatTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Court_Lawyer_code;
			parameters[1].Value = model.C_Lawyer;
			parameters[2].Value = model.C_Court;
			parameters[3].Value = model.C_Court_Lawyer_isDelete;
			parameters[4].Value = model.C_Court_Lawyer_creator;
			parameters[5].Value = model.C_Court_Lawyer_creatTime;

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
        public bool Update(CommonService.Model.C_Court_Lawyer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Court_Lawyer set ");
			strSql.Append("C_Court_Lawyer_code=@C_Court_Lawyer_code,");
			strSql.Append("C_Lawyer=@C_Lawyer,");
			strSql.Append("C_Court=@C_Court,");
			strSql.Append("C_Court_Lawyer_isDelete=@C_Court_Lawyer_isDelete,");
			strSql.Append("C_Court_Lawyer_creator=@C_Court_Lawyer_creator,");
			strSql.Append("C_Court_Lawyer_creatTime=@C_Court_Lawyer_creatTime");
			strSql.Append(" where C_Court_Lawyer_id=@C_Court_Lawyer_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Court_Lawyer_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Lawyer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Lawyer_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Court_Lawyer_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_Lawyer_creatTime", SqlDbType.DateTime),
					new SqlParameter("@C_Court_Lawyer_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Court_Lawyer_code;
			parameters[1].Value = model.C_Lawyer;
			parameters[2].Value = model.C_Court;
			parameters[3].Value = model.C_Court_Lawyer_isDelete;
			parameters[4].Value = model.C_Court_Lawyer_creator;
			parameters[5].Value = model.C_Court_Lawyer_creatTime;
			parameters[6].Value = model.C_Court_Lawyer_id;

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
		public bool Delete(Guid lawyerCode, Guid courtCodes)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Court_Lawyer set C_Court_Lawyer_isDelete=1");
            strSql.Append(" where C_Lawyer=@C_Lawyer ");
            strSql.Append("and C_Court=@C_Court ");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Lawyer", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Court",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = lawyerCode;
            parameters[1].Value = courtCodes;

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
		public bool DeleteList(string C_Court_Lawyer_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Court_Lawyer ");
			strSql.Append(" where C_Court_Lawyer_id in ("+C_Court_Lawyer_idlist + ")  ");
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
        public CommonService.Model.C_Court_Lawyer GetModel(int C_Court_Lawyer_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_Court_Lawyer_id,C_Court_Lawyer_code,C_Lawyer,C_Court,C_Court_Lawyer_isDelete,C_Court_Lawyer_creator,C_Court_Lawyer_creatTime from C_Court_Lawyer ");
			strSql.Append(" where C_Court_Lawyer_id=@C_Court_Lawyer_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Court_Lawyer_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Court_Lawyer_id;

            CommonService.Model.C_Court_Lawyer model = new CommonService.Model.C_Court_Lawyer();
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
        public CommonService.Model.C_Court_Lawyer DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Court_Lawyer model = new CommonService.Model.C_Court_Lawyer();
			if (row != null)
			{
				if(row["C_Court_Lawyer_id"]!=null && row["C_Court_Lawyer_id"].ToString()!="")
				{
					model.C_Court_Lawyer_id=int.Parse(row["C_Court_Lawyer_id"].ToString());
				}
				if(row["C_Court_Lawyer_code"]!=null && row["C_Court_Lawyer_code"].ToString()!="")
				{
					model.C_Court_Lawyer_code= new Guid(row["C_Court_Lawyer_code"].ToString());
				}
				if(row["C_Lawyer"]!=null && row["C_Lawyer"].ToString()!="")
				{
					model.C_Lawyer= new Guid(row["C_Lawyer"].ToString());
				}
				if(row["C_Court"]!=null && row["C_Court"].ToString()!="")
				{
					model.C_Court= new Guid(row["C_Court"].ToString());
				}
				if(row["C_Court_Lawyer_isDelete"]!=null && row["C_Court_Lawyer_isDelete"].ToString()!="")
				{
					if((row["C_Court_Lawyer_isDelete"].ToString()=="1")||(row["C_Court_Lawyer_isDelete"].ToString().ToLower()=="true"))
					{
						model.C_Court_Lawyer_isDelete=true;
					}
					else
					{
						model.C_Court_Lawyer_isDelete=false;
					}
				}
				if(row["C_Court_Lawyer_creator"]!=null && row["C_Court_Lawyer_creator"].ToString()!="")
				{
					model.C_Court_Lawyer_creator= new Guid(row["C_Court_Lawyer_creator"].ToString());
				}
				if(row["C_Court_Lawyer_creatTime"]!=null && row["C_Court_Lawyer_creatTime"].ToString()!="")
				{
					model.C_Court_Lawyer_creatTime=DateTime.Parse(row["C_Court_Lawyer_creatTime"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.Customer.V_Lawyer DataRowToLawyerModel(DataRow row)
        {
            CommonService.Model.Customer.V_Lawyer model = new CommonService.Model.Customer.V_Lawyer();
            if (row != null)
            {
                if (row["LawyerId"] != null && row["LawyerId"].ToString() != "")
                {
                    model.LawyerId = int.Parse(row["LawyerId"].ToString());
                }
                if (row["C_Userinfo_code"] != null && row["C_Userinfo_code"].ToString() != "")
                {
                    model.C_Userinfo_code = new Guid(row["C_Userinfo_code"].ToString());
                }
                if(row["C_Userinfo_name"]!=null && row["C_Userinfo_name"].ToString()!="")
                {
                    model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
                }
                if(row["C_Userinfo_roleID"]!=null && row["C_Userinfo_roleID"].ToString()!="")
                {
                    model.C_Userinfo_roleID = int.Parse(row["C_Userinfo_roleID"].ToString());
                }
                if(row["C_Userinfo_parent"]!=null && row["C_Userinfo_parent"].ToString()!="")
                {
                    model.C_Userinfo_parent = new Guid(row["C_Userinfo_parent"].ToString());
                }
                if(row["C_Userinfo_description"]!=null && row["C_Userinfo_description"].ToString()!="")
                {
                    model.C_Userinfo_description = row["C_Userinfo_description"].ToString();
                }
                if (row["C_Userinfo_state"] != null && row["C_Userinfo_state"].ToString() != "")
                {
                    model.C_Userinfo_state = int.Parse(row["C_Userinfo_state"].ToString());
                }
                if (row["C_Userinfo_Organization"] != null && row["C_Userinfo_Organization"].ToString() != "")
                {
                    model.C_Userinfo_Organization = new Guid(row["C_Userinfo_Organization"].ToString());
                }
                if (row["C_Userinfo_post"] != null && row["C_Userinfo_post"].ToString() != "")
                {
                    model.C_Userinfo_post = new Guid(row["C_Userinfo_post"].ToString());
                }
                if (row["C_Userinfo_isDefault"] != null && row["C_Userinfo_isDefault"].ToString() != "")
                {
                    if ((row["C_Userinfo_isDefault"].ToString() == "1") || (row["C_Userinfo_isDefault"].ToString().ToLower() == "true"))
                    {
                        model.C_Userinfo_isDefault = true;
                    }
                    else
                    {
                        model.C_Userinfo_isDefault = false;
                    }
                }
                if (row.Table.Columns.Contains("C_Userinfo_Organization_name"))
                {
                    if (row["C_Userinfo_Organization_name"] != null && row["C_Userinfo_Organization_name"].ToString() != "")
                    {
                        model.C_Userinfo_Organization_name = row["C_Userinfo_Organization_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Userinfo_post_name"))
                {
                    if (row["C_Userinfo_post_name"] != null && row["C_Userinfo_post_name"].ToString() != "")
                    {
                        model.C_Userinfo_post_name = row["C_Userinfo_post_name"].ToString();
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
			strSql.Append("select C_Court_Lawyer_id,C_Court_Lawyer_code,C_Lawyer,C_Court,C_Court_Lawyer_isDelete,C_Court_Lawyer_creator,C_Court_Lawyer_creatTime ");
			strSql.Append(" FROM C_Court_Lawyer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据法院获得数据列表
        /// </summary>
        public DataSet GetListByCourt(Guid C_Court)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Court_Lawyer_id,C_Court_Lawyer_code,C_Lawyer,C_Court,C_Court_Lawyer_isDelete,C_Court_Lawyer_creator,C_Court_Lawyer_creatTime ");
            strSql.Append(" FROM C_Court_Lawyer ");
            strSql.Append("where C_Court=@C_Court ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = C_Court;
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
			strSql.Append(" C_Court_Lawyer_id,C_Court_Lawyer_code,C_Lawyer,C_Court,C_Court_Lawyer_isDelete,C_Court_Lawyer_creator,C_Court_Lawyer_creatTime ");
			strSql.Append(" FROM C_Court_Lawyer ");
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
		public int GetRecordCount(CommonService.Model.Customer.V_Lawyer model)
		{
            SqlParameter[] parameters = {
					new SqlParameter("@startIndex", SqlDbType.Int,4),
                    new SqlParameter("@endIndex",SqlDbType.Int,4),
                    new SqlParameter("@LawyerName",SqlDbType.VarChar)};
            parameters[0].Value = 1;
            parameters[1].Value = 1000000;
            parameters[2].Value = model.C_Userinfo_name;
            DataSet ds = DbHelperSQL.RunProcedure("proc_GetAllLawyer", parameters, "Lawyer");
            if (ds == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(ds.Tables[0].Rows.Count);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(CommonService.Model.Customer.V_Lawyer model, string orderby, int startIndex, int endIndex)
		{
            SqlParameter[] parameters = {
					new SqlParameter("@startIndex", SqlDbType.Int,4),
                    new SqlParameter("@endIndex",SqlDbType.Int,4),
                    new SqlParameter("@LawyerName",SqlDbType.VarChar)};
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = model.C_Userinfo_name;
            return DbHelperSQL.RunProcedure("proc_GetAllLawyer", parameters, "Lawyer");
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
			parameters[0].Value = "C_Court_Lawyer";
			parameters[1].Value = "C_Court_Lawyer_id";
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

