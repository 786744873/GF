using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    public class NotesController : BaseController
    {
        private readonly ICommonService.OA.IO_Notes _notesWCF;
        //
        // GET: /OA/Notes/
        public NotesController()
        {
            #region 服务初始化
            _notesWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Notes>("notesWCF");
            #endregion
        }
        public ActionResult Create()
        {
            CommonService.Model.OA.O_Notes model = new CommonService.Model.OA.O_Notes();
            model.O_Notes_code = Guid.NewGuid();
            model.O_Notes_creator = Context.UIContext.Current.RootUserCode;
            model.O_Notes_isDelete = false;
            model.O_Notes_person = Context.UIContext.Current.RootUserCode;
            return View(model);
        }
        /// <summary>
        /// 便签列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            List<CommonService.Model.OA.O_Notes> noteList = _notesWCF.GetList(" O_Notes_person='" + Context.UIContext.Current.RootUserCode + "'");

            ViewBag.noteList = noteList;
            #region   拼接html
            string colheadHtml = "<div class=\"col-md-4 column sortable\">";//大列的开始
            string colendHtml = "</div>";//大列的结束
            string rowheadHtml = "<div class=\"portlet portlet-sortable box green-meadow\">";//小列的开始
            string strHtml = "";
            string strHtmlcol1 = "";//第一列
            string strHtmlcol2 = "";//第二列
            string strHtmlcol3 = "";//第三列
            int flag = 1;
            if (noteList.Count() == 0)
            {//如果没有便签  默认增加一个模板
                strHtml = strHtml + colheadHtml;
                strHtml = strHtml + rowheadHtml;
                //表头
                strHtml = strHtml + "<div class=\"portlet-title\"> <div class=\"caption\"> <i class=\"icon-puzzle font-White-flamingo\"></i><span class=\"caption-subject bold font-White-flamingo uppercase\">" + DateTime.Now.ToString("yyyy-MM-dd") + "</span> <span class=\"caption-helper\">.</span></div><div class=\"tools\">";
                //操作   只能添加
                strHtml = strHtml + "<a data-original-title=\"新增\" class=\"config ajaxify\" href=\"/oa/notes/create\" ></a><a data-original-title=\"打开/关闭\" href=\"\" class=\"collapse\"></a><a data-original-title=\"全屏\" href=\"\" class=\"fullscreen\"></a></div></div>";
                //便签的内容
                strHtml = strHtml + "<div class=\"portlet-body\"><p>点击添加，创建你的第一个标签。</p> </div>";
                strHtml = strHtml + colendHtml;
                strHtml = strHtml + colendHtml;
                ViewBag.strHtml = strHtml;
            }
            else
            {
                foreach (var item in noteList)
                {
                    #region   拼接html

                    if (flag % 3 == 0)//第三列
                    {
                        strHtmlcol3 = strHtmlcol3 + rowheadHtml;//便签的开始
                        //便签的头部
                        strHtmlcol3 = strHtmlcol3 + "<div class=\"portlet-title\"> <div class=\"caption\"> <i class=\"icon-puzzle font-White-flamingo\"></i><span class=\"caption-subject bold font-White-flamingo uppercase\">" + item.O_Notes_createTime.Value.ToString("yyyy-MM-dd") + "</span> <span class=\"caption-helper\"></span></div><div class=\"tools list_tool_dialog_toolbar\">";
                        //操作
                        strHtmlcol3 = strHtmlcol3 + "<a data-original-title=\"新增\" class=\"config ajaxify\" href=\"/oa/notes/create\"></a><a data-original-title=\"修改\" class=\"config ajaxify\" href=\"/oa/notes/edit?noteCode=" + item.O_Notes_code + "\"> </a><a data-original-title=\"删除\" href=\"/oa/notes/delete?notecode=" + item.O_Notes_code + "\" class=\"remove\" operatetargettype=\"ajaxtodo\" singleoperate=\"singleoperate\"></a><a data-original-title=\"打开/关闭\" href=\"\" class=\"collapse\"></a><a data-original-title=\"全屏\" href=\"\" class=\"fullscreen\"></a></div></div>";
                        //便签的内容
                        strHtmlcol3 = strHtmlcol3 + "<div class=\"portlet-body\"><p>" + item.O_Notes_content + "</p> </div>";
                        strHtmlcol3 = strHtmlcol3 + colendHtml;
                    }
                    else if (flag % 2 == 0)//第二列
                    {
                        strHtmlcol2 = strHtmlcol2 + rowheadHtml;//便签的开始
                        //便签的头部
                        strHtmlcol2 = strHtmlcol2 + "<div class=\"portlet-title\"> <div class=\"caption\"> <i class=\"icon-puzzle font-White-flamingo\"></i><span class=\"caption-subject bold font-White-flamingo uppercase\">" + item.O_Notes_createTime.Value.ToString("yyyy-MM-dd") + "</span> <span class=\"caption-helper\"></span></div><div class=\"tools list_tool_dialog_toolbar\">";
                        //操作
                        strHtmlcol2 = strHtmlcol2 + "<a data-original-title=\"新增\" class=\"config ajaxify\" href=\"/oa/notes/create\"></a><a data-original-title=\"修改\" class=\"config ajaxify\" href=\"/oa/notes/edit?noteCode=" + item.O_Notes_code + "\"></a><a data-original-title=\"删除\" href=\"/oa/notes/delete?notecode=" + item.O_Notes_code + "\" class=\"remove\" operatetargettype=\"ajaxtodo\" singleoperate=\"singleoperate\"></a><a data-original-title=\"打开/关闭\" href=\"\" class=\"collapse\"></a><a data-original-title=\"全屏\" href=\"\" class=\"fullscreen\"></a></div></div>";
                        //便签的内容
                        strHtmlcol2 = strHtmlcol2 + "<div class=\"portlet-body\"><p>" + item.O_Notes_content + "</p> </div>";

                        strHtmlcol2 = strHtmlcol2 + colendHtml;
                    }
                    else//第一列
                    {
                        strHtmlcol1 = strHtmlcol1 + rowheadHtml;//便签的开始
                        //便签的头部
                        strHtmlcol1 = strHtmlcol1 + "<div class=\"portlet-title\"> <div class=\"caption\"> <i class=\"icon-puzzle font-White-flamingo\"></i><span class=\"caption-subject bold font-White-flamingo uppercase\">" + item.O_Notes_createTime.Value.ToString("yyyy-MM-dd") + "</span> <span class=\"caption-helper\"></span></div><div class=\"tools list_tool_dialog_toolbar\">";
                        //操作
                        strHtmlcol1 = strHtmlcol1 + "<a data-original-title=\"新增\" class=\"config ajaxify\" href=\"/oa/notes/create\"></a><a data-original-title=\"修改\" class=\"config ajaxify\" href=\"/oa/notes/edit?noteCode=" + item.O_Notes_code + "\"></a><a data-original-title=\"删除\" href=\"/oa/notes/delete?notecode=" + item.O_Notes_code + "\" class=\"remove\" operatetargettype=\"ajaxtodo\" singleoperate=\"singleoperate\"></a><a data-original-title=\"打开/关闭\" href=\"\" class=\"collapse\"></a><a data-original-title=\"全屏\" href=\"\" class=\"fullscreen\"></a></div></div>";
                        //便签的内容
                        strHtmlcol1 = strHtmlcol1 + "<div class=\"portlet-body\"><p>" + item.O_Notes_content + "</p> </div>";
                        strHtmlcol1 = strHtmlcol1 + colendHtml;
                    }
                    flag++;
                    #endregion
                }
                strHtmlcol1 = colheadHtml + strHtmlcol1 + colendHtml;//第一列
                strHtmlcol2 = colheadHtml + strHtmlcol2 + colendHtml;//第二列
                strHtmlcol3 = colheadHtml + strHtmlcol3 + colendHtml;//第三列
                strHtml = strHtmlcol1 + strHtmlcol2 + strHtmlcol3;
                ViewBag.strHtml = strHtml;
            }

            #endregion
            return View();
        }
        /// <summary>
        /// 修改便签
        /// </summary>
        /// <param name="noteCode"></param>
        /// <returns></returns>
        public ActionResult Edit(string noteCode)
        {
            CommonService.Model.OA.O_Notes model = _notesWCF.GetModelByCode(new Guid(noteCode));
            return View("Create", model);
        }
        /// <summary>
        /// 删除便签
        /// </summary>
        /// <param name="noteCode"></param>
        /// <returns></returns>
         [HttpPost]
        public ActionResult Delete(string noteCode)
        {
            CommonService.Model.OA.O_Notes model = _notesWCF.GetModelByCode(new Guid(noteCode));
            model.O_Notes_isDelete = true;
            if (_notesWCF.Update(model))
            {//成功(这里可以给一个便签导航超链接的id，目的是操作页面后，刷新页面,必须这种情况，必须以"ajaxify_sidebar_"开始)
                return Json(TipHelper.JsonData("删除便签信息成功！", "ajaxify_sidebar_note", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除便签信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.OA.O_Notes notes)
        {
            //服务方法调用
            int notesId = 0;
            if (notes.O_Notes_id > 0)
            {//修改
                bool isUpdateSuccess = _notesWCF.Update(notes);
                if (isUpdateSuccess)
                {
                    notesId = notes.O_Notes_id;
                }
            }
            else
            {//添加
                DateTime now = DateTime.Now;
                notes.O_Notes_createTime = now;
                notesId = _notesWCF.Add(notes);
            }

            if (notesId > 0)
            {
                /*
                 * description:标签这个页面比较特殊，因为它不是列表形式，所以这里要在对应ajaxdone.js里单独处理，来刷新页面
                 * author:hety
                 * date:2015-07-30
                **/
                return Json(TipHelper.JsonData("保存便签信息成功！", "ajaxify_trigger|baseLargeModal|/oa/notes/list", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshThisPage));
            }
            else
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("保存便签信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
    }
}