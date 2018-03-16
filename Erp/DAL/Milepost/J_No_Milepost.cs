
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.Milepost
{
    /// <summary>
    /// 数据访问类:J_No_Milepost
    /// </summary>
    public partial class J_No_Milepost
    {
        public J_No_Milepost()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("J_No_Milepost_id", "J_No_Milepost");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int J_No_Milepost_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from J_No_Milepost");
            strSql.Append(" where J_No_Milepost_id=J_No_Milepost_id");
            SqlParameter[] parameters = {
					new SqlParameter("J_No_Milepost_id", SqlDbType.Int,4)
			};
            parameters[0].Value = J_No_Milepost_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.Milepost.J_No_Milepost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into J_No_Milepost(");
            strSql.Append("J_No_Milepost_code,J_No_Milepost_JTime,J_No_Milepost_ZUserinfo_code,J_No_Milepost_DepUserinfo_code,J_No_Milepost_GenerUserinfo_code,J_No_Milepost_CaseNumber,J_No_Milepost_DocumentPo,J_No_Milepost_Filing,J_No_Milepost_Preservation,J_No_Milepost_Auditor,J_No_Milepost_TJMessageType,J_No_Milepost_TJMessageContent,J_No_Milepost_AdMessageType,J_No_Milepost_AdMessageContent,J_No_Milepost_AdStatus,J_No_Milepost_createTime,J_No_Milepost_isDelete,J_No_Milepost_Z_TJMessageType,J_No_Milepost_Z_TJMessageContent,J_No_Milepost_Dep_TJMessageType,J_No_Milepost_Dep_TJMessageContent,J_No_Milepost_Z_AdMessageType,J_No_Milepost_Z_AdMessageContent,J_No_Milepost_Z_AdStatus,J_No_Milepost_Dep_AdMessageType,J_No_Milepost_Dep_AdMessageContent,J_No_Milepost_Dep_AdStatus)");
            strSql.Append(" values (");
            strSql.Append("@J_No_Milepost_code,@J_No_Milepost_JTime,@J_No_Milepost_ZUserinfo_code,@J_No_Milepost_DepUserinfo_code,@J_No_Milepost_GenerUserinfo_code,@J_No_Milepost_CaseNumber,@J_No_Milepost_DocumentPo,@J_No_Milepost_Filing,@J_No_Milepost_Preservation,@J_No_Milepost_Auditor,@J_No_Milepost_TJMessageType,@J_No_Milepost_TJMessageContent,@J_No_Milepost_AdMessageType,@J_No_Milepost_AdMessageContent,@J_No_Milepost_AdStatus,@J_No_Milepost_createTime,@J_No_Milepost_isDelete,@J_No_Milepost_Z_TJMessageType,@J_No_Milepost_Z_TJMessageContent,@J_No_Milepost_Dep_TJMessageType,@J_No_Milepost_Dep_TJMessageContent,@J_No_Milepost_Z_AdMessageType,@J_No_Milepost_Z_AdMessageContent,@J_No_Milepost_Z_AdStatus,@J_No_Milepost_Dep_AdMessageType,@J_No_Milepost_Dep_AdMessageContent,@J_No_Milepost_Dep_AdStatus)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@J_No_Milepost_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_JTime", SqlDbType.DateTime),
					new SqlParameter("@J_No_Milepost_ZUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_DepUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_GenerUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_CaseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@J_No_Milepost_DocumentPo", SqlDbType.NVarChar,500),
					new SqlParameter("@J_No_Milepost_Filing", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Preservation", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Auditor", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_TJMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_No_Milepost_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_No_Milepost_AdStatus", SqlDbType.Int,4),
					new SqlParameter("@J_No_Milepost_createTime", SqlDbType.DateTime),
					new SqlParameter("@J_No_Milepost_isDelete", SqlDbType.Bit,1),
                                        
                    new SqlParameter("@J_No_Milepost_Z_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Z_TJMessageContent", SqlDbType.NVarChar,50),
                    new SqlParameter("@J_No_Milepost_Dep_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Dep_TJMessageContent", SqlDbType.NVarChar,50),
                    new SqlParameter("@J_No_Milepost_Z_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Z_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_No_Milepost_Z_AdStatus", SqlDbType.Int,4),           
                           
                       new SqlParameter("@J_No_Milepost_Dep_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Dep_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_No_Milepost_Dep_AdStatus", SqlDbType.Int,4), 
                                        };
            parameters[0].Value = model.J_No_Milepost_code;
            parameters[1].Value = model.J_No_Milepost_JTime;
            parameters[2].Value = model.J_No_Milepost_ZUserinfo_code;
            parameters[3].Value = model.J_No_Milepost_DepUserinfo_code;
            parameters[4].Value = model.J_No_Milepost_GenerUserinfo_code;
            parameters[5].Value = model.J_No_Milepost_CaseNumber;
            parameters[6].Value = model.J_No_Milepost_DocumentPo;
            parameters[7].Value = model.J_No_Milepost_Filing;
            parameters[8].Value = model.J_No_Milepost_Preservation;
            parameters[9].Value = model.J_No_Milepost_Auditor;
            parameters[10].Value = model.J_No_Milepost_TJMessageType;
            parameters[11].Value = model.J_No_Milepost_TJMessageContent;
            parameters[12].Value = model.J_No_Milepost_AdMessageType;
            parameters[13].Value = model.J_No_Milepost_AdMessageContent;
            parameters[14].Value = model.J_No_Milepost_AdStatus;
            parameters[15].Value = model.J_No_Milepost_createTime;
            parameters[16].Value = model.J_No_Milepost_isDelete;
            parameters[17].Value = model.J_No_Milepost_Z_TJMessageType;
            parameters[18].Value = model.J_No_Milepost_Z_TJMessageContent;

            parameters[19].Value = model.J_No_Milepost_Dep_TJMessageType;
            parameters[20].Value = model.J_No_Milepost_Dep_TJMessageContent;

            parameters[21].Value = model.J_No_Milepost_Z_AdMessageType;
            parameters[22].Value = model.J_No_Milepost_Z_AdMessageContent;
            parameters[23].Value = model.J_No_Milepost_Z_AdStatus;

            parameters[24].Value = model.J_No_Milepost_Dep_AdMessageType;
            parameters[25].Value = model.J_No_Milepost_Dep_AdMessageContent;
            parameters[26].Value = model.J_No_Milepost_Dep_AdStatus;

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
        /// 根据非里程碑Id，稽查项,插入数据
        /// </summary>
        /// <param name="J_No_Milepost_id">非里程碑Id</param>
        /// <param name="documentPro">稽查项</param>
        /// <returns></returns>
        public bool InsertByMilePostIdAndDocumentPro(int J_No_Milepost_id, string documentPro)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into J_No_Milepost");
            strSql.Append("(");
            strSql.Append("J_No_Milepost_code,J_No_Milepost_JTime,J_No_Milepost_ZUserinfo_code,J_No_Milepost_DepUserinfo_code,J_No_Milepost_GenerUserinfo_code,");
            strSql.Append("J_No_Milepost_CaseNumber,J_No_Milepost_DocumentPo,J_No_Milepost_Filing,J_No_Milepost_Preservation,J_No_Milepost_Auditor,J_No_Milepost_TJMessageType,");
            strSql.Append("J_No_Milepost_TJMessageContent,J_No_Milepost_AdMessageType,J_No_Milepost_AdMessageContent,J_No_Milepost_AdStatus,J_No_Milepost_createTime,");
            strSql.Append("J_No_Milepost_isDelete,J_No_Milepost_Z_TJMessageType,J_No_Milepost_Z_TJMessageContent,J_No_Milepost_Dep_TJMessageType,J_No_Milepost_Dep_TJMessageContent,");
            strSql.Append("J_No_Milepost_Z_AdMessageType,J_No_Milepost_Z_AdMessageContent,J_No_Milepost_Z_AdStatus,J_No_Milepost_Dep_AdMessageType,J_No_Milepost_Dep_AdMessageContent,");
            strSql.Append("J_No_Milepost_Dep_AdStatus");
            strSql.Append(") ");
            strSql.Append("select ");
            strSql.Append("newid(),J_No_Milepost_JTime,J_No_Milepost_ZUserinfo_code,J_No_Milepost_DepUserinfo_code,J_No_Milepost_GenerUserinfo_code,");
            strSql.Append("J_No_Milepost_CaseNumber,@J_No_Milepost_DocumentPo,J_No_Milepost_Filing,J_No_Milepost_Preservation,J_No_Milepost_Auditor,J_No_Milepost_TJMessageType,");
            strSql.Append("J_No_Milepost_TJMessageContent,J_No_Milepost_AdMessageType,J_No_Milepost_AdMessageContent,J_No_Milepost_AdStatus,J_No_Milepost_createTime,");
            strSql.Append("J_No_Milepost_isDelete,J_No_Milepost_Z_TJMessageType,J_No_Milepost_Z_TJMessageContent,J_No_Milepost_Dep_TJMessageType,J_No_Milepost_Dep_TJMessageContent,");
            strSql.Append("J_No_Milepost_Z_AdMessageType,J_No_Milepost_Z_AdMessageContent,J_No_Milepost_Z_AdStatus,J_No_Milepost_Dep_AdMessageType,J_No_Milepost_Dep_AdMessageContent,");
            strSql.Append("J_No_Milepost_Dep_AdStatus ");
            strSql.Append("from J_No_Milepost ");
            strSql.Append("where J_No_Milepost_id=@J_No_Milepost_id ");
            strSql.Append("");
            strSql.Append("");
            

            SqlParameter[] parameters = {
                    new SqlParameter("@J_No_Milepost_DocumentPo", SqlDbType.NVarChar,2000),
					new SqlParameter("@J_No_Milepost_id", SqlDbType.Int)
			};
            parameters[0].Value = documentPro;
            parameters[1].Value = J_No_Milepost_id;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.Milepost.J_No_Milepost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update J_No_Milepost set ");
            strSql.Append("J_No_Milepost_code=@J_No_Milepost_code,");
            strSql.Append("J_No_Milepost_JTime=@J_No_Milepost_JTime,");
            strSql.Append("J_No_Milepost_ZUserinfo_code=@J_No_Milepost_ZUserinfo_code,");
            strSql.Append("J_No_Milepost_DepUserinfo_code=@J_No_Milepost_DepUserinfo_code,");
            strSql.Append("J_No_Milepost_GenerUserinfo_code=@J_No_Milepost_GenerUserinfo_code,");
            strSql.Append("J_No_Milepost_CaseNumber=@J_No_Milepost_CaseNumber,");
            strSql.Append("J_No_Milepost_DocumentPo=@J_No_Milepost_DocumentPo,");
            strSql.Append("J_No_Milepost_Filing=@J_No_Milepost_Filing,");
            strSql.Append("J_No_Milepost_Preservation=@J_No_Milepost_Preservation,");
            strSql.Append("J_No_Milepost_Auditor=@J_No_Milepost_Auditor,");
            strSql.Append("J_No_Milepost_TJMessageType=@J_No_Milepost_TJMessageType,");
            strSql.Append("J_No_Milepost_TJMessageContent=@J_No_Milepost_TJMessageContent,");
            strSql.Append("J_No_Milepost_AdMessageType=@J_No_Milepost_AdMessageType,");
            strSql.Append("J_No_Milepost_AdMessageContent=@J_No_Milepost_AdMessageContent,");
            strSql.Append("J_No_Milepost_AdStatus=@J_No_Milepost_AdStatus,");
            strSql.Append("J_No_Milepost_createTime=@J_No_Milepost_createTime,");
            strSql.Append("J_No_Milepost_isDelete=@J_No_Milepost_isDelete,");

            strSql.Append("J_No_Milepost_Z_TJMessageType=@J_No_Milepost_Z_TJMessageType,");
            strSql.Append("J_No_Milepost_Z_TJMessageContent=@J_No_Milepost_Z_TJMessageContent,");
            strSql.Append("J_No_Milepost_Dep_TJMessageType=@J_No_Milepost_Dep_TJMessageType,");
            strSql.Append("J_No_Milepost_Dep_TJMessageContent=@J_No_Milepost_Dep_TJMessageContent,");

            strSql.Append("J_No_Milepost_Z_AdMessageType=@J_No_Milepost_Z_AdMessageType,");
            strSql.Append("J_No_Milepost_Z_AdMessageContent=@J_No_Milepost_Z_AdMessageContent,");
            strSql.Append("J_No_Milepost_Z_AdStatus=@J_No_Milepost_Z_AdStatus,");

            strSql.Append("J_No_Milepost_Dep_AdMessageType=@J_No_Milepost_Dep_AdMessageType,");
            strSql.Append("J_No_Milepost_Dep_AdMessageContent=@J_No_Milepost_Dep_AdMessageContent,");
            strSql.Append("J_No_Milepost_Dep_AdStatus=@J_No_Milepost_Dep_AdStatus ");

            strSql.Append(" where J_No_Milepost_id=@J_No_Milepost_id");
            SqlParameter[] parameters = {
					new SqlParameter("@J_No_Milepost_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_JTime", SqlDbType.DateTime),
					new SqlParameter("@J_No_Milepost_ZUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_DepUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_GenerUserinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_CaseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@J_No_Milepost_DocumentPo", SqlDbType.NVarChar,500),
					new SqlParameter("@J_No_Milepost_Filing", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Preservation", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Auditor", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@J_No_Milepost_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_TJMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_No_Milepost_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_No_Milepost_AdStatus", SqlDbType.Int,4),
					new SqlParameter("@J_No_Milepost_createTime", SqlDbType.DateTime),
					new SqlParameter("@J_No_Milepost_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@J_No_Milepost_id", SqlDbType.Int,4),

                    new SqlParameter("@J_No_Milepost_Z_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Z_TJMessageContent", SqlDbType.NVarChar,50),
                    new SqlParameter("@J_No_Milepost_Dep_TJMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Dep_TJMessageContent", SqlDbType.NVarChar,50),
                    new SqlParameter("@J_No_Milepost_Z_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Z_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_No_Milepost_Z_AdStatus", SqlDbType.Int,4),           
                           
                       new SqlParameter("@J_No_Milepost_Dep_AdMessageType", SqlDbType.NVarChar,20),
					new SqlParameter("@J_No_Milepost_Dep_AdMessageContent", SqlDbType.NVarChar,50),
					new SqlParameter("@J_No_Milepost_Dep_AdStatus", SqlDbType.Int,4)            
                                        
                                        };
            parameters[0].Value = model.J_No_Milepost_code;
            parameters[1].Value = model.J_No_Milepost_JTime;
            parameters[2].Value = model.J_No_Milepost_ZUserinfo_code;
            parameters[3].Value = model.J_No_Milepost_DepUserinfo_code;
            parameters[4].Value = model.J_No_Milepost_GenerUserinfo_code;
            parameters[5].Value = model.J_No_Milepost_CaseNumber;
            parameters[6].Value = model.J_No_Milepost_DocumentPo;
            parameters[7].Value = model.J_No_Milepost_Filing;
            parameters[8].Value = model.J_No_Milepost_Preservation;
            parameters[9].Value = model.J_No_Milepost_Auditor;
            parameters[10].Value = model.J_No_Milepost_TJMessageType;
            parameters[11].Value = model.J_No_Milepost_TJMessageContent;
            parameters[12].Value = model.J_No_Milepost_AdMessageType;
            parameters[13].Value = model.J_No_Milepost_AdMessageContent;
            parameters[14].Value = model.J_No_Milepost_AdStatus;
            parameters[15].Value = model.J_No_Milepost_createTime;
            parameters[16].Value = model.J_No_Milepost_isDelete;
            parameters[17].Value = model.J_No_Milepost_id;
            parameters[18].Value = model.J_No_Milepost_Z_TJMessageType;
            parameters[19].Value = model.J_No_Milepost_Z_TJMessageContent;

            parameters[20].Value = model.J_No_Milepost_Dep_TJMessageType;
            parameters[21].Value = model.J_No_Milepost_Dep_TJMessageContent;

            parameters[22].Value = model.J_No_Milepost_Z_AdMessageType;
            parameters[23].Value = model.J_No_Milepost_Z_AdMessageContent;
            parameters[24].Value = model.J_No_Milepost_Z_AdStatus;

            parameters[25].Value = model.J_No_Milepost_Dep_AdMessageType;
            parameters[26].Value = model.J_No_Milepost_Dep_AdMessageContent;
            parameters[27].Value = model.J_No_Milepost_Dep_AdStatus;
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
        /// 根据非里程碑Id，更改稽查项
        /// </summary>
        /// <param name="J_No_Milepost_id">非里程碑Id</param>
        /// <param name="documentPro">稽查项</param>
        /// <returns></returns>
        public bool UploadDocumentPro(int J_No_Milepost_id,string documentPro)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update J_No_Milepost set J_No_Milepost_DocumentPo=@J_No_Milepost_DocumentPo ");
            strSql.Append("where J_No_Milepost_id=@J_No_Milepost_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@J_No_Milepost_DocumentPo", SqlDbType.NVarChar,2000),
					new SqlParameter("@J_No_Milepost_id", SqlDbType.Int)
			};
            parameters[0].Value = documentPro;
            parameters[1].Value = J_No_Milepost_id;

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
        public bool Delete(int J_No_Milepost_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update J_No_Milepost set J_No_Milepost_isDelete=1 ");
            strSql.Append("where J_No_Milepost_id=@J_No_Milepost_id");
            SqlParameter[] parameters = {
					new SqlParameter("@J_No_Milepost_id", SqlDbType.Int)
			};
            parameters[0].Value = J_No_Milepost_id;

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
        public bool DeleteList(string J_No_Milepost_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from J_No_Milepost ");
            strSql.Append(" where J_No_Milepost_id in (" + J_No_Milepost_idlist + ")  ");
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
        public CommonService.Model.Milepost.J_No_Milepost GetModel(int J_No_Milepost_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_No_Milepost_Auditor) as J_No_Milepost_AuditorName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_No_Milepost_ZUserinfo_code) as J_No_Milepost_ZUserinfo_codeName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_No_Milepost_DepUserinfo_code) as J_No_Milepost_DepUserinfo_codeName ");


            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_No_Milepost_GenerUserinfo_code) as J_No_Milepost_GenerUserinfo_codeName ");

            strSql.Append(",(select (select C_Customer_name  from C_Customer where C_Customer_code=B_Case_link.C_FK_code) from B_Case_link where B_Case_code =(select top 1 B_Case_code from B_Case where B_Case_number=TT.J_No_Milepost_CaseNumber) and B_Case_link_type=1) as C_Customer_yg ");


            strSql.Append(",(select stuff((select '+'+(select C_CRival_name  from C_CRival where C_CRival_code=t.C_FK_code) from B_Case_link t where B_Case_code in(select B_Case_code from B_Case where B_Case_number=TT.J_No_Milepost_CaseNumber) and B_Case_link_type=2 for xml path('')), 1, 1, '')) as C_Customer_BG_1 ");
            strSql.Append(",(select stuff((select '+'+(select C_PRival_name  from C_PRival where C_PRival_code=t.C_FK_code) from B_Case_link t where B_Case_code in(select B_Case_code from B_Case where B_Case_number=TT.J_No_Milepost_CaseNumber) and B_Case_link_type=3 for xml path('')), 1, 1, '')) as C_Customer_BG_2 ");

            strSql.Append(" FROM  J_No_Milepost as TT");
            strSql.Append(" where J_No_Milepost_id=@J_No_Milepost_id");
            SqlParameter[] parameters = {
					new SqlParameter("@J_No_Milepost_id", SqlDbType.Int,4)
			};
            parameters[0].Value = J_No_Milepost_id;

            CommonService.Model.Milepost.J_No_Milepost model = new CommonService.Model.Milepost.J_No_Milepost();
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
        public CommonService.Model.Milepost.J_No_Milepost DataRowToModel(DataRow row)
        {
            CommonService.Model.Milepost.J_No_Milepost model = new CommonService.Model.Milepost.J_No_Milepost();
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



                if (row["J_No_Milepost_ZUserinfo_codeName"] != null && row["J_No_Milepost_ZUserinfo_codeName"].ToString() != "")
                {
                    model.J_No_Milepost_ZUserinfo_codeName = row["J_No_Milepost_ZUserinfo_codeName"].ToString();
                }

                if (row["J_No_Milepost_DepUserinfo_codeName"] != null && row["J_No_Milepost_DepUserinfo_codeName"].ToString() != "")
                {
                    model.J_No_Milepost_DepUserinfo_codeName = row["J_No_Milepost_DepUserinfo_codeName"].ToString();
                }

                if (row["J_No_Milepost_GenerUserinfo_codeName"] != null && row["J_No_Milepost_GenerUserinfo_codeName"].ToString() != "")
                {
                    model.J_No_Milepost_GenerUserinfo_codeName = row["J_No_Milepost_GenerUserinfo_codeName"].ToString();
                }

                if (row["J_No_Milepost_AuditorName"] != null && row["J_No_Milepost_AuditorName"].ToString() != "")
                {
                    model.J_No_Milepost_AuditorName = row["J_No_Milepost_AuditorName"].ToString();
                }
                if (row["J_No_Milepost_id"] != null && row["J_No_Milepost_id"].ToString() != "")
                {
                    model.J_No_Milepost_id = int.Parse(row["J_No_Milepost_id"].ToString());
                }
                if (row["J_No_Milepost_code"] != null && row["J_No_Milepost_code"].ToString() != "")
                {
                    model.J_No_Milepost_code = new Guid(row["J_No_Milepost_code"].ToString());
                }
                if (row["J_No_Milepost_JTime"] != null && row["J_No_Milepost_JTime"].ToString() != "")
                {
                    model.J_No_Milepost_JTime = DateTime.Parse(row["J_No_Milepost_JTime"].ToString());
                }
                if (row["J_No_Milepost_ZUserinfo_code"] != null && row["J_No_Milepost_ZUserinfo_code"].ToString() != "")
                {
                    model.J_No_Milepost_ZUserinfo_code = new Guid(row["J_No_Milepost_ZUserinfo_code"].ToString());
                }
                if (row["J_No_Milepost_DepUserinfo_code"] != null && row["J_No_Milepost_DepUserinfo_code"].ToString() != "")
                {
                    model.J_No_Milepost_DepUserinfo_code = new Guid(row["J_No_Milepost_DepUserinfo_code"].ToString());
                }
                if (row["J_No_Milepost_GenerUserinfo_code"] != null && row["J_No_Milepost_GenerUserinfo_code"].ToString() != "")
                {
                    model.J_No_Milepost_GenerUserinfo_code = new Guid(row["J_No_Milepost_GenerUserinfo_code"].ToString());
                }
                if (row["J_No_Milepost_CaseNumber"] != null)
                {
                    model.J_No_Milepost_CaseNumber = row["J_No_Milepost_CaseNumber"].ToString();
                }
                if (row["J_No_Milepost_DocumentPo"] != null)
                {
                    model.J_No_Milepost_DocumentPo = row["J_No_Milepost_DocumentPo"].ToString();
                }
                if (row["J_No_Milepost_Filing"] != null)
                {
                    model.J_No_Milepost_Filing = row["J_No_Milepost_Filing"].ToString();
                }
                if (row["J_No_Milepost_Preservation"] != null)
                {
                    model.J_No_Milepost_Preservation = row["J_No_Milepost_Preservation"].ToString();
                }
                if (row["J_No_Milepost_Auditor"] != null && row["J_No_Milepost_Auditor"].ToString() != "")
                {
                    model.J_No_Milepost_Auditor = new Guid(row["J_No_Milepost_Auditor"].ToString());
                }
                if (row["J_No_Milepost_TJMessageType"] != null)
                {
                    model.J_No_Milepost_TJMessageType = row["J_No_Milepost_TJMessageType"].ToString();
                }
                if (row["J_No_Milepost_TJMessageContent"] != null)
                {
                    model.J_No_Milepost_TJMessageContent = row["J_No_Milepost_TJMessageContent"].ToString();
                }


                if (row["J_No_Milepost_Z_TJMessageType"] != null)
                {
                    model.J_No_Milepost_Z_TJMessageType = row["J_No_Milepost_Z_TJMessageType"].ToString();
                }
                if (row["J_No_Milepost_Z_TJMessageContent"] != null)
                {
                    model.J_No_Milepost_Z_TJMessageContent = row["J_No_Milepost_Z_TJMessageContent"].ToString();
                }

                if (row["J_No_Milepost_Dep_TJMessageType"] != null)
                {
                    model.J_No_Milepost_Dep_TJMessageType = row["J_No_Milepost_Dep_TJMessageType"].ToString();
                }
                if (row["J_No_Milepost_Dep_TJMessageContent"] != null)
                {
                    model.J_No_Milepost_Dep_TJMessageContent = row["J_No_Milepost_Dep_TJMessageContent"].ToString();
                }





                if (row["J_No_Milepost_AdMessageType"] != null)
                {
                    model.J_No_Milepost_AdMessageType = row["J_No_Milepost_AdMessageType"].ToString();
                }
                if (row["J_No_Milepost_AdMessageContent"] != null)
                {
                    model.J_No_Milepost_AdMessageContent = row["J_No_Milepost_AdMessageContent"].ToString();
                }
                if (row["J_No_Milepost_AdStatus"] != null && row["J_No_Milepost_AdStatus"].ToString() != "")
                {
                    model.J_No_Milepost_AdStatus = int.Parse(row["J_No_Milepost_AdStatus"].ToString());
                }


                if (row["J_No_Milepost_Z_AdMessageType"] != null)
                {
                    model.J_No_Milepost_Z_AdMessageType = row["J_No_Milepost_Z_AdMessageType"].ToString();
                }
                if (row["J_No_Milepost_Z_AdMessageContent"] != null)
                {
                    model.J_No_Milepost_Z_AdMessageContent = row["J_No_Milepost_Z_AdMessageContent"].ToString();
                }
                if (row["J_No_Milepost_Z_AdStatus"] != null && row["J_No_Milepost_Z_AdStatus"].ToString() != "")
                {
                    model.J_No_Milepost_Z_AdStatus = int.Parse(row["J_No_Milepost_Z_AdStatus"].ToString());
                }

                if (row["J_No_Milepost_Dep_AdMessageType"] != null)
                {
                    model.J_No_Milepost_Dep_AdMessageType = row["J_No_Milepost_Dep_AdMessageType"].ToString();
                }
                if (row["J_No_Milepost_Dep_AdMessageContent"] != null)
                {
                    model.J_No_Milepost_Dep_AdMessageContent = row["J_No_Milepost_Dep_AdMessageContent"].ToString();
                }
                if (row["J_No_Milepost_Dep_AdStatus"] != null && row["J_No_Milepost_Dep_AdStatus"].ToString() != "")
                {
                    model.J_No_Milepost_Dep_AdStatus = int.Parse(row["J_No_Milepost_Dep_AdStatus"].ToString());
                }



                if (row["J_No_Milepost_createTime"] != null && row["J_No_Milepost_createTime"].ToString() != "")
                {
                    model.J_No_Milepost_createTime = DateTime.Parse(row["J_No_Milepost_createTime"].ToString());
                }
                if (row["J_No_Milepost_isDelete"] != null && row["J_No_Milepost_isDelete"].ToString() != "")
                {
                    if ((row["J_No_Milepost_isDelete"].ToString() == "1") || (row["J_No_Milepost_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.J_No_Milepost_isDelete = true;
                    }
                    else
                    {
                        model.J_No_Milepost_isDelete = false;
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
            strSql.Append("select *");
            strSql.Append(" FROM J_No_Milepost ");
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
            strSql.Append(" J_No_Milepost_id,J_No_Milepost_code,J_No_Milepost_JTime,J_No_Milepost_ZUserinfo_code,J_No_Milepost_DepUserinfo_code,J_No_Milepost_GenerUserinfo_code,J_No_Milepost_CaseNumber,J_No_Milepost_DocumentPo,J_No_Milepost_Filing,J_No_Milepost_Preservation,J_No_Milepost_Auditor,J_No_Milepost_TJMessageType,J_No_Milepost_TJMessageContent,J_No_Milepost_AdMessageType,J_No_Milepost_AdMessageContent,J_No_Milepost_AdStatus,J_No_Milepost_createTime,J_No_Milepost_isDelete ");
            strSql.Append(" FROM J_No_Milepost ");
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
            strSql.Append("select count(1) FROM J_No_Milepost ");
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
                strSql.Append("order by T.J_No_Milepost_id desc");
            }
            strSql.Append(")AS Row, T.*  from J_No_Milepost T ");
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
                    new SqlParameter("tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("PageSize", SqlDbType.Int),
                    new SqlParameter("PageIndex", SqlDbType.Int),
                    new SqlParameter("IsReCount", SqlDbType.Bit),
                    new SqlParameter("OrderType", SqlDbType.Bit),
                    new SqlParameter("strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "J_No_Milepost";
            parameters[1].Value = "J_No_Milepost_id";
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

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(CommonService.Model.Milepost.J_No_Milepost model, string but, Guid? UserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM J_No_Milepost as T");
            strSql.Append(" where 1=1 and J_No_Milepost_isDelete=0 ");
            if (model != null)
            {
                if (model.J_No_Milepost_DocumentPo != null && model.J_No_Milepost_DocumentPo != "")
                {
                    strSql.Append(" and  J_No_Milepost_DocumentPo=@J_No_Milepost_DocumentPo ");
                }
                if (model.J_No_Milepost_CaseNumber != null && model.J_No_Milepost_CaseNumber != "")
                {//案号
                    strSql.Append(" and  J_No_Milepost_CaseNumber like N'%'+@J_No_Milepost_CaseNumber+'%' ");
                }
                if (model.J_No_Milepost_AuditorName != null && model.J_No_Milepost_AuditorName != "")
                {
                    strSql.Append(" and ((select stuff((select ','+convert(varchar(50),C_Userinfo_code) from C_Userinfo t where C_Userinfo_name like '%" + model.J_No_Milepost_AuditorName + "%' and C_Userinfo_isDelete=0 for xml path('')), 1, 1, ''))) like('%'+convert(varchar(50),T.J_No_Milepost_Auditor)+'%') ");
                }
                if (model.J_No_Milepost_ZUserinfo_codeName != null)
                {//被稽查人
                    strSql.Append(" and(");
                    strSql.Append(" exists(select top 1 * from C_Userinfo as U with(nolock) where U.C_Userinfo_code=T.J_No_Milepost_ZUserinfo_code and U.C_Userinfo_name like N'%'+@J_No_Milepost_ZUserinfo_codeName+'%') ");
                    strSql.Append(" or exists(select top 1 * from C_Userinfo as U1 with(nolock) where U1.C_Userinfo_code=T.J_No_Milepost_DepUserinfo_code and U1.C_Userinfo_name like N'%'+@J_No_Milepost_ZUserinfo_codeName+'%') ");
                    strSql.Append(" or exists(select top 1 * from C_Userinfo as U2 with(nolock) where U2.C_Userinfo_code=T.J_No_Milepost_GenerUserinfo_code and U2.C_Userinfo_name like N'%'+@J_No_Milepost_ZUserinfo_codeName+'%')");
                    strSql.Append(")");
                }
                if (model.J_No_Milepost_JTime != null && model.J_No_Milepost_JTime1 != null)
                {//稽查时间
                    strSql.Append(" and J_No_Milepost_JTime between convert(datetime,@J_No_Milepost_JTime,120) and convert(datetime,@J_No_Milepost_JTime1,120)");
                }
                if (model.J_No_Milepost_clientCrival != null)
                {//委托人/对方当事人
                    strSql.Append(" and (");
                    strSql.Append("exists(select top 1 * from B_Case_link as CL with(nolock),B_Case as C with(nolock),C_Customer as CUS with(nolock) where C.B_Case_code=CL.B_Case_code and C.B_Case_number=T.J_No_Milepost_CaseNumber and CL.B_Case_link_type=1 and CL.C_FK_code=CUS.C_Customer_code and CUS.C_Customer_name like N'%'+@J_No_Milepost_clientCrival+'%' )");
                    strSql.Append("or exists(select top 1 * from B_Case_link as CL1 with(nolock),B_Case as C1 with(nolock),C_CRival as CR with(nolock) where C1.B_Case_code=CL1.B_Case_code and C1.B_Case_number=T.J_No_Milepost_CaseNumber and CL1.B_Case_link_type=2 and CL1.C_FK_code=CR.C_CRival_code and CR.C_CRival_name like N'%'+@J_No_Milepost_clientCrival+'%' )");
                    strSql.Append("or exists(select top 1 * from B_Case_link as CL2 with(nolock),B_Case as C2 with(nolock),C_PRival as PR with(nolock) where C2.B_Case_code=CL2.B_Case_code and C2.B_Case_number=T.J_No_Milepost_CaseNumber and CL2.B_Case_link_type=3 and CL2.C_FK_code=PR.C_PRival_code and PR.C_PRival_name like N'%'+@J_No_Milepost_clientCrival+'%' )");
                    strSql.Append(")");
                }
            }
            if (but != "")
                strSql.Append(" and ( '" + but + "' like '%'+convert(varchar(50),J_No_Milepost_Auditor)+'%' or J_No_Milepost_ZUserinfo_code='" + UserCode + "' or J_No_Milepost_DepUserinfo_code='" + UserCode + "' or J_No_Milepost_GenerUserinfo_code='" + UserCode + "') ");
            SqlParameter[] parameters = {
                    new SqlParameter("@J_No_Milepost_DocumentPo", SqlDbType.VarChar,500),
                    new SqlParameter("@J_No_Milepost_CaseNumber", SqlDbType.VarChar,50),
                    new SqlParameter("@J_No_Milepost_ZUserinfo_codeName",SqlDbType.VarChar),
                    new SqlParameter("@J_No_Milepost_JTime",SqlDbType.DateTime),
                    new SqlParameter("@J_No_Milepost_JTime1",SqlDbType.DateTime),
                    new SqlParameter("@J_No_Milepost_clientCrival",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.J_No_Milepost_DocumentPo;
            parameters[1].Value = model.J_No_Milepost_CaseNumber;
            parameters[2].Value = model.J_No_Milepost_ZUserinfo_codeName;
            parameters[3].Value = model.J_No_Milepost_JTime;
            parameters[4].Value = model.J_No_Milepost_JTime1;
            parameters[5].Value = model.J_No_Milepost_clientCrival;

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
        public DataSet GetListByPage(CommonService.Model.Milepost.J_No_Milepost model, string orderby, int startIndex, int endIndex, string but, Guid? UserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *");
            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_No_Milepost_Auditor) as J_No_Milepost_AuditorName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_No_Milepost_ZUserinfo_code) as J_No_Milepost_ZUserinfo_codeName ");

            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_No_Milepost_DepUserinfo_code) as J_No_Milepost_DepUserinfo_codeName ");

            strSql.Append(",(select top 1(select C_Involved_project_name from C_Involved_project where C_Involved_project_code=(select top 1 C_FK_code from B_Case_link where B_Case_link_type=7 and B_Case_code=B_Case.B_Case_code)) from B_Case where B_Case_number=TT.J_No_Milepost_CaseNumber) as ProjectName ");
            strSql.Append(",(select top 1 C_Userinfo_name from C_Userinfo where C_Userinfo_code=TT.J_No_Milepost_GenerUserinfo_code) as J_No_Milepost_GenerUserinfo_codeName ");

            strSql.Append(",(select top 1(select C_Customer_name  from C_Customer where C_Customer_code=B_Case_link.C_FK_code) from B_Case_link where B_Case_code =(select top 1 B_Case_code from B_Case where B_Case_number=TT.J_No_Milepost_CaseNumber) and B_Case_link_type=1) as C_Customer_yg ");


            strSql.Append(",(select stuff((select '+'+(select C_CRival_name  from C_CRival where C_CRival_code=t.C_FK_code) from B_Case_link t where B_Case_code in(select B_Case_code from B_Case where B_Case_number=TT.J_No_Milepost_CaseNumber) and B_Case_link_type=2 for xml path('')), 1, 1, '')) as C_Customer_BG_1 ");
            strSql.Append(",(select stuff((select '+'+(select C_PRival_name  from C_PRival where C_PRival_code=t.C_FK_code) from B_Case_link t where B_Case_code in(select B_Case_code from B_Case where B_Case_number=TT.J_No_Milepost_CaseNumber) and B_Case_link_type=3 for xml path('')), 1, 1, '')) as C_Customer_BG_2 ");

            strSql.Append("FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.J_No_Milepost_id desc");
            }
            strSql.Append(")AS Row, T.*  from J_No_Milepost T ");
            strSql.Append(" where 1=1 and J_No_Milepost_isDelete=0 ");
            if (model != null)
            {
                if (model.J_No_Milepost_DocumentPo != null && model.J_No_Milepost_DocumentPo != "")
                {
                    //特殊判断
                    string sub = "";
                    string[] spl = model.J_No_Milepost_DocumentPo.Split(',');
                    foreach (var item in spl)
                    {
                        if (item == "") continue;
                        sub = sub + " J_No_Milepost_DocumentPo like N'%," + item + ",%' or";

                    }
                    if (sub != "")
                    {
                        sub = sub.Substring(0, sub.Length - 2);
                    }


                    strSql.Append(" and (" + sub + ") ");


                }
                if (model.J_No_Milepost_CaseNumber != null && model.J_No_Milepost_CaseNumber != "")
                {//案号
                    strSql.Append(" and  J_No_Milepost_CaseNumber like N'%'+@J_No_Milepost_CaseNumber+'%' ");
                }
                if (model.J_No_Milepost_AuditorName != null && model.J_No_Milepost_AuditorName != "")
                {//稽查人
                    strSql.Append(" and ((select stuff((select ','+convert(varchar(50),C_Userinfo_code) from C_Userinfo t where C_Userinfo_name like '%" + model.J_No_Milepost_AuditorName + "%' and C_Userinfo_isDelete=0 for xml path('')), 1, 1, ''))) like('%'+convert(varchar(50),T.J_No_Milepost_Auditor)+'%') ");
                }
                if (model.J_No_Milepost_ZUserinfo_codeName != null)
                {//被稽查人
                    strSql.Append(" and(");
                    strSql.Append(" exists(select top 1 * from C_Userinfo as U with(nolock) where U.C_Userinfo_code=T.J_No_Milepost_ZUserinfo_code and U.C_Userinfo_name like N'%'+@J_No_Milepost_ZUserinfo_codeName+'%') ");
                    strSql.Append(" or exists(select top 1 * from C_Userinfo as U1 with(nolock) where U1.C_Userinfo_code=T.J_No_Milepost_DepUserinfo_code and U1.C_Userinfo_name like N'%'+@J_No_Milepost_ZUserinfo_codeName+'%') ");
                    strSql.Append(" or exists(select top 1 * from C_Userinfo as U2 with(nolock) where U2.C_Userinfo_code=T.J_No_Milepost_GenerUserinfo_code and U2.C_Userinfo_name like N'%'+@J_No_Milepost_ZUserinfo_codeName+'%')");
                    strSql.Append(")");
                }
                if (model.J_No_Milepost_JTime != null && model.J_No_Milepost_JTime1 != null)
                {//稽查时间
                    strSql.Append(" and J_No_Milepost_JTime between convert(datetime,@J_No_Milepost_JTime,120) and convert(datetime,@J_No_Milepost_JTime1,120)");
                }
                if (model.J_No_Milepost_clientCrival != null)
                {//委托人/对方当事人
                    strSql.Append(" and (");
                    strSql.Append("exists(select top 1 * from B_Case_link as CL with(nolock),B_Case as C with(nolock),C_Customer as CUS with(nolock) where C.B_Case_code=CL.B_Case_code and C.B_Case_number=T.J_No_Milepost_CaseNumber and CL.B_Case_link_type=1 and CL.C_FK_code=CUS.C_Customer_code and CUS.C_Customer_name like N'%'+@J_No_Milepost_clientCrival+'%' )");
                    strSql.Append("or exists(select top 1 * from B_Case_link as CL1 with(nolock),B_Case as C1 with(nolock),C_CRival as CR with(nolock) where C1.B_Case_code=CL1.B_Case_code and C1.B_Case_number=T.J_No_Milepost_CaseNumber and CL1.B_Case_link_type=2 and CL1.C_FK_code=CR.C_CRival_code and CR.C_CRival_name like N'%'+@J_No_Milepost_clientCrival+'%' )");
                    strSql.Append("or exists(select top 1 * from B_Case_link as CL2 with(nolock),B_Case as C2 with(nolock),C_PRival as PR with(nolock) where C2.B_Case_code=CL2.B_Case_code and C2.B_Case_number=T.J_No_Milepost_CaseNumber and CL2.B_Case_link_type=3 and CL2.C_FK_code=PR.C_PRival_code and PR.C_PRival_name like N'%'+@J_No_Milepost_clientCrival+'%' )");
                    strSql.Append(")");
                }
            }
            if (but != "")
                strSql.Append(" and ( '" + but + "' like '%'+convert(varchar(50),J_No_Milepost_Auditor)+'%' or J_No_Milepost_ZUserinfo_code='" + UserCode + "' or J_No_Milepost_DepUserinfo_code='" + UserCode + "' or J_No_Milepost_GenerUserinfo_code='" + UserCode + "') ");

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
                    new SqlParameter("@J_No_Milepost_DocumentPo", SqlDbType.VarChar,500),
                    new SqlParameter("@J_No_Milepost_CaseNumber", SqlDbType.VarChar,50),
                    new SqlParameter("@J_No_Milepost_ZUserinfo_codeName",SqlDbType.VarChar),
                    new SqlParameter("@J_No_Milepost_JTime",SqlDbType.DateTime),
                    new SqlParameter("@J_No_Milepost_JTime1",SqlDbType.DateTime),
                    new SqlParameter("@J_No_Milepost_clientCrival",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.J_No_Milepost_DocumentPo;
            parameters[1].Value = model.J_No_Milepost_CaseNumber;
            parameters[2].Value = model.J_No_Milepost_ZUserinfo_codeName;
            parameters[3].Value = model.J_No_Milepost_JTime;
            parameters[4].Value = model.J_No_Milepost_JTime1;
            parameters[5].Value = model.J_No_Milepost_clientCrival;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
    }
}

