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
    /// 数据访问类:客户联系人关联表
    /// 作者：贺太玉
    /// 日期：2015/05/04
    /// </summary>
    public partial class C_Customer_Contacts
    {
        public C_Customer_Contacts()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Customer_Contacts_Id", "C_Customer_Contacts");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Customer_Contacts_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Customer_Contacts");
            strSql.Append(" where C_Customer_Contacts_Id=@C_Customer_Contacts_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Contacts_Id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_Contacts_Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Customer_Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Customer_Contacts(");
            strSql.Append("C_Customer_Contacts_customer,C_Customer_Contacts_contact,C_Customer_Contacts_isDelete,C_Customer_Contacts_creator,C_Customer_Contacts_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Customer_Contacts_customer,@C_Customer_Contacts_contact,@C_Customer_Contacts_isDelete,@C_Customer_Contacts_creator,@C_Customer_Contacts_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Contacts_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Contacts_contact", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Contacts_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Customer_Contacts_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Contacts_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Customer_Contacts_customer;
            parameters[1].Value = model.C_Customer_Contacts_contact;
            parameters[2].Value = model.C_Customer_Contacts_isDelete;
            parameters[3].Value = model.C_Customer_Contacts_creator;
            parameters[4].Value = model.C_Customer_Contacts_createTime;

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
        public bool Update(CommonService.Model.C_Customer_Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer_Contacts set ");
            strSql.Append("C_Customer_Contacts_customer=@C_Customer_Contacts_customer,");
            strSql.Append("C_Customer_Contacts_contact=@C_Customer_Contacts_contact,");
            strSql.Append("C_Customer_Contacts_isDelete=@C_Customer_Contacts_isDelete,");
            strSql.Append("C_Customer_Contacts_creator=@C_Customer_Contacts_creator,");
            strSql.Append("C_Customer_Contacts_createTime=@C_Customer_Contacts_createTime");
            strSql.Append(" where C_Customer_Contacts_Id=@C_Customer_Contacts_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Contacts_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Contacts_contact", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Contacts_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Customer_Contacts_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Contacts_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_Contacts_Id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Customer_Contacts_customer;
            parameters[1].Value = model.C_Customer_Contacts_contact;
            parameters[2].Value = model.C_Customer_Contacts_isDelete;
            parameters[3].Value = model.C_Customer_Contacts_creator;
            parameters[4].Value = model.C_Customer_Contacts_createTime;
            parameters[5].Value = model.C_Customer_Contacts_Id;

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
        public bool Delete(int C_Customer_Contacts_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Customer_Contacts ");
            strSql.Append(" where C_Customer_Contacts_Id=@C_Customer_Contacts_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Contacts_Id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_Contacts_Id;

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
        /// 根据客户Guid，联系人Guid进行删除
        /// </summary>
        /// <param name="C_Customer_Contacts_customer">客户Guid</param>
        /// <param name="C_Customer_Contacts_contact">联系人Guid</param>
        /// <returns></returns>
        public bool Delete(Guid C_Customer_Contacts_customer, Guid C_Customer_Contacts_contact)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer_Contacts set C_Customer_Contacts_isDelete=1 ");
            strSql.Append("where C_Customer_Contacts_customer=@C_Customer_Contacts_customer ");
            strSql.Append(" and C_Customer_Contacts_contact=@C_Customer_Contacts_contact");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Contacts_customer", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_Customer_Contacts_contact", SqlDbType.UniqueIdentifier),
			};
            parameters[0].Value = C_Customer_Contacts_customer;
            parameters[1].Value = C_Customer_Contacts_contact;

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
        public bool DeleteList(string C_Customer_Contacts_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Customer_Contacts ");
            strSql.Append(" where C_Customer_Contacts_Id in (" + C_Customer_Contacts_Idlist + ")  ");
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
        public CommonService.Model.C_Customer_Contacts GetModel(int C_Customer_Contacts_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Customer_Contacts_Id,C_Customer_Contacts_customer,C_Customer_Contacts_contact,C_Customer_Contacts_isDelete,C_Customer_Contacts_creator,C_Customer_Contacts_createTime from C_Customer_Contacts ");
            strSql.Append(" where C_Customer_Contacts_Id=@C_Customer_Contacts_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Contacts_Id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_Contacts_Id;

            CommonService.Model.C_Customer_Contacts model = new CommonService.Model.C_Customer_Contacts();
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
        public CommonService.Model.C_Customer_Contacts DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Customer_Contacts model = new CommonService.Model.C_Customer_Contacts();
            if (row != null)
            {
                if (row["C_Customer_Contacts_Id"] != null && row["C_Customer_Contacts_Id"].ToString() != "")
                {
                    model.C_Customer_Contacts_Id = int.Parse(row["C_Customer_Contacts_Id"].ToString());
                }
                if (row["C_Customer_Contacts_customer"] != null && row["C_Customer_Contacts_customer"].ToString() != "")
                {
                    model.C_Customer_Contacts_customer = new Guid(row["C_Customer_Contacts_customer"].ToString());
                }
                if (row["C_Customer_Contacts_contact"] != null && row["C_Customer_Contacts_contact"].ToString() != "")
                {
                    model.C_Customer_Contacts_contact = new Guid(row["C_Customer_Contacts_contact"].ToString());
                }
                if (row["C_Customer_Contacts_isDelete"] != null && row["C_Customer_Contacts_isDelete"].ToString() != "")
                {
                    if ((row["C_Customer_Contacts_isDelete"].ToString() == "1") || (row["C_Customer_Contacts_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Customer_Contacts_isDelete = true;
                    }
                    else
                    {
                        model.C_Customer_Contacts_isDelete = false;
                    }
                }
                if (row["C_Customer_Contacts_creator"] != null && row["C_Customer_Contacts_creator"].ToString() != "")
                {
                    model.C_Customer_Contacts_creator = new Guid(row["C_Customer_Contacts_creator"].ToString());
                }
                if (row["C_Customer_Contacts_createTime"] != null && row["C_Customer_Contacts_createTime"].ToString() != "")
                {
                    model.C_Customer_Contacts_createTime = DateTime.Parse(row["C_Customer_Contacts_createTime"].ToString());
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
            strSql.Append("select C_Customer_Contacts_Id,C_Customer_Contacts_customer,C_Customer_Contacts_contact,C_Customer_Contacts_isDelete,C_Customer_Contacts_creator,C_Customer_Contacts_createTime ");
            strSql.Append(" FROM C_Customer_Contacts ");
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
            strSql.Append(" C_Customer_Contacts_Id,C_Customer_Contacts_customer,C_Customer_Contacts_contact,C_Customer_Contacts_isDelete,C_Customer_Contacts_creator,C_Customer_Contacts_createTime ");
            strSql.Append(" FROM C_Customer_Contacts ");
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
            strSql.Append("select count(1) FROM C_Customer_Contacts ");
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
                strSql.Append("order by T.C_Customer_Contacts_Id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Customer_Contacts T ");
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
            parameters[0].Value = "C_Customer_Contacts";
            parameters[1].Value = "C_Customer_Contacts_Id";
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
