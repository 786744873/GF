/**
***包含业务操作的列表加载js，包括按钮操作，弹出层操作
****/

//列表页data数据
/*var commonListData = { uniqueId: '' };*/

$(function () {    
    //$('<div class="dialog"><iframe width="99%" height="100%" scrolling="no" ></iframe></div>').appendTo("body");
    //$(".dialog").dialog({
    //    autoOpen: false, modal: true, closeText: "关闭"
    //    //open: function (event, ui) {
           
    //    //    var $dialog = $(this);
    //    //    $('.ui-dialog-title', $dialog.parent()).css('width', '70%'); // 界定选取范围。
    //    //    var atext = $(".ui-dialog-titlebar-close", $dialog.parent()).before('<button type="button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only ui-dialog-titlebar-close" role="button" title="关闭"><span class="ui-button-icon-primary ui-icon ui-icon-closethick"></span><span class="ui-button-text">最大化</span></button>');
    //    //}
    //});//初始化弹出Dialog, width: 800, height: 550
    var $toolbar = $(".toolbar");
    $("a[target=popdialog]", $toolbar).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            var uniqueName = commonListData.uniqueName+'_';
            //点击了修改按钮
            var edit = $this.attr("edit");
            if (edit) {
                if (commonListData.uniqueId == '') {
                    alertMsg.warn('请选择信息！');
                    return;
                }        
            } else
            {
                uniqueName = '';
            }
            
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", commonListData.uniqueId);

            //打开对话框
            //$(".outer_wrapper").show();//显示蒙版
            //$(".ui-dialog-title").text($(this).attr("title"));//设置Dialog标题
            //$(".dialog").find("iframe").contents().find("body").html("");//清空body内容           
            //$(".dialog").find("iframe").attr("src", switchUrl);//重新加载url
            //$(".dialog").dialog("open").css({ height: $(this).attr("dialogheight") });//打开对话框.parent().css({ width: 800, height: 560 })
            //$(".dialog").dialog("open").parent().css({ width: $(this).attr("dialogwidth") });
            //var left = ($(document.body).width() - $(this).attr("dialogwidth")) / 2;//计算dialog初始化距离左侧位置
            //$(".dialog").dialog("open").parent().offset({ top: 0, left: left });

            _openDialog(uniqueName+$(this).attr("title"), switchUrl, $(this).attr("dialogwidth"), $(this).attr("dialogheight"));
             
            // dialog-extend options
	/*	    var dialogExtendOptions = {
			  "close" : true,
			  "maximize" : true,
			  "minimize" : true,
			  "dblclick": "maximize",
			  "titlebar": false
		    };

		    
          
            var dialogOptions = {
                "title": $(this).attr("title"),
                "width": $(this).attr("dialogwidth"),
                "height": $(this).attr("dialogheight"),
                "modal": true,                         
                "close": function () { $(this).remove();}
            };
     
            $("<div class=\"dialog\"><iframe width=\"99%\" height=\"100%\" scrolling=\"no\" src=\"" + switchUrl + "\" ></iframe></div>").dialog(dialogOptions).dialogExtend(dialogExtendOptions);*/
        });
    });

    ///数据列表点击事件注册
  /*  var $tablelist = $(".tablelist");
    $("tbody tr", $tablelist).each(function () {
        $(this).click(function () {
            $("tbody tr", $tablelist).each(function () {
                $(this).removeClass("selected");//去掉原有选中行样式
            });
            var $this = $(this);
            $this.addClass("selected");//增加点击选中行样式   
            var tempUniqueId = commonListData.uniqueId;
            commonListData.uniqueId = $this.attr('rel');
            //扩展行改变事件
            if ($this.attr('rowchange') && tempUniqueId != $this.attr('rel')) {
                eval($this.attr('rowchange'));//动态执行js代码
            }            
        });
    });*/

    //提示确认操作(单个操作)(包括删除)
    $("a[target=ajaxtodo]", $toolbar).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);

            //点击了操作按钮
            var singleoperate = $this.attr("singleoperate");
            if (singleoperate) {
                if (commonListData.uniqueId == '') {
                    alertMsg.warn('请选择信息！');
                    return;
                }
            }
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", commonListData.uniqueId);

            alertMsg.confirm($this.attr('title'),{
                  okCall: function(){
                      $.ajax({
                          type: 'POST',
                          url: switchUrl,
                          data: null,
                          dataType: "json",
                          cache: false,
                          success: ajaxToDoCallBack,
                          error: function () {
                              alert('网络错误，请稍后再试!');
                          }
                      });
                  }
            });
        });
    });
    //提示确认操作(多个操作)(包括删除)
    $("a[target=ajaxtodo]", $toolbar).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            //获取多选Guid结合
            var guids = '';
            var mulityoperate = $this.attr("mulityoperate");
            if (mulityoperate) {
                $("input[type=checkbox]", $globalTablelist.children("tbody")).each(function () {
                    var $checkbox = $(this);
                    if ($checkbox.is(':checked')) {                      
                        guids += $checkbox.parents('tr').attr('rel')+',';
                    }
                });
         
                if (guids == '') {
                    alertMsg.warn('请选择信息！');
                    return;
                }
            }
            if (guids != '') {
                guids = guids.substr(0, guids.length - 1);
            } else {
                return;
            }
       
            var inputDatas={};//数据格式{'key':'value','key1':'value'}
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", guids);
           
            //对url参数进行转化为表单post提交data数据格式
            if (switchUrl.split('?').length >= 2) {
                inputDatas = '';
                var urlParameterGroup = switchUrl.split('?')[1].split('&');//形式：key=value,key1=value1...
                for (var i = 0; i < urlParameterGroup.length; i++) {
                    var parameterKeyValue = urlParameterGroup[i].split('=');
                    inputDatas += "'" + parameterKeyValue[0] + "':" + "'" + parameterKeyValue[1] + "',";
                }
                if (inputDatas != '') {
                    inputDatas = inputDatas.substr(0, inputDatas.length - 1);                   
                    inputDatas = '{' + inputDatas + '}';
                    inputDatas = eval('(' + inputDatas+')');//json格式串转为为json对象
                }
            }
            //去掉url参数的最终提交url地址
            switchUrl = switchUrl.split('?')[0];            
            alertMsg.confirm($this.attr('title'), {
                okCall: function () {
                    $.ajax({
                        type: 'POST',
                        url: switchUrl,
                        data: inputDatas,
                        dataType: "json",
                        cache: false,
                        success: ajaxToDoCallBack,
                        error: function () {
                            alert('网络错误，请稍后再试!');
                        }
                    });
                }
            });
        });
    });

    $("a[target=ajaxtodo_owndefine]", $toolbar).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            //获取多选Guid结合
            var guids = '';
            var mulityoperate = $this.attr("mulityoperate");
            if (!mulityoperate) {
                return;
            }
            $("input[type=checkbox]", $globalTablelist.children("tbody")).each(function () {
                var $checkbox = $(this);
                if ($checkbox.is(':checked')) {
                    guids += $checkbox.parents('tr').attr('rel') + ',';
                }
            });
            if (guids != '') {
                guids = guids.substr(0, guids.length - 1);
            }

            var inputDatas = {};//数据格式{'key':'value','key1':'value'}
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", guids);

            //对url参数进行转化为表单post提交data数据格式
            if (switchUrl.split('?').length >= 2) {
                inputDatas = '';
                var urlParameterGroup = switchUrl.split('?')[1].split('&');//形式：key=value,key1=value1...
                for (var i = 0; i < urlParameterGroup.length; i++) {
                    var parameterKeyValue = urlParameterGroup[i].split('=');
                    inputDatas += "'" + parameterKeyValue[0] + "':" + "'" + parameterKeyValue[1] + "',";
                }
                if (inputDatas != '') {
                    inputDatas = inputDatas.substr(0, inputDatas.length - 1);
                    inputDatas = '{' + inputDatas + '}';
                    inputDatas = eval('(' + inputDatas + ')');//json格式串转为为json对象
                }
            }
            //去掉url参数的最终提交url地址
            switchUrl = switchUrl.split('?')[0];
            $.ajax({
                type: 'POST',
                url: switchUrl,
                data: inputDatas,
                dataType: "json",
                cache: false,
                success: ajaxToDoCallBack,
                error: function () {
                    alert('网络错误，请稍后再试!');
                }
            });
        });
    });
});

//操作后回调函数
function ajaxToDoCallBack(json) {  
    //是否弹出消息框
    if (json.isAlertTip == 'Yes') {
        if (json.alertTipPageType == 'ThisPage') {//当前页面弹出
            alertMsg.info(json.Message);//这里可以根据消息类型，弹出不一样的消息对话框，以后扩展.....
            //消息弹出后是否关闭显示内容对话框
            if (json.operateTypeAfterTip == 'NoAction') {
               
            }
            else if (json.operateTypeAfterTip == 'RefreshThisPage')
            {
                setTimeout(function () {
                    if (json.operateTypeAfterTip == 'RefreshThisPage') {
                        window.location.reload();
                    }
                }, 1000);
            } else if (json.operateTypeAfterTip == 'CloseTipAndRefreshThisPage') {
                setTimeout(function () {
                    if (json.operateTypeAfterTip == 'CloseTipAndRefreshThisPage') {
                        alertMsg.close();
                        window.location.reload();
                    }
                }, 1000);
            }
            else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshParent') {
                setTimeout(function () {
                    if (json.operateTypeAfterTip == 'CloseDialogAndRefreshParent') {
                        parent.location.reload();
                    }
                }, 1000);
            } else if (json.operateTypeAfterTip == 'RefreshIframeChildren') {//ajaxtodo刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称
                    setTimeout(function () {
                        alertMsg.close();
                        window.frames[json.forwardUrlAfterTip].location.reload();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshIframeChildren') {//关闭弹出Dialog并且刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称                    
                    setTimeout(function () {
                        alertMsg.close();
                        parent.alertDialog.close();
                        window.parent.frames[json.forwardUrlAfterTip].location.reload();
                    }, 1000);
                }
            }
        }
    } else {

    }
}

/*
**isPreSetManager(是否内置系统管理员)
**roleButtonIds(非内置系统管理员，检查是否有打开详细页面的按钮权限)
**/
function openDetailsView(buttonPower, title, dialogwidth, dialogheight, switchUrl, isPreSetManager, roleButtonIds) {//双击打开详细页面      
    var isAllowOpen = false;//是否允许打开
    if (isPreSetManager == '1') {
        isAllowOpen = true;
    } else {      
        if (roleButtonIds.indexOf(buttonPower) >= 0) {
            isAllowOpen = true;
        }
    } 
    if (isAllowOpen) {
        _openDialog(title, switchUrl, dialogwidth, dialogheight);
    }
}