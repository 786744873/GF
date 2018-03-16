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
    /// 客户银行控制器
    /// </summary>
    public class BankController : BaseController
    {
        private readonly ICommonService.IC_Bank _bankWCF;
        public BankController()
        {
            #region 服务初始化
            _bankWCF = ServiceProxyFactory.Create<ICommonService.IC_Bank>("C_BankWCF");
            #endregion
        }
        //
        // GET: /BaseData/Bank/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string customerCode)
        {
            //创建初始化组客户实体
            CommonService.Model.C_Bank bank = new CommonService.Model.C_Bank();
            bank.C_Bank_code = Guid.NewGuid();
            bank.C_Bank_isDelete = false;
            bank.C_Bank_isDefault = false;

            if (!String.IsNullOrEmpty(customerCode))
            {
                bank.C_Bank_customer = new Guid(customerCode);
            }
            bank.C_Bank_creator = Context.UIContext.Current.UserCode;
            bank.C_Bank_createTime = DateTime.Now;

            return View(bank);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string bankCode)
        {
            CommonService.Model.C_Bank bank = _bankWCF.Get(new Guid(bankCode));
            return View("Create", bank);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Bank bank)
        {
            //服务方法调用
            int bankId = 0;

            if (bank.C_Bank_id > 0)
            {//修改
                bool isUpdateSuccess = _bankWCF.Update(bank);
                if (isUpdateSuccess)
                {
                    bankId = bank.C_Bank_id;
                }
            }
            else
            {//添加
                bank.C_Bank_createTime = DateTime.Now;
                bankId = _bankWCF.Add(bank);
            }

            if (bankId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存银行信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存银行信息成功", "/basedata/bank/create?customerCode=" + bank.C_Bank_customer, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
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
                return Json(TipHelper.JsonData("保存银行信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string bankCode)
        {
            bool isSuccess = _bankWCF.Delete(new Guid(bankCode));
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
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string customerCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //组织机构查询模型
            CommonService.Model.C_Bank bankConditon = new CommonService.Model.C_Bank();
            //客户Guid条件(url参数)
            if (!String.IsNullOrEmpty(customerCode))
            {
                bankConditon.C_Bank_customer = new Guid(customerCode);
            }
            if (bankConditon.C_Bank_customer != null)
            {//url参数到地址栏
                this.AddressUrlParameters = "?customerCode=" + bankConditon.C_Bank_customer;
            }

            //银行查询模型传递到前端视图中
            ViewBag.BankConditon = bankConditon;
            this.PageSize = 13;

            #endregion

            //获取组织机构总记录数
            this.TotalRecordCount = _bankWCF.GetRecordCount(bankConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取组织机构数据信息
            List<CommonService.Model.C_Bank> banks = _bankWCF.GetListByPage(bankConditon,
                "C_Bank_createTime Desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(banks);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="customerCode">客户Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string customerCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //银行查询模型
            CommonService.Model.C_Bank bankConditon = new CommonService.Model.C_Bank();
            //客户Guid条件(url参数)
            if (!String.IsNullOrEmpty(customerCode))
            {
                bankConditon.C_Bank_customer = new Guid(customerCode);
            }
            if (bankConditon.C_Bank_customer != null)
            {//url参数到地址栏
                this.AddressUrlParameters = "?customerCode=" + bankConditon.C_Bank_customer;
            }
            this.PageSize = 13;

            #endregion

            //获取银行总记录数
            this.TotalRecordCount = _bankWCF.GetRecordCount(bankConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取银行数据信息
            List<CommonService.Model.C_Bank> banks = _bankWCF.GetListByPage(bankConditon,
                "C_Bank_createTime Desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(banks);
        }
    }
}