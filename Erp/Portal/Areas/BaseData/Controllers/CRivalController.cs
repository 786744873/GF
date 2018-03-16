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
    /// 法律对手信息表控制器
    /// 作者：崔慧栋
    /// 日期：2015/04/24
    /// </summary>
    public class CRivalController : BaseController
    {
        private readonly ICommonService.IC_CRival _crivalWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Rival_Region _rivalRegionWCF;

        public CRivalController()
        {
            #region 服务初始化
            _crivalWCF = ServiceProxyFactory.Create<ICommonService.IC_CRival>("CRivalWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _rivalRegionWCF = ServiceProxyFactory.Create<ICommonService.IC_Rival_Region>("Rival_RegionWCF");
            #endregion
        }
        //
        // GET: /BaseData/CRival/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 公司详细tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string crival_code)
        {
            ViewBag.CRival_code = crival_code;
            return View();
        }


        /// <summary>
        /// 公司信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string crivalCode)
        {
            CommonService.Model.C_CRival crival = _crivalWCF.GetModel(new Guid(crivalCode));
            InitializationPageParameter(crival);
            return View(crival);
        }
        /// <summary>
        /// 公司信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult CustDetails(string crivalCode)
        {
            CommonService.Model.C_CRival crival = _crivalWCF.GetModel(new Guid(crivalCode));
            InitializationPageParameter(crival);
            ViewBag.CRival_code = crival.C_CRival_code;
            return View(crival);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            InitializationPageParameter();
            //创建初始化组织机构实体
            CommonService.Model.C_CRival crival = new CommonService.Model.C_CRival();
            crival.C_CRival_code = Guid.NewGuid();
            crival.C_CRival_number = "";
            crival.C_CRival_fregtime = DateTime.Now;
            crival.C_CRival_isdelete = 0;
            crival.C_CRival_cdate = DateTime.Now;
            crival.C_CRival_cuserid = Context.UIContext.Current.UserCode;

            return View(crival);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string C_CRival_code)
        {
            InitializationPageParameter();
            CommonService.Model.C_CRival crival = _crivalWCF.GetModel(new Guid(C_CRival_code));
            return View("Create", crival);
        }

        public ActionResult List(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //组织机构查询模型
            CommonService.Model.C_CRival crConditon = new CommonService.Model.C_CRival();

            if (!String.IsNullOrEmpty(form["C_CRival_name"]))
            {//企业名称查询条件
                crConditon.C_CRival_name = form["C_CRival_name"].Trim(); 
            }

            //法律对手信息查询模型传递到前端视图中
            ViewBag.CrConditon = crConditon;

            #endregion

            //获取法律对手总记录数
            this.TotalRecordCount = _crivalWCF.GetRecordCount(crConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 15;

            List<CommonService.Model.C_CRival> crival = _crivalWCF.GetListByPage(crConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion
            
            return View(crival);
        }
        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {

            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //组织机构查询模型
            CommonService.Model.C_CRival crConditon = new CommonService.Model.C_CRival();

            if (!String.IsNullOrEmpty(form["C_CRival_name"]))
            {//企业名称查询条件
                crConditon.C_CRival_name = form["C_CRival_name"].Trim();
            }

            //法律对手信息查询模型传递到前端视图中
            ViewBag.CrConditon = crConditon;

            #endregion

        
            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 15;

            List<CommonService.Model.C_CRival> checkList = _crivalWCF.GetListByPage(crConditon, "", 1, 1000000);

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
            row1.CreateCell(0).SetCellValue("企业名称");
            row1.CreateCell(1).SetCellValue("工商注册地");
            row1.CreateCell(2).SetCellValue("实际经营地");
            row1.CreateCell(3).SetCellValue("成立时间");
            row1.CreateCell(4).SetCellValue("企业类型");
             row1.CreateCell(5).SetCellValue("注册资本");
            row1.CreateCell(6).SetCellValue("资本结构");
            row1.CreateCell(7).SetCellValue("资质情况");
            row1.CreateCell(8).SetCellValue("经营模式");
            row1.CreateCell(9).SetCellValue("主营项目");
            row1.CreateCell(10).SetCellValue("联系电话");
            //....N行
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < checkList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(checkList[i].C_CRival_name.ToString());
                rowtemp.CreateCell(1).SetCellValue(checkList[i].C_CRival_iland.ToString());
                rowtemp.CreateCell(2).SetCellValue(checkList[i].C_CRival_aland.ToString());
                rowtemp.CreateCell(3).SetCellValue(checkList[i].C_CRival_fregtime.ToString());
               if(checkList[i].C_CRival_ftype==51){
                   rowtemp.CreateCell(4).SetCellValue("国有企业");
               }else if(checkList[i].C_CRival_ftype==52){
                   rowtemp.CreateCell(4).SetCellValue("集体所有制企业");
               }
               else if (checkList[i].C_CRival_ftype == 53)
               {
                   rowtemp.CreateCell(4).SetCellValue("私营企业");
               }
               else if (checkList[i].C_CRival_ftype == 54)
               {
                   rowtemp.CreateCell(4).SetCellValue("股份制企业");
               }
               else if (checkList[i].C_CRival_ftype == 55)
               {
                   rowtemp.CreateCell(4).SetCellValue("联营企业");
               }
               else if (checkList[i].C_CRival_ftype == 56)
               {
                   rowtemp.CreateCell(4).SetCellValue("外商投资企业");
               }
               else if (checkList[i].C_CRival_ftype == 57)
               {
                   rowtemp.CreateCell(4).SetCellValue("港澳台投资企业");
               }
               else if (checkList[i].C_CRival_ftype == 58)
               {
                   rowtemp.CreateCell(4).SetCellValue("股份合作企业");
               }
               else {
                   rowtemp.CreateCell(4).SetCellValue("");
               }
               rowtemp.CreateCell(5).SetCellValue(checkList[i].C_CRival_rassets.ToString());
               if (checkList[i].C_CRival_corgan == 60) {
                   rowtemp.CreateCell(6).SetCellValue("国有资本");
               }
               else if (checkList[i].C_CRival_corgan == 61)
               {
                   rowtemp.CreateCell(6).SetCellValue("法人资本");
               }
               else if (checkList[i].C_CRival_corgan == 62)
               {
                   rowtemp.CreateCell(6).SetCellValue("个人资本");
               }
               else if (checkList[i].C_CRival_corgan == 63)
               {
                   rowtemp.CreateCell(6).SetCellValue("港澳台商资本");
               }
               else if (checkList[i].C_CRival_corgan == 64)
               {
                   rowtemp.CreateCell(6).SetCellValue("外商资本");
               }
               rowtemp.CreateCell(7).SetCellValue(checkList[i].C_CRival_acase.ToString());
               if (checkList[i].C_CRival_smodel == 66)
               {
                   rowtemp.CreateCell(8).SetCellValue("纯直营");
               }
               else if (checkList[i].C_CRival_smodel == 67)
               {
                   rowtemp.CreateCell(8).SetCellValue("直营为主");
               }
               else if (checkList[i].C_CRival_smodel == 68)
               {
                   rowtemp.CreateCell(8).SetCellValue("单纯挂靠");
               }
               else if (checkList[i].C_CRival_smodel == 69)
               {
                   rowtemp.CreateCell(8).SetCellValue("挂靠为主");
               }
               rowtemp.CreateCell(9).SetCellValue(checkList[i].C_CRival_mitem.ToString());
               rowtemp.CreateCell(10).SetCellValue(checkList[i].C_CRival_phone.ToString());
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "公司对手列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
        /// <summary>
        /// 单选回调公司列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList(FormCollection form,string type, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //组织机构查询模型
            CommonService.Model.C_CRival crConditon = new CommonService.Model.C_CRival();

            if (!String.IsNullOrEmpty(form["C_CRival_name"]))
            {//企业名称查询条件
                crConditon.C_CRival_name = form["C_CRival_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["type"]))
            {//企业名称查询条件
                type = form["type"].Trim();
            }
            ViewBag.type = type;
            //法律对手信息查询模型传递到前端视图中
            ViewBag.CrConditon = crConditon;

            #endregion
            this.AddressUrlParameters = "?type="+type;

            //获取法律对手总记录数
            this.TotalRecordCount = _crivalWCF.GetRecordCount(crConditon);
            this.PageSize = 8;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_CRival> crival = _crivalWCF.GetListByPage(crConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 多选回调公司列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefList(FormCollection form,string checkedRivalCode, string type, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //组织机构查询模型
            CommonService.Model.C_CRival crConditon = new CommonService.Model.C_CRival();

            if (!String.IsNullOrEmpty(form["C_CRival_name"]))
            {//企业名称查询条件
                crConditon.C_CRival_name = form["C_CRival_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["type"]))
            {//企业名称查询条件
                type = form["type"].Trim();
            }
            ViewBag.type = type;
            ViewBag.checkedRivalCode = checkedRivalCode;
            //法律对手信息查询模型传递到前端视图中
            ViewBag.CrConditon = crConditon;

            this.AddressUrlParameters = "?type=" + type;

            #endregion

            //获取法律对手总记录数
            this.TotalRecordCount = _crivalWCF.GetRecordCount(crConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 9;

            List<CommonService.Model.C_CRival> crival = _crivalWCF.GetListByPage(crConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        #region 自定义表单列表编辑页面所用Callback带回
        /// <summary>
        /// 单选回调公司列表(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="rebuildProperty">重组表单属性</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList_CrivalForm_List(FormCollection form, string lookupgroup, string rebuildProperty, string mappingField, string mappingFieldName, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //公司查询模型
            CommonService.Model.C_CRival crivalConditon = new CommonService.Model.C_CRival();

            if (!String.IsNullOrEmpty(form["C_CRival_name"]))
            {//企业名称查询条件
                crivalConditon.C_CRival_name = form["C_CRival_name"].Trim();
            }
            //公司查询模型传递到前端视图中
            ViewBag.CrivalConditon = crivalConditon;
            this.PageSize = 8;

            #endregion
            #region 参照配置条件
            string _lookupgroup = String.Empty;
            string _rebuildProperty = String.Empty;
            string _mappingField = String.Empty;
            string _mappingFieldName = String.Empty;

            if (!String.IsNullOrEmpty(form["lookupgroup"]))
            {
                _lookupgroup = form["lookupgroup"];
            }
            if (!String.IsNullOrEmpty(form["rebuildProperty"]))
            {
                _rebuildProperty = form["rebuildProperty"];
            }
            if (!String.IsNullOrEmpty(lookupgroup))
            {
                _lookupgroup = lookupgroup;
            }
            if (!String.IsNullOrEmpty(rebuildProperty))
            {
                _rebuildProperty = rebuildProperty;
            }
            ViewBag.Lookupgroup = _lookupgroup;
            ViewBag.RebuildProperty = _rebuildProperty;
            ViewBag.MappingField = _mappingField;
            ViewBag.MappingFieldName = _mappingFieldName;


            this.AddressUrlParameters = "?lookupgroup=" + _lookupgroup;//加入地址栏条件
            this.AddressUrlParameters = this.AddressUrlParameters + "&rebuildProperty=" + _rebuildProperty;
            #endregion

            //获取公司总记录数
            this.TotalRecordCount = _crivalWCF.GetRecordCount(crivalConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取公司数据信息
            List<CommonService.Model.C_CRival> crival = _crivalWCF.GetListByPage(crivalConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(crival);
        }

        #endregion


        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_CRival crival)
        {
            if(_crivalWCF.ExistsByName(crival))
            {
                return Json(TipHelper.JsonData("此对手公司名称已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            #region 关联区域

            List<CommonService.Model.C_Rival_Region> rivalRegionList = new List<CommonService.Model.C_Rival_Region>();
            string regionCodeStr = "";
            if(!String.IsNullOrEmpty(form["regionlookup.Code"].Trim()))
            {
                regionCodeStr = form["regionlookup.Code"].Trim();
                string[] regionCodes = regionCodeStr.Split(',');
                foreach (var regionCode in regionCodes)
                {
                    CommonService.Model.C_Rival_Region rivalRegion = new CommonService.Model.C_Rival_Region();
                    rivalRegion.C_Rival_Region_rival = crival.C_CRival_code;
                    rivalRegion.C_Rival_Region_relRegion = new Guid(regionCode);
                    rivalRegion.C_Rival_Region_isDelete = 0;
                    rivalRegion.C_Rival_Region_creator = Context.UIContext.Current.UserCode;
                    rivalRegion.C_Rival_Region_createTime = DateTime.Now;

                    rivalRegionList.Add(rivalRegion);
                }
                _rivalRegionWCF.OperateList(rivalRegionList);
            }

            #endregion
            //服务方法调用
            int crivalId = 0;

            if (crival.C_CRival_id > 0)
            {//修改
                bool isUpdateSuccess = _crivalWCF.Update(crival);
                if (isUpdateSuccess)
                {
                    crivalId = crival.C_CRival_id;
                }
            }
            else
            {//添加
                crival.C_CRival_cdate = DateTime.Now;
                crivalId = _crivalWCF.Add(crival);
            }

            if (crivalId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存法律对手信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存法律对手信息成功", "/basedata/crival/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存法律对手信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存法律对手信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string C_CRival_code)
        {
            bool isSuccess = _crivalWCF.Delete(new Guid(C_CRival_code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除法律对手信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除法律对手信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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
            //企业类型参数集合
            List<CommonService.Model.C_Parameters> CRival_ftype = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CRivalEnum.企业类型));
            ViewBag.CRival_ftype = CRival_ftype;
            //资本结构参数集合
            List<CommonService.Model.C_Parameters> CRival_corgan = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CRivalEnum.资本结构));
            ViewBag.CRival_corgan = CRival_corgan;
            //经营模式参数集合
            List<CommonService.Model.C_Parameters> CRival_smodel = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CRivalEnum.经营模式));
            ViewBag.CRival_smodel = CRival_smodel;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="crival">公司对象</param>
        private void InitializationPageParameter(CommonService.Model.C_CRival crival)
        {
            //企业类型参数集合
            CommonService.Model.C_Parameters CRival_ftype = new CommonService.Model.C_Parameters();
            if (crival.C_CRival_ftype==null)
            {
                ViewBag.CRival_ftype = CRival_ftype;
            }else
            {
                CRival_ftype = _parameterWCF.GetModel(crival.C_CRival_ftype.Value);
                ViewBag.CRival_ftype = CRival_ftype;
            }            
            //资本结构参数集合
            CommonService.Model.C_Parameters CRival_corgan = new CommonService.Model.C_Parameters();
            if (crival.C_CRival_corgan==null)
            {
                ViewBag.CRival_corgan = CRival_corgan;
            }else
            {
                CRival_corgan = _parameterWCF.GetModel(crival.C_CRival_corgan.Value);
                ViewBag.CRival_corgan = CRival_corgan;
            }
            //经营模式参数集合
            CommonService.Model.C_Parameters CRival_smodel = new CommonService.Model.C_Parameters();
            if (crival.C_CRival_smodel==null)
            {
                ViewBag.CRival_smodel = CRival_smodel;
            }else
            {
                CRival_smodel = _parameterWCF.GetModel(crival.C_CRival_smodel.Value);
                ViewBag.CRival_smodel = CRival_smodel;
            }           
        }
	}
}