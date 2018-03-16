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
    /// 数据访问类:流程表
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_Flow
    {
        public O_Flow()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("O_Flow_id", "O_Flow");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Flow_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Flow");
            strSql.Append(" where O_Flow_id=@O_Flow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Flow_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Flow_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Flow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Flow(");
            strSql.Append("O_Flow_code,O_Flow_name,O_Flow_isFree,O_Flow_isDelete,O_Flow_creator,O_Flow_createTime)");
            strSql.Append(" values (");
            strSql.Append("@O_Flow_code,@O_Flow_name,@O_Flow_isFree,@O_Flow_isDelete,@O_Flow_creator,@O_Flow_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Flow_name", SqlDbType.NVarChar,50),
					new SqlParameter("@O_Flow_isFree", SqlDbType.Bit,1),
					new SqlParameter("@O_Flow_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Flow_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Flow_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.O_Flow_code;
            parameters[1].Value = model.O_Flow_name;
            parameters[2].Value = model.O_Flow_isFree;
            parameters[3].Value = model.O_Flow_isDelete;
            parameters[4].Value = model.O_Flow_creator;
            parameters[5].Value = model.O_Flow_createTime;

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
        public bool Update(CommonService.Model.OA.O_Flow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Flow set ");
            strSql.Append("O_Flow_code=@O_Flow_code,");
            strSql.Append("O_Flow_name=@O_Flow_name,");
            strSql.Append("O_Flow_isFree=@O_Flow_isFree,");
            strSql.Append("O_Flow_isDelete=@O_Flow_isDelete,");
            strSql.Append("O_Flow_creator=@O_Flow_creator,");
            strSql.Append("O_Flow_createTime=@O_Flow_createTime");
            strSql.Append(" where O_Flow_id=@O_Flow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Flow_name", SqlDbType.NVarChar,50),
					new SqlParameter("@O_Flow_isFree", SqlDbType.Bit,1),
					new SqlParameter("@O_Flow_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Flow_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Flow_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Flow_id", SqlDbType.Int,4)};
            parameters[0].Value = model.O_Flow_code;
            parameters[1].Value = model.O_Flow_name;
            parameters[2].Value = model.O_Flow_isFree;
            parameters[3].Value = model.O_Flow_isDelete;
            parameters[4].Value = model.O_Flow_creator;
            parameters[5].Value = model.O_Flow_createTime;
            parameters[6].Value = model.O_Flow_id;

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
        public bool Delete(Guid O_Flow_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Flow set O_Flow_isDelete = 1 ");
            strSql.Append(" where O_Flow_code=@O_Flow_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Flow_code;

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
        public bool DeleteList(string O_Flow_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Flow ");
            strSql.Append(" where O_Flow_id in (" + O_Flow_idlist + ")  ");
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
        public CommonService.Model.OA.O_Flow GetModel(Guid O_Flow_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Flow_id,O_Flow_code,O_Flow_name,O_Flow_isFree,O_Flow_isDelete,O_Flow_creator,O_Flow_createTime from O_Flow ");
            strSql.Append(" where O_Flow_code=@O_Flow_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Flow_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Flow_code;

            CommonService.Model.OA.O_Flow model = new CommonService.Model.OA.O_Flow();
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
        public CommonService.Model.OA.O_Flow DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Flow model = new CommonService.Model.OA.O_Flow();
            if (row != null)
            {
                if (row["O_Flow_id"] != null && row["O_Flow_id"].ToString() != "")
                {
                    model.O_Flow_id = int.Parse(row["O_Flow_id"].ToString());
                }
                if (row["O_Flow_code"] != null && row["O_Flow_code"].ToString() != "")
                {
                    model.O_Flow_code = new Guid(row["O_Flow_code"].ToString());
                }
                if (row["O_Flow_name"] != null)
                {
                    model.O_Flow_name = row["O_Flow_name"].ToString();
                }
                if (row["O_Flow_isFree"] != null && row["O_Flow_isFree"].ToString() != "")
                {
                    if ((row["O_Flow_isFree"].ToString() == "1") || (row["O_Flow_isFree"].ToString().ToLower() == "true"))
                    {
                        model.O_Flow_isFree = true;
                    }
                    else
                    {
                        model.O_Flow_isFree = false;
                    }
                }
                if (row["O_Flow_isDelete"] != null && row["O_Flow_isDelete"].ToString() != "")
                {
                    if ((row["O_Flow_isDelete"].ToString() == "1") || (row["O_Flow_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Flow_isDelete = true;
                    }
                    else
                    {
                        model.O_Flow_isDelete = false;
                    }
                }
                if (row["O_Flow_creator"] != null && row["O_Flow_creator"].ToString() != "")
                {
                    model.O_Flow_creator = new Guid(row["O_Flow_creator"].ToString());
                }
                if (row["O_Flow_createTime"] != null && row["O_Flow_createTime"].ToString() != "")
                {
                    model.O_Flow_createTime = DateTime.Parse(row["O_Flow_createTime"].ToString());
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
            strSql.Append("select O_Flow_id,O_Flow_code,O_Flow_name,O_Flow_isFree,O_Flow_isDelete,O_Flow_creator,O_Flow_createTime ");
            strSql.Append(" FROM O_Flow ");
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
            strSql.Append(" O_Flow_id,O_Flow_code,O_Flow_name,O_Flow_isFree,O_Flow_isDelete,O_Flow_creator,O_Flow_createTime ");
            strSql.Append(" FROM O_Flow ");
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
        public int GetRecordCount(CommonService.Model.OA.O_Flow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM O_Flow ");
            strSql.Append(" where 1=1 and O_Flow_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Flow_name != null)
                {
                    strSql.Append(" and O_Flow_name  like N'%'+@O_Flow_name+'%' ");
                }
            }
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Flow_name", SqlDbType.NVarChar,200),
                                        };
            parameters[0].Value = model.O_Flow_name;
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
        public DataSet GetListByPage(CommonService.Model.OA.O_Flow model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.O_Flow_createTime desc");
            }
            strSql.Append(")AS Row, T.*  from O_Flow T ");
            strSql.Append(" where 1=1 and O_Flow_isDelete=0 ");
            if (model != null)
            {
                if (model.O_Flow_name != null)
                {
                    strSql.Append(" and O_Flow_name like N'%'+@O_Flow_name+'%' ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {					 
					new SqlParameter("@O_Flow_name", SqlDbType.NVarChar,200),
                                        };
            parameters[0].Value = model.O_Flow_name;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
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
            parameters[0].Value = "O_Flow";
            parameters[1].Value = "O_Flow_id";
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
