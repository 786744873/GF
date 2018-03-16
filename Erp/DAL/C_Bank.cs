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
    /// 数据访问类:客户银行表
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Bank
    {
        public C_Bank()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Bank_id", "C_Bank");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Bank_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Bank");
            strSql.Append(" where C_Bank_id=@C_Bank_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Bank_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Bank_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Bank(");
            strSql.Append("C_Bank_code,C_Bank_customer,C_Bank_openBank,C_Bank_account,C_Bank_accountNo,C_Bank_isDefault,C_Bank_isDelete,C_Bank_remark,C_Bank_creator,C_Bank_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Bank_code,@C_Bank_customer,@C_Bank_openBank,@C_Bank_account,@C_Bank_accountNo,@C_Bank_isDefault,@C_Bank_isDelete,@C_Bank_remark,@C_Bank_creator,@C_Bank_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Bank_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Bank_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Bank_openBank", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Bank_account", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Bank_accountNo", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Bank_isDefault", SqlDbType.Bit,1),
					new SqlParameter("@C_Bank_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Bank_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Bank_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Bank_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Bank_code;
            parameters[1].Value = model.C_Bank_customer;
            parameters[2].Value = model.C_Bank_openBank;
            parameters[3].Value = model.C_Bank_account;
            parameters[4].Value = model.C_Bank_accountNo;
            parameters[5].Value = model.C_Bank_isDefault;
            parameters[6].Value = model.C_Bank_isDelete;
            parameters[7].Value = model.C_Bank_remark;
            parameters[8].Value = model.C_Bank_creator;
            parameters[9].Value = model.C_Bank_createTime;

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
        public bool Update(CommonService.Model.C_Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Bank set ");
            strSql.Append("C_Bank_code=@C_Bank_code,");
            strSql.Append("C_Bank_customer=@C_Bank_customer,");
            strSql.Append("C_Bank_openBank=@C_Bank_openBank,");
            strSql.Append("C_Bank_account=@C_Bank_account,");
            strSql.Append("C_Bank_accountNo=@C_Bank_accountNo,");
            strSql.Append("C_Bank_isDefault=@C_Bank_isDefault,");
            strSql.Append("C_Bank_isDelete=@C_Bank_isDelete,");
            strSql.Append("C_Bank_remark=@C_Bank_remark,");
            strSql.Append("C_Bank_creator=@C_Bank_creator,");
            strSql.Append("C_Bank_createTime=@C_Bank_createTime");
            strSql.Append(" where C_Bank_id=@C_Bank_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Bank_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Bank_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Bank_openBank", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Bank_account", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Bank_accountNo", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Bank_isDefault", SqlDbType.Bit,1),
					new SqlParameter("@C_Bank_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Bank_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Bank_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Bank_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Bank_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Bank_code;
            parameters[1].Value = model.C_Bank_customer;
            parameters[2].Value = model.C_Bank_openBank;
            parameters[3].Value = model.C_Bank_account;
            parameters[4].Value = model.C_Bank_accountNo;
            parameters[5].Value = model.C_Bank_isDefault;
            parameters[6].Value = model.C_Bank_isDelete;
            parameters[7].Value = model.C_Bank_remark;
            parameters[8].Value = model.C_Bank_creator;
            parameters[9].Value = model.C_Bank_createTime;
            parameters[10].Value = model.C_Bank_id;

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
        public bool Delete(Guid C_Bank_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Bank set C_Bank_isDelete=1");
            strSql.Append(" where C_Bank_code=@C_Bank_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Bank_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Bank_code;

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
        public bool DeleteList(string C_Bank_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Bank ");
            strSql.Append(" where C_Bank_id in (" + C_Bank_idlist + ")  ");
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
        public CommonService.Model.C_Bank GetModel(int C_Bank_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Bank_id,C_Bank_code,C_Bank_customer,C_Bank_openBank,C_Bank_account,C_Bank_accountNo,C_Bank_isDefault,C_Bank_isDelete,C_Bank_remark,C_Bank_creator,C_Bank_createTime from C_Bank ");
            strSql.Append(" where C_Bank_id=@C_Bank_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Bank_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Bank_id;

            CommonService.Model.C_Bank model = new CommonService.Model.C_Bank();
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
        public CommonService.Model.C_Bank GetModel(Guid C_Bank_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Bank_id,C_Bank_code,C_Bank_customer,C_Bank_openBank,C_Bank_account,C_Bank_accountNo,C_Bank_isDefault,C_Bank_isDelete,C_Bank_remark,C_Bank_creator,C_Bank_createTime from C_Bank ");
            strSql.Append(" where C_Bank_code=@C_Bank_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Bank_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Bank_code;

            CommonService.Model.C_Bank model = new CommonService.Model.C_Bank();
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
        public CommonService.Model.C_Bank DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Bank model = new CommonService.Model.C_Bank();
            if (row != null)
            {
                if (row["C_Bank_id"] != null && row["C_Bank_id"].ToString() != "")
                {
                    model.C_Bank_id = int.Parse(row["C_Bank_id"].ToString());
                }
                if (row["C_Bank_code"] != null && row["C_Bank_code"].ToString() != "")
                {
                    model.C_Bank_code = new Guid(row["C_Bank_code"].ToString());
                }
                if (row["C_Bank_customer"] != null && row["C_Bank_customer"].ToString() != "")
                {
                    model.C_Bank_customer = new Guid(row["C_Bank_customer"].ToString());
                }
                if (row["C_Bank_openBank"] != null)
                {
                    model.C_Bank_openBank = row["C_Bank_openBank"].ToString();
                }
                if (row["C_Bank_account"] != null)
                {
                    model.C_Bank_account = row["C_Bank_account"].ToString();
                }
                if (row["C_Bank_accountNo"] != null)
                {
                    model.C_Bank_accountNo = row["C_Bank_accountNo"].ToString();
                }
                if (row["C_Bank_isDefault"] != null && row["C_Bank_isDefault"].ToString() != "")
                {
                    if ((row["C_Bank_isDefault"].ToString() == "1") || (row["C_Bank_isDefault"].ToString().ToLower() == "true"))
                    {
                        model.C_Bank_isDefault = true;
                    }
                    else
                    {
                        model.C_Bank_isDefault = false;
                    }
                }
                if (row["C_Bank_isDelete"] != null && row["C_Bank_isDelete"].ToString() != "")
                {
                    if ((row["C_Bank_isDelete"].ToString() == "1") || (row["C_Bank_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Bank_isDelete = true;
                    }
                    else
                    {
                        model.C_Bank_isDelete = false;
                    }
                }
                if (row["C_Bank_remark"] != null)
                {
                    model.C_Bank_remark = row["C_Bank_remark"].ToString();
                }
                if (row["C_Bank_creator"] != null && row["C_Bank_creator"].ToString() != "")
                {
                    model.C_Bank_creator = new Guid(row["C_Bank_creator"].ToString());
                }
                if (row["C_Bank_createTime"] != null && row["C_Bank_createTime"].ToString() != "")
                {
                    model.C_Bank_createTime = DateTime.Parse(row["C_Bank_createTime"].ToString());
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
            strSql.Append("select C_Bank_id,C_Bank_code,C_Bank_customer,C_Bank_openBank,C_Bank_account,C_Bank_accountNo,C_Bank_isDefault,C_Bank_isDelete,C_Bank_remark,C_Bank_creator,C_Bank_createTime ");
            strSql.Append(" FROM C_Bank ");
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
            strSql.Append(" C_Bank_id,C_Bank_code,C_Bank_customer,C_Bank_openBank,C_Bank_account,C_Bank_accountNo,C_Bank_isDefault,C_Bank_isDelete,C_Bank_remark,C_Bank_creator,C_Bank_createTime ");
            strSql.Append(" FROM C_Bank ");
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
        public int GetRecordCount(CommonService.Model.C_Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Bank With(nolock) ");
            strSql.Append(" where 1=1 and C_Bank_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Bank_customer != null)
                {
                    strSql.Append("and C_Bank_customer=@C_Bank_customer ");
                }
                if (model.C_Bank_openBank != null)
                {
                    strSql.Append(" and C_Bank_openBank=@C_Bank_openBank ");
                }
                if (model.C_Bank_account != null)
                {
                    strSql.Append("and C_Bank_account=@C_Bank_account ");
                }
                if (model.C_Bank_accountNo != null)
                {
                    strSql.Append(" and C_Bank_accountNo=@C_Bank_accountNo ");
                }
               
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Bank_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Bank_openBank", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Bank_account", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Bank_accountNo", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.C_Bank_customer;
            parameters[1].Value = model.C_Bank_openBank;
            parameters[2].Value = model.C_Bank_account;
            parameters[3].Value = model.C_Bank_accountNo;
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
        public DataSet GetListByPage(CommonService.Model.C_Bank model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Organization_id desc");
            }
            strSql.Append(")AS Row, T.* from C_Bank AS T With(nolock) ");

            strSql.Append(" where 1=1 and T.C_Bank_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Bank_customer != null)
                {
                    strSql.Append("and C_Bank_customer=@C_Bank_customer ");
                }
                if (model.C_Bank_openBank != null)
                {
                    strSql.Append(" and C_Bank_openBank=@C_Bank_openBank ");
                }
                if (model.C_Bank_account != null)
                {
                    strSql.Append("and C_Bank_account=@C_Bank_account ");
                }
                if (model.C_Bank_accountNo != null)
                {
                    strSql.Append(" and C_Bank_accountNo=@C_Bank_accountNo ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Bank_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Bank_openBank", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Bank_account", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Bank_accountNo", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.C_Bank_customer;
            parameters[1].Value = model.C_Bank_openBank;
            parameters[2].Value = model.C_Bank_account;
            parameters[3].Value = model.C_Bank_accountNo;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            parameters[0].Value = "C_Bank";
            parameters[1].Value = "C_Bank_id";
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
