using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    public class RivalController : BaseController
    {
        /// <summary>
        /// 对手控制器
        /// </summary>
        //
        // GET: /BaseData/Rival/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails()
        {
            return View();
        }

        /// <summary>
        /// 多选回调tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult ListTabDetails(string type, string checkedRivalCode)
        {
            ViewBag.type = type;
            ViewBag.checkedRivalCode = checkedRivalCode;
            return View();
        }
        /// <summary>
        /// 单选回调tab 页签
        /// </summary>
        /// <returns></returns>
        //public ActionResult ListTabDetails(string type, string checkedRivalCode)
        //{
        //    ViewBag.type = type;
        //    ViewBag.checkedRivalCode = checkedRivalCode;
        //    return View();
        //}

        /// <summary>
        /// 单选回调tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult SingleListTabDetails(string type, string checkedRivalCode)
        {
            ViewBag.type = type;
            ViewBag.checkedRivalCode = checkedRivalCode;
            return View();
        }

        #region 自定义表单用(只用于列表编辑页面中的Callback带回)

        /// <summary>
        /// 单选回(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="rebuildProperty">重组表单属性</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefListDv_Tab_List(string lookupgroup, string rebuildProperty, string mappingField, string mappingFieldName)
        {
            #region 参照配置条件

            ViewBag.Lookupgroup = lookupgroup;
            ViewBag.RebuildProperty = rebuildProperty;
            ViewBag.MappingField = mappingField;
            ViewBag.MappingFieldName = mappingFieldName;
            #endregion

            return View();
        }

        #endregion

    }
}