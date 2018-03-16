/****
**** author: hety
**** date: 2015-05-21
**** description: 弹出dialog业务扩展
***/
$(function () {
    //模拟点击下拉框弹出对话框(最大化插件)
    //var dialogExtendOptions = {
    //    "close": true,
    //    "maximize": true,
    //    "minimize": false,
    //    "dblclick": "maximize",
    //    "titlebar": false
    //};
    ////最大化插件事件
    //dialogExtendOptions.events = dialogExtendOptions.events || {};
    //dialogExtendOptions.events["beforeMaximize"] = function (evt, dlg) {
    //    $(this).parents(".ui-dialog").offset({ top: 0, left: 0 });
    //};

    //$('<div class="dialog"><iframe width="99%" height="100%" scrolling="no" ></iframe></div>').appendTo('body');
    //$(".dialog").dialog({
    //    autoOpen: false, modal: true,"resizable" :true,
    //}).dialogExtend(dialogExtendOptions);
 
    //以上代码为:2015-08-31之前的做法，hety,现在已经更换
});
function _openDialog(title, switchUrl, dialogwidth, dialogheight) {
    if (dialogwidth > $(document.body).width())
    {
        var temp = dialogwidth - $(document.body).width();
        dialogwidth = $(document.body).width()-35;
        dialogheight = parseInt(dialogheight) + parseInt(temp*2);
        //$(".dialog").find("iframe").css("overflow-y", "yes");
    }
    //dialog options
    var dialogOptions = {
        "title": title,
        "width": dialogwidth,
        "height": dialogheight,
        "modal": true,
        "resizable": true,
        "draggable": true,
        "position": { my: "top", at: "top", of: window },
        "closeText": "关闭",
        "close": function () {            
            $(this).remove();
        }
    };
    var dialogExtendOptions = {
        "close": true,
        "maximize": true,
        "minimize": false,
        "dblclick": "maximize",
        "titlebar": false
    };
    //插件事件
    dialogExtendOptions.events = dialogExtendOptions.events || {};
    dialogExtendOptions.events["beforeMaximize"] = function (evt, dlg) {//触发最大化之前
        $(this).parents(".ui-dialog").offset({ top: 0, left: 0 });//从左上角开始最大化
    };
   
    $("<div class=\"dialog\"><iframe width=\"99%\" height=\"100%\" scrolling=\"no\"  src=\"" + switchUrl + "\"></iframe></div>").dialog(dialogOptions).dialogExtend(dialogExtendOptions); 
}
//打开还有滚动类型的dialog
function _openScrollingTypeDialog(title, switchUrl, dialogwidth, dialogheight, scrollingType) {
    if (dialogwidth > $(document.body).width()) {
        var temp = dialogwidth - $(document.body).width();
        dialogwidth = $(document.body).width() - 35;
        dialogheight = parseInt(dialogheight) + parseInt(temp * 2);
        //$(".dialog").find("iframe").css("overflow-y", "yes");
    }
    //dialog options
    var dialogOptions = {
        "title": title,
        "width": dialogwidth,
        "height": dialogheight,
        "modal": true,
        "resizable": true,
        "draggable": true,
        "position": { my: "top", at: "top", of: window },
        "closeText": "关闭",
        "close": function () {
            $(this).remove();
        }
    };
    var dialogExtendOptions = {
        "close": true,
        "maximize": true,
        "minimize": false,
        "dblclick": "maximize",
        "titlebar": false
    };
    //插件事件
    dialogExtendOptions.events = dialogExtendOptions.events || {};
    dialogExtendOptions.events["beforeMaximize"] = function (evt, dlg) {//触发最大化之前
        $(this).parents(".ui-dialog").offset({ top: 0, left: 0 });//从左上角开始最大化
    };

    $("<div class=\"dialog\"><iframe width=\"99%\" height=\"100%\" scrolling=\"" + scrollingType + "\"  src=\"" + switchUrl + "\"></iframe></div>").dialog(dialogOptions).dialogExtend(dialogExtendOptions);
}
//打开弹出框，并且附带关闭事件
function _openDialogHaveCloseEvent(title, switchUrl, dialogwidth, dialogheight,closeEventCallBack) {
    if (dialogwidth > $(document.body).width()) {
        var temp = dialogwidth - $(document.body).width();
        dialogwidth = $(document.body).width() - 35;
        dialogheight = parseInt(dialogheight) + parseInt(temp * 2);
        //$(".dialog").find("iframe").css("overflow-y", "yes");
    }     
    //dialog options
    var dialogOptions = {
        "title": title,
        "width": dialogwidth,
        "height": dialogheight,
        "modal": true,
        "resizable": true,
        "draggable": true,
        "position": { my: "top", at: "top", of: window },
        "closeText": "关闭",
        "close": function () {
            $(this).remove();           
            eval(closeEventCallBack);//动态执行js代码
        }
    };
    var dialogExtendOptions = {
        "close": true,
        "maximize": true,
        "minimize": false,
        "dblclick": "maximize",
        "titlebar": false
    };
    //插件事件
    dialogExtendOptions.events = dialogExtendOptions.events || {};
    dialogExtendOptions.events["beforeMaximize"] = function (evt, dlg) {//触发最大化之前
        $(this).parents(".ui-dialog").offset({ top: 0, left: 0 });//从左上角开始最大化
    };

    $("<div class=\"dialog\"><iframe width=\"99%\" height=\"100%\" scrolling=\"no\"  src=\"" + switchUrl + "\"></iframe></div>").dialog(dialogOptions).dialogExtend(dialogExtendOptions);
}






//以下代码为:2015-08-31之前的做法，hety,现在已经更换
//$(".ui-dialog-title").text(title);//设置Dialog标题
//$(".dialog").find("iframe").contents().find("body").html("");//清空body内容           
//$(".dialog").find("iframe").attr("src", switchUrl);//重新加载url

//if (dialogwidth > $(document.body).width())
//{
//    var temp = dialogwidth - $(document.body).width();
//    dialogwidth = $(document.body).width();
//    dialogheight = parseInt(dialogheight) + parseInt(temp*2);
//    //$(".dialog").find("iframe").css("overflow-y", "yes");
//}

//$(".dialog").dialog("open").css({ height: dialogheight });//打开对话框.parent().css({ width: 800, height: 560 })
//$(".dialog").dialog("open").parent().css({ width: dialogwidth });
//var left = ($(document.body).width() - dialogwidth) / 2;//计算dialog初始化距离左侧位置

//$(".dialog").dialog("open").parent().offset({ top: 0, left: left }); 