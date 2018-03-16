using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    /// <summary>
    /// 资源查找搜索后界面以及处理
    /// cyj
    /// 2015-11-24
    /// </summary>
    public class SearchResourcesController : BaseController
    {
        private readonly ICommonService.KMS.IK_Resources _resourcesWCF;
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;

        public SearchResourcesController()
        {
            #region 服务初始化
            _resourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources>("K_ResourcesWCF");
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /KMS/SearchResources/
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 搜索后界面
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string keyword, string knowledge, string resourcestype)
        {
            if (!string.IsNullOrEmpty(keyword))
                ViewBag.keyword = keyword;
            if (!string.IsNullOrEmpty(knowledge))
                ViewBag.knowledge = knowledge;
            if (!string.IsNullOrEmpty(resourcestype))
                ViewBag.resourcestyperel = resourcestype;
            InitializationPageParameter();
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult Ajaxlist(jQueryDataTableParamModel param, string knowledgeCode)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Resources Conditon = new CommonService.Model.KMS.K_Resources();
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            //关键字查询   
            string title = Request.Params.Get("s_title");
            Random rd = new Random();
            string index = rd.Next().ToString();
            //索引服务器附件存放全目录
            string indexPath = Server.MapPath("../../") + "\\" + "indextemp" + "\\" + index;
            if (!Directory.Exists(indexPath))
            {
                Directory.CreateDirectory(indexPath);
            }
            //根据关键字查询，返回查询的数据的code集合
            bool flag = true;//是否执行下一步查询（查询数据详细信息）
            string keyWord = "";
            if (!string.IsNullOrEmpty(title))
            {
                keyWord = title;
                string codeList = _resourcesWCF.GetResourcesCodelist(indexPath, title);
                if (codeList == "")
                    flag = false;
                else
                    Conditon.K_Resources_codeItems = codeList;
            }
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                //资源所属类型查询条件
                string type = Request.Params.Get("shareResourcesType");
                if (type != null && type.ToString() != "" && Convert.ToInt32(type) != 0)
                {
                    Conditon.K_Resources_type = Convert.ToInt32(type);
                }
                //资源所属知识类型查询条件
                string knowledge = Request.Params.Get("KnowledgeType");
                if (!string.IsNullOrEmpty(knowledge))
                {
                    Conditon.K_Resources_Knowledge_code = knowledge;
                }
                #endregion
            }
            Conditon.K_Resources_state = Convert.ToInt32(ResourcesStateEnum.已发布);
            #endregion

            #region 分页数据处理
            List<CommonService.Model.KMS.K_Resources> redources = new List<CommonService.Model.KMS.K_Resources>();
            if (flag == false)
            { //不在进行详细数据查询
                this.TotalRecordCount = 0;               
            }
            else
            {
                //总记录数
                this.TotalRecordCount = _resourcesWCF.GetRecordCount(Conditon);
                //数据信息
                redources = _resourcesWCF.GetListByPage(Conditon,
                    "K_Resources_createTime desc ", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            }
            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Resources_code.ToString(),
                 c.K_Resources_coverImage, 
                 c.K_Resources_description,
                 c.K_Resources_type.ToString(),
                 c.K_Resources_url.ToString(),
                 c.K_Resources_creatorName.ToString(),
                 c.K_Resources_zambiaCount!=null?c.K_Resources_zambiaCount.ToString():"0",
                 c.K_Browse_LogCount.ToString(),
                 c.K_Resources_createTime.ToString(),
                 c.K_Resources_name.ToString(),
                 TotalRecordCount.ToString(),
                 keyWord
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
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //资源状态参数集合
            List<CommonService.Model.C_Parameters> ResourcesState = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ResourcesEnum.资源状态));
            ViewBag.ResourcesState = ResourcesState;
            List<CommonService.Model.C_Parameters> ResourcesType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ResourcesEnum.资源类型));
            ViewBag.ResourcesType = ResourcesType;
            List<CommonService.Model.KMS.K_Knowledge> listK = _knowledgeWCF.GetAllList();
            ViewBag.listK = listK;
            List<CommonService.Model.KMS.K_Resources> listR = _resourcesWCF.GetListByBrowseCount(5, null, null);
            ViewBag.listR = listR;
        }

    }
}