using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件结案审核表
    /// 作者：崔慧栋
    /// 日期：2015/12/24
    /// </summary>
	public partial class B_Case_Check
	{
		public B_Case_Check()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("B_Case_Check_id", "B_Case_Check"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int B_Case_Check_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_Case_Check");
			strSql.Append(" where B_Case_Check_id=@B_Case_Check_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Check_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_Case_Check_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_Check model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_Case_Check(");
			strSql.Append("B_Case_Check_code,B_Case_Confirm_code,B_Case_Check_State,B_Case_Check_Type,B_Case_Check_checkPerson,B_Case_Check_checkTime,B_Case_Check_SuggestContent,B_Case_Check_order,B_Case_Check_creator,B_Case_Check_createTime,B_Case_Check_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_Case_Check_code,@B_Case_Confirm_code,@B_Case_Check_State,@B_Case_Check_Type,@B_Case_Check_checkPerson,@B_Case_Check_checkTime,@B_Case_Check_SuggestContent,@B_Case_Check_order,@B_Case_Check_creator,@B_Case_Check_createTime,@B_Case_Check_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Check_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Check_State", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Check_Type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Check_checkPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Check_checkTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_Check_SuggestContent", SqlDbType.NVarChar,500),
					new SqlParameter("@B_Case_Check_order", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Check_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Check_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_Check_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.B_Case_Check_code;
            parameters[1].Value = model.B_Case_Confirm_code;
			parameters[2].Value = model.B_Case_Check_State;
			parameters[3].Value = model.B_Case_Check_Type;
            parameters[4].Value = model.B_Case_Check_checkPerson;
			parameters[5].Value = model.B_Case_Check_checkTime;
			parameters[6].Value = model.B_Case_Check_SuggestContent;
			parameters[7].Value = model.B_Case_Check_order;
            parameters[8].Value = model.B_Case_Check_creator;
			parameters[9].Value = model.B_Case_Check_createTime;
			parameters[10].Value = model.B_Case_Check_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_Case_Check model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_Case_Check set ");
			strSql.Append("B_Case_Check_code=@B_Case_Check_code,");
			strSql.Append("B_Case_Confirm_code=@B_Case_Confirm_code,");
			strSql.Append("B_Case_Check_State=@B_Case_Check_State,");
			strSql.Append("B_Case_Check_Type=@B_Case_Check_Type,");
			strSql.Append("B_Case_Check_checkPerson=@B_Case_Check_checkPerson,");
			strSql.Append("B_Case_Check_checkTime=@B_Case_Check_checkTime,");
			strSql.Append("B_Case_Check_SuggestContent=@B_Case_Check_SuggestContent,");
			strSql.Append("B_Case_Check_order=@B_Case_Check_order,");
			strSql.Append("B_Case_Check_creator=@B_Case_Check_creator,");
			strSql.Append("B_Case_Check_createTime=@B_Case_Check_createTime,");
			strSql.Append("B_Case_Check_isDelete=@B_Case_Check_isDelete");
			strSql.Append(" where B_Case_Check_id=@B_Case_Check_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Check_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Check_State", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Check_Type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Check_checkPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Check_checkTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_Check_SuggestContent", SqlDbType.NVarChar,500),
					new SqlParameter("@B_Case_Check_order", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Check_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Check_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_Check_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@B_Case_Check_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_Case_Check_code;
			parameters[1].Value = model.B_Case_Confirm_code;
			parameters[2].Value = model.B_Case_Check_State;
			parameters[3].Value = model.B_Case_Check_Type;
			parameters[4].Value = model.B_Case_Check_checkPerson;
			parameters[5].Value = model.B_Case_Check_checkTime;
			parameters[6].Value = model.B_Case_Check_SuggestContent;
			parameters[7].Value = model.B_Case_Check_order;
			parameters[8].Value = model.B_Case_Check_creator;
			parameters[9].Value = model.B_Case_Check_createTime;
			parameters[10].Value = model.B_Case_Check_isDelete;
			parameters[11].Value = model.B_Case_Check_id;

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
		public bool Delete(int B_Case_Check_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_Case_Check set B_Case_Check_isDelete=1");
			strSql.Append(" where B_Case_Check_id=@B_Case_Check_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Check_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_Case_Check_id;

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
        public bool Delete(Guid B_Case_Check_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case_Check set B_Case_Check_isDelete=1");
            strSql.Append(" where B_Case_Check_code=@B_Case_Check_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Check_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Check_code;

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
        /// 根据案件确认Guid删除关联数据
        /// </summary>
        public bool DeleteByConfirmCode(Guid B_Case_Confirm_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case_Check set B_Case_Check_isDelete=1");
            strSql.Append(" where B_Case_Confirm_code=@B_Case_Confirm_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Confirm_code;

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
		public bool DeleteList(string B_Case_Check_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_Case_Check ");
			strSql.Append(" where B_Case_Check_id in ("+B_Case_Check_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_Case_Check GetModel(int B_Case_Check_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 B_Case_Check_id,B_Case_Check_code,B_Case_Confirm_code,B_Case_Check_State,B_Case_Check_Type,B_Case_Check_checkPerson,B_Case_Check_checkTime,B_Case_Check_SuggestContent,B_Case_Check_order,B_Case_Check_creator,B_Case_Check_createTime,B_Case_Check_isDelete from B_Case_Check ");
			strSql.Append(" where B_Case_Check_id=@B_Case_Check_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Check_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_Case_Check_id;

            CommonService.Model.CaseManager.B_Case_Check model = new CommonService.Model.CaseManager.B_Case_Check();
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
        /// 根据案件确认Guid获得
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Check GetModelByConfirmAndOrder(Guid B_Case_Confirm_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_Check_id,B_Case_Check_code,B_Case_Confirm_code,B_Case_Check_State,B_Case_Check_Type,B_Case_Check_checkPerson,B_Case_Check_checkTime,B_Case_Check_SuggestContent,B_Case_Check_order,B_Case_Check_creator,B_Case_Check_createTime,B_Case_Check_isDelete from B_Case_Check ");
            strSql.Append(" where B_Case_Check_isDelete=0 and B_Case_Confirm_code=@B_Case_Confirm_code");
            strSql.Append(" and B_Case_Check_State=966");//状态为"未开始"
            strSql.Append(" order by B_Case_Check_order Asc");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Confirm_code;

            CommonService.Model.CaseManager.B_Case_Check model = new CommonService.Model.CaseManager.B_Case_Check();
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
        public CommonService.Model.CaseManager.B_Case_Check GetModel(Guid B_Case_Check_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_Check_id,B_Case_Check_code,B_Case_Confirm_code,B_Case_Check_State,B_Case_Check_Type,B_Case_Check_checkPerson,B_Case_Check_checkTime,B_Case_Check_SuggestContent,B_Case_Check_order,B_Case_Check_creator,B_Case_Check_createTime,B_Case_Check_isDelete from B_Case_Check ");
            strSql.Append(" where B_Case_Check_code=@B_Case_Check_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Check_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Check_code;

            CommonService.Model.CaseManager.B_Case_Check model = new CommonService.Model.CaseManager.B_Case_Check();
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
        public CommonService.Model.CaseManager.B_Case_Check DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_Case_Check model = new CommonService.Model.CaseManager.B_Case_Check();
			if (row != null)
			{
				if(row["B_Case_Check_id"]!=null && row["B_Case_Check_id"].ToString()!="")
				{
					model.B_Case_Check_id=int.Parse(row["B_Case_Check_id"].ToString());
				}
				if(row["B_Case_Check_code"]!=null && row["B_Case_Check_code"].ToString()!="")
				{
					model.B_Case_Check_code= new Guid(row["B_Case_Check_code"].ToString());
				}
				if(row["B_Case_Confirm_code"]!=null && row["B_Case_Confirm_code"].ToString()!="")
				{
					model.B_Case_Confirm_code= new Guid(row["B_Case_Confirm_code"].ToString());
				}
				if(row["B_Case_Check_State"]!=null && row["B_Case_Check_State"].ToString()!="")
				{
					model.B_Case_Check_State=int.Parse(row["B_Case_Check_State"].ToString());
				}
				if(row["B_Case_Check_Type"]!=null && row["B_Case_Check_Type"].ToString()!="")
				{
					model.B_Case_Check_Type=int.Parse(row["B_Case_Check_Type"].ToString());
				}
				if(row["B_Case_Check_checkPerson"]!=null && row["B_Case_Check_checkPerson"].ToString()!="")
				{
					model.B_Case_Check_checkPerson= new Guid(row["B_Case_Check_checkPerson"].ToString());
				}
				if(row["B_Case_Check_checkTime"]!=null && row["B_Case_Check_checkTime"].ToString()!="")
				{
					model.B_Case_Check_checkTime=DateTime.Parse(row["B_Case_Check_checkTime"].ToString());
				}
				if(row["B_Case_Check_SuggestContent"]!=null)
				{
					model.B_Case_Check_SuggestContent=row["B_Case_Check_SuggestContent"].ToString();
				}
				if(row["B_Case_Check_order"]!=null && row["B_Case_Check_order"].ToString()!="")
				{
					model.B_Case_Check_order=int.Parse(row["B_Case_Check_order"].ToString());
				}
				if(row["B_Case_Check_creator"]!=null && row["B_Case_Check_creator"].ToString()!="")
				{
					model.B_Case_Check_creator= new Guid(row["B_Case_Check_creator"].ToString());
				}
				if(row["B_Case_Check_createTime"]!=null && row["B_Case_Check_createTime"].ToString()!="")
				{
					model.B_Case_Check_createTime=DateTime.Parse(row["B_Case_Check_createTime"].ToString());
				}
				if(row["B_Case_Check_isDelete"]!=null && row["B_Case_Check_isDelete"].ToString()!="")
				{
					if((row["B_Case_Check_isDelete"].ToString()=="1")||(row["B_Case_Check_isDelete"].ToString().ToLower()=="true"))
					{
						model.B_Case_Check_isDelete=true;
					}
					else
					{
						model.B_Case_Check_isDelete=false;
					}
				}
                if (row.Table.Columns.Contains("B_Case_Check_typeName"))
                {
                    if (row["B_Case_Check_typeName"] != null && row["B_Case_Check_typeName"].ToString() != "")
                    {
                        model.B_Case_Check_typeName = row["B_Case_Check_typeName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_Case_Check_creatorName"))
                {
                    if (row["B_Case_Check_creatorName"] != null && row["B_Case_Check_creatorName"].ToString() != "")
                    {
                        model.B_Case_Check_creatorName = row["B_Case_Check_creatorName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_Case_Check_checkpersonName"))
                {
                    if (row["B_Case_Check_checkpersonName"] != null && row["B_Case_Check_checkpersonName"].ToString() != "")
                    {
                        model.B_Case_Check_checkpersonName = row["B_Case_Check_checkpersonName"].ToString();
                    }
                }
			}
			return model;
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByConfirmCode(Guid B_Case_Confirm_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.B_Case_Check_id,T.B_Case_Check_code,T.B_Case_Confirm_code,T.B_Case_Check_State,T.B_Case_Check_Type,T.B_Case_Check_checkPerson,T.B_Case_Check_checkTime,T.B_Case_Check_SuggestContent,T.B_Case_Check_order,T.B_Case_Check_creator,T.B_Case_Check_createTime,T.B_Case_Check_isDelete,P.C_Parameters_name as 'B_Case_Check_typeName',U.C_Userinfo_name as 'B_Case_Check_checkpersonName' ");
            strSql.Append(" FROM B_Case_Check as T ");
            strSql.Append("left join C_Parameters as P on T.B_Case_Check_Type=P.C_Parameters_id ");
            strSql.Append("left join C_Userinfo as U on T.B_Case_Check_checkPerson=U.C_Userinfo_code ");
            strSql.Append("where 1=1 ");
            strSql.Append("and T.B_Case_Confirm_code=@B_Case_Confirm_code and T.B_Case_Check_isDelete=0 ");
            strSql.Append("order by T.B_Case_Check_order asc");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Confirm_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Confirm_code;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select B_Case_Check_id,B_Case_Check_code,B_Case_Confirm_code,B_Case_Check_State,B_Case_Check_Type,B_Case_Check_checkPerson,B_Case_Check_checkTime,B_Case_Check_SuggestContent,B_Case_Check_order,B_Case_Check_creator,B_Case_Check_createTime,B_Case_Check_isDelete ");
			strSql.Append(" FROM B_Case_Check ");
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
			strSql.Append(" B_Case_Check_id,B_Case_Check_code,B_Case_Confirm_code,B_Case_Check_State,B_Case_Check_Type,B_Case_Check_checkPerson,B_Case_Check_checkTime,B_Case_Check_SuggestContent,B_Case_Check_order,B_Case_Check_creator,B_Case_Check_createTime,B_Case_Check_isDelete ");
			strSql.Append(" FROM B_Case_Check ");
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
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM B_Case_Check ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.B_Case_Check_id desc");
			}
			strSql.Append(")AS Row, T.*  from B_Case_Check T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "B_Case_Check";
			parameters[1].Value = "B_Case_Check_id";
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

