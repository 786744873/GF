

var n = 0;
var leeShowTimeNumber = 0;
var leeShowTimeNumber1 = 0;

var leeShowTimeMinNumber = 0;
var leeShowTimeMinNumber1 = 0;

var loadYear = "";
var loadMonth = "";
var loadDay = "";

var m_aMonHead = new Array(12); //定义阳历中每个月的最大天数 
m_aMonHead[0] = 31; m_aMonHead[1] = 28; m_aMonHead[2] = 31; m_aMonHead[3] = 30; m_aMonHead[4] = 31; m_aMonHead[5] = 30;
m_aMonHead[6] = 31; m_aMonHead[7] = 31; m_aMonHead[8] = 30; m_aMonHead[9] = 31; m_aMonHead[10] = 30; m_aMonHead[11] = 31;
var leeShowTimeModel;
var ScollHeight = 0; var ScollWidth = 0;

function loadCSS(filePath) {
   
    var link = document.createElement("link");
    link.setAttribute("rel", "stylesheet");
    link.setAttribute("type", "text/css");
    link.setAttribute("href", filePath + "Lee10DateCSS.css");
    var head = document.getElementsByTagName("head")[0];
    head.appendChild(link);
}

$(function () {
    var scriptModels = $("script");
    var cssPath = "";
    for (var i = 0; i < scriptModels.length; i++) {
        if ($(scriptModels[i]).attr("src") != null && $(scriptModels[i]).attr("src").indexOf("Lee10DateJS.js") > 0) {
            cssPath = String($(scriptModels[i]).attr("src")).substr(0, $(scriptModels[i]).attr("src").indexOf("Lee10DateJS.js"));
        }
    }
    loadCSS("/Theme/js/Lee10DateTime/");

    var maxShowDiv = $("<div id='Lee_MyShowTime' onclick='Show_LeeTime()'><input type='hidden' id='LeeShowTime_Tyear' /><input type='hidden' id='LeeShowTime_Tmonth' /><input type='hidden' id='LeeShowTime_Tday' /><input type='hidden' id='LeeShowTimeMM_Type' /><input type='hidden' id='LeeShowTime_Type' /></div>");
    var mtopShowDiv = $("<div id='Lee_MyShowTime_Top'><div class='MinLeftDiv' style='margin-left: 5px;' id='Top_Left1'><div class='MyShowDivTime_Img2' onclick='YearUp()'></div></div><div class='MinLeftDiv' style='margin-left: 5px;' id='Top_Left2'><div class='MyShowDivTime_Img1' onclick='MonthUp()'></div></div><div class='ContectDiv' id='Top_Content'><span id='Lee_MyShowTime_Month' style='cursor: pointer;' onclick=CheckYm('M',this)>09</span>月 <span id='Lee_MyShowTime_Year' style='cursor: pointer;' onclick=CheckYm('Y',this) >2013</span></div><div class='MinRightDiv' id='Top_Right1'><div class='MyShowDivTime_Img3' onclick='MonthDown()'></div></div><div class='MinRightDiv' style='margin-right: 3px;' id='Top_Right2'><div class='MyShowDivTime_Img4' onclick='YearDown()'></div></div></div>");
    maxShowDiv.append(mtopShowDiv);
    var mContentShowDiv = $("<div id='Lee_MyShowTime_Content'><div id='Lee_MyShowTime_ContentTop'><table class='MyShowTime_tabClass'><tr><td>日<td>一</td><td>二</td><td>三</td><td>四</td><td>五</td><td>六</td></tr></table></div><div id='Lee_MyShowTime_ContentB'><table id='MyShowTime_tabTime' class='MyShowTime_tabClass'></table></div></div>")
    maxShowDiv.append(mContentShowDiv);
    var mButtomShowDiv = $("<div id='Lee_MyShowTime_Buttom'><div class='Lee_MyShowTime_Buttom_CSS' id='Lee_MyShowTime_Buttom_One'><div class='Lee_MyShowTime_Buttom_CSS1'>时间</div><div class='Lee_MyShowTime_Buttom_CSS2'><span onclick=CheckYm('H',this) id='LeeShowTime_T_H'>08</span>&nbsp;:&nbsp;<span onclick=CheckYm('MM',this) id='LeeShowTime_T_M'>00</span>&nbsp;:&nbsp;<span onclick=CheckYm('S',this) id='LeeShowTime_T_S'>00</span></div></div><div class='Lee_MyShowTime_Buttom_CSS' id='Lee_MyShowTime_Buttom_Two'><div class='buttons' style='width: 100%; height: 100%;'><a href='#' class='regular' onclick='showDateTime(1)'>确定</a> <a href='#' class='regular'onclick='showDateTime(2)'>今天</a> <a href='#' class='regular' onclick='showDateTime(3)'>清除</a></div></div></div><div id='Lee_Show_MinDiv' onclick='Show_LeeMinTime()'></div>")
    maxShowDiv.append(mButtomShowDiv);
    $("body").append(maxShowDiv);

    for (var i = 0; i < 6; i++) {
        var Lee_time_tr = $("<tr align='center' class='Lee_tr' id='trTiannetDay" + i + "' ></tr>");
        for (var j = 0; j < 7; j++) {
            var Lee_time_td = $("<td class='Lee_td' align='center' id='tdTiannetDay" + n + "' > </td>");
            n++;
            Lee_time_tr.append(Lee_time_td);
        }
        $("#MyShowTime_tabTime").append(Lee_time_tr);
    }

    LeeShowDate("", "", "");

    //这个是兼容IE9及360的事件（监测鼠标点击事件）
    $(document).click(function (e) {
        if (leeShowTimeNumber == 2 && leeShowTimeNumber1 == 1) {
            leeShowTimeNumber1 = 0;
        } else if (leeShowTimeNumber == 1 && leeShowTimeNumber1 == 0) {
            leeShowTimeNumber1 = 2;
        } else if (leeShowTimeNumber == 1 && leeShowTimeNumber1 == 2) {
            tiannetHideControl_LeeShowTime();
        } else {
            tiannetHideControl_LeeShowTime();
        }

        if (leeShowTimeMinNumber == 2 && leeShowTimeMinNumber1 == 1) {
            leeShowTimeMinNumber1 = 0;
        } else if (leeShowTimeMinNumber == 1 && leeShowTimeMinNumber1 == 0) {
            leeShowTimeMinNumber1 = 2;
        } else if (leeShowTimeMinNumber == 1 && leeShowTimeMinNumber1 == 2) {
            tiannetHideControl();
        } else {
            tiannetHideControl();
        }
    })

    $("[ctype=date]").click(function () {
        leeShowTimeNumber = 0;
        leeShowTimeNumber1 = 0;
        leeShowTimeMinNumber = 0;
        leeShowTimeMinNumber1 = 0;

        $("#LeeShowTime_Type").val("");
        $("#LeeShowTime_Type").val($(this).attr("s_type"));

        $("#LeeShowTimeMM_Type").val("");
        $("#LeeShowTimeMM_Type").val($(this).attr("c_time"));

        $("#LeeShowTime_T_H").text("08")
        $("#LeeShowTime_T_M").text("00");
        $("#LeeShowTime_T_S").text("00");

        if ($("#LeeShowTime_Type").val() == "4") {
            $("#LeeShowTime_T_H").text((Number((new Date).getHours()) < 10 ? "0" + (new Date).getHours() : (new Date).getHours()));
            $("#LeeShowTime_T_M").text((Number((new Date).getMinutes()) < 10 ? "0" + (new Date).getMinutes() : (new Date).getMinutes()));
            $("#LeeShowTime_T_S").text((Number((new Date).getSeconds()) < 10 ? "0" + (new Date).getSeconds() : (new Date).getSeconds()));
        }

        leeShowTimeModel = this;

        var bodyHeight = $(window).height();
        var MyTimeHeight = $("#Lee_MyShowTime").height();

        var position = $(this).position();
        var top = position.top + $(this).height() + 7;
        var left = position.left //position.left + ($(obj).width() - 100);
        var scroll = $(".scroll").size() > 0 ? $(".scroll").height() : 0;
        leeShowTimeNumber = 1;

        if (top + MyTimeHeight > bodyHeight) {
            if (position.top > MyTimeHeight + 9) {
                top = position.top - MyTimeHeight - 3;
            }
        }

        $("#Lee_MyShowTime").css("top", top);
        $("#Lee_MyShowTime").css("left", left);
        $("#Lee_Show_MinDiv").css("display", "none");
        LeeShowDate(($(this).val() == "" ? "" : $(this).val()), "", "");
        $("#Lee_MyShowTime").css("display", "block");
    })
})

function showDateTime(type) {
    var Lee_Date = $("#LeeShowTime_Tyear").val() + "-" + $("#LeeShowTime_Tmonth").val() + "-" + $("#LeeShowTime_Tday").val();
    var Lee_hh = $("#LeeShowTime_T_H").text();
    var Lee_mm = $("#LeeShowTime_T_M").text();
    var Lee_ss = $("#LeeShowTime_T_S").text();
    if (Number(type) == 1) {
        if ($("#LeeShowTime_Type").val() == "1")
            $(leeShowTimeModel).val(Lee_Date);
        else if ($("#LeeShowTime_Type").val() == "2")
            $(leeShowTimeModel).val(Lee_Date + " " + Lee_hh + ":" + Lee_mm);
        else
            $(leeShowTimeModel).val(Lee_Date + " " + Lee_hh + ":" + Lee_mm + ":" + Lee_ss);
    } else if (Number(type) == 2) {
        Lee_Date = (new Date).getFullYear() + "-" + (Number((new Date).getMonth()) + 1) + "-" + (new Date).getDate();
        if ($("#LeeShowTime_Type").val() == "1")
            $(leeShowTimeModel).val(Lee_Date);
        else if ($("#LeeShowTime_Type").val() == "2")
            $(leeShowTimeModel).val(Lee_Date + " 08:00");
        else if ($("#LeeShowTime_Type").val() == "3")
            $(leeShowTimeModel).val(Lee_Date + " " + (Number((new Date).getHours()) < 10 ? "0" + (new Date).getHours() : (new Date).getHours()) + ":" + (Number((new Date).getMinutes()) < 10 ? "0" + (new Date).getMinutes() : (new Date).getMinutes()) + ":" + (Number((new Date).getSeconds()) < 10 ? "0" + (new Date).getSeconds() : (new Date).getSeconds()));
        else
            $(leeShowTimeModel).val(Lee_Date + " 08:00:00");
    } else {
        $(leeShowTimeModel).val("");
    }

    tiannetHideControl_LeeShowTime();
}

var LeeShowMinDivNum = 0;
function CheckYm(type, obj) {
    leeShowTimeMinNumber = 2;
    leeShowTimeMinNumber1 = 1;
    Lee_PositionDiv($(obj).parent(), type);
}

function Show_LeeTime() {
    leeShowTimeNumber = 2;
    leeShowTimeNumber1 = 1;
}

function Show_LeeMinTime() {
    leeShowTimeMinNumber = 2;
    leeShowTimeMinNumber1 = 1;
}

//这个是兼容IE7及IE7的事件（监测鼠标点击事件）
//    function document.onclick() {
//        with (window.event.srcElement) {
//            if (tagName != "INPUT" && getAttribute("Author") != "tiannet")
//                tiannetHideControl();
//        }
//    }

function tiannetHideControl() {
    leeShowTimeMinNumber = 0;
    leeShowTimeMinNumber1 = 0;
    $("#Lee_Show_MinDiv").css("display", "none");
}

function tiannetHideControl_LeeShowTime() {
    leeShowTimeNumber = 0;
    leeShowTimeNumber1 = 0;
    $("#Lee_MyShowTime").css("display", "none");
}

function Lee_PositionDiv(obj, type) {
    var position = $(obj).position();
    var top = position.top + $(obj).height();
    var left = position.left - 8; //position.left + ($(obj).width() - 100);
    var scroll = $(".scroll").size() > 0 ? $(".scroll").height() : 0;
    var leeMinIsShow = 0;
    LeeShowMinDivNum = 1;

    $("#Lee_Show_MinDiv").empty();
    var Lee_Add_table = $("<table style='margin-left:2px;'></table>");
    var Lee_Add_Num = 1;
    $("#Lee_Show_MinDiv").css("height", "80px")
    if (type == "M") {
        for (var i = 0; i < 4; i++) {
            var Lee_Add_tr = $("<tr></tr>");
            for (var j = 0; j < 3; j++) {
                var Lee_Add_td = $("<td class='Lee_td' style='text-align: center; width:33px;'><span style='cursor: pointer;' onclick='Lee_Set_Month(" + Lee_Add_Num + ")'>" + Lee_Add_Num + "月</span></td>");
                Lee_Add_Num++;
                Lee_Add_tr.append(Lee_Add_td);
            }
            Lee_Add_table.append(Lee_Add_tr);
        }
        $("#Lee_Show_MinDiv").append(Lee_Add_table);
    } else if (type == "Y") {
        var year = Number($("#LeeShowTime_Tyear").val()) - 6;
        if (year < 1989) {
            year = 1989;
        }
        for (var i = 0; i < 4; i++) {
            var Lee_Add_tr = $("<tr></tr>");
            if (i == 2) {
                year++;
            }
            for (var j = 0; j < 3; j++) {
                var Lee_Add_td = $("<td class='Lee_td' style='text-align: center; width:33px;'><span style='cursor: pointer;' onclick='Lee_Set_Year(" + year + ")'>" + year + "</span></td>");
                year++;
                Lee_Add_tr.append(Lee_Add_td);
            }
            Lee_Add_table.append(Lee_Add_tr);
        }
        $("#Lee_Show_MinDiv").append(Lee_Add_table);
    } else {
        if ($("#LeeShowTime_Type").val() != "1") {
            top = position.top - 80;
            left = left + 5;
            if (type == "H") {
                Lee_Add_Num = 0;
                for (var i = 0; i < 4; i++) {
                    var Lee_Add_tr = $("<tr></tr>");
                    for (var j = 0; j < 6; j++) {
                        var Lee_Add_td = $("<td class='Lee_td' style='text-align: center;'><span style='cursor: pointer;' onclick='Lee_Set_Hous(" + Lee_Add_Num + ")'>" + Lee_Add_Num + "</span></td>");
                        Lee_Add_Num++;
                        Lee_Add_tr.append(Lee_Add_td);
                    }
                    Lee_Add_table.append(Lee_Add_tr);
                }
                $("#Lee_Show_MinDiv").append(Lee_Add_table);
            } else {
                top = position.top - 40;
                $("#Lee_Show_MinDiv").css("height", "40px");
                Lee_Add_Num = 0;
                if (type == "MM") {
                    $("#Lee_Show_MinDiv").css("display", "none");
                    if ($("#LeeShowTimeMM_Type").val() == "1") {
                        if ($("#LeeShowTime_T_M").text() == "00") {
                            $("#LeeShowTime_T_M").text("30");
                        } else {
                            $("#LeeShowTime_T_M").text("00");
                        }
                        return;
                    } else {
                        for (var i = 0; i < 2; i++) {
                            var Lee_Add_tr = $("<tr></tr>");
                            for (var j = 0; j < 6; j++) {
                                var Lee_Add_td = $("<td class='Lee_td' style='text-align: center;'><span style='cursor: pointer;' onclick='Lee_Set_Muen(" + Lee_Add_Num * 5 + ")'>" + Lee_Add_Num * 5 + "</span></td>");
                                Lee_Add_Num++;
                                Lee_Add_tr.append(Lee_Add_td);
                            }
                            Lee_Add_table.append(Lee_Add_tr);
                        }
                        $("#Lee_Show_MinDiv").append(Lee_Add_table);
                    }
                } else {
                    if ($("#LeeShowTime_Type").val() != "2") {
                        top = position.top - 20;
                        $("#Lee_Show_MinDiv").css("height", "20px");
                        for (var i = 0; i < 1; i++) {
                            var Lee_Add_tr = $("<tr></tr>");
                            for (var j = 0; j < 6; j++) {
                                var Lee_Add_td = $("<td class='Lee_td' style='text-align: center; width:16px;'><span style='cursor: pointer;' onclick='Lee_Set_SS(" + Lee_Add_Num * 10 + ")'>" + Lee_Add_Num * 10 + "</span></td>");
                                Lee_Add_Num++;
                                Lee_Add_tr.append(Lee_Add_td);
                            }
                            Lee_Add_table.append(Lee_Add_tr);
                        }
                        $("#Lee_Show_MinDiv").append(Lee_Add_table);
                    } else {
                        leeMinIsShow = 1;
                    }
                }
            }
        } else {
            leeMinIsShow = 1;
        }
    }

    if (leeMinIsShow == 0) {
        $("#Lee_Show_MinDiv").css("top", top);
        $("#Lee_Show_MinDiv").css("left", left);
        $("#Lee_Show_MinDiv").css("display", "block");
    }
}

function CheckDay(obj) {
    $("[class=Lee_td]").css("background-color", "");
    $(obj).parent().css("background-color", "#3FC43F");
    $("#LeeShowTime_Tday").val($(obj).text());
}

function MonthDown() {
    LeeShowDate("", "", "UP");
}

function MonthUp() {
    LeeShowDate("", "", "DOWN");
}

function YearDown() {
    LeeShowDate("", "UP", "");
}

function YearUp() {
    LeeShowDate("", "DOWN", "");
}

function Lee_Set_Month(month) {
    $("#Lee_Show_MinDiv").css("display", "none");
    var m = "01";
    if (month < 10) {
        m = "0" + month;
    } else {
        m = String(month);
    }
    LeeShowDateNow($("#LeeShowTime_Tyear").val(), m, $("#LeeShowTime_Tday").val());
}

function Lee_Set_Year(year) {
    $("#Lee_Show_MinDiv").css("display", "none");
    LeeShowDateNow(year, $("#LeeShowTime_Tmonth").val(), $("#LeeShowTime_Tday").val());
}

function Lee_Set_Hous(hous) {
    $("#Lee_Show_MinDiv").css("display", "none");
    if (Number(hous) < 10) {
        hous = "0" + hous;
    }
    $("#LeeShowTime_T_H").text(hous);
}

function Lee_Set_Muen(muen) {
    $("#Lee_Show_MinDiv").css("display", "none");
    if (Number(muen) < 10) {
        muen = "0" + muen;
    }
    $("#LeeShowTime_T_M").text(muen);
}

function Lee_Set_SS(ss) {
    $("#Lee_Show_MinDiv").css("display", "none");
    if (Number(ss) < 10) {
        ss = "0" + ss;
    }
    $("#LeeShowTime_T_S").text(ss);
}

function LeeShowDate(date, yUD, mUD) {
    var year = "", month = "", day = "";
    if (yUD == "" && mUD == "") {
        if (date == "") {
            year = (new Date).getFullYear();
            month = (Number((new Date).getMonth()) + 1);
            day = (new Date).getDate();
            date = year + "-" + month + "-" + day;
        } else {
            year = date.substr(0, 4);
            month = date.substr(5, 2);
            day = date.substr(8, 2);

            loadYear = date.substr(0, 4);
            loadMonth = date.substr(5, 2);
            loadDay = date.substr(8, 2);
        }
    } else {
        year = $("#LeeShowTime_Tyear").val();
        month = $("#LeeShowTime_Tmonth").val();
        day = $("#LeeShowTime_Tday").val();

        if (mUD != "") {
            if (mUD == "DOWN" && Number(month) == 1) {
                if (Number(year) != 1989) {
                    year = String(Number(year) - 1);
                    month = "12";
                }
            } else if (mUD == "UP" && Number(month) == 12) {
                year = String(Number(year) + 1);
                month = "1";
            } else if (mUD == "DOWN") {
                month = String(Number(month) - 1);
            } else {
                month = String(Number(month) + 1);
            }
        }

        if (yUD != "") {
            if (yUD == "DOWN") {
                if ((Number(year) - 1) < 1990) {
                    year = "1989";
                }
                year = String(Number(year) - 1);
            } else {
                year = String(Number(year) + 1);
            }
        }
    }

    LeeShowDateNow(year, month, day);
}

function LeeShowDateNow(year, month, day) {
    //显示的年月
    $("#Lee_MyShowTime_Year").text(year);
    if (Number(month) < 10) {
        month = "0" + Number(month);
    }
    $("#Lee_MyShowTime_Month").text(month);
    //影藏的年月日
    $("#LeeShowTime_Tyear").val(year);
    $("#LeeShowTime_Tmonth").val(month);
    $("#LeeShowTime_Tday").val(day);

    var dayCount = getMonthCount(year, month);
    var dayMon = getDaySQ(year + "-" + month + "-01");

    var Lee_DayNum = dayMon + dayCount;
    var Lee_DayNumber = 1;
    var tdSpan;

    $("[class=Lee_td]").css("background-color", "");

    for (var i = dayMon; i < Lee_DayNum; i++) {
        tdSpan = $("<span style='color:blue;cursor: pointer;' onClick='CheckDay(this)'>" + Lee_DayNumber + "</span>");
        if (i % 7 == 0 || (i + 1) % 7 == 0) {
            tdSpan = $("<span style='color:#DE2F2F;cursor: pointer;' onClick='CheckDay(this)'>" + Lee_DayNumber + "</span>");
        }
        $("#tdTiannetDay" + i).css("border", "");
        $("#tdTiannetDay" + i).css("background-color", "");
        if (year == (new Date).getFullYear() && Number(month) == (Number((new Date).getMonth()) + 1)) {
            if (Lee_DayNumber == Number((new Date).getDate())) {
                $("#tdTiannetDay" + i).css("border", "1px solid #3FC43F");
            }
        }

        if (year == loadYear && month == loadMonth && Lee_DayNumber == loadDay) {
            $("#tdTiannetDay" + i).css("background-color", "#3FC43F");
        }

        $("#tdTiannetDay" + i).empty();
        $("#tdTiannetDay" + i).append(tdSpan);
        Lee_DayNumber++;
    }

    Lee_DayNumber = 1;
    for (var i = Lee_DayNum; i < 42; i++) {
        tdSpan = $("<span style='color:#898989;'>" + Lee_DayNumber + "</span>");
        $("#tdTiannetDay" + i).empty();
        $("#tdTiannetDay" + i).append(tdSpan);
        Lee_DayNumber++;
    }

    if (Number(month) == 1) {
        year = String(Number(year) - 1);
        month = "12";
    } else {
        month = String(Number(month) - 1);
    }

    dayCount = getMonthCount(year, month);
    Lee_DayNumber = dayCount - dayMon + 1;
    for (var i = 0; i < dayMon; i++) {
        tdSpan = $("<span style='color:#898989;'>" + Lee_DayNumber + "</span>");
        $("#tdTiannetDay" + i).empty();
        $("#tdTiannetDay" + i).append(tdSpan);
        Lee_DayNumber++;
    }
}

//判断是否是时间
function isDate(str) {
    var reg = /^(\d+)-(\d{1,2})-(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
    return !reg.test(str);
}

//判断某年是否为闰年 
function isPinYear(year) {
    var bolRet = false;
    if (0 == year % 4 && ((year % 100 != 0) || (year % 400 == 0))) {
        bolRet = true;
    }
    return bolRet;
}
//得到一个月的天数，闰年为29天 
function getMonthCount(year, month) {
    var c = m_aMonHead[month - 1];
    if ((month == 2) && isPinYear(year)) c++;
    return c;
}

//得到当前时间是周几
function getDaySQ(date) {
    var s1 = "1990-01-01".replace(/-/g, "/");
    var s2 = date.replace(/-/g, "/");
    d1 = new Date(s1);
    d2 = new Date(s2);

    var time = d2.getTime() - d1.getTime();
    var days = parseInt(time / (1000 * 60 * 60 * 24));
    var num = days % 7 + 1;
    if (num < 0) {
        num = Number(String(num + 1).substr(1));
    }
    return num;
}

//这里控制它是否滚动就消失
//    function move() {
//        tiannetHideControl_LeeShowTime();
//    }
//    window.onscroll = move;