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
    /// 数据访问类:R_ImplementationMeasures_Reporting
    /// </summary>
    public partial class R_ImplementationMeasures_Reporting 
    {
        public R_ImplementationMeasures_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_ImplementationMeasures_Reporting");
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
        public int Add(Model.Reporting.R_ImplementationMeasures_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_ImplementationMeasures_Reporting(");
            strSql.Append("Year,Month,AreaName,HostName,CoName,StageDevelopment,Total,ExecutiveSubject,DocumentIncome,OverdueIncome,ActualTotal,ActualExecutiveSubject,ActualDocumentIncome,ActualOverdueIncome,ApplicationTotal,ApplicationExecutiveSubject,ApplicationDocumentIncome,ApplicationOverdueIncome,Total_2,CompletionTotal,CompletionExecutiveSubject,CompletionDocumentIncome,CompletionOverdueIncome,NormalTotal,NormalExecutiveSubject,NormalDocumentIncome,NormalOverdueIncome,BankDeposit,Vehicle,HouseProperty,Land,Detention,Other,ExecutionPlan,Amount)");
            strSql.Append(" values (");
            strSql.Append("@Year,@Month,@AreaName,@HostName,@CoName,@StageDevelopment,@Total,@ExecutiveSubject,@DocumentIncome,@OverdueIncome,@ActualTotal,@ActualExecutiveSubject,@ActualDocumentIncome,@ActualOverdueIncome,@ApplicationTotal,@ApplicationExecutiveSubject,@ApplicationDocumentIncome,@ApplicationOverdueIncome,@Total_2,@CompletionTotal,@CompletionExecutiveSubject,@CompletionDocumentIncome,@CompletionOverdueIncome,@NormalTotal,@NormalExecutiveSubject,@NormalDocumentIncome,@NormalOverdueIncome,@BankDeposit,@Vehicle,@HouseProperty,@Land,@Detention,@Other,@ExecutionPlan,@Amount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Year", SqlDbType.VarChar,50),
					new SqlParameter("@Month", SqlDbType.VarChar,50),
					new SqlParameter("@AreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@HostName", SqlDbType.NVarChar,50),
					new SqlParameter("@CoName", SqlDbType.NVarChar,50),
					new SqlParameter("@StageDevelopment", SqlDbType.NVarChar,150),
					new SqlParameter("@Total", SqlDbType.VarChar,50),
					new SqlParameter("@ExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@DocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@OverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ActualTotal", SqlDbType.VarChar,50),
					new SqlParameter("@ActualExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@ActualDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ActualOverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ApplicationTotal", SqlDbType.VarChar,50),
					new SqlParameter("@ApplicationExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@ApplicationDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ApplicationOverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@Total_2", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionTotal", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionOverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NormalTotal", SqlDbType.VarChar,50),
					new SqlParameter("@NormalExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@NormalDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NormalOverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@BankDeposit", SqlDbType.VarChar,50),
					new SqlParameter("@Vehicle", SqlDbType.VarChar,50),
					new SqlParameter("@HouseProperty", SqlDbType.VarChar,50),
					new SqlParameter("@Land", SqlDbType.VarChar,50),
					new SqlParameter("@Detention", SqlDbType.VarChar,50),
					new SqlParameter("@Other", SqlDbType.VarChar,50),
					new SqlParameter("@ExecutionPlan", SqlDbType.VarChar,50),
					new SqlParameter("@Amount", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Year;
            parameters[1].Value = model.Month;
            parameters[2].Value = model.AreaName;
            parameters[3].Value = model.HostName;
            parameters[4].Value = model.CoName;
            parameters[5].Value = model.StageDevelopment;
            parameters[6].Value = model.Total;
            parameters[7].Value = model.ExecutiveSubject;
            parameters[8].Value = model.DocumentIncome;
            parameters[9].Value = model.OverdueIncome;
            parameters[10].Value = model.ActualTotal;
            parameters[11].Value = model.ActualExecutiveSubject;
            parameters[12].Value = model.ActualDocumentIncome;
            parameters[13].Value = model.ActualOverdueIncome;
            parameters[14].Value = model.ApplicationTotal;
            parameters[15].Value = model.ApplicationExecutiveSubject;
            parameters[16].Value = model.ApplicationDocumentIncome;
            parameters[17].Value = model.ApplicationOverdueIncome;
            parameters[18].Value = model.Total_2;
            parameters[19].Value = model.CompletionTotal;
            parameters[20].Value = model.CompletionExecutiveSubject;
            parameters[21].Value = model.CompletionDocumentIncome;
            parameters[22].Value = model.CompletionOverdueIncome;
            parameters[23].Value = model.NormalTotal;
            parameters[24].Value = model.NormalExecutiveSubject;
            parameters[25].Value = model.NormalDocumentIncome;
            parameters[26].Value = model.NormalOverdueIncome;
            parameters[27].Value = model.BankDeposit;
            parameters[28].Value = model.Vehicle;
            parameters[29].Value = model.HouseProperty;
            parameters[30].Value = model.Land;
            parameters[31].Value = model.Detention;
            parameters[32].Value = model.Other;
            parameters[33].Value = model.ExecutionPlan;
            parameters[34].Value = model.Amount;

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
        public bool Update(Model.Reporting.R_ImplementationMeasures_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_ImplementationMeasures_Reporting set ");
            strSql.Append("Year=@Year,");
            strSql.Append("Month=@Month,");
            strSql.Append("AreaName=@AreaName,");
            strSql.Append("HostName=@HostName,");
            strSql.Append("CoName=@CoName,");
            strSql.Append("StageDevelopment=@StageDevelopment,");
            strSql.Append("Total=@Total,");
            strSql.Append("ExecutiveSubject=@ExecutiveSubject,");
            strSql.Append("DocumentIncome=@DocumentIncome,");
            strSql.Append("OverdueIncome=@OverdueIncome,");
            strSql.Append("ActualTotal=@ActualTotal,");
            strSql.Append("ActualExecutiveSubject=@ActualExecutiveSubject,");
            strSql.Append("ActualDocumentIncome=@ActualDocumentIncome,");
            strSql.Append("ActualOverdueIncome=@ActualOverdueIncome,");
            strSql.Append("ApplicationTotal=@ApplicationTotal,");
            strSql.Append("ApplicationExecutiveSubject=@ApplicationExecutiveSubject,");
            strSql.Append("ApplicationDocumentIncome=@ApplicationDocumentIncome,");
            strSql.Append("ApplicationOverdueIncome=@ApplicationOverdueIncome,");
            strSql.Append("Total_2=@Total_2,");
            strSql.Append("CompletionTotal=@CompletionTotal,");
            strSql.Append("CompletionExecutiveSubject=@CompletionExecutiveSubject,");
            strSql.Append("CompletionDocumentIncome=@CompletionDocumentIncome,");
            strSql.Append("CompletionOverdueIncome=@CompletionOverdueIncome,");
            strSql.Append("NormalTotal=@NormalTotal,");
            strSql.Append("NormalExecutiveSubject=@NormalExecutiveSubject,");
            strSql.Append("NormalDocumentIncome=@NormalDocumentIncome,");
            strSql.Append("NormalOverdueIncome=@NormalOverdueIncome,");
            strSql.Append("BankDeposit=@BankDeposit,");
            strSql.Append("Vehicle=@Vehicle,");
            strSql.Append("HouseProperty=@HouseProperty,");
            strSql.Append("Land=@Land,");
            strSql.Append("Detention=@Detention,");
            strSql.Append("Other=@Other,");
            strSql.Append("ExecutionPlan=@ExecutionPlan,");
            strSql.Append("Amount=@Amount");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Year", SqlDbType.VarChar,50),
					new SqlParameter("@Month", SqlDbType.VarChar,50),
					new SqlParameter("@AreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@HostName", SqlDbType.NVarChar,50),
					new SqlParameter("@CoName", SqlDbType.NVarChar,50),
					new SqlParameter("@StageDevelopment", SqlDbType.NVarChar,150),
					new SqlParameter("@Total", SqlDbType.VarChar,50),
					new SqlParameter("@ExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@DocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@OverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ActualTotal", SqlDbType.VarChar,50),
					new SqlParameter("@ActualExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@ActualDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ActualOverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ApplicationTotal", SqlDbType.VarChar,50),
					new SqlParameter("@ApplicationExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@ApplicationDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@ApplicationOverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@Total_2", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionTotal", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@CompletionOverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NormalTotal", SqlDbType.VarChar,50),
					new SqlParameter("@NormalExecutiveSubject", SqlDbType.VarChar,50),
					new SqlParameter("@NormalDocumentIncome", SqlDbType.VarChar,50),
					new SqlParameter("@NormalOverdueIncome", SqlDbType.VarChar,50),
					new SqlParameter("@BankDeposit", SqlDbType.VarChar,50),
					new SqlParameter("@Vehicle", SqlDbType.VarChar,50),
					new SqlParameter("@HouseProperty", SqlDbType.VarChar,50),
					new SqlParameter("@Land", SqlDbType.VarChar,50),
					new SqlParameter("@Detention", SqlDbType.VarChar,50),
					new SqlParameter("@Other", SqlDbType.VarChar,50),
					new SqlParameter("@ExecutionPlan", SqlDbType.VarChar,50),
					new SqlParameter("@Amount", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Year;
            parameters[1].Value = model.Month;
            parameters[2].Value = model.AreaName;
            parameters[3].Value = model.HostName;
            parameters[4].Value = model.CoName;
            parameters[5].Value = model.StageDevelopment;
            parameters[6].Value = model.Total;
            parameters[7].Value = model.ExecutiveSubject;
            parameters[8].Value = model.DocumentIncome;
            parameters[9].Value = model.OverdueIncome;
            parameters[10].Value = model.ActualTotal;
            parameters[11].Value = model.ActualExecutiveSubject;
            parameters[12].Value = model.ActualDocumentIncome;
            parameters[13].Value = model.ActualOverdueIncome;
            parameters[14].Value = model.ApplicationTotal;
            parameters[15].Value = model.ApplicationExecutiveSubject;
            parameters[16].Value = model.ApplicationDocumentIncome;
            parameters[17].Value = model.ApplicationOverdueIncome;
            parameters[18].Value = model.Total_2;
            parameters[19].Value = model.CompletionTotal;
            parameters[20].Value = model.CompletionExecutiveSubject;
            parameters[21].Value = model.CompletionDocumentIncome;
            parameters[22].Value = model.CompletionOverdueIncome;
            parameters[23].Value = model.NormalTotal;
            parameters[24].Value = model.NormalExecutiveSubject;
            parameters[25].Value = model.NormalDocumentIncome;
            parameters[26].Value = model.NormalOverdueIncome;
            parameters[27].Value = model.BankDeposit;
            parameters[28].Value = model.Vehicle;
            parameters[29].Value = model.HouseProperty;
            parameters[30].Value = model.Land;
            parameters[31].Value = model.Detention;
            parameters[32].Value = model.Other;
            parameters[33].Value = model.ExecutionPlan;
            parameters[34].Value = model.Amount;
            parameters[35].Value = model.ID;

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
            strSql.Append("delete from R_ImplementationMeasures_Reporting ");
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
            strSql.Append("delete from R_ImplementationMeasures_Reporting ");
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
        public Model.Reporting.R_ImplementationMeasures_Reporting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Year,Month,AreaName,HostName,CoName,StageDevelopment,Total,ExecutiveSubject,DocumentIncome,OverdueIncome,ActualTotal,ActualExecutiveSubject,ActualDocumentIncome,ActualOverdueIncome,ApplicationTotal,ApplicationExecutiveSubject,ApplicationDocumentIncome,ApplicationOverdueIncome,Total_2,CompletionTotal,CompletionExecutiveSubject,CompletionDocumentIncome,CompletionOverdueIncome,NormalTotal,NormalExecutiveSubject,NormalDocumentIncome,NormalOverdueIncome,BankDeposit,Vehicle,HouseProperty,Land,Detention,Other,ExecutionPlan,Amount from R_ImplementationMeasures_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Reporting.R_ImplementationMeasures_Reporting model = new Model.Reporting.R_ImplementationMeasures_Reporting();
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
        public Model.Reporting.R_ImplementationMeasures_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_ImplementationMeasures_Reporting model = new Model.Reporting.R_ImplementationMeasures_Reporting();
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
                if (row["ExecutiveSubject"] != null)
                {
                    model.ExecutiveSubject = row["ExecutiveSubject"].ToString();
                }
                if (row["DocumentIncome"] != null)
                {
                    model.DocumentIncome = row["DocumentIncome"].ToString();
                }
                if (row["OverdueIncome"] != null)
                {
                    model.OverdueIncome = row["OverdueIncome"].ToString();
                }
                if (row["ActualTotal"] != null)
                {
                    model.ActualTotal = row["ActualTotal"].ToString();
                }
                if (row["ActualExecutiveSubject"] != null)
                {
                    model.ActualExecutiveSubject = row["ActualExecutiveSubject"].ToString();
                }
                if (row["ActualDocumentIncome"] != null)
                {
                    model.ActualDocumentIncome = row["ActualDocumentIncome"].ToString();
                }
                if (row["ActualOverdueIncome"] != null)
                {
                    model.ActualOverdueIncome = row["ActualOverdueIncome"].ToString();
                }
                if (row["ApplicationTotal"] != null)
                {
                    model.ApplicationTotal = row["ApplicationTotal"].ToString();
                }
                if (row["ApplicationExecutiveSubject"] != null)
                {
                    model.ApplicationExecutiveSubject = row["ApplicationExecutiveSubject"].ToString();
                }
                if (row["ApplicationDocumentIncome"] != null)
                {
                    model.ApplicationDocumentIncome = row["ApplicationDocumentIncome"].ToString();
                }
                if (row["ApplicationOverdueIncome"] != null)
                {
                    model.ApplicationOverdueIncome = row["ApplicationOverdueIncome"].ToString();
                }
                if (row["Total_2"] != null)
                {
                    model.Total_2 = row["Total_2"].ToString();
                }
                if (row["CompletionTotal"] != null)
                {
                    model.CompletionTotal = row["CompletionTotal"].ToString();
                }
                if (row["CompletionExecutiveSubject"] != null)
                {
                    model.CompletionExecutiveSubject = row["CompletionExecutiveSubject"].ToString();
                }
                if (row["CompletionDocumentIncome"] != null)
                {
                    model.CompletionDocumentIncome = row["CompletionDocumentIncome"].ToString();
                }
                if (row["CompletionOverdueIncome"] != null)
                {
                    model.CompletionOverdueIncome = row["CompletionOverdueIncome"].ToString();
                }
                if (row["NormalTotal"] != null)
                {
                    model.NormalTotal = row["NormalTotal"].ToString();
                }
                if (row["NormalExecutiveSubject"] != null)
                {
                    model.NormalExecutiveSubject = row["NormalExecutiveSubject"].ToString();
                }
                if (row["NormalDocumentIncome"] != null)
                {
                    model.NormalDocumentIncome = row["NormalDocumentIncome"].ToString();
                }
                if (row["NormalOverdueIncome"] != null)
                {
                    model.NormalOverdueIncome = row["NormalOverdueIncome"].ToString();
                }
                if (row["BankDeposit"] != null)
                {
                    model.BankDeposit = row["BankDeposit"].ToString();
                }
                if (row["Vehicle"] != null)
                {
                    model.Vehicle = row["Vehicle"].ToString();
                }
                if (row["HouseProperty"] != null)
                {
                    model.HouseProperty = row["HouseProperty"].ToString();
                }
                if (row["Land"] != null)
                {
                    model.Land = row["Land"].ToString();
                }
                if (row["Detention"] != null)
                {
                    model.Detention = row["Detention"].ToString();
                }
                if (row["Other"] != null)
                {
                    model.Other = row["Other"].ToString();
                }
                if (row["ExecutionPlan"] != null)
                {
                    model.ExecutionPlan = row["ExecutionPlan"].ToString();
                }
                if (row["Amount"] != null)
                {
                    model.Amount = row["Amount"].ToString();
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
            strSql.Append("select ID,Year,Month,AreaName,HostName,CoName,StageDevelopment,Total,ExecutiveSubject,DocumentIncome,OverdueIncome,ActualTotal,ActualExecutiveSubject,ActualDocumentIncome,ActualOverdueIncome,ApplicationTotal,ApplicationExecutiveSubject,ApplicationDocumentIncome,ApplicationOverdueIncome,Total_2,CompletionTotal,CompletionExecutiveSubject,CompletionDocumentIncome,CompletionOverdueIncome,NormalTotal,NormalExecutiveSubject,NormalDocumentIncome,NormalOverdueIncome,BankDeposit,Vehicle,HouseProperty,Land,Detention,Other,ExecutionPlan,Amount ");
            strSql.Append(" FROM R_ImplementationMeasures_Reporting ");
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
            strSql.Append(" ID,Year,Month,AreaName,HostName,CoName,StageDevelopment,Total,ExecutiveSubject,DocumentIncome,OverdueIncome,ActualTotal,ActualExecutiveSubject,ActualDocumentIncome,ActualOverdueIncome,ApplicationTotal,ApplicationExecutiveSubject,ApplicationDocumentIncome,ApplicationOverdueIncome,Total_2,CompletionTotal,CompletionExecutiveSubject,CompletionDocumentIncome,CompletionOverdueIncome,NormalTotal,NormalExecutiveSubject,NormalDocumentIncome,NormalOverdueIncome,BankDeposit,Vehicle,HouseProperty,Land,Detention,Other,ExecutionPlan,Amount ");
            strSql.Append(" FROM R_ImplementationMeasures_Reporting ");
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
            strSql.Append("select count(1) FROM R_ImplementationMeasures_Reporting ");
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
            strSql.Append(")AS Row, T.*  from R_ImplementationMeasures_Reporting T ");
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
            parameters[0].Value = "R_ImplementationMeasures_Reporting";
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

