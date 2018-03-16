using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:知识分类和（资源，问吧）中间表
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
	public partial class K_Knowledge_Resources
	{
		public K_Knowledge_Resources()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("K_Knowledge_Resources_id", "K_Knowledge_Resources"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int K_Knowledge_Resources_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from K_Knowledge_Resources");
			strSql.Append(" where K_Knowledge_Resources_id=@K_Knowledge_Resources_id");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_Resources_id", SqlDbType.Int,4)
			};
			parameters[0].Value = K_Knowledge_Resources_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid K_Knowledge_code, Guid P_FK_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Knowledge_Resources");
            strSql.Append(" where K_Knowledge_code=@K_Knowledge_code ");
            strSql.Append(" and P_FK_code=@P_FK_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_FK_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Knowledge_code;
            parameters[1].Value = P_FK_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.KMS.K_Knowledge_Resources model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into K_Knowledge_Resources(");
			strSql.Append("K_Knowledge_Resources_code,K_Knowledge_Resources_type,P_FK_code,K_Knowledge_code,K_Knowledge_Resources_creator,K_Knowledge_Resources_isDelete,K_Knowledge_Resources_createTime)");
			strSql.Append(" values (");
			strSql.Append("@K_Knowledge_Resources_code,@K_Knowledge_Resources_type,@P_FK_code,@K_Knowledge_code,@K_Knowledge_Resources_creator,@K_Knowledge_Resources_isDelete,@K_Knowledge_Resources_createTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_Resources_type", SqlDbType.Int,4),
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_Resources_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_Resources_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Knowledge_Resources_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.K_Knowledge_Resources_code;
			parameters[1].Value = model.K_Knowledge_Resources_type;
            parameters[2].Value = model.P_FK_code;
            parameters[3].Value = model.K_Knowledge_code;
            parameters[4].Value = model.K_Knowledge_Resources_creator;
			parameters[5].Value = model.K_Knowledge_Resources_isDelete;
			parameters[6].Value = model.K_Knowledge_Resources_createTime;

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
        public bool Update(CommonService.Model.KMS.K_Knowledge_Resources model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update K_Knowledge_Resources set ");
			strSql.Append("K_Knowledge_Resources_code=@K_Knowledge_Resources_code,");
			strSql.Append("K_Knowledge_Resources_type=@K_Knowledge_Resources_type,");
			strSql.Append("P_FK_code=@P_FK_code,");
			strSql.Append("K_Knowledge_code=@K_Knowledge_code,");
			strSql.Append("K_Knowledge_Resources_creator=@K_Knowledge_Resources_creator,");
			strSql.Append("K_Knowledge_Resources_isDelete=@K_Knowledge_Resources_isDelete,");
			strSql.Append("K_Knowledge_Resources_createTime=@K_Knowledge_Resources_createTime");
			strSql.Append(" where K_Knowledge_Resources_id=@K_Knowledge_Resources_id");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_Resources_type", SqlDbType.Int,4),
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_Resources_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Knowledge_Resources_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Knowledge_Resources_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Knowledge_Resources_id", SqlDbType.Int,4)};
			parameters[0].Value = model.K_Knowledge_Resources_code;
			parameters[1].Value = model.K_Knowledge_Resources_type;
			parameters[2].Value = model.P_FK_code;
			parameters[3].Value = model.K_Knowledge_code;
			parameters[4].Value = model.K_Knowledge_Resources_creator;
			parameters[5].Value = model.K_Knowledge_Resources_isDelete;
			parameters[6].Value = model.K_Knowledge_Resources_createTime;
			parameters[7].Value = model.K_Knowledge_Resources_id;

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
        public bool Delete(Guid K_Knowledge_Resources_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update K_Knowledge_Resources set K_Knowledge_Resources_isDelete=1 ");
            strSql.Append(" where K_Knowledge_Resources_code=@K_Knowledge_Resources_code");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_Resources_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Knowledge_Resources_code;

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
        /// 根据关联Guid删除一条数据
        /// </summary>
        public bool DeleteByFkCode(Guid P_FK_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Knowledge_Resources set K_Knowledge_Resources_isDelete=1 ");
            strSql.Append(" where P_FK_code=@P_FK_code");
            SqlParameter[] parameters = {
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_FK_code;

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
		public bool DeleteList(string K_Knowledge_Resources_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from K_Knowledge_Resources ");
			strSql.Append(" where K_Knowledge_Resources_id in ("+K_Knowledge_Resources_idlist + ")  ");
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
        /// 移动资源
        /// </summary>
        /// <param name="knowledgeCode">知识分类Guid</param>
        /// <param name="resourcesCode">资源Guid</param>
        /// <returns></returns>
        public bool MobileResource(Guid knowledgeCode, Guid resourcesCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Knowledge_Resources set K_Knowledge_code=@K_Knowledge_code ");
            strSql.Append(" where P_FK_code=@P_FK_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@K_Knowledge_code",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = knowledgeCode;
            parameters[1].Value = resourcesCode;

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
        public CommonService.Model.KMS.K_Knowledge_Resources GetModel(int K_Knowledge_Resources_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 K_Knowledge_Resources_id,K_Knowledge_Resources_code,K_Knowledge_Resources_type,P_FK_code,K_Knowledge_code,K_Knowledge_Resources_creator,K_Knowledge_Resources_isDelete,K_Knowledge_Resources_createTime from K_Knowledge_Resources ");
			strSql.Append(" where K_Knowledge_Resources_id=@K_Knowledge_Resources_id");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_Resources_id", SqlDbType.Int,4)
			};
			parameters[0].Value = K_Knowledge_Resources_id;

            CommonService.Model.KMS.K_Knowledge_Resources model = new CommonService.Model.KMS.K_Knowledge_Resources();
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
        /// 根据关联Guid获取一条数据
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Knowledge_Resources GetModelByFkCode(Guid P_FK_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top(1)* from K_Knowledge_Resources ");
            strSql.Append(" where P_FK_code=@P_FK_code and K_Knowledge_Resources_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@P_FK_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_FK_code;

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
        public CommonService.Model.KMS.K_Knowledge_Resources GetModel(Guid K_Knowledge_Resources_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Knowledge_Resources_id,K_Knowledge_Resources_code,K_Knowledge_Resources_type,P_FK_code,K_Knowledge_code,K_Knowledge_Resources_creator,K_Knowledge_Resources_isDelete,K_Knowledge_Resources_createTime from K_Knowledge_Resources ");
            strSql.Append(" where K_Knowledge_Resources_isDelete=0 ");
            strSql.Append(" and K_Knowledge_Resources_code=@K_Knowledge_Resources_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Knowledge_Resources_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Knowledge_Resources_code;

            CommonService.Model.KMS.K_Knowledge_Resources model = new CommonService.Model.KMS.K_Knowledge_Resources();
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
        public CommonService.Model.KMS.K_Knowledge_Resources DataRowToModel(DataRow row)
		{
            CommonService.Model.KMS.K_Knowledge_Resources model = new CommonService.Model.KMS.K_Knowledge_Resources();
			if (row != null)
			{
				if(row["K_Knowledge_Resources_id"]!=null && row["K_Knowledge_Resources_id"].ToString()!="")
				{
					model.K_Knowledge_Resources_id=int.Parse(row["K_Knowledge_Resources_id"].ToString());
				}
				if(row["K_Knowledge_Resources_code"]!=null && row["K_Knowledge_Resources_code"].ToString()!="")
				{
					model.K_Knowledge_Resources_code= new Guid(row["K_Knowledge_Resources_code"].ToString());
				}
				if(row["K_Knowledge_Resources_type"]!=null && row["K_Knowledge_Resources_type"].ToString()!="")
				{
					model.K_Knowledge_Resources_type=int.Parse(row["K_Knowledge_Resources_type"].ToString());
				}
				if(row["P_FK_code"]!=null && row["P_FK_code"].ToString()!="")
				{
					model.P_FK_code= new Guid(row["P_FK_code"].ToString());
				}
				if(row["K_Knowledge_code"]!=null && row["K_Knowledge_code"].ToString()!="")
				{
					model.K_Knowledge_code= new Guid(row["K_Knowledge_code"].ToString());
				}
				if(row["K_Knowledge_Resources_creator"]!=null && row["K_Knowledge_Resources_creator"].ToString()!="")
				{
					model.K_Knowledge_Resources_creator= new Guid(row["K_Knowledge_Resources_creator"].ToString());
				}
				if(row["K_Knowledge_Resources_isDelete"]!=null && row["K_Knowledge_Resources_isDelete"].ToString()!="")
				{
					if((row["K_Knowledge_Resources_isDelete"].ToString()=="1")||(row["K_Knowledge_Resources_isDelete"].ToString().ToLower()=="true"))
					{
						model.K_Knowledge_Resources_isDelete=true;
					}
					else
					{
						model.K_Knowledge_Resources_isDelete=false;
					}
				}
				if(row["K_Knowledge_Resources_createTime"]!=null && row["K_Knowledge_Resources_createTime"].ToString()!="")
				{
					model.K_Knowledge_Resources_createTime=DateTime.Parse(row["K_Knowledge_Resources_createTime"].ToString());
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
			strSql.Append("select K_Knowledge_Resources_id,K_Knowledge_Resources_code,K_Knowledge_Resources_type,P_FK_code,K_Knowledge_code,K_Knowledge_Resources_creator,K_Knowledge_Resources_isDelete,K_Knowledge_Resources_createTime ");
			strSql.Append(" FROM K_Knowledge_Resources ");
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
			strSql.Append(" K_Knowledge_Resources_id,K_Knowledge_Resources_code,K_Knowledge_Resources_type,P_FK_code,K_Knowledge_code,K_Knowledge_Resources_creator,K_Knowledge_Resources_isDelete,K_Knowledge_Resources_createTime ");
			strSql.Append(" FROM K_Knowledge_Resources ");
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
		public int GetRecordCount(CommonService.Model.KMS.K_Knowledge_Resources model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM K_Knowledge_Resources ");
            strSql.Append(" where 1=1 and K_Knowledge_Resources_isDelete=0 ");
            if (model != null)
            {

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
		public DataSet GetListByPage(CommonService.Model.KMS.K_Knowledge_Resources model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.K_Knowledge_Resources_id desc");
			}
            strSql.Append(")AS Row, T.*  from K_Knowledge_Resources T ");
            strSql.Append(" where 1=1 and T.K_Knowledge_Resources_isDelete=0 ");
            if (model != null)
            {

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
			parameters[0].Value = "K_Knowledge_Resources";
			parameters[1].Value = "K_Knowledge_Resources_id";
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

