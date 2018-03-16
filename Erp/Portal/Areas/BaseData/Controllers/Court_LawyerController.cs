using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 法院律师关联控制器
    /// </summary>
    public class Court_LawyerController : BaseController
    {
        private readonly ICommonService.IC_Court_Lawyer _court_LawyerWCF;
        private readonly ICommonService.IC_Court _courtWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        public Court_LawyerController()
        {
            #region 服务初始化
            _court_LawyerWCF = ServiceProxyFactory.Create<ICommonService.IC_Court_Lawyer>("Court_LawyerWCF");
            _courtWCF = ServiceProxyFactory.Create<ICommonService.IC_Court>("CourtWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }
        //
        // GET: /BaseData/Court_Lawyer/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.Customer.V_Lawyer Conditon = new CommonService.Model.Customer.V_Lawyer();

            if (!String.IsNullOrEmpty(form["C_Userinfo_name"]))
            {
                Conditon.C_Userinfo_name = form["C_Userinfo_name"];
            }
            else
            {
                Conditon.C_Userinfo_name = "";
            }

            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion

            this.PageSize = 15;
            //获取总记录数
            this.TotalRecordCount = _court_LawyerWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.Customer.V_Lawyer> Court_Lawyer = _court_LawyerWCF.GetListByPage(Conditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(Court_Lawyer);
        }

        /// <summary>
        /// 分配法院
        /// </summary>
        /// <param name="userinfoCode"></param>
        /// <returns></returns>
        public ActionResult AllocateCourt(string userinfoCode, FormCollection form)
        {
            string _userinfoCode = String.Empty;
            string _userRegioncode = String.Empty;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();

            if (String.IsNullOrEmpty(form["userinfoCode"]))
            {
                _userinfoCode = userinfoCode;
            }
            else
            {
                _userinfoCode = form["userinfoCode"];
            }

            if (!String.IsNullOrEmpty(form["C_Region_code"]))
            {
                _userRegioncode = form["C_Region_code"];
            }

            ViewBag.RegionList = regionList;
            ViewBag.userinfoCode = _userinfoCode;

            if (userinfoCode != null)
            {
                if (!String.IsNullOrEmpty(_userRegioncode))
                {
                    ViewBag.UserRegioncode = _userRegioncode;
                }
                else
                {
                    #region 根据用户code获得此用户对应的区域code
                    Guid UserRegioncode2 = _regionWCF.GetRegionCodeByUsercode(new Guid(userinfoCode));
                    ViewBag.UserRegioncode = UserRegioncode2.ToString();
                    #endregion
                }
            }

            return View();
        }

        /// <summary>
        /// 已分配法院
        /// </summary>
        /// <param name="userinfoCode"></param>
        /// <returns></returns>
        public ActionResult AllocatedCourt(string userinfoCode)
        {
            List<CommonService.Model.C_Court> courts = _courtWCF.GetAllListByLawyer(new Guid(userinfoCode));
            return View(courts);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(string lawyerCode, string courtCodes)
        {
            bool isSuccess = false;

            string[] courtCodeStr = courtCodes.Split(',');
            if (courtCodes != "")
            {
                List<CommonService.Model.C_Court_Lawyer> courtLawyerList = new List<CommonService.Model.C_Court_Lawyer>();
                foreach (var courtCode in courtCodeStr)
                {
                    CommonService.Model.C_Court_Lawyer courtLawyer = new CommonService.Model.C_Court_Lawyer();
                    courtLawyer.C_Court_Lawyer_code = Guid.NewGuid();
                    courtLawyer.C_Lawyer = new Guid(lawyerCode);
                    courtLawyer.C_Court = new Guid(courtCode);
                    courtLawyer.C_Court_Lawyer_isDelete = false;
                    courtLawyer.C_Court_Lawyer_creator = Context.UIContext.Current.UserCode;
                    courtLawyer.C_Court_Lawyer_creatTime = DateTime.Now;

                    courtLawyerList.Add(courtLawyer);
                }

                _court_LawyerWCF.OperateList(courtLawyerList);

                isSuccess = true;
            }

            if (isSuccess)
            {
                //保存成功
                return Json(TipHelper.JsonData("保存信息成功", "iframe_allCourtList,iframe_allocatedCourtList", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string lawyerCode, string courtCodes)
        {
            bool isSuccess = _court_LawyerWCF.Delete(new Guid(lawyerCode), new Guid(courtCodes));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除信息成功！", "iframe_allocatedCourtList", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult CourtRelationLawyer(FormCollection form, string courtCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //用户查询模型
            CommonService.Model.SysManager.C_Userinfo userConditon = new CommonService.Model.SysManager.C_Userinfo();

            if (!String.IsNullOrEmpty(form["C_Userinfo_name"]))
            {//用户名称查询条件
                userConditon.C_Userinfo_name = form["C_Userinfo_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Userinfo_relationCode"]))
            {//用户Guid
                userConditon.C_Userinfo_relationCode = new Guid(form["C_Userinfo_relationCode"]);
            }
            if (courtCode != null)
            {
                userConditon.C_Userinfo_relationCode = new Guid(courtCode);
            }
            userConditon.C_Userinfo_relationType = 2;

            this.AddressUrlParameters = "?courtCode=" + courtCode;

            //用户查询模型传递到前端视图中
            ViewBag.UserConditon = userConditon;

            #endregion

            //获取用户总记录数
            this.TotalRecordCount = _userinfoWCF.GetRecordCount(userConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取用户数据信息
            List<CommonService.Model.SysManager.C_Userinfo> userinfos = _userinfoWCF.GetListByPage(userConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(userinfos);
        }
    }
}