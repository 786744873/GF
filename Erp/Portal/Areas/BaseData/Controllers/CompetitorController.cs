using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 竞争对手控制器
    /// 作者：崔慧栋
    /// 日期：2015/04/24
    public class CompetitorController : BaseController
    {
        private readonly ICommonService.IC_Competitor _competitorWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        public CompetitorController()
        {
            #region 服务初始化
            _competitorWCF = ServiceProxyFactory.Create<ICommonService.IC_Competitor>("CompetitorWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }
        //
        // GET: /BaseData/Competitor/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            InitializationPageParameter();
            //创建初始化竞争对手实体
            CommonService.Model.C_Competitor competitor = new CommonService.Model.C_Competitor();
            competitor.C_Competitor_code = Guid.NewGuid();
            competitor.C_Competitor_number = "";
            competitor.C_Competitor_deleted = 0;
            competitor.C_Competitor_cTime = DateTime.Now;
            competitor.C_Competitor_cUserID = Context.UIContext.Current.UserCode;
            competitor.C_Competitor_empNumber = Context.UIContext.Current.UserCode;
            competitor.C_Competitor_empNumber_name = Context.UIContext.Current.UserName;

            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;

            return View(competitor);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string competitorCode)
        {
            InitializationPageParameter();
            CommonService.Model.C_Competitor competitor = _competitorWCF.Get(new Guid(competitorCode));

            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;

            return View("Create", competitor);
        }

        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //竞争对手查询模型
            CommonService.Model.C_Competitor comConditon = new CommonService.Model.C_Competitor();

            if (!String.IsNullOrEmpty(form["C_Competitor_name"]))
            {//对手名称查询条件
                comConditon.C_Competitor_name = form["C_Competitor_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {//专业顾问
                comConditon.C_Competitor_empNumber = new Guid(form["mainLawyerlookup.Code"]);
                comConditon.C_Competitor_empNumber_name = form["mainLawyerlookup.Name"];
            }
            string aaa = form["C_Competitor_region"];
            if (!String.IsNullOrEmpty(form["C_Competitor_region"]))
            {//区域
                comConditon.C_Competitor_region = new Guid(form["C_Competitor_region"]);
            }
            //竞争对手查询模型传递到前端视图中
            ViewBag.ComConditon = comConditon;

            #endregion

            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;

            //获取竞争对手总记录数
            this.TotalRecordCount = _competitorWCF.GetRecordCount(comConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Competitor> competitor = _competitorWCF.GetListByPage(comConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(competitor);
        }
        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {


            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //竞争对手查询模型
            CommonService.Model.C_Competitor comConditon = new CommonService.Model.C_Competitor();

            if (!String.IsNullOrEmpty(form["C_Competitor_name"]))
            {//对手名称查询条件
                comConditon.C_Competitor_name = form["C_Competitor_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {//专业顾问
                comConditon.C_Competitor_empNumber = new Guid(form["mainLawyerlookup.Code"]);
                comConditon.C_Competitor_empNumber_name = form["mainLawyerlookup.Name"];
            }
            string aaa = form["C_Competitor_region"];
            if (!String.IsNullOrEmpty(form["C_Competitor_region"]))
            {//区域
                comConditon.C_Competitor_region = new Guid(form["C_Competitor_region"]);
            }
            //竞争对手查询模型传递到前端视图中
            ViewBag.ComConditon = comConditon;

            #endregion

            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;

            //获取竞争对手总记录数
            this.TotalRecordCount = _competitorWCF.GetRecordCount(comConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Competitor> checkList = _competitorWCF.GetListByPage(comConditon, "", 1, 1000000);

            #region 权限
            this.InitializationButtonsPower();
            #endregion


            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("对手名称");
            row1.CreateCell(1).SetCellValue("国家");
            row1.CreateCell(2).SetCellValue("城市");
            row1.CreateCell(3).SetCellValue("地址");
            row1.CreateCell(4).SetCellValue("公司网址");
            row1.CreateCell(5).SetCellValue("威胁程度");
            row1.CreateCell(6).SetCellValue("主要产品");
            row1.CreateCell(7).SetCellValue("主要客户");
            //....N行
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < checkList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(checkList[i].C_Competitor_name.ToString());
                rowtemp.CreateCell(1).SetCellValue(checkList[i].C_Competitor_country.ToString());
                rowtemp.CreateCell(2).SetCellValue(checkList[i].C_Competitor_City.ToString());
                rowtemp.CreateCell(3).SetCellValue(checkList[i].C_Competitor_Address.ToString());
                rowtemp.CreateCell(4).SetCellValue(checkList[i].C_Competitor_Url.ToString());
                rowtemp.CreateCell(5).SetCellValue(checkList[i].C_Competitor_levelRisk.ToString());
                rowtemp.CreateCell(6).SetCellValue(checkList[i].C_Competitor_mainProject.ToString());
                rowtemp.CreateCell(7).SetCellValue(checkList[i].C_Competitor_majorClient.ToString());
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "竞争对手列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Competitor competitor)
        {
            if(_competitorWCF.ExistsByName(competitor))
            {//判断竞争对手名称是否存在
                return Json(TipHelper.JsonData("此竞争对手名称已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            //服务方法调用
            int competitorId = 0;

            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {
                competitor.C_Competitor_empNumber = new Guid(form["mainLawyerlookup.Code"]);
            }

            if (competitor.C_Competitor_id > 0)
            {//修改
                bool isUpdateSuccess = _competitorWCF.Update(competitor);
                if (isUpdateSuccess)
                {
                    competitorId = competitor.C_Competitor_id;
                }
            }
            else
            {//添加
                competitor.C_Competitor_cTime = DateTime.Now;
                competitorId = _competitorWCF.Add(competitor);
            }

            if (competitorId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存竞争对手信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存竞争对手信息成功", "/basedata/competitor/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存竞争对手信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存竞争对手信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string competitorCode)
        {
            bool isSuccess = _competitorWCF.Delete(new Guid(competitorCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除竞争对手信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除竞争对手信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 单选全部竞争对手列表Action
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
            CommonService.Model.C_Competitor comConditon = new CommonService.Model.C_Competitor();

            if (!String.IsNullOrEmpty(form["C_Competitor_name"]))
            {//对手名称查询条件
                comConditon.C_Competitor_name = form["C_Competitor_name"].Trim();
            }

            //联系人查询模型传递到前端视图中
            ViewBag.comConditon = comConditon;

            #endregion

            //获取竞争对手总记录数
            this.TotalRecordCount = _competitorWCF.GetRecordCount(comConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Competitor> competitor = _competitorWCF.GetListByPage(comConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(competitor);
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
            //状态参数集合
            List<CommonService.Model.C_Parameters> CompetitorStatus = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CompetitorEnum.状态));
            ViewBag.CompetitorStatus = CompetitorStatus;
        }
    }
}