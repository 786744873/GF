/**
 * 消息框
 */
var alertMsgWarn = {
    _boxId: "#alertMsgBox",
    _bgId: "#alertBackground",
    _closeTimer: null,

    _types: { error: "error", info: "info", warn: "warn", correct: "correct", confirm: "confirm" },

    _getTitle: function (key) {
        return $.regional.alertMsg.title[key];
    },

    _keydownOk: function (event) {
        if (event.keyCode == DWZ.keyCode.ENTER) event.data.target.trigger("click");
        return false;
    },
    _keydownEsc: function (event) {
        if (event.keyCode == DWZ.keyCode.ESC) event.data.target.trigger("click");
    },
    /**
	 * 
	 * @param {Object} type
	 * @param {Object} msg
	 * @param {Object} buttons [button1, button2]
	 */
    _open: function (type, msg, buttons) {
        $(this._boxId).remove();
        var butsHtml = "";
        if (buttons) {
            for (var i = 0; i < buttons.length; i++) {
                var sRel = buttons[i].call ? "callback" : "";
                butsHtml += DWZ.frag["alertButFrag"].replace("#butMsg#", buttons[i].name).replace("#callback#", sRel);
            }
        }
        var boxHtml = DWZ.frag["alertBoxFrag"].replace("#type#", type).replace("#title#", this._getTitle(type)).replace("#message#", msg).replace("#butFragment#", butsHtml);
        $(boxHtml).appendTo("body").css({ top: -$(this._boxId).height() + "px" }).animate({ top: "0px" }, 500);

        if (this._closeTimer) {
            clearTimeout(this._closeTimer);
            this._closeTimer = null;
        }
        if (this._types.info == type || this._types.correct == type) {
            this._closeTimer = setTimeout(function () { alertMsg.close() }, 3500);
        } else {
            $(this._bgId).show();
        }

        var jButs = $(this._boxId).find("a.button");
        var jCallButs = jButs.filter("[rel=callback]");
        var jDoc = $(document);

        for (var i = 0; i < buttons.length; i++) {
            if (buttons[i].call) jCallButs.eq(i).click(buttons[i].call);
            if (buttons[i].keyCode == DWZ.keyCode.ENTER) {
                jDoc.bind("keydown", { target: jButs.eq(i) }, this._keydownOk);
            }
            if (buttons[i].keyCode == DWZ.keyCode.ESC) {
                jDoc.bind("keydown", { target: jButs.eq(i) }, this._keydownEsc);
            }
        }
    },
    close: function () {
        $(document).unbind("keydown", this._keydownOk).unbind("keydown", this._keydownEsc);
        $(this._boxId).animate({ top: -$(this._boxId).height() }, 500, function () {
            $(this).remove();
        });
        $(this._bgId).hide();
    },
    error: function (msg, options) {
        this._alert(this._types.error, msg, options);
    },
    info: function (msg, options) {
        this._alert(this._types.info, msg, options);
    },
    warn: function (msg, options) {
        this._alert(this._types.warn, msg, options);
    },
    correct: function (msg, options) {
        this._alert(this._types.correct, msg, options);
    },
    _alert: function (type, msg, options) {
        var op = { okName: $.regional.alertMsg.butMsg.ok, okCall: null };
        $.extend(op, options);
        var buttons = [
			{ name: op.okName, call: op.okCall, keyCode: DWZ.keyCode.ENTER }
        ];
        this._open(type, msg, buttons);
    },
    /**
	 * 
	 * @param {Object} msg
	 * @param {Object} options {okName, okCal, cancelName, cancelCall}
	 */
    confirm: function (msg, options) {
        var op = { okName: $.regional.alertMsg.butMsg.ok, okCall: null, cancelName: $.regional.alertMsg.butMsg.cancel, cancelCall: null };
        $.extend(op, options);
        var buttons = [
			{ name: op.okName, call: op.okCall, keyCode: DWZ.keyCode.ENTER },
			{ name: op.cancelName, call: op.cancelCall, keyCode: DWZ.keyCode.ESC }
        ];
        this._open(this._types.confirm, msg, buttons);
    }
};

var alertMsg = {
    _boxId: "#alertMsgBox",
    _types: { error: "error", info: "info", warn: "warn", correct: "correct", confirm: "confirm" },
    _button: { buttontype: "onlyclose" },//按钮类型：onlyclose，仅关闭；closeandconfirm，关闭并且确认
    _open: function (type, msg) {
        $(this._boxId).remove();
        var butsHtml = "";
        var boxHtml = '';
        if (this._types.info == type) {
            boxHtml += '<div id="alertMsgBox" class="tip">';
            boxHtml += '<div class="tiptop"><span>提示信息</span><a onclick="alertMsg.close()"></a></div>';
            boxHtml += '<div class="tipinfo">';
            boxHtml += '<span><img src="/theme/images/ticon.png" /></span>';
            boxHtml += '<div class="tipright">';
            boxHtml += '<p>' + msg + '</p>';
            //boxHtml += '<p style="color:orange;">(稍等一下，小窗自动仙去～～)</p>';
            //boxHtml += '<cite>如果是请点击确定按钮 ，否则请点取消。</cite>';
            boxHtml += '</div>';
            boxHtml += '</div>';
            boxHtml += '<div class="tipbtn">';
            boxHtml += '<input name="" type="button" onclick="alertMsg.close()" class="sure" value="确定" />&nbsp;';
            //boxHtml += ' <input name="" type="button" class="cancel" value="取消" />';
            boxHtml += '</div>';
            boxHtml += '</div>';
        } else if (this._types.warn == type) {
            boxHtml += '<div id="alertMsgBox" class="tip">';
            boxHtml += '<div class="tiptop"><span>提示信息</span><a onclick="alertMsg.close()"></a></div>';
            boxHtml += '<div class="tipinfo">';
            boxHtml += '<span><img src="/theme/images/ticon.png" /></span>';
            boxHtml += '<div class="tipright">';
            boxHtml += '<p>' + msg + '</p>';
            //boxHtml += '<p style="color:orange;">(稍等一下，小窗自动仙去～～)</p>';
            //boxHtml += '<cite>如果是请点击确定按钮 ，否则请点取消。</cite>';
            boxHtml += '</div>';
            boxHtml += '</div>';
            boxHtml += '<div class="tipbtn">';
            boxHtml += '<input name="" type="button" onclick="alertMsg.close()" class="sure" value="确定" />&nbsp;';
            //boxHtml += ' <input name="" type="button" class="cancel" value="取消" />';
            boxHtml += '</div>';
            boxHtml += '</div>';
        } else if (this._types.confirm == type) {
            boxHtml += '<div id="alertMsgBox" class="tip">';
            boxHtml += '<div class="tiptop"><span>提示信息</span><a onclick="alertMsg.close()"></a></div>';
            boxHtml += '<div class="tipinfo">';
            boxHtml += '<span><img src="/theme/images/ticon.png" /></span>';
            boxHtml += '<div class="tipright">';
            boxHtml += '<p>' + msg + '</p>';
            boxHtml += '<cite>如果是请点击确定按钮 ，否则请点取消。</cite>';
            boxHtml += '</div>';
            boxHtml += '</div>';
            boxHtml += '<div class="tipbtn">';
            boxHtml += '<input name="" type="button" onclick="alertMsg.closeandconfirm();" class="sure" value="确定" />&nbsp;';
            boxHtml += '<input name="" type="button"  onclick="alertMsg.close()"  class="cancel" value="取消" />';
            boxHtml += '</div>';
            boxHtml += '</div>';
        }
        $(boxHtml).appendTo("body");
    },
    close: function () {
        this._button.buttontype = "onlyclose";
        $(this._boxId).remove();
    },
    closeandconfirm: function () {
        this._button.buttontype = "closeandconfirm";
        $(this._boxId).remove();
        $.okCall();//调用扩展来的方法
    },
    info: function (msg) {
        this._open(this._types.info, msg);
    },
    warn: function (msg) {
        this._open(this._types.warn, msg);
    },
    confirm: function (msg, options) {
        $.extend(options);//将options参数方法合并到jquery的全局对象中
        this._open(this._types.confirm, msg);
    }
};
