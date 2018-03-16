using CommonService.Common;
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
    /// 数据访问类:客户表
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Customer
    {
        public C_Customer()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Customer_id", "C_Customer");
        }

         /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(CommonService.Model.C_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Customer");
            strSql.Append(" where C_Customer_name=@C_Customer_name ");
            strSql.Append("and C_Customer_isDelete=0");
            if (model.C_Customer_id > 0)
            {
                strSql.Append(" and C_Customer_code <> @C_Customer_code ");
            }
            if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.客户))
            {
                strSql.Append(" and C_Customer_businessType <> " + Convert.ToInt32(CustomerBusiness.委托人));
            }
            else if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.委托人))
            {
                strSql.Append(" and C_Customer_businessType <> " + Convert.ToInt32(CustomerBusiness.客户));
            }

            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_name", SqlDbType.NVarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_Customer_name;
            parameters[1].Value = model.C_Customer_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByCustomerName(string C_Customer_name, int C_Customer_businessType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Customer");
            strSql.Append(" where C_Customer_name=@C_Customer_name");
            strSql.Append(" and C_Customer_businessType=@C_Customer_businessType ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_name", SqlDbType.NVarChar,200),
                    new SqlParameter("@C_Customer_businessType",SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_name;
            parameters[1].Value = C_Customer_businessType;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByCustomerNameAndCode(string C_Customer_name, Guid C_Customer_code, int C_Customer_businessType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Customer");
            strSql.Append(" where C_Customer_name=@C_Customer_name ");
            strSql.Append(" and C_Customer_isDelete=0");
            strSql.Append(" and C_Customer_code <> @C_Customer_code ");
            if (C_Customer_businessType == Convert.ToInt32(CustomerBusiness.客户))
            {
                strSql.Append(" and C_Customer_businessType <> " + Convert.ToInt32(CustomerBusiness.委托人));
            }
            else if (C_Customer_businessType == Convert.ToInt32(CustomerBusiness.委托人))
            {
                strSql.Append(" and C_Customer_businessType <> " + Convert.ToInt32(CustomerBusiness.客户));
            }

            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_name", SqlDbType.NVarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Customer_name;
            parameters[1].Value = C_Customer_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Customer(");
            strSql.Append("C_Customer_code,C_Customer_number,C_Customer_type,C_Customer_level,C_Customer_name,C_Customer_shortName,C_Customer_province,C_Customer_city,C_Customer_industryCode,C_Customer_yearTurnover,C_Customer_isSignedState,C_Customer_companySize,C_Customer_source,C_Customer_signedState,C_Customer_tel,C_Customer_phone,C_Customer_fax,C_Customer_email,C_Customer_website,C_Customer_contacter,C_Customer_mainContactPhone,C_Customer_value,C_Customer_address,C_Customer_reguser,C_Customer_regdate,C_Customer_loyalty,C_Customer_lastContactDate,C_Customer_businessType,C_Customer_consultant,C_Customer_responsibleDept,C_Customer_goingStatus,C_Customer_responsiblePerson,C_Customer_chiefResponsiblePerson,C_Customer_planStartTime,C_Customer_planEndTime,C_Customer_factStartTime,C_Customer_factEndTime,C_Customer_isDelete,C_Customer_remark,C_Customer_creator,C_Customer_createTime,C_Customer_Category,C_Customer_State)");
            strSql.Append(" values (");
            strSql.Append("@C_Customer_code,@C_Customer_number,@C_Customer_type,@C_Customer_level,@C_Customer_name,@C_Customer_shortName,@C_Customer_province,@C_Customer_city,@C_Customer_industryCode,@C_Customer_yearTurnover,@C_Customer_isSignedState,@C_Customer_companySize,@C_Customer_source,@C_Customer_signedState,@C_Customer_tel,@C_Customer_phone,@C_Customer_fax,@C_Customer_email,@C_Customer_website,@C_Customer_contacter,@C_Customer_mainContactPhone,@C_Customer_value,@C_Customer_address,@C_Customer_reguser,@C_Customer_regdate,@C_Customer_loyalty,@C_Customer_lastContactDate,@C_Customer_businessType,@C_Customer_consultant,@C_Customer_responsibleDept,@C_Customer_goingStatus,@C_Customer_responsiblePerson,@C_Customer_chiefResponsiblePerson,@C_Customer_planStartTime,@C_Customer_planEndTime,@C_Customer_factStartTime,@C_Customer_factEndTime,@C_Customer_isDelete,@C_Customer_remark,@C_Customer_creator,@C_Customer_createTime,@C_Customer_Category,@C_Customer_State)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_number", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Customer_type", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_level", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_name", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Customer_shortName", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Customer_province", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_city", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_industryCode", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_yearTurnover", SqlDbType.Decimal,9),
					new SqlParameter("@C_Customer_isSignedState", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_companySize", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Customer_source", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_signedState", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_tel", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Customer_phone", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Customer_fax", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Customer_email", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Customer_website", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Customer_contacter", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Customer_mainContactPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Customer_value", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Customer_address", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Customer_reguser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_regdate", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_loyalty", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_lastContactDate", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_businessType", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_consultant", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_responsibleDept", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_goingStatus",SqlDbType.Int,6),
                    new SqlParameter("@C_Customer_responsiblePerson", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_chiefResponsiblePerson", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_planStartTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_planEndTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_factStartTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_factEndTime", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Customer_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Customer_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_createTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_Category",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_State",SqlDbType.Int,4)
            };
            parameters[0].Value = model.C_Customer_code;
            parameters[1].Value = model.C_Customer_number;
            parameters[2].Value = model.C_Customer_type;
            parameters[3].Value = model.C_Customer_level;
            parameters[4].Value = model.C_Customer_name;
            parameters[5].Value = model.C_Customer_shortName;
            parameters[6].Value = model.C_Customer_province;
            parameters[7].Value = model.C_Customer_city;
            parameters[8].Value = model.C_Customer_industryCode;
            parameters[9].Value = model.C_Customer_yearTurnover;
            parameters[10].Value = model.C_Customer_isSignedState;
            parameters[11].Value = model.C_Customer_companySize;
            parameters[12].Value = model.C_Customer_source;
            parameters[13].Value = model.C_Customer_signedState;
            parameters[14].Value = model.C_Customer_tel;
            parameters[15].Value = model.C_Customer_phone;
            parameters[16].Value = model.C_Customer_fax;
            parameters[17].Value = model.C_Customer_email;
            parameters[18].Value = model.C_Customer_website;
            parameters[19].Value = model.C_Customer_contacter;
            parameters[20].Value = model.C_Customer_mainContactPhone;
            parameters[21].Value = model.C_Customer_value;
            parameters[22].Value = model.C_Customer_address;
            parameters[23].Value = model.C_Customer_reguser;
            parameters[24].Value = model.C_Customer_regdate;
            parameters[25].Value = model.C_Customer_loyalty;
            parameters[26].Value = model.C_Customer_lastContactDate;
            parameters[27].Value = model.C_Customer_businessType;
            parameters[28].Value = model.C_Customer_consultant;
            parameters[29].Value = model.C_Customer_responsibleDept;
            parameters[30].Value = model.C_Customer_goingStatus;
            parameters[31].Value = model.C_Customer_responsiblePerson;
            parameters[32].Value = model.C_Customer_chiefResponsiblePerson;
            parameters[33].Value = model.C_Customer_planStartTime;
            parameters[34].Value = model.C_Customer_planEndTime;
            parameters[35].Value = model.C_Customer_factStartTime;
            parameters[36].Value = model.C_Customer_factEndTime;
            parameters[37].Value = model.C_Customer_isDelete;
            parameters[38].Value = model.C_Customer_remark;
            parameters[39].Value = model.C_Customer_creator;
            parameters[40].Value = model.C_Customer_createTime;
            parameters[41].Value = model.C_Customer_Category;
            parameters[42].Value = model.C_Customer_State;

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
        public bool Update(CommonService.Model.C_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer set ");
            strSql.Append("C_Customer_number=@C_Customer_number,");
            strSql.Append("C_Customer_type=@C_Customer_type,");
            strSql.Append("C_Customer_level=@C_Customer_level,");
            strSql.Append("C_Customer_name=@C_Customer_name,");
            strSql.Append("C_Customer_shortName=@C_Customer_shortName,");
            strSql.Append("C_Customer_province=@C_Customer_province,");
            strSql.Append("C_Customer_city=@C_Customer_city,");
            strSql.Append("C_Customer_industryCode=@C_Customer_industryCode,");
            strSql.Append("C_Customer_yearTurnover=@C_Customer_yearTurnover,");
            strSql.Append("C_Customer_isSignedState=@C_Customer_isSignedState,");
            strSql.Append("C_Customer_companySize=@C_Customer_companySize,");
            strSql.Append("C_Customer_source=@C_Customer_source,");
            strSql.Append("C_Customer_signedState=@C_Customer_signedState,");
            strSql.Append("C_Customer_tel=@C_Customer_tel,");
            strSql.Append("C_Customer_phone=@C_Customer_phone,");
            strSql.Append("C_Customer_fax=@C_Customer_fax,");
            strSql.Append("C_Customer_email=@C_Customer_email,");
            strSql.Append("C_Customer_website=@C_Customer_website,");
            strSql.Append("C_Customer_contacter=@C_Customer_contacter,");
            strSql.Append("C_Customer_mainContactPhone=@C_Customer_mainContactPhone,");
            strSql.Append("C_Customer_value=@C_Customer_value,");
            strSql.Append("C_Customer_address=@C_Customer_address,");
            strSql.Append("C_Customer_reguser=@C_Customer_reguser,");
            strSql.Append("C_Customer_regdate=@C_Customer_regdate,");
            strSql.Append("C_Customer_loyalty=@C_Customer_loyalty,");
            strSql.Append("C_Customer_lastContactDate=@C_Customer_lastContactDate,");
            strSql.Append("C_Customer_businessType=@C_Customer_businessType,");
            strSql.Append("C_Customer_consultant=@C_Customer_consultant,");
            strSql.Append("C_Customer_responsibleDept=@C_Customer_responsibleDept,");
            strSql.Append("C_Customer_goingStatus=@C_Customer_goingStatus,");
            strSql.Append("C_Customer_responsiblePerson=@C_Customer_responsiblePerson,");
            strSql.Append("C_Customer_chiefResponsiblePerson=@C_Customer_chiefResponsiblePerson,");
            strSql.Append("C_Customer_planStartTime=@C_Customer_planStartTime,");
            strSql.Append("C_Customer_planEndTime=@C_Customer_planEndTime,");
            strSql.Append("C_Customer_factStartTime=@C_Customer_factStartTime,");
            strSql.Append("C_Customer_factEndTime=@C_Customer_factEndTime,");
            strSql.Append("C_Customer_isDelete=@C_Customer_isDelete,");
            strSql.Append("C_Customer_remark=@C_Customer_remark,");
            strSql.Append("C_Customer_creator=@C_Customer_creator,");
            strSql.Append("C_Customer_createTime=@C_Customer_createTime,");
            strSql.Append("C_Customer_Category=@C_Customer_Category,");
            strSql.Append("C_Customer_State=@C_Customer_State");
            strSql.Append(" where C_Customer_code=@C_Customer_code");
            SqlParameter[] parameters = {				 
					new SqlParameter("@C_Customer_number", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Customer_type", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_level", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_name", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Customer_shortName", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Customer_province", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_city", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_industryCode", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_yearTurnover", SqlDbType.Decimal,9),
					new SqlParameter("@C_Customer_isSignedState", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_companySize", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Customer_source", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_signedState", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_tel", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Customer_phone", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Customer_fax", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Customer_email", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Customer_website", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Customer_contacter", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Customer_mainContactPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Customer_value", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Customer_address", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Customer_reguser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_regdate", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_loyalty", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_lastContactDate", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_businessType", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_consultant", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_responsibleDept", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_goingStatus",SqlDbType.Int,6),
                    new SqlParameter("@C_Customer_responsiblePerson", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_chiefResponsiblePerson", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_planStartTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_planEndTime ", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_factStartTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_factEndTime", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Customer_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Customer_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_createTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_Category",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_State",SqlDbType.Int,4),
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = model.C_Customer_number;
            parameters[1].Value = model.C_Customer_type;
            parameters[2].Value = model.C_Customer_level;
            parameters[3].Value = model.C_Customer_name;
            parameters[4].Value = model.C_Customer_shortName;
            parameters[5].Value = model.C_Customer_province;
            parameters[6].Value = model.C_Customer_city;
            parameters[7].Value = model.C_Customer_industryCode;
            parameters[8].Value = model.C_Customer_yearTurnover;
            parameters[9].Value = model.C_Customer_isSignedState;
            parameters[10].Value = model.C_Customer_companySize;
            parameters[11].Value = model.C_Customer_source;
            parameters[12].Value = model.C_Customer_signedState;
            parameters[13].Value = model.C_Customer_tel;
            parameters[14].Value = model.C_Customer_phone;
            parameters[15].Value = model.C_Customer_fax;
            parameters[16].Value = model.C_Customer_email;
            parameters[17].Value = model.C_Customer_website;
            parameters[18].Value = model.C_Customer_contacter;
            parameters[19].Value = model.C_Customer_mainContactPhone;
            parameters[20].Value = model.C_Customer_value;
            parameters[21].Value = model.C_Customer_address;
            parameters[22].Value = model.C_Customer_reguser;
            parameters[23].Value = model.C_Customer_regdate;
            parameters[24].Value = model.C_Customer_loyalty;
            parameters[25].Value = model.C_Customer_lastContactDate;
            parameters[26].Value = model.C_Customer_businessType;
            parameters[27].Value = model.C_Customer_consultant;
            parameters[28].Value = model.C_Customer_responsibleDept;
            parameters[29].Value = model.C_Customer_goingStatus;
            parameters[30].Value = model.C_Customer_responsiblePerson;
            parameters[31].Value = model.C_Customer_chiefResponsiblePerson;
            parameters[32].Value = model.C_Customer_planStartTime;
            parameters[33].Value = model.C_Customer_planEndTime;
            parameters[34].Value = model.C_Customer_factStartTime;
            parameters[35].Value = model.C_Customer_factEndTime;
            parameters[36].Value = model.C_Customer_isDelete;
            parameters[37].Value = model.C_Customer_remark;
            parameters[38].Value = model.C_Customer_creator;
            parameters[39].Value = model.C_Customer_createTime;
            parameters[40].Value = model.C_Customer_Category;
            parameters[41].Value = model.C_Customer_State;
            parameters[42].Value = model.C_Customer_code;

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
        /// 设置客户计划
        /// </summary>
        /// <param name="model">客户数据模型</param>
        /// <returns></returns>        
        public bool SetCustomerPlan(CommonService.Model.C_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer set ");
            strSql.Append("C_Customer_responsiblePerson=@C_Customer_responsiblePerson,");
            strSql.Append("C_Customer_chiefResponsiblePerson=@C_Customer_chiefResponsiblePerson,");
            strSql.Append("C_Customer_planStartTime=@C_Customer_planStartTime,");
            strSql.Append("C_Customer_planEndTime=@C_Customer_planEndTime ");
            strSql.Append("where C_Customer_code=@C_Customer_code");
            SqlParameter[] parameters = {				 
                    new SqlParameter("@C_Customer_responsiblePerson", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_chiefResponsiblePerson", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_planStartTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_planEndTime ", SqlDbType.DateTime),           					 
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = model.C_Customer_responsiblePerson;
            parameters[1].Value = model.C_Customer_chiefResponsiblePerson;
            parameters[2].Value = model.C_Customer_planStartTime;
            parameters[3].Value = model.C_Customer_planEndTime;
            parameters[4].Value = model.C_Customer_code;

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
        public bool Delete(Guid C_Customer_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer set C_Customer_isDelete=1 ");
            strSql.Append(" where C_Customer_code=@C_Customer_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Customer_code;

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
        public bool DeleteList(string C_Customer_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Customer ");
            strSql.Append(" where C_Customer_id in (" + C_Customer_idlist + ")  ");
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
        public CommonService.Model.C_Customer GetModel(int C_Customer_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C.*,O.C_Organization_name As C_Customer_responsibleDept_Name ");
            strSql.Append("from C_Customer with(nolock) As C ");
            strSql.Append("left join C_Organization As O with(nolock) on C.C_Customer_responsibleDept=O.C_Organization_code ");
            strSql.Append(" where C.C_Customer_id=@C_Customer_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_id;

            CommonService.Model.C_Customer model = new CommonService.Model.C_Customer();
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
        public CommonService.Model.C_Customer GetModel(Guid C_Customer_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C.C_Customer_id,C.C_Customer_code,C.C_Customer_number,C.C_Customer_type,C.C_Customer_level,C.C_Customer_name,C.C_Customer_shortName,C.C_Customer_province,C.C_Customer_city,C.C_Customer_industryCode,C.C_Customer_yearTurnover,C.C_Customer_isSignedState,C.C_Customer_companySize,C.C_Customer_source,C.C_Customer_signedState,C.C_Customer_tel,C.C_Customer_phone,C.C_Customer_fax,C.C_Customer_email,C.C_Customer_website,C.C_Customer_contacter,C.C_Customer_mainContactPhone,C.C_Customer_value,C.C_Customer_address,C.C_Customer_reguser,C.C_Customer_regdate,C.C_Customer_loyalty,C.C_Customer_lastContactDate,C.C_Customer_businessType,C.C_Customer_consultant,C.C_Customer_responsibleDept,C.C_Customer_isDelete,C.C_Customer_remark,C.C_Customer_creator,C.C_Customer_createTime,C.C_Customer_Category,C.C_Customer_State,");
            strSql.Append("C.C_Customer_goingStatus,C.C_Customer_responsiblePerson,C.C_Customer_chiefResponsiblePerson,C.C_Customer_planStartTime,C.C_Customer_planEndTime,C.C_Customer_factStartTime,C.C_Customer_factEndTime,");
            strSql.Append("U.C_Userinfo_name as 'C_Customer_consultant_name',O.C_Organization_name As C_Customer_responsibleDept_Name,p.C_Parameters_name as C_Customer_industrycode_name ");
            strSql.Append("from C_Customer as C left join C_Userinfo as U on C.C_Customer_consultant=U.C_Userinfo_code ");
            strSql.Append("left join C_Organization As O with(nolock) on C.C_Customer_responsibleDept=O.C_Organization_code ");
            strSql.Append("left join C_Parameters as p on p.C_Parameters_id=c.C_Customer_industryCode");
            strSql.Append(" where C_Customer_code=@C_Customer_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Customer_code;

            CommonService.Model.C_Customer model = new CommonService.Model.C_Customer();
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
        public CommonService.Model.C_Customer DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Customer model = new CommonService.Model.C_Customer();
            if (row != null)
            {
                if (row["C_Customer_id"] != null && row["C_Customer_id"].ToString() != "")
                {
                    model.C_Customer_id = int.Parse(row["C_Customer_id"].ToString());
                }
                if (row["C_Customer_code"] != null && row["C_Customer_code"].ToString() != "")
                {
                    model.C_Customer_code = new Guid(row["C_Customer_code"].ToString());
                }
                if (row["C_Customer_number"] != null)
                {
                    model.C_Customer_number = row["C_Customer_number"].ToString();
                }
                if (row["C_Customer_type"] != null && row["C_Customer_type"].ToString() != "")
                {
                    model.C_Customer_type = int.Parse(row["C_Customer_type"].ToString());
                }
                if (row["C_Customer_level"] != null && row["C_Customer_level"].ToString() != "")
                {
                    model.C_Customer_level = int.Parse(row["C_Customer_level"].ToString());
                }
                if (row["C_Customer_name"] != null)
                {
                    model.C_Customer_name = row["C_Customer_name"].ToString();
                }
                if (row["C_Customer_shortName"] != null)
                {
                    model.C_Customer_shortName = row["C_Customer_shortName"].ToString();
                }
                if (row["C_Customer_province"] != null && row["C_Customer_province"].ToString() != "")
                {
                    model.C_Customer_province = int.Parse(row["C_Customer_province"].ToString());
                }
                if (row["C_Customer_city"] != null && row["C_Customer_city"].ToString() != "")
                {
                    model.C_Customer_city = int.Parse(row["C_Customer_city"].ToString());
                }
                if (row["C_Customer_industryCode"] != null && row["C_Customer_industryCode"].ToString() != "")
                {
                    model.C_Customer_industryCode = int.Parse(row["C_Customer_industryCode"].ToString());
                }
                if (row["C_Customer_yearTurnover"] != null && row["C_Customer_yearTurnover"].ToString() != "")
                {
                    model.C_Customer_yearTurnover = decimal.Parse(row["C_Customer_yearTurnover"].ToString());
                }
                if (row["C_Customer_isSignedState"] != null && row["C_Customer_isSignedState"].ToString() != "")
                {
                    model.C_Customer_isSignedState = int.Parse(row["C_Customer_isSignedState"].ToString());
                }
                if (row["C_Customer_companySize"] != null)
                {
                    model.C_Customer_companySize = row["C_Customer_companySize"].ToString();
                }
                if (row["C_Customer_source"] != null && row["C_Customer_source"].ToString() != "")
                {
                    model.C_Customer_source = int.Parse(row["C_Customer_source"].ToString());
                }
                if (row["C_Customer_signedState"] != null && row["C_Customer_signedState"].ToString() != "")
                {
                    model.C_Customer_signedState = int.Parse(row["C_Customer_signedState"].ToString());
                }
                if (row["C_Customer_tel"] != null)
                {
                    model.C_Customer_tel = row["C_Customer_tel"].ToString();
                }
                if (row["C_Customer_phone"] != null)
                {
                    model.C_Customer_phone = row["C_Customer_phone"].ToString();
                }
                if (row["C_Customer_fax"] != null)
                {
                    model.C_Customer_fax = row["C_Customer_fax"].ToString();
                }
                if (row["C_Customer_email"] != null)
                {
                    model.C_Customer_email = row["C_Customer_email"].ToString();
                }
                if (row["C_Customer_website"] != null)
                {
                    model.C_Customer_website = row["C_Customer_website"].ToString();
                }
                if (row["C_Customer_contacter"] != null)
                {
                    model.C_Customer_contacter = row["C_Customer_contacter"].ToString();
                }
                if (row["C_Customer_mainContactPhone"] != null)
                {
                    model.C_Customer_mainContactPhone = row["C_Customer_mainContactPhone"].ToString();
                }
                if (row["C_Customer_value"] != null)
                {
                    model.C_Customer_value = row["C_Customer_value"].ToString();
                }
                if (row["C_Customer_address"] != null)
                {
                    model.C_Customer_address = row["C_Customer_address"].ToString();
                }
                if (row["C_Customer_reguser"] != null && row["C_Customer_reguser"].ToString() != "")
                {
                    model.C_Customer_reguser = new Guid(row["C_Customer_reguser"].ToString());
                }
                if (row["C_Customer_regdate"] != null && row["C_Customer_regdate"].ToString() != "")
                {
                    model.C_Customer_regdate = DateTime.Parse(row["C_Customer_regdate"].ToString());
                }
                if (row["C_Customer_loyalty"] != null && row["C_Customer_loyalty"].ToString() != "")
                {
                    model.C_Customer_loyalty = int.Parse(row["C_Customer_loyalty"].ToString());
                }
                if (row["C_Customer_lastContactDate"] != null && row["C_Customer_lastContactDate"].ToString() != "")
                {
                    model.C_Customer_lastContactDate = DateTime.Parse(row["C_Customer_lastContactDate"].ToString());
                }
                if (row["C_Customer_businessType"] != null && row["C_Customer_businessType"].ToString() != "")
                {
                    model.C_Customer_businessType = int.Parse(row["C_Customer_businessType"].ToString());
                }
                if (row["C_Customer_consultant"] != null && row["C_Customer_consultant"].ToString() != "")
                {
                    model.C_Customer_consultant = new Guid(row["C_Customer_consultant"].ToString());
                }
                if (row["C_Customer_responsibleDept"] != null && row["C_Customer_responsibleDept"].ToString() != "")
                {
                    model.C_Customer_responsibleDept = new Guid(row["C_Customer_responsibleDept"].ToString());
                }
                //检查进行状态是否存在于表中(非虚拟属性)
                if (row.Table.Columns.Contains("C_Customer_goingStatus"))
                {
                    if (row["C_Customer_goingStatus"] != null && row["C_Customer_goingStatus"].ToString() != "")
                    {
                        model.C_Customer_goingStatus = int.Parse(row["C_Customer_goingStatus"].ToString());
                    }
                }
                //检查客户负责人是否存在于表中(非虚拟属性)
                if (row.Table.Columns.Contains("C_Customer_responsiblePerson"))
                {
                    if (row["C_Customer_responsiblePerson"] != null && row["C_Customer_responsiblePerson"].ToString() != "")
                    {
                        model.C_Customer_responsiblePerson = new Guid(row["C_Customer_responsiblePerson"].ToString());
                    }
                }
                //检查客户首席负责人是否存在于表中(非虚拟属性)
                if (row.Table.Columns.Contains("C_Customer_chiefResponsiblePerson"))
                {
                    if (row["C_Customer_chiefResponsiblePerson"] != null && row["C_Customer_chiefResponsiblePerson"].ToString() != "")
                    {
                        model.C_Customer_chiefResponsiblePerson = new Guid(row["C_Customer_chiefResponsiblePerson"].ToString());
                    }
                }
                //检查计划开始时间是否存在于表中(非虚拟属性)
                if (row.Table.Columns.Contains("C_Customer_planStartTime"))
                {
                    if (row["C_Customer_planStartTime"] != null && row["C_Customer_planStartTime"].ToString() != "")
                    {
                        model.C_Customer_planStartTime = DateTime.Parse(row["C_Customer_planStartTime"].ToString());
                    }
                }
                //检查计划结束时间是否存在于表中(非虚拟属性)
                if (row.Table.Columns.Contains("C_Customer_planEndTime"))
                {
                    if (row["C_Customer_planEndTime"] != null && row["C_Customer_planEndTime"].ToString() != "")
                    {
                        model.C_Customer_planEndTime = DateTime.Parse(row["C_Customer_planEndTime"].ToString());
                    }
                }
                //检查实际开始时间是否存在于表中(非虚拟属性)
                if (row.Table.Columns.Contains("C_Customer_factStartTime"))
                {
                    if (row["C_Customer_factStartTime"] != null && row["C_Customer_factStartTime"].ToString() != "")
                    {
                        model.C_Customer_factStartTime = DateTime.Parse(row["C_Customer_factStartTime"].ToString());
                    }
                }
                //检查实际结束时间是否存在于表中(非虚拟属性)
                if (row.Table.Columns.Contains("C_Customer_factEndTime"))
                {
                    if (row["C_Customer_factEndTime"] != null && row["C_Customer_factEndTime"].ToString() != "")
                    {
                        model.C_Customer_factEndTime = DateTime.Parse(row["C_Customer_factEndTime"].ToString());
                    }
                }

                if (row["C_Customer_isDelete"] != null && row["C_Customer_isDelete"].ToString() != "")
                {
                    if ((row["C_Customer_isDelete"].ToString() == "1") || (row["C_Customer_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Customer_isDelete = true;
                    }
                    else
                    {
                        model.C_Customer_isDelete = false;
                    }
                }
                if (row["C_Customer_remark"] != null)
                {
                    model.C_Customer_remark = row["C_Customer_remark"].ToString();
                }
                if (row["C_Customer_creator"] != null && row["C_Customer_creator"].ToString() != "")
                {
                    model.C_Customer_creator = new Guid(row["C_Customer_creator"].ToString());
                }
                if (row["C_Customer_createTime"] != null && row["C_Customer_createTime"].ToString() != "")
                {
                    model.C_Customer_createTime = DateTime.Parse(row["C_Customer_createTime"].ToString());
                }
                if (row["C_Customer_Category"] != null && row["C_Customer_Category"].ToString() != "")
                {
                    model.C_Customer_Category = int.Parse(row["C_Customer_Category"].ToString());
                }
                if (row["C_Customer_State"] != null && row["C_Customer_State"].ToString() != "")
                {
                    model.C_Customer_State = int.Parse(row["C_Customer_State"].ToString());
                }
                //判断销售顾问名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Customer_consultant_name"))
                {
                    if (row["C_Customer_consultant_name"] != null && row["C_Customer_consultant_name"].ToString() != "")
                    {
                        model.C_Customer_consultant_name = row["C_Customer_consultant_name"].ToString();
                    }
                }
                //判断负责部门名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Customer_responsibleDept_Name"))
                {
                    if (row["C_Customer_responsibleDept_Name"] != null && row["C_Customer_responsibleDept_Name"].ToString() != "")
                    {
                        model.C_Customer_responsibleDept_Name = row["C_Customer_responsibleDept_Name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_Region"))
                {
                    if (row["C_Customer_Region"] != null && row["C_Customer_Region"].ToString() != "")
                    {
                        model.C_Customer_Region = row["C_Customer_Region"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_goingstatusName"))
                {
                    if (row["C_Customer_goingstatusName"] != null && row["C_Customer_goingstatusName"].ToString() != "")
                    {
                        model.C_Customer_goingstatusName = row["C_Customer_goingstatusName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_industrycode_name"))
                {
                    if (row["C_Customer_industrycode_name"] != null && row["C_Customer_industrycode_name"].ToString() != "")
                    {
                        model.C_Customer_industrycode_name = row["C_Customer_industrycode_name"].ToString();
                    }
                }
                
                #region App专用
                //客户忠诚度名称
                if (row.Table.Columns.Contains("C_customer_loyalty_name"))
                {
                    if (row["C_customer_loyalty_name"] != null && row["C_customer_loyalty_name"].ToString() != "")
                    {
                        model.C_customer_loyalty_name = row["C_customer_loyalty_name"].ToString();
                    }
                }

                //签约客户状态名称
                if (row.Table.Columns.Contains("C_customer_signedState_name"))
                {
                    if (row["C_customer_signedState_name"] != null && row["C_customer_signedState_name"].ToString() != "")
                    {
                        model.C_customer_signedState_name = row["C_customer_signedState_name"].ToString();
                    }
                }

                //客户来源名称
                if (row.Table.Columns.Contains("C_customer_source_name"))
                {
                    if (row["C_customer_source_name"] != null && row["C_customer_source_name"].ToString() != "")
                    {
                        model.C_customer_source_name = row["C_customer_source_name"].ToString();
                    }
                }


                //客户级别
                if (row.Table.Columns.Contains("C_customer_level_name"))
                {
                    if (row["C_customer_level_name"] != null && row["C_customer_level_name"].ToString() != "")
                    {
                        model.C_customer_level_name = row["C_customer_level_name"].ToString();
                    }
                }

                //客户状态名称
                if (row.Table.Columns.Contains("C_customer_state_name"))
                {
                    if (row["C_customer_state_name"] != null && row["C_customer_state_name"].ToString() != "")
                    {
                        model.C_customer_state_name = row["C_customer_state_name"].ToString();
                    }
                }

                //客户类型名称
                if (row.Table.Columns.Contains("C_customer_type_name"))
                {
                    if (row["C_customer_type_name"] != null && row["C_customer_type_name"].ToString() != "")
                    {
                        model.C_customer_type_name = row["C_customer_type_name"].ToString();
                    }
                }

                //客户类别名称
                if (row.Table.Columns.Contains("C_customer_category_name"))
                {
                    if (row["C_customer_category_name"] != null && row["C_customer_category_name"].ToString() != "")
                    {
                        model.C_customer_category_name = row["C_customer_category_name"].ToString();
                    }
                }
                #endregion
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Customer_id,C_Customer_code,C_Customer_number,C_Customer_type,C_Customer_level,C_Customer_parent,C_Customer_name,C_Customer_shortName,C_Customer_province,C_Customer_city,C_Customer_industryCode,C_Customer_yearTurnover,C_Customer_isSignedState,C_Customer_companySize,C_Customer_source,C_Customer_signedState,C_Customer_tel,C_Customer_phone,C_Customer_fax,C_Customer_email,C_Customer_website,C_Customer_contacter,C_Customer_mainContactPhone,C_Customer_value,C_Customer_address,C_Customer_reguser,C_Customer_regdate,C_Customer_loyalty,C_Customer_lastContactDate,C_Customer_businessType,C_Customer_consultant,C_Customer_responsibleDept,C_Customer_isDelete,C_Customer_remark,C_Customer_creator,C_Customer_createTime,C_Customer_Category,C_Customer_State ");
            strSql.Append(" FROM C_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据专业顾问获得数据列表
        /// </summary>
        public DataSet GetListByConsultant(Guid consultantCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Customer_id,C_Customer_code,C_Customer_number,C_Customer_type,C_Customer_level,C_Customer_name,C_Customer_shortName,C_Customer_province,C_Customer_city,C_Customer_industryCode,C_Customer_yearTurnover,C_Customer_isSignedState,C_Customer_companySize,C_Customer_source,C_Customer_signedState,C_Customer_tel,C_Customer_phone,C_Customer_fax,C_Customer_email,C_Customer_website,C_Customer_contacter,C_Customer_mainContactPhone,C_Customer_value,C_Customer_address,C_Customer_reguser,C_Customer_regdate,C_Customer_loyalty,C_Customer_lastContactDate,C_Customer_businessType,C_Customer_consultant,C_Customer_responsibleDept,C_Customer_goingStatus,C_Customer_responsiblePerson,C_Customer_chiefResponsiblePerson,C_Customer_planStartTime,C_Customer_planEndTime,C_Customer_factStartTime,C_Customer_factEndTime,C_Customer_isDelete,C_Customer_remark,C_Customer_creator,C_Customer_createTime,C_Customer_Category,C_Customer_State ");
            strSql.Append(" FROM C_Customer ");
            strSql.Append("where C_Customer_isDelete=0 and C_Customer_consultant=@C_Customer_consultant and C_Customer_businessType<>82");

            SqlParameter[] parameters = {					 
                    new SqlParameter("@C_Customer_consultant", SqlDbType.UniqueIdentifier,16)
		    };
            parameters[0].Value = consultantCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Customer_id,C_Customer_code,C_Customer_number,C_Customer_type,C_Customer_level,C_Customer_parent,C_Customer_name,C_Customer_shortName,C_Customer_province,C_Customer_city,C_Customer_industryCode,C_Customer_yearTurnover,C_Customer_isSignedState,C_Customer_companySize,C_Customer_source,C_Customer_signedState,C_Customer_tel,C_Customer_phone,C_Customer_fax,C_Customer_email,C_Customer_website,C_Customer_contacter,C_Customer_mainContactPhone,C_Customer_value,C_Customer_address,C_Customer_reguser,C_Customer_regdate,C_Customer_loyalty,C_Customer_lastContactDate,C_Customer_businessType,C_Customer_consultant,C_Customer_responsibleDept,C_Customer_isDelete,C_Customer_remark,C_Customer_creator,C_Customer_createTime,C_Customer_Category,C_Customer_State ");
            strSql.Append(" FROM C_Customer where 1=1 and C_Customer_isDelete=0");
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
            strSql.Append(" C_Customer_id,C_Customer_code,C_Customer_number,C_Customer_type,C_Customer_level,C_Customer_parent,C_Customer_name,C_Customer_shortName,C_Customer_province,C_Customer_city,C_Customer_industryCode,C_Customer_yearTurnover,C_Customer_isSignedState,C_Customer_companySize,C_Customer_source,C_Customer_signedState,C_Customer_tel,C_Customer_phone,C_Customer_fax,C_Customer_email,C_Customer_website,C_Customer_contacter,C_Customer_mainContactPhone,C_Customer_value,C_Customer_address,C_Customer_reguser,C_Customer_regdate,C_Customer_loyalty,C_Customer_lastContactDate,C_Customer_businessType,C_Customer_consultant,C_Customer_responsibleDept,C_Customer_isDelete,C_Customer_remark,C_Customer_creator,C_Customer_createTime,C_Customer_Category,C_Customer_State ");
            strSql.Append(" FROM C_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(Model.C_Customer model, string orderby, int startIndex, int endIndex, string butstring)
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
                strSql.Append("order by T.C_Customer_id desc");
            }
            strSql.Append(")AS Row, T.*,U.C_Userinfo_name as 'C_Customer_consultant_name' from C_Customer T left join C_Userinfo as U on T.C_Customer_consultant=U.C_Userinfo_code ");
            if (model.C_Customer_Follow_time_type != null)
            {
                DateTime date = DateTime.Now;
                string sql = "";
                if (model.C_Customer_Follow_time_type == 1)
                {
                    date = date.AddMonths(-3);
                    sql = " C_Customer_Follow_time  between getdate() and '" + date + "'";
                }
                else if (model.C_Customer_Follow_time_type == 2)
                {
                    sql = " C_Customer_Follow_time  is not null";
                }
                else
                {
                    sql = " DATEDIFF(dd,getdate(),C_Customer_Follow_time )=0 ";
                }
                if (model.C_Customer_Follow_time_type != 3)
                {
                    strSql.Append(" right join (select *　from　C_Customer_Follow  where " + sql + " ) As CCF on T.C_Customer_code=CCF.C_Customer_code ");
                }
            }
            if (model.C_Customer_reldatatype == 1)
            {//客户关联委托人               
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_customer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else if (model.C_Customer_reldatatype == 2)
            {//委托人关联客户
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_customer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_relCustomer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else if (model.C_Customer_reldatatype == 3)
            {//代表多客户关联多委托人
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Customer_code ");
                strSql.Append("and charindex(CAST(CC.C_Customer_Customer_customer AS nvarchar(50)),@C_Customer_Customer_customers)>0) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else
            {
                strSql.Append("where 1=1 and T.C_Customer_isDelete=0 ");
            }

            if (model != null)
            {
                if (model.C_Customer_name != null)
                {
                    strSql.Append("and T.C_Customer_name like N'%'+@C_Customer_name+'%'");

                }
                if (model.C_Customer_businessType != null)
                {
                    if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.客户))
                    {//客户信息列表
                        strSql.Append("and C_Customer_businessType!=" + Convert.ToInt32(CustomerBusiness.委托人));
                    }
                    else if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.委托人))
                    {//委托人信息列表
                        strSql.Append("and C_Customer_businessType!=" + Convert.ToInt32(CustomerBusiness.客户));
                    }
                    //strSql.Append("and C_Customer_businessType=@C_Customer_businessType ");
                }
                if (model.C_Customer_reldatatype != null)
                {

                }
                if (model.C_Customer_type != null)
                {
                    strSql.Append(" and C_Customer_type=@C_Customer_type ");
                }
                if (model.C_Customer_Follow_time_type == 3)
                {
                    strSql.Append(" and T.C_Customer_code not in (select C_Customer_code  from C_Customer_Follow) ");
                }
            }

            if (butstring != "")
            {
                strSql.Append("and '" + butstring + "' like '%'+convert(varchar(100),C_Customer_consultant)+'%'");
            }

            strSql.Append(" ) TT");

            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					 
					new SqlParameter("@C_Customer_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_businessType", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Customer_customer", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_Customer_customers", SqlDbType.NVarChar,4000),
                    new SqlParameter("@C_Customer_type", SqlDbType.Int,4),
		    };
            parameters[0].Value = model.C_Customer_name;
            parameters[1].Value = model.C_Customer_businessType;
            parameters[2].Value = model.C_Customer_code;
            parameters[3].Value = model.C_Customer_relcodes;
            parameters[4].Value = model.C_Customer_type;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取数据总数
        /// </summary>
        public int GetListByPageCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) from C_Customer T left join C_Userinfo as U on T.C_Customer_consultant=U.C_Userinfo_code ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
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
                strSql.Append("order by T.C_Customer_id desc");
            }
            strSql.Append(")AS Row, T.*,U.C_Userinfo_name as 'C_Customer_consultant_name' from C_Customer T left join C_Userinfo as U on T.C_Customer_consultant=U.C_Userinfo_code ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数   
        /// 2016-1-26
        /// </summary>
        /// <param name="model">客户实体</param>
        /// <param name="IsPreSetManager">是否为管理员</param>
        /// <param name="rolePowerIds">角色权限</param>
        /// <param name="userCode">登录人code</param>
        /// <param name="postCode">登录人岗位</param>
        /// <param name="deptCode">登录人部门</param>
        /// <returns></returns>
        public int GetCustomerListCount(Model.C_Customer model, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Customer as T with(nolock) ");
            if (model.C_Customer_reldatatype == 1)
            {//客户关联委托人
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_customer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else if (model.C_Customer_reldatatype == 2)
            {//委托人关联客户
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_customer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_relCustomer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else if (model.C_Customer_reldatatype == 3 && model.C_Customer_relcodes != null && model.C_Customer_relcodes.Replace(",,", "") != "")
            {//代表多客户关联多委托人
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Customer_code ");
                strSql.Append("and charindex(CAST(CC.C_Customer_Customer_customer AS nvarchar(50)),@C_Customer_Customer_customers)>0) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else
            {
                strSql.Append(" where 1=1 and C_Customer_isDelete=0 ");
            }

            if (model != null)
            {
                if (model.C_Customer_name != null)
                {
                    strSql.Append("and C_Customer_name like N'%'+@C_Customer_name+'%' ");
                }
                if (model.C_Customer_businessType != null)
                {
                    if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.客户))
                    {//客户信息列表
                        strSql.Append(" and C_Customer_businessType!=" + Convert.ToInt32(CustomerBusiness.委托人));
                    }
                    else if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.委托人))
                    {//委托人信息列表
                        strSql.Append(" and C_Customer_businessType!=" + Convert.ToInt32(CustomerBusiness.客户));
                    }
                    //strSql.Append("and C_Customer_businessType=@C_Customer_businessType ");
                }
                if (model.C_Customer_reldatatype != null)
                {

                }
                if (model.C_Customer_type != null)
                {
                    strSql.Append(" and C_Customer_type=@C_Customer_type ");
                }
                //区域的条件过滤
                if (model.C_Customer_Region_code != Guid.Empty.ToString() && model.C_Customer_Region_code != null)
                {
                    strSql.Append(" and  T.C_Customer_code in (select C_Customer_Region_customer from C_Customer_Region where C_Customer_Region_relRegion like N'%'+@C_Customer_Region_code+'%')");

                }
                #region  新增高级查询条件
                //客户级别
                if (model.C_Customer_level != null)
                {
                    strSql.Append(" and C_Customer_level=@C_Customer_level");
                }
                //最后跟进时间
                if (model.C_Customer_lastContactDate != null && model.C_Customer_lastContactEndDate != null)
                {
                    strSql.Append(" and C_Customer_lastContactDate between convert(datetime,@C_Customer_lastContactDate,120) and convert(datetime,@C_Customer_lastContactEndDate,120) ");
                }
                //专业顾问的过滤
                if (model.C_Customer_consultant != null)
                {
                    strSql.Append(" and C_Customer_consultant=@C_Customer_consultant ");
                }
                //客户类别
                if (model.C_Customer_Category != null)
                {
                    strSql.Append(" and C_Customer_Category=@C_Customer_Category");
                }
                //客户开发阶段
                if (model.C_Customer_Open != null)
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow where P_Fk_code=C_Customer_code and P_Flow_code=@C_Customer_Open)");
                }
                //客户来源
                if (model.C_Customer_source != null)
                {
                    strSql.Append(" and C_Customer_source=@C_Customer_source");
                }
                //客户忠诚度
                if (model.C_Customer_loyalty != null)
                {
                    strSql.Append(" and C_Customer_loyalty=@C_Customer_loyalty");
                }
                //是否签约
                if (model.C_Customer_isSignedState != null)
                {
                    strSql.Append(" and C_Customer_isSignedState=@C_Customer_isSignedState");
                }
                //签约状态
                if (model.C_Customer_signedState != null)
                {
                    strSql.Append(" and C_Customer_signedState=@C_Customer_signedState");
                }
                #endregion
            }
            #region  跟进时间查询条件
            if (model.C_Customer_Follow_time_type != null)
            {
                DateTime date = DateTime.Now;
                if (model.C_Customer_Follow_time_type == 1)
                {//近三个月联系过
                    strSql.Append(" and C_Customer_lastContactDate  between dateadd(mm,-3,getdate()) and getdate() ");
                }
                else if (model.C_Customer_Follow_time_type == 2)
                {//三个月前联系过
                    strSql.Append(" and   DATEDIFF(dd,DateAdd(Month,-3,getdate()),C_Customer_lastContactDate )<0 ");
                }
                else if (model.C_Customer_Follow_time_type == 3)
                {//从未联系
                    strSql.Append(" and C_Customer_lastContactDate  is null ");
                }
                else
                {//今日新增
                    strSql.Append(" and  DATEDIFF(day,C_Customer_createTime,getdate())=0 ");
                }
            }
            #endregion

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限 2016-1-26 陈盼盼
                //39.只能查看案件业务员为自己的客户
                //40.只能查看案件负责人为自己的客户
                //41.只能查看流程负责人是自己的客户
                //42.只能查看表单负责人或者副负责人为自己的客户
                //43.能查看案件业务员为该岗位组织架构下所有人的的客户
                //44.能查看用户关联区域的客户
                //54.查看关联部长的客户
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",39,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Customer As CC with(nolock) where CC.C_Customer_code=T.C_Customer_code and CC.C_Customer_isDelete=0 and CC.C_Customer_consultant=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",40,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Customer T1 where T1.C_Customer_responsiblePerson=@ThisUserCode and T1.C_Customer_code=T.C_Customer_code) ");
                }
                if (rolePowerIds.Contains(",41,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.C_Customer_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",42,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.C_Customer_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.C_Customer_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",43,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from C_Customer As CC with(nolock) where CC.C_Customer_isDelete=0 and CC.C_Customer_code=T.C_Customer_code and CC.C_Customer_consultant=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",44,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As CRR with(nolock),C_Customer_Region As CCR with(nolock) ");
                    strPowerSql.Append("where CRR.C_region_code=CCR.C_Customer_Region_relRegion ");
                    strPowerSql.Append("and CRR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Organization_code=@ThisDeptCode ");
                    strPowerSql.Append("and CRR.C_Post_code=@ThisPostCode ");
                    strPowerSql.Append("and CCR.C_Customer_Region_isDelete=0 ");
                    strPowerSql.Append("and CCR.C_Customer_Region_customer=T.C_Customer_code) ");
                }
                if (rolePowerIds.Contains(",54,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.C_Customer_responsiblePerson=CEM.C_Minister_Code) ");
                }

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            SqlParameter[] parameters = {					 
					new SqlParameter("@C_Customer_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_businessType", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Customer_customer", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_Customer_customers", SqlDbType.NVarChar,4000),
                    new SqlParameter("@C_Customer_type", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Region_code", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_consultant", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisUserCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_level",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_lastContactDate",SqlDbType.DateTime,50),
                    new SqlParameter("@C_Customer_lastContactEndDate",SqlDbType.DateTime,50),
                    new SqlParameter("@C_Customer_Category",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Open",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_source",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_loyalty",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_isSignedState",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_signedState",SqlDbType.Int,4),
				 };
            parameters[0].Value = model.C_Customer_name;
            parameters[1].Value = model.C_Customer_businessType;
            parameters[2].Value = model.C_Customer_code;
            parameters[3].Value = model.C_Customer_relcodes;
            parameters[4].Value = model.C_Customer_type;
            parameters[5].Value = model.C_Customer_Region_code;
            parameters[6].Value = model.C_Customer_consultant;
            parameters[7].Value = userCode;
            parameters[8].Value = deptCode;
            parameters[9].Value = postCode;
            parameters[10].Value = model.C_Customer_level;
            parameters[11].Value = model.C_Customer_lastContactDate;
            parameters[12].Value = model.C_Customer_lastContactEndDate;
            parameters[13].Value = model.C_Customer_Category;
            parameters[14].Value = model.C_Customer_Open;
            parameters[15].Value = model.C_Customer_source;
            parameters[16].Value = model.C_Customer_loyalty;
            parameters[17].Value = model.C_Customer_isSignedState;
            parameters[18].Value = model.C_Customer_signedState;
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
        /// 分页获取客户列表   
        /// 2016-1-26
        /// </summary>
        /// <param name="model">客户实体</param>
        /// <param name="orderby">排序</param>
        /// <param name="startIndex">开始数据数</param>
        /// <param name="endIndex">结束数据数</param>
        /// <param name="IsPreSetManager">是否为管理员</param>
        /// <param name="rolePowerIds">角色权限</param>
        /// <param name="userCode">登录人</param>
        /// <param name="postCode">登录人岗位</param>
        /// <param name="deptCode">登录人部门</param>
        /// <returns></returns>
        public DataSet GetCustomerListByPage(Model.C_Customer model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
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
                strSql.Append("order by T.C_Customer_id desc");
            }
            strSql.Append(")AS Row, T.*,U.C_Userinfo_name as 'C_Customer_consultant_name',P.C_Parameters_name as 'C_Customer_goingstatusName' from C_Customer T left join C_Userinfo as U on T.C_Customer_consultant=U.C_Userinfo_code ");
            strSql.Append(" left join C_Parameters as P on T.C_Customer_goingStatus=P.C_Parameters_id ");
            if (model.C_Customer_reldatatype == 1)
            {//客户关联委托人               
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_customer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else if (model.C_Customer_reldatatype == 2)
            {//委托人关联客户
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_customer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_relCustomer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else if (model.C_Customer_reldatatype == 3 && model.C_Customer_relcodes != null && model.C_Customer_relcodes.Replace(",,", "") != "")
            {//代表多客户关联多委托人
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Customer_code ");

                strSql.Append("and charindex(CAST(CC.C_Customer_Customer_customer AS nvarchar(50)),@C_Customer_Customer_customers)>0");

                strSql.Append(") and C_Customer_isDelete=0 ");
            }
            else
            {
                strSql.Append("where 1=1 and T.C_Customer_isDelete=0 ");
            }

            if (model != null)
            {
                if (model.C_Customer_name != null)
                {
                    strSql.Append("and T.C_Customer_name like N'%'+@C_Customer_name+'%'");

                }
                if (model.C_Customer_businessType != null)
                {
                    if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.客户))
                    {//客户信息列表
                        strSql.Append(" and C_Customer_businessType <> " + Convert.ToInt32(CustomerBusiness.委托人));
                    }
                    else if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.委托人))
                    {//委托人信息列表
                        strSql.Append(" and C_Customer_businessType <> " + Convert.ToInt32(CustomerBusiness.客户));
                    }
                    //strSql.Append("and C_Customer_businessType=@C_Customer_businessType ");
                }
                if (model.C_Customer_reldatatype != null)
                {

                }
                if (model.C_Customer_type != null)
                {
                    strSql.Append(" and C_Customer_type=@C_Customer_type ");
                }
                //区域的条件过滤
                if (model.C_Customer_Region_code != null && model.C_Customer_Region_code != Guid.Empty.ToString())
                {

                    strSql.Append(" and T.C_Customer_code in (select C_Customer_Region_customer from C_Customer_Region where C_Customer_Region_relRegion like N'%'+@C_Customer_Region_code+'%')");

                }

                #region  新增高级查询条件
                //客户级别
                if (model.C_Customer_level != null)
                {
                    strSql.Append(" and C_Customer_level=@C_Customer_level");
                }
                //最后跟进时间
                if (model.C_Customer_lastContactDate != null && model.C_Customer_lastContactEndDate != null)
                {
                    strSql.Append(" and C_Customer_lastContactDate between convert(datetime,@C_Customer_lastContactDate,120) and convert(datetime,@C_Customer_lastContactEndDate,120) ");
                }
                //专业顾问的过滤
                if (model.C_Customer_consultant != null)
                {
                    strSql.Append(" and C_Customer_consultant=@C_Customer_consultant ");
                }
                //客户类别
                if (model.C_Customer_Category != null)
                {
                    strSql.Append(" and C_Customer_Category=@C_Customer_Category");
                }
                //客户开发阶段
                if (model.C_Customer_Open != null)
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow where P_Fk_code=C_Customer_code and P_Flow_code=@C_Customer_Open)");
                }
                //客户来源
                if (model.C_Customer_source != null)
                {
                    strSql.Append(" and C_Customer_source=@C_Customer_source");
                }
                //客户忠诚度
                if (model.C_Customer_loyalty != null)
                {
                    strSql.Append(" and C_Customer_loyalty=@C_Customer_loyalty");
                }
                //是否签约
                if (model.C_Customer_isSignedState != null)
                {
                    strSql.Append(" and C_Customer_isSignedState=@C_Customer_isSignedState");
                }
                //签约状态
                if (model.C_Customer_signedState != null)
                {
                    strSql.Append(" and C_Customer_signedState=@C_Customer_signedState");
                }
                #endregion
            }
            #region  跟进时间查询条件
            if (model.C_Customer_Follow_time_type != null)
            {
                DateTime date = DateTime.Now;
                if (model.C_Customer_Follow_time_type == 1)
                {//近三个月联系过
                    strSql.Append(" and C_Customer_lastContactDate  between dateadd(mm,-3,getdate()) and getdate() ");
                }
                else if (model.C_Customer_Follow_time_type == 2)
                {//三个月前联系过
                    strSql.Append(" and   DATEDIFF(dd,DateAdd(Month,-3,getdate()),C_Customer_lastContactDate )<0 ");
                }
                else if (model.C_Customer_Follow_time_type == 3)
                {//从未联系
                    strSql.Append(" and C_Customer_lastContactDate  is null ");
                }
                else
                {//今日新增
                    strSql.Append(" and  DATEDIFF(day,C_Customer_createTime,getdate())=0 ");
                }
            }
            #endregion

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表 
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限 2016-1-26 陈盼盼
                //39.只能查看案件业务员为自己的客户
                //40.只能查看案件负责人为自己的客户
                //41.只能查看流程负责人是自己的客户
                //42.只能查看表单负责人或者副负责人为自己的客户
                //43.能查看案件业务员为该岗位组织架构下所有人的的客户
                //44.能查看用户关联区域的客户
                //54.查看关联部长的客户
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",39,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Customer As CC with(nolock) where CC.C_Customer_code=T.C_Customer_code and CC.C_Customer_isDelete=0 and CC.C_Customer_consultant=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",40,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Customer T1 where T1.C_Customer_responsiblePerson=@ThisUserCode and T1.C_Customer_code=T.C_Customer_code) ");
                }
                if (rolePowerIds.Contains(",41,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.C_Customer_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",42,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.C_Customer_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.C_Customer_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",43,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from C_Customer As CC with(nolock) where CC.C_Customer_isDelete=0 and CC.C_Customer_code=T.C_Customer_code and CC.C_Customer_consultant=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",44,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As CRR with(nolock),C_Customer_Region As CCR with(nolock) ");
                    strPowerSql.Append("where CRR.C_region_code=CCR.C_Customer_Region_relRegion ");
                    strPowerSql.Append("and CRR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Organization_code=@ThisDeptCode ");
                    strPowerSql.Append("and CRR.C_Post_code=@ThisPostCode ");
                    strPowerSql.Append("and CCR.C_Customer_Region_isDelete=0 ");
                    strPowerSql.Append("and CCR.C_Customer_Region_customer=T.C_Customer_code) ");
                }
                if (rolePowerIds.Contains(",54,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.C_Customer_responsiblePerson=CEM.C_Minister_Code) ");
                }

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            strSql.Append(" ) TT");

            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					 
					new SqlParameter("@C_Customer_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_businessType", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Customer_customer", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_Customer_customers", SqlDbType.NVarChar,4000),
                    new SqlParameter("@C_Customer_type", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Region_code", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_consultant", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisUserCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_level",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_lastContactDate",SqlDbType.DateTime,50),
                    new SqlParameter("@C_Customer_lastContactEndDate",SqlDbType.DateTime,50),
                    new SqlParameter("@C_Customer_Category",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Open",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_source",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_loyalty",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_isSignedState",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_signedState",SqlDbType.Int,4)
		    };
            parameters[0].Value = model.C_Customer_name;
            parameters[1].Value = model.C_Customer_businessType;
            parameters[2].Value = model.C_Customer_code;
            parameters[3].Value = model.C_Customer_relcodes;
            parameters[4].Value = model.C_Customer_type;
            parameters[5].Value = model.C_Customer_Region_code;
            parameters[6].Value = model.C_Customer_consultant;
            parameters[7].Value = userCode;
            parameters[8].Value = deptCode;
            parameters[9].Value = postCode;
            parameters[10].Value = model.C_Customer_level;
            parameters[11].Value = model.C_Customer_lastContactDate;
            parameters[12].Value = model.C_Customer_lastContactEndDate;
            parameters[13].Value = model.C_Customer_Category;
            parameters[14].Value = model.C_Customer_Open;
            parameters[15].Value = model.C_Customer_source;
            parameters[16].Value = model.C_Customer_loyalty;
            parameters[17].Value = model.C_Customer_isSignedState;
            parameters[18].Value = model.C_Customer_signedState;

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
            parameters[0].Value = "C_Customer";
            parameters[1].Value = "C_Customer_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  App专用
        /// <summary>
        /// 分页获取数据列表 待条件
        /// </summary>
        public DataSet AppGetListByPage(Model.C_Customer model, string orderby, int startIndex, int endIndex, string butstring, string butstring2, string FRegion, Guid? userCode, int type)
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
                strSql.Append("order by T.C_Customer_id desc");
            }
            strSql.Append(")AS Row, T.*,U.C_Userinfo_name as 'C_Customer_consultant_name',P.C_Parameters_name as 'C_Customer_goingstatusName' ");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=C_customer_loyalty) as C_customer_loyalty_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=C_customer_signedState) as C_customer_signedState_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=C_customer_source) as C_customer_source_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=C_customer_industryCode) as C_Customer_industrycode_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=C_customer_level) as C_customer_level_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=C_customer_state) as C_customer_state_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=C_customer_type) as C_customer_type_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=C_customer_category) as C_customer_category_name ");
            strSql.Append("from C_Customer T left join C_Userinfo as U on T.C_Customer_consultant=U.C_Userinfo_code ");
            strSql.Append(" left join C_Parameters as P on T.C_Customer_goingStatus=P.C_Parameters_id ");
            if (model.C_Customer_Follow_time_type != null)
            {
                DateTime date = DateTime.Now;
                string sql = "";
                if (model.C_Customer_Follow_time_type == 1)
                {
                    date = date.AddMonths(-3);
                    sql = " C_Customer_Follow_time  between getdate() and '" + date + "'";
                }
                else if (model.C_Customer_Follow_time_type == 2)
                {
                    sql = " C_Customer_Follow_time  is not null";
                }
                else
                {
                    sql = " DATEDIFF(dd,getdate(),C_Customer_Follow_time )=0 ";
                }
                if (model.C_Customer_Follow_time_type != 3)
                {
                    strSql.Append(" right join (select *　from　C_Customer_Follow  where " + sql + " ) As CCF on T.C_Customer_code=CCF.C_Customer_code ");
                }
            }
            if (model.C_Customer_reldatatype == 1)
            {//客户关联委托人               
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_customer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else if (model.C_Customer_reldatatype == 2)
            {//委托人关联客户
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_customer=C_Customer_code ");
                strSql.Append("and CC.C_Customer_Customer_relCustomer=@C_Customer_Customer_customer) ");
                strSql.Append("and C_Customer_isDelete=0 ");
            }
            else if (model.C_Customer_reldatatype == 3 && model.C_Customer_relcodes != null && model.C_Customer_relcodes.Replace(",,", "") != "")
            {//代表多客户关联多委托人
                strSql.Append("where exists(select 1 from C_Customer_Customer AS CC with(nolock) where CC.C_Customer_Customer_isDelete=0 and CC.C_Customer_Customer_relCustomer=C_Customer_code ");

                strSql.Append("and charindex(CAST(CC.C_Customer_Customer_customer AS nvarchar(50)),@C_Customer_Customer_customers)>0");

                strSql.Append(") and C_Customer_isDelete=0 ");
            }
            else
            {
                strSql.Append("where 1=1 and T.C_Customer_isDelete=0 ");
            }

            if (model != null)
            {
                if (model.C_Customer_name != null)
                {
                    strSql.Append("and T.C_Customer_name like N'%'+@C_Customer_name+'%'");

                }
                if (model.C_Customer_businessType != null)
                {
                    if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.客户))
                    {//客户信息列表
                        strSql.Append("and C_Customer_businessType <> " + Convert.ToInt32(CustomerBusiness.委托人));
                    }
                    else if (model.C_Customer_businessType == Convert.ToInt32(CustomerBusiness.委托人))
                    {//委托人信息列表
                        strSql.Append("and C_Customer_businessType <> " + Convert.ToInt32(CustomerBusiness.客户));
                    }
                    //strSql.Append("and C_Customer_businessType=@C_Customer_businessType ");
                }
                if (model.C_Customer_reldatatype != null)
                {

                }
                if (model.C_Customer_type != null)
                {
                    strSql.Append(" and C_Customer_type=@C_Customer_type ");
                }
                if (model.C_Customer_Follow_time_type == 3)
                {
                    strSql.Append(" and T.C_Customer_code not in (select C_Customer_code  from C_Customer_Follow) ");
                }
                //区域的条件过滤
                if (model.C_Customer_Region_code != null && model.C_Customer_Region_code != Guid.Empty.ToString())
                {

                    strSql.Append(" and T.C_Customer_code in (select C_Customer_Region_customer from C_Customer_Region where C_Customer_Region_relRegion like N'%'+@C_Customer_Region_code+'%')");

                }
                //专业顾问的过滤
                if (model.C_Customer_consultant != null)
                {
                    strSql.Append(" and C_Customer_consultant like N'%'+convert(varchar(100),@C_Customer_consultant)+'%' ");
                }

                //客户GUID或者委托人GUID
                if (model.C_Customer_code != null)
                {
                    if (type == 1) //客户获取委托人列表
                    {
                        strSql.Append(" and C_Customer_code in(select C_Customer_Customer_relCustomer from C_Customer_Customer where C_Customer_Customer_customer=@C_Customer_code)");
                    }
                    else if (type == 2) //委托人获取客户列表
                    {
                        strSql.Append(" and C_Customer_code in(select C_Customer_Customer_customer from C_Customer_Customer where C_Customer_Customer_relCustomer=@C_Customer_code)");
                    }
                }
            }
            if (model.C_Customer_relcodes != null && model.C_Customer_relcodes.Replace(",,", "") != "")
            { }
            else
            {
                if (butstring != "")
                {
                    strSql.Append("and '" + butstring + "' like '%'+convert(varchar(100),C_Customer_consultant)+'%'");
                }
                //获取当前选择组织架构下匹配的专业顾问的客户
                if (butstring2 != "")
                {
                    strSql.Append("and '" + butstring2 + "' like '%'+convert(varchar(100),C_Customer_consultant)+'%' ");
                }
                if (FRegion != "")
                {
                    strSql.Append("and exists(select 1 from C_Customer_region where C_Customer_Region_customer=T.C_Customer_code and C_Customer_Region_relRegion in (select C_Region_code from C_Userinfo_region where C_Userinfo_code=@userCode))");
                    //strSql.Append(" and @FRegion like '%'+convert(varchar(100),(select top 1 C_Customer_Region_relRegion from C_Customer_Region where C_Customer_Region.C_Customer_Region_customer=T.C_Customer_code))+'%' ");
                }
            }
            strSql.Append(" ) TT");

            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					 
					new SqlParameter("@C_Customer_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_businessType", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Customer_customer", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_Customer_customers", SqlDbType.NVarChar,4000),
                    new SqlParameter("@C_Customer_type", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Region_code", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_consultant", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@FRegion",SqlDbType.VarChar,50),
                    new SqlParameter("@userCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_code",SqlDbType.UniqueIdentifier,16)
		    };
            parameters[0].Value = model.C_Customer_name;
            parameters[1].Value = model.C_Customer_businessType;
            parameters[2].Value = model.C_Customer_code;
            parameters[3].Value = model.C_Customer_relcodes;
            parameters[4].Value = model.C_Customer_type;
            parameters[5].Value = model.C_Customer_Region_code;
            parameters[6].Value = model.C_Customer_consultant;
            parameters[7].Value = FRegion;
            parameters[8].Value = userCode;
            parameters[9].Value = model.C_Customer_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        #endregion
    }
}
