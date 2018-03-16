/**
***author:hety
***date:2015-05-18
***description:主要用于界面选择框的业务操作
***/
//列表页data数据
/*var commonListData = { uniqueId: '', callbackjson:'' };*/

$(function () {
    /*
     ** （1）、操作工具栏（callback list 结构页工具栏）
     ***/
    var $callback_list_tool = $(".callback_list_tool>.tools>.toolbar");
    //确认带回操作(单个操作)(单个带回)
    $("a[target=ajaxtodo]", $callback_list_tool).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            
            //点击了操作按钮
            var singleoperate = $this.attr("singleoperate");
            if (singleoperate) {
                var executeMethod = $this.attr('href').replace("{callbackjson}", commonListData.callbackjson);
                eval(executeMethod);//动态执行js代码
            }
        });
    });
    //确认带回操作(多个操作)(多个带回)
    $("a[target=ajaxtodo]", $callback_list_tool).each(function () {
        var $this = $(this);
        $this.click(function (event) {
            event.preventDefault();           
            //获取多选Guid结合
            var guids = '';
            var mulityoperate = $this.attr("mulityoperate");

            if (!mulityoperate) {
                return;
            }


            //json 串
            var jsonStr = '';
            //多选带回模板标识
            var mulitylookupgroupIdentity = 'mulitylookupgroup';
            //最终带回json数据对象
            var jsonObj = {};
            var jsonCount = 0;
            var ischeck = false;//检查行记录是否被选中，如果有行记录被选中，则其值为true，目的是为了在没有选中任何记录的时候，清空关联UI控件

            $("input[type=checkbox]", $globalTablelist.children("tbody")).each(function () {
                var $checkbox = $(this);
                if ($checkbox.is(':checked')) {
                    ischeck = true;
                    jsonCount++;
                    guids += $checkbox.parents('tr').attr('rel') + ',';
                    jsonStr = $checkbox.parents('tr').attr('callbackjson');
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
            //if (guids != '') {
            //    alertMsg.warn('请选择信息！');
            //    return;
            //}
            var executeMethod = "";
           
            if (!ischeck) {           
                executeMethod = $this.attr('href').replace("{callbackjson}", $globalTablelist.children("thead").find('tr').attr('callbackjson'));
            } else {
                guids = guids.substr(0, guids.length - 1);
                jsonStr = "";
                //把最终json对象转化为json字符串
                for (var json in jsonObj) {
                    jsonStr += "'" + json + "':'" + jsonObj[json] + "',";
                }
                if (jsonStr != '') {
                    jsonStr = jsonStr.substr(0, jsonStr.length - 1);
                }
                jsonStr = "{" + jsonStr + "}";
                 
                commonListData.callbackjson = jsonStr;
                executeMethod = $this.attr('href').replace("{callbackjson}", commonListData.callbackjson);
            }

            eval(executeMethod);//动态执行js代码
        });
    });

    /*
     ** （2）、操作工具栏（iframe callback list 结构父亲页工具栏）
     ***/
    var $iframe_callback_list_tool = $(".iframe_callback_list_tool>.tools>.toolbar");
    //提示确认操作(单个操作)(单个带回)
    $("a[target=ajaxtodo]", $iframe_callback_list_tool).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            //点击了操作按钮
            var singleoperate = $this.attr("singleoperate");

            if (!singleoperate) {
                return;
            }
            var frameName = $this.attr('frametarget');
            var frameuitype = $this.attr('frameuitype');//子框架UI展示形式，包括 "list" 和 "tree",根据不同的UI类型，取不同的唯一业务Guid
            var notice = $this.attr('notice');//提示信息
            var uniqueId = '';
            if (frameuitype) {
                if (frameuitype == 'list') {//列表
                    uniqueId = window.frames[frameName].commonListData.uniqueId;
                } else if (frameuitype == 'tree') {//树
                    uniqueId = window.frames[frameName].commonTreeData.uniqueId;
                }
            }
            if (uniqueId == '') {
                alertMsg.warn(notice);
                return;
            }

            var executeMethod = $this.attr('href').replace("{callbackjson}", window.frames[frameName].commonListData.callbackjson);//这里先取列表中的CallBack带回，如果需要点击树带回的话，以后再扩展，hety，2015-05-28
            eval(executeMethod);//动态执行js代码

        });
    });
    //确认带回操作(多个操作)(多个带回)
    $("a[target=ajaxtodo]", $iframe_callback_list_tool).each(function () {
        var $this = $(this);
        $this.click(function (event) {
            event.preventDefault();
           
            //var $this = $(this);
            //获取多选Guid结合
            var guids = '';
            var mulityoperate = $this.attr("mulityoperate");

            if (!mulityoperate) {
                return;
            }
            var frameName = $this.attr('frametarget');
            var frameuitype = $this.attr('frameuitype');//子框架UI展示形式，包括 "list" 和 "tree",根据不同的UI类型，取不同的唯一业务Guid
            var notice = $this.attr('notice');//提示信息
            var uniqueId = '';

            //json 串
            var jsonStr = '';
            //多选带回模板标识
            var mulitylookupgroupIdentity = 'mulitylookupgroup';
            //最终带回json数据对象
            var jsonObj = {};
            var jsonCount = 0;

            if (frameuitype) {
                if (frameuitype == 'list') {//列表
                    uniqueId = window.frames[frameName].commonListData.uniqueId;
                    $("input[type=checkbox]", window.frames[frameName].$globalTablelist.children("tbody")).each(function () {
                        var $checkbox = $(this);
                        if ($checkbox.is(':checked')) {
                            jsonCount++;
                            guids += $checkbox.parents('tr').attr('rel') + ',';
                            jsonStr = $checkbox.parents('tr').attr('callbackjson');
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
                } else if (frameuitype == 'tree') {//树
                    //以后如果需要树这种带回，再扩展，hety,2015-05-28
                }
            }

            if (guids == '') {
                alertMsg.warn(notice);
                return;
            }
            guids = guids.substr(0, guids.length - 1);
            jsonStr = "";
            //把最终json对象转化为json字符串
            for (var json in jsonObj) {
                jsonStr += "'" + json + "':'" + jsonObj[json] + "',";
            }
            if (jsonStr != '') {
                jsonStr = jsonStr.substr(0, jsonStr.length - 1);
            }
            jsonStr = "{" + jsonStr + "}";
            window.frames[frameName].commonListData.callbackjson = jsonStr;
            var executeMethod = $this.attr('href').replace("{callbackjson}", window.frames[frameName].commonListData.callbackjson);//这里先取列表中的CallBack带回，如果需要点击树带回的话，以后再扩展，hety，2015-05-28
            eval(executeMethod);//动态执行js代码
        });
    });


    /*
     ** （3）、操作工具栏（callback tree 结构页工具栏）
     ***/
    var $iframe_callback_tree_tool = $(".iframe_callback_tree_tool>.tools>.toolbar");
    //确认带回操作(单个操作)(单个带回)
    $("a[target=ajaxtodo]", $iframe_callback_tree_tool).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            //点击了操作按钮
            var singleoperate = $this.attr("singleoperate");

            if (!singleoperate) {
                return;
            }
            var frameName = $this.attr('frametarget');
            var frameuitype = $this.attr('frameuitype');//子框架UI展示形式，包括 "list" 和 "tree",根据不同的UI类型，取不同的唯一业务Guid
            var notice = $this.attr('notice');//提示信息
            var uniqueId = '';
            if (frameuitype) {
                if (frameuitype == 'list') {//列表
                    uniqueId = window.frames[frameName].commonListData.uniqueId;
                } else if (frameuitype == 'tree') {//树
                    uniqueId = window.frames[frameName].commonTreeData.uniqueId;
                }
            }
            if (uniqueId == '') {
                alertMsg.warn(notice);
                return;
            }

            var executeMethod = $this.attr('href').replace("{callbackjson}", window.frames[frameName].commonTreeData.callbackjson);//这里先取点击树的CallBack带回，目前这个模板应该不允许点击列表CallBack带回，hety，2015-07-09
            eval(executeMethod);//动态执行js代码
        });
    });

});