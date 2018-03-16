/* Chinese initialisation for the jQuery UI date picker plugin. */
/* Written by Cloudream (cloudream@gmail.com). */
/*datepicker日期控件中文初始化*/
//(function (factory) {
//    if (typeof define === "function" && define.amd) {

//        // AMD. Register as an anonymous module.
//        define(["../datepicker"], factory);
//    } else {

//        // Browser globals
//        factory(jQuery.datepicker);
//    }
//}
//(function (datepicker) {

//    datepicker.regional['zh-CN'] = {
//        closeText: '关闭',
//        prevText: '&#x3C;上月',
//        nextText: '下月&#x3E;',
//        currentText: '今天',
//        monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
//        '七月', '八月', '九月', '十月', '十一月', '十二月'],
//        monthNamesShort: ['一月', '二月', '三月', '四月', '五月', '六月',
//        '七月', '八月', '九月', '十月', '十一月', '十二月'],
//        dayNames: ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
//        dayNamesShort: ['周日', '周一', '周二', '周三', '周四', '周五', '周六'],
//        dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
//        weekHeader: '周',
//        dateFormat: 'yy-mm-dd',
//        firstDay: 1,
//        isRTL: false,
//        showMonthAfterYear: true,
//        yearSuffix: '年'
//    };
//    datepicker.setDefaults(datepicker.regional['zh-CN']);

//    return datepicker.regional['zh-CN'];

//}));

/**
***以下为业务中集成的日期控件初始化逻辑
***hety,2015-05-07
***/
$(function () {
    var $forminfo = $(".forminfo");//编辑表单
    var $emptyforminfo = $(".emptyforminfo");//收缩的查询条件表单
    var $tableedit = $('.tableedit');//编辑table
    $("input[type=text][date=date]", $forminfo).each(function () {
        $this = $(this);
        $this.addClass("Wdate");
        var dateformat=$this.attr('dateformat');
        //$this.datepicker({ showOn: "button", changeYear: true, changeMonth: true, dateFormat: $this.attr('dateformat') || 'yy-mm-dd', showButtonPanel: true, buttonImage: "/theme/images/calendar.gif", buttonImageOnly: true,buttonText:"选择" });
        $this.click(function () {
            WdatePicker({ dateFmt: dateformat || 'yyyy-MM-dd', skin: 'twoer' });
        });
        //得到关联日期文本框对象
        //var $datetext = $this.parent().find('input');
        ////获取统一文本框宽度
        //var datetext_originalwidth = $datetext.width();
        ////减去日期文本框一些宽度，目的是让日期图片可以显示在统一页面风格之内
        //var datetext_newwidth = $datetext.width() - 60;
        //$datetext.width(datetext_newwidth);
    });
    $("input[type=text][date=date]", $emptyforminfo).each(function () {
        $this = $(this);
        $this.addClass("Wdate");
        var dateformat = $this.attr('dateformat');
        //$this.datepicker({ showOn: "button", changeYear: true, changeMonth: true, dateFormat: $this.attr('dateformat') || 'yy-mm-dd', showButtonPanel: true, buttonImage: "/theme/images/calendar.gif", buttonImageOnly: true,buttonText:"选择" });
        $this.click(function () {
            WdatePicker({ dateFmt: dateformat || 'yyyy-MM-dd', skin: 'twoer' });
        });
        //得到关联日期文本框对象
        //var $datetext = $this.parent().find('input');
        ////获取统一文本框宽度
        //var datetext_originalwidth = $datetext.width();
        ////减去日期文本框一些宽度，目的是让日期图片可以显示在统一页面风格之内
        //var datetext_newwidth = $datetext.width() - 60;
        //$datetext.width(datetext_newwidth);
    });
    $("input[type=text][date=date]", $tableedit).each(function () {
        $this = $(this);
        var dateformat = $this.attr('dateformat');
        //$this.datepicker({ showOn: "button", changeYear: true, changeMonth: true, dateFormat: $this.attr('dateformat') || 'yy-mm-dd', showButtonPanel: true, buttonImage: "/theme/images/calendar.gif", buttonImageOnly: true, buttonText: "选择" });
        $this.addClass("Wdate");
        $this.click(function () {
            WdatePicker({ dateFmt: dateformat || 'yyyy-MM-dd', skin: 'twoer' });
        });
        //得到关联日期文本框对象
        //var $datetext = $this.parent().find('input');
        ////获取统一文本框宽度
        //var datetext_originalwidth = $datetext.width();
        ////减去日期文本框一些宽度，目的是让日期图片可以显示在统一页面风格之内
        //var datetext_newwidth = $datetext.width() - 60;
        //$datetext.width(datetext_newwidth);
    });
});

//第三方插件初始化(编辑table里的插件)，hety,2015-08-18
var ComponentsPickers = function () {
    var $tableedit;//编辑table
    var handleDatePickers = function () {
        $("input[type=text][date=date]", $tableedit).each(function () {
            $this = $(this);           
            if (!$this.hasClass('Wdate')) {//如果日期控件已经初始化，则不可以继续初始化            
                //$this.datepicker({ showOn: "button", changeYear: true, changeMonth: true, dateFormat: $this.attr('dateformat') || 'yy-mm-dd', showButtonPanel: true, buttonImage: "/theme/images/calendar.gif", buttonImageOnly: true, buttonText: "选择" });
                ////得到关联日期文本框对象
                //var $datetext = $this.parent().find('input');
                ////获取统一文本框宽度
                //var datetext_originalwidth = $datetext.width();
                ////减去日期文本框一些宽度，目的是让日期图片可以显示在统一页面风格之内
                //var datetext_newwidth = $datetext.width() - 60;
                //$datetext.width(datetext_newwidth);
                $this = $(this);
                var dateformat = $this.attr('dateformat');
                //$this.datepicker({ showOn: "button", changeYear: true, changeMonth: true, dateFormat: $this.attr('dateformat') || 'yy-mm-dd', showButtonPanel: true, buttonImage: "/theme/images/calendar.gif", buttonImageOnly: true, buttonText: "选择" });
                $this.addClass("Wdate");
                $this.click(function () {
                    WdatePicker({ dateFmt: dateformat || 'yyyy-MM-dd', skin: 'twoer' });
                });
            }
        });
    }

    return {
        //main function to initiate the module
        init: function (_tableId) {
            $tableedit = $('#' + _tableId);
            handleDatePickers();
        }
    };

}();