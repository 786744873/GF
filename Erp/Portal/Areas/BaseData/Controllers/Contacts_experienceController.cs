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
    /// 联系人工作经历控制器
    /// </summary>
    public class Contacts_experienceController : BaseController
    {
        private readonly ICommonService.IC_Contacts_experience _contacts_experienceWCF;

         public Contacts_experienceController()
        {
            #region 服务初始化
            _contacts_experienceWCF = ServiceProxyFactory.Create<ICommonService.IC_Contacts_experience>("Contacts_experienceWCF");
            #endregion
        }
        //
        // GET: /BaseData/Contacts_experience/
        public ActionResult Index()
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
            //创建初始化参数实体
            CommonService.Model.C_Contacts_experience experience = new CommonService.Model.C_Contacts_experience();
            experience.C_Contacts_code = new Guid(C_Contacts_code);
            experience.C_Contacts_experience_date = DateTime.Now;
            experience.C_Contacts_experience_creator = Context.UIContext.Current.UserCode;
            experience.C_Contacts_experience_createTime = DateTime.Now;
            experience.C_Contacts_experience_isDelete = 0;
            return View(experience);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int C_Contacts_experience_id)
        {
            CommonService.Model.C_Contacts_experience parameter = _contacts_experienceWCF.GetModel(C_Contacts_experience_id);
            return View("Create", parameter);
        }

        public ActionResult List(FormCollection form, string C_Contacts_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //参数查询模型
            CommonService.Model.C_Contacts_experience expConditon = new CommonService.Model.C_Contacts_experience();

            if (!String.IsNullOrEmpty(C_Contacts_code))
            {//参数名称查询条件
                expConditon.C_Contacts_code = new Guid(C_Contacts_code);
                this.AddressUrlParameters = "?C_Contacts_code=" + expConditon.C_Contacts_code;
            }

            //参数查询模型传递到前端视图中
            ViewBag.ExpConditon = expConditon;
            ViewBag.C_Contacts_code = C_Contacts_code;
            #endregion

            //获取参数总记录数
            this.TotalRecordCount = _contacts_experienceWCF.GetRecordCount(expConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts_experience> experience = _contacts_experienceWCF.GetListByPage(expConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(experience);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string C_Contacts_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //参数查询模型
            CommonService.Model.C_Contacts_experience expConditon = new CommonService.Model.C_Contacts_experience();

            if (!String.IsNullOrEmpty(C_Contacts_code))
            {//参数名称查询条件
                expConditon.C_Contacts_code = new Guid(C_Contacts_code);
                this.AddressUrlParameters = "?C_Contacts_code=" + expConditon.C_Contacts_code;
            }

            //参数查询模型传递到前端视图中
            ViewBag.ExpConditon = expConditon;

            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _contacts_experienceWCF.GetRecordCount(expConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Contacts_experience> experience = _contacts_experienceWCF.GetListByPage(expConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(experience);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Contacts_experience experience)
        {
            //服务方法调用
            int experienceId = 0;

            if (experience.C_Contacts_experience_id > 0)
            {//修改
                bool isUpdateSuccess = _contacts_experienceWCF.Update(experience);
                if (isUpdateSuccess)
                {
                    experienceId = experience.C_Contacts_experience_id;
                }
            }
            else
            {//添加
                experience.C_Contacts_experience_createTime = DateTime.Now;
                experienceId = _contacts_experienceWCF.Add(experience);
            }

            if (experienceId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存联系人工作经历信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存联系人工作经历信息成功", "/basedata/Contacts_experience/create?C_Contacts_code="+experience.C_Contacts_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存联系人工作经历信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存联系人工作经历信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int C_Contacts_experience_id)
        {
            bool isSuccess = _contacts_experienceWCF.Delete(C_Contacts_experience_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除联系人工作经历信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除联系人工作经历信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}