using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.SysManager.Controllers
{
    /// <summary>
    /// 角色控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/28
    /// </summary>
    public class RolesController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Roles _rolesWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_case_type _userinfo_case_typeWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        public RolesController()
        {
            #region 服务初始化
            _rolesWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Roles>("RolesWCF");
            _userinfo_case_typeWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_case_type>("Userinfo_case_typeWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            #endregion
        }
        //
        // GET: /SysManager/Roles/
        public ActionResult Index()
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
            //创建初始化角色实体
            CommonService.Model.SysManager.C_Roles role = new CommonService.Model.SysManager.C_Roles();
            role.C_Roles_isDelete = false;
            role.C_Roles_creator = Context.UIContext.Current.UserCode;
            role.C_Roles_createTime = DateTime.Now;
            return View(role);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int Roles_id)
        {
            CommonService.Model.SysManager.C_Roles role = _rolesWCF.GetModel(Roles_id);
            return View("Create", role);
        }

        /// <summary>
        /// 菜单按钮布局结构Action
        /// </summary>
        /// <returns></returns>
        public ActionResult DefaultLayout(int? roleId)
        {
            ViewBag.roleId = roleId;
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

            //角色查询模型
            CommonService.Model.SysManager.C_Roles roleConditon = new CommonService.Model.SysManager.C_Roles();

            if (!String.IsNullOrEmpty(form["C_Roles_name"]))
            {//角色名称查询条件
                roleConditon.C_Roles_name = form["C_Roles_name"].Trim(); ;
            }

            //角色查询模型传递到前端视图中
            ViewBag.RoleConditon = roleConditon;

            #endregion

            //获取角色总记录数
            this.TotalRecordCount = _rolesWCF.GetRecordCount(roleConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取角色数据信息
            List<CommonService.Model.SysManager.C_Roles> menus = _rolesWCF.GetListByPage(roleConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(menus);
        }
        /// <summary>
        /// 列表>无分页/无查询
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult RolesListNoPage(string roleCode, string opcreatype)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)
            List<CommonService.Model.SysManager.C_Roles> menus = new List<CommonService.Model.SysManager.C_Roles>();
            if (opcreatype.Equals("{opcreatype}"))
            {
                menus= null;
            }
            string[] post_codes = null;
            if (!string.IsNullOrEmpty(roleCode))
                post_codes = roleCode.Split(',');
            if (post_codes.Length >= 2 && (!string.IsNullOrEmpty(post_codes[2])))//角色id如果不为空
            {
                ViewBag.roleCode = post_codes[2];
            }
            #endregion

            //获取角色数据信息
            menus = _rolesWCF.GetAllList();
            return View(menus);
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <returns></returns>
        public ActionResult AllList(FormCollection form)
        {
            //角色查询模型
            CommonService.Model.SysManager.C_Roles roleConditon = new CommonService.Model.SysManager.C_Roles();

            if (!String.IsNullOrEmpty(form["C_Roles_name"]))
            {//角色名称查询条件
                roleConditon.C_Roles_name = form["C_Roles_name"].Trim(); ;
            }

            //角色查询模型传递到前端视图中
            ViewBag.RoleConditon = roleConditon;
            List<CommonService.Model.SysManager.C_Roles> menus = _rolesWCF.GetAllList();
            return View(menus);
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.SysManager.C_Roles menu)
        {
            //服务方法调用
            int menuId = 0;

            if (menu.C_Roles_id > 0)
            {//修改
                bool isUpdateSuccess = _rolesWCF.Update(menu);
                if (isUpdateSuccess)
                {
                    menuId = menu.C_Roles_id;
                }
            }
            else
            {//添加
                menuId = _rolesWCF.Add(menu);
            }

            if (menuId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存角色信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存角色信息成功", "/sysmanager/roles/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存角色信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存角色信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Roles_id)
        {
            bool isSuccess = _rolesWCF.Delete(Roles_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除角色信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除角色信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.Case_type = Case_type;
        }
        /// <summary>
        /// 角色管理
        /// </summary>
        /// <param name="Userinfo_code">用户code</param>
        /// <returns></returns>
        public ActionResult RoleManager(string Userinfo_code)
        {
            Guid usercode = Guid.Empty;
            if (!Userinfo_code.Equals("{sid_Iterm}"))
            {
                usercode = new Guid(Userinfo_code);
            }
            ViewBag.usercode = usercode;
            return View();
        }
       
        /// <summary>
        /// 处理角色管理角色变换事件
        /// </summary>
        /// <param name="orgcodeAndpostCodeAndrolecode">组织机构Code岗位Code角色Code</param>
        /// <param name="newRoleCode">新角色Code</param>
        /// <param name="userCode">用户父级Code</param>
        /// <returns></returns>
        public ActionResult RoleDistribution(string orgcodeAndpostCodeAndrolecode, string newRoleCode, string userCode)
        {
            string[] codesString = null;
            if (!orgcodeAndpostCodeAndrolecode.Equals("{orgcodeAndpostCodeAndrolecode}"))
                codesString = orgcodeAndpostCodeAndrolecode.Split(',');
            else
            {
                return Json(TipHelper.JsonData("请选择组织岗位信息！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            int? RoleCode=null;
            if ((!newRoleCode.Equals("undefined")) && (!string.IsNullOrEmpty(newRoleCode)))
                RoleCode = Convert.ToInt32(newRoleCode);
            else
                return Json(TipHelper.JsonData("角色分配失败！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));

            //int? oldRoleCode;
            Guid orgCode = new Guid();
            Guid postCode = new Guid();
            if (!string.IsNullOrEmpty(codesString[0]))
                orgCode = new Guid(codesString[0]);//组织机构guid
            if (!string.IsNullOrEmpty(codesString[1]))
                postCode = new Guid(codesString[1]);//岗位guid
            //if (!string.IsNullOrEmpty(codesString[2]))
            //    oldRoleCode = Convert.ToInt32(codesString[2]);//旧角色guid
            Guid UserCode = Guid.Empty;
            if (!userCode.Equals("{userCode}"))
            {
                UserCode = new Guid(userCode);//用户GUID
            }
            CommonService.Model.SysManager.C_Userinfo userInfo = new CommonService.Model.SysManager.C_Userinfo();
            userInfo = _userinfoWCF.GetUsersByOrgAndPostChirld(orgCode, postCode, UserCode)[0];//得到此用户实体
            userInfo.C_Userinfo_roleID = RoleCode;
            if (_userinfoWCF.Update(userInfo))
            {
                return Json(TipHelper.JsonData("角色分配成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {
                return Json(TipHelper.JsonData("角色分配失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public ActionResult DistributionRole(string orgCode, string userCode, string postCode)
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

            List<CommonService.Model.SysManager.C_Roles> roles = _rolesWCF.GetAllRoles(_orgCode, _userCode, _postCode);
            return View(roles);
        }
    }
}