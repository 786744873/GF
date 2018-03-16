using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:客户委托人关系表
    /// 作者：贺太玉
    /// 日期：2015/05/06
    /// </summary>
    public partial class C_Customer_Customer
    {
        public C_Customer_Customer()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Customer_Customer_Id", "C_Customer_Customer");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Customer_Customer_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Customer_Customer");
            strSql.Append(" where C_Customer_Customer_Id=@C_Customer_Customer_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Customer_Id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_Customer_Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Customer_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Customer_Customer(");
            strSql.Append("C_Customer_Customer_customer,C_Customer_Customer_relCustomer,C_Customer_Customer_isDelete,C_Customer_Customer_creator,C_Customer_Customer_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Customer_Customer_customer,@C_Customer_Customer_relCustomer,@C_Customer_Customer_isDelete,@C_Customer_Customer_creator,@C_Customer_Customer_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Customer_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Customer_relCustomer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Customer_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Customer_Customer_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Customer_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Customer_Customer_customer;
            parameters[1].Value = model.C_Customer_Customer_relCustomer;
            parameters[2].Value = model.C_Customer_Customer_isDelete;
            parameters[3].Value = model.C_Customer_Customer_creator;
            parameters[4].Value = model.C_Customer_Customer_createTime;

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
        public bool Update(CommonService.Model.C_Customer_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer_Customer set ");
            strSql.Append("C_Customer_Customer_customer=@C_Customer_Customer_customer,");
            strSql.Append("C_Customer_Customer_relCustomer=@C_Customer_Customer_relCustomer,");
            strSql.Append("C_Customer_Customer_isDelete=@C_Customer_Customer_isDelete,");
            strSql.Append("C_Customer_Customer_creator=@C_Customer_Customer_creator,");
            strSql.Append("C_Customer_Customer_createTime=@C_Customer_Customer_createTime");
            strSql.Append(" where C_Customer_Customer_Id=@C_Customer_Customer_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Customer_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Customer_relCustomer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Customer_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Customer_Customer_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Customer_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_Customer_Id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Customer_Customer_customer;
            parameters[1].Value = model.C_Customer_Customer_relCustomer;
            parameters[2].Value = model.C_Customer_Customer_isDelete;
            parameters[3].Value = model.C_Customer_Customer_creator;
            parameters[4].Value = model.C_Customer_Customer_createTime;
            parameters[5].Value = model.C_Customer_Customer_Id;

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
        /// 删除一条记录
        /// </summary>
        /// <param name="relationCode">客户Guid</param>
        /// <param name="clientCode">关联委托人Guid</param>
        /// <returns></returns>
        public bool Delete(Guid relationCode,Guid clientCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer_Customer set C_Customer_Customer_isDelete=1 ");
            strSql.Append(" where C_Customer_Customer_customer=@C_Customer_Customer_customer ");
            strSql.Append(" and C_Customer_Customer_relCustomer=@C_Customer_Customer_relCustomer ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Customer_customer", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_Customer_relCustomer",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = relationCode;
            parameters[1].Value = clientCode;

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
        public bool DeleteList(string C_Customer_Customer_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Customer_Customer ");
            strSql.Append(" where C_Customer_Customer_Id in (" + C_Customer_Customer_Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public CommonService.Model.C_Customer_Customer GetModel(int C_Customer_Customer_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Customer_Customer_Id,C_Customer_Customer_customer,C_Customer_Customer_relCustomer,C_Customer_Customer_isDelete,C_Customer_Customer_creator,C_Customer_Customer_createTime from C_Customer_Customer ");
            strSql.Append(" where C_Customer_Customer_Id=@C_Customer_Customer_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Customer_Id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_Customer_Id;

            CommonService.Model.C_Customer_Customer model = new CommonService.Model.C_Customer_Customer();
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
        public CommonService.Model.C_Customer_Customer DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Customer_Customer model = new CommonService.Model.C_Customer_Customer();
            if (row != null)
            {
                if (row["C_Customer_Customer_Id"] != null && row["C_Customer_Customer_Id"].ToString() != "")
                {
                    model.C_Customer_Customer_Id = int.Parse(row["C_Customer_Customer_Id"].ToString());
                }
                if (row["C_Customer_Customer_customer"] != null && row["C_Customer_Customer_customer"].ToString() != "")
                {
                    model.C_Customer_Customer_customer = new Guid(row["C_Customer_Customer_customer"].ToString());
                }
                if (row["C_Customer_Customer_relCustomer"] != null && row["C_Customer_Customer_relCustomer"].ToString() != "")
                {
                    model.C_Customer_Customer_relCustomer = new Guid(row["C_Customer_Customer_relCustomer"].ToString());
                }
                if (row["C_Customer_Customer_isDelete"] != null && row["C_Customer_Customer_isDelete"].ToString() != "")
                {
                    if ((row["C_Customer_Customer_isDelete"].ToString() == "1") || (row["C_Customer_Customer_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Customer_Customer_isDelete = true;
                    }
                    else
                    {
                        model.C_Customer_Customer_isDelete = false;
                    }
                }
                if (row["C_Customer_Customer_creator"] != null && row["C_Customer_Customer_creator"].ToString() != "")
                {
                    model.C_Customer_Customer_creator = new Guid(row["C_Customer_Customer_creator"].ToString());
                }
                if (row["C_Customer_Customer_createTime"] != null && row["C_Customer_Customer_createTime"].ToString() != "")
                {
                    model.C_Customer_Customer_createTime = DateTime.Parse(row["C_Customer_Customer_createTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Customer_Customer_Id,C_Customer_Customer_customer,C_Customer_Customer_relCustomer,C_Customer_Customer_isDelete,C_Customer_Customer_creator,C_Customer_Customer_createTime ");
            strSql.Append(" FROM C_Customer_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" C_Customer_Customer_Id,C_Customer_Customer_customer,C_Customer_Customer_relCustomer,C_Customer_Customer_isDelete,C_Customer_Customer_creator,C_Customer_Customer_createTime ");
            strSql.Append(" FROM C_Customer_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Customer_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.C_Customer_Customer_Id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Customer_Customer T ");
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
            parameters[0].Value = "C_Customer_Customer";
            parameters[1].Value = "C_Customer_Customer_Id";
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
