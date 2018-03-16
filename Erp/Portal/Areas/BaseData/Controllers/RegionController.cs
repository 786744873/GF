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
    /// 区域控制器
    /// 作者：崔慧栋
    /// 日期：2015/06/01
    /// </summary>
    public class RegionController : BaseController
    {
          private readonly ICommonService.IC_Region _regionWCF;
          private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
         public RegionController()
        {
            #region 服务初始化
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            #endregion
        }
        //
         // GET: /basedata/region/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string regionCode)
        {
            //创建初始化区域实体
            CommonService.Model.C_Region region = new CommonService.Model.C_Region();
            if (!String.IsNullOrEmpty(regionCode))
            {
                region.C_Region_parent = new Guid(regionCode);
            }
            region.C_Region_code = Guid.NewGuid();
            region.C_Region_level = 1;
            region.C_Region_isSpecial = 0;
            region.C_Region_isDelete = 0;
            region.C_Region_creator = Context.UIContext.Current.UserCode;
            region.C_Region_createTime = DateTime.Now;
            if (region.C_Region_parent == null)
            {
                ViewBag.SelectedRegionCode = "";
            }
            else
            {
                ViewBag.SelectedRegionCode = regionCode;
            }

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(region);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string regionCode)
        {
            if (String.IsNullOrEmpty(regionCode) || regionCode=="{regionCode}")
            {
                return RedirectToAction("Create");
            }
            CommonService.Model.C_Region region = _regionWCF.GetModelByCode(new Guid(regionCode));
            ViewBag.SelectedRegionCode = regionCode;

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View("Create", region);
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
        /// 生成区域树Action
        /// </summary>
        /// <returns></returns>
        public ActionResult Tree(int sourceType)
        {
            SetSingleRegion(sourceType);
            ViewBag.SourceType = sourceType;
            return View();
        }

        /// <summary>
        /// 生成区域树Action，单选回调区域树调用
        /// </summary>
        /// <returns></returns>
        public ActionResult NoTargetTree(int sourceType)
        {
            SetSingleRegion(sourceType);
            //ViewBag.SourceType = sourceType;
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,int roleId, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //区域查询模型
            CommonService.Model.C_Region regionConditon = new CommonService.Model.C_Region();

            if (!String.IsNullOrEmpty(form["C_Region_name"]))
            {//区域名称查询条件
                regionConditon.C_Region_name = form["C_Region_name"].Trim(); ;
            }

            //区域查询模型传递到前端视图中
            ViewBag.OrgConditon = regionConditon;

            #endregion

            //获取区域总记录数
            this.TotalRecordCount = _regionWCF.GetRecordCount(regionConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取区域数据信息
            List<CommonService.Model.C_Region> menus = _regionWCF.GetListByPage(regionConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(menus);
        }

        /// <summary>
        /// 多选全部区域Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityRefList(FormCollection form,int roleId,int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Region regConditon = new CommonService.Model.C_Region();
            if (!String.IsNullOrEmpty(form["C_Region_name"]))
            {//联系人名称查询条件
                regConditon.C_Region_name = form["C_Region_name"].Trim();
            }
            regConditon.C_Region_isSpecial = 0;
            ViewBag.RoleId = roleId;

            //联系人查询模型传递到前端视图中
            ViewBag.RegConditon = regConditon;

            this.AddressUrlParameters = "?roleId="+roleId;

            #endregion

            //获取联系人总记录数
            this.TotalRecordCount = _regionWCF.GetRecordCount(regConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Region> contacts = _regionWCF.GetListByPage(regConditon, "C_Region_Id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(contacts);
        }

        /// <summary>
        /// 多选回调区域列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>SingleCallbackRefList
        public ActionResult MulityCallbackRefList(FormCollection form,string selectedRegionCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Region regConditon = new CommonService.Model.C_Region();
            if (!String.IsNullOrEmpty(form["C_Region_name"]))
            {//联系人名称查询条件
                regConditon.C_Region_name = form["C_Region_name"].Trim();
            }
            regConditon.C_Region_isSpecial = 0;
            //联系人查询模型传递到前端视图中
            ViewBag.RegConditon = regConditon;
            ViewBag.selectedRegionCode = selectedRegionCode;
            #endregion

            //获取联系人总记录数
            this.TotalRecordCount = _regionWCF.GetRecordCount(regConditon);
            this.PageSize = 10;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Region> regions = _regionWCF.GetListByPage(regConditon, "C_Region_Id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(regions);
        }
        /// <summary>
        /// 单选回调区域列表(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList_AreaForm(FormCollection form, string lookupgroup, string propertyValueCode, string mappingField, string mappingFieldName, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Region regConditon = new CommonService.Model.C_Region();
            if (!String.IsNullOrEmpty(form["C_Region_name"]))
            {//联系人名称查询条件
                regConditon.C_Region_name = form["C_Region_name"].Trim();
            }
            regConditon.C_Region_isSpecial = 0;
            //联系人查询模型传递到前端视图中
            ViewBag.RegConditon = regConditon;
            #endregion
            #region 参照配置条件
            string _lookupgroup = String.Empty;
            string _propertyValueCode = String.Empty;
            string _mappingField = String.Empty;
            string _mappingFieldName = String.Empty;

            if (!String.IsNullOrEmpty(form["lookupgroup"]))
            {
                _lookupgroup = form["lookupgroup"];
            }
            if (!String.IsNullOrEmpty(form["propertyValueCode"]))
            {
                _propertyValueCode = form["propertyValueCode"];
            }
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
            //获取联系人总记录数
            this.TotalRecordCount = _regionWCF.GetRecordCount(regConditon);
            this.PageSize = 10;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Region> regions = _regionWCF.GetListByPage(regConditon, "C_Region_Id asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(regions);
        }
        /// <summary>
        /// 单选回调区域树
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefTree(int sourceType)
        {
            ViewBag.SourceType = sourceType;
            return View();
        }

        /// <summary>
        /// 区域角色关联
        /// </summary>
        /// <param name="form"></param>
        /// <param name="role">角色ID</param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefNoPageList(FormCollection form,string userCode)
        {
            CommonService.Model.SysManager.C_Userinfo_region regConditon = new CommonService.Model.SysManager.C_Userinfo_region();
            List<CommonService.Model.SysManager.C_Userinfo_region> regions = new List<CommonService.Model.SysManager.C_Userinfo_region>();
            if (!String.IsNullOrEmpty(userCode))
            {//联系人名称查询条件
                regConditon.C_Userinfo_code = new Guid(userCode);
                regions = _userinfo_areaWCF.GetListByPage(regConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, 100);
            }
            else
            {
                List<CommonService.Model.C_Region> regionall = _regionWCF.GetAllList();
                foreach (CommonService.Model.C_Region region in regionall)
                {
                    CommonService.Model.SysManager.C_Userinfo_region role_region = new CommonService.Model.SysManager.C_Userinfo_region();
                    role_region.C_Region_code = region.C_Region_code;
                    role_region.C_Region_name = region.C_Region_name;
                    regions.Add(role_region);
                }
            }
           
            return View(regions);
        }
       /// <summary>
        /// 处理添加或删除角色下区域
       /// </summary>
       /// <param name="role">角色id</param>
       /// <param name="regioncode">区域code</param>
       /// <param name="type">类型（1：添加，2：删除）</param>
       /// <returns></returns>
        public ActionResult Add_region(string userCode,string regioncode,string type)
        {
            CommonService.Model.SysManager.C_Userinfo_region role_region = new CommonService.Model.SysManager.C_Userinfo_region();
            role_region.C_Userinfo_code = new Guid(userCode);
            role_region.C_Region_code = new Guid(regioncode);
            int flag=Convert.ToInt32(type);
            if (flag == 1)//添加新的区域操作
            {
                //查找是否存在该条信息
                if (_userinfo_areaWCF.Exits(role_region))
                    return Json(TipHelper.JsonData("添加关联区域失败，已存在该区域", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                else//不存在，需要添加
                {
                    if (_userinfo_areaWCF.Add(role_region))
                    {
                        return Json(TipHelper.JsonData("添加关联区域成功", "iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
                    }
                    else
                    {
                        return Json(TipHelper.JsonData("添加关联区域失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                    }
                }
            }
            else
            { 
                //删除该角色下的区域信息
                if (_userinfo_areaWCF.Delete(new Guid(userCode), new Guid(regioncode)))
                {
                    return Json(TipHelper.JsonData("删除关联区域成功", "iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
                }
                else
                {
                    return Json(TipHelper.JsonData("删除关联区域失败", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
                }
            }
            return View();
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Region region)
        {
            //服务方法调用
            int regionId = 0;

            if (region.C_Region_Id > 0)
            {//修改
                bool isUpdateSuccess = _regionWCF.Update(region);
                if (isUpdateSuccess)
                {
                    regionId = region.C_Region_Id;
                }
            }
            else
            {//添加
                regionId = _regionWCF.Add(region);
            }

            if (regionId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                return Json(TipHelper.JsonData("保存客户信息成功", ""));//默认仅仅保存
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存区域信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string regionCode)
        {
            bool isSuccess = _regionWCF.Delete(new Guid(regionCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除区域信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除区域信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #region 不含checkbox的区域递归

        /// <summary>
        ///  装载全部区域信息
        /// </summary>
        private void SetSingleRegion(int sourceType)
        {
            List<CommonService.Model.C_Region> regions = _regionWCF.GetAllList();
            SetSingleTopRegion(regions, sourceType);
        }

        /// <summary>
        /// 装载顶级区域
        /// </summary>
        private void SetSingleTopRegion(List<CommonService.Model.C_Region> regionList, int sourceType)
        {
            string regionTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topRegionList = from allList in regionList
                                      where allList.C_Region_level == 1
                                      orderby allList.C_Region_Id ascending
                                      select allList;
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */

            regionTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"\" href=\"\">区域</a>";
            regionTreeHtml += "<ul>";

            foreach (CommonService.Model.C_Region region in topRegionList)
            {
                string href = "";
                switch (sourceType)
                {
                    case 1://区域页面自身调用
                        href = "?{regionCode}=" + region.C_Region_code.Value+"&{regionName}="+region.C_Region_name;
                        break;
                    case 2://Tree CallBack 调用
                        href = "";
                        break;
                }
                string uniqueId = region.C_Region_code.Value.ToString();
                if(sourceType==1)
                {
                    regionTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + region.C_Region_name + "</a>";
                }else if(sourceType==2)
                {
                    regionTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"  callbackjson=\"{'lookupgroup':'regionlookup','Code':'" + region.C_Region_code.Value.ToString() + "','Name':'" + region.C_Region_name + "'}\" >" + region.C_Region_name + "</a>";
                }                
                SetSignleRecursionTree(region.C_Region_code.Value, ref regionTreeHtml, regionList, sourceType);
                regionTreeHtml += "</li>";
            }
            regionTreeHtml += "</ul>";
            regionTreeHtml += "</li>";
            ViewBag.SingleRegionTreeHtml = preTreeHtml + regionTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有区域
        /// </summary>
        private void SetSignleRecursionTree(Guid parentCode, ref string regionTreeHtml, List<CommonService.Model.C_Region> regionList, int sourceType)
        {
            var lowregionList = from allList in regionList
                                      where allList.C_Region_parent == parentCode
                                      orderby allList.C_Region_Id ascending
                                      select allList;
            if (lowregionList.Count() != 0)
            {
                regionTreeHtml += "<ul>";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.C_Region region in lowregionList)
            {
                string href = "";

                switch (sourceType)
                {
                    case 1://区域页面自身调用
                        href = "?{regionCode}=" + region.C_Region_code.Value + "&{regionName}=" + region.C_Region_name;
                        break;

                    case 2://Tree CallBack 调用
                        href = "";
                        break;
                }

                string uniqueId = region.C_Region_code.Value.ToString();
                if (sourceType == 1)
                {
                    regionTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + region.C_Region_name + "</a>";
                }
                else if (sourceType == 2)
                {
                    regionTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"  callbackjson=\"{'lookupgroup':'regionlookup','Code':'" + region.C_Region_code.Value.ToString() + "','Name':'" + region.C_Region_name + "'}\" >" + region.C_Region_name + "</a>";
                }
                SetSignleRecursionTree(region.C_Region_code.Value, ref regionTreeHtml, regionList, sourceType);
                regionTreeHtml += "</li>";
            }
            if (lowregionList.Count() != 0)
            {
                regionTreeHtml += "</ul>";
            }
        }

        #endregion

        /// <summary>
        /// 角色关联区域添加
        /// </summary>
        /// <returns></returns>
        public ActionResult RelationContact(string userCode, string regionCodes)
        {
            bool isSuccess = false;
            string[] region_codes = regionCodes.Split(',');
            if (userCode != null)
            {//关联区域
                for (int i = 0; i < region_codes.Length; i++)
                {
                    if (!String.IsNullOrEmpty(region_codes[i]))
                    {
                        CommonService.Model.SysManager.C_Userinfo_region roleRegion = new CommonService.Model.SysManager.C_Userinfo_region();
                        roleRegion.C_Userinfo_code = new Guid(userCode);
                        roleRegion.C_Region_code = new Guid(region_codes[i]);
                        _userinfo_areaWCF.Add(roleRegion);
                        isSuccess = true;
                    }
                }
            }

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联区域信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联区域信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 获取所有区域
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public ActionResult DistributionRegion(string orgCode, string userCode, string postCode)
        {
            Guid? _orgCode = null;
            Guid? _userCode = null;
            Guid? _postCode = null;

            if (!orgCode.Contains("{orgCode}"))
            {
                _orgCode = new Guid(orgCode);
            }

            if (!userCode.Contains("{userCode}"))
            {
                _userCode = new Guid(userCode);
            }

            if (!postCode.Contains("{postCode}"))
            {
                _postCode = new Guid(postCode);
            }

            List<CommonService.Model.C_Region> regions = _regionWCF.GetAllRegion(_orgCode, _userCode, _postCode);
            return View(regions);
        }
	}
}