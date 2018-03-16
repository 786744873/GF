using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.BusinessChanceManager
{
    /// <summary>
    /// 数据访问类:商机表
    /// 作者：崔慧栋
    /// 日期：2015/07/27
    /// </summary>
	public partial class B_BusinessChance
	{
		public B_BusinessChance()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("B_BusinessChance_id", "B_BusinessChance"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int B_BusinessChance_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_BusinessChance");
			strSql.Append(" where B_BusinessChance_id=@B_BusinessChance_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_id", SqlDbType.Int,4)
			};
			parameters[0].Value = B_BusinessChance_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(Model.BusinessChanceManager.B_BusinessChance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_BusinessChance");
            strSql.Append(" where B_BusinessChance_name=@B_BusinessChance_name");
            strSql.Append(" and B_BusinessChance_isDelete=0");
            if(model.B_BusinessChance_id > 0)
            {
                strSql.Append(" and B_BusinessChance_code<>@B_BusinessChance_code");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_name", SqlDbType.NVarChar),
                    new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.B_BusinessChance_name;
            parameters[1].Value = model.B_BusinessChance_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_BusinessChance(");
            strSql.Append("B_BusinessChance_name,B_BusinessChance_number,B_BusinessChance_code,B_BusinessChance_type,B_BusinessChance_Case_nature,B_BusinessChance_customerType,B_BusinessChance_Competitor,B_BusinessChance_registerTime,B_BusinessChance_obtainTime,B_BusinessChance_expectedTarget,B_BusinessChance_successProbability,B_BusinessChance_Outline,B_BusinessChance_remark,B_BusinessChance_state,B_BusinessChance_checkStatus,B_BusinessChance_transferTargetMoney,B_BusinessChance_transferTargetOther,B_BusinessChance_execMoney,B_BusinessChance_execOther,B_BusinessChance_expectedGrant,B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial,B_BusinessChance_Requirement,B_BusinessChance_person,B_BusinessChance_planStartTime,B_BusinessChance_planEndTime,B_BusinessChance_factStartTime,B_BusinessChance_factEndTime,B_BusinessChance_creator,B_BusinessChance_createTime,B_BusinessChance_isDelete,B_BusinessChance_remarks,B_BusinessChance_firstClassResponsiblePerson)");
			strSql.Append(" values (");
            strSql.Append("@B_BusinessChance_name,@B_BusinessChance_number,@B_BusinessChance_code,@B_BusinessChance_type,@B_BusinessChance_Case_nature,@B_BusinessChance_customerType,@B_BusinessChance_Competitor,@B_BusinessChance_registerTime,@B_BusinessChance_obtainTime,@B_BusinessChance_expectedTarget,@B_BusinessChance_successProbability,@B_BusinessChance_Outline,@B_BusinessChance_remark,@B_BusinessChance_state,@B_BusinessChance_checkStatus,@B_BusinessChance_transferTargetMoney,@B_BusinessChance_transferTargetOther,@B_BusinessChance_execMoney,@B_BusinessChance_execOther,@B_BusinessChance_expectedGrant,@B_BusinessChance_courtFirst,@B_BusinessChance_courtSecond,@B_BusinessChance_courtExec,@B_BusinessChance_Trial,@B_BusinessChance_Requirement,@B_BusinessChance_person,@B_BusinessChance_planStartTime,@B_BusinessChance_planEndTime,@B_BusinessChance_factStartTime,@B_BusinessChance_factEndTime,@B_BusinessChance_creator,@B_BusinessChance_createTime,@B_BusinessChance_isDelete,@B_BusinessChance_remarks,@B_BusinessChance_firstClassResponsiblePerson)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_BusinessChance_number", SqlDbType.VarChar,50),
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_type", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_customerType", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_Competitor", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_registerTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_obtainTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_expectedTarget", SqlDbType.Decimal,9),
					new SqlParameter("@B_BusinessChance_successProbability", SqlDbType.VarChar,50),
					new SqlParameter("@B_BusinessChance_Outline", SqlDbType.VarChar,500),
					new SqlParameter("@B_BusinessChance_remark", SqlDbType.VarChar,500),
					new SqlParameter("@B_BusinessChance_state", SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_checkStatus", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_transferTargetMoney", SqlDbType.Decimal,9),
					new SqlParameter("@B_BusinessChance_transferTargetOther", SqlDbType.VarChar,500),
					new SqlParameter("@B_BusinessChance_execMoney", SqlDbType.Decimal,9),
					new SqlParameter("@B_BusinessChance_execOther", SqlDbType.VarChar,500),
					new SqlParameter("@B_BusinessChance_expectedGrant", SqlDbType.Decimal,9),
					new SqlParameter("@B_BusinessChance_courtFirst", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_courtSecond", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_courtExec", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_Trial", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_Requirement", SqlDbType.NVarChar,3000),
					new SqlParameter("@B_BusinessChance_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_planStartTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_planEndTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_factStartTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_factEndTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_remarks",SqlDbType.NVarChar,200),
                    new SqlParameter("@B_BusinessChance_firstClassResponsiblePerson",SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.B_BusinessChance_name;
			parameters[1].Value = model.B_BusinessChance_number;
            parameters[2].Value = model.B_BusinessChance_code;
			parameters[3].Value = model.B_BusinessChance_type;
			parameters[4].Value = model.B_BusinessChance_Case_nature;
			parameters[5].Value = model.B_BusinessChance_customerType;
            parameters[6].Value = model.B_BusinessChance_Competitor;
			parameters[7].Value = model.B_BusinessChance_registerTime;
			parameters[8].Value = model.B_BusinessChance_obtainTime;
			parameters[9].Value = model.B_BusinessChance_expectedTarget;
			parameters[10].Value = model.B_BusinessChance_successProbability;
			parameters[11].Value = model.B_BusinessChance_Outline;
			parameters[12].Value = model.B_BusinessChance_remark;
			parameters[13].Value = model.B_BusinessChance_state;
            parameters[14].Value = model.B_BusinessChance_checkStatus;
			parameters[15].Value = model.B_BusinessChance_transferTargetMoney;
			parameters[16].Value = model.B_BusinessChance_transferTargetOther;
			parameters[17].Value = model.B_BusinessChance_execMoney;
			parameters[18].Value = model.B_BusinessChance_execOther;
			parameters[19].Value = model.B_BusinessChance_expectedGrant;
            parameters[20].Value = model.B_BusinessChance_courtFirst;
            parameters[21].Value = model.B_BusinessChance_courtSecond;
            parameters[22].Value = model.B_BusinessChance_courtExec;
            parameters[23].Value = model.B_BusinessChance_Trial;
			parameters[24].Value = model.B_BusinessChance_Requirement;
            parameters[25].Value = model.B_BusinessChance_person;
			parameters[26].Value = model.B_BusinessChance_planStartTime;
			parameters[27].Value = model.B_BusinessChance_planEndTime;
			parameters[28].Value = model.B_BusinessChance_factStartTime;
			parameters[29].Value = model.B_BusinessChance_factEndTime;
            parameters[30].Value = model.B_BusinessChance_creator;
			parameters[31].Value = model.B_BusinessChance_createTime;
			parameters[32].Value = model.B_BusinessChance_isDelete;
            parameters[33].Value = model.B_BusinessChance_remarks;
            parameters[34].Value = model.B_BusinessChance_firstClassResponsiblePerson;

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
        public bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_BusinessChance set ");
			strSql.Append("B_BusinessChance_name=@B_BusinessChance_name,");
			strSql.Append("B_BusinessChance_number=@B_BusinessChance_number,");
			strSql.Append("B_BusinessChance_code=@B_BusinessChance_code,");
			strSql.Append("B_BusinessChance_type=@B_BusinessChance_type,");
			strSql.Append("B_BusinessChance_Case_nature=@B_BusinessChance_Case_nature,");
			strSql.Append("B_BusinessChance_customerType=@B_BusinessChance_customerType,");
			strSql.Append("B_BusinessChance_Competitor=@B_BusinessChance_Competitor,");
			strSql.Append("B_BusinessChance_registerTime=@B_BusinessChance_registerTime,");
			strSql.Append("B_BusinessChance_obtainTime=@B_BusinessChance_obtainTime,");
			strSql.Append("B_BusinessChance_expectedTarget=@B_BusinessChance_expectedTarget,");
			strSql.Append("B_BusinessChance_successProbability=@B_BusinessChance_successProbability,");
			strSql.Append("B_BusinessChance_Outline=@B_BusinessChance_Outline,");
			strSql.Append("B_BusinessChance_remark=@B_BusinessChance_remark,");
			strSql.Append("B_BusinessChance_state=@B_BusinessChance_state,");
            strSql.Append("B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus,");
			strSql.Append("B_BusinessChance_transferTargetMoney=@B_BusinessChance_transferTargetMoney,");
			strSql.Append("B_BusinessChance_transferTargetOther=@B_BusinessChance_transferTargetOther,");
			strSql.Append("B_BusinessChance_execMoney=@B_BusinessChance_execMoney,");
			strSql.Append("B_BusinessChance_execOther=@B_BusinessChance_execOther,");
			strSql.Append("B_BusinessChance_expectedGrant=@B_BusinessChance_expectedGrant,");
			strSql.Append("B_BusinessChance_courtFirst=@B_BusinessChance_courtFirst,");
			strSql.Append("B_BusinessChance_courtSecond=@B_BusinessChance_courtSecond,");
			strSql.Append("B_BusinessChance_courtExec=@B_BusinessChance_courtExec,");
			strSql.Append("B_BusinessChance_Trial=@B_BusinessChance_Trial,");
			strSql.Append("B_BusinessChance_Requirement=@B_BusinessChance_Requirement,");
			strSql.Append("B_BusinessChance_person=@B_BusinessChance_person,");
			strSql.Append("B_BusinessChance_planStartTime=@B_BusinessChance_planStartTime,");
			strSql.Append("B_BusinessChance_planEndTime=@B_BusinessChance_planEndTime,");
			strSql.Append("B_BusinessChance_factStartTime=@B_BusinessChance_factStartTime,");
			strSql.Append("B_BusinessChance_factEndTime=@B_BusinessChance_factEndTime,");
			strSql.Append("B_BusinessChance_creator=@B_BusinessChance_creator,");
			strSql.Append("B_BusinessChance_createTime=@B_BusinessChance_createTime,");
			strSql.Append("B_BusinessChance_isDelete=@B_BusinessChance_isDelete,");
            strSql.Append("B_BusinessChance_remarks=@B_BusinessChance_remarks,");
            strSql.Append("B_BusinessChance_firstClassResponsiblePerson=@B_BusinessChance_firstClassResponsiblePerson ");
			strSql.Append(" where B_BusinessChance_id=@B_BusinessChance_id");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_BusinessChance_number", SqlDbType.VarChar,50),
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_type", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_Case_nature", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_customerType", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_Competitor", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_registerTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_obtainTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_expectedTarget", SqlDbType.Decimal,9),
					new SqlParameter("@B_BusinessChance_successProbability", SqlDbType.VarChar,50),
					new SqlParameter("@B_BusinessChance_Outline", SqlDbType.VarChar,500),
					new SqlParameter("@B_BusinessChance_remark", SqlDbType.VarChar,500),
					new SqlParameter("@B_BusinessChance_state", SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_checkStatus", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_transferTargetMoney", SqlDbType.Decimal,9),
					new SqlParameter("@B_BusinessChance_transferTargetOther", SqlDbType.VarChar,500),
					new SqlParameter("@B_BusinessChance_execMoney", SqlDbType.Decimal,9),
					new SqlParameter("@B_BusinessChance_execOther", SqlDbType.VarChar,500),
					new SqlParameter("@B_BusinessChance_expectedGrant", SqlDbType.Decimal,9),
					new SqlParameter("@B_BusinessChance_courtFirst", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_courtSecond", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_courtExec", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_Trial", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_Requirement", SqlDbType.NVarChar,3000),
					new SqlParameter("@B_BusinessChance_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_planStartTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_planEndTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_factStartTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_factEndTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_remarks",SqlDbType.NVarChar,200),
                    new SqlParameter("@B_BusinessChance_firstClassResponsiblePerson",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_id", SqlDbType.Int,4)};
			parameters[0].Value = model.B_BusinessChance_name;
			parameters[1].Value = model.B_BusinessChance_number;
			parameters[2].Value = model.B_BusinessChance_code;
			parameters[3].Value = model.B_BusinessChance_type;
            parameters[4].Value = model.B_BusinessChance_Case_nature;
            parameters[5].Value = model.B_BusinessChance_customerType;
            parameters[6].Value = model.B_BusinessChance_Competitor;
            parameters[7].Value = model.B_BusinessChance_registerTime;
            parameters[8].Value = model.B_BusinessChance_obtainTime;
            parameters[9].Value = model.B_BusinessChance_expectedTarget;
            parameters[10].Value = model.B_BusinessChance_successProbability;
            parameters[11].Value = model.B_BusinessChance_Outline;
            parameters[12].Value = model.B_BusinessChance_remark;
            parameters[13].Value = model.B_BusinessChance_state;
            parameters[14].Value = model.B_BusinessChance_checkStatus;
            parameters[15].Value = model.B_BusinessChance_transferTargetMoney;
            parameters[16].Value = model.B_BusinessChance_transferTargetOther;
            parameters[17].Value = model.B_BusinessChance_execMoney;
            parameters[18].Value = model.B_BusinessChance_execOther;
            parameters[19].Value = model.B_BusinessChance_expectedGrant;
            parameters[20].Value = model.B_BusinessChance_courtFirst;
            parameters[21].Value = model.B_BusinessChance_courtSecond;
            parameters[22].Value = model.B_BusinessChance_courtExec;
            parameters[23].Value = model.B_BusinessChance_Trial;
            parameters[24].Value = model.B_BusinessChance_Requirement;
            parameters[25].Value = model.B_BusinessChance_person;
            parameters[26].Value = model.B_BusinessChance_planStartTime;
            parameters[27].Value = model.B_BusinessChance_planEndTime;
            parameters[28].Value = model.B_BusinessChance_factStartTime;
            parameters[29].Value = model.B_BusinessChance_factEndTime;
            parameters[30].Value = model.B_BusinessChance_creator;
            parameters[31].Value = model.B_BusinessChance_createTime;
            parameters[32].Value = model.B_BusinessChance_isDelete;
            parameters[33].Value = model.B_BusinessChance_remarks;
            parameters[34].Value = model.B_BusinessChance_firstClassResponsiblePerson;
			parameters[35].Value = model.B_BusinessChance_id;

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
        /// 改变商机审查状态
        /// </summary>
        /// <param name="businessChangeCode">商机Guid</param>
        /// <param name="checkStatus">审查状态</param>
        /// <returns></returns>
        public bool UpdateCheckStatus(Guid businessChangeCode, int checkStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_BusinessChance set B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus ");
            strSql.Append("where B_BusinessChance_code=@B_BusinessChance_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@B_BusinessChance_checkStatus", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = checkStatus;
            parameters[1].Value = businessChangeCode;

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
        /// 改变商机状态
        /// </summary>
        /// <param name="businessChangeCode">商机Guid</param>
        /// <param name="carryingStatus">进行状态</param>
        /// <param name="checkStatus">审查状态</param>
        /// <returns></returns>
        public bool UpdateStatus(Guid businessChangeCode,int carryingStatus, int checkStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_BusinessChance set B_BusinessChance_state=@B_BusinessChance_state,B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus ");
            strSql.Append("where B_BusinessChance_code=@B_BusinessChance_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@B_BusinessChance_state", SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_checkStatus", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = carryingStatus;
            parameters[1].Value = checkStatus;
            parameters[2].Value = businessChangeCode;

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
		public bool Delete(Guid B_BusinessChance_code)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_BusinessChance set B_BusinessChance_isDelete=1 ");
            strSql.Append(" where B_BusinessChance_code=@B_BusinessChance_code");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_BusinessChance_code;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string B_BusinessChance_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_BusinessChance ");
			strSql.Append(" where B_BusinessChance_id in ("+B_BusinessChance_idlist + ")  ");
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
        public CommonService.Model.BusinessChanceManager.B_BusinessChance GetModelByNumber(string B_BusinessChance_number)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_BusinessChance_id,B_BusinessChance_name,B_BusinessChance_number,B_BusinessChance_code,B_BusinessChance_type,B_BusinessChance_Case_nature,B_BusinessChance_customerType,B_BusinessChance_Competitor,B_BusinessChance_registerTime,B_BusinessChance_obtainTime,B_BusinessChance_expectedTarget,B_BusinessChance_successProbability,B_BusinessChance_Outline,B_BusinessChance_remark,B_BusinessChance_state,B_BusinessChance_checkStatus,B_BusinessChance_transferTargetMoney,B_BusinessChance_transferTargetOther,B_BusinessChance_execMoney,B_BusinessChance_execOther,B_BusinessChance_expectedGrant,B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial,B_BusinessChance_Requirement,B_BusinessChance_person,B_BusinessChance_planStartTime,B_BusinessChance_planEndTime,B_BusinessChance_factStartTime,B_BusinessChance_factEndTime,B_BusinessChance_creator,B_BusinessChance_createTime,B_BusinessChance_isDelete,B_BusinessChance_remarks,B_BusinessChance_firstClassResponsiblePerson from B_BusinessChance ");
            strSql.Append(" where B_BusinessChance_number like N'%'+@B_BusinessChance_number+'%' order by B_BusinessChance_number desc");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_number", SqlDbType.VarChar,50)
			};
            parameters[0].Value = B_BusinessChance_number;

            CommonService.Model.BusinessChanceManager.B_BusinessChance model = new CommonService.Model.BusinessChanceManager.B_BusinessChance();
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
        public CommonService.Model.BusinessChanceManager.B_BusinessChance GetModel(int B_BusinessChance_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_BusinessChance_id,B_BusinessChance_name,B_BusinessChance_number,B_BusinessChance_code,B_BusinessChance_type,B_BusinessChance_Case_nature,B_BusinessChance_customerType,B_BusinessChance_Competitor,B_BusinessChance_registerTime,B_BusinessChance_obtainTime,B_BusinessChance_expectedTarget,B_BusinessChance_successProbability,B_BusinessChance_Outline,B_BusinessChance_remark,B_BusinessChance_state,B_BusinessChance_checkStatus,B_BusinessChance_transferTargetMoney,B_BusinessChance_transferTargetOther,B_BusinessChance_execMoney,B_BusinessChance_execOther,B_BusinessChance_expectedGrant,B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial,B_BusinessChance_Requirement,B_BusinessChance_person,B_BusinessChance_planStartTime,B_BusinessChance_planEndTime,B_BusinessChance_factStartTime,B_BusinessChance_factEndTime,B_BusinessChance_creator,B_BusinessChance_createTime,B_BusinessChance_isDelete,B_BusinessChance_remarks,B_BusinessChance_firstClassResponsiblePerson from B_BusinessChance ");
            strSql.Append(" where B_BusinessChance_id=@B_BusinessChance_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_BusinessChance_id;

            CommonService.Model.BusinessChanceManager.B_BusinessChance model = new CommonService.Model.BusinessChanceManager.B_BusinessChance();
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
        public CommonService.Model.BusinessChanceManager.B_BusinessChance GetModel(Guid B_BusinessChance_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 BC.*,C1.C_Court_name as 'B_BusinessChance_courtFirstName',C2.C_Court_name as 'B_BusinessChance_courtSecondName',C3.C_Court_name as 'B_BusinessChance_courtExecName',P.C_Parameters_name as 'B_BusinessChance_type_name',U.C_Userinfo_name as 'B_Businesschance_personName', ");
            strSql.Append("F.C_Userinfo_name as B_BusinessChance_firstClassResponsiblePerson_name ");
            strSql.Append("from B_BusinessChance as BC left join C_Court as C1 on C1.C_Court_code=BC.B_BusinessChance_courtFirst ");
            strSql.Append("left join C_Court as C2 on C2.C_Court_code=BC.B_BusinessChance_courtSecond ");
            strSql.Append("left join C_Court as C3 on C3.C_Court_code=BC.B_BusinessChance_courtExec ");
            strSql.Append("left join C_Parameters as P on BC.B_BusinessChance_type=P.C_Parameters_id ");
            strSql.Append("left join C_Userinfo as U on BC.B_BusinessChance_person=U.C_Userinfo_code ");
            strSql.Append("left join C_Userinfo as F on BC.B_BusinessChance_firstClassResponsiblePerson=F.C_Userinfo_code ");
            strSql.Append("where BC.B_BusinessChance_code=@B_BusinessChance_code ");
			SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_BusinessChance_code;

            CommonService.Model.BusinessChanceManager.B_BusinessChance model = new CommonService.Model.BusinessChanceManager.B_BusinessChance();
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
        public CommonService.Model.BusinessChanceManager.B_BusinessChance DataRowToModel(DataRow row)
		{
            CommonService.Model.BusinessChanceManager.B_BusinessChance model = new CommonService.Model.BusinessChanceManager.B_BusinessChance();
			if (row != null)
			{
				if(row["B_BusinessChance_id"]!=null && row["B_BusinessChance_id"].ToString()!="")
				{
					model.B_BusinessChance_id=int.Parse(row["B_BusinessChance_id"].ToString());
				}
				if(row["B_BusinessChance_name"]!=null)
				{
					model.B_BusinessChance_name=row["B_BusinessChance_name"].ToString();
				}
				if(row["B_BusinessChance_number"]!=null)
				{
					model.B_BusinessChance_number=row["B_BusinessChance_number"].ToString();
				}
				if(row["B_BusinessChance_code"]!=null && row["B_BusinessChance_code"].ToString()!="")
				{
					model.B_BusinessChance_code= new Guid(row["B_BusinessChance_code"].ToString());
				}
				if(row["B_BusinessChance_type"]!=null && row["B_BusinessChance_type"].ToString()!="")
				{
					model.B_BusinessChance_type=int.Parse(row["B_BusinessChance_type"].ToString());
				}
                //判断类型名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("B_BusinessChance_type_name"))
                {
                    if(row["B_BusinessChance_type_name"]!=null && row["B_BusinessChance_type_name"].ToString()!="")
                    {
                        model.B_BusinessChance_type_name = row["B_BusinessChance_type_name"].ToString();
                    }
                }
				if(row["B_BusinessChance_Case_nature"]!=null && row["B_BusinessChance_Case_nature"].ToString()!="")
				{
					model.B_BusinessChance_Case_nature=int.Parse(row["B_BusinessChance_Case_nature"].ToString());
				}
				if(row["B_BusinessChance_customerType"]!=null && row["B_BusinessChance_customerType"].ToString()!="")
				{
					model.B_BusinessChance_customerType=int.Parse(row["B_BusinessChance_customerType"].ToString());
				}
				if(row["B_BusinessChance_Competitor"]!=null && row["B_BusinessChance_Competitor"].ToString()!="")
				{
					model.B_BusinessChance_Competitor= new Guid(row["B_BusinessChance_Competitor"].ToString());
				}
				if(row["B_BusinessChance_registerTime"]!=null && row["B_BusinessChance_registerTime"].ToString()!="")
				{
					model.B_BusinessChance_registerTime=DateTime.Parse(row["B_BusinessChance_registerTime"].ToString());
				}
				if(row["B_BusinessChance_obtainTime"]!=null && row["B_BusinessChance_obtainTime"].ToString()!="")
				{
					model.B_BusinessChance_obtainTime=DateTime.Parse(row["B_BusinessChance_obtainTime"].ToString());
				}
				if(row["B_BusinessChance_expectedTarget"]!=null && row["B_BusinessChance_expectedTarget"].ToString()!="")
				{
					model.B_BusinessChance_expectedTarget=decimal.Parse(row["B_BusinessChance_expectedTarget"].ToString());
				}
				if(row["B_BusinessChance_successProbability"]!=null)
				{
					model.B_BusinessChance_successProbability=row["B_BusinessChance_successProbability"].ToString();
				}
				if(row["B_BusinessChance_Outline"]!=null)
				{
					model.B_BusinessChance_Outline=row["B_BusinessChance_Outline"].ToString();
				}
				if(row["B_BusinessChance_remark"]!=null)
				{
					model.B_BusinessChance_remark=row["B_BusinessChance_remark"].ToString();
				}
				if(row["B_BusinessChance_state"]!=null && row["B_BusinessChance_state"].ToString()!="")
				{
					model.B_BusinessChance_state=int.Parse(row["B_BusinessChance_state"].ToString());
				}
                if (row["B_BusinessChance_checkStatus"] != null && row["B_BusinessChance_checkStatus"].ToString() != "")
                {
                    model.B_BusinessChance_checkStatus = int.Parse(row["B_BusinessChance_checkStatus"].ToString());
                }
                //检查审查状态（虚拟字段）是否存在
                if (row.Table.Columns.Contains("B_BusinessChance_checkStatus_name"))
                {
                    if (row["B_BusinessChance_checkStatus_name"] != null && row["B_BusinessChance_checkStatus_name"].ToString() != "")
                    {
                        model.B_BusinessChance_checkStatus_name = row["B_BusinessChance_checkStatus_name"].ToString();
                    }
                }
				if(row["B_BusinessChance_transferTargetMoney"]!=null && row["B_BusinessChance_transferTargetMoney"].ToString()!="")
				{
					model.B_BusinessChance_transferTargetMoney=decimal.Parse(row["B_BusinessChance_transferTargetMoney"].ToString());
				}
				if(row["B_BusinessChance_transferTargetOther"]!=null)
				{
					model.B_BusinessChance_transferTargetOther=row["B_BusinessChance_transferTargetOther"].ToString();
				}
				if(row["B_BusinessChance_execMoney"]!=null && row["B_BusinessChance_execMoney"].ToString()!="")
				{
					model.B_BusinessChance_execMoney=decimal.Parse(row["B_BusinessChance_execMoney"].ToString());
				}
				if(row["B_BusinessChance_execOther"]!=null)
				{
					model.B_BusinessChance_execOther=row["B_BusinessChance_execOther"].ToString();
				}
				if(row["B_BusinessChance_expectedGrant"]!=null && row["B_BusinessChance_expectedGrant"].ToString()!="")
				{
					model.B_BusinessChance_expectedGrant=decimal.Parse(row["B_BusinessChance_expectedGrant"].ToString());
				}
				if(row["B_BusinessChance_courtFirst"]!=null && row["B_BusinessChance_courtFirst"].ToString()!="")
				{
					model.B_BusinessChance_courtFirst= new Guid(row["B_BusinessChance_courtFirst"].ToString());
				}
                //判断是否包含该字段
                if (row.Table.Columns.Contains("B_BusinessChance_courtFirstName"))
                {
                    if(row["B_BusinessChance_courtFirstName"]!=null && row["B_BusinessChance_courtFirstName"].ToString()!="")
                    {
                        model.B_BusinessChance_courtFirstName = row["B_BusinessChance_courtFirstName"].ToString();
                    }
                }
				if(row["B_BusinessChance_courtSecond"]!=null && row["B_BusinessChance_courtSecond"].ToString()!="")
				{
					model.B_BusinessChance_courtSecond= new Guid(row["B_BusinessChance_courtSecond"].ToString());
				}
                //判断是否包含该字段
                if (row.Table.Columns.Contains("B_BusinessChance_courtSecondName"))
                {
                    if (row["B_BusinessChance_courtSecondName"] != null && row["B_BusinessChance_courtSecondName"].ToString() != "")
                    {
                        model.B_BusinessChance_courtSecondName = row["B_BusinessChance_courtSecondName"].ToString();
                    }
                }
				if(row["B_BusinessChance_courtExec"]!=null && row["B_BusinessChance_courtExec"].ToString()!="")
				{
					model.B_BusinessChance_courtExec= new Guid(row["B_BusinessChance_courtExec"].ToString());
				}
                //判断是否包含该字段
                if (row.Table.Columns.Contains("B_BusinessChance_courtExecName"))
                {
                    if (row["B_BusinessChance_courtExecName"] != null && row["B_BusinessChance_courtExecName"].ToString() != "")
                    {
                        model.B_BusinessChance_courtExecName = row["B_BusinessChance_courtExecName"].ToString();
                    }
                }
				if(row["B_BusinessChance_Trial"]!=null && row["B_BusinessChance_Trial"].ToString()!="")
				{
					model.B_BusinessChance_Trial= new Guid(row["B_BusinessChance_Trial"].ToString());
				}
				if(row["B_BusinessChance_Requirement"]!=null)
				{
					model.B_BusinessChance_Requirement=row["B_BusinessChance_Requirement"].ToString();
				}
				if(row["B_BusinessChance_person"]!=null && row["B_BusinessChance_person"].ToString()!="")
				{
					model.B_BusinessChance_person= new Guid(row["B_BusinessChance_person"].ToString());
				}
                //商机负责人名称（虚拟字段）
                if (row.Table.Columns.Contains("B_Businesschance_personName"))
                {
                    if (row["B_Businesschance_personName"] != null && row["B_Businesschance_personName"].ToString() != "")
                    {
                        model.B_Businesschance_personName = row["B_Businesschance_personName"].ToString();
                    }
                }
				if(row["B_BusinessChance_planStartTime"]!=null && row["B_BusinessChance_planStartTime"].ToString()!="")
				{
					model.B_BusinessChance_planStartTime=DateTime.Parse(row["B_BusinessChance_planStartTime"].ToString());
				}
				if(row["B_BusinessChance_planEndTime"]!=null && row["B_BusinessChance_planEndTime"].ToString()!="")
				{
					model.B_BusinessChance_planEndTime=DateTime.Parse(row["B_BusinessChance_planEndTime"].ToString());
				}
				if(row["B_BusinessChance_factStartTime"]!=null && row["B_BusinessChance_factStartTime"].ToString()!="")
				{
					model.B_BusinessChance_factStartTime=DateTime.Parse(row["B_BusinessChance_factStartTime"].ToString());
				}
				if(row["B_BusinessChance_factEndTime"]!=null && row["B_BusinessChance_factEndTime"].ToString()!="")
				{
					model.B_BusinessChance_factEndTime=DateTime.Parse(row["B_BusinessChance_factEndTime"].ToString());
				}
				if(row["B_BusinessChance_creator"]!=null && row["B_BusinessChance_creator"].ToString()!="")
				{
					model.B_BusinessChance_creator= new Guid(row["B_BusinessChance_creator"].ToString());
				}
				if(row["B_BusinessChance_createTime"]!=null && row["B_BusinessChance_createTime"].ToString()!="")
				{
					model.B_BusinessChance_createTime=DateTime.Parse(row["B_BusinessChance_createTime"].ToString());
				}
				if(row["B_BusinessChance_isDelete"]!=null && row["B_BusinessChance_isDelete"].ToString()!="")
				{
					model.B_BusinessChance_isDelete=int.Parse(row["B_BusinessChance_isDelete"].ToString());
				}
                if (row["B_BusinessChance_remarks"] != null && row["B_BusinessChance_remarks"].ToString()!="")
                {
                    model.B_BusinessChance_remarks = row["B_BusinessChance_remarks"].ToString();
                }
                //判断专业顾问（虚拟字段）是否存在
                if(row.Table.Columns.Contains("B_BusinessChance_consultant_name"))
                {
                    if(row["B_BusinessChance_consultant_name"]!=null && row["B_BusinessChance_consultant_name"].ToString()!="")
                    {
                        model.B_BusinessChance_consultant_name = row["B_BusinessChance_consultant_name"].ToString();
                    }
                }
                if (row["B_BusinessChance_firstClassResponsiblePerson"] != null && row["B_BusinessChance_firstClassResponsiblePerson"].ToString() != "")
                {
                    model.B_BusinessChance_firstClassResponsiblePerson = new Guid(row["B_BusinessChance_firstClassResponsiblePerson"].ToString());
                }
                //一级负责人名称（虚拟字段）
                if (row.Table.Columns.Contains("B_BusinessChance_firstClassResponsiblePerson_name"))
                {
                    if (row["B_BusinessChance_firstClassResponsiblePerson_name"] != null && row["B_BusinessChance_firstClassResponsiblePerson_name"].ToString() != "")
                    {
                        model.B_BusinessChance_firstClassResponsiblePerson_name = row["B_BusinessChance_firstClassResponsiblePerson_name"].ToString();
                    }
                }
                //所属案件Guid（虚拟字段）
                if (row.Table.Columns.Contains("B_BusinessChance_case_code"))
                {
                    if (row["B_BusinessChance_case_code"] != null && row["B_BusinessChance_case_code"].ToString() != "")
                    {
                        model.B_BusinessChance_case_code = new Guid(row["B_BusinessChance_case_code"].ToString());
                    }
                }
                //所属案件编码（虚拟字段）
                if (row.Table.Columns.Contains("B_BusinessChance_case_number"))
                {
                    if (row["B_BusinessChance_case_number"] != null && row["B_BusinessChance_case_number"].ToString() != "")
                    {
                        model.B_BusinessChance_case_number = row["B_BusinessChance_case_number"].ToString();
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select B_BusinessChance_id,B_BusinessChance_name,B_BusinessChance_number,B_BusinessChance_code,B_BusinessChance_type,B_BusinessChance_Case_nature,B_BusinessChance_customerType,B_BusinessChance_Competitor,B_BusinessChance_registerTime,B_BusinessChance_obtainTime,B_BusinessChance_expectedTarget,B_BusinessChance_successProbability,B_BusinessChance_Outline,B_BusinessChance_remark,B_BusinessChance_state,B_BusinessChance_checkStatus,B_BusinessChance_transferTargetMoney,B_BusinessChance_transferTargetOther,B_BusinessChance_execMoney,B_BusinessChance_execOther,B_BusinessChance_expectedGrant,B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial,B_BusinessChance_Requirement,B_BusinessChance_person,B_BusinessChance_planStartTime,B_BusinessChance_planEndTime,B_BusinessChance_factStartTime,B_BusinessChance_factEndTime,B_BusinessChance_creator,B_BusinessChance_createTime,B_BusinessChance_isDelete,B_BusinessChance_remarks,B_BusinessChance_firstClassResponsiblePerson ");
			strSql.Append(" FROM B_BusinessChance ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByConsultant(Guid consultantCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.*");
            strSql.Append(" FROM B_BusinessChance as T where T.B_BusinessChance_isDelete=0");
            strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=5 and BCL.C_FK_code=@C_FK_code)");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = consultantCode;
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
            strSql.Append(" B_BusinessChance_id,B_BusinessChance_name,B_BusinessChance_number,B_BusinessChance_code,B_BusinessChance_type,B_BusinessChance_Case_nature,B_BusinessChance_customerType,B_BusinessChance_Competitor,B_BusinessChance_registerTime,B_BusinessChance_obtainTime,B_BusinessChance_expectedTarget,B_BusinessChance_successProbability,B_BusinessChance_Outline,B_BusinessChance_remark,B_BusinessChance_state,B_BusinessChance_checkStatus,B_BusinessChance_transferTargetMoney,B_BusinessChance_transferTargetOther,B_BusinessChance_execMoney,B_BusinessChance_execOther,B_BusinessChance_expectedGrant,B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial,B_BusinessChance_Requirement,B_BusinessChance_person,B_BusinessChance_planStartTime,B_BusinessChance_planEndTime,B_BusinessChance_factStartTime,B_BusinessChance_factEndTime,B_BusinessChance_creator,B_BusinessChance_createTime,B_BusinessChance_isDelete,B_BusinessChance_remarks,B_BusinessChance_firstClassResponsiblePerson ");
			strSql.Append(" FROM B_BusinessChance ");
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
		public int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance model)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;

			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT count(*) FROM ( ");
            strSql.Append(" SELECT ");
            if (model.B_BusinessChance_oprationtype == 1)
            {
                strSql.Append(" T.*  from B_BusinessChance T ");
                if (model != null)
                {
                    //办案阶段限制
                    if (!string.IsNullOrEmpty(model.B_BusinessChance_stage))
                    {
                        strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_BusinessChance_stage and p.P_Business_isdelete=0) As F on T.B_BusinessChance_code= F.P_Fk_code ");
                    }
                    //工程
                    if (!string.IsNullOrEmpty(model.B_BusinessChance_Project_code))
                    {
                        strSql.Append("right join (select C_Userinfo_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Userinfo As CP  on CL.C_FK_code = CP.C_Userinfo_code where CL.C_FK_code = @B_BusinessChance_consultant_code and CL.B_BusinessChance_link_type=5) As BBC on T.B_BusinessChance_code=BBC.B_BusinessChance_code ");
                    }
                    //销售/专业顾问
                    if (!string.IsNullOrEmpty(model.B_BusinessChance_consultant_code))
                    {
                        strSql.Append("right join (select * from B_BusinessChance_link As BCL left join C_Involved_project As CI on  BCL.C_FK_code=CI.C_Involved_project_code where BCL.C_FK_code = @B_BusinessChance_consultant_code and BCL.B_BusinessChance_link_type=5) As CBP on T.B_BusinessChance_code=CBP.B_BusinessChance_code ");
                        a = 1;
                    }
                    //客户   委托人
                    if ((!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code)) && (!string.IsNullOrEmpty(model.B_BusinessChance_Client_code)))
                    {
                        strSql.Append("right join (select C_Customer_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_BusinessChance_link_type=0) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");

                        strSql.Append("right join (select C_Customer_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_BusinessChance_link_type=1) As CP2 on T.B_BusinessChance_code=CP2.B_BusinessChance_code ");

                        b = c = d = 1;
                    }
                    if (d != 1)
                    {
                        if ((!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code)) || (!string.IsNullOrEmpty(model.B_BusinessChance_Client_code)))
                        {
                            if (!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code))
                            {
                                strSql.Append("right join (select * from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_BusinessChance_link_type=0) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");
                                b = 1;
                            }
                            else
                            {//委托人
                                strSql.Append("right join (select * from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_BusinessChance_link_type=1) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");
                                c = 1;
                            }

                        }
                    }
                    //对方当事人
                    if (!string.IsNullOrEmpty(model.B_BusinessChance_Person_code))
                    {
                        strSql.Append("left join(select C_PRival_code,B_BusinessChance_code from B_BusinessChance_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_BusinessChance_Person_code and CL.B_BusinessChance_link_type=3) As CIP on CIP.B_BusinessChance_code=T.B_BusinessChance_code ");
                        strSql.Append("left join(select C_CRival_code,B_BusinessChance_code from B_BusinessChance_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_BusinessChance_Person_code and CL.B_BusinessChance_link_type=2) As CRB on CRB.B_BusinessChance_code=T.B_BusinessChance_code ");
                        e = 1;
                    }

                }
                strSql.Append(" where 1=1 and B_BusinessChance_isDelete=0 ");
            }
            else if (model.B_BusinessChance_oprationtype == 2)
            {
                strSql.Append(" T.*  from B_BusinessChance_link CL ");
                strSql.Append("left join B_BusinessChance as T on CL.B_BusinessChance_code=T.B_BusinessChance_code ");
                strSql.Append("where CL.B_BusinessChance_link_isDelete=0 ");
            }
            if (model != null)
            {
                if (model.B_BusinessChance_number != null && model.B_BusinessChance_number.ToString() != "")
                {
                    strSql.Append("and B_BusinessChance_number like N'%'+@B_BusinessChance_number+'%' ");
                }
                //if (model.B_BusinessChance_consultant_code != null && model.B_BusinessChance_consultant_code.ToString() != "")
                //{
                //    strSql.Append("and B_BusinessChance_consultant_code=@B_BusinessChance_consultant_code ");
                //}
                if (model.B_BusinessChance_name != null && model.B_BusinessChance_name.ToString() != "")
                {
                    strSql.Append("and B_BusinessChance_name like N'%'+@B_BusinessChance_name+'%' ");
                }
                if (model.B_BusinessChance_registerTime != null && model.B_BusinessChance_registerTime2 != null)
                {
                    strSql.Append("and B_BusinessChance_registerTime between convert(datetime,@B_BusinessChance_registerTime,120) and convert(datetime,@B_BusinessChance_registerTime2,120)");
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
                if (e == 1)
                {
                    strSql.Append("and (C_PRival_code=@B_BusinessChance_Person_code or C_CRival_code=@B_BusinessChance_Person_code) ");
                }
                if (a == 1)
                {
                    strSql.Append("and C_Involved_project_code=@B_BusinessChance_Project_code ");
                }
                if (model.B_BusinessChance_state != null)
                {
                    strSql.Append("and B_BusinessChance_state=@B_BusinessChance_state ");
                }
                if (model.B_BusinessChance_checkStatus != null)
                {
                    strSql.Append("and B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus ");
                }
                if (!string.IsNullOrEmpty(model.B_BusinessChance_courtFirst.ToString()))
                {
                    strSql.Append("and @B_BusinessChance_courtFirst in (B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial) ");
                }
                if (model.B_BusinessChance_type != null)
                {
                    strSql.Append("and B_BusinessChance_type=@B_BusinessChance_type ");
                }
                if ((!string.IsNullOrEmpty(model.B_BusinessChance_execMoney.ToString())) && !string.IsNullOrEmpty(model.B_BusinessChance_execMoney2.ToString()))
                {
                    strSql.Append("and B_BusinessChance_execMoney between @B_BusinessChance_execMoney and @B_BusinessChance_execMoney2 ");
                }
            }
            strSql.Append(" ) TT");

            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_BusinessChance_number", SqlDbType.VarChar,50),
					new SqlParameter("@B_BusinessChance_consultant_code", SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_stage",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_Project_code",SqlDbType.VarChar),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_Person_code",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_registerTime",SqlDbType.DateTime),
                    new SqlParameter("@B_BusinessChance_registerTime2",SqlDbType.DateTime),
                    new SqlParameter("@B_BusinessChance_state",SqlDbType.Int,4),
                     new SqlParameter("@B_BusinessChance_checkStatus",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_courtFirst",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_type",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_execMoney",SqlDbType.Decimal),
                    new SqlParameter("@B_BusinessChance_execMoney2",SqlDbType.Decimal)};
            parameters[0].Value = model.B_BusinessChance_name;
            parameters[1].Value = model.B_BusinessChance_number;
            parameters[2].Value = model.B_BusinessChance_consultant_code;
            parameters[3].Value = model.B_BusinessChance_stage;
            parameters[4].Value = model.B_BusinessChance_Project_code;
            parameters[5].Value = model.B_BusinessChance_Customer_code;
            parameters[6].Value = model.B_BusinessChance_Client_code;
            parameters[7].Value = model.B_BusinessChance_Person_code;
            parameters[8].Value = model.B_BusinessChance_registerTime;
            parameters[9].Value = model.B_BusinessChance_registerTime2;
            parameters[10].Value = model.B_BusinessChance_state;
            parameters[11].Value = model.B_BusinessChance_checkStatus;
            parameters[12].Value = model.B_BusinessChance_courtFirst;
            parameters[13].Value = model.B_BusinessChance_type;
            parameters[14].Value = model.B_BusinessChance_execMoney;
            parameters[15].Value = model.B_BusinessChance_execMoney2;
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
		public DataSet GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance model, string orderby, int startIndex, int endIndex)
		{
            int a = 0, b = 0, c = 0, d = 0, e = 0;

			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
                strSql.Append("order by T.B_BusinessChance_checkStatus asc");
			}
            if (model.B_BusinessChance_oprationtype == 1)
            {
                strSql.Append(")AS Row, T.*  from B_BusinessChance T ");
                if (model != null)
                {
                    //办案阶段限制
                    if (!string.IsNullOrEmpty(model.B_BusinessChance_stage))
                    {
                        strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_BusinessChance_stage and p.P_Business_isdelete=0) As F on T.B_BusinessChance_code= F.P_Fk_code ");
                    }
                    //工程
                    if (!string.IsNullOrEmpty(model.B_BusinessChance_Project_code))
                    {
                        strSql.Append("right join (select * from B_BusinessChance_link As BCL left join C_Involved_project As CI on  BCL.C_FK_code=CI.C_Involved_project_code where BCL.C_FK_code = @B_BusinessChance_Project_code and BCL.B_BusinessChance_link_type=4) As CBP on T.B_BusinessChance_code=CBP.B_BusinessChance_code ");
                        a = 1;
                    }
                    //销售/专业顾问
                    if (!string.IsNullOrEmpty(model.B_BusinessChance_consultant_code))
                    {
                        strSql.Append("right join (select C_Userinfo_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Userinfo As CP  on CL.C_FK_code = CP.C_Userinfo_code where CL.C_FK_code = @B_BusinessChance_consultant_code and CL.B_BusinessChance_link_type=5) As BBC on T.B_BusinessChance_code=BBC.B_BusinessChance_code ");
                    }
                    //客户   委托人
                    if ((!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code)) && (!string.IsNullOrEmpty(model.B_BusinessChance_Client_code)))
                    {
                        strSql.Append("right join (select C_Customer_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_BusinessChance_link_type=0) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");

                        strSql.Append("right join (select C_Customer_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_BusinessChance_link_type=1) As CP2 on T.B_BusinessChance_code=CP2.B_BusinessChance_code ");

                        b = c = d = 1;
                    }
                    if (d != 1)
                    {
                        if ((!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code)) || (!string.IsNullOrEmpty(model.B_BusinessChance_Client_code)))
                        {
                            if (!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code))
                            {
                                strSql.Append("right join (select * from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_BusinessChance_link_type=0) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");
                                b = 1;
                            }
                            else
                            {//委托人
                                strSql.Append("right join (select * from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_BusinessChance_link_type=1) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");
                                c = 1;
                            }

                        }
                    }
                    //对方当事人
                    if (!string.IsNullOrEmpty(model.B_BusinessChance_Person_code))
                    {
                        strSql.Append("left join(select C_PRival_code,B_BusinessChance_code from B_BusinessChance_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_BusinessChance_Person_code and CL.B_BusinessChance_link_type=3) As CIP on CIP.B_BusinessChance_code=T.B_BusinessChance_code ");
                        strSql.Append("left join(select C_CRival_code,B_BusinessChance_code from B_BusinessChance_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_BusinessChance_Person_code and CL.B_BusinessChance_link_type=2) As CRB on CRB.B_BusinessChance_code=T.B_BusinessChance_code ");
                        e = 1;
                    }

                }
                strSql.Append(" where 1=1 and B_BusinessChance_isDelete=0 ");
            }
            else if (model.B_BusinessChance_oprationtype == 2)
            {
                strSql.Append(")AS Row, T.*  from B_BusinessChance_link CL ");
                strSql.Append("left join B_BusinessChance as T on CL.B_BusinessChance_code=T.B_BusinessChance_code ");
                strSql.Append("where CL.B_BusinessChance_link_isDelete=0 ");
            }
            if (model != null)
            {
                if (model.B_BusinessChance_number != null && model.B_BusinessChance_number.ToString() != "")
                {
                    strSql.Append("and B_BusinessChance_number like N'%'+@B_BusinessChance_number+'%' ");
                }
                //if (model.B_BusinessChance_consultant_code != null && model.B_BusinessChance_consultant_code.ToString() != "")
                //{
                //    strSql.Append("and B_BusinessChance_consultant_code=@B_BusinessChance_consultant_code ");
                //}
                if (model.B_BusinessChance_name != null && model.B_BusinessChance_name.ToString() != "")
                {
                    strSql.Append("and B_BusinessChance_name like N'%'+@B_BusinessChance_name+'%' ");
                }
                if(model.B_BusinessChance_registerTime!=null && model.B_BusinessChance_registerTime2!=null)
                {
                    strSql.Append("and B_BusinessChance_registerTime between convert(datetime,@B_BusinessChance_registerTime,120) and convert(datetime,@B_BusinessChance_registerTime2,120)");
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
                if (e == 1)
                {
                    strSql.Append("and (C_PRival_code=@B_BusinessChance_Person_code or C_CRival_code=@B_BusinessChance_Person_code) ");
                }
                if (a == 1)
                {
                    strSql.Append("and C_Involved_project_code=@B_BusinessChance_Project_code ");
                }
                if(model.B_BusinessChance_state!=null)
                {
                    strSql.Append("and B_BusinessChance_state=@B_BusinessChance_state ");
                }
                if (model.B_BusinessChance_checkStatus != null)
                {
                    strSql.Append("and B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus ");
                }
                if (!string.IsNullOrEmpty(model.B_BusinessChance_courtFirst.ToString()))
                {
                    strSql.Append("and @B_BusinessChance_courtFirst in (B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial) ");
                }
                if(model.B_BusinessChance_type!=null)
                {
                    strSql.Append("and B_BusinessChance_type=@B_BusinessChance_type ");
                }
                if ((!string.IsNullOrEmpty(model.B_BusinessChance_execMoney.ToString())) && !string.IsNullOrEmpty(model.B_BusinessChance_execMoney2.ToString()))
                {
                    strSql.Append("and B_BusinessChance_execMoney between @B_BusinessChance_execMoney and @B_BusinessChance_execMoney2 ");
                }
            }
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_BusinessChance_number", SqlDbType.VarChar,50),
					new SqlParameter("@B_BusinessChance_consultant_code", SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_stage",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_Project_code",SqlDbType.VarChar),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_Person_code",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_registerTime",SqlDbType.DateTime),
                    new SqlParameter("@B_BusinessChance_registerTime2",SqlDbType.DateTime),
                    new SqlParameter("@B_BusinessChance_state",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_checkStatus",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_courtFirst",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_type",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_execMoney",SqlDbType.Decimal),
                    new SqlParameter("@B_BusinessChance_execMoney2",SqlDbType.Decimal)};
            parameters[0].Value = model.B_BusinessChance_name;
            parameters[1].Value = model.B_BusinessChance_number;
            parameters[2].Value = model.B_BusinessChance_consultant_code;
            parameters[3].Value = model.B_BusinessChance_stage;
            parameters[4].Value = model.B_BusinessChance_Project_code;
            parameters[5].Value = model.B_BusinessChance_Customer_code;
            parameters[6].Value = model.B_BusinessChance_Client_code;
            parameters[7].Value = model.B_BusinessChance_Person_code;
            parameters[8].Value = model.B_BusinessChance_registerTime;
            parameters[9].Value = model.B_BusinessChance_registerTime2;
            parameters[10].Value = model.B_BusinessChance_state;
            parameters[11].Value = model.B_BusinessChance_checkStatus;
            parameters[12].Value = model.B_BusinessChance_courtFirst;
            parameters[13].Value = model.B_BusinessChance_type;
            parameters[14].Value = model.B_BusinessChance_execMoney;
            parameters[15].Value = model.B_BusinessChance_execMoney2;
			return DbHelperSQL.Query(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 获取权限记录总数
        /// </summary>
        public int GetPowerRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance model, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            #region 老Sql
            //int a = 0, b = 0, c = 0, d = 0, e = 0;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT count(*) FROM ( ");
            //strSql.Append(" SELECT ");
            //if (model.B_BusinessChance_oprationtype == 1)
            //{
            //    strSql.Append(" T.*  from B_BusinessChance T ");
            //    if (model != null)
            //    {
            //        //办案阶段限制
            //        if (!string.IsNullOrEmpty(model.B_BusinessChance_stage))
            //        {
            //            strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_BusinessChance_stage and p.P_Business_isdelete=0) As F on T.B_BusinessChance_code= F.P_Fk_code ");
            //        }
            //        //销售/专业顾问
            //        if (!string.IsNullOrEmpty(model.B_BusinessChance_consultant_code))
            //        {
            //            strSql.Append("right join (select C_Userinfo_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Userinfo As CP  on CL.C_FK_code = CP.C_Userinfo_code where CL.C_FK_code = @B_BusinessChance_consultant_code and CL.B_BusinessChance_link_type=5) As BBC on T.B_BusinessChance_code=BBC.B_BusinessChance_code ");
            //        }
            //        //工程
            //        if (!string.IsNullOrEmpty(model.B_BusinessChance_Project_code))
            //        {
            //            strSql.Append("right join (select * from B_BusinessChance_link As BCL left join C_Involved_project As CI on  BCL.C_FK_code=CI.C_Involved_project_code where BCL.C_FK_code = @B_BusinessChance_Project_code and BCL.B_BusinessChance_link_type=4) As CBP on T.B_BusinessChance_code=CBP.B_BusinessChance_code ");
            //            a = 1;
            //        }
            //        //客户   委托人
            //        if ((!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code)) && (!string.IsNullOrEmpty(model.B_BusinessChance_Client_code)))
            //        {
            //            strSql.Append("right join (select C_Customer_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_BusinessChance_link_type=0) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");

            //            strSql.Append("right join (select C_Customer_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_BusinessChance_link_type=1) As CP2 on T.B_BusinessChance_code=CP2.B_BusinessChance_code ");

            //            b = c = d = 1;
            //        }
            //        if (d != 1)
            //        {
            //            if ((!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code)) || (!string.IsNullOrEmpty(model.B_BusinessChance_Client_code)))
            //            {
            //                if (!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code))
            //                {
            //                    strSql.Append("right join (select * from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_BusinessChance_link_type=0) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");
            //                    b = 1;
            //                }
            //                else
            //                {//委托人
            //                    strSql.Append("right join (select * from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_BusinessChance_link_type=1) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");
            //                    c = 1;
            //                }

            //            }
            //        }
            //        //对方当事人
            //        if (!string.IsNullOrEmpty(model.B_BusinessChance_Person_code))
            //        {
            //            strSql.Append("left join(select C_PRival_code,B_BusinessChance_code from B_BusinessChance_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_BusinessChance_Person_code and CL.B_BusinessChance_link_type=3) As CIP on CIP.B_BusinessChance_code=T.B_BusinessChance_code ");
            //            strSql.Append("left join(select C_CRival_code,B_BusinessChance_code from B_BusinessChance_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_BusinessChance_Person_code and CL.B_BusinessChance_link_type=2) As CRB on CRB.B_BusinessChance_code=T.B_BusinessChance_code ");
            //            e = 1;
            //        }

            //    }
            //    strSql.Append(" where 1=1 and B_BusinessChance_isDelete=0 ");
            //}
            //else if (model.B_BusinessChance_oprationtype == 2)
            //{
            //    strSql.Append(" T.*  from B_BusinessChance_link CL ");
            //    strSql.Append("left join B_BusinessChance as T on CL.B_BusinessChance_code=T.B_BusinessChance_code ");
            //    strSql.Append("where CL.B_BusinessChance_link_isDelete=0 ");
            //}
            //if (model != null)
            //{
            //    if (model.B_BusinessChance_number != null && model.B_BusinessChance_number.ToString() != "")
            //    {
            //        strSql.Append("and B_BusinessChance_number like N'%'+@B_BusinessChance_number+'%' ");
            //    }
            //    //if (model.B_BusinessChance_consultant_code != null && model.B_BusinessChance_consultant_code.ToString() != "")
            //    //{
            //    //    strSql.Append("and B_BusinessChance_consultant_code=@B_BusinessChance_consultant_code ");
            //    //}
            //    if (model.B_BusinessChance_name != null && model.B_BusinessChance_name.ToString() != "")
            //    {
            //        strSql.Append("and B_BusinessChance_name like N'%'+@B_BusinessChance_name+'%' ");
            //    }
            //    if (model.B_BusinessChance_registerTime != null && model.B_BusinessChance_registerTime2 != null)
            //    {
            //        strSql.Append("and B_BusinessChance_registerTime between convert(datetime,@B_BusinessChance_registerTime,120) and convert(datetime,@B_BusinessChance_registerTime2,120)");
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
            //        if (b == 1 || c == 1)
            //        {
            //            strSql.Append("and C_Customer_code=@C_Customer_code ");
            //        }
            //    }
            //    if (e == 1)
            //    {
            //        strSql.Append("and (C_PRival_code=@B_BusinessChance_Person_code or C_CRival_code=@B_BusinessChance_Person_code) ");
            //    }
            //    if (a == 1)
            //    {
            //        strSql.Append("and C_Involved_project_code=@B_BusinessChance_Project_code ");
            //    }
            //    if (model.B_BusinessChance_state != null)
            //    {
            //        strSql.Append("and B_BusinessChance_state=@B_BusinessChance_state ");
            //    }
            //    if (model.B_BusinessChance_checkStatus != null)
            //    {
            //        strSql.Append("and B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus ");
            //    }
            //    if (!string.IsNullOrEmpty(model.B_BusinessChance_courtFirst.ToString()))
            //    {
            //        strSql.Append("and @B_BusinessChance_courtFirst in (B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial) ");
            //    }
            //    if (model.B_BusinessChance_type != null)
            //    {
            //        strSql.Append("and B_BusinessChance_type=@B_BusinessChance_type ");
            //    }
            //    if ((!string.IsNullOrEmpty(model.B_BusinessChance_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_BusinessChance_execMoney2.ToString()))
            //    {
            //        strSql.Append("and B_BusinessChance_transferTargetMoney between @B_BusinessChance_transferTargetMoney and @B_BusinessChance_execMoney2 ");
            //    }
            //}
            #endregion

            #region 重写Sql，2016/1/26，崔慧栋
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.Append(" from B_BusinessChance as T");
            strSql.Append(" where 1=1 and T.B_BusinessChance_isDelete=0");
            if (model != null)
            {
                //商机名称
                if (model.B_BusinessChance_name != null && model.B_BusinessChance_name.ToString() != "")
                {
                    strSql.Append(" and T.B_BusinessChance_name like N'%'+@B_BusinessChance_name+'%'");
                }
                //商机编码
                if (model.B_BusinessChance_number != null && model.B_BusinessChance_number.ToString() != "")
                {
                    strSql.Append(" and T.B_BusinessChance_number like N'%'+@B_BusinessChance_number+'%'");
                }
                //商机办案阶段
                if (model.B_BusinessChance_stage != null && model.B_BusinessChance_stage.ToString() != "")
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow as PBF where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and PBF.P_Flow_code=@B_BusinessChance_stage)");
                }
                //专业顾问
                if (model.B_BusinessChance_consultant_code != null && model.B_BusinessChance_consultant_code.ToString() != "")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=5 and BCL.C_FK_code=@B_BusinessChance_consultant_code)");
                }
                //涉案项目
                if (model.B_BusinessChance_Project_code != null && model.B_BusinessChance_Project_code.ToString() != "")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=4 and BCL.C_FK_code=@B_BusinessChance_Project_code)");
                }
                //客户
                if (model.B_BusinessChance_Customer_code != null && model.B_BusinessChance_Customer_code.ToString() != "")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=0 and BCL.C_FK_code=@C_Customer_code)");
                }
                //委托人
                if (model.B_BusinessChance_Client_code != null && model.B_BusinessChance_Client_code.ToString() != "")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=1 and BCL.C_FK_code=@C_Client_code)");
                }
                //对方当事人
                if (model.B_BusinessChance_Person_code != null && model.B_BusinessChance_Person_code.ToString() != "")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and (BCL.B_BusinessChance_link_type=2 or BCL.B_BusinessChance_link_type=3) and BCL.C_FK_code=@B_BusinessChance_Person_code)");
                }
                //收案时间
                if (model.B_BusinessChance_registerTime != null && model.B_BusinessChance_registerTime2 != null)
                {
                    strSql.Append(" and T.B_BusinessChance_registerTime between convert(datetime,@B_BusinessChance_registerTime,120) and convert(datetime,@B_BusinessChance_registerTime2,120)");
                }
                //商机状态
                if (model.B_BusinessChance_state != null)
                {
                    strSql.Append(" and B_BusinessChance_state=@B_BusinessChance_state");
                }
                //审查状态
                if (model.B_BusinessChance_checkStatus != null)
                {
                    strSql.Append(" and B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus");
                }
                //法院
                if (!string.IsNullOrEmpty(model.B_BusinessChance_courtFirst.ToString()))
                {
                    strSql.Append(" and @B_BusinessChance_courtFirst in (B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial)");
                }
                //商机类型
                if (model.B_BusinessChance_type != null)
                {
                    strSql.Append(" and B_BusinessChance_type=@B_BusinessChance_type");
                }
                //移交标的金额
                if ((!string.IsNullOrEmpty(model.B_BusinessChance_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_BusinessChance_execMoney2.ToString()))
                {
                    strSql.Append(" and B_BusinessChance_transferTargetMoney between @B_BusinessChance_transferTargetMoney and @B_BusinessChance_execMoney2");
                }
            }
            #endregion

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，崔慧栋，2015-08-12
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_BusinessChance_link As BCL with(nolock) where BCL.B_BusinessChance_link_type=5 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or T.B_BusinessChance_person=@ThisUserCode ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user as OPU where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_BusinessChance_link As BCL with(nolock) where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_link_type=5 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    //strPowerSql.Append("and CU.C_Userinfo_post=@ThisPostCode ");
                    //strPowerSql.Append("and T.B_Case_consultant_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_BusinessChance_link As BCL with(nolock) ");
                    strPowerSql.Append("where ");
                    strPowerSql.Append("exists(select 1 from C_Organization_post_user_region as OPUR where OPUR.C_Organization_post_user_region_isDelete=0 and OPUR.C_region_code=BCL.C_FK_code and OPUR.C_User_code=@ThisUserCode) ");
                    strPowerSql.Append("and BCL.B_BusinessChance_link_type=7 ");
                    strPowerSql.Append("and BCL.B_BusinessChance_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_BusinessChance_code=T.B_BusinessChance_code) ");
                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_BusinessChance_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As OPUR with(nolock),B_BusinessChance_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where OPUR.C_region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and OPUR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_BusinessChance_link_type=7 ");
                    strPowerSql.Append("and BCL.B_BusinessChance_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_BusinessChance_code=T.B_BusinessChance_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and OPUR.C_User_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_BusinessChance_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_BusinessChance_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                //案件负责人
                strPowerSql.Append("or T.B_BusinessChance_person=@ThisUserCode ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_BusinessChance_link As BCL with(nolock) where BCL.B_BusinessChance_link_type=5 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion


            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_BusinessChance_number", SqlDbType.VarChar,50),
					new SqlParameter("@B_BusinessChance_consultant_code", SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_stage",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_Project_code",SqlDbType.VarChar),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_Person_code",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_registerTime",SqlDbType.DateTime),
                    new SqlParameter("@B_BusinessChance_registerTime2",SqlDbType.DateTime),
                    new SqlParameter("@B_BusinessChance_state",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_checkStatus",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_courtFirst",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_type",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_transferTargetMoney",SqlDbType.Decimal),
                    new SqlParameter("@B_BusinessChance_execMoney2",SqlDbType.Decimal),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.B_BusinessChance_name;
            parameters[1].Value = model.B_BusinessChance_number;
            parameters[2].Value = model.B_BusinessChance_consultant_code;
            parameters[3].Value = model.B_BusinessChance_stage;
            parameters[4].Value = model.B_BusinessChance_Project_code;
            parameters[5].Value = model.B_BusinessChance_Customer_code;
            parameters[6].Value = model.B_BusinessChance_Client_code;
            parameters[7].Value = model.B_BusinessChance_Person_code;
            parameters[8].Value = model.B_BusinessChance_registerTime;
            parameters[9].Value = model.B_BusinessChance_registerTime2;
            parameters[10].Value = model.B_BusinessChance_state;
            parameters[11].Value = model.B_BusinessChance_checkStatus;
            parameters[12].Value = model.B_BusinessChance_courtFirst;
            parameters[13].Value = model.B_BusinessChance_type;
            parameters[14].Value = model.B_BusinessChance_transferTargetMoney;
            parameters[15].Value = model.B_BusinessChance_execMoney2;
            parameters[16].Value = userCode;
            parameters[17].Value = deptCode;
            parameters[18].Value = postCode;
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
        /// 分页获取权限数据列表
        /// </summary>
        public DataSet GetPowerListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            #region 老Sql
            //int a = 0, b = 0, c = 0, d = 0, e = 0;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append("order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append("order by T.B_BusinessChance_id desc");
            //}
            //if (model.B_BusinessChance_oprationtype == 1)
            //{
            //    strSql.Append(")AS Row, T.*,checkStatus.C_Parameters_name As B_BusinessChance_checkStatus_name,C.B_Case_code As B_BusinessChance_case_code,C.B_Case_number As B_BusinessChance_case_number ");
            //    strSql.Append("from B_BusinessChance T ");
            //    strSql.Append("left join B_Case as C on T.B_BusinessChance_code=C.B_Case_businessChance_Code ");
            //    strSql.Append("left join C_Parameters As checkStatus on T.B_BusinessChance_checkStatus=checkStatus.C_Parameters_id ");
            //    if (model != null)
            //    {
            //        //办案阶段限制
            //        if (!string.IsNullOrEmpty(model.B_BusinessChance_stage))
            //        {
            //            strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_BusinessChance_stage and p.P_Business_isdelete=0) As F on T.B_BusinessChance_code= F.P_Fk_code ");
            //        }
            //        //销售/专业顾问
            //        if (!string.IsNullOrEmpty(model.B_BusinessChance_consultant_code))
            //        {
            //            strSql.Append("right join (select C_Userinfo_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Userinfo As CP  on CL.C_FK_code = CP.C_Userinfo_code where CL.C_FK_code = @B_BusinessChance_consultant_code and CL.B_BusinessChance_link_type=5) As BBC on T.B_BusinessChance_code=BBC.B_BusinessChance_code ");
            //        }
            //        //工程
            //        if (!string.IsNullOrEmpty(model.B_BusinessChance_Project_code))
            //        {
            //            strSql.Append("right join (select * from B_BusinessChance_link As BCL left join C_Involved_project As CI on  BCL.C_FK_code=CI.C_Involved_project_code where BCL.C_FK_code = @B_BusinessChance_Project_code and BCL.B_BusinessChance_link_type=4) As CBP on T.B_BusinessChance_code=CBP.B_BusinessChance_code ");
            //            a = 1;
            //        }
            //        //客户   委托人
            //        if ((!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code)) && (!string.IsNullOrEmpty(model.B_BusinessChance_Client_code)))
            //        {
            //            strSql.Append("right join (select C_Customer_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_BusinessChance_link_type=0) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");

            //            strSql.Append("right join (select C_Customer_code,B_BusinessChance_code from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_BusinessChance_link_type=1) As CP2 on T.B_BusinessChance_code=CP2.B_BusinessChance_code ");

            //            b = c = d = 1;
            //        }
            //        if (d != 1)
            //        {
            //            if ((!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code)) || (!string.IsNullOrEmpty(model.B_BusinessChance_Client_code)))
            //            {
            //                if (!string.IsNullOrEmpty(model.B_BusinessChance_Customer_code))
            //                {
            //                    strSql.Append("right join (select * from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_BusinessChance_link_type=0) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");
            //                    b = 1;
            //                }
            //                else
            //                {//委托人
            //                    strSql.Append("right join (select * from B_BusinessChance_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_BusinessChance_link_type=1) As CP on T.B_BusinessChance_code=CP.B_BusinessChance_code ");
            //                    c = 1;
            //                }

            //            }
            //        }
            //        //对方当事人
            //        if (!string.IsNullOrEmpty(model.B_BusinessChance_Person_code))
            //        {
            //            strSql.Append("left join(select C_PRival_code,B_BusinessChance_code from B_BusinessChance_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_BusinessChance_Person_code and CL.B_BusinessChance_link_type=3) As CIP on CIP.B_BusinessChance_code=T.B_BusinessChance_code ");
            //            strSql.Append("left join(select C_CRival_code,B_BusinessChance_code from B_BusinessChance_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_BusinessChance_Person_code and CL.B_BusinessChance_link_type=2) As CRB on CRB.B_BusinessChance_code=T.B_BusinessChance_code ");
            //            e = 1;
            //        }

            //    }
            //    strSql.Append(" where 1=1 and B_BusinessChance_isDelete=0 ");
            //}
            //else if (model.B_BusinessChance_oprationtype == 2)
            //{
            //    strSql.Append(")AS Row, T.*  from B_BusinessChance_link CL ");
            //    strSql.Append("left join B_BusinessChance as T on CL.B_BusinessChance_code=T.B_BusinessChance_code ");
            //    strSql.Append("where CL.B_BusinessChance_link_isDelete=0 ");
            //}
            //if (model != null)
            //{
            //    if (model.B_BusinessChance_number != null && model.B_BusinessChance_number.ToString() != "")
            //    {
            //        strSql.Append("and B_BusinessChance_number like N'%'+@B_BusinessChance_number+'%' ");
            //    }
            //    //if (model.B_BusinessChance_consultant_code != null && model.B_BusinessChance_consultant_code.ToString() != "")
            //    //{
            //    //    strSql.Append("and B_BusinessChance_consultant_code=@B_BusinessChance_consultant_code ");
            //    //}
            //    if (model.B_BusinessChance_name != null && model.B_BusinessChance_name.ToString() != "")
            //    {
            //        strSql.Append("and B_BusinessChance_name like N'%'+@B_BusinessChance_name+'%' ");
            //    }
            //    if (model.B_BusinessChance_registerTime != null && model.B_BusinessChance_registerTime2 != null)
            //    {
            //        strSql.Append("and B_BusinessChance_registerTime between convert(datetime,@B_BusinessChance_registerTime,120) and convert(datetime,@B_BusinessChance_registerTime2,120)");
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
            //        if (b == 1 || c == 1)
            //        {
            //            strSql.Append("and C_Customer_code=@C_Customer_code ");
            //        }
            //    }
            //    if (e == 1)
            //    {
            //        strSql.Append("and (C_PRival_code=@B_BusinessChance_Person_code or C_CRival_code=@B_BusinessChance_Person_code) ");
            //    }
            //    if (a == 1)
            //    {
            //        strSql.Append("and C_Involved_project_code=@B_BusinessChance_Project_code ");
            //    }
            //    if (model.B_BusinessChance_state != null)
            //    {
            //        strSql.Append("and B_BusinessChance_state=@B_BusinessChance_state ");
            //    }
            //    if (model.B_BusinessChance_checkStatus != null)
            //    {
            //        strSql.Append("and B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus ");
            //    }
            //    if (!string.IsNullOrEmpty(model.B_BusinessChance_courtFirst.ToString()))
            //    {
            //        strSql.Append("and @B_BusinessChance_courtFirst in (B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial) ");
            //    }
            //    if (model.B_BusinessChance_type != null)
            //    {
            //        strSql.Append("and B_BusinessChance_type=@B_BusinessChance_type ");
            //    }
            //    if ((!string.IsNullOrEmpty(model.B_BusinessChance_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_BusinessChance_execMoney2.ToString()))
            //    {
            //        strSql.Append("and B_BusinessChance_transferTargetMoney between @B_BusinessChance_transferTargetMoney and @B_BusinessChance_execMoney2 ");
            //    }
            //}
            #endregion

            #region 重写Sql，2016/1/26，崔慧栋
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.* ");
            strSql.Append(" from B_BusinessChance as T");
            strSql.Append(" left join B_Case as C on T.B_BusinessChance_code=C.B_Case_businessChance_Code");
            strSql.Append(" left join C_Parameters As checkStatus on T.B_BusinessChance_checkStatus=checkStatus.C_Parameters_id");
            strSql.Append(" where 1=1 and T.B_BusinessChance_isDelete=0");
            if (model != null)
            {
                //商机名称
                if(model.B_BusinessChance_name!=null && model.B_BusinessChance_name.ToString() != "")
                {
                    strSql.Append(" and T.B_BusinessChance_name like N'%'+@B_BusinessChance_name+'%'");
                }
                //商机编码
                if(model.B_BusinessChance_number!=null && model.B_BusinessChance_number.ToString()!="")
                {
                    strSql.Append(" and T.B_BusinessChance_number like N'%'+@B_BusinessChance_number+'%'");
                }
                //商机办案阶段
                if(model.B_BusinessChance_stage!=null && model.B_BusinessChance_stage.ToString()!="")
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow as PBF where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and PBF.P_Flow_code=@B_BusinessChance_stage)");
                }
                //专业顾问
                if(model.B_BusinessChance_consultant_code!=null && model.B_BusinessChance_consultant_code.ToString()!="")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=5 and BCL.C_FK_code=@B_BusinessChance_consultant_code)");
                }
                //涉案项目
                if(model.B_BusinessChance_Project_code!=null && model.B_BusinessChance_Project_code.ToString()!="")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=4 and BCL.C_FK_code=@B_BusinessChance_Project_code)");
                }
                //客户
                if(model.B_BusinessChance_Customer_code!=null && model.B_BusinessChance_Customer_code.ToString()!="")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=0 and BCL.C_FK_code=@C_Customer_code)");
                }
                //委托人
                if(model.B_BusinessChance_Client_code!=null && model.B_BusinessChance_Client_code.ToString()!="")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_type=1 and BCL.C_FK_code=@C_Client_code)");
                }
                //对方当事人
                if(model.B_BusinessChance_Person_code!=null && model.B_BusinessChance_Person_code.ToString()!="")
                {
                    strSql.Append(" and exists(select 1 from B_BusinessChance_link as BCL where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and (BCL.B_BusinessChance_link_type=2 or BCL.B_BusinessChance_link_type=3) and BCL.C_FK_code=@B_BusinessChance_Person_code)");
                }
                //收案时间
                if(model.B_BusinessChance_registerTime!=null && model.B_BusinessChance_registerTime2!=null)
                {
                    strSql.Append(" and T.B_BusinessChance_registerTime between convert(datetime,@B_BusinessChance_registerTime,120) and convert(datetime,@B_BusinessChance_registerTime2,120)");
                }
                //商机状态
                if(model.B_BusinessChance_state!=null)
                {
                    strSql.Append(" and B_BusinessChance_state=@B_BusinessChance_state");
                }
                //审查状态
                if (model.B_BusinessChance_checkStatus != null)
                {
                    strSql.Append(" and B_BusinessChance_checkStatus=@B_BusinessChance_checkStatus");
                }
                //法院
                if (!string.IsNullOrEmpty(model.B_BusinessChance_courtFirst.ToString()))
                {
                    strSql.Append(" and @B_BusinessChance_courtFirst in (B_BusinessChance_courtFirst,B_BusinessChance_courtSecond,B_BusinessChance_courtExec,B_BusinessChance_Trial)");
                }
                //商机类型
                if (model.B_BusinessChance_type != null)
                {
                    strSql.Append(" and B_BusinessChance_type=@B_BusinessChance_type");
                }
                //移交标的金额
                if ((!string.IsNullOrEmpty(model.B_BusinessChance_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(model.B_BusinessChance_execMoney2.ToString()))
                {
                    strSql.Append(" and B_BusinessChance_transferTargetMoney between @B_BusinessChance_transferTargetMoney and @B_BusinessChance_execMoney2");
                }
            }
            #endregion

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，崔慧栋，2015-08-12
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_BusinessChance_link As BCL with(nolock) where BCL.B_BusinessChance_link_type=5 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or T.B_BusinessChance_person=@ThisUserCode ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user as OPU where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_BusinessChance_link As BCL with(nolock) where BCL.B_BusinessChance_link_isDelete=0 and BCL.B_BusinessChance_link_type=5 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    //strPowerSql.Append("and CU.C_Userinfo_post=@ThisPostCode ");
                    //strPowerSql.Append("and T.B_Case_consultant_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_BusinessChance_link As BCL with(nolock) ");
                    strPowerSql.Append("where ");
                    strPowerSql.Append("exists(select 1 from C_Organization_post_user_region as OPUR where OPUR.C_Organization_post_user_region_isDelete=0 and OPUR.C_region_code=BCL.C_FK_code and OPUR.C_User_code=@ThisUserCode) ");
                    strPowerSql.Append("and BCL.B_BusinessChance_link_type=7 ");
                    strPowerSql.Append("and BCL.B_BusinessChance_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_BusinessChance_code=T.B_BusinessChance_code) ");
                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_BusinessChance_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region As OPUR with(nolock),B_BusinessChance_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where OPUR.C_region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and OPUR.C_User_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_BusinessChance_link_type=7 ");
                    strPowerSql.Append("and BCL.B_BusinessChance_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_BusinessChance_code=T.B_BusinessChance_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and OPUR.C_User_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=T.B_BusinessChance_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and T.B_BusinessChance_person=CEM.C_Minister_Code) ");
                }

                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                //案件负责人
                strPowerSql.Append("or T.B_BusinessChance_person=@ThisUserCode ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_BusinessChance_link As BCL with(nolock) where BCL.B_BusinessChance_link_type=5 and BCL.B_BusinessChance_code=T.B_BusinessChance_code and BCL.B_BusinessChance_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and PBF.P_Business_person=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=T.B_BusinessChance_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            if (!string.IsNullOrEmpty(orderby))
            {
                strSql.Append(" order by " + orderby);
            }
            else
            {
                strSql.Append(" order by B_BusinessChance_id desc");
            }
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);

            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_name", SqlDbType.VarChar,200),
					new SqlParameter("@B_BusinessChance_number", SqlDbType.VarChar,50),
					new SqlParameter("@B_BusinessChance_consultant_code", SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_stage",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_Project_code",SqlDbType.VarChar),
                    new SqlParameter("@C_Customer_code",SqlDbType.VarChar),
                    new SqlParameter("@C_Client_code",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_Person_code",SqlDbType.VarChar),
                    new SqlParameter("@B_BusinessChance_registerTime",SqlDbType.DateTime),
                    new SqlParameter("@B_BusinessChance_registerTime2",SqlDbType.DateTime),
                    new SqlParameter("@B_BusinessChance_state",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_checkStatus",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_courtFirst",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_type",SqlDbType.Int,4),
                    new SqlParameter("@B_BusinessChance_transferTargetMoney",SqlDbType.Decimal),
                    new SqlParameter("@B_BusinessChance_execMoney2",SqlDbType.Decimal),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.B_BusinessChance_name;
            parameters[1].Value = model.B_BusinessChance_number;
            parameters[2].Value = model.B_BusinessChance_consultant_code;
            parameters[3].Value = model.B_BusinessChance_stage;
            parameters[4].Value = model.B_BusinessChance_Project_code;
            parameters[5].Value = model.B_BusinessChance_Customer_code;
            parameters[6].Value = model.B_BusinessChance_Client_code;
            parameters[7].Value = model.B_BusinessChance_Person_code;
            parameters[8].Value = model.B_BusinessChance_registerTime;
            parameters[9].Value = model.B_BusinessChance_registerTime2;
            parameters[10].Value = model.B_BusinessChance_state;
            parameters[11].Value = model.B_BusinessChance_checkStatus;
            parameters[12].Value = model.B_BusinessChance_courtFirst;
            parameters[13].Value = model.B_BusinessChance_type;
            parameters[14].Value = model.B_BusinessChance_transferTargetMoney;
            parameters[15].Value = model.B_BusinessChance_execMoney2;
            parameters[16].Value = userCode;
            parameters[17].Value = deptCode;
            parameters[18].Value = postCode;
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
			parameters[0].Value = "B_BusinessChance";
			parameters[1].Value = "B_BusinessChance_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 根据客户的code获得此客户相关的商机的列表
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public DataSet GetBusinessChanceListByCustomer(Guid customerCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from B_BusinessChance as a ");
            strSql.Append("where exists(select 1 from B_BusinessChance_link as b where b.B_BusinessChance_code=a.B_BusinessChance_code and b.B_BusinessChance_link_type=0 and b.C_FK_code=@customerCode and b.B_BusinessChance_link_isDelete=0) ");
            strSql.Append("and a.B_BusinessChance_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@customerCode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = customerCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

