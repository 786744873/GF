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
    /// 财产线索银行控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
    public class Property_trail_bankController : BaseController
    {
        private readonly ICommonService.IC_Property_trail_bank _property_trail_bankWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public Property_trail_bankController()
        {
            #region 服务初始化
            _property_trail_bankWCF = ServiceProxyFactory.Create<ICommonService.IC_Property_trail_bank>("Property_trail_bankWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /BaseData/Property_trail_bank/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string property_trail_bank_belongs, int? property_trail_bank_type)
        {
            InitializationPageParameter();
            //创建初始化财产线索银行实体
            CommonService.Model.C_Property_trail_bank bank = new CommonService.Model.C_Property_trail_bank();
            if (property_trail_bank_type != null)
            {
                bank.C_Property_trail_bank_type = property_trail_bank_type;
            }
            if (!String.IsNullOrEmpty(property_trail_bank_belongs))
            {
                bank.C_Property_trail_bank_belongs = new Guid(property_trail_bank_belongs);
            }
            bank.C_Property_trail_bank_code = "";
            bank.C_Property_trail_bank_rTime = DateTime.Now;
            bank.C_Property_trail_bank_creator = Context.UIContext.Current.UserCode;
            bank.C_Property_trail_bank_createTime = DateTime.Now;
            bank.C_Property_trail_bank_isDelete = 0;

            return View(bank);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int property_trail_bank_id)
        {
            InitializationPageParameter();
            CommonService.Model.C_Property_trail_bank bank = _property_trail_bankWCF.GetModel(property_trail_bank_id);
            return View("Create", bank);
        }

        public ActionResult List(FormCollection form, string property_trail_bank_belongs, int? property_trail_bank_type, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //财产线索银行查询模型
            CommonService.Model.C_Property_trail_bank bankConditon = new CommonService.Model.C_Property_trail_bank();

            if (!String.IsNullOrEmpty(property_trail_bank_belongs))
            {//财产线索银行所属查询条件
                bankConditon.C_Property_trail_bank_belongs = new Guid(property_trail_bank_belongs);
            }
            if (property_trail_bank_type != null)
            {//财产线索银行所属查询条件
                bankConditon.C_Property_trail_bank_type = property_trail_bank_type;
            }

            //财产线索银行查询模型传递到前端视图中
            ViewBag.BankConditon = bankConditon;

            #endregion

            //获取财产线索银行总记录数
            this.TotalRecordCount = _property_trail_bankWCF.GetRecordCount(bankConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 9;

            List<CommonService.Model.C_Property_trail_bank> crival = _property_trail_bankWCF.GetListByPage(bankConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string property_trail_bank_belongs, int? property_trail_bank_type, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //财产线索银行查询模型
            CommonService.Model.C_Property_trail_bank bankConditon = new CommonService.Model.C_Property_trail_bank();

            if (!String.IsNullOrEmpty(property_trail_bank_belongs))
            {//财产线索银行所属查询条件
                bankConditon.C_Property_trail_bank_belongs = new Guid(property_trail_bank_belongs);
            }
            if (property_trail_bank_type != null)
            {//财产线索银行所属查询条件
                bankConditon.C_Property_trail_bank_type = property_trail_bank_type;
            }

            this.AddressUrlParameters = "?property_trail_bank_belongs=" + property_trail_bank_belongs + "&property_trail_bank_type=" + property_trail_bank_type;
            //财产线索银行查询模型传递到前端视图中
            ViewBag.BankConditon = bankConditon;

            #endregion

            //获取财产线索银行总记录数
            this.TotalRecordCount = _property_trail_bankWCF.GetRecordCount(bankConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 8;

            //获取财产线索银行数据信息
            List<CommonService.Model.C_Property_trail_bank> change = _property_trail_bankWCF.GetListByPage(bankConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(change);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Property_trail_bank bank)
        {
            //服务方法调用
            int bankId = 0;

            if (bank.C_Property_trail_bank_id > 0)
            {//修改
                bool isUpdateSuccess = _property_trail_bankWCF.Update(bank);
                if (isUpdateSuccess)
                {
                    bankId = bank.C_Property_trail_bank_id;
                }
            }
            else
            {//添加
                bank.C_Property_trail_bank_createTime = DateTime.Now;
                bankId = _property_trail_bankWCF.Add(bank);
            }

            if (bankId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存银行信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存银行信息成功", "/basedata/Property_trail_bank/create?property_trail_bank_belongs="+bank.C_Property_trail_bank_belongs+"&property_trail_bank_type="+bank.C_Property_trail_bank_type, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存银行信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存银行信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int property_trail_bank_id)
        {
            bool isSuccess = _property_trail_bankWCF.Delete(property_trail_bank_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除银行信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除银行信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //账号类型参数集合
            List<CommonService.Model.C_Parameters> AccountType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Property_trail_bankEnum.账号类型));
            ViewBag.AccountType = AccountType;
        }
	}
}