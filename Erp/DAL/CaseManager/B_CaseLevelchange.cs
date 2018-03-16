using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件级别变更表
    /// 作者：崔慧栋
    /// 日期：2015/12/16
    /// </summary>
	public partial class B_CaseLevelchange
	{
		public B_CaseLevelchange()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("B_CaseLevelchange_id", "B_CaseLevelchange"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int B_CaseLevelchange_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_CaseLevelchange");
			strSql.Append(" where B_CaseLevelchange_id=@B_CaseLevelchange_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelchange_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseLevelchange_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_CaseLevelchange model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_CaseLevelchange(");
			strSql.Append("B_CaseLevelchange_code,B_Case_code,B_CaseLevelchange_type,B_CaseLevelchange_changeRecord,B_CaseLevelchange_state,B_CaseLevelchange_IsValid,B_CaseLevelchange_creator,B_CaseLevelchange_createTime,B_CaseLevelchange_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_CaseLevelchange_code,@B_Case_code,@B_CaseLevelchange_type,@B_CaseLevelchange_changeRecord,@B_CaseLevelchange_state,@B_CaseLevelchange_IsValid,@B_CaseLevelchange_creator,@B_CaseLevelchange_createTime,@B_CaseLevelchange_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelchange_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelchange_type", SqlDbType.Int,4),
					new SqlParameter("@B_CaseLevelchange_changeRecord", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelchange_state", SqlDbType.Int,4),
					new SqlParameter("@B_CaseLevelchange_IsValid", SqlDbType.Bit,1),
					new SqlParameter("@B_CaseLevelchange_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelchange_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseLevelchange_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.B_CaseLevelchange_code;
            parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_CaseLevelchange_type;
            parameters[3].Value = model.B_CaseLevelchange_changeRecord;
			parameters[4].Value = model.B_CaseLevelchange_state;
			parameters[5].Value = model.B_CaseLevelchange_IsValid;
            parameters[6].Value = model.B_CaseLevelchange_creator;
			parameters[7].Value = model.B_CaseLevelchange_createTime;
			parameters[8].Value = model.B_CaseLevelchange_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_CaseLevelchange model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_CaseLevelchange set ");
			strSql.Append("B_CaseLevelchange_code=@B_CaseLevelchange_code,");
			strSql.Append("B_Case_code=@B_Case_code,");
			strSql.Append("B_CaseLevelchange_type=@B_CaseLevelchange_type,");
			strSql.Append("B_CaseLevelchange_changeRecord=@B_CaseLevelchange_changeRecord,");
			strSql.Append("B_CaseLevelchange_state=@B_CaseLevelchange_state,");
			strSql.Append("B_CaseLevelchange_IsValid=@B_CaseLevelchange_IsValid,");
			strSql.Append("B_CaseLevelchange_creator=@B_CaseLevelchange_creator,");
			strSql.Append("B_CaseLevelchange_createTime=@B_CaseLevelchange_createTime,");
			strSql.Append("B_CaseLevelchange_isDelete=@B_CaseLevelchange_isDelete");
			strSql.Append(" where B_CaseLevelchange_id=@B_CaseLevelchange_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelchange_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelchange_type", SqlDbType.Int,4),
					new SqlParameter("@B_CaseLevelchange_changeRecord", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelchange_state", SqlDbType.Int,4),
					new SqlParameter("@B_CaseLevelchange_IsValid", SqlDbType.Bit,1),
					new SqlParameter("@B_CaseLevelchange_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseLevelchange_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseLevelchange_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@B_CaseLevelchange_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_CaseLevelchange_code;
			parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_CaseLevelchange_type;
			parameters[3].Value = model.B_CaseLevelchange_changeRecord;
			parameters[4].Value = model.B_CaseLevelchange_state;
			parameters[5].Value = model.B_CaseLevelchange_IsValid;
			parameters[6].Value = model.B_CaseLevelchange_creator;
			parameters[7].Value = model.B_CaseLevelchange_createTime;
			parameters[8].Value = model.B_CaseLevelchange_isDelete;
			parameters[9].Value = model.B_CaseLevelchange_id;

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
		public bool Delete(int B_CaseLevelchange_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_CaseLevelchange set B_CaseLevelchange_isDelete=1 ");
			strSql.Append(" where B_CaseLevelchange_id=@B_CaseLevelchange_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelchange_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseLevelchange_id;

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
        public bool Delete(Guid B_CaseLevelchange_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_CaseLevelchange set B_CaseLevelchange_isDelete=1 ");
            strSql.Append(" where B_CaseLevelchange_code=@B_CaseLevelchange_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelchange_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_CaseLevelchange_code;

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
		public bool DeleteList(string B_CaseLevelchange_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_CaseLevelchange ");
			strSql.Append(" where B_CaseLevelchange_id in ("+B_CaseLevelchange_idlist + ")  ");
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
        /// 根据案件Guid查询是否有未审核的变更数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public bool IsNotAudited(Guid caseCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CaseLevelchange");
            strSql.Append(" where B_Case_code=@B_Case_code and B_CaseLevelchange_state=947 and B_CaseLevelchange_IsValid=0 and B_CaseLevelchange_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = caseCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

         /// <summary>
        /// 根据案件Guid查询是否有变更记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public bool IsChange(Guid caseCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CaseLevelchange");
            strSql.Append(" where B_Case_code=@B_Case_code and B_CaseLevelchange_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = caseCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据案件Guid查询是否有调整记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="B_CaseLevelchange_type">案件级别变更类型</param>
        /// <returns></returns>
        public bool IsHardToAdjust(Guid caseCode, int B_CaseLevelchange_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CaseLevelchange");
            strSql.Append(" where B_Case_code=@B_Case_code and B_CaseLevelchange_isDelete=0 and B_CaseLevelchange_state=948 and B_CaseLevelchange_type=@B_CaseLevelchange_type ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_CaseLevelchange_type",SqlDbType.Int,4)
			};
            parameters[0].Value = caseCode;
            parameters[1].Value = B_CaseLevelchange_type;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.CaseManager.B_CaseLevelchange GetModel(int B_CaseLevelchange_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 B_CaseLevelchange_id,B_CaseLevelchange_code,B_Case_code,B_CaseLevelchange_type,B_CaseLevelchange_changeRecord,B_CaseLevelchange_state,B_CaseLevelchange_IsValid,B_CaseLevelchange_creator,B_CaseLevelchange_createTime,B_CaseLevelchange_isDelete from B_CaseLevelchange ");
			strSql.Append(" where B_CaseLevelchange_id=@B_CaseLevelchange_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelchange_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_CaseLevelchange_id;

            CommonService.Model.CaseManager.B_CaseLevelchange model = new CommonService.Model.CaseManager.B_CaseLevelchange();
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
        public CommonService.Model.CaseManager.B_CaseLevelchange GetModel(Guid B_CaseLevelchange_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_CaseLevelchange_id,B_CaseLevelchange_code,B_Case_code,B_CaseLevelchange_type,B_CaseLevelchange_changeRecord,B_CaseLevelchange_state,B_CaseLevelchange_IsValid,B_CaseLevelchange_creator,B_CaseLevelchange_createTime,B_CaseLevelchange_isDelete from B_CaseLevelchange ");
            strSql.Append(" where B_CaseLevelchange_code=@B_CaseLevelchange_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelchange_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_CaseLevelchange_code;

            CommonService.Model.CaseManager.B_CaseLevelchange model = new CommonService.Model.CaseManager.B_CaseLevelchange();
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
        public CommonService.Model.CaseManager.B_CaseLevelchange DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_CaseLevelchange model = new CommonService.Model.CaseManager.B_CaseLevelchange();
			if (row != null)
			{
				if(row["B_CaseLevelchange_id"]!=null && row["B_CaseLevelchange_id"].ToString()!="")
				{
					model.B_CaseLevelchange_id=int.Parse(row["B_CaseLevelchange_id"].ToString());
				}
				if(row["B_CaseLevelchange_code"]!=null && row["B_CaseLevelchange_code"].ToString()!="")
				{
					model.B_CaseLevelchange_code= new Guid(row["B_CaseLevelchange_code"].ToString());
				}
				if(row["B_Case_code"]!=null && row["B_Case_code"].ToString()!="")
				{
					model.B_Case_code= new Guid(row["B_Case_code"].ToString());
				}
				if(row["B_CaseLevelchange_type"]!=null && row["B_CaseLevelchange_type"].ToString()!="")
				{
					model.B_CaseLevelchange_type=int.Parse(row["B_CaseLevelchange_type"].ToString());
				}
				if(row["B_CaseLevelchange_changeRecord"]!=null && row["B_CaseLevelchange_changeRecord"].ToString()!="")
				{
					model.B_CaseLevelchange_changeRecord= new Guid(row["B_CaseLevelchange_changeRecord"].ToString());
				}
				if(row["B_CaseLevelchange_state"]!=null && row["B_CaseLevelchange_state"].ToString()!="")
				{
					model.B_CaseLevelchange_state=int.Parse(row["B_CaseLevelchange_state"].ToString());
				}
				if(row["B_CaseLevelchange_IsValid"]!=null && row["B_CaseLevelchange_IsValid"].ToString()!="")
				{
					if((row["B_CaseLevelchange_IsValid"].ToString()=="1")||(row["B_CaseLevelchange_IsValid"].ToString().ToLower()=="true"))
					{
						model.B_CaseLevelchange_IsValid=true;
					}
					else
					{
						model.B_CaseLevelchange_IsValid=false;
					}
				}
				if(row["B_CaseLevelchange_creator"]!=null && row["B_CaseLevelchange_creator"].ToString()!="")
				{
					model.B_CaseLevelchange_creator= new Guid(row["B_CaseLevelchange_creator"].ToString());
				}
				if(row["B_CaseLevelchange_createTime"]!=null && row["B_CaseLevelchange_createTime"].ToString()!="")
				{
					model.B_CaseLevelchange_createTime=DateTime.Parse(row["B_CaseLevelchange_createTime"].ToString());
				}
				if(row["B_CaseLevelchange_isDelete"]!=null && row["B_CaseLevelchange_isDelete"].ToString()!="")
				{
					if((row["B_CaseLevelchange_isDelete"].ToString()=="1")||(row["B_CaseLevelchange_isDelete"].ToString().ToLower()=="true"))
					{
						model.B_CaseLevelchange_isDelete=true;
					}
					else
					{
						model.B_CaseLevelchange_isDelete=false;
					}
				}
                if (row.Table.Columns.Contains("B_CaseLevelchange_typeName"))
                {
                    if (row["B_CaseLevelchange_typeName"] != null && row["B_CaseLevelchange_typeName"].ToString() != "")
                    {
                        model.B_CaseLevelchange_typeName = row["B_CaseLevelchange_typeName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_CaseLevelchange_creatorName"))
                {
                    if (row["B_CaseLevelchange_creatorName"] != null && row["B_CaseLevelchange_creatorName"].ToString() != "")
                    {
                        model.B_CaseLevelchange_creatorName = row["B_CaseLevelchange_creatorName"].ToString();
                    }
                }
			}
			return model;
		}

        /// <summary>
        /// 根据变更记录Guid获得数据列表
        /// </summary>
        public DataSet GetListByChangeRecord(Guid B_CaseLevelchange_changeRecord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select B_CaseLevelchange_id,B_CaseLevelchange_code,B_Case_code,B_CaseLevelchange_type,B_CaseLevelchange_changeRecord,B_CaseLevelchange_state,B_CaseLevelchange_IsValid,B_CaseLevelchange_creator,B_CaseLevelchange_createTime,B_CaseLevelchange_isDelete ");
            strSql.Append(" FROM B_CaseLevelchange ");
            strSql.Append(" B_CaseLevelchange_changeRecord=@B_CaseLevelchange_changeRecord");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseLevelchange_changeRecord", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_CaseLevelchange_changeRecord;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 根据案件Guid获得数据列表
        /// </summary>
        /// <param name="B_Case_code">案件Guid</param>
        /// <param name="type">type=1、获取无效数据 2、获取有效通过数据 3、获取未通过的有效数据4、获取有效数据</param>
        /// <returns></returns>
        public DataSet GetListByCaseCode(Guid B_Case_code,int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CLC.B_CaseLevelchange_id,CLC.B_CaseLevelchange_code,CLC.B_Case_code,CLC.B_CaseLevelchange_type,CLC.B_CaseLevelchange_changeRecord,CLC.B_CaseLevelchange_state,CLC.B_CaseLevelchange_IsValid,CLC.B_CaseLevelchange_creator,CLC.B_CaseLevelchange_createTime,CLC.B_CaseLevelchange_isDelete,C.C_Parameters_name as 'B_CaseLevelchange_typeName' ");
            strSql.Append(" FROM B_CaseLevelchange as CLC");
            strSql.Append(" left join C_Parameters as C on CLC.B_CaseLevelchange_type=C.C_Parameters_id");
            strSql.Append(" where 1=1 ");
            strSql.Append(" and CLC.B_Case_code=@B_Case_code");
            if(type == 1)
            {
                strSql.Append(" and CLC.B_CaseLevelchange_IsValid=0");
            }else if(type==2)
            {
                strSql.Append(" and CLC.B_CaseLevelchange_IsValid=1");
                strSql.Append(" and CLC.B_CaseLevelchange_state=948 ");
            }
            else if (type == 3)
            {
                strSql.Append(" and CLC.B_CaseLevelchange_IsValid=1");
                strSql.Append(" and CLC.B_CaseLevelchange_state=949 ");
            }else
            {
                strSql.Append(" and CLC.B_CaseLevelchange_IsValid=1");
            }
            strSql.Append(" and CLC.B_CaseLevelchange_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select B_CaseLevelchange_id,B_CaseLevelchange_code,B_Case_code,B_CaseLevelchange_type,B_CaseLevelchange_changeRecord,B_CaseLevelchange_state,B_CaseLevelchange_IsValid,B_CaseLevelchange_creator,B_CaseLevelchange_createTime,B_CaseLevelchange_isDelete ");
			strSql.Append(" FROM B_CaseLevelchange ");
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
			strSql.Append(" B_CaseLevelchange_id,B_CaseLevelchange_code,B_Case_code,B_CaseLevelchange_type,B_CaseLevelchange_changeRecord,B_CaseLevelchange_state,B_CaseLevelchange_IsValid,B_CaseLevelchange_creator,B_CaseLevelchange_createTime,B_CaseLevelchange_isDelete ");
			strSql.Append(" FROM B_CaseLevelchange ");
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_CaseLevelchange model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM B_CaseLevelchange ");
            strSql.Append("where 1=1 and B_CaseLevelchange_isDelete=0 ");
            if (model != null)
            {
                
            }
            SqlParameter[] parameters = {};
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
        public DataSet GetListByPage(CommonService.Model.CaseManager.B_CaseLevelchange model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.B_CaseLevelchange_id desc");
			}
            strSql.Append(")AS Row, T.*  from B_CaseLevelchange T ");
            strSql.Append("where 1=1 and B_CaseLevelchange_isDelete=0 ");
            if (model != null)
            {

            }
            SqlParameter[] parameters = { };
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
			parameters[0].Value = "B_CaseLevelchange";
			parameters[1].Value = "B_CaseLevelchange_id";
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

