using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    /// <summary>
    /// 案件执行控制器
    /// </summary>
    public class CaseExecuteController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        private readonly ICommonService.Milepost.IJ_No_Milepost _NoImilepost;
        private readonly ICommonService.Milepost.IJ_Milepost Imilepost;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance_link _businessChance_linkWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance_check _businessChance_checkWCF;
        private readonly ICommonService.CaseManager.IB_Case_Confirm _case_confirmWCF;
        private readonly ICommonService.Customer.IV_CheckAuthority checkAuthorityWCF;
        public CaseExecuteController()
        {
            #region 服务初始化
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _NoImilepost = ServiceProxyFactory.Create<ICommonService.Milepost.IJ_No_Milepost>("NoMilepostWCF");
            Imilepost = ServiceProxyFactory.Create<ICommonService.Milepost.IJ_Milepost>("MilepostWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            _businessChance_linkWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance_link>("BusinessChance_linkWCF");
            _businessChance_checkWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance_check>("B_BusinessChance_checkWCF");
            _case_confirmWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_Confirm>("CaseConfirmWCF");
            checkAuthorityWCF = ServiceProxyFactory.Create<ICommonService.Customer.IV_CheckAuthority>("VCheckAuthorityWCF");
            #endregion
        }

        //
        // GET: /CaseManager/CaseExecute/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 案件执行布局页Action
        /// </summary>
        /// <param name="fkCode">关联Guid比如案件、商机Guid等</param>
        /// <param name="fkType">关联Guid类型,案件=153;商机=154</param>
        /// <returns></returns>
        public ActionResult DefaultLayout(string fkCode, int fkType)
        {
            if (!string.IsNullOrEmpty(fkCode))
            {
                string[] a = fkCode.Split(',');
                if (a.Length == 2)
                {
                    fkCode = a[0];
                }
            }
            else
            {
                fkCode = Guid.Empty.ToString();
            }
            List<CommonService.Model.FlowManager.P_Business_flow> BusinessFlows = _bussinessFlowWCF.GetListByFkCodeAndLevel(new Guid(fkCode), 1);
            CommonService.Model.CaseManager.B_Case Case = _caseWCF.GetModel(new Guid(fkCode));
            CommonService.Model.SysManager.C_Userinfo userinfo = new CommonService.Model.SysManager.C_Userinfo();
            if (Case.B_Consultant_code != null && Case.B_Consultant_code != "")
            {
                string[] consultantStr = Case.B_Consultant_code.Split(',');
                userinfo = _userinfoWCF.GetModelByUserCode(new Guid(consultantStr[0]));
                ViewBag.userinfo = userinfo;
            }
            else
            {
                ViewBag.userinfo = userinfo;
            }
            ViewBag.Case = Case;
            ViewBag.FkCode = fkCode;
            ViewBag.FkType = fkType;
            ViewBag.Fstate = Case.B_Case_state;

            ViewBag.CoutName1 = Case.B_Case_courtFirstName;
            ViewBag.Cout1 = Case.B_Case_courtFirst;

            ViewBag.CoutName2 = Case.B_Case_courtSecondName;
            ViewBag.Cout2 = Case.B_Case_courtSecond;

            ViewBag.CoutName3 = Case.B_Case_courtExecName;
            ViewBag.Cout3 = Case.B_Case_courtExec;

            ViewBag.CoutName4 = Case.B_Case_TrialName;
            ViewBag.Cout4 = Case.B_Case_Trial;

            //获取该案件下对应表单字段的值
            //预期收益
            string expectedGrant = "0";
            //文书
            string DocumValue = "0";

            string DocumTimeValue = "";

            string yqsrValue = "0";

            string yqsrTimeValue = "";
            if (BusinessFlows.Count > 0)
            {
                foreach (var item in BusinessFlows.OrderBy(p => p.P_Business_createTime).ToList())
                {
                    var flowformlist = _businessFlowFormWCF.GetBusinessFlowForms(item.P_Business_flow_code.Value);
                    //128EBF60-F58E-4AE2-B3B7-826DD62A0960(预期收益计算)
                    expectedGrant = BindFormValue(expectedGrant, flowformlist, Guid.Parse("128EBF60-F58E-4AE2-B3B7-826DD62A0960"), "预期收入额");
                    // 诉讼办案小结2E091784-C303-4BA5-99E6-DB33C29E48B2
                    DocumValue = BindFormValue(DocumValue, flowformlist, Guid.Parse("2E091784-C303-4BA5-99E6-DB33C29E48B2"), "文书收入(元)");
                    //  DocumTimeValue = BindFormValue(DocumTimeValue, flowformlist, Guid.Parse("2E091784-C303-4BA5-99E6-DB33C29E48B2"), "文书生效时间");

                    //执行方案 321694F2-853F-434B-B255-91A907586523
                    yqsrValue = BindFormValue(yqsrValue, flowformlist, Guid.Parse("321694F2-853F-434B-B255-91A907586523"), "逾期收入(元)");
                    //  yqsrTimeValue = BindFormValue(yqsrTimeValue, flowformlist, Guid.Parse("321694F2-853F-434B-B255-91A907586523"), "拟执行立案时间");
                }
            }

            ViewBag.expectedGrant = expectedGrant;
            ViewBag.DocumValue = DocumValue;
            ViewBag.DocumTimeValue = DocumTimeValue;
            ViewBag.yqsrValue = yqsrValue;
            ViewBag.yqsrTimeValue = yqsrTimeValue;

            #region 提交结案
            CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.GetModelIsCrossForm(new Guid(fkCode), Context.UIContext.Current.UserCode.Value);
            ViewBag.businessFlow = businessFlow;
            #endregion

            #region 结案确认
            CommonService.Model.CaseManager.B_Case_Confirm caseConfirm = _case_confirmWCF.GetModelByCaseAndPerson(new Guid(fkCode), Context.UIContext.Current.UserCode.Value);
            ViewBag.caseConfirm = caseConfirm;
            #endregion

            #region 提交结案纪要
            List<CommonService.Model.CaseManager.B_Case_Confirm> confirmList = _case_confirmWCF.GetListByCaseCode(new Guid(fkCode));
            ViewBag.confirmList = confirmList;
            #endregion

            #region 案件稽查情况
            List<CommonService.Model.Customer.V_CheckAuthority> VCheckAuthoritys = checkAuthorityWCF.GetBriefCheckAuthorityByPkCode(new Guid(fkCode));
            ViewBag.VCheckAuthoritys = VCheckAuthoritys;
            #endregion

            return View(BusinessFlows);
        }

        private string BindFormValue(string expectedGrant, List<CommonService.Model.FlowManager.P_Business_flow_form> flowformlist, Guid F_Form_code, string F_FormProperty_showName)
        {
            if (flowformlist.Count > 0 && flowformlist.Where(p => p.F_Form_code == F_Form_code).Count() > 0)
            {
                //当该流程存在表单的时候
                foreach (var item2 in flowformlist)
                {
                    string formvalue = _caseWCF.GetFormValue(item2.P_Business_flow_form_code.Value.ToString(), F_FormProperty_showName, F_Form_code.ToString());

                    if (formvalue != null && formvalue != "")
                    {
                        expectedGrant = formvalue.Replace(".00", "");
                        break;
                    }
                }
            }
            return expectedGrant;
        }

        /// <summary>
        /// 案件执行布局页Action
        /// </summary>
        /// <param name="fkCode">关联Guid比如案件、商机Guid等</param>
        /// <param name="fkType">关联Guid类型,案件=153;商机=154</param>
        /// <returns></returns>
        public ActionResult DefaultLayout_Milepost(int MilepostID, int fkType)
        {
            var dmodel = _NoImilepost.GetModel(MilepostID);

            //获取案件
            var caseModelN = _caseWCF.GetModelList(" B_Case_number='" + dmodel.J_No_Milepost_CaseNumber + "'")[0];

            List<CommonService.Model.FlowManager.P_Business_flow> BusinessFlows = _bussinessFlowWCF.GetListByFkCodeAndLevel(caseModelN.B_Case_code.Value, 1);
            CommonService.Model.CaseManager.B_Case Case = _caseWCF.GetModel(caseModelN.B_Case_code.Value);
            CommonService.Model.SysManager.C_Userinfo userinfo = new CommonService.Model.SysManager.C_Userinfo();
            ViewBag.Case = Case;
            if (Case.B_Consultant_code != null && Case.B_Consultant_code != "")
            {
                string[] consultantStr = Case.B_Consultant_code.Split(',');
                userinfo = _userinfoWCF.GetModelByUserCode(new Guid(consultantStr[0]));
                ViewBag.userinfo = userinfo;
            }
            else
            {
                ViewBag.userinfo = userinfo;
            }
            ViewBag.FkCode = caseModelN.B_Case_code.Value.ToString();
            ViewBag.FkType = fkType;
            ViewBag.Fstate = Case.B_Case_state;

            #region 案件法院
            ViewBag.CoutName1 = Case.B_Case_courtFirstName;
            ViewBag.Cout1 = Case.B_Case_courtFirst;

            ViewBag.CoutName2 = Case.B_Case_courtSecondName;
            ViewBag.Cout2 = Case.B_Case_courtSecond;

            ViewBag.CoutName3 = Case.B_Case_courtExecName;
            ViewBag.Cout3 = Case.B_Case_courtExec;

            ViewBag.CoutName4 = Case.B_Case_TrialName;
            ViewBag.Cout4 = Case.B_Case_Trial;
            #endregion

            #region 案件稽查情况
            List<CommonService.Model.Customer.V_CheckAuthority> VCheckAuthoritys = checkAuthorityWCF.GetBriefCheckAuthorityByPkCode(caseModelN.B_Case_code.Value);
            ViewBag.VCheckAuthoritys = VCheckAuthoritys;
            #endregion

            #region 提交结案纪要
            List<CommonService.Model.CaseManager.B_Case_Confirm> confirmList = _case_confirmWCF.GetListByCaseCode(caseModelN.B_Case_code.Value);
            ViewBag.confirmList = confirmList;
            #endregion

            return View("DefaultLayout", BusinessFlows);
        }
        public ActionResult DefaultLayout_Milepost_2(int MilepostID, int fkType)
        {
            var dmodel = Imilepost.GetModel(MilepostID);

            //获取案件
            var caseModelN = _caseWCF.GetModelList(" B_Case_number='" + dmodel.J_Milepost_CaseNumber + "'")[0];

            List<CommonService.Model.FlowManager.P_Business_flow> BusinessFlows = _bussinessFlowWCF.GetListByFkCodeAndLevel(caseModelN.B_Case_code.Value, 1);
            CommonService.Model.CaseManager.B_Case Case = _caseWCF.GetModel(caseModelN.B_Case_code.Value);
            CommonService.Model.SysManager.C_Userinfo userinfo = new CommonService.Model.SysManager.C_Userinfo();
            ViewBag.Case = Case;
            if (Case.B_Consultant_code != null && Case.B_Consultant_code != "")
            {
                string[] consultantStr = Case.B_Consultant_code.Split(',');
                userinfo = _userinfoWCF.GetModelByUserCode(new Guid(consultantStr[0]));
                ViewBag.userinfo = userinfo;
            }
            else
            {
                ViewBag.userinfo = userinfo;
            }
            ViewBag.FkCode = caseModelN.B_Case_code.Value.ToString();
            ViewBag.FkType = fkType;
            ViewBag.Fstate = Case.B_Case_state;

            #region 案件法院
            ViewBag.CoutName1 = Case.B_Case_courtFirstName;
            ViewBag.Cout1 = Case.B_Case_courtFirst;

            ViewBag.CoutName2 = Case.B_Case_courtSecondName;
            ViewBag.Cout2 = Case.B_Case_courtSecond;

            ViewBag.CoutName3 = Case.B_Case_courtExecName;
            ViewBag.Cout3 = Case.B_Case_courtExec;

            ViewBag.CoutName4 = Case.B_Case_TrialName;
            ViewBag.Cout4 = Case.B_Case_Trial;
            #endregion

            #region 案件稽查情况
            List<CommonService.Model.Customer.V_CheckAuthority> VCheckAuthoritys = checkAuthorityWCF.GetBriefCheckAuthorityByPkCode(caseModelN.B_Case_code.Value);
            ViewBag.VCheckAuthoritys = VCheckAuthoritys;
            #endregion

            #region 提交结案纪要
            List<CommonService.Model.CaseManager.B_Case_Confirm> confirmList = _case_confirmWCF.GetListByCaseCode(caseModelN.B_Case_code.Value);
            ViewBag.confirmList = confirmList;
            #endregion

            return View("DefaultLayout", BusinessFlows);
        }
        /// <summary>
        /// 商机执行布局页Action
        /// </summary>
        /// <param name="fkCode">关联Guid比如案件、商机Guid等</param>
        /// <param name="fkType">关联Guid类型,案件=153;商机=154</param>
        /// <returns></returns>
        public ActionResult BusinessChanceDefaultLayout(string fkCode, int fkType)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> BusinessFlows = _bussinessFlowWCF.GetListByFkCodeAndLevel(new Guid(fkCode), 1);
            CommonService.Model.BusinessChanceManager.B_BusinessChance BusinessChance = _businessChanceWCF.GetModel(new Guid(fkCode));
            //最近一次审查的数据模型
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check latestChanceCheck = _businessChance_checkWCF.GetLatestChanceCheckByBusinessChance(new Guid(fkCode));

            ViewBag.BusinessChance = BusinessChance;
            ViewBag.FkCode = fkCode;
            ViewBag.FkType = fkType;
            ViewBag.Fstate = BusinessChance.B_BusinessChance_state;
            ViewBag.LatestChanceCheck = latestChanceCheck;

            #region 数据权限
            List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                roleRolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
            }
            else
            {
                roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(Context.UIContext.Current.OrgCode,Context.UIContext.Current.UserCode,
                    Context.UIContext.Current.PostCode);
            }
            ViewBag.RoleRolePowers = roleRolePowers;

            bool isBusiChangeConsultant = false;//当前登录用户是否此商机专业顾问
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                //当前商机专业顾问
                List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> businessChanceLinks = _businessChance_linkWCF.GetBusinessChanceLinks(new Guid(fkCode), 5);
                if (businessChanceLinks.Where(p => p.C_FK_code == Context.UIContext.Current.UserCode).Count() != 0)
                {
                    isBusiChangeConsultant = true;
                }
            }

            ViewBag.IsBusiChangeConsultant = isBusiChangeConsultant;
            #endregion

            #region 按钮权限

            /**
             * author:hety
             * date:2015-10-27
             * descption:
             * 在商机未启动的情况下，"商机启动"按钮，根据当前用户是否拥有此按钮的权限来控制(内置系统管理员除外)
             ***/
            bool isShowStartBtn = false;//是否显示"商机启动"按钮
            if (BusinessChance != null)
            {
                if (BusinessChance.B_BusinessChance_state == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    if (Context.UIContext.Current.IsPreSetManager)
                    {
                        isShowStartBtn = true;
                    }
                    else
                    {
                        this.InitializationButtonsPower();
                        List<CommonService.Model.SysManager.C_Role_button> RoleButtons = ViewBag.RoleButtons;
                        if (RoleButtons.Where(r => r.C_Menu_buttons_id == 132).Count() != 0)
                        {
                            isShowStartBtn = true;
                        }
                    }
                }
            }
            ViewBag.IsShowStartBtn = isShowStartBtn;
            #endregion

            return View(BusinessFlows);
        }

    }
}