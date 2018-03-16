using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonService.Common;

namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:C_Principal
    /// </summary>
    public partial class C_Principal
    {
        public C_Principal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Principal_id", "C_Principal");
        }

        /// <summary>
        /// 根据实体是否存在该记录
        /// </summary>
        public bool Exists(Model.C_Principal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Principal");
            strSql.Append(" where C_Principal_name=@C_Principal_name");
            if (model.C_Principal_id>0)
            {
                strSql.Append(" and C_Principal_code <> @C_Principal_code");
            }
            if (model.C_Principal_businessType==Convert.ToInt32(CustomerBusiness.客户))
            {
                strSql.Append(" and C_Principal_businessType <> " + Convert.ToInt32(CustomerBusiness.委托人));
            }
            else if (model.C_Principal_businessType==Convert.ToInt32(CustomerBusiness.委托人))
            {
                strSql.Append(" and C_Principal_businessType <> " + Convert.ToInt32(CustomerBusiness.客户));
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Principal_name", SqlDbType.NVarChar,200),
                    new SqlParameter("@C_Principal_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_Principal_name;
            parameters[1].Value =model.C_Principal_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据委托人姓名查询是否存在记录
        /// </summary>
        /// <param name="C_Principal_name"></param>
        /// <param name="C_Principal_businessType"></param>
        /// <returns></returns>
        public bool ExistsByPrincipalName(string C_Principal_name,int C_Principal_businessType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Principal");
            strSql.Append(" where C_Principal_name=@C_Principal_name");
            strSql.Append(" and C_Principal_businessType=@C_Principal_businessType");
            SqlParameter[] parameters = { 
                                        new SqlParameter("@C_Principal_name",SqlDbType.NVarChar,200),
                                        new SqlParameter("@C_Principal_businessType",SqlDbType.Int,4)
                                        };
            parameters[0].Value = C_Principal_name;
            parameters[1].Value = C_Principal_businessType;
            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 根据委托人姓名和GUID查询是否存在
        /// </summary>
        /// <param name="C_Principal_name"></param>
        /// <param name="C_Principal_code"></param>
        /// <param name="C_Principal_businessType"></param>
        /// <returns></returns>
        public bool ExistsByPrincipalNameAndCode(string C_Principal_name,Guid C_Principal_code,int C_Principal_businessType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Principal");
            strSql.Append(" where C_Principal_name=@C_Principal_name");
            strSql.Append(" and C_Principal_code <> @C_Principal_code");
            if (C_Principal_businessType == Convert.ToInt32(CustomerBusiness.客户))
            {
                strSql.Append(" and C_Principal_businessType <> " + Convert.ToInt32(CustomerBusiness.委托人));
            }
            else if (C_Principal_businessType == Convert.ToInt32(CustomerBusiness.委托人))
            {
                strSql.Append(" and C_Principal_businessType <> " + Convert.ToInt32(CustomerBusiness.客户));
            }
            SqlParameter[] parameters = { 
                                        new SqlParameter("@C_Principal_name",SqlDbType.NVarChar,200),
                                        new SqlParameter("@C_Principal_code",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = C_Principal_name;
            parameters[1].Value = C_Principal_code;
            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.C_Principal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Principal(");
            strSql.Append("C_Principal_code,C_Principal_number,C_Principal_type,C_Principal_level,C_Principal_name,C_Principal_shortName,C_Principal_region,C_Principal_province,C_Principal_city,C_Principal_industryCode,C_Principal_yearTurnover,C_Principal_isSignedState,C_Principal_companySize,C_Principal_source,C_Principal_signedState,C_Principal_tel,C_Principal_phone,C_Principal_fax,C_Principal_email,C_Principal_website,C_Principal_contacter,C_Principal_mainContactPhone,C_Principal_value,C_Principal_address,C_Principal_reguser,C_Principal_regdate,C_Principal_loyalty,C_Principal_lastContactDate,C_Principal_businessType,C_Principal_consultant,C_Principal_responsibleDept,C_Principal_isDelete,C_Principal_creator,C_Principal_createTime,C_Principal_remark)");
            strSql.Append(" values (");
            strSql.Append("@C_Principal_code,@C_Principal_number,@C_Principal_type,@C_Principal_level,@C_Principal_name,@C_Principal_shortName,@C_Principal_region,@C_Principal_province,@C_Principal_city,@C_Principal_industryCode,@C_Principal_yearTurnover,@C_Principal_isSignedState,@C_Principal_companySize,@C_Principal_source,@C_Principal_signedState,@C_Principal_tel,@C_Principal_phone,@C_Principal_fax,@C_Principal_email,@C_Principal_website,@C_Principal_contacter,@C_Principal_mainContactPhone,@C_Principal_value,@C_Principal_address,@C_Principal_reguser,@C_Principal_regdate,@C_Principal_loyalty,@C_Principal_lastContactDate,@C_Principal_businessType,@C_Principal_consultant,@C_Principal_responsibleDept,@C_Principal_isDelete,@C_Principal_creator,@C_Principal_createTime,@C_Principal_remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Principal_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_number", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Principal_type", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_level", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_name", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Principal_shortName", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Principal_region", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_province", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_city", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_industryCode", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_yearTurnover", SqlDbType.Decimal,9),
					new SqlParameter("@C_Principal_isSignedState", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_companySize", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Principal_source", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_signedState", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_tel", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Principal_phone", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Principal_fax", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Principal_email", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Principal_website", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Principal_contacter", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Principal_mainContactPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Principal_value", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Principal_address", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Principal_reguser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_regdate", SqlDbType.DateTime),
					new SqlParameter("@C_Principal_loyalty", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_lastContactDate", SqlDbType.DateTime),
					new SqlParameter("@C_Principal_businessType", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_consultant", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_responsibleDept", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Principal_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_createTime", SqlDbType.DateTime),
                                        new SqlParameter("C_Principal_remark",SqlDbType.NVarChar,500)
                                        };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.C_Principal_number;
            parameters[2].Value = model.C_Principal_type;
            parameters[3].Value = model.C_Principal_level;
            parameters[4].Value = model.C_Principal_name;
            parameters[5].Value = model.C_Principal_shortName;
            parameters[6].Value = model.C_Principal_region;
            parameters[7].Value = model.C_Principal_province;
            parameters[8].Value = model.C_Principal_city;
            parameters[9].Value = model.C_Principal_industryCode;
            parameters[10].Value = model.C_Principal_yearTurnover;
            parameters[11].Value = model.C_Principal_isSignedState;
            parameters[12].Value = model.C_Principal_companySize;
            parameters[13].Value = model.C_Principal_source;
            parameters[14].Value = model.C_Principal_signedState;
            parameters[15].Value = model.C_Principal_tel;
            parameters[16].Value = model.C_Principal_phone;
            parameters[17].Value = model.C_Principal_fax;
            parameters[18].Value = model.C_Principal_email;
            parameters[19].Value = model.C_Principal_website;
            parameters[20].Value = model.C_Principal_contacter;
            parameters[21].Value = model.C_Principal_mainContactPhone;
            parameters[22].Value = model.C_Principal_value;
            parameters[23].Value = model.C_Principal_address;
            parameters[24].Value = model.C_Principal_reguser;
            parameters[25].Value = model.C_Principal_regdate;
            parameters[26].Value = model.C_Principal_loyalty;
            parameters[27].Value = model.C_Principal_lastContactDate;
            parameters[28].Value = model.C_Principal_businessType;
            parameters[29].Value = model.C_Principal_consultant;
            parameters[30].Value = model.C_Principal_responsibleDept;
            parameters[31].Value = model.C_Principal_isDelete;
            parameters[32].Value = model.C_Principal_creator;
            parameters[33].Value = model.C_Principal_createTime;
            parameters[34].Value = model.C_principal_remark;

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
        public bool Update(Model.C_Principal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Principal set ");
            strSql.Append("C_Principal_number=@C_Principal_number,");
            strSql.Append("C_Principal_type=@C_Principal_type,");
            strSql.Append("C_Principal_level=@C_Principal_level,");
            strSql.Append("C_Principal_name=@C_Principal_name,");
            strSql.Append("C_Principal_shortName=@C_Principal_shortName,");
            strSql.Append("C_Principal_province=@C_Principal_province,");
            strSql.Append("C_Principal_city=@C_Principal_city,");
            strSql.Append("C_Principal_industryCode=@C_Principal_industryCode,");
            strSql.Append("C_Principal_yearTurnover=@C_Principal_yearTurnover,");
            strSql.Append("C_Principal_isSignedState=@C_Principal_isSignedState,");
            strSql.Append("C_Principal_companySize=@C_Principal_companySize,");
            strSql.Append("C_Principal_source=@C_Principal_source,");
            strSql.Append("C_Principal_signedState=@C_Principal_signedState,");
            strSql.Append("C_Principal_tel=@C_Principal_tel,");
            strSql.Append("C_Principal_phone=@C_Principal_phone,");
            strSql.Append("C_Principal_fax=@C_Principal_fax,");
            strSql.Append("C_Principal_email=@C_Principal_email,");
            strSql.Append("C_Principal_website=@C_Principal_website,");
            strSql.Append("C_Principal_contacter=@C_Principal_contacter,");
            strSql.Append("C_Principal_mainContactPhone=@C_Principal_mainContactPhone,");
            strSql.Append("C_Principal_value=@C_Principal_value,");
            strSql.Append("C_Principal_address=@C_Principal_address,");
            strSql.Append("C_Principal_reguser=@C_Principal_reguser,");
            strSql.Append("C_Principal_regdate=@C_Principal_regdate,");
            strSql.Append("C_Principal_loyalty=@C_Principal_loyalty,");
            strSql.Append("C_Principal_lastContactDate=@C_Principal_lastContactDate,");
            strSql.Append("C_Principal_businessType=@C_Principal_businessType,");
            strSql.Append("C_Principal_consultant=@C_Principal_consultant,");
            strSql.Append("C_Principal_responsibleDept=@C_Principal_responsibleDept,");
            strSql.Append("C_Principal_isDelete=@C_Principal_isDelete,");
            strSql.Append("C_Principal_creator=@C_Principal_creator,");
            strSql.Append("C_Principal_createTime=@C_Principal_createTime,");
            strSql.Append("C_Principal_remark=@C_Principal_remark");
            strSql.Append(" where C_Principal_code=@C_Principal_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Principal_number", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Principal_type", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_level", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_name", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Principal_shortName", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Principal_province", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_city", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_industryCode", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_yearTurnover", SqlDbType.Decimal,9),
					new SqlParameter("@C_Principal_isSignedState", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_companySize", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Principal_source", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_signedState", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_tel", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Principal_phone", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Principal_fax", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Principal_email", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Principal_website", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Principal_contacter", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Principal_mainContactPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Principal_value", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Principal_address", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Principal_reguser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_regdate", SqlDbType.DateTime),
					new SqlParameter("@C_Principal_loyalty", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_lastContactDate", SqlDbType.DateTime),
					new SqlParameter("@C_Principal_businessType", SqlDbType.Int,4),
					new SqlParameter("@C_Principal_consultant", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_responsibleDept", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Principal_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Principal_createTime", SqlDbType.DateTime),
				    new SqlParameter("@C_Principal_remark",SqlDbType.NVarChar,500),
                    new SqlParameter("@C_Principal_code", SqlDbType.UniqueIdentifier,16)};
            
            parameters[0].Value = model.C_Principal_number;
            parameters[1].Value = model.C_Principal_type;
            parameters[2].Value = model.C_Principal_level;
            parameters[3].Value = model.C_Principal_name;
            parameters[4].Value = model.C_Principal_shortName;
            parameters[5].Value = model.C_Principal_province;
            parameters[6].Value = model.C_Principal_city;
            parameters[7].Value = model.C_Principal_industryCode;
            parameters[8].Value = model.C_Principal_yearTurnover;
            parameters[9].Value = model.C_Principal_isSignedState;
            parameters[10].Value = model.C_Principal_companySize;
            parameters[11].Value = model.C_Principal_source;
            parameters[12].Value = model.C_Principal_signedState;
            parameters[13].Value = model.C_Principal_tel;
            parameters[14].Value = model.C_Principal_phone;
            parameters[15].Value = model.C_Principal_fax;
            parameters[16].Value = model.C_Principal_email;
            parameters[17].Value = model.C_Principal_website;
            parameters[18].Value = model.C_Principal_contacter;
            parameters[19].Value = model.C_Principal_mainContactPhone;
            parameters[20].Value = model.C_Principal_value;
            parameters[21].Value = model.C_Principal_address;
            parameters[22].Value = model.C_Principal_reguser;
            parameters[23].Value = model.C_Principal_regdate;
            parameters[24].Value = model.C_Principal_loyalty;
            parameters[25].Value = model.C_Principal_lastContactDate;
            parameters[26].Value = model.C_Principal_businessType;
            parameters[27].Value = model.C_Principal_consultant;
            parameters[28].Value = model.C_Principal_responsibleDept;
            parameters[29].Value = model.C_Principal_isDelete;
            parameters[30].Value = model.C_Principal_creator;
            parameters[31].Value = model.C_Principal_createTime;
            parameters[32].Value = model.C_principal_remark;
            parameters[33].Value = model.C_Principal_code;

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
        public bool Delete(Guid C_Principal_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Principal set C_Principal_isDelete=1");
            strSql.Append(" where C_Principal_code=@C_Principal_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Principal_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Principal_code;

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
        public bool DeleteList(string C_Principal_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Principal ");
            strSql.Append(" where C_Principal_id in (" + C_Principal_idlist + ")  ");
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
        public CommonService.Model.C_Principal GetModel(int C_Principal_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C.*,O.C_Organization_name As C_Principal_responsibleDept_Name ");
            strSql.Append("from C_Principal with(nolock) As C ");
            strSql.Append("left join C_Organization As O with(nolock) on C.C_Principal_responsibleDept=O.C_Organization_code ");
            strSql.Append(" where C.C_Principal_id=@C_Principal_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Principal_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Principal_id;

            CommonService.Model.C_Principal model = new CommonService.Model.C_Principal();
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
        public Model.C_Principal GetModel(Guid C_Principal_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C.C_Principal_id,C.C_Principal_code,C.C_Principal_number,C.C_Principal_type,C.C_Principal_level,C.C_Principal_name,C.C_Principal_shortName,C.C_Principal_province,C.C_Principal_city,C.C_Principal_industryCode,C.C_Principal_yearTurnover,C.C_Principal_isSignedState,C.C_Principal_companySize,C.C_Principal_source,C.C_Principal_signedState,C.C_Principal_tel,C.C_Principal_phone,C.C_Principal_fax,C.C_Principal_email,C.C_Principal_website,C.C_Principal_contacter,C.C_Principal_mainContactPhone,C.C_Principal_value,C.C_Principal_address,C.C_Principal_reguser,C.C_Principal_regdate,C.C_Principal_loyalty,C.C_Principal_lastContactDate,C.C_Principal_businessType,C.C_Principal_consultant,C.C_Principal_responsibleDept,C.C_Principal_isDelete,C.C_Principal_creator,C.C_Principal_createTime,C.C_Principal_remark, ");
            strSql.Append("U.C_Userinfo_name as 'C_principal_consultant_name',O.C_Organization_name as 'C_principal_responsibledept_name',p.C_Parameters_name as 'C_Principal_industrycode_name' ");
            strSql.Append("from C_Principal as C left join C_Userinfo as U on C.C_Principal_consultant=U.C_Userinfo_code ");
            strSql.Append("left join C_Organization As O with(nolock) on C.C_Principal_responsibleDept=O.C_Organization_code ");
            strSql.Append("left join C_Parameters as p on p.C_Parameters_id=C.C_Principal_industryCode");
            strSql.Append(" where C_Principal_code=@C_Principal_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Principal_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Principal_code;

            Model.C_Principal model = new Model.C_Principal();
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
        public Model.C_Principal DataRowToModel(DataRow row)
        {
            Model.C_Principal model = new Model.C_Principal();
            if (row != null)
            {
                if (row["C_Principal_id"] != null && row["C_Principal_id"].ToString() != "")
                {
                    model.C_Principal_id = int.Parse(row["C_Principal_id"].ToString());
                }
                if (row["C_Principal_code"] != null && row["C_Principal_code"].ToString() != "")
                {
                    model.C_Principal_code = new Guid(row["C_Principal_code"].ToString());
                }
                if (row["C_Principal_number"] != null)
                {
                    model.C_Principal_number = row["C_Principal_number"].ToString();
                }
                if (row["C_Principal_type"] != null && row["C_Principal_type"].ToString() != "")
                {
                    model.C_Principal_type = int.Parse(row["C_Principal_type"].ToString());
                }
                if (row["C_Principal_level"] != null && row["C_Principal_level"].ToString() != "")
                {
                    model.C_Principal_level = int.Parse(row["C_Principal_level"].ToString());
                }
                if (row["C_Principal_name"] != null)
                {
                    model.C_Principal_name = row["C_Principal_name"].ToString();
                }
                if (row["C_Principal_shortName"] != null)
                {
                    model.C_Principal_shortName = row["C_Principal_shortName"].ToString();
                }
                
                if (row["C_Principal_province"] != null && row["C_Principal_province"].ToString() != "")
                {
                    model.C_Principal_province = int.Parse(row["C_Principal_province"].ToString());
                }
                if (row["C_Principal_city"] != null && row["C_Principal_city"].ToString() != "")
                {
                    model.C_Principal_city = int.Parse(row["C_Principal_city"].ToString());
                }
                if (row["C_Principal_industryCode"] != null && row["C_Principal_industryCode"].ToString() != "")
                {
                    model.C_Principal_industryCode = int.Parse(row["C_Principal_industryCode"].ToString());
                }
                if (row["C_Principal_yearTurnover"] != null && row["C_Principal_yearTurnover"].ToString() != "")
                {
                    model.C_Principal_yearTurnover = decimal.Parse(row["C_Principal_yearTurnover"].ToString());
                }
                if (row["C_Principal_isSignedState"] != null && row["C_Principal_isSignedState"].ToString() != "")
                {
                    model.C_Principal_isSignedState = int.Parse(row["C_Principal_isSignedState"].ToString());
                }
                if (row["C_Principal_companySize"] != null)
                {
                    model.C_Principal_companySize = row["C_Principal_companySize"].ToString();
                }
                if (row["C_Principal_source"] != null && row["C_Principal_source"].ToString() != "")
                {
                    model.C_Principal_source = int.Parse(row["C_Principal_source"].ToString());
                }
                if (row["C_Principal_signedState"] != null && row["C_Principal_signedState"].ToString() != "")
                {
                    model.C_Principal_signedState = int.Parse(row["C_Principal_signedState"].ToString());
                }
                if (row["C_Principal_tel"] != null)
                {
                    model.C_Principal_tel = row["C_Principal_tel"].ToString();
                }
                if (row["C_Principal_phone"] != null)
                {
                    model.C_Principal_phone = row["C_Principal_phone"].ToString();
                }
                if (row["C_Principal_fax"] != null)
                {
                    model.C_Principal_fax = row["C_Principal_fax"].ToString();
                }
                if (row["C_Principal_email"] != null)
                {
                    model.C_Principal_email = row["C_Principal_email"].ToString();
                }
                if (row["C_Principal_website"] != null)
                {
                    model.C_Principal_website = row["C_Principal_website"].ToString();
                }
                if (row["C_Principal_contacter"] != null)
                {
                    model.C_Principal_contacter = row["C_Principal_contacter"].ToString();
                }
                if (row["C_Principal_mainContactPhone"] != null)
                {
                    model.C_Principal_mainContactPhone = row["C_Principal_mainContactPhone"].ToString();
                }
                if (row["C_Principal_value"] != null)
                {
                    model.C_Principal_value = row["C_Principal_value"].ToString();
                }
                if (row["C_Principal_address"] != null)
                {
                    model.C_Principal_address = row["C_Principal_address"].ToString();
                }
                if (row["C_Principal_reguser"] != null && row["C_Principal_reguser"].ToString() != "")
                {
                    model.C_Principal_reguser = new Guid(row["C_Principal_reguser"].ToString());
                }
                if (row["C_Principal_regdate"] != null && row["C_Principal_regdate"].ToString() != "")
                {
                    model.C_Principal_regdate = DateTime.Parse(row["C_Principal_regdate"].ToString());
                }
                if (row["C_Principal_loyalty"] != null && row["C_Principal_loyalty"].ToString() != "")
                {
                    model.C_Principal_loyalty = int.Parse(row["C_Principal_loyalty"].ToString());
                }
                if (row["C_Principal_lastContactDate"] != null && row["C_Principal_lastContactDate"].ToString() != "")
                {
                    model.C_Principal_lastContactDate = DateTime.Parse(row["C_Principal_lastContactDate"].ToString());
                }
                if (row["C_Principal_businessType"] != null && row["C_Principal_businessType"].ToString() != "")
                {
                    model.C_Principal_businessType = int.Parse(row["C_Principal_businessType"].ToString());
                }
                if (row["C_Principal_consultant"] != null && row["C_Principal_consultant"].ToString() != "")
                {
                    model.C_Principal_consultant = new Guid(row["C_Principal_consultant"].ToString());
                }
                if (row["C_Principal_responsibleDept"] != null && row["C_Principal_responsibleDept"].ToString() != "")
                {
                    model.C_Principal_responsibleDept = new Guid(row["C_Principal_responsibleDept"].ToString());
                }
                if (row["C_Principal_isDelete"] != null && row["C_Principal_isDelete"].ToString() != "")
                {
                    if ((row["C_Principal_isDelete"].ToString() == "1") || (row["C_Principal_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Principal_isDelete = true;
                    }
                    else
                    {
                        model.C_Principal_isDelete = false;
                    }
                }
                if (row["C_Principal_creator"] != null && row["C_Principal_creator"].ToString() != "")
                {
                    model.C_Principal_creator = new Guid(row["C_Principal_creator"].ToString());
                }
                if (row["C_Principal_createTime"] != null && row["C_Principal_createTime"].ToString() != "")
                {
                    model.C_Principal_createTime = DateTime.Parse(row["C_Principal_createTime"].ToString());
                }
                if (row["C_Principal_remark"]!=null && row["C_Principal_remark"].ToString()!="")
                {
                    model.C_principal_remark = row["C_Principal_remark"].ToString();
                }
                //判断销售顾问名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_principal_consultant_name"))
                {
                    if (row["C_principal_consultant_name"] != null && row["C_principal_consultant_name"].ToString() != "")
                    {
                        model.C_principal_consultant_name = row["C_principal_consultant_name"].ToString();
                    }
                }
                //判断负责部门名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_principal_responsibledept_name"))
                {
                    if (row["C_principal_responsibledept_name"] != null && row["C_principal_responsibledept_name"].ToString() != "")
                    {
                        model.C_principal_responsibledept_name = row["C_principal_responsibledept_name"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Principal_id,C_Principal_code,C_Principal_number,C_Principal_type,C_Principal_level,C_Principal_name,C_Principal_shortName,C_Principal_province,C_Principal_city,C_Principal_industryCode,C_Principal_yearTurnover,C_Principal_isSignedState,C_Principal_companySize,C_Principal_source,C_Principal_signedState,C_Principal_tel,C_Principal_phone,C_Principal_fax,C_Principal_email,C_Principal_website,C_Principal_contacter,C_Principal_mainContactPhone,C_Principal_value,C_Principal_address,C_Principal_reguser,C_Principal_regdate,C_Principal_loyalty,C_Principal_lastContactDate,C_Principal_businessType,C_Principal_consultant,C_Principal_responsibleDept,C_Principal_isDelete,C_Principal_creator,C_Principal_createTime,C_Principal_remark ");
            strSql.Append(" FROM C_Principal ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得未进行假删的数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Principal_id,C_Principal_code,C_Principal_number,C_Principal_type,C_Principal_level,C_Principal_name,C_Principal_shortName,C_Principal_province,C_Principal_city,C_Principal_industryCode,C_Principal_yearTurnover,C_Principal_isSignedState,C_Principal_companySize,C_Principal_source,C_Principal_signedState,C_Principal_tel,C_Principal_phone,C_Principal_fax,C_Principal_email,C_Principal_website,C_Principal_contacter,C_Principal_mainContactPhone,C_Principal_value,C_Principal_address,C_Principal_reguser,C_Principal_regdate,C_Principal_loyalty,C_Principal_lastContactDate,C_Principal_businessType,C_Principal_consultant,C_Principal_responsibleDept,C_Principal_isDelete,C_Principal_creator,C_Principal_createTime,C_Principal_remark ");
            strSql.Append(" FROM C_Principal where 1=1 and C_Principal_isDelete=0");
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
            strSql.Append(" C_Principal_id,C_Principal_code,C_Principal_number,C_Principal_type,C_Principal_level,C_Principal_name,C_Principal_shortName,C_Principal_province,C_Principal_city,C_Principal_industryCode,C_Principal_yearTurnover,C_Principal_isSignedState,C_Principal_companySize,C_Principal_source,C_Principal_signedState,C_Principal_tel,C_Principal_phone,C_Principal_fax,C_Principal_email,C_Principal_website,C_Principal_contacter,C_Principal_mainContactPhone,C_Principal_value,C_Principal_address,C_Principal_reguser,C_Principal_regdate,C_Principal_loyalty,C_Principal_lastContactDate,C_Principal_businessType,C_Principal_consultant,C_Principal_responsibleDept,C_Principal_isDelete,C_Principal_creator,C_Principal_createTime ");
            strSql.Append(" FROM C_Principal ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 一个条件获取记录总数
        /// </summary>
        public int GetRecordCount(Model.C_Principal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Principal as T with(nolock) ");
            if (model.C_Principal_reldatatype == 1)
            {//客户关联委托人
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Principal_code ");
                strSql.Append("and CC.C_Customer_Customer_customer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Principal_isDelete=0 ");
            }
            else if (model.C_Principal_reldatatype == 2)
            {//委托人关联客户
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_customer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_relCustomer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Principal_isDelete=0 ");
            }
            //else if (model.C_Principal_reldatatype == 3 && model.C_Principal_reldatatype != null && model.C_Principal_reldatatype.Replace(",,", "") != "")
            //{//代表多客户关联多委托人
            //    strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Principal_code ");
            //    strSql.Append("and charindex(CAST(CC.C_Customer_Customer_customer AS nvarchar(50)),@C_Customer_Customer_customers)>0) ");
            //    strSql.Append("and C_Principal_isDelete=0 ");
            //}
            else
            {
                strSql.Append(" where 1=1 and C_Principal_isDelete=0 ");
            }
            
            if (model!=null)
            {
                if (model.C_Principal_name!=null)
                {
                    strSql.Append("and C_Principal_name like N'%'+@C_Principal_name+'%' ");
                } 
                if (model.C_Principal_type != null)
                {
                    strSql.Append(" and C_Principal_type=@C_Principal_type ");
                }
                if (model.C_principal_Region_code!=Guid.Empty.ToString() && model.C_principal_Region_code!=null )
                {
                    strSql.Append(" and  T.C_principal_code in (select C_Customer_Region_customer from C_Customer_Region where C_Customer_Region_relRegion like N'%'+@C_principal_Region_code+'%')");
                }

            }
           
            SqlParameter[] parameters = { 
                                        new SqlParameter("@C_Principal_name",SqlDbType.VarChar,50),
                                        new SqlParameter("@C_Principal_type",SqlDbType.Int,4),
                                        new SqlParameter("@C_principal_Region_code",SqlDbType.VarChar,50),
                                        new SqlParameter("@C_Customer_Customer_customer",SqlDbType.UniqueIdentifier,16),
                                        //new SqlParameter("@C_Customer_Customer_customers", SqlDbType.NVarChar,4000),
                                    
                                        };
            parameters[0].Value = model.C_Principal_name;
            parameters[1].Value = model.C_Principal_type;
            parameters[2].Value = model.C_principal_Region_code;
            parameters[3].Value = model.C_Principal_code;
            //parameters[4].Value = model.C_principal_relCode;
           
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
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby);
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.C_Principal_id desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from C_Principal T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="butstring"></param>
        /// <returns></returns>
        public DataSet GetListByPage(Model.C_Principal model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Principal_id desc");
            }
            strSql.Append(")AS Row, T.*,U.C_Userinfo_name as 'C_Principal_consultant_name' from C_Principal T left join C_Userinfo as U on T.C_Principal_consultant=U.C_Userinfo_code ");
            if (model.C_Principal_reldatatype == 1)
            {//客户关联委托人               
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Principal_code ");
                strSql.Append("and CC.C_Customer_Customer_customer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Principal_isDelete=0 ");
            }
            else if (model.C_Principal_reldatatype == 2)
            {//委托人关联客户
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_customer=C_Principal_code ");
                strSql.Append("and CC.C_Customer_Customer_relCustomer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Principal_isDelete=0 ");
            }
            //else if (model.C_Principal_reldatatype == 3)
            //{//代表多客户关联多委托人
            //    strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Principal_code ");
            //    strSql.Append("and charindex(CAST(CC.C_Customer_Customer_customer AS nvarchar(50)),@C_Customer_Customer_customers)>0) ");
            //    strSql.Append("and C_Principal_isDelete=0 ");
            //}
            else
            {
                strSql.Append("where 1=1 and T.C_Principal_isDelete=0 ");
            }
            
            if (model!=null)
            {
                if (model.C_Principal_name!=null)
                {
                     strSql.Append("and T.C_Principal_name like N'%'+@C_Principal_name+'%'");
                }
                
                if (model.C_Principal_type != null)
                {
                    strSql.Append(" and C_Principal_type=@C_Principal_type ");
                }
                if (model.C_principal_Region_code != null && model.C_principal_Region_code != Guid.Empty.ToString())
                {

                    strSql.Append(" and T.C_principal_code in (select C_Customer_Region_customer from C_Customer_Region where C_Customer_Region_relRegion like N'%'+@C_principal_Region_code+'%')");

                }
               
                if (model.C_Principal_consultant != null)
                {
                    strSql.Append(" and C_Principal_consultant=@C_Principal_consultant ");
                }
                
            }
            
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = { 
                                        new SqlParameter("@C_Principal_name",SqlDbType.VarChar,50),
                                        new SqlParameter("@C_Principal_type",SqlDbType.Int,4),
                                        new SqlParameter("@C_principal_Region_code",SqlDbType.VarChar,50),
                                        new SqlParameter("@C_Principal_consultant",SqlDbType.UniqueIdentifier,16),
                                        new SqlParameter("@C_Principal_businessType",SqlDbType.Int,4),
                                        new SqlParameter("@C_Customer_Customer_customer",SqlDbType.UniqueIdentifier,16),
                                        //new SqlParameter("@C_Customer_Customer_customers",SqlDbType.NVarChar,4000)

                                       
                                        };
            parameters[0].Value = model.C_Principal_name;
            parameters[1].Value = model.C_Principal_type;
            parameters[2].Value = model.C_principal_Region_code;
            parameters[3].Value = model.C_Principal_consultant;
            parameters[4].Value = model.C_Principal_businessType;
            parameters[5].Value = model.C_Principal_code;
            //parameters[6].Value = model.C_principal_relCode;
           
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
            parameters[0].Value = "C_Principal";
            parameters[1].Value = "C_Principal_id";
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
