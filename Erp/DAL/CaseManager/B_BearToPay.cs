using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件--费用承担表
    /// 作者：崔慧栋
    /// 日期：2015/06/05
    /// </summary>
	public partial class B_BearToPay
	{
		public B_BearToPay()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("B_BearToPay_id", "B_BearToPay");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_BearToPay_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_BearToPay");
            strSql.Append(" where B_BearToPay_id=@B_BearToPay_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BearToPay_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_BearToPay_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_BearToPay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_BearToPay(");
			strSql.Append("B_BearToPay_code,B_Case_code,B_BearToPay_ctypes,B_BearToPay_pmethod,B_BearToPay_figure,B_BearToPay_explain,B_BearToPay_creator,B_BearToPay_createTime,B_BearToPay_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_BearToPay_code,@B_Case_code,@B_BearToPay_ctypes,@B_BearToPay_pmethod,@B_BearToPay_figure,@B_BearToPay_explain,@B_BearToPay_creator,@B_BearToPay_createTime,@B_BearToPay_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BearToPay_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BearToPay_ctypes", SqlDbType.Int,4),
					new SqlParameter("@B_BearToPay_pmethod", SqlDbType.Int,4),
					new SqlParameter("@B_BearToPay_figure", SqlDbType.Decimal,9),
					new SqlParameter("@B_BearToPay_explain", SqlDbType.VarChar,500),
					new SqlParameter("@B_BearToPay_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BearToPay_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_BearToPay_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.B_BearToPay_code;
            parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_BearToPay_ctypes;
			parameters[3].Value = model.B_BearToPay_pmethod;
			parameters[4].Value = model.B_BearToPay_figure;
			parameters[5].Value = model.B_BearToPay_explain;
            parameters[6].Value = model.B_BearToPay_creator;
			parameters[7].Value = model.B_BearToPay_createTime;
			parameters[8].Value = model.B_BearToPay_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_BearToPay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_BearToPay set ");
			strSql.Append("B_BearToPay_code=@B_BearToPay_code,");
			strSql.Append("B_Case_code=@B_Case_code,");
			strSql.Append("B_BearToPay_ctypes=@B_BearToPay_ctypes,");
			strSql.Append("B_BearToPay_pmethod=@B_BearToPay_pmethod,");
			strSql.Append("B_BearToPay_figure=@B_BearToPay_figure,");
			strSql.Append("B_BearToPay_explain=@B_BearToPay_explain,");
			strSql.Append("B_BearToPay_creator=@B_BearToPay_creator,");
			strSql.Append("B_BearToPay_createTime=@B_BearToPay_createTime,");
			strSql.Append("B_BearToPay_isDelete=@B_BearToPay_isDelete");
			strSql.Append(" where B_BearToPay_id=@B_BearToPay_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BearToPay_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BearToPay_ctypes", SqlDbType.Int,4),
					new SqlParameter("@B_BearToPay_pmethod", SqlDbType.Int,4),
					new SqlParameter("@B_BearToPay_figure", SqlDbType.Decimal,9),
					new SqlParameter("@B_BearToPay_explain", SqlDbType.VarChar,500),
					new SqlParameter("@B_BearToPay_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BearToPay_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_BearToPay_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_BearToPay_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_BearToPay_code;
			parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_BearToPay_ctypes;
			parameters[3].Value = model.B_BearToPay_pmethod;
			parameters[4].Value = model.B_BearToPay_figure;
			parameters[5].Value = model.B_BearToPay_explain;
			parameters[6].Value = model.B_BearToPay_creator;
			parameters[7].Value = model.B_BearToPay_createTime;
			parameters[8].Value = model.B_BearToPay_isDelete;
			parameters[9].Value = model.B_BearToPay_id;

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
		public bool Delete(int B_BearToPay_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_BearToPay set B_BearToPay_isDelete=1 ");
			strSql.Append(" where B_BearToPay_id=@B_BearToPay_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BearToPay_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_BearToPay_id;

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
		public bool DeleteList(string B_BearToPay_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_BearToPay ");
			strSql.Append(" where B_BearToPay_id in ("+B_BearToPay_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_BearToPay GetModel(int B_BearToPay_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 B_BearToPay_id,B_BearToPay_code,B_Case_code,B_BearToPay_ctypes,B_BearToPay_pmethod,B_BearToPay_figure,B_BearToPay_explain,B_BearToPay_creator,B_BearToPay_createTime,B_BearToPay_isDelete from B_BearToPay ");
			strSql.Append(" where B_BearToPay_id=@B_BearToPay_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BearToPay_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_BearToPay_id;

            CommonService.Model.CaseManager.B_BearToPay model = new CommonService.Model.CaseManager.B_BearToPay();
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
        /// 根据案件GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_BearToPay GetModel(Guid B_Case_code, int B_BearToPay_ctypes)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 P.C_Parameters_id as 'B_BearToPay_ctypes_id',P.C_Parameters_name as 'B_BearToPay_ctypes_name',T.* ");
            strSql.Append("from (select * from B_BearToPay where B_Case_code=@B_Case_code and B_BearToPay_ctypes=@B_BearToPay_ctypes and B_BearToPay_isDelete=0) T ");
            strSql.Append("right join C_Parameters as P on T.B_BearToPay_ctypes=P.C_Parameters_id ");
            strSql.Append("where P.C_Parameters_id=@B_BearToPay_ctypes_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BearToPay_ctypes",SqlDbType.Int,4),
                    new SqlParameter("@B_BearToPay_ctypes_id",SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_code;
            parameters[1].Value = B_BearToPay_ctypes;
            parameters[2].Value = B_BearToPay_ctypes;

            CommonService.Model.CaseManager.B_BearToPay model = new CommonService.Model.CaseManager.B_BearToPay();
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
        public CommonService.Model.CaseManager.B_BearToPay DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_BearToPay model = new CommonService.Model.CaseManager.B_BearToPay();
			if (row != null)
			{
				if(row["B_BearToPay_id"]!=null && row["B_BearToPay_id"].ToString()!="")
				{
					model.B_BearToPay_id=int.Parse(row["B_BearToPay_id"].ToString());
				}
				if(row["B_BearToPay_code"]!=null && row["B_BearToPay_code"].ToString()!="")
				{
					model.B_BearToPay_code= new Guid(row["B_BearToPay_code"].ToString());
				}
				if(row["B_Case_code"]!=null && row["B_Case_code"].ToString()!="")
				{
					model.B_Case_code= new Guid(row["B_Case_code"].ToString());
				}
				if(row["B_BearToPay_ctypes"]!=null && row["B_BearToPay_ctypes"].ToString()!="")
				{
					model.B_BearToPay_ctypes=int.Parse(row["B_BearToPay_ctypes"].ToString());
				}
				if(row["B_BearToPay_pmethod"]!=null && row["B_BearToPay_pmethod"].ToString()!="")
				{
					model.B_BearToPay_pmethod=int.Parse(row["B_BearToPay_pmethod"].ToString());
				}
				if(row["B_BearToPay_figure"]!=null && row["B_BearToPay_figure"].ToString()!="")
				{
					model.B_BearToPay_figure=decimal.Parse(row["B_BearToPay_figure"].ToString());
				}
				if(row["B_BearToPay_explain"]!=null)
				{
					model.B_BearToPay_explain=row["B_BearToPay_explain"].ToString();
				}
				if(row["B_BearToPay_creator"]!=null && row["B_BearToPay_creator"].ToString()!="")
				{
					model.B_BearToPay_creator= new Guid(row["B_BearToPay_creator"].ToString());
				}
				if(row["B_BearToPay_createTime"]!=null && row["B_BearToPay_createTime"].ToString()!="")
				{
					model.B_BearToPay_createTime=DateTime.Parse(row["B_BearToPay_createTime"].ToString());
				}
				if(row["B_BearToPay_isDelete"]!=null && row["B_BearToPay_isDelete"].ToString()!="")
				{
					model.B_BearToPay_isDelete=int.Parse(row["B_BearToPay_isDelete"].ToString());
				}
                //判断费用类型名称（虚拟字段）是否存在
                if(row.Table.Columns.Contains("B_BearToPay_ctypes_name"))
                {
                    if(row["B_BearToPay_ctypes_name"]!=null && row["B_BearToPay_ctypes_name"].ToString()!="")
                    {
                        model.B_BearToPay_ctypes_name = row["B_BearToPay_ctypes_name"].ToString();
                    }
                }
                //判断费用类型关联parameterID（虚拟字段）是否存在
                if (row.Table.Columns.Contains("B_BearToPay_ctypes_id"))
                {
                    if (row["B_BearToPay_ctypes_id"] != null && row["B_BearToPay_ctypes_id"].ToString() != "")
                    {
                        model.B_BearToPay_ctypes_id = int.Parse(row["B_BearToPay_ctypes_id"].ToString());
                    }
                }
                //判断支付方式名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("B_BearToPay_pmethod_name"))
                {
                    if (row["B_BearToPay_pmethod_name"] != null && row["B_BearToPay_pmethod_name"].ToString() != "")
                    {
                        model.B_BearToPay_pmethod_name = row["B_BearToPay_pmethod_name"].ToString();
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
			strSql.Append("select B_BearToPay_id,B_BearToPay_code,B_Case_code,B_BearToPay_ctypes,B_BearToPay_pmethod,B_BearToPay_figure,B_BearToPay_explain,B_BearToPay_creator,B_BearToPay_createTime,B_BearToPay_isDelete ");
			strSql.Append(" FROM B_BearToPay ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCaseCode(Guid B_Case_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select B_BearToPay_id,B_BearToPay_code,B_Case_code,B_BearToPay_ctypes,B_BearToPay_pmethod,B_BearToPay_figure,B_BearToPay_explain,B_BearToPay_creator,B_BearToPay_createTime,B_BearToPay_isDelete ");
            strSql.Append(" FROM B_BearToPay ");
            strSql.Append("where B_Case_code=@B_Case_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = B_Case_code;
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
			strSql.Append(" B_BearToPay_id,B_BearToPay_code,B_Case_code,B_BearToPay_ctypes,B_BearToPay_pmethod,B_BearToPay_figure,B_BearToPay_explain,B_BearToPay_creator,B_BearToPay_createTime,B_BearToPay_isDelete ");
			strSql.Append(" FROM B_BearToPay ");
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_BearToPay model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM (select * from B_BearToPay where B_Case_code=@B_Case_code and B_BearToPay_isDelete=0) T ");
            strSql.Append("right join C_Parameters as P on T.B_BearToPay_ctypes=P.C_Parameters_id ");
            strSql.Append("left join C_Parameters P1 on T.B_BearToPay_pmethod=P1.C_Parameters_id ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.B_BearToPay_ctypes_id != null && model.B_BearToPay_ctypes_id.ToString() != "")
                {
                    strSql.Append("and P.C_Parameters_parent=@B_BearToPay_ctypes_id ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BearToPay_ctypes_id",SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_code;
            parameters[1].Value = model.B_BearToPay_ctypes_id;
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
        public DataSet GetListByPage(CommonService.Model.CaseManager.B_BearToPay model, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by P." + orderby );
			}
			else
			{
				strSql.Append("order by T.B_BearToPay_id desc");
			}
            strSql.Append(")AS Row, P.C_Parameters_id as 'B_BearToPay_ctypes_id',P.C_Parameters_name as 'B_BearToPay_ctypes_name',P1.C_Parameters_name as 'B_BearToPay_pmethod_name',T.* ");
            strSql.Append("from (select * from B_BearToPay where B_Case_code=@B_Case_code and B_BearToPay_isDelete=0) T ");
            strSql.Append("right join C_Parameters as P on T.B_BearToPay_ctypes=P.C_Parameters_id ");
            strSql.Append("left join C_Parameters P1 on T.B_BearToPay_pmethod=P1.C_Parameters_id ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if(model.B_BearToPay_ctypes_id!=null && model.B_BearToPay_ctypes_id.ToString()!="")
                {
                    strSql.Append("and P.C_Parameters_parent=@B_BearToPay_ctypes_id ");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BearToPay_ctypes_id",SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_code;
            parameters[1].Value = model.B_BearToPay_ctypes_id;
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
			parameters[0].Value = "B_BearToPay";
			parameters[1].Value = "B_BearToPay_id";
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

