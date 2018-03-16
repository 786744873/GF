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
    /// 个人工作经历表控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/07
    /// </summary>
    public class PRival_experienceController : BaseController
    {
        private readonly ICommonService.IC_PRival_experience _prival_experienceWCF;

         public PRival_experienceController()
        {
            #region 服务初始化
            _prival_experienceWCF = ServiceProxyFactory.Create<ICommonService.IC_PRival_experience>("PRival_experienceWCF");
            #endregion
        }
        //
        // GET: /BaseData/PRival_experience/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string prival_code)
        {
            //创建初始化个人工作经历实体
            CommonService.Model.C_PRival_experience prival = new CommonService.Model.C_PRival_experience();
            if (!String.IsNullOrEmpty(prival_code))
            {
                prival.C_PRival_code = new Guid(prival_code);
            }
            prival.C_PRival_experience_number = "";
            prival.C_PRival_experience_date = DateTime.Now;
            prival.C_PRival_experience_isDelete = 0;
            prival.C_PRival_experience_createTime = DateTime.Now;
            prival.C_PRival_experience_creator = Context.UIContext.Current.UserCode;

            return View(prival);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int prival_experience_id)
        {
            CommonService.Model.C_PRival_experience experience = _prival_experienceWCF.GetModel(prival_experience_id);
            return View("Create", experience);
        }

        public ActionResult List(FormCollection form, string prival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //工作经历查询模型
            CommonService.Model.C_PRival_experience exConditon = new CommonService.Model.C_PRival_experience();

            if (!String.IsNullOrEmpty(prival_code))
            {//个人姓名查询条件
                exConditon.C_PRival_code = new Guid(prival_code);
            }

            //法律对手个人工作经历信息查询模型传递到前端视图中
            ViewBag.ExConditon = exConditon;

            #endregion

            //获取法律对手个人工作经历总记录数
            this.TotalRecordCount = _prival_experienceWCF.GetRecordCount(exConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_PRival_experience> education = _prival_experienceWCF.GetListByPage(exConditon, "", (this.ThisPageIndex - 1) * this.PageSize, this.ThisPageIndex * this.PageSize);
            return View(education);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string prival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //工作经历查询模型
            CommonService.Model.C_PRival_experience exConditon = new CommonService.Model.C_PRival_experience();

            if (!String.IsNullOrEmpty(prival_code))
            {//个人姓名查询条件
                exConditon.C_PRival_code = new Guid(prival_code);
            }

            //法律对手个人工作经历信息查询模型传递到前端视图中
            ViewBag.ExConditon = exConditon;

            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _prival_experienceWCF.GetRecordCount(exConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_PRival_experience> experience = _prival_experienceWCF.GetListByPage(exConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(experience);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_PRival_experience experience)
        {
            //服务方法调用
            int experienceId = 0;

            if (experience.C_PRival_experience_id > 0)
            {//修改
                bool isUpdateSuccess = _prival_experienceWCF.Update(experience);
                if (isUpdateSuccess)
                {
                    experienceId = experience.C_PRival_experience_id;
                }
            }
            else
            {//添加
                experience.C_PRival_experience_createTime = DateTime.Now;
                experienceId = _prival_experienceWCF.Add(experience);
            }

            if (experienceId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存个人工作经历信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存个人工作经历信息成功", "/basedata/PRival_experience/create?prival_code=" + experience.C_PRival_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存个人工作经历信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存个人工作经历信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int prival_experience_id)
        {
            bool isSuccess = _prival_experienceWCF.Delete(prival_experience_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除个人工作经历信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除个人工作经历信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}