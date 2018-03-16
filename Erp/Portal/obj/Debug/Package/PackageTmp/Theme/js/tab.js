$(function () {
    $('<div class="tabson"><iframe width="100%" height="100%" frameborder="0" scrolling="auto" ></iframe></div>').appendTo(".usual");
    //tab页签处理
    var $itab = $(".itab");
    $("ul li a", $itab).each(function () {
        //默认tab panel 内容加载
        if ($(this).attr('class')) {
            $defaulta = $(this);
            var switchUrl = $defaulta.attr("href");
            $(".tabson").find("iframe").contents().find("body").html("");//清空body内容 
            if ($defaulta.attr('tabpanelwidth')) {
                $(".tabson").find("iframe").width($defaulta.attr('tabpanelwidth'));
            }
            if ($defaulta.attr('tabpanelheight')) {
                $(".tabson").find("iframe").height($defaulta.attr('tabpanelheight'));
            }
            if ($(this).hasClass("selected") || $(this).hasClass("selected2")) {
                $(".tabson").find("iframe").attr("src", switchUrl);//重新加载url
            }           
        }

        //点击切换tab
        $(this).click(function (event) {
            event.preventDefault();
            var $a = $(this);
            //用来处理自定义表单中，关联导航到OA系统中的连接
            if ($a.attr('oafeereimbursementlink')) {
                if ($('#oafeereimbursementlink')) {//导航到OA费用报销界面
                    $('#oafeereimbursementlink').attr('href', $a.attr('oafeereimbursementlink'));
                    //验证没有对应权限，隐藏按钮
                    oaUrl = $a.attr('oafeereimbursementlink').replace(/&amp;/g, '&');
                    var isFormPer = oaUrl.split('&')[3].split('=');
                    if (isFormPer[1] == '0') {
                        $('#oafeereimbursementlink').addClass('hide');
                    } else {
                        $('#oafeereimbursementlink').removeClass('hide');
                    }
                }
            }
            if ($a.attr('oafeeloanlink')) {
                if ($('#oafeeLoanlink')) {//导航到OA费用借款界面
                    $('#oafeeLoanlink').attr('href', $a.attr('oafeeloanlink'));
                    //验证没有对应权限，隐藏按钮
                    oaUrl = $a.attr('oafeeloanlink').replace(/&amp;/g, '&');
                    var isFormPer = oaUrl.split('&')[3].split('=');
                    if (isFormPer[1] == '0') {
                        $('#oafeeLoanlink').addClass('hide');
                    } else {
                        $('#oafeeLoanlink').removeClass('hide');
                    }
                }
            }
            //切换tab样式
            $("ul li a", $itab).each(function () {
                if ($(this).attr('class')) {
                    if ($(this).hasClass("selected")) {
                        $(this).removeClass("selected");
                    }
                    if ($(this).hasClass("selected2")) {
                        $(this).removeClass("selected2");
                    }
                }
            });
            if ($a.attr('selectedclass')) {
                $a.addClass($a.attr('selectedclass'));
            } else {
                $a.addClass("selected");
            }            

            var switchUrl = $a.attr("href");
            $(".tabson").find("iframe").contents().find("body").html("");//清空body内容 
            if ($a.attr('tabpanelwidth')) {
                $(".tabson").find("iframe").width($a.attr('tabpanelwidth'));
            }
            if ($a.attr('tabpanelheight')) {
                $(".tabson").find("iframe").height($a.attr('tabpanelheight'));
            }
            $(".tabson").find("iframe").attr("src", switchUrl);//重新加载url
        });
    });

});