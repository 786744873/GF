var FormValidation = function () {
    var validationForm;
    var callback;
    // validation using icons
    var handleValidation = function () {
        // for more info visit the official plugin documentation: 
        // http://docs.jquery.com/Plugins/Validation
        var error = $('.alert-danger', validationForm);
        var success = $('.alert-success', validationForm);
        error.find('span').text(error.find('span').attr('defaulttext'));
        success.find('span').text(error.find('span').attr('defaulttext'));

        //从新构架验证，hety,2015-07-21
        var customerRulesStr='';
        var customerMessagesStr = '';
        var customerRules;
        var customerMessages;
        $("input[type=text],input[type=password],textarea,input[type=file]", this.validationForm).each(function () {
            var $this = $(this);         
            //验证类型
            if ($this.attr("validateType") != undefined) {
                customerRulesStr += $this.attr("name") + ":" + $this.attr("validateType") + ",";
            }
            //验证信息
            if ($this.attr("validateMessage") != undefined) {
                customerMessagesStr += $this.attr("name") + ":" + $this.attr("validateMessage") + ",";
            }
        });

        if (customerRulesStr != '') {
            customerRulesStr = customerRulesStr.substr(0, customerRulesStr.length - 1);
            customerRulesStr = '{' + customerRulesStr + '}';
            customerRules = eval("(" + customerRulesStr + ")");
        } else {
            customerRules = {};//构架空对象
        }
        if (customerMessagesStr != '') {
            customerMessagesStr = customerMessagesStr.substr(0, customerMessagesStr.length - 1);
            customerMessagesStr = '{' + customerMessagesStr + '}'; 
            customerMessages = eval("(" + customerMessagesStr + ")");
        } else {
            customerMessages = {};//构架空对象
        }

        validationForm.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block help-block-error', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",  // validate all fields including form hidden input
            rules: customerRules,
            messages: customerMessages,

            invalidHandler: function (event, validator) { //display error alert on form submit              
                success.hide();
                error.show();
                Metronic.scrollTo(error, -200);
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                var icon = $(element).parent('.input-icon').children('i');
                icon.removeClass('fa-check').addClass("fa-warning");
                icon.attr("data-original-title", error.text()).tooltip();//
            },

            highlight: function (element) { // hightlight error inputs
                $(element).closest('.form-group').removeClass("has-success").addClass('has-error'); // set error class to the control group   
            },

            unhighlight: function (element) { // revert the change done by hightlight

            },

            success: function (label, element) {
                var icon = $(element).parent('.input-icon').children('i');
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success'); // set success class to the control group
                icon.removeClass("fa-warning").addClass("fa-check");
            },

            submitHandler: function (form) {
                success.show();
                error.hide();
                //jquery validate 插件表单验证后，回调此方法
                // submit the form    
                //表单提交之前解禁select控件disabled="disabled"属性,否则提交表单在Action中取不到此控件的值
                $("select", this.validationForm).each(function () {
                    var $this = $(this);
                    if ($this.attr("disabled") != undefined) {
                        $this.attr("disabled", false);
                    }
                });
                //提交
                if (validationForm.attr('enctype')) {
                    if (validationForm.attr('submitplug'))
                    {
                        if (validationForm.attr('submitplug') == 'formplug') {//使用jquery.form.js插件提交
                            _submitFnByJqueryForm(validationForm, callback, success, error);
                        }
                    } else {
                        //带队列文件上传的表单提交(这种情况，对于已添加了的文件，才会执行此方法，否则按普通表单提交执行)
                        var needUploadFileNum = 0;//需要上传文件的数量
                        $("tr[newfile=newfile]", '.files').each(function () {
                            needUploadFileNum++;
                        });

                        if (needUploadFileNum == 0) {
                            _submitFn(validationForm, callback, success, error);
                        } else {
                            _submitFileFn(validationForm, callback, success, error);
                        }
                    }                 
                } else {
                    //普通表单提交
                    _submitFn(validationForm, callback, success, error);
                }                
            }
        });


    }

    return {
        //main function to initiate the module
        init: function (formId,callbackFunction) {
            validationForm = $('#' + formId);
            callback = callbackFunction;
            handleValidation();         
        }
    };

}();

//保存表单数据
function saveForm(formId) {     
    $thisForm = $('#' + formId);
    //IMPORTANT: update CKEDITOR textarea with actual content before submit，否则文本编辑的的内容取不到值
    for (var instanceName in CKEDITOR.instances) {
      CKEDITOR.instances[instanceName].updateElement();
    }
    $thisForm.submit();
}
