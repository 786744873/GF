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
    /// 联系人教育背景控制器
    /// </summary>
    public class Contacts_educationController : BaseController
    {
        private readonly ICommonService.IC_Contacts_education _contacts_educationWCF;

        public Contacts_educationController()
        {
            #region 服务初始化
            _contacts_educationWCF = ServiceProxyFactory.Create<ICommonService.IC_Contacts_education>("Contacts_educationWCF");
            #endregion
        }
        //
        // GET: /BaseData/Contacts_education/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string C_Contacts_code)
        {
            //创建初始化联系人教育背景实体
            CommonService.Model.C_Contacts_education education = new CommonService.Model.C_Contacts_education();
            education.C_Contacts_code =new Guid(C_Contacts_code);
            education.C_Contacts_education_graduation_date = DateTime.Now;
            education.C_Contacts_education_creator = Context.UIContext.Current.UserCode;
            education.C_Contacts_education_createTime = DateTime.Now;
            education.C_Contacts_education_isDelete = 0;
            return View(education);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int C_Contacts_education_id)
        {
            CommonService.Model.C_Contacts_education parameter = _contacts_educationWCF.GetModel(C_Contacts_education_id);
            return View("Create", parameter);
        }

        public ActionResult List(FormCollection form,string C_Contacts_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //联系人教育背景查询模型
            CommonService.Model.C_Contacts_education eduConditon = new CommonService.Model.C_Contacts_education();

            if (!String.IsNullOrEmpty(C_Contacts_code))
            {//联系人名称查询条件
                eduConditon.C_Contacts_code = new Guid(C_Contacts_code);
                this.AddressUrlParameters = "?C_Contacts_code=" + eduConditon.C_Contacts_code;
            }

            // 教育背景查询模型传递到前端视图中
            ViewBag.EduConditon = eduConditon;
            #endregion

            //获取教育背景总记录数
            this.TotalRecordCount = _contacts_educationWCF.GetRecordCount(eduConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts_education> education = _contacts_educationWCF.GetListByPage(eduConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(education);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string C_Contacts_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //教育背景查询模型
            CommonService.Model.C_Contacts_education eduConditon = new CommonService.Model.C_Contacts_education();

            if (!String.IsNullOrEmpty(C_Contacts_code))
            {//联系人名称查询条件
                eduConditon.C_Contacts_code = new Guid(C_Contacts_code);
                this.AddressUrlParameters = "?C_Contacts_code=" + eduConditon.C_Contacts_code;
            }

            //教育背景查询模型传递到前端视图中
            ViewBag.EduConditon = eduConditon;

            #endregion

            //获取教育背景总记录数
            this.TotalRecordCount = _contacts_educationWCF.GetRecordCount(eduConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Contacts_education> education = _contacts_educationWCF.GetListByPage(eduConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(education);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Contacts_education education)
        {
            //服务方法调用
            int educationId = 0;

            if (education.C_Contacts_education_id > 0)
            {//修改
                bool isUpdateSuccess = _contacts_educationWCF.Update(education);
                if (isUpdateSuccess)
                {
                    educationId = education.C_Contacts_education_id;
                }
            }
            else
            {//添加
                education.C_Contacts_education_createTime = DateTime.Now;
                educationId = _contacts_educationWCF.Add(education);
            }

            if (educationId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存联系人教育背景信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存联系人教育背景信息成功", "/basedata/Contacts_education/create?C_Contacts_code="+education.C_Contacts_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存联系人教育背景信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存联系人教育背景信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int C_Contacts_education_id)
        {
            bool isSuccess = _contacts_educationWCF.Delete(C_Contacts_education_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除联系人教育背景信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除联系人教育背景信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}