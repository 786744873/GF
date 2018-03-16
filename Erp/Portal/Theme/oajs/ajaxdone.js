//表单成功或失败的提示信息对象
var formAlert = function () {
    var success;
    var error;
};
//确认操作
function confirmOperate(thisObj) {
    $('#alertConfirmWarning').modal('hide');//关闭确认信息框
    var switchUrl = $(thisObj).attr('url');    
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

//普通表单提交
function _submitFn(form, callback, success, error) {
    var $form = form;
    formAlert.success = success;
    formAlert.error = error;   
    $.ajax({
        type: form.method || 'POST',
        url: $form.attr("action"),
        data: $form.serializeArray(),
        dataType: "json",
        cache: false,
        success: callback,
        error: function () {
            alert('网络错误，请稍后再试!');
        }
    });
}

//带队列文件表单提交
function _submitFileFn(form, callback, success, error) {
    var $form = form;
    var formId = $form.attr('id');//表单Id
    formAlert.success = success;
    formAlert.error = error;
    $.ajax({
        type: form.method || 'POST',
        url: $form.attr("action"),
        data: $form.serializeArray(),
        dataType: "json",
        cache: false,
        success: function () {           
            //执行上传文件逻辑(触发对应的上传按钮点击事件)          
             $('#' + formId + "_uploadFile").click();           
        },
        error: function () {
            alert('网络错误，请稍后再试!');
        }
    });
}
//jquery.form.js插件提交
function _submitFnByJqueryForm(form, callback, success, error) {
    var $form = form;
    if ($form.attr('baseLargeModal'))
    {//处理上传文件，正在处理中gif图片
        $('#baseLargeModal').modal('show');
    }
    formAlert.success = success;
    formAlert.error = error;
    form.ajaxSubmit({
        type: "post",
        url: form.attr('action'),
        //beforeSubmit: showRequest,
        success: callback
    });
}

//弹出表单提交后回到函数
function formDialogAjaxDone(json) {
    //是否弹出消息框   
    if (json.isAlertTip == 'No') {
        if (json.alertTipPageType == 'ThisPage') {//当前页面弹出消息框
            //根据消息类型，处理消息内容
            if (json.tipTyped == 'Success') {//成功消息
                formAlert.success.find('span').text(json.Message);
                formAlert.success.show();
                formAlert.error.hide();
            } else if (json.tipTyped == 'Error') {//失败消息
                formAlert.error.find('span').text(json.Message);
                formAlert.success.hide();
                formAlert.error.show();
            }

            //消息框弹出后，如何处理业务
            if (json.operateTypeAfterTip == 'NoAction') {//不做任何处理

            } else if (json.operateTypeAfterTip == 'CloseDialogAndRefreshThisPage') {//关闭弹出Dialog并且刷新页面
                setTimeout(function () {
                   // $('#baseLargeModal').modal('hide');
                    if (json.forwardUrlAfterTip != '') {
                        var operateIds = json.forwardUrlAfterTip.split('|');
                        if (operateIds[0].indexOf('calendar_') > -1) {
                            $('#' + operateIds[0]).fullCalendar('refetchEvents'); //刷新日历事件
                        } else if (operateIds[0].indexOf('ajaxify_trigger') > -1) {                            
                            $('#' + operateIds[0]).attr('href', operateIds[2]);
                            $('#' + operateIds[0]).click();//关联触发Ajax Loading Content加载其它页面
                        }
                        else {
                            $('#' + operateIds[0]).dataTable().fnDraw(false);//刷新列表
                        }
                        
                        $('#' + operateIds[1]).modal('hide');//关闭弹出Dialog
                    }
                }, 1000);
            }
        }
    } 
}

//非弹出表单提交后回调函数
function formNavAjaxDone(json) {
    //是否弹出消息框       
    if (json.isAlertTip == 'No') {
        if (json.alertTipPageType == 'ThisPage') {//当前页面弹出消息框
            //根据消息类型，处理消息内容
            if (json.tipTyped == 'Success') {//成功消息
                formAlert.success.find('span').text(json.Message);
                formAlert.success.show();
                formAlert.error.hide();
            } else if (json.tipTyped == 'Error') {//失败消息
                formAlert.error.find('span').text(json.Message);
                formAlert.success.hide();
                formAlert.error.show();
            }

            //消息框弹出后，如何处理业务
            if (json.operateTypeAfterTip == 'NoAction') {//不做任何处理

            } else if (json.operateTypeAfterTip == 'ThisPageGoAnotherPage') {//当前页面跳转到另外一个页面
                setTimeout(function () {                    
                    if (json.forwardUrlAfterTip != '') {
                        var operateIds = json.forwardUrlAfterTip.split('|');
                        if (operateIds[0].indexOf('ajaxify_trigger') > -1) {
                            $('#' + operateIds[0]).attr('href', operateIds[1]);
                            $('#' + operateIds[0]).click(); //关联触发Ajax Loading Content加载其它页面
                        } else {
                            window.location.href = operateIds[0];
                        }
                    }
                }, 1000);
            } else if (json.operateTypeAfterTip == 'ThisPageOpenAnotherPage') {//当前页面打开另外一个页面
                setTimeout(function () {
                    if (json.forwardUrlAfterTip != '') {                      
                        var operateIds = json.forwardUrlAfterTip.split('|');
                        if (operateIds[0].indexOf('atarget_trigger') > -1) {
                            $('#' + operateIds[0]).attr('href', operateIds[2]);
                            $('#' + operateIds[0]).attr('data-target', '#' + operateIds[1]);
                            $('#' + operateIds[0]).click(); //关联触发弹出一个Dialog
                        }
                    }
                }, 1000);
            }
            else if (json.operateTypeAfterTip == 'RefreshThisPage') {//刷新当前页面
                setTimeout(function () {
                    window.location.reload();
                }, 1000);
            }
            else if (json.operateTypeAfterTip == 'RefreshPartial') {//刷新当前页面
                $('#refshcom').click();
            }
        }
    }
}


//Dialog表单提交后回调函数
function dialogAjaxDone(json) {
    //是否弹出消息框   
   if (json.isAlertTip == 'Yes') {
       if (json.alertTipPageType == 'ThisPage') {//当前页面弹出消息框
           //根据消息类型，处理消息内容
           if (json.tipTyped == 'Success' || json.tipTyped == 'Error') {//成功消息 或者失败消息                 
               $('#alertWarning').find('.modal-body').html(json.Message);//重新设置提示信息
               $('#alertWarning').modal('show');//打开信息框
           }

           //消息框弹出后，如何处理业务
           if (json.operateTypeAfterTip == 'NoAction') {//不做任何处理

           } else if (json.operateTypeAfterTip == 'CloseTipAndRefreshThisPage') {//关闭提示消息，并且刷新当前页面
               setTimeout(function () {
                   $('#alertWarning').modal('hide');//关闭信息框                  
                   if (json.forwardUrlAfterTip != '') {
                       if (json.forwardUrlAfterTip.indexOf('|') > -1) {
                           var operateIds = json.forwardUrlAfterTip.split('|');
                           if (operateIds[0].indexOf('calendar_') > -1) {
                               $('#' + operateIds[0]).fullCalendar('refetchEvents'); //刷新日历事件
                           }
                           $('#' + operateIds[1]).modal('hide');//关闭弹出Dialog
                       } else {
                           if (json.forwardUrlAfterTip.indexOf('ajaxify_sidebar_') > -1) {
                               $('#' + json.forwardUrlAfterTip).click();//刷新类似便签页面
                           } else {
                               $('#' + json.forwardUrlAfterTip).dataTable().fnDraw(false);//刷新列表
                           }
                       }                     
                   }
               }, 1000);
           } else if (json.operateTypeAfterTip == 'ThisPageGoAnotherPage') {//当前页面跳转到另外一个页面
               setTimeout(function () {
                   if (json.forwardUrlAfterTip != '') {
                       var operateIds = json.forwardUrlAfterTip.split('|');
                       if (operateIds[0].indexOf('ajaxify_part_trigger') > -1) {
                           $('#' + operateIds[0]).attr('href', operateIds[1]);
                           $('#' + operateIds[0]).click(); //关联触发Ajax Loading Content加载其它页面
                       }
                       if (operateIds[0].indexOf('ajaxify_trigger') > -1) {
                           $('#' + operateIds[0]).attr('href', operateIds[1]);
                           $('#' + operateIds[0]).click(); //关联触发Ajax Loading Content加载其它页面
                       }
                   }
               }, 1000);
           } else if (json.operateTypeAfterTip == 'CloseTipAndThisPageGoAnotherPage') {//关闭提示并且当前页面跳转到另外一个页面
               setTimeout(function () {
                   $('#alertWarning').modal('hide');//关闭信息框     
                   if (json.forwardUrlAfterTip != '') {
                       var operateIds = json.forwardUrlAfterTip.split('|');
                       if (operateIds[0].indexOf('ajaxify_part_trigger') > -1) {
                           $('#' + operateIds[0]).attr('href', operateIds[1]);
                           $('#' + operateIds[0]).click(); //关联触发Ajax Loading Content加载其它页面
                       }
                       if (operateIds[0].indexOf('ajaxify_trigger') > -1) {
                           $('#' + operateIds[0]).attr('href', operateIds[1]);
                           $('#' + operateIds[0]).click(); //关联触发Ajax Loading Content加载其它页面
                       }
                   }
               }, 1000);
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