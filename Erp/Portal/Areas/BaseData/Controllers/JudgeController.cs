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
    /// 法官信息控制器
    /// </summary>
    public class JudgeController : BaseController
    {
        private readonly ICommonService.IC_Judge _judgeWCF;
        private readonly ICommonService.IC_Contacts _contactsWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Court_Judge _court_judgeWCF;
        public JudgeController()
        {
            #region 服务初始化
            _judgeWCF = ServiceProxyFactory.Create<ICommonService.IC_Judge>("JudgeWCF");
            _contactsWCF = ServiceProxyFactory.Create<ICommonService.IC_Contacts>("ContactsWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _court_judgeWCF = ServiceProxyFactory.Create<ICommonService.IC_Court_Judge>("Court_JudgeWCF");
            #endregion
        }
        //
        // GET: /BaseData/Judge/
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
            //创建初始化法官实体
            CommonService.Model.C_Contacts judge = new CommonService.Model.C_Contacts();
            judge.C_Contacts_code = Guid.NewGuid();
            judge.C_Contacts_number = "";
            judge.C_Contacts_type = 4;
            judge.C_Contacts_sex = 1;
            judge.C_Contacts_relationCode = Guid.NewGuid();
            judge.C_Contacts_birthday = DateTime.Now;
            judge.C_Contacts_creator = Context.UIContext.Current.UserCode;
            judge.C_Contacts_createTime = DateTime.Now;
            judge.C_Contacts_isDelete = 0;

            return View(judge);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string C_Contacts_code)
        {
            InitializationPageParameter();
            CommonService.Model.C_Contacts contacts = _contactsWCF.Get(new Guid(C_Contacts_code));
            return View("Create", contacts);
        }

        public ActionResult List(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法官查询模型
            CommonService.Model.C_Contacts judConditon = new CommonService.Model.C_Contacts();
            judConditon.C_Contacts_type = 4;
            judConditon.C_Contacts_relationCode = Guid.NewGuid();
            if (!String.IsNullOrEmpty(form["C_Contacts_name"]))
            {//法官名称查询条件
                judConditon.C_Contacts_name = form["C_Contacts_name"].Trim();
            }
            //C_Contacts_mobile
            if (!String.IsNullOrEmpty(form["C_Contacts_contact_number"]))
            {//法官名称查询条件
                judConditon.C_Contacts_contact_number = form["C_Contacts_contact_number"].Trim();
            }

            //法官查询模型传递到前端视图中
            ViewBag.JudgeConditon = judConditon;

            #endregion

            //获取法官总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(judConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts> contacts = _contactsWCF.GetListByPage(judConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion
            
            return View(contacts);
        }
        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {

            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法官查询模型
            CommonService.Model.C_Contacts judConditon = new CommonService.Model.C_Contacts();
            judConditon.C_Contacts_type = 4;
            judConditon.C_Contacts_relationCode = Guid.NewGuid();
            if (!String.IsNullOrEmpty(form["C_Contacts_name"]))
            {//法官名称查询条件
                judConditon.C_Contacts_name = form["C_Contacts_name"].Trim();
            }

            //法官查询模型传递到前端视图中
            ViewBag.JudgeConditon = judConditon;

            #endregion

            //获取法官总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(judConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts> checkList = _contactsWCF.GetListByPage(judConditon, "", 1, 1000000);


            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);

            row1.CreateCell(0).SetCellValue("姓名");
            row1.CreateCell(1).SetCellValue("性别");
            row1.CreateCell(2).SetCellValue("政治面貌");
            row1.CreateCell(3).SetCellValue("住址");
            row1.CreateCell(4).SetCellValue("联系电话");
             row1.CreateCell(5).SetCellValue("性格特征");
            row1.CreateCell(6).SetCellValue("兴趣爱好");
            //....N行
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < checkList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(checkList[i].C_Contacts_name.ToString());
                if (checkList[i].C_Contacts_sex == 1)
                {
                    rowtemp.CreateCell(1).SetCellValue("男");
                }
                else {
                    rowtemp.CreateCell(1).SetCellValue("女");
                }
                if (checkList[i].C_Contacts_political == 73) {
                    rowtemp.CreateCell(2).SetCellValue("无党派人士");
                }
                else if (checkList[i].C_Contacts_political == 74)
                {
                    rowtemp.CreateCell(2).SetCellValue("党员");
                }
                rowtemp.CreateCell(3).SetCellValue(checkList[i].C_Contacts_address.ToString());
                rowtemp.CreateCell(4).SetCellValue(checkList[i].C_Contacts_contact_number.ToString());
                rowtemp.CreateCell(5).SetCellValue(checkList[i].C_Contacts_character.ToString());
                rowtemp.CreateCell(6).SetCellValue(checkList[i].C_Contacts_hobby.ToString());
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "法官列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
        /// <summary>
        /// 多选全部法官
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relCode">关联Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityRefList(FormCollection form, string courtCode, string type, string duty, string judgecode, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法官查询模型
            CommonService.Model.C_Contacts judConditon = new CommonService.Model.C_Contacts();
            judConditon.C_Contacts_type = 4;
            judConditon.C_Contacts_relationCode = Guid.NewGuid();
            if (!String.IsNullOrEmpty(form["C_Contacts_name"]))
            {//法官名称查询条件
                judConditon.C_Contacts_name = form["C_Contacts_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["CourtCode"]))
            {//法院Guid
                courtCode = form["CourtCode"];
            }
            if (!String.IsNullOrEmpty(form["Type"]))
            {//
                type = form["Type"];
            }
            if (!String.IsNullOrEmpty(form["Duty"]))
            {//
                duty = form["Duty"];
            }
            //法官查询模型传递到前端视图中 
            ViewBag.JudgeConditon = judConditon;
            ViewBag.CourtCode = courtCode;
            ViewBag.Type = type;
            ViewBag.Duty = duty;
            ViewBag.JudgeCode = judgecode;
            #endregion

            //获取法官总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(judConditon);
            this.PageSize = 12;
            this.AddressUrlParameters = "?courtCode=" + courtCode + "&type=" + type + "&duty=" + duty + "&judgecode=" + judgecode;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts> contacts = _contactsWCF.GetListByPage(judConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(contacts);
        }
        /// <summary>
        /// 多选回调法管列表(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">多选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList_JudgeForm(FormCollection form, string lookupgroup, string propertyValueCode, string mappingField, string mappingFieldName, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //法官查询模型
            CommonService.Model.C_Contacts judConditon = new CommonService.Model.C_Contacts();
            judConditon.C_Contacts_type = 4;
            judConditon.C_Contacts_relationCode = Guid.NewGuid();
            if (!String.IsNullOrEmpty(form["C_Contacts_name"]))
            {//法官名称查询条件
                judConditon.C_Contacts_name = form["C_Contacts_name"].Trim();
            }

            //法官查询模型传递到前端视图中
            ViewBag.JudgeConditon = judConditon;

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
            #endregion
            //获取法官总记录数
            this.TotalRecordCount = _contactsWCF.GetRecordCount(judConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Contacts> contacts = _contactsWCF.GetListByPage(judConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(contacts);
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Contacts judge)
        {
            //服务方法调用
            int contactsId = 0;

            if (judge.C_Contacts_id > 0)
            {//修改
                bool isUpdateSuccess = _contactsWCF.Update(judge);
                if (isUpdateSuccess)
                {
                    contactsId = judge.C_Contacts_id;
                }
            }
            else
            {//添加
                judge.C_Contacts_createTime = DateTime.Now;
                contactsId = _contactsWCF.Add(judge);
                if (contactsId > 0)
                {
                    CommonService.Model.C_Judge jud = new CommonService.Model.C_Judge();
                    jud.C_Judge_code = judge.C_Contacts_relationCode;
                    jud.C_Judge_contactscode = judge.C_Contacts_code;
                    jud.C_Judge_createTime = DateTime.Now;
                    jud.C_Judge_creator = Context.UIContext.Current.UserCode;
                    contactsId = _judgeWCF.Add(jud);
                }

            }

            if (contactsId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存法官信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存法官信息成功", "/BaseData/Judge/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存法官信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存法官信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string C_Contacts_code, string relationCode, int contactType)
        {
            bool isSuccess = _contactsWCF.Delete(new Guid(C_Contacts_code), new Guid(relationCode), contactType);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除法官信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除法官信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 关联法官添加
        /// </summary>
        /// <param name="courtCode">法官Guid串，用逗号隔开</param>
        /// <returns></returns>
        public ActionResult RelationJudge(string judge_codes, string courtCode, string types, string dutys)
        {
            bool isSuccess = false;

            List<CommonService.Model.C_Court_Judge> courtJudgeList = new List<CommonService.Model.C_Court_Judge>();
            string[] c_judge_codes = judge_codes.Split(',');

            if (courtCode != Guid.Empty.ToString())
            {//关联法官
                for (int i = 0; i < c_judge_codes.Length; i++)
                {
                    string judgeCode = c_judge_codes[i];
                    if (c_judge_codes[i] == "")
                    {
                        judgeCode = Guid.Empty.ToString();
                    }
                    CommonService.Model.C_Court_Judge courtJudge = new CommonService.Model.C_Court_Judge();
                    CommonService.Model.C_Judge judge = _judgeWCF.GetModelByJudgeCode(new Guid(judgeCode));
                    if (judge == null)
                    {
                        judge = new CommonService.Model.C_Judge();
                    }
                    courtJudge.C_Court_code = new Guid(courtCode);
                    courtJudge.C_Judge_code = new Guid(judgeCode);
                    courtJudge.C_Court_Judge_type = types;
                    courtJudge.C_Court_Judge_duty = dutys;
                    courtJudge.C_Court_Judge_name = judge.C_Contacts_name;
                    courtJudge.C_Court_Judge_creator = Context.UIContext.Current.UserCode;
                    courtJudge.C_Court_Judge_createTime = DateTime.Now;
                    courtJudge.C_Court_Judge_isdelete = 0;

                    courtJudgeList.Add(courtJudge);
                }
            }
            isSuccess = _court_judgeWCF.OperateList(courtJudgeList);   

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联法官信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联法官信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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
            List<CommonService.Model.C_Parameters> Contacts_nation = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ContactsEnum.民族));
            ViewBag.Contacts_nation = Contacts_nation;
            //政治面貌参数集合
            List<CommonService.Model.C_Parameters> Contacts_political = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ContactsEnum.政治面貌));
            ViewBag.Contacts_political = Contacts_political;
        }


    }
}