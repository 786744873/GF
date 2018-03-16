/****
**** author: hety
**** date: 2015-05-20
**** description: 所有操作异步的业务扩展
***/
$(function () {

    /*
     ** （1）、操作工具栏（tree frameset结构页工具栏）
     ***/
    var $frameset_tree_tool = $(".frameset_tree_tool>.tools>.toolbar");
    //提示确认操作(单个操作)(包括删除)
    $("a[target=ajaxtodo]", $frameset_tree_tool).each(function () {
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
            if (!notice) {
                notice = "请选择信息！";
            }
           
            var uniqueId = '';
            if (frameuitype) {
                if (frameuitype == 'list') {//列表
                    uniqueId = window.parent.frames[frameName].commonListData.uniqueId;
                } else if (frameuitype == 'tree') {//树
                    uniqueId = window.parent.frames[frameName].commonTreeData.uniqueId;
                }
            } 
            if (uniqueId == '') {
                alertMsg.warn(notice);
                return;
            }
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", uniqueId);

            alertMsg.confirm($this.attr('title'), {
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
        });
    });
    //点击弹出Dialog
    $("a[target=popdialog]", $frameset_tree_tool).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);

            var frameName = $this.attr('frametarget');
            var frameuitype = $this.attr('frameuitype');//子框架UI展示形式，包括 "list" 和 "tree",根据不同的UI类型，取不同的唯一业务Guid
            var notice = $this.attr('notice');//提示信息
            if (!notice) {
                notice = "请选择信息！";
            }
            var uniqueId = '';

            if (frameuitype) {
                if (frameuitype == 'list') {//列表
                    uniqueId = window.parent.frames[frameName].commonListData.uniqueId;
                } else if (frameuitype == 'tree') {//树
                    uniqueId = window.parent.frames[frameName].commonTreeData.uniqueId;
                }
            }

            if ($this.attr('edit')) {
                if (uniqueId == '') {
                    alertMsg.warn(notice);
                    return;
                }
            }

            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", uniqueId);
            _openDialog($(this).attr("title"), switchUrl, $(this).attr("dialogwidth"), $(this).attr("dialogheight"));
        });
    });

    /*
     ** （2）、操作工具栏（iframe tree 结构父亲页工具栏）
     ***/
    var $iframe_tree_tool = $(".iframe_tree_tool>.tools>.toolbar");
    //提示确认操作(单个操作)(包括删除)
    $("a[target=ajaxtodo]", $iframe_tree_tool).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);

            //点击了操作按钮
            var singleoperate = $this.attr("singleoperate");

            if (!singleoperate) {
                return;
            }

            if (!$this.attr('enablecheck')) {//除去没有选中信息的约束
                if (window.frames["iframe_tree"].commonTreeData.uniqueId == '') {
                    alertMsg.warn('请选择信息！');
                    return;
                }
            }

            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", window.frames["iframe_tree"].commonTreeData.uniqueId);

            alertMsg.confirm($this.attr('title'), {
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
        });
    });
    //点击弹出Dialog
    $("a[target=popdialog]", $iframe_tree_tool).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            if ($this.attr('edit')) {
                if (window.frames["iframe_tree"].commonTreeData.uniqueId == '') {
                    alertMsg.warn('请选择信息！');
                    return;
                }
            }
            
            //if (parseInt(window.frames["iframe_tree"].commonTreeData.level) > 1) {
            //    alertMsg.warn('对不起，系统当前限定2级流程！');
            //    return;
            //}
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", window.frames["iframe_tree"].commonTreeData.uniqueId);
            _openDialog($(this).attr("title"), switchUrl, $(this).attr("dialogwidth"), $(this).attr("dialogheight"));
        });
    });

    /*
     ** （3）、操作工具栏（iframe list 结构父亲页工具栏）
     ***/
    var $iframe_list_tool = $(".iframe_list_tool>.tools>.toolbar");
    //提示确认操作(单个操作)(包括删除)
    $("a[target=ajaxtodo]", $iframe_list_tool).each(function () {
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
 
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", uniqueId);

            alertMsg.confirm($this.attr('title'), {
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
        });
    });
    //提示确认操作(多个操作)(包括删除)
    $("a[target=ajaxtodo]", $iframe_list_tool).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);

            //获取多选Guid结合
            var guids = '';
            var mulityoperate = $this.attr("mulityoperate");
            if (!mulityoperate) {
                return;
            }
           

            var frameName = $this.attr('frametarget');
            var frameuitype = $this.attr('frameuitype');//子框架UI展示形式，包括 "list" 和 "tree",根据不同的UI类型，取不同的唯一业务Guid
            var notice = $this.attr('notice') || "请选择信息！";//提示信息



            var uniqueId = '';
            if (frameuitype) {
                if (frameuitype == 'list') {//列表
                    //uniqueId = window.frames[frameName].commonListData.uniqueId;
                    if (!window.frames[frameName].$globalTablelist) {
                        alertMsg.warn(notice);
                        return;
                    }
                    $("input[type=checkbox]", window.frames[frameName].$globalTablelist.children("tbody")).each(function () {
                        var $checkbox = $(this);
                        if ($checkbox.is(':checked')) {
                            guids += $checkbox.parents('tr').attr('rel') + ',';
                        }
                    });
                } else if (frameuitype == 'tree') {//树
                    //uniqueId = window.frames[frameName].commonTreeData.uniqueId;
                }
            }
            if (guids == '') {
                alertMsg.warn(notice);
                return;
            }

            if (guids != '') {
                guids = guids.substr(0, guids.length - 1);
            } else {
                return;
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
            alertMsg.confirm($this.attr('title'), {
                okCall: function () {
                    $.ajax({
                        type: 'POST',
                        url: switchUrl,
                        data: inputDatas,
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
    });

    //点击弹出Dialog
    $("a[target=popdialog]", $iframe_list_tool).each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);

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
            if ($this.attr('edit')) {
                if (uniqueId == '') {
                    alertMsg.warn(notice);
                    return;
                }
            }
            //替换url参数
            var switchUrl = $this.attr("href").replace("{sid_Iterm}", uniqueId);
            _openDialog($(this).attr("title"), switchUrl, $(this).attr("dialogwidth"), $(this).attr("dialogheight"));
        });
    });

});


//普通表单提交
function _submitFn(form, callback) {
    var $form = $(form);
    var formid = $form.attr('id');
    if (formid == "formCase")
    {
        if (window.parent != window) {
            top.showBasicLoading();
        }
    }
    $.ajax({
        type: form.method || 'POST',
        url: $form.attr("action"),
        data: $form.serializeArray(),
        dataType: "json",
        cache: false,
        success: callback,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert(JSON.stringify($form.serializeArray()));
            alert('表单中存在不合法数据，请认真检查后再试!');
            //表单提交错误时，重新设置"表单是否已点击了保存"标识为false
            if (commonEditFormData) {
                if (commonEditFormData.isClickedSaveBtn) {
                    commonEditFormData.isClickedSaveBtn = false;
                }
            }
        }
    });
}
///表单保存回调后，设置可以继续点击保存按钮并且执行保存逻辑
function setAllowClickSave() {
    //表单提交成功时，重新设置"表单是否已点击了保存"标识为false(只针对表单提交后的，回调)  
    var typeStr = typeof commonEditFormData;   
    if (typeStr != 'undefined') {
        if (commonEditFormData.isClickedSaveBtn) {
            commonEditFormData.isClickedSaveBtn = false;
        }
    }
}

//Dialog表单提交后回调函数
function dialogAjaxDone(json) {    
    //是否弹出消息框       
    if (json.isAlertTip == 'Yes') {
        if (json.alertTipPageType == 'ThisPage') {//当前页面弹出           
            alertMsg.info(json.Message);//这里可以根据消息类型，弹出不一样的消息对话框，以后扩展.....          
            if (json.operateTypeAfterTip == 'NoAction') {
                setAllowClickSave();
            } else if (json.operateTypeAfterTip == 'CloseTip') {//关闭提示
                setTimeout(function () {
                    alertMsg.close();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'CloseTipAndRefreshThisPage') {//关闭提示并且刷新页面
                setTimeout(function () {                  
                    alertMsg.close();
                    setAllowClickSave();
                    window.location.reload();                    
                }, 1000);
            }else if (json.operateTypeAfterTip == 'RefreshThisPage') {//刷新当前页面
                setTimeout(function () {
                    window.location.reload();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshParent') {//关闭弹出Dialog并且刷新父页面
                setTimeout(function () {
                    parent.location.reload();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'RefreshIframeChildren') {//ajaxtodo刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称
                    setTimeout(function () {
                        alertMsg.close();
                        window.frames[json.forwardUrlAfterTip].location.reload();
                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshIframeChildren') {//关闭弹出Dialog并且刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称                    
                    setTimeout(function () {
                        parent.alertMsg.close();                       
                        window.parent.frames[json.forwardUrlAfterTip].location.reload();
                        setAllowClickSave();
                        parent.alertDialog.close();                        
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'CloseDialog') {//关闭弹出Dialog
                setTimeout(function () {
                    alertMsg.close();
                    parent.alertDialog.close();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'ThisPageGoAnotherPage') {//当前页面跳转到另外一个页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        alertMsg.close();
                        window.location.href = json.forwardUrlAfterTip;
                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'ThisPageGoAnotherPageAndRefreshParentPage') {//当前页面跳转到另外一个页面并且刷新父页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        alertMsg.close();
                        window.parent.location.reload();
                        window.location.href = json.forwardUrlAfterTip;
                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'ParentPageGoAnotherPage') {//父页面跳转到另外一个页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        alertMsg.close();
                        setAllowClickSave();
                        window.parent.location.href = json.forwardUrlAfterTip;
                    }, 1000);
                }
            }
            
            setTimeout(function () {
                if (json.operateTypeAfterTip == 'RefreshParent') {
                    parent.location.reload();
                    setAllowClickSave();
                }
            }, 1000);
            setTimeout(function () {
                if (json.operateTypeAfterTip == 'CloseDialogAndRefreshGrandpa') {
                    parent.parent.location.reload();
                    setAllowClickSave();
                }
            }, 1000);
        } else if (json.alertTipPageType == 'ParentPage') {//父页面弹出
            parent.alertMsg.info(json.Message);//这里可以根据消息类型，弹出不一样的消息对话框，以后扩展.....
            //消息弹出后,后续操作类型
            if (json.operateTypeAfterTip == 'NoAction') {
                setAllowClickSave();
            }else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshParent') {
                //parent.alertDialog.close();
                setTimeout(function () {
                    parent.location.reload();
                    setAllowClickSave();
                }, 1000);              
            } else if (json.operateTypeAfterTip == 'RefreshParent') {
                setTimeout(function () {
                    parent.location.reload();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'RefreshThisPage') {//刷新当前页面
                setTimeout(function () {
                    window.location.reload();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'CloseTipAndRefreshThisPage') {//关闭提示并且刷新页面
                setTimeout(function () {                  
                    parent.alertMsg.close();
                    window.location.reload();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'CloseTip') {//关闭提示
                setTimeout(function () {
                    parent.alertMsg.close();                  
                    setAllowClickSave();
                }, 1000);
            }
            else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshIframeChildren') {//关闭弹出Dialog并且刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称
                    parent.alertDialog.close();
                    setTimeout(function () {
                        parent.alertMsg.close();
                        window.parent.frames[json.forwardUrlAfterTip].location.reload();
                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'ThisPageGoAnotherPage') {//当前页面跳转到另外一个页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        parent.alertMsg.close();
                        window.location.href = json.forwardUrlAfterTip;
                        setAllowClickSave();
                    }, 1000);
                }
            }
            else if (json.operateTypeAfterTip == 'ThisPageGoAnotherPageAndRefreshParentPage') {//当前页面跳转到另外一个页面并且刷新父页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        parent.alertMsg.close();
                        window.parent.document.forms[0].submit();//无法实现
                        window.location.href = json.forwardUrlAfterTip;
                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'ParentPageGoAnotherPage') {//父页面跳转到另外一个页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        parent.alertMsg.close();
                        setAllowClickSave();
                        window.parent.location.href = json.forwardUrlAfterTip;
                    }, 1000);
                }
            }
        }
    } else {
        if (json.alertTipPageType == 'ThisPage') {//当前页面弹出       
            if (json.operateTypeAfterTip == 'NoAction') {
                setAllowClickSave();
            } else if (json.operateTypeAfterTip == 'CloseTip') {//关闭提示
                setTimeout(function () {
                    alertMsg.close();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'RefreshThisPage') {//刷新当前页面
                setTimeout(function () {                    
                    setAllowClickSave();
                    window.location.reload();                    
                }, 1000);
            } else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshParent') {//关闭弹出Dialog并且刷新父页面
                setTimeout(function () {
                    parent.location.reload();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'RefreshIframeChildren') {//ajaxtodo刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称
                    setTimeout(function () {
                        alertMsg.close();
                        window.frames[json.forwardUrlAfterTip].location.reload();
                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshIframeChildren') {//关闭弹出Dialog并且刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称                    
                    setTimeout(function () {
                        parent.alertMsg.close();
                        setAllowClickSave();
                        parent.alertDialog.close();
                        window.parent.frames[json.forwardUrlAfterTip].location.reload();                        
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'CloseDialog') {//关闭弹出Dialog
                setTimeout(function () {
                    alertMsg.close();
                    parent.alertDialog.close();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'MoveMenu') {//针对菜单移动
                setTimeout(function () {
                    var treeMenuId = window.frames["iframe_tree"].commonTreeData.uniqueId;
                    window.document.getElementById("iframe_tree").src = "/sysmanager/menu/tree?menuId=" + treeMenuId;
                    setAllowClickSave();
                    //window.frames["iframe_tree"].location.reload();
                }, 1000);
            }
            setTimeout(function () {
                if (json.operateTypeAfterTip == 'RefreshParent') {
                    parent.location.reload();
                    setAllowClickSave();
                }
            }, 1000);
            setTimeout(function () {
                if (json.operateTypeAfterTip == 'CloseDialogAndRefreshGrandpa') {
                    parent.parent.location.reload();
                    setAllowClickSave();
                }
            }, 1000);
        } else if (json.alertTipPageType == 'ParentPage') {//父页面弹出
            parent.alertMsg.info(json.Message);//这里可以根据消息类型，弹出不一样的消息对话框，以后扩展.....
            //消息弹出后,后续操作类型
            if (json.operateTypeAfterTip == 'CloseDialogAndRefreshParent') {
                parent.alertDialog.close();
                setTimeout(function () {
                    parent.location.reload();
                    setAllowClickSave();
                }, 1000);
            } else if (json.operateTypeAfterTip == 'RefreshParent') {
                setTimeout(function () {
                    parent.location.reload();
                    setAllowClickSave();
                }, 1000);
            }
            else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshIframeChildren') {//关闭弹出Dialog并且刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称
                    parent.alertDialog.close();
                    setTimeout(function () {
                        parent.alertMsg.close();
                        window.parent.frames[json.forwardUrlAfterTip].location.reload();
                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'ThisPageGoAnotherPage') {//当前页面跳转到另外一个页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        parent.alertMsg.close();
                        setAllowClickSave();
                        window.location.href = json.forwardUrlAfterTip;                        
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'ThisPageOpenAnotherPage') {//当前页面打开另外一个页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        parent.alertMsg.close();
                        parent._openDialog('提交表单', json.forwardUrlAfterTip, '1200', '610');
                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'ParentPageGoAnotherPage') {//父页面跳转到另外一个页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 目标 url                    
                    setTimeout(function () {
                        parent.alertMsg.close();
                        setAllowClickSave();
                        window.parent.location.href = json.forwardUrlAfterTip;
                    }, 1000);
                }
            }
        }
    }
    top.hideBasicLoading();
}
//nav表单提交后回调函数
function navAjaxDone(json) {

    //是否弹出消息框   
    if (json.isAlertTip == 'Yes') {
        if (json.alertTipPageType == 'ThisPage') {//当前页面弹出
            alertMsg.info(json.Message);//这里可以根据消息类型，弹出不一样的消息对话框，以后扩展.....          
            if (json.operateTypeAfterTip == 'NoAction') {
                setAllowClickSave();
            } else if (json.operateTypeAfterTip == 'RefreshIframeChildren') {//ajaxtodo刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称
                    setTimeout(function () {
                        alertMsg.close();
                        //可以处理多个Iframe子页面的重新加载
                        var iframeNameGroup = json.forwardUrlAfterTip.split(',');
                        for (var i = 0; i < iframeNameGroup.length; i++) {
                            window.frames[iframeNameGroup[i]].location.reload();
                        }

                        setAllowClickSave();
                    }, 1000);
                }
            } else if (json.operateTypeAfterTip == 'OrganizationSave') {//针对组织架构保存
                setTimeout(function () {
                    //parent.location.reload();
                    alertMsg.close();                    
                    document.getElementById("addOrg").click();
                    var treeFrameCode = window.parent.frames["leftTreeFrame"].commonTreeData.uniqueId;
                    window.parent.document.getElementById("leftTreeFrame").src = window.parent.document.getElementById("leftTreeFrame").src + "&orgCode=" + treeFrameCode;
                    //window.parent.frames["leftTreeFrame"].location.reload();
                    setAllowClickSave();
                }, 1000);                
            } else if (json.operateTypeAfterTip == 'CloseTip') {//关闭提示
                setTimeout(function () {
                    alertMsg.close();
                    setAllowClickSave();
                }, 1000);
            }
            setTimeout(function () {
                if (json.operateTypeAfterTip == 'RefreshParent') {
                    parent.location.reload();
                    setAllowClickSave();
                }
            }, 1000);
        } else if (json.alertTipPageType == 'ParentPage') {//父页面弹出
            //消息弹出后,后续操作类型
            if (json.operateTypeAfterTip == 'CloseDialogAndRefreshParent') {
                parent.alertDialog.close();
                setAllowClickSave();
            }
            parent.alertMsg.info(json.Message);//这里可以根据消息类型，弹出不一样的消息对话框，以后扩展.....

            setTimeout(function () {
                if (json.operateTypeAfterTip == 'CloseDialogAndRefreshParent') {
                    parent.location.reload();
                    setAllowClickSave();
                }
                if (json.operateTypeAfterTip == 'RefreshParent') {
                    parent.location.reload();
                    setAllowClickSave();
                }
            }, 1000);
        }
    } else {
        if (json.alertTipPageType == 'ThisPage') {//当前页面弹出        
            if (json.operateTypeAfterTip == 'NoAction') {
                setAllowClickSave();
            } else if (json.operateTypeAfterTip == 'RefreshIframeChildren') {//ajaxtodo刷新Iframe子页面
                if (json.forwardUrlAfterTip != '') {                   
                    //这种情况 json.forwardUrlAfterTip 里存放 Iframe 子页面名称
                    setTimeout(function () {
                        alertMsg.close();
                        var iframeNameGroup = json.forwardUrlAfterTip.split(',');
                        for (var i = 0; i < iframeNameGroup.length; i++) {
                            window.frames[iframeNameGroup[i]].location.reload();
                        }
                        setAllowClickSave();
                    }, 1000);
                }
            }
        }
    }
}