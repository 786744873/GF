using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.Customer
{
    /// <summary>
    /// 数据访问类:虚拟监控中心表
    /// 作者：崔慧栋
    /// 日期：2015/06/29
    /// </summary>
    public class V_MonitorCenter
    {
        /// <summary>
        /// 获取监控中心流程集合(执行存储过程)
        /// </summary>
        /// <param name="flowType">流程类型</param>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public DataSet GetMonitorCenterFlows(int flowType, CommonService.Model.CaseManager.B_Case casemodel)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@flowType", SqlDbType.Int,4),
                    new SqlParameter("@B_Case_name",SqlDbType.VarChar,100),
                     new SqlParameter("@B_Case_registerTime_S",SqlDbType.VarChar,100),
                     new SqlParameter("@B_Case_registerTime_E",SqlDbType.VarChar,100),
                    new SqlParameter("@B_Case_number",SqlDbType.VarChar,100),
                     new SqlParameter("@ConsultantCode",SqlDbType.VarChar,100),
                       new SqlParameter("@Involvedproject",SqlDbType.VarChar,100),
                      new SqlParameter("@Court",SqlDbType.VarChar,100),
                        new SqlParameter("@Casetype",SqlDbType.VarChar,100),
                         new SqlParameter("@ExecMoney1",SqlDbType.VarChar,100),
                     new SqlParameter("@ExecMoney2",SqlDbType.VarChar,100),
                          new SqlParameter("@CustomerCode",SqlDbType.VarChar,100),
                    new SqlParameter("@ClientCode",SqlDbType.VarChar,100),
                    new SqlParameter("@RivalCode",SqlDbType.VarChar,100),
				 };
            parameters[0].Value = flowType;
            parameters[1].Value = casemodel.B_Case_name == null ? "" : casemodel.B_Case_name;
            parameters[2].Value = casemodel.B_Case_registerTime == null ? DateTime.Now.AddYears(-100) : casemodel.B_Case_registerTime2;
            parameters[3].Value = casemodel.B_Case_registerTime2 == null ? DateTime.Now.AddYears(100) : casemodel.B_Case_registerTime2;
            parameters[4].Value = casemodel.B_Case_number == null ? "" : casemodel.B_Case_number;
            if (casemodel.B_Case_consultant_code == null)
                parameters[5].Value = "";
            else
                parameters[5].Value = casemodel.B_Case_consultant_code;
            parameters[6].Value = casemodel.C_Project_code == null ? "" : casemodel.C_Project_code;
            if (casemodel.B_Case_courtFirst == null)
                parameters[7].Value = "";
            else
                parameters[7].Value = casemodel.B_Case_courtFirst;
            if (casemodel.B_Case_type == null)
                parameters[8].Value = "";
            else
                parameters[8].Value = casemodel.B_Case_type;
            parameters[9].Value = casemodel.B_Case_transferTargetMoney == null ? 0 : casemodel.B_Case_transferTargetMoney;
            parameters[10].Value = casemodel.B_Case_execMoney2 == null ? 1000000000 : casemodel.B_Case_execMoney2;
            parameters[11].Value = casemodel.C_Customer_code == null ? "" : casemodel.C_Customer_code;
            parameters[12].Value = casemodel.C_Client_code == null ? "" : casemodel.C_Client_code;
            parameters[13].Value = casemodel.B_Case_Rival_code == null ? "" : casemodel.B_Case_Rival_code;

            DataSet ds = DbHelperSQL.RunProcedure("proc_GetMonitorCenterFlows", parameters, "MonitorCenter");
            return ds;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.Customer.V_MonitorCenter DataRowToModel(DataRow row)
        {
            CommonService.Model.Customer.V_MonitorCenter model = new CommonService.Model.Customer.V_MonitorCenter();
            if (row != null)
            {
                if (row["FlowCode"] != null && row["FlowCode"].ToString() != "")
                {
                    model.FlowCode = new Guid(row["FlowCode"].ToString());
                }
                if (row["FlowName"] != null && row["FlowName"].ToString() != "")
                {
                    model.FlowName = row["FlowName"].ToString();
                }
                if (row["CaseNumber"] != null && row["CaseNumber"].ToString() != "")
                {
                    model.CaseNumber = int.Parse(row["CaseNumber"].ToString());
                }
            }
            return model;
        }
    }
}
