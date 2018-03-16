using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maticsoft.Common
{
    /// <summary>
    /// Json消息框
    /// </summary>
    public class TipHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg">提示消息内容</param>
        /// <param name="forwardUrlAfterTip">跳转url，或者目标框架名称</param>
        /// <param name="isAlertTip">是否弹出提示消息框(默认弹出)</param>
        /// <param name="tipTyped">提示消息类型(默认成果消息)</param>
        /// <param name="alertTipPageType">弹出提示消息页面类型(默认父页面)</param>
        /// <param name="operateTypeAfterTip">消息提示后，后续操作类型(默认关闭弹出Dialog并且刷新父页面)</param>
        /// <returns></returns>
        public static Dictionary<string, string> JsonData(string msg, string forwardUrlAfterTip, IsAlertTip? isAlertTip = IsAlertTip.Yes, TipType? tipTyped = TipType.Success,
     AlertTipPageType? alertTipPageType = AlertTipPageType.ParentPage, OperateTypeAfterTip? operateTypeAfterTip = OperateTypeAfterTip.CloseDialogAndRefreshParent)
        {
            Dictionary<string, string> jsonData = new Dictionary<string, string>();
            jsonData.Add("Message", msg);
            jsonData.Add("forwardUrlAfterTip", forwardUrlAfterTip);
            jsonData.Add("isAlertTip", isAlertTip.Value.ToString());
            jsonData.Add("tipTyped", tipTyped.Value.ToString());
            jsonData.Add("alertTipPageType", alertTipPageType.Value.ToString());
            jsonData.Add("operateTypeAfterTip", operateTypeAfterTip.Value.ToString());

            return jsonData;
        }
    }
}
