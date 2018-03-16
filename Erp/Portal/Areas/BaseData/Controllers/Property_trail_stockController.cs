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
    /// 财产线索股票控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
    public class Property_trail_stockController : BaseController
    {
        private readonly ICommonService.IC_Property_trail_stock _property_trail_stockWCF;

        public Property_trail_stockController()
        {
            #region 服务初始化
            _property_trail_stockWCF = ServiceProxyFactory.Create<ICommonService.IC_Property_trail_stock>("Property_trail_stockWCF");
            #endregion
        }
        //
        // GET: /BaseData/Property_trail_stock/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string property_trail_stock_belongs, int? property_trail_stock_type)
        {
            //创建初始化财产线索股票实体
            CommonService.Model.C_Property_trail_stock stock = new CommonService.Model.C_Property_trail_stock();
            if (property_trail_stock_type != null)
            {
                stock.C_Property_trail_stock_type = property_trail_stock_type;
            }
            if (!String.IsNullOrEmpty(property_trail_stock_belongs))
            {
                stock.C_Property_trail_stock_belongs = new Guid(property_trail_stock_belongs);
            }
            stock.C_Property_trail_stock_code = "";
            stock.C_Property_trail_stock_creator = Context.UIContext.Current.UserCode;
            stock.C_Property_trail_stock_createTime = DateTime.Now;
            stock.C_Property_trail_stock_isDelete = 0;

            return View(stock);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int property_trail_stock_id)
        {
            CommonService.Model.C_Property_trail_stock crival = _property_trail_stockWCF.GetModel(property_trail_stock_id);
            return View("Create", crival);
        }

        public ActionResult List(FormCollection form, string property_trail_stock_belongs, int? property_trail_stock_type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //财产线索股票查询模型
            CommonService.Model.C_Property_trail_stock stockConditon = new CommonService.Model.C_Property_trail_stock();

            if (!String.IsNullOrEmpty(property_trail_stock_belongs))
            {//财产线索股票所属查询条件
                stockConditon.C_Property_trail_stock_belongs = new Guid(property_trail_stock_belongs);
            }
            if (property_trail_stock_type != null)
            {//财产线索股票所属查询条件
                stockConditon.C_Property_trail_stock_type = property_trail_stock_type;
            }

            //财产线索股票查询模型传递到前端视图中
            ViewBag.StockConditon = stockConditon;

            #endregion

            //获取财产线索股票总记录数
            this.TotalRecordCount = _property_trail_stockWCF.GetRecordCount(stockConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 9;

            List<CommonService.Model.C_Property_trail_stock> crival = _property_trail_stockWCF.GetListByPage(stockConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string property_trail_stock_belongs, int? property_trail_stock_type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)
            //财产线索股票查询模型
            CommonService.Model.C_Property_trail_stock stockConditon = new CommonService.Model.C_Property_trail_stock();

            if (!String.IsNullOrEmpty(property_trail_stock_belongs))
            {//财产线索股票所属查询条件
                stockConditon.C_Property_trail_stock_belongs = new Guid(property_trail_stock_belongs);
            }
            if (property_trail_stock_type != null)
            {//财产线索股票所属查询条件
                stockConditon.C_Property_trail_stock_type = property_trail_stock_type;
            }

            this.AddressUrlParameters = "?property_trail_stock_belongs=" + property_trail_stock_belongs + "&property_trail_stock_type=" + property_trail_stock_type;
            //财产线索股票查询模型传递到前端视图中
            ViewBag.StockConditon = stockConditon;

            #endregion

            //获取财产线索股票总记录数
            this.TotalRecordCount = _property_trail_stockWCF.GetRecordCount(stockConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 8;

            //获取财产线索股票数据信息
            List<CommonService.Model.C_Property_trail_stock> car = _property_trail_stockWCF.GetListByPage(stockConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(car);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Property_trail_stock stock)
        {
            //服务方法调用
            int stockId = 0;

            if (stock.C_Property_trail_stock_id > 0)
            {//修改
                bool isUpdateSuccess = _property_trail_stockWCF.Update(stock);
                if (isUpdateSuccess)
                {
                    stockId = stock.C_Property_trail_stock_id;
                }
            }
            else
            {//添加
                stock.C_Property_trail_stock_createTime = DateTime.Now;
                stockId = _property_trail_stockWCF.Add(stock);
            }

            if (stockId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存股票信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存股票信息成功", "/basedata/Property_trail_stock/create?property_trail_stock_belongs="+stock.C_Property_trail_stock_belongs+"&property_trail_stock_type="+stock.C_Property_trail_stock_type, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存股票信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存股票信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int property_trail_stock_id)
        {
            bool isSuccess = _property_trail_stockWCF.Delete(property_trail_stock_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除股票信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除股票信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}