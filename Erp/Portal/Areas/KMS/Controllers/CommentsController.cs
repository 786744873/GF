using CommonService.Common;
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
    public class CommentsController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.KMS.IK_Comments _commentsWCF;
        public CommentsController()
        {
            #region 服务初始化
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _commentsWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Comments>("K_CommentsWCF");
            #endregion
        }
        //
        // GET: /KMS/Comments/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表Action
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

            //查询模型
            CommonService.Model.KMS.K_Comments Conditon = new CommonService.Model.KMS.K_Comments();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Comments_content = title;
                }
                string state = Request.Params.Get("i_state");
                if (state != null && state != "-1")
                {
                    Conditon.K_Comments_type = Convert.ToInt32(state);
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _commentsWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Comments> knowledge = _commentsWCF.GetListByPage(Conditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in knowledge
                         select new[] { 
                 c.K_Comments_code.ToString(),
                 c.K_Comments_typeName, 
                 c.P_FK_name,
                 c.K_Comments_content,
                 c.K_Comments_score.ToString(),
                 c.K_Comments_parentName,
                 c.K_Comments_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                 c.C_Userinfo_name,
                 c.K_Comments_helpfulCount==false ? "未采纳" : "采纳"
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
        /// 删除资源
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string commentsCode,string reflash)
        {
            bool isSuccess = _commentsWCF.DeleteList(commentsCode);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除评论信息成功！", reflash, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除评论信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //资源状态参数集合
            List<CommonService.Model.C_Parameters> CommentsType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CommentsEunm.评论类型));
            ViewBag.CommentsType = CommentsType;
        }
	}
}