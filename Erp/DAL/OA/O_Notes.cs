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
    /// 数据访问类:O_Notes
    /// 便签表
    /// cyj
    /// 2015年7月14日17:09:58
    /// </summary>
    public partial class O_Notes
    {
        public O_Notes()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Notes_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from O_Notes");
            strSql.Append(" where O_Notes_id=@O_Notes_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Notes_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Notes_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Notes model)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into O_Notes(");
            strSql.Append("O_Notes_code,O_Notes_person,O_Notes_creator,O_Notes_createTime,O_Notes_isDelete,O_Notes_content)");
            strSql.Append(" values (");
            strSql.Append("@O_Notes_code,@O_Notes_person,@O_Notes_creator,@O_Notes_createTime,@O_Notes_isDelete,@O_Notes_content)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Notes_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Notes_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Notes_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Notes_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Notes_isDelete", SqlDbType.Bit,1),
                    new SqlParameter("@O_Notes_content", SqlDbType.Text,5000),                    
                                        };
            parameters[0].Value = model.O_Notes_code;
            parameters[1].Value = model.O_Notes_person;
            parameters[2].Value = model.O_Notes_creator;
            parameters[3].Value = model.O_Notes_createTime;
            parameters[4].Value = model.O_Notes_isDelete;
            parameters[5].Value = model.O_Notes_content;
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
        public bool Update(CommonService.Model.OA.O_Notes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update O_Notes set ");
            strSql.Append("O_Notes_code=@O_Notes_code,");
            strSql.Append("O_Notes_person=@O_Notes_person,");
            strSql.Append("O_Notes_creator=@O_Notes_creator,");
            strSql.Append("O_Notes_createTime=@O_Notes_createTime,");
            strSql.Append("O_Notes_isDelete=@O_Notes_isDelete,");
            strSql.Append("O_Notes_content=@O_Notes_content");
            strSql.Append(" where O_Notes_id=@O_Notes_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Notes_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Notes_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Notes_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@O_Notes_createTime", SqlDbType.DateTime),
					new SqlParameter("@O_Notes_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@O_Notes_id", SqlDbType.Int,4),
                    new SqlParameter("@O_Notes_content", SqlDbType.Text,5000)
                                        };
            parameters[0].Value = model.O_Notes_code;
            parameters[1].Value = model.O_Notes_person;
            parameters[2].Value = model.O_Notes_creator;
            parameters[3].Value = model.O_Notes_createTime;
            parameters[4].Value = model.O_Notes_isDelete;
            parameters[5].Value = model.O_Notes_id;
            parameters[6].Value = model.O_Notes_content;
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
        public bool Delete(int O_Notes_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Notes ");
            strSql.Append(" where O_Notes_id=@O_Notes_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Notes_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Notes_id;

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
        public bool DeleteList(string O_Notes_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from O_Notes ");
            strSql.Append(" where O_Notes_id in (" + O_Notes_idlist + ")  ");
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
        public CommonService.Model.OA.O_Notes GetModel(int O_Notes_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Notes_id,O_Notes_code,O_Notes_person,O_Notes_creator,O_Notes_createTime,O_Notes_isDelete from O_Notes ");
            strSql.Append(" where O_Notes_id=@O_Notes_id");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Notes_id", SqlDbType.Int,4)
			};
            parameters[0].Value = O_Notes_id;

            CommonService.Model.OA.O_Notes model = new CommonService.Model.OA.O_Notes();
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
        /// 根据code得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Notes GetModelByCode(Guid O_Notes_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 O_Notes_id,O_Notes_code,O_Notes_person,O_Notes_creator,O_Notes_createTime,O_Notes_isDelete,O_Notes_content from O_Notes ");
            strSql.Append(" where O_Notes_code=@O_Notes_code");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Notes_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = O_Notes_code;

            CommonService.Model.OA.O_Notes model = new CommonService.Model.OA.O_Notes();
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
        public CommonService.Model.OA.O_Notes DataRowToModel(DataRow row)
        {
            CommonService.Model.OA.O_Notes model = new CommonService.Model.OA.O_Notes();
            if (row != null)
            {
                if (row["O_Notes_id"] != null && row["O_Notes_id"].ToString() != "")
                {
                    model.O_Notes_id = int.Parse(row["O_Notes_id"].ToString());
                }
                if (row["O_Notes_code"] != null && row["O_Notes_code"].ToString() != "")
                {
                    model.O_Notes_code = new Guid(row["O_Notes_code"].ToString());
                }
                if (row["O_Notes_person"] != null && row["O_Notes_person"].ToString() != "")
                {
                    model.O_Notes_person = new Guid(row["O_Notes_person"].ToString());
                }
                if (row["O_Notes_creator"] != null && row["O_Notes_creator"].ToString() != "")
                {
                    model.O_Notes_creator = new Guid(row["O_Notes_creator"].ToString());
                }
                if (row["O_Notes_createTime"] != null && row["O_Notes_createTime"].ToString() != "")
                {
                    model.O_Notes_createTime = DateTime.Parse(row["O_Notes_createTime"].ToString());
                }
                if (row["O_Notes_isDelete"] != null && row["O_Notes_isDelete"].ToString() != "")
                {
                    if ((row["O_Notes_isDelete"].ToString() == "1") || (row["O_Notes_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.O_Notes_isDelete = true;
                    }
                    else
                    {
                        model.O_Notes_isDelete = false;
                    }
                }
                if (row["O_Notes_content"] != null && row["O_Notes_content"].ToString() != "")
                {
                    model.O_Notes_content = row["O_Notes_content"].ToString();
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
            strSql.Append("select O_Notes_id,O_Notes_code,O_Notes_person,O_Notes_creator,O_Notes_createTime,O_Notes_isDelete,O_Notes_content ");
            strSql.Append(" FROM O_Notes where 1=1 and O_Notes_isDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  " + strWhere);
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
            strSql.Append(" O_Notes_id,O_Notes_code,O_Notes_person,O_Notes_creator,O_Notes_createTime,O_Notes_isDelete ");
            strSql.Append(" FROM O_Notes ");
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
            strSql.Append("select count(1) FROM O_Notes ");
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
                strSql.Append("order by T.O_Notes_id desc");
            }
            strSql.Append(")AS Row, T.*  from O_Notes T ");
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
            parameters[0].Value = "O_Notes";
            parameters[1].Value = "O_Notes_id";
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
