using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.FlowManager.Controllers
{
    /// <summary>
    ///流程--表单中间表控制器
    ///作者：崔慧栋
    ///日期：2015/05/21
    /// </summary>
    public class Flow_formController : BaseController
    {
         private readonly ICommonService.IC_Parameters _parametersWCF;
         private readonly ICommonService.FlowManager.IP_Flow_form _flowformWCF;
         private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
         private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
         public Flow_formController()
        {
            #region 服务初始化
            _parametersWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _flowformWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow_form>("Flow_formWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            #endregion
        }
        //
        // GET: /FlowManager/Flow_form/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string flowCode)
        {
            //创建初始化参数实体
            CommonService.Model.FlowManager.P_Flow flow = new CommonService.Model.FlowManager.P_Flow();
            flow.P_Flow_code = Guid.NewGuid();
            flow.P_Flow_level = 0;
            if (!String.IsNullOrEmpty(flowCode))
            {
                flow.P_Flow_parent = new Guid(flowCode);
            }
            flow.P_Flow_creator = Context.UIContext.Current.UserCode;
            flow.P_Flow_createTime = DateTime.Now;
            flow.P_Flow_isDelete = 0;
            flow.P_Flow_order = 0;
            return View(flow);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int Flow_form_id)
        {
            CommonService.Model.FlowManager.P_Flow_form flowform = _flowformWCF.GetModel(Flow_form_id);
            return View("Create", flowform);
        }

        public ActionResult List(FormCollection form,string flowCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //参数查询模型
            CommonService.Model.FlowManager.P_Flow_form flowformConditon = new CommonService.Model.FlowManager.P_Flow_form();

            if (!String.IsNullOrEmpty(flowCode))
            {//参数名称查询条件
                flowformConditon.P_Flow_code = new Guid(flowCode);
            }
            this.AddressUrlParameters = "?flowCode=" + flowformConditon.P_Flow_code;

            //参数查询模型传递到前端视图中
            ViewBag.FlowformConditon = flowformConditon;

            #endregion

            //获取参数总记录数
            this.TotalRecordCount = _flowformWCF.GetRecordCount(flowformConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.FlowManager.P_Flow_form> flow = _flowformWCF.GetListByPage(flowformConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(flow);
        }

        /// <summary>
        /// 流程关联所有表单Action
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public ActionResult FlowRelationFormList(string flowCode,string businessFlowCode)
        {
            List<CommonService.Model.FlowManager.P_Flow_form> flowForms;
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms;
            if (businessFlowCode != "{sid_Iterm}" && !String.IsNullOrEmpty(businessFlowCode)&&businessFlowCode != "{sid_item}")
            {
                CommonService.Model.FlowManager.P_Business_flow model = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
                flowCode = model.P_Flow_code.ToString();
            }
            if (flowCode == "{flowCode}")
            {
                flowForms = new List<CommonService.Model.FlowManager.P_Flow_form>();
            }else{
                flowForms = _flowformWCF.GetListByFlowCode(new Guid(flowCode));
                if (!String.IsNullOrEmpty(businessFlowCode))
                {
                    ArrayList flowformsArrays = new ArrayList();
                    businessFlowForms = _businessFlowFormWCF.GetBusinessFlowForms(new Guid(businessFlowCode));
                    for (int i = 0; i < flowForms.Count(); i++)
                    {
                        for (int j = 0; j < businessFlowForms.Count(); j++)
                        {
                            //去掉"已作废"的表单
                            if (businessFlowForms[j].P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.已作废))
                            {
                                continue;
                            }
                            if (flowForms[i].F_Form_code == businessFlowForms[j].F_Form_code)
                            {
                                flowformsArrays.Add(flowForms[i]);
                            }
                        }
                    }
                    if (flowformsArrays != null)
                    {
                        foreach (CommonService.Model.FlowManager.P_Flow_form flowform in flowformsArrays)
                        {
                            flowForms.Remove(flowform);
                        }
                    }
                }
            }
          
            return View(flowForms);
        }

        /// <summary>
        /// 流程关联所有表单Action
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public ActionResult FlowRelationFormListToEntry(string flowCode)
        {
            List<CommonService.Model.FlowManager.P_Flow_form> flowForms;
            if (flowCode == "{flowCode}")
            {
                flowForms = new List<CommonService.Model.FlowManager.P_Flow_form>();
            }
            else
            {
                flowForms = _flowformWCF.GetListByFlowCode(new Guid(flowCode));
            }

            return View(flowForms);
        }


        /// <summary>
        /// 流程关联所有表单Action
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public ActionResult RelationFormList(string flowCode)
        {
            List<CommonService.Model.FlowManager.P_Flow_form> flowForms;
            if (flowCode == "")
            {
                flowForms = new List<CommonService.Model.FlowManager.P_Flow_form>();
            }
            else
            {
                flowForms = _flowformWCF.GetListByFlowCode(new Guid(flowCode));
            }
            
            return View(flowForms);
        }


        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(CommonService.Model.FlowManager.P_Flow_form flowform)
        {
            //服务方法调用
            int flowformId = 0;

            if (flowform.P_Flow_form_id > 0)
            {//修改
                bool isUpdateSuccess = _flowformWCF.Update(flowform);
                if (isUpdateSuccess)
                {
                    flowformId = flowform.P_Flow_form_id;
                }
            }
            else
            {//添加
                flowform.P_Flow_form_createTime = DateTime.Now;
                flowformId = _flowformWCF.Add(flowform);
            }

            if (flowformId >= 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("分配表单成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("分配表单失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string Flow_form_ids)
        {
            bool isSuccess = _flowformWCF.Delete(Flow_form_ids);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除表单成功", "iframe_businessFlowForm", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除表单失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }



        /// <summary>
        /// 改变默认状态
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeDefault(string flow_form_ids, string P_Flow_code) 
        {
            bool isSuccess = _flowformWCF.UpdateDefaultByid(flow_form_ids, new Guid(P_Flow_code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("修改表单成功！", "iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("修改表单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}