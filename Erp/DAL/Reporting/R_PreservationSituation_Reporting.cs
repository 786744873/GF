﻿using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.Reporting
{
    /// <summary>
    /// 数据访问类:R_PreservationSituation_Reporting
    /// </summary>
    public partial class R_PreservationSituation_Reporting 
    {
        public R_PreservationSituation_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_PreservationSituation_Reporting");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Reporting.R_PreservationSituation_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_PreservationSituation_Reporting(");
            strSql.Append("Year,Month,AreaName,HostName,CoName,StageDevelopment,Total,HandOver,ExpectedandDocumentIncome,NoSecurityCasesNumber,NoSecurityHandOver,NoSecurityExpectedandDocumentIncome,ActualNumberCases,ActualHandOver,ActualExpectedandDocumentIncome,AExteCases,AExteHandOver,AExteActualExpectedandDocumentIncome,CompletionCasesNumber,CompletionHandOver,CompletionExpectedandDocumentIncome,NormalCaseNumber,NormalHandOver,NormalExpectedandDocumentIncome,FullSecurityNumber,FullSecurityHandOver,FullSecurityExpectedandDocumentIncome,NoFullSecurityNumber,NoFullSecurityHandOver,NoFullSecurityExpectedandDocumentIncome)");
            strSql.Append(" values (");
            strSql.Append("@Year,@Month,@AreaName,@HostName,@CoName,@StageDevelopment,@Total,@HandOver,@ExpectedandDocumentIncome,@NoSecurityCasesNumber,@NoSecurityHandOver,@NoSecurityExpectedandDocumentIncome,@ActualNumberCases,@ActualHandOver,@ActualExpectedandDocumentIncome,@AExteCases,@AExteHandOver,@AExteActualExpectedandDocumentIncome,@CompletionCasesNumber,@CompletionHandOver,@CompletionExpectedandDocumentIncome,@NormalCaseNumber,@NormalHandOver,@NormalExpectedandDocumentIncome,@FullSecurityNumber,@FullSecurityHandOver,@FullSecurityExpectedandDocumentIncome,@NoFullSecurityNumber,@NoFullSecurityHandOver,@NoFullSecurityExpectedandDocumentIncome)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Year", SqlDbType.VarChar,50),
					new SqlParameter("@Month", SqlDbType.VarChar,50),
					new SqlParameter("@AreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@HostName", SqlDbType.NVarChar,50),
					new SqlParameter("@CoName", SqlDbType.NVarChar,50),
					new SqlParameter("@StageDevelopment", SqlDbType.NVarChar,150),
					new SqlParameter("@Total", SqlDbType.VarChar,50),
					new SqlParameter("@HandOver", SqlDbType.VarChar,50),
					new SqlParameter("@ExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NoSecurityCasesNumber", SqlDbType.VarChar,50),
					new SqlParameter("@NoSecurityHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@NoSecurityExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ActualNumberCases", SqlDbType.VarChar,50),
					new SqlParameter("@ActualHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@ActualExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@AExteCases", SqlDbType.VarChar,50),
					new SqlParameter("@AExteHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@AExteActualExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionCasesNumber", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NormalCaseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@NormalHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@NormalExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@FullSecurityNumber", SqlDbType.VarChar,50),
					new SqlParameter("@FullSecurityHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@FullSecurityExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NoFullSecurityNumber", SqlDbType.VarChar,50),
					new SqlParameter("@NoFullSecurityHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@NoFullSecurityExpectedandDocumentIncome", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Year;
            parameters[1].Value = model.Month;
            parameters[2].Value = model.AreaName;
            parameters[3].Value = model.HostName;
            parameters[4].Value = model.CoName;
            parameters[5].Value = model.StageDevelopment;
            parameters[6].Value = model.Total;
            parameters[7].Value = model.HandOver;
            parameters[8].Value = model.ExpectedandDocumentIncome;
            parameters[9].Value = model.NoSecurityCasesNumber;
            parameters[10].Value = model.NoSecurityHandOver;
            parameters[11].Value = model.NoSecurityExpectedandDocumentIncome;
            parameters[12].Value = model.ActualNumberCases;
            parameters[13].Value = model.ActualHandOver;
            parameters[14].Value = model.ActualExpectedandDocumentIncome;
            parameters[15].Value = model.AExteCases;
            parameters[16].Value = model.AExteHandOver;
            parameters[17].Value = model.AExteActualExpectedandDocumentIncome;
            parameters[18].Value = model.CompletionCasesNumber;
            parameters[19].Value = model.CompletionHandOver;
            parameters[20].Value = model.CompletionExpectedandDocumentIncome;
            parameters[21].Value = model.NormalCaseNumber;
            parameters[22].Value = model.NormalHandOver;
            parameters[23].Value = model.NormalExpectedandDocumentIncome;
            parameters[24].Value = model.FullSecurityNumber;
            parameters[25].Value = model.FullSecurityHandOver;
            parameters[26].Value = model.FullSecurityExpectedandDocumentIncome;
            parameters[27].Value = model.NoFullSecurityNumber;
            parameters[28].Value = model.NoFullSecurityHandOver;
            parameters[29].Value = model.NoFullSecurityExpectedandDocumentIncome;

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
        public bool Update(Model.Reporting.R_PreservationSituation_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_PreservationSituation_Reporting set ");
            strSql.Append("Year=@Year,");
            strSql.Append("Month=@Month,");
            strSql.Append("AreaName=@AreaName,");
            strSql.Append("HostName=@HostName,");
            strSql.Append("CoName=@CoName,");
            strSql.Append("StageDevelopment=@StageDevelopment,");
            strSql.Append("Total=@Total,");
            strSql.Append("HandOver=@HandOver,");
            strSql.Append("ExpectedandDocumentIncome=@ExpectedandDocumentIncome,");
            strSql.Append("NoSecurityCasesNumber=@NoSecurityCasesNumber,");
            strSql.Append("NoSecurityHandOver=@NoSecurityHandOver,");
            strSql.Append("NoSecurityExpectedandDocumentIncome=@NoSecurityExpectedandDocumentIncome,");
            strSql.Append("ActualNumberCases=@ActualNumberCases,");
            strSql.Append("ActualHandOver=@ActualHandOver,");
            strSql.Append("ActualExpectedandDocumentIncome=@ActualExpectedandDocumentIncome,");
            strSql.Append("AExteCases=@AExteCases,");
            strSql.Append("AExteHandOver=@AExteHandOver,");
            strSql.Append("AExteActualExpectedandDocumentIncome=@AExteActualExpectedandDocumentIncome,");
            strSql.Append("CompletionCasesNumber=@CompletionCasesNumber,");
            strSql.Append("CompletionHandOver=@CompletionHandOver,");
            strSql.Append("CompletionExpectedandDocumentIncome=@CompletionExpectedandDocumentIncome,");
            strSql.Append("NormalCaseNumber=@NormalCaseNumber,");
            strSql.Append("NormalHandOver=@NormalHandOver,");
            strSql.Append("NormalExpectedandDocumentIncome=@NormalExpectedandDocumentIncome,");
            strSql.Append("FullSecurityNumber=@FullSecurityNumber,");
            strSql.Append("FullSecurityHandOver=@FullSecurityHandOver,");
            strSql.Append("FullSecurityExpectedandDocumentIncome=@FullSecurityExpectedandDocumentIncome,");
            strSql.Append("NoFullSecurityNumber=@NoFullSecurityNumber,");
            strSql.Append("NoFullSecurityHandOver=@NoFullSecurityHandOver,");
            strSql.Append("NoFullSecurityExpectedandDocumentIncome=@NoFullSecurityExpectedandDocumentIncome");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Year", SqlDbType.VarChar,50),
					new SqlParameter("@Month", SqlDbType.VarChar,50),
					new SqlParameter("@AreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@HostName", SqlDbType.NVarChar,50),
					new SqlParameter("@CoName", SqlDbType.NVarChar,50),
					new SqlParameter("@StageDevelopment", SqlDbType.NVarChar,150),
					new SqlParameter("@Total", SqlDbType.VarChar,50),
					new SqlParameter("@HandOver", SqlDbType.VarChar,50),
					new SqlParameter("@ExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NoSecurityCasesNumber", SqlDbType.VarChar,50),
					new SqlParameter("@NoSecurityHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@NoSecurityExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ActualNumberCases", SqlDbType.VarChar,50),
					new SqlParameter("@ActualHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@ActualExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@AExteCases", SqlDbType.VarChar,50),
					new SqlParameter("@AExteHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@AExteActualExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionCasesNumber", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NormalCaseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@NormalHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@NormalExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@FullSecurityNumber", SqlDbType.VarChar,50),
					new SqlParameter("@FullSecurityHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@FullSecurityExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NoFullSecurityNumber", SqlDbType.VarChar,50),
					new SqlParameter("@NoFullSecurityHandOver", SqlDbType.VarChar,50),
					new SqlParameter("@NoFullSecurityExpectedandDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Year;
            parameters[1].Value = model.Month;
            parameters[2].Value = model.AreaName;
            parameters[3].Value = model.HostName;
            parameters[4].Value = model.CoName;
            parameters[5].Value = model.StageDevelopment;
            parameters[6].Value = model.Total;
            parameters[7].Value = model.HandOver;
            parameters[8].Value = model.ExpectedandDocumentIncome;
            parameters[9].Value = model.NoSecurityCasesNumber;
            parameters[10].Value = model.NoSecurityHandOver;
            parameters[11].Value = model.NoSecurityExpectedandDocumentIncome;
            parameters[12].Value = model.ActualNumberCases;
            parameters[13].Value = model.ActualHandOver;
            parameters[14].Value = model.ActualExpectedandDocumentIncome;
            parameters[15].Value = model.AExteCases;
            parameters[16].Value = model.AExteHandOver;
            parameters[17].Value = model.AExteActualExpectedandDocumentIncome;
            parameters[18].Value = model.CompletionCasesNumber;
            parameters[19].Value = model.CompletionHandOver;
            parameters[20].Value = model.CompletionExpectedandDocumentIncome;
            parameters[21].Value = model.NormalCaseNumber;
            parameters[22].Value = model.NormalHandOver;
            parameters[23].Value = model.NormalExpectedandDocumentIncome;
            parameters[24].Value = model.FullSecurityNumber;
            parameters[25].Value = model.FullSecurityHandOver;
            parameters[26].Value = model.FullSecurityExpectedandDocumentIncome;
            parameters[27].Value = model.NoFullSecurityNumber;
            parameters[28].Value = model.NoFullSecurityHandOver;
            parameters[29].Value = model.NoFullSecurityExpectedandDocumentIncome;
            parameters[30].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_PreservationSituation_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_PreservationSituation_Reporting ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Model.Reporting.R_PreservationSituation_Reporting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Year,Month,AreaName,HostName,CoName,StageDevelopment,Total,HandOver,ExpectedandDocumentIncome,NoSecurityCasesNumber,NoSecurityHandOver,NoSecurityExpectedandDocumentIncome,ActualNumberCases,ActualHandOver,ActualExpectedandDocumentIncome,AExteCases,AExteHandOver,AExteActualExpectedandDocumentIncome,CompletionCasesNumber,CompletionHandOver,CompletionExpectedandDocumentIncome,NormalCaseNumber,NormalHandOver,NormalExpectedandDocumentIncome,FullSecurityNumber,FullSecurityHandOver,FullSecurityExpectedandDocumentIncome,NoFullSecurityNumber,NoFullSecurityHandOver,NoFullSecurityExpectedandDocumentIncome from R_PreservationSituation_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Reporting.R_PreservationSituation_Reporting model = new Model.Reporting.R_PreservationSituation_Reporting();
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
        public Model.Reporting.R_PreservationSituation_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_PreservationSituation_Reporting model = new Model.Reporting.R_PreservationSituation_Reporting();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Year"] != null)
                {
                    model.Year = row["Year"].ToString();
                }
                if (row["Month"] != null)
                {
                    model.Month = row["Month"].ToString();
                }
                if (row["AreaName"] != null)
                {
                    model.AreaName = row["AreaName"].ToString();
                }
                if (row["HostName"] != null)
                {
                    model.HostName = row["HostName"].ToString();
                }
                if (row["CoName"] != null)
                {
                    model.CoName = row["CoName"].ToString();
                }
                if (row["StageDevelopment"] != null)
                {
                    model.StageDevelopment = row["StageDevelopment"].ToString();
                }
                if (row["Total"] != null)
                {
                    model.Total = row["Total"].ToString();
                }
                if (row["HandOver"] != null)
                {
                    model.HandOver = row["HandOver"].ToString();
                }
                if (row["ExpectedandDocumentIncome"] != null)
                {
                    model.ExpectedandDocumentIncome = row["ExpectedandDocumentIncome"].ToString();
                }
                if (row["NoSecurityCasesNumber"] != null)
                {
                    model.NoSecurityCasesNumber = row["NoSecurityCasesNumber"].ToString();
                }
                if (row["NoSecurityHandOver"] != null)
                {
                    model.NoSecurityHandOver = row["NoSecurityHandOver"].ToString();
                }
                if (row["NoSecurityExpectedandDocumentIncome"] != null)
                {
                    model.NoSecurityExpectedandDocumentIncome = row["NoSecurityExpectedandDocumentIncome"].ToString();
                }
                if (row["ActualNumberCases"] != null)
                {
                    model.ActualNumberCases = row["ActualNumberCases"].ToString();
                }
                if (row["ActualHandOver"] != null)
                {
                    model.ActualHandOver = row["ActualHandOver"].ToString();
                }
                if (row["ActualExpectedandDocumentIncome"] != null)
                {
                    model.ActualExpectedandDocumentIncome = row["ActualExpectedandDocumentIncome"].ToString();
                }
                if (row["AExteCases"] != null)
                {
                    model.AExteCases = row["AExteCases"].ToString();
                }
                if (row["AExteHandOver"] != null)
                {
                    model.AExteHandOver = row["AExteHandOver"].ToString();
                }
                if (row["AExteActualExpectedandDocumentIncome"] != null)
                {
                    model.AExteActualExpectedandDocumentIncome = row["AExteActualExpectedandDocumentIncome"].ToString();
                }
                if (row["CompletionCasesNumber"] != null)
                {
                    model.CompletionCasesNumber = row["CompletionCasesNumber"].ToString();
                }
                if (row["CompletionHandOver"] != null)
                {
                    model.CompletionHandOver = row["CompletionHandOver"].ToString();
                }
                if (row["CompletionExpectedandDocumentIncome"] != null)
                {
                    model.CompletionExpectedandDocumentIncome = row["CompletionExpectedandDocumentIncome"].ToString();
                }
                if (row["NormalCaseNumber"] != null)
                {
                    model.NormalCaseNumber = row["NormalCaseNumber"].ToString();
                }
                if (row["NormalHandOver"] != null)
                {
                    model.NormalHandOver = row["NormalHandOver"].ToString();
                }
                if (row["NormalExpectedandDocumentIncome"] != null)
                {
                    model.NormalExpectedandDocumentIncome = row["NormalExpectedandDocumentIncome"].ToString();
                }
                if (row["FullSecurityNumber"] != null)
                {
                    model.FullSecurityNumber = row["FullSecurityNumber"].ToString();
                }
                if (row["FullSecurityHandOver"] != null)
                {
                    model.FullSecurityHandOver = row["FullSecurityHandOver"].ToString();
                }
                if (row["FullSecurityExpectedandDocumentIncome"] != null)
                {
                    model.FullSecurityExpectedandDocumentIncome = row["FullSecurityExpectedandDocumentIncome"].ToString();
                }
                if (row["NoFullSecurityNumber"] != null)
                {
                    model.NoFullSecurityNumber = row["NoFullSecurityNumber"].ToString();
                }
                if (row["NoFullSecurityHandOver"] != null)
                {
                    model.NoFullSecurityHandOver = row["NoFullSecurityHandOver"].ToString();
                }
                if (row["NoFullSecurityExpectedandDocumentIncome"] != null)
                {
                    model.NoFullSecurityExpectedandDocumentIncome = row["NoFullSecurityExpectedandDocumentIncome"].ToString();
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
            strSql.Append("select ID,Year,Month,AreaName,HostName,CoName,StageDevelopment,Total,HandOver,ExpectedandDocumentIncome,NoSecurityCasesNumber,NoSecurityHandOver,NoSecurityExpectedandDocumentIncome,ActualNumberCases,ActualHandOver,ActualExpectedandDocumentIncome,AExteCases,AExteHandOver,AExteActualExpectedandDocumentIncome,CompletionCasesNumber,CompletionHandOver,CompletionExpectedandDocumentIncome,NormalCaseNumber,NormalHandOver,NormalExpectedandDocumentIncome,FullSecurityNumber,FullSecurityHandOver,FullSecurityExpectedandDocumentIncome,NoFullSecurityNumber,NoFullSecurityHandOver,NoFullSecurityExpectedandDocumentIncome ");
            strSql.Append(" FROM R_PreservationSituation_Reporting ");
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
            strSql.Append(" ID,Year,Month,AreaName,HostName,CoName,StageDevelopment,Total,HandOver,ExpectedandDocumentIncome,NoSecurityCasesNumber,NoSecurityHandOver,NoSecurityExpectedandDocumentIncome,ActualNumberCases,ActualHandOver,ActualExpectedandDocumentIncome,AExteCases,AExteHandOver,AExteActualExpectedandDocumentIncome,CompletionCasesNumber,CompletionHandOver,CompletionExpectedandDocumentIncome,NormalCaseNumber,NormalHandOver,NormalExpectedandDocumentIncome,FullSecurityNumber,FullSecurityHandOver,FullSecurityExpectedandDocumentIncome,NoFullSecurityNumber,NoFullSecurityHandOver,NoFullSecurityExpectedandDocumentIncome ");
            strSql.Append(" FROM R_PreservationSituation_Reporting ");
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
            strSql.Append("select count(1) FROM R_PreservationSituation_Reporting ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from R_PreservationSituation_Reporting T ");
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
            parameters[0].Value = "R_PreservationSituation_Reporting";
            parameters[1].Value = "ID";
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
