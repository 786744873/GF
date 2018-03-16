/**
*** author:hety
*** date:2015-05-28
*** description:主要用于列表的业务操作
***/

//列表页data数据
var commonListData = { uniqueId: '', callbackjson: '',uniqueName:''}
var $globalTablelist;
$(function () {
    $globalTablelist = $(".tablelist");
    commonListData.table = $globalTablelist;
    $("tbody tr", $globalTablelist).each(function () {
        $(this).click(function () {
            var $this = $(this);

            //扩展行改变事件(行改变之前)
            if ($this.attr('rowchange_before')) {
                var returnFlag = eval($this.attr('rowchange_before'));//动态执行js代码
                if (!returnFlag) {
                    return;//这个事件触发后，回调函数必须返回一个true或者false，目的是处理是否继续执行后续js业务(只有返回true，才可以继续执行后续js业务)
                }
            }
            
            $("tbody tr", $globalTablelist).each(function () {
                $(this).removeClass("selected");//去掉原有选中行样式
            });
           
            $this.addClass("selected");//增加点击选中行样式   
            var tempUniqueId = commonListData.uniqueId;
            commonListData.uniqueId = $this.attr('rel');
            commonListData.uniqueName = $this.attr('relName');
            if ($this.attr('callbackjson')) {
                commonListData.callbackjson = $this.attr('callbackjson');
            }
            //扩展行改变事件(行改变之后)
            if ($this.attr('rowchange') && tempUniqueId != $this.attr('rel')) {
                eval($this.attr('rowchange'));//动态执行js代码
            }
        });
    });
    //处理没有选中时候的，清空关联UI控件值,hety,2015-09-18,目前只能处理界面中只有table的情况，多个table不支持
    $("thead tr", $globalTablelist).each(function () {
        $this = $(this);
        if ($this.attr('callbackjson')) {
            commonListData.callbackjson = $this.attr('callbackjson');
        }
    });
});
