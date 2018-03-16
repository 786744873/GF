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
    /// 法院信息控制器
    /// </summary>
    public class CourtController : BaseController
    {
        private readonly ICommonService.IC_Court _courtWCF;
        private readonly ICommonService.IC_Court_Judge _court_judgeWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        public CourtController()
        {
            #region 服务初始化
            _courtWCF = ServiceProxyFactory.Create<ICommonService.IC_Court>("CourtWCF");
            _court_judgeWCF = ServiceProxyFactory.Create<ICommonService.IC_Court_Judge>("Court_JudgeWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            #endregion
        }
        //
        // GET: /BaseData/court/
        public override ActionResult Index()
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
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllList();
            ViewBag.regionList = regionList;
            //创建初始化法院实体
            CommonService.Model.C_Court court = new CommonService.Model.C_Court();
            court.C_Court_code = Guid.NewGuid();
            court.C_Court_number = "";
            court.C_Court_name = "";
            court.C_Court_isdelete = 0;
            court.C_Court_isAllocate = false;
            court.C_Court_userid = Context.UIContext.Current.UserCode;
            court.C_Court_cdate = DateTime.Now;
            return View(court);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string courtCode)
        {
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllList();
            ViewBag.regionList = regionList;
            CommonService.Model.C_Court court = _courtWCF.Get(new Guid(courtCode));
            return View("Create", court);
        }

        /// <summary>
        /// 人员成分
        /// </summary>
        /// <param name="courtCode"></param>
        /// <returns></returns>
        public ActionResult PersonComponent(string courtCode)
        {
            ViewBag.CourtCode = courtCode;
            List<CommonService.Model.C_Court_Judge> court_judges = _court_judgeWCF.GetListByCourt(new Guid(courtCode));
            return View(court_judges);
        }

        /// <summary>
        /// 法院详细tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string courtCode)
        {
            ViewBag.CourtCode = courtCode;
            return View();
        }
        /// <summary>
        /// 法院详细页签
        /// </summary>
        /// <param name="courtCode"></param>
        /// <returns></returns>
        public ActionResult CutTabDetails(string courtCode)
        {
            ViewBag.CourtCode = courtCode;
            return View();
        }


        /// <summary>
        /// 法院信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string courtCode)
        {
            CommonService.Model.C_Court court = _courtWCF.Get(new Guid(courtCode));
            return View(court);
        }

        /// <summary>
        /// 人员组成信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult PersonComponentDetails(string courtCode)
        {
            List<CommonService.Model.C_Court_Judge> court_judges = _court_judgeWCF.GetListByCourt(new Guid(courtCode));
            return View(court_judges);
        }

        public ActionResult List(FormCollection form, int? page = 1)
        {
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法院查询模型
            CommonService.Model.C_Court couConditon = new CommonService.Model.C_Court();

            if (!String.IsNullOrEmpty(form["C_Court_name"]))
            {//法院名称查询条件
                couConditon.C_Court_name = form["C_Court_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                couConditon.C_Court_area = new Guid(form["C_Region_code"]);
            }
            //法院查询模型传递到前端视图中
            ViewBag.CouConditon = couConditon;

            #endregion

            //获取法院总记录数
            this.TotalRecordCount = _courtWCF.GetRecordCount(couConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Court> court = _courtWCF.GetListByPage(couConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(court);
        }

        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {


            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法院查询模型
            CommonService.Model.C_Court couConditon = new CommonService.Model.C_Court();

            if (!String.IsNullOrEmpty(form["C_Court_name"]))
            {//法院名称查询条件
                couConditon.C_Court_name = form["C_Court_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                couConditon.C_Court_area = new Guid(form["C_Region_code"]);
            }

            //法院查询模型传递到前端视图中
            ViewBag.CouConditon = couConditon;

            #endregion

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Court> checkList = _courtWCF.GetListByPage(couConditon, "", 1, 1000000);

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

            row1.CreateCell(0).SetCellValue("法院名称");
            row1.CreateCell(1).SetCellValue("法院区域");
            row1.CreateCell(2).SetCellValue("法院网址");
            row1.CreateCell(3).SetCellValue("法院地址");
            row1.CreateCell(4).SetCellValue("备注");
            //....N行
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < checkList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(checkList[i].C_Court_name.ToString());
                rowtemp.CreateCell(1).SetCellValue(checkList[i].C_Court_area_name == null ? "" : checkList[i].C_Court_area_name.ToString());
                rowtemp.CreateCell(2).SetCellValue(checkList[i].C_Court_url.ToString());
                rowtemp.CreateCell(3).SetCellValue(checkList[i].C_Court_address.ToString());
                rowtemp.CreateCell(4).SetCellValue(checkList[i].C_Court_remark.ToString());
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "法院列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion

        public ActionResult MulityRefList(Guid? UserRegioncode)
        {
            List<CommonService.Model.C_Court> courts = new List<CommonService.Model.C_Court>();
            if (UserRegioncode == null)
            {
                courts = _courtWCF.GetAllList();
            }
            else
            {

                courts = _courtWCF.GetAllListByUserRegioncode(new Guid(UserRegioncode.ToString()));
            }
            return View(courts);
        }
        /// <summary>
        /// 根据地区code获得法院列表
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public ActionResult GetRegionList(string region)
        {
            List<CommonService.Model.C_Court> courts = new List<CommonService.Model.C_Court>();
            if (region == "全部")
            {
                courts = _courtWCF.GetAllList();
            }
            else
            {

                courts = _courtWCF.GetAllListByUserRegioncode(new Guid(region.ToString()));
            }
            return Json(courts);
        }
        /// <summary>
        /// 单选回调法院列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList(FormCollection form, string type, string isChecked, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法院查询模型
            CommonService.Model.C_Court couConditon = new CommonService.Model.C_Court();
            if (form["checked"] == null || form["checked"] == "" || isChecked == null || (!Context.UIContext.Current.IsPreSetManager))
            {
                Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
                List<CommonService.Model.SysManager.C_Userinfo_region> userInfoRegionList = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
                if (userInfoRegionList.Count != 0)
                {
                    foreach (CommonService.Model.SysManager.C_Userinfo_region userinfoRegion in userInfoRegionList)
                    {
                        couConditon.C_Court_regions += userinfoRegion.C_Region_code.ToString() + ',';
                    }

                }
                string ischeck = "";
                if (isChecked != null)
                {
                    ischeck = form["isChecked"].Trim();
                }//userCode.ToString() != "0a48cff5-8cb3-4a41-a863-121531173187"
                if (ischeck != "0" && (!Context.UIContext.Current.IsPreSetManager) && couConditon.C_Court_regions!=null)
                {
                    couConditon.C_Court_regions = couConditon.C_Court_regions.Substring(0, couConditon.C_Court_regions.Length - 1);

                }
                else
                {
                    couConditon.C_Court_regions = null;
                }
                ViewBag.ischeck = ischeck;
            }
            if (!String.IsNullOrEmpty(form["C_Court_name"]))
            {//法院名称查询条件
                couConditon.C_Court_name = form["C_Court_name"].Trim();
            }
            if ((!String.IsNullOrEmpty(form["C_Region_code"])) && (form["C_Region_code"].ToString() != "全部"))
            {//区域查询条件
                couConditon.C_Court_area = new Guid(form["C_Region_code"].ToString());
            }
            if (!String.IsNullOrEmpty(form["type"]))
            {//Select Dialog 弹出业务类型(虚拟属性，只是为了做区分，不会关联WCF业务)
                type = form["type"].Trim();
            }

            ViewBag.Type = type;

            //法院查询模型传递到前端视图中
            ViewBag.CouConditon = couConditon;

            #endregion

            //获取法院总记录数
            this.TotalRecordCount = _courtWCF.GetRecordCount(couConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            List<CommonService.Model.C_Court> court = _courtWCF.GetListByPage(couConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(court);
        }

        /// <summary>
        /// 单选回调法院列表(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList_CustomerForm(FormCollection form, string lookupgroup, string propertyValueCode, string mappingField, string mappingFieldName, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法院查询模型
            CommonService.Model.C_Court couConditon = new CommonService.Model.C_Court();

            if (!String.IsNullOrEmpty(form["C_Court_name"]))
            {//法院名称查询条件
                couConditon.C_Court_name = form["C_Court_name"].Trim();
            }

            if ((!String.IsNullOrEmpty(form["C_Region_code"])) && (form["C_Region_code"].ToString() != "全部"))
            {//区域查询条件
                couConditon.C_Court_area = new Guid(form["C_Region_code"].ToString());
            }

            //法院查询模型传递到前端视图中
            ViewBag.CouConditon = couConditon;
            this.PageSize = 8;
            #endregion

            #region 参照配置条件
            string _lookupgroup = String.Empty;
            string _propertyValueCode = String.Empty;
            string _mappingField = String.Empty;
            string _mappingFieldName = String.Empty;

            if (!String.IsNullOrEmpty(form["lookupgroup"]))
            {
                _lookupgroup = form["lookupgroup"];
            }
            if (!String.IsNullOrEmpty(form["propertyValueCode"]))
            {
                _propertyValueCode = form["propertyValueCode"];
            }
            if (!String.IsNullOrEmpty(lookupgroup))
            {
                _lookupgroup = lookupgroup;
            }
            if (!String.IsNullOrEmpty(propertyValueCode))
            {
                _propertyValueCode = propertyValueCode;
            }
            ViewBag.Lookupgroup = _lookupgroup;
            ViewBag.PropertyValueCode = _propertyValueCode;
            ViewBag.MappingField = _mappingField;
            ViewBag.MappingFieldName = _mappingFieldName;

            this.AddressUrlParameters = "?lookupgroup=" + _lookupgroup;//加入地址栏条件
            this.AddressUrlParameters = this.AddressUrlParameters + "&propertyValueCode=" + _propertyValueCode;
            #endregion

            //获取法院总记录数
            this.TotalRecordCount = _courtWCF.GetRecordCount(couConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //区域
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;

            //获取法院信息
            List<CommonService.Model.C_Court> court = _courtWCF.GetListByPage(couConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(court);
        }


        /// <summary>
        /// 多选回调法院列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefList(FormCollection form, string type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法院查询模型
            CommonService.Model.C_Court couConditon = new CommonService.Model.C_Court();

            if (!String.IsNullOrEmpty(form["C_Court_name"]))
            {//法院名称查询条件
                couConditon.C_Court_name = form["C_Court_name"].Trim();
            }
            if ((!String.IsNullOrEmpty(form["C_Region_code"])) && (form["C_Region_code"].ToString() != "全部"))
            {//区域查询条件
                couConditon.C_Court_area = new Guid(form["C_Region_code"].ToString());
            }
            if (!String.IsNullOrEmpty(form["type"]))
            {//Select Dialog 弹出业务类型(虚拟属性，只是为了做区分，不会关联WCF业务)
                type = form["type"].Trim();
            }

            this.AddressUrlParameters = "?type=" + type;
            ViewBag.Type = type;

            //法院查询模型传递到前端视图中
            ViewBag.CouConditon = couConditon;

            #endregion

            //获取法院总记录数
            this.TotalRecordCount = _courtWCF.GetRecordCount(couConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            List<CommonService.Model.C_Court> court = _courtWCF.GetListByPage(couConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(court);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Court court)
        {
            //if (!String.IsNullOrEmpty(form["regionlookup.Code"].Trim()))
            //{
            //    court.C_Court_area = new Guid(form["regionlookup.Code"].Trim());
            //}
            //服务方法调用
            int courtId = 0;
            #region  参照值处理


            #endregion
            if (_courtWCF.ExistsByName(court))
            {//是否已经存在该法院名称
                return Json(TipHelper.JsonData("此法院已经存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (court.C_Court_id > 0)
            {//修改
                bool isUpdateSuccess = _courtWCF.Update(court);
                if (isUpdateSuccess)
                {
                    courtId = court.C_Court_id;
                }
            }
            else
            {//添加
                court.C_Court_cdate = DateTime.Now;
                courtId = _courtWCF.Add(court);
            }

            if (courtId >= 0)
            {
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存法院信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存法院信息成功", "/BaseData/court/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存法院信息成功", ""));//默认仅仅保存
                }
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存法院信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string courtCode)
        {
            bool isSuccess = _courtWCF.Delete(new Guid(courtCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除法院信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除法院信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        [HttpPost]
        public ActionResult GetListBylawyer(string lawyerCode)
        {
            List<CommonService.Model.C_Court> courts = _courtWCF.GetListBylawyer(new Guid(lawyerCode));
            return Json(courts);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}