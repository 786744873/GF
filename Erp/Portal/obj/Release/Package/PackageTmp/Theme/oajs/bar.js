/****
**** author: hety
**** date: 2015-05-20
**** description: 所有操作异步的业务扩展
***/
$(function () {

    /*
     ** （1）、操作工具栏
     ***/
    var $list_tool_dialog_toolbar = $(".list_tool_dialog_toolbar");
    //提示确认操作(单个操作)(包括删除)
    $("a[operatetargettype=ajaxtodo]", $list_tool_dialog_toolbar).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            //点击了操作按钮
            var singleoperate = $this.attr("singleoperate");
            if (!singleoperate) {
                return;
            }
            var nodatatip = $this.attr('nodatatip');//无数据的提示信息
            if (!nodatatip) {
                nodatatip = "请选择信息！";
            }

            var uniqueId = commonListData.uniqueId;
          
            if (uniqueId == '') {
                $('#alertWarning').find('.modal-body').html(nodatatip);//重新设置无数据提示信息
                $('#alertWarning').modal('show');//弹出提示信息框
                return;
            }
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", uniqueId);

            var confirmtip = $this.attr('confirmtip');//确认提示信息，如果无此属性，则为直接操作
            if (confirmtip) {               
                $('#alertConfirmWarning').find('.modal-footer').children().first().attr('url', switchUrl);//设置确定按钮url
                $('#alertConfirmWarning').find('.modal-body').html(confirmtip);//重新设置确认提示信息
                $('#alertConfirmWarning').modal('show');//打开确认信息框
            } else {
                $.ajax({
                    type: 'POST',
                    url: switchUrl,
                    data: null,
                    dataType: "json",
                    cache: false,
                    success: dialogAjaxDone,
                    error: function () {
                        alert('网络错误，请稍后再试!');
                    }
                });
            }          
        });
    });

    //提示确认操作(多个操作)(包括删除)
    $("a[operatetargettype=ajaxtodo]", $list_tool_dialog_toolbar).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            
            //点击了操作按钮
            var mulityoperate = $this.attr("mulityoperate");
            if (!mulityoperate) {
                return;
            }
         
            var nodatatip = $this.attr('nodatatip');//无数据的提示信息
            if (!nodatatip) {
                nodatatip = "请选择信息！";
            }

            var uniqueId = commonListData.uniqueId;
          
            //获取多选Guid结合
            var guids = '';
            $("input[type=checkbox][operate=operate]", $("#" + commonListData.tableId).children("tbody")).each(function () {
                var $checkbox = $(this);
                if ($checkbox.is(':checked')) {
                    guids += $checkbox.parents('tr').attr('rel') + ',';
                }
            });
           
            if (guids == '') {
                $('#alertWarning').find('.modal-body').html(nodatatip);//重新设置无数据提示信息
                $('#alertWarning').modal('show');//弹出提示信息框
                return;
            }

            if (guids != '') {
                guids = guids.substr(0, guids.length - 1);
            }

            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", guids);

            var confirmtip = $this.attr('confirmtip');//确认提示信息，如果无此属性，则为直接操作
            if (confirmtip) {
                $('#alertConfirmWarning').find('.modal-footer').children().first().attr('url', switchUrl);//设置确定按钮url
                $('#alertConfirmWarning').find('.modal-body').html(confirmtip);//重新设置确认提示信息
                $('#alertConfirmWarning').modal('show');//打开确认信息框
            } else {
                $.ajax({
                    type: 'POST',
                    url: switchUrl,
                    data: null,
                    dataType: "json",
                    cache: false,
                    success: dialogAjaxDone,
                    error: function () {
                        alert('网络错误，请稍后再试!');
                    }
                });
            }
        });
    });


    //点击弹出Dialog
    $("a[operatetargettype=popdialog]", $list_tool_dialog_toolbar).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            var operatetargetid = $this.attr('operatetargetid');//某标模式Dialog Id
            var relationid = $this.attr('relationid');//关联触发A Id

            var nodatatip = $this.attr('nodatatip');//无数据的提示信息
            if (!nodatatip) {
                nodatatip = "请选择信息！";
            }

            var uniqueId = commonListData.uniqueId;

            if ($this.attr('edit')) {
                if (uniqueId == '') {
                    $('#alertWarning').find('.modal-body').html(nodatatip);//重新设置无数据提示信息
                    $('#alertWarning').modal('show');//弹出提示信息框
                    return;
                }
            }           
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", uniqueId);
            //关联触发打开           
            $('#' + relationid).attr('href', switchUrl);
            $('#' + relationid).attr('data-target', '#' + operatetargetid);
            $('#' + relationid).click();
        });
    });

    //点击Ajax Loading
    $("a[operatetargettype=ajaxify]", $list_tool_dialog_toolbar).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);          
            var relationid = $this.attr('relationid');//关联触发A Id

            var nodatatip = $this.attr('nodatatip');//无数据的提示信息
            if (!nodatatip) {
                nodatatip = "请选择信息！";
            }

            var uniqueId = commonListData.uniqueId;

            if ($this.attr('edit')) {
                if (uniqueId == '') {
                    $('#alertWarning').find('.modal-body').html(nodatatip);//重新设置无数据提示信息
                    $('#alertWarning').modal('show');//弹出提示信息框
                    return;
                }
            }
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", uniqueId);
            //关联触发打开           
            $('#' + relationid).attr('href', switchUrl);
            
            $('#' + relationid).click();
        });
    });
});

//弹出按钮操作
function btnDialogOperate(thisBtn) {   
    $this = $(thisBtn);
    //替换url参数
    var switchUrl = $this.attr("switchurl");

    var confirmtip = $this.attr('confirmtip');//确认提示信息，如果无此属性，则为直接操作
    if (confirmtip) {
        $('#alertConfirmWarning').find('.modal-footer').children().first().attr('url', switchUrl);//设置确定按钮url
        $('#alertConfirmWarning').find('.modal-body').html(confirmtip);//重新设置确认提示信息
        $('#alertConfirmWarning').modal('show');//打开确认信息框
    } else {
        $.ajax({
            type: 'POST',
            url: switchUrl,
            data: null,
            dataType: "json",
            cache: false,
            success: dialogAjaxDone,
            error: function () {
                alert('网络错误，请稍后再试!');
            }
        });
    }
}