using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    /// <summary>
    /// 文章控制器
    /// </summary>
    public class ArticleController : BaseController
    {
        private readonly ICommonService.OA.IO_Article _articleWCF;
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.OA.IO_Article_user _articleUserWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;

        public ArticleController()
        {
            #region 服务初始化
            _articleWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Article>("articleWCF");
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _articleUserWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Article_user>("article_userWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }

        //
        // GET: /OA/Article/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            CommonService.Model.OA.O_Article article = new CommonService.Model.OA.O_Article();
            article.O_Article_code = Guid.NewGuid();
            article.O_Article_publisher = Context.UIContext.Current.RootUserCode;
            article.O_Article_creator = Context.UIContext.Current.RootUserCode;
            article.O_Article_isDelete = false;
            article.O_Article_state = Convert.ToInt32(ArticleStateEnum.审核通过);
            article.O_Article_state_name = "审核通过";

            SetSingleOrganization();

            return View(article);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="articleCode">文章Guid</param>
        /// <returns></returns>
        public ActionResult Edit(string articleCode)
        {
            CommonService.Model.OA.O_Article article = _articleWCF.GetModel(new Guid(articleCode));
            SetSingleOrganization();
            return View("Create", article);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="articleCode">文章Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string articleCode)
        {
            bool isSuccess = _articleWCF.Delete(new Guid(articleCode));
            if (isSuccess)
            {//成功(这里可以给一个table的id，目的是操作table后，刷新table)
                return Json(TipHelper.JsonData("删除文章信息成功！", "articleList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除文章信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }


        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.OA.O_Article article)
        {
            //服务方法调用
            int articleId = 0;
            bool flag = true;
            if (article.O_Article_id > 0)
            {//修改
                bool isUpdateSuccess = _articleWCF.Update(article);
                if (isUpdateSuccess)
                {
                    articleId = article.O_Article_id;
                }
            }
            else
            {//添加
                DateTime now = DateTime.Now;
                article.O_Article_createTime = now;
                article.O_Article_publishTime = now;
                articleId = _articleWCF.Add(article);
            }

            if (articleId > 0)
            {

                //保存文章成功后向文章用户表中添加数据
                if (!string.IsNullOrEmpty(form["orglist"].ToString()))
                {
                    string orgLists = form["orglist"].ToString();
                    if (_articleUserWCF.AddList(orgLists, article))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }

                //表单提交成功固定写法(table id + 模式 dialog id)
            }
            if (flag)
            {
                return Json(TipHelper.JsonData("保存文章信息成功！", "ajaxify_trigger|/oa/article/List", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("保存文章信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
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
            this.TotalRecordCount = _articleWCF.GetRecordCount(articleConditon);
            //数据信息
            List<CommonService.Model.OA.O_Article> articles = _articleWCF.GetListByPage(articleConditon,
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

        #region 含checkbox的组织机构递归

        /// <summary>
        ///  装载全部组织机构信息
        /// </summary>
        private void SetSingleOrganization()
        {
            List<CommonService.Model.SysManager.C_Organization> organizations = _organizationWCF.GetAllList();
            SetSingleTopOrganization(organizations);
        }

        /// <summary>
        /// 装载顶级组织机构
        /// </summary>
        /// <param name="organizationList">组织机构集合</param>
        private void SetSingleTopOrganization(List<CommonService.Model.SysManager.C_Organization> organizationList)
        {
            string organizationTreeHtml = "";
            string preTreeHtml = "[";//树前缀
            string backTreeHtml = "]";//树后缀
            var topOrganizationList = from allList in organizationList
                                      where allList.C_Organization_level == 1
                                      orderby allList.C_Organization_order ascending
                                      select allList;

            organizationTreeHtml += "{\"text\":\"组织机构\",\"id\":\"00000000-0000-0000-0000-000000000000\",\"state\": {\"opened\": true},";
            organizationTreeHtml += "\"children\": [";

            foreach (CommonService.Model.SysManager.C_Organization organzation in topOrganizationList)
            {
                string href = "";

                string uniqueId = organzation.C_Organization_code.Value.ToString();

                organizationTreeHtml += "{\"text\":\"" + organzation.C_Organization_name + "\",\"id\":\"" + organzation.C_Organization_code + "\",\"state\": {\"opened\": true},";

                SetSignleRecursionTree(organzation.C_Organization_code.Value, ref organizationTreeHtml, organizationList);
                organizationTreeHtml += "},";
            }
            organizationTreeHtml += "]";
            organizationTreeHtml += "}";
            ViewBag.OrgTree = preTreeHtml + organizationTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有组织机构(递归加载组织机构，默认指打开三级，其余的默认不打开)
        /// </summary>
        /// <param name="parentCode">上级组织机构Code</param>
        /// <param name="organizationTreeHtml">组织机构Tree Html</param>
        private void SetSignleRecursionTree(Guid parentCode, ref string organizationTreeHtml, List<CommonService.Model.SysManager.C_Organization> organizationList)
        {


            var loworganizationList = from allList in organizationList
                                      where allList.C_Organization_parent == parentCode
                                      orderby allList.C_Organization_order ascending
                                      select allList;

            if (loworganizationList.Count() != 0)
            {
                organizationTreeHtml += "\"children\": [";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Organization organization in loworganizationList)
            {
                string href = "";

                string uniqueId = organization.C_Organization_code.Value.ToString();

                organizationTreeHtml += "{\"text\":\"" + organization.C_Organization_name + "\",\"id\":\"" + organization.C_Organization_code + "\",";

                SetSignleRecursionTree(organization.C_Organization_code.Value, ref organizationTreeHtml, organizationList);
                organizationTreeHtml += "},";
            }
            if (loworganizationList.Count() != 0)
            {
                organizationTreeHtml += "]";
            }
        }

        #endregion

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //客户类型参数集合
            List<CommonService.Model.C_Parameters> ArticleStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ArticleEnum.文章状态));
            ViewBag.ArticleStates = ArticleStates;
        }

    }
}