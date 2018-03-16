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
    /// 客户地址Control
    /// </summary>
    public class AddressController : BaseController
    {
        private readonly ICommonService.IC_Address _addressWCF;

        public AddressController()
        {
            _addressWCF = ServiceProxyFactory.Create<ICommonService.IC_Address>("AddressWCF");
        }

        //
        // GET: /BaseData/Address/
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
            //创建初始化客户地址实体
            CommonService.Model.C_Address address = new CommonService.Model.C_Address();
            address.C_Address_shortName = "";
            address.C_Address_code = Guid.NewGuid();
            address.C_Address_isDelete = false;
            address.C_Address_isMainAddress = false;

            if (!String.IsNullOrEmpty(customerCode))
            {
                address.C_Address_customer = new Guid(customerCode);
            }
            address.C_Address_creator = Context.UIContext.Current.UserCode;
            address.C_Address_createTime = DateTime.Now;

            return View(address);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string addressCode)
        {
            CommonService.Model.C_Address address = _addressWCF.Get(new Guid(addressCode));
            return View("Create", address);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Address address)
        {
            //服务方法调用
            int address_id = 0;

            if (address.C_Address_id > 0)
            {//修改
                bool isUpdateSuccess = _addressWCF.Update(address);
                if (isUpdateSuccess)
                {
                    address_id = address.C_Address_id;
                }
            }
            else
            {//添加
                address.C_Address_createTime = DateTime.Now;
                address_id = _addressWCF.Add(address);
            }

            if (address_id > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存地址信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存地址信息成功", "/basedata/address/create?customerCode="+address.C_Address_customer, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存地址信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存地址信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string addressCode)
        {
            bool isSuccess = _addressWCF.Delete(new Guid(addressCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除地址信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除地址信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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

            //客户地址查询模型
            CommonService.Model.C_Address addressConditon = new CommonService.Model.C_Address();
            //客户Guid条件(url参数)
            if (!String.IsNullOrEmpty(customerCode))
            {
                addressConditon.C_Address_customer = new Guid(customerCode);
            }
            if (addressConditon.C_Address_customer != null)
            {//url参数到地址栏
                this.AddressUrlParameters = "?customerCode=" + addressConditon.C_Address_customer;
            }

            //地址查询模型传递到前端视图中
            ViewBag.AddressConditon = addressConditon;
            this.PageSize = 13;

            #endregion

            //获取客户地址总记录数
            this.TotalRecordCount = _addressWCF.GetRecordCount(addressConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户地址数据信息
            List<CommonService.Model.C_Address> companys = _addressWCF.GetListByPage(addressConditon,
                "C_Address_createTime Desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(companys);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="customerCode">客户Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string customerCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户地址查询模型
            CommonService.Model.C_Address addressConditon = new CommonService.Model.C_Address();
            //客户Guid条件(url参数)
            if (!String.IsNullOrEmpty(customerCode))
            {
                addressConditon.C_Address_customer = new Guid(customerCode);
            }
            if (addressConditon.C_Address_customer != null)
            {//url参数到地址栏
                this.AddressUrlParameters = "?customerCode=" + addressConditon.C_Address_customer;
            }

            this.PageSize = 13;

            #endregion

            //获取客户地址总记录数
            this.TotalRecordCount = _addressWCF.GetRecordCount(addressConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户地址数据信息
            List<CommonService.Model.C_Address> companys = _addressWCF.GetListByPage(addressConditon,
                "C_Address_createTime Desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(companys);
        }

	}
}