/**
***author:hety
***date:2015-10-09
***description:自定义表单中公用js
***/

document.onkeyup = function (e) {      //onkeyup是javascript的一个事件、当按下某个键弹起 var _key; //的时触发
    if (e == null) { // ie
        _key = event.keyCode;
    } else { // firefox              //获取你按下键的keyCode
        _key = e.which;          //每个键的keyCode是不一样的
    }
    if (_key == 13) {   //判断keyCode是否是13，也就是回车键(回车的keyCode是13)
        onlySaveForm(document.getElementById('btnSave'));
    }
}

//查看附件
function viewAttachment(obj) {
    $this = $(obj);
    var switchUrl = $this.attr("url");
    _openDialog($this.attr("title"), switchUrl, $this.attr("dialogwidth"), $this.attr("dialogheight"));
}
//表单元素自定义事件处理       
$(function () {
    //页面加载时,自定义事件触发,执行相应业务逻辑
    //radio事件触发
    $("input[type=radio]").each(function () {
        var $this = $(this);
        if ($this.attr('triggereventtype') && $this.attr('triggereventtype') == '685') {
            radio_change(this);
        }
    });
});
//radio change事件
function radio_change(obj) {
    var $this = $(obj);
    var name = $this.attr('name');
    var checkValue = $('input[name="' + name + '"]:checked').val() + '';
    var dynamicJs = $this.attr('dynamicJs');
    dynamicJs = decodeURIComponent(dynamicJs);
    //动态执行js
    eval(dynamicJs);
}
//重做表单
function redoneForm(obj) {
    var $a = $(obj);
    var switchUrl = $a.attr('confirmurl');
    var title = '是否要确认重做此表单？';
    alertMsg.confirm(title, {
        okCall: function () {
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
}
//查看历史记录
function viewHistoryForm() {
    //切换重做表单历史记录显示与影藏
    if ($('#redone_record_wrap').is(":hidden")) {
        $('#redone_record_wrap').show();
    } else {
        $('#redone_record_wrap').hide();
    }
}
