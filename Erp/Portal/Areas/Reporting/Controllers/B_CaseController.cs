using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.Reporting.Controllers
{
    public class B_CaseController : BaseController
    {

        private readonly ICommonService.Reporting.IR_Case_Reporting _reporting_CaseWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.CaseManager.IB_Case_link _caselinkWCF;
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.IC_PRival _privalWCF;
        private readonly ICommonService.IC_CRival _crivalWCF;
        private readonly ICommonService.IC_Involved_project _involved_projectWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        public B_CaseController()
        {
            _reporting_CaseWCF = ServiceProxyFactory.Create<ICommonService.Reporting.IR_Case_Reporting>("Reporting_CaseWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _caselinkWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_link>("Case_linkWCF");
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _privalWCF = ServiceProxyFactory.Create<ICommonService.IC_PRival>("PRivalWCF");
            _crivalWCF = ServiceProxyFactory.Create<ICommonService.IC_CRival>("CRivalWCF");
            _involved_projectWCF = ServiceProxyFactory.Create<ICommonService.IC_Involved_project>("Involved_projectWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
        }

        //
        // GET: /Reporting/B_Case/
        public ActionResult List()
        {

            List<CommonService.Model.FlowManager.P_Flow> flowList = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.案件));
            List<CommonService.Model.FlowManager.P_Flow> casestage = new List<CommonService.Model.FlowManager.P_Flow>();
            flowList = SetSingleTopFlow(flowList, casestage);

            ViewBag.casestage = flowList;
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                var rgcode = _regionWCF.GetRegionCodeByUsercode(Context.UIContext.Current.UserCode.Value);
                ViewBag.AreaName = _regionWCF.GetModelByCode(rgcode).C_Region_name;
            }

            return View();
        }
        private List<CommonService.Model.FlowManager.P_Flow> SetSingleTopFlow(List<CommonService.Model.FlowManager.P_Flow> flowList, List<CommonService.Model.FlowManager.P_Flow> casestage)
        {
            var topFlowCaseList = from allList in flowList
                                  where allList.P_Flow_level == 1
                                  orderby allList.P_Flow_order ascending
                                  select allList;

            foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowCaseList)
            {
                casestage.Add(flow);
                SetSignleRecursion(flowList, flow.P_Flow_code.Value, casestage);
            }
            return casestage;
        }
        private List<CommonService.Model.FlowManager.P_Flow> SetSignleRecursion(List<CommonService.Model.FlowManager.P_Flow> flowList, Guid flowCode, List<CommonService.Model.FlowManager.P_Flow> casestage)
        {
            foreach (CommonService.Model.FlowManager.P_Flow flow in flowList)
            {
                if (flow.P_Flow_parent == flowCode)
                {
                    casestage.Add(flow);
                    SetSignleRecursion(flowList, flow.P_Flow_code.Value, casestage);
                }
            }
            return casestage;
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.V_Case_Reporting oFormConditon = new CommonService.Model.Reporting.V_Case_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && (isExecutedSearch == "1"))
            {//代表已执行查询
                #region 查询项处理
                string s_number = Request.Params.Get("s_number");
                if (s_number != null && s_number != "")
                {
                    oFormConditon.B_Case_number = s_number;

                }
                string s_project = Request.Params.Get("s_project");
                if (s_project != null && s_project != "")
                {
                    oFormConditon.B_Project_Name = s_project;

                }
                string i_state = Request.Params.Get("i_state");
                if (i_state != null && i_state != "" && i_state != "-1")
                {
                    oFormConditon.B_Case_Type = i_state;
                }
                string B_Case_Stage = Request.Params.Get("B_Case_Stage");
                if (B_Case_Stage != null && B_Case_Stage != "" && B_Case_Stage != "-1")
                {
                    oFormConditon.B_Case_CurrentStage = B_Case_Stage;
                }
                string B_CaseStatus = Request.Params.Get("i_state_type");
                if (B_CaseStatus != null && B_CaseStatus != "" && B_CaseStatus != "-1")
                {
                    oFormConditon.B_CaseStatus = B_CaseStatus;
                }

                string B_TransferTime_1 = Request.Params.Get("B_TransferTime_1");
                if (B_TransferTime_1 != null && B_TransferTime_1 != "" && B_TransferTime_1 != "-1")
                {
                    oFormConditon.B_TransferTime = B_TransferTime_1;
                }
                string B_TransferTime_2 = Request.Params.Get("B_TransferTime_2");
                if (B_TransferTime_2 != null && B_TransferTime_2 != "" && B_TransferTime_2 != "-1")
                {
                    oFormConditon.B_Remark = B_TransferTime_2;
                }


                string B_TransferPrice_b = Request.Params.Get("B_TransferPrice_b");
                if (B_TransferPrice_b != null && B_TransferPrice_b != "" && B_TransferPrice_b != "-1")
                {
                    oFormConditon.B_TransferPrice = B_TransferPrice_b;
                }
                string B_TransferPrice_e = Request.Params.Get("B_TransferPrice_e");
                if (B_TransferPrice_e != null && B_TransferPrice_e != "" && B_TransferPrice_e != "-1")
                {
                    oFormConditon.B_Plaintiff_Code = B_TransferPrice_e;
                }

                string B_AreaName = Request.Params.Get("B_AreaName");
                if (B_AreaName != null && B_AreaName != "" && B_AreaName != "-1")
                {
                    oFormConditon.B_AreaName = B_AreaName;
                }


                #endregion
            }
            else
            {
                string B_AreaName = Request.Params.Get("B_AreaName");
                if (B_AreaName != null && B_AreaName != "" && B_AreaName != "-1")
                {
                    oFormConditon.B_AreaName = B_AreaName;
                }
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetRecordCount(oFormConditon);



            List<CommonService.Model.Reporting.V_Case_Reporting> listsLoan = _reporting_CaseWCF.GetListByPage(oFormConditon, " ID asc ", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);



            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                             c.ID,
                             c.B_AreaName,
                             c.B_Case_cons,
                             c.B_Case_organ,
                             c.B_Case_number,
                             c.B_Plaintiff_Name,
                             c.B_Defendant_Name,
                             c.B_Project_Name,
                             c.B_Case_Type,
                             c.B_TransferTime,
                             c.B_TransferPrice,
                             c.B_Case_CurrentStage,
                             c.B_Case_AllStage,
                             c.B_ExpectedPrice,
                             c.B_DocumentPrice,
                             c.B_OverduePrice,
                             c.B_RealPrice,

                             c.B_TotalDisbursementPrice,
                             c.B_AcceptancePrice,
                             c.B_MaintenancePrice,
                             c.B_GuaranteePrice,
                             c.B_BondPrice,
                             c.B_TravelPrice,
                             c.B_AnnouncementPrice,
                             c.B_CourtExecutivePrice,
                             c.B_RefundReceivablePrice,
                             c.B_CourtReceivablePrice,
                         
                             c.B_NotReceivablePrice,
                             c.B_DisbursementPrice,
                             c.B_TotalReceivablesPrice,
                             c.B_TotalRealPrice,
                             c.B_ReceivablePrice,
                             c.B_CaseExpensesPrice,
                             c.B_CaseProceedsPrice,
                             c.B_CaseYieldPrice,
                             c.B_CaseStatus,
                             c.B_EarlyWarning,
                             c.B_Remark,
                             
            };
            //返回json数据
            return Json(
                new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = this.TotalRecordCount,
                    iTotalDisplayRecords = this.TotalRecordCount,
                    aaData = result
                }
            );
        }




        [HttpPost]
        public void TbService()
        {

            _reporting_CaseWCF.Statistics();
        }


        #region 数据导出功能
        public FileResult Export(string s_number, string s_project, string i_state, string B_Case_Stage, string B_CaseStatus, string B_TransferTime_1, string B_TransferTime_2, string B_TransferPrice_e, string B_TransferPrice_b, string B_AreaName)
        {

            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.V_Case_Reporting oFormConditon = new CommonService.Model.Reporting.V_Case_Reporting();

            //代表已执行查询
            #region 查询项处理

            if (s_number != null && s_number != "")
            {
                oFormConditon.B_Case_number = s_number;

            }

            if (s_project != null && s_project != "")
            {
                oFormConditon.B_Project_Name = s_project;

            }

            if (i_state != null && i_state != "" && i_state != "-1")
            {
                oFormConditon.B_Case_Type = i_state;
            }

            if (B_Case_Stage != null && B_Case_Stage != "" && B_Case_Stage != "-1")
            {
                oFormConditon.B_Case_CurrentStage = B_Case_Stage;
            }

            if (B_CaseStatus != null && B_CaseStatus != "" && B_CaseStatus != "-1")
            {
                oFormConditon.B_CaseStatus = B_CaseStatus;
            }


            if (B_TransferTime_1 != null && B_TransferTime_1 != "" && B_TransferTime_1 != "-1")
            {
                oFormConditon.B_TransferTime = B_TransferTime_1;
            }
            if (B_TransferTime_2 != null && B_TransferTime_2 != "" && B_TransferTime_2 != "-1")
            {
                oFormConditon.B_Remark = B_TransferTime_2;
            }


            if (B_TransferPrice_b != null && B_TransferPrice_b != "" && B_TransferPrice_b != "-1")
            {
                oFormConditon.B_TransferPrice = B_TransferPrice_b;
            }

            if (B_TransferPrice_e != null && B_TransferPrice_e != "" && B_TransferPrice_e != "-1")
            {
                oFormConditon.B_Plaintiff_Code = B_TransferPrice_e;
            }


            if (B_AreaName != null && B_AreaName != "" && B_AreaName != "-1")
            {
                oFormConditon.B_AreaName = B_AreaName;
            }



            #endregion


            #endregion

            List<CommonService.Model.Reporting.V_Case_Reporting> listsLoan = _reporting_CaseWCF.GetListByPage(oFormConditon, " ID asc ", 1, 10000);




            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("区域");
            row1.CreateCell(1).SetCellValue("部门");
            row1.CreateCell(2).SetCellValue("专业顾问");
            row1.CreateCell(3).SetCellValue("案号");
            row1.CreateCell(4).SetCellValue("原告");
            row1.CreateCell(5).SetCellValue("被告");
            row1.CreateCell(6).SetCellValue("项目名称");
            row1.CreateCell(7).SetCellValue("案件类型");
            row1.CreateCell(8).SetCellValue("移交时间");
            row1.CreateCell(9).SetCellValue("移交金额");
            row1.CreateCell(10).SetCellValue("案件当前阶段");
            row1.CreateCell(11).SetCellValue("案件所有阶段");
            row1.CreateCell(12).SetCellValue("预期收入");
            row1.CreateCell(13).SetCellValue("文书收入");
            row1.CreateCell(14).SetCellValue("逾期收入");
            row1.CreateCell(15).SetCellValue("实际收入");
            row1.CreateCell(16).SetCellValue("应收代垫款总额");
            row1.CreateCell(17).SetCellValue("受理费");
            row1.CreateCell(18).SetCellValue("保全费");
            row1.CreateCell(19).SetCellValue("担保费");
            row1.CreateCell(20).SetCellValue("保证金");
            row1.CreateCell(21).SetCellValue("差旅费");
            row1.CreateCell(22).SetCellValue("公告费");
            row1.CreateCell(23).SetCellValue("法院执行费");
            row1.CreateCell(24).SetCellValue("应收法院退费");
            row1.CreateCell(25).SetCellValue("已收法院退费");
            row1.CreateCell(26).SetCellValue("未收法院退费");
            row1.CreateCell(27).SetCellValue("实收代垫款总额");
            row1.CreateCell(28).SetCellValue("合计应收款");
            row1.CreateCell(29).SetCellValue("合计实收款");
            row1.CreateCell(30).SetCellValue("应收款金额");
            row1.CreateCell(31).SetCellValue("案件支出");
            row1.CreateCell(32).SetCellValue("案件收益");
            row1.CreateCell(33).SetCellValue("案件收益率");
            row1.CreateCell(34).SetCellValue("是否结案");
            row1.CreateCell(35).SetCellValue("是否预警");
            row1.CreateCell(36).SetCellValue("备注");

            //....N行


            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].B_AreaName);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].B_Case_cons);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].B_Case_organ);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].B_Case_number);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].B_Plaintiff_Name);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].B_Defendant_Name);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].B_Project_Name);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].B_Case_Type);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].B_TransferTime);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].B_TransferPrice);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].B_Case_CurrentStage);
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].B_Case_AllStage);
                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].B_ExpectedPrice);
                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].B_DocumentPrice);
                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].B_OverduePrice);
                rowtemp.CreateCell(15).SetCellValue(listsLoan[i].B_RealPrice);
                rowtemp.CreateCell(16).SetCellValue(listsLoan[i].B_TotalDisbursementPrice);
                rowtemp.CreateCell(17).SetCellValue(listsLoan[i].B_AcceptancePrice);
                rowtemp.CreateCell(18).SetCellValue(listsLoan[i].B_MaintenancePrice);
                rowtemp.CreateCell(19).SetCellValue(listsLoan[i].B_GuaranteePrice);
                rowtemp.CreateCell(20).SetCellValue(listsLoan[i].B_BondPrice);
                rowtemp.CreateCell(21).SetCellValue(listsLoan[i].B_TravelPrice);
                rowtemp.CreateCell(22).SetCellValue(listsLoan[i].B_AnnouncementPrice);
                rowtemp.CreateCell(23).SetCellValue(listsLoan[i].B_CourtExecutivePrice);
                rowtemp.CreateCell(24).SetCellValue(listsLoan[i].B_RefundReceivablePrice);
                rowtemp.CreateCell(25).SetCellValue(listsLoan[i].B_CourtReceivablePrice);
                rowtemp.CreateCell(26).SetCellValue(listsLoan[i].B_NotReceivablePrice);
                rowtemp.CreateCell(27).SetCellValue(listsLoan[i].B_DisbursementPrice);
                rowtemp.CreateCell(28).SetCellValue(listsLoan[i].B_TotalReceivablesPrice);
                rowtemp.CreateCell(29).SetCellValue(listsLoan[i].B_TotalRealPrice);
                rowtemp.CreateCell(30).SetCellValue(listsLoan[i].B_ReceivablePrice);
                rowtemp.CreateCell(31).SetCellValue(listsLoan[i].B_CaseExpensesPrice);
                rowtemp.CreateCell(32).SetCellValue(listsLoan[i].B_CaseProceedsPrice);
                rowtemp.CreateCell(33).SetCellValue(listsLoan[i].B_CaseYieldPrice);
                rowtemp.CreateCell(34).SetCellValue(listsLoan[i].B_CaseStatus);
                rowtemp.CreateCell(35).SetCellValue(listsLoan[i].B_EarlyWarning);
                rowtemp.CreateCell(36).SetCellValue(listsLoan[i].B_Remark);



                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "财务报表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion

    }
}