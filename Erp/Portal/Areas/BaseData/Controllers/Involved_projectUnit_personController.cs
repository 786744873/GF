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
    /// 涉案工程人控制器
    ///  作者：崔慧栋
    /// 日期：2015/05/14
    /// </summary>
    public class Involved_projectUnit_personController : BaseController
    {
        private readonly ICommonService.IC_Involved_projectUnit_person _projectUnit_personWCF;
        private readonly ICommonService.IC_Contacts _contactsWCF;
         public Involved_projectUnit_personController()
        {
            #region 服务初始化
            _projectUnit_personWCF = ServiceProxyFactory.Create<ICommonService.IC_Involved_projectUnit_person>("Involved_projectUnit_personWCF");
            _contactsWCF = ServiceProxyFactory.Create<ICommonService.IC_Contacts>("ContactsWCF");
            #endregion
        }
        //
        // GET: /BaseData/Involved_projectUnit_person/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string Involved_projectUnit_code)
        {
            //创建初始化涉案工程人实体
            CommonService.Model.C_Involved_projectUnit_person projectUnit_person = new CommonService.Model.C_Involved_projectUnit_person();
            if (!String.IsNullOrEmpty(Involved_projectUnit_code))
            {
                projectUnit_person.C_Involved_projectUnit_code = new Guid(Involved_projectUnit_code);
            }
            projectUnit_person.C_Involved_projectUnit_person_creator = Context.UIContext.Current.UserCode;
            projectUnit_person.C_Involved_projectUnit_person_createTime = DateTime.Now;
            projectUnit_person.C_Involved_projectUnit_person_isDelete = 0;

            return View(projectUnit_person);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int projectUnit_person_id)
        {
            CommonService.Model.C_Involved_projectUnit_person projectUnit_person = _projectUnit_personWCF.GetModel(projectUnit_person_id);
            return View("Create", projectUnit_person);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relationCode"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string relationCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Contacts conConditon = new CommonService.Model.C_Contacts();
            conConditon.C_Contacts_type = 5;
            if (!String.IsNullOrEmpty(form["C_Contacts_name"]))
            {//联系人名称查询条件
                conConditon.C_Contacts_name = form["C_Contacts_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Contacts_type"]))
            {//联系人类型查询条件
                conConditon.C_Contacts_type = Convert.ToInt32(form["C_Contacts_type"].Trim());
            }
            if (!String.IsNullOrEmpty(form["C_Contacts_relationCode"]))
            {//关联表Guid查询条件
                conConditon.C_Contacts_relationCode = new Guid(form["C_Contacts_relationCode"].Trim());
            }
            if (conConditon.C_Contacts_relationCode == null)
            {
                if (String.IsNullOrEmpty(relationCode))
                {
                    conConditon.C_Contacts_relationCode = Guid.Empty;
                }
                else
                {
                    conConditon.C_Contacts_relationCode = new Guid(relationCode);
                }
            }

            //联系人类型Url条件
            this.AddressUrlParameters = "?contactType=" + conConditon.C_Contacts_type;
            //关联Guid Url条件
            this.AddressUrlParameters = this.AddressUrlParameters + "&relationCode=" + conConditon.C_Contacts_relationCode;

            //联系人查询模型传递到前端视图中
            ViewBag.ConConditon = conConditon;

            #endregion

            //获取联系人总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(conConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts> contacts = _contactsWCF.GetListByPage(conConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(contacts);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relationCode"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string relationCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Contacts conConditon = new CommonService.Model.C_Contacts();
            conConditon.C_Contacts_type = 5;
            if (!String.IsNullOrEmpty(form["C_Contacts_name"]))
            {//联系人名称查询条件
                conConditon.C_Contacts_name = form["C_Contacts_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Contacts_type"]))
            {//联系人类型查询条件
                conConditon.C_Contacts_type = Convert.ToInt32(form["C_Contacts_type"].Trim());
            }
            if (!String.IsNullOrEmpty(form["C_Contacts_relationCode"]))
            {//关联表Guid查询条件
                conConditon.C_Contacts_relationCode = new Guid(form["C_Contacts_relationCode"].Trim());
            }
            if (conConditon.C_Contacts_relationCode == null)
            {
                if (String.IsNullOrEmpty(relationCode))
                {
                    conConditon.C_Contacts_relationCode = Guid.Empty;
                }
                else
                {
                    conConditon.C_Contacts_relationCode = new Guid(relationCode);
                }
            }

            //联系人类型Url条件
            this.AddressUrlParameters = "?contactType=" + conConditon.C_Contacts_type;
            //关联Guid Url条件
            this.AddressUrlParameters = this.AddressUrlParameters + "&relationCode=" + conConditon.C_Contacts_relationCode;

            //联系人查询模型传递到前端视图中
            ViewBag.ConConditon = conConditon;

            #endregion

            //获取联系人总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(conConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts> contacts = _contactsWCF.GetListByPage(conConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(contacts);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(CommonService.Model.C_Involved_projectUnit_person projectUnit_person)
        {
            //服务方法调用
            int personId = 0;

            if (projectUnit_person.C_Involved_projectUnit_person_id > 0)
            {//修改
                bool isUpdateSuccess = _projectUnit_personWCF.Update(projectUnit_person);
                if (isUpdateSuccess)
                {
                    personId = projectUnit_person.C_Involved_projectUnit_person_id;
                }
            }
            else
            {//添加
                projectUnit_person.C_Involved_projectUnit_person_createTime = DateTime.Now;
                personId = _projectUnit_personWCF.Add(projectUnit_person);
            }

            if (personId > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存涉案工程人信息成功", ""));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存涉案工程人信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string Contacts_code)
        {
            bool isSuccess = _projectUnit_personWCF.Delete(new Guid(Contacts_code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除涉案工程人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除涉案工程人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}