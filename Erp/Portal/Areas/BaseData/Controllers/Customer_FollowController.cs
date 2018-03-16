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
    /// 客户跟进控制器
    /// </summary>
    public class Customer_FollowController : BaseController
    {
        private readonly ICommonService.IC_Customer_Follow _customer_FollowWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Customer _customerWCF;
        public Customer_FollowController()
        {
            #region 服务初始化
            _customer_FollowWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Follow>("CustomerFollowWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            #endregion
        }
        //
        // GET: /BaseData/Customer_Follow/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string customerCode)
        {
            InitializationPageParameter();
            //创建初始化案件实体
            CommonService.Model.C_Customer_Follow customerFollow = new CommonService.Model.C_Customer_Follow();
            customerFollow.C_Customer_Follow_code = Guid.NewGuid();
            if (!String.IsNullOrEmpty(customerCode))
            {
                customerFollow.C_Customer_code = new Guid(customerCode);
            }
            customerFollow.C_Customer_Follow_time = DateTime.Now;
            customerFollow.C_Customer_Follow_creator = Context.UIContext.Current.UserCode;
            customerFollow.C_Customer_Follow_createTime = DateTime.Now;
            customerFollow.C_Customer_Follow_isDelete = 0;

            List<CommonService.Model.C_Contacts> contactsList = _customerWCF.GetContactsListByCustomerCode(new Guid(customerCode));
            ViewBag.ContactsList = contactsList;

            return View(customerFollow);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int customer_Follow_id)
        {
            InitializationPageParameter();
            CommonService.Model.C_Customer_Follow customerFollow = _customer_FollowWCF.GetModel(customer_Follow_id);

            List<CommonService.Model.C_Contacts> contactsList = _customerWCF.GetContactsListByCustomerCode(customerFollow.C_Customer_code.Value);
            ViewBag.ContactsList = contactsList;

            return View("Create", customerFollow);
        }

        public ActionResult List(FormCollection form,string customerCode,int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.C_Customer_Follow Conditon = new CommonService.Model.C_Customer_Follow();
            if (!String.IsNullOrEmpty(customerCode))
            {
                Conditon.C_Customer_code = new Guid(customerCode.ToString());
            }
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;
            ViewBag.CustomerCode = customerCode;
            #endregion

            //获取总记录数
            this.TotalRecordCount = _customer_FollowWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 15;

            List<CommonService.Model.C_Customer_Follow> customerFollow = _customer_FollowWCF.GetListByPage(Conditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(customerFollow);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Customer_Follow customerFollow)
        {
            //服务方法调用
            int customerFollowId = 0;

            if (customerFollow.C_Customer_Follow_id > 0)
            {//修改
                bool isUpdateSuccess = _customer_FollowWCF.Update(customerFollow);
                if (isUpdateSuccess)
                {
                    customerFollowId = customerFollow.C_Customer_Follow_id;
                }
            }
            else
            {//添加
                customerFollow.C_Customer_Follow_createTime = DateTime.Now;
                customerFollowId = _customer_FollowWCF.Add(customerFollow);
                //添加完成后更新客户的最后接触时间
                CommonService.Model.C_Customer model = _customerWCF.Get(new Guid(customerFollow.C_Customer_code.ToString()));
                model.C_Customer_lastContactDate = customerFollow.C_Customer_Follow_createTime;
                if (!_customerWCF.Update(model))
                    customerFollowId = -1;
            }

            if (customerFollowId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存客户跟进信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存客户跟进信息成功", "/basedata/customer_Follow/create?customerCode=" + customerFollow.C_Customer_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存客户跟进信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存客户跟进信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int customer_Follow_id)
        {
            bool isSuccess = _customer_FollowWCF.Delete(customer_Follow_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除客户跟进信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除客户跟进信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //跟进阶段参数集合
            List<CommonService.Model.C_Parameters> Customer_Follow_Stages = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFollowEnum.跟进阶段));
            ViewBag.Customer_Follow_Stages = Customer_Follow_Stages;
            //联系方式参数集合
            List<CommonService.Model.C_Parameters> contactInformations = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFollowEnum.联系方式));
            ViewBag.ContactInformations = contactInformations;
        }
	}
}