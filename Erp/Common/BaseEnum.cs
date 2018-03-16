using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maticsoft.Common
{
    /// <summary>
    /// 是否弹出消息框
    /// </summary>
    public enum IsAlertTip
    {
        /// <summary>
        /// 弹出
        /// </summary>
        Yes,
        /// <summary>
        /// 不弹出
        /// </summary>
        No
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum TipType
    {
        /// <summary>
        /// 成功消息
        /// </summary>
        Success,
        /// <summary>
        /// 警告消息
        /// </summary>
        Warning,
        /// <summary>
        /// 错误消息
        /// </summary>
        Error
    }

    /// <summary>
    /// 弹出消息页面类型
    /// </summary>
    public enum AlertTipPageType
    {
        /// <summary>
        /// 当前页面
        /// </summary>
        ThisPage,
        /// <summary>
        /// 父页面
        /// </summary>
        ParentPage
    }

    /// <summary>
    /// 消息提示后，后续操作类型
    /// </summary>
    public enum OperateTypeAfterTip
    {
        /// <summary>
        /// 关闭弹出Dialog
        /// </summary>
        CloseDialog,
        /// <summary>
        /// 关闭弹出Dialog并且刷新父页面
        /// </summary>
        CloseDialogAndRefreshParent,
        /// <summary>
        ///  关闭弹出Dialog并且刷新祖父页面
        /// </summary>
        CloseDialogAndRefreshGrandpa,
        /// <summary>
        /// 刷新父页面
        /// </summary>
        RefreshParent,
        /// <summary>
        /// ajaxtodo刷新Iframe子页面
        /// </summary>
        RefreshIframeChildren,
        /// <summary>
        /// 关闭弹出Dialog并且刷新Iframe子页面
        /// </summary>
        CloseDialogAndRefreshIframeChildren,
        /// <summary>
        /// 刷新当前页面
        /// </summary>
        RefreshThisPage,
        /// <summary>
        /// 关闭提示并且刷新页面
        /// </summary>
        CloseTipAndRefreshThisPage,
        /// <summary>
        /// 关闭弹出Dialog并且刷新页面
        /// </summary>
        CloseDialogAndRefreshThisPage,
        /// <summary>
        /// 关闭提示
        /// </summary>
        CloseTip,
        /// <summary>
        /// 没有任何操作
        /// </summary>
        NoAction,
        /// <summary>
        /// 当前页面跳转到另外一个页面
        /// </summary>
        ThisPageGoAnotherPage,
        /// <summary>
        /// 当前页面跳转到另外一个页面并且刷新父页面
        /// </summary>
        ThisPageGoAnotherPageAndRefreshParentPage,
        /// <summary>
        /// 当前页面打开另外一个页面
        /// </summary>
        ThisPageOpenAnotherPage,
        /// <summary>
        /// 父页面跳转到另外一个页面
        /// </summary>
        ParentPageGoAnotherPage,
        /// <summary>
        /// 关闭提示并且当前页面跳转到另外一个页面
        /// </summary>
        CloseTipAndThisPageGoAnotherPage,
        /// <summary>
        /// 刷新局部内容
        /// </summary>
        RefreshPartial,
        /// <summary>
        /// 针对组织架构保存
        /// </summary>
        OrganizationSave,
        /// <summary>
        /// 针对菜单移动
        /// </summary>
        MoveMenu
    }
}
