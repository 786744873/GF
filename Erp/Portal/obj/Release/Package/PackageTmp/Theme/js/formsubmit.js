$(function () {
    //模拟点击下拉框弹出对话框 
    //text 得到单击事件
    $("input[type=text][selectdialog=selectdialog]").click(function () {
        var $this = $(this);
        
        if ($this.attr('isdblclick')) {
            //如果为双击事件，则跳出
            return;
        }

        //url
        var switchUrl = $this.attr("switchurl");
        /*
        *** author: hety
        *** date: 2015-05-21
        *** description: 这里用来扩展url中存在的界面UI控件参数，目前只支持一种并且一个UI控件参数(type=hidden)，以后有需要再扩展，完善....
        **/
        var hiddenUI = "input[type=hidden]";
        var handleUrl = switchUrl;
        var newParameters = '';
        //解析switchUrl参数
        if (handleUrl.split('?').length > 1) {
            var urlParameterGroup = handleUrl.split('?')[1].split('&');
            for (var i = 0; i < urlParameterGroup.length; i++) {
                var parameterKeyValue = urlParameterGroup[i].split('=');
                if (parameterKeyValue.length == 2) {//正常情况,key=value(value中不再包含=)
                    newParameters += parameterKeyValue[0] + '=' + parameterKeyValue[1] + '&';
                } else if (parameterKeyValue.length > 2) {//非正常情况,key=value(value中包含=)
                    var specialParaKeyValue = urlParameterGroup[i].split('{');
                    if (specialParaKeyValue.length > 1) {
                        if (specialParaKeyValue[1].indexOf(hiddenUI) >= 0) {
                            var filterHiddenUI = specialParaKeyValue[1].replace("{", "").replace("}", "");
                            var paramValue = $(filterHiddenUI).val();
                            newParameters += specialParaKeyValue[0].replace("=", "") + '=' + paramValue + '&';
                        }
                    }
                }
            }
        }
        if (newParameters != '') {
            newParameters = newParameters.substr(0, newParameters.length - 1);
            switchUrl = switchUrl.split('?')[0] + '?' + newParameters;
        }
        _openDialog($(this).attr("title"), switchUrl, $(this).attr("dialogwidth"), $(this).attr("dialogheight"));
    });

    //text双击事件
    //text 得到点击事件
    $("input[type=text][selectdialog=selectdialog]").dblclick(function () {
        var $this = $(this);

        if (!$this.attr('isdblclick')) {
            //如果不存在此属性，则跳出
            return;
        }

        //url
        var switchUrl = $this.attr("switchurl");
        /*
        *** author: hety
        *** date: 2015-05-21
        *** description: 这里用来扩展url中存在的界面UI控件参数，目前只支持一种并且一个UI控件参数(type=hidden)，以后有需要再扩展，完善....
        **/
        var hiddenUI = "input[type=hidden]";
        var handleUrl = switchUrl;
        var newParameters = '';
        //解析switchUrl参数
        if (handleUrl.split('?').length > 1) {
            var urlParameterGroup = handleUrl.split('?')[1].split('&');
            for (var i = 0; i < urlParameterGroup.length; i++) {
                var parameterKeyValue = urlParameterGroup[i].split('=');
                if (parameterKeyValue.length == 2) {//正常情况,key=value(value中不再包含=)
                    newParameters += parameterKeyValue[0] + '=' + parameterKeyValue[1] + '&';
                } else if (parameterKeyValue.length > 2) {//非正常情况,key=value(value中包含=)
                    var specialParaKeyValue = urlParameterGroup[i].split('{');
                    if (specialParaKeyValue.length > 1) {
                        if (specialParaKeyValue[1].indexOf(hiddenUI) >= 0) {
                            var filterHiddenUI = specialParaKeyValue[1].replace("{", "").replace("}", "");
                            var paramValue = $(filterHiddenUI).val();
                            newParameters += specialParaKeyValue[0].replace("=", "") + '=' + paramValue + '&';
                        }
                    }
                }
            }
        }
        if (newParameters != '') {
            newParameters = newParameters.substr(0, newParameters.length - 1);
            switchUrl = switchUrl.split('?')[0] + '?' + newParameters;
        }
        _openDialog($(this).attr("title"), switchUrl, $(this).attr("dialogwidth"), $(this).attr("dialogheight"));
    });

    //控件触发chang事件后，处理相关业务
    $("input[type=text][triggerevent=change], input[type=password][triggerevent=change], input[type=hidden][triggerevent=change] , textarea[triggerevent=change], select[triggerevent=change]").each(function () {
        $(this).change(function () {
            var $thisUI = $(this);
            var clearRelationUIControlValue = $thisUI.attr('clearRelationUIControlValue')
            if (clearRelationUIControlValue) {//清空关联控件值
                var relationUIControl = clearRelationUIControlValue.split(',');
                for (var i = 0; i < relationUIControl.length; i++) {
                    $(relationUIControl[i]).val('');
                }
            }
            var setRelationDropDownUIControlValue = $thisUI.attr('SetRelationDropDownUIControlValue')
            if (setRelationDropDownUIControlValue) {//
                var relationUIControl = setRelationDropDownUIControlValue;
                var requsetUrl = $thisUI.attr('requsetUrl');
                $.ajax({
                    type: 'post',
                    url: requsetUrl + $thisUI.val(),
                    data: null,
                    dataType: "json",
                    cache: true,
                    success: function (data) {
                        $(relationUIControl).html('');
                        var htmls = '';
                        for (var i = 0; i < data.length; i++) {
                            htmls+="<option value='" + data[i].C_Contacts_code + "'>" + data[i].C_Contacts_name + "</option>";
                        }
                        $(relationUIControl).append(htmls);
                    },
                    error: function () {
                        alert('网络错误，请稍后再试!');
                    }
                });
            }
        });
    });

    //模拟下拉框弹出对话框,默认追加"清空"功能
    $("input[type=text][selectdialog=selectdialog]").each(function () {
        $selectText = $(this);//select text
        $("<span class='icon'></span>").insertAfter($selectText).click(function () {
            $span = $(this);
            $span.parent().find('input[type=text]').val('');
            $span.parent().find('input[type=hidden]').val('');
        });  
    });

});
//选择界面带回值(单个带回)
function bringBack(jsonData) {
    if (jsonData == undefined || jsonData == null) { alertDialog.close(); return };
    $("input[type=text][selectdialog=selectdialog]").each(function () {
        alertDialog.close();
        var $thisText = $(this);
        var lookupgroup = $thisText.attr('lookupgroup');
        if (lookupgroup && jsonData.lookupgroup == lookupgroup) {
            for (var json in jsonData) {//对应控件赋值
                if (json != 'lookupgroup') {
                    $('#' + lookupgroup + '_' + json).val(jsonData[json]);
                }
            }
            return false;
        }
    });
}
//选择界面带回值(多个带回)
function mulityBringBack(jsonData) {    
    $("input[type=text][selectdialog=selectdialog]").each(function () {
        alertDialog.close();
        var $thisText = $(this);
      
        var mulitylookupgroup = $thisText.attr('mulitylookupgroup');
        if (mulitylookupgroup && jsonData.mulitylookupgroup == mulitylookupgroup) {            
            for (var json in jsonData) {//对应控件赋值
                if (json != 'mulitylookupgroup') {
                    //控件原始值
                    var oldValue = $('#' + mulitylookupgroup + '_' + json).val();
                    $('#' + mulitylookupgroup + '_' + json).val(jsonData[json]);
                    //这个地方可以加入当前UI控件值改变时所引发的关联控件chang事件
                    var triggerevent = $('#' + mulitylookupgroup + '_' + json).attr('triggerevent');
                    //控件新值
                    var newValue = jsonData[json];
                    if (triggerevent) {
                        if (oldValue != newValue) {//只有原始值和新值不一样的时候，才可以触发对应事件
                            if (triggerevent == 'change') {//触发chang事件
                                $('#' + mulitylookupgroup + '_' + json).trigger('change');
                            }
                        }
                    }
                }
            }
           
            return false;
        }   

    });
}

//选择界面(编辑界面)带回值(多个带回)
function mulityEditBringBack(jsonData) {
    $("input[type=text][selectdialog=selectdialog]").each(function () {
        alertDialog.close();
        var $thisText = $(this);
        var mulitylookupgroup = $thisText.attr('mulityeditlookupgroup');
        if (mulitylookupgroup && jsonData.mulityeditlookupgroup == mulitylookupgroup) {
            for (var json in jsonData) {//对应控件赋值
                if (json != 'mulityeditlookupgroup') {
                    //控件原始值
                    var oldValue = $('#' + mulitylookupgroup + '_' + json).val();
                    $('#' + mulitylookupgroup + '_' + json).val(jsonData[json]);
                    //这个地方可以加入当前UI控件值改变时所引发的关联控件chang事件
                    var triggerevent = $('#' + mulitylookupgroup + '_' + json).attr('triggerevent');
                    //控件新值
                    var newValue = jsonData[json];

                    if (triggerevent) {
                        if (oldValue != newValue) {//只有原始值和新值不一样的时候，才可以触发对应事件
                            if (triggerevent == 'change') {//触发chang事件
                                $('#' + mulitylookupgroup + '_' + json).trigger('change');
                            }
                        }
                    }
                }
            }

            return false;
        }
    });
}

var commonEditFormData = { isClickedSaveBtn: false };//是否已经点击了表单"保存"按钮，主要是为了控制双击鼠标后，出现数据重复保存的现象，hety，2015-10-08

//仅仅保存
function onlySaveForm(thisBtn) {   
    $thisForm = $(thisBtn).parents('form');

    //表单提交之前解禁select控件disabled="disabled"属性,否则提交表单在Action中取不到此控件的值
    $("select", $thisForm).each(function () {
        var $this = $(this);
        if ($this.attr("disabled") != undefined) {
            $this.attr("disabled", false);
        } 
    });

    $thisForm.find("[name='formOperateType']").val("onlySave");
    $thisForm.submit();
}
//保存并且新增下一个
function saveAndNewNext(thisBtn) {
    $thisForm = $(thisBtn).parents('form');

    //表单提交之前解禁select控件disabled="disabled"属性,否则提交表单在Action中取不到此控件的值
    $("select", $thisForm).each(function () {
        var $this = $(this);
        if ($this.attr("disabled") != undefined) {
            $this.attr("disabled", false);
        }
    });

    $thisForm.find("[name='formOperateType']").val("saveAndNewNext");
    $thisForm.submit();
}

//是否允许执行保存逻辑
function isAllowSave() {
    if (commonEditFormData.isClickedSaveBtn) {
        return false;
    } else {
        commonEditFormData.isClickedSaveBtn = true;//设置"表单是否已点击了保存"标识为true
        return true;
    }
}

/**
 * 普通ajax表单提交
 * @param {Object} form
 * @param {Object} callback
 * @param {String} confirmMsg 提示确认信息
 */
function validateCallback(form, callback) {
    var $form = $(form);

    if (!formValidate($form)) {
        return false;
    }

    if (!isAllowSave()) {
        return false;
    }   

    //提交
    _submitFn(form, callback);

    return false;
}

//表单控件验证函数
function formValidate($thisForm) {
    var isValidate = true;
    $("input[type=text], input[type=password], textarea", $thisForm).each(function () {
        var $this = $(this);
        var text = $.trim($this.val());
        //非空验证
        if ($this.attr("requiredInput") != undefined) {
            $this.parent().children("i").html('');
            if (text == '') {
                $this.focus();
                $this.parent().children("i").html($this.attr("requiredInput"));
                isValidate = false;
                return false;
            }
        }
        //密码格式验证
        if ($this.attr("verifypassword") != undefined) {
            $this.parent().children("i").html('');
            var regname = /^(?=\d{0,5}[a-zA-Z])(?=[a-zA-Z]{0,5}\d)[a-zA-Z0-9]{6,}$/;
            if (regname.test(text)) {
                isValidate = true;
                return true;
            }
            else {
                $this.focus();
                $this.parent().children("i").html($this.attr("verifypassword"));
                isValidate = false;
                return false;
            }
        }
        //正整数验证
        if ($this.attr("positiveInteger") != undefined) {
            $this.parent().children("i").html('');
            if (text != '') {
                if (!new RegExp(/^[1-9]\d*$/).test(text)) {
                    $this.focus();
                    $this.parent().children("i").html($this.attr("positiveInteger"));
                    isValidate = false;
                    return false;
                }
            }
        }
        //金额验证
        if ($this.attr("money") != undefined) {
            $this.parent().children("i").html('');
            if (text != '') {
                if (!new RegExp(/^([1-9][\d]{0,12}|0)(\.[\d]{1,2})?$/).test(text)) {
                    $this.focus();
                    $this.parent().children("i").html($this.attr("money"));
                    isValidate = false;
                    return false;
                }
            }
        }
        //身份证号验证
        if ($this.attr("idnumber") != undefined) {
            $this.parent().children("i").html('');
            if (text != '') {
                if (!new RegExp(/^[1-9]{1}[0-9]{14}$|^[1-9]{1}[0-9]{16}([0-9]|[xX])$/).test(text)) {
                    $this.focus();
                    $this.parent().children("i").html($this.attr("idnumber"));
                    isValidate = false;
                    return false;
                }
            }
        }

    });
    $("select", $thisForm).each(function () {
        var $this = $(this);
        var selectValue = $this.val();
        if (selectValue == '-1') {
            $this.focus();
            $this.parent().children("i").html($this.attr("requiredInput"));
            isValidate = false;
            return false;
        }
    });
    return isValidate;
}

//关联select操作(自定义表单列表联动用到)
function select_onchange_ref(_thisSelect) {
    //这里需要累加条件值  
    $select = $(_thisSelect);
    _refUi = $select.attr('refUi');
    _refUrl = $select.attr('refUrl');
    
    $.ajax({
        type: "POST", dataType: "html", async: false,
        url: _refUrl,
        data: { conditionValue: $select.val() },
        success: function (response) {           
            $('#' + _refUi).html(response);
        }
    });
}

//第三方插件初始化(编辑table里的插件-SelectDialog)，hety,2015-09-16
var ComponentsSelectDialog = function () {
    var $container;//容器
    var handleSelectDialog = function () {
        //单击事件
        $("input[type=text][selectdialog=selectdialog]", $container).click(function () {
            var $this = $(this);

            if ($this.attr('isdblclick')) {
                //如果为双击事件，则跳出
                return;
            }

            //url
            var switchUrl = $this.attr("switchurl");
            /*
            *** author: hety
            *** date: 2015-05-21
            *** description: 这里用来扩展url中存在的界面UI控件参数，目前只支持一种并且一个UI控件参数(type=hidden)，以后有需要再扩展，完善....
            **/
            var hiddenUI = "input[type=hidden]";
            var handleUrl = switchUrl;
            var newParameters = '';
            //解析switchUrl参数
            if (handleUrl.split('?').length > 1) {
                var urlParameterGroup = handleUrl.split('?')[1].split('&');
                for (var i = 0; i < urlParameterGroup.length; i++) {
                    var parameterKeyValue = urlParameterGroup[i].split('=');
                    if (parameterKeyValue.length == 2) {//正常情况,key=value(value中不再包含=)
                        newParameters += parameterKeyValue[0] + '=' + parameterKeyValue[1] + '&';
                    } else if (parameterKeyValue.length > 2) {//非正常情况,key=value(value中包含=)
                        var specialParaKeyValue = urlParameterGroup[i].split('{');
                        if (specialParaKeyValue.length > 1) {
                            if (specialParaKeyValue[1].indexOf(hiddenUI) >= 0) {
                                var filterHiddenUI = specialParaKeyValue[1].replace("{", "").replace("}", "");
                                var paramValue = $(filterHiddenUI).val();
                                newParameters += specialParaKeyValue[0].replace("=", "") + '=' + paramValue + '&';
                            }
                        }
                    }
                }
            }
            if (newParameters != '') {
                newParameters = newParameters.substr(0, newParameters.length - 1);
                switchUrl = switchUrl.split('?')[0] + '?' + newParameters;
            }
            _openDialog($(this).attr("title"), switchUrl, $(this).attr("dialogwidth"), $(this).attr("dialogheight"));
        });
        
        //双击事件
        $("input[type=text][selectdialog=selectdialog]", $container).dblclick(function () {
            var $this = $(this);

            if (!$this.attr('isdblclick')) {
                //如果不存在此属性，则跳出
                return;
            }

            //url
            var switchUrl = $this.attr("switchurl");
            /*
            *** author: hety
            *** date: 2015-05-21
            *** description: 这里用来扩展url中存在的界面UI控件参数，目前只支持一种并且一个UI控件参数(type=hidden)，以后有需要再扩展，完善....
            **/
            var hiddenUI = "input[type=hidden]";
            var handleUrl = switchUrl;
            var newParameters = '';
            //解析switchUrl参数
            if (handleUrl.split('?').length > 1) {
                var urlParameterGroup = handleUrl.split('?')[1].split('&');
                for (var i = 0; i < urlParameterGroup.length; i++) {
                    var parameterKeyValue = urlParameterGroup[i].split('=');
                    if (parameterKeyValue.length == 2) {//正常情况,key=value(value中不再包含=)
                        newParameters += parameterKeyValue[0] + '=' + parameterKeyValue[1] + '&';
                    } else if (parameterKeyValue.length > 2) {//非正常情况,key=value(value中包含=)
                        var specialParaKeyValue = urlParameterGroup[i].split('{');
                        if (specialParaKeyValue.length > 1) {
                            if (specialParaKeyValue[1].indexOf(hiddenUI) >= 0) {
                                var filterHiddenUI = specialParaKeyValue[1].replace("{", "").replace("}", "");
                                var paramValue = $(filterHiddenUI).val();
                                newParameters += specialParaKeyValue[0].replace("=", "") + '=' + paramValue + '&';
                            }
                        }
                    }
                }
            }
            if (newParameters != '') {
                newParameters = newParameters.substr(0, newParameters.length - 1);
                switchUrl = switchUrl.split('?')[0] + '?' + newParameters;
            }
            _openDialog($(this).attr("title"), switchUrl, $(this).attr("dialogwidth"), $(this).attr("dialogheight"));
        });
         
        //模拟下拉框弹出对话框,默认追加"清空"功能
        $("input[type=text][selectdialog=selectdialog]", $container).each(function () {
            $selectText = $(this);//select text
            $("<span class='icon'></span>").insertAfter($selectText).click(function () {
                $span = $(this);
                $span.parent().find('input[type=text]').val('');
                $span.parent().find('input[type=hidden]').val('');
            });
        });
    }

    return {
        //main function to initiate the module
        init: function (_container) {//传递一个局部jquery对象，避免事件追加
            //$container = $('#' + _containerId);
            $container = _container;
            handleSelectDialog();
        }
    };

}();