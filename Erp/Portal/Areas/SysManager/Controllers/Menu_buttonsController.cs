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
    /// 菜单按钮控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/26
    /// </summary>
    public class Menu_buttonsController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Menu_buttons _menu_buttonsWCF;
        private readonly ICommonService.SysManager.IC_Role_button _role_buttonWCF;

        public Menu_buttonsController()
        {
            #region 服务初始化
            _menu_buttonsWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Menu_buttons>("menu_buttonsWCF");
            _role_buttonWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_button>("Role_buttonWCF");
            #endregion
        }
        //
        // GET: /SysManager/Menu_buttons/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int menuId)
        {
            //创建初始化菜单实体
            CommonService.Model.SysManager.C_Menu_buttons buttons = new CommonService.Model.SysManager.C_Menu_buttons();
            buttons.C_Menu_id = menuId;
            buttons.C_Menu_buttons_order = 0;
            buttons.C_Menu_buttons_isdelete = 0;
            buttons.C_Menu_buttons_creator = Context.UIContext.Current.UserCode;
            buttons.C_Menu_buttons_createTime = DateTime.Now;
            return View(buttons);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int menu_buttonsId)
        {
            CommonService.Model.SysManager.C_Menu_buttons buttons = _menu_buttonsWCF.GetModel(menu_buttonsId);
            return View("Create", buttons);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int menuId, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //菜单查询模型
            CommonService.Model.SysManager.C_Menu_buttons butConditon = new CommonService.Model.SysManager.C_Menu_buttons();

            if (!String.IsNullOrEmpty(form["C_Menu_buttons_name"]))
            {//菜单名称查询条件
                butConditon.C_Menu_buttons_name = form["C_Menu_buttons_name"].Trim(); ;
            }
            if(menuId!=null)
            {
                butConditon.C_Menu_id = menuId;
            }

            //菜单查询模型传递到前端视图中
            ViewBag.ButConditon = butConditon;

            #endregion

            //获取菜单总记录数
            this.TotalRecordCount = _menu_buttonsWCF.GetRecordCount(butConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取菜单数据信息
            List<CommonService.Model.SysManager.C_Menu_buttons> buttons = _menu_buttonsWCF.GetListByPage(butConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(buttons);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuRelationButtonsList(int? menuId)
        {
            int Menu_id=0;
            if(menuId!=null)
            {
                Menu_id =int.Parse(menuId.ToString());
            }
            List<CommonService.Model.SysManager.C_Menu_buttons> menu_buttons = _menu_buttonsWCF.GetListByMenuId(Menu_id);
            return View(menu_buttons);
        }

        /// <summary>
        /// 多选全部按钮Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityRefList(FormCollection form,int roleId, int? menuId, int? page = 1)
        {
            int C_Menu_id = 0;
            if (menuId != null)
            {//角色ID查询条件
                C_Menu_id = (int)menuId;
            }

            List<CommonService.Model.SysManager.C_Menu_buttons> contacts = _menu_buttonsWCF.GetListByMenuId(C_Menu_id);
            return View(contacts);
        }

        


        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form,CommonService.Model.SysManager.C_Menu_buttons buttons)
        {
            //服务方法调用
            int menu_buttonsId = 0;

            if (buttons.C_Menu_buttons_id > 0)
            {//修改
                bool isUpdateSuccess = _menu_buttonsWCF.Update(buttons);
                if (isUpdateSuccess)
                {
                    menu_buttonsId = buttons.C_Menu_buttons_id;
                }
            }
            else
            {//添加
                menu_buttonsId = _menu_buttonsWCF.Add(buttons);
            }

            if (menu_buttonsId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存菜单按钮信息成功", "iframe_buttons", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshIframeChildren));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存菜单按钮信息成功", "/sysmanager/menu_buttons/create?menuId="+buttons.C_Menu_id, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存菜单按钮信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存菜单按钮信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="organizationCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int menu_buttonsId)
        {
            bool isSuccess = _menu_buttonsWCF.Delete(menu_buttonsId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除菜单按钮信息成功！", "iframe_buttons", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除菜单按钮信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 关联按钮添加
        /// </summary>
        /// <returns></returns>
        public ActionResult RelationContact(int? roleId, string menubuttonIds)
        {
            bool isSuccess = false;
            string[] menu_button_ids = menubuttonIds.Split(',');
            if (roleId != null)
            {//关联按钮
                for (int i = 0; i < menu_button_ids.Length; i++)
                {
                    if (!String.IsNullOrEmpty(menu_button_ids[i]))
                    {
                        CommonService.Model.SysManager.C_Role_button roleButton = new CommonService.Model.SysManager.C_Role_button();
                        roleButton.C_Roles_id = roleId;
                        roleButton.C_Menu_buttons_id = int.Parse(menu_button_ids[i]);

                        isSuccess = _role_buttonWCF.Add(roleButton); 
                    }
                }
            }


            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联按钮信息成功！", "iframe_allocatedBtnList", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联按钮信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}