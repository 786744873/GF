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
    /// 数据访问类:O_Teams5.	分组表	
    /// cyj
    /// 2015年7月14日15:58:16
    /// </summary>
    public partial class O_Teams
    {
        public O_Teams()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Teams_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Teams");
            strSql.Append(" where O_Teams_id=@O_Teams_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Teams_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Teams model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Teams(");
            strSql.Append("O_Teams_code,O_Teams_name,O_Teams_creator,O_Teams_createTime,O_Teams_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@O_Teams_code,@O_Teams_name,@O_Teams_creator,@O_Teams_createTime,@O_Teams_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_name", SqlDbType.NVarChar,100),
					new SqlParameter("@O_Teams_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.O_Teams_name;
            parameters[2].Value = Guid.NewGuid();
            parameters[3].Value = model.O_Teams_createTime;
            parameters[4].Value = model.O_Teams_isDelete;

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
        public bool Update(CommonService.Model.OA.O_Teams model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Teams set ");
            strSql.Append("O_Teams_code=@O_Teams_code,");
            strSql.Append("O_Teams_name=@O_Teams_name,");
            strSql.Append("O_Teams_creator=@O_Teams_creator,");
            strSql.Append("O_Teams_createTime=@O_Teams_createTime,");
            strSql.Append("O_Teams_isDelete=@O_Teams_isDelete");
            strSql.Append(" where O_Teams_id=@O_Teams_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_name", SqlDbType.NVarChar,100),
					new SqlParameter("@O_Teams_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Teams_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Teams_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Teams_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Teams_code;
            parameters[1].Value = model.O_Teams_name;
            parameters[2].Value = model.O_Teams_creator;
            parameters[3].Value = model.O_Teams_createTime;
            parameters[4].Value = model.O_Teams_isDelete;
            parameters[5].Value = model.O_Teams_id;

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
        public bool Delete(int O_Teams_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Teams ");
            strSql.Append(" where O_Teams_id=@O_Teams_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Teams_id;

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
        public bool DeleteList(string O_Teams_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Teams ");
            strSql.Append(" where O_Teams_id in (" + O_Teams_idlist + ")  ");
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
        public CommonService.Model.OA.O_Teams GetModel(int O_Teams_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Teams_id,O_Teams_code,O_Teams_name,O_Teams_creator,O_Teams_createTime,O_Teams_isDelete from O_Teams ");
            strSql.Append(" where O_Teams_id=@O_Teams_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Teams_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Teams_id;

            CommonService.Model.OA.O_Teams model = new CommonService.Model.OA.O_Teams();
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
        public CommonService.Model.OA.O_Teams DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Teams model = new CommonService.Model.OA.O_Teams();
            if (row != null)
            {
                if (row["O_Teams_id"] != null && row["O_Teams_id"].ToString() != "")
                {
                    model.O_Teams_id = int.Parse(row["O_Teams_id"].ToString());
                }
                if (row["O_Teams_code"] != null && row["O_Teams_code"].ToString() != "")
                {
                    model.O_Teams_code = new Guid(row["O_Teams_code"].ToString());
                }
                if (row["O_Teams_name"] != null)
                {
                    model.O_Teams_name = row["O_Teams_name"].ToString();
                }
                if (row["O_Teams_creator"] != null && row["O_Teams_creator"].ToString() != "")
                {
                    model.O_Teams_creator = new Guid(row["O_Teams_creator"].ToString());
                }
                if (row["O_Teams_createTime"] != null && row["O_Teams_createTime"].ToString() != "")
                {
                    model.O_Teams_createTime = DateTime.Parse(row["O_Teams_createTime"].ToString());
                }
                if (row["O_Teams_isDelete"] != null && row["O_Teams_isDelete"].ToString() != "")
                {
                    if ((row["O_Teams_isDelete"].ToString() == "1") || (row["O_Teams_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Teams_isDelete = true;
                    }
                    else
                    {
                        model.O_Teams_isDelete = false;
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
            strSql.Append("select O_Teams_id,O_Teams_code,O_Teams_name,O_Teams_creator,O_Teams_createTime,O_Teams_isDelete ");
            strSql.Append(" FROM O_Teams ");
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
            strSql.Append(" O_Teams_id,O_Teams_code,O_Teams_name,O_Teams_creator,O_Teams_createTime,O_Teams_isDelete ");
            strSql.Append(" FROM O_Teams ");
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
            strSql.Append("select count(1) FROM O_Teams ");
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
                strSql.Append("order by T.O_Teams_id desc");
            }
            strSql.Append(")AS Row, T.*  from O_Teams T ");
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
            parameters[0].Value = "O_Teams";
            parameters[1].Value = "O_Teams_id";
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
