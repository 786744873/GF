/**
***author:hety
***date:2015-08-17
***description:处理自定义编辑table
***/
(function ($) {
    $.fn.extend({
        tableEdit: function () {
            return this.each(function () {               
                var $table = $(this), $tbody = $table.find("tbody");
                var tableId = $table.attr('id');//table id
                var fields = [];

                $table.find("tr:first th[uitype]").each(function (i) {
                    var $th = $(this);
                    var field = {
                        type: $th.attr("uitype") || "129",
                        patternDate: $th.attr("dateFmt") || "yyyy-MM-dd",
                        name: $th.attr("name") || "",
                        defaultVal: $th.attr("defaultVal") || "",                       
                        htmlAttributes: $th.attr("htmlAttributes") || "",
                        htmlcontent: $th.attr("htmlcontent") || "",
                        jsoncontent: $th.attr("jsoncontent") || "",
                        refUi: $th.attr("refUi") || "",
                        refUrl: $th.attr("refUrl") || "",
                        lookupGroup: $th.attr("lookupGroup") || "",
                        lookupUrl: $th.attr("lookupUrl") || "",
                        lookupPk: $th.attr("lookupPk") || "id",
                        suggestUrl: $th.attr("suggestUrl"),
                        suggestFields: $th.attr("suggestFields"),
                        postField: $th.attr("postField") || "",
                        fieldClass: $th.attr("fieldClass") || "",
                        fieldAttrs: $th.attr("fieldAttrs") || ""
                    };
                    fields.push(field);
                });

                $tbody.find("a.tablelink").click(function () {
                    var $btnDel = $(this);

                    if ($btnDel.is("[href^=javascript:]")) {
                        $btnDel.parents("tr:first").remove();
                        initSuffix($tbody);
                        return false;
                    }

                    function delDbData() {
                        $.ajax({
                            type: 'POST', dataType: "json", url: $btnDel.attr('href'), cache: false,
                            success: function () {
                                $btnDel.parents("tr:first").remove();
                                initSuffix($tbody);
                            },
                            error: DWZ.ajaxError
                        });
                    }

                    if ($btnDel.attr("title")) {
                        alertMsg.confirm($btnDel.attr("title"), { okCall: delDbData });
                    } else {
                        delDbData();
                    }

                    return false;
                });
                
                var $addBut = $('#' + $table.attr("relationbutton"));
                if ($addBut) {
                    var trTm = "";
                    $addBut.click(function (event) {
                        event.preventDefault();

                        //扩展按钮动态追加业务(创建行之前)
                        if ($(this).attr('create_before_triggerevent')) {
                            var isSuccess = eval($(this).attr('create_before_triggerevent'));//动态执行js代码
                            if(!isSuccess)
                            {
                                return;
                            }
                        }

                        if (!trTm) trTm = trHtml(fields);
                        var rowNum = 1;

                        var $tr = $(trTm);
                        $tr.appendTo($tbody).find("a.tablelink").click(function () {
                            $(this).parents("tr:first").remove();
                            initSuffix($tbody);
                            return false;
                        });

                        //扩展按钮动态追加业务(创建行之后)
                        if ($(this).attr('create_after_triggerevent')) {
                            //  eval($(this).attr('create_after_triggerevent') + "($tr)");//动态执行js代码,并且把刚创建的Tr作为对象，传入回调函数中      
                            eval($(this).attr('create_after_triggerevent'));
                        }
                         
                        initSuffix($tbody);
                        ComponentsPickers.init(tableId);//新增时，日期控件初始化         
                    });
                }
            });

            /**
			 * 删除时重新初始化下标
			 */
            function initSuffix($tbody) {
                $tbody.find('>tr').each(function (i) {
                    $(':input, a.btnLook, a.btnAttach', this).each(function () {
                        var $this = $(this), relname = $this.attr('relname'), id = $this.attr('id'), relRefUi = $this.attr('relRefUi'), val = $this.val();

                        if (relname) $this.attr('name', relname.replace(/_index_/g, '_' + i + "_"));//替换name属性中的"_index_"为索引下标
                        if (id) $this.attr('id', relname.replace(/_index_/g, '_' + i + "_"));//如果存在Id的情况
                        if (relRefUi) $this.attr('refUi', relRefUi.replace(/_index_/g, '_' + i + "_"));//如果存在refUi的情况
                       
                    });
                });
            }

            function tdHtml(field) {
                var html = '', suffix = '_index_';

                var suffixFrag = suffix ? ' suffix="' + suffix + '" ' : '';

                var attrFrag = '';
                if (field.fieldAttrs) {
                    
                }

                var onlyRead = field.isOnlyRead == "0" ? "" : "readonly=readonly";
                switch (field.type) {
                    case 'del'://删除按钮
                        html = '<a href="javascript:;" class="tablelink"> 删除</a>';
                        break;
                    case 'hid'://影藏列表
                        html = '<input type="hidden" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" />';
                        return '<td class="hide">' + html + '</td>';
                    case 'lookup':
                        var suggestFrag = '';
                        if (field.suggestFields) {
                            suggestFrag = 'autocomplete="off" lookupGroup="' + field.lookupGroup + '"' + suffixFrag + ' suggestUrl="' + field.suggestUrl + '" suggestFields="' + field.suggestFields + '"' + ' postField="' + field.postField + '"';
                        }

                        html = '<input type="hidden" name="' + field.lookupGroup + '.' + field.lookupPk + suffix + '"/>'
							+ '<input type="text" name="' + field.name + '"' + suggestFrag + ' lookupPk="' + field.lookupPk + '" size="' + field.size + '" class="' + field.fieldClass + '"/>'
							+ '<a class="btnLook" href="' + field.lookupUrl + '" lookupGroup="' + field.lookupGroup + '" ' + suggestFrag + ' lookupPk="' + field.lookupPk + '" title="查找带回">查找带回</a>';
                        break;
                    case 'attach':
                        html = '<input type="hidden" name="' + field.lookupGroup + '.' + field.lookupPk + suffix + '"/>'
							+ '<input type="text" name="' + field.name + '" size="' + field.size + '" readonly="readonly" class="' + field.fieldClass + '"/>'
							+ '<a class="btnAttach" href="' + field.lookupUrl + '" lookupGroup="' + field.lookupGroup + '" ' + suggestFrag + ' lookupPk="' + field.lookupPk + '" width="560" height="300" title="查找带回">查找带回</a>';
                        break;
                    case 'enum':
                        $.ajax({
                            type: "POST", dataType: "html", async: false,
                            url: field.enumUrl,
                            data: { inputName: field.name },
                            success: function (response) {
                                html = response;
                            }
                        });
                        break;
                    case '131'://单选框
                        html = '<div class="itemtext">';
                        //html += '<input checked="checked" class="dfradio" name="formproperty_b55" type="radio" value="1"><span>是</span><input class="dfradio" name="formproperty_b55" type="radio" value="0"><span>否</span>';    
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '132'://复选框
                        html = '<div class="itemtext">';
                        //html += '<input name="formproperty_b6" type="checkbox" value=""><span>是</span>';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '133'://下拉框
                    case '682'://联动下拉框
                        html = '<div class="itemtext">';
                        //优先级：先json格式数据，后html格式数据
                        if (field.jsoncontent != '') {//采用json格式数据组装下拉框   
                            if (field.refUi == '') {
                                html += '<select id="' + field.name + '" name="' + field.name + '" relname="' + field.name + '" ' + field.htmlAttributes + '>';
                            } else {
                                html += '<select id="' + field.name + '" name="' + field.name + '" relname="' + field.name + '" ' + field.htmlAttributes + ' relRefUi="' + field.refUi + '" refUi="' + field.refUi + '" refUrl="' + field.refUrl + '" onchange="select_onchange_ref(this)">';
                            }                            
                            var dropData = eval("(" + field.jsoncontent + ")");
                            for (var dropIndex = 0; dropIndex < dropData.length; dropIndex++)
                            {                               
                                if (field.defaultVal == dropData[dropIndex].key) {
                                    //设置默认选中项目
                                    html += "<option selected=selected value=" + dropData[dropIndex].key + " >" + dropData[dropIndex].value + "</option>";
                                } else {
                                    html += "<option value=" + dropData[dropIndex].key + " >" + dropData[dropIndex].value + "</option>";
                                }
                            }
                            html += '</select>';
                        } else {//采用html格式数据组装下拉框
                            if (field.refUi == '') {
                                html += '<select id="' + field.name + '" name="' + field.name + '" relname="' + field.name + '" ' + field.htmlAttributes + '>' + field.htmlcontent + '</select>';
                            } else {
                                html += '<select id="' + field.name + '" name="' + field.name + '" relname="' + field.name + '" ' + field.htmlAttributes + ' relRefUi="' + field.refUi + '" refUi="' + field.refUi + '" refUrl="' + field.refUrl + '" onchange="select_onchange_ref(this)">' + field.htmlcontent + '</select>';
                            }                            
                        }
                        html += '<i></i>';
                        html += '</div>';                       
                        break;
                    case '134'://日期框                       
                        html = '<div class="itemtext">';
                        html += '<input name="' + field.name + '" relname="' + field.name + '" type="text" value="' + field.defaultVal + '" date="date" dateformat="' + field.patternDate + '" ' + field.htmlAttributes + ' />';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '135'://日期时间框
                        html = '<div class="itemtext">';
                        html += '<input name="' + field.name + '" relname="' + field.name + '" type="text" value="' + field.defaultVal + '" date="date" dateformat="yyyy-MM-dd HH:mm:ss" ' + field.htmlAttributes + ' />';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '130'://多行文本框
                        html = '<div class="itemtext">';
                        html += '<textarea name="' + field.name + '" relname="' + field.name + '" rows="2" cols="20"  ' + field.htmlAttributes + ' >' + field.defaultVal + '</textarea>';
                        html +='<i></i>';
                        html += '</div>';
                        break;
                    default://默认单行文本框
                        html = '<div class="itemtext">';
                        html += '<input name="' + field.name + '" relname="' + field.name + '" type="text" value="' + field.defaultVal + '" ' + field.htmlAttributes + ' />';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                }
                return '<td>' + html + '</td>';
            }
            function trHtml(fields) {
                var html = '';
                $(fields).each(function () {
                    html += tdHtml(this);
                });

                return '<tr>' + html + '</tr>';
            }
        }
    });

    //自定义编辑表单插件初始化
    //if ($.fn.tableEdit) $("table.tableedit").tableEdit();
    if ($.fn.tableEdit) {       
        $("table.tableedit").tableEdit();
    }
})(jQuery);

