using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件--涉案合同权益分配表
    /// 作者：崔慧栋
    /// 日期：2015/06/04
    /// </summary>
	public partial class B_EqAllot
	{
		public B_EqAllot()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("B_EqAllot_id", "B_EqAllot");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_EqAllot_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_EqAllot");
            strSql.Append(" where B_EqAllot_id=@B_EqAllot_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_EqAllot_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_EqAllot_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_EqAllot model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_EqAllot(");
			strSql.Append("B_EqAllot_code,B_Case_code,B_EqAllot_pright,B_EqAllot_mvalue,B_EqAllot_cusradio,B_EqAllot_explain,B_EqAllot_creator,B_EqAllot_createTime,B_EqAllot_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_EqAllot_code,@B_Case_code,@B_EqAllot_pright,@B_EqAllot_mvalue,@B_EqAllot_cusradio,@B_EqAllot_explain,@B_EqAllot_creator,@B_EqAllot_createTime,@B_EqAllot_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_EqAllot_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_EqAllot_pright", SqlDbType.Int,4),
					new SqlParameter("@B_EqAllot_mvalue", SqlDbType.Decimal,9),
					new SqlParameter("@B_EqAllot_cusradio", SqlDbType.Decimal,9),
					new SqlParameter("@B_EqAllot_explain", SqlDbType.VarChar,500),
					new SqlParameter("@B_EqAllot_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_EqAllot_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_EqAllot_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.B_EqAllot_code;
            parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_EqAllot_pright;
			parameters[3].Value = model.B_EqAllot_mvalue;
			parameters[4].Value = model.B_EqAllot_cusradio;
			parameters[5].Value = model.B_EqAllot_explain;
            parameters[6].Value = model.B_EqAllot_creator;
			parameters[7].Value = model.B_EqAllot_createTime;
			parameters[8].Value = model.B_EqAllot_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_EqAllot model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_EqAllot set ");
			strSql.Append("B_EqAllot_code=@B_EqAllot_code,");
			strSql.Append("B_Case_code=@B_Case_code,");
			strSql.Append("B_EqAllot_pright=@B_EqAllot_pright,");
			strSql.Append("B_EqAllot_mvalue=@B_EqAllot_mvalue,");
			strSql.Append("B_EqAllot_cusradio=@B_EqAllot_cusradio,");
			strSql.Append("B_EqAllot_explain=@B_EqAllot_explain,");
			strSql.Append("B_EqAllot_creator=@B_EqAllot_creator,");
			strSql.Append("B_EqAllot_createTime=@B_EqAllot_createTime,");
			strSql.Append("B_EqAllot_isDelete=@B_EqAllot_isDelete");
			strSql.Append(" where B_EqAllot_id=@B_EqAllot_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_EqAllot_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_EqAllot_pright", SqlDbType.Int,4),
					new SqlParameter("@B_EqAllot_mvalue", SqlDbType.Decimal,9),
					new SqlParameter("@B_EqAllot_cusradio", SqlDbType.Decimal,9),
					new SqlParameter("@B_EqAllot_explain", SqlDbType.VarChar,500),
					new SqlParameter("@B_EqAllot_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_EqAllot_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_EqAllot_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_EqAllot_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_EqAllot_code;
			parameters[1].Value = model.B_Case_code;
			parameters[2].Value = model.B_EqAllot_pright;
			parameters[3].Value = model.B_EqAllot_mvalue;
			parameters[4].Value = model.B_EqAllot_cusradio;
			parameters[5].Value = model.B_EqAllot_explain;
			parameters[6].Value = model.B_EqAllot_creator;
			parameters[7].Value = model.B_EqAllot_createTime;
			parameters[8].Value = model.B_EqAllot_isDelete;
			parameters[9].Value = model.B_EqAllot_id;

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
		public bool Delete(int B_EqAllot_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_EqAllot set B_EqAllot_isDelete=1 ");
			strSql.Append(" where B_EqAllot_id=@B_EqAllot_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_EqAllot_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_EqAllot_id;

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
		public bool DeleteList(string B_EqAllot_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_EqAllot ");
			strSql.Append(" where B_EqAllot_id in ("+B_EqAllot_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_EqAllot GetModel(int B_EqAllot_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 B_EqAllot_id,B_EqAllot_code,B_Case_code,B_EqAllot_pright,B_EqAllot_mvalue,B_EqAllot_cusradio,B_EqAllot_explain,B_EqAllot_creator,B_EqAllot_createTime,B_EqAllot_isDelete ");
            strSql.Append(" FROM B_EqAllot ");
            strSql.Append("where B_EqAllot_id=@B_EqAllot_id");
            SqlParameter[] parameters = {new SqlParameter("@B_EqAllot_id",SqlDbType.Int,4)
			};
            parameters[0].Value = B_EqAllot_id;

            CommonService.Model.CaseManager.B_EqAllot model = new CommonService.Model.CaseManager.B_EqAllot();
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
        public CommonService.Model.CaseManager.B_EqAllot GetModel(Guid B_Case_code, int B_EqAllot_pright)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 P.C_Parameters_id as 'B_EqAllot_pright_id',P.C_Parameters_name as 'B_EqAllot_pright_name',E.* ");
            strSql.Append("from (select * from B_EqAllot where B_Case_code=@B_Case_code and B_EqAllot_pright=@B_EqAllot_pright and B_EqAllot_isDelete=0) as E ");
            strSql.Append("right join C_Parameters as P on E.B_EqAllot_pright=P.C_Parameters_id ");
            strSql.Append("where P.C_Parameters_id=@B_EqAllot_pright_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_EqAllot_pright",SqlDbType.Int,4),
                    new SqlParameter("@B_EqAllot_pright_id",SqlDbType.Int,4)
			};
			parameters[0].Value = B_Case_code;
            parameters[1].Value = B_EqAllot_pright;
            parameters[2].Value = B_EqAllot_pright;

            CommonService.Model.CaseManager.B_EqAllot model = new CommonService.Model.CaseManager.B_EqAllot();
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
        public CommonService.Model.CaseManager.B_EqAllot DataRowToModel(DataRow row)
		{
            CommonService.Model.CaseManager.B_EqAllot model = new CommonService.Model.CaseManager.B_EqAllot();
			if (row != null)
			{
				if(row["B_EqAllot_id"]!=null && row["B_EqAllot_id"].ToString()!="")
				{
					model.B_EqAllot_id=int.Parse(row["B_EqAllot_id"].ToString());
				}
				if(row["B_EqAllot_code"]!=null && row["B_EqAllot_code"].ToString()!="")
				{
					model.B_EqAllot_code= new Guid(row["B_EqAllot_code"].ToString());
				}
				if(row["B_Case_code"]!=null && row["B_Case_code"].ToString()!="")
				{
					model.B_Case_code= new Guid(row["B_Case_code"].ToString());
				}
				if(row["B_EqAllot_pright"]!=null && row["B_EqAllot_pright"].ToString()!="")
				{
					model.B_EqAllot_pright=int.Parse(row["B_EqAllot_pright"].ToString());
				}
				if(row["B_EqAllot_mvalue"]!=null && row["B_EqAllot_mvalue"].ToString()!="")
				{
					model.B_EqAllot_mvalue=decimal.Parse(row["B_EqAllot_mvalue"].ToString());
				}
				if(row["B_EqAllot_cusradio"]!=null && row["B_EqAllot_cusradio"].ToString()!="")
				{
					model.B_EqAllot_cusradio=decimal.Parse(row["B_EqAllot_cusradio"].ToString());
				}
				if(row["B_EqAllot_explain"]!=null)
				{
					model.B_EqAllot_explain=row["B_EqAllot_explain"].ToString();
				}
				if(row["B_EqAllot_creator"]!=null && row["B_EqAllot_creator"].ToString()!="")
				{
					model.B_EqAllot_creator= new Guid(row["B_EqAllot_creator"].ToString());
				}
				if(row["B_EqAllot_createTime"]!=null && row["B_EqAllot_createTime"].ToString()!="")
				{
					model.B_EqAllot_createTime=DateTime.Parse(row["B_EqAllot_createTime"].ToString());
				}
				if(row["B_EqAllot_isDelete"]!=null && row["B_EqAllot_isDelete"].ToString()!="")
				{
					model.B_EqAllot_isDelete=int.Parse(row["B_EqAllot_isDelete"].ToString());
				}
                //判断财产权利（虚拟属性）是否存在
                if (row.Table.Columns.Contains("B_EqAllot_pright_name"))
                {
                    if (row["B_EqAllot_pright_name"] != null && row["B_EqAllot_pright_name"].ToString() != "")
                    {
                        model.B_EqAllot_pright_name = row["B_EqAllot_pright_name"].ToString();
                    }
                }
                //判断案件类型（虚拟属性）是否存在
                if (row.Table.Columns.Contains("B_Case_type"))
                {
                    if (row["B_Case_type"] != null && row["B_Case_type"].ToString() != "")
                    {
                        model.B_Case_type = int.Parse(row["B_Case_type"].ToString());
                    }
                }
                //判断财产权利（虚拟属性）是否存在
                if (row.Table.Columns.Contains("B_EqAllot_pright_id"))
                {
                    if (row["B_EqAllot_pright_id"] != null && row["B_EqAllot_pright_id"].ToString() != "")
                    {
                        model.B_EqAllot_pright_id = int.Parse(row["B_EqAllot_pright_id"].ToString());
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
			strSql.Append("select B_EqAllot_id,B_EqAllot_code,B_Case_code,B_EqAllot_pright,B_EqAllot_mvalue,B_EqAllot_cusradio,B_EqAllot_explain,B_EqAllot_creator,B_EqAllot_createTime,B_EqAllot_isDelete ");
			strSql.Append(" FROM B_EqAllot ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList(Guid B_Case_code, int B_Case_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P.C_Parameters_name,E.* from C_Parameters as P left join (select * from B_EqAllot where B_Case_code=@B_Case_code and B_EqAllot_isDelete=0) as E ");
            strSql.Append("on E.B_EqAllot_pright=P.C_Parameters_id ");
            strSql.Append("where P.C_Parameters_parent=@B_Case_type ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_type",SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_code;
            parameters[1].Value = B_Case_type;

            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 根据关联Guid获得数据列表
        /// </summary>
        public DataSet GetAllListByCaseCode(Guid B_Case_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select B_EqAllot_id,B_EqAllot_code,B_Case_code,B_EqAllot_pright,B_EqAllot_mvalue,B_EqAllot_cusradio,B_EqAllot_explain,B_EqAllot_creator,B_EqAllot_createTime,B_EqAllot_isDelete from B_EqAllot ");
            strSql.Append("where B_Case_code=@B_Case_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_code;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
			strSql.Append(" B_EqAllot_id,B_EqAllot_code,B_Case_code,B_EqAllot_pright,B_EqAllot_mvalue,B_EqAllot_cusradio,B_EqAllot_explain,B_EqAllot_creator,B_EqAllot_createTime,B_EqAllot_isDelete ");
			strSql.Append(" FROM B_EqAllot ");
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_EqAllot model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select COUNT(1) from C_Parameters as P left join (select * from B_EqAllot where B_Case_code=@B_Case_code and B_EqAllot_isDelete=0) as E ");
            strSql.Append("on E.B_EqAllot_pright=P.C_Parameters_id ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    strSql.Append("and P.C_Parameters_parent=@B_Case_type ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_type",SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_code;
            parameters[1].Value = model.B_Case_type;

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
		public DataSet GetListByPage(CommonService.Model.CaseManager.B_EqAllot model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.B_EqAllot_id desc");
			}
            strSql.Append(")AS Row, T.*,P.C_Parameters_id as 'B_EqAllot_pright_id',P.C_Parameters_name as 'B_EqAllot_pright_name'  from (select * from B_EqAllot where B_Case_code=@B_Case_code and B_EqAllot_isDelete=0) T ");
            strSql.Append("right join C_Parameters as P on T.B_EqAllot_pright=P.C_Parameters_id ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    strSql.Append("and P.C_Parameters_parent=@B_Case_type ");
                }
            }

			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_type",SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_code;
            parameters[1].Value = model.B_Case_type;
			return DbHelperSQL.Query(strSql.ToString(),parameters);
		}


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

