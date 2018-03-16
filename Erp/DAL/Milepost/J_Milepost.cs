using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace CommonService.DAL.Milepost
{
    /// <summary>
    /// 数据访问类:J_Milepost
    /// </summary>
    public partial class J_Milepost
    {
        public J_Milepost()
        { }
        #region  BasicMethod
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("J_Milepost_id", "J_Milepost");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int J_Milepost_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from J_Milepost");
            strSql.Append(" where J_Milepost_id=@J_Milepost_id");
            SqlParameter[] parameters = {
					new SqlParameter("@J_Milepost_id", SqlDbType.Int,4)
			};
            parameters[0].Value = J_Milepost_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.Milepost.J_Milepost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into J_Milepost(");
            strSql.Append("J_Milepost_code,J_Milepost_JTime,J_Milepost_Organization_code,J_Milepost_ZUserinfo_code,J_Milepost_XUserinfo_code,J_Milepost_DepUserinfo_code,J_Milepost_GenerUserinfo_code,J_Milepost_CaseNumber,J_Milepost_DocumentPo,J_Milepost_Filing,J_Milepost_Preservation,J_Milepost_Firstcomplete,J_Milepost_Firstinstance,J_Milepost_Conciliation,J_Milepost_Prosecution,J_Milepost_Verdict,J_Milepost_ProgramScoreY,J_Milepost_ProgramScoreS,J_Milepost_EntityScore,J_Milepost_CaseScore,J_Milepost_Auditor,J_Milepost_TJMessageType,J_Milepost_TJMessageContent,J_Milepost_AdMessageType,J_Milepost_AdMessageContent,J_Milepost_AdStatus,J_Milepost_createTime,J_Milepost_Type,J_Milepost_isDelete,J_Milepost_Z_TJMessageType,J_Milepost_Z_TJMessageContent,J_Milepost_Dep_TJMessageType,J_Milepost_Dep_TJMessageContent,J_Milepost_Z_AdMessageType,J_Milepost_Z_AdMessageContent,J_Milepost_Z_AdStatus,J_Milepost_Dep_AdMessageType,J_Milepost_Dep_AdMessageContent,J_Milepost_Dep_AdStatus)");
            strSql.Append(" values (");
            strSql.Append("@J_Milepost_code,@J_Milepost_JTime,@J_Milepost_Organization_code,@J_Milepost_ZUserinfo_code,@J_Milepost_XUserinfo_code,@J_Milepost_DepUserinfo_code,@J_Milepost_GenerUserinfo_code,@J_Milepost_CaseNumber,@J_Milepost_DocumentPo,@J_Milepost_Filing,@J_Milepost_Preservation,@J_Milepost_Firstcomplete,@J_Milepost_Firstinstance,@J_Milepost_Conciliation,@J_Milepost_Prosecution,@J_Milepost_Verdict,@J_Milepost_ProgramScoreY,@J_Milepost_ProgramScoreS,@J_Milepost_EntityScore,@J_Milepost_CaseScore,@J_Milepost_Auditor,@J_Milepost_TJMessageType,@J_Milepost_TJMessageContent,@J_Milepost_AdMessageType,@J_Milepost_AdMessageContent,@J_Milepost_AdStatus,@J_Milepost_createTime,@J_Milepost_Type,@J_Milepost_isDelete,@J_Milepost_Z_TJMessageType,@J_Milepost_Z_TJMessageContent,@J_Milepost_Dep_TJMessageType,@J_Milepost_Dep_TJMessageContent,@J_Milepost_Z_AdMessageType,@J_Milepost_Z_AdMessageContent,@J_Milepost_Z_AdStatus,@J_Milepost_Dep_AdMessageType,@J_Milepost_Dep_AdMessageContent,@J_Milepost_Dep_AdStatus)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@J_Milepost_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_JTime", SqlDbType.DateTime),
					new SqlParameter("@J_Milepost_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_ZUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_XUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_DepUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_GenerUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_CaseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@J_Milepost_DocumentPo", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Filing", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Preservation", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Firstcomplete", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Firstinstance", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Conciliation", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Prosecution", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Verdict", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_ProgramScoreY", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_ProgramScoreS", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_EntityScore", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_CaseScore", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Auditor", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_TJMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_Milepost_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_Milepost_AdStatus", SqlDbType.Int,4),
					new SqlParameter("@J_Milepost_createTime", SqlDbType.DateTime),
                    	new SqlParameter("@J_Milepost_Type", SqlDbType.Int,4),
					new SqlParameter("@J_Milepost_isDelete", SqlDbType.Bit,1),
                                        
                     new SqlParameter("@J_Milepost_Z_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Z_TJMessageContent", SqlDbType.NVarChar,50),
                    new SqlParameter("@J_Milepost_Dep_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Dep_TJMessageContent", SqlDbType.NVarChar,50),
                    new SqlParameter("@J_Milepost_Z_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Z_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_Milepost_Z_AdStatus", SqlDbType.Int,4),           
                           
                       new SqlParameter("@J_Milepost_Dep_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Dep_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_Milepost_Dep_AdStatus", SqlDbType.Int,4)
                                        };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.J_Milepost_JTime;
            parameters[2].Value = model.J_Milepost_Organization_code;
            parameters[3].Value = model.J_Milepost_ZUserinfo_code;
            parameters[4].Value = model.J_Milepost_XUserinfo_code;
            parameters[5].Value = model.J_Milepost_DepUserinfo_code;
            parameters[6].Value = model.J_Milepost_GenerUserinfo_code;
            parameters[7].Value = model.J_Milepost_CaseNumber;
            parameters[8].Value = model.J_Milepost_DocumentPo;
            parameters[9].Value = model.J_Milepost_Filing;
            parameters[10].Value = model.J_Milepost_Preservation;
            parameters[11].Value = model.J_Milepost_Firstcomplete;
            parameters[12].Value = model.J_Milepost_Firstinstance;
            parameters[13].Value = model.J_Milepost_Conciliation;
            parameters[14].Value = model.J_Milepost_Prosecution;
            parameters[15].Value = model.J_Milepost_Verdict;
            parameters[16].Value = model.J_Milepost_ProgramScoreY;
            parameters[17].Value = model.J_Milepost_ProgramScoreS;
            parameters[18].Value = model.J_Milepost_EntityScore;
            parameters[19].Value = model.J_Milepost_CaseScore;
            parameters[20].Value = model.J_Milepost_Auditor;
            parameters[21].Value = model.J_Milepost_TJMessageType;
            parameters[22].Value = model.J_Milepost_TJMessageContent;
            parameters[23].Value = model.J_Milepost_AdMessageType;
            parameters[24].Value = model.J_Milepost_AdMessageContent;
            parameters[25].Value = model.J_Milepost_AdStatus;
            parameters[26].Value = model.J_Milepost_createTime;
            parameters[27].Value = model.J_Milepost_Type;
            parameters[28].Value = model.J_Milepost_isDelete;
            parameters[29].Value = model.J_Milepost_Z_TJMessageType;
            parameters[30].Value = model.J_Milepost_Z_TJMessageContent;

            parameters[31].Value = model.J_Milepost_Dep_TJMessageType;
            parameters[32].Value = model.J_Milepost_Dep_TJMessageContent;

            parameters[33].Value = model.J_Milepost_Z_AdMessageType;
            parameters[34].Value = model.J_Milepost_Z_AdMessageContent;
            parameters[35].Value = model.J_Milepost_Z_AdStatus;

            parameters[36].Value = model.J_Milepost_Dep_AdMessageType;
            parameters[37].Value = model.J_Milepost_Dep_AdMessageContent;
            parameters[38].Value = model.J_Milepost_Dep_AdStatus;

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
        public bool Update(CommonService.Model.Milepost.J_Milepost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update J_Milepost set ");
            strSql.Append("J_Milepost_code=@J_Milepost_code,");
            strSql.Append("J_Milepost_JTime=@J_Milepost_JTime,");
            strSql.Append("J_Milepost_Organization_code=@J_Milepost_Organization_code,");
            strSql.Append("J_Milepost_ZUserinfo_code=@J_Milepost_ZUserinfo_code,");
            strSql.Append("J_Milepost_XUserinfo_code=@J_Milepost_XUserinfo_code,");
            strSql.Append("J_Milepost_DepUserinfo_code=@J_Milepost_DepUserinfo_code,");
            strSql.Append("J_Milepost_GenerUserinfo_code=@J_Milepost_GenerUserinfo_code,");
            strSql.Append("J_Milepost_CaseNumber=@J_Milepost_CaseNumber,");
            strSql.Append("J_Milepost_DocumentPo=@J_Milepost_DocumentPo,");
            strSql.Append("J_Milepost_Filing=@J_Milepost_Filing,");
            strSql.Append("J_Milepost_Preservation=@J_Milepost_Preservation,");
            strSql.Append("J_Milepost_Firstcomplete=@J_Milepost_Firstcomplete,");
            strSql.Append("J_Milepost_Firstinstance=@J_Milepost_Firstinstance,");
            strSql.Append("J_Milepost_Conciliation=@J_Milepost_Conciliation,");
            strSql.Append("J_Milepost_Prosecution=@J_Milepost_Prosecution,");
            strSql.Append("J_Milepost_Verdict=@J_Milepost_Verdict,");
            strSql.Append("J_Milepost_ProgramScoreY=@J_Milepost_ProgramScoreY,");
            strSql.Append("J_Milepost_ProgramScoreS=@J_Milepost_ProgramScoreS,");
            strSql.Append("J_Milepost_EntityScore=@J_Milepost_EntityScore,");
            strSql.Append("J_Milepost_CaseScore=@J_Milepost_CaseScore,");
            strSql.Append("J_Milepost_Auditor=@J_Milepost_Auditor,");
            strSql.Append("J_Milepost_TJMessageType=@J_Milepost_TJMessageType,");
            strSql.Append("J_Milepost_TJMessageContent=@J_Milepost_TJMessageContent,");
            strSql.Append("J_Milepost_AdMessageType=@J_Milepost_AdMessageType,");
            strSql.Append("J_Milepost_AdMessageContent=@J_Milepost_AdMessageContent,");
            strSql.Append("J_Milepost_AdStatus=@J_Milepost_AdStatus,");
            strSql.Append("J_Milepost_createTime=@J_Milepost_createTime,");
            strSql.Append("J_Milepost_Type=@J_Milepost_Type,");
            strSql.Append("J_Milepost_isDelete=@J_Milepost_isDelete, ");

            strSql.Append("J_Milepost_Z_TJMessageType=@J_Milepost_Z_TJMessageType,");
            strSql.Append("J_Milepost_Z_TJMessageContent=@J_Milepost_Z_TJMessageContent,");
            strSql.Append("J_Milepost_Dep_TJMessageType=@J_Milepost_Dep_TJMessageType,");
            strSql.Append("J_Milepost_Dep_TJMessageContent=@J_Milepost_Dep_TJMessageContent,");

            strSql.Append("J_Milepost_Z_AdMessageType=@J_Milepost_Z_AdMessageType,");
            strSql.Append("J_Milepost_Z_AdMessageContent=@J_Milepost_Z_AdMessageContent,");
            strSql.Append("J_Milepost_Z_AdStatus=@J_Milepost_Z_AdStatus,");

            strSql.Append("J_Milepost_Dep_AdMessageType=@J_Milepost_Dep_AdMessageType,");
            strSql.Append("J_Milepost_Dep_AdMessageContent=@J_Milepost_Dep_AdMessageContent,");
            strSql.Append("J_Milepost_Dep_AdStatus=@J_Milepost_Dep_AdStatus ");

            strSql.Append(" where J_Milepost_id=@J_Milepost_id");
            SqlParameter[] parameters = {
					new SqlParameter("@J_Milepost_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_JTime", SqlDbType.DateTime),
					new SqlParameter("@J_Milepost_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_ZUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_XUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_DepUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_GenerUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_CaseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@J_Milepost_DocumentPo", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Filing", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Preservation", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Firstcomplete", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Firstinstance", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Conciliation", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Prosecution", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Verdict", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_ProgramScoreY", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_ProgramScoreS", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_EntityScore", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_CaseScore", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Auditor", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_Milepost_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_TJMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_Milepost_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_Milepost_AdStatus", SqlDbType.Int,4),
					new SqlParameter("@J_Milepost_createTime", SqlDbType.DateTime),
                    	new SqlParameter("@J_Milepost_Type", SqlDbType.Int,4),
					new SqlParameter("@J_Milepost_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@J_Milepost_id", SqlDbType.Int,4),
                      new SqlParameter("@J_Milepost_Z_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Z_TJMessageContent", SqlDbType.NVarChar,50),
                    new SqlParameter("@J_Milepost_Dep_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Dep_TJMessageContent", SqlDbType.NVarChar,50),
                    new SqlParameter("@J_Milepost_Z_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Z_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_Milepost_Z_AdStatus", SqlDbType.Int,4),           
                           
                       new SqlParameter("@J_Milepost_Dep_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_Milepost_Dep_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_Milepost_Dep_AdStatus", SqlDbType.Int,4)       
                                        
                                        };
            parameters[0].Value = model.J_Milepost_code;
            parameters[1].Value = model.J_Milepost_JTime;
            parameters[2].Value = model.J_Milepost_Organization_code;
            parameters[3].Value = model.J_Milepost_ZUserinfo_code;
            parameters[4].Value = model.J_Milepost_XUserinfo_code;
            parameters[5].Value = model.J_Milepost_DepUserinfo_code;
            parameters[6].Value = model.J_Milepost_GenerUserinfo_code;
            parameters[7].Value = model.J_Milepost_CaseNumber;
            parameters[8].Value = model.J_Milepost_DocumentPo;
            parameters[9].Value = model.J_Milepost_Filing;
            parameters[10].Value = model.J_Milepost_Preservation;
            parameters[11].Value = model.J_Milepost_Firstcomplete;
            parameters[12].Value = model.J_Milepost_Firstinstance;
            parameters[13].Value = model.J_Milepost_Conciliation;
            parameters[14].Value = model.J_Milepost_Prosecution;
            parameters[15].Value = model.J_Milepost_Verdict;
            parameters[16].Value = model.J_Milepost_ProgramScoreY;
            parameters[17].Value = model.J_Milepost_ProgramScoreS;
            parameters[18].Value = model.J_Milepost_EntityScore;
            parameters[19].Value = model.J_Milepost_CaseScore;
            parameters[20].Value = model.J_Milepost_Auditor;
            parameters[21].Value = model.J_Milepost_TJMessageType;
            parameters[22].Value = model.J_Milepost_TJMessageContent;
            parameters[23].Value = model.J_Milepost_AdMessageType;
            parameters[24].Value = model.J_Milepost_AdMessageContent;
            parameters[25].Value = model.J_Milepost_AdStatus;
            parameters[26].Value = model.J_Milepost_createTime;
            parameters[27].Value = model.J_Milepost_Type;
            parameters[28].Value = model.J_Milepost_isDelete;
            parameters[29].Value = model.J_Milepost_id;
            parameters[30].Value = model.J_Milepost_Z_TJMessageType;
            parameters[31].Value = model.J_Milepost_Z_TJMessageContent;

            parameters[32].Value = model.J_Milepost_Dep_TJMessageType;
            parameters[33].Value = model.J_Milepost_Dep_TJMessageContent;

            parameters[34].Value = model.J_Milepost_Z_AdMessageType;
            parameters[35].Value = model.J_Milepost_Z_AdMessageContent;
            parameters[36].Value = model.J_Milepost_Z_AdStatus;

            parameters[37].Value = model.J_Milepost_Dep_AdMessageType;
            parameters[38].Value = model.J_Milepost_Dep_AdMessageContent;
            parameters[39].Value = model.J_Milepost_Dep_AdStatus;
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
        public bool Delete(int J_Milepost_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from J_Milepost ");
            strSql.Append(" where J_Milepost_id=@J_Milepost_id");
            SqlParameter[] parameters = {
					new SqlParameter("@J_Milepost_id", SqlDbType.Int,4)
			};
            parameters[0].Value = J_Milepost_id;

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
        public bool DeleteList(string J_Milepost_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from J_Milepost ");
            strSql.Append(" where J_Milepost_id in (" + J_Milepost_idlist + ")  ");
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
        public CommonService.Model.Milepost.J_Milepost GetModel(int J_Milepost_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_Auditor) as J_Milepost_AuditorName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_ZUserinfo_code) as J_Milepost_ZUserinfo_codeName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_XUserinfo_code) as J_Milepost_XUserinfo_codeName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_DepUserinfo_code) as J_Milepost_DepUserinfo_codeName ");


            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_GenerUserinfo_code) as J_Milepost_GenerUserinfo_codeName ");

            strSql.Append(",(select (select C_Customer_name  from C_Customer where C_Customer_code=B_Case_link.C_FK_code) from B_Case_link where B_Case_code =(select top 1 B_Case_code from B_Case where B_Case_number=TT.J_Milepost_CaseNumber) and B_Case_link_type=1) as C_Customer_yg ");


            strSql.Append(",(select stuff((select '+'+(select C_CRival_name  from C_CRival where C_CRival_code=t.C_FK_code) from B_Case_link t where B_Case_code in(select B_Case_code from B_Case where B_Case_number=TT.J_Milepost_CaseNumber) and B_Case_link_type=2 for xml path('')), 1, 1, '')) as C_Customer_BG_1 ");
            strSql.Append(",(select stuff((select '+'+(select C_PRival_name  from C_PRival where C_PRival_code=t.C_FK_code) from B_Case_link t where B_Case_code in(select B_Case_code from B_Case where B_Case_number=TT.J_Milepost_CaseNumber) and B_Case_link_type=3 for xml path('')), 1, 1, '')) as C_Customer_BG_2 ");

            strSql.Append(" from J_Milepost  as TT ");
            strSql.Append(" where J_Milepost_id=@J_Milepost_id");
            SqlParameter[] parameters = {
					new SqlParameter("@J_Milepost_id", SqlDbType.Int,4)
			};
            parameters[0].Value = J_Milepost_id;

            CommonService.Model.Milepost.J_Milepost model = new CommonService.Model.Milepost.J_Milepost();
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
        public CommonService.Model.Milepost.J_Milepost DataRowToModel(DataRow row)
        {
            CommonService.Model.Milepost.J_Milepost model = new CommonService.Model.Milepost.J_Milepost();
            if (row != null)
            {
                if (row["C_Customer_yg"] != null && row["C_Customer_yg"].ToString() != "")
                {
                    model.C_Customer_yg = row["C_Customer_yg"].ToString();
                }

                if (row["C_Customer_BG_1"] != null && row["C_Customer_BG_1"].ToString() != "")
                {
                    model.C_Customer_BG_1 = row["C_Customer_BG_1"].ToString();
                }

                if (row["C_Customer_BG_2"] != null && row["C_Customer_BG_2"].ToString() != "")
                {
                    model.C_Customer_BG_2 = row["C_Customer_BG_2"].ToString();
                }
                if (row["J_Milepost_GenerUserinfo_codeName"] != null && row["J_Milepost_GenerUserinfo_codeName"].ToString() != "")
                {
                    model.J_Milepost_GenerUserinfo_codeName = row["J_Milepost_GenerUserinfo_codeName"].ToString();
                }


                if (row["J_Milepost_XUserinfo_codeName"] != null && row["J_Milepost_XUserinfo_codeName"].ToString() != "")
                {
                    model.J_Milepost_XUserinfo_codeName = row["J_Milepost_XUserinfo_codeName"].ToString();
                }

                if (row["J_Milepost_ZUserinfo_codeName"] != null && row["J_Milepost_ZUserinfo_codeName"].ToString() != "")
                {
                    model.J_Milepost_ZUserinfo_codeName = row["J_Milepost_ZUserinfo_codeName"].ToString();
                }

                if (row["J_Milepost_DepUserinfo_codeName"] != null && row["J_Milepost_DepUserinfo_codeName"].ToString() != "")
                {
                    model.J_Milepost_DepUserinfo_codeName = row["J_Milepost_DepUserinfo_codeName"].ToString();
                }

                if (row["J_Milepost_AuditorName"] != null && row["J_Milepost_AuditorName"].ToString() != "")
                {
                    model.J_Milepost_AuditorName = row["J_Milepost_AuditorName"].ToString();
                }

                if (row["J_Milepost_AuditorName"] != null && row["J_Milepost_AuditorName"].ToString() != "")
                {
                    model.J_Milepost_AuditorName = row["J_Milepost_AuditorName"].ToString();
                }

                if (row["J_Milepost_Type"] != null && row["J_Milepost_Type"].ToString() != "")
                {
                    model.J_Milepost_Type = int.Parse(row["J_Milepost_Type"].ToString());
                }

                if (row["J_Milepost_id"] != null && row["J_Milepost_id"].ToString() != "")
                {
                    model.J_Milepost_id = int.Parse(row["J_Milepost_id"].ToString());
                }
                if (row["J_Milepost_code"] != null && row["J_Milepost_code"].ToString() != "")
                {
                    model.J_Milepost_code = new Guid(row["J_Milepost_code"].ToString());
                }
                if (row["J_Milepost_JTime"] != null && row["J_Milepost_JTime"].ToString() != "")
                {
                    model.J_Milepost_JTime = DateTime.Parse(row["J_Milepost_JTime"].ToString());
                }
                if (row["J_Milepost_Organization_code"] != null && row["J_Milepost_Organization_code"].ToString() != "")
                {
                    model.J_Milepost_Organization_code = new Guid(row["J_Milepost_Organization_code"].ToString());
                }
                if (row["J_Milepost_ZUserinfo_code"] != null && row["J_Milepost_ZUserinfo_code"].ToString() != "")
                {
                    model.J_Milepost_ZUserinfo_code = new Guid(row["J_Milepost_ZUserinfo_code"].ToString());
                }
                if (row["J_Milepost_XUserinfo_code"] != null && row["J_Milepost_XUserinfo_code"].ToString() != "")
                {
                    model.J_Milepost_XUserinfo_code = new Guid(row["J_Milepost_XUserinfo_code"].ToString());
                }
                if (row["J_Milepost_DepUserinfo_code"] != null && row["J_Milepost_DepUserinfo_code"].ToString() != "")
                {
                    model.J_Milepost_DepUserinfo_code = new Guid(row["J_Milepost_DepUserinfo_code"].ToString());
                }
                if (row["J_Milepost_GenerUserinfo_code"] != null && row["J_Milepost_GenerUserinfo_code"].ToString() != "")
                {
                    model.J_Milepost_GenerUserinfo_code = new Guid(row["J_Milepost_GenerUserinfo_code"].ToString());
                }
                if (row["J_Milepost_CaseNumber"] != null)
                {
                    model.J_Milepost_CaseNumber = row["J_Milepost_CaseNumber"].ToString();
                }
                if (row["J_Milepost_DocumentPo"] != null)
                {
                    model.J_Milepost_DocumentPo = row["J_Milepost_DocumentPo"].ToString();
                }
                if (row["J_Milepost_Filing"] != null)
                {
                    model.J_Milepost_Filing = row["J_Milepost_Filing"].ToString();
                }
                if (row["J_Milepost_Preservation"] != null)
                {
                    model.J_Milepost_Preservation = row["J_Milepost_Preservation"].ToString();
                }
                if (row["J_Milepost_Firstcomplete"] != null)
                {
                    model.J_Milepost_Firstcomplete = row["J_Milepost_Firstcomplete"].ToString();
                }
                if (row["J_Milepost_Firstinstance"] != null)
                {
                    model.J_Milepost_Firstinstance = row["J_Milepost_Firstinstance"].ToString();
                }
                if (row["J_Milepost_Conciliation"] != null)
                {
                    model.J_Milepost_Conciliation = row["J_Milepost_Conciliation"].ToString();
                }
                if (row["J_Milepost_Prosecution"] != null)
                {
                    model.J_Milepost_Prosecution = row["J_Milepost_Prosecution"].ToString();
                }
                if (row["J_Milepost_Verdict"] != null)
                {
                    model.J_Milepost_Verdict = row["J_Milepost_Verdict"].ToString();
                }
                if (row["J_Milepost_ProgramScoreY"] != null)
                {
                    model.J_Milepost_ProgramScoreY = row["J_Milepost_ProgramScoreY"].ToString();
                }
                if (row["J_Milepost_ProgramScoreS"] != null)
                {
                    model.J_Milepost_ProgramScoreS = row["J_Milepost_ProgramScoreS"].ToString();
                }
                if (row["J_Milepost_EntityScore"] != null)
                {
                    model.J_Milepost_EntityScore = row["J_Milepost_EntityScore"].ToString();
                }
                if (row["J_Milepost_CaseScore"] != null)
                {
                    model.J_Milepost_CaseScore = row["J_Milepost_CaseScore"].ToString();
                }
                if (row["J_Milepost_Auditor"] != null && row["J_Milepost_Auditor"].ToString() != "")
                {
                    model.J_Milepost_Auditor = new Guid(row["J_Milepost_Auditor"].ToString());
                }
                if (row["J_Milepost_TJMessageType"] != null)
                {
                    model.J_Milepost_TJMessageType = row["J_Milepost_TJMessageType"].ToString();
                }
                if (row["J_Milepost_TJMessageContent"] != null)
                {
                    model.J_Milepost_TJMessageContent = row["J_Milepost_TJMessageContent"].ToString();
                }
                if (row["J_Milepost_AdMessageType"] != null)
                {
                    model.J_Milepost_AdMessageType = row["J_Milepost_AdMessageType"].ToString();
                }
                if (row["J_Milepost_AdMessageContent"] != null)
                {
                    model.J_Milepost_AdMessageContent = row["J_Milepost_AdMessageContent"].ToString();
                }
                if (row["J_Milepost_AdStatus"] != null && row["J_Milepost_AdStatus"].ToString() != "")
                {
                    model.J_Milepost_AdStatus = int.Parse(row["J_Milepost_AdStatus"].ToString());
                }




                if (row["J_Milepost_Z_TJMessageType"] != null)
                {
                    model.J_Milepost_Z_TJMessageType = row["J_Milepost_Z_TJMessageType"].ToString();
                }
                if (row["J_Milepost_Z_TJMessageContent"] != null)
                {
                    model.J_Milepost_Z_TJMessageContent = row["J_Milepost_Z_TJMessageContent"].ToString();
                }

                if (row["J_Milepost_Dep_TJMessageType"] != null)
                {
                    model.J_Milepost_Dep_TJMessageType = row["J_Milepost_Dep_TJMessageType"].ToString();
                }
                if (row["J_Milepost_Dep_TJMessageContent"] != null)
                {
                    model.J_Milepost_Dep_TJMessageContent = row["J_Milepost_Dep_TJMessageContent"].ToString();
                }





                if (row["J_Milepost_AdMessageType"] != null)
                {
                    model.J_Milepost_AdMessageType = row["J_Milepost_AdMessageType"].ToString();
                }
                if (row["J_Milepost_AdMessageContent"] != null)
                {
                    model.J_Milepost_AdMessageContent = row["J_Milepost_AdMessageContent"].ToString();
                }
                if (row["J_Milepost_AdStatus"] != null && row["J_Milepost_AdStatus"].ToString() != "")
                {
                    model.J_Milepost_AdStatus = int.Parse(row["J_Milepost_AdStatus"].ToString());
                }


                if (row["J_Milepost_Z_AdMessageType"] != null)
                {
                    model.J_Milepost_Z_AdMessageType = row["J_Milepost_Z_AdMessageType"].ToString();
                }
                if (row["J_Milepost_Z_AdMessageContent"] != null)
                {
                    model.J_Milepost_Z_AdMessageContent = row["J_Milepost_Z_AdMessageContent"].ToString();
                }
                if (row["J_Milepost_Z_AdStatus"] != null && row["J_Milepost_Z_AdStatus"].ToString() != "")
                {
                    model.J_Milepost_Z_AdStatus = int.Parse(row["J_Milepost_Z_AdStatus"].ToString());
                }

                if (row["J_Milepost_Dep_AdMessageType"] != null)
                {
                    model.J_Milepost_Dep_AdMessageType = row["J_Milepost_Dep_AdMessageType"].ToString();
                }
                if (row["J_Milepost_Dep_AdMessageContent"] != null)
                {
                    model.J_Milepost_Dep_AdMessageContent = row["J_Milepost_Dep_AdMessageContent"].ToString();
                }
                if (row["J_Milepost_Dep_AdStatus"] != null && row["J_Milepost_Dep_AdStatus"].ToString() != "")
                {
                    model.J_Milepost_Dep_AdStatus = int.Parse(row["J_Milepost_Dep_AdStatus"].ToString());
                }



                if (row["J_Milepost_createTime"] != null && row["J_Milepost_createTime"].ToString() != "")
                {
                    model.J_Milepost_createTime = DateTime.Parse(row["J_Milepost_createTime"].ToString());
                }
                if (row["J_Milepost_isDelete"] != null && row["J_Milepost_isDelete"].ToString() != "")
                {
                    if ((row["J_Milepost_isDelete"].ToString() == "1") || (row["J_Milepost_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.J_Milepost_isDelete = true;
                    }
                    else
                    {
                        model.J_Milepost_isDelete = false;
                    }
                }
                
                if (row.Table.Columns.Contains("ProjectName") && row["ProjectName"] != null && row["ProjectName"].ToString() != "")
                {
                    model.ProjectName = row["ProjectName"].ToString();
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
            strSql.Append("select J_Milepost_id,J_Milepost_code,J_Milepost_JTime,J_Milepost_Organization_code,J_Milepost_ZUserinfo_code,J_Milepost_XUserinfo_code,J_Milepost_DepUserinfo_code,J_Milepost_GenerUserinfo_code,J_Milepost_CaseNumber,J_Milepost_DocumentPo,J_Milepost_Filing,J_Milepost_Preservation,J_Milepost_Firstcomplete,J_Milepost_Firstinstance,J_Milepost_Conciliation,J_Milepost_Prosecution,J_Milepost_Verdict,J_Milepost_ProgramScoreY,J_Milepost_ProgramScoreS,J_Milepost_EntityScore,J_Milepost_CaseScore,J_Milepost_Auditor,J_Milepost_TJMessageType,J_Milepost_TJMessageContent,J_Milepost_AdMessageType,J_Milepost_AdMessageContent,J_Milepost_AdStatus,J_Milepost_createTime,J_Milepost_isDelete ");
            strSql.Append(" FROM J_Milepost ");
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
            strSql.Append(" J_Milepost_id,J_Milepost_code,J_Milepost_JTime,J_Milepost_Organization_code,J_Milepost_ZUserinfo_code,J_Milepost_XUserinfo_code,J_Milepost_DepUserinfo_code,J_Milepost_GenerUserinfo_code,J_Milepost_CaseNumber,J_Milepost_DocumentPo,J_Milepost_Filing,J_Milepost_Preservation,J_Milepost_Firstcomplete,J_Milepost_Firstinstance,J_Milepost_Conciliation,J_Milepost_Prosecution,J_Milepost_Verdict,J_Milepost_ProgramScoreY,J_Milepost_ProgramScoreS,J_Milepost_EntityScore,J_Milepost_CaseScore,J_Milepost_Auditor,J_Milepost_TJMessageType,J_Milepost_TJMessageContent,J_Milepost_AdMessageType,J_Milepost_AdMessageContent,J_Milepost_AdStatus,J_Milepost_createTime,J_Milepost_isDelete ");
            strSql.Append(" FROM J_Milepost ");
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
            strSql.Append("select count(1) FROM J_Milepost ");
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
                strSql.Append("order by T.J_Milepost_id desc");
            }
            strSql.Append(")AS Row, T.*  from J_Milepost T ");
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
        /// </summary>
        public int GetRecordCount(CommonService.Model.Milepost.J_Milepost model, string but, Guid? UserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM J_Milepost as M ");
            strSql.Append(" where 1=1 and J_Milepost_isDelete=0 ");
            if (model != null)
            {
                if (model.J_Milepost_Type != null)
                {
                    strSql.Append("and J_Milepost_Type=@J_Milepost_Type");
                }
                if (model.J_Milepost_CaseNumber != null)
                {//案号
                    strSql.Append(" and J_Milepost_CaseNumber like N'%'+@J_Milepost_CaseNumber+'%' ");
                }
                if (model.J_Milepost_AuditorName != null && model.J_Milepost_AuditorName != "")
                {
                    strSql.Append(" and ((select stuff((select ','+convert(varchar(50),C_Userinfo_code) from C_Userinfo t where C_Userinfo_name like '%" + model.J_Milepost_AuditorName + "%' and C_Userinfo_isDelete=0 for xml path('')), 1, 1, ''))) like('%'+convert(varchar(50),M.J_Milepost_Auditor)+'%') ");
                }
                if (model.J_Milepost_JTime != null && model.J_Milepost_JTime1 != null)
                {//稽核时间
                    strSql.Append(" and J_Milepost_JTime between convert(datetime,@J_Milepost_JTime,120) and convert(datetime,@J_Milepost_JTime1,120)");
                }
                if (model.J_Milepost_clientRival != null)
                {//委托人/对方当事人
                    strSql.Append(" and (");
                    strSql.Append("exists(select top 1 * from B_Case_link as CL with(nolock),B_Case as C with(nolock),C_Customer as CUS with(nolock) where C.B_Case_code=CL.B_Case_code and C.B_Case_number=M.J_Milepost_CaseNumber and CL.B_Case_link_type=1 and CL.C_FK_code=CUS.C_Customer_code and CUS.C_Customer_name like N'%'+@J_Milepost_clientRival+'%' )");
                    strSql.Append("or exists(select top 1 * from B_Case_link as CL1 with(nolock),B_Case as C1 with(nolock),C_CRival as CR with(nolock) where C1.B_Case_code=CL1.B_Case_code and C1.B_Case_number=M.J_Milepost_CaseNumber and CL1.B_Case_link_type=2 and CL1.C_FK_code=CR.C_CRival_code and CR.C_CRival_name like N'%'+@J_Milepost_clientRival+'%' )");
                    strSql.Append("or exists(select top 1 * from B_Case_link as CL2 with(nolock),B_Case as C2 with(nolock),C_PRival as PR with(nolock) where C2.B_Case_code=CL2.B_Case_code and C2.B_Case_number=M.J_Milepost_CaseNumber and CL2.B_Case_link_type=3 and CL2.C_FK_code=PR.C_PRival_code and PR.C_PRival_name like N'%'+@J_Milepost_clientRival+'%' )");
                    strSql.Append(")");
                }
                if (model.J_Milepost_sponsorlawyer != null)
                {//主办律师
                    strSql.Append(" and (");
                    strSql.Append(" exists(select top 1 * from P_Business_flow as BF with(nolock),B_Case as C with(nolock),C_Userinfo as U with(nolock) where M.J_Milepost_CaseNumber=C.B_Case_number and BF.P_Fk_code=C.B_Case_code and BF.P_Business_person=U.C_Userinfo_code and U.C_Userinfo_name like N'%'+@J_Milepost_sponsorlawyer+'%')");
                    strSql.Append(")");
                }
                if (model.J_Milepost_Colawyer != null)
                {//协办律师
                    strSql.Append(" and (");
                    strSql.Append(" exists(select top 1 * from P_Business_flow_form as BFF with(nolock),P_Business_flow as BF with(nolock),B_Case as C with(nolock),C_Userinfo as U with(nolock) where M.J_Milepost_CaseNumber=C.B_Case_number and BF.P_Fk_code=C.B_Case_code and BFF.P_Business_flow_code=BF.P_Business_flow_code and BFF.P_Business_flow_form_person=U.C_Userinfo_code and U.C_Userinfo_name like N'%'+@J_Milepost_Colawyer+'%')");
                    strSql.Append(")");
                }
            }
            if (but != "")
                strSql.Append(" and( '" + but + "' like '%'+convert(varchar(50),J_Milepost_Auditor)+'%' or J_Milepost_ZUserinfo_code='" + UserCode + "' or J_Milepost_DepUserinfo_code='" + UserCode + "' or J_Milepost_GenerUserinfo_code='" + UserCode + "') ");


            SqlParameter[] parameters = {
                    new SqlParameter("@J_Milepost_Type", SqlDbType.Int),
                    new SqlParameter("@J_Milepost_CaseNumber", SqlDbType.VarChar,50),
                    new SqlParameter("@J_Milepost_JTime",SqlDbType.DateTime),
                    new SqlParameter("@J_Milepost_JTime1",SqlDbType.DateTime),
                    new SqlParameter("@J_Milepost_clientRival",SqlDbType.VarChar),
                    new SqlParameter("@J_Milepost_sponsorlawyer",SqlDbType.VarChar),
                    new SqlParameter("@J_Milepost_Colawyer",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.J_Milepost_Type;
            parameters[1].Value = model.J_Milepost_CaseNumber;
            parameters[2].Value = model.J_Milepost_JTime;
            parameters[3].Value = model.J_Milepost_JTime1;
            parameters[4].Value = model.J_Milepost_clientRival;
            parameters[5].Value = model.J_Milepost_sponsorlawyer;
            parameters[6].Value = model.J_Milepost_Colawyer;
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
        public DataSet GetListByPage(CommonService.Model.Milepost.J_Milepost model, string orderby, int startIndex, int endIndex, string but, Guid? UserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *");
            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_Auditor) as J_Milepost_AuditorName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_ZUserinfo_code) as J_Milepost_ZUserinfo_codeName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_XUserinfo_code) as J_Milepost_XUserinfo_codeName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_DepUserinfo_code) as J_Milepost_DepUserinfo_codeName ");

            strSql.Append(",(select top 1(select C_Involved_project_name from C_Involved_project where C_Involved_project_code=(select top 1 C_FK_code from B_Case_link where B_Case_link_type=7 and B_Case_code=B_Case.B_Case_code)) from B_Case where B_Case_number=TT.J_Milepost_CaseNumber) as ProjectName ");
            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_Milepost_GenerUserinfo_code) as J_Milepost_GenerUserinfo_codeName ");

            strSql.Append(",(select top 1 (select C_Customer_name  from C_Customer where C_Customer_code=B_Case_link.C_FK_code) from B_Case_link where B_Case_code =(select top 1 B_Case_code from B_Case where B_Case_number=TT.J_Milepost_CaseNumber) and B_Case_link_type=1) as C_Customer_yg ");


            strSql.Append(",(select stuff((select '+'+(select C_CRival_name  from C_CRival where C_CRival_code=t.C_FK_code) from B_Case_link t where B_Case_code in(select B_Case_code from B_Case where B_Case_number=TT.J_Milepost_CaseNumber) and B_Case_link_type=2 for xml path('')), 1, 1, '')) as C_Customer_BG_1 ");
            strSql.Append(",(select stuff((select '+'+(select C_PRival_name  from C_PRival where C_PRival_code=t.C_FK_code) from B_Case_link t where B_Case_code in(select B_Case_code from B_Case where B_Case_number=TT.J_Milepost_CaseNumber) and B_Case_link_type=3 for xml path('')), 1, 1, '')) as C_Customer_BG_2 ");

            strSql.Append("FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.J_Milepost_id desc");
            }
            strSql.Append(")AS Row, T.*  from J_Milepost T ");
            strSql.Append(" where 1=1 and J_Milepost_isDelete=0 ");
            if (model != null)
            {
                if (model.J_Milepost_Type != null)
                {
                    strSql.Append(" and J_Milepost_Type=@J_Milepost_Type ");
                }
                if (model.J_Milepost_CaseNumber != null)
                {//案号
                    strSql.Append(" and J_Milepost_CaseNumber like N'%'+@J_Milepost_CaseNumber+'%' ");
                }
                if (model.J_Milepost_AuditorName != null && model.J_Milepost_AuditorName != "")
                {
                    strSql.Append(" and ((select stuff((select ','+convert(varchar(50),C_Userinfo_code) from C_Userinfo t where C_Userinfo_name like '%" + model.J_Milepost_AuditorName + "%' and C_Userinfo_isDelete=0 for xml path('')), 1, 1, ''))) like('%'+convert(varchar(50),T.J_Milepost_Auditor)+'%') ");
                }
                if (model.J_Milepost_JTime != null && model.J_Milepost_JTime1 != null)
                {//稽核时间
                    strSql.Append(" and J_Milepost_JTime between convert(datetime,@J_Milepost_JTime,120) and convert(datetime,@J_Milepost_JTime1,120)");
                }
                if (model.J_Milepost_clientRival != null)
                {//委托人/对方当事人
                    strSql.Append(" and (");
                    strSql.Append("exists(select top 1 * from B_Case_link as CL with(nolock),B_Case as C with(nolock),C_Customer as CUS with(nolock) where C.B_Case_code=CL.B_Case_code and C.B_Case_number=T.J_Milepost_CaseNumber and CL.B_Case_link_type=1 and CL.C_FK_code=CUS.C_Customer_code and CUS.C_Customer_name like N'%'+@J_Milepost_clientRival+'%' )");
                    strSql.Append("or exists(select top 1 * from B_Case_link as CL1 with(nolock),B_Case as C1 with(nolock),C_CRival as CR with(nolock) where C1.B_Case_code=CL1.B_Case_code and C1.B_Case_number=T.J_Milepost_CaseNumber and CL1.B_Case_link_type=2 and CL1.C_FK_code=CR.C_CRival_code and CR.C_CRival_name like N'%'+@J_Milepost_clientRival+'%' )");
                    strSql.Append("or exists(select top 1 * from B_Case_link as CL2 with(nolock),B_Case as C2 with(nolock),C_PRival as PR with(nolock) where C2.B_Case_code=CL2.B_Case_code and C2.B_Case_number=T.J_Milepost_CaseNumber and CL2.B_Case_link_type=3 and CL2.C_FK_code=PR.C_PRival_code and PR.C_PRival_name like N'%'+@J_Milepost_clientRival+'%' )");
                    strSql.Append(")");
                }
                if (model.J_Milepost_sponsorlawyer != null)
                {//主办律师
                    strSql.Append(" and (");
                    strSql.Append(" exists(select top 1 * from P_Business_flow as BF with(nolock),B_Case as C with(nolock),C_Userinfo as U with(nolock) where T.J_Milepost_CaseNumber=C.B_Case_number and BF.P_Fk_code=C.B_Case_code and BF.P_Business_person=U.C_Userinfo_code and U.C_Userinfo_name like N'%'+@J_Milepost_sponsorlawyer+'%')");
                    strSql.Append(")");
                }
                if (model.J_Milepost_Colawyer != null)
                {//协办律师
                    strSql.Append(" and (");
                    strSql.Append(" exists(select top 1 * from P_Business_flow_form as BFF with(nolock),P_Business_flow as BF with(nolock),B_Case as C with(nolock),C_Userinfo as U with(nolock) where T.J_Milepost_CaseNumber=C.B_Case_number and BF.P_Fk_code=C.B_Case_code and BFF.P_Business_flow_code=BF.P_Business_flow_code and BFF.P_Business_flow_form_person=U.C_Userinfo_code and U.C_Userinfo_name like N'%'+@J_Milepost_Colawyer+'%')");
                    strSql.Append(")");
                }

            }
            if (but != "")
                strSql.Append(" and( '" + but + "' like '%'+convert(varchar(50),J_Milepost_Auditor)+'%' or J_Milepost_ZUserinfo_code='" + UserCode + "' or J_Milepost_DepUserinfo_code='" + UserCode + "' or J_Milepost_GenerUserinfo_code='" + UserCode + "') ");


            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
                    new SqlParameter("@J_Milepost_Type", SqlDbType.Int),
                    new SqlParameter("@J_Milepost_CaseNumber", SqlDbType.VarChar,50),
                    new SqlParameter("@J_Milepost_JTime",SqlDbType.DateTime),
                    new SqlParameter("@J_Milepost_JTime1",SqlDbType.DateTime),
                    new SqlParameter("@J_Milepost_clientRival",SqlDbType.VarChar),
                    new SqlParameter("@J_Milepost_sponsorlawyer",SqlDbType.VarChar),
                    new SqlParameter("@J_Milepost_Colawyer",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.J_Milepost_Type;
            parameters[1].Value = model.J_Milepost_CaseNumber;
            parameters[2].Value = model.J_Milepost_JTime;
            parameters[3].Value = model.J_Milepost_JTime1;
            parameters[4].Value = model.J_Milepost_clientRival;
            parameters[5].Value = model.J_Milepost_sponsorlawyer;
            parameters[6].Value = model.J_Milepost_Colawyer;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

