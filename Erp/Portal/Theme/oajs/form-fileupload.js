var FormFileUpload = function () {
    var uploadForm;

    return {
        //main function to initiate the module
        init: function (formId) {

            uploadForm = $('#' + formId);
            // Initialize the jQuery File Upload widget:
            uploadForm.fileupload({
                disableImageResize: false,
                autoUpload: false,
                disableImageResize: /Android(?!.*Chrome)|Opera/.test(window.navigator.userAgent),
                maxFileSize: 5000000,
                acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i 
                // Uncomment the following to send cross-domain cookies:
                //xhrFields: {withCredentials: true},                
            }).bind('fileuploadstop', function (e, data)
            {//全部文件上传成功后，回调此方法
                if (formId == 'formFeedback')
                {//意见反馈页面，上传文件后的后续执行逻辑
                    window.location.href = "/feedback/feedback/List";
                }

            });

            // Enable iframe cross-domain access via redirect option:
            uploadForm.fileupload(
                'option',
                'redirect',
                window.location.href.replace(
                    /\/[^\/]*$/,
                    '/cors/result.html?%s'
                )
            );

            // Upload server status check for browsers with CORS support:
            //if ($.support.cors) {
            //    $.ajax({
            //        type: 'HEAD'
            //    }).fail(function () {
            //        $('<div class="alert alert-danger"/>')
            //            .text('Upload server currently unavailable - ' +
            //                    new Date())
            //            .appendTo('#formFeedback');
            //    });
            //}

            // Load & display existing files:
            uploadForm.addClass('fileupload-processing');
            $.ajax({
                // Uncomment the following to send cross-domain cookies:
                //xhrFields: {withCredentials: true},
                url: uploadForm.attr("action"),
                dataType: 'json',
                context: uploadForm[0]
            }).always(function () {
                $(this).removeClass('fileupload-processing');
            }).done(function (result) {               
                $(this).fileupload('option', 'done')
                .call(this, $.Event('done'), { result: result });
            });
        }

    };

}();