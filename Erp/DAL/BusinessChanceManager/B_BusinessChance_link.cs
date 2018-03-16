using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace CommonService.DAL.BusinessChanceManager
{
    /// <summary>
    /// 数据访问类:商机关联表
    /// 作者：崔慧栋
    /// 日期：2015/07/27
    /// </summary>
	public partial class B_BusinessChance_link
	{
		public B_BusinessChance_link()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("B_BusinessChance_link_id", "B_BusinessChance_link"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int B_BusinessChance_link_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_BusinessChance_link");
			strSql.Append(" where B_BusinessChance_link_id=@B_BusinessChance_link_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_link_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_BusinessChance_link_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsBusinessChanceLink(Guid B_BusinessChance_code, Guid C_FK_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_BusinessChance_link");
            strSql.Append(" where B_BusinessChance_code=@B_BusinessChance_code ");
            strSql.Append("and C_FK_code=@C_FK_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_BusinessChance_code;
            parameters[1].Value = C_FK_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_BusinessChance_link(");
			strSql.Append("B_BusinessChance_code,C_FK_code,B_BusinessChance_link_type,B_BusinessChance_link_creator,B_BusinessChance_link_createTime,B_BusinessChance_link_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@B_BusinessChance_code,@C_FK_code,@B_BusinessChance_link_type,@B_BusinessChance_link_creator,@B_BusinessChance_link_createTime,@B_BusinessChance_link_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_link_type", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_link_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_link_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_link_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.B_BusinessChance_code;
            parameters[1].Value = model.C_FK_code;
			parameters[2].Value = model.B_BusinessChance_link_type;
            parameters[3].Value = model.B_BusinessChance_link_creator;
			parameters[4].Value = model.B_BusinessChance_link_createTime;
			parameters[5].Value = model.B_BusinessChance_link_isDelete;

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
        public bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_BusinessChance_link set ");
			strSql.Append("B_BusinessChance_code=@B_BusinessChance_code,");
			strSql.Append("C_FK_code=@C_FK_code,");
			strSql.Append("B_BusinessChance_link_type=@B_BusinessChance_link_type,");
			strSql.Append("B_BusinessChance_link_creator=@B_BusinessChance_link_creator,");
			strSql.Append("B_BusinessChance_link_createTime=@B_BusinessChance_link_createTime,");
			strSql.Append("B_BusinessChance_link_isDelete=@B_BusinessChance_link_isDelete");
			strSql.Append(" where B_BusinessChance_link_id=@B_BusinessChance_link_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_link_type", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_link_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_link_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_link_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_link_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_BusinessChance_code;
			parameters[1].Value = model.C_FK_code;
			parameters[2].Value = model.B_BusinessChance_link_type;
			parameters[3].Value = model.B_BusinessChance_link_creator;
			parameters[4].Value = model.B_BusinessChance_link_createTime;
			parameters[5].Value = model.B_BusinessChance_link_isDelete;
			parameters[6].Value = model.B_BusinessChance_link_id;

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
		/// 根据商机Guid和类型删除所关联数据
		/// </summary>
        public bool Delete(Guid B_BusinessChance_code, int B_BusinessChance_link_type)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from B_BusinessChance_link ");
            strSql.Append(" where B_BusinessChance_code=@B_BusinessChance_code ");
            strSql.Append("and B_BusinessChance_link_type=@B_BusinessChance_link_type ");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_link_type",SqlDbType.Int,4)
			};
            parameters[0].Value = B_BusinessChance_code;
            parameters[1].Value = B_BusinessChance_link_type;

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
        /// 根据商机Guid和关联Guid删除所关联数据
        /// </summary>
        public bool Delete(Guid B_BusinessChance_code, Guid C_FK_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_BusinessChance_link ");
            strSql.Append(" where B_BusinessChance_code=@B_BusinessChance_code ");
            strSql.Append("and C_FK_code=@C_FK_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_BusinessChance_code;
            parameters[1].Value = C_FK_code;

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
        /// 根据商机Guid删除所关联数据
        /// </summary>
        public bool DeleteByBusinessChanceCode(Guid B_BusinessChance_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_BusinessChance_link ");
            strSql.Append(" where B_BusinessChance_code=@B_BusinessChance_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_BusinessChance_code;

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
		public bool DeleteList(string B_BusinessChance_link_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_BusinessChance_link ");
			strSql.Append(" where B_BusinessChance_link_id in ("+B_BusinessChance_link_idlist + ")  ");
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
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_link GetModel(int B_BusinessChance_link_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 B_BusinessChance_link_id,B_BusinessChance_code,C_FK_code,B_BusinessChance_link_type,B_BusinessChance_link_creator,B_BusinessChance_link_createTime,B_BusinessChance_link_isDelete from B_BusinessChance_link ");
            strSql.Append(" where B_BusinessChance_link_id=@B_BusinessChance_link_id and B_BusinessChance_link_isDelete=0");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_link_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_BusinessChance_link_id;

            CommonService.Model.BusinessChanceManager.B_BusinessChance_link model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
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
        /// 根据商机code和类型得到一个对象实体
        /// </summary>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_link GetModelByFk_codeAndType(Guid? Fk_code,int? type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_BusinessChance_link_id,B_BusinessChance_code,C_FK_code,B_BusinessChance_link_type,B_BusinessChance_link_creator,B_BusinessChance_link_createTime,B_BusinessChance_link_isDelete from B_BusinessChance_link ");
            strSql.Append(" where B_BusinessChance_code=@B_BusinessChance_code and B_BusinessChance_link_type=@B_BusinessChance_link_type and B_BusinessChance_link_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_link_type", SqlDbType.Int,4)
			};
            parameters[0].Value = Fk_code;
            parameters[1].Value = type;
            CommonService.Model.BusinessChanceManager.B_BusinessChance_link model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
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
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_link DataRowToModel(DataRow row)
		{
            CommonService.Model.BusinessChanceManager.B_BusinessChance_link model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
			if (row != null)
			{
				if(row["B_BusinessChance_link_id"]!=null && row["B_BusinessChance_link_id"].ToString()!="")
				{
					model.B_BusinessChance_link_id=int.Parse(row["B_BusinessChance_link_id"].ToString());
				}
				if(row["B_BusinessChance_code"]!=null && row["B_BusinessChance_code"].ToString()!="")
				{
					model.B_BusinessChance_code= new Guid(row["B_BusinessChance_code"].ToString());
				}
				if(row["C_FK_code"]!=null && row["C_FK_code"].ToString()!="")
				{
					model.C_FK_code= new Guid(row["C_FK_code"].ToString());
				}
				if(row["B_BusinessChance_link_type"]!=null && row["B_BusinessChance_link_type"].ToString()!="")
				{
					model.B_BusinessChance_link_type=int.Parse(row["B_BusinessChance_link_type"].ToString());
				}
				if(row["B_BusinessChance_link_creator"]!=null && row["B_BusinessChance_link_creator"].ToString()!="")
				{
					model.B_BusinessChance_link_creator= new Guid(row["B_BusinessChance_link_creator"].ToString());
				}
				if(row["B_BusinessChance_link_createTime"]!=null && row["B_BusinessChance_link_createTime"].ToString()!="")
				{
					model.B_BusinessChance_link_createTime=DateTime.Parse(row["B_BusinessChance_link_createTime"].ToString());
				}
				if(row["B_BusinessChance_link_isDelete"]!=null && row["B_BusinessChance_link_isDelete"].ToString()!="")
				{
					model.B_BusinessChance_link_isDelete=int.Parse(row["B_BusinessChance_link_isDelete"].ToString());
				}
                if (row.Table.Columns.Contains("C_Customer_name"))
                {
                    model.C_Customer_name = row["C_Customer_name"].ToString();
                }
                if (row.Table.Columns.Contains("C_CRival_name"))
                {
                    model.C_CRival_name = row["C_CRival_name"].ToString();
                }
                if (row.Table.Columns.Contains("C_PRival_name"))
                {
                    model.C_PRival_name = row["C_PRival_name"].ToString();
                }
                if (row.Table.Columns.Contains("C_Involved_project_name"))
                {
                    model.C_Involved_project_name = row["C_Involved_project_name"].ToString();
                }
                if (row.Table.Columns.Contains("C_Userinfo_name"))
                {
                    model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
                }
                if(row.Table.Columns.Contains("C_Region_name"))
                {
                    model.C_Region_name = row["C_Region_name"].ToString();
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
			strSql.Append("select B_BusinessChance_link_id,B_BusinessChance_code,C_FK_code,B_BusinessChance_link_type,B_BusinessChance_link_creator,B_BusinessChance_link_createTime,B_BusinessChance_link_isDelete ");
			strSql.Append(" FROM B_BusinessChance_link ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据商机Guid，类型值，获取商机关联数据集合
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="linkType">类型值</param>
        /// <returns></returns>     
        public DataSet GetBusinessChanceLinks(Guid businessChanceCode, int linkType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from B_BusinessChance_link with(nolock) ");
            strSql.Append("where B_BusinessChance_link_isDelete = 0 and B_BusinessChance_code=@B_BusinessChance_code and B_BusinessChance_link_type=@B_BusinessChance_link_type ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_link_type", SqlDbType.Int,4)
			};
            parameters[0].Value = businessChanceCode;
            parameters[1].Value = linkType;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据商机Guid，获取商机关联数据集合
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param> 
        /// <returns></returns>     
        public DataSet GetBusinessChanceAllLinks(Guid businessChanceCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from B_BusinessChance_link with(nolock) ");
            strSql.Append("where B_BusinessChance_link_isDelete=0 and B_BusinessChance_code=@B_BusinessChance_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)        
			};
            parameters[0].Value = businessChanceCode;
         
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
			strSql.Append(" B_BusinessChance_link_id,B_BusinessChance_code,C_FK_code,B_BusinessChance_link_type,B_BusinessChance_link_creator,B_BusinessChance_link_createTime,B_BusinessChance_link_isDelete ");
			strSql.Append(" FROM B_BusinessChance_link ");
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
		public int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM B_BusinessChance_link ");
            strSql.Append(" where 1=1 and B_BusinessChance_link_isDelete=0 ");
            if (model != null)
            {
                if (model.B_BusinessChance_code != null && model.B_BusinessChance_code.ToString() != "")
                {
                    strSql.Append("and B_BusinessChance_code=@B_BusinessChance_code ");
                }
                if (model.C_FK_code != null && model.C_FK_code.ToString() != "")
                {
                    strSql.Append("and C_FK_code=@C_FK_code ");
                }
                if (model.B_BusinessChance_link_type != null && model.B_BusinessChance_link_type.ToString() != "")
                {
                    strSql.Append("and B_BusinessChance_link_type=@B_BusinessChance_link_type ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_link_type", SqlDbType.Int,4)};
            parameters[0].Value = model.B_BusinessChance_code;
            parameters[1].Value = model.C_FK_code;
            parameters[2].Value = model.B_BusinessChance_link_type;
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


        public DataSet GetLinkByCode(Guid guid,int type)
        {
            string str = "select * from B_BusinessChance_link where B_BusinessChance_code='" + guid.ToString() + "' and B_BusinessChance_link_type="+type;
            return DbHelperSQL.Query(str.ToString());
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.B_BusinessChance_link_id desc");
			}
            strSql.Append(")AS Row, T.*  from B_BusinessChance_link T ");
            strSql.Append(" where 1=1 and B_BusinessChance_link_isDelete=0 ");
            if (model != null)
            {
                if (model.B_BusinessChance_code != null && model.B_BusinessChance_code.ToString() != "")
                {
                    strSql.Append("and B_BusinessChance_code=@B_BusinessChance_code ");
                }
                if (model.C_FK_code != null && model.C_FK_code.ToString() != "")
                {
                    strSql.Append("and C_FK_code=@C_FK_code ");
                }
                if (model.B_BusinessChance_link_type != null && model.B_BusinessChance_link_type.ToString() != "")
                {
                    strSql.Append("and B_BusinessChance_link_type=@B_BusinessChance_link_type ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_link_type", SqlDbType.Int,4)};
            parameters[0].Value = model.B_BusinessChance_code;
            parameters[1].Value = model.C_FK_code;
            parameters[2].Value = model.B_BusinessChance_link_type;
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
			parameters[0].Value = "B_BusinessChance_link";
			parameters[1].Value = "B_BusinessChance_link_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> DataRowToList(DataSet ds)
        {
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> modelList = new List<Model.BusinessChanceManager.B_BusinessChance_link>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.BusinessChanceManager.B_BusinessChance_link model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(ds.Tables[0].Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 根据商机Code获得关联客户，委托人数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetCustomerListByBusinessChancecode(Guid B_BusinessChance_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BCL.*,CUS.C_Customer_name from B_BusinessChance_link as BCL join C_Customer as CUS on BCL.C_FK_code=CUS.C_Customer_code ");
            strSql.Append("where BCL.B_BusinessChance_code=@B_BusinessChance_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = B_BusinessChance_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return DataRowToList(ds);
        }

        /// <summary>
        /// 根据商机Code获得关联对方当事人公司数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetCRivalListByBusinessChancecode(Guid B_BusinessChance_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BCL.*,CR.C_CRival_name from B_BusinessChance_link as BCL join C_CRival as CR on BCL.C_FK_code=CR.C_CRival_code ");
            strSql.Append("where BCL.B_BusinessChance_code=@B_BusinessChance_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = B_BusinessChance_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return DataRowToList(ds);
        }

        /// <summary>
        /// 根据商机Code获得关联对方当事人个人数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetPRivalListByBusinessChancecode(Guid B_BusinessChance_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BCL.*,PR.C_PRival_name from B_BusinessChance_link as BCL join C_PRival as PR on BCL.C_FK_code=PR.C_PRival_code ");
            strSql.Append("where BCL.B_BusinessChance_code=@B_BusinessChance_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = B_BusinessChance_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return DataRowToList(ds);
        }

        /// <summary>
        /// 根据商机Code获得关联工程数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetProjectListByBusinessChancecode(Guid B_BusinessChance_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BCL.*,PRO.C_Involved_project_name from B_BusinessChance_link as BCL join C_Involved_project as PRO on BCL.C_FK_code=PRO.C_Involved_project_code ");
            strSql.Append("where BCL.B_BusinessChance_code=@B_BusinessChance_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = B_BusinessChance_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return DataRowToList(ds);
        }

        /// <summary>
        /// 根据商机Code获得关联数据列表(所有类型的数据)
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetConsultantListByBusinessChancecode(Guid B_BusinessChance_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BCL.*,U.C_Userinfo_name ");
            strSql.Append("from B_BusinessChance_link as BCL ");
            strSql.Append("join C_Userinfo as U on BCL.C_FK_code=U.C_Userinfo_code ");
            strSql.Append("where BCL.B_BusinessChance_code=@B_BusinessChance_code ");
            strSql.Append("and BCL.B_BusinessChance_link_isDelete=0 and U.C_Userinfo_isDelete=0 and U.C_Userinfo_state=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = B_BusinessChance_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return DataRowToList(ds);
        }

        /// <summary>
        /// 根据商机Code获得关联区域数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetRegionListByBusinessChancecode(Guid B_BusinessChance_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BCL.*,R.C_Region_name from B_BusinessChance_link as BCL join C_Region as R on BCL.C_FK_code=R.C_Region_code ");
            strSql.Append("where BCL.B_BusinessChance_code=@B_BusinessChance_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = B_BusinessChance_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return DataRowToList(ds);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

