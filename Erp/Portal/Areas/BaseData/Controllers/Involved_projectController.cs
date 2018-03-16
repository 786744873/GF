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
    /// 涉案项目控制器
    ///  作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
    public class Involved_projectController : BaseController
    {
        private readonly ICommonService.IC_Involved_project _involved_projectWCF;
        public Involved_projectController()
        {
            #region 服务初始化
            _involved_projectWCF = ServiceProxyFactory.Create<ICommonService.IC_Involved_project>("Involved_projectWCF");
            #endregion
        }
        //
        // GET: /BaseData/Involved_project/
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
            //创建初始化涉案项目实体
            CommonService.Model.C_Involved_project involved_project = new CommonService.Model.C_Involved_project();
            involved_project.C_Involved_project_code = Guid.NewGuid();
            involved_project.C_Involved_project_createTime = DateTime.Now;
            involved_project.C_Involved_project_creator = Context.UIContext.Current.UserCode;
            involved_project.C_Involved_project_isDelete =0;

            return View(involved_project);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string Involved_project_code)
        {
            CommonService.Model.C_Involved_project involved_project = _involved_projectWCF.GetModelByCode(new Guid(Involved_project_code));
            return View("Create", involved_project);
        }


        /// <summary>
        /// tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string Involved_project_code)
        {
            ViewBag.Involved_project_code = Involved_project_code;
            return View();
        }

        /// <summary>
        /// tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult CutTabDetails(string Involved_project_code)
        {
            ViewBag.Involved_project_code = Involved_project_code;
            return View();
        }

        /// <summary>
        /// 详细
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string Involved_project_code)
        {
            CommonService.Model.C_Involved_project project = _involved_projectWCF.GetModelByCode(new Guid(Involved_project_code));
            return View(project);
        }


        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //涉案项目查询模型
            CommonService.Model.C_Involved_project projectConditon = new CommonService.Model.C_Involved_project();

            if (!String.IsNullOrEmpty(form["C_Involved_project_name"]))
            {//涉案项目名称查询条件
                projectConditon.C_Involved_project_name = form["C_Involved_project_name"].Trim();
            }
            // 
            if (!String.IsNullOrEmpty(form["C_Involved_project_address"]))
            {//涉案地点查询条件
                projectConditon.C_Involved_project_address = form["C_Involved_project_address"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Involved_project_type"]))
            {//涉案类别
                projectConditon.C_Involved_project_type = form["C_Involved_project_type"].Trim();
            }
            //C_Involved_project_type
            //涉案项目查询模型传递到前端视图中
            ViewBag.ProjectConditon = projectConditon;

            #endregion

            //获取涉案项目总记录数
            this.TotalRecordCount = _involved_projectWCF.GetRecordCount(projectConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取涉案项目数据信息
            List<CommonService.Model.C_Involved_project> projects = _involved_projectWCF.GetListByPage(projectConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(projects);
        }

        /// <summary>
        /// 单选回调工程列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList(FormCollection form,int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //涉案项目查询模型
            CommonService.Model.C_Involved_project projectConditon = new CommonService.Model.C_Involved_project();

            if (!String.IsNullOrEmpty(form["C_Involved_project_name"]))
            {//涉案项目名称查询条件
                projectConditon.C_Involved_project_name = form["C_Involved_project_name"].Trim();
            }
            //涉案项目查询模型传递到前端视图中
            ViewBag.ProjectConditon = projectConditon;

            #endregion

            //获取涉案项目总记录数
            this.TotalRecordCount = _involved_projectWCF.GetRecordCount(projectConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 8;
            //获取涉案项目数据信息
            List<CommonService.Model.C_Involved_project> projects = _involved_projectWCF.GetListByPage(projectConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(projects);
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
        public ActionResult SingleCallbackRefList_ProjectForm(FormCollection form, string lookupgroup, string propertyValueCode, string mappingField, string mappingFieldName, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //涉案项目查询模型
            CommonService.Model.C_Involved_project projectConditon = new CommonService.Model.C_Involved_project();

            if (!String.IsNullOrEmpty(form["C_Involved_project_name"]))
            {//涉案项目名称查询条件
                projectConditon.C_Involved_project_name = form["C_Involved_project_name"].Trim();
            }
            //涉案项目查询模型传递到前端视图中
            ViewBag.ProjectConditon = projectConditon;
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
            //获取涉案项目总记录数
            this.TotalRecordCount = _involved_projectWCF.GetRecordCount(projectConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取涉案项目数据信息
            List<CommonService.Model.C_Involved_project> projects = _involved_projectWCF.GetListByPage(projectConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(projects);
        }
        /// <summary>
        /// 多选回调工程列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefList(FormCollection form,string checkedProjectCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //涉案项目查询模型
            CommonService.Model.C_Involved_project projectConditon = new CommonService.Model.C_Involved_project();

            if (!String.IsNullOrEmpty(form["C_Involved_project_name"]))
            {//涉案项目名称查询条件
                projectConditon.C_Involved_project_name = form["C_Involved_project_name"].Trim();
            }
            //涉案项目查询模型传递到前端视图中
            ViewBag.ProjectConditon = projectConditon;
            ViewBag.checkedProjectCode = checkedProjectCode;
            #endregion

            //获取涉案项目总记录数
            this.TotalRecordCount = _involved_projectWCF.GetRecordCount(projectConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;

            //获取涉案项目数据信息
            List<CommonService.Model.C_Involved_project> projects = _involved_projectWCF.GetListByPage(projectConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(projects);
        }

        

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Involved_project project)
        {
            if(_involved_projectWCF.ExistsByName(project))
            {
                return Json(TipHelper.JsonData("此涉案项目名称已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            //服务方法调用
            int projectId = 0;

            if (project.C_Involved_project_id > 0)
            {//修改
                bool isUpdateSuccess = _involved_projectWCF.Update(project);
                if (isUpdateSuccess)
                {
                    projectId = project.C_Involved_project_id;
                }
            }
            else
            {//添加
                project.C_Involved_project_createTime = DateTime.Now;
                projectId = _involved_projectWCF.Add(project);
            }

            if (projectId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存涉案项目信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存涉案项目信息成功", "/basedata/Involved_project/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存涉案项目信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存涉案项目信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string Involved_project_code)
        {
            bool isSuccess = _involved_projectWCF.Delete(new Guid(Involved_project_code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除涉案项目信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除涉案项目信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}