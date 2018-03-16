using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.MonitorManager
{
    /// <summary>
    /// 数据访问类:条目统计表
    /// 作者：崔慧栋
    /// 日期：2015/06/11
    /// </summary>
    public partial class M_Entry_Statistics
    {
        public M_Entry_Statistics()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("M_Entry_Statistics_id", "M_Entry_Statistics");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int M_Entry_Statistics_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from M_Entry_Statistics");
            strSql.Append(" where M_Entry_Statistics_id=@M_Entry_Statistics_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_id", SqlDbType.Int,4)
			};
            parameters[0].Value = M_Entry_Statistics_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据案件Guid，检查是否有延期条目统计信息
        /// </summary>
        /// <param name="pkCode">案件guid</param>
        /// <returns></returns>
        public bool ExistsDelayByPkCode(Guid pkCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from M_Entry_Statistics with(nolock) ");
            strSql.Append("where M_Case_code=@M_Case_code and M_Entry_Statistics_status=397 and M_Entry_Statistics_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Case_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = pkCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.MonitorManager.M_Entry_Statistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into M_Entry_Statistics(");
            strSql.Append("M_Entry_Statistics_code,M_Case_code,M_Case_name,M_Case_type,M_Case_number,M_Entry_code,M_Entry_Statistics_changeDuration,M_Entry_Statistics_entrySTime,M_Entry_Statistics_entryETime,M_Entry_Statistics_status,M_Entry_Statistics_isDelete,M_Entry_Statistics_creator,M_Entry_Statistics_createTime,M_Entry_Statistics_warningSituation,M_Entry_Statistics_HandlingState,M_Entry_Statistics_Management)");
            strSql.Append(" values (");
            strSql.Append("@M_Entry_Statistics_code,@M_Case_code,@M_Case_name,@M_Case_type,@M_Case_number,@M_Entry_code,@M_Entry_Statistics_changeDuration,@M_Entry_Statistics_entrySTime,@M_Entry_Statistics_entryETime,@M_Entry_Statistics_status,@M_Entry_Statistics_isDelete,@M_Entry_Statistics_creator,@M_Entry_Statistics_createTime,@M_Entry_Statistics_warningSituation,@M_Entry_Statistics_HandlingState,@M_Entry_Statistics_Management)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Case_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@M_Case_type",SqlDbType.Int,4),
                    new SqlParameter("@M_Case_number",SqlDbType.NVarChar,50),
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_changeDuration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_entrySTime", SqlDbType.DateTime),
					new SqlParameter("@M_Entry_Statistics_entryETime", SqlDbType.DateTime),
                    new SqlParameter("@M_Entry_Statistics_status", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_isDelete", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_createTime", SqlDbType.DateTime),
                    new SqlParameter("@M_Entry_Statistics_warningSituation",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_HandlingState",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management",SqlDbType.Int,4)};
            parameters[0].Value = model.M_Entry_Statistics_code;
            parameters[1].Value = model.M_Case_code;
            parameters[2].Value = model.M_Case_name;
            parameters[3].Value = model.M_Case_type;
            parameters[4].Value = model.M_Case_number;
            parameters[5].Value = model.M_Entry_code;
            parameters[6].Value = model.M_Entry_Statistics_changeDuration;
            parameters[7].Value = model.M_Entry_Statistics_entrySTime;
            parameters[8].Value = model.M_Entry_Statistics_entryETime;
            parameters[9].Value = model.M_Entry_Statistics_status;
            parameters[10].Value = model.M_Entry_Statistics_isDelete;
            parameters[11].Value = model.M_Entry_Statistics_creator;
            parameters[12].Value = model.M_Entry_Statistics_createTime;
            parameters[13].Value = model.M_Entry_Statistics_warningSituation;
            parameters[14].Value = model.M_Entry_Statistics_HandlingState;
            parameters[15].Value = model.M_Entry_Statistics_Management;

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
        public bool Update(CommonService.Model.MonitorManager.M_Entry_Statistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Statistics set ");
            strSql.Append("M_Entry_Statistics_code=@M_Entry_Statistics_code,");
            strSql.Append("M_Case_code=@M_Case_code,");
            strSql.Append("M_Case_name=@M_Case_name,");
            strSql.Append("M_Case_type=@M_Case_type,");
            strSql.Append("M_Case_number=@M_Case_number,");
            strSql.Append("M_Entry_code=@M_Entry_code,");
            strSql.Append("M_Entry_Statistics_changeDuration=@M_Entry_Statistics_changeDuration,");
            strSql.Append("M_Entry_Statistics_entrySTime=@M_Entry_Statistics_entrySTime,");
            strSql.Append("M_Entry_Statistics_entryETime=@M_Entry_Statistics_entryETime,");
            strSql.Append("M_Entry_Statistics_status=@M_Entry_Statistics_status,");
            strSql.Append("M_Entry_Statistics_isDelete=@M_Entry_Statistics_isDelete,");
            strSql.Append("M_Entry_Statistics_creator=@M_Entry_Statistics_creator,");
            strSql.Append("M_Entry_Statistics_createTime=@M_Entry_Statistics_createTime,");
            strSql.Append("M_Entry_Statistics_warningSituation=@M_Entry_Statistics_warningSituation,");
            strSql.Append("M_Entry_Statistics_HandlingState=@M_Entry_Statistics_HandlingState,");
            strSql.Append("M_Entry_Statistics_Management=@M_Entry_Statistics_Management");
            strSql.Append(" where M_Entry_Statistics_id=@M_Entry_Statistics_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Case_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@M_Case_type",SqlDbType.Int,4),
                    new SqlParameter("@M_Case_number",SqlDbType.NVarChar,50),
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_changeDuration", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_entrySTime", SqlDbType.DateTime),
					new SqlParameter("@M_Entry_Statistics_entryETime", SqlDbType.DateTime),
                    new SqlParameter("@M_Entry_Statistics_status", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_isDelete", SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_createTime", SqlDbType.DateTime),
                    new SqlParameter("@M_Entry_Statistics_warningSituation",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_HandlingState",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management",SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_id", SqlDbType.Int,4)};
            parameters[0].Value = model.M_Entry_Statistics_code;
            parameters[1].Value = model.M_Case_code;
            parameters[2].Value = model.M_Case_name;
            parameters[3].Value = model.M_Case_type;
            parameters[4].Value = model.M_Case_number;
            parameters[5].Value = model.M_Entry_code;
            parameters[6].Value = model.M_Entry_Statistics_changeDuration;
            parameters[7].Value = model.M_Entry_Statistics_entrySTime;
            parameters[8].Value = model.M_Entry_Statistics_entryETime;
            parameters[9].Value = model.M_Entry_Statistics_status;
            parameters[10].Value = model.M_Entry_Statistics_isDelete;
            parameters[11].Value = model.M_Entry_Statistics_creator;
            parameters[12].Value = model.M_Entry_Statistics_createTime;
            parameters[13].Value = model.M_Entry_Statistics_warningSituation;
            parameters[14].Value = model.M_Entry_Statistics_HandlingState;
            parameters[15].Value = model.M_Entry_Statistics_Management;
            parameters[16].Value = model.M_Entry_Statistics_id;

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
        /// 更新变更时长
        /// </summary>
        public bool UpdateChangeDuration(Guid M_Entry_Statistics_code, int M_Entry_Statistics_changeDuration)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Statistics set ");
            strSql.Append("M_Entry_Statistics_changeDuration=M_Entry_Statistics_changeDuration+@M_Entry_Statistics_changeDuration ");
            strSql.Append(" where M_Entry_Statistics_code=@M_Entry_Statistics_code");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_Statistics_changeDuration", SqlDbType.Int)};
            parameters[0].Value = M_Entry_Statistics_code;
            parameters[1].Value = M_Entry_Statistics_changeDuration;

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
        /// 修改预警情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByWarningSituation(CommonService.Model.MonitorManager.M_Entry_Statistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Statistics set ");
            strSql.Append("M_Entry_Statistics_warningSituation=@M_Entry_Statistics_warningSituation ");
            strSql.Append(" where M_Entry_Statistics_id=@M_Entry_Statistics_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@M_Entry_Statistics_warningSituation",SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_id", SqlDbType.Int,4)};
            parameters[0].Value = model.M_Entry_Statistics_warningSituation;
            parameters[1].Value = model.M_Entry_Statistics_id;

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
        /// 修改预警情况(将值为空的修改为非预警)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWarningSituation()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Statistics set ");
            strSql.Append("M_Entry_Statistics_warningSituation=465 ");
            strSql.Append(" where M_Entry_Statistics_warningSituation is null ");

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
        /// 修改办案状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByHandlingState(CommonService.Model.MonitorManager.M_Entry_Statistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Statistics set ");
            strSql.Append("M_Entry_Statistics_HandlingState=@M_Entry_Statistics_HandlingState,");
            strSql.Append("M_Entry_Statistics_Management=@M_Entry_Statistics_Management ");
            strSql.Append(" where M_Entry_Statistics_id=@M_Entry_Statistics_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@M_Entry_Statistics_HandlingState",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management",SqlDbType.Int,4),
					new SqlParameter("@M_Entry_Statistics_id", SqlDbType.Int,4)};
            parameters[0].Value = model.M_Entry_Statistics_HandlingState;
            parameters[1].Value = model.M_Entry_Statistics_Management;
            parameters[2].Value = model.M_Entry_Statistics_id;

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
        /// 修改预警情况(手工结束)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHandlingState(Guid M_Entry_Statistics_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Statistics set ");
            strSql.Append("M_Entry_Statistics_warningSituation=466 ");
            strSql.Append(" where M_Entry_Statistics_code=@M_Entry_Statistics_code");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = M_Entry_Statistics_code;

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
        public bool Delete(int M_Entry_Statistics_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update M_Entry_Statistics set M_Entry_Statistics_isDelete =1 ");
            strSql.Append(" where M_Entry_Statistics_id=@M_Entry_Statistics_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_id", SqlDbType.Int,4)
			};
            parameters[0].Value = M_Entry_Statistics_id;

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
        public bool DeleteList(string M_Entry_Statistics_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from M_Entry_Statistics ");
            strSql.Append(" where M_Entry_Statistics_id in (" + M_Entry_Statistics_idlist + ")  ");
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
        public CommonService.Model.MonitorManager.M_Entry_Statistics GetModel(int M_Entry_Statistics_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 M_Entry_Statistics_id,M_Entry_Statistics_code,M_Case_code,M_Case_name,M_Case_type,M_Case_number,M_Entry_code,M_Entry_Statistics_changeDuration,M_Entry_Statistics_entrySTime,M_Entry_Statistics_entryETime,M_Entry_Statistics_status,M_Entry_Statistics_isDelete,M_Entry_Statistics_creator,M_Entry_Statistics_createTime,M_Entry_Statistics_warningSituation,M_Entry_Statistics_HandlingState,M_Entry_Statistics_Management from M_Entry_Statistics ");
            strSql.Append(" where M_Entry_Statistics_id=@M_Entry_Statistics_id");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_id", SqlDbType.Int,4)
			};
            parameters[0].Value = M_Entry_Statistics_id;

            CommonService.Model.MonitorManager.M_Entry_Statistics model = new CommonService.Model.MonitorManager.M_Entry_Statistics();
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
        public CommonService.Model.MonitorManager.M_Entry_Statistics GetModel(Guid M_Entry_Statistics_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 T.*,E.M_Entry_name,E.M_Entry_Duration,E.M_Entry_warningType,E.M_Entry_warningDuration from M_Entry_Statistics as T ");
            strSql.Append(" left join M_Entry as E on T.M_Entry_code=E.M_Entry_code ");
            strSql.Append(" where T.M_Entry_Statistics_code=@M_Entry_Statistics_code");
            strSql.Append(" and T.M_Entry_Statistics_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = M_Entry_Statistics_code;

            CommonService.Model.MonitorManager.M_Entry_Statistics model = new CommonService.Model.MonitorManager.M_Entry_Statistics();
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
        /// 根据条目Guid，生成条目统计信息
        /// </summary>
        /// <param name="entryCode">条目Guid</param>
        /// <param name="flowType">流程类型</param>
        /// <param name="creatorCode">操作人</param>
        public void GenerateEntryStatisticsByEntryCode(Guid entryCode, int flowType, Guid creatorCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@entryCode", SqlDbType.UniqueIdentifier,16),                    
                    new SqlParameter("@flowType", SqlDbType.Int,4),
                    new SqlParameter("@creatorCode", SqlDbType.UniqueIdentifier,16)
				 };
            parameters[0].Value = entryCode;
            parameters[1].Value = flowType;
            parameters[2].Value = creatorCode;

            DbHelperSQL.RunNoVoidProcedure("proc_GenerateEntryStatisticsByEntryCode", parameters);

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.MonitorManager.M_Entry_Statistics DataRowToModel(DataRow row)
        {
            CommonService.Model.MonitorManager.M_Entry_Statistics model = new CommonService.Model.MonitorManager.M_Entry_Statistics();
            if (row != null)
            {
                if (row["M_Entry_Statistics_id"] != null && row["M_Entry_Statistics_id"].ToString() != "")
                {
                    model.M_Entry_Statistics_id = int.Parse(row["M_Entry_Statistics_id"].ToString());
                }
                if (row["M_Entry_Statistics_code"] != null && row["M_Entry_Statistics_code"].ToString() != "")
                {
                    model.M_Entry_Statistics_code = new Guid(row["M_Entry_Statistics_code"].ToString());
                }
                if (row["M_Case_code"] != null && row["M_Case_code"].ToString() != "")
                {
                    model.M_Case_code = new Guid(row["M_Case_code"].ToString());
                }
                if (row["M_Case_name"] != null)
                {
                    model.M_Case_name = row["M_Case_name"].ToString();
                }
                if (row["M_Case_type"] != null && row["M_Case_type"].ToString() != "")
                {
                    model.M_Case_type = int.Parse(row["M_Case_type"].ToString());
                }
                if (row["M_Case_number"] != null && row["M_Case_number"].ToString() != "")
                {
                    model.M_Case_number = row["M_Case_number"].ToString();
                }
                if (row["M_Entry_code"] != null && row["M_Entry_code"].ToString() != "")
                {
                    model.M_Entry_code = new Guid(row["M_Entry_code"].ToString());
                }
                if (row["M_Entry_Statistics_changeDuration"] != null && row["M_Entry_Statistics_changeDuration"].ToString() != "")
                {
                    model.M_Entry_Statistics_changeDuration = int.Parse(row["M_Entry_Statistics_changeDuration"].ToString());
                }
                if (row["M_Entry_Statistics_entrySTime"] != null && row["M_Entry_Statistics_entrySTime"].ToString() != "")
                {
                    model.M_Entry_Statistics_entrySTime = DateTime.Parse(row["M_Entry_Statistics_entrySTime"].ToString());
                }
                if (row["M_Entry_Statistics_entryETime"] != null && row["M_Entry_Statistics_entryETime"].ToString() != "")
                {
                    model.M_Entry_Statistics_entryETime = DateTime.Parse(row["M_Entry_Statistics_entryETime"].ToString());
                }
                if (row["M_Entry_Statistics_status"] != null && row["M_Entry_Statistics_status"].ToString() != "")
                {
                    model.M_Entry_Statistics_status = int.Parse(row["M_Entry_Statistics_status"].ToString());
                }
                if (row["M_Entry_Statistics_isDelete"] != null && row["M_Entry_Statistics_isDelete"].ToString() != "")
                {
                    model.M_Entry_Statistics_isDelete = int.Parse(row["M_Entry_Statistics_isDelete"].ToString());
                }
                if (row["M_Entry_Statistics_creator"] != null && row["M_Entry_Statistics_creator"].ToString() != "")
                {
                    model.M_Entry_Statistics_creator = new Guid(row["M_Entry_Statistics_creator"].ToString());
                }
                if (row["M_Entry_Statistics_createTime"] != null && row["M_Entry_Statistics_createTime"].ToString() != "")
                {
                    model.M_Entry_Statistics_createTime = DateTime.Parse(row["M_Entry_Statistics_createTime"].ToString());
                }
                if (row["M_Entry_Statistics_warningSituation"] != null && row["M_Entry_Statistics_warningSituation"].ToString() != "")
                {
                    model.M_Entry_Statistics_warningSituation = int.Parse(row["M_Entry_Statistics_warningSituation"].ToString());
                }
                if (row["M_Entry_Statistics_HandlingState"] != null && row["M_Entry_Statistics_HandlingState"].ToString() != "")
                {
                    model.M_Entry_Statistics_HandlingState = int.Parse(row["M_Entry_Statistics_HandlingState"].ToString());
                }
                if (row["M_Entry_Statistics_Management"] != null && row["M_Entry_Statistics_Management"].ToString() != "")
                {
                    model.M_Entry_Statistics_Management = int.Parse(row["M_Entry_Statistics_Management"].ToString());
                }
                //判断条目名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("M_Entry_name"))
                {
                    if (row["M_Entry_name"] != null && row["M_Entry_name"].ToString() != "")
                    {
                        model.M_Entry_name = row["M_Entry_name"].ToString();
                    }
                }
                //判断标准时长（虚拟字段）是否存在
                if (row.Table.Columns.Contains("M_Entry_Duration"))
                {
                    if (row["M_Entry_Duration"] != null && row["M_Entry_Duration"].ToString() != "")
                    {
                        model.M_Entry_Duration = int.Parse(row["M_Entry_Duration"].ToString());
                    }
                }
                //判断预警类型（虚拟字段）是否存在
                if (row.Table.Columns.Contains("M_Entry_warningType"))
                {
                    if (row["M_Entry_warningType"] != null && row["M_Entry_warningType"].ToString() != "")
                    {
                        model.M_Entry_warningType = int.Parse(row["M_Entry_warningType"].ToString());
                    }
                }
                //判断预警时长（虚拟字段）是否存在
                if (row.Table.Columns.Contains("M_Entry_warningDuration"))
                {
                    if (row["M_Entry_warningDuration"] != null && row["M_Entry_warningDuration"].ToString() != "")
                    {
                        model.M_Entry_warningDuration = int.Parse(row["M_Entry_warningDuration"].ToString());
                    }
                }
                //案件类型名称（虚拟字段App专用）
                if (row.Table.Columns.Contains("M_Case_type_name"))
                {
                    if (row["M_Case_type_name"] != null && row["M_Case_type_name"].ToString() != "")
                    {
                        model.M_Case_type_name = row["M_Case_type_name"].ToString();
                    }
                }
                //办理状态名称（虚拟字段App专用）
                if (row.Table.Columns.Contains("M_Entry_Statistics_HandlingState_name"))
                {
                    if (row["M_Entry_Statistics_HandlingState_name"] != null && row["M_Entry_Statistics_HandlingState_name"].ToString() != "")
                    {
                        model.M_Entry_Statistics_HandlingState_name = row["M_Entry_Statistics_HandlingState_name"].ToString();
                    }
                }
                //预警情况名称（虚拟字段App专用）
                if (row.Table.Columns.Contains("M_Entry_Statistics_warningSituation_name"))
                {
                    if (row["M_Entry_Statistics_warningSituation_name"] != null && row["M_Entry_Statistics_warningSituation_name"].ToString() != "")
                    {
                        model.M_Entry_Statistics_warningSituation_name = row["M_Entry_Statistics_warningSituation_name"].ToString();
                    }
                }
                //预警类型名称（虚拟字段App专用）
                if (row.Table.Columns.Contains("M_Entry_warningType_name"))
                {
                    if (row["M_Entry_warningType_name"] != null && row["M_Entry_warningType_name"].ToString() != "")
                    {
                        model.M_Entry_warningType_name = row["M_Entry_warningType_name"].ToString();
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
            strSql.Append("select M_Entry_Statistics_id,M_Entry_Statistics_code,M_Case_code,M_Case_name,M_Case_type,M_Case_number,M_Entry_code,M_Entry_Statistics_changeDuration,M_Entry_Statistics_entrySTime,M_Entry_Statistics_entryETime,M_Entry_Statistics_status,M_Entry_Statistics_isDelete,M_Entry_Statistics_creator,M_Entry_Statistics_createTime,M_Entry_Statistics_warningSituation,M_Entry_Statistics_HandlingState,M_Entry_Statistics_Management ");
            strSql.Append(" FROM M_Entry_Statistics ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据预警情况获得'非预警'数据列表
        /// </summary>
        public DataSet GetListByWarningSituation()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.*,E.M_Entry_Duration,E.M_Entry_warningType,E.M_Entry_warningDuration ");
            strSql.Append(" FROM M_Entry_Statistics as T ");
            strSql.Append("right join M_Entry as E on T.M_Entry_code=E.M_Entry_code and E.M_Entry_isDelete=0 ");
            strSql.Append("where M_Entry_Statistics_status=397 and M_Entry_Statistics_warningSituation=465 ");
            strSql.Append("and M_Entry_Statistics_isDelete=0 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据办案状态获得非'已结束'数据列表
        /// </summary>
        public DataSet GetListByHandlingState()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.*,E.M_Entry_Duration ");
            strSql.Append(" FROM M_Entry_Statistics as T ");
            strSql.Append("right join M_Entry as E on T.M_Entry_code=E.M_Entry_code and E.M_Entry_isDelete=0 ");
            strSql.Append("where M_Entry_Statistics_status=397 and ((M_Entry_Statistics_HandlingState<>471  and M_Entry_Statistics_HandlingState<>793) or M_Entry_Statistics_HandlingState is null) ");
            strSql.Append("and M_Entry_Statistics_isDelete=0 ");
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
            strSql.Append(" M_Entry_Statistics_id,M_Entry_Statistics_code,M_Case_code,M_Case_name,M_Case_type,M_Case_number,M_Entry_code,M_Entry_Statistics_changeDuration,M_Entry_Statistics_entrySTime,M_Entry_Statistics_entryETime,M_Entry_Statistics_status,M_Entry_Statistics_isDelete,M_Entry_Statistics_creator,M_Entry_Statistics_createTime,M_Entry_Statistics_warningSituation,M_Entry_Statistics_HandlingState,M_Entry_Statistics_Management ");
            strSql.Append(" FROM M_Entry_Statistics ");
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
        public int GetRecordCount(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            #region  123
            //int a = 0, b = 0, c = 0, d = 0, e = 0, g = 0;
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT count(*) FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append("order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append("order by T.M_Entry_Statistics_id desc");
            //}
            //strSql.Append(")AS Row, T.*,E.M_Entry_name,E.M_Entry_Duration,E.M_Entry_warningType,E.M_Entry_warningDuration  from M_Entry_Statistics T ");
            //strSql.Append("left join M_Entry as E on T.M_Entry_code=E.M_Entry_code ");
            //strSql.Append(" where 1=1 and T.M_Entry_Statistics_isDelete=0 ");
            //if (model != null)
            //{
            //    if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
            //    }
            //    if (model.M_Case_code != null && model.M_Case_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Case_code=@M_Case_code ");
            //    }
            //    if (model.M_Entry_code != null && model.M_Entry_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_code=@M_Entry_code ");
            //    }
            //    if (model.M_Entry_Statistics_status != null && model.M_Entry_Statistics_status.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_Statistics_status=@M_Entry_Statistics_status ");
            //    }
            //    else
            //    {
            //        strSql.Append("and T.M_Entry_Statistics_status=397  ");
            //    }
            //}
            //strSql.Append(" ) TT");
            //strSql.Append(" left join (");
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ");
            //strSql.Append(" T.*  from B_Case as T ");
            //if (casemodel != null)
            //{
            //    //办案阶段限制
            //    if (!string.IsNullOrEmpty(casemodel.B_Case_Stage))
            //    {
            //        strSql.Append("right join (select * from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0) As F on T.B_Case_code= F.P_Fk_code ");
            //    }
            //    //工程
            //    if (!string.IsNullOrEmpty(casemodel.C_Project_code))
            //    {
            //        strSql.Append("right join (select * from B_Case_link As CL left join C_Involved_project As CI on  CL.C_FK_code=CI.C_Involved_project_code where CL.C_FK_code = @C_Project_code and CL.B_Case_link_type=7) As CBP on T.B_Case_code=CBP.B_Case_code ");
            //        a = 1;
            //    }
            //    //客户   委托人
            //    if ((!string.IsNullOrEmpty(casemodel.C_Customer_code)) && (!string.IsNullOrEmpty(casemodel.C_Client_code)))
            //    {
            //        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");

            //        strSql.Append("right join (select C_Customer_code,B_Case_code from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP2 on T.B_Case_code=CP2.B_Case_code ");

            //        b = c = d = 1;
            //    }
            //    if (d != 1)
            //    {
            //        if ((!string.IsNullOrEmpty(casemodel.C_Customer_code)) || (!string.IsNullOrEmpty(casemodel.C_Client_code)))
            //        {
            //            if (!string.IsNullOrEmpty(casemodel.C_Customer_code))
            //            {
            //                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
            //                b = 1;
            //            }
            //            else
            //            {//委托人
            //                strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
            //                c = 1;
            //            }

            //        }
            //    }
            //    //对方当事人
            //    if (!string.IsNullOrEmpty(casemodel.B_Case_Rival_code))
            //    {
            //        strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
            //        strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
            //        e = 1;
            //    }
            //    //区域
            //    if (!String.IsNullOrEmpty(casemodel.C_Region_code))
            //    {
            //        strSql.Append("left join(select C_Region_code,B_Case_code from B_Case_link As CL  left join C_Region As CR  on CL.C_FK_code = CR.C_Region_code where CL.C_FK_code=@C_Region_code and CL.B_Case_link_type=6) As CIP on CIP.B_Case_code=T.B_Case_code ");
            //        g = 1;
            //    }
            //    strSql.Append(" where 1=1 and B_Case_isDelete=0 ");
            //}
            //if (casemodel != null)
            //{
            //    if (casemodel.B_Case_code != null && casemodel.B_Case_code.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_code=@B_Case_code ");
            //    }
            //    if (casemodel.B_Case_name != null && casemodel.B_Case_name.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_name like N'%'+@B_Case_name+'%' ");
            //    }
            //    if (casemodel.B_Case_type != null && casemodel.B_Case_type.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_type=@B_Case_type ");
            //    }
            //    if (casemodel.B_Case_nature != null && casemodel.B_Case_nature.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_nature=@B_Case_nature ");
            //    }
            //    if (casemodel.B_Case_customerType != null && casemodel.B_Case_customerType.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_customerType=@B_Case_customerType ");
            //    }
            //    if (casemodel.B_Case_state != null && casemodel.B_Case_state.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_state=@B_Case_state ");
            //    }
            //    //新添加条件查询
            //    if (!string.IsNullOrEmpty(casemodel.B_Case_number))
            //    {
            //        strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
            //    }
            //    //专业顾问暂时没加
            //    if (!string.IsNullOrEmpty(casemodel.B_Case_consultant_code.ToString()))
            //    {
            //        strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
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
            //            strSql.Append("and  C_Customer_code=@C_Customer_code ");
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(casemodel.B_Case_consultant_code.ToString()))
            //    {
            //        strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
            //    }
            //    if (e == 1)
            //    {
            //        strSql.Append("and (C_PRival_code=@B_Case_Rival_code or C_CRival_code=@B_Case_Rival_code) ");
            //    }
            //    if (g == 1)
            //    {
            //        strSql.Append("and C_Region_code=@C_Region_code ");
            //    }
            //    if (!string.IsNullOrEmpty(casemodel.B_Case_courtFirst.ToString()))
            //    {
            //        strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
            //    }
            //    if ((!string.IsNullOrEmpty(casemodel.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(casemodel.B_Case_execMoney2.ToString()))
            //    {
            //        strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
            //    }
            //    if ((!string.IsNullOrEmpty(casemodel.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_registerTime2.ToString())))
            //    {
            //        strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
            //    }
            //    if ((!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant2.ToString())))
            //    {
            //        strSql.Append("and B_Case_expectedGrant between @B_Case_expectedGrant and @B_Case_expectedGrant2 ");
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
            //        strPowerSql.Append("or T.B_Case_person=@ThisUserCode ");
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
            //        strPowerSql.Append("or exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization)");
            //        //strPowerSql.Append("and CU.C_Userinfo_Organization=@ThisDeptCode ");
            //        //strPowerSql.Append("and CU.C_Userinfo_post=@ThisPostCode ");
            //        strPowerSql.Append("and T.B_Case_consultant_code=CU.C_Userinfo_code) ");
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
            //    strPowerSql.Append("or T.B_Case_person=@ThisUserCode ");
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


            //strSql.Append(" ) TC) TB on TB.B_Case_code=TT.M_Case_code");

            //strSql.Append(" WHERE TB.B_Case_code like '%' ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@M_Case_code", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@B_Case_name", SqlDbType.VarChar,200),
            //        new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@B_Case_type", SqlDbType.Int,4),
            //        new SqlParameter("@B_Case_nature", SqlDbType.Int,4),
            //        new SqlParameter("@B_Case_customerType", SqlDbType.Int,4),
            //        new SqlParameter("@C_FK_code",SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@B_Case_Stage",SqlDbType.VarChar,50),
            //        new SqlParameter("@C_Project_code",SqlDbType.VarChar,200),
            //        new SqlParameter("@C_Customer_code",SqlDbType.VarChar,200),
            //        new SqlParameter("@C_Client_code",SqlDbType.VarChar,200),
            //        new SqlParameter("@B_Case_Rival_code",SqlDbType.VarChar,200),
            //        new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
            //        new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
            //        new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
            //        new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
            //        new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
            //        new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
            //        new SqlParameter("@B_Case_state",SqlDbType.Int,4),
            //        new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@ThisRoleId",SqlDbType.Int,4),
            //        new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@M_Entry_Statistics_status", SqlDbType.Int,4),
            //        new SqlParameter("@B_Case_expectedGrant", SqlDbType.Decimal,16),
            //        new SqlParameter("@B_Case_expectedGrant2", SqlDbType.Decimal,16),
            //                            };
            //parameters[0].Value = model.M_Entry_Statistics_code;
            //parameters[1].Value = model.M_Case_code;
            //parameters[2].Value = model.M_Entry_code;
            //parameters[3].Value = casemodel.B_Case_name;
            //parameters[4].Value = casemodel.B_Case_code;
            //parameters[5].Value = casemodel.B_Case_type;
            //parameters[6].Value = casemodel.B_Case_nature;
            //parameters[7].Value = casemodel.B_Case_customerType;
            //parameters[8].Value = casemodel.B_Case_relationCode;
            //parameters[9].Value = casemodel.B_Case_Stage;
            //parameters[10].Value = casemodel.C_Project_code;
            //parameters[11].Value = casemodel.C_Customer_code;
            //parameters[12].Value = casemodel.C_Client_code;
            //parameters[13].Value = casemodel.B_Case_Rival_code;
            //parameters[14].Value = casemodel.C_Region_code;
            //parameters[15].Value = casemodel.B_Case_number;
            //parameters[16].Value = casemodel.B_Case_courtFirst;
            //parameters[17].Value = casemodel.B_Case_transferTargetMoney;
            //parameters[18].Value = casemodel.B_Case_execMoney2;
            //parameters[19].Value = casemodel.B_Case_registerTime;
            //parameters[20].Value = casemodel.B_Case_registerTime2;
            //parameters[21].Value = casemodel.B_Case_state;
            //parameters[22].Value = casemodel.B_Case_consultant_code;
            //parameters[23].Value = userCode;
            //parameters[24].Value = roleId;
            //parameters[25].Value = deptCode;
            //parameters[26].Value = postCode;
            //parameters[27].Value = model.M_Entry_Statistics_status;
            //parameters[28].Value = casemodel.B_Case_expectedGrant;
            //parameters[29].Value = casemodel.B_Case_expectedGrant2;
            //object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            //if (obj == null)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}
            #endregion
            #region 新sql
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(1) from ");
            strSql.Append(" M_Entry_Statistics T");
            strSql.Append(" right join B_Case B on T.M_Case_code=B.B_Case_code and B.B_Case_isDelete=0");
            strSql.Append(" right join M_Entry as E on T.M_Entry_code=E.M_Entry_code and E.M_Entry_isDelete=0  where 1=1 and T.M_Entry_Statistics_isDelete=0 ");

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=B.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }

                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
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
                    strPowerSql.Append("and BCL.B_Case_code=B.B_Case_code) ");

                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=B.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=B.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=B.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and B.B_Case_person=CEM.C_Minister_Code) ");
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

            if (model != null)
            {
                if (model.M_Entry_name != null)
                {
                    strSql.Append("and E.M_Entry_name like N'%'+@M_Entry_name+'%' ");
                }
                if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
                }
                if (model.M_Case_code != null && model.M_Case_code.ToString() != "")
                {
                    strSql.Append("and T.M_Case_code=@M_Case_code ");
                }
                if (model.M_Entry_code != null && model.M_Entry_code.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_code=@M_Entry_code ");
                }
                if (model.M_Entry_Statistics_status != null && model.M_Entry_Statistics_status.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_Statistics_status=@M_Entry_Statistics_status ");
                }
                else
                {
                    strSql.Append("and T.M_Entry_Statistics_status=397  ");
                }
                if (model.M_Entry_Statistics_HandlingState != null && model.M_Entry_Statistics_HandlingState.ToString() != "")
                {
                    strSql.Append(" and T.M_Entry_Statistics_HandlingState=@M_Entry_Statistics_HandlingState ");
                }
                if (model.M_Entry_Statistics_Management != null && model.M_Entry_Statistics_Management1 != null)
                {
                    strSql.Append(" and T.M_Entry_Statistics_Management between @M_Entry_Statistics_Management and @M_Entry_Statistics_Management1 ");
                }
            }
            if (casemodel != null)
            {
                //案件编码
                if (!string.IsNullOrEmpty(casemodel.B_Case_code.ToString()))
                {
                    strSql.Append(" and B.B_Case_code like N'%'+@B_Case_code+'%' ");

                }

                //案件名称
                if (casemodel.B_Case_name != null && casemodel.B_Case_name.ToString() != "")
                {
                    strSql.Append(" and B.B_Case_name like N'%'+@B_Case_name+'%' ");
                }
                //案件类型
                if (casemodel.B_Case_type != null && casemodel.B_Case_type.ToString() != "")
                {
                    strSql.Append("and B.B_Case_type =@B_Case_type ");
                }
                //案件性质
                if (casemodel.B_Case_nature != null && casemodel.B_Case_nature.ToString() != "")
                {
                    strSql.Append("and B.B_Case_nature =@B_Case_nature ");
                }
                //案件客户类型
                if (casemodel.B_Case_customerType != null && casemodel.B_Case_customerType.ToString() != "")
                {
                    strSql.Append("and B.B_Case_customerType =@B_Case_customerType ");
                }
                //案件状态
                if (casemodel.B_Case_state != null && casemodel.B_Case_state.ToString() != "")
                {
                    strSql.Append("and B.B_Case_state =@B_Case_state ");
                }
                //案件编码
                if (!string.IsNullOrEmpty(casemodel.B_Case_number))
                {
                    strSql.Append("and B.B_Case_number like N'%'+@B_Case_number+'%' ");
                }
                //专业顾问
                if (!string.IsNullOrEmpty(casemodel.B_Case_consultant_code.ToString()))
                {
                    strSql.Append(" and B.B_Case_consultant_code=@B_Case_consultant_code ");
                }

                if (!string.IsNullOrEmpty(casemodel.B_Case_courtFirst.ToString()))
                {
                    strSql.Append("and @B_Case_courtFirst in (B.B_Case_courtFirst,B.B_Case_courtSecond,B.B_Case_courtExec,B.B_Case_Trial) ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(casemodel.B_Case_execMoney2.ToString()))
                {
                    strSql.Append("and B.B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_registerTime2.ToString())))
                {
                    strSql.Append("and B.B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant2.ToString())))
                {
                    strSql.Append("and B.B_Case_expectedGrant between @B_Case_expectedGrant and @B_Case_expectedGrant2 ");
                }

                //办案阶段限制
                if (!string.IsNullOrEmpty(casemodel.B_Case_Stage))
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow where P_Business_flow.P_Flow_code=@B_Case_Stage and P_Business_flow.P_Fk_code=B.B_Case_code and P_Business_flow.P_Business_isdelete=0)");
                }
                //工程
                if (!string.IsNullOrEmpty(casemodel.C_Project_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Project_code and B_Case_link.B_Case_link_type=7)");
                }
                //客户   委托人

                if (!string.IsNullOrEmpty(casemodel.C_Customer_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Customer_code and B_Case_link.B_Case_link_type=0)");
                }
                if (!string.IsNullOrEmpty(casemodel.C_Client_code))
                {//委托人
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Client_code and B_Case_link.B_Case_link_type=1)");
                }

                //对方当事人
                if (!string.IsNullOrEmpty(casemodel.B_Case_Rival_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Case_Rival_code and (B_Case_link.B_Case_link_type=2 or B_Case_link.B_Case_link_type=3))");
                }
                //区域
                if (!String.IsNullOrEmpty(casemodel.C_Region_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Region_code and B_Case_link.B_Case_link_type=6)");
                }

            }
            #endregion

            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
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
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@M_Entry_Statistics_status", SqlDbType.Int,4),
                     new SqlParameter("@B_Case_expectedGrant", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_expectedGrant2", SqlDbType.Decimal,16),
                    new SqlParameter("@M_Entry_Statistics_HandlingState",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management1",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_name",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.M_Entry_Statistics_code;
            parameters[1].Value = model.M_Case_code;
            parameters[2].Value = model.M_Entry_code;
            parameters[3].Value = casemodel.B_Case_name;
            parameters[4].Value = casemodel.B_Case_code;
            parameters[5].Value = casemodel.B_Case_type;
            parameters[6].Value = casemodel.B_Case_nature;
            parameters[7].Value = casemodel.B_Case_customerType;
            parameters[8].Value = casemodel.B_Case_relationCode;
            parameters[9].Value = casemodel.B_Case_Stage;
            parameters[10].Value = casemodel.C_Project_code;
            parameters[11].Value = casemodel.C_Customer_code;
            parameters[12].Value = casemodel.C_Client_code;
            parameters[13].Value = casemodel.B_Case_Rival_code;
            parameters[14].Value = casemodel.C_Region_code;
            parameters[15].Value = casemodel.B_Case_number;
            parameters[16].Value = casemodel.B_Case_courtFirst;
            parameters[17].Value = casemodel.B_Case_transferTargetMoney;
            parameters[18].Value = casemodel.B_Case_execMoney2;
            parameters[19].Value = casemodel.B_Case_registerTime;
            parameters[20].Value = casemodel.B_Case_registerTime2;
            parameters[21].Value = casemodel.B_Case_state;
            parameters[22].Value = casemodel.B_Case_consultant_code;
            parameters[23].Value = userCode;
            parameters[24].Value = deptCode;
            parameters[25].Value = postCode;
            parameters[26].Value = model.M_Entry_Statistics_status;
            parameters[27].Value = casemodel.B_Case_expectedGrant;
            parameters[28].Value = casemodel.B_Case_expectedGrant2;
            parameters[29].Value = model.M_Entry_Statistics_HandlingState;
            parameters[30].Value = model.M_Entry_Statistics_Management;
            parameters[31].Value = model.M_Entry_Statistics_Management1;
            parameters[32].Value = model.M_Entry_name;
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
        public DataSet GetListByPage(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            #region 新sql
            StringBuilder strSql = new StringBuilder();
            //strSql.Append(" select * from (SELECT ROW_NUMBER() OVER (order by M_Entry_Statistics_id desc)AS Row,* FROM");
            strSql.Append(" SELECT T.*,E.M_Entry_name,E.M_Entry_Duration,E.M_Entry_warningType,E.M_Entry_warningDuration  from M_Entry_Statistics T");
            strSql.Append(" right join B_Case B on T.M_Case_code=B.B_Case_code and B.B_Case_isDelete=0");
            strSql.Append(" right join M_Entry as E on T.M_Entry_code=E.M_Entry_code and E.M_Entry_isDelete=0  where 1=1 and T.M_Entry_Statistics_isDelete=0 ");

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                if (rolePowerIds.Contains(",1,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",2,"))
                {
                    strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=B.B_Case_code) ");
                }
                if (rolePowerIds.Contains(",3,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                }
                if (rolePowerIds.Contains(",4,"))
                {
                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                }

                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where exists(select 1 from C_Organization_post_user As OPU with(nolock) where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=CU.C_Userinfo_code and OPU.C_Organization_code=DTree.C_Organization_code)) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
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
                    strPowerSql.Append("and BCL.B_Case_code=B.B_Case_code) ");

                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=B.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=B.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=B.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and B.B_Case_person=CEM.C_Minister_Code) ");
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

            if (model != null)
            {
                if (model.M_Entry_name != null)
                {
                    strSql.Append("and E.M_Entry_name like N'%'+@M_Entry_name+'%' ");
                }
                if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
                }
                if (model.M_Case_code != null && model.M_Case_code.ToString() != "")
                {
                    strSql.Append("and T.M_Case_code=@M_Case_code ");
                }
                if (model.M_Entry_code != null && model.M_Entry_code.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_code=@M_Entry_code ");
                }
                if (model.M_Entry_Statistics_status != null && model.M_Entry_Statistics_status.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_Statistics_status=@M_Entry_Statistics_status ");
                }
                else
                {
                    strSql.Append("and T.M_Entry_Statistics_status=397  ");
                }
                if (model.M_Entry_Statistics_HandlingState != null && model.M_Entry_Statistics_HandlingState.ToString() != "")
                {
                    strSql.Append(" and T.M_Entry_Statistics_HandlingState=@M_Entry_Statistics_HandlingState ");
                }
                if (model.M_Entry_Statistics_Management != null && model.M_Entry_Statistics_Management1 != null)
                {
                    strSql.Append(" and T.M_Entry_Statistics_Management between @M_Entry_Statistics_Management and @M_Entry_Statistics_Management1 ");
                }
            }
            if (casemodel != null)
            {
                //案件编码
                if (!string.IsNullOrEmpty(casemodel.B_Case_code.ToString()))
                {
                    strSql.Append(" and B.B_Case_code like N'%'+@B_Case_code+'%' ");

                }

                //案件名称
                if (casemodel.B_Case_name != null && casemodel.B_Case_name.ToString() != "")
                {
                    strSql.Append(" and B.B_Case_name like N'%'+@B_Case_name+'%' ");
                }
                //案件类型
                if (casemodel.B_Case_type != null && casemodel.B_Case_type.ToString() != "")
                {
                    strSql.Append("and B.B_Case_type =@B_Case_type ");
                }
                //案件性质
                if (casemodel.B_Case_nature != null && casemodel.B_Case_nature.ToString() != "")
                {
                    strSql.Append("and B.B_Case_nature =@B_Case_nature ");
                }
                //案件客户类型
                if (casemodel.B_Case_customerType != null && casemodel.B_Case_customerType.ToString() != "")
                {
                    strSql.Append("and B.B_Case_customerType =@B_Case_customerType ");
                }
                //案件状态
                if (casemodel.B_Case_state != null && casemodel.B_Case_state.ToString() != "")
                {
                    strSql.Append("and B.B_Case_state =@B_Case_state ");
                }
                //案件编码
                if (!string.IsNullOrEmpty(casemodel.B_Case_number))
                {
                    strSql.Append("and B.B_Case_number like N'%'+@B_Case_number+'%' ");
                }
                //专业顾问
                if (!string.IsNullOrEmpty(casemodel.B_Case_consultant_code.ToString()))
                {
                    strSql.Append(" and B.B_Case_consultant_code=@B_Case_consultant_code ");
                }

                if (!string.IsNullOrEmpty(casemodel.B_Case_courtFirst.ToString()))
                {
                    strSql.Append("and @B_Case_courtFirst in (B.B_Case_courtFirst,B.B_Case_courtSecond,B.B_Case_courtExec,B.B_Case_Trial) ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(casemodel.B_Case_execMoney2.ToString()))
                {
                    strSql.Append("and B.B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_registerTime2.ToString())))
                {
                    strSql.Append("and B.B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant2.ToString())))
                {
                    strSql.Append("and B.B_Case_expectedGrant between @B_Case_expectedGrant and @B_Case_expectedGrant2 ");
                }

                //办案阶段限制
                if (!string.IsNullOrEmpty(casemodel.B_Case_Stage))
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow where P_Business_flow.P_Flow_code=@B_Case_Stage and P_Business_flow.P_Fk_code=B.B_Case_code and P_Business_flow.P_Business_isdelete=0)");
                }
                //工程
                if (!string.IsNullOrEmpty(casemodel.C_Project_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Project_code and B_Case_link.B_Case_link_type=7)");
                }
                //客户   委托人

                if (!string.IsNullOrEmpty(casemodel.C_Customer_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Customer_code and B_Case_link.B_Case_link_type=0)");
                }
                if (!string.IsNullOrEmpty(casemodel.C_Client_code))
                {//委托人
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Client_code and B_Case_link.B_Case_link_type=1)");
                }

                //对方当事人
                if (!string.IsNullOrEmpty(casemodel.B_Case_Rival_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Case_Rival_code and (B_Case_link.B_Case_link_type=2 or B_Case_link.B_Case_link_type=3))");
                }
                //区域
                if (!String.IsNullOrEmpty(casemodel.C_Region_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Region_code and B_Case_link.B_Case_link_type=6)");
                }


            }
            #endregion

            if (!string.IsNullOrEmpty(orderby))
            {
                strSql.Append(" order by " + orderby);
            }
            else
            {
                strSql.Append(" order by M_Entry_Statistics_id desc");
            }
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);
            //strSql.Append(" ) TMC) as TW");
            //strSql.AppendFormat(" WHERE   TW.Row between {0} and {1} order by Row", startIndex, endIndex);

            #region sql
            //int a = 0, b = 0, c = 0, d = 0, e = 0, g = 0;
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append(" select*from (SELECT ROW_NUMBER() OVER (order by M_Entry_Statistics_id desc)AS Row,* FROM");
            //strSql.Append(" (SELECT T.*,E.M_Entry_name,E.M_Entry_Duration,E.M_Entry_warningType,E.M_Entry_warningDuration  from M_Entry_Statistics T");
            //strSql.Append(" left join M_Entry as E on T.M_Entry_code=E.M_Entry_code  where 1=1 and T.M_Entry_Statistics_isDelete=0 ");

            //if (model != null)
            //{
            //    if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
            //    }
            //    if (model.M_Case_code != null && model.M_Case_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Case_code=@M_Case_code ");
            //    }
            //    if (model.M_Entry_code != null && model.M_Entry_code.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_code=@M_Entry_code ");
            //    }
            //    if (model.M_Entry_Statistics_status != null && model.M_Entry_Statistics_status.ToString() != "")
            //    {
            //        strSql.Append("and T.M_Entry_Statistics_status=@M_Entry_Statistics_status ");
            //    }
            //    else
            //    {
            //        strSql.Append("and T.M_Entry_Statistics_status=397  ");
            //    }
            //}

            //strSql.Append("and(1<>1 ");


            //if (model.M_Entry_Statistics_code == null && model.M_Case_code == null && model.M_Entry_code == null && casemodel.C_Project_code==null
            //    && casemodel.B_Case_Stage == null && casemodel.C_Customer_code == null && casemodel.B_Case_Rival_code == null && casemodel.C_Client_code == null
            //    && casemodel.B_Case_Rival_code == null && casemodel.C_Region_code == null && casemodel.B_Case_code == null && casemodel.B_Case_name == null && casemodel.B_Case_expectedGrant == null && casemodel.B_Case_registerTime == null && casemodel.B_Case_transferTargetMoney == null && casemodel.B_Case_courtFirst == null && casemodel.B_Case_consultant_code == null && casemodel.B_Case_number == null && casemodel.B_Case_type == null && casemodel.B_Case_nature == null && casemodel.B_Case_customerType == null && casemodel.B_Case_state == null
            //    )
            //{
            //    strSql.Append("or exists(SELECT  1 from B_Case  where 1=1 and B_Case_isDelete=0 and B_Case_code=T.M_Case_code ");
            //    strSql.Append(" ) ");
            //}
            //else { strSql.Append(" or (1<>1 "); }




            //if (casemodel.C_Project_code!=null||casemodel.B_Case_Stage != null || casemodel.C_Client_code != null || casemodel.C_Customer_code != null || casemodel.B_Case_code != null || casemodel.B_Case_name != null || casemodel.B_Case_Rival_code != null || casemodel.B_Case_expectedGrant != null || casemodel.B_Case_registerTime != null || casemodel.B_Case_transferTargetMoney != null || casemodel.B_Case_courtFirst != null || casemodel.B_Case_consultant_code != null || casemodel.B_Case_number != null || casemodel.B_Case_type != null || casemodel.B_Case_nature != null || casemodel.B_Case_customerType != null || casemodel.B_Case_state != null || casemodel.C_Region_code != null)
            //{
            //    strSql.Append(" or exists(SELECT  1 from B_Case  where 1=1 and B_Case_isDelete=0 and B_Case_code=T.M_Case_code ");

            //    if (casemodel.B_Case_code != null && casemodel.B_Case_code.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_code=@B_Case_code ");
            //    }
            //    if (casemodel.B_Case_name != null && casemodel.B_Case_name.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_name like  N'%'+@B_Case_name+'%' ");

            //    }
            //    if (casemodel.B_Case_type != null && casemodel.B_Case_type.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_type=@B_Case_type ");
            //    }
            //    if (casemodel.B_Case_nature != null && casemodel.B_Case_nature.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_nature=@B_Case_nature ");
            //    }
            //    if (casemodel.B_Case_customerType != null && casemodel.B_Case_customerType.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_customerType=@B_Case_customerType ");
            //    }
            //    if (casemodel.B_Case_state != null && casemodel.B_Case_state.ToString() != "")
            //    {
            //        strSql.Append("and B_Case_state=@B_Case_state ");
            //    }
            //    //新添加条件查询
            //    if (!string.IsNullOrEmpty(casemodel.B_Case_number))
            //    {
            //        strSql.Append("and B_Case_number like N'%'+@B_Case_number+'%' ");
            //    }
            //    //专业顾问
            //    if (!string.IsNullOrEmpty(casemodel.B_Case_consultant_code.ToString()))
            //    {
            //        strSql.Append(" and B_Case_consultant_code=@B_Case_consultant_code ");
            //    }

            //    if (!string.IsNullOrEmpty(casemodel.B_Case_courtFirst.ToString()))
            //    {
            //        strSql.Append("and @B_Case_courtFirst in (B_Case_courtFirst,B_Case_courtSecond,B_Case_courtExec,B_Case_Trial) ");
            //    }
            //    if ((!string.IsNullOrEmpty(casemodel.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(casemodel.B_Case_execMoney2.ToString()))
            //    {
            //        strSql.Append("and B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
            //    }
            //    if ((!string.IsNullOrEmpty(casemodel.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_registerTime2.ToString())))
            //    {
            //        strSql.Append("and B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
            //    }
            //    if ((!string.IsNullOrEmpty(c.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant2.ToString())))
            //    {
            //        strSql.Append("and B_Case_expectedGrant between @B_Case_expectedGrant and @B_Case_expectedGrant2 ");
            //    }

            //    if (casemodel != null)
            //    {
            //        //办案阶段限制
            //        if (!string.IsNullOrEmpty(casemodel.B_Case_Stage))
            //        {
            //            strSql.Append("and exists(select 1 from P_Business_flow As P  where p.P_Flow_code=@B_Case_Stage and p.P_Business_isdelete=0 and T.M_Case_code=P_Fk_code) ");
            //        }
            //        //工程
            //        if (!string.IsNullOrEmpty(casemodel.C_Project_code))
            //        {
            //            strSql.Append("and exists(select 1 from B_Case_link as CL left join C_Involved_project As CI on  CL.C_FK_Code=CI.C_Involved_project_code where CL.C_FK_Code =@C_Project_code and CL.B_Case_link_type=7 and T.M_Case_code=CL.B_Case_code)");
            //            a = 1;
            //        }
            //        //客户   委托人
            //        if ((!string.IsNullOrEmpty(casemodel.C_Customer_code)) && (!string.IsNullOrEmpty(casemodel.C_Client_code)))
            //        {

            //            strSql.Append(" and exists(select 1 from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and  CL.B_Case_link_type=0  and T.M_Case_code=CL.B_Case_code) ");


            //            strSql.Append(" and exists(select 1 from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1 and T.M_Case_code=CL.B_Case_code) ");


            //            b = c = d = 1;
            //        }
            //        if (d != 1)
            //        {
            //            if ((!string.IsNullOrEmpty(casemodel.C_Customer_code)) || (!string.IsNullOrEmpty(casemodel.C_Client_code)))
            //            {
            //                if (!string.IsNullOrEmpty(casemodel.C_Customer_code))
            //                {
            //                    strSql.Append(" and exists(select 1 from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0 and T.M_Case_code=CL.B_Case_code) ");
            //                    //   strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Customer_code and CL.B_Case_link_type=0) As CP on T.B_Case_code=CP.B_Case_code ");
            //                    b = 1;
            //                }
            //                else
            //                {//委托人
            //                    strSql.Append(" and exists(select 1 from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1 and T.M_Case_code=CL.B_Case_code)  ");
            //                    // strSql.Append("right join (select * from B_Case_link As CL left join C_Customer As CI on  CL.C_FK_code=CI.C_Customer_code where CL.C_FK_code = @C_Client_code and CL.B_Case_link_type=1) As CP on T.B_Case_code=CP.B_Case_code ");
            //                    c = 1;
            //                }

            //            }
            //        }
            //        //对方当事人
            //        if (!string.IsNullOrEmpty(casemodel.B_Case_Rival_code))
            //        {
            //            strSql.Append(" and exists(select 1  from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2 and CL.B_Case_code=T.M_Case_code)  ");
            //            strSql.Append(" or exists(select 1  from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3 and CL.B_Case_code=T.M_Case_code)  ");
            //            // strSql.Append("left join(select C_PRival_code,B_Case_code from B_Case_link As CL  left join C_PRival As CP  on CL.C_FK_code = CP.C_PRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=3) As CIP on CIP.B_Case_code=T.B_Case_code ");
            //            //  strSql.Append("left join(select C_CRival_code,B_Case_code from B_Case_link As CL  left join C_CRival As CP  on CL.C_FK_code = CP.C_CRival_code where CL.C_FK_code=@B_Case_Rival_code and CL.B_Case_link_type=2) As CRB on CRB.B_Case_code=T.B_Case_code ");
            //            e = 1;
            //        }
            //        //区域
            //        if (!String.IsNullOrEmpty(casemodel.C_Region_code))
            //        {
            //            strSql.Append(" and exists(select 1 from B_Case_link As CL  left join C_Region As CR  on CL.C_FK_code = CR.C_Region_code where CL.C_FK_code=@C_Region_code and CL.B_Case_link_type=6 and CL.B_Case_code=T.M_Case_code) ");

            //            //   strSql.Append("left join(select C_Region_code,B_Case_code from B_Case_link As CL  left join C_Region As CR  on CL.C_FK_code = CR.C_Region_code where CL.C_FK_code=@C_Region_code and CL.B_Case_link_type=6) As CIP on CIP.B_Case_code=T.B_Case_code ");

            //            g = 1;
            //        }

            //    }





            //    if (model.M_Entry_Statistics_code == null && model.M_Case_code == null && model.M_Entry_code == null && casemodel.C_Project_code==null
            //                    && casemodel.B_Case_Stage == null && casemodel.C_Customer_code == null && casemodel.B_Case_Rival_code == null && casemodel.C_Client_code == null
            //                    && casemodel.B_Case_Rival_code == null && casemodel.C_Region_code == null && casemodel.B_Case_code == null && casemodel.B_Case_name == null && casemodel.B_Case_expectedGrant == null && casemodel.B_Case_registerTime == null && casemodel.B_Case_transferTargetMoney == null && casemodel.B_Case_courtFirst == null && casemodel.B_Case_consultant_code == null && casemodel.B_Case_number == null && casemodel.B_Case_type == null && casemodel.B_Case_nature == null && casemodel.B_Case_customerType == null && casemodel.B_Case_state == null
            //                    )
            //    {
            //        strSql.Append(")");
            //    }
            //    strSql.Append(")");
            //    strSql.Append(" ) ");
            //}



            //strSql.Append(" ) ");












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
            //        strPowerSql.Append("or T.B_Case_person=@ThisUserCode ");
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
            //        strPowerSql.Append("or exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization)");
            //        //strPowerSql.Append("and CU.C_Userinfo_Organization=@ThisDeptCode ");
            //        //strPowerSql.Append("and CU.C_Userinfo_post=@ThisPostCode ");
            //        strPowerSql.Append("and T.B_Case_consultant_code=CU.C_Userinfo_code) ");
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
            //    strPowerSql.Append("or T.B_Case_person=@ThisUserCode ");
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


            //strSql.Append(" ) TMC) as TW");
            //strSql.AppendFormat(" WHERE   TW.Row between {0} and {1} order by Row", startIndex, endIndex);
            #endregion

            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
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
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_number", SqlDbType.VarChar,200),
                    new SqlParameter("@B_Case_courtFirst", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_execMoney", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_execMoney2", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_registerTime", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_registerTime2", SqlDbType.DateTime,16),
                    new SqlParameter("@B_Case_state",SqlDbType.Int,4),
                    new SqlParameter("@B_Case_consultant_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisUserCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisDeptCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ThisPostCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@M_Entry_Statistics_status", SqlDbType.Int,4),
                     new SqlParameter("@B_Case_expectedGrant", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_expectedGrant2", SqlDbType.Decimal,16),
                    new SqlParameter("@M_Entry_Statistics_HandlingState",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management1",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_name",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.M_Entry_Statistics_code;
            parameters[1].Value = model.M_Case_code;
            parameters[2].Value = model.M_Entry_code;
            parameters[3].Value = casemodel.B_Case_name;
            parameters[4].Value = casemodel.B_Case_code;
            parameters[5].Value = casemodel.B_Case_type;
            parameters[6].Value = casemodel.B_Case_nature;
            parameters[7].Value = casemodel.B_Case_customerType;
            parameters[8].Value = casemodel.B_Case_relationCode;
            parameters[9].Value = casemodel.B_Case_Stage;
            parameters[10].Value = casemodel.C_Project_code;
            parameters[11].Value = casemodel.C_Customer_code;
            parameters[12].Value = casemodel.C_Client_code;
            parameters[13].Value = casemodel.B_Case_Rival_code;
            parameters[14].Value = casemodel.C_Region_code;
            parameters[15].Value = casemodel.B_Case_number;
            parameters[16].Value = casemodel.B_Case_courtFirst;
            parameters[17].Value = casemodel.B_Case_transferTargetMoney;
            parameters[18].Value = casemodel.B_Case_execMoney2;
            parameters[19].Value = casemodel.B_Case_registerTime;
            parameters[20].Value = casemodel.B_Case_registerTime2;
            parameters[21].Value = casemodel.B_Case_state;
            parameters[22].Value = casemodel.B_Case_consultant_code;
            parameters[23].Value = userCode;
            parameters[24].Value = deptCode;
            parameters[25].Value = postCode;
            parameters[26].Value = model.M_Entry_Statistics_status;
            parameters[27].Value = casemodel.B_Case_expectedGrant;
            parameters[28].Value = casemodel.B_Case_expectedGrant2;
            parameters[29].Value = model.M_Entry_Statistics_HandlingState;
            parameters[30].Value = model.M_Entry_Statistics_Management;
            parameters[31].Value = model.M_Entry_Statistics_Management1;
            parameters[32].Value = model.M_Entry_name;
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
            parameters[0].Value = "M_Entry_Statistics";
            parameters[1].Value = "M_Entry_Statistics_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion
        #region  ExtensionMethod
        /// <summary>
        /// 根据条目获取统计信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public DataSet GetStatisticsByEntry(Guid guid)
        {
            string sql = "select * from M_Entry_Statistics where M_Entry_isDelete=0 and M_Entry_Statistics_status=397 and M_Entry_code=@M_Entry_code";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@M_Entry_code",SqlDbType.UniqueIdentifier,16)
            };
            return DbHelperSQL.Query(sql, para);
        }

        /// <summary>
        /// 根据条目获取统计信息(带律师，需要阶段GUID)
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public DataSet GetStatisticsByEntry(Guid guid, Guid flowGuid)
        {
            string sql = "select *,(select C_Userinfo_name from C_Userinfo cuser where cuser.C_Userinfo_code=(select top 1 P_Business_person from P_Business_flow flow where flow.P_Fk_code=";
            sql += "a.M_Case_code and flow.P_Business_isdelete=0 and flow.P_Flow_code=@P_Flow_code)) as 主办律师,";
            sql += "(select value=(STUFF((select ','+ convert(varchar(500),(select C_Userinfo_name from C_Userinfo where C_Userinfo_code=(x.P_Business_flow_form_person))) ";
            sql += "from P_Business_flow_form x where x.P_Business_flow_code=u.P_Business_flow_code  group by x.P_Business_flow_form_person for xml path('')),1,1,'')) ";
            sql += "from P_Business_flow_form u where u.P_Business_flow_code=(select top 1 P_Business_flow_code from P_Business_flow ";
            sql += "where P_Fk_code=a.M_Case_code and P_Flow_code=@P_Flow_code) group by  u.P_Business_flow_code ) as 协办律师,";
            sql += "(select C_Userinfo_Organization from C_Userinfo cuser where C_Userinfo_code=(select top 1 C_FK_Code from B_Case_link where B_Case_link_type=11 and B_Case_code=a.M_Case_code)) as 部门, ";
            sql += "(select C_Court_name from C_Court where C_Court_code=(select B_Case_courtFirst from B_Case where B_Case_code=a.M_Case_code)) as 一审管辖法院, ";
            sql += "(select C_Court_name from C_Court where C_Court_code=(select B_Case_courtSecond from B_Case where B_Case_code=a.M_Case_code)) as 二审管辖法院,* ";
            sql += " from M_Entry_Statistics a ";
            sql += " left join B_Case on B_Case.B_Case_code=a.M_Case_code";
            sql += " where M_Entry_Statistics_isDelete=0 and M_Entry_Statistics_status=397 and M_Entry_code=@M_Entry_code";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@M_Entry_code",SqlDbType.UniqueIdentifier,16),
                new SqlParameter("@P_Flow_code",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = guid;
            para[1].Value = flowGuid;
            return DbHelperSQL.Query(sql, para);
        }
        #endregion  ExtensionMethod

        #region App专用
        /// <summary>
        /// 根据条件获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="casemodel"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="IsPreSetManager"></param>
        /// <param name="rolePowerIds"></param>
        /// <param name="roleId"></param>
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public DataSet AppGetListByPage(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, int startIndex, int endIndex, bool IsPreSetManager, string rolePowerIds, int? roleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            #region 新sql
            StringBuilder strSql = new StringBuilder();
            //strSql.Append(" select * from (SELECT ROW_NUMBER() OVER (order by M_Entry_Statistics_id desc)AS Row,* FROM");
            strSql.Append(" SELECT T.*,E.M_Entry_name,E.M_Entry_Duration,E.M_Entry_warningType,E.M_Entry_warningDuration");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=M_Case_type) as M_Case_type_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=M_Entry_Statistics_HandlingState) as M_Entry_Statistics_HandlingState_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=M_Entry_Statistics_warningSituation) as M_Entry_Statistics_warningSituation_name");
            strSql.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=E.M_Entry_warningType) as M_Entry_warningType_name");
            strSql.Append(" from M_Entry_Statistics T");
            strSql.Append(" right join B_Case B on T.M_Case_code=B.B_Case_code and B.B_Case_isDelete=0");
            strSql.Append(" right join M_Entry as E on T.M_Entry_code=E.M_Entry_code and E.M_Entry_isDelete=0  where 1=1 and T.M_Entry_Statistics_isDelete=0 ");

            #region 数据权限处理，具体业务逻辑，请查询 C_Role_Power 表
            if (!IsPreSetManager)
            {//注意：内置系统管理员拥有所有数据权限，hety，2015-07-10
                StringBuilder strPowerSql = new StringBuilder();
                strPowerSql.Append(" and (1<>1 ");
                //if (rolePowerIds.Contains(",1,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //}
                //if (rolePowerIds.Contains(",2,"))
                //{
                //    strPowerSql.Append("or B.B_Case_person=@ThisUserCode ");
                //}
                //if (rolePowerIds.Contains(",3,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");
                //}
                //if (rolePowerIds.Contains(",4,"))
                //{
                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //    strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");

                //    strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                //    strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                //    strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                //}

                if (rolePowerIds.Contains(",5,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo As CU with(nolock) ");
                    strPowerSql.Append("where CU.C_Userinfo_isDelete=0 ");
                    strPowerSql.Append("and exists(select 1 from DeptTree(@ThisDeptCode) as DTree where DTree.C_Organization_code=CU.C_Userinfo_Organization) ");
                    strPowerSql.Append("and exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_isDelete=0 and BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.C_FK_code=CU.C_Userinfo_code) ");
                    strPowerSql.Append(") ");
                }
                if (rolePowerIds.Contains(",6,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=B.B_Case_code) ");

                }
                if (rolePowerIds.Contains(",7,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=B.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",8,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock),C_Userinfo_case_type As CRCT with(nolock) ");
                    strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=B.B_Case_code ");
                    strPowerSql.Append("and CRCT.C_Userinfo_code=@ThisUserCode ");
                    strPowerSql.Append("and CRR.C_Userinfo_code=CRCT.C_Userinfo_code ");
                    strPowerSql.Append("and CRCT.C_Parameters_id=B.B_Case_type) ");
                }
                if (rolePowerIds.Contains(",17,"))
                {
                    strPowerSql.Append("or exists(select 1 from C_ChiefExpert_Minister As CEM with(nolock) where CEM.C_ChiefExpert_Code=@ThisUserCode and B.B_Case_person=CEM.C_Minister_Code) ");
                }
                #region 只要当前登录人，是案件负责人，或者销售顾问，或者业务流程负责人或者表主办律师或者协办律师，就可以查看此案件
                //协办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock),P_Business_flow_form_user As BFFU with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_isdelete=0 and BFFU.P_Business_flow_form_code=BFF.P_Business_flow_form_code ");
                strPowerSql.Append("and BFFU.P_Business_flow_form_user_user=@ThisUserCode) ");
                //主办律师
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock),P_Business_flow_form As BFF with(nolock) ");
                strPowerSql.Append("where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and BFF.P_Business_flow_form_isdelete=0 and BFF.P_Business_flow_code=PBF.P_Business_flow_code ");
                strPowerSql.Append("and BFF.P_Business_flow_form_person=@ThisUserCode) ");
                //案件负责人
                strPowerSql.Append("or exists(select 1 from B_Case T1 where T1.B_Case_person=@ThisUserCode and T1.B_Case_code=B.B_Case_code) ");
                //销售顾问
                strPowerSql.Append("or exists(select 1 from B_Case_link As BCL with(nolock) where BCL.B_Case_link_type=11 and BCL.B_Case_code=B.B_Case_code and BCL.B_Case_link_isDelete=0 and BCL.C_FK_code=@ThisUserCode) ");
                //业务流程负责人
                strPowerSql.Append("or exists(select 1 from P_Business_flow AS PBF with(nolock) where PBF.P_Business_isdelete=0 and PBF.P_Fk_code=B.B_Case_code and PBF.P_Business_person=@ThisUserCode) ");

                #endregion

                strPowerSql.Append(") ");
                strSql.Append(strPowerSql.ToString());//附件权限sql到最外查询sql中
            }
            #endregion

            if (model != null)
            {
                if (model.M_Entry_name != null)
                {
                    strSql.Append("and E.M_Entry_name like N'%'+@M_Entry_name+'%' ");
                }
                if (model.M_Entry_Statistics_code != null && model.M_Entry_Statistics_code.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_Statistics_code=@M_Entry_Statistics_code ");
                }
                if (model.M_Case_code != null && model.M_Case_code.ToString() != "")
                {
                    strSql.Append("and T.M_Case_code=@M_Case_code ");
                }
                if (model.M_Entry_code != null && model.M_Entry_code.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_code=@M_Entry_code ");
                }
                if (model.M_Entry_Statistics_status != null && model.M_Entry_Statistics_status.ToString() != "")
                {
                    strSql.Append("and T.M_Entry_Statistics_status=@M_Entry_Statistics_status ");
                }
                else
                {
                    strSql.Append("and T.M_Entry_Statistics_status=397  ");
                }
                if (model.M_Entry_Statistics_HandlingState != null && model.M_Entry_Statistics_HandlingState.ToString() != "")
                {
                    strSql.Append(" and T.M_Entry_Statistics_HandlingState=@M_Entry_Statistics_HandlingState ");
                }
                if (model.M_Entry_Statistics_Management != null && model.M_Entry_Statistics_Management1 != null)
                {
                    strSql.Append(" and T.M_Entry_Statistics_Management between @M_Entry_Statistics_Management and @M_Entry_Statistics_Management1 ");
                }
            }
            if (casemodel != null)
            {
                //案件编码
                if (!string.IsNullOrEmpty(casemodel.B_Case_code.ToString()))
                {
                    strSql.Append(" and B.B_Case_code like N'%'+@B_Case_code+'%' ");

                }

                //案件名称
                if (casemodel.B_Case_name != null && casemodel.B_Case_name.ToString() != "")
                {
                    strSql.Append(" and B.B_Case_name like N'%'+@B_Case_name+'%' ");
                }
                //案件类型
                if (casemodel.B_Case_type != null && casemodel.B_Case_type.ToString() != "")
                {
                    strSql.Append("and B.B_Case_type =@B_Case_type ");
                }
                //案件性质
                if (casemodel.B_Case_nature != null && casemodel.B_Case_nature.ToString() != "")
                {
                    strSql.Append("and B.B_Case_nature =@B_Case_nature ");
                }
                //案件客户类型
                if (casemodel.B_Case_customerType != null && casemodel.B_Case_customerType.ToString() != "")
                {
                    strSql.Append("and B.B_Case_customerType =@B_Case_customerType ");
                }
                //案件状态
                if (casemodel.B_Case_state != null && casemodel.B_Case_state.ToString() != "")
                {
                    strSql.Append("and B.B_Case_state =@B_Case_state ");
                }
                //案件编码
                if (!string.IsNullOrEmpty(casemodel.B_Case_number))
                {
                    strSql.Append("and B.B_Case_number like N'%'+@B_Case_number+'%' ");
                }
                //专业顾问
                if (!string.IsNullOrEmpty(casemodel.B_Case_consultant_code.ToString()))
                {
                    strSql.Append(" and B.B_Case_consultant_code=@B_Case_consultant_code ");
                }

                if (!string.IsNullOrEmpty(casemodel.B_Case_courtFirst.ToString()))
                {
                    strSql.Append("and @B_Case_courtFirst in (B.B_Case_courtFirst,B.B_Case_courtSecond,B.B_Case_courtExec,B.B_Case_Trial) ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_transferTargetMoney.ToString())) && !string.IsNullOrEmpty(casemodel.B_Case_execMoney2.ToString()))
                {
                    strSql.Append("and B.B_Case_transferTargetMoney between @B_Case_execMoney and @B_Case_execMoney2 ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_registerTime.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_registerTime2.ToString())))
                {
                    strSql.Append("and B.B_Case_registerTime between convert(datetime,@B_Case_registerTime,120) and convert(datetime,@B_Case_registerTime2,120) ");
                }
                if ((!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant.ToString())) && (!string.IsNullOrEmpty(casemodel.B_Case_expectedGrant2.ToString())))
                {
                    strSql.Append("and B.B_Case_expectedGrant between @B_Case_expectedGrant and @B_Case_expectedGrant2 ");
                }

                //办案阶段限制
                if (!string.IsNullOrEmpty(casemodel.B_Case_Stage))
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow where P_Business_flow.P_Flow_code=@B_Case_Stage and P_Business_flow.P_Fk_code=B.B_Case_code and P_Business_flow.P_Business_isdelete=0)");
                }
                //工程
                if (!string.IsNullOrEmpty(casemodel.C_Project_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Project_code and B_Case_link.B_Case_link_type=7)");
                }
                //客户   委托人

                if (!string.IsNullOrEmpty(casemodel.C_Customer_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Customer_code and B_Case_link.B_Case_link_type=0)");
                }
                if (!string.IsNullOrEmpty(casemodel.C_Client_code))
                {//委托人
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Client_code and B_Case_link.B_Case_link_type=1)");
                }

                //对方当事人
                if (!string.IsNullOrEmpty(casemodel.B_Case_Rival_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@B_Case_Rival_code and (B_Case_link.B_Case_link_type=2 or B_Case_link.B_Case_link_type=3))");
                }
                //区域
                if (!String.IsNullOrEmpty(casemodel.C_Region_code))
                {
                    strSql.Append(" and exists(select 1 from B_Case_link where B_Case_link.B_Case_code=B.B_Case_code and B_Case_link.B_Case_link_isDelete=0 and B_Case_link.C_FK_code=@C_Region_code and B_Case_link.B_Case_link_type=6)");
                }


            }
            #endregion




            if (!string.IsNullOrEmpty(orderby))
            {
                strSql.Append(" order by " + orderby);
            }
            else
            {
                strSql.Append(" order by M_Entry_Statistics_id desc");
            }
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);
            SqlParameter[] parameters = {
					new SqlParameter("@M_Entry_Statistics_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@M_Entry_code", SqlDbType.UniqueIdentifier,16),
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
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar,200),
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
                    new SqlParameter("@M_Entry_Statistics_status", SqlDbType.Int,4),
                     new SqlParameter("@B_Case_expectedGrant", SqlDbType.Decimal,16),
                    new SqlParameter("@B_Case_expectedGrant2", SqlDbType.Decimal,16),
                    new SqlParameter("@M_Entry_Statistics_HandlingState",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_Statistics_Management1",SqlDbType.Int,4),
                    new SqlParameter("@M_Entry_name",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.M_Entry_Statistics_code;
            parameters[1].Value = model.M_Case_code;
            parameters[2].Value = model.M_Entry_code;
            parameters[3].Value = casemodel.B_Case_name;
            parameters[4].Value = casemodel.B_Case_code;
            parameters[5].Value = casemodel.B_Case_type;
            parameters[6].Value = casemodel.B_Case_nature;
            parameters[7].Value = casemodel.B_Case_customerType;
            parameters[8].Value = casemodel.B_Case_relationCode;
            parameters[9].Value = casemodel.B_Case_Stage;
            parameters[10].Value = casemodel.C_Project_code;
            parameters[11].Value = casemodel.C_Customer_code;
            parameters[12].Value = casemodel.C_Client_code;
            parameters[13].Value = casemodel.B_Case_Rival_code;
            parameters[14].Value = casemodel.C_Region_code;
            parameters[15].Value = casemodel.B_Case_number;
            parameters[16].Value = casemodel.B_Case_courtFirst;
            parameters[17].Value = casemodel.B_Case_transferTargetMoney;
            parameters[18].Value = casemodel.B_Case_execMoney2;
            parameters[19].Value = casemodel.B_Case_registerTime;
            parameters[20].Value = casemodel.B_Case_registerTime2;
            parameters[21].Value = casemodel.B_Case_state;
            parameters[22].Value = casemodel.B_Case_consultant_code;
            parameters[23].Value = userCode;
            parameters[24].Value = roleId;
            parameters[25].Value = deptCode;
            parameters[26].Value = postCode;
            parameters[27].Value = model.M_Entry_Statistics_status;
            parameters[28].Value = casemodel.B_Case_expectedGrant;
            parameters[29].Value = casemodel.B_Case_expectedGrant2;
            parameters[30].Value = model.M_Entry_Statistics_HandlingState;
            parameters[31].Value = model.M_Entry_Statistics_Management;
            parameters[32].Value = model.M_Entry_Statistics_Management1;
            parameters[33].Value = model.M_Entry_name;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion
    }
}

