using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    public class MyArticleController : BaseController
    {
        private readonly ICommonService.OA.IO_Article _articleWCF;
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.OA.IO_Article_user _articleUserWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        //
        // GET: /OA/MyArticle/
        public ActionResult Index()
        {
            return View();
        }
        public MyArticleController()
        {
            #region 服务初始化
            _articleWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Article>("articleWCF");
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _articleUserWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Article_user>("article_userWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }

        /// <summary>
        /// 默认列表Action(菜单超链接打开)
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            InitializationPageParameter();
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //文章查询模型
            CommonService.Model.OA.O_Article articleConditon = new CommonService.Model.OA.O_Article();
            articleConditon.C_Userinfo_code = Context.UIContext.Current.RootUserCode;//用户guid
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    articleConditon.O_Article_title = title;
                }
                string state = Request.Params.Get("i_state");
                if (state != null && state != "-1")
                {
                    articleConditon.O_Article_state = Convert.ToInt32(state);
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _articleWCF.GetRecordCount2(articleConditon);
            //数据信息
            List<CommonService.Model.OA.O_Article> articles = _articleWCF.GetListByPage2(articleConditon,
                "O_Article_createTime Desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in articles
                         select new[] { 
                 c.O_Article_code.Value.ToString(), 
                 c.O_Article_title, 
                 c.O_Article_publisher_name,
                 c.O_Article_publishTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                 c.O_Article_state_name.ToString() 
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
            //客户类型参数集合
            List<CommonService.Model.C_Parameters> ArticleStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ArticleEnum.文章状态));
            ViewBag.ArticleStates = ArticleStates;
        }
        public ActionResult Details(string articleCode, string type)
        {
            CommonService.Model.OA.O_Article_user modelu = _articleUserWCF.GetModelByAcodeAndCcode(new Guid(articleCode), new Guid(Context.UIContext.Current.RootUserCode.ToString()));
            if (!modelu.O_Article_user_isRead)
            {
                modelu.O_Article_user_isRead = true;
                _articleUserWCF.Update(modelu);
            }
            CommonService.Model.OA.O_Article model = _articleWCF.GetModel(new Guid(articleCode));
            List<CommonService.Model.OA.O_Article_user> lists = _articleUserWCF.GetListByCode(new Guid(articleCode));//已读的用户

            List<CommonService.Model.OA.O_Article_user> NRlists = _articleUserWCF.GetNoreadListByCode(new Guid(articleCode));//未读的用户

            CommonService.Model.OA.O_Article articleConditon = new CommonService.Model.OA.O_Article();
            articleConditon.C_Userinfo_code = Context.UIContext.Current.RootUserCode;//用户guid
            List<CommonService.Model.OA.O_Article> articles = _articleWCF.GetListByPage2(articleConditon,
            "O_Article_createTime Desc", 0, 1000);//其他公告

            ViewBag.count = lists.Count;
            ViewBag.type = type;//
            ViewBag.otherlists = articles;
            ViewBag.NRlists = NRlists;
            ViewBag.Rlists = lists;
            return View(model);
        }
    }
}