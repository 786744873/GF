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
    /// 个人配偶信息控制器
    /// </summary>
    public class SpouseController : BaseController
    {
        private readonly ICommonService.IC_PRival _privalWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Rival_Region _rivalRegionWCF;

        public SpouseController()
        {
            #region 服务初始化
            _privalWCF = ServiceProxyFactory.Create<ICommonService.IC_PRival>("PRivalWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _rivalRegionWCF = ServiceProxyFactory.Create<ICommonService.IC_Rival_Region>("Rival_RegionWCF");
            #endregion
        }
        //
        // GET: /BaseData/Spouse/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string prival_pcode)
        {
            InitializationPageParameter();
            //创建初始化个人配偶实体
            CommonService.Model.C_PRival prival = new CommonService.Model.C_PRival();
            prival.C_PRival_code = Guid.NewGuid();
            prival.C_PRival_number = "";
            prival.C_PRival_type = 2;
            if (!String.IsNullOrEmpty(prival_pcode))
            {
                prival.C_PRival_pcode = new Guid(prival_pcode);
            }
            prival.C_PRival_sex = 1;
            prival.C_PRival_birthday = DateTime.Now;
            prival.C_PRival_isDelete = 0;
            prival.C_PRival_createTime = DateTime.Now;
            prival.C_PRival_creator = Context.UIContext.Current.UserCode;

            return View(prival);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string prival_code)
        {
            InitializationPageParameter();
            CommonService.Model.C_PRival prival = _privalWCF.GetModel(new Guid(prival_code));
            return View("Create", prival);
        }

        /// <summary>
        /// 个人配偶详细tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string prival_code)
        {
            CommonService.Model.C_PRival prival = _privalWCF.GetModelByPcode(new Guid(prival_code));
            if(prival!=null)
            {
                ViewBag.PRival_code = prival.C_PRival_code;
            }else
            {
                ViewBag.PRival_code = Guid.Empty;
            }
            return View();
        }


        /// <summary>
        /// 个人配偶信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string prival_code)
        {
            CommonService.Model.C_PRival prival = _privalWCF.GetModel(new Guid(prival_code));
            if(prival==null)
            {
                CommonService.Model.C_PRival spouse = new CommonService.Model.C_PRival();
                spouse.C_PRival_name = "";
                spouse.C_PRival_sex = null;
                spouse.C_PRival_birthday = null;
                spouse.C_PRival_nation_name = "";
                spouse.C_PRival_hometown = "";
                spouse.C_PRival_pa_name = "";
                spouse.C_PRival_address = "";
                spouse.C_PRival_cnumber = "";
                spouse.C_PRival_phone = "";
                spouse.C_PRival_traits = "";
                spouse.C_PRival_hobby = "";
                spouse.C_PRival_region_name = "";

                return View(spouse);
            }else
            {
                return View(prival);
            }
        }

        public ActionResult List(FormCollection form, string prival_code, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //个人配偶查询模型
            CommonService.Model.C_PRival prConditon = new CommonService.Model.C_PRival();

            if (!String.IsNullOrEmpty(prival_code))
            {//个人名称查询条件
                prConditon.C_PRival_pcode =new Guid(prival_code);
            }

            //个人配偶查询模型传递到前端视图中
            ViewBag.PrConditon = prConditon;

            #endregion

            //获取个人配偶总记录数
            this.TotalRecordCount = _privalWCF.GetRecordCount(prConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_PRival> prival = _privalWCF.GetListByPage(prConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(prival);
        }



        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_PRival spouse)
        {
            #region 关联区域

            List<CommonService.Model.C_Rival_Region> rivalRegionList = new List<CommonService.Model.C_Rival_Region>();
            string regionCodeStr = form["regionlookup.Code"];
            string[] regionCodes = regionCodeStr.Split(',');
            foreach (var regionCode in regionCodes)
            {
                CommonService.Model.C_Rival_Region rivalRegion = new CommonService.Model.C_Rival_Region();
                rivalRegion.C_Rival_Region_rival = spouse.C_PRival_code;
                rivalRegion.C_Rival_Region_relRegion = new Guid(regionCode);
                rivalRegion.C_Rival_Region_isDelete = 0;
                rivalRegion.C_Rival_Region_creator = Context.UIContext.Current.UserCode;
                rivalRegion.C_Rival_Region_createTime = DateTime.Now;

                rivalRegionList.Add(rivalRegion);
            }
            _rivalRegionWCF.OperateList(rivalRegionList);

            #endregion
            //服务方法调用
            int spouseId = 0;

            if (spouse.C_PRival_id > 0)
            {//修改
                bool isUpdateSuccess = _privalWCF.Update(spouse);
                if (isUpdateSuccess)
                {
                    spouseId = spouse.C_PRival_id;
                }
            }
            else
            {//添加
                spouse.C_PRival_createTime = DateTime.Now;
                spouseId = _privalWCF.Add(spouse);
            }

            if (spouseId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存配偶信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存配偶信息成功", "/basedata/Spouse/create?prival_pcode=" + spouse.C_PRival_pcode, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存配偶信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存配偶信息信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string prival_code)
        {
            bool isSuccess = _privalWCF.Delete(new Guid(prival_code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除配偶信息信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除配偶信息信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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
            List<CommonService.Model.C_Parameters> nation = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ContactsEnum.民族));
            ViewBag.Nation = nation;
            //政治面貌参数集合
            List<CommonService.Model.C_Parameters> pa = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ContactsEnum.政治面貌));
            ViewBag.Pa = pa;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="crival">个人对象</param>
        private void InitializationPageParameter(CommonService.Model.C_PRival prival)
        {
            //民族参数集合
            CommonService.Model.C_Parameters nation = _parameterWCF.GetModel(prival.C_PRival_nation.Value);
            ViewBag.Nation = nation;
            //政治面貌参数集合
            CommonService.Model.C_Parameters pa = _parameterWCF.GetModel(prival.C_PRival_pa.Value);
            ViewBag.Pa = pa;
        }
	}
}