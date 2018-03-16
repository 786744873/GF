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
    /// 个人教育背景表控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/07
    /// </summary>
    public class PRival_educationController : BaseController
    {
        private readonly ICommonService.IC_PRival_education _prival_educationWCF;

         public PRival_educationController()
        {
            #region 服务初始化
            _prival_educationWCF = ServiceProxyFactory.Create<ICommonService.IC_PRival_education>("PRival_educationWCF");
            #endregion
        }
        //
        // GET: /BaseData/PRival_education/
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
            //创建初始化个人教育背景实体
            CommonService.Model.C_PRival_education prival = new CommonService.Model.C_PRival_education();
            if(!String.IsNullOrEmpty(prival_code))
            {
                prival.C_PRival_code =new Guid(prival_code);
            }
            prival.C_PRival_education_number = "";
            prival.C_PRival_education_graduation_date = DateTime.Now;
            prival.C_PRival_education_isDelete = 0;
            prival.C_PRival_education_createTime = DateTime.Now;
            prival.C_PRival_education_creator = Context.UIContext.Current.UserCode;

            return View(prival);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int prival_education_id)
        {
            CommonService.Model.C_PRival_education prival = _prival_educationWCF.GetModel(prival_education_id);
            return View("Create", prival);
        }

        public ActionResult List(FormCollection form,string prival_code,int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //教育背景查询模型
            CommonService.Model.C_PRival_education eduConditon = new CommonService.Model.C_PRival_education();

            if (!String.IsNullOrEmpty(prival_code))
            {//个人姓名查询条件
                eduConditon.C_PRival_code = new Guid(prival_code);
            }

            //法律对手个人教育背景信息查询模型传递到前端视图中
            ViewBag.EduConditon = eduConditon;

            #endregion

            //获取法律对手个人教育背景总记录数
            this.TotalRecordCount = _prival_educationWCF.GetRecordCount(eduConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_PRival_education> education = _prival_educationWCF.GetListByPage(eduConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(education);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string prival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //教育背景查询模型
            CommonService.Model.C_PRival_education eduConditon = new CommonService.Model.C_PRival_education();

            if (!String.IsNullOrEmpty(prival_code))
            {//个人姓名查询条件
                eduConditon.C_PRival_code = new Guid(prival_code);
            }

            //法律对手个人教育背景信息查询模型传递到前端视图中
            ViewBag.EduConditon = eduConditon;

            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _prival_educationWCF.GetRecordCount(eduConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_PRival_education> education = _prival_educationWCF.GetListByPage(eduConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(education);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_PRival_education crival)
        {
            //服务方法调用
            int crivalId = 0;

            if (crival.C_PRival_education_id > 0)
            {//修改
                bool isUpdateSuccess = _prival_educationWCF.Update(crival);
                if (isUpdateSuccess)
                {
                    crivalId = crival.C_PRival_education_id;
                }
            }
            else
            {//添加
                crival.C_PRival_education_createTime = DateTime.Now;
                crivalId = _prival_educationWCF.Add(crival);
            }

            if (crivalId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存个人教育背景信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存个人教育背景信息成功", "/basedata/PRival_education/create?prival_code=" + crival.C_PRival_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存个人教育背景信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存个人教育背景信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int prival_education_id)
        {
            bool isSuccess = _prival_educationWCF.Delete(prival_education_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除个人教育背景信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除个人教育背景信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}