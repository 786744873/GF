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
    /// 财产线索车辆控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
    public class Property_trail_carsController : BaseController
    {
        private readonly ICommonService.IC_Property_trail_cars _property_trail_carsWCF;

        public Property_trail_carsController()
        {
            #region 服务初始化
            _property_trail_carsWCF = ServiceProxyFactory.Create<ICommonService.IC_Property_trail_cars>("Property_trail_carsWCF");
            #endregion
        }

        //
        // GET: /BaseData/Property_trail_cars/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string property_trail_cars_belongs, int? property_trail_cars_type)
        {
            //创建初始化车辆财产线索实体
            CommonService.Model.C_Property_trail_cars cars = new CommonService.Model.C_Property_trail_cars();
            if (property_trail_cars_type!=null)
            {
                cars.C_Property_trail_cars_type = property_trail_cars_type;
            }
            if (!String.IsNullOrEmpty(property_trail_cars_belongs))
            {
                cars.C_Property_trail_cars_belongs = new Guid(property_trail_cars_belongs);
            }
            cars.C_Property_trail_cars_code = "";
            cars.C_Property_trail_cars_buyDate = DateTime.Now;
            cars.C_Property_trail_cars_creator = Context.UIContext.Current.UserCode;
            cars.C_Property_trail_cars_createTime = DateTime.Now;
            cars.C_Property_trail_cars_isDelete = 0;

            return View(cars);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int property_trail_cars_id)
        {
            CommonService.Model.C_Property_trail_cars crival = _property_trail_carsWCF.GetModel(property_trail_cars_id);
            return View("Create", crival);
        }

        public ActionResult List(FormCollection form,string property_trail_cars_belongs,int? property_trail_cars_type,int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //车辆财产线索查询模型
            CommonService.Model.C_Property_trail_cars carConditon = new CommonService.Model.C_Property_trail_cars();

            if (!String.IsNullOrEmpty(property_trail_cars_belongs))
            {//车辆财产线索所属查询条件
                carConditon.C_Property_trail_cars_belongs = new Guid(property_trail_cars_belongs);
            }
            if (property_trail_cars_type!=null)
            {//车辆财产线索所属查询条件
                carConditon.C_Property_trail_cars_type = property_trail_cars_type;
            }

            //车辆财产线索查询模型传递到前端视图中
            ViewBag.CarConditon = carConditon;

            #endregion

            //获取车辆财产线索总记录数
            this.TotalRecordCount = _property_trail_carsWCF.GetRecordCount(carConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 9;

            List<CommonService.Model.C_Property_trail_cars> crival = _property_trail_carsWCF.GetListByPage(carConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string property_trail_cars_belongs, int? property_trail_cars_type, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //车辆财产线索查询模型
            CommonService.Model.C_Property_trail_cars carConditon = new CommonService.Model.C_Property_trail_cars();

            if (!String.IsNullOrEmpty(property_trail_cars_belongs))
            {//车辆财产线索所属查询条件
                carConditon.C_Property_trail_cars_belongs = new Guid(property_trail_cars_belongs);
            }
            if (property_trail_cars_type != null)
            {//车辆财产线索所属查询条件
                carConditon.C_Property_trail_cars_type = property_trail_cars_type;
            }

            this.AddressUrlParameters = "?property_trail_cars_belongs=" + property_trail_cars_belongs + "&property_trail_cars_type=" + property_trail_cars_type;
            //车辆财产线索查询模型传递到前端视图中
            ViewBag.CarConditon = carConditon;

            #endregion

            //获取车辆财产线索总记录数
            this.TotalRecordCount = _property_trail_carsWCF.GetRecordCount(carConditon);
            this.PageSize = 8;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取车辆财产线索数据信息
            List<CommonService.Model.C_Property_trail_cars> car = _property_trail_carsWCF.GetListByPage(carConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(car);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Property_trail_cars crival)
        {
            //服务方法调用
            int crivalId = 0;

            if (crival.C_Property_trail_cars_id > 0)
            {//修改
                bool isUpdateSuccess = _property_trail_carsWCF.Update(crival);
                if (isUpdateSuccess)
                {
                    crivalId = crival.C_Property_trail_cars_id;
                }
            }
            else
            {//添加
                crival.C_Property_trail_cars_createTime = DateTime.Now;
                crivalId = _property_trail_carsWCF.Add(crival);
            }

            if (crivalId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存车辆信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存车辆信息成功", "/basedata/Property_trail_cars/create?property_trail_cars_belongs="+crival.C_Property_trail_cars_belongs+"&property_trail_cars_type="+crival.C_Property_trail_cars_type, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存车辆信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存车辆信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int property_trail_cars_id)
        {
            bool isSuccess = _property_trail_carsWCF.Delete(property_trail_cars_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除车辆信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除车辆信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}