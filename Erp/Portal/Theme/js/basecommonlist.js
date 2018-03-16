/**
***公共列表加载js，主页为分页，查询操作
****/

//分页查询
function executeSearch(thisObj) {    
    if (window.parent != window) {
        top.showBasicLoading();//只有当前页面有父页面时，才会执行加载loading方法
    }
    $this = $(thisObj);
    $targetForm = $("#" + $this.attr("targetformid") + "");
    $targetForm.find(".ThisPageIndex").val($this.attr("currentPageIndex"))//当前页面赋值  
    var isExcutedFormSearch = $targetForm.find(".IsExcutedFormSearch").val();//获取是否已点击过表单查询按钮
    if (parseInt(isExcutedFormSearch) == 1) {
        document.getElementById("" + $this.attr("targetformid") + "").submit();//执行表单分页查询
    } else {
        window.location.href = $this.attr("url");//执行地址栏分页查询
    }
}

//确认跳转分页
function confirmChangePageIndex(thisObj, targetFormId) {
    $this = $(thisObj);
    $targetForm = $("#" + targetFormId + "");
    var pageIndex = $.trim($this.parent().find("input.inputInput").val());
    var reg = /^[1-9]{1}[0-9]*?$/;
    if (!reg.test(pageIndex)) {
        alert('请输入一个有效的页码!');
        return;
    }
    var totalpages = $this.attr("totalPages");
    if (parseInt(pageIndex) > parseInt(totalpages)) {
        alert('请输入一个有效的页码!');
        return;
    }
    $targetForm.find(".ThisPageIndex").val(pageIndex)//当前页码赋值 

    var oldurl = $this.attr("url");
    var newurl;
    newurl = oldurl + pageIndex;

    if (window.parent != window) {
        top.showBasicLoading();//只有当前页面有父页面时，才会执行加载loading方法
    }

    var isExcutedFormSearch = $targetForm.find(".IsExcutedFormSearch").val();//获取是否已点击过表单查询按钮
    if (parseInt(isExcutedFormSearch) == 1) {
        document.getElementById("" + targetFormId + "").submit();///执行表单分页查询
    } else {
        window.location.href = newurl;//执行地址栏分页查询
    }
}

//点击查询
function clickSearch(thisForm) {
    if (window.parent != window) {
        top.showBasicLoading();//只有当前页面有父页面时，才会执行加载loading方法
    }
    $(thisForm).find(".ThisPageIndex").val('1');//初始化页码为：1   
    return true;
}

$(function () {
    $('.tablelist tbody tr:odd').addClass('odd');//初始化Table行背景颜色交替

    var btn = '<li><label>&nbsp;</label><input type="button" class="clearbtn" value="清空" /></li>'; //清空按钮
    var temp = $('.seachform :submit').parent();
    $(temp).after(btn);
    //$('.seachform').append(btn); //添加清空按钮

    $('.clearbtn').click(function () { //清空按钮事件
        var form = $('.seachform').parents('form');
        $(form).find('input:not(.ThisPageIndex):not(.IsExcutedFormSearch):not(:button):not(:submit)').val("");
        $(form).find('select').each(function (index) {
            $(this).get(0).selectedIndex = 0;
        });
       
    });
});