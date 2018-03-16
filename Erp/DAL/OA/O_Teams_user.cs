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
    /// 数据访问类:O_Teams_user分组用户中间表
    /// cyj
    /// 2015年7月14日17:09:21
    /// </summary>
    public partial class O_Teams_user
    {
        public O_Teams_user()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Teams_user");
            strSql.Append(" where O_Teams_user_id=@O_Teams_user_id and O_Teams_code=@O_Teams_code and C_Userinfo_code=@C_Userinfo_code and O_Teams_user_isManager=@O_Teams_user_isManager and O_Teams_user_inTime=@O_Teams_user_inTime and O_Teams_user_creator=@O_Teams_user_creator and O_Teams_user_createTime=@O_Teams_user_createTime and O_Teams_user_isDelete=@O_Teams_user_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_user_id", SqlDbType.Int,4),
					new SqlParameter("@O_Teams_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_isManager", SqlDbType.Bit,1),
					new SqlParameter("@O_Teams_user_inTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Teams_user_id;
            parameters[1].Value = O_Teams_code;
            parameters[2].Value = C_Userinfo_code;
            parameters[3].Value = O_Teams_user_isManager;
            parameters[4].Value = O_Teams_user_inTime;
            parameters[5].Value = O_Teams_user_creator;
            parameters[6].Value = O_Teams_user_createTime;
            parameters[7].Value = O_Teams_user_isDelete;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.OA.O_Teams_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Teams_user(");
            strSql.Append("O_Teams_user_id,O_Teams_code,C_Userinfo_code,O_Teams_user_isManager,O_Teams_user_inTime,O_Teams_user_creator,O_Teams_user_createTime,O_Teams_user_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@O_Teams_user_id,@O_Teams_code,@C_Userinfo_code,@O_Teams_user_isManager,@O_Teams_user_inTime,@O_Teams_user_creator,@O_Teams_user_createTime,@O_Teams_user_isDelete)");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_user_id", SqlDbType.Int,4),
					new SqlParameter("@O_Teams_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_isManager", SqlDbType.Bit,1),
					new SqlParameter("@O_Teams_user_inTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.O_Teams_user_id;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = Guid.NewGuid();
            parameters[3].Value = model.O_Teams_user_isManager;
            parameters[4].Value = model.O_Teams_user_inTime;
            parameters[5].Value = Guid.NewGuid();
            parameters[6].Value = model.O_Teams_user_createTime;
            parameters[7].Value = model.O_Teams_user_isDelete;

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
        public bool Update(CommonService.Model.OA.O_Teams_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Teams_user set ");
            strSql.Append("O_Teams_user_id=@O_Teams_user_id,");
            strSql.Append("O_Teams_code=@O_Teams_code,");
            strSql.Append("C_Userinfo_code=@C_Userinfo_code,");
            strSql.Append("O_Teams_user_isManager=@O_Teams_user_isManager,");
            strSql.Append("O_Teams_user_inTime=@O_Teams_user_inTime,");
            strSql.Append("O_Teams_user_creator=@O_Teams_user_creator,");
            strSql.Append("O_Teams_user_createTime=@O_Teams_user_createTime,");
            strSql.Append("O_Teams_user_isDelete=@O_Teams_user_isDelete");
            strSql.Append(" where O_Teams_user_id=@O_Teams_user_id and O_Teams_code=@O_Teams_code and C_Userinfo_code=@C_Userinfo_code and O_Teams_user_isManager=@O_Teams_user_isManager and O_Teams_user_inTime=@O_Teams_user_inTime and O_Teams_user_creator=@O_Teams_user_creator and O_Teams_user_createTime=@O_Teams_user_createTime and O_Teams_user_isDelete=@O_Teams_user_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_user_id", SqlDbType.Int,4),
					new SqlParameter("@O_Teams_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_isManager", SqlDbType.Bit,1),
					new SqlParameter("@O_Teams_user_inTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.O_Teams_user_id;
            parameters[1].Value = model.O_Teams_code;
            parameters[2].Value = model.C_Userinfo_code;
            parameters[3].Value = model.O_Teams_user_isManager;
            parameters[4].Value = model.O_Teams_user_inTime;
            parameters[5].Value = model.O_Teams_user_creator;
            parameters[6].Value = model.O_Teams_user_createTime;
            parameters[7].Value = model.O_Teams_user_isDelete;

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
        public bool Delete(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Teams_user ");
            strSql.Append(" where O_Teams_user_id=@O_Teams_user_id and O_Teams_code=@O_Teams_code and C_Userinfo_code=@C_Userinfo_code and O_Teams_user_isManager=@O_Teams_user_isManager and O_Teams_user_inTime=@O_Teams_user_inTime and O_Teams_user_creator=@O_Teams_user_creator and O_Teams_user_createTime=@O_Teams_user_createTime and O_Teams_user_isDelete=@O_Teams_user_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_user_id", SqlDbType.Int,4),
					new SqlParameter("@O_Teams_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_isManager", SqlDbType.Bit,1),
					new SqlParameter("@O_Teams_user_inTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Teams_user_id;
            parameters[1].Value = O_Teams_code;
            parameters[2].Value = C_Userinfo_code;
            parameters[3].Value = O_Teams_user_isManager;
            parameters[4].Value = O_Teams_user_inTime;
            parameters[5].Value = O_Teams_user_creator;
            parameters[6].Value = O_Teams_user_createTime;
            parameters[7].Value = O_Teams_user_isDelete;

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
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Teams_user GetModel(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Teams_user_id,O_Teams_code,C_Userinfo_code,O_Teams_user_isManager,O_Teams_user_inTime,O_Teams_user_creator,O_Teams_user_createTime,O_Teams_user_isDelete from O_Teams_user ");
            strSql.Append(" where O_Teams_user_id=@O_Teams_user_id and O_Teams_code=@O_Teams_code and C_Userinfo_code=@C_Userinfo_code and O_Teams_user_isManager=@O_Teams_user_isManager and O_Teams_user_inTime=@O_Teams_user_inTime and O_Teams_user_creator=@O_Teams_user_creator and O_Teams_user_createTime=@O_Teams_user_createTime and O_Teams_user_isDelete=@O_Teams_user_isDelete ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_user_id", SqlDbType.Int,4),
					new SqlParameter("@O_Teams_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_isManager", SqlDbType.Bit,1),
					new SqlParameter("@O_Teams_user_inTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_user_isDelete", SqlDbType.Bit,1)			};
            parameters[0].Value = O_Teams_user_id;
            parameters[1].Value = O_Teams_code;
            parameters[2].Value = C_Userinfo_code;
            parameters[3].Value = O_Teams_user_isManager;
            parameters[4].Value = O_Teams_user_inTime;
            parameters[5].Value = O_Teams_user_creator;
            parameters[6].Value = O_Teams_user_createTime;
            parameters[7].Value = O_Teams_user_isDelete;

            CommonService.Model.OA.O_Teams_user model = new CommonService.Model.OA.O_Teams_user();
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
        public CommonService.Model.OA.O_Teams_user DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Teams_user model = new CommonService.Model.OA.O_Teams_user();
            if (row != null)
            {
                if (row["O_Teams_user_id"] != null && row["O_Teams_user_id"].ToString() != "")
                {
                    model.O_Teams_user_id = int.Parse(row["O_Teams_user_id"].ToString());
                }
                if (row["O_Teams_code"] != null && row["O_Teams_code"].ToString() != "")
                {
                    model.O_Teams_code = new Guid(row["O_Teams_code"].ToString());
                }
                if (row["C_Userinfo_code"] != null && row["C_Userinfo_code"].ToString() != "")
                {
                    model.C_Userinfo_code = new Guid(row["C_Userinfo_code"].ToString());
                }
                if (row["O_Teams_user_isManager"] != null && row["O_Teams_user_isManager"].ToString() != "")
                {
                    if ((row["O_Teams_user_isManager"].ToString() == "1") || (row["O_Teams_user_isManager"].ToString().ToLower() == "true"))
                    {
                        model.O_Teams_user_isManager = true;
                    }
                    else
                    {
                        model.O_Teams_user_isManager = false;
                    }
                }
                if (row["O_Teams_user_inTime"] != null && row["O_Teams_user_inTime"].ToString() != "")
                {
                    model.O_Teams_user_inTime = DateTime.Parse(row["O_Teams_user_inTime"].ToString());
                }
                if (row["O_Teams_user_creator"] != null && row["O_Teams_user_creator"].ToString() != "")
                {
                    model.O_Teams_user_creator = new Guid(row["O_Teams_user_creator"].ToString());
                }
                if (row["O_Teams_user_createTime"] != null && row["O_Teams_user_createTime"].ToString() != "")
                {
                    model.O_Teams_user_createTime = DateTime.Parse(row["O_Teams_user_createTime"].ToString());
                }
                if (row["O_Teams_user_isDelete"] != null && row["O_Teams_user_isDelete"].ToString() != "")
                {
                    if ((row["O_Teams_user_isDelete"].ToString() == "1") || (row["O_Teams_user_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Teams_user_isDelete = true;
                    }
                    else
                    {
                        model.O_Teams_user_isDelete = false;
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
            strSql.Append("select O_Teams_user_id,O_Teams_code,C_Userinfo_code,O_Teams_user_isManager,O_Teams_user_inTime,O_Teams_user_creator,O_Teams_user_createTime,O_Teams_user_isDelete ");
            strSql.Append(" FROM O_Teams_user ");
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
            strSql.Append(" O_Teams_user_id,O_Teams_code,C_Userinfo_code,O_Teams_user_isManager,O_Teams_user_inTime,O_Teams_user_creator,O_Teams_user_createTime,O_Teams_user_isDelete ");
            strSql.Append(" FROM O_Teams_user ");
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
            strSql.Append("select count(1) FROM O_Teams_user ");
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
                strSql.Append("order by T.O_Teams_user_isDelete desc");
            }
            strSql.Append(")AS Row, T.*  from O_Teams_user T ");
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
            parameters[0].Value = "O_Teams_user";
            parameters[1].Value = "O_Teams_user_isDelete";
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
