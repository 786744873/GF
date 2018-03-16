using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:学习表
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
	public partial class K_study
	{
		public K_study()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("K_study_id", "K_study"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int K_study_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from K_study");
			strSql.Append(" where K_study_id=@K_study_id");
			SqlParameter[] parameters = {
					new SqlParameter("@K_study_id", SqlDbType.Int,4)
			};
			parameters[0].Value = K_study_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsStudy(Guid K_study_creator, Guid K_Resources_code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from K_study");
            strSql.Append(" where K_Resources_code=@K_Resources_code ");
            strSql.Append(" and K_study_creator=@K_study_creator ");
			SqlParameter[] parameters = {
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_study_creator",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Resources_code;
            parameters[1].Value = K_study_creator;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.KMS.K_study model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into K_study(");
			strSql.Append("K_study_code,K_Resources_code,K_study_createTime,K_study_creator,K_study_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@K_study_code,@K_Resources_code,@K_study_createTime,@K_study_creator,@K_study_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@K_study_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_study_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_study_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_study_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.K_study_code;
            parameters[1].Value = model.K_Resources_code;
			parameters[2].Value = model.K_study_createTime;
            parameters[3].Value = model.K_study_creator;
			parameters[4].Value = model.K_study_isDelete;

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
        public bool Update(CommonService.Model.KMS.K_study model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update K_study set ");
			strSql.Append("K_study_code=@K_study_code,");
			strSql.Append("K_Resources_code=@K_Resources_code,");
			strSql.Append("K_study_createTime=@K_study_createTime,");
			strSql.Append("K_study_creator=@K_study_creator,");
			strSql.Append("K_study_isDelete=@K_study_isDelete");
			strSql.Append(" where K_study_id=@K_study_id");
			SqlParameter[] parameters = {
					new SqlParameter("@K_study_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Resources_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_study_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_study_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_study_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_study_id", SqlDbType.Int,4)};
			parameters[0].Value = model.K_study_code;
			parameters[1].Value = model.K_Resources_code;
			parameters[2].Value = model.K_study_createTime;
			parameters[3].Value = model.K_study_creator;
			parameters[4].Value = model.K_study_isDelete;
			parameters[5].Value = model.K_study_id;

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
        public bool Delete(Guid K_study_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update K_study set K_study_isDelete=1 ");
            strSql.Append(" where K_study_code=@K_study_code");
			SqlParameter[] parameters = {
					new SqlParameter("@K_study_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_study_code;

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
		public bool DeleteList(string K_study_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from K_study ");
			strSql.Append(" where K_study_id in ("+K_study_idlist + ")  ");
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
        public CommonService.Model.KMS.K_study GetModel(int K_study_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 K_study_id,K_study_code,K_Resources_code,K_study_createTime,K_study_creator,K_study_isDelete from K_study ");
			strSql.Append(" where K_study_id=@K_study_id");
			SqlParameter[] parameters = {
					new SqlParameter("@K_study_id", SqlDbType.Int,4)
			};
			parameters[0].Value = K_study_id;

            CommonService.Model.KMS.K_study model = new CommonService.Model.KMS.K_study();
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
        public CommonService.Model.KMS.K_study GetModel(Guid K_study_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_study_id,K_study_code,K_Resources_code,K_study_createTime,K_study_creator,K_study_isDelete from K_study ");
            strSql.Append(" where K_study_isDelete=0 ");
            strSql.Append(" and K_study_code=@K_study_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_study_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_study_code;

            CommonService.Model.KMS.K_study model = new CommonService.Model.KMS.K_study();
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
        public CommonService.Model.KMS.K_study DataRowToModel(DataRow row)
		{
            CommonService.Model.KMS.K_study model = new CommonService.Model.KMS.K_study();
			if (row != null)
			{
				if(row["K_study_id"]!=null && row["K_study_id"].ToString()!="")
				{
					model.K_study_id=int.Parse(row["K_study_id"].ToString());
				}
				if(row["K_study_code"]!=null && row["K_study_code"].ToString()!="")
				{
					model.K_study_code= new Guid(row["K_study_code"].ToString());
				}
				if(row["K_Resources_code"]!=null && row["K_Resources_code"].ToString()!="")
				{
					model.K_Resources_code= new Guid(row["K_Resources_code"].ToString());
				}
				if(row["K_study_createTime"]!=null && row["K_study_createTime"].ToString()!="")
				{
					model.K_study_createTime=DateTime.Parse(row["K_study_createTime"].ToString());
				}
				if(row["K_study_creator"]!=null && row["K_study_creator"].ToString()!="")
				{
					model.K_study_creator= new Guid(row["K_study_creator"].ToString());
				}
				if(row["K_study_isDelete"]!=null && row["K_study_isDelete"].ToString()!="")
				{
					if((row["K_study_isDelete"].ToString()=="1")||(row["K_study_isDelete"].ToString().ToLower()=="true"))
					{
						model.K_study_isDelete=true;
					}
					else
					{
						model.K_study_isDelete=false;
					}
				}
                if(row.Table.Columns.Contains("K_Resources_name"))
                {
                    if(row["K_Resources_name"]!=null && row["K_Resources_name"].ToString()!="")
                    {
                        model.K_Resources_name = row["K_Resources_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_type"))
                {
                    if (row["K_Resources_type"] != null && row["K_Resources_type"].ToString() != "")
                    {
                        model.K_Resources_type = Convert.ToInt32(row["K_Resources_type"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Resources_url"))
                {
                    if (row["K_Resources_url"] != null && row["K_Resources_url"].ToString() != "")
                    {
                        model.K_Resources_url = row["K_Resources_url"].ToString();
                    }
                }
			}
			return model;
		}
         /// <summary>
        /// 最近收藏
        /// </summary>
        /// <param name="K_study_creator">用户Guid</param>
        /// <param name="pageSize">展示数量</param>
        /// <returns></returns>
        public DataSet GetListByCreatorTime(Guid K_study_creator, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top "+ pageSize.ToString());
            strSql.Append(" S.K_study_id,S.K_study_code,S.K_Resources_code,S.K_study_createTime,S.K_study_creator,S.K_study_isDelete,R.K_Resources_name as 'K_Resources_name',R.K_Resources_type as 'K_Resources_type',R.K_Resources_url as 'K_Resources_url' ");
            strSql.Append(" FROM K_study as S");
            strSql.Append(" left join K_Resources as R on S.K_Resources_code=R.K_Resources_code ");
            strSql.Append(" where S.K_study_isDelete=0 and S.K_study_creator=@K_study_creator order by S.K_study_createTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_study_creator", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_study_creator;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select K_study_id,K_study_code,K_Resources_code,K_study_createTime,K_study_creator,K_study_isDelete ");
			strSql.Append(" FROM K_study ");
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
			strSql.Append(" K_study_id,K_study_code,K_Resources_code,K_study_createTime,K_study_creator,K_study_isDelete ");
			strSql.Append(" FROM K_study ");
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
		public int GetRecordCount(CommonService.Model.KMS.K_study model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM K_study as T");
            strSql.Append(" left join K_Resources as R on T.K_Resources_code=R.K_Resources_code ");
            strSql.Append(" where 1=1 and K_study_isDelete=0 ");
            if (model != null)
            {
                if (model.K_study_creator != null && model.K_study_creator.ToString() != "")
                {
                    strSql.Append(" and K_study_creator=@K_study_creator ");
                }
                if (model.K_Resources_type == 1)
                {//获取文档：资源类型为word、pdf、excel、ppt
                    strSql.Append(" and R.K_Resources_type not in (825,827,829)");
                }
                else if (model.K_Resources_type != null && model.K_Resources_type.ToString() != "")
                {
                    strSql.Append(" and R.K_Resources_type=@K_Resources_type ");
                }
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and R.K_Resources_name like N'%'+@K_Resources_name+'%' ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_study_creator", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Resources_type",SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_name",SqlDbType.NVarChar)
			};
            parameters[0].Value = model.K_study_creator;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_name;
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
		public DataSet GetListByPage(CommonService.Model.KMS.K_study model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.K_study_id desc");
			}
            strSql.Append(")AS Row, T.*,R.K_Resources_name as 'K_Resources_name',R.K_Resources_type as 'K_Resources_type',R.K_Resources_url as 'K_Resources_url'  from K_study T ");
            strSql.Append(" left join K_Resources as R on T.K_Resources_code=R.K_Resources_code ");
            strSql.Append(" where 1=1 and T.K_study_isDelete=0 and R.K_Resources_isDelete=0 ");
            if (model != null)
            {
                if(model.K_study_creator!=null && model.K_study_creator.ToString()!="")
                {
                    strSql.Append(" and K_study_creator=@K_study_creator ");
                }
                if (model.K_Resources_type == 1)
                {//获取文档：资源类型为word、pdf、excel、ppt
                    strSql.Append(" and R.K_Resources_type not in (825,827,829)");
                }else if (model.K_Resources_type != null && model.K_Resources_type.ToString() != "")
                {
                    strSql.Append(" and R.K_Resources_type=@K_Resources_type ");
                }
                if (model.K_Resources_name != null && model.K_Resources_name.ToString() != "")
                {
                    strSql.Append(" and R.K_Resources_name like N'%'+@K_Resources_name+'%' ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex); 
            SqlParameter[] parameters = {
					new SqlParameter("@K_study_creator", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Resources_type",SqlDbType.Int,4),
                    new SqlParameter("@K_Resources_name",SqlDbType.NVarChar)
			};
            parameters[0].Value = model.K_study_creator;
            parameters[1].Value = model.K_Resources_type;
            parameters[2].Value = model.K_Resources_name;
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
			parameters[0].Value = "K_study";
			parameters[1].Value = "K_study_id";
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

