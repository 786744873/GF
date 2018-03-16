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
    /// 涉案项目----建设单位关联控制器
    ///  作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
    public class Involved_project_CUController : BaseController
    {
        private readonly ICommonService.IC_Involved_project_CU _involved_project_cuWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_CRival _crivalWCF;
        private readonly ICommonService.IC_PRival _privalWCF;
         public Involved_project_CUController()
        {
            #region 服务初始化
            _involved_project_cuWCF = ServiceProxyFactory.Create<ICommonService.IC_Involved_project_CU>("Involved_project_CUWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _crivalWCF = ServiceProxyFactory.Create<ICommonService.IC_CRival>("CRivalWCF");
            _privalWCF = ServiceProxyFactory.Create<ICommonService.IC_PRival>("PRivalWCF");
            #endregion
        }
        //
        // GET: /BaseData/Involved_project_CU/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string Involved_project_code)
        {
            InitializationPageParameter();
            //创建初始化涉案项目实体
            CommonService.Model.C_Involved_project_CU involved_project_cu = new CommonService.Model.C_Involved_project_CU();
            if (!String.IsNullOrEmpty(Involved_project_code))
            {
                involved_project_cu.C_Involved_project_code = new Guid(Involved_project_code);
            }
            involved_project_cu.C_Involved_project_CU_creator = Context.UIContext.Current.UserCode;
            involved_project_cu.C_Involved_project_CU_createTime = DateTime.Now;
            involved_project_cu.C_Involved_project_CU_isDelete = 0;

            return View(involved_project_cu);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int Involved_project_CU_id)
        {
            InitializationPageParameter();
            string name = String.Empty;
            CommonService.Model.C_Involved_project_CU cu = _involved_project_cuWCF.GetModel(Involved_project_CU_id);
            
            return View("Create", cu);
        }

        public ActionResult List(FormCollection form,string Involved_project_code, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //建设单位查询模型
            CommonService.Model.C_Involved_project_CU cuConditon = new CommonService.Model.C_Involved_project_CU();

            if (!String.IsNullOrEmpty(Involved_project_code))
            {//涉案项目名称查询条件
                cuConditon.C_Involved_project_code = new Guid(Involved_project_code);
                this.AddressUrlParameters = "?Involved_project_code=" + Involved_project_code;
            }

            //建设单位信息查询模型传递到前端视图中
            ViewBag.CUConditon = cuConditon;

            #endregion

            //获取建设单位总记录数
            this.TotalRecordCount = _involved_project_cuWCF.GetRecordCount(cuConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Involved_project_CU> crival = _involved_project_cuWCF.GetListByPage(cuConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string Involved_project_code, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //建设单位查询模型
            CommonService.Model.C_Involved_project_CU cuConditon = new CommonService.Model.C_Involved_project_CU();

            if (!String.IsNullOrEmpty(Involved_project_code))
            {//涉案项目名称查询条件
                cuConditon.C_Involved_project_code = new Guid(Involved_project_code);
                this.AddressUrlParameters = "?Involved_project_code=" + Involved_project_code;
            }

            //建设单位信息查询模型传递到前端视图中
            ViewBag.CUConditon = cuConditon;

            #endregion

            //获取建设单位总记录数
            this.TotalRecordCount = _involved_project_cuWCF.GetRecordCount(cuConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Involved_project_CU> crival = _involved_project_cuWCF.GetListByPage(cuConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(crival);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Involved_project_CU involved_project_cu)
        {
            //服务方法调用
            int projectId = 0;
            if (form["rivallookup.Code"].Trim()!="")
            {
                involved_project_cu.C_Rival_code = new Guid(form["rivallookup.Code"].Trim());
            }
            if (form["rivallookup.Type"].Trim()!="")
            {
                involved_project_cu.C_Rival_type = int.Parse(form["rivallookup.Type"].Trim());
            }

            if (involved_project_cu.C_Involved_project_CU_id > 0)
            {//修改
                bool isUpdateSuccess = _involved_project_cuWCF.Update(involved_project_cu);
                if (isUpdateSuccess)
                {
                    projectId = involved_project_cu.C_Involved_project_CU_id;
                }
            }
            else
            {//添加
                involved_project_cu.C_Involved_project_CU_createTime = DateTime.Now;
                projectId = _involved_project_cuWCF.Add(involved_project_cu);
            }

            if (projectId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存建设单位信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存建设单位信息成功", "/basedata/Involved_project_CU/create?Involved_project_code=" + involved_project_cu.C_Involved_project_code, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存建设单位信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存建设单位信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Involved_project_CU_id)
        {
            bool isSuccess = _involved_project_cuWCF.Delete(Involved_project_CU_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除建设单位信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除建设单位信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //报建情况参数集合
            List<CommonService.Model.C_Parameters> situation = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.报建情况));
            ViewBag.situation = situation;
            //发包形式参数集合
            List<CommonService.Model.C_Parameters> bagStyle = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.发包形式));
            ViewBag.bagStyle = bagStyle;
            //建设资金来源参数集合
            List<CommonService.Model.C_Parameters> fundsSource = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(Involved_projectEnum.建设资金来源));
            ViewBag.fundsSource = fundsSource;
        }
	}
}