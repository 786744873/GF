/**
Core script to handle the entire theme and core functions
**/
$(function () {

    // Reference the auto-generated proxy for the hub.  
    var chat = $.connection.chatHub;
    // Create a function that the hub can call back to display messages.
    chat.client.addNewMessageToPage = function (message) {
        Recived(message);
    };
    chat.client.sendEmailMsg = function (json) {//发送邮件消息
        EachEmailJson(json);
    };
    chat.client.sendScheduleMsg = function (json) {//发送日程消息
        EachScheduleJson(json);
    };
    chat.client.sendFormSubMsg = function (json) {//发送表单审核消息
        EachFormSubJson(json);
    };
    chat.client.removeFormSubMsg = function (li) {//表单审核消息查看
        RemoveFormLi(li);
    };
    chat.client.removeEmailSubMsg = function (li) {//邮箱消息查看
        RemoveEmailLi(li);
    };
    chat.client.removeScheduleSubMsg = function (li) {//日程消息查看
        RemoveScheduleLi(li);
    };
    // Get the user name and store it to prepend to messages.

    // Start the connection.
    $.connection.hub.start().done(function () {
        var wrapper = $('.page-quick-sidebar-wrapper');
        var wrapperChat = wrapper.find('.page-quick-sidebar-chat');
        wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control').keypress(function (e) {
            if (e.which == 13) {
                chat.server.send(wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control').val());
                wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control').val("");
                return false;
            }
        });

        $('.page-quick-sidebar-chat-user-form .btn').click(function () {
            // Call the Send method on the hub. 
            try {
                chat.server.send(wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control').val());
            } catch (e) {
                alert(e.message);
            }

            wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control').val("");
            // Clear text box and reset focus for next comment. 

        });
    });
});
function EachEmailJson(json) {
    var oldcount = $('#inboxcount').html();
    var count = parseInt(oldcount) + parseInt(1);
    $('#inboxcount').html("" + count + "");
    $('#emailCount').html("" + count + "");
    var data = eval("(" + json + ")");
    //把data添加到邮件列表中
    $('#emailNoReadList').prepend(" <li id=" + data.C_Messages_id + "><a href='/oa/email/List?emailCode=" + data.O_Email_code + "&msgID=" + data.C_Messages_id + "&Mlist=1' class='ajaxify' ><span class='photo'><img src='/theme/assets/admin/layout3/img/avatar2.jpg' class='img-circle' alt=''></span><span class='subject'> <span class='from'>  " + data.C_Userinfo_name + "</span><span class='time'>" + data.O_Email_createTime + " </span></span> <span class='message'>" + data.O_Email_title + " </span></a> </li>");
}
function EachScheduleJson(json) {
    var oldcount = $('#scheduleCount').html();
    var count = parseInt(oldcount) + parseInt(1);
    $('#scheduleCount').html("" + count + "");
    $('#scheduleCount2').html("" + count + "");
    var data = eval("(" + json + ")");
    //把DATA添加到日程列表中
    $('#scheduleNoReadList').prepend(" <li id=" + data.C_Messages_id + "><a href='/oa/schedule/Details?scheduleCode=" + data.O_Schedule_code + "&msgID=" + data.C_Messages_id + "' class='ajaxify'><span class='photo'><img src='/theme/assets/admin/layout3/img/avatar2.jpg' class='img-circle' alt=''></span><span class='subject'> <span class='from'>  " + data.O_Schedule_title + "</span><span class='time'>" + data.O_Schedule_startTime + " </span></span> <span class='message'>" + data.O_Schedule_content + " </span></a> </li>");
}
function EachFormSubJson(json) {
    var oldcount = $('#FormSubCount').html();
    var count = parseInt(oldcount) + parseInt(1);
    $('#FormSubCount').html("" + count + "");
    $('#FormSubCount2').html("" + count + "");
    var data = eval("(" + json + ")");
    //把DATA添加到表单通知列表中
    $('#FormSubList').prepend(" <li id=" + data.C_Messages_id + "><a href='/oa/form/layoutroottabs?oFormCode=" + data.O_Form_code + "&msgID=" + data.C_Messages_id + "' class='ajaxify'><span class='photo'><img src='/theme/assets/admin/layout3/img/avatar2.jpg' class='img-circle' alt=''></span><span class='subject'> <span class='from'>  " + data.O_Form_AuditPerson_statusname + "</span><span class='time'>" + data.O_Form_AuditFlow_createTime + " </span></span> <span class='message'>" + data.O_Form_AuditPerson_content + " </span></a> </li>");
}
function RemoveFormLi(li) {//表单审核，读取消息后的操作
    //移除li
    $('#' + li).remove();
    var oldcount = $('#FormSubCount').html();
    var count = parseInt(oldcount) - parseInt(1);
    $('#FormSubCount').html("" + count + "");
    $('#FormSubCount2').html("" + count + "");
}
function RemoveEmailLi(li) {//邮箱，读取消息后的操作
    //移除li
    $('#' + li).remove();
    var oldcount = $('#inboxcount').html();
    var count = parseInt(oldcount) - parseInt(1);
    $('#inboxcount').html("" + count + "");
    $('#emailCount').html("" + count + "");
}
function RemoveScheduleLi(li) {//日程，读取消息后的操作
    //移除li
    $('#' + li).remove();
    var oldcount = $('#scheduleCount').html();
    var count = parseInt(oldcount) - parseInt(1);
    $('#scheduleCount').html("" + count + "");
    $('#scheduleCount2').html("" + count + "");
}
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}

var wrapper = $('.page-quick-sidebar-wrapper');
var wrapperChat = wrapper.find('.page-quick-sidebar-chat');
var chatContainer = wrapperChat.find(".page-quick-sidebar-chat-user-messages");

function Recived(text) {
    var time = new Date();
    var message = preparePost('in', (time.getHours() + ':' + time.getMinutes()), "Ella Wong", 'avatar2', text);

    message = $(message);

    chatContainer.append(message);
    chatContainer.slimScroll({
        scrollTo: getLastPostPos()
    });

}
var preparePost = function (dir, time, name, avatar, message) {
    var tpl = '';
    tpl += '<div class="post ' + dir + '">';
    tpl += '<img class="avatar" alt="" src="' + Layout.getLayoutImgPath() + avatar + '.jpg"/>';
    tpl += '<div class="message">';
    tpl += '<span class="arrow"></span>';
    tpl += '<a href="#" class="name">Bob Nilson</a>&nbsp;';
    tpl += '<span class="datetime">' + time + '</span>';
    tpl += '<span class="body">';
    tpl += message;
    tpl += '</span>';
    tpl += '</div>';
    tpl += '</div>';

    return tpl;
};

var getLastPostPos = function () {
    var height = 0;
    chatContainer.find(".post").each(function () {
        height = height + $(this).outerHeight();
    });
    alert("11");
    return height;
};

var QuickSidebar = function () {

    // Handles quick sidebar toggler
    var handleQuickSidebarToggler = function () {
        // quick sidebar toggler
        $('.top-menu .dropdown-quick-sidebar-toggler a, .page-quick-sidebar-toggler').click(function (e) {
            $('body').toggleClass('page-quick-sidebar-open');
        });
    };

    // Handles quick sidebar chats
    var handleQuickSidebarChat = function () {
        //var wrapper = $('.page-quick-sidebar-wrapper');
        //var wrapperChat = wrapper.find('.page-quick-sidebar-chat');

        var initChatSlimScroll = function () {
            var chatUsers = wrapper.find('.page-quick-sidebar-chat-users');
            var chatUsersHeight;

            chatUsersHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

            // chat user list 
            Metronic.destroySlimScroll(chatUsers);
            chatUsers.attr("data-height", chatUsersHeight);
            Metronic.initSlimScroll(chatUsers);

            var chatMessages = wrapperChat.find('.page-quick-sidebar-chat-user-messages');
            var chatMessagesHeight = chatUsersHeight - wrapperChat.find('.page-quick-sidebar-chat-user-form').outerHeight() - wrapperChat.find('.page-quick-sidebar-nav').outerHeight();

            // user chat messages 
            Metronic.destroySlimScroll(chatMessages);
            chatMessages.attr("data-height", chatMessagesHeight);
            Metronic.initSlimScroll(chatMessages);
        };

        initChatSlimScroll();
        Metronic.addResizeHandler(initChatSlimScroll); // reinitialize on window resize

        wrapper.find('.page-quick-sidebar-chat-users .media-list > .media').click(function () {
            wrapperChat.addClass("page-quick-sidebar-content-item-shown");
        });

        wrapper.find('.page-quick-sidebar-chat-user .page-quick-sidebar-back-to-list').click(function () {
            wrapperChat.removeClass("page-quick-sidebar-content-item-shown");
        });

        var handleChatMessagePost = function (e) {
            e.preventDefault();

            //var chatContainer = wrapperChat.find(".page-quick-sidebar-chat-user-messages");
            var input = wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control');

            var text = input.val();
            if (text.length === 0) {
                return;
            }
            //chatContainer.append(message);
            var time = new Date();
            var m = preparePost('out', (time.getHours() + ':' + time.getMinutes()), "Bob Nilson", 'avatar3', text);
            m = $(m);
            chatContainer.append(m);



            chatContainer.slimScroll({
                scrollTo: getLastPostPos()
            });

            //input.val("");

            // simulate reply
            //setTimeout(function(){
            //    var time = new Date();
            //    var message = preparePost('in', (time.getHours() + ':' + time.getMinutes()), "Ella Wong", 'avatar2', 'Lorem ipsum doloriam nibh...');
            //    message = $(message);
            //    chatContainer.append(message);

            //    chatContainer.slimScroll({
            //        scrollTo: getLastPostPos()
            //    });
            //}, 3000);
        };

        wrapperChat.find('.page-quick-sidebar-chat-user-form .btn').click(handleChatMessagePost);
        wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control').keypress(function (e) {
            if (e.which == 13) {
                handleChatMessagePost(e);
                return false;
            }
        });

    };

    // Handles quick sidebar tasks
    var handleQuickSidebarAlerts = function () {
        var wrapper = $('.page-quick-sidebar-wrapper');
        var wrapperAlerts = wrapper.find('.page-quick-sidebar-alerts');

        var initAlertsSlimScroll = function () {
            var alertList = wrapper.find('.page-quick-sidebar-alerts-list');
            var alertListHeight;

            alertListHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

            // alerts list 
            Metronic.destroySlimScroll(alertList);
            alertList.attr("data-height", alertListHeight);
            Metronic.initSlimScroll(alertList);
        };

        initAlertsSlimScroll();
        Metronic.addResizeHandler(initAlertsSlimScroll); // reinitialize on window resize
    };

    // Handles quick sidebar settings
    var handleQuickSidebarSettings = function () {
        var wrapper = $('.page-quick-sidebar-wrapper');
        var wrapperAlerts = wrapper.find('.page-quick-sidebar-settings');

        var initSettingsSlimScroll = function () {
            var settingsList = wrapper.find('.page-quick-sidebar-settings-list');
            var settingsListHeight;

            settingsListHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

            // alerts list 
            Metronic.destroySlimScroll(settingsList);
            settingsList.attr("data-height", settingsListHeight);
            Metronic.initSlimScroll(settingsList);
        };

        initSettingsSlimScroll();
        Metronic.addResizeHandler(initSettingsSlimScroll); // reinitialize on window resize
    };

    return {

        init: function () {
            handleQuickSidebarToggler(); // handles quick sidebar's toggler
            handleQuickSidebarChat(); // handles quick sidebar's chats
            handleQuickSidebarAlerts(); // handles quick sidebar's alerts
            handleQuickSidebarSettings(); // handles quick sidebar's setting
        }
    };

}();

