using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.FlowManager
{
    /// <summary>
    /// 数据访问类:流程表----岗位表中间表
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class P_Flow_post
	{
		public P_Flow_post()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("P_Flow_post_id", "P_Flow_post");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Flow_post_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Flow_post");
            strSql.Append(" where P_Flow_post_id=@P_Flow_post_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_post_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Flow_post_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FlowManager.P_Flow_post model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into P_Flow_post(");
			strSql.Append("P_Flow_code,F_Post_code,P_Flow_post_isDelete,P_Flow_post_creator,P_Flow_post_createTime)");
			strSql.Append(" values (");
			strSql.Append("@P_Flow_code,@F_Post_code,@P_Flow_post_isDelete,@P_Flow_post_creator,@P_Flow_post_createTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_post_isDelete", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_post_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_post_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.P_Flow_code;
            parameters[1].Value = model.F_Post_code;
			parameters[2].Value = model.P_Flow_post_isDelete;
            parameters[3].Value = model.P_Flow_post_creator;
			parameters[4].Value = model.P_Flow_post_createTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(CommonService.Model.FlowManager.P_Flow_post model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update P_Flow_post set ");
			strSql.Append("P_Flow_code=@P_Flow_code,");
			strSql.Append("F_Post_code=@F_Post_code,");
			strSql.Append("P_Flow_post_isDelete=@P_Flow_post_isDelete,");
			strSql.Append("P_Flow_post_creator=@P_Flow_post_creator,");
			strSql.Append("P_Flow_post_createTime=@P_Flow_post_createTime");
            strSql.Append(" where P_Flow_post_id＝@P_Flow_post_id");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_post_isDelete", SqlDbType.Int,4),
					new SqlParameter("@P_Flow_post_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_post_createTime", SqlDbType.DateTime),
                    new SqlParameter("@P_Flow_post_id",SqlDbType.Int,4)};
			parameters[0].Value = model.P_Flow_code;
			parameters[1].Value = model.F_Post_code;
			parameters[2].Value = model.P_Flow_post_isDelete;
			parameters[3].Value = model.P_Flow_post_creator;
			parameters[4].Value = model.P_Flow_post_createTime;
            parameters[5].Value = model.P_Flow_post_id;

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
        public bool Delete(int P_Flow_post_id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update P_Flow_post set P_Flow_post_isDelete=1 ");
            strSql.Append(" where P_Flow_post_id=@P_Flow_post_id");
            SqlParameter[] parameters = {new SqlParameter("@P_Flow_post_id",SqlDbType.Int,4)
			};
            parameters[0].Value = P_Flow_post_id;
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
        /// 根据流程GUID删除一条数据
        /// </summary>
        public bool DeleteByFlowcode(Guid P_Flow_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Flow_post set P_Flow_post_isDelete=1 ");
            strSql.Append(" where P_Flow_code=@P_Flow_code");
            SqlParameter[] parameters = {new SqlParameter("@P_Flow_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Flow_code;
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
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FlowManager.P_Flow_post GetModel(int P_Flow_post_id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 P_Flow_post_id,P_Flow_code,F_Post_code,P_Flow_post_isDelete,P_Flow_post_creator,P_Flow_post_createTime from P_Flow_post ");
            strSql.Append(" where P_Flow_post_id=@P_Flow_post_id");
            SqlParameter[] parameters = {new SqlParameter("@P_Flow_post_id",SqlDbType.Int,4)
			};
            parameters[0].Value = P_Flow_post_id;
            CommonService.Model.FlowManager.P_Flow_post model = new CommonService.Model.FlowManager.P_Flow_post();
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
        public CommonService.Model.FlowManager.P_Flow_post DataRowToModel(DataRow row)
		{
            CommonService.Model.FlowManager.P_Flow_post model = new CommonService.Model.FlowManager.P_Flow_post();
			if (row != null)
			{
                if (row["P_Flow_post_id"] != null && row["P_Flow_post_id"].ToString() != "")
                {
                    model.P_Flow_post_id = int.Parse(row["P_Flow_post_id"].ToString());
                }
				if(row["P_Flow_code"]!=null && row["P_Flow_code"].ToString()!="")
				{
					model.P_Flow_code= new Guid(row["P_Flow_code"].ToString());
				}
                //简称此列是否存在于此表
                if (row.Table.Columns.Contains("C_Post_name"))
                {
                    if (row["C_Post_name"] != null && row["C_Post_name"].ToString() != "")
                    {
                        model.C_Post_name = row["C_Post_name"].ToString();
                    }
                }
				if(row["F_Post_code"]!=null && row["F_Post_code"].ToString()!="")
				{
					model.F_Post_code= new Guid(row["F_Post_code"].ToString());
				}
				if(row["P_Flow_post_isDelete"]!=null && row["P_Flow_post_isDelete"].ToString()!="")
				{
					model.P_Flow_post_isDelete=int.Parse(row["P_Flow_post_isDelete"].ToString());
				}
				if(row["P_Flow_post_creator"]!=null && row["P_Flow_post_creator"].ToString()!="")
				{
					model.P_Flow_post_creator= new Guid(row["P_Flow_post_creator"].ToString());
				}
				if(row["P_Flow_post_createTime"]!=null && row["P_Flow_post_createTime"].ToString()!="")
				{
					model.P_Flow_post_createTime=DateTime.Parse(row["P_Flow_post_createTime"].ToString());
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
            strSql.Append("select P_Flow_post_id,P_Flow_code,F_Post_code,P_Flow_post_isDelete,P_Flow_post_creator,P_Flow_post_createTime ");
			strSql.Append(" FROM P_Flow_post ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据流程Code获得数据列表
        /// </summary>
        public DataSet GetListByFlowcode(Guid P_Flow_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FP.P_Flow_post_id,FP.P_Flow_code,FP.F_Post_code,FP.P_Flow_post_isDelete,FP.P_Flow_post_creator,FP.P_Flow_post_createTime,");
            strSql.Append("P.C_Post_name As C_Post_name ");
            strSql.Append("from P_Flow_post AS FP WITH(NOLOCK) ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on FP.F_Post_code = P.C_Post_code ");
            strSql.Append("where FP.P_Flow_code=@P_Flow_code and FP.P_Flow_post_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = P_Flow_code;

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
            strSql.Append(" P_Flow_post_id,P_Flow_code,F_Post_code,P_Flow_post_isDelete,P_Flow_post_creator,P_Flow_post_createTime ");
			strSql.Append(" FROM P_Flow_post ");
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
		public int GetRecordCount(CommonService.Model.FlowManager.P_Flow_post model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM P_Flow_post ");
            strSql.Append(" where 1=1 and P_Flow_post_isDelete=0 ");
            if (model != null)
            {
                if (model.P_Flow_code != null && model.P_Flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Flow_code=@P_Flow_code");
                }
                if (model.F_Post_code != null && model.F_Post_code.ToString() != "")
                {
                    strSql.Append(" and F_Post_code=@F_Post_code");
                }
            }
            SqlParameter[] parameters = { new SqlParameter("@P_Flow_code",SqlDbType.UniqueIdentifier,16),
                                        new SqlParameter("@F_Post_code",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.P_Flow_code;
            parameters[1].Value = model.F_Post_code;
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
		public DataSet GetListByPage(CommonService.Model.FlowManager.P_Flow_post model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.P_Business_flow_form_id desc");
			}
            strSql.Append(")AS Row, T.*  from P_Flow_post T ");
            strSql.Append(" where 1=1 and P_Flow_post_isDelete=0 ");
            if (model != null)
            {
                if (model.P_Flow_code != null && model.P_Flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Flow_code=@P_Flow_code");
                }
                if (model.F_Post_code != null && model.F_Post_code.ToString() != "")
                {
                    strSql.Append(" and F_Post_code=@F_Post_code");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = { new SqlParameter("@P_Flow_code",SqlDbType.UniqueIdentifier,16),
                                        new SqlParameter("@F_Post_code",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.P_Flow_code;
            parameters[1].Value = model.F_Post_code;
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
			parameters[0].Value = "P_Flow_post";
			parameters[1].Value = "P_Business_flow_form_id";
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

