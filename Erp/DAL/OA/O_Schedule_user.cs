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
    /// 数据访问类:O_Schedule_user日程用户中间表
    /// cyj
    /// 2015年7月14日17:09:41
    /// </summary>
    public partial class O_Schedule_user
    {
        public O_Schedule_user()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Schedule_user");
            strSql.Append(" where O_Schedule_code=@O_Schedule_code and C_userinfo_code=@C_userinfo_code and O_Schedule_creator=@O_Schedule_creator and O_Schedule_createTime=@O_Schedule_createTime and O_Schedule_isDelete=@O_Schedule_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Schedule_code;
            parameters[1].Value = C_userinfo_code;
            parameters[2].Value = O_Schedule_creator;
            parameters[3].Value = O_Schedule_createTime;
            parameters[4].Value = O_Schedule_isDelete;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.OA.O_Schedule_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Schedule_user(");
            strSql.Append("O_Schedule_code,C_userinfo_code,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@O_Schedule_code,@C_userinfo_code,@O_Schedule_creator,@O_Schedule_createTime,@O_Schedule_isDelete)");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.O_Schedule_code;
            parameters[1].Value = model.C_userinfo_code;
            parameters[2].Value = model.O_Schedule_creator;
            parameters[3].Value = model.O_Schedule_createTime;
            parameters[4].Value = model.O_Schedule_isDelete;

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
        public bool Update(CommonService.Model.OA.O_Schedule_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Schedule_user set ");
            strSql.Append("O_Schedule_code=@O_Schedule_code,");
            strSql.Append("C_userinfo_code=@C_userinfo_code,");
            strSql.Append("O_Schedule_creator=@O_Schedule_creator,");
            strSql.Append("O_Schedule_createTime=@O_Schedule_createTime,");
            strSql.Append("O_Schedule_isDelete=@O_Schedule_isDelete");
            strSql.Append(" where O_Schedule_code=@O_Schedule_code and C_userinfo_code=@C_userinfo_code and O_Schedule_creator=@O_Schedule_creator and O_Schedule_createTime=@O_Schedule_createTime and O_Schedule_isDelete=@O_Schedule_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.O_Schedule_code;
            parameters[1].Value = model.C_userinfo_code;
            parameters[2].Value = model.O_Schedule_creator;
            parameters[3].Value = model.O_Schedule_createTime;
            parameters[4].Value = model.O_Schedule_isDelete;

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
        public bool Delete(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Schedule_user ");
            strSql.Append(" where O_Schedule_code=@O_Schedule_code and C_userinfo_code=@C_userinfo_code and O_Schedule_creator=@O_Schedule_creator and O_Schedule_createTime=@O_Schedule_createTime and O_Schedule_isDelete=@O_Schedule_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Schedule_code;
            parameters[1].Value = C_userinfo_code;
            parameters[2].Value = O_Schedule_creator;
            parameters[3].Value = O_Schedule_createTime;
            parameters[4].Value = O_Schedule_isDelete;

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
        /// 通过日程Guid，删除关联日程用户数据
        /// </summary>
        public bool DeleteByScheduleCode(Guid scheduleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Schedule_user set O_Schedule_isDelete=1 ");
            strSql.Append("where O_Schedule_code=@O_Schedule_code");
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
        /// 通过日程Guid，获取日程用户集合
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        /// <returns></returns>
        public DataSet GetScheduleUsersByScheduleCode(Guid scheduleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from O_Schedule_user with(nolock) ");
            strSql.Append("where O_Schedule_code = @O_Schedule_code and O_Schedule_isDelete = 0 ");
           
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = scheduleCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        ///// <summary>
        ///// 通过用户Guid，获取集合
        ///// </summary>
        ///// <param name="scheduleCode">用户Guid</param>
        ///// <returns></returns>
        //public DataSet GetScheduleUsersByUserCode(Guid userCode)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from O_Schedule_user with(nolock) ");
        //    strSql.Append("where C_userinfo_code = @C_userinfo_code and O_Schedule_isDelete = 0 ");

        //    SqlParameter[] parameters = {
        //            new SqlParameter("@C_userinfo_code", SqlDbType.UniqueIdentifier,16)
        //    };
        //    parameters[0].Value = userCode;

        //    return DbHelperSQL.Query(strSql.ToString(), parameters);
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Schedule_user GetModel(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Schedule_code,C_userinfo_code,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete from O_Schedule_user ");
            strSql.Append(" where O_Schedule_code=@O_Schedule_code and C_userinfo_code=@C_userinfo_code and O_Schedule_creator=@O_Schedule_creator and O_Schedule_createTime=@O_Schedule_createTime and O_Schedule_isDelete=@O_Schedule_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Schedule_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Schedule_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Schedule_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Schedule_code;
            parameters[1].Value = C_userinfo_code;
            parameters[2].Value = O_Schedule_creator;
            parameters[3].Value = O_Schedule_createTime;
            parameters[4].Value = O_Schedule_isDelete;

            CommonService.Model.OA.O_Schedule_user model = new CommonService.Model.OA.O_Schedule_user();
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
        public CommonService.Model.OA.O_Schedule_user DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Schedule_user model = new CommonService.Model.OA.O_Schedule_user();
            if (row != null)
            {
                if (row["O_Schedule_code"] != null && row["O_Schedule_code"].ToString() != "")
                {
                    model.O_Schedule_code = new Guid(row["O_Schedule_code"].ToString());
                }
                if (row["C_userinfo_code"] != null && row["C_userinfo_code"].ToString() != "")
                {
                    model.C_userinfo_code = new Guid(row["C_userinfo_code"].ToString());
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
                //虚拟字段是否存在于集合中（参与者名称）
                if (row.Table.Columns.Contains("C_Userinfo_name"))
                {
                    if (row["C_Userinfo_name"] != null)
                    {
                        model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
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
            strSql.Append("select O_Schedule_code,C_userinfo_code,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete ");
            strSql.Append(" FROM O_Schedule_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得参与者数据列表
        /// </summary>
        public DataSet GetUserList(Guid O_Schedule_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select S.O_Schedule_code,S.C_userinfo_code,S.O_Schedule_creator,S.O_Schedule_createTime,S.O_Schedule_isDelete,U.C_Userinfo_name As C_Userinfo_name ");
            strSql.Append(" FROM O_Schedule_user As S ");
            strSql.Append(" left join C_Userinfo As U on S.C_userinfo_code=U.C_userinfo_code where S.O_Schedule_code=@O_Schedule_code ");
            strSql.Append(" and S.O_Schedule_isDelete=0 ");
            SqlParameter[] parameters = { 
                                        new SqlParameter("O_Schedule_code",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = O_Schedule_code;
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
            strSql.Append(" O_Schedule_code,C_userinfo_code,O_Schedule_creator,O_Schedule_createTime,O_Schedule_isDelete ");
            strSql.Append(" FROM O_Schedule_user ");
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
            strSql.Append("select count(1) FROM O_Schedule_user ");
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
                strSql.Append("order by T.O_Schedule_isDelete desc");
            }
            strSql.Append(")AS Row, T.*  from O_Schedule_user T ");
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
            parameters[0].Value = "O_Schedule_user";
            parameters[1].Value = "O_Schedule_isDelete";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  App专用

        #endregion  
    }
}
