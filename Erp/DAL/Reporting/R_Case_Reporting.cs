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
    public class R_Case_Reporting
    {
        public R_Case_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_Case_Reporting");
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
        public int Add(Model.Reporting.R_Case_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_Case_Reporting(");
            strSql.Append("B_Case_cons,B_Case_organ,B_Case_code,B_Case_number,B_Plaintiff_Name,B_Plaintiff_Code,B_Defendant_Name,B_Defendant_Code,B_Project_Name,B_Project_Code,B_Case_Type,B_TransferTime,B_TransferPrice,B_Case_CurrentStage,B_Case_AllStage,B_ExpectedPrice,B_DocumentPrice,B_OverduePrice,B_RealPrice,B_TotalDisbursementPrice,B_AcceptancePrice,B_MaintenancePrice,B_GuaranteePrice,B_BondPrice,B_TravelPrice,B_AnnouncementPrice,B_CourtExecutivePrice,B_RefundReceivablePrice,B_CourtReceivablePrice,B_NotReceivablePrice,B_DisbursementPrice,B_TotalReceivablesPrice,B_TotalRealPrice,B_ReceivablePrice,B_CaseExpensesPrice,B_CaseProceedsPrice,B_CaseYieldPrice,B_CaseStatus,B_EarlyWarning,B_Remark,B_AreaName)");
            strSql.Append(" values (");
            strSql.Append("@B_Case_cons,@B_Case_organ,@B_Case_code,@B_Case_number,@B_Plaintiff_Name,@B_Plaintiff_Code,@B_Defendant_Name,@B_Defendant_Code,@B_Project_Name,@B_Project_Code,@B_Case_Type,@B_TransferTime,@B_TransferPrice,@B_Case_CurrentStage,@B_Case_AllStage,@B_ExpectedPrice,@B_DocumentPrice,@B_OverduePrice,@B_RealPrice,@B_TotalDisbursementPrice,@B_AcceptancePrice,@B_MaintenancePrice,@B_GuaranteePrice,@B_BondPrice,@B_TravelPrice,@B_AnnouncementPrice,@B_CourtExecutivePrice,@B_RefundReceivablePrice,@B_CourtReceivablePrice,@B_NotReceivablePrice,@B_DisbursementPrice,@B_TotalReceivablesPrice,@B_TotalRealPrice,@B_ReceivablePrice,@B_CaseExpensesPrice,@B_CaseProceedsPrice,@B_CaseYieldPrice,@B_CaseStatus,@B_EarlyWarning,@B_Remark,@B_AreaName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_number", SqlDbType.VarChar,150),
					new SqlParameter("@B_Plaintiff_Name", SqlDbType.VarChar,150),
					new SqlParameter("@B_Plaintiff_Code",SqlDbType.VarChar,500),
					new SqlParameter("@B_Defendant_Name", SqlDbType.VarChar,150),
					new SqlParameter("@B_Defendant_Code", SqlDbType.VarChar,500),
					new SqlParameter("@B_Project_Name", SqlDbType.VarChar,150),
					new SqlParameter("@B_Project_Code", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_Type", SqlDbType.VarChar,50),
					new SqlParameter("@B_TransferTime", SqlDbType.DateTime),
					new SqlParameter("@B_TransferPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_Case_CurrentStage", SqlDbType.NVarChar,500),
					new SqlParameter("@B_Case_AllStage", SqlDbType.NVarChar,500),
					new SqlParameter("@B_ExpectedPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_DocumentPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_OverduePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_RealPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_TotalDisbursementPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_AcceptancePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_MaintenancePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_GuaranteePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_BondPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_TravelPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_AnnouncementPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_CourtExecutivePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_RefundReceivablePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_CourtReceivablePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_NotReceivablePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_DisbursementPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_TotalReceivablesPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_TotalRealPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_ReceivablePrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_CaseExpensesPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_CaseProceedsPrice", SqlDbType.Decimal,9),
					new SqlParameter("@B_CaseYieldPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@B_CaseStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@B_EarlyWarning", SqlDbType.NVarChar,150),
					new SqlParameter("@B_Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@B_AreaName", SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Case_cons",SqlDbType.VarChar,50),
                    new SqlParameter("@B_Case_organ",SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.B_Case_number;
            parameters[2].Value = model.B_Plaintiff_Name;
            parameters[3].Value = model.B_Plaintiff_Code;
            parameters[4].Value = model.B_Defendant_Name;
            parameters[5].Value = model.B_Defendant_Code;
            parameters[6].Value = model.B_Project_Name;
            parameters[7].Value = model.B_Project_Code;
            parameters[8].Value = model.B_Case_Type;
            parameters[9].Value = model.B_TransferTime;
            parameters[10].Value = model.B_TransferPrice;
            parameters[11].Value = model.B_Case_CurrentStage;
            parameters[12].Value = model.B_Case_AllStage;
            parameters[13].Value = model.B_ExpectedPrice;
            parameters[14].Value = model.B_DocumentPrice;
            parameters[15].Value = model.B_OverduePrice;
            parameters[16].Value = model.B_RealPrice;
            parameters[17].Value = model.B_TotalDisbursementPrice;
            parameters[18].Value = model.B_AcceptancePrice;
            parameters[19].Value = model.B_MaintenancePrice;
            parameters[20].Value = model.B_GuaranteePrice;
            parameters[21].Value = model.B_BondPrice;
            parameters[22].Value = model.B_TravelPrice;
            parameters[23].Value = model.B_AnnouncementPrice;
            parameters[24].Value = model.B_CourtExecutivePrice;
            parameters[25].Value = model.B_RefundReceivablePrice;
            parameters[26].Value = model.B_CourtReceivablePrice;
            parameters[27].Value = model.B_NotReceivablePrice;
            parameters[28].Value = model.B_DisbursementPrice;
            parameters[29].Value = model.B_TotalReceivablesPrice;
            parameters[30].Value = model.B_TotalRealPrice;
            parameters[31].Value = model.B_ReceivablePrice;
            parameters[32].Value = model.B_CaseExpensesPrice;
            parameters[33].Value = model.B_CaseProceedsPrice;
            parameters[34].Value = model.B_CaseYieldPrice;
            parameters[35].Value = model.B_CaseStatus;
            parameters[36].Value = model.B_EarlyWarning;
            parameters[37].Value = model.B_Remark;
            parameters[38].Value = model.B_AreaName;
            parameters[39].Value = model.B_Case_cons;
            parameters[40].Value = model.B_Case_organ;
            

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
        public bool Update(Model.Reporting.R_Case_Reporting model)
        {
            return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_Case_Reporting ");
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
        /// 删除所有数据
        /// </summary>
        public bool DeleteAll()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Truncate table R_Case_Reporting ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_Case_Reporting ");
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
        public Model.Reporting.R_Case_Reporting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from R_Case_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Reporting.R_Case_Reporting model = new Model.Reporting.R_Case_Reporting();
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
        public Model.Reporting.R_Case_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_Case_Reporting model = new Model.Reporting.R_Case_Reporting();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["B_Case_cons"] != null)
                {
                    model.B_Case_cons = row["B_Case_cons"].ToString();
                }
                if (row["B_Case_organ"] != null)
                {
                    model.B_Case_organ = row["B_Case_organ"].ToString();
                }
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString() != "")
                {
                    model.B_Case_code = new Guid(row["B_Case_code"].ToString());
                }
                if (row["B_Case_number"] != null)
                {
                    model.B_Case_number = row["B_Case_number"].ToString();
                }
                if (row["B_Plaintiff_Name"] != null)
                {
                    model.B_Plaintiff_Name = row["B_Plaintiff_Name"].ToString();
                }
                if (row["B_Plaintiff_Code"] != null && row["B_Plaintiff_Code"].ToString() != "")
                {
                    model.B_Plaintiff_Code = row["B_Plaintiff_Code"].ToString();
                }
                if (row["B_Defendant_Name"] != null)
                {
                    model.B_Defendant_Name = row["B_Defendant_Name"].ToString();
                }
                if (row["B_Defendant_Code"] != null && row["B_Defendant_Code"].ToString() != "")
                {
                    model.B_Defendant_Code = row["B_Defendant_Code"].ToString();
                }
                if (row["B_Project_Name"] != null)
                {
                    model.B_Project_Name = row["B_Project_Name"].ToString();
                }
                if (row["B_Project_Code"] != null && row["B_Project_Code"].ToString() != "")
                {
                    model.B_Project_Code = row["B_Project_Code"].ToString();
                }
                if (row["B_Case_Type"] != null && row["B_Case_Type"].ToString() != "")
                {
                    model.B_Case_Type = row["B_Case_Type"].ToString();
                }
                if (row["B_TransferTime"] != null && row["B_TransferTime"].ToString() != "")
                {
                    model.B_TransferTime = DateTime.Parse(row["B_TransferTime"].ToString());
                }
                if (row["B_TransferPrice"] != null && row["B_TransferPrice"].ToString() != "")
                {
                    model.B_TransferPrice = decimal.Parse(row["B_TransferPrice"].ToString());
                }
                if (row["B_Case_CurrentStage"] != null)
                {
                    model.B_Case_CurrentStage = row["B_Case_CurrentStage"].ToString();
                }
                if (row["B_Case_AllStage"] != null)
                {
                    model.B_Case_AllStage = row["B_Case_AllStage"].ToString();
                }
                if (row["B_ExpectedPrice"] != null && row["B_ExpectedPrice"].ToString() != "")
                {
                    model.B_ExpectedPrice = decimal.Parse(row["B_ExpectedPrice"].ToString());
                }
                if (row["B_DocumentPrice"] != null && row["B_DocumentPrice"].ToString() != "")
                {
                    model.B_DocumentPrice = decimal.Parse(row["B_DocumentPrice"].ToString());
                }
                if (row["B_OverduePrice"] != null && row["B_OverduePrice"].ToString() != "")
                {
                    model.B_OverduePrice = decimal.Parse(row["B_OverduePrice"].ToString());
                }
                if (row["B_RealPrice"] != null && row["B_RealPrice"].ToString() != "")
                {
                    model.B_RealPrice = decimal.Parse(row["B_RealPrice"].ToString());
                }
                if (row["B_TotalDisbursementPrice"] != null && row["B_TotalDisbursementPrice"].ToString() != "")
                {
                    model.B_TotalDisbursementPrice = decimal.Parse(row["B_TotalDisbursementPrice"].ToString());
                }
                if (row["B_AcceptancePrice"] != null && row["B_AcceptancePrice"].ToString() != "")
                {
                    model.B_AcceptancePrice = decimal.Parse(row["B_AcceptancePrice"].ToString());
                }
                if (row["B_MaintenancePrice"] != null && row["B_MaintenancePrice"].ToString() != "")
                {
                    model.B_MaintenancePrice = decimal.Parse(row["B_MaintenancePrice"].ToString());
                }
                if (row["B_GuaranteePrice"] != null && row["B_GuaranteePrice"].ToString() != "")
                {
                    model.B_GuaranteePrice = decimal.Parse(row["B_GuaranteePrice"].ToString());
                }
                if (row["B_BondPrice"] != null && row["B_BondPrice"].ToString() != "")
                {
                    model.B_BondPrice = decimal.Parse(row["B_BondPrice"].ToString());
                }
                if (row["B_TravelPrice"] != null && row["B_TravelPrice"].ToString() != "")
                {
                    model.B_TravelPrice = decimal.Parse(row["B_TravelPrice"].ToString());
                }
                if (row["B_AnnouncementPrice"] != null && row["B_AnnouncementPrice"].ToString() != "")
                {
                    model.B_AnnouncementPrice = decimal.Parse(row["B_AnnouncementPrice"].ToString());
                }
                if (row["B_CourtExecutivePrice"] != null && row["B_CourtExecutivePrice"].ToString() != "")
                {
                    model.B_CourtExecutivePrice = decimal.Parse(row["B_CourtExecutivePrice"].ToString());
                }
                if (row["B_RefundReceivablePrice"] != null && row["B_RefundReceivablePrice"].ToString() != "")
                {
                    model.B_RefundReceivablePrice = decimal.Parse(row["B_RefundReceivablePrice"].ToString());
                }
                if (row["B_CourtReceivablePrice"] != null && row["B_CourtReceivablePrice"].ToString() != "")
                {
                    model.B_CourtReceivablePrice = decimal.Parse(row["B_CourtReceivablePrice"].ToString());
                }
                if (row["B_NotReceivablePrice"] != null && row["B_NotReceivablePrice"].ToString() != "")
                {
                    model.B_NotReceivablePrice = decimal.Parse(row["B_NotReceivablePrice"].ToString());
                }
                if (row["B_DisbursementPrice"] != null && row["B_DisbursementPrice"].ToString() != "")
                {
                    model.B_DisbursementPrice = decimal.Parse(row["B_DisbursementPrice"].ToString());
                }
                if (row["B_TotalReceivablesPrice"] != null && row["B_TotalReceivablesPrice"].ToString() != "")
                {
                    model.B_TotalReceivablesPrice = decimal.Parse(row["B_TotalReceivablesPrice"].ToString());
                }
                if (row["B_TotalRealPrice"] != null && row["B_TotalRealPrice"].ToString() != "")
                {
                    model.B_TotalRealPrice = decimal.Parse(row["B_TotalRealPrice"].ToString());
                }
                if (row["B_ReceivablePrice"] != null && row["B_ReceivablePrice"].ToString() != "")
                {
                    model.B_ReceivablePrice = decimal.Parse(row["B_ReceivablePrice"].ToString());
                }
                if (row["B_CaseExpensesPrice"] != null && row["B_CaseExpensesPrice"].ToString() != "")
                {
                    model.B_CaseExpensesPrice = decimal.Parse(row["B_CaseExpensesPrice"].ToString());
                }
                if (row["B_CaseProceedsPrice"] != null && row["B_CaseProceedsPrice"].ToString() != "")
                {
                    model.B_CaseProceedsPrice = decimal.Parse(row["B_CaseProceedsPrice"].ToString());
                }
                if (row["B_CaseYieldPrice"] != null && row["B_CaseYieldPrice"].ToString() != "")
                {
                    model.B_CaseYieldPrice = decimal.Parse(row["B_CaseYieldPrice"].ToString());
                }
                if (row["B_CaseStatus"] != null && row["B_CaseStatus"].ToString() != "")
                {
                    model.B_CaseStatus = row["B_CaseStatus"].ToString();
                }
                if (row["B_EarlyWarning"] != null)
                {
                    model.B_EarlyWarning = row["B_EarlyWarning"].ToString();
                }
                if (row["B_Remark"] != null)
                {
                    model.B_Remark = row["B_Remark"].ToString();
                }

                if (row["B_AreaName"] != null)
                {
                    model.B_AreaName = row["B_AreaName"].ToString();
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.V_Case_Reporting DataRowToVModel(DataRow row)
        {
            Model.Reporting.V_Case_Reporting model = new Model.Reporting.V_Case_Reporting();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["B_Case_cons"] != null)
                {
                    model.B_Case_cons = row["B_Case_cons"].ToString();
                }
                if (row["B_Case_organ"] != null)
                {
                    model.B_Case_organ = row["B_Case_organ"].ToString();
                }
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString() != "")
                {
                    model.B_Case_code = row["B_Case_code"].ToString();
                }
                if (row["B_Case_number"] != null)
                {
                    model.B_Case_number = row["B_Case_number"].ToString();
                }
                if (row["B_Plaintiff_Name"] != null)
                {
                    model.B_Plaintiff_Name = row["B_Plaintiff_Name"].ToString();
                }
                if (row["B_Plaintiff_Code"] != null && row["B_Plaintiff_Code"].ToString() != "")
                {
                    model.B_Plaintiff_Code = row["B_Plaintiff_Code"].ToString();
                }
                if (row["B_Defendant_Name"] != null)
                {
                    model.B_Defendant_Name = row["B_Defendant_Name"].ToString();
                }
                if (row["B_Defendant_Code"] != null && row["B_Defendant_Code"].ToString() != "")
                {
                    model.B_Defendant_Code = row["B_Defendant_Code"].ToString();
                }
                if (row["B_Project_Name"] != null)
                {
                    model.B_Project_Name = row["B_Project_Name"].ToString();
                }
                if (row["B_Project_Code"] != null && row["B_Project_Code"].ToString() != "")
                {
                    model.B_Project_Code = row["B_Project_Code"].ToString();
                }
                if (row["B_Case_Type"] != null && row["B_Case_Type"].ToString() != "")
                {
                    model.B_Case_Type = row["B_Case_Type"].ToString();
                }
                if (row["B_TransferTime"] != null && row["B_TransferTime"].ToString() != "")
                {
                    model.B_TransferTime = row["B_TransferTime"].ToString();
                }
                if (row["B_TransferPrice"] != null && row["B_TransferPrice"].ToString() != "")
                {
                    model.B_TransferPrice = row["B_TransferPrice"].ToString();
                }
                if (row["B_Case_CurrentStage"] != null)
                {
                    model.B_Case_CurrentStage = row["B_Case_CurrentStage"].ToString();
                }
                if (row["B_Case_AllStage"] != null)
                {
                    model.B_Case_AllStage = row["B_Case_AllStage"].ToString();
                }
                if (row["B_ExpectedPrice"] != null && row["B_ExpectedPrice"].ToString() != "")
                {
                    model.B_ExpectedPrice = row["B_ExpectedPrice"].ToString();
                }
                if (row["B_DocumentPrice"] != null && row["B_DocumentPrice"].ToString() != "")
                {
                    model.B_DocumentPrice = row["B_DocumentPrice"].ToString();
                }
                if (row["B_OverduePrice"] != null && row["B_OverduePrice"].ToString() != "")
                {
                    model.B_OverduePrice = row["B_OverduePrice"].ToString();
                }
                if (row["B_RealPrice"] != null && row["B_RealPrice"].ToString() != "")
                {
                    model.B_RealPrice = row["B_RealPrice"].ToString();
                }
                if (row["B_TotalDisbursementPrice"] != null && row["B_TotalDisbursementPrice"].ToString() != "")
                {
                    model.B_TotalDisbursementPrice = row["B_TotalDisbursementPrice"].ToString();
                }
                if (row["B_AcceptancePrice"] != null && row["B_AcceptancePrice"].ToString() != "")
                {
                    model.B_AcceptancePrice = row["B_AcceptancePrice"].ToString();
                }
                if (row["B_MaintenancePrice"] != null && row["B_MaintenancePrice"].ToString() != "")
                {
                    model.B_MaintenancePrice = row["B_MaintenancePrice"].ToString();
                }
                if (row["B_GuaranteePrice"] != null && row["B_GuaranteePrice"].ToString() != "")
                {
                    model.B_GuaranteePrice = row["B_GuaranteePrice"].ToString();
                }
                if (row["B_BondPrice"] != null && row["B_BondPrice"].ToString() != "")
                {
                    model.B_BondPrice = row["B_BondPrice"].ToString();
                }
                if (row["B_TravelPrice"] != null && row["B_TravelPrice"].ToString() != "")
                {
                    model.B_TravelPrice = row["B_TravelPrice"].ToString();
                }
                if (row["B_AnnouncementPrice"] != null && row["B_AnnouncementPrice"].ToString() != "")
                {
                    model.B_AnnouncementPrice = row["B_AnnouncementPrice"].ToString();
                }
                if (row["B_CourtExecutivePrice"] != null && row["B_CourtExecutivePrice"].ToString() != "")
                {
                    model.B_CourtExecutivePrice = row["B_CourtExecutivePrice"].ToString();
                }
                if (row["B_RefundReceivablePrice"] != null && row["B_RefundReceivablePrice"].ToString() != "")
                {
                    model.B_RefundReceivablePrice = row["B_RefundReceivablePrice"].ToString();
                }
                if (row["B_CourtReceivablePrice"] != null && row["B_CourtReceivablePrice"].ToString() != "")
                {
                    model.B_CourtReceivablePrice = row["B_CourtReceivablePrice"].ToString();
                }
                if (row["B_NotReceivablePrice"] != null && row["B_NotReceivablePrice"].ToString() != "")
                {
                    model.B_NotReceivablePrice = row["B_NotReceivablePrice"].ToString();
                }
                if (row["B_DisbursementPrice"] != null && row["B_DisbursementPrice"].ToString() != "")
                {
                    model.B_DisbursementPrice = row["B_DisbursementPrice"].ToString();
                }
                if (row["B_TotalReceivablesPrice"] != null && row["B_TotalReceivablesPrice"].ToString() != "")
                {
                    model.B_TotalReceivablesPrice = row["B_TotalReceivablesPrice"].ToString();
                }
                if (row["B_TotalRealPrice"] != null && row["B_TotalRealPrice"].ToString() != "")
                {
                    model.B_TotalRealPrice = row["B_TotalRealPrice"].ToString();
                }
                if (row["B_ReceivablePrice"] != null && row["B_ReceivablePrice"].ToString() != "")
                {
                    model.B_ReceivablePrice = row["B_ReceivablePrice"].ToString();
                }
                if (row["B_CaseExpensesPrice"] != null && row["B_CaseExpensesPrice"].ToString() != "")
                {
                    model.B_CaseExpensesPrice = row["B_CaseExpensesPrice"].ToString();
                }
                if (row["B_CaseProceedsPrice"] != null && row["B_CaseProceedsPrice"].ToString() != "")
                {
                    model.B_CaseProceedsPrice = row["B_CaseProceedsPrice"].ToString();
                }
                if (row["B_CaseYieldPrice"] != null && row["B_CaseYieldPrice"].ToString() != "")
                {
                    model.B_CaseYieldPrice = row["B_CaseYieldPrice"].ToString();
                }
                if (row["B_CaseStatus"] != null && row["B_CaseStatus"].ToString() != "")
                {
                    model.B_CaseStatus = row["B_CaseStatus"].ToString();
                }

                if (row["B_EarlyWarning"] != null)
                {
                    model.B_EarlyWarning = row["B_EarlyWarning"].ToString();
                }
                if (row["B_Remark"] != null)
                {
                    model.B_Remark = row["B_Remark"].ToString();
                }
                if (row["B_AreaName"] != null)
                {
                    model.B_AreaName = row["B_AreaName"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM R_Case_Reporting ");
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
            strSql.Append(" ID,B_Case_cons,B_Case_organ,B_Case_code,B_Case_number,B_Plaintiff_Name,B_Plaintiff_Code,B_Defendant_Name,B_Defendant_Code,B_Project_Name,B_Project_Code,B_Case_Type,B_TransferTime,B_TransferPrice,B_Case_CurrentStage,B_Case_AllStage,B_ExpectedPrice,B_DocumentPrice,B_OverduePrice,B_RealPrice,B_TotalDisbursementPrice,B_AcceptancePrice,B_MaintenancePrice,B_GuaranteePrice,B_BondPrice,B_TravelPrice,B_AnnouncementPrice,B_CourtExecutivePrice,B_RefundReceivablePrice,B_CourtReceivablePrice,B_NotReceivablePrice,B_DisbursementPrice,B_TotalReceivablesPrice,B_TotalRealPrice,B_ReceivablePrice,B_CaseExpensesPrice,B_CaseProceedsPrice,B_CaseYieldStatus,B_EarlyWarning,B_Remark ");
            strSql.Append(" FROM R_Case_Reporting ");
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
        public int GetRecordCount(CommonService.Model.Reporting.V_Case_Reporting model)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM R_Case_Reporting where 1=1  ");
            if (model.B_Case_number != null)
            {
                strSql.Append(" and B_Case_number like N'%'+ @B_Case_number +'%' ");
            }
            if (model.B_Case_cons !=null)
            {
                strSql.Append(" and B_Case_cons like N'%'+ @B_Case_cons +'%' ");
            }
            if (model.B_Case_organ!=null)
            {
                strSql.Append(" and B_Case_organ like N'%'+ @B_Case_organ +'%'");
            }
            if (model.B_Project_Name != null)
            {
                strSql.Append(" and B_Project_Name like N'%'+@B_Project_Name+'%' ");
            }
            if (model.B_Case_Type != null)
            {
                strSql.Append(" and B_Case_Type like N'%'+@B_Case_Type+'%' ");
            }
            if (model.B_Case_AllStage != null)
            {
                strSql.Append(" and B_Case_AllStage like N'%'+@B_Case_AllStage+'%' ");
            }
            if (model.B_EarlyWarning != null)
            {
                strSql.Append(" and B_EarlyWarning like N'%'+@B_EarlyWarning+'%' ");

            }

            if (model.B_TransferTime != null && model.B_Remark != null)
            {
                strSql.Append(" and [B_TransferTime]<'" + model.B_Remark + "' and [B_TransferTime]>'" + model.B_TransferTime + "' ");
            }
            if (model.B_TransferTime != null && model.B_Remark == null)
            {
                strSql.Append(" and [B_TransferTime]>='" + model.B_TransferTime + "' ");
            }
            if (model.B_TransferTime == null && model.B_Remark != null)
            {
                strSql.Append(" and [B_TransferTime]=<'" + model.B_Remark + "' ");
            }
            if (model.B_TransferPrice != null && model.B_Plaintiff_Code != null)
            {
                strSql.Append(" and [B_TransferPrice]<'" + model.B_Plaintiff_Code + "' and [B_TransferPrice]>'" + model.B_TransferPrice + "' ");
            }
            if (model.B_TransferPrice != null && model.B_Plaintiff_Code == null)
            {
                strSql.Append(" and [B_TransferPrice]>='" + model.B_TransferPrice + "' ");
            }
            if (model.B_TransferPrice == null && model.B_Plaintiff_Code != null)
            {
                strSql.Append(" and [B_TransferPrice]<='" + model.B_Plaintiff_Code + "' ");
            }

            if (model.B_AreaName != null)
            {
                strSql.Append(" and [B_AreaName]='" + model.B_AreaName + "' ");
            }

            if (model.B_Case_CurrentStage != null)
            {
                strSql.Append(" and B_Case_CurrentStage like N'%'+@B_Case_CurrentStage+'%' ");
            }

            if (model.B_CaseStatus != null)
            {
                strSql.Append(" and B_CaseStatus like N'%'+@B_CaseStatus+'%' ");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@B_Case_number", SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Project_Name",  SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Case_Type",  SqlDbType.NVarChar,50)
                    ,new SqlParameter("@B_Case_AllStage", SqlDbType.NVarChar,50),
                    new SqlParameter("@B_EarlyWarning",  SqlDbType.NVarChar,50),
                    new SqlParameter("@B_CaseStatus",  SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Case_CurrentStage",  SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Case_cons",SqlDbType.VarChar,50),
                    new SqlParameter("@B_Case_organ",SqlDbType.VarChar,50)

                    
            };
            parameters[0].Value = model.B_Case_number;
            parameters[1].Value = model.B_Project_Name;
            parameters[2].Value = model.B_Case_Type;
            parameters[3].Value = model.B_Case_AllStage;
            parameters[4].Value = model.B_EarlyWarning;
            parameters[5].Value = model.B_CaseStatus;
            parameters[6].Value = model.B_Case_CurrentStage;
            parameters[7].Value = model.B_Case_cons;
            parameters[8].Value = model.B_Case_organ;


            object rows = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (rows == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(rows);
            }

        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(CommonService.Model.Reporting.V_Case_Reporting model, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.*  from R_Case_Reporting T where 1=1  ");
            if (model.B_Case_number != null)
            {
                strSql.Append(" and B_Case_number like N'%'+@B_Case_number+'%' ");
            }
            if (model.B_Case_cons != null)
            {
                strSql.Append(" and B_Case_cons like N'%'+ @B_Case_cons +'%' ");
            }
            if (model.B_Case_organ != null)
            {
                strSql.Append(" and B_Case_organ like N'%'+ @B_Case_organ +'%'");
            }
            if (model.B_Project_Name != null)
            {
                strSql.Append(" and B_Project_Name like N'%'+@B_Project_Name+'%' ");
            }
            if (model.B_Case_Type != null)
            {
                strSql.Append(" and B_Case_Type like N'%'+@B_Case_Type+'%' ");
            }
            if (model.B_Case_AllStage != null)
            {
                strSql.Append(" and B_Case_AllStage like N'%'+@B_Case_AllStage+'%' ");
            }
            if (model.B_EarlyWarning != null)
            {
                strSql.Append(" and B_EarlyWarning like N'%'+@B_EarlyWarning+'%' ");

            }
            if (model.B_Case_CurrentStage != null)
            {
                strSql.Append(" and B_Case_CurrentStage like N'%'+@B_Case_CurrentStage+'%' ");
            }

            if (model.B_TransferTime != null && model.B_Remark != null)
            {
                strSql.Append(" and [B_TransferTime]<'" + model.B_Remark + "' and [B_TransferTime]>'" + model.B_TransferTime + "' ");
            }
            if (model.B_TransferTime != null && model.B_Remark == null)
            {
                strSql.Append(" and [B_TransferTime]>'" + model.B_TransferTime + "' ");
            }
            if (model.B_TransferTime == null && model.B_Remark != null)
            {
                strSql.Append(" and [B_TransferTime]<'" + model.B_Remark + "' ");
            }

            

            if (model.B_TransferPrice != null && model.B_Plaintiff_Code != null)
            {
                strSql.Append(" and [B_TransferPrice]<'" + model.B_Plaintiff_Code + "' and [B_TransferPrice]>'" + model.B_TransferPrice + "' ");
            }
            if (model.B_TransferPrice != null && model.B_Plaintiff_Code == null)
            {
                strSql.Append(" and [B_TransferPrice]>'" + model.B_TransferPrice + "' ");
            }
            if (model.B_TransferPrice == null && model.B_Plaintiff_Code != null)
            {
                strSql.Append(" and [B_TransferPrice]<'" + model.B_Plaintiff_Code + "' ");
            }

            if (model.B_AreaName != null)
            {
                strSql.Append(" and [B_AreaName]='" + model.B_AreaName + "' ");
            }

            if (model.B_CaseStatus != null)
            {
                strSql.Append(" and B_CaseStatus like N'%'+@B_CaseStatus+'%' ");
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
                    new SqlParameter("@B_Case_number", SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Project_Name",  SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Case_Type",  SqlDbType.NVarChar,50)
                    ,new SqlParameter("@B_Case_AllStage", SqlDbType.NVarChar,50),
                    new SqlParameter("@B_EarlyWarning",  SqlDbType.NVarChar,50),
                    new SqlParameter("@B_CaseStatus",  SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Case_CurrentStage",  SqlDbType.NVarChar,50)
                    
            };
            parameters[0].Value = model.B_Case_number;
            parameters[1].Value = model.B_Project_Name;
            parameters[2].Value = model.B_Case_Type;
            parameters[3].Value = model.B_Case_AllStage;
            parameters[4].Value = model.B_EarlyWarning;
            parameters[5].Value = model.B_CaseStatus;
            parameters[6].Value = model.B_Case_CurrentStage;


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
            parameters[0].Value = "R_Case_Reporting";
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

