using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.FlowManager
{
    /// <summary>
    /// 数据访问类:流程----表单中间表
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class P_Flow_form
	{
		public P_Flow_form()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("P_Flow_form_id", "P_Flow_form");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Flow_form_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Flow_form");
            strSql.Append(" where P_Flow_form_id=@P_Flow_form_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_form_id", SqlDbType.Int,4)
			};
            parameters[0].Value = P_Flow_form_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid P_Flow_code, Guid F_Form_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Flow_form");
            strSql.Append(" where P_Flow_code=@P_Flow_code ");
            strSql.Append("and F_Form_code=@F_Form_code ");
            strSql.Append("and P_Flow_form_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Flow_code;
            parameters[1].Value = F_Form_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FlowManager.P_Flow_form model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into P_Flow_form(");
            strSql.Append("P_Flow_code,F_Form_code,P_Flow_form_creator,P_Flow_form_createTime,P_Flow_form_isDelete,P_Flow_form_isDefault)");
			strSql.Append(" values (");
            strSql.Append("@P_Flow_code,@F_Form_code,@P_Flow_form_creator,@P_Flow_form_createTime,@P_Flow_form_isDelete,@P_Flow_form_isDefault)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_form_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_form_createTime", SqlDbType.DateTime),
					new SqlParameter("@P_Flow_form_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@P_Flow_form_isDefault",SqlDbType.Int,4)};
            parameters[0].Value = model.P_Flow_code;
            parameters[1].Value = model.F_Form_code;
            parameters[2].Value = model.P_Flow_form_creator;
			parameters[3].Value = model.P_Flow_form_createTime;
			parameters[4].Value = model.P_Flow_form_isDelete;
            parameters[5].Value = model.P_Flow_form_isDefault;

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
        public bool Update(CommonService.Model.FlowManager.P_Flow_form model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update P_Flow_form set ");
			strSql.Append("P_Flow_code=@P_Flow_code,");
			strSql.Append("F_Form_code=@F_Form_code,");
			strSql.Append("P_Flow_form_creator=@P_Flow_form_creator,");
			strSql.Append("P_Flow_form_createTime=@P_Flow_form_createTime,");
			strSql.Append("P_Flow_form_isDelete=@P_Flow_form_isDelete,");
            strSql.Append("P_Flow_form_isDefault=@P_Flow_form_isDefault");
			strSql.Append(" where P_Flow_form_id=@P_Flow_form_id");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_form_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Flow_form_createTime", SqlDbType.DateTime),
					new SqlParameter("@P_Flow_form_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@P_Flow_form_isDefault",SqlDbType.Int,4),
					new SqlParameter("@P_Flow_form_id", SqlDbType.Int,4)};
			parameters[0].Value = model.P_Flow_code;
			parameters[1].Value = model.F_Form_code;
			parameters[2].Value = model.P_Flow_form_creator;
			parameters[3].Value = model.P_Flow_form_createTime;
			parameters[4].Value = model.P_Flow_form_isDelete;
            parameters[5].Value = model.P_Flow_form_isDefault;
			parameters[6].Value = model.P_Flow_form_id;

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
        /// 根据ID修改是否默认值为是
        /// </summary>
        /// <param name="P_Flow_form_idlist"></param>
        /// <returns></returns>
        public bool UpdateDefaulttrueByid(int P_Flow_form_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Flow_form set ");
            strSql.Append("P_Flow_form_isDefault=1 ");
            strSql.Append(" where P_Flow_form_id=@P_Flow_form_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_form_id", SqlDbType.Int,4)};
            parameters[0].Value = P_Flow_form_id;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        /// 根据ID修改是否默认值为否
        /// </summary>
        /// <param name="P_Flow_form_idlist"></param>
        /// <returns></returns>
        public bool UpdateDefaultfalseByid(int P_Flow_form_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Flow_form set ");
            strSql.Append("P_Flow_form_isDefault=0 ");
            strSql.Append(" where P_Flow_form_id=@P_Flow_form_id");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_form_id", SqlDbType.Int,4)};
            parameters[0].Value = P_Flow_form_id;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int P_Flow_form_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update P_Flow_form set P_Flow_form_isDelete=1 ");
            strSql.Append(" where P_Flow_form_id=@P_Flow_form_id");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_form_id", SqlDbType.Int,4)
			};
			parameters[0].Value = P_Flow_form_id;

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
        public int DeleteByFlowCodeAndFormCode(Guid P_Flow_code, Guid F_Form_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Flow_form set P_Flow_form_isDelete=1 ");
            strSql.Append(" where P_Flow_code=@P_Flow_code ");
            strSql.Append("and F_Form_code=@F_Form_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = P_Flow_code;
            parameters[1].Value = F_Form_code;

            object obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string P_Flow_form_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from P_Flow_form ");
			strSql.Append(" where P_Flow_form_id in ("+P_Flow_form_idlist + ")  ");
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
        public CommonService.Model.FlowManager.P_Flow_form GetModel(int P_Flow_form_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 P_Flow_form_id,P_Flow_code,F_Form_code,P_Flow_form_creator,P_Flow_form_createTime,P_Flow_form_isDelete,P_Flow_form_isDefault from P_Flow_form ");
			strSql.Append(" where P_Flow_form_id=@P_Flow_form_id");
			SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_form_id", SqlDbType.Int,4)
			};
			parameters[0].Value = P_Flow_form_id;

            CommonService.Model.FlowManager.P_Flow_form model = new CommonService.Model.FlowManager.P_Flow_form();
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
        public CommonService.Model.FlowManager.P_Flow_form DataRowToModel(DataRow row)
		{
            CommonService.Model.FlowManager.P_Flow_form model = new CommonService.Model.FlowManager.P_Flow_form();
			if (row != null)
			{
				if(row["P_Flow_form_id"]!=null && row["P_Flow_form_id"].ToString()!="")
				{
					model.P_Flow_form_id=int.Parse(row["P_Flow_form_id"].ToString());
				}
				if(row["P_Flow_code"]!=null && row["P_Flow_code"].ToString()!="")
				{
					model.P_Flow_code= new Guid(row["P_Flow_code"].ToString());
				}

                //流程名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Flow_name"))
                {
                    model.P_Flow_name = row["P_Flow_name"].ToString();
                }
				if(row["F_Form_code"]!=null && row["F_Form_code"].ToString()!="")
				{				
                    if (row["F_Form_code"] != null && row["F_Form_code"].ToString() != "")
                    {
                        model.F_Form_code = new Guid(row["F_Form_code"].ToString());
                    }
				}

                //表单显示名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("F_Form_chineseName"))
                {
                    if (row["F_Form_chineseName"] != null && row["F_Form_chineseName"].ToString() != "")
                    {
                        model.F_Form_chineseName = row["F_Form_chineseName"].ToString();
                    }
                }
 
				if(row["P_Flow_form_creator"]!=null && row["P_Flow_form_creator"].ToString()!="")
				{
					model.P_Flow_form_creator= new Guid(row["P_Flow_form_creator"].ToString());
				}
				if(row["P_Flow_form_createTime"]!=null && row["P_Flow_form_createTime"].ToString()!="")
				{
					model.P_Flow_form_createTime=DateTime.Parse(row["P_Flow_form_createTime"].ToString());
				}
				if(row["P_Flow_form_isDelete"]!=null && row["P_Flow_form_isDelete"].ToString()!="")
				{
					model.P_Flow_form_isDelete=int.Parse(row["P_Flow_form_isDelete"].ToString());
				}
                if (row["P_Flow_form_isDefault"] != null && row["P_Flow_form_isDefault"].ToString() != "")
                {
                    model.P_Flow_form_isDefault = int.Parse(row["P_Flow_form_isDefault"].ToString());
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
            strSql.Append("select P_Flow_form_id,P_Flow_code,F_Form_code,P_Flow_form_creator,P_Flow_form_createTime,P_Flow_form_isDelete,P_Flow_form_isDefault ");
			strSql.Append(" FROM P_Flow_form ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="flowCode"></param>
        /// <returns></returns>
        public DataSet GetListByFlowCode(Guid flowCode, int isDefalut)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Flow_form_id,P_Flow_code,F_Form_code,P_Flow_form_creator,P_Flow_form_createTime,P_Flow_form_isDelete,P_Flow_form_isDefault from P_Flow_form ");
            strSql.Append(" where P_Flow_code=@P_Flow_code and P_Flow_form_isDefault=@isDefalut and P_Flow_form_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@isDefalut", SqlDbType.Int,4)
			};
            parameters[0].Value = flowCode;
            parameters[1].Value = isDefalut;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public DataSet GetListByFlowCode(Guid flowCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PFF.P_Flow_form_id,PFF.P_Flow_code,PFF.F_Form_code,PFF.P_Flow_form_creator,PFF.P_Flow_form_createTime,PFF.P_Flow_form_isDelete,PFF.P_Flow_form_isDefault,");
            strSql.Append("F.F_Form_chineseName AS F_Form_chineseName ");
            strSql.Append("from P_Flow_form AS PFF WITH(NOLOCK) ");
            strSql.Append("left join F_Form AS F WITH(NOLOCK) on PFF.F_Form_code = F.F_Form_code ");
            strSql.Append("where P_Flow_code=@P_Flow_code and P_Flow_form_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16)                   
			};
            parameters[0].Value = flowCode;
           
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
            strSql.Append(" P_Flow_form_id,P_Flow_code,F_Form_code,P_Flow_form_creator,P_Flow_form_createTime,P_Flow_form_isDelete,P_Flow_form_isDefault ");
			strSql.Append(" FROM P_Flow_form ");
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
		public int GetRecordCount(CommonService.Model.FlowManager.P_Flow_form model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM P_Flow_form ");
            strSql.Append(" where 1=1 and P_Flow_form_isDelete=0 ");
            if (model != null)
            {
                if (model.P_Flow_code != null && model.P_Flow_code.ToString() != "")
                {
                    strSql.Append(" and P_Flow_code=@P_Flow_code");
                }
                 if (model.F_Form_code != null && model.F_Form_code.ToString() != "")
                {
                    strSql.Append(" and F_Form_code=@F_Form_code");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.P_Flow_code;
			parameters[1].Value = model.F_Form_code;
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
		public DataSet GetListByPage(CommonService.Model.FlowManager.P_Flow_form model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.P_Flow_form_id desc");
			}
            strSql.Append(")AS Row, T.*,F.P_Flow_name,FM.F_Form_chineseName  from P_Flow_form T ");
            strSql.Append("left join P_Flow as F on F.P_Flow_code=T.P_Flow_code left join F_Form as FM on FM.F_Form_code=T.F_Form_code ");
            strSql.Append(" where 1=1 and T.P_Flow_form_isDelete=0 ");
            if (model != null)
            {
                if (model.P_Flow_code != null && model.P_Flow_code.ToString() != "")
                {
                    strSql.Append(" and T.P_Flow_code=@P_Flow_code");
                }
                 if (model.F_Form_code != null && model.F_Form_code.ToString() != "")
                {
                    strSql.Append(" and T.F_Form_code=@F_Form_code");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.P_Flow_code;
            parameters[1].Value = model.F_Form_code;
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
			parameters[0].Value = "P_Flow_form";
			parameters[1].Value = "P_Flow_form_id";
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

