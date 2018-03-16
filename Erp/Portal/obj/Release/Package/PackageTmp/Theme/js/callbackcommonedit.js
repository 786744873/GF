/**
***author:hety
***date:2015-09-07
***description:主要用于界面编辑选择框带回的业务操作
***/

$(function () {
    /*
     ** （1）、（callback edit 结构页）
    ***/
    var $callback_edit_btn = $(".callback_edit_btn");

    //确认带回操作(多个操作)(多个带回) 
    $callback_edit_btn.click(function (event) {
        var mulityoperate = $callback_edit_btn.attr("mulityoperate");
        if (!mulityoperate) {
            return;
        }

        //json 串
        var jsonStr = '';
        //多选带回模板标识
        var mulitylookupgroupIdentity = 'mulityeditlookupgroup';
        //最终带回json数据对象
        var jsonObj = {};
        var jsonCount = 0;
        var tempUiBoxValues = '';

        $("input[type=text]", $callback_edit_btn.parents('ul.forminfo')).each(function () {
            var $uibox = $(this);
            if ($uibox.val() != '') {
                jsonCount++;

                tempUiBoxValues += $uibox.val() + ',';

                var mulityeditlookupgroup = $uibox.attr('mulityeditlookupgroup');
                var code = $uibox.attr('code');
                var codevalue = $uibox.attr('codevalue');
                var name = $uibox.attr('name');

                jsonStr = "{'mulityeditlookupgroup':'" + mulityeditlookupgroup + "','" + code + "':'" + codevalue + "','" + name + "':'" + $uibox.val() + "'}";

                var thisJson = eval("(" + jsonStr + ")");
                if (jsonCount == 1) {//如果为第一次，则克隆json数据结构
                    jsonObj = thisJson;
                } else {
                    //如果为大于第一次的情况，则累加json值，值以逗号隔开
                    for (var json in jsonObj) {
                        if (json == mulitylookupgroupIdentity) {
                            continue;
                        }
                        for (var item in thisJson) {
                            if (item == mulitylookupgroupIdentity) {
                                continue;
                            }
                            if (json == item) {
                                jsonObj[json] = jsonObj[json] + ',' + thisJson[item];
                            }
                        }
                    }
                }
            }
        });

        if ($callback_edit_btn.attr('notice')) {
            if (tempUiBoxValues=='') {
                alertMsg.warn($callback_edit_btn.attr('notice'));
                return;
            }
        }

        var executeMethod = "";
        
        jsonStr = "";
        //把最终json对象转化为json字符串
        for (var json in jsonObj) {
            jsonStr += "'" + json + "':'" + jsonObj[json] + "',";
        }
        if (jsonStr != '') {
            jsonStr = jsonStr.substr(0, jsonStr.length - 1);
        }      
        jsonStr = "{" + jsonStr + "}";
        executeMethod = $callback_edit_btn.attr('callback').replace("{callbackjson}", jsonStr);
      
        eval(executeMethod);//动态执行js代码
    });


});