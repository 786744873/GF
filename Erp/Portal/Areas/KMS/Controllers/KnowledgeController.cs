using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class KnowledgeController : BaseController
    {
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.KMS.IK_Resources _resourcesWCF;
        public KnowledgeController()
        {
            #region 服务初始化
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            _resourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources>("K_ResourcesWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            #endregion
        }
        //
        // GET: /KMS/Knowledge/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表Action
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string knowledgeCode)
        {
            //获取所有知识分类
            List<CommonService.Model.KMS.K_Knowledge> listK = new List<CommonService.Model.KMS.K_Knowledge>();
            if (Context.UIContext.Current.IsPreSetManager)
            {
                listK = _knowledgeWCF.GetAllList();
                ViewBag.listK = listK;
            }
            else
            {
                listK = _knowledgeWCF.GetAllListByPerson(Context.UIContext.Current.RootUserCode.Value);
                ViewBag.listK = listK;
            }
            if (!String.IsNullOrEmpty(knowledgeCode))
            {
                ViewBag.knowledgeCode = knowledgeCode;
            }
            else
            {
                ViewBag.knowledgeCode = "";
            }
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param, string knowledgeCode)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改

            //查询模型
            CommonService.Model.KMS.K_Knowledge Conditon = new CommonService.Model.KMS.K_Knowledge();
            if (!String.IsNullOrEmpty(knowledgeCode))
            {
                Conditon.K_Knowledge_code = new Guid(knowledgeCode);
            }
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Knowledge_name = title;
                }
                string state = Request.Params.Get("i_state");
                if (state != null && state != "-1")
                {
                    //Conditon.O_Article_state = Convert.ToInt32(state);
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _knowledgeWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Knowledge> knowledge = _knowledgeWCF.GetListByPage(Conditon,
                "K_Knowledge_parent Asc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in knowledge
                         select new[] { 
                 c.K_Knowledge_code.ToString(),
                 c.K_Knowledge_name, 
                 c.K_Knowledge_parentName,
                 c.K_Knowledge_PersonName,
                 c.K_Knowledge_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                 c.K_Knowledge_creatorName 
            };
            //返回json数据
            return Json(
                new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = this.TotalRecordCount,
                    iTotalDisplayRecords = this.TotalRecordCount,
                    aaData = result
                }
            );

            #endregion
        }

        /// <summary>
        /// 新增Action
        /// </summary>
        /// <param name="knowledgeParent">父级Guid</param>
        /// <returns></returns>
        public ActionResult Create(string knowledgeParent)
        {
            CommonService.Model.KMS.K_Knowledge knowledge = new CommonService.Model.KMS.K_Knowledge();
            knowledge.K_Knowledge_code = Guid.NewGuid();
            if (knowledgeParent!="")
            {
                //CommonService.Model.KMS.K_Knowledge knowledgeModel = _knowledgeWCF.GetModel(new Guid(knowledgeParent));
                knowledge.K_Knowledge_parent = new Guid(knowledgeParent);
            }            
            knowledge.K_Knowledge_creator = Context.UIContext.Current.RootUserCode;
            knowledge.K_Knowledge_isDelete = false;

            List<CommonService.Model.SysManager.C_Userinfo> userLists = _userinfoWCF.GetParentList();
            string userHtml = "";
            foreach (var user in userLists)
            {
                userHtml += "<option value=" + user.C_Userinfo_code + ">" + user.C_Userinfo_name + "</option>";
            }
            ViewBag.userhtml = userHtml;

            return View(knowledge);
        }

        /// <summary>
        /// 修改Action
        /// </summary>
        /// <param name="knowledgeCode"></param>
        /// <returns></returns>
        public ActionResult Edit(string knowledgeCode)
        {
            List<CommonService.Model.SysManager.C_Userinfo> userLists = _userinfoWCF.GetParentList();
            string userHtml = "";
            foreach (var user in userLists)
            {
                userHtml += "<option value=" + user.C_Userinfo_code + ">" + user.C_Userinfo_name + "</option>";
            }
            ViewBag.userhtml = userHtml;

            CommonService.Model.KMS.K_Knowledge knowledge = _knowledgeWCF.GetModel(new Guid(knowledgeCode));
            return View("create",knowledge);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.KMS.K_Knowledge knowledge)
        {
            //服务方法调用
            int knowledgeId = 0;

            if(knowledge.K_Knowledge_id>0)
            {//修改
                bool isUpdateSuccess = _knowledgeWCF.Update(knowledge);
                if (isUpdateSuccess)
                {
                    knowledgeId = knowledge.K_Knowledge_id;
                }
            }else
            {//增加
                DateTime now = DateTime.Now;
                knowledge.K_Knowledge_createTime = now;
                knowledgeId = _knowledgeWCF.Add(knowledge);
            }
            if (knowledgeId > 0)
            {
                return Json(TipHelper.JsonData("保存知识分类成功！", "/kms/Knowledge/List", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("保存知识分类失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除Action
        /// </summary>
        /// <param name="knowledgeCode">知识分类Guid</param>
        /// <returns></returns>
        public ActionResult Delete(string knowledgeCode)
        {
            //判断此分类下有没有数据，如果有暂时禁止删除（后期修改为只有管理员能删除，且同时删除该分类下所有知识）
            CommonService.Model.KMS.K_Resources resources = new CommonService.Model.KMS.K_Resources();
            resources.K_Resources_Knowledge_code = knowledgeCode;
            int recount = _resourcesWCF.GetRecordCount(resources);
            if (recount > 0)
            {//失败
                return Json(TipHelper.JsonData("该分类下有资料，禁止删除！如需删除，请联系管理员！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));

            }
            else
            {
                bool isSuccess = _knowledgeWCF.Delete(new Guid(knowledgeCode));
                if (isSuccess)
                {//成功
                    return Json(TipHelper.JsonData("删除知识分类成功！", "knowledgeList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
                }
                else
                {//失败
                    return Json(TipHelper.JsonData("删除知识分类失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
        }
        /// <summary>
        /// 移动资源
        /// </summary>
        /// <param name="knowledgeCode">知识分类Guid</param>
        /// <param name="resourcesCode">资源Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MobileResource(string knowledgeCode,string resourcesCode)
        {
            bool isSuccess = _knowledgeWCF.MobileResource(new Guid(knowledgeCode), new Guid(resourcesCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("移动知识成功！", "KnowledgeMaintenance", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("移动知识失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}