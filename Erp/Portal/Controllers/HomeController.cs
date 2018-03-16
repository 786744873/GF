using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context;
using CommonService.Common;
using System.Collections;
using System.Text.RegularExpressions;

namespace Portal.Controllers
{
    /// <summary>
    /// 主控制器
    /// </summary>
    public class HomeController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Menu _menuWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.SysManager.IC_Post _postWCF;
        private readonly ICommonService.OA.IO_Email_user _emailUserWCF;
        private readonly ICommonService.OA.IO_Schedule_user _scheduleUserWCF;
        private readonly ICommonService.OA.IO_Schedule _scheduleWCF;
        private readonly ICommonService.OA.IO_Form_AuditFlow _oformAuditFlowWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.SysManager.IC_Log _LogWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userWCF;
        private readonly ICommonService.KMS.IK_Resources _resourcesWCF;
        private readonly ICommonService.KMS.IK_Problem _problemWCF;
        private readonly ICommonService.KMS.IK_Comments _commentsWCF;
        private readonly ICommonService.KMS.IK_Kms_Log _Kms_LogWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user_role _org_post_user_roleWCF;

        public HomeController()
        {
            #region 服务初始化
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _menuWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Menu>("menuWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _postWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Post>("PostWCF");
            _emailUserWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Email_user>("email_userWCF");
            _scheduleUserWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Schedule_user>("schedule_userWCF");
            _scheduleWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Schedule>("scheduleWCF");
            _oformAuditFlowWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form_AuditFlow>("oForm_AuditFlowWCF");
            _LogWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Log>("LogWCF");
            _userWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _resourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources>("K_ResourcesWCF");
            _problemWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Problem>("K_ProblemWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _commentsWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Comments>("K_CommentsWCF");
            _Kms_LogWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Kms_Log>("K_Kms_LogWCF");
            _org_post_user_roleWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user_role>("C_Organization_post_user_roleWCF");
            #endregion
        }

        public override ActionResult Index()
        {
            return View();
        }
        #region 虚拟对象
        public partial class caseList
        {
            public int value { get; set; }
            public string text { get; set; }
            public string color { get; set; }
            public string click { get; set; }
        }
        #endregion

        public ActionResult Default()
        {
            int pass = 0;
            if (Request.IsAuthenticated)
            {
                if (!Context.UIContext.Current.IsPreSetManager)
                {
                    CommonService.Model.SysManager.C_Userinfo model = _userinfoWCF.GetModelByUserCode(new Guid(Context.UIContext.Current.UserCode.ToString()));
                    if (model.C_Userinfo_password == "2251022057731868917119086224872421513662")
                    {
                        pass = 1;
                    }
                }
            }

            ViewBag.pass = pass;
            return View();
        }

        public ActionResult LeftMid()
        {
            return View();
        }

        public ActionResult TopMid()
        {
            return View();
        }

        public ActionResult Frameset()
        {
            return View();
        }

        public ActionResult Main()
        {

            CommonService.Model.SysManager.C_Userinfo userInfo = _userWCF.GetModelByLoginName(Context.UIContext.Current.LoginName);
            List<CommonService.Model.SysManager.C_Log> list = _LogWCF.GetListDate(new Guid(userInfo.C_Userinfo_code.ToString()));
            if (list != null)
            {
                if (list.Count() >= 2)
                {
                    ViewBag.TopLoginDate = list[1].C_Datatime;
                }
                else
                {
                    ViewBag.TopLoginDate = list[0].C_Datatime;
                }
            }
            else
            {
                ViewBag.TopLoginDate = DateTime.Now;
            }
            return View();
        }
        #region  加载主页统计图
        /// <summary>
        /// 读取我的案件读取
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CaseDetails()
        {
            ArrayList list = new ArrayList();
            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();
            //流程查询模型
            //CommonService.Model.FlowManager.P_Business_flow flowConditon = new CommonService.Model.FlowManager.P_Business_flow();
            caseConditon.B_Case_oprationtype = 1;
            //我的全部案件
            int MyCaseAll;
            MyCaseAll = _caseWCF.GetPowerRecordCount(null, caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
             UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList myall = new caseList();
            myall.value = MyCaseAll;
            myall.text = "我的全部案件";
            list.Add(myall);
            //我的在办案件
            int MyCaseIng;
            //flowConditon.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
            //if (UIContext.Current.IsPreSetManager)
            //{
            //    flowConditon.P_Business_person = null;
            //}
            //else
            //{
            //    flowConditon.P_Business_person = Context.UIContext.Current.UserCode;
            //}
            MyCaseIng = _caseWCF.GetPowerRecordCount(null, caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
            UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList mying = new caseList();
            mying.value = MyCaseIng;
            mying.text = "我的在办案件";
            list.Add(mying);
            //我的未开始
            int MyCaseDo;
            //if (UIContext.Current.IsPreSetManager)
            //{
            //    flowConditon.P_Business_person = null;
            //}
            //else
            //{
            //    flowConditon.P_Business_person = Context.UIContext.Current.UserCode;
            //}
            //flowConditon.P_Business_state = Convert.ToInt32(BusinessFlowStatus.未开始);
            MyCaseDo = _caseWCF.GetPowerRecordCount(null, caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
            UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList mydo = new caseList();
            mydo.value = MyCaseDo;
            mydo.text = "我的未开始";
            list.Add(mydo);
            //我的已结案件
            int MyCaseEnd;
            //flowConditon.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
            //if (UIContext.Current.IsPreSetManager)
            //{
            //    flowConditon.P_Business_person = null;
            //}
            //else
            //{
            //    flowConditon.P_Business_person = Context.UIContext.Current.UserCode;
            //}
            MyCaseEnd = _caseWCF.GetPowerRecordCount(null, caseConditon, UIContext.Current.IsPreSetManager,UIContext.Current.UserCode,
            UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList myend = new caseList();
            myend.value = MyCaseEnd;
            myend.text = "我的已结案件";
            list.Add(myend);
            if (UIContext.Current.IsPreSetManager)
            {
                //在办案件
                int caseIng;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                caseIng = _caseWCF.GetPowerRecordCount(null, caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                UIContext.Current.PostCode, UIContext.Current.OrgCode);
                caseList caseing = new caseList();
                caseing.value = caseIng;
                caseing.text = "在办案件";
                list.Add(caseing);
                //未开始案件
                int caseNoStar;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.未开始);
                caseNoStar = _caseWCF.GetPowerRecordCount(null, caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                UIContext.Current.PostCode, UIContext.Current.OrgCode);
                caseList caseNostart = new caseList();
                caseNostart.value = caseNoStar;
                caseNostart.text = "未开始案件";
                list.Add(caseNostart);
                //已结案件
                int caseEnd;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                caseEnd = _caseWCF.GetPowerRecordCount(null, caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                UIContext.Current.PostCode, UIContext.Current.OrgCode);
                caseList caseend = new caseList();
                caseend.value = caseEnd;
                caseend.text = "已结案件";
                list.Add(caseend);
            }
            return Json(list);
        }
        /// <summary>
        /// 读取商机的统计图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BusinessDetails()
        {
            ArrayList list = new ArrayList();
            //商机查询模型
            CommonService.Model.BusinessChanceManager.B_BusinessChance bChanceConditon = new CommonService.Model.BusinessChanceManager.B_BusinessChance();
            bChanceConditon.B_BusinessChance_oprationtype = 1;
            //全部商机
            int all;
            all = _businessChanceWCF.GetPowerRecordCount(bChanceConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
            UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList allB = new caseList();
            allB.value = all;
            allB.text = "全部商机";
            list.Add(allB);
            return Json(list);
        }
        /// <summary>
        /// 读取客户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CustermDetails()
        {
            ArrayList list = new ArrayList();
            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();
            //全部客户
            int all;
            all = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
               UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList allC = new caseList();
            allC.value = all;
            allC.text = "全部客户";
            list.Add(allC);
            //企业客户
            int R;
            customerConditon.C_Customer_type = Convert.ToInt32(CustomertypeEnum.单位);
            R = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
               UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList RC = new caseList();
            RC.value = R;
            RC.text = "企业客户";
            list.Add(RC);
            //个人客户
            int P;
            customerConditon.C_Customer_type = Convert.ToInt32(CustomertypeEnum.个体户);
            P = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
            UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList PC = new caseList();
            PC.value = P;
            PC.text = "个人客户";
            list.Add(PC);
            //近三个月联系过
            int Q;
            customerConditon.C_Customer_type = null;
            customerConditon.C_Customer_Follow_time_type = 1;
            Q = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
            UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList QC = new caseList();
            QC.value = Q;
            QC.text = "最近联系过";
            list.Add(QC);
            //三个月以前联系过
            int W;
            customerConditon.C_Customer_Follow_time_type = 2;
            W = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
            UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList WC = new caseList();
            WC.value = W;
            WC.text = "三个月前联系过";
            list.Add(WC);
            //从未联系过
            int T;
            customerConditon.C_Customer_Follow_time_type = 3;
            T = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
            UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList TC = new caseList();
            TC.value = T;
            TC.text = "从未联系过";
            list.Add(TC);
            //今日新增
            int I;
            customerConditon.C_Customer_Follow_time_type = 4;
            I = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
            UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);
            caseList IC = new caseList();
            IC.value = I;
            IC.text = "今日新增";
            list.Add(IC);
            return Json(list);
        }
        /// <summary>
        /// 我的消息统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult MsgDetails()
        {
            ArrayList list = new ArrayList();
            //消息查询模型
            CommonService.Model.C_Messages messageConditon = new CommonService.Model.C_Messages();
            messageConditon.C_Messages_isRead = 0;
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                messageConditon.C_Messages_person = Context.UIContext.Current.UserCode;
            }
            //案件消息
            int caseMsg;
            messageConditon.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
            caseMsg = _messageWCF.GetRecordCount(messageConditon);
            caseList CM = new caseList();
            CM.value = caseMsg;
            CM.text = "案件消息";
            list.Add(CM);
            //商机消息
            int BusiMsg;
            messageConditon.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
            BusiMsg = _messageWCF.GetRecordCount(messageConditon);
            caseList CB = new caseList();
            CB.value = BusiMsg;
            CB.text = "商机消息";
            list.Add(CB);
            //客户消息
            int CuMsg;
            messageConditon.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
            CuMsg = _messageWCF.GetRecordCount(messageConditon);
            caseList CC = new caseList();
            CC.value = CuMsg;
            CC.text = "客户消息";
            list.Add(CC);
            //进程消息
            int JingChengMsg;
            messageConditon.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.进程管理);
            JingChengMsg = _messageWCF.GetRecordCount(messageConditon);
            caseList CD = new caseList();
            CD.value = JingChengMsg;
            CD.text = "进程管理";
            list.Add(CD);
            //财务消息
            int CaiWuMsg;
            messageConditon.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.财务消息);
            CaiWuMsg = _messageWCF.GetRecordCount(messageConditon);
            caseList CE = new caseList();
            CE.value = CaiWuMsg;
            CE.text = "财务消息";
            list.Add(CE);

            //新增案件
            /*int smAddC;
            messageConditon.C_Messages_fType = 426;
            messageConditon.C_Messages_type = 429;
            smAddC = _messageWCF.GetRecordCount(messageConditon);
            if (smAddC != 0)
            {
                caseList a = new caseList();
                a.value = smAddC;
                a.text = "新增案件";
                list.Add(a);
            }
            //案件分配
            int smFp;
            messageConditon.C_Messages_type = 430;
            int smFpa = _messageWCF.GetRecordCount(messageConditon);
            messageConditon.C_Messages_type = 431;
            int smFpb = _messageWCF.GetRecordCount(messageConditon);
            smFp = smFpa + smFpb;
            if (smFp != 0)
            {
                caseList a = new caseList();
                a.value = smFp;
                a.text = "任务分配(案件)";
                list.Add(a);
            }
            //案件待审核
            int smandsh;
            messageConditon.C_Messages_type = 432582;
            smandsh = _messageWCF.GetRecordCount(messageConditon);
            if (smandsh != 0)
            {
                caseList a = new caseList();
                a.value = smandsh;
                a.text = "待审核(案件)";
                list.Add(a);
            }
            //案件审核通过
            int smanshtg;
            messageConditon.C_Messages_type = 433583;
            smanshtg = _messageWCF.GetRecordCount(messageConditon);
            if (smanshtg != 0)
            {
                caseList a = new caseList();
                a.value = smanshtg;
                a.text = "审核通过(案件)";
                list.Add(a);
            }
            //案件审核驳回
            int smajshbh;
            messageConditon.C_Messages_type = 434584;
            smajshbh = _messageWCF.GetRecordCount(messageConditon);
            if (smajshbh != 0)
            {
                caseList a = new caseList();
                a.value = smajshbh;
                a.text = "驳回(案件)";
                list.Add(a);
            }


            //新增商机
            int smAddB;
            messageConditon.C_Messages_fType = 427;
            messageConditon.C_Messages_type = 429;
            smAddB = _messageWCF.GetRecordCount(messageConditon);
            if (smAddB != 0)
            {
                caseList a = new caseList();
                a.value = smAddB;
                a.text = "新增商机";
                list.Add(a);
            }
            //商机分配
            int smsjFp;
            messageConditon.C_Messages_type = 430;
            int smsjFpa = _messageWCF.GetRecordCount(messageConditon);
            messageConditon.C_Messages_type = 431;
            int smsjFpb = _messageWCF.GetRecordCount(messageConditon);
            smsjFp = smsjFpa + smsjFpb;
            if (smsjFp != 0)
            {
                caseList a = new caseList();
                a.value = smsjFp;
                a.text = "任务分配(商机)";
                list.Add(a);
            }
            //商机待审核
            int smsjdsh;
            messageConditon.C_Messages_type = 432582;
            smsjdsh = _messageWCF.GetRecordCount(messageConditon);
            if (smsjdsh != 0)
            {
                caseList a = new caseList();
                a.value = smsjdsh;
                a.text = "待审核(商机)";
                list.Add(a);
            }
            //商机审核通过
            int smsjshtg;
            messageConditon.C_Messages_type = 433583;
            smsjshtg = _messageWCF.GetRecordCount(messageConditon);
            if (smsjshtg != 0)
            {
                caseList a = new caseList();
                a.value = smsjshtg;
                a.text = "审核通过(商机)";
                list.Add(a);
            }
            //商机审核驳回
            int smsjshbh;
            messageConditon.C_Messages_type = 434584;
            smsjshbh = _messageWCF.GetRecordCount(messageConditon);
            if (smsjshbh != 0)
            {
                caseList a = new caseList();
                a.value = smsjshbh;
                a.text = "驳回(商机)";
                list.Add(a);
            }*/
            return Json(list);
        }
        #endregion
        public ActionResult Top()
        {
            #region 消息处理
            CommonService.Model.C_Messages messageConditon = new CommonService.Model.C_Messages();
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                messageConditon.C_Messages_person = Context.UIContext.Current.UserCode;
            }
            messageConditon.C_Messages_isRead = 0;
            //messageConditon.C_Messages_fType = 1;//案件商机客户
            //获取消息总记录数
            this.TotalRecordCount = _messageWCF.GetAllERPMessageCount(messageConditon);

            ViewBag.MessageCount = this.TotalRecordCount;

            //获取OA消息总记录数
            //messageConditon.C_Messages_isRead = 0;
            //messageConditon.C_Messages_fType = 509580585;//日程 OA表单消息 OA邮箱消息

            List<CommonService.Model.OA.O_Email_user> EmailList = _emailUserWCF.GetNoReadListUserCode(new Guid(Context.UIContext.Current.RootUserCode.ToString()));//获取收件人未读取邮件数据
            List<CommonService.Model.OA.O_Schedule> scheduleList = _scheduleWCF.GetMsgListByUsercode(new Guid(Context.UIContext.Current.RootUserCode.ToString()));//获取未读取的日程消息
            List<CommonService.Model.OA.O_Form_AuditFlow> FAFList = _oformAuditFlowWCF.GetListStatusByuserCode(new Guid(Context.UIContext.Current.UserCode.ToString()));//获得登录人表单信息

            int OAMessageCount = EmailList.Count() + scheduleList.Count() + FAFList.Count();
            ViewBag.OAMessageCount = OAMessageCount;
            #endregion

            #region 当前登录用户关联所有岗位(内置系统管理员除外)
            //string postName = String.Empty;
            //List<CommonService.Model.SysManager.C_Userinfo> UserPosts;
            //if (UIContext.Current.IsPreSetManager)
            //{
            //    UserPosts = new List<CommonService.Model.SysManager.C_Userinfo>();
            //}
            //else
            //{
            //    UserPosts = _userinfoWCF.GetUserPostsByUser(UIContext.Current.UserCode.Value);
            //    CommonService.Model.SysManager.C_Post post = _postWCF.GetModelByPostCode(UIContext.Current.PostCode.Value);
            //    if (post != null)
            //    {
            //        postName = post.C_Post_name;
            //    }
            //}

            //ViewBag.UserPosts = UserPosts;
            //ViewBag.PostName = postName;
            #endregion

            return View();
        }
        /// <summary>
        /// 读消息数量
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ReadMessageCount()
        {
            CommonService.Model.C_Messages messageConditon = new CommonService.Model.C_Messages();
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                messageConditon.C_Messages_person = Context.UIContext.Current.UserCode;
            }
            messageConditon.C_Messages_isRead = 0;

            //获取消息总记录数
            this.TotalRecordCount = _messageWCF.GetAllERPMessageCount(messageConditon);
            return Content(this.TotalRecordCount.ToString());
        }
        /// <summary>
        /// 左侧菜单Action
        /// </summary>
        /// <returns></returns>
        public ActionResult Left()
        {
            List<CommonService.Model.SysManager.C_Menu> Menus = _menuWCF.GetMenuListByRoles(Context.UIContext.Current.UserCode.Value, Context.UIContext.Current.IsPreSetManager);
            SetSingleTopMenus(Menus);
            return View();
        }

        public ActionResult Right()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 切换岗位
        /// </summary>
        /// <param name="userCode">切换用户Guid</param>
        /// <returns></returns>
        public ActionResult SwitchUserPosts(string userCode)
        {
            //CommonService.Model.SysManager.C_Userinfo userInfo = _userinfoWCF.GetModelByUserCode(new Guid(userCode));
            //if (userInfo != null)
            //{
            //    this.SetUserAuthentication(userInfo.C_Userinfo_code.Value,
            //     userInfo.C_Userinfo_parent,
            //     userInfo.C_Userinfo_name,
            //     userInfo.C_Userinfo_loginID,
            //     userInfo.C_Userinfo_Organization,
            //     userInfo.C_Userinfo_post, userInfo.C_Userinfo_roleID,
            //     false,
            //     false,
            //     userInfo.C_Region_abbreviation
            //    );
            //}

            return RedirectToAction("Default");
        }

        #region 递归加载左侧菜单

        /// <summary>
        /// 装置顶级菜单(目前最多支持两级)
        /// author:hety
        /// date:2015-06-17
        /// description:目前左侧菜单项，不支持无限级递归加载，因为UI中的菜单html结构不支持无限树形加载操作，最多支持两级，以后如有需要再进行扩展
        /// </summary>
        /// <param name="menus"></param>
        private void SetSingleTopMenus(List<CommonService.Model.SysManager.C_Menu> menus)
        {
            string menuTreeHtml = "";
            string preTreeHtml = "";//树前缀
            string backTreeHtml = "";//树后缀
            var topMenuList = from allList in menus
                              where allList.C_Menu_parent == 0
                              orderby allList.C_Menu_order ascending
                              select allList;

            foreach (CommonService.Model.SysManager.C_Menu menu in topMenuList)
            {
                if (menu.C_Menu_type != 1)
                {
                    continue;
                }
                menuTreeHtml += "<dd>";
                menuTreeHtml += "<div class=\"title\">";
                menuTreeHtml += "<span><img src=\"" + menu.C_Menu_image + "\" /></span>" + menu.C_Menu_name;
                menuTreeHtml += "</div>";

                SetMenuRecursionTree(menu.C_Menu_id, ref menuTreeHtml, menus);
                menuTreeHtml += "</dd>";
            }
            ViewBag.MenuTreeHtml = preTreeHtml + menuTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有菜单
        /// </summary>
        /// <param name="parentId">上级菜单Id</param>
        /// <param name="organizationTreeHtml">菜单Tree Html</param>
        /// <param name="organizationList">菜单集合</param>
        private void SetMenuRecursionTree(int parentId, ref string menuTreeHtml, List<CommonService.Model.SysManager.C_Menu> meuns)
        {
            var lowMenuList = from allList in meuns
                              where allList.C_Menu_parent == parentId
                              orderby allList.C_Menu_order ascending
                              select allList;
            if (lowMenuList.Count() != 0)
            {
                menuTreeHtml += "<ul class=\"menuson\">";
            }

            foreach (CommonService.Model.SysManager.C_Menu lowMenu in lowMenuList)
            {
                if (lowMenu.C_Menu_type == 2)
                    continue;
                else if (lowMenu.C_Menu_type == 4)
                    continue;
                if (lowMenu.C_Menu_id == 29)
                {//默认打开主控制台
                    menuTreeHtml += "<li class=\"active\"><cite></cite><a href=\"" + lowMenu.C_Menu_url + "\" target=\"rightFrame\">" + lowMenu.C_Menu_name + "</a><i></i></li>";
                }
                else
                {
                    menuTreeHtml += "<li><cite></cite><a href=\"" + lowMenu.C_Menu_url + "\" target=\"rightFrame\">" + lowMenu.C_Menu_name + "</a><i></i></li>";
                }
                //SetMenuRecursionTree(lowMenu.C_Menu_id, ref menuTreeHtml, meuns);
                menuTreeHtml += "</li>";
            }
            if (lowMenuList.Count() != 0)
            {
                menuTreeHtml += "</ul>";
            }
        }



        #endregion

        #region OA

        public ActionResult OADefault()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }

            ViewBag.userEmailCode = Context.UIContext.Current.RootUserCode;
            ViewBag.userCode = Context.UIContext.Current.UserCode;

            #region 处理ERP->OA导航参数(这里用加密密钥进行处理，目的为防止恶意窜写)
            string id = String.Empty;//唯一标识
            string nav = String.Empty;//导航标识
            string key = String.Empty;//加密key
            string isNav = "0";//是否跳转到其它页
            if (Request["key"] != null)
            {
                id = Request["id"];
                nav = Request["nav"];
                key = Request["key"];
                string originalStr = id + nav + Encryption.GetSecretKey();
                string encrytionStr = Encryption.GetMd5(originalStr);
                if (key == encrytionStr)
                {
                    isNav = "1";
                }
            }
            ViewBag.Id = id;
            ViewBag.Nav = nav;
            ViewBag.IsNav = isNav;
            #endregion

            return View();
        }
        /// <summary>
        /// OA头部信息
        /// </summary>
        /// <returns></returns>
        public PartialViewResult OAHeader()
        {
            List<CommonService.Model.OA.O_Email_user> EmailList = _emailUserWCF.GetNoReadListUserCode(new Guid(Context.UIContext.Current.RootUserCode.ToString()));//获取收件人未读取邮件数据
            ViewBag.emailCount = EmailList.Count();//未读取邮件总数
            ViewBag.emailList = EmailList;//未读取邮件数据集
            List<CommonService.Model.OA.O_Schedule> scheduleList = _scheduleWCF.GetMsgListByUsercode(new Guid(Context.UIContext.Current.RootUserCode.ToString()));//获取未读取的日程消息
            ViewBag.scheduleList = scheduleList;
            ViewBag.scheduleCount = scheduleList.Count();
            List<CommonService.Model.OA.O_Form_AuditFlow> FAFList = _oformAuditFlowWCF.GetListStatusByuserCode(new Guid(Context.UIContext.Current.UserCode.ToString()));//获得登录人表单信息
            ViewBag.formNoAuditList = FAFList;
            //需审核的表单和审核通过或者驳回的表单总和
            ViewBag.formNoAuditListCount = FAFList.Count();//只是未审核的消息总和
            return PartialView("_OAHeaderPartial");
        }

        public PartialViewResult OASidebar()
        {
            List<CommonService.Model.SysManager.C_Menu> Menus = _menuWCF.GetMenuListByRoles(Context.UIContext.Current.UserCode.Value, Context.UIContext.Current.IsPreSetManager);
            SetSingleTopOAMenus(Menus);
            return PartialView("_OASidebarPartial");
        }

        public PartialViewResult OAThemePanel()
        {
            return PartialView("_OAThemePanelPartial");
        }

        public PartialViewResult OAQuickSidebar()
        {
            return PartialView("_OAQuickSidebarPartial");
        }

        public PartialViewResult OAFooter()
        {
            return PartialView("_OAFooterPartial");
        }
        /// <summary>
        /// 装置OA顶级菜单(目前最多支持两级)
        /// author:cyj
        /// date:2015-08-20
        /// description:目前左侧菜单项，不支持无限级递归加载，因为UI中的菜单html结构不支持无限树形加载操作，最多支持两级，以后如有需要再进行扩展
        /// </summary>
        /// <param name="menus"></param>
        private void SetSingleTopOAMenus(List<CommonService.Model.SysManager.C_Menu> menus)
        {
            string menuTreeHtml = "";
            string preTreeHtml = "";//树前缀
            string backTreeHtml = "";//树后缀
            var topMenuList = from allList in menus
                              where allList.C_Menu_parent == 1036  //1036    OA的所有菜单的主菜单
                              orderby allList.C_Menu_order ascending
                              select allList;

            foreach (CommonService.Model.SysManager.C_Menu menu in topMenuList)
            {
                if (menu.C_Menu_type != 2) //OA类型
                {
                    continue;
                }
                if (menu.C_Menu_order == 1)//主页    第一菜单
                {
                    menuTreeHtml += "<li class=\"start\">";
                    menuTreeHtml += "<a class=\"ajaxify start\" href=\"" + menu.C_Menu_url + "\">";
                    menuTreeHtml += "<i class=\"" + menu.C_Menu_image + "\"></i>";
                    menuTreeHtml += "<span class=\"title\">" + menu.C_Menu_name + "</span>";
                    menuTreeHtml += "<span class=\"selected\"></span>";
                    menuTreeHtml += "</a>";
                }
                else if (menu.C_Menu_order == topMenuList.Count())//最后一个   菜单
                {
                    menuTreeHtml += "<li class=\"last\">";
                    menuTreeHtml += "<a href=\"javascript:;\">";
                    menuTreeHtml += "<i class=\"" + menu.C_Menu_image + "\"></i>";
                    menuTreeHtml += "<span class=\"title\">" + menu.C_Menu_name + "</span>";
                    menuTreeHtml += "<span class=\"arrow\"></span>";
                    menuTreeHtml += "</a>";

                }
                else//中间菜单
                {
                    if (menu.C_Menu_name == "办公协同")
                    {
                        menuTreeHtml += "<li class=\"open\">";
                    }
                    else
                    {
                        menuTreeHtml += "<li>";
                    }

                    menuTreeHtml += "<a href=\"javascript:;\">";
                    menuTreeHtml += "<i class=\"" + menu.C_Menu_image + "\"></i>";
                    menuTreeHtml += "<span class=\"title\">" + menu.C_Menu_name + "</span>";
                    menuTreeHtml += "<span class=\"arrow\"></span>";
                    menuTreeHtml += "</a>";
                }
                SetMenuRecursionOATree(menu.C_Menu_id, ref menuTreeHtml, menus, menu.C_Menu_name);
                menuTreeHtml += "</li>";
            }
            ViewBag.MenuTreeHtml = preTreeHtml + menuTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有菜单
        /// </summary>
        /// <param name="parentId">上级菜单Id</param>
        /// <param name="organizationTreeHtml">菜单Tree Html</param>
        /// <param name="organizationList">菜单集合</param>
        private void SetMenuRecursionOATree(int parentId, ref string menuTreeHtml, List<CommonService.Model.SysManager.C_Menu> meuns, string menuname)
        {
            var lowMenuList = from allList in meuns
                              where allList.C_Menu_parent == parentId
                              orderby allList.C_Menu_order ascending
                              select allList;
            if (lowMenuList.Count() != 0)
            {
                menuTreeHtml += "<ul class=\"sub-menu\">";
            }

            foreach (CommonService.Model.SysManager.C_Menu lowMenu in lowMenuList)
            {
                if (lowMenu.C_Menu_type == 1)
                    continue;
                menuTreeHtml += "<li><a class=\"ajaxify \" href=\"" + lowMenu.C_Menu_url + "\"  Navigation=\" > " + menuname + " > " + lowMenu.C_Menu_name + "\">" + lowMenu.C_Menu_name + "</a>";
                //SetMenuRecursionTree(lowMenu.C_Menu_id, ref menuTreeHtml, meuns);
                menuTreeHtml += "</li>";
            }
            if (lowMenuList.Count() != 0)
            {
                menuTreeHtml += "</ul>";
            }
        }
        #endregion

        #region 知识管理系统
        /// <summary>
        /// kms首页
        /// </summary>
        /// <returns></returns>
        public ActionResult KMSDefault()
        {
            //最热文档
            List<CommonService.Model.KMS.K_Resources> listZm = _resourcesWCF.GetListByzambiaCount(4, "putoff/案件管理", 1);//获得前4条 去掉案件管理的数据  固定格式为putoff/+知识分类
            ViewBag.listZm = listZm;
            List<CommonService.Model.KMS.K_Resources> listCase = _resourcesWCF.GetListByzambiaCount(4, "案件管理", 1);//获得案件管理前4条
            ViewBag.listCase = listCase;

            ViewBag.userCode = Context.UIContext.Current.RootUserCode;

            return View();
        }
        public PartialViewResult KMSHeader()
        {
            //资源评论消息
            List<CommonService.Model.KMS.K_Comments> resourcesComments = _commentsWCF.GetUnreadList(Context.UIContext.Current.RootUserCode.Value, Convert.ToInt32(CommentsTypeEunm.资源评论));
            foreach (CommonService.Model.KMS.K_Comments comment in resourcesComments)
            {
                string content = FilterHtml.StripHTML(comment.K_Comments_content);//过滤html标签
                comment.K_Comments_content = content.Length > 10 ? content.Substring(0, 10) : content;
            }
            ViewBag.resourcesComments = resourcesComments;
            ViewBag.resourcesCommentCount = resourcesComments.Count();
            //问吧回答消息
            List<CommonService.Model.KMS.K_Comments> problemComments = _commentsWCF.GetUnreadList(Context.UIContext.Current.RootUserCode.Value, Convert.ToInt32(CommentsTypeEunm.问吧回答));
            foreach (CommonService.Model.KMS.K_Comments comment in problemComments)
            {
                string content = FilterHtml.StripHTML(comment.K_Comments_content);//过滤html标签
                comment.K_Comments_content = content.Length > 10 ? content.Substring(0, 10) : content;
            }
            ViewBag.problemComments = problemComments;
            ViewBag.problemCommentCount = problemComments.Count();
            return PartialView("_KMSHeaderPartial");
        }

        public PartialViewResult KMSSidebar()
        {
            List<CommonService.Model.SysManager.C_Menu> Menus = _menuWCF.GetMenuListByRoles(Context.UIContext.Current.UserCode.Value, Context.UIContext.Current.IsPreSetManager);
            SetSingleTopKmsMenus(Menus);
            return PartialView("_KMSSidebarPartial");
        }
        public PartialViewResult KMSThemePanel()
        {
            return PartialView("_KMSThemePanelPartial");
        }
        public PartialViewResult KMSQuickSidebar()
        {
            return PartialView("_KMSQuickSidebarPartial");
        }
        public PartialViewResult KMSFooter()
        {
            return PartialView("_KMSFooterPartial");
        }

        /// <summary>
        /// 登陆日志的插入
        /// </summary>
        public void SaveKmsLog()
        {
            CommonService.Model.KMS.K_Kms_Log kmslog = new CommonService.Model.KMS.K_Kms_Log();
            kmslog.K_Kms_Log_usercode = Context.UIContext.Current.RootUserCode.Value;//登录主账户code
            kmslog.K_Kms_Log_datetime = DateTime.Now;//登录时间
            kmslog.K_Kms_Log_ip = Request.UserHostAddress;  //取得本机IP
            kmslog.K_Kms_Log_type = "系统登录";
            _Kms_LogWCF.Add(kmslog);

            #region 登陆日志的插入-----与北斗云同一个表
            CommonService.Model.SysManager.C_Userinfo userInfo = _userWCF.GetDefaultChildUserByParentCode(Context.UIContext.Current.RootUserCode.Value);//获取子用户
            CommonService.Model.SysManager.C_Log clogmodel = new CommonService.Model.SysManager.C_Log();
            if (userInfo != null)
            {
                clogmodel.C_Userinfo_name = userInfo.C_Userinfo_name;
                clogmodel.C_Userinfo_post = userInfo.C_Userinfo_post.ToString();
            }
            else
            {
                clogmodel.C_Userinfo_name = Context.UIContext.Current.UserName.ToString();
            }
            clogmodel.C_Userinfo_code = Context.UIContext.Current.RootUserCode.Value;//登录主账户code
            clogmodel.C_Log_code = Guid.NewGuid();
            clogmodel.C_Datatime = DateTime.Now;
            clogmodel.C_Log_Type = Convert.ToInt32(LoginTypeEnum.云学堂);

            clogmodel.C_Log_ip = Request.UserHostAddress;  //取得本机IP
            clogmodel.C_Operate = "登陆成功";
            _LogWCF.Add(clogmodel);
            #endregion
        }

        #region 递归加载知识库菜单

        /// <summary>
        /// 装置顶级菜单(目前最多支持两级)
        /// author:崔慧栋
        /// date:2015-11-9
        /// </summary>
        /// <param name="menus"></param>
        private void SetSingleTopKmsMenus(List<CommonService.Model.SysManager.C_Menu> menus)
        {
            string menuTreeHtml = "";
            string preTreeHtml = "";//树前缀
            string backTreeHtml = "";//树后缀
            var topMenuList = from allList in menus
                              where allList.C_Menu_parent == 1128
                              orderby allList.C_Menu_order ascending
                              select allList;

            foreach (CommonService.Model.SysManager.C_Menu menu in topMenuList)
            {
                if (menu.C_Menu_type == 4)
                {
                    var menuChild = menus.Where(m => m.C_Menu_parent == menu.C_Menu_id).FirstOrDefault();
                    if (menuChild == null)
                    {
                        menuTreeHtml += "<li id=\"" + menu.C_Menu_id + "s\" class=\"\">";
                        menuTreeHtml += "<a id=\"" + menu.C_Menu_id + "\" href=\"" + menu.C_Menu_url + "\">" + menu.C_Menu_name + "</a>";
                        //menuTreeHtml += "<span><img src=\"" + menu.C_Menu_image + "\" /></span>" + menu.C_Menu_name;
                        menuTreeHtml += "</li>";
                    }
                    else
                    {
                        menuTreeHtml += "<li id=\"" + menu.C_Menu_id + "s\" class=\"menu-dropdown classic-menu-dropdown\">";
                        menuTreeHtml += "<a data-hover=\"megamenu-dropdown\" data-close-others=\"true\" data-toggle=\"dropdown\" href=\"javascript:;\">" + menu.C_Menu_name + "<i class=\"fa fa-angle-down\"></i></a>";
                        //menuTreeHtml += "<span><img src=\"" + menu.C_Menu_image + "\" /></span>" + menu.C_Menu_name;

                        SetMenuRecursionKmsTree(menu.C_Menu_id, ref menuTreeHtml, menus);
                        menuTreeHtml += "</li>";
                    }

                }
            }
            ViewBag.MenuTreeHtml = preTreeHtml + menuTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有菜单
        /// </summary>
        /// <param name="parentId">上级菜单Id</param>
        /// <param name="organizationTreeHtml">菜单Tree Html</param>
        /// <param name="organizationList">菜单集合</param>
        private void SetMenuRecursionKmsTree(int parentId, ref string menuTreeHtml, List<CommonService.Model.SysManager.C_Menu> meuns)
        {
            var lowMenuList = from allList in meuns
                              where allList.C_Menu_parent == parentId
                              orderby allList.C_Menu_order ascending
                              select allList;

            if (lowMenuList.Count() != 0)
            {
                menuTreeHtml += "<ul id=\"" + parentId + "\" class=\"dropdown-menu pull-left\">";
            }

            foreach (CommonService.Model.SysManager.C_Menu lowMenu in lowMenuList)
            {
                if (lowMenu.C_Menu_type == 4)
                {
                    menuTreeHtml += "<li id=\"" + lowMenu.C_Menu_id + "s\" class=\"\"><a id=\"" + lowMenu.C_Menu_id + "\" href=\"" + lowMenu.C_Menu_url + "\"><i class=\"icon-briefcase\"></i>" + lowMenu.C_Menu_name + "</a></li>";
                }
            }
            if (lowMenuList.Count() != 0)
            {
                menuTreeHtml += "</ul>";
            }
        }

        #endregion

        #endregion

        #region 报表信息

        public ActionResult ReportingDefault()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }

            ViewBag.userEmailCode = Context.UIContext.Current.RootUserCode;
            ViewBag.userCode = Context.UIContext.Current.UserCode;

            #region 处理ERP->OA导航参数(这里用加密密钥进行处理，目的为防止恶意窜写)
            string id = String.Empty;//唯一标识
            string nav = String.Empty;//导航标识
            string key = String.Empty;//加密key
            string isNav = "0";//是否跳转到其它页
            if (Request["key"] != null)
            {
                id = Request["id"];
                nav = Request["nav"];
                key = Request["key"];
                string originalStr = id + nav + Encryption.GetSecretKey();
                string encrytionStr = Encryption.GetMd5(originalStr);
                if (key == encrytionStr)
                {
                    isNav = "1";
                }
            }
            ViewBag.Id = id;
            ViewBag.Nav = nav;
            ViewBag.IsNav = isNav;
            #endregion

            return View();
        }



        /// <summary>
        /// OA头部信息
        /// </summary>
        /// <returns></returns>
        public PartialViewResult ReportingHeader()
        {

            return PartialView("_ReportingHeaderPartial");
        }

        public PartialViewResult ReportingSidebar()
        {
            List<CommonService.Model.SysManager.C_Menu> Menus = _menuWCF.GetMenuListByRoles(Context.UIContext.Current.UserCode.Value, Context.UIContext.Current.IsPreSetManager);
            SetSingleTopReportingMenus(Menus);
            return PartialView("_ReportingSidebarPartial");
        }


        /// <summary>
        /// 装置报表顶级菜单(目前最多支持两级)
        /// author:ylw
        /// date:2015-10-13
        /// description:目前左侧菜单项，不支持无限级递归加载，因为UI中的菜单html结构不支持无限树形加载操作，最多支持两级，以后如有需要再进行扩展
        /// </summary>
        /// <param name="menus"></param>
        private void SetSingleTopReportingMenus(List<CommonService.Model.SysManager.C_Menu> menus)
        {
            string menuTreeHtml = "";
            string preTreeHtml = "";//树前缀
            string backTreeHtml = "";//树后缀
            var topMenuList = from allList in menus
                              where allList.C_Menu_parent == 1087     //   报表的所有菜单的主菜单
                              orderby allList.C_Menu_order ascending
                              select allList;

            foreach (CommonService.Model.SysManager.C_Menu menu in topMenuList)
            {
                if (menu.C_Menu_type != 3) //报表类型
                {
                    continue;
                }
                if (menu.C_Menu_order == 1)//主页    第一菜单
                {
                    menuTreeHtml += "<li>";
                    menuTreeHtml += "<a class=\"ajaxify start\" href=\"" + menu.C_Menu_url + "\">";
                    menuTreeHtml += "<i class=\"" + menu.C_Menu_image + "\"></i>";
                    menuTreeHtml += "<span class=\"title\">" + menu.C_Menu_name + "</span>";
                    menuTreeHtml += "<span class=\"selected\"></span>";
                    menuTreeHtml += "</a>";
                }
                else if (menu.C_Menu_order == topMenuList.Count())//最后一个   菜单
                {
                    menuTreeHtml += "<li class=\"last\">";
                    menuTreeHtml += "<a href=\"javascript:;\">";
                    menuTreeHtml += "<i class=\"" + menu.C_Menu_image + "\"></i>";
                    menuTreeHtml += "<span class=\"title\">" + menu.C_Menu_name + "</span>";
                    menuTreeHtml += "<span class=\"arrow\"></span>";
                    menuTreeHtml += "</a>";

                }
                else//中间菜单
                {
                    if (menu.C_Menu_name == "办公协同")
                    {
                        menuTreeHtml += "<li class=\"open\">";
                    }
                    else
                    {
                        menuTreeHtml += "<li>";
                    }

                    menuTreeHtml += "<a href=\"javascript:;\">";
                    menuTreeHtml += "<i class=\"" + menu.C_Menu_image + "\"></i>";
                    menuTreeHtml += "<span class=\"title\">" + menu.C_Menu_name + "</span>";
                    menuTreeHtml += "<span class=\"arrow\"></span>";
                    menuTreeHtml += "</a>";
                }
                SetMenuRecursionReportingTree(menu.C_Menu_id, ref menuTreeHtml, menus, menu.C_Menu_name);
                menuTreeHtml += "</li>";
            }
            ViewBag.MenuTreeHtml = preTreeHtml + menuTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有菜单
        /// </summary>
        /// <param name="parentId">上级菜单Id</param>
        /// <param name="organizationTreeHtml">菜单Tree Html</param>
        /// <param name="organizationList">菜单集合</param>
        private void SetMenuRecursionReportingTree(int parentId, ref string menuTreeHtml, List<CommonService.Model.SysManager.C_Menu> meuns, string menuname)
        {
            var lowMenuList = from allList in meuns
                              where allList.C_Menu_parent == parentId && allList.C_Menu_isDelete == false
                              orderby allList.C_Menu_order ascending
                              select allList;
            if (lowMenuList.Count() != 0)
            {
                menuTreeHtml += "<ul class=\"sub-menu\">";
            }
            int childrenCount = 0;
            foreach (CommonService.Model.SysManager.C_Menu lowMenu in lowMenuList)
            {
                if (lowMenu.C_Menu_type == 1)
                    continue;
                childrenCount++;
                if (childrenCount == 1)
                {
                    menuTreeHtml += "<li><a class=\"ajaxify\" href=\"" + lowMenu.C_Menu_url + "\"  Navigation=\" > " + menuname + " > " + lowMenu.C_Menu_name + "\">" + lowMenu.C_Menu_name + "</a>";
                }
                else
                {
                    menuTreeHtml += "<li><a class=\"ajaxify\" href=\"" + lowMenu.C_Menu_url + "\"  Navigation=\" > " + menuname + " > " + lowMenu.C_Menu_name + "\">" + lowMenu.C_Menu_name + "</a>";
                }

                //SetMenuRecursionTree(lowMenu.C_Menu_id, ref menuTreeHtml, meuns);
                menuTreeHtml += "</li>";
            }
            if (lowMenuList.Count() != 0)
            {
                menuTreeHtml += "</ul>";
            }
        }

        public PartialViewResult ReportingThemePanel()
        {
            return PartialView("_ReportingThemePanelPartial");
        }

        public PartialViewResult ReportingQuickSidebar()
        {
            return PartialView("_ReportingQuickSidebarPartial");
        }
        public PartialViewResult ReportingFooter()
        {
            return PartialView("_ReportingFooterPartial");
        }


        #endregion
    }
}