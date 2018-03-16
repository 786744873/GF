using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.MonitorManager
{
    /// <summary>
    /// 数据访问类:条目变更表
    /// 作者：崔慧栋
    /// 日期：2015/06/12
    /// </summary>
    public partial class M_Entry_Change
    {
        public M_Entry_Change()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("M_Entry_Change_id", "M_Entry_Change");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int M_Entry_Change_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from M_Entry_Change");
            strSql.Append(" where M_Entry_Change_id=@M_Entry_Change_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Change_id", SqlDbType.Int,4)
			};
            parameters[0].Value = M_Entry_Change_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.MonitorManager.M_Entry_Change model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into M_Entry_Change(");
            strSql.Append("M_Entry_Change_code,M_Entry_Statistics_code,M_Entry_Change_proposer,M_Entry_Change_applicationTime,M_Entry_Change_applicationDuration,M_Entry_Change_applicationReason,M_Entry_Change_approvalPerson,M_Entry_Change_approvalTime,M_Entry_Change_approvalDuration,M_Entry_Change_approvalReason,M_Entry_Change_IsThrough,M_Entry_Change_isDelete,M_Entry_Change_creator,M_Entry_Change_createTime,M_Entry_Change_Applicant,M_Entry_Change_Approval)");
            strSql.Append(" values (");
            strSql.Append("@M_Entry_Change_code,@M_Entry_Statistics_code,@M_Entry_Change_proposer,@M_Entry_Change_applicationTime,@M_Entry_Change_applicationDuration,@M_Entry_Change_applicationReason,@M_Entry_Change_approvalPerson,@M_Entry_Change_approvalTime,@M_Entry_Change_approvalDuration,@M_Entry_Change_approvalReason,@M_Entry_Change_IsThrough,@M_Entry_Change_isDelete,@M_Entry_Change_creator,@M_Entry_Change_createTime,@M_Entry_Change_Applicant,@M_Entry_Change_Approval)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Change_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Change_proposer", SqlDbType.VarChar,50),
					new SqlParameter("@M_Entry_Change_applicationTime", SqlDbType.DateTime),
					new SqlParameter("@M_Entry_Change_applicationDuration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_applicationReason", SqlDbType.VarChar,200),
					new SqlParameter("@M_Entry_Change_approvalPerson", SqlDbType.VarChar,50),
					new SqlParameter("@M_Entry_Change_approvalTime", SqlDbType.DateTime),
					new SqlParameter("@M_Entry_Change_approvalDuration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_approvalReason", SqlDbType.VarChar,200),
                    new SqlParameter("@M_Entry_Change_IsThrough",SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_isDelete", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Change_createTime", SqlDbType.DateTime),
                    new SqlParameter("@M_Entry_Change_Applicant",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@M_Entry_Change_Approval",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.M_Entry_Change_code;
            parameters[1].Value = model.M_Entry_Statistics_code;
            parameters[2].Value = model.M_Entry_Change_proposer;
            parameters[3].Value = model.M_Entry_Change_applicationTime;
            parameters[4].Value = model.M_Entry_Change_applicationDuration;
            parameters[5].Value = model.M_Entry_Change_applicationReason;
            parameters[6].Value = model.M_Entry_Change_approvalPerson;
            parameters[7].Value = model.M_Entry_Change_approvalTime;
            parameters[8].Value = model.M_Entry_Change_approvalDuration;
            parameters[9].Value = model.M_Entry_Change_approvalReason;
            parameters[10].Value = model.M_Entry_Change_IsThrough;
            parameters[11].Value = model.M_Entry_Change_isDelete;
            parameters[12].Value = model.M_Entry_Change_creator;
            parameters[13].Value = model.M_Entry_Change_createTime;
            parameters[14].Value = model.M_Entry_Change_Applicant;
            parameters[15].Value = model.M_Entry_Change_Approval;

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
        public bool Update(CommonService.Model.MonitorManager.M_Entry_Change model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Change set ");
            strSql.Append("M_Entry_Change_code=@M_Entry_Change_code,");
            strSql.Append("M_Entry_Statistics_code=@M_Entry_Statistics_code,");
            strSql.Append("M_Entry_Change_proposer=@M_Entry_Change_proposer,");
            strSql.Append("M_Entry_Change_applicationTime=@M_Entry_Change_applicationTime,");
            strSql.Append("M_Entry_Change_applicationDuration=@M_Entry_Change_applicationDuration,");
            strSql.Append("M_Entry_Change_applicationReason=@M_Entry_Change_applicationReason,");
            strSql.Append("M_Entry_Change_approvalPerson=@M_Entry_Change_approvalPerson,");
            strSql.Append("M_Entry_Change_approvalTime=@M_Entry_Change_approvalTime,");
            strSql.Append("M_Entry_Change_approvalDuration=@M_Entry_Change_approvalDuration,");
            strSql.Append("M_Entry_Change_approvalReason=@M_Entry_Change_approvalReason,");
            strSql.Append("M_Entry_Change_IsThrough=@M_Entry_Change_IsThrough,");
            strSql.Append("M_Entry_Change_isDelete=@M_Entry_Change_isDelete,");
            strSql.Append("M_Entry_Change_creator=@M_Entry_Change_creator,");
            strSql.Append("M_Entry_Change_createTime=@M_Entry_Change_createTime,");
            strSql.Append("M_Entry_Change_Applicant=@M_Entry_Change_Applicant,");
            strSql.Append("M_Entry_Change_Approval=@M_Entry_Change_Approval ");
            strSql.Append(" where M_Entry_Change_id=@M_Entry_Change_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Change_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Change_proposer", SqlDbType.VarChar,50),
					new SqlParameter("@M_Entry_Change_applicationTime", SqlDbType.DateTime),
					new SqlParameter("@M_Entry_Change_applicationDuration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_applicationReason", SqlDbType.VarChar,200),
					new SqlParameter("@M_Entry_Change_approvalPerson", SqlDbType.VarChar,50),
					new SqlParameter("@M_Entry_Change_approvalTime", SqlDbType.DateTime),
					new SqlParameter("@M_Entry_Change_approvalDuration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_approvalReason", SqlDbType.VarChar,200),
                    new SqlParameter("@M_Entry_Change_IsThrough",SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_isDelete", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Change_createTime", SqlDbType.DateTime),
					new SqlParameter("@M_Entry_Change_id", SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Change_Applicant",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@M_Entry_Change_Approval",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.M_Entry_Change_code;
            parameters[1].Value = model.M_Entry_Statistics_code;
            parameters[2].Value = model.M_Entry_Change_proposer;
            parameters[3].Value = model.M_Entry_Change_applicationTime;
            parameters[4].Value = model.M_Entry_Change_applicationDuration;
            parameters[5].Value = model.M_Entry_Change_applicationReason;
            parameters[6].Value = model.M_Entry_Change_approvalPerson;
            parameters[7].Value = model.M_Entry_Change_approvalTime;
            parameters[8].Value = model.M_Entry_Change_approvalDuration;
            parameters[9].Value = model.M_Entry_Change_approvalReason;
            parameters[10].Value = model.M_Entry_Change_IsThrough;
            parameters[11].Value = model.M_Entry_Change_isDelete;
            parameters[12].Value = model.M_Entry_Change_creator;
            parameters[13].Value = model.M_Entry_Change_createTime;
            parameters[14].Value = model.M_Entry_Change_id;
            parameters[15].Value = model.M_Entry_Change_Applicant;
            parameters[16].Value = model.M_Entry_Change_Approval;

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
        public bool Delete(int M_Entry_Change_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Change set M_Entry_Change_isDelete =1 ");
            strSql.Append(" where M_Entry_Change_id=@M_Entry_Change_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Change_id", SqlDbType.Int,4)
			};
            parameters[0].Value = M_Entry_Change_id;

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
        public bool DeleteList(string M_Entry_Change_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from M_Entry_Change ");
            strSql.Append(" where M_Entry_Change_id in (" + M_Entry_Change_idlist + ")  ");
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
        public CommonService.Model.MonitorManager.M_Entry_Change GetModel(int M_Entry_Change_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 M_Entry_Change_id,M_Entry_Change_code,M_Entry_Statistics_code,M_Entry_Change_proposer,M_Entry_Change_applicationTime,M_Entry_Change_applicationDuration,M_Entry_Change_applicationReason,M_Entry_Change_approvalPerson,M_Entry_Change_approvalTime,M_Entry_Change_approvalDuration,M_Entry_Change_approvalReason,M_Entry_Change_IsThrough,M_Entry_Change_isDelete,M_Entry_Change_creator,M_Entry_Change_createTime,M_Entry_Change_Applicant,M_Entry_Change_Approval from M_Entry_Change ");
            strSql.Append(" where M_Entry_Change_id=@M_Entry_Change_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Change_id", SqlDbType.Int,4)
			};
            parameters[0].Value = M_Entry_Change_id;

            CommonService.Model.MonitorManager.M_Entry_Change model = new CommonService.Model.MonitorManager.M_Entry_Change();
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
        public CommonService.Model.MonitorManager.M_Entry_Change GetModel(Guid M_Entry_Change_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 M_Entry_Change_id,M_Entry_Change_code,M_Entry_Statistics_code,M_Entry_Change_proposer,M_Entry_Change_applicationTime,M_Entry_Change_applicationDuration,M_Entry_Change_applicationReason,M_Entry_Change_approvalPerson,M_Entry_Change_approvalTime,M_Entry_Change_approvalDuration,M_Entry_Change_approvalReason,M_Entry_Change_IsThrough,M_Entry_Change_isDelete,M_Entry_Change_creator,M_Entry_Change_createTime,M_Entry_Change_Applicant,M_Entry_Change_Approval from M_Entry_Change ");
            strSql.Append(" where M_Entry_Change_code=@M_Entry_Change_code");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Change_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = M_Entry_Change_code;

            CommonService.Model.MonitorManager.M_Entry_Change model = new CommonService.Model.MonitorManager.M_Entry_Change();
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
        public CommonService.Model.MonitorManager.M_Entry_Change DataRowToModel(DataRow row)
        {
            CommonService.Model.MonitorManager.M_Entry_Change model = new CommonService.Model.MonitorManager.M_Entry_Change();
            if (row != null)
            {
                if (row["M_Entry_Change_id"] != null && row["M_Entry_Change_id"].ToString() != "")
                {
                    model.M_Entry_Change_id = int.Parse(row["M_Entry_Change_id"].ToString());
                }
                if (row["M_Entry_Change_code"] != null && row["M_Entry_Change_code"].ToString() != "")
                {
                    model.M_Entry_Change_code = new Guid(row["M_Entry_Change_code"].ToString());
                }
                if (row["M_Entry_Statistics_code"] != null && row["M_Entry_Statistics_code"].ToString() != "")
                {
                    model.M_Entry_Statistics_code = new Guid(row["M_Entry_Statistics_code"].ToString());
                }
                if (row["M_Entry_Change_proposer"] != null)
                {
                    model.M_Entry_Change_proposer = row["M_Entry_Change_proposer"].ToString();
                }
                if (row["M_Entry_Change_applicationTime"] != null && row["M_Entry_Change_applicationTime"].ToString() != "")
                {
                    model.M_Entry_Change_applicationTime = DateTime.Parse(row["M_Entry_Change_applicationTime"].ToString());
                }
                if (row["M_Entry_Change_applicationDuration"] != null && row["M_Entry_Change_applicationDuration"].ToString() != "")
                {
                    model.M_Entry_Change_applicationDuration = int.Parse(row["M_Entry_Change_applicationDuration"].ToString());
                }
                if (row["M_Entry_Change_applicationReason"] != null)
                {
                    model.M_Entry_Change_applicationReason = row["M_Entry_Change_applicationReason"].ToString();
                }
                if (row["M_Entry_Change_approvalPerson"] != null)
                {
                    model.M_Entry_Change_approvalPerson = row["M_Entry_Change_approvalPerson"].ToString();
                }
                if (row["M_Entry_Change_approvalTime"] != null && row["M_Entry_Change_approvalTime"].ToString() != "")
                {
                    model.M_Entry_Change_approvalTime = DateTime.Parse(row["M_Entry_Change_approvalTime"].ToString());
                }
                if (row["M_Entry_Change_approvalDuration"] != null && row["M_Entry_Change_approvalDuration"].ToString() != "")
                {
                    model.M_Entry_Change_approvalDuration = int.Parse(row["M_Entry_Change_approvalDuration"].ToString());
                }
                if (row["M_Entry_Change_approvalReason"] != null)
                {
                    model.M_Entry_Change_approvalReason = row["M_Entry_Change_approvalReason"].ToString();
                }
                if (row.Table.Columns.Contains("M_Entry_Change_IsThrough"))
                {
                    if (row["M_Entry_Change_IsThrough"] != null && row["M_Entry_Change_IsThrough"].ToString() != "")
                    {
                        model.M_Entry_Change_IsThrough = int.Parse(row["M_Entry_Change_IsThrough"].ToString());
                    }
                }
                if (row["M_Entry_Change_isDelete"] != null && row["M_Entry_Change_isDelete"].ToString() != "")
                {
                    model.M_Entry_Change_isDelete = int.Parse(row["M_Entry_Change_isDelete"].ToString());
                }
                if (row["M_Entry_Change_creator"] != null && row["M_Entry_Change_creator"].ToString() != "")
                {
                    model.M_Entry_Change_creator = new Guid(row["M_Entry_Change_creator"].ToString());
                }
                if (row["M_Entry_Change_createTime"] != null && row["M_Entry_Change_createTime"].ToString() != "")
                {
                    model.M_Entry_Change_createTime = DateTime.Parse(row["M_Entry_Change_createTime"].ToString());
                }
                if (row["M_Entry_Change_Applicant"] != null && row["M_Entry_Change_Applicant"].ToString() != "")
                {
                    model.M_Entry_Change_Applicant = new Guid(row["M_Entry_Change_Applicant"].ToString());
                }
                if (row["M_Entry_Change_Approval"] != null && row["M_Entry_Change_Approval"].ToString() != "")
                {
                    model.M_Entry_Change_Approval = new Guid(row["M_Entry_Change_Approval"].ToString());
                }
                //判断案件名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("M_Case_name"))
                {
                    if (row["M_Case_name"] != null && row["M_Case_name"].ToString() != "")
                    {
                        model.M_Case_name = row["M_Case_name"].ToString();
                    }
                }
                //判断案件编码（虚拟字段）是否存在
                if (row.Table.Columns.Contains("M_Case_number"))
                {
                    if (row["M_Case_number"] != null && row["M_Case_number"].ToString() != "")
                    {
                        model.M_Case_number = row["M_Case_number"].ToString();
                    }
                }
                //判断条目名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("M_Entry_name"))
                {
                    if (row["M_Entry_name"] != null && row["M_Entry_name"].ToString() != "")
                    {
                        model.M_Entry_name = row["M_Entry_name"].ToString();
                    }
                }
                //判断案件code（虚拟字段）是否存在
                if (row.Table.Columns.Contains("M_Case_code"))
                {
                    if (row["M_Case_code"] != null && row["M_Case_code"].ToString() != "")
                    {
                        model.M_Case_code = new Guid(row["M_Case_code"].ToString());
                    }
                }
                //变更时长的搜索阶段是否存在
                if (row.Table.Columns.Contains("M_Entry_Change_approvalDuration2"))
                {
                    if (row["M_Entry_Change_approvalDuration2"] != null && row["M_Entry_Change_approvalDuration2"].ToString() != "")
                    {
                        model.M_Entry_Change_approvalDuration2 = int.Parse(row["M_Entry_Change_approvalDuration2"].ToString());
                    }
                }
                //检查条目统计办案状态名称(虚拟属性)是否存在于列表中
                if (row.Table.Columns.Contains("M_Entry_Statistics_HandlingState_name"))
                {
                    if (row["M_Entry_Statistics_HandlingState_name"] != null)
                    {
                        model.M_Entry_Statistics_HandlingState_name = row["M_Entry_Statistics_HandlingState_name"].ToString();
                    }
                }
                //检查条目统计预警情况名称(虚拟属性)是否存在于列表中
                if (row.Table.Columns.Contains("M_Entry_Statistics_warningSituation_name"))
                {
                    if (row["M_Entry_Statistics_warningSituation_name"] != null)
                    {
                        model.M_Entry_Statistics_warningSituation_name = row["M_Entry_Statistics_warningSituation_name"].ToString();
                    }
                }
                //检查条目统计办理情况(虚拟属性)是否存在于列表中
                if (row.Table.Columns.Contains("M_Entry_Statistics_Management"))
                {
                    if (row["M_Entry_Statistics_Management"] != null && row["M_Entry_Statistics_Management"].ToString() != "")
                    {
                        model.M_Entry_Statistics_Management = int.Parse(row["M_Entry_Statistics_Management"].ToString());
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
            strSql.Append("select M_Entry_Change_id,M_Entry_Change_code,M_Entry_Statistics_code,M_Entry_Change_proposer,M_Entry_Change_applicationTime,M_Entry_Change_applicationDuration,M_Entry_Change_applicationReason,M_Entry_Change_approvalPerson,M_Entry_Change_approvalTime,M_Entry_Change_approvalDuration,M_Entry_Change_approvalReason,M_Entry_Change_IsThrough,M_Entry_Change_isDelete,M_Entry_Change_creator,M_Entry_Change_createTime,M_Entry_Change_Applicant,M_Entry_Change_Approval ");
            strSql.Append(" FROM M_Entry_Change ");
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
            strSql.Append(" M_Entry_Change_id,M_Entry_Change_code,M_Entry_Statistics_code,M_Entry_Change_proposer,M_Entry_Change_applicationTime,M_Entry_Change_applicationDuration,M_Entry_Change_applicationReason,M_Entry_Change_approvalPerson,M_Entry_Change_approvalTime,M_Entry_Change_approvalDuration,M_Entry_Change_approvalReason,M_Entry_Change_isDelete,M_Entry_Change_creator,M_Entry_Change_createTime,M_Entry_Change_Applicant,M_Entry_Change_Approval ");
            strSql.Append(" FROM M_Entry_Change ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据案件Guid，获取条目变更记录
        /// </summary>
        /// <param name="pkCode">案件Guid</param>
        /// <returns></returns>        
        public DataSet GetEntryChangeRecordByPkCode(Guid pkCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EC.M_Entry_Change_id,EC.M_Entry_Change_code,EC.M_Entry_Statistics_code,EC.M_Entry_Change_proposer,EC.M_Entry_Change_applicationTime,EC.M_Entry_Change_applicationDuration,");
            strSql.Append("EC.M_Entry_Change_applicationReason,EC.M_Entry_Change_approvalPerson,EC.M_Entry_Change_approvalTime,EC.M_Entry_Change_approvalDuration,EC.M_Entry_Change_approvalReason,EC.M_Entry_Change_IsThrough,");
            strSql.Append("EC.M_Entry_Change_isDelete,EC.M_Entry_Change_creator,EC.M_Entry_Change_createTime,EC.M_Entry_Change_Applicant,EC.M_Entry_Change_Approval,");
            strSql.Append("E.M_Entry_name As M_Entry_name,");
            strSql.Append("HandlingState.C_Parameters_name As M_Entry_Statistics_HandlingState_name,");
            strSql.Append("WarningSituation.C_Parameters_name As M_Entry_Statistics_warningSituation_name,");
            strSql.Append("ES.M_Entry_Statistics_Management ");
            strSql.Append("FROM M_Entry_Statistics As ES with(nolock) ");
            strSql.Append("LEFT JOIN M_Entry_Change As EC with(nolock) on EC.M_Entry_Statistics_code=ES.M_Entry_Statistics_code and EC.M_Entry_Change_isDelete=0 and EC.M_Entry_Change_IsThrough<>328 ");
            strSql.Append("LEFT JOIN M_Entry As E with(nolock) on ES.M_Entry_code=E.M_Entry_code ");
            strSql.Append("LEFT JOIN C_Parameters As HandlingState on ES.M_Entry_Statistics_HandlingState=HandlingState.C_Parameters_id ");
            strSql.Append("LEFT JOIN C_Parameters As WarningSituation on ES.M_Entry_Statistics_warningSituation=WarningSituation.C_Parameters_id ");
            strSql.Append("where ES.M_Case_code=@M_Case_code ");
            strSql.Append("");
            strSql.Append("and ES.M_Entry_Statistics_isDelete=0 ");
            strSql.Append("and ES.M_Entry_Statistics_status=397");

            SqlParameter[] parameters = {
					new SqlParameter("@M_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = pkCode;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return ds;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(CommonService.Model.MonitorManager.M_Entry_Change model, string orderby, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select count(1) from M_Entry_Change T ");
            strSql.Append(" right join M_Entry_Statistics as ES on T.M_Entry_Statistics_code=ES.M_Entry_Statistics_code and ES.M_Entry_Statistics_isDelete=0 ");
            strSql.Append(" right join M_Entry E on ES.M_Entry_code=E.M_Entry_code and E.M_Entry_isDelete=0 ");
            strSql.Append(" right join B_Case as BC on BC.B_Case_code=ES.M_Case_code and BC.B_Case_isDelete=0 ");
            strSql.Append(" where 1=1 and T.M_Entry_Change_isDelete=0 and ES.M_Case_code is not null ");
            if (model != null)
            {
                if (model.M_Entry_Change_code != null && model.M_Entry_Change_code.ToString() != "")
                {
                    strSql.Append(" and T.M_Entry_Change_code=@M_Entry_Change_code ");
                }
                if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
                {
                    strSql.Append(" and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
                }

                //申请人
                if (model.M_Entry_Change_proposer != null && model.M_Entry_Change_proposer != "")
                {
                    strSql.Append(" and T.M_Entry_Change_proposer like  N'%'+@M_Entry_Change_proposer+'%' ");
                }
                //变更时长
                if (model.M_Entry_Change_approvalDuration != null && model.M_Entry_Change_approvalDuration2 != null)
                {
                    strSql.Append(" and T.M_Entry_Change_approvalDuration between @M_Entry_Change_approvalDuration and @M_Entry_Change_approvalDuration2 ");
                }
                //变更审批人
                if (model.M_Entry_Change_approvalPerson != null && model.M_Entry_Change_approvalPerson != "")
                {
                    strSql.Append(" and T.M_Entry_Change_approvalPerson like  N'%'+@M_Entry_Change_approvalPerson+'%' ");
                }
                //变更情况
                if (model.M_Entry_Change_IsThrough != null)
                {
                    strSql.Append(" and T.M_Entry_Change_IsThrough=@M_Entry_Change_IsThrough ");
                }
                if (model.M_Case_name != null)
                {
                    strSql.AppendFormat(" and BC.B_Case_name like N'%'+@M_Case_name+'%' ");
                }
                if (model.M_Case_number != null)
                {
                    strSql.AppendFormat(" and BC.B_Case_number like N'%'+@M_Case_number+'%'");
                }
            }

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=BC.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=BC.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }

                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=BC.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
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
                    strPowerSql.Append("and BCL.B_Case_code=BC.B_Case_code) ");

                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=BC.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=BC.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=BC.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and BC.B_Case_person=CEM.C_Minister_Code) ");
                }
                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                ////协办律师
                //strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                //strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                //strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                ////主办律师
                //strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                //strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                ////案件负责人
                //strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=B.B_Case_code) ");
                ////销售顾问
                //strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                ////业务流程负责人
                //strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion



            #region 老sql
            //strSql.Append("SELECT count(*) FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append("order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append("order by T.M_Entry_Change_id desc");
            //}
            //strSql.Append(")AS Row, T.*,ES.M_Case_name,ES.M_Case_number,ES.M_Case_code,ES.M_Case_type,E.M_Entry_name from M_Entry_Change T ");
            //strSql.Append("left join M_Entry_Statistics as ES on T.M_Entry_Statistics_code=ES.M_Entry_Statistics_code ");
            //strSql.Append("left join M_Entry E on ES.M_Entry_code=E.M_Entry_code ");
            //strSql.Append(" where 1=1 and T.M_Entry_Change_isDelete=0 ");
            //if (model != null)
            //{
            //    if (model.M_Entry_Change_code != null && model.M_Entry_Change_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_Change_code=@M_Entry_Change_code ");
            //    }
            //    if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
            //    }               
            //    //申请人
            //    if (model.M_Entry_Change_proposer != null && model.M_Entry_Change_proposer != "")
            //    {
            //        strSql.Append("and T.M_Entry_Change_proposer like  N'%'+@M_Entry_Change_proposer+'%' ");
            //    }
            //    //变更时长
            //    if (model.M_Entry_Change_approvalDuration != null && model.M_Entry_Change_approvalDuration2 != null )
            //    {
            //        strSql.Append("and T.M_Entry_Change_approvalDuration between @M_Entry_Change_approvalDuration and @M_Entry_Change_approvalDuration2 ");
            //    }         
            //    //变更审批人
            //    if (model.M_Entry_Change_approvalPerson != null && model.M_Entry_Change_approvalPerson != "")
            //    {
            //        strSql.Append("and T.M_Entry_Change_approvalPerson like  N'%'+@M_Entry_Change_approvalPerson+'%' ");
            //    }
            //}
            //strSql.Append(" ) TT");
            //strSql.Append(" left join B_Case as BC");
            //strSql.Append(" on BC.B_Case_number=TT.M_Case_number ");
            //strSql.Append(" where 1=1 ");

            //#region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            //if (!IsPreSetManager)
            //{//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
            //    StringBuilder strPowerSql = new StringBuilder();
            //    strPowerSql.Append(" and (1<>1 ");
            //    if (rolePowerIds.Contains(",1,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=BC.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",2,"))
            //    {
            //        strPowerSql.Append("or BC.B_Case_person=@ThisUserCode ");
            //    }
            //    if (rolePowerIds.Contains(",3,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",4,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",5,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
            //        strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
            //        strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization)");
            //        //strPowerSql.Append("and CU.C_Userinfo_Organization=@ThisDeptCode ");
            //        //strPowerSql.Append("and CU.C_Userinfo_post=@ThisPostCode ");
            //        strPowerSql.Append("and BC.B_Case_consultant_code=CU.C_Userinfo_code) ");
            //    }
            //    if (rolePowerIds.Contains(",6,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=BC.B_Case_code) ");

            //    }
            //    if (rolePowerIds.Contains(",7,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=BC.B_Case_type) ");
            //    }
            //    if (rolePowerIds.Contains(",8,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=BC.B_Case_code ");
            //        strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=BC.B_Case_type) ");
            //    }
            //    #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
            //    //案件负责人
            //    strPowerSql.Append("or BC.B_Case_person=@ThisUserCode ");
            //    //销售顾问
            //    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=BC.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    //业务流程负责人
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    //主办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
            //    //协办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

            //    #endregion

            //    strPowerSql.Append(") ");
            //    strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            //}
            //#endregion

            //if (model.M_Case_name != null)
            //{
            //    strSql.AppendFormat(" and BC.B_Case_name like N'%'+@M_Case_name+'%' ");
            //}
            //if (model.M_Case_number != null)
            //{
            //    strSql.AppendFormat(" and BC.B_Case_number like N'%'+@M_Case_number+'%'");
            //}
            #endregion

            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Change_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
                     new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@M_Case_number", SqlDbType.VarChar,200),
					new SqlParameter("@M_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@M_Entry_Change_proposer", SqlDbType.VarChar,200),
					new SqlParameter("@M_Entry_Change_approvalDuration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_approvalDuration2", SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Change_approvalPerson",SqlDbType.VarChar,200),
                    new SqlParameter("@M_Entry_Change_IsThrough",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.M_Entry_Change_code;
            parameters[1].Value = model.M_Entry_Statistics_code;

            parameters[2].Value = userCode;
            parameters[3].Value = deptCode;
            parameters[4].Value = postCode;
            parameters[5].Value = model.M_Case_number;

            parameters[6].Value = model.M_Case_name;
            parameters[7].Value = model.M_Entry_Change_proposer;
            parameters[8].Value = model.M_Entry_Change_approvalDuration;
            parameters[9].Value = model.M_Entry_Change_approvalDuration2;
            parameters[10].Value = model.M_Entry_Change_approvalPerson;
            parameters[11].Value = model.M_Entry_Change_IsThrough;

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
        public DataSet GetListByPage(CommonService.Model.MonitorManager.M_Entry_Change model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select T.*,ES.M_Case_name,ES.M_Case_number,ES.M_Case_code,ES.M_Case_type,E.M_Entry_name from M_Entry_Change T ");
            strSql.Append(" right join M_Entry_Statistics as ES on T.M_Entry_Statistics_code=ES.M_Entry_Statistics_code and ES.M_Entry_Statistics_isDelete=0 ");
            strSql.Append(" right join M_Entry E on ES.M_Entry_code=E.M_Entry_code and E.M_Entry_isDelete=0 ");
            strSql.Append(" right join B_Case as BC on BC.B_Case_code=ES.M_Case_code and BC.B_Case_isDelete=0 ");
            strSql.Append(" where 1=1 and T.M_Entry_Change_isDelete=0 and ES.M_Case_code is not null ");
            if (model != null)
            {
                if (model.M_Entry_Change_code != null && model.M_Entry_Change_code.ToString() != "")
                {
                    strSql.Append(" and T.M_Entry_Change_code=@M_Entry_Change_code ");
                }
                if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
                {
                    strSql.Append(" and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
                }

                //申请人
                if (model.M_Entry_Change_proposer != null && model.M_Entry_Change_proposer != "")
                {
                    strSql.Append(" and T.M_Entry_Change_proposer like  N'%'+@M_Entry_Change_proposer+'%' ");
                }
                //变更时长
                if (model.M_Entry_Change_approvalDuration != null && model.M_Entry_Change_approvalDuration2 != null)
                {
                    strSql.Append(" and T.M_Entry_Change_approvalDuration between @M_Entry_Change_approvalDuration and @M_Entry_Change_approvalDuration2 ");
                }
                //变更审批人
                if (model.M_Entry_Change_approvalPerson != null && model.M_Entry_Change_approvalPerson != "")
                {
                    strSql.Append(" and T.M_Entry_Change_approvalPerson like  N'%'+@M_Entry_Change_approvalPerson+'%' ");
                }
                //变更情况
                if (model.M_Entry_Change_IsThrough != null)
                {
                    strSql.Append(" and T.M_Entry_Change_IsThrough=@M_Entry_Change_IsThrough ");
                }
                if (model.M_Case_name != null)
                {
                    strSql.AppendFormat(" and BC.B_Case_name like N'%'+@M_Case_name+'%' ");
                }
                if (model.M_Case_number != null)
                {
                    strSql.AppendFormat(" and BC.B_Case_number like N'%'+@M_Case_number+'%'");
                }
            }

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=BC.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=BC.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }

                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=BC.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
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
                    strPowerSql.Append("and BCL.B_Case_code=BC.B_Case_code) ");

                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=BC.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=BC.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=BC.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and BC.B_Case_person=CEM.C_Minister_Code) ");
                }
                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                ////协办律师
                //strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                //strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                //strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                ////主办律师
                //strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                //strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                ////案件负责人
                //strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=B.B_Case_code) ");
                ////销售顾问
                //strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                ////业务流程负责人
                //strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");

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
                strSql.Append(" order by B_Case_id desc");
            }
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);

            #region 老sql
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append("order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append("order by T.M_Entry_Change_id desc");
            //}
            //strSql.Append(")AS Row, T.*,ES.M_Case_name,ES.M_Case_number,ES.M_Case_code,ES.M_Case_type,E.M_Entry_name from M_Entry_Change T ");
            //strSql.Append("left join M_Entry_Statistics as ES on T.M_Entry_Statistics_code=ES.M_Entry_Statistics_code ");
            //strSql.Append("left join M_Entry E on ES.M_Entry_code=E.M_Entry_code ");
            //strSql.Append(" where 1=1 and T.M_Entry_Change_isDelete=0 ");
            //if (model != null)
            //{
            //    if (model.M_Entry_Change_code != null && model.M_Entry_Change_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_Change_code=@M_Entry_Change_code ");
            //    }
            //    if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
            //    }

            //    //申请人
            //    if (model.M_Entry_Change_proposer != null && model.M_Entry_Change_proposer != "")
            //    {
            //        strSql.Append("and T.M_Entry_Change_proposer like  N'%'+@M_Entry_Change_proposer+'%' ");
            //    }
            //    //变更时长
            //    if (model.M_Entry_Change_approvalDuration != null && model.M_Entry_Change_approvalDuration2 != null)
            //    {
            //        strSql.Append("and T.M_Entry_Change_approvalDuration between @M_Entry_Change_approvalDuration and @M_Entry_Change_approvalDuration2 ");
            //    }
            //    //变更审批人
            //    if (model.M_Entry_Change_approvalPerson != null && model.M_Entry_Change_approvalPerson != "")
            //    {
            //        strSql.Append("and T.M_Entry_Change_approvalPerson like  N'%'+@M_Entry_Change_approvalPerson+'%' ");
            //    }
            //}
            //strSql.Append(" ) TT");
            //strSql.Append(" left join B_Case as BC");
            //strSql.Append(" on BC.B_Case_number=TT.M_Case_number ");
            //strSql.Append(" where 1=1 ");

            //#region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            //if (!IsPreSetManager)
            //{//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
            //    StringBuilder strPowerSql = new StringBuilder();
            //    strPowerSql.Append(" and (1<>1 ");
            //    if (rolePowerIds.Contains(",1,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=BC.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",2,"))
            //    {
            //        strPowerSql.Append("or BC.B_Case_person=@ThisUserCode ");
            //    }
            //    if (rolePowerIds.Contains(",3,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",4,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

            //        strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //        strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //        strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
            //    }
            //    if (rolePowerIds.Contains(",5,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
            //        strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
            //        strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization)");
            //        //strPowerSql.Append("and CU.C_Userinfo_Organization=@ThisDeptCode ");
            //        //strPowerSql.Append("and CU.C_Userinfo_post=@ThisPostCode ");
            //        strPowerSql.Append("and BC.B_Case_consultant_code=CU.C_Userinfo_code) ");
            //    }
            //    if (rolePowerIds.Contains(",6,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=BC.B_Case_code) ");

            //    }
            //    if (rolePowerIds.Contains(",7,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=BC.B_Case_type) ");
            //    }
            //    if (rolePowerIds.Contains(",8,"))
            //    {
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=BC.B_Case_code ");
            //        strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
            //        strPowerSql.Append("and CRCT.C_Parameters_id=BC.B_Case_type) ");
            //    }
            //    #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
            //    //案件负责人
            //    strPowerSql.Append("or BC.B_Case_person=@ThisUserCode ");
            //    //销售顾问
            //    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=BC.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
            //    //业务流程负责人
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
            //    //主办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
            //    //协办律师
            //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
            //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=BC.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
            //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");

            //    #endregion

            //    strPowerSql.Append(") ");
            //    strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            //}
            //#endregion

            //if (model.M_Case_name != null)
            //{
            //    strSql.AppendFormat(" and BC.B_Case_name like N'%'+@M_Case_name+'%' ");
            //}
            //if (model.M_Case_number != null)
            //{
            //    strSql.AppendFormat(" and BC.B_Case_number like N'%'+@M_Case_number+'%'");
            //}
            //strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            #endregion

            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Change_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@M_Case_number", SqlDbType.VarChar,200),
					new SqlParameter("@M_Case_name", SqlDbType.VarChar,200),
					new SqlParameter("@M_Entry_Change_proposer", SqlDbType.VarChar,200),
					new SqlParameter("@M_Entry_Change_approvalDuration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Change_approvalDuration2", SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Change_approvalPerson",SqlDbType.VarChar,200),
                    new SqlParameter("@M_Entry_Change_IsThrough",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.M_Entry_Change_code;
            parameters[1].Value = model.M_Entry_Statistics_code;

            parameters[2].Value = userCode;
            parameters[3].Value = deptCode;
            parameters[4].Value = postCode;
            parameters[5].Value = model.M_Case_number;

            parameters[6].Value = model.M_Case_name;
            parameters[7].Value = model.M_Entry_Change_proposer;
            parameters[8].Value = model.M_Entry_Change_approvalDuration;
            parameters[9].Value = model.M_Entry_Change_approvalDuration2;
            parameters[10].Value = model.M_Entry_Change_approvalPerson;
            parameters[11].Value = model.M_Entry_Change_IsThrough;
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
            parameters[0].Value = "M_Entry_Change";
            parameters[1].Value = "M_Entry_Change_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

    }
}

