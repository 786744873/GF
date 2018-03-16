using CommonService;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.SysManager.Controllers
{
    /// <summary>
    /// 组织架构控制器
    /// 作者：贺太玉
    /// 日期：2015/04/22
    /// </summary>
    public class OrganizationController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        private readonly ICommonService.SysManager.IC_Organization_post _organizationPostWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user_region _organization_post_user_regionWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user _organization_post_userWCF;
        public OrganizationController()
        {
            #region 服务初始化
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            _organizationPostWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post>("OrganizationPostWCF");
            _organization_post_user_regionWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user_region>("C_Organization_post_user_regionWCF");
            _organization_post_userWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user>("OrgPostUserWCF");
            #endregion
        }

        //
        // GET: /SysManager/Organization/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string organizationCode)
        {
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            //创建初始化组织机构实体
            CommonService.Model.SysManager.C_Organization organization = new CommonService.Model.SysManager.C_Organization();
            organization.C_Organization_name = "";
            organization.C_Organization_code = Guid.NewGuid();
            organization.C_Organization_isDelete = false;
            if (!String.IsNullOrEmpty(organizationCode))
            {
                organization.C_Organization_parent = new Guid(organizationCode);
            }
            organization.C_Organization_creator = Context.UIContext.Current.UserCode;
            organization.C_Organization_createTime = DateTime.Now;
            /*级别与显示顺序均在WCF逻辑中处理
             * */
            organization.C_Organization_order = 0;
            organization.C_Organization_level = 0;
            organization.C_Organization_state = 1;
            organization.C_Organization_isMarketing = false;
            if (organization.C_Organization_parent == null)
            {
                ViewBag.SelectedOrganizationCode = "";
            }
            else
            {
                ViewBag.SelectedOrganizationCode = organizationCode;
            }

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(organization);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string organizationCode)
        {
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            if (String.IsNullOrEmpty(organizationCode) || organizationCode == "{organizationCode}")
            {
                return RedirectToAction("Create");
            }
            CommonService.Model.SysManager.C_Organization organization = _organizationWCF.Get(new Guid(organizationCode));
            ViewBag.SelectedOrganizationCode = organizationCode;

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View("Create", organization);
        }

        /// <summary>
        /// 布局TreeList
        /// </summary>
        /// <returns></returns>
        public ActionResult LayoutTreeList()
        {
            return View();
        }

        /// <summary>
        /// 生成组织机构树Action
        /// </summary>
        /// <param name="sourceType">调用组织机构来源:1 代表组织机构页面自身调用；2 代表业务流程分配负责人页面调用;3 代表用户分配岗位页面调用</param>
        /// <returns></returns>
        public ActionResult Tree(string orgCode, int sourceType, string isChecked, int? type)
        {
            //isChecked==0,查看全部区域，ischecked!=0,仅查看当前区域
            if (isChecked != "0")
            {
                SetSingleOrganization(sourceType, 1, orgCode, type);
            }
            else
            {
                SetSingleOrganization(sourceType, 0, orgCode, type);
            }

            ViewBag.SourceType = sourceType;
            return View();
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

            //组织机构查询模型
            CommonService.Model.SysManager.C_Organization orgConditon = new CommonService.Model.SysManager.C_Organization();

            if (!String.IsNullOrEmpty(form["C_Organization_name"]))
            {//组织机构名称查询条件
                orgConditon.C_Organization_name = form["C_Organization_name"].Trim(); ;
            }

            //组织机构查询模型传递到前端视图中
            ViewBag.OrgConditon = orgConditon;

            #endregion
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            //获取组织机构总记录数
            this.TotalRecordCount = _organizationWCF.GetRecordCount(orgConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取组织机构数据信息
            List<CommonService.Model.SysManager.C_Organization> organizations = _organizationWCF.GetListByPage(orgConditon,
                "C_Organization_level Asc,T.C_Organization_order Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(organizations);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.SysManager.C_Organization organization)
        {
            Guid oldorganizationcode = new Guid();
            if (organization.C_Organization_Area != null)
            {
                oldorganizationcode = new Guid(organization.C_Organization_Area.ToString());//保存老的区域code
            }
            else
            {
                oldorganizationcode = Guid.Empty;
            }

            //服务方法调用
            int organizationId = 0;
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                organization.C_Organization_Area = new Guid(form["C_Region_code"]);
            }
            if (organization.C_Organization_id > 0)
            {//修改
                bool isUpdateSuccess = _organizationWCF.Update(organization, oldorganizationcode);
                if (isUpdateSuccess)
                {
                    organizationId = organization.C_Organization_id;
                }
            }
            else
            {//添加
                organizationId = _organizationWCF.Add(organization);
            }

            if (organizationId > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存组织机构信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.OrganizationSave));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存组织机构信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="organizationCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string organizationCode)
        {
            bool isSuccess = _organizationWCF.Delete(new Guid(organizationCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除组织机构信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除组织机构信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #region 不含checkbox的组织机构递归

        /// <summary>
        ///  装载全部组织机构信息
        /// </summary>
        private void SetSingleOrganization(int sourceType, int CKorg, string orgCode, int? type)
        {
            List<CommonService.Model.SysManager.C_Organization> organizations = new List<CommonService.Model.SysManager.C_Organization>();
            if (sourceType == 1 && !Context.UIContext.Current.IsPreSetManager)
            {
                //根据用户所在的部门取该部门的组织架构的父级架构和子级架构
                List<CommonService.Model.SysManager.C_Organization_post_user> listPostByUser = _organization_post_userWCF.GetHasDisbutedPostsByUser(Context.UIContext.Current.UserCode.Value);
                for (int i = 0; i < listPostByUser.Count; i++)
                {
                    if (listPostByUser[i].C_Post_name != "系统管理组")
                    {
                        List<CommonService.Model.SysManager.C_Organization> listOrg = _organizationWCF.GetChirldAllList(listPostByUser[i].C_Organization_code);
                        if (listOrg != null)
                        {
                            organizations.AddRange(listOrg);
                        }
                    }
                }
                organizations = organizations.Where((x, i) => organizations.FindIndex(z => z.C_Organization_code == x.C_Organization_code) == i).ToList();
            }
            else
            {
                organizations = _organizationWCF.GetAllList();
            }
            SetSingleTopOrganization(organizations, sourceType, CKorg, orgCode, type);
        }

        /// <summary>
        /// 装载顶级组织机构
        /// </summary>
        /// <param name="organizationList">组织机构集合</param>
        /// <param name="sourceType">调用组织机构来源:1 代表组织机构页面自身调用；2 代表业务流程分配负责人页面调用;3 代表岗位分配页面调用;4 代表 Tree CallBack 调用,返回组织机构Guid，和组织机构名称</param>
        private void SetSingleTopOrganization(List<CommonService.Model.SysManager.C_Organization> organizationList, int sourceType, int CKorg, string orgCode, int? type)
        {
            string organizationTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topOrganizationList = from allList in organizationList
                                      where allList.C_Organization_level == 1
                                      orderby allList.C_Organization_order ascending
                                      select allList;
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */

            organizationTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"\" href=\"\">组织架构</a>";
            organizationTreeHtml += "<ul>";

            foreach (CommonService.Model.SysManager.C_Organization organzation in topOrganizationList)
            {
                string href = "";
                switch (sourceType)
                {
                    case 1://组织机构页面自身调用
                        //href = "/sysmanager/organization/edit?organizationCode=" + organzation.C_Organization_code;
                        href = "?{organizationCode}=" + organzation.C_Organization_code;
                        break;
                    case 2://业务流程分配负责人页面调用
                        href = "?{orgCode}=" + organzation.C_Organization_code.Value.ToString();
                        break;
                    case 3://岗位分配
                        href = "?{orgCode}=" + organzation.C_Organization_code.Value.ToString();
                        break;
                    case 4://Tree CallBack 调用
                        href = "";
                        break;
                }
                string uniqueId = organzation.C_Organization_code.Value.ToString();
                if (sourceType == 2)
                {
                    organizationTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + organzation.C_Organization_name + "</a>";
                }
                else if (sourceType == 3)
                {//动态加入树节点改变后的触发事件
                    organizationTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" >" + organzation.C_Organization_name + "</a>";
                }
                else if (sourceType == 4)
                {//代表 Tree CallBack 调用,带回组织机构Guid，和组织机构名称
                    organizationTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"  callbackjson=\"{'lookupgroup':'responsibleDeptlookup','Code':'" + organzation.C_Organization_code.Value.ToString() + "','Name':'" + organzation.C_Organization_name + "'}\" >" + organzation.C_Organization_name + "</a>";
                }
                else
                {
                    string defaultSelect = string.Empty;
                    if (orgCode != null && orgCode != Guid.Empty.ToString())
                    {
                        if (organzation.C_Organization_code.Value.ToString() == orgCode)
                        {
                            defaultSelect = "class=\"jstree-anchor jstree-clicked\"";
                        }
                    }
                    organizationTreeHtml += "<li class=\"jstree-open\"><a " + defaultSelect + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + organzation.C_Organization_name + "</a>";
                }

                SetSignleRecursionTree(organzation.C_Organization_code.Value, ref organizationTreeHtml, organizationList, sourceType, CKorg, orgCode, type);
                organizationTreeHtml += "</li>";
            }
            organizationTreeHtml += "</ul>";
            organizationTreeHtml += "</li>";
            ViewBag.SingleOrganizationTreeHtml = preTreeHtml + organizationTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有组织机构(递归加载组织机构，默认指打开三级，其余的默认不打开)
        /// </summary>
        /// <param name="parentCode">上级组织机构Code</param>
        /// <param name="organizationTreeHtml">组织机构Tree Html</param>
        /// <param name="organizationList">组织机构集合</param>
        private void SetSignleRecursionTree(Guid parentCode, ref string organizationTreeHtml, List<CommonService.Model.SysManager.C_Organization> organizationList, int sourceType, int CKorg, string orgCode, int? type)
        {
            var loworganizationList = from allList in organizationList
                                      where allList.C_Organization_parent == parentCode
                                      orderby allList.C_Organization_order ascending
                                      select allList;
            if (loworganizationList.Count() != 0)
            {
                organizationTreeHtml += "<ul>";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Organization organization in loworganizationList)
            {
                string href = "";

                switch (sourceType)
                {
                    case 1://组织机构页面自身调用
                        //href = "/sysmanager/organization/edit?organizationCode=" + organization.C_Organization_code;
                        href = "?{organizationCode}=" + organization.C_Organization_code;
                        break;
                    case 2://业务流程分配负责人页面调用
                        href = "?{orgCode}=" + organization.C_Organization_code.Value.ToString();
                        break;
                    case 3://岗位分配
                        href = "?{orgCode}=" + organization.C_Organization_code.Value.ToString();
                        break;
                    case 4://Tree CallBack 调用
                        href = "";
                        break;
                }

                string uniqueId = organization.C_Organization_code.Value.ToString();
                string jsTreeOpenClass = string.Empty;//不打开这些子组织机,如果要打开，则用：jsTreeOpenClass = "class=jstree-open"
                if (sourceType == 2)
                {
                    #region 业务流程分配负责人页面调用
                    if (Context.UIContext.Current.IsPreSetManager || CKorg == 0)
                    {
                        organizationTreeHtml += "<li " + jsTreeOpenClass + "><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + organization.C_Organization_name + "</a>";
                    }
                    else
                    {//获取用户关联区域内的组织架构
                        Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
                        ArrayList UserRelRegionList = new ArrayList();//用户关联区域集合
                        //List<CommonService.Model.SysManager.C_Userinfo_region> userInfoRegionList = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
                        List<CommonService.Model.SysManager.C_Organization_post_user_region> OrgPostUserRegionList = _organization_post_user_regionWCF.GetListByUserinfoCode(userCode);
                        if (OrgPostUserRegionList.Count != 0)
                        {
                            foreach (CommonService.Model.SysManager.C_Organization_post_user_region OrgPostUserRegion in OrgPostUserRegionList)
                            {
                                //couConditon.C_Court_regions += userinfoRegion.C_Region_code.ToString() + ',';
                                if (organization.C_Organization_Area == OrgPostUserRegion.C_region_code && (!UserRelRegionList.Contains(OrgPostUserRegion.C_region_code)))
                                {
                                    UserRelRegionList.Add(OrgPostUserRegion.C_region_code);
                                    if (type != null)
                                    {
                                        if (IsIncludeLawyer(organization.C_Organization_code.Value, type))
                                        {
                                            organizationTreeHtml += "<li " + jsTreeOpenClass + "><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + organization.C_Organization_name + "</a>";
                                        }
                                    }
                                    else
                                    {
                                        organizationTreeHtml += "<li " + jsTreeOpenClass + "><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + organization.C_Organization_name + "</a>";
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                else if (sourceType == 3)
                {//动态加入树节点改变后的触发事件
                    organizationTreeHtml += "<li " + jsTreeOpenClass + "><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + organization.C_Organization_name + "</a>";
                }
                else if (sourceType == 4)
                {//代表 Tree CallBack 调用,带回组织机构Guid，和组织机构名称
                    if (Context.UIContext.Current.IsPreSetManager)
                    {
                        organizationTreeHtml += "<li " + jsTreeOpenClass + "><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"  callbackjson=\"{'lookupgroup':'responsibleDeptlookup','Code':'" + organization.C_Organization_code.Value.ToString() + "','Name':'" + organization.C_Organization_name + "'}\" >" + organization.C_Organization_name + "</a>";
                    }
                    else
                    {//获取用户关联区域内的组织架构
                        Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
                        ArrayList UserRelRegionList = new ArrayList();//用户关联区域集合
                        //List<CommonService.Model.SysManager.C_Userinfo_region> userInfoRegionList = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
                        List<CommonService.Model.SysManager.C_Organization_post_user_region> OrgPostUserRegionList = _organization_post_user_regionWCF.GetListByUserinfoCode(userCode);
                        if (OrgPostUserRegionList.Count != 0)
                        {
                            foreach (CommonService.Model.SysManager.C_Organization_post_user_region OrgPostUserRegion in OrgPostUserRegionList)
                            {
                                //couConditon.C_Court_regions += userinfoRegion.C_Region_code.ToString() + ',';
                                if (organization.C_Organization_Area == OrgPostUserRegion.C_region_code && (!UserRelRegionList.Contains(OrgPostUserRegion.C_region_code)))
                                {
                                    UserRelRegionList.Add(OrgPostUserRegion.C_region_code);
                                    organizationTreeHtml += "<li " + jsTreeOpenClass + "><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"  callbackjson=\"{'lookupgroup':'responsibleDeptlookup','Code':'" + organization.C_Organization_code.Value.ToString() + "','Name':'" + organization.C_Organization_name + "'}\" >" + organization.C_Organization_name + "</a>";
                                }
                            }
                            //couConditon.C_Court_regions = couConditon.C_Court_regions.Length > 0 ? couConditon.C_Court_regions.Substring(0, couConditon.C_Court_regions.Length - 1) : couConditon.C_Court_regions;
                        }
                    }
                }
                else
                {
                    string defaultSelect = string.Empty;
                    bool isHead = false;
                    if (orgCode != null && orgCode != Guid.Empty.ToString())
                    {
                        isHead = _organizationWCF.isHeadOrganizationCode(organization.C_Organization_code.Value, new Guid(orgCode));
                        if (isHead)
                        {
                            jsTreeOpenClass = "class=\"jstree-open\"";
                            //defaultSelect = "class=\"jstree-anchor jstree-clicked\"";
                        }
                        if (organization.C_Organization_code.Value.ToString() == orgCode)
                        {
                            jsTreeOpenClass = "class=\"jstree-open\"";
                            defaultSelect = "class=\"jstree-anchor jstree-clicked\"";
                        }
                    }
                    organizationTreeHtml += "<li " + jsTreeOpenClass + "><a " + defaultSelect + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + organization.C_Organization_name + "</a>";
                }
                SetSignleRecursionTree(organization.C_Organization_code.Value, ref organizationTreeHtml, organizationList, sourceType, CKorg, orgCode, type);
                organizationTreeHtml += "</li>";
            }
            if (loworganizationList.Count() != 0)
            {
                organizationTreeHtml += "</ul>";
            }
        }
        /// <summary>
        /// 组织架构下是否包含律师岗位
        /// </summary>
        /// <param name="organizationCode">组织架构Guid</param>
        /// <param name="type">type=1 包含律师岗位的 type=2 包含专业顾问岗位的</param>
        /// <returns></returns>
        private bool IsIncludeLawyer(Guid organizationCode, int? type)
        {
            int flag = 0;
            CommonService.Model.SysManager.C_Organization organization = _organizationWCF.Get(organizationCode);
            List<CommonService.Model.SysManager.C_Organization_post> organizationPostList = _organizationPostWCF.GetRelationPostsByOrg(organizationCode);
            foreach (CommonService.Model.SysManager.C_Organization_post organizationPost in organizationPostList)
            {
                if (type == 1)
                {
                    if (organizationPost.C_Post_code.ToString() == "a605ab84-c55c-4dbd-bbc8-e9884ef2db32" || //主办律师
                        organizationPost.C_Post_code.ToString() == "bb69a900-1906-446d-a8c5-08c6d1e798ee" || //助理律师
                        organizationPost.C_Post_code.ToString() == "e7db1ad6-f51f-4f5e-a400-d5e442b4742f" || //协办律师
                        organizationPost.C_Post_code.ToString() == "AEAE4D40-4E65-4694-BA3D-0BF4D4777617" || //查控律师
                        organization.C_Organization_parent.ToString() == "5d882c84-5db8-47dc-8d1e-84749016f7d6")
                    {
                        flag++;
                    }
                }
                else if (type == 2)
                {
                    if (organizationPost.C_Post_code.ToString() == "c5e154c7-d8fe-46d4-9fa6-07084403a88e" || //专业顾问
                        organization.C_Organization_parent.ToString() == "5d882c84-5db8-47dc-8d1e-84749016f7d6")
                    {
                        flag++;
                    }
                }
            }
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion

        /// <summary>
        /// 单选带回组织架构树 CallBack
        /// </summary>
        /// <returns></returns>
        public ActionResult SingleCallbackRefTree(int sourceType)
        {
            ViewBag.SourceType = sourceType;
            return View();
        }


        #region 自定义表单所用

        /// <summary>
        /// 单选回调组织机构树(自定义表单调用)
        /// </summary>     
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>      
        /// <returns></returns>
        public ActionResult SingleCallbackRefTreeDv_OrgForm(string lookupgroup, string propertyValueCode, string mappingField, string mappingFieldName)
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
        /// 生成组织机构树Action
        /// </summary>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefTree_OrgForm(string lookupgroup, string propertyValueCode)
        {
            SetSingleOrganization_OrgForm(lookupgroup, propertyValueCode);
            return View();
        }

        /// <summary>
        /// 装载全部组织机构信息
        /// </summary>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        private void SetSingleOrganization_OrgForm(string lookupgroup, string propertyValueCode)
        {
            List<CommonService.Model.SysManager.C_Organization> organizations = _organizationWCF.GetAllList();
            SetSingleTopOrganization_OrgForm(organizations, lookupgroup, propertyValueCode);
        }

        /// <summary>
        /// 装载顶级组织机构
        /// </summary>
        /// <param name="organizationList">组织机构集合</param>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        private void SetSingleTopOrganization_OrgForm(List<CommonService.Model.SysManager.C_Organization> organizationList, string lookupgroup, string propertyValueCode)
        {
            string organizationTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topOrganizationList = from allList in organizationList
                                      where allList.C_Organization_level == 1
                                      orderby allList.C_Organization_order ascending
                                      select allList;
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */

            organizationTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"\" href=\"\">组织架构</a>";
            organizationTreeHtml += "<ul>";

            foreach (CommonService.Model.SysManager.C_Organization organzation in topOrganizationList)
            {
                string href = "";
                string uniqueId = organzation.C_Organization_code.Value.ToString();

                string code = "Code_formproperty_" + propertyValueCode;
                string name = "Name_formproperty_" + propertyValueCode;

                organizationTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"  callbackjson=\"{'lookupgroup':'" + lookupgroup + "','" + code + "':'" + organzation.C_Organization_code.Value.ToString() + "','" + name + "':'" + organzation.C_Organization_name + "'}\" >" + organzation.C_Organization_name + "</a>";

                SetSignleRecursionTree_OrgForm(organzation.C_Organization_code.Value, ref organizationTreeHtml, organizationList, lookupgroup, propertyValueCode);
                organizationTreeHtml += "</li>";
            }
            organizationTreeHtml += "</ul>";
            organizationTreeHtml += "</li>";
            ViewBag.SingleOrganizationTreeHtml = preTreeHtml + organizationTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有组织机构(递归加载组织机构，默认指打开三级，其余的默认不打开)
        /// </summary>
        /// <param name="parentCode">上级组织机构Code</param>
        /// <param name="organizationTreeHtml">组织机构Tree Html</param>
        /// <param name="organizationList">组织机构集合</param>
        private void SetSignleRecursionTree_OrgForm(Guid parentCode, ref string organizationTreeHtml, List<CommonService.Model.SysManager.C_Organization> organizationList, string lookupgroup, string propertyValueCode)
        {
            var loworganizationList = from allList in organizationList
                                      where allList.C_Organization_parent == parentCode
                                      orderby allList.C_Organization_order ascending
                                      select allList;
            if (loworganizationList.Count() != 0)
            {
                organizationTreeHtml += "<ul>";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Organization organization in loworganizationList)
            {
                string href = "";

                string uniqueId = organization.C_Organization_code.Value.ToString();
                string jsTreeOpenClass = String.Empty;//不打开这些子组织机,如果要打开，则用：jsTreeOpenClass = "class=jstree-open"

                string code = "Code_formproperty_" + propertyValueCode;
                string name = "Name_formproperty_" + propertyValueCode;

                organizationTreeHtml += "<li " + jsTreeOpenClass + "><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"  callbackjson=\"{'lookupgroup':'" + lookupgroup + "','" + code + "':'" + organization.C_Organization_code.Value.ToString() + "','" + name + "':'" + organization.C_Organization_name + "'}\" >" + organization.C_Organization_name + "</a>";

                SetSignleRecursionTree_OrgForm(organization.C_Organization_code.Value, ref organizationTreeHtml, organizationList, lookupgroup, propertyValueCode);
                organizationTreeHtml += "</li>";
            }
            if (loworganizationList.Count() != 0)
            {
                organizationTreeHtml += "</ul>";
            }
        }


        #endregion

        public ActionResult Test()
        {
            return View();
        }
    }
}