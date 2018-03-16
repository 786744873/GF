using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:竞争对手_竞争产品表
    /// 作者：崔慧栋
    /// 日期：2015/04/23
    /// </summary>
    public class C_RCProduct
    {
        public C_RCProduct()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_RCProduct_id", "C_RCProduct");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_RCProduct_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_RCProduct");
            strSql.Append(" where C_RCProduct_id=@C_RCProduct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_RCProduct_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_RCProduct_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_RCProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_RCProduct(");
            strSql.Append("C_RCProduct_code,C_RCProduct_number,C_RCProduct_competitorCode,C_RCProduct_name,C_RCProduct_cTime,C_RCProduct_cUserID,C_RCProduct_isdelete)");
            strSql.Append(" values (");
            strSql.Append("@C_RCProduct_code,@C_RCProduct_number,@C_RCProduct_competitorCode,@C_RCProduct_name,@C_RCProduct_cTime,@C_RCProduct_cUserID,@C_RCProduct_isdelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_RCProduct_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_RCProduct_number",SqlDbType.VarChar,100),
					new SqlParameter("@C_RCProduct_competitorCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_RCProduct_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_RCProduct_cTime", SqlDbType.DateTime),
					new SqlParameter("@C_RCProduct_cUserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_RCProduct_isdelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_RCProduct_code;
            parameters[1].Value = model.C_RCProduct_number;
            parameters[2].Value = model.C_RCProduct_competitorCode;
            parameters[3].Value = model.C_RCProduct_name;
            parameters[4].Value = model.C_RCProduct_cTime;
            parameters[5].Value = model.C_RCProduct_cUserID;
            parameters[6].Value = model.C_RCProduct_isdelete;

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
        public bool Update(CommonService.Model.C_RCProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_RCProduct set ");
            strSql.Append("C_RCProduct_code=@C_RCProduct_code,");
            strSql.Append("C_RCProduct_number=@C_RCProduct_number,");
            strSql.Append("C_RCProduct_competitorCode=@C_RCProduct_competitorCode,");
            strSql.Append("C_RCProduct_name=@C_RCProduct_name,");
            strSql.Append("C_RCProduct_cTime=@C_RCProduct_cTime,");
            strSql.Append("C_RCProduct_cUserID=@C_RCProduct_cUserID,");
            strSql.Append("C_RCProduct_isdelete=@C_RCProduct_isdelete,");
            strSql.Append(" where C_RCProduct_id=@C_RCProduct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_RCProduct_code", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_RCProduct_number",SqlDbType.VarChar,100),
					new SqlParameter("@C_RCProduct_competitorCode", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_RCProduct_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_RCProduct_cTime", SqlDbType.DateTime),
					new SqlParameter("@C_RCProduct_cUserID", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_RCProduct_isdelete", SqlDbType.Int,4),
                    new SqlParameter("@C_RCProduct_id",SqlDbType.Int,4)};
            parameters[0].Value = model.C_RCProduct_code;
            parameters[1].Value = model.C_RCProduct_number;
            parameters[2].Value = model.C_RCProduct_competitorCode;
            parameters[3].Value = model.C_RCProduct_name;
            parameters[4].Value = model.C_RCProduct_cTime;
            parameters[5].Value = model.C_RCProduct_cUserID;
            parameters[6].Value = model.C_RCProduct_isdelete;
            parameters[7].Value = model.C_RCProduct_id;

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
        public bool Delete(int C_RCProduct_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_RCProduct set C_RCProduct_isdelete=1 ");
            strSql.Append(" where C_RCProduct_id=@C_RCProduct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_RCProduct_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_RCProduct_id;

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
        public bool DeleteList(string C_RCProduct_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_RCProduct ");
            strSql.Append(" where C_RCProduct_id in (" + C_RCProduct_idlist + ")  ");
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
        public CommonService.Model.C_RCProduct GetModel(int C_RCProduct_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_RCProduct_id,C_RCProduct_code,C_RCProduct_number,C_RCProduct_competitorCode,C_RCProduct_name,C_RCProduct_cTime,C_RCProduct_cUserID,C_RCProduct_isdelete from C_RCProduct ");
            strSql.Append(" where C_RCProduct_id=@C_RCProduct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_RCProduct_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_RCProduct_id;

            CommonService.Model.C_RCProduct model = new CommonService.Model.C_RCProduct();
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
        public CommonService.Model.C_RCProduct GetModel(Guid C_RCProduct_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_RCProduct_id,C_RCProduct_code,C_RCProduct_number,C_RCProduct_competitorCode,C_RCProduct_name,C_RCProduct_cTime,C_RCProduct_cUserID,C_RCProduct_isdelete from C_RCProduct ");
            strSql.Append(" where C_RCProduct_code=@C_RCProduct_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_RCProduct_code", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = C_RCProduct_code;

            CommonService.Model.C_RCProduct model = new CommonService.Model.C_RCProduct();
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
        public CommonService.Model.C_RCProduct DataRowToModel(DataRow row)
        {
            CommonService.Model.C_RCProduct model = new CommonService.Model.C_RCProduct();
            if (row != null)
            {
                if (row["C_RCProduct_id"] != null && row["C_RCProduct_id"].ToString() != "")
                {
                    model.C_RCProduct_id = int.Parse(row["C_RCProduct_id"].ToString());
                }
                if (row["C_RCProduct_code"] != null)
                {
                    model.C_RCProduct_code =new Guid(row["C_RCProduct_code"].ToString());
                }
                if (row["C_RCProduct_number"] != null)
                {
                    model.C_RCProduct_number =row["C_RCProduct_number"].ToString();
                }
                if (row["C_RCProduct_competitorCode"] != null)
                {
                    model.C_RCProduct_competitorCode =new Guid(row["C_RCProduct_competitorCode"].ToString());
                }
                if (row["C_RCProduct_name"] != null)
                {
                    model.C_RCProduct_name = row["C_RCProduct_name"].ToString();
                }
                //if (row["C_RCProduct_isDelete"] != null && row["C_RCProduct_isDelete"].ToString() != "")
                //{
                //    if ((row["C_RCProduct_isDelete"].ToString() == "1") || (row["C_RCProduct_isDelete"].ToString().ToLower() == "true"))
                //    {
                //        model.C_RCProduct_isDelete = true;
                //    }
                //    else
                //    {
                //        model.C_RCProduct_isDelete = false;
                //    }
                //}
                if (row["C_RCProduct_cTime"] != null)
                {
                    model.C_RCProduct_cTime = DateTime.Parse(row["C_RCProduct_cTime"].ToString());
                }
                if (row["C_RCProduct_cUserID"] != null && row["C_RCProduct_cUserID"].ToString() != "")
                {
                    model.C_RCProduct_cUserID =new Guid(row["C_RCProduct_cUserID"].ToString());
                }
                if (row["C_RCProduct_isdelete"] != null && row["C_RCProduct_isdelete"].ToString() != "")
                {
                    model.C_RCProduct_isdelete = int.Parse(row["C_RCProduct_isdelete"].ToString());
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
            strSql.Append("select C_RCProduct_id,C_RCProduct_code,C_RCProduct_number,C_RCProduct_competitorCode,C_RCProduct_name,C_RCProduct_cTime,C_RCProduct_cUserID,C_RCProduct_isdelete");
            strSql.Append(" FROM C_RCProduct ");
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
            strSql.Append(" C_RCProduct_id,C_RCProduct_code,C_RCProduct_number,C_RCProduct_competitorCode,C_RCProduct_name,C_RCProduct_cTime,C_RCProduct_cUserID,C_RCProduct_isdelete");
            strSql.Append(" FROM C_RCProduct ");
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
        public int GetRecordCount(Model.C_RCProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_RCProduct ");
            strSql.Append(" where 1=1 and C_RCProduct_isdelete=0");
            if (model != null)
            {
                if (model.C_RCProduct_code != null)
                {
                    strSql.Append(" and C_RCProduct_code=@C_RCProduct_code");
                }
                if (model.C_RCProduct_number != null)
                {
                    strSql.Append(" and C_RCProduct_number=@C_RCProduct_number");
                }
                if (model.C_RCProduct_competitorCode != null)
                {
                    strSql.Append(" and C_RCProduct_competitorCode=@C_RCProduct_competitorCode");
                }
                if (model.C_RCProduct_name != null && model.C_RCProduct_name != "")
                {
                    strSql.Append(" and C_RCProduct_name=@C_RCProduct_name");
                }
                if (model.C_RCProduct_cTime != null)
                {
                    strSql.Append(" and C_RCProduct_cTime=@C_RCProduct_cTime");
                }
                if (model.C_RCProduct_cUserID != null)
                {
                    strSql.Append(" and C_RCProduct_cUserID=@C_RCProduct_cUserID");
                }

            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_RCProduct_code", SqlDbType.VarChar,50),
                    new SqlParameter("@C_RCProduct_number",SqlDbType.VarChar,100),
					new SqlParameter("@C_RCProduct_competitorCode", SqlDbType.VarChar,50),
					new SqlParameter("@C_RCProduct_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_RCProduct_cTime", SqlDbType.DateTime),
					new SqlParameter("@C_RCProduct_cUserID", SqlDbType.Int,4),};
            parameters[0].Value = model.C_RCProduct_code;
            parameters[1].Value = model.C_RCProduct_number;
            parameters[2].Value = model.C_RCProduct_competitorCode;
            parameters[3].Value = model.C_RCProduct_name;
            parameters[4].Value = model.C_RCProduct_cTime;
            parameters[5].Value = model.C_RCProduct_cUserID;
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
        public DataSet GetListByPage(Model.C_RCProduct model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_RCProduct_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_RCProduct T ");
            strSql.Append(" where 1=1 and C_RCProduct_isdelete=0");
            if (model != null)
            {
                if (model.C_RCProduct_code != null)
                {
                    strSql.Append(" and C_RCProduct_code=@C_RCProduct_code");
                }
                if (model.C_RCProduct_number != null)
                {
                    strSql.Append(" and C_RCProduct_number=@C_RCProduct_number");
                }
                if (model.C_RCProduct_competitorCode != null)
                {
                    strSql.Append(" and C_RCProduct_competitorCode=@C_RCProduct_competitorCode");
                }
                if (model.C_RCProduct_name != null && model.C_RCProduct_name != "")
                {
                    strSql.Append(" and C_RCProduct_name=@C_RCProduct_name");
                }
                if (model.C_RCProduct_cTime != null)
                {
                    strSql.Append(" and C_RCProduct_cTime=@C_RCProduct_cTime");
                }
                if (model.C_RCProduct_cUserID != null)
                {
                    strSql.Append(" and C_RCProduct_cUserID=@C_RCProduct_cUserID");
                }
            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_RCProduct_code", SqlDbType.VarChar,50),
                    new SqlParameter("@C_RCProduct_number",SqlDbType.VarChar,100),
					new SqlParameter("@C_RCProduct_competitorCode", SqlDbType.VarChar,50),
					new SqlParameter("@C_RCProduct_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_RCProduct_cTime", SqlDbType.DateTime),
					new SqlParameter("@C_RCProduct_cUserID", SqlDbType.Int,4),
                    new SqlParameter("@C_RCProduct_id",SqlDbType.Int,4)};
            parameters[0].Value = model.C_RCProduct_code;
            parameters[1].Value = model.C_RCProduct_number;
            parameters[2].Value = model.C_RCProduct_competitorCode;
            parameters[3].Value = model.C_RCProduct_name;
            parameters[4].Value = model.C_RCProduct_cTime;
            parameters[5].Value = model.C_RCProduct_cUserID;
            parameters[6].Value = model.C_RCProduct_id;
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
            parameters[0].Value = "C_RCProduct";
            parameters[1].Value = "C_RCProduct_id";
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
