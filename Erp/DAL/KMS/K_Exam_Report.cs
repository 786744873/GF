using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:K_Exam_Report
    /// 作者：cpp 
    /// 日期：2016-2-29
    /// </summary>
    public partial class K_Exam_Report
    {
        public K_Exam_Report()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid K_Exam_Report_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Exam_Report");
            strSql.Append(" where K_Exam_Report_code=@K_Exam_Report_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_Report_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_Exam_Report_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.KMS.K_Exam_Report model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Exam_Report(");
            strSql.Append("K_Exam_Report_code,K_Exam_Students_code,K_Exam_code,K_Exam_Report_title,K_Exam_Report_testId,K_Exam_Report_paperId,K_Exam_Report_beginTime,K_Exam_Report_endTime,K_Exam_Report_elapsedTime,K_ExtInfos_code,K_Exam_Report_score,K_Exam_Report_points,K_Exam_Report_switchTimes)");
            strSql.Append(" values (");
            strSql.Append("@K_Exam_Report_code,@K_Exam_Students_code,@K_Exam_code,@K_Exam_Report_title,@K_Exam_Report_testId,@K_Exam_Report_paperId,@K_Exam_Report_beginTime,@K_Exam_Report_endTime,@K_Exam_Report_elapsedTime,@K_ExtInfos_code,@K_Exam_Report_score,@K_Exam_Report_points,@K_Exam_Report_switchTimes)");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_Report_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_Students_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_Report_title", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_Report_testId", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Exam_Report_paperId", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Exam_Report_beginTime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_Report_endTime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_Report_elapsedTime", SqlDbType.NVarChar,100),
					new SqlParameter("@K_ExtInfos_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_Report_score", SqlDbType.Decimal,9),
					new SqlParameter("@K_Exam_Report_points", SqlDbType.Decimal,9),
					new SqlParameter("@K_Exam_Report_switchTimes", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = Guid.NewGuid();
            parameters[3].Value = model.K_Exam_Report_title;
            parameters[4].Value = model.K_Exam_Report_testId;
            parameters[5].Value = model.K_Exam_Report_paperId;
            parameters[6].Value = model.K_Exam_Report_beginTime;
            parameters[7].Value = model.K_Exam_Report_endTime;
            parameters[8].Value = model.K_Exam_Report_elapsedTime;
            parameters[9].Value = Guid.NewGuid();
            parameters[10].Value = model.K_Exam_Report_score;
            parameters[11].Value = model.K_Exam_Report_points;
            parameters[12].Value = model.K_Exam_Report_switchTimes;

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
        public bool Update(CommonService.Model.KMS.K_Exam_Report model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Exam_Report set ");
            strSql.Append("K_Exam_Students_code=@K_Exam_Students_code,");
            strSql.Append("K_Exam_code=@K_Exam_code,");
            strSql.Append("K_Exam_Report_title=@K_Exam_Report_title,");
            strSql.Append("K_Exam_Report_testId=@K_Exam_Report_testId,");
            strSql.Append("K_Exam_Report_paperId=@K_Exam_Report_paperId,");
            strSql.Append("K_Exam_Report_beginTime=@K_Exam_Report_beginTime,");
            strSql.Append("K_Exam_Report_endTime=@K_Exam_Report_endTime,");
            strSql.Append("K_Exam_Report_elapsedTime=@K_Exam_Report_elapsedTime,");
            strSql.Append("K_ExtInfos_code=@K_ExtInfos_code,");
            strSql.Append("K_Exam_Report_score=@K_Exam_Report_score,");
            strSql.Append("K_Exam_Report_points=@K_Exam_Report_points,");
            strSql.Append("K_Exam_Report_switchTimes=@K_Exam_Report_switchTimes");
            strSql.Append(" where K_Exam_Report_code=@K_Exam_Report_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_Students_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_Report_title", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_Report_testId", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Exam_Report_paperId", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Exam_Report_beginTime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_Report_endTime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_Report_elapsedTime", SqlDbType.NVarChar,100),
					new SqlParameter("@K_ExtInfos_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_Report_score", SqlDbType.Decimal,9),
					new SqlParameter("@K_Exam_Report_points", SqlDbType.Decimal,9),
					new SqlParameter("@K_Exam_Report_switchTimes", SqlDbType.Int,4),
					new SqlParameter("@K_Exam_Report_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.K_Exam_Students_code;
            parameters[1].Value = model.K_Exam_code;
            parameters[2].Value = model.K_Exam_Report_title;
            parameters[3].Value = model.K_Exam_Report_testId;
            parameters[4].Value = model.K_Exam_Report_paperId;
            parameters[5].Value = model.K_Exam_Report_beginTime;
            parameters[6].Value = model.K_Exam_Report_endTime;
            parameters[7].Value = model.K_Exam_Report_elapsedTime;
            parameters[8].Value = model.K_ExtInfos_code;
            parameters[9].Value = model.K_Exam_Report_score;
            parameters[10].Value = model.K_Exam_Report_points;
            parameters[11].Value = model.K_Exam_Report_switchTimes;
            parameters[12].Value = model.K_Exam_Report_code;

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
        public bool Delete(Guid K_Exam_Report_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Exam_Report ");
            strSql.Append(" where K_Exam_Report_code=@K_Exam_Report_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_Report_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_Exam_Report_code;

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
        public bool DeleteList(string K_Exam_Report_codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Exam_Report ");
            strSql.Append(" where K_Exam_Report_code in (" + K_Exam_Report_codelist + ")  ");
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
        public CommonService.Model.KMS.K_Exam_Report GetModel(Guid K_Exam_Report_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Exam_Report_code,K_Exam_Students_code,K_Exam_code,K_Exam_Report_title,K_Exam_Report_testId,K_Exam_Report_paperId,K_Exam_Report_beginTime,K_Exam_Report_endTime,K_Exam_Report_elapsedTime,K_ExtInfos_code,K_Exam_Report_score,K_Exam_Report_points,K_Exam_Report_switchTimes from K_Exam_Report ");
            strSql.Append(" where K_Exam_Report_code=@K_Exam_Report_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_Report_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_Exam_Report_code;

            CommonService.Model.KMS.K_Exam_Report model = new CommonService.Model.KMS.K_Exam_Report();
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
        public CommonService.Model.KMS.K_Exam_Report DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Exam_Report model = new CommonService.Model.KMS.K_Exam_Report();
            if (row != null)
            {
                if (row["K_Exam_Report_code"] != null && row["K_Exam_Report_code"].ToString() != "")
                {
                    model.K_Exam_Report_code = new Guid(row["K_Exam_Report_code"].ToString());
                }
                if (row["K_Exam_Students_code"] != null && row["K_Exam_Students_code"].ToString() != "")
                {
                    model.K_Exam_Students_code = new Guid(row["K_Exam_Students_code"].ToString());
                }
                if (row["K_Exam_code"] != null && row["K_Exam_code"].ToString() != "")
                {
                    model.K_Exam_code = new Guid(row["K_Exam_code"].ToString());
                }
                if (row["K_Exam_Report_title"] != null)
                {
                    model.K_Exam_Report_title = row["K_Exam_Report_title"].ToString();
                }
                if (row["K_Exam_Report_testId"] != null)
                {
                    model.K_Exam_Report_testId = row["K_Exam_Report_testId"].ToString();
                }
                if (row["K_Exam_Report_paperId"] != null)
                {
                    model.K_Exam_Report_paperId = row["K_Exam_Report_paperId"].ToString();
                }
                if (row["K_Exam_Report_beginTime"] != null && row["K_Exam_Report_beginTime"].ToString() != "")
                {
                    model.K_Exam_Report_beginTime = DateTime.Parse(row["K_Exam_Report_beginTime"].ToString());
                }
                if (row["K_Exam_Report_endTime"] != null && row["K_Exam_Report_endTime"].ToString() != "")
                {
                    model.K_Exam_Report_endTime = DateTime.Parse(row["K_Exam_Report_endTime"].ToString());
                }
                if (row["K_Exam_Report_elapsedTime"] != null)
                {
                    model.K_Exam_Report_elapsedTime = row["K_Exam_Report_elapsedTime"].ToString();
                }
                if (row["K_ExtInfos_code"] != null && row["K_ExtInfos_code"].ToString() != "")
                {
                    model.K_ExtInfos_code = new Guid(row["K_ExtInfos_code"].ToString());
                }
                if (row["K_Exam_Report_score"] != null && row["K_Exam_Report_score"].ToString() != "")
                {
                    model.K_Exam_Report_score = decimal.Parse(row["K_Exam_Report_score"].ToString());
                }
                if (row["K_Exam_Report_points"] != null && row["K_Exam_Report_points"].ToString() != "")
                {
                    model.K_Exam_Report_points = decimal.Parse(row["K_Exam_Report_points"].ToString());
                }
                if (row["K_Exam_Report_switchTimes"] != null && row["K_Exam_Report_switchTimes"].ToString() != "")
                {
                    model.K_Exam_Report_switchTimes = int.Parse(row["K_Exam_Report_switchTimes"].ToString());
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
            strSql.Append("select K_Exam_Report_code,K_Exam_Students_code,K_Exam_code,K_Exam_Report_title,K_Exam_Report_testId,K_Exam_Report_paperId,K_Exam_Report_beginTime,K_Exam_Report_endTime,K_Exam_Report_elapsedTime,K_ExtInfos_code,K_Exam_Report_score,K_Exam_Report_points,K_Exam_Report_switchTimes ");
            strSql.Append(" FROM K_Exam_Report ");
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
            strSql.Append(" K_Exam_Report_code,K_Exam_Students_code,K_Exam_code,K_Exam_Report_title,K_Exam_Report_testId,K_Exam_Report_paperId,K_Exam_Report_beginTime,K_Exam_Report_endTime,K_Exam_Report_elapsedTime,K_ExtInfos_code,K_Exam_Report_score,K_Exam_Report_points,K_Exam_Report_switchTimes ");
            strSql.Append(" FROM K_Exam_Report ");
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
            strSql.Append("select count(1) FROM K_Exam_Report ");
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
                strSql.Append("order by T.K_Exam_Report_code desc");
            }
            strSql.Append(")AS Row, T.*  from K_Exam_Report T ");
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
            parameters[0].Value = "K_Exam_Report";
            parameters[1].Value = "K_Exam_Report_code";
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
