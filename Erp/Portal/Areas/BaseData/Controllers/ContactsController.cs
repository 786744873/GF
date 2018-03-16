using CommonService.Common;
using Context;
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
    /// 联系人控制器
    /// </summary>
    public class ContactsController : BaseController
    {
        private readonly ICommonService.IC_Contacts _contactsWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Customer_Contacts _customerContactWCF;
        private readonly ICommonService.IC_Judge _judgeWCF;
        private readonly ICommonService.IC_Involved_projectUnit_person _projectUnit_personWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance_link _businessChance_linkWCF;
        public ContactsController()
        {
            #region 服务初始化
            _contactsWCF = ServiceProxyFactory.Create<ICommonService.IC_Contacts>("ContactsWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _customerContactWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Contacts>("CustomerContactsWCF");
            _judgeWCF = ServiceProxyFactory.Create<ICommonService.IC_Judge>("JudgeWCF");
            _projectUnit_personWCF = ServiceProxyFactory.Create<ICommonService.IC_Involved_projectUnit_person>("Involved_projectUnit_personWCF");
            _businessChance_linkWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance_link>("BusinessChance_linkWCF");
            #endregion
        }
        //
        // GET: /BaseData/Contacts/
        public override ActionResult Index()
        {
            
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string relationCode, int? contactType = 3)
        {
            InitializationPageParameter();
            //创建初始化联系人实体
            CommonService.Model.C_Contacts contacts = new CommonService.Model.C_Contacts();
            contacts.C_Contacts_code = Guid.NewGuid();
            contacts.C_Contacts_number = "";
            contacts.C_Contacts_sex = 1;
            contacts.C_Contacts_is_main = 1;
            contacts.C_Contacts_type = contactType;
            contacts.C_Contacts_birthday = DateTime.Now;
            contacts.C_Contacts_creator = Context.UIContext.Current.UserCode;
            contacts.C_Contacts_createTime = DateTime.Now;
            contacts.C_Contacts_isDelete = 0;
            if (!String.IsNullOrEmpty(relationCode))
            {
                contacts.C_Contacts_relationCode = new Guid(relationCode);
            }
            else
            {
                contacts.C_Contacts_relationCode = Guid.Empty;
            }

            return View(contacts);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string C_Contacts_code)
        {
            InitializationPageParameter();
            CommonService.Model.C_Contacts contacts = _contactsWCF.Get(new Guid(C_Contacts_code));
            return View("Create", contacts);
        }

        /// <summary>
        /// 联系人详细tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string C_Contacts_code, int? type)
        {
            ViewBag.C_Contacts_code = C_Contacts_code;
            ViewBag.type = type;
            return View();
        }


        /// <summary>
        /// 联系人信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string C_Contacts_code)
        {
            CommonService.Model.C_Contacts contacts = _contactsWCF.Get(new Guid(C_Contacts_code));
            InitializationPageParameter(contacts);
            return View(contacts);
        }

        /// <summary>
        /// 全部联系人列表或者根据对应关联表关联的联系人列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relationCode">关联表Guid</param>
        /// <param name="contactType">联系人类型</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string relationCode, int? contactType = 3, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Contacts conConditon = new CommonService.Model.C_Contacts();
            conConditon.C_Contacts_type = contactType;
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
            //
            if (!String.IsNullOrEmpty(form["C_Contacts_mobile"]))
            {//联系人移动电话查询条件
                conConditon.C_Contacts_mobile =form["C_Contacts_mobile"].Trim();
            }
            if (conConditon.C_Contacts_type == null)
            {
                conConditon.C_Contacts_type = contactType;
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

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(contacts);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relationCode">关联表Guid</param>
        /// <param name="contactType">联系人类型</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string relationCode, int? contactType = 3, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Contacts conConditon = new CommonService.Model.C_Contacts();
            conConditon.C_Contacts_type = contactType;
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
            if (conConditon.C_Contacts_type == null)
            {
                conConditon.C_Contacts_type = contactType;
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
        /// 多选全部联系人Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityRefList(FormCollection form, string relationCode, int? contactType = 3, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Contacts conConditon = new CommonService.Model.C_Contacts();
            conConditon.C_Contacts_type = contactType;
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
            if (conConditon.C_Contacts_type == null)
            {
                conConditon.C_Contacts_type = contactType;
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

            if (!String.IsNullOrEmpty(relationCode))
            {
                string contactsStr = "";
                List<CommonService.Model.C_Contacts> contact = _contactsWCF.GetListByRelationAndType(conConditon);
                foreach (CommonService.Model.C_Contacts con in contact)
                {
                    contactsStr += con.C_Contacts_code + ",";
                }
                ViewBag.Contacts_code = contactsStr == "" ? contactsStr : contactsStr.Substring(0, contactsStr.Length - 1);
            }

            //联系人类型Url条件
            this.AddressUrlParameters = "?contactType=" + conConditon.C_Contacts_type;
            //关联Guid Url条件
            this.AddressUrlParameters = this.AddressUrlParameters + "&relationCode=" + conConditon.C_Contacts_relationCode;

            //联系人查询模型传递到前端视图中
            ViewBag.ConConditon = conConditon;
            ViewBag.C_Contacts_type = conConditon.C_Contacts_type;
            ViewBag.C_Contacts_relationCode = conConditon.C_Contacts_relationCode;

            conConditon.C_Contacts_type = 3;//默认联系人类型
            conConditon.C_Contacts_relationCode = null;

            #endregion

            //获取联系人总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(conConditon);
            this.PageSize = 10;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts> contacts = _contactsWCF.GetListByPage(conConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(contacts);
        }

        /// <summary>
        /// 单选全部联系人Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relationCode"></param>
        /// <param name="contactType"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleRefList(FormCollection form, string relationCode, int? contactType, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Contacts conConditon = new CommonService.Model.C_Contacts();
            conConditon.C_Contacts_type = contactType;
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
            if (conConditon.C_Contacts_type == null)
            {
                conConditon.C_Contacts_type = contactType;
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
            ViewBag.JudConditon = conConditon;
            ViewBag.C_Contacts_type = conConditon.C_Contacts_type;
            ViewBag.C_Contacts_relationCode = conConditon.C_Contacts_relationCode;

            conConditon.C_Contacts_type = 3;//默认联系人类型
            conConditon.C_Contacts_relationCode = null;

            #endregion

            //获取联系人总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(conConditon);
            this.PageSize = 10;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts> contacts = _contactsWCF.GetListByPage(conConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(contacts);
        }

        /// <summary>
        /// 单选全部联系人列表Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relationCode"></param>
        /// <param name="contactType"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人查询模型
            CommonService.Model.C_Contacts conConditon = new CommonService.Model.C_Contacts();
            conConditon.C_Contacts_type = 3;
            if (!String.IsNullOrEmpty(form["C_Contacts_name"]))
            {//联系人名称查询条件
                conConditon.C_Contacts_name = form["C_Contacts_name"].Trim();
            }

            //联系人查询模型传递到前端视图中
            ViewBag.conConditon = conConditon;

            #endregion

            //获取联系人总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(conConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;

            List<CommonService.Model.C_Contacts> contacts = _contactsWCF.GetListByPage(conConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(contacts);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Contacts contacts)
        {
            //服务方法调用
            int contactsId = 0;

            if (contacts.C_Contacts_id > 0)
            {//修改
                bool isUpdateSuccess = _contactsWCF.Update(contacts);
                if (isUpdateSuccess)
                {
                    contactsId = contacts.C_Contacts_id;
                }
            }
            else
            {//添加
                contacts.C_Contacts_createTime = DateTime.Now;
                contactsId = _contactsWCF.Add(contacts);
                #region hety,2015-05-04,添加时，这里根据联系人类型，处理不同的业务逻辑
                if (contactsId > 0)
                {
                    switch (contacts.C_Contacts_type.Value)
                    {
                        case 2://客户联系人
                            CommonService.Model.C_Customer_Contacts customerContact = new CommonService.Model.C_Customer_Contacts();
                            customerContact.C_Customer_Contacts_contact = contacts.C_Contacts_code;
                            customerContact.C_Customer_Contacts_customer = contacts.C_Contacts_relationCode;
                            customerContact.C_Customer_Contacts_creator = Context.UIContext.Current.UserCode;
                            customerContact.C_Customer_Contacts_createTime = DateTime.Now;
                            customerContact.C_Customer_Contacts_isDelete = false;
                            _customerContactWCF.Add(customerContact);
                            break;
                        case 3://默认联系人
                            break;
                        case 4://法官联系人
                            break;
                        case 6://商机联系人
                            CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChanceLink = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                            businessChanceLink.B_BusinessChance_code = contacts.C_Contacts_relationCode;
                            businessChanceLink.C_FK_code = contacts.C_Contacts_code;
                            businessChanceLink.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.联系人);
                            businessChanceLink.B_BusinessChance_link_creator = Context.UIContext.Current.UserCode;
                            businessChanceLink.B_BusinessChance_link_createTime = DateTime.Now;
                            businessChanceLink.B_BusinessChance_link_isDelete = 0;
                            _businessChance_linkWCF.Add(businessChanceLink);
                            break;
                        default:
                            break;
                    }
                }
                #endregion
            }

            if (contactsId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存联系人信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存联系人信息成功", "/BaseData/contacts/create?relationCode=" + contacts.C_Contacts_relationCode + "&contactType=" + contacts.C_Contacts_type, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存联系人信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存联系人信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="C_Contacts_code">联系人Guid</param>
        /// <param name="relationCode">关联表Guid</param>
        /// <param name="contactType">联系人类型</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string C_Contacts_code, string relationCode, int contactType)
        {
            bool isSuccess = _contactsWCF.Delete(new Guid(C_Contacts_code), new Guid(relationCode), contactType);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除联系人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除联系人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 关联联系人添加
        /// </summary>
        /// <param name="c_Contacts_codes">联系人Guid串，用逗号隔开</param>
        /// <returns></returns>
        public ActionResult RelationContact(string c_Contacts_codes, string relationCode, int? contactType = 3)
        {
            bool isSuccess = false;
            string[] contact_codes = c_Contacts_codes.Split(',');
            if (contactType == 2 && relationCode != Guid.Empty.ToString())
            {//关联客户
                for (int i = 0; i < contact_codes.Length; i++)
                {
                    if (!String.IsNullOrEmpty(contact_codes[i]))
                    {
                        CommonService.Model.C_Customer_Contacts customerContact = new CommonService.Model.C_Customer_Contacts();
                        customerContact.C_Customer_Contacts_contact = new Guid(contact_codes[i]);
                        customerContact.C_Customer_Contacts_customer = new Guid(relationCode);
                        customerContact.C_Customer_Contacts_creator = Context.UIContext.Current.UserCode;
                        customerContact.C_Customer_Contacts_createTime = DateTime.Now;
                        customerContact.C_Customer_Contacts_isDelete = false;
                        _customerContactWCF.Add(customerContact);
                        isSuccess = true;
                    }
                }
            }
            else if (contactType == 5 && relationCode != Guid.Empty.ToString())
            {//关联涉案工程人
                for (int i = 0; i < contact_codes.Length; i++)
                {
                    if (!String.IsNullOrEmpty(contact_codes[i]))
                    {
                        CommonService.Model.C_Involved_projectUnit_person personContact = new CommonService.Model.C_Involved_projectUnit_person();
                        personContact.C_Involved_projectUnit_person_contacts = new Guid(contact_codes[i]);
                        personContact.C_Involved_projectUnit_code = new Guid(relationCode);
                        personContact.C_Involved_projectUnit_person_creator = Context.UIContext.Current.UserCode;
                        personContact.C_Involved_projectUnit_person_createTime = DateTime.Now;
                        personContact.C_Involved_projectUnit_person_isDelete = 0;
                        _projectUnit_personWCF.Add(personContact);
                        isSuccess = true;
                    }
                }
            }
            else if (contactType == 6 && relationCode != Guid.Empty.ToString())
            {//关联商机联系人
                for (int i = 0; i < contact_codes.Length; i++)
                {
                    if (!String.IsNullOrEmpty(contact_codes[i]))
                    {
                        CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChanceLink = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                        businessChanceLink.B_BusinessChance_code = new Guid(relationCode);
                        businessChanceLink.C_FK_code = new Guid(contact_codes[i]);
                        businessChanceLink.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.联系人);
                        businessChanceLink.B_BusinessChance_link_creator = Context.UIContext.Current.UserCode;
                        businessChanceLink.B_BusinessChance_link_createTime = DateTime.Now;
                        businessChanceLink.B_BusinessChance_link_isDelete = 0;
                        _businessChance_linkWCF.Add(businessChanceLink);
                        isSuccess = true;
                    }
                }
            }


            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联联系人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联联系人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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
            //民族参数集合
            List<CommonService.Model.C_Parameters> Contacts_nation = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ContactsEnum.民族));
            ViewBag.Contacts_nation = Contacts_nation;
            //政治面貌参数集合
            List<CommonService.Model.C_Parameters> Contacts_political = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ContactsEnum.政治面貌));
            ViewBag.Contacts_political = Contacts_political;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="crival">个人对象</param>
        private void InitializationPageParameter(CommonService.Model.C_Contacts contacts)
        {
            //民族参数集合
            CommonService.Model.C_Parameters Contacts_nation = contacts.C_Contacts_nation == null ? null : _parameterWCF.GetModel(contacts.C_Contacts_nation.Value);
            ViewBag.Contacts_nation = Contacts_nation;
            //政治面貌参数集合
            CommonService.Model.C_Parameters Contacts_political = contacts.C_Contacts_political == null ? null : _parameterWCF.GetModel(contacts.C_Contacts_political.Value);
            ViewBag.Contacts_political = Contacts_political;
        }

        /// <summary>
        /// 关联联系人添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact(string Contacts_codes, int? contactType)
        {
            int judgeId = 0;
            if (contactType == 4)
            {
                if (_judgeWCF.Exists(new Guid(Contacts_codes)))
                {
                    return Json(TipHelper.JsonData("该法官信息已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else
                {
                    CommonService.Model.C_Judge judgeContact = new CommonService.Model.C_Judge();
                    judgeContact.C_Judge_code = Guid.NewGuid();
                    judgeContact.C_Judge_contactscode = new Guid(Contacts_codes);
                    judgeContact.C_Judge_creator = Context.UIContext.Current.UserCode;
                    judgeContact.C_Judge_createTime = DateTime.Now;
                    judgeContact.C_Judge_isdelete = false;
                    judgeId = _judgeWCF.Add(judgeContact);
                }
            }
            else if (contactType == 5)
            { }

            if (judgeId > 0)
            {//成功
                return Json(TipHelper.JsonData("关联联系人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联联系人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
    }
}