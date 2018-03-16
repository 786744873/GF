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
    chat.client.sendFormSubMsg = function (json) {//发送资源评论消息
        EachFormSubJson(json);
    };
    chat.client.removeFormSubMsg = function (li) {//资源评论消息查看
        RemoveFormLi(li);
    };
    chat.client.sendProblemCommentMsg = function (json) {//发送问吧评论消息
        EachProblemCommentJson(json);
    };
    chat.client.removeProblemCommentMsg = function (li) {//问吧评论消息查看
        RemoveProblemLi(li);
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

function EachFormSubJson(json) {
    var oldcount = $('#resourcesCount').html();
    var count = parseInt(oldcount) + parseInt(1);
    $('#resourcesCount').html("" + count + "");
    $('#resourcesCount2').html("" + count + "");
    var data = eval("(" + json + ")");
    //把DATA添加到资源评论通知列表中
    var type = data.K_Resources_type;
    var href = "";
    if (type == 827) {
        href = "/kms/avi/Details?id=" + data.K_Resources_url + '&msgID=' + data.C_Messages_id;
    } else {
        href = '/kms/Resources/SelectResources?resourceCode=' + data.P_FK_code + '&msgID=' + data.C_Messages_id + '&type=' + data.K_Resources_type;
    }
    $('#resourcesCommentList').prepend(" <li><a href='" + href + "'><span class='time'>" + data.K_Comments_createTime + "</span><span class='details'><span class='label label-sm label-icon label-warning'><i class='fa fa-bell-o'></span>" + data.K_Comments_content + "</span></i></a> </li>");
}
function RemoveFormLi(li) {//资源评论，读取消息后的操作
    //移除li
    $('#' + li).remove();
    var oldcount = $('#resourcesCount').html();
    var count = parseInt(oldcount) - parseInt(1);
    $('#resourcesCount').html("" + count + "");
    $('#resourcesCount2').html("" + count + "");
}
function EachProblemCommentJson(json) {
    var oldcount = $('#problemCount').html();
    var count = parseInt(oldcount) + parseInt(1);
    $('#problemCount').html("" + count + "");
    $('#problemCount2').html("" + count + "");
    var data = eval("(" + json + ")");
    //把DATA添加到问吧评论通知列表中
    $('#problemList').prepend(" <li><a href='javascript:;'><span class='time'>" + data.K_Comments_createTime + "</span><span class='details'><span class='label label-sm label-icon label-warning'><i class='fa fa-bell-o'></span>" + data.K_Comments_content + "</span></i></a> </li>");
}
function RemoveProblemLi(li) {//问吧评论，读取消息后的操作
    //移除li
    $('#' + li).remove();
    var oldcount = $('#problemCount').html();
    var count = parseInt(oldcount) - parseInt(1);
    $('#problemCount').html("" + count + "");
    $('#problemCount2').html("" + count + "");
}

var QuickSidebar = function () {

    // Handles quick sidebar toggler
    var handleQuickSidebarToggler = function () {
        // quick sidebar toggler
        $('.page-header .quick-sidebar-toggler, .page-quick-sidebar-toggler').click(function (e) {
            $('body').toggleClass('page-quick-sidebar-open');
        });
    };

    // Handles quick sidebar chats
    var handleQuickSidebarChat = function () {
        var wrapper = $('.page-quick-sidebar-wrapper');
        var wrapperChat = wrapper.find('.page-quick-sidebar-chat');

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

            var chatContainer = wrapperChat.find(".page-quick-sidebar-chat-user-messages");
            var input = wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control');

            var text = input.val();
            if (text.length === 0) {
                return;
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

            // handle post
            var time = new Date();
            var message = preparePost('out', (time.getHours() + ':' + time.getMinutes()), "Bob Nilson", 'avatar3', text);
            message = $(message);
            chatContainer.append(message);

            var getLastPostPos = function () {
                var height = 0;
                chatContainer.find(".post").each(function () {
                    height = height + $(this).outerHeight();
                });

                return height;
            };

            chatContainer.slimScroll({
                scrollTo: getLastPostPos()
            });

            input.val("");

            // simulate reply
            setTimeout(function () {
                var time = new Date();
                var message = preparePost('in', (time.getHours() + ':' + time.getMinutes()), "Ella Wong", 'avatar2', 'Lorem ipsum doloriam nibh...');
                message = $(message);
                chatContainer.append(message);

                chatContainer.slimScroll({
                    scrollTo: getLastPostPos()
                });
            }, 3000);
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
            //layout handlers
            handleQuickSidebarToggler(); // handles quick sidebar's toggler
            handleQuickSidebarChat(); // handles quick sidebar's chats
            handleQuickSidebarAlerts(); // handles quick sidebar's alerts
            handleQuickSidebarSettings(); // handles quick sidebar's setting
        }
    };

}();