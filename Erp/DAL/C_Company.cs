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
    /// 数据访问类:客户公司表
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Company
    {
        public C_Company()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Company_id", "C_Company");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Company_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Company");
            strSql.Append(" where C_Company_id=@C_Company_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Company_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Company_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Company(");
            strSql.Append("C_Company_code,C_Company_name,C_Company_customer,C_Company_property,C_Company_legalPerson,C_Company_establishmentDate,C_Company_registeredCapital,C_Company_licenseCode,C_Company_organizationCode,C_Company_taxCode,C_Company_address,C_Company_isDefault,C_Company_isDelete,C_Company_remark,C_Company_creator,C_Company_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Company_code,@C_Company_name,@C_Company_customer,@C_Company_property,@C_Company_legalPerson,@C_Company_establishmentDate,@C_Company_registeredCapital,@C_Company_licenseCode,@C_Company_organizationCode,@C_Company_taxCode,@C_Company_address,@C_Company_isDefault,@C_Company_isDelete,@C_Company_remark,@C_Company_creator,@C_Company_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Company_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Company_name", SqlDbType.VarChar,200),
					new SqlParameter("@C_Company_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Company_property", SqlDbType.Int,4),
					new SqlParameter("@C_Company_legalPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Company_establishmentDate", SqlDbType.DateTime),
					new SqlParameter("@C_Company_registeredCapital", SqlDbType.Decimal,9),
					new SqlParameter("@C_Company_licenseCode", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Company_organizationCode", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Company_taxCode", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Company_address", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Company_isDefault", SqlDbType.Bit,1),
					new SqlParameter("@C_Company_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Company_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Company_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Company_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Company_code;
            parameters[1].Value = model.C_Company_name;
            parameters[2].Value = model.C_Company_customer;
            parameters[3].Value = model.C_Company_property;
            parameters[4].Value = model.C_Company_legalPerson;
            parameters[5].Value = model.C_Company_establishmentDate;
            parameters[6].Value = model.C_Company_registeredCapital;
            parameters[7].Value = model.C_Company_licenseCode;
            parameters[8].Value = model.C_Company_organizationCode;
            parameters[9].Value = model.C_Company_taxCode;
            parameters[10].Value = model.C_Company_address;
            parameters[11].Value = model.C_Company_isDefault;
            parameters[12].Value = model.C_Company_isDelete;
            parameters[13].Value = model.C_Company_remark;
            parameters[14].Value = model.C_Company_creator;
            parameters[15].Value = model.C_Company_createTime;

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
        public bool Update(CommonService.Model.C_Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Company set ");
            strSql.Append("C_Company_code=@C_Company_code,");
            strSql.Append("C_Company_name=@C_Company_name,");
            strSql.Append("C_Company_customer=@C_Company_customer,");
            strSql.Append("C_Company_property=@C_Company_property,");
            strSql.Append("C_Company_legalPerson=@C_Company_legalPerson,");
            strSql.Append("C_Company_establishmentDate=@C_Company_establishmentDate,");
            strSql.Append("C_Company_registeredCapital=@C_Company_registeredCapital,");
            strSql.Append("C_Company_licenseCode=@C_Company_licenseCode,");
            strSql.Append("C_Company_organizationCode=@C_Company_organizationCode,");
            strSql.Append("C_Company_taxCode=@C_Company_taxCode,");
            strSql.Append("C_Company_address=@C_Company_address,");
            strSql.Append("C_Company_isDefault=@C_Company_isDefault,");
            strSql.Append("C_Company_isDelete=@C_Company_isDelete,");
            strSql.Append("C_Company_remark=@C_Company_remark,");
            strSql.Append("C_Company_creator=@C_Company_creator,");
            strSql.Append("C_Company_createTime=@C_Company_createTime");
            strSql.Append(" where C_Company_id=@C_Company_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Company_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Company_name", SqlDbType.VarChar,200),
					new SqlParameter("@C_Company_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Company_property", SqlDbType.Int,4),
					new SqlParameter("@C_Company_legalPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Company_establishmentDate", SqlDbType.DateTime),
					new SqlParameter("@C_Company_registeredCapital", SqlDbType.Decimal,9),
					new SqlParameter("@C_Company_licenseCode", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Company_organizationCode", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Company_taxCode", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Company_address", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Company_isDefault", SqlDbType.Bit,1),
					new SqlParameter("@C_Company_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Company_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Company_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Company_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Company_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Company_code;
            parameters[1].Value = model.C_Company_name;
            parameters[2].Value = model.C_Company_customer;
            parameters[3].Value = model.C_Company_property;
            parameters[4].Value = model.C_Company_legalPerson;
            parameters[5].Value = model.C_Company_establishmentDate;
            parameters[6].Value = model.C_Company_registeredCapital;
            parameters[7].Value = model.C_Company_licenseCode;
            parameters[8].Value = model.C_Company_organizationCode;
            parameters[9].Value = model.C_Company_taxCode;
            parameters[10].Value = model.C_Company_address;
            parameters[11].Value = model.C_Company_isDefault;
            parameters[12].Value = model.C_Company_isDelete;
            parameters[13].Value = model.C_Company_remark;
            parameters[14].Value = model.C_Company_creator;
            parameters[15].Value = model.C_Company_createTime;
            parameters[16].Value = model.C_Company_id;

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
        public bool Delete(Guid C_Company_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Company set C_Company_isDelete=1");
            strSql.Append(" where C_Company_code=@C_Company_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Company_code", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = C_Company_code;

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
        public bool Delete(int C_Company_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Company ");
            strSql.Append(" where C_Company_id=@C_Company_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Company_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Company_id;

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
        public bool DeleteList(string C_Company_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Company ");
            strSql.Append(" where C_Company_id in (" + C_Company_idlist + ")  ");
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
        public CommonService.Model.C_Company GetModel(int C_Company_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Company_id,C_Company_code,C_Company_name,C_Company_customer,C_Company_property,C_Company_legalPerson,C_Company_establishmentDate,C_Company_registeredCapital,C_Company_licenseCode,C_Company_organizationCode,C_Company_taxCode,C_Company_address,C_Company_isDefault,C_Company_isDelete,C_Company_remark,C_Company_creator,C_Company_createTime from C_Company ");
            strSql.Append(" where C_Company_id=@C_Company_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Company_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Company_id;

            CommonService.Model.C_Company model = new CommonService.Model.C_Company();
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
        public CommonService.Model.C_Company GetModel(Guid C_Company_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Company_id,C_Company_code,C_Company_name,C_Company_customer,C_Company_property,C_Company_legalPerson,C_Company_establishmentDate,C_Company_registeredCapital,C_Company_licenseCode,C_Company_organizationCode,C_Company_taxCode,C_Company_address,C_Company_isDefault,C_Company_isDelete,C_Company_remark,C_Company_creator,C_Company_createTime,'' AS C_Company_property_name from C_Company ");
            strSql.Append(" where C_Company_code=@C_Company_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Company_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Company_code;

            CommonService.Model.C_Company model = new CommonService.Model.C_Company();
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
        public CommonService.Model.C_Company DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Company model = new CommonService.Model.C_Company();
            if (row != null)
            {
                if (row["C_Company_id"] != null && row["C_Company_id"].ToString() != "")
                {
                    model.C_Company_id = int.Parse(row["C_Company_id"].ToString());
                }
                if (row["C_Company_code"] != null && row["C_Company_code"].ToString() != "")
                {
                    model.C_Company_code = new Guid(row["C_Company_code"].ToString());
                }
                if (row["C_Company_name"] != null)
                {
                    model.C_Company_name = row["C_Company_name"].ToString();
                }
                if (row["C_Company_customer"] != null && row["C_Company_customer"].ToString() != "")
                {
                    model.C_Company_customer = new Guid(row["C_Company_customer"].ToString());
                }
                if (row["C_Company_property"] != null && row["C_Company_property"].ToString() != "")
                {
                    model.C_Company_property = int.Parse(row["C_Company_property"].ToString());
                }
                if (row["C_Company_property_name"] != null && row["C_Company_property_name"].ToString() != "")
                {
                    model.C_Company_property_name = row["C_Company_property_name"].ToString();
                }
                if (row["C_Company_legalPerson"] != null)
                {
                    model.C_Company_legalPerson = row["C_Company_legalPerson"].ToString();
                }
                if (row["C_Company_establishmentDate"] != null && row["C_Company_establishmentDate"].ToString() != "")
                {
                    model.C_Company_establishmentDate = DateTime.Parse(row["C_Company_establishmentDate"].ToString());
                }
                if (row["C_Company_registeredCapital"] != null && row["C_Company_registeredCapital"].ToString() != "")
                {
                    model.C_Company_registeredCapital = decimal.Parse(row["C_Company_registeredCapital"].ToString());
                }
                if (row["C_Company_licenseCode"] != null)
                {
                    model.C_Company_licenseCode = row["C_Company_licenseCode"].ToString();
                }
                if (row["C_Company_organizationCode"] != null)
                {
                    model.C_Company_organizationCode = row["C_Company_organizationCode"].ToString();
                }
                if (row["C_Company_taxCode"] != null)
                {
                    model.C_Company_taxCode = row["C_Company_taxCode"].ToString();
                }
                if (row["C_Company_address"] != null)
                {
                    model.C_Company_address = row["C_Company_address"].ToString();
                }
                if (row["C_Company_isDefault"] != null && row["C_Company_isDefault"].ToString() != "")
                {
                    if ((row["C_Company_isDefault"].ToString() == "1") || (row["C_Company_isDefault"].ToString().ToLower() == "true"))
                    {
                        model.C_Company_isDefault = true;
                    }
                    else
                    {
                        model.C_Company_isDefault = false;
                    }
                }
                if (row["C_Company_isDelete"] != null && row["C_Company_isDelete"].ToString() != "")
                {
                    if ((row["C_Company_isDelete"].ToString() == "1") || (row["C_Company_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Company_isDelete = true;
                    }
                    else
                    {
                        model.C_Company_isDelete = false;
                    }
                }
                if (row["C_Company_remark"] != null)
                {
                    model.C_Company_remark = row["C_Company_remark"].ToString();
                }
                if (row["C_Company_creator"] != null && row["C_Company_creator"].ToString() != "")
                {
                    model.C_Company_creator = new Guid(row["C_Company_creator"].ToString());
                }
                if (row["C_Company_createTime"] != null && row["C_Company_createTime"].ToString() != "")
                {
                    model.C_Company_createTime = DateTime.Parse(row["C_Company_createTime"].ToString());
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
            strSql.Append("select C_Company_id,C_Company_code,C_Company_name,C_Company_customer,C_Company_property,C_Company_legalPerson,C_Company_establishmentDate,C_Company_registeredCapital,C_Company_licenseCode,C_Company_organizationCode,C_Company_taxCode,C_Company_address,C_Company_isDefault,C_Company_isDelete,C_Company_remark,C_Company_creator,C_Company_createTime ");
            strSql.Append(" FROM C_Company ");
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
            strSql.Append(" C_Company_id,C_Company_code,C_Company_name,C_Company_customer,C_Company_property,C_Company_legalPerson,C_Company_establishmentDate,C_Company_registeredCapital,C_Company_licenseCode,C_Company_organizationCode,C_Company_taxCode,C_Company_address,C_Company_isDefault,C_Company_isDelete,C_Company_remark,C_Company_creator,C_Company_createTime ");
            strSql.Append(" FROM C_Company ");
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
        public int GetRecordCount(Model.C_Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Company With(nolock) ");
            strSql.Append(" where 1=1 and C_Company_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Company_name != null)
                {
                    strSql.Append("and C_Company_name=@C_Company_name ");
                }
                if (model.C_Company_property != null)
                {
                    strSql.Append("and C_Company_property=@C_Company_property ");
                }
                if (model.C_Company_customer != null)
                {
                    strSql.Append("and C_Company_customer=@C_Company_customer ");
                }
            }
            SqlParameter[] parameters = {					
					new SqlParameter("@C_Company_name", SqlDbType.VarChar,200),
					new SqlParameter("@C_Company_property", SqlDbType.Int,4),
                    new SqlParameter("@C_Company_customer", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = model.C_Company_name;
            parameters[1].Value = model.C_Company_property;
            parameters[2].Value = model.C_Company_customer;
            
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(CommonService.Model.C_Company model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Company_id desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name AS C_Company_property_name from C_Company AS T With(nolock) ");
            strSql.Append("left join C_Parameters AS P With(nolock) on T.C_Company_property=P.C_Parameters_id ");
            strSql.Append(" where 1=1 and T.C_Company_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Company_name != null)
                {
                    strSql.Append("and C_Company_name=@C_Company_name ");
                }
                if (model.C_Company_property != null)
                {
                    strSql.Append("and C_Company_property=@C_Company_property ");
                }
                if (model.C_Company_customer != null)
                {
                    strSql.Append("and C_Company_customer=@C_Company_customer ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = { new SqlParameter("@C_Company_name", SqlDbType.VarChar,200),
					new SqlParameter("@C_Company_property", SqlDbType.Int,4),
                    new SqlParameter("@C_Company_customer", SqlDbType.UniqueIdentifier) };
            parameters[0].Value = model.C_Company_name;
            parameters[1].Value = model.C_Company_property;
            parameters[2].Value = model.C_Company_customer;
      
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
            parameters[0].Value = "C_Company";
            parameters[1].Value = "C_Company_id";
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
