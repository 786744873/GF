/**
***author:hety
***date:2015-09-15
***description:处理自定义编辑页面(专指那种可以"新增元素"的编辑页面)
***/

(function ($) {
    $.fn.extend({
        formDvEdit: function () {
            return this.each(function () {
                var $formDv = $(this), $formdv_head = $formDv.find(".formdv_head"), $formdv_body = $formDv.find(".formdv_body");
                var formDvId = $formDv.attr('id');//form dv id
                var fields = [];

                $formdv_head.find("span[uitype]").each(function (i) {
                    var $th = $(this);
                    var field = {
                        type: $th.attr("uitype") || "129",
                        patternDate: $th.attr("dateFmt") || "yyyy-MM-dd",
                        id: $th.attr("id") || "",
                        name: $th.attr("name") || "",
                        showName: $th.attr("showName") || "",
                        defaultVal: $th.attr("defaultVal") || "",
                        htmlAttributes: $th.attr("htmlAttributes") || "",
                        htmlcontent: $th.attr("htmlcontent") || "",
                        jsoncontent: $th.attr("jsoncontent") || "",
                        refUi: $th.attr("refUi") || "",
                        refUrl: $th.attr("refUrl") || "",
                        lookupGroup: $th.attr("lookupGroup") || "",
                        lookupUrl: $th.attr("lookupUrl") || "",
                        lookupId: $th.attr("lookupId") || "",
                        lookupName: $th.attr("lookupName") || "",
                        suggestUrl: $th.attr("suggestUrl"),
                        suggestFields: $th.attr("suggestFields"),
                        postField: $th.attr("postField") || "",
                        fieldClass: $th.attr("fieldClass") || "",
                        fieldAttrs: $th.attr("fieldAttrs") || ""
                    };
                    fields.push(field);
                });

                $formdv_body.find("a.tablelink").click(function () {
                    var $btnDel = $(this);

                    if ($btnDel.is("[href^=javascript:]")) {
                        $btnDel.parents(".formdv_body_item").remove();
                        initSuffix($formdv_body);
                        return false;
                    }

                    function delDbData() {
                        $.ajax({
                            type: 'POST', dataType: "json", url: $btnDel.attr('href'), cache: false,
                            success: function () {
                                $btnDel.parents("tr:first").remove();
                                initSuffix($formdv_body);
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

                var $addBut = $('#' + $formDv.attr("relationbutton"));
                if ($addBut) {
                    var itemTm = "";
                    $addBut.click(function (event) {
                        event.preventDefault();

                        //扩展按钮动态追加业务(创建行之前)
                        if ($(this).attr('create_before_triggerevent')) {
                            var isSuccess = eval($(this).attr('create_before_triggerevent'));//动态执行js代码
                            if (!isSuccess) {
                                return;
                            }
                        } 

                        if (!itemTm) itemTm = itemHtml(fields);
                        var rowNum = 1;

                        var $itemTm = $(itemTm);
                       
                        $itemTm.appendTo($formdv_body).find("a.tablelink").click(function () {
                            $(this).parents(".formdv_body_item").remove();
                            initSuffix($formdv_body);
                            return false;
                        });

                        //扩展按钮动态追加业务(创建行之后)
                        if ($(this).attr('create_after_triggerevent')) {
                            //  eval($(this).attr('create_after_triggerevent') + "($itemTm)");//动态执行js代码,并且把刚创建的itemTm作为对象，传入回调函数中      
                            eval($(this).attr('create_after_triggerevent'));
                        }

                        initSuffix($formdv_body);
                        ComponentsPickers.init(formDvId);//新增时，日期控件初始化 
                        ComponentsSelectDialog.init($itemTm);//新增时，Select Dialog控件初始化 

                    });
                }
            });

            /**
			 * 删除时重新初始化下标
			 */
            function initSuffix($formdv_body) {
                $formdv_body.find('.formdv_body_item').each(function (i) {
                    $(':input, a.btnLook, a.btnAttach', this).each(function () {
                        var $this = $(this), relname = $this.attr('relname'), relid = $this.attr('relid'), relRefUi = $this.attr('relRefUi'), relswitchurl = $this.attr('relswitchurl'), val = $this.val();

                        if (relname) $this.attr('name', relname.replace(/_index_/g, '_' + i + "_"));//替换name属性中的"_index_"为索引下标
                        if (relid) $this.attr('id', relid.replace(/_index_/g, '_' + i + "_"));//如果存在Id的情况
                        if (relRefUi) $this.attr('refUi', relRefUi.replace(/_index_/g, '_' + i + "_"));//如果存在refUi的情况
                        if (relswitchurl) $this.attr('switchurl', relswitchurl.replace(/_index_/g, '_' + i + "_"));//如果存在refUi的情况

                    });
                });
            }

            function singleHtml(field) {
                var html = '', suffix = '_index_';

                var suffixFrag = suffix ? ' suffix="' + suffix + '" ' : '';

                var attrFrag = '';
                if (field.fieldAttrs) {

                }

                var onlyRead = field.isOnlyRead == "0" ? "" : "readonly=readonly";
                switch (field.type) {
                    case 'del'://删除按钮
                        html = '<div class="formdv_body_item_line"><a href="javascript:;" class="tablelink"> 删除</a></div>';
                        break;
                    case 'hid'://影藏列表
                        html = '<input type="hidden"  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" value="' + field.defaultVal + '" />';
                        return '<span class="hide">' + html + '</span>';
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
                        html = '<div class="mulitytext">';
                        html += '<label>' + field.showName + '</label>';
                        var radioData = eval("(" + field.jsoncontent + ")");
                        for (var radioIndex = 0; radioIndex < radioData.length; radioIndex++) {
                            if (field.defaultVal == radioData[radioIndex].key) {
                                //设置默认选中项目
                                html += '<input type="radio"  name="' + field.name + '" relname="' + field.name + '"  checked="checked" value="' + radioData[radioIndex].key + '" ><span>' + radioData[radioIndex].value + '</span>';
                            } else {
                                html += '<input type="radio"  name="' + field.name + '" relname="' + field.name + '"  value="' + radioData[radioIndex].key + '" ><span>' + radioData[radioIndex].value + '</span>';
                            }
                        }
    
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '132'://复选框
                        html = '<div class="mulitytext">';
                        html += '<label>' + field.showName + '</label>';
                        //html += '<input name="formproperty_b6" type="checkbox" value=""><span>是</span>';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '133'://下拉框
                    case '682'://联动下拉框
                        html = '<div class="mulitytext">';
                        html += '<label>' + field.showName + '</label>';
                        //优先级：先json格式数据，后html格式数据
                        if (field.jsoncontent != '') {//采用json格式数据组装下拉框   
                            if (field.refUi == '') {
                                html += '<select  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" ' + field.htmlAttributes + '>';
                            } else {
                                html += '<select  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" ' + field.htmlAttributes + ' relRefUi="' + field.refUi + '" refUi="' + field.refUi + '" refUrl="' + field.refUrl + '" onchange="select_onchange_ref(this)">';
                            }
                            var dropData = eval("(" + field.jsoncontent + ")");
                            for (var dropIndex = 0; dropIndex < dropData.length; dropIndex++) {
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
                                html += '<select  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" ' + field.htmlAttributes + '>' + field.htmlcontent + '</select>';
                            } else {
                                html += '<select  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" ' + field.htmlAttributes + ' relRefUi="' + field.refUi + '" refUi="' + field.refUi + '" refUrl="' + field.refUrl + '" onchange="select_onchange_ref(this)">' + field.htmlcontent + '</select>';
                            }
                        }
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '134'://日期框                       
                        html = '<div class="mulitytext">';
                        html += '<label>' + field.showName + '</label>';
                        html += '<input  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" type="text" value="' + field.defaultVal + '" date="date" dateformat="' + field.patternDate + '" ' + field.htmlAttributes + ' />';
                        html += '<i></i>';
                        html += '</div>';              
                        break;
                    case '135'://日期时间框
                        html = '<div class="mulitytext">';
                        html += '<label>' + field.showName + '</label>';
                        html += '<input  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" type="text" value="' + field.defaultVal + '" date="date" dateformat="yyyy-MM-dd HH:mm:ss" ' + field.htmlAttributes + ' />';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '130'://多行文本框
                        html = '<div class="mulitytextarealonger">';
                        html += '<label>' + field.showName + '</label>';
                        html += '<textarea  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" rows="2" cols="20"  ' + field.htmlAttributes + ' >' + field.defaultVal + '</textarea>';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    case '705'://不严谨单选弹出框
                        html = '<div class="mulitytext">';
                        html += '<label>' + field.showName + '</label>';
                        html += '<input type="hidden" lookupgroup="' + field.lookupGroup + '" id="' + field.lookupId + '" relid="' + field.lookupId + '"  name="' + field.lookupName + '" relname="' + field.lookupName + '" value="' + field.defaultVal + '" />';
                        html += '<input type="text" lookupgroup="' + field.lookupGroup + '" id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" title="' + field.showName + '" switchurl="' + field.lookupUrl + '" relswitchurl="' + field.lookupUrl + '" selectdialog="selectdialog" isdblclick="isdblclick" class="textselect" dialogheight="550" dialogwidth="1080"  value="' + field.defaultVal + '" ' + field.htmlAttributes + ' />';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                    default://默认单行文本框
                        html = '<div class="mulitytext">';
                        html += '<label>' + field.showName + '</label>';
                        html += '<input  id="' + field.id + '" relid="' + field.id + '"  name="' + field.name + '" relname="' + field.name + '" type="text" value="' + field.defaultVal + '" ' + field.htmlAttributes + ' />';
                        html += '<i></i>';
                        html += '</div>';
                        break;
                }
                return '' + html + '';
            }
            function itemHtml(fields) {
                var html = '';
                $(fields).each(function () {
                    html += singleHtml(this);
                });

                return '<div class="formdv_body_item">' + html + '</div>';
            }
        }
    });

    //自定义编辑表单插件初始化
    if ($.fn.formDvEdit) {
        $("div.formdvedit").formDvEdit();
    }
})(jQuery);

