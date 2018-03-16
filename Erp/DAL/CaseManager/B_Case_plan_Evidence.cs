using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.CaseManager
{
    /// <summary>
    /// 数据访问类:B_Case_plan_Evidence办案方案和提交的证据中间表
    /// 作者：陈永俊
    /// 时间：2015年6月16日
    /// </summary>
    public partial class B_Case_plan_Evidence
    {
        public B_Case_plan_Evidence()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_plan_Evidence_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Case_plan_Evidence");
            strSql.Append(" where B_Case_plan_Evidence_id=@B_Case_plan_Evidence_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Evidence_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_plan_Evidence_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_plan_Evidence model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Case_plan_Evidence(");
            strSql.Append("B_Case_plan_Evidence_code,B_Case_plan_code,B_Case_paln_Evidence_type,B_Case_plan_Evidence_file_code,B_Case_plan_Evidence_creator,B_Case_plan_Evidence_createTime,B_Case_plan_Evidence_isDelete,B_Case_plan_Evidence_Parameters_id)");
            strSql.Append(" values (");
            strSql.Append("@B_Case_plan_Evidence_code,@B_Case_plan_code,@B_Case_paln_Evidence_type,@B_Case_plan_Evidence_file_code,@B_Case_plan_Evidence_creator,@B_Case_plan_Evidence_createTime,@B_Case_plan_Evidence_isDelete,@B_Case_plan_Evidence_Parameters_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Evidence_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_paln_Evidence_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Evidence_file_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_Evidence_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_Evidence_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_plan_Evidence_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Evidence_Parameters_id", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.B_Case_plan_code;
            parameters[2].Value = model.B_Case_paln_Evidence_type;
            parameters[3].Value = model.B_Case_plan_Evidence_file_code;
            parameters[4].Value = Guid.NewGuid();
            parameters[5].Value = model.B_Case_plan_Evidence_createTime;
            parameters[6].Value = model.B_Case_plan_Evidence_isDelete;
            parameters[7].Value = model.B_Case_plan_Evidence_Parameters_id;

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
        public bool Update(CommonService.Model.CaseManager.B_Case_plan_Evidence model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case_plan_Evidence set ");
            strSql.Append("B_Case_plan_Evidence_code=@B_Case_plan_Evidence_code,");
            strSql.Append("B_Case_plan_code=@B_Case_plan_code,");
            strSql.Append("B_Case_paln_Evidence_type=@B_Case_paln_Evidence_type,");
            strSql.Append("B_Case_plan_Evidence_file_code=@B_Case_plan_Evidence_file_code,");
            strSql.Append("B_Case_plan_Evidence_creator=@B_Case_plan_Evidence_creator,");
            strSql.Append("B_Case_plan_Evidence_createTime=@B_Case_plan_Evidence_createTime,");
            strSql.Append("B_Case_plan_Evidence_isDelete=@B_Case_plan_Evidence_isDelete,");
            strSql.Append("B_Case_plan_Evidence_Parameters_id=@B_Case_plan_Evidence_Parameters_id");
            strSql.Append(" where B_Case_plan_Evidence_id=@B_Case_plan_Evidence_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Evidence_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_paln_Evidence_type", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Evidence_file_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_Evidence_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_Evidence_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_plan_Evidence_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Evidence_Parameters_id", SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_plan_Evidence_code;
            parameters[1].Value = model.B_Case_plan_code;
            parameters[2].Value = model.B_Case_paln_Evidence_type;
            parameters[3].Value = model.B_Case_plan_Evidence_file_code;
            parameters[4].Value = model.B_Case_plan_Evidence_creator;
            parameters[5].Value = model.B_Case_plan_Evidence_createTime;
            parameters[6].Value = model.B_Case_plan_Evidence_isDelete;
            parameters[7].Value = model.B_Case_plan_Evidence_Parameters_id;

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
        public bool Delete(int B_Case_plan_Evidence_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_plan_Evidence ");
            strSql.Append(" where B_Case_plan_Evidence_id=@B_Case_plan_Evidence_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Evidence_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_plan_Evidence_id;

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
        /// 根据关联的案件GUID删除一条数据
        /// </summary>
        public bool Delete(Guid B_Case_plan_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_plan_Evidence ");
            strSql.Append(" where B_Case_plan_code=@B_Case_plan_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_plan_code;

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
        public bool DeleteList(string B_Case_plan_Evidence_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_plan_Evidence ");
            strSql.Append(" where B_Case_plan_Evidence_id in (" + B_Case_plan_Evidence_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_Case_plan_Evidence GetModel(int B_Case_plan_Evidence_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_plan_Evidence_id,B_Case_plan_Evidence_code,B_Case_plan_code,B_Case_paln_Evidence_type,B_Case_plan_Evidence_file_code,B_Case_plan_Evidence_creator,B_Case_plan_Evidence_createTime,B_Case_plan_Evidence_isDelete,B_Case_plan_Evidence_Parameters_id from B_Case_plan_Evidence ");
            strSql.Append(" where B_Case_plan_Evidence_id=@B_Case_plan_Evidence_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Evidence_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_plan_Evidence_id;

            CommonService.Model.CaseManager.B_Case_plan_Evidence model = new CommonService.Model.CaseManager.B_Case_plan_Evidence();
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
        public CommonService.Model.CaseManager.B_Case_plan_Evidence DataRowToModel(DataRow row)
        {
            CommonService.Model.CaseManager.B_Case_plan_Evidence model = new CommonService.Model.CaseManager.B_Case_plan_Evidence();
            if (row != null)
            {
                if (row["B_Case_plan_Evidence_id"] != null && row["B_Case_plan_Evidence_id"].ToString() != "")
                {
                    model.B_Case_plan_Evidence_id = int.Parse(row["B_Case_plan_Evidence_id"].ToString());
                }
                if (row["B_Case_plan_Evidence_code"] != null && row["B_Case_plan_Evidence_code"].ToString() != "")
                {
                    model.B_Case_plan_Evidence_code = new Guid(row["B_Case_plan_Evidence_code"].ToString());
                }
                if (row["B_Case_plan_code"] != null && row["B_Case_plan_code"].ToString() != "")
                {
                    model.B_Case_plan_code = new Guid(row["B_Case_plan_code"].ToString());
                }
                if (row["B_Case_paln_Evidence_type"] != null && row["B_Case_paln_Evidence_type"].ToString() != "")
                {
                    model.B_Case_paln_Evidence_type = int.Parse(row["B_Case_paln_Evidence_type"].ToString());
                }
                if (model.B_Case_paln_Evidence_type!=3&&row["B_Case_plan_Evidence_file_code"] != null)
                {
                    model.B_Case_plan_Evidence_file_code =  new Guid(row["B_Case_plan_Evidence_file_code"].ToString());
                }
                if (row["B_Case_plan_Evidence_creator"] != null && row["B_Case_plan_Evidence_creator"].ToString() != "")
                {
                    model.B_Case_plan_Evidence_creator = new Guid(row["B_Case_plan_Evidence_creator"].ToString());
                }
                if (row["B_Case_plan_Evidence_createTime"] != null && row["B_Case_plan_Evidence_createTime"].ToString() != "")
                {
                    model.B_Case_plan_Evidence_createTime = DateTime.Parse(row["B_Case_plan_Evidence_createTime"].ToString());
                }
                if (row["B_Case_plan_Evidence_isDelete"] != null && row["B_Case_plan_Evidence_isDelete"].ToString() != "")
                {
                    model.B_Case_plan_Evidence_isDelete = int.Parse(row["B_Case_plan_Evidence_isDelete"].ToString());
                }
                if (row["B_Case_plan_Evidence_Parameters_id"] != null && row["B_Case_plan_Evidence_Parameters_id"].ToString() != "")
                {
                    model.B_Case_plan_Evidence_Parameters_id = int.Parse(row["B_Case_plan_Evidence_Parameters_id"].ToString());
                }
                //检查是否存在字段文件名称
                if (row.Table.Columns.Contains("B_Case_plan_Evidence_name"))
                {
                    if (row["B_Case_plan_Evidence_name"] != null)
                    {
                        model.B_Case_plan_Evidence_name = row["B_Case_plan_Evidence_name"].ToString();
                    }
                }
                //检查是否存在字段类型名称
                if (row.Table.Columns.Contains("B_Case_plan_Evidence_Parameters_name"))
                {
                    if (row["B_Case_plan_Evidence_Parameters_name"] != null)
                    {
                        model.B_Case_plan_Evidence_Parameters_name = row["B_Case_plan_Evidence_Parameters_name"].ToString();
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_plan_Evidence> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select B_Case_plan_Evidence_id,B_Case_plan_Evidence_code,B_Case_plan_code,B_Case_paln_Evidence_type,B_Case_plan_Evidence_file_code,B_Case_plan_Evidence_creator,B_Case_plan_Evidence_createTime,B_Case_plan_Evidence_isDelete,B_Case_plan_Evidence_Parameters_id,F.C_Files_viewName As B_Case_plan_Evidence_name,P.C_Parameters_name As B_Case_plan_Evidence_Parameters_name ");
            strSql.Append(" FROM B_Case_plan_Evidence As C ");
            strSql.Append(" left join C_Files As F on C.B_Case_plan_Evidence_file_code= F.C_Files_code");
            strSql.Append(" left join C_Parameters As P on C.B_Case_plan_Evidence_Parameters_id=P.C_Parameters_id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where C.B_Case_plan_Evidence_isDelete=0 and " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return DataRowToList(ds);
        }
        public List<CommonService.Model.CaseManager.B_Case_plan_Evidence> DataRowToList(DataSet ds)
        {
            List<CommonService.Model.CaseManager.B_Case_plan_Evidence> modelList = new List<CommonService.Model.CaseManager.B_Case_plan_Evidence>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_Case_plan_Evidence model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(ds.Tables[0].Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
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
            strSql.Append(" B_Case_plan_Evidence_id,B_Case_plan_Evidence_code,B_Case_plan_code,B_Case_paln_Evidence_type,B_Case_plan_Evidence_file_code,B_Case_plan_Evidence_creator,B_Case_plan_Evidence_createTime,B_Case_plan_Evidence_isDelete,B_Case_plan_Evidence_Parameters_id ");
            strSql.Append(" FROM B_Case_plan_Evidence ");
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
            strSql.Append("select count(1) FROM B_Case_plan_Evidence ");
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
                strSql.Append("order by T.B_Case_plan_Evidence_id desc");
            }
            strSql.Append(")AS Row, T.*  from B_Case_plan_Evidence T ");
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
            parameters[0].Value = "B_Case_plan_Evidence";
            parameters[1].Value = "B_Case_plan_Evidence_id";
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
