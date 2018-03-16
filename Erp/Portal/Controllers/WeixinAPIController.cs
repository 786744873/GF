using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class WeixinAPIController : Controller
    {
        private readonly ICommonService.SysManager.IC_Userinfo _userWCF;
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        string WeixinAPIAuthorCode = ConfigurationManager.AppSettings["WeixinAPIAuthorCode"].ToString();



        public WeixinAPIController()
        {
            #region 服务初始化
            _userWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            #endregion
        }

        //
        // GET: /WeixinAPI/
        public ActionResult Index()
        {
            return Content("微信接口对接类");
        }
        public JsonResult Emp_Service(string AuthorCode)
        {

            var res = new JsonResult();
            if (AuthorCode != WeixinAPIAuthorCode)
            {
                res.Data = "无权访问！";
                res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
                return res;
            }
            List<B_EmpTemp> Outlist = new List<B_EmpTemp>();
            var bhmessage = _userWCF.GetModelList("  C_Userinfo_roleID=10 or C_Userinfo_roleID=8 ");




            foreach (var model in bhmessage)
            {

                if (model != null)
                {
                    B_EmpTemp item3 = new B_EmpTemp();
                    item3.per_sn = model.C_Userinfo_code.ToString();
                    item3.per_fid = model.C_Userinfo_Organization_name;
                    item3.per_name = model.C_Userinfo_name;
                    item3.per_sex = "男";
                    item3.per_phone = "18501070603";
                    item3.per_head = "无";
                    item3.per_mail = "";
                    item3.per_job = model.C_Userinfo_post_name;
                    item3.per_body = "";
                    item3.per_pass = model.C_Userinfo_isDelete == true ? 1 : 0;
                    if (Outlist.Count(p => p.per_sn == model.C_Userinfo_code.ToString()) <= 0)
                        Outlist.Add(item3);



                    //根据用户获取专业顾问对应的客户
                    var cuslist = _customerWCF.GetListByPageAll(" C_Customer_consultant='" + model.C_Userinfo_code + "'", "", 1, 1000);

                    foreach (var item4 in cuslist)
                    {
                        item3.per_customers = item3.per_customers + item4.C_Customer_code + ",";
                    }
                    if (item3.per_customers != null && item3.per_customers != "")
                        item3.per_customers = item3.per_customers.Substring(0, item3.per_customers.Length - 1);
                }
            }
            res.Data = Outlist;//返回列表
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
            return res;

        }



        public JsonResult Customer_Service(string AuthorCode)
        {

            var res = new JsonResult();
            if (AuthorCode != WeixinAPIAuthorCode)
            {
                res.Data = "无权访问！";
                res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
                return res;
            }

            List<B_CustomerTemp> Outlist = new List<B_CustomerTemp>();
            var bhmessage = _customerWCF.GetListByPageAll("","",1,10000);
            foreach (var item in bhmessage)
            {

                B_CustomerTemp item3 = new B_CustomerTemp();
                item3.mem_fid = "";
                item3.mem_no = item.C_Customer_code.ToString();
                item3.mem_name = item.C_Customer_name;
                item3.mem_sex = "";
                item3.mem_birthday = "";
                item3.mem_img = "";
                item3.mem_mp = item.C_Customer_phone;
                item3.mem_wx_nc = "";
                item3.mem_mail = item.C_Customer_email;
                Outlist.Add(item3);

            }
            res.Data = Outlist;//返回列表
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
            return res;



        }



        public JsonResult Flow_Service(string AuthorCode, string FCaseCode)
        {
            var res = new JsonResult();
            if (AuthorCode != WeixinAPIAuthorCode)
            {
                res.Data = "无权访问！";
                res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
                return res;
            }
            List<B_CaseFlowTemp> Outlist = new List<B_CaseFlowTemp>();
            var list = _bussinessFlowWCF.GetListByCaseNumber(FCaseCode);
            foreach (var item in list)
            {
                B_CaseFlowTemp model = new B_CaseFlowTemp();
                model.case_id = item.P_Business_flow_id;
                model.part_title = item.P_Business_flow_name;


                switch (item.P_Business_state)
                {
                    case 200:
                        model.part_pass = "进行中";
                        break;
                    case 199:
                        model.part_pass = "未完成";
                        break;
                    case 201:
                        model.part_pass = "已完成";
                        break;

                }
                model.part_startdate = item.P_Business_flow_factStartTime.ToString();
                model.part_enddate = item.P_Business_flow_factEndTime.ToString();
                model.part_person = item.P_Business_person.ToString();
                model.part_body = item.P_Business_remark;

                Outlist.Add(model);
            }

            res.Data = Outlist;//返回列表
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
            return res;

        }


        public JsonResult Case_Service(string AuthorCode)
        {
            var res = new JsonResult();
            if (AuthorCode != WeixinAPIAuthorCode)
            {
                res.Data = "无权访问！";
                res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
                return res;
            }
            List<B_CasePieceTemp> Outlist = new List<B_CasePieceTemp>();
            var list = _caseWCF.GetModelList("");
            foreach (var item in list)
            {
                B_CasePieceTemp model = new B_CasePieceTemp();
                model.case_fid = Convert.ToInt32(item.B_Case_id);
                model.case_bz = item.B_Case_number.ToString();
                model.case_title = item.B_Case_name;

                //找到客户
                model.case_cusname = _caseWCF.GetModel(item.B_Case_code.Value).C_Customer_name;
                model.case_cusid = _caseWCF.GetModel(item.B_Case_code.Value).C_Customer_code;

                model.case_lawyer = item.B_Case_name;
                model.case_ftitle = "";
                model.case_body = item.B_Case_remark;


                switch (item.B_Case_state)
                {
                    case 199:
                        model.case_state = "未开始";
                        break;
                    case 200:
                        model.case_state = "正在进行";
                        break;
                    case 201:
                        model.case_state = "已经完成";
                        break;
                }


                Outlist.Add(model);
            }

            res.Data = Outlist;//返回列表
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
            return res;

        }

    }




    #region 基础类
    public class B_EmpTemp
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public string per_sn { get; set; }
        /// <summary>
        /// 所在部门
        /// </summary>
        public string per_fid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string per_name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string per_sex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string per_phone { get; set; }
        /// <summary>
        /// 头像图片路径
        /// </summary>
        public string per_head { get; set; }
        /// <summary>
        ///电子邮件
        /// </summary>
        public string per_mail { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string per_job { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string per_body { get; set; }
        /// <summary>
        /// 状态：正常、禁用
        /// </summary>
        public int per_pass { get; set; }

        /// <summary>
        /// 服务客户
        /// </summary>
        public string per_customers { get; set; }


    }


    /// <summary>
    /// a)	客户数据接口类
    /// </summary>
    public class B_CustomerTemp
    {
        /// <summary>
        /// 客户分组
        /// </summary>
        public string mem_fid { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string mem_no { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string mem_name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string mem_sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string mem_birthday { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string mem_img { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string mem_mp { get; set; }
        /// <summary>
        /// 微信昵称，用于自动绑定
        /// </summary>
        public string mem_wx_nc { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string mem_mail { get; set; }
    }

    /// <summary>
    /// 流程
    /// </summary>
    public class B_CaseFlowTemp
    {
        public int case_id { get; set; }

        public string part_title { get; set; }


        public string part_pass { get; set; }


        public string part_startdate { get; set; }

        public string part_enddate { get; set; }


        public string part_person { get; set; }

        public string part_body { get; set; }
    }


    /// <summary>
    /// 案件
    /// </summary>
    public class B_CasePieceTemp
    {
        public int case_fid { get; set; }
        public string case_bz { get; set; }


        public string case_title { get; set; }

        public string case_cusid { get; set; }
        public string case_cusname { get; set; }
        public string case_lawyer { get; set; }
        public string case_ftitle { get; set; }

        public string case_body { get; set; }
        public string case_state { get; set; }

    }

    #endregion
}