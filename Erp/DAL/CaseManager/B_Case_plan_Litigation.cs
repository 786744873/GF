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
    /// 数据访问类:B_Case_plan_Litigation办案方案诉讼请求----和参数中间表
    /// 作者：陈永俊
    /// 时间：2015年6月19日
    /// 
    /// </summary>
    public partial class B_Case_plan_Litigation
    {
        public B_Case_plan_Litigation()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_plan_Litigation_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Case_plan_Litigation");
            strSql.Append(" where B_Case_plan_Litigation_id=@B_Case_plan_Litigation_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Litigation_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_plan_Litigation_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据参数ID 和案件GUID查找是否存在记录
        /// </summary>
        /// <param name="parameterid"></param>
        /// <param name="casecode"></param>
        /// <returns></returns>
        public bool ExitsByParameteridAndCasecode(int parameterid, Guid casecode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Case_plan_Litigation");
            strSql.Append(" where B_Case_plan_Litigation_ParameterId=@B_Case_plan_Litigation_ParameterId and B_Case_code=@B_Case_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Litigation_ParameterId", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parameterid;
            parameters[1].Value = casecode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_plan_Litigation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Case_plan_Litigation(");
            strSql.Append("B_Case_plan_Litigation_code,B_Case_plan_Litigation_ParameterId,B_Case_plan_Litigation_Amount,B_Case_plan_Litigation_description,B_Case_plan_Litigation_creator,B_Case_plan_Litigation_createTime,B_Case_plan_Litigation_isDelete,B_Case_code)");
            strSql.Append(" values (");
            strSql.Append("@B_Case_plan_Litigation_code,@B_Case_plan_Litigation_ParameterId,@B_Case_plan_Litigation_Amount,@B_Case_plan_Litigation_description,@B_Case_plan_Litigation_creator,@B_Case_plan_Litigation_createTime,@B_Case_plan_Litigation_isDelete,@B_Case_code)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Litigation_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_Litigation_ParameterId", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Litigation_Amount", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Litigation_description", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_plan_Litigation_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_Litigation_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_plan_Litigation_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16) };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.B_Case_plan_Litigation_ParameterId;
            parameters[2].Value = model.B_Case_plan_Litigation_Amount;
            parameters[3].Value = model.B_Case_plan_Litigation_description;
            parameters[4].Value = Guid.NewGuid();
            parameters[5].Value = model.B_Case_plan_Litigation_createTime;
            parameters[6].Value = model.B_Case_plan_Litigation_isDelete;
            parameters[7].Value = model.B_Case_code;
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
        public bool Update(CommonService.Model.CaseManager.B_Case_plan_Litigation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case_plan_Litigation set ");
            strSql.Append("B_Case_plan_Litigation_code=@B_Case_plan_Litigation_code,");
            strSql.Append("B_Case_plan_Litigation_ParameterId=@B_Case_plan_Litigation_ParameterId,");
            strSql.Append("B_Case_plan_Litigation_Amount=@B_Case_plan_Litigation_Amount,");
            strSql.Append("B_Case_plan_Litigation_description=@B_Case_plan_Litigation_description,");
            strSql.Append("B_Case_plan_Litigation_creator=@B_Case_plan_Litigation_creator,");
            strSql.Append("B_Case_plan_Litigation_createTime=@B_Case_plan_Litigation_createTime,");
            strSql.Append("B_Case_plan_Litigation_isDelete=@B_Case_plan_Litigation_isDelete,");
            strSql.Append("B_Case_code=@B_Case_code");
            strSql.Append(" where B_Case_plan_Litigation_id=@B_Case_plan_Litigation_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Litigation_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_Litigation_ParameterId", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Litigation_Amount", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Litigation_description", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_plan_Litigation_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_plan_Litigation_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_plan_Litigation_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_Case_plan_Litigation_id", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16) };
            parameters[0].Value = model.B_Case_plan_Litigation_code;
            parameters[1].Value = model.B_Case_plan_Litigation_ParameterId;
            parameters[2].Value = model.B_Case_plan_Litigation_Amount;
            parameters[3].Value = model.B_Case_plan_Litigation_description;
            parameters[4].Value = model.B_Case_plan_Litigation_creator;
            parameters[5].Value = model.B_Case_plan_Litigation_createTime;
            parameters[6].Value = model.B_Case_plan_Litigation_isDelete;
            parameters[7].Value = model.B_Case_plan_Litigation_id;
            parameters[8].Value = model.B_Case_code;
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
        public bool Delete(int B_Case_plan_Litigation_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_plan_Litigation ");
            strSql.Append(" where B_Case_plan_Litigation_id=@B_Case_plan_Litigation_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Litigation_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_plan_Litigation_id;

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
        public bool DeleteList(string B_Case_plan_Litigation_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_plan_Litigation ");
            strSql.Append(" where B_Case_plan_Litigation_id in (" + B_Case_plan_Litigation_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_Case_plan_Litigation GetModel(int B_Case_plan_Litigation_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_plan_Litigation_id,B_Case_plan_Litigation_code,B_Case_plan_Litigation_ParameterId,B_Case_plan_Litigation_Amount,B_Case_plan_Litigation_description,B_Case_plan_Litigation_creator,B_Case_plan_Litigation_createTime,B_Case_plan_Litigation_isDelete,B_Case_code from B_Case_plan_Litigation ");
            strSql.Append(" where B_Case_plan_Litigation_id=@B_Case_plan_Litigation_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Litigation_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_plan_Litigation_id;

            CommonService.Model.CaseManager.B_Case_plan_Litigation model = new CommonService.Model.CaseManager.B_Case_plan_Litigation();
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
        /// 通过参数ID和案件GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan_Litigation GetModelByParameterAndCasecode(int parameterid,Guid casecode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_plan_Litigation_id,B_Case_plan_Litigation_code,B_Case_plan_Litigation_ParameterId,B_Case_plan_Litigation_Amount,B_Case_plan_Litigation_description,B_Case_plan_Litigation_creator,B_Case_plan_Litigation_createTime,B_Case_plan_Litigation_isDelete,B_Case_code from B_Case_plan_Litigation As L ");
            strSql.Append(" left join C_Parameters As P on L.B_Case_plan_Litigation_ParameterId=P.C_Parameters_id ");
            strSql.Append(" where B_Case_plan_Litigation_ParameterId=@B_Case_plan_Litigation_ParameterId and B_Case_code=@B_Case_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_plan_Litigation_ParameterId", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parameterid;
            parameters[1].Value = casecode;
            CommonService.Model.CaseManager.B_Case_plan_Litigation model = new CommonService.Model.CaseManager.B_Case_plan_Litigation();
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
        public CommonService.Model.CaseManager.B_Case_plan_Litigation DataRowToModel(DataRow row)
        {
            CommonService.Model.CaseManager.B_Case_plan_Litigation model = new CommonService.Model.CaseManager.B_Case_plan_Litigation();
            if (row != null)
            {
                if (row["B_Case_plan_Litigation_id"] != null && row["B_Case_plan_Litigation_id"].ToString() != "")
                {
                    model.B_Case_plan_Litigation_id = int.Parse(row["B_Case_plan_Litigation_id"].ToString());
                }
                if (row["B_Case_plan_Litigation_code"] != null && row["B_Case_plan_Litigation_code"].ToString() != "")
                {
                    model.B_Case_plan_Litigation_code = new Guid(row["B_Case_plan_Litigation_code"].ToString());
                }
                if (row["B_Case_plan_Litigation_ParameterId"] != null && row["B_Case_plan_Litigation_ParameterId"].ToString() != "")
                {
                    model.B_Case_plan_Litigation_ParameterId = int.Parse(row["B_Case_plan_Litigation_ParameterId"].ToString());
                }
                if (row["B_Case_plan_Litigation_Amount"] != null && row["B_Case_plan_Litigation_Amount"].ToString() != "")
                {
                    model.B_Case_plan_Litigation_Amount = int.Parse(row["B_Case_plan_Litigation_Amount"].ToString());
                }
                if (row["B_Case_plan_Litigation_description"] != null)
                {
                    model.B_Case_plan_Litigation_description = row["B_Case_plan_Litigation_description"].ToString();
                }
                if (row["B_Case_plan_Litigation_creator"] != null && row["B_Case_plan_Litigation_creator"].ToString() != "")
                {
                    model.B_Case_plan_Litigation_creator = new Guid(row["B_Case_plan_Litigation_creator"].ToString());
                }
                if (row["B_Case_plan_Litigation_createTime"] != null && row["B_Case_plan_Litigation_createTime"].ToString() != "")
                {
                    model.B_Case_plan_Litigation_createTime = DateTime.Parse(row["B_Case_plan_Litigation_createTime"].ToString());
                }
                if (row["B_Case_plan_Litigation_isDelete"] != null && row["B_Case_plan_Litigation_isDelete"].ToString() != "")
                {
                    model.B_Case_plan_Litigation_isDelete = int.Parse(row["B_Case_plan_Litigation_isDelete"].ToString());
                }
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString() != "")
                {
                    model.B_Case_code = new Guid(row["B_Case_code"].ToString());
                }
                if (row.Table.Columns.Contains("B_Case_plan_litigation_parameter_name"))
                {
                    if (row["B_Case_plan_litigation_parameter_name"] != null && row["B_Case_plan_litigation_parameter_name"].ToString() != "")
                    {
                        model.B_Case_plan_litigation_parameter_name = row["B_Case_plan_litigation_parameter_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Parameterid"))
                {
                    if (row["C_Parameterid"] != null && row["C_Parameterid"].ToString() != "")
                    {
                        model.C_Parameterid = int.Parse(row["C_Parameterid"].ToString());
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
            strSql.Append("select B_Case_plan_Litigation_id,B_Case_plan_Litigation_code,B_Case_plan_Litigation_ParameterId,B_Case_plan_Litigation_Amount,B_Case_plan_Litigation_description,B_Case_plan_Litigation_creator,B_Case_plan_Litigation_createTime,B_Case_plan_Litigation_isDelete,B_Case_code,P.C_Parameters_name As B_Case_plan_litigation_parameter_name ");
            strSql.Append(" FROM B_Case_plan_Litigation As L ");
            strSql.Append(" left join C_Parameters As P  on L.B_Case_plan_Litigation_ParameterId=P.C_Parameters_id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据父级ParameterID和案件编码获取列表
        /// </summary>
        /// <param name="C_Parameters_id">父级ID</param>
        /// <param name="casecode">案件编码</param>
        /// <returns></returns>
        public DataSet GetListByCasecodeAndParameterId(int C_Parameters_id,Guid casecode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select l.*,p.C_Parameters_name As B_Case_plan_litigation_parameter_name,p.C_Parameters_id As C_Parameterid  from (select * from B_Case_plan_Litigation where B_Case_code=@B_Case_code)As L right join (select C_Parameters_id,C_Parameters_name from C_Parameters where C_Parameters_parent=@C_Parameters_parent) as p on l.B_Case_plan_Litigation_ParameterId=p.C_Parameters_id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Parameters_parent",SqlDbType.Int,4)
			};
            parameters[0].Value = casecode;
            parameters[1].Value = C_Parameters_id;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
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
            strSql.Append(" B_Case_plan_Litigation_id,B_Case_plan_Litigation_code,B_Case_plan_Litigation_ParameterId,B_Case_plan_Litigation_Amount,B_Case_plan_Litigation_description,B_Case_plan_Litigation_creator,B_Case_plan_Litigation_createTime,B_Case_plan_Litigation_isDelete,B_Case_code ");
            strSql.Append(" FROM B_Case_plan_Litigation ");
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
            strSql.Append("select count(1) FROM B_Case_plan_Litigation ");
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
                strSql.Append("order by T.B_Case_plan_Litigation_id desc");
            }
            strSql.Append(")AS Row, T.*  from B_Case_plan_Litigation T ");
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
            parameters[0].Value = "B_Case_plan_Litigation";
            parameters[1].Value = "B_Case_plan_Litigation_id";
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
