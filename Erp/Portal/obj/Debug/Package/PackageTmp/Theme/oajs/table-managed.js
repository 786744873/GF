//列表页data数据
var commonListData = { uniqueId: '', callbackjson: '', tableId: '', isSubmitExport: '0' }
//点击按钮，执行table查询(table id + search id)
function executeSearch(tableId, searchId) {
    commonListData.isSubmitExport = '0';//点击查询时，设置不可导出，主要是用来控制点击查询按钮后，查询逻辑和导出逻辑同时执行
    $('#' + searchId).find("input[type=hidden][name='isExecutedSearch']").val('1');//点击查询后，设置查询标识为1   
    $('#' + tableId).dataTable().fnDraw();//刷新列表
}
//点击按钮，执行导出(search id + exportForm id)
function executeExport(searchId, exportForm) {
    var $exportForm = $("#" + exportForm);//导出查询元素表单Id   
    commonListData.isSubmitExport = '1';
    $exportForm.submit();//提交导出
}
///是否允许提交导出(只有点击了"导出"按钮，才会执行导出逻辑)
function isAllowSubmitExport() {
    if (commonListData.isSubmitExport == '1')
        return true;
    else
        return false;
}

var TableManaged = function () {
    var table;
    var tableSearch;
    var defaultColumns = [];
    var submitUrl = '';
    var tableid;
    var initTable = function () {
        table.dataTable({
            // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
            // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
            // So when dropdowns used the scrollable div should be removed. 
            //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

            "bStateSave": false, // save datatable state(pagination, sort, etc) in cookie.
            "sAjaxSource": submitUrl, // "../server_side/scripts/server_processing.php"
            "fnServerParams": function (aoData) {
                $("input[type=text], input[type=hidden], select, textarea", tableSearch).each(function () {
                    aoData.push({ "name": $(this).attr('name'), "value": $(this).val() });
                });
                // aoData.push({ "name": $('#isExecutedSearch').attr('name'), "value": $('#isExecutedSearch').val() });
                // aoData.push({ "name": $('#s_title').attr('name'), "value": $('#s_title').val() }, { "name": $('#i_state').attr('name'), "value": $('#i_state').val() });
                // send a little bit of extra information to the server
            },
            "sServerMethod": "POST", // The default is 'GET            
            "bProcessing": true,
            "bServerSide": true,
            "ordering": false,//关闭表头排序总开关
            "bFilter": false, //关闭默认查询总开关
            "bLengthChange": false,
            //"lengthMenu": [
            //    [5, 10, 20, 30],
            //    [5, 10, 20, 30] // change per page values here
            //],
            // set the initial value
            "pageLength": 15,
            "pagingType": "bootstrap_full_number",
            "language": {
                "lengthMenu": "每页显示 _MENU_ 条记录",
                "info": "当前从记录 _START_ 到记录 _END_ /记录总数: _TOTAL_ ",
                "infoEmpty": "",
                "paginate": {
                    "previous": "上一页",
                    "next": "下一页",
                    "last": "末页",
                    "first": "首页"
                },
                "sProcessing": "数据加载中...",
                "search": "查询:",
                "emptyTable": "无记录结果！"
            },
            "aoColumns": defaultColumns,
            "aoColumnDefs": [
                //       { "bSearchable": false, "bVisible": false, "aTargets": [0] }
            ],
            "fnCreatedRow": function (nRow, aData, iDataIndex) {//tr上设置一自定义属性
                $(nRow).attr('rel', aData[0]);
                if (tableid == 'emailList') {//邮件标题添加超链接
                    var num = $(nRow).children('td').eq(0).children('a').attr('eType');
                    if (num == 1 || num == 2)
                        $(nRow).children('td').eq(0).children('a').attr('href', '/oa/email/Details?emailCode=' + aData[0] + '&type=' + num + '');
                    else
                        $(nRow).children('td').eq(0).children('a').attr('href', '/oa/email/edit?emailCode=' + aData[0] + '&type=' + num + '');
                }
                else if (tableid == 'articleList') {//文章标题添加超链接  
                    $(nRow).children('td').eq(0).children('a').attr('href', '/oa/article/edit?articleCode=' + aData[0] + '');
                }
                else if (tableid == 'myarticleList') {//我的文章标题添加超链接  
                    $(nRow).children('td').eq(0).children('a').attr('href', '/oa/myarticle/Details?articleCode=' + aData[0] + '');
                }
                else if (tableid == 'messageList') {//消息列表添加超链接  
                    $(nRow).children('td').eq(0).children('a').attr('href', '/oa/message/Details?scheduleCode=' + aData[0] + '');
                }
                else if (tableid == 'flowList') {//流程列表添加超链接  
                    $(nRow).children('td').eq(0).children('a').attr('href', '/oa/flow/edit?flowCode=' + aData[0] + '');
                }
                else if (tableid == 'formList' || tableid == 'myTaskList') {//表单列表添加超链接  
                    $(nRow).children('td').eq(0).children('a').attr('href', '/oa/form/layoutroottabs?oFormCode=' + aData[0] + '');
                }
                else if (tableid == 'flowSetList') {//流程预设列表添加超链接  
                    $(nRow).children('td').eq(0).children('a').attr('href', '/oa/flowset/edit?flowSetCode=' + aData[0] + '');
                }
                else if (tableid == 'reimList') {//报销单
                    $(nRow).children('td').eq(1).children('a').attr('href', '/oa/form/layoutroottabs?oFormCode=' + aData[0] + '');
                }
                else if (tableid == 'loanList') {//借款单
                    $(nRow).children('td').eq(1).children('a').attr('href', '/oa/form/layoutroottabs?oFormCode=' + aData[0] + '');
                }
                else if (tableid == 'feedbackList') {//意见反馈
                    $(nRow).children('td').eq(1).children('a').attr('href', '/feedback/feedback/Detial?feedbackCode=' + aData[0] + '');
                }
                else if (tableid == 'knowledgeList') {//知识分类
                    $(nRow).children('td').eq(0).children('a').attr('href', '/kms/knowledge/Edit?knowledgeCode=' + aData[0] + '');
                }
                else if (tableid == 'problemList') {//问吧
                    $(nRow).children('td').eq(1).children('a').attr('href', '/kms/Problem/AnswerProblem?problemCode=' + aData[0] + '');
                }
                else if (tableid == 'problemCommentList') {//问吧管理
                    $(nRow).children('td').eq(1).children('a').attr('href', '/kms/Problem/AnswerProblem?problemCode=' + aData[0] + '');
                }
                else if (tableid == 'PromblemMorelist') {//更多问题
                    if (aData[7] == "" || aData[7] == null) {
                        $("#search").html('<h5>搜索结果，共<span id="searchTotal">' + aData[6] + '</span>条</h5>');
                    }
                    else {
                        $("#search").html('<h5>搜索关键字“<code id="keyWord">' + aData[7] + '</code>”的结果，共<span id="searchTotal">' + aData[6] + '</span>条</h5>');
                    }
                    $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Problem/AnswerProblem?problemCode=' + aData[0] + '');
                }
                else if (tableid == 'resourcesList') {//资源维护
                    var type = aData[1];
                    if (type == 827) {
                        $(nRow).children('td').eq(1).children('a').attr('href', '/kms/avi/Details?id=' + aData[3] + '');//视频
                    } else {
                        $(nRow).children('td').eq(1).children('a').attr('href', '/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[1] + '');//文档
                    }
                    var strHtml = "";
                    var Permissions = aData[9];//下载权限
                    if (type != 827) {
                        if (Permissions == "True") {
                            strHtml += '<span class="glyphicon glyphicon-ok"></span>';
                        }
                        else {
                            strHtml += '<span class="glyphicon glyphicon-remove"></span>';
                        }
                    } else {
                        strHtml += '<span class="glyphicon glyphicon-ban-circle"></span>';
                    }
                    $(nRow).children('td').eq(7).html(strHtml);
                }
                else if (tableid == 'myCollectionList') {//我的收藏
                    var type = aData[1];
                    if (type == 827) {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/avi/Details?id=' + aData[2] + '');//视频
                    } else {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[1] + '');//文档
                    }
                }
                else if (tableid == 'myBrowseList') {//我的浏览记录
                    var type = aData[2];
                    if (type == 827) {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/avi/Details?id=' + aData[3] + '');//视频
                    } else {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[2] + '');//文档
                    }
                }
                else if (tableid == 'MyPromblemList') {//我的问题
                    $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Problem/AnswerProblem?problemCode=' + aData[0] + '');
                }
                else if (tableid == 'myDocumentList') {//我的资料
                    var type = aData[1];
                    if (type == 827) {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/avi/Details?id=' + aData[2] + '');//视频
                    } else {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[1] + '');//文档
                    }
                }
                else if (tableid == 'commentsList') {//我的评论  type为空的即为问吧回答
                    var type = aData[1];
                    var comType = aData[4];
                    if (comType == 875 && type == 827) {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/avi/Details?id=' + aData[2] + '');//视频
                    } else if (comType == 875) {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Resources/SelectResources?resourceCode=' + aData[3] + '&type=' + aData[1] + '');//文档
                    }
                    else {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/problem/AnswerProblem?problemCode=' + aData[3] + '');//问题
                    }

                    var commentContent = aData[8];
                    var start_ptn = /<[^>]*>/g;      //过滤标签   
                    var space_ptn = /&nbsp;/ig;          //过滤标签结尾
                    var contenttext = $.trim(commentContent.replace(start_ptn, "").replace(space_ptn, ""));   //c为富文本 
                    if (contenttext.length > 15) {
                        $(nRow).children('td').eq(3).text(contenttext.substring(0, 15) + "...");
                    } else {
                        $(nRow).children('td').eq(3).text(contenttext);
                    }
                }
                else if (tableid == 'MyShareDocumentslist') {//我的分享
                    var type = aData[1];
                    if (type == 827) {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/avi/Details?id=' + aData[2] + '');//视频
                    } else {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[1] + '');//文档
                    }
                    var state = aData[8];
                    var btnGroup = '';
                    if (state == 832) {//只有未审核的资源可以编辑
                        if (type != 827) {//827视频不支持编辑       
                            if (type == 829)//文章编辑
                                btnGroup += '<a href="/kms/article/create?resourceesCode=' + aData[0] + '&type=2&reflash=myshare1" class="btn btn-xs purple"><i class="fa fa-edit"></i> 编辑 </a>';
                            else
                                btnGroup += '<a href="/kms/resources/Upload?resourceesCode=' + aData[0] + '&type=2&reflash=myshare1" class="btn btn-xs purple"><i class="fa fa-edit"></i> 编辑 </a>';

                            btnGroup += '<a onclick="deleteResource(\'' + aData[0] + '\',\'1\')" class="btn btn-xs grey-cascade"><i class="fa fa-trash-o"></i> 删除 </a>';
                        } else {
                            btnGroup += '<a onclick="deleteResource(\'' + aData[0] + '\',\'1\')" class="btn btn-xs grey-cascade"><i class="fa fa-trash-o"></i> 删除 </a>';
                        }
                    } else {
                        btnGroup += '<a onclick="deleteResource(\'' + aData[0] + '\',\'1\')" class="btn btn-xs grey-cascade"><i class="fa fa-trash-o"></i> 删除 </a>';
                    }
                    $(nRow).children('td').eq(5).html(btnGroup);
                }
                else if (tableid == 'KnowledgeAuditlist') {//知识审核
                    var type = aData[1];
                    if (type == 827) {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/avi/Details?id=' + aData[2] + '');//视频
                    } else {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[1] + '');//文档
                    }
                    var state = aData[10];
                    var strHtml = '';
                    var Permissions = aData[7];//下载权限
                    if (type == 827) {
                        strHtml += '<span class="glyphicon glyphicon-ban-circle"></span>';
                    } else {
                        if (Permissions == "True") {
                            strHtml += '<span class="glyphicon glyphicon-ok"></span>';
                        }
                        else {
                            strHtml += '<span class="glyphicon glyphicon-remove"></span>';
                        }
                    }
                    $(nRow).children('td').eq(4).html(strHtml);

                    var btnGroup = '';
                    btnGroup += '<div class="btn-group">';
                    btnGroup += '<button type="button" class="btn btn-xs purple dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="false">';
                    btnGroup += '审核 <i class="fa fa-angle-down"></i>';
                    btnGroup += '</button>';
                    btnGroup += '<ul class="dropdown-menu" style="min-width:0px;">';
                    btnGroup += '<li><a onclick="auditResource(\'' + aData[0] + '\',\'834\')">通过</a></li>';
                    btnGroup += '<li><a onclick="auditResource(\'' + aData[0] + '\',\'833\')">不通过</a></li>';
                    btnGroup += '</ul>';
                    btnGroup += '</div>';
                    btnGroup += '<div class="btn-group">';

                    if (type == 827) {
                        btnGroup += '<button disabled="disabled" type="button" class="btn btn-xs purple dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="false">';
                    } else {
                        btnGroup += '<button type="button" class="btn btn-xs purple dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="false">';
                    }
                    btnGroup += '下载 <i class="fa fa-angle-down"></i>';
                    btnGroup += '</button>';
                    btnGroup += '<ul class="dropdown-menu" style="min-width:0px;">';
                    btnGroup += '<li><a onclick="downLoadResource(\'' + aData[0] + '\',\'1\')">允许</a></li>';
                    btnGroup += '<li><a onclick="downLoadResource(\'' + aData[0] + '\',\'0\')">不允许</a></li>';
                    btnGroup += '</ul>';
                    btnGroup += '</div>';

                    $(nRow).children('td').eq(7).html(btnGroup);
                }
                else if (tableid == 'KnowledgeMaintenance') {//知识维护
                    var type = aData[1];
                    if (type == 827) {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/avi/Details?id=' + aData[2] + '');//视频
                    } else {
                        $(nRow).children('td').eq(0).children('a').attr('href', '/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[1] + '');//文档
                    }
                    var state = aData[10];
                    var btnGroup = '';
                    if (type != 827) {//827视频不支持编辑       
                        if (type == 829)//文章编辑
                            btnGroup += '<a href="/kms/article/create?resourceesCode=' + aData[0] + '&type=3&reflash=myshare3" class="btn btn-xs purple"><i class="fa fa-edit"></i> 编辑 </a>';
                        else
                            btnGroup += '<a href="/kms/resources/Upload?resourceesCode=' + aData[0] + '&type=3&reflash=myshare3" class="btn btn-xs purple"><i class="fa fa-edit"></i> 编辑 </a>';
                    }
                    else {
                        btnGroup += '<a disabled="disabled" class="btn btn-xs purple"><i class="fa fa-edit"></i> 编辑 </a>';
                    }
                    //btnGroup += '<a href="/kms/article/create?resourceesCode=' + aData[0] + '&type=2&reflash=myshare3" class="btn btn-xs purple"><i class="fa fa-edit"></i> 编辑 </a>';
                    btnGroup += '<a onclick="deleteResource(\'' + aData[0] + '\',\'2\')" class="btn btn-xs grey-cascade"><i class="fa fa-trash-o"></i> 删除 </a>';
                    $(nRow).children('td').eq(7).html(btnGroup);
                }
                else if (tableid == 'searchresourcesList')//资源搜索结果界面
                {
                    //$("#searchTotal").text(aData[10]);//搜索关键字总数
                    if (aData[11] == "") {
                        $("#search").html('<h5>搜索结果，共<span id="searchTotal">' + aData[10] + '</span>条</h5>');
                    }
                    else {
                        $("#search").html('<h5>搜索关键字“<code id="keyWord">' + aData[11] + '</code>”的结果，共<span id="searchTotal">' + aData[10] + '</span>条</h5>');
                    }
                    //封装页面html
                    var htmlRs = '';
                    htmlRs += '<div class="row booking-results col-md-12">';
                    htmlRs += '<div class="col-md-12">';
                    htmlRs += '<div class="booking-result">';
                    htmlRs += '<div class="booking-img" style="width:auto;">';
                    if (aData[3] == 827)
                        htmlRs += '<a href="/kms/avi/Details?id=' + aData[4] + '"><img src=' + aData[1] + ' style="width:173px; height:130px" alt=""></a>';
                    else
                        htmlRs += '<a href="/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[3] + '"><img src=' + aData[1] + ' style="width:173px; height:130px" alt=""></a>';
                    //htmlRs += '<img src=' + aData[1] + ' style="width:173px; height:130px" alt="">';
                    htmlRs += '</div>';
                    htmlRs += '<div class="booking-info">';
                    htmlRs += '<h5>';
                    if (aData[3] == 827)
                        htmlRs += '<a href="/kms/avi/Details?id=' + aData[4] + '">' + aData[9] + '</a>';
                    else
                        htmlRs += '<a href="/kms/Resources/SelectResources?resourceCode=' + aData[0] + '&type=' + aData[3] + '">' + aData[9] + '</a>';
                    htmlRs += '</h5>';
                    htmlRs += '<div style="line-height:35px;">';
                    htmlRs += '<p>';
                    var strcontent = '';
                    var start_ptn = /<[^>]*>/g;
                    var space_ptn = /&nbsp;/ig;
                    //var reg = /s/g;
                    var contenttext = $.trim(aData[2].replace(start_ptn, "").replace(space_ptn, ""));
                    if (contenttext.length > 100)
                        strcontent = contenttext.substring(0, 100) + ". . .";
                    else
                        strcontent = contenttext;
                    htmlRs += '' + strcontent + '';
                    htmlRs += '</p></div>';
                    htmlRs += '<ul class="list-inline blog-tags">';
                    htmlRs += '<li >' + aData[5] + '</li>';
                    htmlRs += '<li style="margin-left:15px;">赞(' + aData[6] + ')</li>';
                    htmlRs += '<li style="margin-left:15px;">浏览(' + aData[7] + ')</li>';
                    htmlRs += '<li style="margin-left:15px;">发布于  ' + aData[8] + '</li>';
                    htmlRs += '</ul>';
                    htmlRs += '</div>';
                    htmlRs += '</div>';
                    htmlRs += '</div>';
                    htmlRs += '</div>';

                    $(nRow).children('td').eq(0).html(htmlRs);
                }
                else if (tableid == 'commentsManagerList')//评论管理
                {
                    var commentContent = aData[3];
                    var commentParent = aData[5];
                    var start_ptn = /<[^>]*>/g;      //过滤标签   
                    var space_ptn = /&nbsp;/ig;          //过滤标签结尾
                    var contenttext = $.trim(commentContent.replace(start_ptn, "").replace(space_ptn, ""));   //c为富文本 
                    var parentContent = null;
                    if (commentParent != null) {
                        parentContent = $.trim(commentParent.replace(start_ptn, "").replace(space_ptn, ""));   //c为富文本
                    }
                    if (contenttext.length > 16) {
                        $(nRow).children('td').eq(1).text(contenttext.substring(0, 16) + "...");
                    } else {
                        $(nRow).children('td').eq(1).text(contenttext);
                    }
                    if (parentContent != null) {
                        if (parentContent.length > 16) {
                            $(nRow).children('td').eq(3).text(parentContent.substring(0, 16) + "...");
                        } else {
                            $(nRow).children('td').eq(3).text(parentContent);
                        }
                    }
                }
                else if (tableid == 'ProcessReportingList')//进程管理报表统计
                {
                    var type = aData[0];
                    var opreatStr = '';
                    if (type == 1) {
                        opreatStr += '<a style="color:blue;" class="ajaxify" href="/Reporting/ProcessReporting/ProcessReportingDetails?ProcessReportingStr=' + aData + '">详情</a>';
                        $(nRow).children('td').eq(9).html(opreatStr);
                    } else {
                        opreatStr += '<a style="color:blue;" class="ajaxify" href="/Reporting/ProcessReporting/ProcessReportingDetails?ProcessReportingStr=' + aData + '">详情</a>';
                        $(nRow).children('td').eq(10).html(opreatStr);
                    }
                }
                else if (tableid == 'typicalCaseList')//典型案例列表
                {
                    $(nRow).children('td').eq(1).children('a').attr('href', '/typicalcase/typicalcase/details?typicalCode=' + aData[0] + '');
                }
                else if (tableid == 'ProcessReportingDetailsList')//进程管理报表统计详细
                {
                    //计算标准时长
                    var Entry_Duration = aData[3];
                    if (Entry_Duration >= 24) {
                        var hours = Entry_Duration;
                        var aHours = hours % 24;
                        var aDay = (hours - aHours) / 24;
                        var hourStr = "";
                        if (aHours != 0)
                            hourStr = aHours + "小时";
                        var a = aDay + "天" + hourStr;
                        $(nRow).children('td').eq(3).text(a);
                    } else {
                        var a = Entry_Duration + "小时";
                        $(nRow).children('td').eq(3).text(a);
                    }
                    //计算变更时长
                    var changeDuration = aData[4];
                    if (changeDuration == null) {
                        $(nRow).children('td').eq(4).text('未变更');
                    } else {
                        if (changeDuration >= 24) {
                            var hours = changeDuration;
                            var aHours = hours % 24;
                            var aDay = (hours - aHours) / 24;
                            var hourStr = "";
                            if (aHours != 0)
                                hourStr = aHours + "小时";
                            var a = aDay + "天" + hourStr;
                            $(nRow).children('td').eq(4).text(a);
                        } else {
                            var a = "";
                            if (changeDuration == null || changeDuration == 0)
                                a = "0小时";
                            else
                                a = changeDuration + "小时";
                            $(nRow).children('td').eq(4).text(a);
                        }
                    }
                    //办案状态
                    var HandlingState = aData[7];
                    if (HandlingState == null) {
                        $(nRow).children('td').eq(7).text('');
                    } else {
                        var handlingStateStr = '';
                        if (HandlingState == "未开始") {
                            handlingStateStr = '<p style="color: black;">' + HandlingState + '</p>';
                            $(nRow).children('td').eq(7).html(handlingStateStr);
                        }
                        if (HandlingState == "已超时") {
                            handlingStateStr = '<p style="color: red;">' + HandlingState + '</p>';
                            $(nRow).children('td').eq(7).html(handlingStateStr);
                        }
                        if (HandlingState == "正进行") {
                            handlingStateStr = '<p style="color: green;">' + HandlingState + '</p>';
                            $(nRow).children('td').eq(7).html(handlingStateStr);
                        }
                        if (HandlingState == "已结束") {
                            handlingStateStr = '<p style="color: black;">' + HandlingState + '</p>';
                            $(nRow).children('td').eq(7).html(handlingStateStr);
                        }
                        if (HandlingState == "提前完成") {
                            handlingStateStr = '<p style="color: #0094ff;">' + HandlingState + '</p>';
                            $(nRow).children('td').eq(7).html(handlingStateStr);
                        }
                        if (HandlingState == "超时完成") {
                            handlingStateStr = '<p style="color: orange;">' + HandlingState + '</p>';
                            $(nRow).children('td').eq(7).html(handlingStateStr);
                        }
                        if (HandlingState == "已作废") {
                            handlingStateStr = '<p style="color: orange;">' + HandlingState + '</p>';
                            $(nRow).children('td').eq(7).html(handlingStateStr);
                        }
                    }
                    //办理情况
                    var Management = aData[8];
                    if (Management != null) {
                        var a = Management;
                        var aHours = a % 24;
                        var aDay = (a - aHours) / 24;
                        var hourStr = "";
                        if (aHours != 0 && aHours > 0)
                            hourStr = aHours + "小时";
                        else if (aHours < 0)
                            hourStr = aHours * -1 + "小时";

                        if (aDay != 0 && aDay > 0) {
                            var s = aDay + "天" + hourStr;
                            $(nRow).children('td').eq(8).text(s);
                        }
                        else {
                            var s = "";
                            if (aDay < 0)
                                s = aDay + "天" + hourStr;
                            else
                                s = "-" + hourStr;
                            $(nRow).children('td').eq(8).text(s);
                        }
                    } else {
                        $(nRow).children('td').eq(8).text(Management);
                    }
                    //预警时长
                    var warningDuration = aData[11];
                    if (warningDuration >= 24) {
                        var hours = warningDuration;
                        var aHours = hours % 24;
                        var aDay = (hours - aHours) / 24;
                        var hourStr = "";
                        if (aHours != 0)
                            hourStr = aHours + "小时";
                        var a = aDay + "天" + hourStr;
                        $(nRow).children('td').eq(11).text(a);
                    } else {
                        var a = warningDuration + "小时";
                        $(nRow).children('td').eq(11).text(a);
                    }
                }
            },
            "fnDrawCallback": function () {
                commonListData.uniqueId = '';//重新设置当前行标识为空
            }
        });
        table.find('tbody').on('click', 'tr', function () {
            if (tableid != 'searchresourcesList') {//知识查询结果界面不用增加选择效果   cyj
                if ($(this).hasClass('active')) {
                    $(this).removeClass('active');
                    commonListData.uniqueId = '';
                    //如果存在操作checkbox，则自动取消选中
                    $checkbox = $(this).find('input[type=checkbox][operate=operate]');
                    if ($checkbox) {
                        $($checkbox).attr("checked", false);
                    }
                }
                else {
                    table.find('tr.active').removeClass('active');
                    $(this).addClass('active');
                    commonListData.uniqueId = $(this).attr('rel');
                    //如果存在操作checkbox，则自动选中
                    $checkbox = $(this).find('input[type=checkbox][operate=operate]');
                    if ($checkbox) {
                        $($checkbox).attr("checked", true);
                    }
                }
            }
        });


        table.find('.group-checkable').change(function () {
            var set = jQuery(this).attr("data-set");
            var checked = jQuery(this).is(":checked");
            jQuery(set).each(function () {
                if (checked) {
                    $(this).attr("checked", true);
                } else {
                    $(this).attr("checked", false);
                }
            });
        });

    }

    return {
        //main function to initiate the module
        init: function (_tableId, _tableSearch, _defaultColumns, _submitUrl) {
            if (!jQuery().dataTable) {
                return;
            }
            tableid = _tableId;
            table = $('#' + _tableId);
            tableSearch = $('#' + _tableSearch);

            defaultColumns = _defaultColumns;
            submitUrl = _submitUrl;

            commonListData.tableId = _tableId;
            //table = $.extend(table, commonListData);
            initTable();
        },
        getTableRowId: function (_tableId) {
            table = $('#' + _tableId);
            alert(table.uniqueId);
        }
    };

}();

var TableEditable = function () {
    var table;
    var tableSearch;
    var defaultColumns = [];
    var submitUrl = '';

    var handleTable = function () {

        var oTable = table.dataTable({
            "bStateSave": false, // save datatable state(pagination, sort, etc) in cookie.
            "sAjaxSource": submitUrl, // "../server_side/scripts/server_processing.php"
            "fnServerParams": function (aoData) {
                $("input[type=text], input[type=hidden], select, textarea", tableSearch).each(function () {
                    aoData.push({ "name": $(this).attr('name'), "value": $(this).val() });
                });
                // aoData.push({ "name": $('#isExecutedSearch').attr('name'), "value": $('#isExecutedSearch').val() });
                // aoData.push({ "name": $('#s_title').attr('name'), "value": $('#s_title').val() }, { "name": $('#i_state').attr('name'), "value": $('#i_state').val() });
                // send a little bit of extra information to the server
            },
            "sServerMethod": "POST", // The default is 'GET            
            "bProcessing": true,
            "bServerSide": true,
            "bPaginate": false,
            "ordering": false,//关闭表头排序总开关
            "bFilter": false, //关闭默认查询总开关
            "lengthMenu": [
                [5, 10, 20, 30],
                [5, 10, 20, 30] // change per page values here
            ],
            // set the initial value
            "pageLength": 20,
            "pagingType": "bootstrap_full_number",
            "language": {
                "lengthMenu": "每页显示 _MENU_ 条记录",
                "info": "当前从记录 _START_ 到记录 _END_ /记录总数: _TOTAL_ ",
                "paginate": {
                    "previous": "上一页",
                    "next": "下一页",
                    "last": "末页",
                    "first": "首页"
                },
                "sProcessing": "数据加载中...",
                "search": "查询:",
                "emptyTable": "无记录结果！"
            },
            "aoColumns": defaultColumns,
            "aoColumnDefs": [
                             {
                                 "targets": [7],
                                 "render": function (data, type, full) {
                                     return "<a href='javascript:;' class='edit'>编辑</a>";
                                 },
                             },
                             {
                                 "targets": [8],
                                 "render": function (data, type, full) {
                                     return "<a href='javascript:;' class='delete'>删除</a>";
                                 },
                             }
            ],
            "fnCreatedRow": function (nRow, aData, iDataIndex) {//tr上设置一自定义属性

            },
            "fnDrawCallback": function () {

            }
        });

        function restoreRow(oTable, nRow) {
            var aData = oTable.fnGetData(nRow);
            var jqTds = $('>td', nRow);

            for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                oTable.fnUpdate(aData[i], nRow, i, false);
            }

            oTable.fnDraw();
        }

        function editRow(oTable, nRow) {
            editCustomerRow(oTable, nRow);
            //var aData = oTable.fnGetData(nRow);
            //var jqTds = $('>td', nRow);
            //jqTds[0].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[3] + '">';
            //jqTds[1].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[4] + '">';
            //jqTds[2].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[5] + '">';
            //jqTds[3].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[6] + '">';
            //jqTds[4].innerHTML = '<a class="edit" href="">保存</a>';
            //jqTds[5].innerHTML = '<a class="cancel" href="">取消</a>';
        }

        function saveRow(oTable, nRow) {
            saveCustomerRow(oTable, nRow);
            //var jqInputs = $('input', nRow);
            //oTable.fnUpdate(jqInputs[0].value, nRow, 3, false);
            //oTable.fnUpdate(jqInputs[1].value, nRow, 4, false);
            //oTable.fnUpdate(jqInputs[2].value, nRow, 5, false);
            //oTable.fnUpdate(jqInputs[3].value, nRow, 6, false);
            //oTable.fnUpdate('<a class="edit" href="">编辑</a>', nRow, 7, false);
            //oTable.fnUpdate('<a class="delete" href="">删除</a>', nRow, 8, false);
            //oTable.fnDraw();
        }

        function cancelEditRow(oTable, nRow) {
            cancelCustomerEditRow(oTable, nRow);
            //var jqInputs = $('input', nRow);
            //oTable.fnUpdate(jqInputs[0].value, nRow, 3, false);
            //oTable.fnUpdate(jqInputs[1].value, nRow, 4, false);
            //oTable.fnUpdate(jqInputs[2].value, nRow, 5, false);
            //oTable.fnUpdate(jqInputs[3].value, nRow, 6, false);
            //oTable.fnUpdate('<a class="edit" href="">编辑</a>', nRow, 7, false);
            //oTable.fnDraw();
        }

        //var tableWrapper = $("#sample_editable_1_wrapper");

        //tableWrapper.find(".dataTables_length select").select2({
        //    showSearchInput: true //hide search box with special css class
        //}); // initialize select2 dropdown

        var nEditing = null;
        var nNew = false;

        $('#addNewCustomerRow').click(function (e) {
            e.preventDefault();

            if (nNew && nEditing) {
                if (confirm("Previose row not saved. Do you want to save it ?")) {
                    saveRow(oTable, nEditing); // save
                    $(nEditing).find("td:first").html("Untitled");
                    nEditing = null;
                    nNew = false;

                } else {
                    oTable.fnDeleteRow(nEditing); // cancel
                    nEditing = null;
                    nNew = false;

                    return;
                }
            }

            var aiNew = oTable.fnAddData(['', '', '', '', '', '', '', '', '']);
            var nRow = oTable.fnGetNodes(aiNew[0]);
            editRow(oTable, nRow);
            nEditing = nRow;
            nNew = true;
        });

        table.on('click', '.delete', function (e) {
            e.preventDefault();

            if (confirm("Are you sure to delete this row ?") == false) {
                return;
            }

            var nRow = $(this).parents('tr')[0];
            oTable.fnDeleteRow(nRow);
            alert("Deleted! Do not forget to do some ajax to sync with backend :)");
        });

        table.on('click', '.cancel', function (e) {
            e.preventDefault();
            if (nNew) {
                oTable.fnDeleteRow(nEditing);
                nEditing = null;
                nNew = false;
            } else {
                restoreRow(oTable, nEditing);
                nEditing = null;
            }
        });

        table.on('click', '.edit', function (e) {
            e.preventDefault();

            /* Get the row as a parent of the link that was clicked on */
            var nRow = $(this).parents('tr')[0];

            if (nEditing !== null && nEditing != nRow) {
                /* Currently editing - but not this row - restore the old before continuing to edit mode */
                restoreRow(oTable, nEditing);
                editRow(oTable, nRow);
                nEditing = nRow;
            } else if (nEditing == nRow && this.innerHTML == "保存") {
                /* Editing this row and want to save it */
                saveRow(oTable, nEditing);
                nEditing = null;
                alert("Updated! Do not forget to do some ajax to sync with backend :)");
            } else {
                /* No edit in progress - let's start one */
                editRow(oTable, nRow);
                nEditing = nRow;
            }
        });
    }

    return {
        //main function to initiate the module
        init: function (_tableId, _tableSearch, _defaultColumns, _submitUrl) {
            commonListData.tableId = _tableId;
            table = $('#' + _tableId);
            tableSearch = $('#' + _tableSearch);

            defaultColumns = _defaultColumns;
            submitUrl = _submitUrl;
            handleTable();
        }

    };

}();