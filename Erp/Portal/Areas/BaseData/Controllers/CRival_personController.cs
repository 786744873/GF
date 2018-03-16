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
    /// 对手公司企业负责人表控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
    public class CRival_personController : BaseController
    {
        private readonly ICommonService.IC_CRival_person _crival_personWCF;

         public CRival_personController()
        {
            #region 服务初始化
            _crival_personWCF = ServiceProxyFactory.Create<ICommonService.IC_CRival_person>("CRival_personWCF");
            #endregion
        }
        //
        // GET: /BaseData/CRival_person/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string C_CRival_code)
        {
            //创建初始化公司企业负责人实体
            CommonService.Model.C_CRival_person crival_person = new CommonService.Model.C_CRival_person();
            if (!String.IsNullOrEmpty(C_CRival_code))
            {
                crival_person.C_CRival_code = new Guid(C_CRival_code);
            }
            crival_person.C_CRival_person_isDelete = 0;
            crival_person.C_CRival_person_sex = 1;
            crival_person.C_CRival_person_birthday = DateTime.Now;
            crival_person.C_CRival_person_ptime = DateTime.Now;
            crival_person.C_CRival_person_craeteTime = DateTime.Now;
            crival_person.C_CRival_person_creator = Context.UIContext.Current.UserCode;

            return View(crival_person);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int crival_personID)
        {
            CommonService.Model.C_CRival_person crival_person = _crival_personWCF.GetModel(crival_personID);
            return View("Create", crival_person);
        }

        public ActionResult List(FormCollection form, string crival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //公司企业负责人查询模型
            CommonService.Model.C_CRival_person crConditon = new CommonService.Model.C_CRival_person();
            if (!String.IsNullOrEmpty(crival_code))
            {//公司名称查询条件
                crConditon.C_CRival_code = new Guid(crival_code);
            }
            this.AddressUrlParameters = "?crival_code=" + crival_code;

            //公司企业负责人查询模型传递到前端视图中
            ViewBag.CrConditon = crConditon;

            #endregion

            //获取公司企业负责人总记录数
            this.TotalRecordCount = _crival_personWCF.GetRecordCount(crConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;

            List<CommonService.Model.C_CRival_person> crival = _crival_personWCF.GetListByPage(crConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string crival_code, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //公司企业负责人查询模型
            CommonService.Model.C_CRival_person crConditon = new CommonService.Model.C_CRival_person();
            if (!String.IsNullOrEmpty(crival_code))
            {//公司名称查询条件
                crConditon.C_CRival_code = new Guid(crival_code);
            }

            //公司企业负责人查询模型传递到前端视图中
            ViewBag.CrChangeConditon = crConditon;

            #endregion

            //获取公司企业负责人总记录数
            this.TotalRecordCount = _crival_personWCF.GetRecordCount(crConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取公司企业负责人数据信息
            List<CommonService.Model.C_CRival_person> car = _crival_personWCF.GetListByPage(crConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(car);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_CRival_person crival_person)
        {
            //服务方法调用
            int crivalId = 0;

            if (crival_person.C_CRival_person_id > 0)
            {//修改
                bool isUpdateSuccess = _crival_personWCF.Update(crival_person);
                if (isUpdateSuccess)
                {
                    crivalId = crival_person.C_CRival_person_id;
                }
            }
            else
            {//添加
                crival_person.C_CRival_person_craeteTime = DateTime.Now;
                crivalId = _crival_personWCF.Add(crival_person);
            }

            if (crivalId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存企业负责人信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存企业负责人信息成功", "/basedata/CRival_person/create?C_CRival_code=" + crival_person.C_CRival_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存企业负责人信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存企业负责人信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int crival_personID)
        {
            bool isSuccess = _crival_personWCF.Delete(crival_personID);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除企业负责人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除企业负责人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}