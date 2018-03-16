using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    public class R_Case_Reporting
    {
        private readonly DAL.Reporting.R_Case_Reporting dal = new DAL.Reporting.R_Case_Reporting();

        private readonly BLL.CaseManager.B_Case caseBLL = new CaseManager.B_Case(); //案件业务逻辑

        private readonly BLL.CaseManager.B_Case_link caseLinkBLL = new CaseManager.B_Case_link(); //案件关联业务逻辑


        private readonly BLL.FlowManager.P_Business_flow_form flowformBll = new FlowManager.P_Business_flow_form(); //表单表
        private readonly BLL.FlowManager.P_Business_flow busBll = new FlowManager.P_Business_flow(); //流程

        private readonly BLL.CustomerForm.F_FormPropertyValue formPropertyValueBll = new CustomerForm.F_FormPropertyValue();

        private readonly BLL.C_Parameters cParamerBLL = new C_Parameters();
        public R_Case_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Reporting.R_Case_Reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_Case_Reporting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除所有数据
        /// </summary>
        public bool DeleteAll()
        {
            return dal.DeleteAll();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.R_Case_Reporting GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Reporting.R_Case_Reporting GetModelByCache(int ID)
        {

            string CacheKey = "R_Case_ReportingModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.Reporting.R_Case_Reporting)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.V_Case_Reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.V_Case_Reporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.V_Case_Reporting> modelList = new List<Model.Reporting.V_Case_Reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.V_Case_Reporting model = null;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToVModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.Reporting.V_Case_Reporting model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.Reporting.V_Case_Reporting> GetListByPage(CommonService.Model.Reporting.V_Case_Reporting model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 报表数据处理
        /// </summary>
        public void Statistics()
        {
            BLL.SysManager.C_Organization organBLL = new SysManager.C_Organization();
            //删除所有报表数据
            dal.DeleteAll();

            //获取所有案件
            var b_caseList = caseBLL.GetModelList(" B_Case_isDelete=0");

            foreach (var item in b_caseList)
            {
                CommonService.Model.Reporting.R_Case_Reporting model = new CommonService.Model.Reporting.R_Case_Reporting();
                model.B_Case_code = item.B_Case_code.Value;
                model.B_Case_number = item.B_Case_number;
                model.B_Case_cons = caseLinkBLL.GetStringFK(item.B_Case_code.Value, 11); //专业顾问
                List<Model.CaseManager.B_Case_link> blList = caseLinkBLL.GetCaseLinksByCaseAndType(item.B_Case_code.Value, 11);
                Model.CaseManager.B_Case_link bl = blList.FirstOrDefault();
                if (bl != null)
                {
                    Model.SysManager.C_Organization organ = organBLL.GetModel(bl.C_FK_code.Value);
                    if(organ!=null)
                    {
                        model.B_Case_organ = organ.C_Organization_name; //部门
                    }
                }
               

                //获取原告
                model.B_Plaintiff_Name = caseLinkBLL.GetStringFK(item.B_Case_code.Value, 1); //委托人

                model.B_AreaName = caseLinkBLL.GetStringFK(item.B_Case_code.Value, 6); //区域


                string cbeigao = caseLinkBLL.GetStringFK(item.B_Case_code.Value, 2);
                string pbeigao = caseLinkBLL.GetStringFK(item.B_Case_code.Value, 3);
                if (cbeigao != "" && pbeigao != "")
                {
                    cbeigao = cbeigao + "," + pbeigao;
                }
                model.B_Defendant_Name = cbeigao == "" ? pbeigao : cbeigao; //被告

                //获取项目名称
                model.B_Project_Name = caseLinkBLL.GetStringFK(item.B_Case_code.Value, 7); //工程



                //案件类型
                var typemodel = cParamerBLL.GetModel(item.B_Case_type.Value);
                if (typemodel != null)
                {
                    model.B_Case_Type = typemodel.C_Parameters_name;
                }



                //移交时间(预收案时间)
                model.B_TransferTime = item.B_Case_registerTime;

                //移交金额(移交标的)
                model.B_TransferPrice = item.B_Case_transferTargetMoney;

                //案件当前阶段
                var busilist = busBll.GetListByFkCode(item.B_Case_code.Value);
                foreach (var chibusi in busilist.Where(p => p.P_Business_state == 200).ToList())
                {
                    model.B_Case_CurrentStage = model.B_Case_CurrentStage + chibusi.P_Business_flow_name + ",";
                }


                if (model.B_Case_CurrentStage != null && model.B_Case_CurrentStage != "")
                    model.B_Case_CurrentStage = model.B_Case_CurrentStage.Substring(0, model.B_Case_CurrentStage.Length - 1);


                //案件所有阶段
                foreach (var chibusi in busilist)
                {
                    model.B_Case_AllStage = model.B_Case_AllStage + chibusi.P_Business_flow_name + ",";
                }
                if (model.B_Case_AllStage != null && model.B_Case_AllStage != "")
                    model.B_Case_AllStage = model.B_Case_AllStage.Substring(0, model.B_Case_AllStage.Length - 1);

                //预期收入(数据来源是：【立案前准备】“预期收益计算”)
                if (busilist != null)
                {
                    var laqzbmodel = busilist.Where(p => p.P_Business_flow_name == "立案前准备").OrderByDescending(p => p.P_Business_flow_id).FirstOrDefault();
                    if (laqzbmodel != null)
                    {
                        var formformlist = flowformBll.GetBusinessFlowForms(laqzbmodel.P_Business_flow_code.Value);
                        if (formformlist != null)
                        {
                            //预期收益计算
                            var formmodel = formformlist.Where(p => p.F_Form_code == Guid.Parse("128EBF60-F58E-4AE2-B3B7-826DD62A0960")).FirstOrDefault();
                            if (formmodel != null)
                            {
                                //首席预期收益金额
                                var fmodel = formPropertyValueBll.GetModel(formmodel.F_Form_code.Value, formmodel.P_Business_flow_form_code.Value, Guid.Parse("E16EC45B-E0E6-40CC-8F8D-1FCAD9D54CAB"));
                                //部长预期收益金额
                                var fmodel1 = formPropertyValueBll.GetModel(formmodel.F_Form_code.Value, formmodel.P_Business_flow_form_code.Value, Guid.Parse("7B13CA2B-1B19-44CD-8259-D9C473A4D06C"));
                                //律师预期收益金额
                                var fmodel2 = formPropertyValueBll.GetModel(formmodel.F_Form_code.Value, formmodel.P_Business_flow_form_code.Value, Guid.Parse("542B2580-01A5-41A1-A789-D4BD613AF448"));

                                if (fmodel != null && fmodel.F_FormPropertyValue_value != null && fmodel.F_FormPropertyValue_value != "")
                                {
                                    model.B_ExpectedPrice = Convert.ToDecimal(fmodel.F_FormPropertyValue_value);
                                }
                                else if (fmodel1 != null && fmodel1.F_FormPropertyValue_value != null && fmodel1.F_FormPropertyValue_value != "")
                                {
                                    model.B_ExpectedPrice = Convert.ToDecimal(fmodel1.F_FormPropertyValue_value);
                                }
                                else if (fmodel2 != null && fmodel2.F_FormPropertyValue_value != null && fmodel2.F_FormPropertyValue_value != "")
                                {
                                    model.B_ExpectedPrice = Convert.ToDecimal(fmodel2.F_FormPropertyValue_value);
                                }
                                else
                                {
                                    model.B_ExpectedPrice = item.B_Case_expectedGrant;
                                }
                                //if (fmodel != null && fmodel.F_FormPropertyValue_value != null && fmodel.F_FormPropertyValue_value != "")
                                //{
                                //    model.B_ExpectedPrice = Convert.ToDecimal(fmodel.F_FormPropertyValue_value);
                                //}
                            }


                        }
                    }

                }



                //文书收入(数据来源是：【诉讼阶段】“诉讼办案小结,文书收入)

                if (busilist != null)
                {
                    var laqzbmodel = busilist.Where(p => p.P_Business_flow_name == "一审诉讼前段" || p.P_Business_flow_name == "一审诉讼后段" || p.P_Business_flow_name == "二审诉讼前段" || p.P_Business_flow_name == "二审诉讼后段").OrderByDescending(p => p.P_Business_flow_id).FirstOrDefault();
                    if (laqzbmodel != null)
                    {
                        var formformlist = flowformBll.GetBusinessFlowForms(laqzbmodel.P_Business_flow_code.Value);
                        if (formformlist != null)
                        {
                            //诉讼办案小结
                            var formmodel = formformlist.Where(p => p.F_Form_code == Guid.Parse("2E091784-C303-4BA5-99E6-DB33C29E48B2")).FirstOrDefault();
                            if (formmodel != null)
                            {
                                //文书收入
                                var fmodel = formPropertyValueBll.GetModel(formmodel.F_Form_code.Value, formmodel.P_Business_flow_form_code.Value, Guid.Parse("F04A72FE-A444-430B-96B1-57E4B1E50041"));
                                if (fmodel.F_FormPropertyValue_value != null && fmodel.F_FormPropertyValue_value != "")
                                {
                                    model.B_DocumentPrice = Convert.ToDecimal(fmodel.F_FormPropertyValue_value);
                                }
                            }


                        }
                    }

                }

                #region  //逾期收入(数据来源是：【执行立案前准备】执行方案)

                if (busilist != null)
                {
                    var laqzbmodel = busilist.Where(p => p.P_Business_flow_name == "执行立案前准备").OrderByDescending(p => p.P_Business_flow_id).FirstOrDefault();
                    if (laqzbmodel != null)
                    {
                        var formformlist = flowformBll.GetBusinessFlowForms(laqzbmodel.P_Business_flow_code.Value);
                        if (formformlist != null)
                        {
                            //执行方案
                            var formmodel = formformlist.Where(p => p.F_Form_code == Guid.Parse("321694F2-853F-434B-B255-91A907586523")).FirstOrDefault();
                            if (formmodel != null)
                            {
                                //逾期收入
                                var fmodel = formPropertyValueBll.GetModel(formmodel.F_Form_code.Value, formmodel.P_Business_flow_form_code.Value, Guid.Parse("D7EF6B19-DDD5-44CE-967A-CA0585135470"));
                                if (fmodel.F_FormPropertyValue_value != null && fmodel.F_FormPropertyValue_value != "")
                                {
                                    model.B_OverduePrice = Convert.ToDecimal(fmodel.F_FormPropertyValue_value);
                                }
                            }


                        }
                    }

                }
                #endregion



  //              //实际收入(财务填写数据（财务系统里是否有该项）)
  //              model.B_RealPrice = 0;



  //              string formCode = "4B483102-0B05-418A-ACC0-41313D5D083E";//费用报销单Guid(固定值)

  //              //受理费(数据来源：该案件下的所有受理费总和)
  //              //获取表单明细属性值
  //              string condition = "  \"0EACB483-D8EF-4141-A767-229DCD71F55A\" = 598 " + "and exists(select * from B_Case as C with(nolock) where C.B_Case_code=TT.P_Fk_code and C.B_Case_number like '%" + item.B_Case_number + "%') ";
  //              DataSet itemFormPropertyValues = formPropertyValueBll.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
  //                  1000, condition + " and  \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = 672");
  //              if (itemFormPropertyValues.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < itemFormPropertyValues.Tables[0].Rows.Count; i++)
  //                  {
  //                      if (itemFormPropertyValues.Tables[0].Rows[i][1] != "")
  //                          model.B_AcceptancePrice = model.B_AcceptancePrice + Convert.ToDecimal(itemFormPropertyValues.Tables[0].Rows[i][1]);
  //                  }
  //              }

  //              //保全费(数据来源：是该案件下的所有保全费总和)
  //              DataSet itemFormPropertyValues2 = formPropertyValueBll.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
  //               1000, condition + " and  \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = 673");
  //              if (itemFormPropertyValues.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < itemFormPropertyValues2.Tables[0].Rows.Count; i++)
  //                  {
  //                      if (itemFormPropertyValues2.Tables[0].Rows[i][1] != "")
  //                          model.B_MaintenancePrice = model.B_MaintenancePrice + Convert.ToDecimal(itemFormPropertyValues2.Tables[0].Rows[i][1]);
  //                  }
  //              }

  //              //担保费(数据来源：是该案件下的所有担保费总和)
  //              DataSet itemFormPropertyValues3 = formPropertyValueBll.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
  //            1000, condition + " and  \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = 674");
  //              if (itemFormPropertyValues3.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < itemFormPropertyValues3.Tables[0].Rows.Count; i++)
  //                  {
  //                      if (itemFormPropertyValues3.Tables[0].Rows[i][1] != "")
  //                          model.B_GuaranteePrice = model.B_GuaranteePrice + Convert.ToDecimal(itemFormPropertyValues3.Tables[0].Rows[i][1]);
  //                  }
  //              }

  //              //保证金(数据来源：是该案件下的所有保证金费总和)
  //              DataSet itemFormPropertyValues4 = formPropertyValueBll.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
  //          1000, condition + " and  \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = 678");
  //              if (itemFormPropertyValues4.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < itemFormPropertyValues4.Tables[0].Rows.Count; i++)
  //                  {
  //                      if (itemFormPropertyValues4.Tables[0].Rows[i][1] != "")
  //                          model.B_BondPrice = model.B_BondPrice + Convert.ToDecimal(itemFormPropertyValues4.Tables[0].Rows[i][1]);
  //                  }
  //              }

  //              //差旅费(数据来源：是该案件下的所有差旅费总和)
  //              DataSet itemFormPropertyValues5 = formPropertyValueBll.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
  //    1000, condition + " and  \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = 676");
  //              if (itemFormPropertyValues5.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < itemFormPropertyValues5.Tables[0].Rows.Count; i++)
  //                  {
  //                      if (itemFormPropertyValues5.Tables[0].Rows[i][1] != "")
  //                          model.B_TravelPrice = model.B_TravelPrice + Convert.ToDecimal(itemFormPropertyValues5.Tables[0].Rows[i][1]);
  //                  }
  //              }
  //              //公告费(数据来源：是该案件下的所有公告费总和)
  //              DataSet itemFormPropertyValues6 = formPropertyValueBll.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
  //  1000, condition + " and  \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = 675");
  //              if (itemFormPropertyValues6.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < itemFormPropertyValues6.Tables[0].Rows.Count; i++)
  //                  {
  //                      if (itemFormPropertyValues6.Tables[0].Rows[i][1] != "")
  //                          model.B_AnnouncementPrice = model.B_AnnouncementPrice + Convert.ToDecimal(itemFormPropertyValues6.Tables[0].Rows[i][1]);
  //                  }
  //              }

  //              //法院执行费(数据来源：是该案件下的所有法院执行费总和)
  //              DataSet itemFormPropertyValues8 = formPropertyValueBll.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
  //1000, condition + " and  \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = 794");
  //              if (itemFormPropertyValues8.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < itemFormPropertyValues8.Tables[0].Rows.Count; i++)
  //                  {
  //                      if (itemFormPropertyValues8.Tables[0].Rows[i][1] != "")
  //                          model.B_CourtExecutivePrice = model.B_CourtExecutivePrice + Convert.ToDecimal(itemFormPropertyValues8.Tables[0].Rows[i][1]);
  //                  }
  //              }

  //              //应收法院退费(数据来源：是该案件下的所有应收法院退费总和)
  //              DataSet itemFormPropertyValues7 = formPropertyValueBll.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
  //1000, condition + " and  \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = 677");
  //              if (itemFormPropertyValues7.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < itemFormPropertyValues7.Tables[0].Rows.Count; i++)
  //                  {
  //                      if (itemFormPropertyValues7.Tables[0].Rows[i][1] != "")
  //                          model.B_RefundReceivablePrice = model.B_RefundReceivablePrice + Convert.ToDecimal(itemFormPropertyValues7.Tables[0].Rows[i][1]);
  //                  }
  //              }

  //              //已收法院退费(数据来源：是该案件下的所有已收法院退费总和)
  //              model.B_CourtReceivablePrice = model.B_RefundReceivablePrice;

  //              //未收法院退费(数据来源：是该案件下的所有未收法院退费总和)
  //              model.B_NotReceivablePrice = model.B_RefundReceivablePrice;



  //              //应收代垫款总额（应收代垫款总额=受理费+保全费+担保费+保证金+差旅费+公告费+法院执行费-应收法院退费）
  //              model.B_TotalDisbursementPrice = (model.B_AcceptancePrice + model.B_MaintenancePrice + model.B_GuaranteePrice + model.B_BondPrice + model.B_TravelPrice + model.B_AnnouncementPrice + model.B_CourtExecutivePrice) - model.B_RefundReceivablePrice;


  //              //实收代垫款总额(财务填写数据（财务系统里是否有该信息）)
  //              model.B_DisbursementPrice = 0;

  //              //合计应收款(文书收入+逾期收入)
  //              model.B_TotalReceivablesPrice = model.B_DocumentPrice + model.B_OverduePrice;


  //              //合计实收款(实际收入+实收代垫款)
  //              model.B_TotalRealPrice = 0;

  //              //应收款余额(合计应收款-合计实收款)
  //              model.B_ReceivablePrice = model.B_TotalReceivablesPrice - model.B_TotalRealPrice;
  //              //案件支出（无数据来源（暂为0）
  //              model.B_CaseExpensesPrice = 0;
  //              //案件收益（无数据来源）

  //              model.B_CaseProceedsPrice = 0;
  //              //案件收益率（无数据来源）
  //              model.B_CaseYieldPrice = 0;

  //              //是否结案
  //              switch (item.B_Case_state)
  //              {
  //                  case 199:
  //                      model.B_CaseStatus = "未开始";
  //                      break;
  //                  case 200:
  //                      model.B_CaseStatus = "进行中";
  //                      break;
  //                  case 201:
  //                      model.B_CaseStatus = "已结案";
  //                      break;
  //              }


  //              //是否预警(预期收入时间间隔3月若未填入文书收入 进行预警；文书收入到实际收入间隔2月，超时预警。（预警时效财务确定后补充）)

  //              model.B_EarlyWarning = "";



  //              //备注
  //              model.B_Remark = item.B_Case_remark;


                dal.Add(model);

            }

        }
        #endregion  ExtensionMethod
    }
}

