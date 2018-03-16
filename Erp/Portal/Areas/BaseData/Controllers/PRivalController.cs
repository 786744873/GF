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
    /// 法律对手个人信息表控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/07
    /// </summary>
    public class PRivalController : BaseController
    {
        private readonly ICommonService.IC_PRival _privalWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Rival_Region _rivalRegionWCF;

        public PRivalController()
        {
            #region 服务初始化
            _privalWCF = ServiceProxyFactory.Create<ICommonService.IC_PRival>("PRivalWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _rivalRegionWCF = ServiceProxyFactory.Create<ICommonService.IC_Rival_Region>("Rival_RegionWCF");
            #endregion
        }
        //
        // GET: /BaseData/PRival/
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
            InitializationPageParameter();
            //创建初始化个人信息实体
            CommonService.Model.C_PRival prival = new CommonService.Model.C_PRival();
            prival.C_PRival_code = Guid.NewGuid();
            prival.C_PRival_number = "";
            prival.C_PRival_type = 1;
            prival.C_PRival_sex = 1;
            prival.C_PRival_pcode = Guid.NewGuid();
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
        /// 个人详细tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string prival_code)
        {
            CommonService.Model.C_PRival prival = _privalWCF.GetModel(new Guid(prival_code));
            ViewBag.PRival_code = prival_code;
            return View(prival);
        }


        /// <summary>
        /// 个人信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string prival_code)
        {
            CommonService.Model.C_PRival prival = _privalWCF.GetModel(new Guid(prival_code));
            return View(prival);
        }

        /// <summary>
        /// 个人信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult CustDetails(string prival_code)
        {
            CommonService.Model.C_PRival prival = _privalWCF.GetModel(new Guid(prival_code));
            ViewBag.PRival_code = prival.C_PRival_code;
            return View(prival);
        }
        public ActionResult List(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //个人信息查询模型
            CommonService.Model.C_PRival prConditon = new CommonService.Model.C_PRival();
            prConditon.C_PRival_type = 1;
            if (!String.IsNullOrEmpty(form["C_PRival_name"]))
            {//个人名称查询条件
                prConditon.C_PRival_name = form["C_PRival_name"].Trim();
            }

            //法律对手个人信息查询模型传递到前端视图中
            ViewBag.PrConditon = prConditon;

            #endregion

            //获取法律对手个人总记录数
            this.TotalRecordCount = _privalWCF.GetRecordCount(prConditon);
            this.PageSize = 15;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_PRival> prival = _privalWCF.GetListByPage(prConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion
            
            return View(prival);
        }
        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {


            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //个人信息查询模型
            CommonService.Model.C_PRival prConditon = new CommonService.Model.C_PRival();
            prConditon.C_PRival_type = 1;
            if (!String.IsNullOrEmpty(form["C_PRival_name"]))
            {//个人名称查询条件
                prConditon.C_PRival_name = form["C_PRival_name"].Trim();
            }

            //法律对手个人信息查询模型传递到前端视图中
            ViewBag.PrConditon = prConditon;

            #endregion
            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_PRival> checkList = _privalWCF.GetListByPage(prConditon, "", 1, 1000000);

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

            row1.CreateCell(0).SetCellValue("姓名");
            row1.CreateCell(1).SetCellValue("性别");
            row1.CreateCell(2).SetCellValue("出生年月");
            row1.CreateCell(3).SetCellValue("民族");
            row1.CreateCell(4).SetCellValue("籍贯");
            row1.CreateCell(5).SetCellValue("政治面貌");
            row1.CreateCell(6).SetCellValue("住址");
            row1.CreateCell(7).SetCellValue("身份证号");
            row1.CreateCell(8).SetCellValue("联系电话");
            row1.CreateCell(9).SetCellValue("性格特征");
            row1.CreateCell(10).SetCellValue("兴趣爱好");
            row1.CreateCell(11).SetCellValue("信息类型");
            //....N行
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < checkList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(checkList[i].C_PRival_name.ToString());
                if (checkList[i].C_PRival_sex == 1)
                {
                    rowtemp.CreateCell(1).SetCellValue("男");
                }
                else {
                    rowtemp.CreateCell(1).SetCellValue("女");
                }
                    rowtemp.CreateCell(2).SetCellValue(checkList[i].C_PRival_birthday.ToString());

                    if (checkList[i].C_PRival_nation == 71) {
                        rowtemp.CreateCell(3).SetCellValue("汉族");
                    }
                    else if (checkList[i].C_PRival_nation == 113)
                    {
                        rowtemp.CreateCell(3).SetCellValue("回族");
                    }
                    else if (checkList[i].C_PRival_nation == 114)
                    {
                        rowtemp.CreateCell(3).SetCellValue("藏族");
                    }

                    else if (checkList[i].C_PRival_nation == 115)
                    {
                        rowtemp.CreateCell(3).SetCellValue("土家族");
                    }
                    else if (checkList[i].C_PRival_nation == 116)
                    {
                        rowtemp.CreateCell(3).SetCellValue("彝族");
                    }
                    rowtemp.CreateCell(4).SetCellValue(checkList[i].C_PRival_hometown.ToString());
                    if (checkList[i].C_PRival_pa == 73) {
                        rowtemp.CreateCell(5).SetCellValue("无党派人士");
                    }
                    else if (checkList[i].C_PRival_pa == 74)
                    {
                        rowtemp.CreateCell(5).SetCellValue("党员");
                    }
                    rowtemp.CreateCell(6).SetCellValue(checkList[i].C_PRival_address.ToString());
                    rowtemp.CreateCell(7).SetCellValue(checkList[i].C_PRival_cnumber.ToString());
                    rowtemp.CreateCell(8).SetCellValue(checkList[i].C_PRival_phone.ToString());
                    rowtemp.CreateCell(9).SetCellValue(checkList[i].C_PRival_traits.ToString());
                    rowtemp.CreateCell(10).SetCellValue(checkList[i].C_PRival_hobby.ToString());
                    if (checkList[i].C_PRival_type == 1)
                    {
                        rowtemp.CreateCell(11).SetCellValue("本人");
                    }
                    else {
                        rowtemp.CreateCell(11).SetCellValue("配偶");
                    }

                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "个人对手列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
        /// <summary>
        /// 单选回调个人列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList(FormCollection form,string type, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //个人信息查询模型
            CommonService.Model.C_PRival prConditon = new CommonService.Model.C_PRival();
            prConditon.C_PRival_type = 1;
            if (!String.IsNullOrEmpty(form["C_PRival_name"]))
            {//个人名称查询条件
                prConditon.C_PRival_name = form["C_PRival_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["type"]))
            {//个人名称查询条件
                type = form["type"].Trim();
            }
            ViewBag.type = type;
       

            this.AddressUrlParameters = "?type=" + type;
            ViewBag.type = type;
            //法律对手个人信息查询模型传递到前端视图中
            ViewBag.PrConditon = prConditon;

            #endregion

            //获取法律对手个人总记录数
            this.TotalRecordCount = _privalWCF.GetRecordCount(prConditon);
            this.PageSize = 8;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_PRival> prival = _privalWCF.GetListByPage(prConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(prival);
        }

        /// <summary>
        /// 多选回调个人列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefList(FormCollection form,string checkedRivalCode, string type, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //个人信息查询模型
            CommonService.Model.C_PRival prConditon = new CommonService.Model.C_PRival();
            prConditon.C_PRival_type = 1;
            if (!String.IsNullOrEmpty(form["C_PRival_name"]))
            {//个人名称查询条件
                prConditon.C_PRival_name = form["C_PRival_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["type"]))
            {//个人名称查询条件
                type = form["type"].Trim();
            }
            ViewBag.type = type;
            ViewBag.checkedRivalCode = checkedRivalCode;
            //法律对手个人信息查询模型传递到前端视图中
            ViewBag.PrConditon = prConditon;

            this.AddressUrlParameters = "?type=" + type;

            #endregion

            //获取法律对手个人总记录数
            this.TotalRecordCount = _privalWCF.GetRecordCount(prConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 9;

            List<CommonService.Model.C_PRival> prival = _privalWCF.GetListByPage(prConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(prival);
        }

        #region 自定义表单列表编辑页面所用Callback带回

        /// <summary>
        /// 单选回调个人列表(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="rebuildProperty">重组表单属性</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList_PrivalForm_List(FormCollection form, string lookupgroup, string rebuildProperty, string mappingField, string mappingFieldName, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //个人查询模型
            CommonService.Model.C_PRival privalConditon = new CommonService.Model.C_PRival();

            if (!String.IsNullOrEmpty(form["C_PRival_name"]))
            {//个人名称查询条件
                privalConditon.C_PRival_name = form["C_PRival_name"].Trim();
            }
            //个人查询模型传递到前端视图中
            ViewBag.PrivalConditon = privalConditon;
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

            //获取个人总记录数
            this.TotalRecordCount = _privalWCF.GetRecordCount(privalConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取个人数据信息
            List<CommonService.Model.C_PRival> privals = _privalWCF.GetListByPage(privalConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(privals);
        }

        #endregion

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_PRival prival)
        {
            if(_privalWCF.ExistsByName(prival))
            {//对手名称是否存在
                return Json(TipHelper.JsonData("此对手个人名称已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            #region 关联区域

            List<CommonService.Model.C_Rival_Region> rivalRegionList = new List<CommonService.Model.C_Rival_Region>();
            string regionCodeStr = form["regionlookup.Code"];
            if (regionCodeStr != "")
            {
                string[] regionCodes = regionCodeStr.Split(',');
                foreach (var regionCode in regionCodes)
                {
                    CommonService.Model.C_Rival_Region rivalRegion = new CommonService.Model.C_Rival_Region();
                    rivalRegion.C_Rival_Region_rival = prival.C_PRival_code;
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

            if (prival.C_PRival_id > 0)
            {//修改
                bool isUpdateSuccess = _privalWCF.Update(prival);
                if (isUpdateSuccess)
                {
                    crivalId = prival.C_PRival_id;
                }
            }
            else
            {//添加
                prival.C_PRival_createTime = DateTime.Now;
                crivalId = _privalWCF.Add(prival);
            }

            if (crivalId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存个人信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存个人信息成功", "/basedata/PRival/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存个人信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存个人信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
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
                return Json(TipHelper.JsonData("删除个人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除个人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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