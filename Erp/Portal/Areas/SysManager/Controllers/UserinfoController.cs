using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.SysManager.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserinfoController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.SysManager.IC_Post _postWCF;
        private readonly ICommonService.SysManager.IC_Group _groupWCF;
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.SysManager.IC_ChiefExpert_Minister _chiefExpert_MinisterWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user_region _organization_post_user_regionWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user _organization_post_userWCF;
        public UserinfoController()
        {
            #region 服务初始化
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _postWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Post>("PostWCF");
            _groupWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Group>("GroupWCF");
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _chiefExpert_MinisterWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_ChiefExpert_Minister>("ChiefExpert_MinisterWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            _organization_post_user_regionWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user_region>("C_Organization_post_user_regionWCF");
            _organization_post_userWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user>("OrgPostUserWCF");
            #endregion
        }

        //
        // GET: /SysManager/Userinfo/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            //创建初始化用户实体
            CommonService.Model.SysManager.C_Userinfo user = new CommonService.Model.SysManager.C_Userinfo();
            user.C_Userinfo_code = Guid.NewGuid();
            user.C_Userinfo_parent = null;
            user.C_Userinfo_roleID = null;
            user.C_Userinfo_state = 0;
            user.C_Userinfo_Organization = null;
            user.C_Userinfo_post = null;
            user.C_Userinfo_isDelete = false;
            user.C_Userinfo_creator = Context.UIContext.Current.UserCode;
            user.C_Userinfo_createTime = DateTime.Now;

            return View(user);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string Userinfo_code)
        {
            CommonService.Model.SysManager.C_Userinfo user = _userinfoWCF.GetUserinfoByCode(new Guid(Userinfo_code));

            user.C_Userinfo_password = "";
            return View("Create", user);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            List<CommonService.Model.SysManager.C_Post> Posts = _postWCF.GetAllPosts();
            ViewBag.Posts = Posts;

            //用户查询模型
            CommonService.Model.SysManager.C_Userinfo userConditon = new CommonService.Model.SysManager.C_Userinfo();
            userConditon.C_Userinfo_code = Context.UIContext.Current.UserCode;
            if (!String.IsNullOrEmpty(form["C_Userinfo_name"]))
            {//用户名称查询条件
                userConditon.C_Userinfo_name = form["C_Userinfo_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//部门Guid查询条件
                userConditon.C_Userinfo_Organization = new Guid(form["responsibleDeptlookup.Code"]);
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Name"]))
            {//部门名称
                userConditon.C_Userinfo_Organization_name = form["responsibleDeptlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Userinfo_post"]))
            {//岗位Guid查询条件
                if (form["C_Userinfo_post"] != "全部")
                {
                    userConditon.C_Userinfo_post = new Guid(form["C_Userinfo_post"]);
                }
            }

            //用户查询模型传递到前端视图中
            ViewBag.UserConditon = userConditon;

            #endregion
            //获取用户总记录数
            this.TotalRecordCount = _userinfoWCF.GetUserListRecordCount(userConditon);
            
            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取用户数据信息
            List<CommonService.Model.SysManager.C_Userinfo> menus = _userinfoWCF.GetUserListByPage(userConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(menus);
        }

        /// <summary>
        /// 组织机构、岗位、人员单选Callback带回布局Action
        /// </summary>
        /// <returns></returns>
        public ActionResult SingleCallbackRef_OrgPostUserLayout(string type, int? powerId, int? otype)
        {
            ViewBag.type = type;
            ViewBag.powerId = powerId;
            ViewBag.otype = otype;
            return View();
        }

        /// <summary>
        /// 组织机构、岗位、人员多选Callback带回布局Action
        /// </summary>
        /// <returns></returns>
        public ActionResult MulityCallbackRef_OrgPostUserLayout(string code, int? type)
        {
            ViewBag.code = code;
            ViewBag.type = type;
            return View();
        }

        /// <summary>
        /// 组织机构，岗位关联人员 单选 Callback Action
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="isChecked">1、获取当前用户关联区域人员；0、获取全部人员</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRef_OrgAndPostRelationUserList(string orgCode, string postCode, string userinfoName, string type, string isChecked, int? otype, int? powerId)
        {
            Guid orginzationCode = Guid.Empty;//组织机构Guid
            Guid orginzationPostCode = Guid.Empty;//岗位Guid
            List<Guid> DepIds = new List<Guid>();
            string regionCodes = "";//区域GUID
            if (!orgCode.Equals("{orgCode}"))
            {
                orginzationCode = new Guid(orgCode);
                //查找当前部门下所有的子级部门

                DepIds.Add(orginzationCode);
                var OrganizationList = _organizationWCF.GetModelByParent(orginzationCode);
                foreach (var item in OrganizationList)
                {
                    DepIds.Add(item.C_Organization_code.Value);
                    SetDep(item.C_Organization_code.Value, DepIds);
                }
            }
            else
            {
                if (isChecked != "0")
                {
                    List<CommonService.Model.SysManager.C_Organization> organizationList = _organizationWCF.GetContainLawyerOrAdvisorList(Context.UIContext.Current.UserCode.Value, otype);
                    if (organizationList.Count() != 0)
                    {
                        foreach (CommonService.Model.SysManager.C_Organization organization in organizationList)
                        {
                            DepIds.Add(organization.C_Organization_code.Value);
                        }
                    }
                    else
                    {
                        DepIds.Add(orginzationCode);
                    }
                }
            }
            if (!postCode.Equals("{postCode}"))
            {
                orginzationPostCode = new Guid(postCode);
            }
            if (userinfoName.Equals("{userName}"))
            {
                userinfoName = string.Empty;
            }
            ViewBag.type = type;
            List<CommonService.Model.SysManager.C_Userinfo> UserInfos = new List<CommonService.Model.SysManager.C_Userinfo>();
            //获取当前用户关联区域
            Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
            ArrayList UserRelRegionList = new ArrayList();//用户关联区域集合
            //List<CommonService.Model.SysManager.C_Userinfo_region> userInfoRegionList = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
            List<CommonService.Model.SysManager.C_Organization_post_user_region> OrgPostUserRegionList = _organization_post_user_regionWCF.GetListByUserinfoCode(userCode);
            if (OrgPostUserRegionList.Count != 0)
            {
                foreach (CommonService.Model.SysManager.C_Organization_post_user_region OrgPostUserRegion in OrgPostUserRegionList)
                {
                    if (UserRelRegionList.Contains(OrgPostUserRegion.C_region_code))
                        continue;
                    UserRelRegionList.Add(OrgPostUserRegion.C_region_code);
                    regionCodes += OrgPostUserRegion.C_region_code + ",";
                }
                regionCodes = regionCodes != "" ? regionCodes.Substring(0, regionCodes.Length - 1) : Guid.Empty.ToString();
            }
            if (powerId != null)
            {
                if (Context.UIContext.Current.IsPreSetManager)
                {
                    regionCodes = Guid.Empty.ToString();
                    UserInfos = _userinfoWCF.GetUsersByOrgAndPostAll(DepIds, orginzationPostCode, userinfoName, regionCodes);
                }
                else
                {
                    if (isChecked == "1")
                    {//获取当前用户关联区域人员
                        UserInfos = _userinfoWCF.GetUsersByOrgAndPostAll(DepIds, orginzationPostCode, userinfoName, regionCodes);
                    }
                    else
                    {
                        regionCodes = Guid.Empty.ToString();
                        UserInfos = _userinfoWCF.GetUsersByOrgAndPostAll(DepIds, orginzationPostCode, userinfoName, regionCodes);
                    }
                }
            }
            else
            {//第一次加载取当前用户所在区域的人员
                if (Context.UIContext.Current.IsPreSetManager)
                {
                    regionCodes = Guid.Empty.ToString();
                    UserInfos = _userinfoWCF.GetUsersByOrgAndPostAll(DepIds, orginzationPostCode, userinfoName, regionCodes);
                }
                else
                {
                    if ((isChecked == "1") || (isChecked.Equals("{isChecked}")))
                    {
                        UserInfos = _userinfoWCF.GetUsersByOrgAndPostAll(DepIds, orginzationPostCode, userinfoName, regionCodes);
                    }
                    else
                    {
                        regionCodes = Guid.Empty.ToString();
                        UserInfos = _userinfoWCF.GetUsersByOrgAndPostAll(DepIds, orginzationPostCode, userinfoName, regionCodes);
                    }
                }
            }

            return View(UserInfos);
        }
        private void SetDep(Guid guid, List<Guid> DepIds)
        {
            var OrganizationList = _organizationWCF.GetModelByParent(guid);
            if (OrganizationList.Count > 0)
            {
                foreach (var item in OrganizationList)
                {
                    DepIds.Add(item.C_Organization_code.Value);
                    SetDep(item.C_Organization_code.Value, DepIds);
                }
            }
        }
        /// <summary>
        /// 组织机构，岗位关联人员 多选 Callback Action
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public ActionResult MulityCallbackRef_OrgAndPostRelationUserList(string orgCode, string postCode, string code, string userinfoName, string isChecked)
        {
            Guid orginzationCode = Guid.Empty;//组织机构Guid
            Guid orginzationPostCode = Guid.Empty;//岗位Guid
            Guid lawyerCode = Guid.Empty;//已选的主办律师的code
            string regionCodes = "";//区域GUID
            if (!orgCode.Equals("{orgCode}"))
            {
                orginzationCode = new Guid(orgCode);
            }
            if (!postCode.Equals("{postCode}"))
            {
                orginzationPostCode = new Guid(postCode);
            }
            if (!string.IsNullOrEmpty(code))
            {
                lawyerCode = new Guid(code);
            }
            if (userinfoName.Equals("{userName}"))
            {
                userinfoName = string.Empty;
            }
            ///区域过滤
            //获取当前用户关联区域
            Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
            ArrayList UserRelRegionList = new ArrayList();//用户关联区域集合
            //List<CommonService.Model.SysManager.C_Userinfo_region> userInfoRegionList = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
            List<CommonService.Model.SysManager.C_Organization_post_user_region> OrgPostUserRegionList = _organization_post_user_regionWCF.GetListByUserinfoCode(userCode);
            if (OrgPostUserRegionList.Count != 0)
            {
                foreach (CommonService.Model.SysManager.C_Organization_post_user_region OrgPostUserRegion in OrgPostUserRegionList)
                {
                    regionCodes += OrgPostUserRegion.C_region_code + ",";
                }
                regionCodes = regionCodes != "" ? regionCodes.Substring(0, regionCodes.Length - 1) : Guid.Empty.ToString();
            }
            List<CommonService.Model.SysManager.C_Userinfo> UserInfos = new List<CommonService.Model.SysManager.C_Userinfo>();
            if (isChecked != "0")
            {//获取当前用户关联区域人员
                regionCodes = regionCodes == "" ? Guid.Empty.ToString() : regionCodes;
                UserInfos = _userinfoWCF.GetUsersByOrgAndPostAndLycode(orginzationCode, orginzationPostCode, lawyerCode, userinfoName, regionCodes);
            }
            else
            {
                regionCodes = Guid.Empty.ToString();
                UserInfos = _userinfoWCF.GetUsersByOrgAndPostAndLycode(orginzationCode, orginzationPostCode, lawyerCode, userinfoName, regionCodes);
            }

            return View(UserInfos);
        }

        /// <summary>
        /// 流程，岗位关联人员Action
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public ActionResult FlowAndPostRelationUserList(string flowCode, string postCode, string C_Userinfo_name, string fkCode, string type, string PCd2, string isChecked)
        {
            Guid orginzationPostCode = Guid.Empty;//岗位Guid
            string regionCodes = "";//区域GUID
            if (C_Userinfo_name.Equals("{userName}"))
            {
                C_Userinfo_name = "";
            }
            if (!postCode.Equals("{postCode}"))
            {
                orginzationPostCode = new Guid(postCode);
            }
            else
            {
                if (PCd2 != null && PCd2 != "")
                {
                    orginzationPostCode = new Guid(PCd2);
                }
            }
            if (String.IsNullOrEmpty(flowCode))
            {
                flowCode = Guid.Empty.ToString();
            }
            ///区域过滤
            //获取当前用户关联区域
            Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
            ArrayList UserRelRegionList = new ArrayList();//用户关联区域集合
            //List<CommonService.Model.SysManager.C_Userinfo_region> userInfoRegionList = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
            List<CommonService.Model.SysManager.C_Organization_post_user_region> OrgPostUserRegionList = _organization_post_user_regionWCF.GetListByUserinfoCode(userCode);
            if (OrgPostUserRegionList.Count != 0)
            {
                foreach (CommonService.Model.SysManager.C_Organization_post_user_region OrgPostUserRegion in OrgPostUserRegionList)
                {
                    regionCodes += OrgPostUserRegion.C_region_code + ",";
                }
                regionCodes = regionCodes != "" ? regionCodes.Substring(0, regionCodes.Length - 1) : Guid.Empty.ToString();
            }
            List<CommonService.Model.SysManager.C_Userinfo> UserInfos = new List<CommonService.Model.SysManager.C_Userinfo>();
            if (isChecked != "0" && userCode.ToString() != "3e11c570-4a11-483a-8367-602fba3aa1de")
            {//获取当前用户关联区域人员
                UserInfos = _userinfoWCF.GetUsersByFlowAndPost(new Guid(flowCode), orginzationPostCode, C_Userinfo_name, fkCode, type, regionCodes);
            }
            else
            {
                regionCodes = Guid.Empty.ToString();
                UserInfos = _userinfoWCF.GetUsersByFlowAndPost(new Guid(flowCode), orginzationPostCode, C_Userinfo_name, fkCode, type, regionCodes);
            }

            return View(UserInfos);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.SysManager.C_Userinfo user)
        {
            //服务方法调用
            int userId = 0;
            if (user.C_Userinfo_password != null && !string.IsNullOrEmpty(user.C_Userinfo_password))
            {
                user.C_Userinfo_password = Encryption.GetMd5(user.C_Userinfo_password);
            }

            bool IsSuccess = false;
            IsSuccess = _userinfoWCF.ExistsByloginID(user.C_Userinfo_loginID);
            if (IsSuccess && user.C_Userinfo_id <= 0)
            {
                return Json(TipHelper.JsonData("此登录名已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                if (user.C_Userinfo_id > 0)
                {//修改
                    if (user.C_Userinfo_password == null)
                    {
                        CommonService.Model.SysManager.C_Userinfo userinfo = _userinfoWCF.GetUserinfoByCode(user.C_Userinfo_code.Value);
                        user.C_Userinfo_password = userinfo.C_Userinfo_password;
                    }

                    bool isUpdateSuccess = _userinfoWCF.Update(user);
                    if (isUpdateSuccess)
                    {
                        userId = user.C_Userinfo_id;
                    }
                }
                else
                {//添加                
                    userId = _userinfoWCF.Add(user);
                }

                if (userId > 0)
                {
                    #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                    string formOperateType = form["formOperateType"].ToString().ToLower();
                    if (formOperateType == "onlysave")
                    {
                        return Json(TipHelper.JsonData("保存用户信息成功", ""));//仅仅保存
                    }
                    else if (formOperateType == "saveandnewnext")
                    {
                        return Json(TipHelper.JsonData("保存用户信息成功", "/sysmanager/roles/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                    }
                    else
                    {
                        return Json(TipHelper.JsonData("保存用户信息成功", ""));//默认仅仅保存
                    }
                    #endregion
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("保存用户信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string Userinfo_code)
        {
            bool isSuccess = _userinfoWCF.Delete(new Guid(Userinfo_code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除用户信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除用户信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除子用户
        /// </summary>
        /// <param name="orgPostUserCode">组织机构+岗位+子用户Guid串</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteChildren(string orgPostUserCode)
        {
            string[] orgPostUserCodeStr = orgPostUserCode.Split(',');
            string childrenUserCode = orgPostUserCodeStr[2];

            bool isSuccess = _userinfoWCF.DeleteChildren(new Guid(childrenUserCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除子用户信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除子用户信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModifyUserStatus(string Userinfo_code, int? userinfoState)
        {
            CommonService.Model.SysManager.C_Userinfo userinfo = _userinfoWCF.GetModelByUserCode(new Guid(Userinfo_code));
            if (userinfoState == userinfo.C_Userinfo_state)
            {
                return Json(TipHelper.JsonData(userinfoState == 1 ? "此用户已启用！" : "此用户已禁用！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            bool isSuccess = _userinfoWCF.ModifyUserStatus(new Guid(Userinfo_code), userinfoState);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData(userinfo.C_Userinfo_state == 0 ? "此用户已启用！" : "此用户已禁用！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData(userinfo.C_Userinfo_state == 0 ? "此用户启用失败！" : "此用户禁用失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除用户关联岗位
        /// </summary>
        /// <param name="post_codeItem">岗位Guid</param>
        /// <param name="orgCode">组织架构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeletePostByUserCodeAndOrgCode(string post_codeItem, string orgCode, string userCode)
        {
            bool isSuccess = _userinfoWCF.DeletePostByUserCodeAndOrgCode(new Guid(orgCode), new Guid(post_codeItem), new Guid(userCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除岗位信息成功！", "iframe_allocatedPostList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除岗位信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 分配岗位
        /// </summary>
        /// <returns></returns>
        public ActionResult UserDistributionPost(string Userinfo_code)
        {
            Guid Userinfo_Code = Guid.Empty;//用户Guid
            if (!Userinfo_code.Equals("{sid_Iterm}"))
            {
                Userinfo_Code = new Guid(Userinfo_code);
            }
            ViewBag.UserCode = Userinfo_code;
            return View();
        }

        /// <summary>
        /// 根据组织机构和用户获取对应的岗位信息
        /// </summary>
        /// <param name="form"></param>
        /// <param name="organizationCode"></param>
        /// <returns></returns>
        public ActionResult GetPostListForOrgAndUserinfo(string orgCode, string userCode)
        {
            Guid orginzationCode = Guid.Empty;
            if (!orgCode.Equals("{orgCode}"))
            {
                orginzationCode = new Guid(orgCode);
            }
            Guid userInfo_code = Guid.Empty;
            if (!userCode.Equals("{userCode}"))
            {
                userInfo_code = new Guid(userCode);
            }
            List<CommonService.Model.SysManager.C_Userinfo> userinfos = _userinfoWCF.GetUsersByOrgAndPostChirld(orginzationCode, null, userInfo_code);
            return View(userinfos);
        }

        /// <summary>
        /// 根据组织结构，用户，岗位code分配岗位
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeDefault(string post_codeItem, string orgCode, string userCode)
        {
            if (_userinfoWCF.UserDistributionPost(post_codeItem, orgCode, userCode))
            {//成功
                return Json(TipHelper.JsonData("分配岗位成功！", "iframe_allocatedPostList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));

            }
            else
            {//失败
                return Json(TipHelper.JsonData("分配岗位失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 人员分配岗位(新)
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCodes">岗位Guids串</param>
        /// <returns></returns>
        public ActionResult DistributionPost(string orgCode, string userCode, string postCodes)
        {
            if (_userinfoWCF.PersonDistributionPost(orgCode, userCode, postCodes, Context.UIContext.Current.RootUserCode.Value))
            {//成功
                return Json(TipHelper.JsonData("分配岗位成功！", "iframe_allocatedPostList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));

            }
            else
            {//失败
                return Json(TipHelper.JsonData("没有可以分配的岗位！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除用户关联岗位(新)
        /// </summary>      
        /// <param name="orgUserPostRelatedId">组织机构-用户-岗位关联Id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeletePost(string orgUserPostRelatedId)
        {
            bool isSuccess = _userinfoWCF.DeletePost(Convert.ToInt32(orgUserPostRelatedId));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除岗位信息成功！", "iframe_allocatedPostList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除岗位信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 关联岗位区域，岗位角色(新)
        /// </summary>
        /// <param name="orgUserPostRelatedId">组织机构-用户-岗位关联Id</param>
        /// <param name="areaCodes">区域Guids</param>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RelatePostAreaRoles(string orgUserPostRelatedId, string areaCodes, string roleId)
        {
            bool isSuccess = _userinfoWCF.RelatePostAreaRoles(Convert.ToInt32(orgUserPostRelatedId), areaCodes, Convert.ToInt32(roleId), Context.UIContext.Current.RootUserCode.Value);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTip));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 角色管理>>人员列表（组织，岗位，角色）
        /// </summary>
        /// <param name="form">用户code</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult MulityRoleManagerList(string usercode)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            Guid userInfo_code = Guid.Empty;//角色Guid
            if (!usercode.Equals("{usercode}"))
            {
                userInfo_code = new Guid(usercode);
            }
            //用户查询模型
            CommonService.Model.SysManager.C_Userinfo userConditon = new CommonService.Model.SysManager.C_Userinfo();



            //ViewBag.UserConditon = userConditon;

            #endregion

            //获取用户总记录数
            //this.TotalRecordCount = _userinfoWCF.GetRecordCount(userConditon);

            //初始化页面信息(固定写法)
            //this.InitializationPageInfo(form, page.Value);

            //获取用户数据信息
            List<CommonService.Model.SysManager.C_Userinfo> menus = _userinfoWCF.GetUsersByOrgAndPostChirld(null, null, userInfo_code);
            //用户查询模型传递到前端视图中
            ViewBag.PostConditon = menus;
            return View(menus);
        }
        /// <summary>
        /// 单选回调法院列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList(FormCollection form, string type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //用户查询模型
            CommonService.Model.SysManager.C_Userinfo userConditon = new CommonService.Model.SysManager.C_Userinfo();

            if (!String.IsNullOrEmpty(form["C_Userinfo_name"]))
            {//用户名称查询条件
                userConditon.C_Userinfo_name = form["C_Userinfo_name"].Trim(); ;
            }

            //用户查询模型传递到前端视图中
            ViewBag.UserConditon = userConditon;

            #endregion

            //获取用户总记录数
            this.TotalRecordCount = _userinfoWCF.GetRecordCount(userConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;

            //获取用户数据信息
            List<CommonService.Model.SysManager.C_Userinfo> menus = _userinfoWCF.GetListByPage(userConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(menus);
        }

        #region 首席部长分配
        /// <summary>
        /// 首席专家列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ChiefExpertList(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //用户查询模型
            CommonService.Model.SysManager.C_Userinfo userConditon = new CommonService.Model.SysManager.C_Userinfo();

            if (!String.IsNullOrEmpty(form["C_Userinfo_name"]))
            {//用户名称查询条件
                userConditon.C_Userinfo_name = form["C_Userinfo_name"].Trim(); ;
            }
            userConditon.C_Userinfo_relationType = 3;
            //用户查询模型传递到前端视图中
            ViewBag.UserConditon = userConditon;

            #endregion

            //获取用户总记录数
            this.TotalRecordCount = _userinfoWCF.GetFirsrRecordCount(userConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取用户数据信息
            List<CommonService.Model.SysManager.C_Userinfo> menus = _userinfoWCF.GetFirstListByPage(userConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(menus);
        }

        /// <summary>
        /// 部长列表
        /// </summary>
        /// <returns></returns>
        public ActionResult MinisterList()
        {
            List<CommonService.Model.SysManager.C_Userinfo> userinfos = _userinfoWCF.GetFirstOrMiniterList(2);
            return View(userinfos);
        }

        /// <summary>
        /// 已分配部长列表
        /// </summary>
        /// <returns></returns>
        public ActionResult AllocatedMinisterList(string userinfoCode)
        {
            List<CommonService.Model.SysManager.C_Userinfo> userinfos = _userinfoWCF.GetMinisterList(new Guid(userinfoCode));
            return View(userinfos);
        }

        /// <summary>
        /// 分配部长
        /// </summary>
        /// <returns></returns>
        public ActionResult AllocationMinister(string userinfoCode)
        {
            ViewBag.userinfoCode = userinfoCode;
            return View();
        }

        /// <summary>
        /// 分配部长
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddChiefExpert_Minister(string ChiefExpert_Code, string Minister_Code)
        {
            bool isSuccess = false;
            if (Minister_Code != "")
            {
                string[] Minister_CodeStr = Minister_Code.Split(',');
                List<CommonService.Model.SysManager.C_ChiefExpert_Minister> ChiefExpert_MinisterList = new List<CommonService.Model.SysManager.C_ChiefExpert_Minister>();
                foreach (var MinisterCode in Minister_CodeStr)
                {
                    CommonService.Model.SysManager.C_ChiefExpert_Minister ChiefExpert_Minister = new CommonService.Model.SysManager.C_ChiefExpert_Minister();
                    ChiefExpert_Minister.C_ChiefExpert_Code = new Guid(ChiefExpert_Code);
                    ChiefExpert_Minister.C_Minister_Code = new Guid(MinisterCode);

                    ChiefExpert_MinisterList.Add(ChiefExpert_Minister);
                }

                isSuccess = _chiefExpert_MinisterWCF.OperateList(ChiefExpert_MinisterList);
            }
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("添加部长信息成功！", "iframe_allocatedCourtList", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("添加部长信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除部长
        /// </summary>
        /// <param name="ChiefExpert_Code"></param>
        /// <param name="Minister_Code"></param>
        /// <returns></returns>
        public ActionResult DeleteChiefExpert_Minister(string ChiefExpert_Code, string Minister_Code)
        {
            bool isSuccess = _chiefExpert_MinisterWCF.Delete(new Guid(ChiefExpert_Code), new Guid(Minister_Code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除部长信息成功！", "iframe_allocatedCourtList", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除部长信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 调整部门布局
        /// </summary>
        /// <param name="userinfoCode">用户GUID</param>
        /// <returns></returns>
        public ActionResult SectorAdjustmentLayout(string userinfoCode)
        {
            ViewBag.userinfoCode = userinfoCode;
            return View();
        }
        /// <summary>
        /// 用户所属 (区域 -> 部门 -> 岗位)
        /// </summary>
        /// <param name="userinfoCode"></param>
        /// <returns></returns>
        public ActionResult GetUserRegionOrgPost(string userinfoCode)
        {
            List<CommonService.Model.SysManager.C_Organization_post_user> organizationPostUsers = _organization_post_userWCF.GetHasDisbutedPostsByUser(new Guid(userinfoCode));
            return View(organizationPostUsers);
        }
        /// <summary>
        /// 调整部门
        /// </summary>
        /// <param name="userinfoCode">用户GUID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SectorAdjustment(string Organization_post_user, string organizationCode)
        {
            bool isSuccess = _userinfoWCF.SectorAdjustment(Organization_post_user, new Guid(organizationCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("调整部门成功！", "iframe_userRegionOrgPost", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("调整部门失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        #endregion

        #region 自定义表单所用

        /// <summary>
        /// 组织机构、岗位、人员多选Callback带回布局Action(自定义表单调用)
        /// </summary>
        /// <param name="lookupgroup">多选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefListDv_UserForm(string lookupgroup, string propertyValueCode, string mappingField, string mappingFieldName)
        {

            #region 参照配置条件
            string _lookupgroup = String.Empty;
            string _propertyValueCode = String.Empty;
            string _mappingField = String.Empty;
            string _mappingFieldName = String.Empty;

            if (!String.IsNullOrEmpty(lookupgroup))
            {
                _lookupgroup = lookupgroup;
            }
            if (!String.IsNullOrEmpty(propertyValueCode))
            {
                _propertyValueCode = propertyValueCode;
            }
            ViewBag.Lookupgroup = _lookupgroup;
            ViewBag.PropertyValueCode = _propertyValueCode;
            ViewBag.MappingField = _mappingField;
            ViewBag.MappingFieldName = _mappingFieldName;
            #endregion

            return View();
        }

        /// <summary>
        /// 组织机构，岗位关联人员 多选 Callback Action
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefList_UserForm(string orgCode, string postCode, string lookupgroup, string propertyValueCode)
        {
            Guid orginzationCode = Guid.Empty;//组织机构Guid
            Guid orginzationPostCode = Guid.Empty;//岗位Guid           
            if (!orgCode.Equals("{orgCode}"))
            {
                orginzationCode = new Guid(orgCode);
            }
            if (!postCode.Equals("{postCode}"))
            {
                orginzationPostCode = new Guid(postCode);
            }
            //多选弹出参照配置条件
            ViewBag.Lookupgroup = lookupgroup;
            ViewBag.PropertyValueCode = propertyValueCode;

            List<CommonService.Model.SysManager.C_Userinfo> UserInfos = _userinfoWCF.GetUsersByOrgAndPostAndLycode(orginzationCode, orginzationPostCode, null, "", Guid.Empty.ToString());
            return View(UserInfos);
        }


        #endregion


    }
}