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
    /// 用户--案件类型控制器
    /// 作者：崔慧栋
    /// 日期：2015/06/01
    /// </summary>
    public class Userinfo_case_typeController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Roles _rolesWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_case_type _userinfo_case_typeWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public Userinfo_case_typeController()
        {
            #region 服务初始化
            _rolesWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Roles>("RolesWCF");
            _userinfo_case_typeWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_case_type>("Userinfo_case_typeWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /SysManager/Role_case_type/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string userCode)
        {
            InitializationPageParameter();
            //创建初始化菜单实体
            CommonService.Model.SysManager.C_Userinfo_case_type role_case_type = new CommonService.Model.SysManager.C_Userinfo_case_type();
            role_case_type.C_Userinfo_code = new Guid(userCode);
            return View(role_case_type);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string userCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)
            //查询模型
            string[] userCodes = userCode.Split(',');
            ViewBag.rctConditon = userCodes[0];

            #endregion
            return View();
        }
        /// <summary>
        /// 角色区域关联处理
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="casecode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult Add_casetype(string userCode, string casecode, string type)
        {
            if (type == "1")//增加一个关联案件类型
            {
                CommonService.Model.SysManager.C_Userinfo_case_type role_case_type = new CommonService.Model.SysManager.C_Userinfo_case_type();
                role_case_type.C_Userinfo_code = new Guid(userCode);
                role_case_type.C_Parameters_id = Convert.ToInt32(casecode);
                if (_userinfo_case_typeWCF.Exits(role_case_type))
                {
                    return Json(TipHelper.JsonData("添加关联案件类型失败,已存在", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else
                {
                    if (_userinfo_case_typeWCF.Add(role_case_type))
                    {
                        return Json(TipHelper.JsonData("添加关联案件类型成功", "iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
                    }
                    else
                    {
                        return Json(TipHelper.JsonData("添加关联案件类型失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                    }
                }
            }
            else//删除一个关联案件类型
            {
                if (_userinfo_case_typeWCF.Delete(new Guid(userCode), Convert.ToInt32(casecode)))
                {
                    return Json(TipHelper.JsonData("删除关联案件类型成功", "iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
                }
                else
                {
                    return Json(TipHelper.JsonData("删除关联案件类型失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }

            }
            return View();
        }
        /// <summary>
        /// 案件列表(无分页)
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefNoPageList(string userCode)
        {
            List<CommonService.Model.SysManager.C_Userinfo_case_type> role_caseitems = new List<CommonService.Model.SysManager.C_Userinfo_case_type>();
            CommonService.Model.SysManager.C_Userinfo_case_type role_case_type = new CommonService.Model.SysManager.C_Userinfo_case_type();
            if (!string.IsNullOrEmpty(userCode))
            {
                role_case_type.C_Userinfo_code = new Guid(userCode);
                //已分配列表
                role_caseitems = _userinfo_case_typeWCF.GetListByPage(role_case_type, "", (this.ThisPageIndex - 1) * this.PageSize + 1, 100);
            }
            else
            { //全部案件类型列表
                List<CommonService.Model.C_Parameters> parmeters = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
                foreach (CommonService.Model.C_Parameters parmeter in parmeters)
                {
                    CommonService.Model.SysManager.C_Userinfo_case_type role_case=new CommonService.Model.SysManager.C_Userinfo_case_type();
                    role_case.C_Parameters_id = parmeter.C_Parameters_id;
                    role_case.C_Parameters_name = parmeter.C_Parameters_name;
                    role_caseitems.Add(role_case);
                }
               
            }
            return View(role_caseitems);
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(CommonService.Model.SysManager.C_Userinfo_case_type role_case_type)
        {
            //服务方法调用
            bool isSuccess = true;
            //添加
            isSuccess = _userinfo_case_typeWCF.Add(role_case_type);


            if (isSuccess)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存关联案件类型信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存关联案件类型信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string userCode, int parametersId)
        {
            bool isSuccess = _userinfo_case_typeWCF.Delete(new Guid(userCode), parametersId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除关联案件类型信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除关联案件类型信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
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
    }
}