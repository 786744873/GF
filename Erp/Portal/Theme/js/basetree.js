/****
**** author: hety
**** date: 2015-05-19
**** description: 树形结构业务扩展
***/

//Tree Data 数据
var commonTreeData = { uniqueId: '', callbackjson: '', level: '' };

$(function () {
    $(".tree").jstree();
    $('.tree').on("changed.jstree", function (e, data) {
        $thisTree = $(this);//当前树对象

        if (data.node == undefined) return;
        var link = data.node.a_attr.href;
        var uniqueId = data.node.a_attr.uniqueid;

        //处理Tree节点按下Ctrl或Shift组合键后的，多选节点
        var i, j, r = [];
        for (i = 0, j = data.selected.length; i < j; i++) {
            r.push(data.instance.get_node(data.selected[i]).a_attr.uniqueid);
        }
        if (r.join(',') != '') {
            uniqueId = r.join(',');
        }

        var level = data.node.a_attr.level;
        commonTreeData.level = level;
        commonTreeData.uniqueId = uniqueId;
        if (!commonTreeData.uniqueId) {
            commonTreeData.uniqueId = '';
            //处理虚拟树节点(即此节点不在数据库表中，而是通过C#程序处理)
        }
        var frametype = $thisTree.parent().attr('frametype');
        var targetFrome = $thisTree.parent().attr('target');
        if (frametype) {
            if (targetFrome && frametype == 'frameset') {//frameset框架
                var targetFromeGroup = targetFrome.split(',');
                for (var j = 0; j < targetFromeGroup.length; j++) {
                    var $thisFrame = $(window.parent.document).find("frame[name='" + targetFromeGroup[j] + "']");
                    var thisFrameSrc = $thisFrame.attr('baseurl');//目标链接地址
                    if (!thisFrameSrc) {//不存在baseurl属性，则取src属性值
                        thisFrameSrc = $thisFrame.attr('src');
                    }
                    var usetreelink = $thisFrame.attr('usetreelink');
                    if (usetreelink) {//如果存在使用树节点连接的话
                        thisFrameSrc = link;
                    }
                    thisFrameSrc = thisFrameSrc.replace("{sid_Iterm}", commonTreeData.uniqueId);//先替换可能存在的唯一业务表Guid
                    if ($thisFrame.attr('baseurl')) {//只有baseurl属性存在，才执行此逻辑
                        //处理树链接中可能传入的参数集合
                        if (link.split('?').length > 1) {
                            var linkParameterGroup = link.split('?')[1].split('&');
                            for (var i = 0; i < linkParameterGroup.length; i++) {
                                var linkParamerterKeyValue = linkParameterGroup[i].split('=');
                                if (linkParamerterKeyValue.length > 1) {
                                    if (thisFrameSrc.indexOf(linkParamerterKeyValue[0]) >= 0) {
                                        thisFrameSrc = thisFrameSrc.replace(linkParamerterKeyValue[0], linkParamerterKeyValue[1]);
                                    }
                                }
                            }
                        }
                    }

                    $thisFrame.attr('src', thisFrameSrc);//导航到目标链接地址
                }

            } else if (targetFrome && frametype == 'iframe') {//iframe框架                 
                var targetFromeGroup = targetFrome.split(',');
                for (var j = 0; j < targetFromeGroup.length; j++) {
                    var $thisFrame = $(window.parent.document).find("iframe[name='" + targetFromeGroup[j] + "']");
                    var thisFrameSrc = $thisFrame.attr('baseurl');//目标链接地址 
                    thisFrameSrc = thisFrameSrc.replace("{sid_Iterm}", commonTreeData.uniqueId);//先替换可能存在的唯一业务表Guid
                    //处理树链接中可能传入的参数集合
                    if (link.split('?').length > 1) {
                        var linkParameterGroup = link.split('?')[1].split('&');
                        for (var i = 0; i < linkParameterGroup.length; i++) {
                            var linkParamerterKeyValue = linkParameterGroup[i].split('=');
                            if (linkParamerterKeyValue.length > 1) {
                                if (thisFrameSrc.indexOf(linkParamerterKeyValue[0]) >= 0) {
                                    thisFrameSrc = thisFrameSrc.replace(linkParamerterKeyValue[0], linkParamerterKeyValue[1]);
                                }
                            }
                        }
                    }

                    $thisFrame.attr('src', thisFrameSrc);//导航到目标链接地址
                }
            }
        }
        //动态触发一个事件   
        var triggerevent = data.node.a_attr.triggerevent;
        if (triggerevent) {
            eval(triggerevent);
        }
        //Call Back 处理
        var callbackjson = data.node.a_attr.callbackjson;
        if (callbackjson) {
            commonTreeData.callbackjson = callbackjson;
        }

    });
});