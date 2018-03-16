/**
***author:hety
***date:2015-08-11
***description:处理自定义编辑table
***/
(function ($) {
    $.fn.extend({
        itemDetail: function () {
            return this.each(function () {
                var $table = $(this), $tbody = $table.find("tbody");
                var tableId = $table.attr('id');//table id
                var fields = [];
              
                $table.find("tr:first th[uitype]").each(function (i) {
                    var $th = $(this);
                    var field = {
                        type: $th.attr("uitype") || "129",
                        patternDate: $th.attr("dateFmt") || "yyyy-mm-dd",
                        id: $th.attr("id") || "",
                        name: $th.attr("name") || "",
                        defaultVal: $th.attr("defaultVal") || "",
                        size: $th.attr("size") || "12",
                        isOnlyRead: $th.attr("isOnlyRead") || "0",
                        isRequireValidate: $th.attr("isRequireValidate") || "0",
                        validateType: $th.attr("validateType") || "",
                        validateMessage: $th.attr("validateMessage") || "",
                        htmlcontent: $th.attr("htmlcontent") || "",
                        triggerEventType: $th.attr("triggerEventType") || "",
                        dynamicJs: $th.attr("dynamicJs") || "",
                        refUi: $th.attr("refUi") || "",
                        refUrl: $th.attr("refUrl") || "",
                        enumUrl: $th.attr("enumUrl") || "",
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

                $tbody.find("a.btn").click(function () {
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
                   // var $addBut = $('<div class="button"><div class="buttonContent"><button type="button">' + addButTxt + '</button></div></div>').insertBefore($table).find("button");
                    //var $rowNum = $('<input type="hidden" name="bd_rowNum" value="1" size="2"/>').insertBefore($table);
                    var trTm = "";
                    $addBut.click(function (event) {
                        event.preventDefault();
                       
                        if (!trTm) trTm = trHtml(fields);
                        var rowNum = 1;
                       // try { rowNum = parseInt($rowNum.val()) } catch (e) { }

                        //for (var i = 0; i < rowNum; i++) {
                            var $tr = $(trTm);
                            $tr.appendTo($tbody).find("a.btn").click(function () {
                                $(this).parents("tr:first").remove();
                                initSuffix($tbody);
                                return false;
                            });
                        //}
                        initSuffix($tbody);
                        ComponentsPickers.init();//新增时，日期控件初始化
                        resetValidate($tr);
                    });
                }
            });

            /**
			 * 删除时重新初始化下标
			 */
            function initSuffix($tbody) {
                $tbody.find('>tr').each(function (i) {
                    $(':input, a.btnLook, a.btnAttach', this).each(function () {
                        var $this = $(this), relname = $this.attr('relname'), relid = $this.attr('relid'), relRefUi = $this.attr('relRefUi'), val = $this.val();

                        if (relname) $this.attr('name', relname.replace(/_index_/g, '_' + i + "_"));//替换name属性中的"_index_"为索引下标
                        if (relid) $this.attr('id', relid.replace(/_index_/g, '_' + i + "_"));//如果存在Id的情况
                        if (relRefUi) $this.attr('refUi', relRefUi.replace(/_index_/g, '_' + i + "_"));//如果存在refUi的情况
                    });
                });
            }

            /**
             * 新增时，重置行元素验证
             */
            function resetValidate($tr) {
                $(':input, a.btnLook, a.btnAttach', $tr).each(function () {
                    var $this = $(this);
                    var validateType = $this.attr('validateType');
                    var validateMessage = $this.attr('validateMessage');
                    if (validateType) {                        
                        //$this.rules('add', {
                        //    required: true,
                        //    digits: true,
                        //    messages: {
                        //        required: '顺序不能为空', digits: '请输入有效顺序'
                        //    }
                        //});
                        var executejs = "$this.rules('add', {" + validateType + "messages: {" + validateMessage + "}});";                         
                        eval(executejs);//动态加入验证
                    }
                });
            }

            function tdHtml(field) {
                var html = '', suffix = '_index_';
               
               // if (field.name.endsWith("[#index#]")) suffix = "[#index#]";
                //else if (field.name.endsWith("[]")) suffix = "[]";

                var suffixFrag = suffix ? ' suffix="' + suffix + '" ' : '';

                var attrFrag = '';
                if (field.fieldAttrs) {
                    //var attrs = DWZ.jsonEval(field.fieldAttrs);
                    //for (var key in attrs) {
                    //    attrFrag += key + '="' + attrs[key] + '"';
                    //}
                }
               
                var onlyRead = field.isOnlyRead == "0" ? "" : "readonly=readonly";
                switch (field.type) {
                    case 'del'://删除按钮
                        html = '<a href="javascript:;" class="btn default btn-sm"><i class="fa fa-times"></i> 删除</a>';                              
                        break;
                    case 'hid'://影藏列表
                        html = '<input type="hidden" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" />';
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
                    case '133'://下拉框
                    case '682'://联动下拉框
                        if (onlyRead != '') {
                            onlyRead = 'disabled=disabled';
                        }

                        html = '<div class="form-group">';
                        html += '<div class="col-md-12">';
                        if (field.refUi == '') {
                            html += '<select id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" class="form-control" ' + onlyRead + '>';
                        } else {
                            html += '<select id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" class="form-control" ' + onlyRead + ' relRefUi="' + field.refUi + '" refUi="' + field.refUi + '" refUrl="' + field.refUrl + '" onchange="select_onchange_ref(this)">';
                        }                       
                        html += field.htmlcontent;
                        html += '</select>';                        
                        html += '</div>';
                        html += '</div>';
                        break;
                    case '134'://日期框                
                        if (field.isRequireValidate == '1') {
                            html='<div class="form-group">';
                            html+='<div class="col-md-12">';
                            html += '<div class="input-group input-medium date date-picker input-icon right" data-date-format="' + field.patternDate + '">';
                            html+='<i class="fa"></i>';
                            html += '<input type="text" class="form-control" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" maxlength="' + field.size + '" ' + onlyRead + ' validateType="' + field.validateType + '" validateMessage="' + field.validateMessage + '" />';
                            html+='<span class="input-group-btn">';
                            html+='<button class="btn default" type="button"><i class="fa fa-calendar"></i></button>';
                            html+='</span>';                            
                            html+='</div>';
                            html+='</div>';
                            html+='</div>';
                        } else {
                            html = '<div class="form-group">';
                            html += '<div class="col-md-12">';
                            html += '<div class="input-group input-medium date date-picker" data-date-format="' + field.patternDate + '">';
                            html += '<input type="text" class="form-control" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" maxlength="' + field.size + '" ' + onlyRead + ' />';
                            html += '<span class="input-group-btn">';
                            html += '<button class="btn default" type="button"><i class="fa fa-calendar"></i></button>';
                            html += '</span>';
                            html += '</div>';
                            html += '</div>';
                            html += '</div>';  
                        }
                        break;
                    case '578'://时间框
                        if (field.isRequireValidate == '1') {
                            html = '<div class="form-group">';
                            html += '<div class="col-md-12">';
                            html += '<div class="input-group input-medium  input-icon right">';
                            html += '<i class="fa"></i>';
                            html += '<input type="text" class="form-control timepicker" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" maxlength="' + field.size + '" ' + onlyRead + ' validateType="' + field.validateType + '" validateMessage="' + field.validateMessage + '" />';
                            html += '<span class="input-group-btn">';
                            html += '<button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>';
                            html += '</span>';                            
                            html += '</div>';
                            html += '</div>';
                            html += '</div>';
                        } else {
                            html = '<div class="form-group">';
                            html += '<div class="col-md-12">';
                            html += '<div class="input-group input-medium">';
                            html += '<input type="text" class="form-control timepicker" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" maxlength="' + field.size + '" ' + onlyRead + ' />';
                            html += '<span class="input-group-btn">';
                            html += '<button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>';
                            html += '</span>';
                            html += '</div>';
                            html += '</div>';
                            html += '</div>';                                 
                        }
                        break;
                    case '130'://多行文本框
                        if (field.isRequireValidate == '1') {
                            html = '<div class="form-group">';
                            html += '<div class="col-md-12">';
                            html += '<div class="input-icon right">';
                            html += '<i class="fa"></i>';
                            html += '<textarea class="form-control input-sm" cols="20" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" rows="2" maxlength="' + field.size + '" ' + onlyRead + ' validateType="' + field.validateType + '" validateMessage="' + field.validateMessage + '">' + field.defaultVal + '</textarea>';
                            html += '</div>';
                            html += '</div>';
                            html += '</div>';
                        } else {
                            html = '<div class="form-group">';
                            html += '<div class="col-md-12">';
                            html += '<textarea class="form-control input-sm" cols="20" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" rows="2" maxlength="' + field.size + '" ' + onlyRead + '>' + field.defaultVal + '</textarea>';
                            html += '</div>';
                            html += '</div>';
                        }
                        break;
                    default://默认单行文本框
                        //html = '<input type="text" name="' + field.name + '" value="' + field.defaultVal + '" size="' + field.size + '" class="' + field.fieldClass + '" ' + attrFrag + '/>';
                        if (field.isRequireValidate == '1') {
                            html = '<div class="form-group">';
                            html+='<div class="col-md-12">';
                            html+='<div class="input-icon right">';
                            html += '<i class="fa"></i>';
                            if (field.triggerEventType == "685") {//加入改变事件
                                html += '<input type="text" class="form-control" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" maxlength="' + field.size + '" ' + onlyRead + ' validateType="' + field.validateType + '" validateMessage="' + field.validateMessage + '" triggerEventType="' + field.triggerEventType + '" dynamicJs="' + field.dynamicJs + '" onchange="text_change(this)" />';
                            } else {
                                html += '<input type="text" class="form-control" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" maxlength="' + field.size + '" ' + onlyRead + ' validateType="' + field.validateType + '" validateMessage="' + field.validateMessage + '" />';
                            }
                          
                            html+='</div>';
                            html+='</div>';
                            html+='</div>';
                        } else {
                            html='<div class="form-group">';
                            html += '<div class="col-md-12">';
                            if (field.triggerEventType == "685") {//加入改变事件
                                html += '<input type="text" class="form-control" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" maxlength="' + field.size + '" ' + onlyRead + ' triggerEventType="' + field.triggerEventType + '" dynamicJs="' + field.dynamicJs + '" onchange="text_change(this)" />';
                            } else {
                                html += '<input type="text" class="form-control" id="' + field.id + '" relid="' + field.id + '" name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" maxlength="' + field.size + '" ' + onlyRead + ' />';
                            }                           
                            html+='</div>';                                          
                            html+='</div> ';                                                                                   
                        }
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
    if ($.fn.itemDetail) $("table.table").itemDetail();
})(jQuery);

