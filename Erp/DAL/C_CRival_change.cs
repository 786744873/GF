﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:对手公司变更表
    /// 作者：崔慧栋
    /// 日期：2015/05/05
    /// </summary>
	public partial class C_CRival_change
	{
		public C_CRival_change()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_CRival_change_id", "C_CRival_change");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_CRival_change_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_CRival_change");
            strSql.Append(" where C_CRival_change_id=@C_CRival_change_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_change_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_CRival_change_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.C_CRival_change model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_CRival_change(");
			strSql.Append("C_CRival_code,C_CRival_change_matter,C_CRival_change_date,C_CRival_change_content,C_CRival_change_creator,C_CRival_change_createTime,C_CRival_change_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@C_CRival_code,@C_CRival_change_matter,@C_CRival_change_date,@C_CRival_change_content,@C_CRival_change_creator,@C_CRival_change_createTime,@C_CRival_change_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_change_matter", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_change_date", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_change_content", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_change_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_change_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_change_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_CRival_code;
			parameters[1].Value = model.C_CRival_change_matter;
			parameters[2].Value = model.C_CRival_change_date;
			parameters[3].Value = model.C_CRival_change_content;
            parameters[4].Value = model.C_CRival_change_creator;
			parameters[5].Value = model.C_CRival_change_createTime;
			parameters[6].Value = model.C_CRival_change_isDelete;

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
		public bool Update(Model.C_CRival_change model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_CRival_change set ");
			strSql.Append("C_CRival_code=@C_CRival_code,");
			strSql.Append("C_CRival_change_matter=@C_CRival_change_matter,");
			strSql.Append("C_CRival_change_date=@C_CRival_change_date,");
			strSql.Append("C_CRival_change_content=@C_CRival_change_content,");
			strSql.Append("C_CRival_change_creator=@C_CRival_change_creator,");
			strSql.Append("C_CRival_change_createTime=@C_CRival_change_createTime,");
			strSql.Append("C_CRival_change_isDelete=@C_CRival_change_isDelete");
			strSql.Append(" where C_CRival_change_id=@C_CRival_change_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_change_matter", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_change_date", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_change_content", SqlDbType.VarChar,500),
					new SqlParameter("@C_CRival_change_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_change_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_change_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_change_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_CRival_code;
			parameters[1].Value = model.C_CRival_change_matter;
			parameters[2].Value = model.C_CRival_change_date;
			parameters[3].Value = model.C_CRival_change_content;
			parameters[4].Value = model.C_CRival_change_creator;
			parameters[5].Value = model.C_CRival_change_createTime;
			parameters[6].Value = model.C_CRival_change_isDelete;
			parameters[7].Value = model.C_CRival_change_id;

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
		public bool Delete(int C_CRival_change_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_CRival_change set C_CRival_change_isDelete=1");
			strSql.Append(" where C_CRival_change_id=@C_CRival_change_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_change_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_CRival_change_id;

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
		public bool DeleteList(string C_CRival_change_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_CRival_change ");
			strSql.Append(" where C_CRival_change_id in ("+C_CRival_change_idlist + ")  ");
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
		public Model.C_CRival_change GetModel(int C_CRival_change_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_CRival_change_id,C_CRival_code,C_CRival_change_matter,C_CRival_change_date,C_CRival_change_content,C_CRival_change_creator,C_CRival_change_createTime,C_CRival_change_isDelete from C_CRival_change ");
			strSql.Append(" where C_CRival_change_id=@C_CRival_change_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_change_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_CRival_change_id;

			Model.C_CRival_change model=new Model.C_CRival_change();
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
		public Model.C_CRival_change DataRowToModel(DataRow row)
		{
			Model.C_CRival_change model=new Model.C_CRival_change();
			if (row != null)
			{
				if(row["C_CRival_change_id"]!=null && row["C_CRival_change_id"].ToString()!="")
				{
					model.C_CRival_change_id=int.Parse(row["C_CRival_change_id"].ToString());
				}
				if(row["C_CRival_code"]!=null && row["C_CRival_code"].ToString()!="")
				{
					model.C_CRival_code= new Guid(row["C_CRival_code"].ToString());
				}
				if(row["C_CRival_change_matter"]!=null)
				{
					model.C_CRival_change_matter=row["C_CRival_change_matter"].ToString();
				}
				if(row["C_CRival_change_date"]!=null && row["C_CRival_change_date"].ToString()!="")
				{
					model.C_CRival_change_date=DateTime.Parse(row["C_CRival_change_date"].ToString());
				}
				if(row["C_CRival_change_content"]!=null)
				{
					model.C_CRival_change_content=row["C_CRival_change_content"].ToString();
				}
				if(row["C_CRival_change_creator"]!=null && row["C_CRival_change_creator"].ToString()!="")
				{
					model.C_CRival_change_creator= new Guid(row["C_CRival_change_creator"].ToString());
				}
				if(row["C_CRival_change_createTime"]!=null && row["C_CRival_change_createTime"].ToString()!="")
				{
					model.C_CRival_change_createTime=DateTime.Parse(row["C_CRival_change_createTime"].ToString());
				}
				if(row["C_CRival_change_isDelete"]!=null && row["C_CRival_change_isDelete"].ToString()!="")
				{
					model.C_CRival_change_isDelete=int.Parse(row["C_CRival_change_isDelete"].ToString());
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
			strSql.Append("select C_CRival_change_id,C_CRival_code,C_CRival_change_matter,C_CRival_change_date,C_CRival_change_content,C_CRival_change_creator,C_CRival_change_createTime,C_CRival_change_isDelete ");
			strSql.Append(" FROM C_CRival_change ");
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
			strSql.Append(" C_CRival_change_id,C_CRival_code,C_CRival_change_matter,C_CRival_change_date,C_CRival_change_content,C_CRival_change_creator,C_CRival_change_createTime,C_CRival_change_isDelete ");
			strSql.Append(" FROM C_CRival_change ");
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
        public int GetRecordCount(Model.C_CRival_change model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM C_CRival_change ");
            strSql.Append(" where 1=1 and C_CRival_change_isDelete=0 ");
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
        public DataSet GetListByPage(Model.C_CRival_change model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_CRival_change_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_CRival_change T ");
            strSql.Append(" where 1=1 and C_CRival_change_isDelete=0 ");
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
			parameters[0].Value = "C_CRival_change";
			parameters[1].Value = "C_CRival_change_id";
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

