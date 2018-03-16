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
    /// 涉案项目关联单位控制器
    ///  作者：崔慧栋
    /// 日期：2015/05/14
    /// </summary>
    public class Involved_projectUnitController : BaseController
    {
        private readonly ICommonService.IC_Involved_projectUnit _involved_projectUnitWCF;
        private readonly ICommonService.IC_Involved_project_CU _involved_project_cuWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Contacts _contactsWCF;
        public Involved_projectUnitController()
        {
            #region 服务初始化
            _involved_projectUnitWCF = ServiceProxyFactory.Create<ICommonService.IC_Involved_projectUnit>("Involved_projectUnitWCF");
            _involved_project_cuWCF = ServiceProxyFactory.Create<ICommonService.IC_Involved_project_CU>("Involved_project_CUWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _contactsWCF = ServiceProxyFactory.Create<ICommonService.IC_Contacts>("ContactsWCF");
            #endregion
        }
        //
        // GET: /BaseData/Involved_projectUnit/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string Involved_project_code)
        {
            InitializationPageParameter();
            //创建初始化涉案项目关联单位实体
            CommonService.Model.C_Involved_projectUnit involved_projectUnit = new CommonService.Model.C_Involved_projectUnit();
            if (!String.IsNullOrEmpty(Involved_project_code))
            {
                involved_projectUnit.C_Involved_project_code = new Guid(Involved_project_code);
            }
            involved_projectUnit.C_Involved_projectUnit_code = Guid.NewGuid();
            involved_projectUnit.C_Involved_projectUnit_startTime = DateTime.Now;
            involved_projectUnit.C_Involved_projectUnit_acceptanceTime = DateTime.Now;
            involved_projectUnit.C_Involved_projectUnit_creator = Context.UIContext.Current.UserCode;
            involved_projectUnit.C_Involved_projectUnit_createTime = DateTime.Now;
            involved_projectUnit.C_Involved_projectUnit_isDelete = 0;

            return View(involved_projectUnit);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string Involved_projectUnit_code)
        {
            InitializationPageParameter();
            List<CommonService.Model.C_Contacts> charger = _contactsWCF.GetModelList();
            CommonService.Model.C_Involved_projectUnit unit = _involved_projectUnitWCF.Get(new Guid(Involved_projectUnit_code));
            if(charger!=null)
            {
                foreach (var chargername in charger)
                { 
                    if(chargername.C_Contacts_code==unit.C_Involved_projectUnit_charger)
                    {
                        unit.C_Involved_projectUnit_chargername = chargername.C_Contacts_name;
                    }
                }
            }
            return View("Create", unit);
        }

        public ActionResult List(FormCollection form, string Involved_project_code, int? page = 1)
        {
            InitializationPageParameter();
            //负责人名称
            ViewBag.charger = _contactsWCF.GetModelList();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //涉案项目关联单位查询模型
            CommonService.Model.C_Involved_projectUnit unitConditon = new CommonService.Model.C_Involved_projectUnit();

            if (!String.IsNullOrEmpty(Involved_project_code))
            {//涉案项目名称查询条件
                unitConditon.C_Involved_project_code = new Guid(Involved_project_code);
            }

            this.AddressUrlParameters = "?Involved_project_code=" + Involved_project_code;

            //涉案项目关联单位信息查询模型传递到前端视图中
            ViewBag.UnitConditon = unitConditon;

            #endregion

            //获取涉案项目关联单位总记录数
            this.TotalRecordCount = _involved_projectUnitWCF.GetRecordCount(unitConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Involved_projectUnit> crival = _involved_projectUnitWCF.GetListByPage(unitConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="Involved_project_code"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string Involved_project_code, int? page = 1)
        {
            InitializationPageParameter();
            //负责人名称
            ViewBag.charger = _contactsWCF.GetModelList();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //涉案项目关联单位查询模型
            CommonService.Model.C_Involved_projectUnit unitConditon = new CommonService.Model.C_Involved_projectUnit();

            if (!String.IsNullOrEmpty(Involved_project_code))
            {//涉案项目名称查询条件
                unitConditon.C_Involved_project_code = new Guid(Involved_project_code);
            }

            this.AddressUrlParameters = "?Involved_project_code=" + Involved_project_code;

            //涉案项目关联单位信息查询模型传递到前端视图中
            ViewBag.UnitConditon = unitConditon;

            #endregion

            //获取涉案项目关联单位总记录数
            this.TotalRecordCount = _involved_projectUnitWCF.GetRecordCount(unitConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Involved_projectUnit> crival = _involved_projectUnitWCF.GetListByPage(unitConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Involved_projectUnit unit)
        {
            //服务方法调用
            int projectId = 0;

            if (unit.C_Involved_projectUnit_id > 0)
            {//修改
                if (!String.IsNullOrEmpty(form["rivallookup.Code"]))
                {//投标单位编码
                    unit.C_Involved_projectUnit_rival = new Guid(form["rivallookup.Code"].Trim());
                }else
                {
                    unit.C_Involved_projectUnit_rival = unit.C_Involved_projectUnit_rival;
                }
                if (!String.IsNullOrEmpty(form["rivallookup.Type"]))
                {//投标单位类型
                    unit.C_Involved_projectUnit_rival_type = int.Parse(form["rivallookup.Type"].Trim());
                }else
                {
                    unit.C_Involved_projectUnit_rival_type = unit.C_Involved_projectUnit_rival_type;
                }
                if (!String.IsNullOrEmpty(form["contactslookup.Code"]))
                {//负责人编码
                    unit.C_Involved_projectUnit_charger = new Guid(form["contactslookup.Code"].Trim());
                }else
                {
                    unit.C_Involved_projectUnit_charger = unit.C_Involved_projectUnit_charger;
                }
                bool isUpdateSuccess = _involved_projectUnitWCF.Update(unit);
                if (isUpdateSuccess)
                {
                    projectId = unit.C_Involved_projectUnit_id;
                }
            }
            else
            {//添加
                unit.C_Involved_projectUnit_createTime = DateTime.Now;
                if (!String.IsNullOrEmpty(form["rivallookup.Code"]))
                {//投标单位编码
                    unit.C_Involved_projectUnit_rival = new Guid(form["rivallookup.Code"].Trim());
                }
                if (!String.IsNullOrEmpty(form["rivallookup.Type"]))
                {//投标单位类型
                    unit.C_Involved_projectUnit_rival_type =int.Parse(form["rivallookup.Type"].Trim());
                }
                if (!String.IsNullOrEmpty(form["contactslookup.Code"]))
                {//负责人编码
                    unit.C_Involved_projectUnit_charger = new Guid(form["contactslookup.Code"].Trim());
                }
                projectId = _involved_projectUnitWCF.Add(unit);
            }

            if (projectId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存关联单位信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存关联单位信息成功", "/basedata/Involved_projectUnit/create?Involved_project_code=" + unit.C_Involved_project_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存关联单位信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存关联单位信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string Involved_projectUnit_code)
        {
            bool isSuccess = _involved_projectUnitWCF.Delete(new Guid(Involved_projectUnit_code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除关联单位信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除关联单位信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //承包形式参数集合
            List<CommonService.Model.C_Parameters> projectUnit_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.发包形式));
            ViewBag.projectUnit_type = projectUnit_type;
            //资金来源参数集合
            List<CommonService.Model.C_Parameters> fundsSource = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.建设资金来源));
            ViewBag.fundsSource = fundsSource;
            //组织形式参数集合
            List<CommonService.Model.C_Parameters> chargerOrgan = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.组织形式));
            ViewBag.chargerOrgan = chargerOrgan;
            //工程进度参数集合
            List<CommonService.Model.C_Parameters> process = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.工程进度));
            ViewBag.process = process;
            //实际负责人亏盈状态参数集合
            List<CommonService.Model.C_Parameters> lossOrProfit = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.实际负责人亏盈状态));
            ViewBag.lossOrProfit = lossOrProfit;
            //亏损原因参数集合
            List<CommonService.Model.C_Parameters> lossReason = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.亏损原因));
            ViewBag.lossReason = lossReason;
        }
	}
}