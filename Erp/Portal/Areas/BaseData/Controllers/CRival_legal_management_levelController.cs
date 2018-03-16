using CommonService.Common;
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
    /// 对手公司法律管理水平表控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
    public class CRival_legal_management_levelController : BaseController
    {
        private readonly ICommonService.IC_CRival_legal_management_level _crival_legal_management_levelWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public CRival_legal_management_levelController()
        {
            #region 服务初始化
            _crival_legal_management_levelWCF = ServiceProxyFactory.Create<ICommonService.IC_CRival_legal_management_level>("CRival_legal_management_levelWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /BaseData/CRival_legal_management_level/
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
            InitializationPageParameter();
            //创建初始化法律管理水平实体
            CommonService.Model.C_CRival_legal_management_level level = new CommonService.Model.C_CRival_legal_management_level();
            if (!String.IsNullOrEmpty(C_CRival_code))
            {
                level.C_CRival_code = new Guid(C_CRival_code);
            }
            level.C_CRival_legal_management_level_isDelete = 0;
            level.C_CRival_legal_management_level_craeteTime = DateTime.Now;
            level.C_CRival_legal_management_level_creator = Context.UIContext.Current.UserCode;

            return View(level);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int CRival_legal_management_level_id)
        {
            InitializationPageParameter();
            CommonService.Model.C_CRival_legal_management_level level = _crival_legal_management_levelWCF.GetModel(CRival_legal_management_level_id);
            return View("Create", level);
        }

        public ActionResult List(FormCollection form, string crival_code, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法律管理水平查询模型
            CommonService.Model.C_CRival_legal_management_level crConditon = new CommonService.Model.C_CRival_legal_management_level();
            if (!String.IsNullOrEmpty(crival_code))
            {//公司名称查询条件
                crConditon.C_CRival_code = new Guid(crival_code);
            }
            this.AddressUrlParameters = "?crival_code=" + crival_code;

            //法律管理水平查询模型传递到前端视图中
            ViewBag.CrConditon = crConditon;

            #endregion

            //获取法律管理水平总记录数
            this.TotalRecordCount = _crival_legal_management_levelWCF.GetRecordCount(crConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;

            List<CommonService.Model.C_CRival_legal_management_level> crival = _crival_legal_management_levelWCF.GetListByPage(crConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string crival_code, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法律管理水平查询模型
            CommonService.Model.C_CRival_legal_management_level crConditon = new CommonService.Model.C_CRival_legal_management_level();
            if (!String.IsNullOrEmpty(crival_code))
            {//公司名称查询条件
                crConditon.C_CRival_code = new Guid(crival_code);
            }

            //法律管理水平查询模型传递到前端视图中
            ViewBag.CrConditon = crConditon;

            #endregion

            //获取法律管理水平总记录数
            this.TotalRecordCount = _crival_legal_management_levelWCF.GetRecordCount(crConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取法律管理水平数据信息
            List<CommonService.Model.C_CRival_legal_management_level> car = _crival_legal_management_levelWCF.GetListByPage(crConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(car);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_CRival_legal_management_level level)
        {
            //服务方法调用
            int crivalId = 0;

            if (level.C_CRival_legal_management_level_id > 0)
            {//修改
                bool isUpdateSuccess = _crival_legal_management_levelWCF.Update(level);
                if (isUpdateSuccess)
                {
                    crivalId = level.C_CRival_legal_management_level_id;
                }
            }
            else
            {//添加
                level.C_CRival_legal_management_level_craeteTime = DateTime.Now;
                crivalId = _crival_legal_management_levelWCF.Add(level);
            }

            if (crivalId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存法律管理水平信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存法律管理水平信息成功", "/basedata/CRival_legal_management_level/create?C_CRival_code="+level.C_CRival_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存法律管理水平信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存法律管理水平信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int CRival_legal_management_level_id)
        {
            bool isSuccess = _crival_legal_management_levelWCF.Delete(CRival_legal_management_level_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除法律管理水平信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除法律管理水平信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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
            //格式文本参数集合
            List<CommonService.Model.C_Parameters> tf = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(legal_management_levelEnum.格式文本));
            ViewBag.Tf = tf;
            //管理风格参数集合
            List<CommonService.Model.C_Parameters> ms = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(legal_management_levelEnum.管理风格));
            ViewBag.Ms = ms;
            //使用习惯参数集合
            List<CommonService.Model.C_Parameters> habit = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(legal_management_levelEnum.使用习惯));
            ViewBag.Habit = habit;
            //诉讼管理参数集合
            List<CommonService.Model.C_Parameters> am = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(legal_management_levelEnum.诉讼管理));
            ViewBag.Am = am;
            //印章责任规避参数集合
            List<CommonService.Model.C_Parameters> sduty = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(legal_management_levelEnum.印章责任规避));
            ViewBag.Sduty = sduty;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter(CommonService.Model.C_CRival_legal_management_level crival)
        {
            //企业类型参数集合
            CommonService.Model.C_Parameters tf = _parameterWCF.GetModel(crival.C_CRival_legal_management_level_tf.Value);
            ViewBag.Tf = tf;
            //资本结构参数集合
            CommonService.Model.C_Parameters ms = _parameterWCF.GetModel(crival.C_CRival_legal_management_level_ms.Value);
            ViewBag.Ms = ms;
            //经营模式参数集合
            CommonService.Model.C_Parameters habit = _parameterWCF.GetModel(crival.C_CRival_legal_management_level_habit.Value);
            ViewBag.Habit = habit;
            //资本结构参数集合
            CommonService.Model.C_Parameters am = _parameterWCF.GetModel(crival.C_CRival_legal_management_level_am.Value);
            ViewBag.Am = am;
            //经营模式参数集合
            CommonService.Model.C_Parameters sduty = _parameterWCF.GetModel(crival.C_CRival_legal_management_level_sduty.Value);
            ViewBag.Sduty = sduty;
        }
	}
}