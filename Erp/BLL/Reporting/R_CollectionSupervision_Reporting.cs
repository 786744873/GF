using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    public class R_CollectionSupervision_Reporting
    {
        private readonly DAL.Reporting.R_CollectionSupervision_Reporting dal = new DAL.Reporting.R_CollectionSupervision_Reporting();


        private readonly BLL.CaseManager.B_Case caseBLL = new CaseManager.B_Case(); //案件业务逻辑


        private readonly BLL.FlowManager.P_Business_flow busBll = new FlowManager.P_Business_flow(); //流程


        private readonly BLL.CaseManager.B_Case_link caseLinkBLL = new CaseManager.B_Case_link(); //案件关联业务逻辑


        private readonly BLL.FlowManager.P_Business_flow_form flowformBll = new FlowManager.P_Business_flow_form(); //表单表


        private readonly BLL.CustomerForm.F_FormPropertyValue formPropertyValueBll = new CustomerForm.F_FormPropertyValue();


        private readonly BLL.FlowManager.P_Flow flowBll = new FlowManager.P_Flow();


        private readonly BLL.C_Court courtBLL = new C_Court(); //法院业务逻辑
        public R_CollectionSupervision_Reporting()
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
        public int Add(CommonService.Model.Reporting.R_CollectionSupervision_Reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_CollectionSupervision_Reporting model)
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.R_CollectionSupervision_Reporting GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Reporting.R_CollectionSupervision_Reporting GetModelByCache(int ID)
        {

            string CacheKey = "R_CollectionSupervision_ReportingModel-" + ID;
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
            return (Model.Reporting.R_CollectionSupervision_Reporting)objModel;
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
        public List<Model.Reporting.R_CollectionSupervision_Reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_CollectionSupervision_Reporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.R_CollectionSupervision_Reporting> modelList = new List<Model.Reporting.R_CollectionSupervision_Reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.R_CollectionSupervision_Reporting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
            //删除处理
            dal.DeleteAll();
            var dsflow = busBll.GetListByFlowCode(Guid.Parse("627FAD91-4396-454C-BAA4-8AC15E5997C7")); //收款监督
            foreach (var item in dsflow)
            {
                Model.Reporting.R_CollectionSupervision_Reporting model = new Model.Reporting.R_CollectionSupervision_Reporting();

                if (item.P_Fk_code == null) continue;
                //获取案件
                var casemodel = caseBLL.GetModel(item.P_Fk_code.Value);
                if (casemodel != null)
                {

                    model.Year = casemodel.B_Case_registerTime == null ? "" : casemodel.B_Case_registerTime.Value.Year.ToString(); // 年
                    model.Month = casemodel.B_Case_registerTime == null ? "" : casemodel.B_Case_registerTime.Value.Month.ToString(); //月
                    model.AreaName = caseLinkBLL.GetStringFK(casemodel.B_Case_code.Value, 6); //地区
                    model.HostName = item.P_Business_person_name; //主办

                    model.CoName = flowformBll.GetCoNames(item.P_Business_flow_code.Value); //协办

                    model.Case_Number = casemodel.B_Case_number; //案号

                    model.B_Plaintiff_Name = caseLinkBLL.GetStringFK(casemodel.B_Case_code.Value, 1); //委托人

                    string cbeigao = caseLinkBLL.GetStringFK(casemodel.B_Case_code.Value, 2);
                    string pbeigao = caseLinkBLL.GetStringFK(casemodel.B_Case_code.Value, 3);
                    if (cbeigao != "" && pbeigao != "")
                    {
                        cbeigao = cbeigao + "," + pbeigao;
                    }
                    model.B_Defendant_Name = cbeigao == "" ? pbeigao : cbeigao; //被告

                    model.B_Project_Name = caseLinkBLL.GetStringFK(casemodel.B_Case_code.Value, 7); //工程


                    model.AcceptanceTime = casemodel.B_Case_registerTime == null ? "" : casemodel.B_Case_registerTime.Value.ToString(); //收案时间

                    model.B_TransferPrice = casemodel.B_Case_transferTargetMoney == null ? "" : casemodel.B_Case_transferTargetMoney.ToString(); //移交标的

                    model.B_ExpectedPrice = casemodel.B_Case_expectedGrant == null ? "" : casemodel.B_Case_expectedGrant.ToString(); //预期收益


                    string courtString = "";
                    if (casemodel.B_Case_courtFirst != null && casemodel.B_Case_courtFirst.ToString() != "") //一审法院
                    {
                        Model.C_Court court = courtBLL.GetModel(new Guid(casemodel.B_Case_courtFirst.ToString()));
                        if (court != null)
                        {
                            courtString += court.C_Court_name + ",";
                        }
                    }

                    if (casemodel.B_Case_courtSecond != null && casemodel.B_Case_courtSecond.ToString() != "") //二审法院
                    {
                        Model.C_Court court = courtBLL.GetModel(new Guid(casemodel.B_Case_courtSecond.ToString()));
                        if (court != null)
                        {
                            courtString += court.C_Court_name + ",";
                        }
                    }

                    if (casemodel.B_Case_courtExec != null && casemodel.B_Case_courtExec.ToString() != "") //管辖法院
                    {
                        Model.C_Court court = courtBLL.GetModel(new Guid(casemodel.B_Case_courtExec.ToString()));
                        if (court != null)
                        {
                            courtString += court.C_Court_name + ",";
                        }
                    }

                    if (casemodel.B_Case_Trial != null && casemodel.B_Case_Trial.ToString() != "") //监督法院
                    {
                        Model.C_Court court = courtBLL.GetModel(new Guid(casemodel.B_Case_Trial.ToString()));
                        if (court != null)
                        {
                            courtString += court.C_Court_name + ",";
                        }
                    }

                    if (courtString.Length > 0)
                    {
                        courtString = courtString.Substring(0, courtString.Length - 1);
                    }

                    model.JurisdictionCourt = courtString; //法院



                    model.WhetherActivePerformance = "";  //是否主动履行(无数据来源)

                    var busilist = busBll.GetListByFkCode(casemodel.B_Case_code.Value);
                    //是否转执行（）
                    foreach (var lc in busilist)
                    {
                        var Folwmodel = flowBll.GetModel(lc.P_Flow_code.Value);
                        if (Folwmodel != null && Folwmodel.P_Flow_ManagerType == 807)//807执行阶段
                        {
                            model.WhetherToExecute = model.WhetherToExecute + Folwmodel.P_Flow_name + ",";
                        }
                    }


                    //可销售回款额

                    var formformPlt = flowformBll.GetBusinessFlowForms(item.P_Business_flow_code.Value);
                    if (formformPlt != null)
                    {
                        //收款监督
                        var chiformmodel_1 = formformPlt.Where(p => p.F_Form_code == Guid.Parse("EBD190B4-FD91-4B11-9146-7EB1C11E0D17")).FirstOrDefault();
                        if (chiformmodel_1 != null)
                        {
                            //已回款+回款列表中的回款额之和
                            var fmodel = formPropertyValueBll.GetModel(chiformmodel_1.F_Form_code.Value, chiformmodel_1.P_Business_flow_form_code.Value, Guid.Parse("60AD1204-1EFC-47F3-A008-EA3C5A0953A2"));
                            if (fmodel.F_FormPropertyValue_value != null && fmodel.F_FormPropertyValue_value != "")
                            {
                                model.SalesReturn = fmodel.F_FormPropertyValue_value;
                            }
                            decimal dsprice = 0;
                            DataSet flist = formPropertyValueBll.DynamicLoadCustmerFormListValues(chiformmodel_1.F_Form_code.Value, chiformmodel_1.P_Business_flow_form_code.Value);
                            for (int i = 0; i < flist.Tables[0].Rows.Count; i++)
                            {

                                if (flist.Tables[2].Rows.Count > 0 && i < flist.Tables[2].Rows.Count && flist.Tables[2].Rows[i][1] != "")
                                {
                                    if (flist.Tables[2].Rows[i][1] != "" && flist.Tables[2].Rows[i][1] != null && flist.Tables[2].Rows[i][1].ToString().Contains(":"))
                                    {
                                        dsprice = dsprice + Convert.ToDecimal(flist.Tables[2].Rows[i][1]);
                                    }
                                }
                            }

                            //可销售回款额
                            if (dsprice > 0)
                            {
                                if (model.SalesReturn != null && model.SalesReturn != "")
                                {
                                    model.SalesReturn = (Convert.ToDecimal(model.SalesReturn) + dsprice).ToString();
                                }
                                else
                                {
                                    model.SalesReturn = dsprice.ToString();
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
                                var chiformmodel = formformlist.Where(p => p.F_Form_code == Guid.Parse("2E091784-C303-4BA5-99E6-DB33C29E48B2")).FirstOrDefault();
                                if (chiformmodel != null)
                                {
                                    //文书收入
                                    var fmodel = formPropertyValueBll.GetModel(chiformmodel.F_Form_code.Value, chiformmodel.P_Business_flow_form_code.Value, Guid.Parse("F04A72FE-A444-430B-96B1-57E4B1E50041"));
                                    if (fmodel.F_FormPropertyValue_value != null && fmodel.F_FormPropertyValue_value != "")
                                    {
                                        model.DocumentIncome = fmodel.F_FormPropertyValue_value;
                                    }
                                }
                            }
                        }

                    }


                }



                dal.Add(model);

            }


        }

        #endregion  ExtensionMethod
    }
}


