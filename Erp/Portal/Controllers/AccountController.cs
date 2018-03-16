using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Maticsoft.Common;
using CommonService.Common;
using Microsoft.Owin;
using System.Web.UI;
using System.Net;
using System.Web.Routing;

namespace Portal.Controllers
{
    /// <summary>
    /// 账号控制器
    /// </summary>
    public class AccountController : UserAuthenticationController
    {
        private readonly ICommonService.SysManager.IC_Userinfo _userWCF;
        private readonly ICommonService.SysManager.IC_Log _LogWCF;
        private readonly ICommonService.KMS.IK_Kms_Log _Kms_LogWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user_role _org_post_user_roleWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user _orgUserPostWCF;

        public AccountController()
        {
            #region 服务初始化
            _userWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _LogWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Log>("LogWCF");
            _Kms_LogWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Kms_Log>("K_Kms_LogWCF");
            _org_post_user_roleWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user_role>("C_Organization_post_user_roleWCF");
            _orgUserPostWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user>("OrgPostUserWCF");
            #endregion
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult SignIn()
        {
            HttpCookie cookies = Request.Cookies["Porschev"];
            ViewBag.user = String.Empty;
            ViewBag.pass = String.Empty;
            ViewBag.isRember = String.Empty; //记住密码
            if (cookies != null)
            {
                if (cookies["user"] != null)
                {
                    ViewBag.user = Server.UrlDecode(cookies["user"]);
                }
                if (cookies["pass"] != null)
                {
                    ViewBag.pass = Server.UrlDecode(cookies["pass"]);
                }
                if (cookies["isRember"] != null)
                {
                    ViewBag.isRember = Server.UrlDecode(cookies["isRember"]) == "1" ? "checked" : "";
                }
            }
            return View();
        }

        /// <summary>
        /// 提交登录信息
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignIn(string loginName, string password, string remberPwd)
        {
            string returnStatus = "1";//代表用户登录成功
            CommonService.Model.SysManager.C_Userinfo userInfo = _userWCF.GetModelByLoginName(loginName);

            if (userInfo == null)
            {
                returnStatus = "-1";//代表用户登录名不存在
                return Content(returnStatus);
            }
            //存取主用户的GUid
            Guid mainguid = userInfo.C_Userinfo_code.Value;

            if (password.Length > 20)
            {
                userInfo = _userWCF.GetModelByLoginNameAndPassword(loginName, password);
            }
            else
            {
                userInfo = _userWCF.GetModelByLoginNameAndPassword(loginName, Encryption.GetMd5(password));
            }
            if (userInfo == null)
            {
                returnStatus = "-2";//代表用户登录密码错误
                return Content(returnStatus);
            }
            if (userInfo.C_Userinfo_isDelete)
            {
                returnStatus = "-3";//代表用户已被删除
                return Content(returnStatus);
            }
            if (userInfo.C_Userinfo_state == Convert.ToInt32(UserLoginStateEnum.未启用))
            {
                returnStatus = "-4";//代表用户未启用
                return Content(returnStatus);
            }
            if (userInfo.C_Userinfo_state == Convert.ToInt32(UserLoginStateEnum.已禁用))
            {
                returnStatus = "-5";//代表用户已禁用
                return Content(returnStatus);
            }
            bool isPreSetManager = false;//是否为系统预置管理员用户
            if (loginName.ToLower().Equals("admin"))
            {//管理员登录
                isPreSetManager = true;              
            }

            if (returnStatus == "1")
            {
                #region 登陆日志的插入
                CommonService.Model.SysManager.C_Log clogmodel = new CommonService.Model.SysManager.C_Log();
                clogmodel.C_Userinfo_name = userInfo.C_Userinfo_name;
                clogmodel.C_Userinfo_code = new Guid(mainguid.ToString());             
                clogmodel.C_Log_code = Guid.NewGuid();
                clogmodel.C_Datatime = DateTime.Now;
                clogmodel.C_Log_Type = Convert.ToInt32(LoginTypeEnum.北斗云PC);

                clogmodel.C_Log_ip = Request.UserHostAddress;  //取得本机IP
                clogmodel.C_Operate = "登陆成功";
                _LogWCF.Add(clogmodel);
                #endregion

                Guid userCode = mainguid;             

                #region 处理用户所属部门、岗位以及部门所属区域关系
                //用户所属部门岗位以及部门所属区域集合(字符串集合)//注意部门名称或岗位名称或者区域名称中，不允许存在 "逗号、竖线"
                string userOrgPosts = String.Empty;
                List<CommonService.Model.SysManager.C_Organization_post_user> OrgUserPosts = _orgUserPostWCF.GetHasDisbutedPostsByUser(userCode);
                foreach (CommonService.Model.SysManager.C_Organization_post_user orgPost in OrgUserPosts)
                {
                    userOrgPosts += "" + orgPost.C_Post_code.Value + "," + orgPost.C_Post_name + "," + orgPost.C_Organization_code.Value + "," + orgPost.Org_name + ",";
                    if (orgPost.Org_region_code != null)
                    {
                        userOrgPosts += "" + orgPost.Org_region_code.Value + ",";
                    }
                    else
                    {
                        userOrgPosts += "" + ",";
                    }
                    userOrgPosts += "" + orgPost.Org_region_name+",";
                    userOrgPosts += "" + orgPost.C_Post_group_code.Value + "," + orgPost.C_Post_group_name + "|";
                }
                if (userOrgPosts != "")
                    userOrgPosts = userOrgPosts.Substring(0, userOrgPosts.Length - 1);
                #endregion

                #region 处理用户角色(多角色)
                List<CommonService.Model.SysManager.C_Organization_post_user_role> listRole = _org_post_user_roleWCF.GetListByUserCode(userCode);
                string roles = "";
                for (int i = 0; i < listRole.Count(); i++)
                {
                    roles += "'" + listRole[i].C_Role_id + "',";
                }
                if (roles.Length > 0)
                    roles = roles.Substring(0, roles.Length - 1);
                #endregion

                this.SetUserAuthentication(userInfo.C_Userinfo_code.Value,
                           userInfo.C_Userinfo_code,
                           userInfo.C_Userinfo_name,
                           userInfo.C_Userinfo_loginID,
                           null,
                           null, null,
                           isPreSetManager,
                           false,
                           userInfo.C_Region_abbreviation,
                           userOrgPosts,
                           roles
                           );
                AddCookies(loginName, password, remberPwd);

            }
            return Content(returnStatus);
        }


        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SignOff()
        {
            //注销当前登录用户
            Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
            return RedirectToAction("SignIn", "Account");
        }


        /// <summary>
        /// OA登录
        /// </summary>
        /// <returns></returns>
        public ActionResult OaSignIn()
        {
            HttpCookie cookies = Request.Cookies["Porschev"];
            ViewBag.user = String.Empty;
            ViewBag.pass = String.Empty;
            ViewBag.isRember = String.Empty;
            if (cookies != null)
            {
                if (cookies["user"] != null)
                    ViewBag.user = Server.UrlDecode(cookies["user"]);
                if (cookies["pass"] != null)
                    ViewBag.pass = Server.UrlDecode(cookies["pass"]);
                if (cookies["isRember"] != null)
                {
                    ViewBag.isRember = Server.UrlDecode(cookies["isRember"]) == "1" ? "checked" : "";
                }
            }
            return View();
        }

        /// <summary>
        /// 知识库登录
        /// </summary>
        /// <returns></returns>
        public ActionResult KmsSignIn()
        {
            HttpCookie cookies = Request.Cookies["Porschev"];
            ViewBag.user = String.Empty;
            ViewBag.pass = String.Empty;
            if (cookies != null)
            {
                if (cookies["user"] != null)
                    ViewBag.user = Server.UrlDecode(cookies["user"]);
                if (cookies["pass"] != null)
                    ViewBag.pass = Server.UrlDecode(cookies["pass"]);
                if (cookies["isRember"] != null)
                {
                    ViewBag.isRember = Server.UrlDecode(cookies["isRember"]) == "1" ? "checked" : "";
                }
            }
            return View();
        }

        /// <summary>
        /// 提交KMS登录信息
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult KmsSignIn(string loginName, string password, string remberPwd)
        {
            string returnStatus = "1";//代表用户登录成功
            CommonService.Model.SysManager.C_Userinfo userInfo = _userWCF.GetModelByLoginName(loginName);

            if (userInfo == null)
            {
                returnStatus = "-1";//代表用户登录名不存在
                return Content(returnStatus);
            }
            //存取主用户的GUid
            Guid mainguid = new Guid(userInfo.C_Userinfo_code.ToString());

            if (password.Length > 20)
            {
                userInfo = _userWCF.GetModelByLoginNameAndPassword(loginName, password);
            }
            else
            {
                userInfo = _userWCF.GetModelByLoginNameAndPassword(loginName, Encryption.GetMd5(password));
            }
            if (userInfo == null)
            {
                returnStatus = "-2";//代表用户登录密码错误
                return Content(returnStatus);
            }
            if (userInfo.C_Userinfo_isDelete)
            {
                returnStatus = "-3";//代表用户已被删除
                return Content(returnStatus);
            }
            if (userInfo.C_Userinfo_state == Convert.ToInt32(UserLoginStateEnum.未启用))
            {
                returnStatus = "-4";//代表用户未启用
                return Content(returnStatus);
            }
            if (userInfo.C_Userinfo_state == Convert.ToInt32(UserLoginStateEnum.已禁用))
            {
                returnStatus = "-5";//代表用户已禁用
                return Content(returnStatus);
            }
            bool isPreSetManager = false;//是否为系统预置管理员用户
            if (loginName.ToLower().Equals("admin"))
            {//管理员登录
                isPreSetManager = true;
            }        

            if (returnStatus == "1")//登录成功记录日志
            {
                Guid userCode = mainguid;                

                #region 处理用户所属部门、岗位以及部门所属区域关系
                //用户所属部门岗位以及部门所属区域集合(字符串集合)//注意部门名称或岗位名称或者区域名称中，不允许存在 "逗号、竖线"
                string userOrgPosts = String.Empty;
                List<CommonService.Model.SysManager.C_Organization_post_user> OrgUserPosts = _orgUserPostWCF.GetHasDisbutedPostsByUser(userCode);
                foreach (CommonService.Model.SysManager.C_Organization_post_user orgPost in OrgUserPosts)
                {
                    userOrgPosts += "" + orgPost.C_Post_code.Value + "," + orgPost.C_Post_name + "," + orgPost.C_Organization_code.Value + "," + orgPost.Org_name+",";
                    if (orgPost.Org_region_code != null)
                    {
                        userOrgPosts += "" + orgPost.Org_region_code.Value + ",";
                    }
                    else
                    {
                        userOrgPosts += "" + ",";
                    }
                    userOrgPosts += "" + orgPost.Org_region_name + ",";
                    userOrgPosts += "" + orgPost.C_Post_group_code.Value + "," + orgPost.C_Post_group_name + "|";
                }
                if (userOrgPosts != "")
                    userOrgPosts = userOrgPosts.Substring(0, userOrgPosts.Length - 1);
                #endregion

                #region 处理用户角色(多角色)
                List<CommonService.Model.SysManager.C_Organization_post_user_role> listRole = _org_post_user_roleWCF.GetListByUserCode(userCode);
                string roles = "";
                for (int i = 0; i < listRole.Count(); i++)
                {
                    roles += "'" + listRole[i].C_Role_id + "',";
                }
                if (roles.Length > 0)
                    roles = roles.Substring(0, roles.Length - 1);
                #endregion

                #region 登陆日志的插入----单独表
                CommonService.Model.KMS.K_Kms_Log kmslog = new CommonService.Model.KMS.K_Kms_Log();
                kmslog.K_Kms_Log_usercode = mainguid;//登录主账户code
                kmslog.K_Kms_Log_datetime = DateTime.Now;//登录时间
                kmslog.K_Kms_Log_ip = Request.UserHostAddress;  //取得本机IP
                kmslog.K_Kms_Log_type = "知识库登录";
                _Kms_LogWCF.Add(kmslog);
                #endregion

                #region 登陆日志的插入-----与北斗云同一个表
                CommonService.Model.SysManager.C_Log clogmodel = new CommonService.Model.SysManager.C_Log();
                clogmodel.C_Userinfo_name = userInfo.C_Userinfo_name;
                clogmodel.C_Userinfo_code = new Guid(mainguid.ToString());         
                clogmodel.C_Log_code = Guid.NewGuid();
                clogmodel.C_Datatime = DateTime.Now;
                clogmodel.C_Log_Type = Convert.ToInt32(LoginTypeEnum.云学堂);

                clogmodel.C_Log_ip = Request.UserHostAddress;  //取得本机IP
                clogmodel.C_Operate = "登陆成功";
                _LogWCF.Add(clogmodel);
                #endregion

                this.SetUserAuthentication(userInfo.C_Userinfo_code.Value,
                           userInfo.C_Userinfo_code,
                           userInfo.C_Userinfo_name,
                           userInfo.C_Userinfo_loginID,
                           null,
                           null, null,
                           isPreSetManager,
                           false,
                           userInfo.C_Region_abbreviation,
                           userOrgPosts,
                           roles);
                AddCookies(loginName, password, remberPwd);

            }
            return Content(returnStatus);
        }

        #region 添加cookeis
        ///<summary>
        /// 添加cookeis
        ///</summary>
        public void AddCookies(string userName, string passWord, string remberPwd)
        {
            HttpCookie cookies = new HttpCookie("Porschev");
            //cookies["isRember"] = Server.UrlEncode(remberPwd);
            cookies["isRember"] = "";
            cookies["user"] = Server.UrlEncode(userName);

            //cookies["pass"] = remberPwd == "1" ? Server.UrlEncode(passWord) : "";
            cookies["pass"] = "";
            cookies.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(cookies);
        }
        #endregion
    }
}