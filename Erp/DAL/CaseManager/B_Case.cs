using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using CommonService.Common;
using CommonService.Model.Reporting;//Please add references
namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:案件表
    /// 作者：崔慧栋
    /// 日期：2015/05/12
    /// </summary>
    public partial class B_Case
    {
        public B_Case()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("B_Case_id", "B_Case");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Case");
            strSql.Append(" where B_Case_id=@B_Case_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Case(");
            strSql.Append("B_Case_name,B_Case_number,B_Case_code,B_Case_contractNo,B_Case_type,B_Case_nature,B_Case_customerType,B_Case_registerTime,B_Case_remark,");
            strSql.Append("B_Case_state,B_Case_transferTargetMoney,B_Case_transferTargetOther,B_Case_expectedGrant,B_Case_execMoney,B_Case_execOther,B_Case_courtFirst,");
            strSql.Append("B_Case_courtSecond,B_Case_courtExec,B_Case_Trial,B_Case_Requirement,B_Case_Remarks,B_Case_person,B_Case_planStartTime,B_Case_planEndTime,");
            strSql.Append("B_Case_factStartTime,B_Case_factEndTime,B_Case_creator,B_Case_createTime,B_Case_isDelete,B_Case_consultant_code,B_Case_levelType,B_Case_firstClassResponsiblePerson,B_Case_businessChance_Code,B_Case_isSure,B_Case_sureDate)");
            strSql.Append(" values (");
            strSql.Append("@B_Case_name,@B_Case_number,@B_Case_code,@B_Case_contractNo,@B_Case_type,@B_Case_nature,@B_Case_customerType,@B_Case_registerTime,@B_Case_remark,");
            strSql.Append("@B_Case_state,@B_Case_transferTargetMoney,@B_Case_transferTargetOther,@B_Case_expectedGrant,@B_Case_execMoney,@B_Case_execOther,@B_Case_courtFirst,");
            strSql.Append("@B_Case_courtSecond,@B_Case_courtExec,@B_Case_Trial,@B_Case_Requirement,@B_Case_Remarks,@B_Case_person,@B_Case_planStartTime,@B_Case_planEndTime,");
            strSql.Append("@B_Case_factStartTime,@B_Case_factEndTime,@B_Case_creator,@B_Case_createTime,@B_Case_isDelete,@B_Case_consultant_code,@B_Case_levelType,@B_Case_firstClassResponsiblePerson,@B_Case_businessChance_Code,@B_Case_isSure,@B_Case_sureDate)");
            strSql.Append(";select @@IDENTITY");

            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_number", SqlDbType.VarChar,50),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_contractNo", SqlDbType.VarChar,50),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
					new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_remark", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_state", SqlDbType.Int,4),
					new SqlParameter("@B_Case_transferTargetMoney", SqlDbType.Decimal,9),
					new SqlParameter("@B_Case_transferTargetOther", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_expectedGrant", SqlDbType.Decimal,9),
					new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,9),
					new SqlParameter("@B_Case_execOther", SqlDbType.VarChar,500),
                    new SqlParameter("@B_Case_courtFirst",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_courtSecond",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_courtExec",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Trial",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Requirement",SqlDbType.NVarChar,3000),
                    new SqlParameter("@B_Case_Remarks",SqlDbType.NVarChar,200),
					new SqlParameter("@B_Case_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_person",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_planStartTime",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_planEndTime",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_factStartTime",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_factEndTime",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_consultant_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_levelType",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_firstClassResponsiblePerson",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_businessChance_Code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_isSure",SqlDbType.Bit,1),
                    new SqlParameter("@B_Case_sureDate",SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_number;
            parameters[2].Value = model.B_Case_code;
            parameters[3].Value = model.B_Case_contractNo;
            parameters[4].Value = model.B_Case_type;
            parameters[5].Value = model.B_Case_nature;
            parameters[6].Value = model.B_Case_customerType;
            parameters[7].Value = model.B_Case_registerTime;
            parameters[8].Value = model.B_Case_remark;
            parameters[9].Value = model.B_Case_state;
            parameters[10].Value = model.B_Case_transferTargetMoney;
            parameters[11].Value = model.B_Case_transferTargetOther;
            parameters[12].Value = model.B_Case_expectedGrant;
            parameters[13].Value = model.B_Case_execMoney;
            parameters[14].Value = model.B_Case_execOther;
            parameters[15].Value = model.B_Case_courtFirst;
            parameters[16].Value = model.B_Case_courtSecond;
            parameters[17].Value = model.B_Case_courtExec;
            parameters[18].Value = model.B_Case_Trial;
            parameters[19].Value = model.B_Case_Requirement;
            parameters[20].Value = model.B_Case_Remarks;
            parameters[21].Value = model.B_Case_creator;
            parameters[22].Value = model.B_Case_createTime;
            parameters[23].Value = model.B_Case_isDelete;
            parameters[24].Value = model.B_Case_person;
            parameters[25].Value = model.B_Case_planStartTime;
            parameters[26].Value = model.B_Case_planEndTime;
            parameters[27].Value = model.B_Case_factStartTime;
            parameters[28].Value = model.B_Case_factEndTime;
            parameters[29].Value = model.B_Case_consultant_code;
            parameters[30].Value = model.B_Case_levelType;
            parameters[31].Value = model.B_Case_firstClassResponsiblePerson;
            parameters[32].Value = model.B_Case_businessChance_Code;
            parameters[33].Value = model.B_Case_isSure;
            parameters[34].Value = model.B_Case_sureDate;
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
        public bool Update(CommonService.Model.CaseManager.B_Case model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case set ");
            strSql.Append("B_Case_name=@B_Case_name,");
            strSql.Append("B_Case_number=@B_Case_number,");
            strSql.Append("B_Case_code=@B_Case_code,");
            strSql.Append("B_Case_contractNo=@B_Case_contractNo,");
            strSql.Append("B_Case_type=@B_Case_type,");
            strSql.Append("B_Case_nature=@B_Case_nature,");
            strSql.Append("B_Case_customerType=@B_Case_customerType,");
            strSql.Append("B_Case_registerTime=@B_Case_registerTime,");
            strSql.Append("B_Case_remark=@B_Case_remark,");
            strSql.Append("B_Case_state=@B_Case_state,");
            strSql.Append("B_Case_transferTargetMoney=@B_Case_transferTargetMoney,");
            strSql.Append("B_Case_transferTargetOther=@B_Case_transferTargetOther,");
            strSql.Append("B_Case_expectedGrant=@B_Case_expectedGrant,");
            strSql.Append("B_Case_execMoney=@B_Case_execMoney,");
            strSql.Append("B_Case_execOther=@B_Case_execOther,");
            strSql.Append("B_Case_courtFirst=@B_Case_courtFirst,");
            strSql.Append("B_Case_courtSecond=@B_Case_courtSecond,");
            strSql.Append("B_Case_courtExec=@B_Case_courtExec,");
            strSql.Append("B_Case_Trial=@B_Case_Trial,");
            strSql.Append("B_Case_Requirement=@B_Case_Requirement,");
            strSql.Append("B_Case_Remarks=@B_Case_Remarks,");
            strSql.Append("B_Case_person=@B_Case_person,");
            strSql.Append("B_Case_planStartTime=@B_Case_planStartTime,");
            strSql.Append("B_Case_planEndTime=@B_Case_planEndTime,");
            strSql.Append("B_Case_factStartTime=@B_Case_factStartTime,");
            strSql.Append("B_Case_factEndTime=@B_Case_factEndTime,");
            strSql.Append("B_Case_creator=@B_Case_creator,");
            strSql.Append("B_Case_createTime=@B_Case_createTime,");
            strSql.Append("B_Case_isDelete=@B_Case_isDelete,");
            strSql.Append("B_Case_consultant_code=@B_Case_consultant_code,");
            strSql.Append("B_Case_levelType=@B_Case_levelType,");
            strSql.Append("B_Case_firstClassResponsiblePerson=@B_Case_firstClassResponsiblePerson,");
            strSql.Append("B_Case_businessChance_Code=@B_Case_businessChance_Code, ");
            strSql.Append("B_Case_isSure=@B_Case_isSure, ");
            strSql.Append("B_Case_sureDate=@B_Case_sureDate ");
            strSql.Append(" where B_Case_id=@B_Case_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_number", SqlDbType.VarChar,50),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_contractNo", SqlDbType.VarChar,50),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
					new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_remark", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_state", SqlDbType.Int,4),
					new SqlParameter("@B_Case_transferTargetMoney", SqlDbType.Decimal,9),
					new SqlParameter("@B_Case_transferTargetOther", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_expectedGrant", SqlDbType.Decimal,9),
					new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,9),
					new SqlParameter("@B_Case_execOther", SqlDbType.VarChar,500),
                    new SqlParameter("@B_Case_courtFirst",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_courtSecond",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_courtExec",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Trial",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Requirement",SqlDbType.NVarChar,3000),
                    new SqlParameter("@B_Case_Remarks",SqlDbType.NVarChar,200),
					new SqlParameter("@B_Case_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_Case_id", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_person",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_planStartTime",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_planEndTime",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_factStartTime",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_factEndTime",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_consultant_code",SqlDbType.UniqueIdentifier),
                    new SqlParameter("@B_Case_levelType",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_firstClassResponsiblePerson",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_businessChance_Code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_isSure",SqlDbType.Bit,1),
                    new SqlParameter("@B_Case_sureDate",SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_number;
            parameters[2].Value = model.B_Case_code;
            parameters[3].Value = model.B_Case_contractNo;
            parameters[4].Value = model.B_Case_type;
            parameters[5].Value = model.B_Case_nature;
            parameters[6].Value = model.B_Case_customerType;
            parameters[7].Value = model.B_Case_registerTime;
            parameters[8].Value = model.B_Case_remark;
            parameters[9].Value = model.B_Case_state;
            parameters[10].Value = model.B_Case_transferTargetMoney;
            parameters[11].Value = model.B_Case_transferTargetOther;
            parameters[12].Value = model.B_Case_expectedGrant;
            parameters[13].Value = model.B_Case_execMoney;
            parameters[14].Value = model.B_Case_execOther;
            parameters[15].Value = model.B_Case_courtFirst;
            parameters[16].Value = model.B_Case_courtSecond;
            parameters[17].Value = model.B_Case_courtExec;
            parameters[18].Value = model.B_Case_Trial;
            parameters[19].Value = model.B_Case_Requirement;
            parameters[20].Value = model.B_Case_Remarks;
            parameters[21].Value = model.B_Case_creator;
            parameters[22].Value = model.B_Case_createTime;
            parameters[23].Value = model.B_Case_isDelete;
            parameters[24].Value = model.B_Case_id;
            parameters[25].Value = model.B_Case_person;
            parameters[26].Value = model.B_Case_planStartTime;
            parameters[27].Value = model.B_Case_planEndTime;
            parameters[28].Value = model.B_Case_factStartTime;
            parameters[29].Value = model.B_Case_factEndTime;
            parameters[30].Value = model.B_Case_consultant_code;
            parameters[31].Value = model.B_Case_levelType;
            parameters[32].Value = model.B_Case_firstClassResponsiblePerson;
            parameters[33].Value = model.B_Case_businessChance_Code;
            parameters[34].Value = model.B_Case_isSure;
            parameters[35].Value = model.B_Case_sureDate;
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
        /// 修改案件进行状态
        /// </summary>
        public bool UpdateState(Guid B_Case_code, int B_Case_state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case set ");
            strSql.Append("B_Case_state=@B_Case_state ");
            strSql.Append(" where B_Case_code=@B_Case_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_state", SqlDbType.Int,4)};
            parameters[0].Value = B_Case_code;
            parameters[1].Value = B_Case_state;

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
        /// 修改预期收益金额
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="expectedGrant">预期收益金额</param>
        /// <returns></returns>
        public bool UpdateExpectedGrant(Guid caseCode, Decimal expectedGrant)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case set ");
            strSql.Append("B_Case_expectedGrant=@expectedGrant ");
            strSql.Append(" where B_Case_code=@caseCode");
            SqlParameter[] parameters = {
					new SqlParameter("@expectedGrant", SqlDbType.Decimal),
					new SqlParameter("@caseCode", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = expectedGrant;
            parameters[1].Value = caseCode;

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
        public bool Delete(Guid B_Case_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case set B_Case_isDelete=1 ");
            strSql.Append(" where B_Case_code=@B_Case_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_code;

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
        public bool DeleteList(string B_Case_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case ");
            strSql.Append(" where B_Case_id in (" + B_Case_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_Case GetModel(int B_Case_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_id,B_Case_name,B_Case_number,B_Case_code,B_Case_contractNo,B_Case_type,B_Case_nature,B_Case_customerType,B_Case_registerTime,B_Case_remark,");
            strSql.Append("B_Case_state,B_Case_transferTargetMoney,B_Case_transferTargetOther,B_Case_expectedGrant,B_Case_execMoney,B_Case_execOther,B_Case_courtFirst,B_Case_courtSecond,");
            strSql.Append("B_Case_courtExec,B_Case_Trial,B_Case_Requirement,B_Case_Remarks,B_Case_person,B_Case_planStartTime,B_Case_planEndTime,B_Case_creator,B_Case_createTime,");
            strSql.Append("B_Case_factStartTime,B_Case_factEndTime,B_Case_isDelete,B_Case_consultant_code,B_Case_levelType,B_Case_firstClassResponsiblePerson,B_Case_businessChance_Code,B_Case_isSure,B_Case_sureDate from B_Case ");
            strSql.Append(" where B_Case_id=@B_Case_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_id;

            CommonService.Model.CaseManager.B_Case model = new CommonService.Model.CaseManager.B_Case();
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
        public CommonService.Model.CaseManager.B_Case GetModel(Guid B_Case_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C.*,C1.C_Court_name as B_Case_courtFirstName,C2.C_Court_name as B_Case_courtSecondName,C3.C_Court_name as B_Case_courtExecName,C4.C_Court_name as B_Case_TrialName,");
            strSql.Append("P.C_Parameters_name As B_Case_type_name,BC.B_BusinessChance_name as 'B_Case_businessChance_Name',U1.C_Userinfo_name as 'B_Case_personName',U2.C_Userinfo_name as 'C_Case_firstClassResponsiblePersonName',");
            strSql.Append("(select count(1) from M_Entry_Statistics As S with(nolock),M_Entry_Change As EC with(nolock) where S.M_Entry_Statistics_code=EC.M_Entry_Statistics_code and S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=C.B_Case_code and EC.M_Entry_Change_IsThrough<>328) As B_Case_Delay_Entry_Statistics_Count,");
            strSql.Append("(select count(1) from M_Entry_Statistics As S with(nolock) where S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=C.B_Case_code and S.M_Entry_Statistics_HandlingState=470) As B_Case_HandlingState_Entry_Statistics_Count,");
            strSql.Append("(select count(1) from M_Entry_Statistics As S with(nolock) where S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=C.B_Case_code and S.M_Entry_Statistics_warningSituation=464) As B_Case_WarningSituation_Entry_Statistics_Count ");
            strSql.Append("from B_Case as C left join C_Court as C1 on C1.C_Court_code=C.B_Case_courtFirst ");
            strSql.Append("left join C_Court as C2 on C2.C_Court_code=C.B_Case_courtSecond ");
            strSql.Append("left join C_Court as C3 on C3.C_Court_code=C.B_Case_courtExec ");
            strSql.Append("left join C_Court as C4 on C4.C_Court_code=C.B_Case_Trial ");
            strSql.Append("left join C_Parameters as P WITH(NOLOCK) on C.B_Case_type=P.C_Parameters_id ");
            strSql.Append("left join B_BusinessChance as BC on C.B_Case_businessChance_Code=BC.B_BusinessChance_code ");
            strSql.Append("left join C_Userinfo as U1 on C.B_Case_person=U1.C_Userinfo_code ");
            strSql.Append("left join C_Userinfo as U2 on C.B_Case_firstClassResponsiblePerson=U2.C_Userinfo_code ");
            strSql.Append("where C.B_Case_isDelete=0 and C.B_Case_code=@B_Case_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_code;

            CommonService.Model.CaseManager.B_Case model = new CommonService.Model.CaseManager.B_Case();
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
        public CommonService.Model.CaseManager.B_Case GetModelByNumber(string B_Case_number)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_id,B_Case_name,B_Case_number,B_Case_code,B_Case_contractNo,B_Case_type,B_Case_nature,B_Case_customerType,B_Case_registerTime,B_Case_remark,");
            strSql.Append("B_Case_state,B_Case_transferTargetMoney,B_Case_transferTargetOther,B_Case_expectedGrant,B_Case_execMoney,B_Case_execOther,B_Case_courtFirst,B_Case_courtSecond,");
            strSql.Append("B_Case_courtExec,B_Case_Trial,B_Case_Requirement,B_Case_Remarks,B_Case_person,B_Case_planStartTime,B_Case_planEndTime,B_Case_creator,B_Case_createTime,");
            strSql.Append("B_Case_factStartTime,B_Case_factEndTime,B_Case_isDelete,B_Case_consultant_code,B_Case_levelType,B_Case_firstClassResponsiblePerson,B_Case_businessChance_Code,B_Case_isSure,B_Case_sureDate from B_Case ");
            strSql.Append(" where B_Case_number like N'%'+@B_Case_number+'%' order by B_Case_number desc ");
            SqlParameter[] parameters = {//
					new SqlParameter("@B_Case_number", SqlDbType.VarChar)
			};
            parameters[0].Value = B_Case_number;

            CommonService.Model.CaseManager.B_Case model = new CommonService.Model.CaseManager.B_Case();
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
        public CommonService.Model.CaseManager.B_Case DataRowToModel(DataRow row)
        {
            CommonService.Model.CaseManager.B_Case model = new CommonService.Model.CaseManager.B_Case();
            if (row != null)
            {
                if (row["B_Case_id"] != null && row["B_Case_id"].ToString() != "")
                {
                    model.B_Case_id = int.Parse(row["B_Case_id"].ToString());
                }
                if (row["B_Case_name"] != null)
                {
                    model.B_Case_name = row["B_Case_name"].ToString();
                }
                if (row["B_Case_number"] != null)
                {
                    model.B_Case_number = row["B_Case_number"].ToString();
                }
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString() != "")
                {
                    model.B_Case_code = new Guid(row["B_Case_code"].ToString());
                }
                if (row["B_Case_contractNo"] != null)
                {
                    model.B_Case_contractNo = row["B_Case_contractNo"].ToString();
                }
                if (row["B_Case_type"] != null && row["B_Case_type"].ToString() != "")
                {
                    model.B_Case_type = int.Parse(row["B_Case_type"].ToString());
                }
                //检查案件类型名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_type_name"))
                {
                    if (row["B_Case_type_name"] != null)
                    {
                        model.B_Case_type_name = row["B_Case_type_name"].ToString();
                    }
                }
                //检查案件类型名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("Ischeck"))
                {
                    if (row["Ischeck"] != null)
                    {
                        model.Ischeck = Convert.ToInt32(row["Ischeck"]);
                    }
                }
                //检查案件类型名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("Ischeck2"))
                {
                    if (row["Ischeck2"] != null)
                    {
                        model.Ischeck2 = row["Ischeck2"].ToString();
                    }
                }
                //检查案件类型名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("Ischeck3"))
                {
                    if (row["Ischeck3"] != null)
                    {
                        model.Ischeck3 = row["Ischeck3"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("M_Entry_Statistics_Management"))
                {
                    if (row["M_Entry_Statistics_Management"] != null && row["M_Entry_Statistics_Management"].ToString() != "")
                    {

                        model.M_Entry_Statistics_Management = Convert.ToInt32(row["M_Entry_Statistics_Management"]);
                    }
                }

                if (row["B_Case_nature"] != null && row["B_Case_nature"].ToString() != "")
                {
                    model.B_Case_nature = int.Parse(row["B_Case_nature"].ToString());
                }
                if (row["B_Case_customerType"] != null && row["B_Case_customerType"].ToString() != "")
                {
                    model.B_Case_customerType = int.Parse(row["B_Case_customerType"].ToString());
                }
                if (row["B_Case_registerTime"] != null && row["B_Case_registerTime"].ToString() != "")
                {
                    model.B_Case_registerTime = DateTime.Parse(row["B_Case_registerTime"].ToString());
                }
                if (row["B_Case_remark"] != null)
                {
                    model.B_Case_remark = row["B_Case_remark"].ToString();
                }
                if (row["B_Case_state"] != null && row["B_Case_state"].ToString() != "")
                {
                    model.B_Case_state = int.Parse(row["B_Case_state"].ToString());
                }
                //检查案件状态(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_state_name"))
                {
                    if (row["B_Case_state_name"] != null)
                    {
                        model.B_Case_state_name = row["B_Case_state_name"].ToString();
                    }
                }
                if (row["B_Case_transferTargetMoney"] != null && row["B_Case_transferTargetMoney"].ToString() != "")
                {
                    model.B_Case_transferTargetMoney = decimal.Parse(row["B_Case_transferTargetMoney"].ToString());
                }
                if (row["B_Case_transferTargetOther"] != null)
                {
                    model.B_Case_transferTargetOther = row["B_Case_transferTargetOther"].ToString();
                }
                if (row["B_Case_expectedGrant"] != null && row["B_Case_expectedGrant"].ToString() != "")
                {
                    model.B_Case_expectedGrant = decimal.Parse(row["B_Case_expectedGrant"].ToString());
                }
                //检查文书收入(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_wenshuInCome"))
                {
                    if (row["B_Case_wenshuInCome"] != null && row["B_Case_wenshuInCome"].ToString() != "")
                    {
                        model.B_Case_wenshuInCome = decimal.Parse(row["B_Case_wenshuInCome"].ToString());
                    }
                }
                //检查逾期收入(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_yuqiInCome"))
                {
                    if (row["B_Case_yuqiInCome"] != null && row["B_Case_yuqiInCome"].ToString() != "")
                    {
                        model.B_Case_yuqiInCome = decimal.Parse(row["B_Case_yuqiInCome"].ToString());
                    }
                }

                if (row["B_Case_execMoney"] != null && row["B_Case_execMoney"].ToString() != "")
                {
                    model.B_Case_execMoney = decimal.Parse(row["B_Case_execMoney"].ToString());
                }
                if (row["B_Case_execOther"] != null)
                {
                    model.B_Case_execOther = row["B_Case_execOther"].ToString();
                }
                if (row["B_Case_courtFirst"] != null && row["B_Case_courtFirst"].ToString() != "")
                {
                    model.B_Case_courtFirst = new Guid(row["B_Case_courtFirst"].ToString());
                }
                if (row.Table.Columns.Contains("B_Case_courtFirstName"))
                {
                    model.B_Case_courtFirstName = row["B_Case_courtFirstName"].ToString();
                }
                if (row["B_Case_courtSecond"] != null && row["B_Case_courtSecond"].ToString() != "")
                {
                    model.B_Case_courtSecond = new Guid(row["B_Case_courtSecond"].ToString());
                }
                if (row.Table.Columns.Contains("B_Case_courtSecondName"))
                {
                    model.B_Case_courtSecondName = row["B_Case_courtSecondName"].ToString();
                }
                if (row["B_Case_courtExec"] != null && row["B_Case_courtExec"].ToString() != "")
                {
                    model.B_Case_courtExec = new Guid(row["B_Case_courtExec"].ToString());
                }
                if (row.Table.Columns.Contains("B_Case_courtExecName"))
                {
                    model.B_Case_courtExecName = row["B_Case_courtExecName"].ToString();
                }
                if (row["B_Case_Trial"] != null && row["B_Case_Trial"].ToString() != "")
                {
                    model.B_Case_Trial = new Guid(row["B_Case_Trial"].ToString());
                }
                if (row.Table.Columns.Contains("B_Case_TrialName"))
                {
                    model.B_Case_TrialName = row["B_Case_TrialName"].ToString();
                }
                if (row["B_Case_Requirement"] != null && row["B_Case_Requirement"].ToString() != "")
                {
                    model.B_Case_Requirement = row["B_Case_Requirement"].ToString();
                }
                if (row["B_Case_Remarks"] != null && row["B_Case_Remarks"].ToString() != "")
                {
                    model.B_Case_Remarks = row["B_Case_Remarks"].ToString();
                }
                if (row.Table.Columns.Contains("B_Case_person"))
                {
                    if (row["B_Case_person"] != null && row["B_Case_person"].ToString() != "")
                    {
                        model.B_Case_person = new Guid(row["B_Case_person"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("B_Case_personName"))
                {//部长名称
                    if (row["B_Case_personName"] != null && row["B_Case_personName"].ToString() != "")
                    {
                        model.B_Case_personName = row["B_Case_personName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Case_firstClassResponsiblePersonName"))
                {//首席名称
                    if (row["C_Case_firstClassResponsiblePersonName"] != null && row["C_Case_firstClassResponsiblePersonName"].ToString() != "")
                    {
                        model.C_Case_firstClassResponsiblePersonName = row["C_Case_firstClassResponsiblePersonName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_Case_planStartTime"))
                {
                    if (row["B_Case_planStartTime"] != null && row["B_Case_planStartTime"].ToString() != "")
                    {
                        model.B_Case_planStartTime = DateTime.Parse(row["B_Case_planStartTime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("B_Case_planEndTime"))
                {
                    if (row["B_Case_planEndTime"] != null && row["B_Case_planEndTime"].ToString() != "")
                    {
                        model.B_Case_planEndTime = DateTime.Parse(row["B_Case_planEndTime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("B_Case_factStartTime"))
                {
                    if (row["B_Case_factStartTime"] != null && row["B_Case_factStartTime"].ToString() != "")
                    {
                        model.B_Case_factStartTime = DateTime.Parse(row["B_Case_factStartTime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("B_Case_factEndTime"))
                {
                    if (row["B_Case_factEndTime"] != null && row["B_Case_factEndTime"].ToString() != "")
                    {
                        model.B_Case_factEndTime = DateTime.Parse(row["B_Case_factEndTime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("B_Case_creator"))
                {
                    if (row["B_Case_creator"] != null && row["B_Case_creator"].ToString() != "")
                    {
                        model.B_Case_creator = new Guid(row["B_Case_creator"].ToString());
                    }
                }
                if (row["B_Case_createTime"] != null && row["B_Case_createTime"].ToString() != "")
                {
                    model.B_Case_createTime = DateTime.Parse(row["B_Case_createTime"].ToString());
                }
                if (row["B_Case_isDelete"] != null && row["B_Case_isDelete"].ToString() != "")
                {
                    model.B_Case_isDelete = int.Parse(row["B_Case_isDelete"].ToString());
                }
                //检查关联GUID(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_relationCode"))
                {
                    if (row["B_Case_relationCode"] != null && row["B_Case_relationCode"].ToString() != "")
                    {
                        model.B_Case_relationCode = new Guid(row["B_Case_relationCode"].ToString());
                    }
                }
                if (row["B_Case_levelType"] != null && row["B_Case_levelType"].ToString() != "")
                {
                    model.B_Case_levelType = int.Parse(row["B_Case_levelType"].ToString());
                }
                if (row["B_Case_firstClassResponsiblePerson"] != null && row["B_Case_firstClassResponsiblePerson"].ToString() != "")
                {
                    model.B_Case_firstClassResponsiblePerson = new Guid(row["B_Case_firstClassResponsiblePerson"].ToString());
                }
                if (row["B_Case_businessChance_Code"] != null && row["B_Case_businessChance_Code"].ToString() != "")
                {
                    model.B_Case_businessChance_Code = new Guid(row["B_Case_businessChance_Code"].ToString());
                }
                if (row.Table.Columns.Contains("B_Case_businessChance_Name"))
                {
                    if (row["B_Case_businessChance_Name"] != null && row["B_Case_businessChance_Name"].ToString() != "")
                    {
                        model.B_Case_businessChance_Name = row["B_Case_businessChance_Name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("P_business_flow_name"))
                {
                    if (row["P_business_flow_name"] != null && row["P_business_flow_name"].ToString() != "")
                    {
                        model.P_business_flow_name = row["P_business_flow_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("F_form_name"))
                {
                    if (row["F_form_name"] != null && row["F_form_name"].ToString() != "")
                    {
                        model.F_form_name = row["F_form_name"].ToString();
                    }
                }

                if (row["B_Case_isSure"] != null && row["B_Case_isSure"].ToString() != "")
                {
                    if ((row["B_Case_isSure"].ToString() == "1") || (row["B_Case_isSure"].ToString().ToLower() == "true"))
                    {
                        model.B_Case_isSure = true;
                    }
                    else
                    {
                        model.B_Case_isSure = false;
                    }
                }

                if (row["B_Case_sureDate"] != null && row["B_Case_sureDate"] != DBNull.Value)
                {
                    model.B_Case_sureDate = Convert.ToDateTime(row["B_Case_sureDate"]);
                }
                //检查延期进程条目统计数量(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_Delay_Entry_Statistics_Count"))
                {
                    if (row["B_Case_Delay_Entry_Statistics_Count"] != null && row["B_Case_Delay_Entry_Statistics_Count"].ToString() != "")
                    {
                        model.B_Case_Delay_Entry_Statistics_Count = int.Parse(row["B_Case_Delay_Entry_Statistics_Count"].ToString());
                    }
                }
                //检查办理状态条目统计数量(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_HandlingState_Entry_Statistics_Count"))
                {
                    if (row["B_Case_HandlingState_Entry_Statistics_Count"] != null && row["B_Case_HandlingState_Entry_Statistics_Count"].ToString() != "")
                    {
                        model.B_Case_HandlingState_Entry_Statistics_Count = int.Parse(row["B_Case_HandlingState_Entry_Statistics_Count"].ToString());
                    }
                }
                //检查预警情况条目统计数量(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_WarningSituation_Entry_Statistics_Count"))
                {
                    if (row["B_Case_WarningSituation_Entry_Statistics_Count"] != null && row["B_Case_WarningSituation_Entry_Statistics_Count"].ToString() != "")
                    {
                        model.B_Case_WarningSituation_Entry_Statistics_Count = int.Parse(row["B_Case_WarningSituation_Entry_Statistics_Count"].ToString());
                    }
                }
                //检查案件是否被稽查(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_IsCheckAuthority"))
                {
                    if (row["B_Case_IsCheckAuthority"] != null && row["B_Case_IsCheckAuthority"].ToString() != "")
                    {
                        if ((row["B_Case_IsCheckAuthority"].ToString() == "1") || (row["B_Case_IsCheckAuthority"].ToString().ToLower() == "true"))
                        {
                            model.B_Case_IsCheckAuthority = true;
                        }
                        else
                        {
                            model.B_Case_IsCheckAuthority = false;
                        }
                    }
                }

                if (row.Table.Columns.Contains("B_Case_caseGrade"))
                {
                    if (row["B_Case_caseGrade"] != null && row["B_Case_caseGrade"].ToString() != "")
                    {
                        model.B_Case_caseGrade = row["B_Case_caseGrade"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_Case_isNotAudited"))
                {
                    if (row["B_Case_isNotAudited"] != null && row["B_Case_isNotAudited"].ToString() != "")
                    {
                        model.B_Case_isNotAudited = Convert.ToInt32(row["B_Case_isNotAudited"].ToString());
                    }
                }

                //检查案件专业顾问(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_consultant_name"))
                {
                    if (row["B_Case_consultant_name"] != null)
                    {
                        model.B_Case_consultant_name = row["B_Case_consultant_name"].ToString();
                    }
                }
                //检查案件区域(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Region_name"))
                {
                    if (row["C_Region_name"] != null)
                    {
                        model.C_Region_name = row["C_Region_name"].ToString();
                    }
                }
                //检查案件办案阶段名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_StageName"))
                {
                    if (row["B_Case_StageName"] != null)
                    {
                        model.B_Case_StageName = row["B_Case_StageName"].ToString();
                    }
                }
                //检查案件原告名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Client_name"))
                {
                    if (row["C_Client_name"] != null)
                    {
                        model.C_Client_name = row["C_Client_name"].ToString();
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
            strSql.Append("select B_Case_id,B_Case_name,B_Case_number,B_Case_code,B_Case_contractNo,B_Case_type,B_Case_nature,B_Case_customerType,B_Case_registerTime,B_Case_remark,B_Case_state,B_Case_transferTargetMoney,B_Case_transferTargetOther,B_Case_expectedGrant,B_Case_execMoney,B_Case_execOther,B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial,B_Case_Requirement,B_Case_Remarks,B_Case_creator,B_Case_createTime,B_Case_isDelete,B_Case_consultant_code,B_Case_levelType,B_Case_firstClassResponsiblePerson,B_Case_businessChance_Code,B_Case_isSure,B_Case_sureDate ");
            strSql.Append(" FROM B_Case ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得全部数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM B_Case ");
            strSql.Append("where B_Case_isDelete=0 ");
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
            strSql.Append(" B_Case_id,B_Case_name,B_Case_number,B_Case_code,B_Case_contractNo,B_Case_type,B_Case_nature,B_Case_customerType,B_Case_registerTime,B_Case_remark,B_Case_state,B_Case_transferTargetMoney,B_Case_transferTargetOther,B_Case_expectedGrant,B_Case_execMoney,B_Case_execOther,B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial,B_Case_Requirement,B_Case_Remarks,B_Case_creator,B_Case_createTime,B_Case_isDelete,B_Case_consultant_code,B_Case_levelType,B_Case_firstClassResponsiblePerson,B_Case_businessChance_Code,B_Case_isSure,B_Case_sureDate ");
            strSql.Append(" FROM B_Case ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据专业顾问获得信息
        /// </summary>
        /// <param name="consultantCode">专业顾问Guid</param>
        /// <returns></returns>
        public DataSet GetListByConsultant(Guid consultantCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.* ");
            strSql.Append(" FROM B_Case as T ");
            strSql.Append("where B_Case_isDelete=0 ");
            strSql.Append("and exists(select 1 from B_Case_link as CL where T.B_Case_code=CL.B_Case_code and CL.B_Case_link_isDelete=0 and CL.B_Case_link_type=11 and CL.C_FK_code=@C_FK_code)");
            SqlParameter[] parameters = {
					new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = consultantCode;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, string rolePowerIds, int? roleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) FROM ( ");
            strSql.Append(" SELECT ");

            if (model.B_Case_oprationtype == 1)
            {//案件列表
                strSql.Append(" T.*  from B_Case T ");
                if (model != null)
                {
                    //办案阶段限制
                    if (!string.IsNullOrEmpty(model.B_Case_Stage))
                    {
                        strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
                    }
                    //工程
                    if (!string.IsNullOrEmpty(model.C_Project_code))
                    {
                        strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
                        a = 1;
                    }
                    //客户   委托人
                    if ((!string.IsNullOrEmpty(model.C_Customer_code)) && (!string.IsNullOrEmpty(model.C_Client_code)))
                    {
                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

                        b = c = d = 1;
                    }
                    if (d != 1)
                    {
                        if ((!string.IsNullOrEmpty(model.C_Customer_code)) || (!string.IsNullOrEmpty(model.C_Client_code)))
                        {
                            if (!string.IsNullOrEmpty(model.C_Customer_code))
                            {
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
                                b = 1;
                            }
                            else
                            {//委托人
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
                                c = 1;
                            }

                        }
                    }
                    //对方当事人
                    if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                    {
                        strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
                        strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
                        e = 1;
                    }

                }
                strSql.Append(" where 1=1 and B_Case_isDelete=0 ");
            }
            else if (model.B_Case_oprationtype == 2)
            {
                strSql.Append("T.*  from B_Case_link CL ");
                strSql.Append("left join B_Case as T on CL.B_Case_code=T.B_Case_code ");
                strSql.Append("where CL.C_FK_code=@C_FK_code and CL.B_Case_link_isDelete=0 ");
            }
            if (model != null)
            {
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and t.B_Case_code=@B_Case_code ");
                }
                if (model.B_Case_name != null && model.B_Case_name.ToString() != "")
                {
                    strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    strSql.Append("and B_Case_type=@B_Case_type ");
                }
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    strSql.Append("and B_Case_nature=@B_Case_nature ");
                }
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    strSql.Append("and B_Case_customerType=@B_Case_customerType ");
                }
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    strSql.Append("and B_Case_state=@B_Case_state ");
                }
                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }
                //专业顾问暂时没加
                if (a == 1)
                {
                    strSql.Append("and C_Involved_project_code=@C_Project_code ");
                }
                int f = 0;
                if (b == 1 && c == 1)
                {
                    strSql.Append("and cp.C_Customer_code=@C_Customer_code ");
                    strSql.Append("and cp2.C_Customer_code=@C_Client_code ");
                    f = 1;

                }
                if (f == 0)
                {
                    if (b == 1 || c == 1)
                    {
                        strSql.Append("and C_Customer_code=@C_Customer_code ");
                    }
                }
                if (!string.IsNullOrEmpty(model.B_Case_consultant_code.ToString()))
                {
                    strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
                }
                if (e == 1)
                {
                    strSql.Append("and (C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code) ");
                }
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
                {
                    strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

            }
            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                //if (rolePowerIds.Contains(",1,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //}
                //if (rolePowerIds.Contains(",2,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                //}
                //if (rolePowerIds.Contains(",3,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //}
                //if (rolePowerIds.Contains(",4,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                //}
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");

                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                //案件负责人
                strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE 1=1");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisRoleId",SqlDbType.Int,4),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Case_type;
            parameters[3].Value = model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code;
            parameters[8].Value = model.C_Customer_code;
            parameters[9].Value = model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_execMoney;
            parameters[14].Value = model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code;
            parameters[19].Value = userCode;
            parameters[20].Value = roleId;
            parameters[21].Value = deptCode;
            parameters[22].Value = postCode;
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
        public DataSet GetListByPage(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds, int? roleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {

            int a = 0, b = 0, c = 0, d = 0, e = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.B_Case_id desc");
            }
            if (model.B_Case_oprationtype == 1)
            {//案件列表
                strSql.Append(")AS Row, T.*  from B_Case T ");
                if (model != null)
                {
                    //办案阶段限制
                    if (!string.IsNullOrEmpty(model.B_Case_Stage))
                    {
                        strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
                    }
                    //工程
                    if (!string.IsNullOrEmpty(model.C_Project_code))
                    {
                        strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
                        a = 1;
                    }
                    //客户   委托人
                    if ((!string.IsNullOrEmpty(model.C_Customer_code)) && (!string.IsNullOrEmpty(model.C_Client_code)))
                    {
                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

                        b = c = d = 1;
                    }
                    if (d != 1)
                    {
                        if ((!string.IsNullOrEmpty(model.C_Customer_code)) || (!string.IsNullOrEmpty(model.C_Client_code)))
                        {
                            if (!string.IsNullOrEmpty(model.C_Customer_code))
                            {
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
                                b = 1;
                            }
                            else
                            {//委托人
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
                                c = 1;
                            }

                        }
                    }
                    //对方当事人
                    if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                    {
                        strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
                        strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
                        e = 1;
                    }

                }
                strSql.Append(" where 1=1 and B_Case_isDelete=0 ");
            }
            else if (model.B_Case_oprationtype == 2)
            {
                strSql.Append(")AS Row, T.*  from B_Case_link CL ");
                strSql.Append("left join B_Case as T on CL.B_Case_code=T.B_Case_code ");
                strSql.Append("where CL.C_FK_code=@C_FK_code and CL.B_Case_link_isDelete=0 ");
            }
            if (model != null)
            {
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and t.B_Case_code=@B_Case_code ");
                }
                if (model.B_Case_name != null && model.B_Case_name.ToString() != "")
                {
                    strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    strSql.Append("and B_Case_type=@B_Case_type ");
                }
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    strSql.Append("and B_Case_nature=@B_Case_nature ");
                }
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    strSql.Append("and B_Case_customerType=@B_Case_customerType ");
                }
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    strSql.Append("and B_Case_state=@B_Case_state ");
                }
                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }
                //专业顾问暂时没加
                if (a == 1)
                {
                    strSql.Append("and C_Involved_project_code=@C_Project_code ");
                }
                int f = 0;
                if (b == 1 && c == 1)
                {
                    strSql.Append("and cp.C_Customer_code=@C_Customer_code ");
                    strSql.Append("and cp2.C_Customer_code=@C_Client_code ");
                    f = 1;

                }
                if (f == 0)
                {
                    if (b == 1 || c == 1)
                    {
                        strSql.Append("and C_Customer_code=@C_Customer_code ");
                    }
                }
                if (!string.IsNullOrEmpty(model.B_Case_consultant_code.ToString()))
                {
                    strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
                }
                if (e == 1)
                {
                    strSql.Append("and (C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code) ");
                }
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }
                if ((model.B_Case_registerTime != null) && (model.B_Case_registerTime2 != null))
                {
                    strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

            }

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                //if (rolePowerIds.Contains(",1,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //}
                //if (rolePowerIds.Contains(",2,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                //}
                //if (rolePowerIds.Contains(",3,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //}
                //if (rolePowerIds.Contains(",4,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                //}
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");

                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                //案件负责人
                strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                     new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisRoleId",SqlDbType.Int,4),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Case_type;
            parameters[3].Value = model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code;
            parameters[8].Value = model.C_Customer_code;
            parameters[9].Value = model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_transferTargetMoney;
            parameters[14].Value = model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code;
            parameters[19].Value = userCode;
            parameters[20].Value = roleId;
            parameters[21].Value = deptCode;
            parameters[22].Value = postCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int GetListByPageByCount(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds, int? roleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.B_Case_id desc");
            }
            if (model.B_Case_oprationtype == 1)
            {//案件列表
                strSql.Append(")AS Row, T.*  from B_Case T ");
                if (model != null)
                {
                    //办案阶段限制
                    if (!string.IsNullOrEmpty(model.B_Case_Stage))
                    {
                        strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
                    }
                    //工程
                    if (!string.IsNullOrEmpty(model.C_Project_code))
                    {
                        strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
                        a = 1;
                    }
                    //客户   委托人
                    if ((!string.IsNullOrEmpty(model.C_Customer_code)) && (!string.IsNullOrEmpty(model.C_Client_code)))
                    {
                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

                        b = c = d = 1;
                    }
                    if (d != 1)
                    {
                        if ((!string.IsNullOrEmpty(model.C_Customer_code)) || (!string.IsNullOrEmpty(model.C_Client_code)))
                        {
                            if (!string.IsNullOrEmpty(model.C_Customer_code))
                            {
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
                                b = 1;
                            }
                            else
                            {//委托人
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
                                c = 1;
                            }

                        }
                    }
                    //对方当事人
                    if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                    {
                        strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
                        strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
                        e = 1;
                    }

                }
                strSql.Append(" where 1=1 and B_Case_isDelete=0 ");
            }
            else if (model.B_Case_oprationtype == 2)
            {
                strSql.Append(")AS Row, T.*  from B_Case_link CL ");
                strSql.Append("left join B_Case as T on CL.B_Case_code=T.B_Case_code ");
                strSql.Append("where CL.C_FK_code=@C_FK_code and CL.B_Case_link_isDelete=0 ");
            }
            if (model != null)
            {
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and t.B_Case_code=@B_Case_code ");
                }
                if (model.B_Case_name != null && model.B_Case_name.ToString() != "")
                {
                    strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    strSql.Append("and B_Case_type=@B_Case_type ");
                }
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    strSql.Append("and B_Case_nature=@B_Case_nature ");
                }
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    strSql.Append("and B_Case_customerType=@B_Case_customerType ");
                }
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    strSql.Append("and B_Case_state=@B_Case_state ");
                }
                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }
                //专业顾问暂时没加
                if (a == 1)
                {
                    strSql.Append("and C_Involved_project_code=@C_Project_code ");
                }
                int f = 0;
                if (b == 1 && c == 1)
                {
                    strSql.Append("and cp.C_Customer_code=@C_Customer_code ");
                    strSql.Append("and cp2.C_Customer_code=@C_Client_code ");
                    f = 1;

                }
                if (f == 0)
                {
                    if (b == 1 || c == 1)
                    {
                        strSql.Append("and C_Customer_code=@C_Customer_code ");
                    }
                }
                if (!string.IsNullOrEmpty(model.B_Case_consultant_code.ToString()))
                {
                    strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
                }
                if (e == 1)
                {
                    strSql.Append("and (C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code) ");
                }
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
                {
                    strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

            }

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or T.B_Case_person=@ThisUserCode ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");

                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                //案件负责人
                strPowerSql.Append("or T.B_Case_person=@ThisUserCode ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            strSql.Append(" ) TT");
            // strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                     new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisRoleId",SqlDbType.Int,4),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Case_type;
            parameters[3].Value = model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code;
            parameters[8].Value = model.C_Customer_code;
            parameters[9].Value = model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_transferTargetMoney;
            parameters[14].Value = model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code;
            parameters[19].Value = userCode;
            parameters[20].Value = roleId;
            parameters[21].Value = deptCode;
            parameters[22].Value = postCode;
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
        /// 获取权限记录总数
        /// </summary>
        public int GetPowerRecordCount(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            #region 查询重写 张东洋20150923
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(B_Case_id) from B_Case T where 1=1 and B_Case_isDelete=0 ");
            if (model != null)
            {
                //办案阶段条件
                if (!string.IsNullOrEmpty(model.B_Case_Stage))
                {
                    sql.Append(" and exists(select 1 from P_Business_flow where P_Business_flow.P_Flow_code=@B_Case_Stage and P_Business_flow.P_Fk_code=T.B_Case_code and P_Business_flow.P_Business_isdelete=0)");
                }

                //工程
                if (!string.IsNullOrEmpty(model.C_Project_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Project_code and B_Case_link.B_Case_link_type=7)");
                }

                //客户
                if (!string.IsNullOrEmpty(model.C_Customer_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Customer_code and B_Case_link.B_Case_link_type=0)");
                }

                //委托人
                if (!string.IsNullOrEmpty(model.C_Client_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Client_code and B_Case_link.B_Case_link_type=1)");
                }

                //对方当事人
                if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Case_Rival_code and (B_Case_link.B_Case_link_type=2 or B_Case_link.B_Case_link_type=3))");
                }

                //区域
                if (!string.IsNullOrEmpty(model.C_Region_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Region_code and B_Case_link.B_Case_link_type=6)");
                }

                //承办律师
                if (!String.IsNullOrEmpty(model.B_Case_lawyerCode.ToString()))
                {
                    sql.Append(" and (exists(select 1 from P_Business_flow where T.B_Case_code=P_Business_flow.P_FK_code and P_Business_flow.P_Business_isdelete=0 and P_Business_flow.P_Business_person=@B_Case_lawyerCode)"); //流程负责人
                    //sql.Append(" or exists(select 1 from P_Business_flow_form where P_Business_flow_form_isdelete=0 and P_Business_flow_form_person=@B_Case_lawyerCode and P_Business_flow_form.P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Business_flow.P_Fk_code=T.B_Case_code))"); //加上后效率慢，原因再调
                    sql.Append(")");
                    //sql.Append("left join (select distinct BF.P_Fk_code,U.C_Userinfo_code from P_Business_flow as BF left join C_Userinfo as U on BF.P_Business_person=U.C_Userinfo_code where U.C_Userinfo_code=@B_Case_lawyerCode) As BU on BU.P_Fk_code=T.B_Case_code ");
                }

                //专业顾问
                if (!string.IsNullOrEmpty(model.B_Consultant_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Consultant_code and B_Case_link.B_Case_link_type=11)");
                }

                //部门
                if (!string.IsNullOrEmpty(model.B_Case_organizationCode))
                {
                    sql.Append(" and exists(select 1 from C_Userinfo As CU with(nolock) ");
                    sql.Append("where CU.C_Userinfo_isDelete=0 ");
                    sql.Append("and exists(select 1 from DeptTree(@B_Case_organizationCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    sql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    sql.Append(") ");
                }

                //法院
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    sql.Append(" and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }

                //案件名称
                if (!string.IsNullOrEmpty(model.B_Case_name))
                {
                    sql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }

                //案件类型
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    sql.Append("and B_Case_type=@B_Case_type ");
                }

                //案件性质
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    sql.Append("and B_Case_nature=@B_Case_nature ");
                }

                //客户类型
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    sql.Append("and B_Case_customerType=@B_Case_customerType ");
                }

                //案件状态
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    sql.Append("and B_Case_state=@B_Case_state ");
                }

                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    sql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }

                //预期收益范围
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    sql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }

                //预收案时间
                if ((model.B_Case_registerTime != null) && (model.B_Case_registerTime2 != null))
                {
                    sql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

                //首席确认开始时间
                if (!string.IsNullOrEmpty(model.B_Case_sureDate.ToString()))
                {
                    sql.Append("and B_Case_sureDate>=@B_Case_sureDate ");
                }

                //首席确认结束时间
                if (!string.IsNullOrEmpty(model.B_Case_sureDateEnd.ToString()))
                {
                    sql.Append("and B_Case_sureDate<=@B_Case_sureDateEnd ");
                }
                //案件级别
                if (model.B_Case_isNotAudited != null)
                {
                    if (model.B_Case_isNotAudited == 1)
                    {
                        sql.Append("and not exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                    }
                    else
                    {
                        sql.Append("and exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_type=@B_CaseLevelchange_type and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                    }
                }
                //重大难案
                if (model.B_Case_Majordifficult == 2)
                {
                    sql.Append("and exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_IsValid=1 and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                }
                #region 不清楚这是干啥的,先去掉,hety,2015-12-02
                /*if (flowModel != null)
                {
                    if ((flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "") || (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != ""))
                    {
                        sql.Append(" and exists (select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code ");
                    }
                    else
                    {
                        sql.Append(" and(1=1 ");
                    }
                    if (flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "")
                    {
                        sql.Append(" and PBF.P_Business_state=@P_Business_state");
                    }
                    if (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != "")
                    {
                        sql.Append(" and (PBF.P_Business_person=@P_Business_person ");

                        sql.Append("or exists(select 1 from   as PFF where pff.P_Business_flow_form_isdelete=0 and pff.P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Fk_code=t.B_Case_code)) or (select count(1) from P_Business_flow_form as PFF where pff.P_Business_flow_code=pbf.P_Business_flow_code and pff.P_Business_flow_form_person=@P_Business_person )>0 )");
                    }
                    sql.Append(" ) ");
                }*/
                #endregion
            }

            #region hety,2015-12-01,针对律师案件列表：我的未开始、我的在办、我的已结 案件列表加入当前登录人(律师)过滤条件(内置系统管理员除外)
            if (vLawyerCond != null)
            {
                if (vLawyerCond.LawyerType == 0)
                {//默认
                    #region 默认
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束的案件(并且关联业务流程的负责人为当前操作人自己))
                         *           OR 协办律师(关联业务表单进行状态为：未开始或已结束的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束或正在进行的案件(并且关联业务流程的负责人为当前操作人自己))
                          *           OR 协办律师(关联业务表单进行状态为：未开始或已结束或正在进行的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state=200) ");
                            sql.Append("or exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_state=200) ");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person and BF.P_Business_state=200) ");
                            sql.Append("or exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person and BFF.P_Business_flow_form_state=200) ");
                            sql.Append(") ");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：已结束的案件(并且关联业务流程的负责人为当前操作人自己))
                          *           OR 协办律师(关联业务表单进行状态为：已结束的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
                else if (vLawyerCond.LawyerType == 1)
                {
                    #region 主办律师
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束的案件(并且关联业务流程的负责人为当前操作人自己))                     
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束或正在进行的案件(并且关联业务流程的负责人为当前操作人自己))                     
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state=200) ");
                        }
                        else
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person and BF.P_Business_state=200) ");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：已结束的案件(并且关联业务流程的负责人为当前操作人自己))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
                else if (vLawyerCond.LawyerType == 2)
                {
                    #region 协办律师
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：协办律师(关联业务表单进行状态为：未开始或已结束的案件(并且关联业务表单负责人为当前操作人自己，并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                       
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：协办律师(关联业务表单进行状态为：未开始或已结束或正在进行的案件(并且关联业务表单负责人为当前操作人自己,并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BFF.P_Business_flow_form_state=200) ");
                        }
                        else
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person and BFF.P_Business_flow_form_state=200)");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：协办律师(关联业务表单进行状态为：已结束的案件(并且关联业务表单负责人为当前操作人自己,并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Organization_code=@ThisDeptCode ");
                    strPowerSql.Append("and CRR.C_Post_code=@ThisPostCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件(完全去掉，以后只通过权限来控制,废弃这种写死的做法，hety，2016-01-25，)

                /*
                //案件负责人、案件一级负责人
                strPowerSql.Append("or exists(select 1 from B_Case T1 where (T1.B_Case_person=@ThisUserCode or T1.B_Case_firstClassResponsiblePerson=@ThisUserCode) and T1.B_Case_code=T.B_Case_code) ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                */
                #endregion

                strPowerSql.Append(") ");
                sql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            #endregion

            #region 老sql
            //int a = 0, b = 0, c = 0, d = 0, e = 0, g = 0, h = 0, i = 0;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT count(*) FROM ( ");
            //strSql.Append(" SELECT ");

            //if (model.B_Case_oprationtype == 1)
            //{//案件列表
            //    strSql.Append(" T.*,BC.B_BusinessChance_name as 'B_Case_businessChance_Name' from B_Case T left join B_BusinessChance as BC on T.B_Case_businessChance_Code=BC.B_BusinessChance_code ");
            //    if (model != null)
            //    {
            //        //办案阶段限制
            //        if (!string.IsNullOrEmpty(model.B_Case_Stage))
            //        {
            //            strSql.Append("right join (select distinct(P_Fk_code) from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
            //        }
            //        //工程
            //        if (!string.IsNullOrEmpty(model.C_Project_code))
            //        {
            //            strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
            //            a = 1;
            //        }
            //        //客户   委托人
            //        if ((!string.IsNullOrEmpty(model.C_Customer_code)) && (!string.IsNullOrEmpty(model.C_Client_code)))
            //        {
            //            strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

            //            strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

            //            b = c = d = 1;
            //        }
            //        if (d != 1)
            //        {
            //            if ((!string.IsNullOrEmpty(model.C_Customer_code)) || (!string.IsNullOrEmpty(model.C_Client_code)))
            //            {
            //                if (!string.IsNullOrEmpty(model.C_Customer_code))
            //                {
            //                    strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
            //                    b = 1;
            //                }
            //                else
            //                {//委托人
            //                    strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
            //                    c = 1;
            //                }

            //            }
            //        }
            //        //对方当事人
            //        if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
            //        {
            //            strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
            //            strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
            //            e = 1;
            //        }
            //        //区域
            //        if (!String.IsNullOrEmpty(model.C_Region_code))
            //        {
            //            strSql.Append("left join(select C_Region_code,B_Case_code from B_Case_link As CL  left join C_Region As CR  on CL.C_FK_code = CR.C_Region_code where CL.C_FK_code=@C_Region_code and CL.B_Case_link_type=6) As CBP2 on CBP2.B_Case_code=T.B_Case_code ");
            //            g = 1;
            //        }
            //        //专业顾问
            //        if (!String.IsNullOrEmpty(model.B_Consultant_code))
            //        {
            //            //strSql.Append("left join(select C_Userinfo_code,B_Case_code from B_Case_link As CL  left join C_Userinfo As U  on CL.C_FK_code = U.C_Userinfo_code where CL.C_FK_code in " + model.B_Consultant_code + " and CL.B_Case_link_type=11) As CCP on CCP.B_Case_code=T.B_Case_code ");
            //            h = 1;
            //        }
            //        //承办律师
            //        if (!String.IsNullOrEmpty(model.B_Case_lawyerCode.ToString()))
            //        {
            //            strSql.Append("left join (select distinct BF.P_Fk_code,U.C_Userinfo_code from P_Business_flow as BF left join C_Userinfo as U on BF.P_Business_person=U.C_Userinfo_code where U.C_Userinfo_code=@B_Case_lawyerCode) As BU on BU.P_Fk_code=T.B_Case_code ");
            //            i = 1;
            //        }
            //    }
            //    //流程查询
            //    //if (flowModel != null)
            //    //{
            //    //    if ((flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "") || (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != ""))
            //    //    {
            //    //        strSql.Append(" left join (select * from P_Business_flow ) As PBflow on PBflow.P_Fk_code=T.B_Case_code ");
            //    //    }
            //    //}

            //    //专业顾问
            //    strSql.Append(" where 1=1 and B_Case_isDelete=0 ");
            //    if (!String.IsNullOrEmpty(model.B_Consultant_code))
            //    {
            //        strSql.Append(" and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code in ('" + model.B_Consultant_code + "')) ");
            //    }

            //    //部门
            //    if (!String.IsNullOrEmpty(model.B_Case_organizationCode))
            //    {
            //        strSql.Append("and exists(select 1 from C_Userinfo As CU with(nolock) ");
            //        strSql.Append("where CU.C_Userinfo_isDelete=0 ");
            //        strSql.Append("and exists(select 1 from DeptTree('" + model.B_Case_organizationCode + "') as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
            //        strSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
            //        strSql.Append(") ");
            //    }
            //}
            //else if (model.B_Case_oprationtype == 2)
            //{
            //    strSql.Append(")AS Row, T.*  from B_Case_link CL ");
            //    strSql.Append("left join B_Case as T on CL.B_Case_code=T.B_Case_code ");
            //    strSql.Append("where CL.C_FK_code=@C_FK_code and CL.B_Case_link_isDelete=0 ");
            //}
            //if (model != null)
            //{
            //    if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
            //    {
            //        strSql.Append("and T.B_Case_code=@B_Case_code ");
            //    }
            //    if (model.B_Case_name != null && model.B_Case_name.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
            //    }
            //    if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_type=@B_Case_type ");
            //    }
            //    if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_nature=@B_Case_nature ");
            //    }
            //    if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_customerType=@B_Case_customerType ");
            //    }
            //    if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_state=@B_Case_state ");
            //    }
            //    //新添加条件查询
            //    if (!string.IsNullOrEmpty(model.B_Case_number))
            //    {
            //        strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
            //    }
            //    //专业顾问暂时没加
            //    if (a == 1)
            //    {
            //        strSql.Append("and C_Involved_project_code=@C_Project_code ");
            //    }
            //    int f = 0;
            //    if (b == 1 && c == 1)
            //    {
            //        strSql.Append("and cp.C_Customer_code=@C_Customer_code ");
            //        strSql.Append("and cp2.C_Customer_code=@C_Client_code ");
            //        f = 1;

            //    }
            //    if (f == 0)
            //    {
            //        if (b == 1)
            //        {
            //            strSql.Append("and C_Customer_code=@C_Customer_code ");
            //        }
            //        if (c == 1)
            //        {
            //            strSql.Append("and C_Customer_code=@C_Client_code ");
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(model.B_Case_consultant_code.ToString()))
            //    {
            //        strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
            //    }
            //    if (e == 1)
            //    {
            //        strSql.Append("and C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code ");
            //    }
            //    if (g == 1)
            //    {
            //        strSql.Append("and C_Region_code=@C_Region_code ");
            //    }
            //    if (h == 1)
            //    {
            //        //strSql.Append("and CCP.C_Userinfo_code in " + model.B_Consultant_code);
            //    }
            //    if (i == 1)
            //    {
            //        strSql.Append("and BU.C_Userinfo_code = @B_Case_lawyerCode ");
            //    }
            //    if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
            //    {
            //        strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
            //    }
            //    if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
            //    {
            //        strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
            //    }
            //    if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
            //    {
            //        strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
            //    }
            //    //if (flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "")
            //    //{
            //    //    strSql.Append(" and PBflow.P_Business_state=@P_Business_state");
            //    //}
            //    //if (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != "")
            //    //{
            //    //    strSql.Append(" and PBflow.P_Business_person=@P_Business_person");
            //    //}
            //    if (flowModel != null)
            //    {
            //        if ((flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "") || (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != ""))
            //        {
            //            strSql.Append(" and exists (select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=t.B_Case_code ");
            //        }
            //        else
            //        {
            //            strSql.Append(" and(1=1 ");
            //        }

            //        if (flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "")
            //        {
            //            strSql.Append(" and PBF.P_Business_state=@P_Business_state ");
            //        }
            //        if (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != "")
            //        {
            //            strSql.Append(" and (PBF.P_Business_person=@P_Business_person ");

            //            strSql.Append("or exists(select 1 from P_Business_flow_form as PFF where pff.P_Business_flow_form_isdelete=0 and pff.P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Fk_code=t.B_Case_code)) or (select count(1) from P_Business_flow_form as PFF where pff.P_Business_flow_code=pbf.P_Business_flow_code and pff.P_Business_flow_form_person=@P_Business_person )>0 )");
            //        }
            //        strSql.Append(")");
            //    }
            //}

            //#region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            //if (!IsPreSetManager)
            //{//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
            //    StringBuilder strPowerSql = new StringBuilder();
            //    strPowerSql.Append(" and (1<>1 ");
            //    if (rolePowerIds.Contains(",1,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",2,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
            //    }
            //    if (rolePowerIds.Contains(",3,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",4,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",5,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
            //        strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
            //        strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
            //        strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
            //        strPowerSql.Append(") ");
            //    }
            //    if (rolePowerIds.Contains(",6,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");

            //    }
            //    if (rolePowerIds.Contains(",7,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
            //    }
            //    if (rolePowerIds.Contains(",8,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
            //        strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
            //    }
            //    if (rolePowerIds.Contains(",17,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
            //    }

            //    #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
            //    //案件负责人
            //    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
            //    //销售顾问
            //    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    //业务流程负责人
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    //主办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
            //    //协办律师

            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");



            //    #endregion

            //    strPowerSql.Append(") ");
            //    strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            //}
            //#endregion

            //strSql.Append(" ) As TT ");
            #endregion

            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),                
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_state", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_lawyerCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Consultant_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_organizationCode",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_sureDate",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_sureDateEnd",SqlDbType.DateTime),
                    new SqlParameter("@B_CaseLevelchange_type",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Case_type;
            parameters[3].Value = model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code;
            parameters[8].Value = model.C_Customer_code;
            parameters[9].Value = model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_transferTargetMoney;
            parameters[14].Value = model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code;
            parameters[19].Value = model.C_Region_code;
            parameters[20].Value = userCode;            
            parameters[21].Value = deptCode;
            parameters[22].Value = postCode;
            parameters[23].Value = null; //flowModel.P_Business_state;目前在过滤条件里，没有用到此条件
            parameters[24].Value = vLawyerCond == null ? null : vLawyerCond.LawyerCode; //flowModel.P_Business_person;
            parameters[25].Value = vLawyerCond == null ? null : vLawyerCond.LawyerCode;//flowModel.P_Business_flow_form_person;
            parameters[26].Value = model.B_Case_lawyerCode;
            parameters[27].Value = model.B_Consultant_code;
            parameters[28].Value = model.B_Case_organizationCode;
            parameters[29].Value = model.B_Case_sureDate;
            parameters[30].Value = model.B_Case_sureDateEnd;
            parameters[31].Value = model.B_Case_isNotAudited;

            object obj = DbHelperSQL.GetSingle(sql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        ///过滤条件
        public int GetPowerRecordCaseMainCount(CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, string rolePowerIds,Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0, g = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) FROM ( ");
            strSql.Append(" SELECT ");

            if (model.B_Case_oprationtype == 1)
            {//案件列表
                strSql.Append(" T.* from B_Case T ");
                if (model != null)
                {
                    //办案阶段限制
                    if (!string.IsNullOrEmpty(model.B_Case_Stage))
                    {
                        strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
                    }
                    //工程
                    if (!string.IsNullOrEmpty(model.C_Project_code))
                    {
                        strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
                        a = 1;
                    }
                    //客户   委托人
                    if ((!string.IsNullOrEmpty(model.C_Customer_code)) && (!string.IsNullOrEmpty(model.C_Client_code)))
                    {
                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

                        b = c = d = 1;
                    }
                    if (d != 1)
                    {
                        if ((!string.IsNullOrEmpty(model.C_Customer_code)) || (!string.IsNullOrEmpty(model.C_Client_code)))
                        {
                            if (!string.IsNullOrEmpty(model.C_Customer_code))
                            {
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
                                b = 1;
                            }
                            else
                            {//委托人
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
                                c = 1;
                            }

                        }
                    }
                    //对方当事人
                    if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                    {
                        strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
                        strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
                        e = 1;
                    }
                    //区域
                    if (!String.IsNullOrEmpty(model.C_Region_code))
                    {
                        strSql.Append("left join(select C_Region_code,B_Case_code from B_Case_link As CL  left join C_Region As CR  on CL.C_FK_code = CR.C_Region_code where CL.C_FK_code=@C_Region_code and CL.B_Case_link_type=6) As CBP2 on CBP2.B_Case_code=T.B_Case_code ");
                        g = 1;
                    }
                }
                strSql.Append(" where 1=1 and B_Case_isDelete=0 ");
                strSql.Append("and " + tj);
            }
            else if (model.B_Case_oprationtype == 2)
            {
                strSql.Append(")AS Row, T.*  from B_Case_link CL ");
                strSql.Append("left join B_Case as T on CL.B_Case_code=T.B_Case_code ");
                strSql.Append("where CL.C_FK_code=@C_FK_code and CL.B_Case_link_isDelete=0 ");
            }
            if (model != null)
            {
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and T.B_Case_code=@B_Case_code ");
                }
                if (model.B_Case_name != null && model.B_Case_name.ToString() != "")
                {
                    strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    strSql.Append("and B_Case_type=@B_Case_type ");
                }
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    strSql.Append("and B_Case_nature=@B_Case_nature ");
                }
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    strSql.Append("and B_Case_customerType=@B_Case_customerType ");
                }
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    strSql.Append("and B_Case_state=@B_Case_state ");
                }
                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }
                //专业顾问暂时没加
                if (a == 1)
                {
                    strSql.Append("and C_Involved_project_code=@C_Project_code ");
                }
                int f = 0;
                if (b == 1 && c == 1)
                {
                    strSql.Append("and cp.C_Customer_code=@C_Customer_code ");
                    strSql.Append("and cp2.C_Customer_code=@C_Client_code ");
                    f = 1;

                }
                if (f == 0)
                {
                    if (b == 1 || c == 1)
                    {
                        strSql.Append("and C_Customer_code=@C_Customer_code ");
                    }
                }
                if (!string.IsNullOrEmpty(model.B_Case_consultant_code.ToString()))
                {
                    strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
                }
                if (e == 1)
                {
                    strSql.Append("and C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code ");
                }
                if (g == 1)
                {
                    strSql.Append("and C_Region_code=@C_Region_code ");
                }
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
                {
                    strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

            }

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Organization_code=@ThisDeptCode ");
                    strPowerSql.Append("and CRR.C_Post_code=@ThisPostCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");
                }

                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件(已作废，只通过权限设置控制，hety,2016-01-26)
                /*
                //案件负责人
                strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                */

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            strSql.Append(" ) As TT ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),                   
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Case_type;
            parameters[3].Value = model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code;
            parameters[8].Value = model.C_Customer_code;
            parameters[9].Value = model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_transferTargetMoney;
            parameters[14].Value = model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code;
            parameters[19].Value = model.C_Region_code;
            parameters[20].Value = userCode;        
            parameters[21].Value = deptCode;
            parameters[22].Value = postCode;

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

        public DataSet GetPowerListB_caseMainByPage(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds,Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0, g = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.B_Case_id desc");
            }
            if (model.B_Case_oprationtype == 1)
            {//案件列表
                strSql.Append(")AS Row, T.*  from B_Case T ");
                if (model != null)
                {
                    //办案阶段限制
                    if (!string.IsNullOrEmpty(model.B_Case_Stage))
                    {
                        strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
                    }
                    //工程
                    if (!string.IsNullOrEmpty(model.C_Project_code))
                    {
                        strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
                        a = 1;
                    }
                    //客户   委托人
                    if ((!string.IsNullOrEmpty(model.C_Customer_code)) && (!string.IsNullOrEmpty(model.C_Client_code)))
                    {
                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

                        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

                        b = c = d = 1;
                    }
                    if (d != 1)
                    {
                        if ((!string.IsNullOrEmpty(model.C_Customer_code)) || (!string.IsNullOrEmpty(model.C_Client_code)))
                        {
                            if (!string.IsNullOrEmpty(model.C_Customer_code))
                            {
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
                                b = 1;
                            }
                            else
                            {//委托人
                                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
                                c = 1;
                            }
                        }
                    }
                    //对方当事人
                    if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                    {
                        strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
                        strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
                        e = 1;
                    }
                    //区域
                    if (!String.IsNullOrEmpty(model.C_Region_code))
                    {
                        strSql.Append("left join(select C_Region_code,B_Case_code from B_Case_link As CL  left join C_Region As CR  on CL.C_FK_code = CR.C_Region_code where CL.C_FK_code=@C_Region_code and CL.B_Case_link_type=6) As CBP on CBP.B_Case_code=T.B_Case_code ");
                        g = 1;
                    }
                }

                strSql.Append(" where 1=1 and B_Case_isDelete=0 ");
                strSql.Append(" and " + tj);
            }
            else if (model.B_Case_oprationtype == 2)
            {
                strSql.Append(")AS Row, T.*  from B_Case_link CL ");
                strSql.Append("left join B_Case as T on CL.B_Case_code=T.B_Case_code ");
                strSql.Append("where CL.C_FK_code=@C_FK_code and CL.B_Case_link_isDelete=0 ");
            }
            if (model != null)
            {
                if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
                {
                    strSql.Append("and B_Case_code=@B_Case_code ");
                }
                if (model.B_Case_name != null && model.B_Case_name.ToString() != "")
                {
                    strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    strSql.Append("and B_Case_type=@B_Case_type ");
                }
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    strSql.Append("and B_Case_nature=@B_Case_nature ");
                }
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    strSql.Append("and B_Case_customerType=@B_Case_customerType ");
                }
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    strSql.Append("and B_Case_state=@B_Case_state ");
                }
                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }
                //专业顾问暂时没加
                if (a == 1)
                {
                    strSql.Append("and C_Involved_project_code=@C_Project_code ");
                }
                int f = 0;
                if (b == 1 && c == 1)
                {
                    strSql.Append("and cp.C_Customer_code=@C_Customer_code ");
                    strSql.Append("and cp2.C_Customer_code=@C_Client_code ");
                    f = 1;

                }
                if (f == 0)
                {
                    if (b == 1 || c == 1)
                    {
                        strSql.Append("and C_Customer_code=@C_Customer_code ");
                    }
                }
                if (!string.IsNullOrEmpty(model.B_Case_consultant_code.ToString()))
                {
                    strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
                }
                if (e == 1)
                {
                    strSql.Append("and C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code ");
                }
                if (g == 1)
                {
                    strSql.Append("and C_Region_code=@C_Region_code ");
                }
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }
                if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
                {
                    strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

            }

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Organization_code=@ThisDeptCode ");
                    strPowerSql.Append("and CRR.C_Post_code=@ThisPostCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");
                }

                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件(已废弃，权限控制只通过设置处理，hety,2016-01-26)
                /*
                //案件负责人
                strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                */
                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),            
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),

                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Case_type;
            parameters[3].Value = model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code;
            parameters[8].Value = model.C_Customer_code;
            parameters[9].Value = model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_transferTargetMoney;
            parameters[14].Value = model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code;
            parameters[19].Value = model.C_Region_code;
            parameters[20].Value = userCode;         
            parameters[21].Value = deptCode;
            parameters[22].Value = postCode;


            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 分页获取权限数据列表
        /// </summary>
        public DataSet GetPowerListByPage(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds,Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            #region 查询重写 张东洋20150923

            StringBuilder sql = new StringBuilder();
            sql.Append("select *,U.C_Userinfo_name as B_Case_personName,UI.C_Userinfo_name as C_Case_firstClassResponsiblePersonName,(select top 1 M_Entry_Statistics_Management from M_Entry_Statistics  M where M.M_Case_number=T.B_Case_number and M.M_Entry_Statistics_HandlingState=470 and M.M_Entry_Statistics_isDelete=0) as M_Entry_Statistics_Management,(case when ((select count(1) from J_Milepost where J_Milepost.J_Milepost_CaseNumber=T.B_Case_number and J_Milepost.J_Milepost_isDelete=0)>0 or (select count(1) from [J_No_Milepost] where [J_No_Milepost].J_No_Milepost_CaseNumber=T.B_Case_number and [J_No_Milepost].J_No_Milepost_isDelete=0)>0) then 1 else 0 end) as Ischeck,(case when ((select top 1 M_Entry_Statistics_HandlingState from M_Entry_Statistics where M_Entry_Statistics.M_Case_number=T.B_Case_number and M_Entry_Statistics.M_Entry_Statistics_isDelete=0)=470 ) then '已超时' else '' end) as Ischeck2,(case when ((select top 1 M_Entry_Statistics_warningSituation from M_Entry_Statistics where M_Entry_Statistics.M_Case_number=T.B_Case_number and M_Entry_Statistics.M_Entry_Statistics_isDelete=0 and M_Entry_Statistics.M_Entry_Statistics_HandlingState!=470)=464) then '预警中' else '' end) as Ischeck3,(case when ((select count(1) from J_Milepost where J_Milepost.J_Milepost_CaseNumber=T.B_Case_number and J_Milepost.J_Milepost_isDelete=0)>0 or (select count(1) from [J_No_Milepost] where [J_No_Milepost].J_No_Milepost_CaseNumber=T.B_Case_number and [J_No_Milepost].J_No_Milepost_isDelete=0)>0) then 1 else 0 end) as Ischeck,(select B_BusinessChance_name from B_BusinessChance where B_BusinessChance.B_BusinessChance_code=T.B_Case_businessChance_Code) as B_Case_businessChance_Name,");
            sql.Append("(select count(1) from M_Entry_Statistics As S with(nolock),M_Entry_Change As EC with(nolock) where S.M_Entry_Statistics_code=EC.M_Entry_Statistics_code and S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=T.B_Case_code and EC.M_Entry_Change_IsThrough<>328) As B_Case_Delay_Entry_Statistics_Count,");
            sql.Append("(select count(1) from M_Entry_Statistics As S with(nolock) where S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=T.B_Case_code and S.M_Entry_Statistics_HandlingState=470) As B_Case_HandlingState_Entry_Statistics_Count,");
            sql.Append("(select count(1) from M_Entry_Statistics As S with(nolock) where S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=T.B_Case_code and S.M_Entry_Statistics_warningSituation=464) As B_Case_WarningSituation_Entry_Statistics_Count,");
            sql.Append("dbo.getCheckAuthorityStatus(T.B_Case_code) As B_Case_IsCheckAuthority,");
            sql.Append("dbo.getCaseLevel(B_Case_code) As B_Case_caseGrade,");
            sql.Append("(select count(1) from B_CaseLevelchange as CLC where CLC.B_Case_code=T.B_Case_code and CLC.B_CaseLevelchange_state=947 and CLC.B_CaseLevelchange_IsValid=0 and CLC.B_CaseLevelchange_isDelete=0) As B_Case_isNotAudited ");
            sql.Append(" from B_Case T  ");
            sql.Append("left join C_Userinfo U on T.B_Case_person=U.C_Userinfo_code left join C_Userinfo UI on T.B_Case_firstClassResponsiblePerson=UI.C_Userinfo_code ");
            sql.Append("where  1=1 and T.B_Case_isDelete=0 ");

            if (model != null)
            {
                //收案时间
                if ((model.B_Case_registerTime != null) && (model.B_Case_registerTime2 != null))
                {
                    sql.Append("and T.B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

                //办案阶段条件
                if (!string.IsNullOrEmpty(model.B_Case_Stage))
                {
                    sql.Append(" and exists(select 1 from P_Business_flow where P_Business_flow.P_Flow_code=@B_Case_Stage and P_Business_flow.P_Fk_code=T.B_Case_code and P_Business_flow.P_Business_isdelete=0)");
                }

                //工程
                if (!string.IsNullOrEmpty(model.C_Project_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Project_code and B_Case_link.B_Case_link_type=7)");
                }

                //客户
                if (!string.IsNullOrEmpty(model.C_Customer_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Customer_code and B_Case_link.B_Case_link_type=0)");
                }

                //委托人
                if (!string.IsNullOrEmpty(model.C_Client_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Client_code and B_Case_link.B_Case_link_type=1)");
                }

                //对方当事人
                if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Case_Rival_code and (B_Case_link.B_Case_link_type=2 or B_Case_link.B_Case_link_type=3))");
                }

                //区域
                if (!string.IsNullOrEmpty(model.C_Region_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Region_code and B_Case_link.B_Case_link_type=6)");
                }

                //承办律师
                if (!String.IsNullOrEmpty(model.B_Case_lawyerCode.ToString()))
                {
                    sql.Append(" and (exists(select 1 from P_Business_flow where T.B_Case_code=P_Business_flow.P_FK_code and P_Business_flow.P_Business_isdelete=0 and P_Business_flow.P_Business_person=@B_Case_lawyerCode)"); //流程负责人
                    //sql.Append(" or exists(select 1 from P_Business_flow_form where P_Business_flow_form_isdelete=0 and P_Business_flow_form_person=@B_Case_lawyerCode and P_Business_flow_form.P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Business_flow.P_Fk_code=T.B_Case_code))"); //加上后效率慢，原因再调
                    sql.Append(")");
                    //sql.Append("left join (select distinct BF.P_Fk_code,U.C_Userinfo_code from P_Business_flow as BF left join C_Userinfo as U on BF.P_Business_person=U.C_Userinfo_code where U.C_Userinfo_code=@B_Case_lawyerCode) As BU on BU.P_Fk_code=T.B_Case_code ");
                }

                //专业顾问
                if (!string.IsNullOrEmpty(model.B_Consultant_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Consultant_code and B_Case_link.B_Case_link_type=11)");
                }

                //部门
                if (!string.IsNullOrEmpty(model.B_Case_organizationCode))
                {
                    sql.Append(" and exists(select 1 from C_Userinfo As CU with(nolock) ");
                    sql.Append("where CU.C_Userinfo_isDelete=0 ");
                    sql.Append("and exists(select 1 from DeptTree(@B_Case_organizationCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    sql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    sql.Append(") ");
                }

                //法院
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    sql.Append(" and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }

                //案件名称
                if (!string.IsNullOrEmpty(model.B_Case_name))
                {
                    sql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }

                //案件类型
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    sql.Append("and B_Case_type=@B_Case_type ");
                }

                //案件性质
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    sql.Append("and B_Case_nature=@B_Case_nature ");
                }

                //客户类型
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    sql.Append("and B_Case_customerType=@B_Case_customerType ");
                }

                //案件状态
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    sql.Append("and B_Case_state=@B_Case_state ");
                }

                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    sql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }

                //预期收益范围
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    sql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }

                //预收案时间
                if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
                {
                    sql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

                //首席确认开始时间
                if (!string.IsNullOrEmpty(model.B_Case_sureDate.ToString()))
                {
                    sql.Append("and B_Case_sureDate>=@B_Case_sureDate ");
                }

                //首席确认结束时间
                if (!string.IsNullOrEmpty(model.B_Case_sureDateEnd.ToString()))
                {
                    sql.Append("and B_Case_sureDate<=@B_Case_sureDateEnd ");
                }

                //案件是否包含流程（监控中心用到）
                if (model.Flow_code != null && model.Flow_code.ToString() != "" && model.Flow_code.ToString() != "0")
                {
                    sql.Append("and exists(select 1 from P_Business_Flow where P_FK_Code=B_Case_code and P_Business_isDelete=0 and P_Flow_code=@Flow_code)");
                }
                //案件级别
                if (model.B_Case_isNotAudited != null)
                {
                    if (model.B_Case_isNotAudited == 1)
                    {//正常
                        sql.Append("and not exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_IsValid=1 and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                    }
                    else
                    {
                        sql.Append("and exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_type=@B_CaseLevelchange_type and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                    }
                }
                //重大难案
                if (model.B_Case_Majordifficult == 2)
                {
                    sql.Append("and exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_IsValid=1 and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                }

                #region 不清楚这是干啥的,先去掉,hety,2015-12-02
                /*if (flowModel != null)
                {
                    if ((flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "") || (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != ""))
                    {
                        sql.Append(" and exists (select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code ");
                    }
                    else
                    {
                        sql.Append(" and(1=1 ");
                    }
                    if (flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "")
                    {
                        sql.Append(" and PBF.P_Business_state=@P_Business_state");
                    }
                    if (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != "")
                    {
                        sql.Append(" and (PBF.P_Business_person=@P_Business_person ");

                        sql.Append("or exists(select 1 from P_Business_flow_form as PFF where pff.P_Business_flow_form_isdelete=0 and pff.P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Fk_code=t.B_Case_code)) or (select count(1) from P_Business_flow_form as PFF where pff.P_Business_flow_code=pbf.P_Business_flow_code and pff.P_Business_flow_form_person=@P_Business_person )>0 )");
                    }
                    sql.Append(" ) ");
                }*/
                #endregion
            }

            #region hety,2015-12-01,针对律师案件列表：我的未开始、我的在办、我的已结 案件列表加入当前登录人(律师)过滤条件(内置系统管理员除外)
            if (vLawyerCond != null)
            {
                if (vLawyerCond.LawyerType == 0)
                {//默认
                    #region 默认
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束的案件(并且关联业务流程的负责人为当前操作人自己))
                         *           OR 协办律师(关联业务表单进行状态为：未开始或已结束的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束或正在进行的案件(并且关联业务流程的负责人为当前操作人自己))
                          *           OR 协办律师(关联业务表单进行状态为：未开始或已结束或正在进行的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state=200) ");
                            sql.Append("or exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_state=200) ");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person and BF.P_Business_state=200) ");
                            sql.Append("or exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person and BFF.P_Business_flow_form_state=200) ");
                            sql.Append(") ");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：已结束的案件(并且关联业务流程的负责人为当前操作人自己))
                          *           OR 协办律师(关联业务表单进行状态为：已结束的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
                else if (vLawyerCond.LawyerType == 1)
                {
                    #region 主办律师
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束的案件(并且关联业务流程的负责人为当前操作人自己))                     
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束或正在进行的案件(并且关联业务流程的负责人为当前操作人自己))                     
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state=200) ");
                        }
                        else
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person and BF.P_Business_state=200) ");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：已结束的案件(并且关联业务流程的负责人为当前操作人自己))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
                else if (vLawyerCond.LawyerType == 2)
                {
                    #region 协办律师
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：协办律师(关联业务表单进行状态为：未开始或已结束的案件(并且关联业务表单负责人为当前操作人自己，并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                       
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：协办律师(关联业务表单进行状态为：未开始或已结束或正在进行的案件(并且关联业务表单负责人为当前操作人自己,并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BFF.P_Business_flow_form_state=200) ");
                        }
                        else
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person and BFF.P_Business_flow_form_state=200)");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：协办律师(关联业务表单进行状态为：已结束的案件(并且关联业务表单负责人为当前操作人自己,并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Organization_code=@ThisDeptCode ");
                    strPowerSql.Append("and CRR.C_Post_code=@ThisPostCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件(去除写死条件，升级后都通过权限控制，hety,2016-01-26)
                //案件负责人、案件一级负责人
                /*
                strPowerSql.Append("or exists(select 1 from B_Case T1 where (T1.B_Case_person=@ThisUserCode or T1.B_Case_firstClassResponsiblePerson=@ThisUserCode) and T1.B_Case_code=T.B_Case_code) ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                */

                #endregion

                strPowerSql.Append(") ");
                sql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            if (!string.IsNullOrEmpty(orderby))
            {
                sql.Append(" order by " + orderby);
            }
            else
            {
                sql.Append(" order by B_Case_id desc");
            }
            sql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);

            #endregion

            #region 老sql
            //int a = 0, b = 0, c = 0, d = 0, e = 0, g = 0, h = 0, i = 0;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append("order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append("order by T.B_Case_id desc");
            //}
            //if (model.B_Case_oprationtype == 1)
            //{//案件列表
            //    strSql.Append(")AS Row, T.*,BC.B_BusinessChance_name as 'B_Case_businessChance_Name' from B_Case T left join B_BusinessChance as BC on T.B_Case_businessChance_Code=BC.B_BusinessChance_code ");
            //    if (model != null)
            //    {
            //        //办案阶段限制
            //        if (!string.IsNullOrEmpty(model.B_Case_Stage))
            //        {
            //            strSql.Append("right join (select distinct(P_Fk_code) from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
            //        }
            //        //工程
            //        if (!string.IsNullOrEmpty(model.C_Project_code))
            //        {
            //            strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
            //            a = 1;
            //        }
            //        //客户   委托人
            //        if ((!string.IsNullOrEmpty(model.C_Customer_code)) && (!string.IsNullOrEmpty(model.C_Client_code)))
            //        {
            //            strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

            //            strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

            //            b = c = d = 1;
            //        }
            //        if (d != 1)
            //        {
            //            if ((!string.IsNullOrEmpty(model.C_Customer_code)) || (!string.IsNullOrEmpty(model.C_Client_code)))
            //            {
            //                if (!string.IsNullOrEmpty(model.C_Customer_code))
            //                {//客户
            //                    strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
            //                    b = 1;
            //                }
            //                if (!string.IsNullOrEmpty(model.C_Client_code))
            //                {//委托人
            //                    strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
            //                    c = 1;
            //                }

            //            }
            //        }
            //        //对方当事人
            //        if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
            //        {
            //            strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
            //            strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
            //            e = 1;
            //        }
            //        //区域
            //        if (!String.IsNullOrEmpty(model.C_Region_code))
            //        {
            //            strSql.Append("left join(select C_Region_code,B_Case_code from B_Case_link As CL  left join C_Region As CR  on CL.C_FK_code = CR.C_Region_code where CL.C_FK_code=@C_Region_code and CL.B_Case_link_type=6) As CBP2 on CBP2.B_Case_code=T.B_Case_code ");
            //            g = 1;
            //        }
            //        //专业顾问
            //        if (!String.IsNullOrEmpty(model.B_Consultant_code))
            //        {
            //            //strSql.Append("left join(select C_Userinfo_code,B_Case_code from B_Case_link As CL  left join C_Userinfo As U  on CL.C_FK_code = U.C_Userinfo_code where CL.C_FK_code in " + model.B_Consultant_code + " and CL.B_Case_link_type=11) As CCP on CCP.B_Case_code=T.B_Case_code ");
            //            h = 1;
            //        }
            //        //承办律师
            //        if (!String.IsNullOrEmpty(model.B_Case_lawyerCode.ToString()))
            //        {
            //            strSql.Append("left join (select distinct BF.P_Fk_code,U.C_Userinfo_code from P_Business_flow as BF left join C_Userinfo as U on BF.P_Business_person=U.C_Userinfo_code where U.C_Userinfo_code=@B_Case_lawyerCode) As BU on BU.P_Fk_code=T.B_Case_code ");
            //            i = 1;
            //        }
            //    }
            //    ////流程查询
            //    //if (flowModel != null)
            //    //{
            //    //    if ((flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "") || (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != ""))
            //    //    {
            //    //        strSql.Append(" left join (select * from P_Business_flow ) As PBflow on PBflow.P_Fk_code=T.B_Case_code ");
            //    //    }
            //    //}
            //    strSql.Append(" where 1=1 and B_Case_isDelete=0 ");

            //    //专业顾问
            //    if (!String.IsNullOrEmpty(model.B_Consultant_code))
            //    {
            //        strSql.Append(" and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code in ('" + model.B_Consultant_code + "')) ");
            //    }

            //    //部门
            //    if (!String.IsNullOrEmpty(model.B_Case_organizationCode))
            //    {
            //        strSql.Append("and exists(select 1 from C_Userinfo As CU with(nolock) ");
            //        strSql.Append("where CU.C_Userinfo_isDelete=0 ");
            //        strSql.Append("and exists(select 1 from DeptTree('" + model.B_Case_organizationCode + "') as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
            //        strSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
            //        strSql.Append(") ");
            //    }
            //}
            //else if (model.B_Case_oprationtype == 2)
            //{
            //    strSql.Append(")AS Row, T.*  from B_Case_link CL ");
            //    strSql.Append("left join B_Case as T on CL.B_Case_code=T.B_Case_code ");
            //    strSql.Append("where CL.C_FK_code=@C_FK_code and CL.B_Case_link_isDelete=0 ");
            //}
            //if (model != null)
            //{
            //    if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_code=@B_Case_code ");
            //    }
            //    if (model.B_Case_name != null && model.B_Case_name.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
            //    }
            //    if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_type=@B_Case_type ");
            //    }
            //    if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_nature=@B_Case_nature ");
            //    }
            //    if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_customerType=@B_Case_customerType ");
            //    }
            //    if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_state=@B_Case_state ");
            //    }
            //    //新添加条件查询
            //    if (!string.IsNullOrEmpty(model.B_Case_number))
            //    {
            //        strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
            //    }
            //    if (a == 1)
            //    {
            //        strSql.Append("and C_Involved_project_code=@C_Project_code ");
            //    }
            //    int f = 0;
            //    if (b == 1 && c == 1)
            //    {
            //        strSql.Append("and cp.C_Customer_code=@C_Customer_code ");
            //        strSql.Append("and cp2.C_Customer_code=@C_Client_code ");
            //        f = 1;

            //    }
            //    if (f == 0)
            //    {
            //        if (b == 1)
            //        {
            //            strSql.Append("and C_Customer_code=@C_Customer_code ");
            //        }
            //        if (c == 1)
            //        {
            //            strSql.Append("and C_Customer_code=@C_Client_code ");
            //        }

            //    }
            //    if (!string.IsNullOrEmpty(model.B_Case_consultant_code.ToString()))
            //    {
            //        strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
            //    }
            //    if (e == 1)
            //    {
            //        strSql.Append("and C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code ");
            //    }
            //    if (g == 1)
            //    {
            //        strSql.Append("and C_Region_code=@C_Region_code ");
            //    }
            //    if (h == 1)
            //    {
            //        //strSql.Append("and CCP.C_Userinfo_code in " + model.B_Consultant_code);
            //    }
            //    if (i == 1)
            //    {
            //        strSql.Append("and BU.C_Userinfo_code = @B_Case_lawyerCode ");
            //    }
            //    if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
            //    {
            //        strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
            //    }
            //    if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
            //    {
            //        strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
            //    }
            //    if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
            //    {
            //        strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
            //    }
            //    //if (flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "")
            //    //{
            //    //    strSql.Append(" and PBflow.P_Business_state=@P_Business_state");
            //    //}
            //    //if (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != "")
            //    //{
            //    //    strSql.Append(" and PBflow.P_Business_person=@P_Business_person");
            //    //}
            //    if (flowModel != null)
            //    {
            //        if ((flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "") || (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != ""))
            //        {
            //            strSql.Append(" and exists (select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=t.B_Case_code ");
            //        }
            //        else
            //        {
            //            strSql.Append(" and(1=1 ");
            //        }
            //        if (flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "")
            //        {
            //            strSql.Append(" and PBF.P_Business_state=@P_Business_state");
            //        }
            //        if (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != "")
            //        {
            //            strSql.Append(" and (PBF.P_Business_person=@P_Business_person ");

            //            strSql.Append("or exists(select 1 from P_Business_flow_form as PFF where pff.P_Business_flow_form_isdelete=0 and pff.P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Fk_code=t.B_Case_code)) or (select count(1) from P_Business_flow_form as PFF where pff.P_Business_flow_code=pbf.P_Business_flow_code and pff.P_Business_flow_form_person=@P_Business_person )>0 )");
            //        }
            //        strSql.Append(" ) ");
            //    }
            //}

            //#region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            //if (!IsPreSetManager)
            //{//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
            //    StringBuilder strPowerSql = new StringBuilder();
            //    strPowerSql.Append(" and (1<>1 ");
            //    if (rolePowerIds.Contains(",1,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",2,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
            //    }
            //    if (rolePowerIds.Contains(",3,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",4,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",5,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
            //        strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
            //        strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
            //        strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
            //        strPowerSql.Append(") ");
            //    }
            //    if (rolePowerIds.Contains(",6,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");
            //    }
            //    if (rolePowerIds.Contains(",7,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
            //    }
            //    if (rolePowerIds.Contains(",8,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
            //        strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
            //    }
            //    if (rolePowerIds.Contains(",17,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
            //    }

            //    #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
            //    //案件负责人
            //    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
            //    //销售顾问
            //    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    //业务流程负责人
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    //主办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
            //    //协办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

            //    #endregion

            //    strPowerSql.Append(") ");
            //    strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            //}
            //#endregion

            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1} order by B_Case_firstClassResponsiblePerson desc", startIndex, endIndex);
            #endregion

            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),                 
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_state", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_lawyerCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Consultant_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_organizationCode",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_sureDate",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_sureDateEnd",SqlDbType.DateTime),
                    new SqlParameter("@Flow_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_CaseLevelchange_type",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.B_Case_name == null ? "" : model.B_Case_name;
            parameters[1].Value = model.B_Case_code == null ? Guid.NewGuid() : model.B_Case_code;
            parameters[2].Value = model.B_Case_type == null ? 0 : model.B_Case_type;
            parameters[3].Value = model.B_Case_nature == null ? 0 : model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType == null ? 0 : model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode == null ? Guid.NewGuid() : model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage == null ? "" : model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code == null ? "" : model.C_Project_code;
            parameters[8].Value = model.C_Customer_code == null ? "" : model.C_Customer_code;
            parameters[9].Value = model.C_Client_code == null ? "" : model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code == null ? "" : model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number == null ? "" : model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst == null ? Guid.NewGuid() : model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_transferTargetMoney == null ? 0 : model.B_Case_transferTargetMoney;
            parameters[14].Value = model.B_Case_execMoney2 == null ? 0 : model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime == null ? DateTime.Now : model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2 == null ? DateTime.Now : model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state == null ? 0 : model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code == null ? Guid.NewGuid() : model.B_Case_consultant_code;
            parameters[19].Value = model.C_Region_code == null ? "" : model.C_Region_code;
            parameters[20].Value = userCode == null ? Guid.NewGuid() : userCode;          
            parameters[21].Value = deptCode == null ? Guid.NewGuid() : deptCode;
            parameters[22].Value = postCode == null ? Guid.NewGuid() : postCode;
            parameters[23].Value = 0; //flowModel.P_Business_state;目前在过滤条件里，没有用到此条件
            parameters[24].Value = vLawyerCond == null ? Guid.NewGuid() : vLawyerCond.LawyerCode; //flowModel.P_Business_person;
            parameters[25].Value = vLawyerCond == null ? Guid.NewGuid() : vLawyerCond.LawyerCode; //model.P_Business_flow_form_person;
            parameters[26].Value = model.B_Case_lawyerCode == null ? Guid.NewGuid() : model.B_Case_lawyerCode;
            parameters[27].Value = model.B_Consultant_code == null ? "" : model.B_Consultant_code;
            parameters[28].Value = model.B_Case_organizationCode == null ? "" : model.B_Case_organizationCode;
            parameters[29].Value = model.B_Case_sureDate == null ? DateTime.Now : model.B_Case_sureDate;
            parameters[30].Value = model.B_Case_sureDateEnd == null ? DateTime.Now : model.B_Case_sureDateEnd;
            parameters[31].Value = model.Flow_code == null ? Guid.NewGuid() : model.Flow_code;
            parameters[32].Value = model.B_Case_isNotAudited == null ? 0 : model.B_Case_isNotAudited;

            return DbHelperSQL.Query(sql.ToString(), parameters);
        }

        /// <summary>
        /// 导出关联权限的案件数据(hety,2016-03-10)
        /// </summary>
        /// <param name="vLawyerCond"></param>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="IsPreSetManager"></param>
        /// <param name="rolePowerIds"></param>
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public DataSet ExportPowerListByPage(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            #region 查询重写 张东洋20150923

            StringBuilder sql = new StringBuilder();
            sql.Append("select *,U.C_Userinfo_name as B_Case_personName,UI.C_Userinfo_name as C_Case_firstClassResponsiblePersonName,");
            sql.Append("(select top 1 M_Entry_Statistics_Management from M_Entry_Statistics  M where M.M_Case_number=T.B_Case_number and M.M_Entry_Statistics_HandlingState=470 and M.M_Entry_Statistics_isDelete=0) as M_Entry_Statistics_Management,");
            sql.Append("(case when ((select count(1) from J_Milepost where J_Milepost.J_Milepost_CaseNumber=T.B_Case_number and J_Milepost.J_Milepost_isDelete=0)>0 or (select count(1) from [J_No_Milepost] where [J_No_Milepost].J_No_Milepost_CaseNumber=T.B_Case_number and [J_No_Milepost].J_No_Milepost_isDelete=0)>0) then 1 else 0 end) as Ischeck,(case when ((select top 1 M_Entry_Statistics_HandlingState from M_Entry_Statistics where M_Entry_Statistics.M_Case_number=T.B_Case_number and M_Entry_Statistics.M_Entry_Statistics_isDelete=0)=470 ) then '已超时' else '' end) as Ischeck2,(case when ((select top 1 M_Entry_Statistics_warningSituation from M_Entry_Statistics where M_Entry_Statistics.M_Case_number=T.B_Case_number and M_Entry_Statistics.M_Entry_Statistics_isDelete=0 and M_Entry_Statistics.M_Entry_Statistics_HandlingState!=470)=464) then '预警中' else '' end) as Ischeck3,");
            sql.Append("(select B_BusinessChance_name from B_BusinessChance with(nolock) where B_BusinessChance.B_BusinessChance_code=T.B_Case_businessChance_Code) as B_Case_businessChance_Name,");
            sql.Append("(select count(1) from M_Entry_Statistics As S with(nolock),M_Entry_Change As EC with(nolock) where S.M_Entry_Statistics_code=EC.M_Entry_Statistics_code and S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=T.B_Case_code and EC.M_Entry_Change_IsThrough<>328) As B_Case_Delay_Entry_Statistics_Count,");
            sql.Append("(select count(1) from M_Entry_Statistics As S with(nolock) where S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=T.B_Case_code and S.M_Entry_Statistics_HandlingState=470) As B_Case_HandlingState_Entry_Statistics_Count,");
            sql.Append("(select count(1) from M_Entry_Statistics As S with(nolock) where S.M_Entry_Statistics_isDelete=0 and S.M_Entry_Statistics_status=397 and S.M_Case_code=T.B_Case_code and S.M_Entry_Statistics_warningSituation=464) As B_Case_WarningSituation_Entry_Statistics_Count,");
            sql.Append("dbo.getCheckAuthorityStatus(T.B_Case_code) As B_Case_IsCheckAuthority,");
            sql.Append("dbo.getCaseLevel(B_Case_code) As B_Case_caseGrade,");
            sql.Append("(select count(1) from B_CaseLevelchange as CLC where CLC.B_Case_code=T.B_Case_code and CLC.B_CaseLevelchange_state=947 and CLC.B_CaseLevelchange_IsValid=0 and CLC.B_CaseLevelchange_isDelete=0) As B_Case_isNotAudited,");

            sql.Append("(select top 1 Consultant.C_Userinfo_name from B_Case_link As BL with(nolock),C_Userinfo As Consultant with(nolock) where BL.C_FK_code=Consultant.C_Userinfo_code and BL.B_Case_code=T.B_Case_code and BL.B_Case_link_isDelete=0 and BL.B_Case_link_type=11 and Consultant.C_Userinfo_isDelete=0 and Consultant.C_Userinfo_state=1) As B_Case_consultant_name,");
            sql.Append("(select top 1 CaseType.C_Parameters_name from C_Parameters As CaseType with(nolock) where CaseType.C_Parameters_id=T.B_Case_type) As B_Case_type_name,");
            sql.Append("(select top 1 Region.C_Region_name from B_Case_link As BL with(nolock),C_Region As Region with(nolock) where BL.C_FK_code=Region.C_Region_code and BL.B_Case_code=T.B_Case_code and BL.B_Case_link_isDelete=0 and BL.B_Case_link_type=6 and Region.C_Region_isDelete=0) As C_Region_name,");
            sql.Append("(select top 1 CaseState.C_Parameters_name from C_Parameters As CaseState with(nolock) where CaseState.C_Parameters_id=T.B_Case_state) As B_Case_state_name,");
            sql.Append("dbo.getBusinessFlowNameByCaseCode(T.B_Case_code) As B_Case_StageName,");
            sql.Append("dbo.getWenShuIncomeByCaseCode(T.B_Case_code) As B_Case_wenshuInCome,");
            sql.Append("dbo.getYuQiIncomeByCaseCode(T.B_Case_code) As B_Case_yuqiInCome ");            

            sql.Append("from B_Case T  ");
            sql.Append("left join C_Userinfo U on T.B_Case_person=U.C_Userinfo_code ");
            sql.Append("left join C_Userinfo UI on T.B_Case_firstClassResponsiblePerson=UI.C_Userinfo_code ");
            sql.Append("where 1=1 and T.B_Case_isDelete=0 ");
 
            if (model != null)
            {
                //收案时间
                if ((model.B_Case_registerTime != null) && (model.B_Case_registerTime2 != null))
                {
                    sql.Append("and T.B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

                //办案阶段条件
                if (!string.IsNullOrEmpty(model.B_Case_Stage))
                {
                    sql.Append(" and exists(select 1 from P_Business_flow where P_Business_flow.P_Flow_code=@B_Case_Stage and P_Business_flow.P_Fk_code=T.B_Case_code and P_Business_flow.P_Business_isdelete=0)");
                }

                //工程
                if (!string.IsNullOrEmpty(model.C_Project_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Project_code and B_Case_link.B_Case_link_type=7)");
                }

                //客户
                if (!string.IsNullOrEmpty(model.C_Customer_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Customer_code and B_Case_link.B_Case_link_type=0)");
                }

                //委托人
                if (!string.IsNullOrEmpty(model.C_Client_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Client_code and B_Case_link.B_Case_link_type=1)");
                }

                //对方当事人
                if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Case_Rival_code and (B_Case_link.B_Case_link_type=2 or B_Case_link.B_Case_link_type=3))");
                }

                //区域
                if (!string.IsNullOrEmpty(model.C_Region_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Region_code and B_Case_link.B_Case_link_type=6)");
                }

                //承办律师
                if (!String.IsNullOrEmpty(model.B_Case_lawyerCode.ToString()))
                {
                    sql.Append(" and (exists(select 1 from P_Business_flow where T.B_Case_code=P_Business_flow.P_FK_code and P_Business_flow.P_Business_isdelete=0 and P_Business_flow.P_Business_person=@B_Case_lawyerCode)"); //流程负责人                
                    sql.Append(")");                  
                }

                //专业顾问
                if (!string.IsNullOrEmpty(model.B_Consultant_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Consultant_code and B_Case_link.B_Case_link_type=11)");
                }

                //部门
                if (!string.IsNullOrEmpty(model.B_Case_organizationCode))
                {
                    sql.Append(" and exists(select 1 from C_Userinfo As CU with(nolock) ");
                    sql.Append("where CU.C_Userinfo_isDelete=0 ");
                    sql.Append("and exists(select 1 from DeptTree(@B_Case_organizationCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    sql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    sql.Append(") ");
                }

                //法院
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    sql.Append(" and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }

                //案件名称
                if (!string.IsNullOrEmpty(model.B_Case_name))
                {
                    sql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }

                //案件类型
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    sql.Append("and B_Case_type=@B_Case_type ");
                }

                //案件性质
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    sql.Append("and B_Case_nature=@B_Case_nature ");
                }

                //客户类型
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    sql.Append("and B_Case_customerType=@B_Case_customerType ");
                }

                //案件状态
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    sql.Append("and B_Case_state=@B_Case_state ");
                }

                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    sql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }

                //预期收益范围
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    sql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }

                //预收案时间
                if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
                {
                    sql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

                //首席确认开始时间
                if (!string.IsNullOrEmpty(model.B_Case_sureDate.ToString()))
                {
                    sql.Append("and B_Case_sureDate>=@B_Case_sureDate ");
                }

                //首席确认结束时间
                if (!string.IsNullOrEmpty(model.B_Case_sureDateEnd.ToString()))
                {
                    sql.Append("and B_Case_sureDate<=@B_Case_sureDateEnd ");
                }

                //案件是否包含流程（监控中心用到）
                if (model.Flow_code != null && model.Flow_code.ToString() != "" && model.Flow_code.ToString() != "0")
                {
                    sql.Append("and exists(select 1 from P_Business_Flow where P_FK_Code=B_Case_code and P_Business_isDelete=0 and P_Flow_code=@Flow_code)");
                }
                //案件级别
                if (model.B_Case_isNotAudited != null)
                {
                    if (model.B_Case_isNotAudited == 1)
                    {//正常
                        sql.Append("and not exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_IsValid=1 and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                    }
                    else
                    {
                        sql.Append("and exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_type=@B_CaseLevelchange_type and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                    }
                }
                //重大难案
                if (model.B_Case_Majordifficult == 2)
                {
                    sql.Append("and exists(select top 1 * from B_CaseLevelchange as CLC where T.B_Case_code=CLC.B_Case_code and CLC.B_CaseLevelchange_IsValid=1 and CLC.B_CaseLevelchange_state=948 and CLC.B_CaseLevelchange_isDelete=0)");
                }                 
            }

            #region hety,2015-12-01,针对律师案件列表：我的未开始、我的在办、我的已结 案件列表加入当前登录人(律师)过滤条件(内置系统管理员除外)
            if (vLawyerCond != null)
            {
                if (vLawyerCond.LawyerType == 0)
                {//默认
                    #region 默认
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束的案件(并且关联业务流程的负责人为当前操作人自己))
                         *           OR 协办律师(关联业务表单进行状态为：未开始或已结束的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束或正在进行的案件(并且关联业务流程的负责人为当前操作人自己))
                          *           OR 协办律师(关联业务表单进行状态为：未开始或已结束或正在进行的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state=200) ");
                            sql.Append("or exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_state=200) ");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person and BF.P_Business_state=200) ");
                            sql.Append("or exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person and BFF.P_Business_flow_form_state=200) ");
                            sql.Append(") ");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：已结束的案件(并且关联业务流程的负责人为当前操作人自己))
                          *           OR 协办律师(关联业务表单进行状态为：已结束的案件(并且关联业务表单负责人为当前操作人自己)(并且关联业务表单审核状态不为：已作废))
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(") ");
                            sql.Append("or");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
                else if (vLawyerCond.LawyerType == 1)
                {
                    #region 主办律师
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束的案件(并且关联业务流程的负责人为当前操作人自己))                     
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：未开始或已结束或正在进行的案件(并且关联业务流程的负责人为当前操作人自己))                     
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state=200) ");
                        }
                        else
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person and BF.P_Business_state=200) ");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：主办律师(关联业务流程进行状态为：已结束的案件(并且关联业务流程的负责人为当前操作人自己))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_state IS NOT NULL) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Fk_code=T.B_Case_code and (BF.P_Business_state=199 or BF.P_Business_state=200 or BF.P_Business_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow AS BF with(nolock) where BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person=@P_Business_person) ");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
                else if (vLawyerCond.LawyerType == 2)
                {
                    #region 协办律师
                    if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        /**
                         * 过滤条件：协办律师(关联业务表单进行状态为：未开始或已结束的案件(并且关联业务表单负责人为当前操作人自己，并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                       
                         ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        /**
                          * 过滤条件：协办律师(关联业务表单进行状态为：未开始或已结束或正在进行的案件(并且关联业务表单负责人为当前操作人自己,并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BFF.P_Business_flow_form_state=200) ");
                        }
                        else
                        {
                            sql.Append(" and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person and BFF.P_Business_flow_form_state=200)");
                        }

                    }
                    else if (vLawyerCond.OperateStatus == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        /**
                          * 过滤条件：协办律师(关联业务表单进行状态为：已结束的案件(并且关联业务表单负责人为当前操作人自己,并且关联表单所属业务流程负责人非当前操作人自己)(并且关联业务表单审核状态不为：已作废))                      
                          ***/
                        if (IsPreSetManager)
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                        else
                        {
                            sql.Append(" and(");
                            sql.Append("(");
                            sql.Append("not exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Fk_code=T.B_Case_code and (BFF.P_Business_flow_form_state=199 or BFF.P_Business_flow_form_state=200 or BFF.P_Business_flow_form_state=345)) ");
                            sql.Append("and exists(select 1 from P_Business_flow_form AS BFF with(nolock),P_Business_flow AS BF with(nolock) where BFF.P_Business_flow_code=BF.P_Business_flow_code and BF.P_Business_isdelete=0 and BF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_form_status<>766 and BF.P_Business_person<>BFF.P_Business_flow_form_person and BFF.P_Business_flow_form_person=@P_Business_flow_form_person)");
                            sql.Append(")");
                            sql.Append(") ");
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Organization_code=@ThisDeptCode ");
                    strPowerSql.Append("and CRR.C_Post_code=@ThisPostCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }                 

                strPowerSql.Append(") ");
                sql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            if (!string.IsNullOrEmpty(orderby))
            {
                sql.Append(" order by " + orderby);
            }
            else
            {
                sql.Append(" order by B_Case_id desc");
            }
            sql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);

            #endregion

            #region 老sql
            //int a = 0, b = 0, c = 0, d = 0, e = 0, g = 0, h = 0, i = 0;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append("order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append("order by T.B_Case_id desc");
            //}
            //if (model.B_Case_oprationtype == 1)
            //{//案件列表
            //    strSql.Append(")AS Row, T.*,BC.B_BusinessChance_name as 'B_Case_businessChance_Name' from B_Case T left join B_BusinessChance as BC on T.B_Case_businessChance_Code=BC.B_BusinessChance_code ");
            //    if (model != null)
            //    {
            //        //办案阶段限制
            //        if (!string.IsNullOrEmpty(model.B_Case_Stage))
            //        {
            //            strSql.Append("right join (select distinct(P_Fk_code) from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
            //        }
            //        //工程
            //        if (!string.IsNullOrEmpty(model.C_Project_code))
            //        {
            //            strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
            //            a = 1;
            //        }
            //        //客户   委托人
            //        if ((!string.IsNullOrEmpty(model.C_Customer_code)) && (!string.IsNullOrEmpty(model.C_Client_code)))
            //        {
            //            strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

            //            strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

            //            b = c = d = 1;
            //        }
            //        if (d != 1)
            //        {
            //            if ((!string.IsNullOrEmpty(model.C_Customer_code)) || (!string.IsNullOrEmpty(model.C_Client_code)))
            //            {
            //                if (!string.IsNullOrEmpty(model.C_Customer_code))
            //                {//客户
            //                    strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
            //                    b = 1;
            //                }
            //                if (!string.IsNullOrEmpty(model.C_Client_code))
            //                {//委托人
            //                    strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
            //                    c = 1;
            //                }

            //            }
            //        }
            //        //对方当事人
            //        if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
            //        {
            //            strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
            //            strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
            //            e = 1;
            //        }
            //        //区域
            //        if (!String.IsNullOrEmpty(model.C_Region_code))
            //        {
            //            strSql.Append("left join(select C_Region_code,B_Case_code from B_Case_link As CL  left join C_Region As CR  on CL.C_FK_code = CR.C_Region_code where CL.C_FK_code=@C_Region_code and CL.B_Case_link_type=6) As CBP2 on CBP2.B_Case_code=T.B_Case_code ");
            //            g = 1;
            //        }
            //        //专业顾问
            //        if (!String.IsNullOrEmpty(model.B_Consultant_code))
            //        {
            //            //strSql.Append("left join(select C_Userinfo_code,B_Case_code from B_Case_link As CL  left join C_Userinfo As U  on CL.C_FK_code = U.C_Userinfo_code where CL.C_FK_code in " + model.B_Consultant_code + " and CL.B_Case_link_type=11) As CCP on CCP.B_Case_code=T.B_Case_code ");
            //            h = 1;
            //        }
            //        //承办律师
            //        if (!String.IsNullOrEmpty(model.B_Case_lawyerCode.ToString()))
            //        {
            //            strSql.Append("left join (select distinct BF.P_Fk_code,U.C_Userinfo_code from P_Business_flow as BF left join C_Userinfo as U on BF.P_Business_person=U.C_Userinfo_code where U.C_Userinfo_code=@B_Case_lawyerCode) As BU on BU.P_Fk_code=T.B_Case_code ");
            //            i = 1;
            //        }
            //    }
            //    ////流程查询
            //    //if (flowModel != null)
            //    //{
            //    //    if ((flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "") || (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != ""))
            //    //    {
            //    //        strSql.Append(" left join (select * from P_Business_flow ) As PBflow on PBflow.P_Fk_code=T.B_Case_code ");
            //    //    }
            //    //}
            //    strSql.Append(" where 1=1 and B_Case_isDelete=0 ");

            //    //专业顾问
            //    if (!String.IsNullOrEmpty(model.B_Consultant_code))
            //    {
            //        strSql.Append(" and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code in ('" + model.B_Consultant_code + "')) ");
            //    }

            //    //部门
            //    if (!String.IsNullOrEmpty(model.B_Case_organizationCode))
            //    {
            //        strSql.Append("and exists(select 1 from C_Userinfo As CU with(nolock) ");
            //        strSql.Append("where CU.C_Userinfo_isDelete=0 ");
            //        strSql.Append("and exists(select 1 from DeptTree('" + model.B_Case_organizationCode + "') as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
            //        strSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
            //        strSql.Append(") ");
            //    }
            //}
            //else if (model.B_Case_oprationtype == 2)
            //{
            //    strSql.Append(")AS Row, T.*  from B_Case_link CL ");
            //    strSql.Append("left join B_Case as T on CL.B_Case_code=T.B_Case_code ");
            //    strSql.Append("where CL.C_FK_code=@C_FK_code and CL.B_Case_link_isDelete=0 ");
            //}
            //if (model != null)
            //{
            //    if (model.B_Case_code != null && model.B_Case_code.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_code=@B_Case_code ");
            //    }
            //    if (model.B_Case_name != null && model.B_Case_name.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
            //    }
            //    if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_type=@B_Case_type ");
            //    }
            //    if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_nature=@B_Case_nature ");
            //    }
            //    if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_customerType=@B_Case_customerType ");
            //    }
            //    if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_state=@B_Case_state ");
            //    }
            //    //新添加条件查询
            //    if (!string.IsNullOrEmpty(model.B_Case_number))
            //    {
            //        strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
            //    }
            //    if (a == 1)
            //    {
            //        strSql.Append("and C_Involved_project_code=@C_Project_code ");
            //    }
            //    int f = 0;
            //    if (b == 1 && c == 1)
            //    {
            //        strSql.Append("and cp.C_Customer_code=@C_Customer_code ");
            //        strSql.Append("and cp2.C_Customer_code=@C_Client_code ");
            //        f = 1;

            //    }
            //    if (f == 0)
            //    {
            //        if (b == 1)
            //        {
            //            strSql.Append("and C_Customer_code=@C_Customer_code ");
            //        }
            //        if (c == 1)
            //        {
            //            strSql.Append("and C_Customer_code=@C_Client_code ");
            //        }

            //    }
            //    if (!string.IsNullOrEmpty(model.B_Case_consultant_code.ToString()))
            //    {
            //        strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
            //    }
            //    if (e == 1)
            //    {
            //        strSql.Append("and C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code ");
            //    }
            //    if (g == 1)
            //    {
            //        strSql.Append("and C_Region_code=@C_Region_code ");
            //    }
            //    if (h == 1)
            //    {
            //        //strSql.Append("and CCP.C_Userinfo_code in " + model.B_Consultant_code);
            //    }
            //    if (i == 1)
            //    {
            //        strSql.Append("and BU.C_Userinfo_code = @B_Case_lawyerCode ");
            //    }
            //    if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
            //    {
            //        strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
            //    }
            //    if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
            //    {
            //        strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
            //    }
            //    if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
            //    {
            //        strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
            //    }
            //    //if (flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "")
            //    //{
            //    //    strSql.Append(" and PBflow.P_Business_state=@P_Business_state");
            //    //}
            //    //if (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != "")
            //    //{
            //    //    strSql.Append(" and PBflow.P_Business_person=@P_Business_person");
            //    //}
            //    if (flowModel != null)
            //    {
            //        if ((flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "") || (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != ""))
            //        {
            //            strSql.Append(" and exists (select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=t.B_Case_code ");
            //        }
            //        else
            //        {
            //            strSql.Append(" and(1=1 ");
            //        }
            //        if (flowModel.P_Business_state != null && flowModel.P_Business_state.ToString() != "")
            //        {
            //            strSql.Append(" and PBF.P_Business_state=@P_Business_state");
            //        }
            //        if (flowModel.P_Business_person != null && flowModel.P_Business_person.ToString() != "")
            //        {
            //            strSql.Append(" and (PBF.P_Business_person=@P_Business_person ");

            //            strSql.Append("or exists(select 1 from P_Business_flow_form as PFF where pff.P_Business_flow_form_isdelete=0 and pff.P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Fk_code=t.B_Case_code)) or (select count(1) from P_Business_flow_form as PFF where pff.P_Business_flow_code=pbf.P_Business_flow_code and pff.P_Business_flow_form_person=@P_Business_person )>0 )");
            //        }
            //        strSql.Append(" ) ");
            //    }
            //}

            //#region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            //if (!IsPreSetManager)
            //{//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
            //    StringBuilder strPowerSql = new StringBuilder();
            //    strPowerSql.Append(" and (1<>1 ");
            //    if (rolePowerIds.Contains(",1,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",2,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
            //    }
            //    if (rolePowerIds.Contains(",3,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",4,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",5,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
            //        strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
            //        strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
            //        strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
            //        strPowerSql.Append(") ");
            //    }
            //    if (rolePowerIds.Contains(",6,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");
            //    }
            //    if (rolePowerIds.Contains(",7,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
            //    }
            //    if (rolePowerIds.Contains(",8,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
            //        strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
            //    }
            //    if (rolePowerIds.Contains(",17,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
            //    }

            //    #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
            //    //案件负责人
            //    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
            //    //销售顾问
            //    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    //业务流程负责人
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    //主办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
            //    //协办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

            //    #endregion

            //    strPowerSql.Append(") ");
            //    strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            //}
            //#endregion

            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1} order by B_Case_firstClassResponsiblePerson desc", startIndex, endIndex);
            #endregion

            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),                 
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_state", SqlDbType.Int,4),
                    new SqlParameter("@P_Business_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_lawyerCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Consultant_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_organizationCode",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_sureDate",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_sureDateEnd",SqlDbType.DateTime),
                    new SqlParameter("@Flow_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_CaseLevelchange_type",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.B_Case_name == null ? "" : model.B_Case_name;
            parameters[1].Value = model.B_Case_code == null ? Guid.NewGuid() : model.B_Case_code;
            parameters[2].Value = model.B_Case_type == null ? 0 : model.B_Case_type;
            parameters[3].Value = model.B_Case_nature == null ? 0 : model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType == null ? 0 : model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode == null ? Guid.NewGuid() : model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage == null ? "" : model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code == null ? "" : model.C_Project_code;
            parameters[8].Value = model.C_Customer_code == null ? "" : model.C_Customer_code;
            parameters[9].Value = model.C_Client_code == null ? "" : model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code == null ? "" : model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number == null ? "" : model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst == null ? Guid.NewGuid() : model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_transferTargetMoney == null ? 0 : model.B_Case_transferTargetMoney;
            parameters[14].Value = model.B_Case_execMoney2 == null ? 0 : model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime == null ? DateTime.Now : model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2 == null ? DateTime.Now : model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state == null ? 0 : model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code == null ? Guid.NewGuid() : model.B_Case_consultant_code;
            parameters[19].Value = model.C_Region_code == null ? "" : model.C_Region_code;
            parameters[20].Value = userCode == null ? Guid.NewGuid() : userCode;
            parameters[21].Value = deptCode == null ? Guid.NewGuid() : deptCode;
            parameters[22].Value = postCode == null ? Guid.NewGuid() : postCode;
            parameters[23].Value = 0; //flowModel.P_Business_state;目前在过滤条件里，没有用到此条件
            parameters[24].Value = vLawyerCond == null ? Guid.NewGuid() : vLawyerCond.LawyerCode; //flowModel.P_Business_person;
            parameters[25].Value = vLawyerCond == null ? Guid.NewGuid() : vLawyerCond.LawyerCode; //model.P_Business_flow_form_person;
            parameters[26].Value = model.B_Case_lawyerCode == null ? Guid.NewGuid() : model.B_Case_lawyerCode;
            parameters[27].Value = model.B_Consultant_code == null ? "" : model.B_Consultant_code;
            parameters[28].Value = model.B_Case_organizationCode == null ? "" : model.B_Case_organizationCode;
            parameters[29].Value = model.B_Case_sureDate == null ? DateTime.Now : model.B_Case_sureDate;
            parameters[30].Value = model.B_Case_sureDateEnd == null ? DateTime.Now : model.B_Case_sureDateEnd;
            parameters[31].Value = model.Flow_code == null ? Guid.NewGuid() : model.Flow_code;
            parameters[32].Value = model.B_Case_isNotAudited == null ? 0 : model.B_Case_isNotAudited;

            return DbHelperSQL.Query(sql.ToString(), parameters);
        }


        /// <summary>
        /// 根据表单guid得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case GetModelbyFormcode(Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.P_Business_flow_name as P_business_flow_name,d.F_Form_chineseName as F_form_name  from O_Form as e  ");
            strSql.Append(" left join P_Business_flow_form as c on e.O_Form_businessFlowform=c.P_Business_flow_form_code ");
            strSql.Append(" left join F_Form as d on d.F_Form_code=c.F_Form_code ");
            strSql.Append(" left join P_Business_flow as b on b.P_Business_flow_code=c.P_Business_flow_code  ");
            strSql.Append(" left join B_Case as a on a.B_Case_code=b.P_Fk_code where c.P_Business_flow_form_code=@P_Business_flow_form_code and a.B_Case_isDelete=0 and b.P_Business_isdelete=0 and c.P_Business_flow_form_isdelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = formCode;

            CommonService.Model.CaseManager.B_Case model = new CommonService.Model.CaseManager.B_Case();
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

        public string GetFormValue(string F_FormPropertyValue_BusinessFlowFormCode, string F_Form_chineseName, string F_Form_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_FormPropertyValue_value from F_FormPropertyValue where F_FormPropertyValue_BusinessFlowFormCode=@F_FormPropertyValue_BusinessFlowFormCode ");
            strSql.Append("and F_FormPropertyValue_formProperty=(select top 1 F_FormProperty_code from F_FormProperty where F_FormProperty_form=(select F_Form_code from F_Form where F_Form_code=@F_Form_code) ");
            strSql.Append("  and F_FormProperty_showName=@F_Form_chineseName) and F_FormPropertyValue_isDelete=0 ");

            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_BusinessFlowFormCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_chineseName", SqlDbType.VarChar,50),
                      new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = Guid.Parse(F_FormPropertyValue_BusinessFlowFormCode);
            parameters[1].Value = F_Form_chineseName;
            parameters[2].Value = Guid.Parse(F_Form_code);


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据客户code找相关的案件
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public DataSet GetCaseListByCustomer(Guid customerCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from B_Case as a ");
            strSql.Append("where exists(select 1 from B_Case_link as b where a.B_Case_code=b.B_Case_code and b.B_Case_link_type=0 and b.C_FK_code=@customerCode and b.B_Case_link_isDelete=0) ");
            strSql.Append("and a.B_Case_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@customerCode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = customerCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion  BasicMethod


        #region 转换报表实体
        /// <summary>
        /// 客户团队收案类型统计实体转换
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.Reporting.R_CaseType_Reporting R_CaseType_ReportingTranslate(DataRow row)
        {
            CommonService.Model.Reporting.R_CaseType_Reporting model = new CommonService.Model.Reporting.R_CaseType_Reporting();
            if (row != null)
            {
                if (row["年份"] != null && row["年份"].ToString() != "")
                {
                    model.年份 = row["年份"].ToString();
                }

                if (row["月份"] != null && row["月份"].ToString() != "")
                {
                    model.月份 = row["月份"].ToString();
                }

                if (row["地区"] != null && row["地区"].ToString() != "")
                {
                    model.地区 = row["地区"].ToString();
                }

                if (row["案件类型"] != null && row["案件类型"].ToString() != "")
                {
                    model.案件类型 = row["案件类型"].ToString();
                }

                if (row["收案总数"] != null && row["收案总数"].ToString() != "")
                {
                    model.收案总数 = row["收案总数"].ToString();
                }

                if (row["类型收案数"] != null && row["类型收案数"].ToString() != "")
                {
                    model.类型收案数 = row["类型收案数"].ToString();
                }

                if (row["非类型收案数"] != null && row["非类型收案数"].ToString() != "")
                {
                    model.非类型收案数 = row["非类型收案数"].ToString();
                }

                if (row["移交总标的"] != null && row["移交总标的"].ToString() != "")
                {
                    model.移交总标的 = row["移交总标的"].ToString();
                }

                if (row["类型移交标的"] != null && row["类型移交标的"].ToString() != "")
                {
                    model.类型移交标的 = row["类型移交标的"].ToString();
                }

                if (row["非类型移交标的"] != null && row["非类型移交标的"].ToString() != "")
                {
                    model.非类型移交标的 = row["非类型移交标的"].ToString();
                }

                if (row["预期总收益"] != null && row["预期总收益"].ToString() != "")
                {
                    model.预期总收益 = row["预期总收益"].ToString();
                }

                if (row["类型预期收益"] != null && row["类型预期收益"].ToString() != "")
                {
                    model.类型预期收益 = row["类型预期收益"].ToString();
                }

                if (row["非类型预期收益"] != null && row["非类型预期收益"].ToString() != "")
                {
                    model.非类型预期收益 = row["非类型预期收益"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 区域收案统计
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.Reporting.R_CaseArea_Reporting R_CaseArea_ReportingTranslate(DataRow row)
        {
            CommonService.Model.Reporting.R_CaseArea_Reporting model = new CommonService.Model.Reporting.R_CaseArea_Reporting();
            if (row != null)
            {
                if (row["年份"] != null && row["年份"].ToString() != "")
                {
                    model.收案年份 = row["年份"].ToString();
                }

                if (row["月份"] != null && row["月份"].ToString() != "")
                {
                    model.收案月份 = row["月份"].ToString();
                }

                if (row["地区"] != null && row["地区"].ToString() != "")
                {
                    model.地区 = row["地区"].ToString();
                }

                if (row["收案总数"] != null && row["收案总数"].ToString() != "")
                {
                    model.收案总数 = row["收案总数"].ToString();
                }

                if (row["类型收案数"] != null && row["类型收案数"].ToString() != "")
                {
                    model.类型收案数 = row["类型收案数"].ToString();
                }

                if (row["非类型收案数"] != null && row["非类型收案数"].ToString() != "")
                {
                    model.非类型收案数 = row["非类型收案数"].ToString();
                }

                if (row["客户总数"] != null && row["客户总数"].ToString() != "")
                {
                    model.客户总数 = row["客户总数"].ToString();
                }

                if (row["新客户"] != null && row["新客户"].ToString() != "")
                {
                    model.新客户 = row["新客户"].ToString();
                }

                if (row["老客户"] != null && row["老客户"].ToString() != "")
                {
                    model.老客户 = row["老客户"].ToString();
                }

                if (row["移交总标的"] != null && row["移交总标的"].ToString() != "")
                {
                    model.移交总标的 = row["移交总标的"].ToString();
                }

                if (row["类型移交标的"] != null && row["类型移交标的"].ToString() != "")
                {
                    model.类型移交标的 = row["类型移交标的"].ToString();
                }

                if (row["非类型移交标的"] != null && row["非类型移交标的"].ToString() != "")
                {
                    model.非类型移交标的 = row["非类型移交标的"].ToString();
                }

                if (row["预期总收益"] != null && row["预期总收益"].ToString() != "")
                {
                    model.预期总收益 = row["预期总收益"].ToString();
                }

                if (row["类型预期收益"] != null && row["类型预期收益"].ToString() != "")
                {
                    model.类型预期收益 = row["类型预期收益"].ToString();
                }

                if (row["非类型预期收益"] != null && row["非类型预期收益"].ToString() != "")
                {
                    model.非类型预期收益 = row["非类型预期收益"].ToString();
                }

                model.本月计划收案数 = "";
                model.计划收案完成率 = "";
                model.下月计划收案数 = "";
                model.本月计划预期收益 = "";
                model.计划收益完成率 = "";
                model.下月计划预期收益 = "";
            }
            return model;
        }

        /// <summary>
        /// 部门收案统计
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.Reporting.R_CaseOrgan_Reporting R_CaseOrgan_ReportingTranslate(DataRow row)
        {
            CommonService.Model.Reporting.R_CaseOrgan_Reporting model = new CommonService.Model.Reporting.R_CaseOrgan_Reporting();
            if (row != null)
            {
                if (row["年份"] != null && row["年份"].ToString() != "")
                {
                    model.收案年份 = row["年份"].ToString();
                }

                if (row["月份"] != null && row["月份"].ToString() != "")
                {
                    model.收案月份 = row["月份"].ToString();
                }

                if (row["地区"] != null && row["地区"].ToString() != "")
                {
                    model.地区 = row["地区"].ToString();
                }

                if (row["部门"] != null && row["部门"].ToString() != "")
                {
                    model.部门 = row["部门"].ToString();
                }

                if (row["收案总数"] != null && row["收案总数"].ToString() != "")
                {
                    model.收案总数 = row["收案总数"].ToString();
                }

                if (row["类型收案数"] != null && row["类型收案数"].ToString() != "")
                {
                    model.类型收案数 = row["类型收案数"].ToString();
                }

                if (row["非类型收案数"] != null && row["非类型收案数"].ToString() != "")
                {
                    model.非类型收案数 = row["非类型收案数"].ToString();
                }

                if (row["客户总数"] != null && row["客户总数"].ToString() != "")
                {
                    model.客户总数 = row["客户总数"].ToString();
                }

                if (row["新客户"] != null && row["新客户"].ToString() != "")
                {
                    model.新客户 = row["新客户"].ToString();
                }

                if (row["老客户"] != null && row["老客户"].ToString() != "")
                {
                    model.老客户 = row["老客户"].ToString();
                }

                if (row["移交总标的"] != null && row["移交总标的"].ToString() != "")
                {
                    model.移交总标的 = row["移交总标的"].ToString();
                }

                if (row["类型移交标的"] != null && row["类型移交标的"].ToString() != "")
                {
                    model.类型移交标的 = row["类型移交标的"].ToString();
                }

                if (row["非类型移交标的"] != null && row["非类型移交标的"].ToString() != "")
                {
                    model.非类型移交标的 = row["非类型移交标的"].ToString();
                }

                if (row["预期总收益"] != null && row["预期总收益"].ToString() != "")
                {
                    model.预期总收益 = row["预期总收益"].ToString();
                }

                if (row["类型预期收益"] != null && row["类型预期收益"].ToString() != "")
                {
                    model.类型预期收益 = row["类型预期收益"].ToString();
                }

                if (row["非类型预期收益"] != null && row["非类型预期收益"].ToString() != "")
                {
                    model.非类型预期收益 = row["非类型预期收益"].ToString();
                }

                model.本月计划收案数 = "";
                model.计划收案完成率 = "";
                model.下月计划收案数 = "";
                model.本月计划预期收益 = "";
                model.计划收益完成率 = "";
                model.下月计划预期收益 = "";
            }
            return model;
        }
        #endregion

        #region 报表

        /// <summary>
        /// 根据年份统计
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportByYear()
        {
            string sql = "select month(B_Case_registerTime) as 月份 ,count(1) as 数量,sum(B_Case_expectedGrant) as 预期收益,sum(B_Case_transferTargetMoney) as 移交标的 from B_Case where B_Case_isDelete=0 and year(B_Case_registerTime)=2015 group by month(B_Case_registerTime) order by month(B_Case_registerTime)";
            return DbHelperSQL.Query(sql);
        }


        /// <summary>
        /// 客户团队收案类型统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByCaseTypeCount(Model.Reporting.R_CaseType_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(tt.num) from ");
            strSql.Append("(select 1 as num ");
            strSql.Append("from B_Case ");
            strSql.Append("where B_Case_registerTime is not null and B_Case_isDelete=0 ");

            if (model.QueryArea != null && model.QueryArea.ToString() != "") //地区查询条件
            {
                strSql.Append(" and dbo.GetAreaCode(B_Case_code)=@QueryArea");
            }

            if (model.QueryStartTime != null) //开始预收案时间
            {
                strSql.Append(" and B_Case_registerTime>=@QueryStartTime");
            }

            if (model.QueryEndTime != null) //结束预收案时间
            {
                strSql.Append(" and B_Case_registerTime<=@QueryEndTime");
            }

            if (model.QueryCaseType != null && model.QueryCaseType != 0) //案件类型
            {
                strSql.Append(" and B_Case_type=@QueryCaseType");
            }

            if (model.QueryNature != null && model.QueryNature != 0) //案件性质
            {
                strSql.Append(" and B_Case_nature=@QueryNature");
            }

            if (model.QueryStartTransferTargetMoney != null && model.QueryStartTransferTargetMoney != 0) //开始移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney>=@QueryStartTransferTargetMoney");
            }

            if (model.QueryEndTransferTargetMoney != null && model.QueryEndTransferTargetMoney != 0) //结束移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney<=@QueryEndTransferTargetMoney");
            }

            if (model.QueryStartExpectedGrant != null && model.QueryStartExpectedGrant != 0) //开始预期收益
            {
                strSql.Append(" and B_Case_expectedGrant>=@QueryStartExpectedGrant");
            }

            if (model.QueryEndExpectedGrant != null && model.QueryEndExpectedGrant != 0) //结束预期收益
            {
                strSql.Append(" and B_Case_expectedGrant<=@QueryEndExpectedGrant");
            }
            strSql.Append(" group by year(B_Case_registerTime),month(B_Case_registerTime),dbo.GetAreaCode(B_Case_code),B_Case_type ");
            strSql.Append(") as tt");

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@QueryArea",SqlDbType.UniqueIdentifier,16),
                new SqlParameter("@QueryStartTime",SqlDbType.DateTime),
                new SqlParameter("@QueryEndTime",SqlDbType.DateTime),
                new SqlParameter("@QueryCaseType",SqlDbType.Int,4),
                new SqlParameter("@QueryNature",SqlDbType.Int,4),
                new SqlParameter("@QueryStartTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryStartExpectedGrant",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndExpectedGrant",SqlDbType.Decimal,16)
            };
            para[0].Value = model.QueryArea;
            para[1].Value = model.QueryStartTime;
            para[2].Value = model.QueryEndTime;
            para[3].Value = model.QueryCaseType;
            para[4].Value = model.QueryNature;
            para[5].Value = model.QueryStartTransferTargetMoney;
            para[6].Value = model.QueryEndTransferTargetMoney;
            para[7].Value = model.QueryStartExpectedGrant;
            para[8].Value = model.QueryEndExpectedGrant;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), para);
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
        /// 客户团队收案类型统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetReportByCaseType(Model.Reporting.R_CaseType_Reporting model, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  year(B_Case_registerTime) as 年份,month(B_Case_registerTime) as 月份, ");
            strSql.Append("(select C_Region_name from C_Region where C_Region_code=dbo.GetAreaCode(B_Case_code)) as 地区,");
            strSql.Append("(select C_Parameters_name from C_Parameters where C_Parameters_id=B_Case_type) as 案件类型,");
            strSql.Append("count(1) as 收案总数,");
            strSql.Append("sum(case when B_Case_nature=147 then 1 else 0 end) as 类型收案数,");
            strSql.Append("sum(case when B_Case_nature=148 then 1 else 0 end) as 非类型收案数,");
            strSql.Append("sum(isnull(B_Case_transferTargetMoney,0)) as 移交总标的,");
            strSql.Append("sum(case when B_Case_nature=147 then isnull(B_Case_transferTargetMoney,0) else 0 end) as 类型移交标的,");
            strSql.Append("sum(case when B_Case_nature=148 then isnull(B_Case_transferTargetMoney,0) else 0 end) as 非类型移交标的,");
            strSql.Append("sum(isnull(B_Case_expectedGrant,0)) as 预期总收益,");
            strSql.Append("sum(case when B_Case_nature=147 then isnull(B_Case_expectedGrant,0) else 0 end) as 类型预期收益,");
            strSql.Append("sum(case when B_Case_nature=148 then isnull(B_Case_expectedGrant,0) else 0 end) as 非类型预期收益 ");
            strSql.Append("from B_Case ");
            strSql.Append("where B_Case_registerTime is not null and B_Case_isDelete=0 ");

            if (model.QueryArea != null && model.QueryArea.ToString() != "") //地区查询条件
            {
                strSql.Append(" and dbo.GetAreaCode(B_Case_code)=@QueryArea");
            }

            if (model.QueryStartTime != null) //开始预收案时间
            {
                strSql.Append(" and B_Case_registerTime>=@QueryStartTime");
            }

            if (model.QueryEndTime != null) //结束预收案时间
            {
                strSql.Append(" and B_Case_registerTime<=@QueryEndTime");
            }

            if (model.QueryCaseType != null && model.QueryCaseType != 0) //案件类型
            {
                strSql.Append(" and B_Case_type=@QueryCaseType");
            }

            if (model.QueryNature != null && model.QueryNature != 0) //案件性质
            {
                strSql.Append(" and B_Case_nature=@QueryNature");
            }

            if (model.QueryStartTransferTargetMoney != null && model.QueryStartTransferTargetMoney != 0) //开始移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney>=@QueryStartTransferTargetMoney");
            }

            if (model.QueryEndTransferTargetMoney != null && model.QueryEndTransferTargetMoney != 0) //结束移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney<=@QueryEndTransferTargetMoney");
            }

            if (model.QueryStartExpectedGrant != null && model.QueryStartExpectedGrant != 0) //开始预期收益
            {
                strSql.Append(" and B_Case_expectedGrant>=@QueryStartExpectedGrant");
            }

            if (model.QueryEndExpectedGrant != null && model.QueryEndExpectedGrant != 0) //结束预期收益
            {
                strSql.Append(" and B_Case_expectedGrant<=@QueryEndExpectedGrant");
            }
            strSql.Append(" group by year(B_Case_registerTime),month(B_Case_registerTime),dbo.GetAreaCode(B_Case_code),B_Case_type ");
            strSql.Append(" order by dbo.GetAreaCode(B_Case_code),year(B_Case_registerTime) desc,month(B_Case_registerTime) ");
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@QueryArea",SqlDbType.UniqueIdentifier,16),
                new SqlParameter("@QueryStartTime",SqlDbType.DateTime),
                new SqlParameter("@QueryEndTime",SqlDbType.DateTime),
                new SqlParameter("@QueryCaseType",SqlDbType.Int,4),
                new SqlParameter("@QueryNature",SqlDbType.Int,4),
                new SqlParameter("@QueryStartTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryStartExpectedGrant",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndExpectedGrant",SqlDbType.Decimal,16)
            };
            para[0].Value = model.QueryArea;
            para[1].Value = model.QueryStartTime;
            para[2].Value = model.QueryEndTime;
            para[3].Value = model.QueryCaseType;
            para[4].Value = model.QueryNature;
            para[5].Value = model.QueryStartTransferTargetMoney;
            para[6].Value = model.QueryEndTransferTargetMoney;
            para[7].Value = model.QueryStartExpectedGrant;
            para[8].Value = model.QueryEndExpectedGrant;

            return DbHelperSQL.Query(strSql.ToString(), para);
        }

        /// <summary>
        /// 区域收案统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByAreaCount(Model.Reporting.R_CaseArea_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(tt.num) from ");
            strSql.Append("(select  1 as num ");
            strSql.Append("from B_Case T ");
            strSql.Append("where B_Case_registerTime is not null and B_Case_isDelete=0 ");

            if (model.QueryArea != null && model.QueryArea.ToString() != "") //地区查询条件
            {
                strSql.Append(" and dbo.GetAreaCode(B_Case_code)=@QueryArea");
            }

            if (model.QueryStartTime != null) //开始预收案时间
            {
                strSql.Append(" and B_Case_registerTime>=@QueryStartTime");
            }

            if (model.QueryEndTime != null) //结束预收案时间
            {
                strSql.Append(" and B_Case_registerTime<=@QueryEndTime");
            }

            if (model.QueryCaseType != null && model.QueryCaseType != 0) //案件类型
            {
                strSql.Append(" and B_Case_type=@QueryCaseType");
            }

            if (model.QueryNature != null && model.QueryNature != 0) //案件性质
            {
                strSql.Append(" and B_Case_nature=@QueryNature");
            }

            if (model.QueryStartTransferTargetMoney != null && model.QueryStartTransferTargetMoney != 0) //开始移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney>=@QueryStartTransferTargetMoney");
            }

            if (model.QueryEndTransferTargetMoney != null && model.QueryEndTransferTargetMoney != 0) //结束移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney<=@QueryEndTransferTargetMoney");
            }

            if (model.QueryStartExpectedGrant != null && model.QueryStartExpectedGrant != 0) //开始预期收益
            {
                strSql.Append(" and B_Case_expectedGrant>=@QueryStartExpectedGrant");
            }

            if (model.QueryEndExpectedGrant != null && model.QueryEndExpectedGrant != 0) //结束预期收益
            {
                strSql.Append(" and B_Case_expectedGrant<=@QueryEndExpectedGrant");
            }

            strSql.Append(" group by year(B_Case_registerTime),month(B_Case_registerTime),dbo.GetAreaCode(B_Case_code) ");
            strSql.Append(") as tt");

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@QueryArea",SqlDbType.UniqueIdentifier,16),
                new SqlParameter("@QueryStartTime",SqlDbType.DateTime),
                new SqlParameter("@QueryEndTime",SqlDbType.DateTime),
                new SqlParameter("@QueryCaseType",SqlDbType.Int,4),
                new SqlParameter("@QueryNature",SqlDbType.Int,4),
                new SqlParameter("@QueryStartTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryStartExpectedGrant",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndExpectedGrant",SqlDbType.Decimal,16)
            };
            para[0].Value = model.QueryArea;
            para[1].Value = model.QueryStartTime;
            para[2].Value = model.QueryEndTime;
            para[3].Value = model.QueryCaseType;
            para[4].Value = model.QueryNature;
            para[5].Value = model.QueryStartTransferTargetMoney;
            para[6].Value = model.QueryEndTransferTargetMoney;
            para[7].Value = model.QueryStartExpectedGrant;
            para[8].Value = model.QueryEndExpectedGrant;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), para);
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
        /// 区域收案统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetReportByArea(Model.Reporting.R_CaseArea_Reporting model, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  year(B_Case_registerTime) as 年份,month(B_Case_registerTime) as 月份, ");
            strSql.Append("(select C_Region_name from C_Region where C_Region_code=dbo.GetAreaCode(B_Case_code)) as 地区,");
            strSql.Append("count(1) as 收案总数,");
            strSql.Append("sum(case when B_Case_nature=147 then 1 else 0 end) as 类型收案数,");
            strSql.Append("sum(case when B_Case_nature=148 then 1 else 0 end) as 非类型收案数,");
            strSql.Append("(select count(1) from C_Customer where C_Customer_code in(select C_FK_code from B_Case_link where B_Case_link.B_Case_link_type=0 and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.B_Case_code ");
            strSql.Append("in(select B_Case_Code from B_Case b where year(T.B_Case_registerTime)=year(b.B_Case_registerTime) and month(T.B_Case_registerTime)=month(b.B_Case_registerTime) and dbo.GetAreaCode(T.B_Case_code)= dbo.GetAreaCode(b.B_Case_code) and b.B_Case_isDelete=0))) as 客户总数,");
            strSql.Append("(select count(1) from C_Customer where (select count(1) from B_Case c where ((year(c.B_Case_registerTime))+month(c.B_Case_registerTime))<(year(t.B_Case_registerTime))+month(t.B_Case_registerTime) and B_Case_code in(select B_Case_link.B_Case_code from B_Case_link where B_Case_link.C_FK_code=C_Customer_code and B_Case_link.B_Case_link_isDelete=0))<=0 and C_Customer_code in(select C_FK_code from B_Case_link where B_Case_link.B_Case_link_type=0 and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.B_Case_code ");
            strSql.Append("in(select B_Case_Code from B_Case b where year(T.B_Case_registerTime)=year(b.B_Case_registerTime) and month(T.B_Case_registerTime)=month(b.B_Case_registerTime)  and dbo.GetAreaCode(T.B_Case_code)= dbo.GetAreaCode(b.B_Case_code) and b.B_Case_isDelete=0))) as 新客户,");
            strSql.Append("(select count(1) from C_Customer where (select count(1) from B_Case c where ((year(c.B_Case_registerTime))+month(c.B_Case_registerTime))<(year(t.B_Case_registerTime))+month(t.B_Case_registerTime) and B_Case_code in(select B_Case_link.B_Case_code from B_Case_link where B_Case_link.C_FK_code=C_Customer_code and B_Case_link.B_Case_link_isDelete=0))>0 and C_Customer_code in(select C_FK_code from B_Case_link where B_Case_link.B_Case_link_type=0 and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.B_Case_code ");
            strSql.Append("in(select B_Case_Code from B_Case b where year(T.B_Case_registerTime)=year(b.B_Case_registerTime) and month(T.B_Case_registerTime)=month(b.B_Case_registerTime)  and dbo.GetAreaCode(T.B_Case_code)= dbo.GetAreaCode(b.B_Case_code) and b.B_Case_isDelete=0))) as 老客户,");
            strSql.Append("sum(isnull(B_Case_transferTargetMoney,0)) as 移交总标的,");
            strSql.Append("sum(case when B_Case_nature=147 then isnull(B_Case_transferTargetMoney,0) else 0 end) as 类型移交标的,");
            strSql.Append("sum(case when B_Case_nature=148 then isnull(B_Case_transferTargetMoney,0) else 0 end) as 非类型移交标的,");
            strSql.Append("sum(isnull(B_Case_expectedGrant,0)) as 预期总收益,");
            strSql.Append("sum(case when B_Case_nature=147 then isnull(B_Case_expectedGrant,0) else 0 end) as 类型预期收益,");
            strSql.Append("sum(case when B_Case_nature=148 then isnull(B_Case_expectedGrant,0) else 0 end) as 非类型预期收益 ");
            strSql.Append("from B_Case T ");
            strSql.Append("where B_Case_registerTime is not null and B_Case_isDelete=0 ");

            if (model.QueryArea != null && model.QueryArea.ToString() != "") //地区查询条件
            {
                strSql.Append(" and dbo.GetAreaCode(B_Case_code)=@QueryArea");
            }

            if (model.QueryStartTime != null) //开始预收案时间
            {
                strSql.Append(" and B_Case_registerTime>=@QueryStartTime");
            }

            if (model.QueryEndTime != null) //结束预收案时间
            {
                strSql.Append(" and B_Case_registerTime<=@QueryEndTime");
            }

            if (model.QueryCaseType != null && model.QueryCaseType != 0) //案件类型
            {
                strSql.Append(" and B_Case_type=@QueryCaseType");
            }

            if (model.QueryNature != null && model.QueryNature != 0) //案件性质
            {
                strSql.Append(" and B_Case_nature=@QueryNature");
            }

            if (model.QueryStartTransferTargetMoney != null && model.QueryStartTransferTargetMoney != 0) //开始移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney>=@QueryStartTransferTargetMoney");
            }

            if (model.QueryEndTransferTargetMoney != null && model.QueryEndTransferTargetMoney != 0) //结束移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney<=@QueryEndTransferTargetMoney");
            }

            if (model.QueryStartExpectedGrant != null && model.QueryStartExpectedGrant != 0) //开始预期收益
            {
                strSql.Append(" and B_Case_expectedGrant>=@QueryStartExpectedGrant");
            }

            if (model.QueryEndExpectedGrant != null && model.QueryEndExpectedGrant != 0) //结束预期收益
            {
                strSql.Append(" and B_Case_expectedGrant<=@QueryEndExpectedGrant");
            }

            strSql.Append(" group by year(B_Case_registerTime),month(B_Case_registerTime),dbo.GetAreaCode(B_Case_code) ");
            strSql.Append(" order by dbo.GetAreaCode(B_Case_code),year(B_Case_registerTime) desc,month(B_Case_registerTime) ");
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@QueryArea",SqlDbType.UniqueIdentifier,16),
                new SqlParameter("@QueryStartTime",SqlDbType.DateTime),
                new SqlParameter("@QueryEndTime",SqlDbType.DateTime),
                new SqlParameter("@QueryCaseType",SqlDbType.Int,4),
                new SqlParameter("@QueryNature",SqlDbType.Int,4),
                new SqlParameter("@QueryStartTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryStartExpectedGrant",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndExpectedGrant",SqlDbType.Decimal,16)
            };
            para[0].Value = model.QueryArea;
            para[1].Value = model.QueryStartTime;
            para[2].Value = model.QueryEndTime;
            para[3].Value = model.QueryCaseType;
            para[4].Value = model.QueryNature;
            para[5].Value = model.QueryStartTransferTargetMoney;
            para[6].Value = model.QueryEndTransferTargetMoney;
            para[7].Value = model.QueryStartExpectedGrant;
            para[8].Value = model.QueryEndExpectedGrant;

            return DbHelperSQL.Query(strSql.ToString(), para);
        }

        /// <summary>
        /// 部门收案统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByOrganCount(Model.Reporting.R_CaseOrgan_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(tt.num) from ");
            strSql.Append("(select 1 as num ");
            strSql.Append("from B_Case T ");
            strSql.Append("where B_Case_registerTime is not null and B_Case_isDelete=0 ");

            if (model.QueryArea != null && model.QueryArea.ToString() != "") //地区查询条件
            {
                strSql.Append(" and dbo.GetAreaCode(B_Case_code)=@QueryArea");
            }

            if (model.QueryStartTime != null) //开始预收案时间
            {
                strSql.Append(" and B_Case_registerTime>=@QueryStartTime");
            }

            if (model.QueryEndTime != null) //结束预收案时间
            {
                strSql.Append(" and B_Case_registerTime<=@QueryEndTime");
            }

            if (model.QueryCaseType != null && model.QueryCaseType != 0) //案件类型
            {
                strSql.Append(" and B_Case_type=@QueryCaseType");
            }

            if (model.QueryNature != null && model.QueryNature != 0) //案件性质
            {
                strSql.Append(" and B_Case_nature=@QueryNature");
            }

            if (model.QueryStartTransferTargetMoney != null && model.QueryStartTransferTargetMoney != 0) //开始移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney>=@QueryStartTransferTargetMoney");
            }

            if (model.QueryEndTransferTargetMoney != null && model.QueryEndTransferTargetMoney != 0) //结束移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney<=@QueryEndTransferTargetMoney");
            }

            if (model.QueryStartExpectedGrant != null && model.QueryStartExpectedGrant != 0) //开始预期收益
            {
                strSql.Append(" and B_Case_expectedGrant>=@QueryStartExpectedGrant");
            }

            if (model.QueryEndExpectedGrant != null && model.QueryEndExpectedGrant != 0) //结束预期收益
            {
                strSql.Append(" and B_Case_expectedGrant<=@QueryEndExpectedGrant");
            }

            strSql.Append(" group by year(B_Case_registerTime),month(B_Case_registerTime),dbo.GetAreaCode(B_Case_code),dbo.GetDeptCode(B_Case_code) ");
            strSql.Append(") as tt");

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@QueryArea",SqlDbType.UniqueIdentifier,16),
                new SqlParameter("@QueryStartTime",SqlDbType.DateTime),
                new SqlParameter("@QueryEndTime",SqlDbType.DateTime),
                new SqlParameter("@QueryCaseType",SqlDbType.Int,4),
                new SqlParameter("@QueryNature",SqlDbType.Int,4),
                new SqlParameter("@QueryStartTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryStartExpectedGrant",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndExpectedGrant",SqlDbType.Decimal,16)
            };
            para[0].Value = model.QueryArea;
            para[1].Value = model.QueryStartTime;
            para[2].Value = model.QueryEndTime;
            para[3].Value = model.QueryCaseType;
            para[4].Value = model.QueryNature;
            para[5].Value = model.QueryStartTransferTargetMoney;
            para[6].Value = model.QueryEndTransferTargetMoney;
            para[7].Value = model.QueryStartExpectedGrant;
            para[8].Value = model.QueryEndExpectedGrant;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), para);
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
        /// 部门收案统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetReportByOrgan(Model.Reporting.R_CaseOrgan_Reporting model, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  year(B_Case_registerTime) as 年份,month(B_Case_registerTime) as 月份, ");
            strSql.Append("(select C_Region_name from C_Region where C_Region_code=dbo.GetAreaCode(B_Case_code)) as 地区,");
            strSql.Append("(select C_Organization_name from C_Organization where C_Organization_code=dbo.GetDeptCode(B_Case_code)) as 部门,");
            strSql.Append("count(1) as 收案总数,");
            strSql.Append("sum(case when B_Case_nature=147 then 1 else 0 end) as 类型收案数,");
            strSql.Append("sum(case when B_Case_nature=148 then 1 else 0 end) as 非类型收案数,");
            strSql.Append("(select count(1) from C_Customer where C_Customer_code in(select C_FK_code from B_Case_link where B_Case_link.B_Case_link_type=0 and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.B_Case_code ");
            strSql.Append("in(select B_Case_Code from B_Case b where year(T.B_Case_registerTime)=year(b.B_Case_registerTime) and month(T.B_Case_registerTime)=month(b.B_Case_registerTime) and dbo.GetAreaCode(T.B_Case_code)= dbo.GetAreaCode(b.B_Case_code) and b.B_Case_isDelete=0))) as 客户总数,");
            strSql.Append("(select count(1) from C_Customer where (select count(1) from B_Case c where ((year(c.B_Case_registerTime))+month(c.B_Case_registerTime))<(year(t.B_Case_registerTime))+month(t.B_Case_registerTime) and B_Case_code in(select B_Case_link.B_Case_code from B_Case_link where B_Case_link.C_FK_code=C_Customer_code and B_Case_link.B_Case_link_isDelete=0))<=0 and C_Customer_code in(select C_FK_code from B_Case_link where B_Case_link.B_Case_link_type=0 and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.B_Case_code ");
            strSql.Append("in(select B_Case_Code from B_Case b where year(T.B_Case_registerTime)=year(b.B_Case_registerTime) and month(T.B_Case_registerTime)=month(b.B_Case_registerTime)  and dbo.GetAreaCode(T.B_Case_code)= dbo.GetAreaCode(b.B_Case_code) and b.B_Case_isDelete=0))) as 新客户,");
            strSql.Append("(select count(1) from C_Customer where (select count(1) from B_Case c where ((year(c.B_Case_registerTime))+month(c.B_Case_registerTime))<(year(t.B_Case_registerTime))+month(t.B_Case_registerTime) and B_Case_code in(select B_Case_link.B_Case_code from B_Case_link where B_Case_link.C_FK_code=C_Customer_code and B_Case_link.B_Case_link_isDelete=0))>0 and C_Customer_code in(select C_FK_code from B_Case_link where B_Case_link.B_Case_link_type=0 and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.B_Case_code ");
            strSql.Append("in(select B_Case_Code from B_Case b where year(T.B_Case_registerTime)=year(b.B_Case_registerTime) and month(T.B_Case_registerTime)=month(b.B_Case_registerTime)  and dbo.GetAreaCode(T.B_Case_code)= dbo.GetAreaCode(b.B_Case_code) and b.B_Case_isDelete=0))) as 老客户,");
            strSql.Append("sum(isnull(B_Case_transferTargetMoney,0)) as 移交总标的,");
            strSql.Append("sum(case when B_Case_nature=147 then isnull(B_Case_transferTargetMoney,0) else 0 end) as 类型移交标的,");
            strSql.Append("sum(case when B_Case_nature=148 then isnull(B_Case_transferTargetMoney,0) else 0 end) as 非类型移交标的,");
            strSql.Append("sum(isnull(B_Case_expectedGrant,0)) as 预期总收益,");
            strSql.Append("sum(case when B_Case_nature=147 then isnull(B_Case_expectedGrant,0) else 0 end) as 类型预期收益,");
            strSql.Append("sum(case when B_Case_nature=148 then isnull(B_Case_expectedGrant,0) else 0 end) as 非类型预期收益 ");
            strSql.Append("from B_Case T ");
            strSql.Append("where B_Case_registerTime is not null and B_Case_isDelete=0 ");

            if (model.QueryArea != null && model.QueryArea.ToString() != "") //地区查询条件
            {
                strSql.Append(" and dbo.GetAreaCode(B_Case_code)=@QueryArea");
            }

            if (model.QueryStartTime != null) //开始预收案时间
            {
                strSql.Append(" and B_Case_registerTime>=@QueryStartTime");
            }

            if (model.QueryEndTime != null) //结束预收案时间
            {
                strSql.Append(" and B_Case_registerTime<=@QueryEndTime");
            }

            if (model.QueryCaseType != null && model.QueryCaseType != 0) //案件类型
            {
                strSql.Append(" and B_Case_type=@QueryCaseType");
            }

            if (model.QueryNature != null && model.QueryNature != 0) //案件性质
            {
                strSql.Append(" and B_Case_nature=@QueryNature");
            }

            if (model.QueryStartTransferTargetMoney != null && model.QueryStartTransferTargetMoney != 0) //开始移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney>=@QueryStartTransferTargetMoney");
            }

            if (model.QueryEndTransferTargetMoney != null && model.QueryEndTransferTargetMoney != 0) //结束移交标的
            {
                strSql.Append(" and B_Case_transferTargetMoney<=@QueryEndTransferTargetMoney");
            }

            if (model.QueryStartExpectedGrant != null && model.QueryStartExpectedGrant != 0) //开始预期收益
            {
                strSql.Append(" and B_Case_expectedGrant>=@QueryStartExpectedGrant");
            }

            if (model.QueryEndExpectedGrant != null && model.QueryEndExpectedGrant != 0) //结束预期收益
            {
                strSql.Append(" and B_Case_expectedGrant<=@QueryEndExpectedGrant");
            }

            strSql.Append(" group by year(B_Case_registerTime),month(B_Case_registerTime),dbo.GetAreaCode(B_Case_code),dbo.GetDeptCode(B_Case_code) ");
            strSql.Append(" order by dbo.GetAreaCode(B_Case_code),year(B_Case_registerTime) desc,month(B_Case_registerTime) ");
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@QueryArea",SqlDbType.UniqueIdentifier,16),
                new SqlParameter("@QueryStartTime",SqlDbType.DateTime),
                new SqlParameter("@QueryEndTime",SqlDbType.DateTime),
                new SqlParameter("@QueryCaseType",SqlDbType.Int,4),
                new SqlParameter("@QueryNature",SqlDbType.Int,4),
                new SqlParameter("@QueryStartTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndTransferTargetMoney",SqlDbType.Decimal,16),
                new SqlParameter("@QueryStartExpectedGrant",SqlDbType.Decimal,16),
                new SqlParameter("@QueryEndExpectedGrant",SqlDbType.Decimal,16)
            };
            para[0].Value = model.QueryArea;
            para[1].Value = model.QueryStartTime;
            para[2].Value = model.QueryEndTime;
            para[3].Value = model.QueryCaseType;
            para[4].Value = model.QueryNature;
            para[5].Value = model.QueryStartTransferTargetMoney;
            para[6].Value = model.QueryEndTransferTargetMoney;
            para[7].Value = model.QueryStartExpectedGrant;
            para[8].Value = model.QueryEndExpectedGrant;

            return DbHelperSQL.Query(strSql.ToString(), para);
        }
        #endregion

        #region App专用
        /// <summary>
        /// 获取监控中心横向列表数量
        /// </summary>
        /// <param name="guid">人员GUID</param>
        /// <param name="IsPreSetManager"></param>
        /// <param name="rolePowerIds"></param>
        /// <returns></returns>
        public DataSet GetMonitorCase(bool IsPreSetManager, string rolePowerIds, Guid? guid, Guid? deptCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Flow_code,P_Flow_name ");
            strSql.Append(",(select count(1) from B_Case T where T.B_Case_isDelete=0 and ");
            strSql.Append("exists(select 1 from P_Business_flow pbf where pbf.P_Fk_code=T.B_Case_code and pbf.P_Business_isdelete=0 and pbf.P_Flow_code=pf.P_Flow_code)");
            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=T.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_Case_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                //案件负责人
                strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=T.B_Case_code) ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion
            strSql.Append(") as CaseCount ");
            strSql.Append("from P_Flow pf ");
            strSql.Append("where pf.P_Flow_isDelete=0 and pf.P_Flow_type=153 ");
            strSql.Append("and (select count(1) from B_Case bcase where bcase.B_Case_isDelete=0 and ");
            strSql.Append("exists(select 1 from P_Business_flow pbf where pbf.P_Fk_code=bcase.B_Case_code and pbf.P_Business_isdelete=0 and pbf.P_Flow_code=pf.P_Flow_code))>0 ");
            strSql.Append("order by pf.P_Flow_order");
            SqlParameter[] para = new SqlParameter[]
            {
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = guid;
            para[1].Value = deptCode;
            return DbHelperSQL.Query(strSql.ToString(), para);
        }

        /// <summary>
        /// 根据用户GUID获取他应该审核的案件
        /// </summary>
        /// <param name="guid">用户GUID</param>
        /// <returns>案件列表</returns>
        public DataSet GetPendingCase(CommonService.Model.CaseManager.B_Case model, Guid? guid, int startIndex, int endIndex)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select *,U.C_Userinfo_name as B_Case_personName from B_Case T ");
            sql.Append("left join C_Userinfo U on T.B_Case_person=U.C_Userinfo_code ");
            sql.Append("where exists(select 1 from P_Business_flow pf where pf.P_FK_Code=T.B_Case_code and pf.P_Business_isDelete=0 and  ");
            sql.Append("exists(select 1 from P_Business_flow_form pff where pff.P_Business_flow_code=pf.P_Business_flow_code and pf.P_Business_isdelete=0 and pff.P_Business_flow_form_state=200 and pff.P_Business_flow_form_status=260 and  ");
            sql.Append("exists(select 1 from F_FormCheck fc where fc.F_FormCheck_business_flow_form_code=pff.P_Business_flow_form_code and fc.F_FormCheck_isDelete=0 and fc.F_FormCheck_state=315 and fc.F_FormCheck_checkPerson=@guid))) ");
            if (model != null)
            {
                //收案时间
                if ((model.B_Case_registerTime != null) && (model.B_Case_registerTime2 != null))
                {
                    sql.Append("and T.B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

                //办案阶段条件
                if (!string.IsNullOrEmpty(model.B_Case_Stage))
                {
                    sql.Append(" and exists(select 1 from P_Business_flow where P_Business_flow.P_Flow_code=@B_Case_Stage and P_Business_flow.P_Fk_code=T.B_Case_code and P_Business_flow.P_Business_isdelete=0)");
                }

                //工程
                if (!string.IsNullOrEmpty(model.C_Project_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Project_code and B_Case_link.B_Case_link_type=7)");
                }

                //客户
                if (!string.IsNullOrEmpty(model.C_Customer_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Customer_code and B_Case_link.B_Case_link_type=0)");
                }

                //委托人
                if (!string.IsNullOrEmpty(model.C_Client_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Client_code and B_Case_link.B_Case_link_type=1)");
                }

                //对方当事人
                if (!string.IsNullOrEmpty(model.B_Case_Rival_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Case_Rival_code and (B_Case_link.B_Case_link_type=2 or B_Case_link.B_Case_link_type=3))");
                }

                //区域
                if (!string.IsNullOrEmpty(model.C_Region_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Region_code and B_Case_link.B_Case_link_type=6)");
                }

                //承办律师
                if (!String.IsNullOrEmpty(model.B_Case_lawyerCode.ToString()))
                {
                    sql.Append(" and (exists(select 1 from P_Business_flow where T.B_Case_code=P_Business_flow.P_FK_code and P_Business_flow.P_Business_isdelete=0 and P_Business_flow.P_Business_person=@B_Case_lawyerCode)"); //流程负责人
                    //sql.Append(" or exists(select 1 from P_Business_flow_form where P_Business_flow_form_isdelete=0 and P_Business_flow_form_person=@B_Case_lawyerCode and P_Business_flow_form.P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Business_flow.P_Fk_code=T.B_Case_code))"); //加上后效率慢，原因再调
                    sql.Append(")");
                    //sql.Append("left join (select distinct BF.P_Fk_code,U.C_Userinfo_code from P_Business_flow as BF left join C_Userinfo as U on BF.P_Business_person=U.C_Userinfo_code where U.C_Userinfo_code=@B_Case_lawyerCode) As BU on BU.P_Fk_code=T.B_Case_code ");
                }

                //专业顾问
                if (!string.IsNullOrEmpty(model.B_Consultant_code))
                {
                    sql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=T.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Consultant_code and B_Case_link.B_Case_link_type=11)");
                }

                //部门
                if (!string.IsNullOrEmpty(model.B_Case_organizationCode))
                {
                    sql.Append(" and exists(select 1 from C_Userinfo As CU with(nolock) ");
                    sql.Append("where CU.C_Userinfo_isDelete=0 ");
                    sql.Append("and exists(select 1 from DeptTree(@B_Case_organizationCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
                    sql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=T.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    sql.Append(") ");
                }

                //法院
                if (!string.IsNullOrEmpty(model.B_Case_courtFirst.ToString()))
                {
                    sql.Append(" and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
                }

                //案件名称
                if (!string.IsNullOrEmpty(model.B_Case_name))
                {
                    sql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
                }

                //案件类型
                if (model.B_Case_type != null && model.B_Case_type.ToString() != "")
                {
                    sql.Append("and B_Case_type=@B_Case_type ");
                }

                //案件性质
                if (model.B_Case_nature != null && model.B_Case_nature.ToString() != "")
                {
                    sql.Append("and B_Case_nature=@B_Case_nature ");
                }

                //客户类型
                if (model.B_Case_customerType != null && model.B_Case_customerType.ToString() != "")
                {
                    sql.Append("and B_Case_customerType=@B_Case_customerType ");
                }

                //案件状态
                if (model.B_Case_state != null && model.B_Case_state.ToString() != "")
                {
                    sql.Append("and B_Case_state=@B_Case_state ");
                }

                //新添加条件查询
                if (!string.IsNullOrEmpty(model.B_Case_number))
                {
                    sql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
                }

                //预期收益范围
                if ((!string.IsNullOrEmpty(model.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_Case_execMoney2.ToString()))
                {
                    sql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }

                //预收案时间
                if ((!string.IsNullOrEmpty(model.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(model.B_Case_registerTime2.ToString())))
                {
                    sql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }

                //首席确认开始时间
                if (!string.IsNullOrEmpty(model.B_Case_sureDate.ToString()))
                {
                    sql.Append("and B_Case_sureDate>=@B_Case_sureDate ");
                }

                //首席确认结束时间
                if (!string.IsNullOrEmpty(model.B_Case_sureDateEnd.ToString()))
                {
                    sql.Append("and B_Case_sureDate<=@B_Case_sureDateEnd ");
                }

                //案件是否包含流程（监控中心用到）
                if (model.Flow_code != null && model.Flow_code.ToString() != "" && model.Flow_code.ToString() != "0")
                {
                    sql.Append("and exists(select 1 from P_Business_Flow where P_FK_Code=B_Case_code and P_Business_flow_isDelete=0 and P_Flow_code=@Flow_code)");
                }


            }
            sql.Append("and T.B_Case_isDelete=0 order by B_Case_id desc ");
            if (startIndex != 0 || endIndex != 0)
            {
                sql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_lawyerCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Consultant_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_organizationCode",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_sureDate",SqlDbType.DateTime),
                    new SqlParameter("@B_Case_sureDateEnd",SqlDbType.DateTime),
                    new SqlParameter("@Flow_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.B_Case_name;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Case_type;
            parameters[3].Value = model.B_Case_nature;
            parameters[4].Value = model.B_Case_customerType;
            parameters[5].Value = model.B_Case_relationCode;
            parameters[6].Value = model.B_Case_Stage;
            parameters[7].Value = model.C_Project_code;
            parameters[8].Value = model.C_Customer_code;
            parameters[9].Value = model.C_Client_code;
            parameters[10].Value = model.B_Case_Rival_code;
            parameters[11].Value = model.B_Case_number;
            parameters[12].Value = model.B_Case_courtFirst;
            parameters[13].Value = model.B_Case_transferTargetMoney;
            parameters[14].Value = model.B_Case_execMoney2;
            parameters[15].Value = model.B_Case_registerTime;
            parameters[16].Value = model.B_Case_registerTime2;
            parameters[17].Value = model.B_Case_state;
            parameters[18].Value = model.B_Case_consultant_code;
            parameters[19].Value = model.C_Region_code;
            parameters[20].Value = model.B_Case_lawyerCode;
            parameters[21].Value = model.B_Consultant_code;
            parameters[22].Value = model.B_Case_organizationCode;
            parameters[23].Value = model.B_Case_sureDate;
            parameters[24].Value = model.B_Case_sureDateEnd;
            parameters[25].Value = model.Flow_code;
            parameters[26].Value = guid;
            DataSet ds = DbHelperSQL.Query(sql.ToString(), parameters);
            return ds;
        }
        #endregion
    }
}

