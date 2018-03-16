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
    public class MessageController : BaseController
    {
        private readonly ICommonService.IC_Messages _messageWCF;
        //
        // GET: /OA/Message/
        public MessageController()
        {
            #region 服务初始化
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            #endregion
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
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
            //消息查询模型
            CommonService.Model.C_Messages messageConditon = new CommonService.Model.C_Messages();
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {//查询消息的内容
                    messageConditon.C_Messages_content = title;
                }
                #endregion
            }
            //日程提醒大类
            messageConditon.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.日程);
            //日程提醒小类
            messageConditon.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.日程提醒);
            //登陆者guid
            messageConditon.C_Messages_person = Context.UIContext.Current.RootUserCode;
            #endregion
            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _messageWCF.GetRecordCount(messageConditon);
            //数据信息
            List<CommonService.Model.C_Messages> messages = _messageWCF.GetListByPage(messageConditon,
                "C_Messages_createTime Desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in messages
                         select new[] { 
                 c.C_Messages_link.Value.ToString(), 
                 c.C_Messages_content, 
                 c.C_Messages_isRead==0?"未读":"已读",
                 c.C_Messages_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
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
        /// 消息详细
        /// </summary>
        /// <param name="scheduleCode"></param>
        /// <returns></returns>
        public ActionResult Details(string scheduleCode)
        {
            if (!string.IsNullOrEmpty(scheduleCode))
            {
                //修改消息为已读
                CommonService.Model.C_Messages model = _messageWCF.GetModelByLinkCode(new Guid(scheduleCode));
                if (model.C_Messages_isRead == 0)
                    _messageWCF.ReadMessage(model.C_Messages_id);
            }
            return RedirectToAction("../schedule/Details", new { scheduleCode=scheduleCode });
        }
    }
}