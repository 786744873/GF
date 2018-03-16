using Maticsoft.DBUtility;
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
    /// 数据访问类:R_LitigationCase_Reporting
    /// </summary>
    public partial class R_LitigationCase_Reporting 
    {
        public R_LitigationCase_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_LitigationCase_Reporting");
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
        public int Add(Model.Reporting.R_LitigationCase_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_LitigationCase_Reporting(");
            strSql.Append("Year,Month,AreaName,HostName,CoName,Case_Number,B_Plaintiff_Name,B_Defendant_Name,B_Project_Name,AcceptanceTime,B_TransferPrice,B_ExpectedPrice,JurisdictionCourt,ProgressCaseMonth,ProgressCompletionTime,PreservationState,EffectiveState,DocumentIncome)");
            strSql.Append(" values (");
            strSql.Append("@Year,@Month,@AreaName,@HostName,@CoName,@Case_Number,@B_Plaintiff_Name,@B_Defendant_Name,@B_Project_Name,@AcceptanceTime,@B_TransferPrice,@B_ExpectedPrice,@JurisdictionCourt,@ProgressCaseMonth,@ProgressCompletionTime,@PreservationState,@EffectiveState,@DocumentIncome)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Year", SqlDbType.VarChar,50),
					new SqlParameter("@Month", SqlDbType.VarChar,50),
					new SqlParameter("@AreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@HostName", SqlDbType.NVarChar,50),
					new SqlParameter("@CoName", SqlDbType.NVarChar,50),
					new SqlParameter("@Case_Number", SqlDbType.VarChar,50),
					new SqlParameter("@B_Plaintiff_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@B_Defendant_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@B_Project_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@AcceptanceTime", SqlDbType.VarChar,50),
					new SqlParameter("@B_TransferPrice", SqlDbType.VarChar,50),
					new SqlParameter("@B_ExpectedPrice", SqlDbType.VarChar,50),
					new SqlParameter("@JurisdictionCourt", SqlDbType.VarChar,150),
					new SqlParameter("@ProgressCaseMonth", SqlDbType.NVarChar,500),
					new SqlParameter("@ProgressCompletionTime", SqlDbType.VarChar,500),
					new SqlParameter("@PreservationState", SqlDbType.NVarChar,50),
					new SqlParameter("@EffectiveState", SqlDbType.NVarChar,50),
					new SqlParameter("@DocumentIncome", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Year;
            parameters[1].Value = model.Month;
            parameters[2].Value = model.AreaName;
            parameters[3].Value = model.HostName;
            parameters[4].Value = model.CoName;
            parameters[5].Value = model.Case_Number;
            parameters[6].Value = model.B_Plaintiff_Name;
            parameters[7].Value = model.B_Defendant_Name;
            parameters[8].Value = model.B_Project_Name;
            parameters[9].Value = model.AcceptanceTime;
            parameters[10].Value = model.B_TransferPrice;
            parameters[11].Value = model.B_ExpectedPrice;
            parameters[12].Value = model.JurisdictionCourt;
            parameters[13].Value = model.ProgressCaseMonth;
            parameters[14].Value = model.ProgressCompletionTime;
            parameters[15].Value = model.PreservationState;
            parameters[16].Value = model.EffectiveState;
            parameters[17].Value = model.DocumentIncome;

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
        public bool Update(Model.Reporting.R_LitigationCase_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_LitigationCase_Reporting set ");
            strSql.Append("Year=@Year,");
            strSql.Append("Month=@Month,");
            strSql.Append("AreaName=@AreaName,");
            strSql.Append("HostName=@HostName,");
            strSql.Append("CoName=@CoName,");
            strSql.Append("Case_Number=@Case_Number,");
            strSql.Append("B_Plaintiff_Name=@B_Plaintiff_Name,");
            strSql.Append("B_Defendant_Name=@B_Defendant_Name,");
            strSql.Append("B_Project_Name=@B_Project_Name,");
            strSql.Append("AcceptanceTime=@AcceptanceTime,");
            strSql.Append("B_TransferPrice=@B_TransferPrice,");
            strSql.Append("B_ExpectedPrice=@B_ExpectedPrice,");
            strSql.Append("JurisdictionCourt=@JurisdictionCourt,");
            strSql.Append("ProgressCaseMonth=@ProgressCaseMonth,");
            strSql.Append("ProgressCompletionTime=@ProgressCompletionTime,");
            strSql.Append("PreservationState=@PreservationState,");
            strSql.Append("EffectiveState=@EffectiveState,");
            strSql.Append("DocumentIncome=@DocumentIncome");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Year", SqlDbType.VarChar,50),
					new SqlParameter("@Month", SqlDbType.VarChar,50),
					new SqlParameter("@AreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@HostName", SqlDbType.NVarChar,50),
					new SqlParameter("@CoName", SqlDbType.NVarChar,50),
					new SqlParameter("@Case_Number", SqlDbType.VarChar,50),
					new SqlParameter("@B_Plaintiff_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@B_Defendant_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@B_Project_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@AcceptanceTime", SqlDbType.VarChar,50),
					new SqlParameter("@B_TransferPrice", SqlDbType.VarChar,50),
					new SqlParameter("@B_ExpectedPrice", SqlDbType.VarChar,50),
					new SqlParameter("@JurisdictionCourt", SqlDbType.VarChar,150),
					new SqlParameter("@ProgressCaseMonth", SqlDbType.NVarChar,500),
					new SqlParameter("@ProgressCompletionTime", SqlDbType.VarChar,500),
					new SqlParameter("@PreservationState", SqlDbType.NVarChar,50),
					new SqlParameter("@EffectiveState", SqlDbType.NVarChar,50),
					new SqlParameter("@DocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Year;
            parameters[1].Value = model.Month;
            parameters[2].Value = model.AreaName;
            parameters[3].Value = model.HostName;
            parameters[4].Value = model.CoName;
            parameters[5].Value = model.Case_Number;
            parameters[6].Value = model.B_Plaintiff_Name;
            parameters[7].Value = model.B_Defendant_Name;
            parameters[8].Value = model.B_Project_Name;
            parameters[9].Value = model.AcceptanceTime;
            parameters[10].Value = model.B_TransferPrice;
            parameters[11].Value = model.B_ExpectedPrice;
            parameters[12].Value = model.JurisdictionCourt;
            parameters[13].Value = model.ProgressCaseMonth;
            parameters[14].Value = model.ProgressCompletionTime;
            parameters[15].Value = model.PreservationState;
            parameters[16].Value = model.EffectiveState;
            parameters[17].Value = model.DocumentIncome;
            parameters[18].Value = model.ID;

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
            strSql.Append("delete from R_LitigationCase_Reporting ");
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
            strSql.Append("delete from R_LitigationCase_Reporting ");
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

        public bool DeleteAll() 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Truncate table R_LitigationCase_Reporting ");
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
        public Model.Reporting.R_LitigationCase_Reporting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Year,Month,AreaName,HostName,CoName,Case_Number,B_Plaintiff_Name,B_Defendant_Name,B_Project_Name,AcceptanceTime,B_TransferPrice,B_ExpectedPrice,JurisdictionCourt,ProgressCaseMonth,ProgressCompletionTime,PreservationState,EffectiveState,DocumentIncome from R_LitigationCase_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Reporting.R_LitigationCase_Reporting model = new Model.Reporting.R_LitigationCase_Reporting();
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
        public Model.Reporting.R_LitigationCase_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_LitigationCase_Reporting model = new Model.Reporting.R_LitigationCase_Reporting();
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
                if (row["Case_Number"] != null)
                {
                    model.Case_Number = row["Case_Number"].ToString();
                }
                if (row["B_Plaintiff_Name"] != null)
                {
                    model.B_Plaintiff_Name = row["B_Plaintiff_Name"].ToString();
                }
                if (row["B_Defendant_Name"] != null)
                {
                    model.B_Defendant_Name = row["B_Defendant_Name"].ToString();
                }
                if (row["B_Project_Name"] != null)
                {
                    model.B_Project_Name = row["B_Project_Name"].ToString();
                }
                if (row["AcceptanceTime"] != null)
                {
                    model.AcceptanceTime = row["AcceptanceTime"].ToString();
                }
                if (row["B_TransferPrice"] != null)
                {
                    model.B_TransferPrice = row["B_TransferPrice"].ToString();
                }
                if (row["B_ExpectedPrice"] != null)
                {
                    model.B_ExpectedPrice = row["B_ExpectedPrice"].ToString();
                }
                if (row["JurisdictionCourt"] != null)
                {
                    model.JurisdictionCourt = row["JurisdictionCourt"].ToString();
                }
                if (row["ProgressCaseMonth"] != null)
                {
                    model.ProgressCaseMonth = row["ProgressCaseMonth"].ToString();
                }
                if (row["ProgressCompletionTime"] != null)
                {
                    model.ProgressCompletionTime = row["ProgressCompletionTime"].ToString();
                }
                if (row["PreservationState"] != null)
                {
                    model.PreservationState = row["PreservationState"].ToString();
                }
                if (row["EffectiveState"] != null)
                {
                    model.EffectiveState = row["EffectiveState"].ToString();
                }
                if (row["DocumentIncome"] != null)
                {
                    model.DocumentIncome = row["DocumentIncome"].ToString();
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
            strSql.Append("select ID,Year,Month,AreaName,HostName,CoName,Case_Number,B_Plaintiff_Name,B_Defendant_Name,B_Project_Name,AcceptanceTime,B_TransferPrice,B_ExpectedPrice,JurisdictionCourt,ProgressCaseMonth,ProgressCompletionTime,PreservationState,EffectiveState,DocumentIncome ");
            strSql.Append(" FROM R_LitigationCase_Reporting ");
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
            strSql.Append(" ID,Year,Month,AreaName,HostName,CoName,Case_Number,B_Plaintiff_Name,B_Defendant_Name,B_Project_Name,AcceptanceTime,B_TransferPrice,B_ExpectedPrice,JurisdictionCourt,ProgressCaseMonth,ProgressCompletionTime,PreservationState,EffectiveState,DocumentIncome ");
            strSql.Append(" FROM R_LitigationCase_Reporting ");
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
            strSql.Append("select count(1) FROM R_LitigationCase_Reporting ");
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
            strSql.Append(")AS Row, T.*  from R_LitigationCase_Reporting T ");
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
            parameters[0].Value = "R_LitigationCase_Reporting";
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

