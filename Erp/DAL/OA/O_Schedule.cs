using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.OA
{
    /// <summary>
    /// 1.	日程表  数据访问类:O_Schedule
    /// cyj   2015年7月14日15:04:14
    /// </summary>
    public partial class O_Schedule
    {
        public O_Schedule()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Schedule_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Schedule");
            strSql.Append(" where O_Schedule_id=@O_Schedule_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Schedule_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CommonService.Model.OA.O_Schedule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Schedule(");
            strSql.Append("O_Schedule_code,O_Schedule_title,O_Schedule_content,O_Schedule_startTime,O_Schedule_endTime,O_Schedule_remindType,O_Schedule_repeatType,O_Schedule_endCondition,O_Schedule_endRepeatDate,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete,O_Schedule_isAllDay,O_Schedule_isRepeat)");
            strSql.Append(" values (");
            strSql.Append("@O_Schedule_code,@O_Schedule_title,@O_Schedule_content,@O_Schedule_startTime,@O_Schedule_endTime,@O_Schedule_remindType,@O_Schedule_repeatType,@O_Schedule_endCondition,@O_Schedule_endRepeatDate,@O_Schedule_creator,@O_Schedule_createTime,@O_Schedule_isDelete,@O_Schedule_isAllDay,@O_Schedule_isRepeat)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_title", SqlDbType.NVarChar,100),
					new SqlParameter("@O_Schedule_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@O_Schedule_startTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_endTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_remindType", SqlDbType.Int,4),
					new SqlParameter("@O_Schedule_repeatType", SqlDbType.Int,4),
					new SqlParameter("@O_Schedule_endCondition", SqlDbType.Int,4),
					new SqlParameter("@O_Schedule_endRepeatDate", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_isDelete", SqlDbType.Bit,1),
                    new SqlParameter("@O_Schedule_isAllDay", SqlDbType.Bit,1),
                    new SqlParameter("@O_Schedule_isRepeat", SqlDbType.Bit,1)
                                        };
            parameters[0].Value = model.O_Schedule_code;
            parameters[1].Value = model.O_Schedule_title;
            parameters[2].Value = model.O_Schedule_content;
            parameters[3].Value = model.O_Schedule_startTime;
            parameters[4].Value = model.O_Schedule_endTime;
            parameters[5].Value = model.O_Schedule_remindType;
            parameters[6].Value = model.O_Schedule_repeatType;
            parameters[7].Value = model.O_Schedule_endCondition;
            parameters[8].Value = model.O_Schedule_endRepeatDate;
            parameters[9].Value = model.O_Schedule_creator;
            parameters[10].Value = model.O_Schedule_createTime;
            parameters[11].Value = model.O_Schedule_isDelete;
            parameters[12].Value = model.O_Schedule_isAllDay;
            parameters[13].Value = model.O_Schedule_isRepeat;

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
        public bool Update( CommonService.Model.OA.O_Schedule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Schedule set ");
            strSql.Append("O_Schedule_code=@O_Schedule_code,");
            strSql.Append("O_Schedule_title=@O_Schedule_title,");
            strSql.Append("O_Schedule_content=@O_Schedule_content,");
            strSql.Append("O_Schedule_startTime=@O_Schedule_startTime,");
            strSql.Append("O_Schedule_endTime=@O_Schedule_endTime,");
            strSql.Append("O_Schedule_remindType=@O_Schedule_remindType,");
            strSql.Append("O_Schedule_repeatType=@O_Schedule_repeatType,");
            strSql.Append("O_Schedule_endCondition=@O_Schedule_endCondition,");
            strSql.Append("O_Schedule_endRepeatDate=@O_Schedule_endRepeatDate,");
            strSql.Append("O_Schedule_creator=@O_Schedule_creator,");
            strSql.Append("O_Schedule_createTime=@O_Schedule_createTime,");
            strSql.Append("O_Schedule_isDelete=@O_Schedule_isDelete,");
            strSql.Append("O_Schedule_isAllDay=@O_Schedule_isAllDay,");
            strSql.Append("O_Schedule_isRepeat=@O_Schedule_isRepeat ");
            strSql.Append(" where O_Schedule_id=@O_Schedule_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_title", SqlDbType.NVarChar,100),
					new SqlParameter("@O_Schedule_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@O_Schedule_startTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_endTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_remindType", SqlDbType.Int,4),
					new SqlParameter("@O_Schedule_repeatType", SqlDbType.Int,4),
					new SqlParameter("@O_Schedule_endCondition", SqlDbType.Int,4),
					new SqlParameter("@O_Schedule_endRepeatDate", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_isDelete", SqlDbType.Bit,1),
                    new SqlParameter("@O_Schedule_isAllDay", SqlDbType.Bit,1),
                    new SqlParameter("@O_Schedule_isRepeat", SqlDbType.Bit,1),
					new SqlParameter("@O_Schedule_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Schedule_code;
            parameters[1].Value = model.O_Schedule_title;
            parameters[2].Value = model.O_Schedule_content;
            parameters[3].Value = model.O_Schedule_startTime;
            parameters[4].Value = model.O_Schedule_endTime;
            parameters[5].Value = model.O_Schedule_remindType;
            parameters[6].Value = model.O_Schedule_repeatType;
            parameters[7].Value = model.O_Schedule_endCondition;
            parameters[8].Value = model.O_Schedule_endRepeatDate;
            parameters[9].Value = model.O_Schedule_creator;
            parameters[10].Value = model.O_Schedule_createTime;
            parameters[11].Value = model.O_Schedule_isDelete;
            parameters[12].Value = model.O_Schedule_isAllDay;
            parameters[13].Value = model.O_Schedule_isRepeat;
            parameters[14].Value = model.O_Schedule_id;

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
        public bool Delete(Guid scheduleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Schedule set O_Schedule_isDelete = 1 ");
            strSql.Append(" where O_Schedule_code=@O_Schedule_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = scheduleCode;

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
        public bool DeleteList(string O_Schedule_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Schedule ");
            strSql.Append(" where O_Schedule_id in (" + O_Schedule_idlist + ")  ");
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
        public CommonService.Model.OA.O_Schedule GetModel(Guid scheduleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Schedule_id,O_Schedule_code,O_Schedule_title,O_Schedule_content,O_Schedule_startTime,O_Schedule_endTime,O_Schedule_remindType,O_Schedule_repeatType,O_Schedule_endCondition,O_Schedule_endRepeatDate,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete,O_Schedule_isAllDay,O_Schedule_isRepeat from O_Schedule ");
            strSql.Append(" where O_Schedule_code=@O_Schedule_code and O_Schedule_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = scheduleCode;

             CommonService.Model.OA.O_Schedule model = new  CommonService.Model.OA.O_Schedule();
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
        public  CommonService.Model.OA.O_Schedule DataRowToModel(DataRow row)
        {
           
             CommonService.Model.OA.O_Schedule model = new  CommonService.Model.OA.O_Schedule();
            if (row != null)
            {
                if (row["O_Schedule_id"] != null && row["O_Schedule_id"].ToString() != "")
                {
                    model.O_Schedule_id = int.Parse(row["O_Schedule_id"].ToString());
                }
                if (row["O_Schedule_code"] != null && row["O_Schedule_code"].ToString() != "")
                {
                    model.O_Schedule_code = new Guid(row["O_Schedule_code"].ToString());
                }
                if (row["O_Schedule_title"] != null)
                {
                    model.O_Schedule_title = row["O_Schedule_title"].ToString();
                }
                if (row["O_Schedule_content"] != null)
                {
                    model.O_Schedule_content = row["O_Schedule_content"].ToString();
                }
                if (row["O_Schedule_startTime"] != null && row["O_Schedule_startTime"].ToString() != "")
                {
                    model.O_Schedule_startTime = DateTime.Parse(row["O_Schedule_startTime"].ToString());
                }
                if (row["O_Schedule_endTime"] != null && row["O_Schedule_endTime"].ToString() != "")
                {
                    model.O_Schedule_endTime = DateTime.Parse(row["O_Schedule_endTime"].ToString());
                }
                if (row["O_Schedule_remindType"] != null && row["O_Schedule_remindType"].ToString() != "")
                {
                    model.O_Schedule_remindType = int.Parse(row["O_Schedule_remindType"].ToString());
                }
                if (row["O_Schedule_repeatType"] != null && row["O_Schedule_repeatType"].ToString() != "")
                {
                    model.O_Schedule_repeatType = int.Parse(row["O_Schedule_repeatType"].ToString());
                }
                if (row["O_Schedule_endCondition"] != null && row["O_Schedule_endCondition"].ToString() != "")
                {
                    model.O_Schedule_endCondition = int.Parse(row["O_Schedule_endCondition"].ToString());
                }
                if (row["O_Schedule_endRepeatDate"] != null && row["O_Schedule_endRepeatDate"].ToString() != "")
                {
                    model.O_Schedule_endRepeatDate = DateTime.Parse(row["O_Schedule_endRepeatDate"].ToString());
                }
                if (row["O_Schedule_creator"] != null && row["O_Schedule_creator"].ToString() != "")
                {
                    model.O_Schedule_creator = new Guid(row["O_Schedule_creator"].ToString());
                }
                if (row["O_Schedule_createTime"] != null && row["O_Schedule_createTime"].ToString() != "")
                {
                    model.O_Schedule_createTime = DateTime.Parse(row["O_Schedule_createTime"].ToString());
                }
                if (row["O_Schedule_isDelete"] != null && row["O_Schedule_isDelete"].ToString() != "")
                {
                    if ((row["O_Schedule_isDelete"].ToString() == "1") || (row["O_Schedule_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Schedule_isDelete = true;
                    }
                    else
                    {
                        model.O_Schedule_isDelete = false;
                    }
                }
                //日程所属类型(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("ScheduleBelongType"))
                {
                    if (row["ScheduleBelongType"] != null && row["ScheduleBelongType"].ToString() != "")
                    {
                        model.ScheduleBelongType = int.Parse(row["ScheduleBelongType"].ToString());
                    }
                }
                if (row["O_Schedule_isAllDay"] != null && row["O_Schedule_isAllDay"].ToString() != "")
                {
                    if ((row["O_Schedule_isAllDay"].ToString() == "1") || (row["O_Schedule_isAllDay"].ToString().ToLower() == "true"))
                    {
                        model.O_Schedule_isAllDay = true;
                    }
                    else
                    {
                        model.O_Schedule_isAllDay = false;
                    }
                }
                if (row["O_Schedule_isRepeat"] != null && row["O_Schedule_isRepeat"].ToString() != "")
                {
                    if ((row["O_Schedule_isRepeat"].ToString() == "1") || (row["O_Schedule_isRepeat"].ToString().ToLower() == "true"))
                    {
                        model.O_Schedule_isRepeat = true;
                    }
                    else
                    {
                        model.O_Schedule_isRepeat = false;
                    }
                }
                if (row.Table.Columns.Contains("C_Messages_id"))
                {
                    if (row["C_Messages_id"] != null && row["C_Messages_id"].ToString() != "")
                    {
                        model.C_Messages_id = int.Parse(row["C_Messages_id"].ToString());
                    }
                }
                //日程类型
                if (row.Table.Columns.Contains("O_Schedule_remindTypename"))
                {
                    if (row["O_Schedule_remindTypename"] != null && row["O_Schedule_remindTypename"].ToString() != "")
                    {
                        model.O_Schedule_remindTypename = row["O_Schedule_remindTypename"].ToString();
                    }
                }

                if (row.Table.Columns.Contains("O_schedule_isread") && row["O_schedule_isread"]!=null)
                {
                    if ((row["O_schedule_isread"].ToString() == "1") || (row["O_schedule_isread"].ToString().ToLower() == "true"))
                    {
                        model.O_schedule_isread = true;
                    }
                    else
                    {
                        model.O_schedule_isread = false;
                    }
                }
                
            }
            return model;
        }

        /// <summary>
        /// 获得全部数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Schedule_id,O_Schedule_code,O_Schedule_title,O_Schedule_content,O_Schedule_startTime,O_Schedule_endTime,O_Schedule_remindType,O_Schedule_repeatType,O_Schedule_endCondition,O_Schedule_endRepeatDate,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete,O_Schedule_isAllDay,O_Schedule_isRepeat ");
            strSql.Append("FROM O_Schedule  ");
            strSql.Append("where O_Schedule_isDelete =0 ");
        
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得全部提醒的数据列表
        /// </summary>
        public DataSet GetAllremindList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Schedule_id,O_Schedule_code,O_Schedule_title,O_Schedule_content,O_Schedule_startTime,O_Schedule_endTime,O_Schedule_remindType,O_Schedule_repeatType,O_Schedule_endCondition,O_Schedule_endRepeatDate,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete,O_Schedule_isAllDay,O_Schedule_isRepeat ");
            strSql.Append("FROM O_Schedule  ");
            strSql.Append("where O_Schedule_isDelete =0 and O_Schedule_remindType!='475'");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 通过根用户，获取所有列表
        /// </summary>
        /// <param name="rootUserCode">根用户Guid</param>
        /// <returns></returns>
        public DataSet GetListByRootUserCode(Guid rootUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select S.*,case when S.O_Schedule_creator=@rootUserCode then 1 else 0 end as ScheduleBelongType ");
            strSql.Append("FROM O_Schedule As S with(nolock) ");
            strSql.Append("where S.O_Schedule_isDelete = 0 ");
            strSql.Append("and exists(select 1 from O_Schedule_user As SU with(nolock) where S.O_Schedule_code = SU.O_Schedule_code and SU.O_Schedule_isDelete = 0 and SU.C_userinfo_code = @rootUserCode )");

            SqlParameter[] parameters = {
					new SqlParameter("@rootUserCode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = rootUserCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            strSql.Append(" O_Schedule_id,O_Schedule_code,O_Schedule_title,O_Schedule_content,O_Schedule_startTime,O_Schedule_endTime,O_Schedule_remindType,O_Schedule_repeatType,O_Schedule_endCondition,O_Schedule_endRepeatDate,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete ");
            strSql.Append(" FROM O_Schedule ");
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
            strSql.Append("select count(1) FROM O_Schedule ");
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
                strSql.Append("order by T.O_Schedule_id desc");
            }
            strSql.Append(")AS Row, T.*  from O_Schedule T ");
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
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "O_Schedule";
            parameters[1].Value = "O_Schedule_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        /// <summary>
        /// 通过用户guid获得未读取的日程消息全部数据列表
        /// </summary>
        public DataSet GetMsgListByUsercode(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Schedule_id,A.O_Schedule_code As O_Schedule_code,O_Schedule_title,O_Schedule_content,O_Schedule_startTime,O_Schedule_endTime,O_Schedule_remindType,O_Schedule_repeatType,O_Schedule_endCondition,O_Schedule_endRepeatDate,A.O_Schedule_creator As O_Schedule_creator,A.O_Schedule_createTime As O_Schedule_createTime,  A.O_Schedule_isDelete As O_Schedule_isDelete,O_Schedule_isAllDay,O_Schedule_isRepeat,C.C_Messages_id As C_Messages_id ");
            strSql.Append("FROM O_Schedule  As A left join O_Schedule_user As B on A.O_Schedule_code=B.O_Schedule_code left join C_Messages As C on A.O_Schedule_code=C.C_Messages_link ");
            strSql.Append("where A.O_Schedule_isDelete =0 and B.O_Schedule_isDelete=0 and C.C_Messages_isRead=0 and B.C_userinfo_code=@C_userinfo_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_userinfo_code", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = userCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion  BasicMethod

        #region  App专用
        /// <summary>
        /// 根据用户GUID和日期获取日程
        /// </summary>
        /// <param name="userCode">用户GUID</param>
        /// <param name="dt">日期</param>
        /// <returns>日程列表</returns>
        public DataSet GetListByDateAndUser(Guid? userCode, DateTime dt)
        {
            string sql = "select *,(select C_Parameters_name from C_Parameters where C_Parameters_id=a.O_Schedule_remindType)as O_Schedule_remindTypename from O_Schedule a where  CONVERT(varchar(100),O_Schedule_endTime,23)=@dt and  CONVERT(varchar(100),O_Schedule_startTime,23)=@dt and O_Schedule_isDelete=0 and exists(select 1 from O_Schedule_user b where b.O_Schedule_code=a.O_Schedule_code and b.O_Schedule_isDelete=0 and C_userinfo_code=@guid)";
            SqlParameter[] parameters = {
                    new SqlParameter("@dt",SqlDbType.DateTime),
                    new SqlParameter("@guid", SqlDbType.UniqueIdentifier, 16)
                    };
            parameters[0].Value = dt.ToShortDateString();
            parameters[1].Value = userCode;
            return DbHelperSQL.Query(sql, parameters);
        }

        /// <summary>
        /// 获取所有日程（包含已读未读属性）
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByUserAndMessages(Guid? userCode,int startIndex,int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_Schedule_id,A.O_Schedule_code As O_Schedule_code,O_Schedule_title,O_Schedule_content,O_Schedule_startTime,O_Schedule_endTime,O_Schedule_remindType,O_Schedule_repeatType,O_Schedule_endCondition,O_Schedule_endRepeatDate,A.O_Schedule_creator As O_Schedule_creator,A.O_Schedule_createTime As O_Schedule_createTime,  A.O_Schedule_isDelete As O_Schedule_isDelete,O_Schedule_isAllDay,O_Schedule_isRepeat,C.C_Messages_id As C_Messages_id,C.C_Messages_isRead as O_schedule_isread ");
            strSql.Append("FROM O_Schedule  As A left join O_Schedule_user As B on A.O_Schedule_code=B.O_Schedule_code right join C_Messages As C on A.O_Schedule_code=C.C_Messages_link ");
            strSql.Append("where A.O_Schedule_isDelete =0 and B.O_Schedule_isDelete=0 and B.C_userinfo_code=@C_userinfo_code order by C.C_Messages_isRead,A.O_Schedule_startTime desc");
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);
            SqlParameter[] parameters = {
                    new SqlParameter("@C_userinfo_code", SqlDbType.UniqueIdentifier, 16),
                    };
            parameters[0].Value = userCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion 
    }
}
