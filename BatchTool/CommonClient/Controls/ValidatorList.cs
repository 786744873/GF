using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CommonClient.Properties;
using CommonClient.Utilities;

namespace CommonClient.Controls
{
    public partial class ValidatorList : Component
    {
        public ValidatorList()
        {
            InitializeComponent();
        }

        public ValidatorList(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private static List<ValidatorItem> _validators;
        public static List<ValidatorItem> Validators
        {
            get
            {
                ValidatorList.EnsureValidators();
                return _validators;
            }
        }

        private static void EnsureValidators()
        {
            if (_validators == null)
            {
                _validators = new List<ValidatorItem>();
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined1", Regex = @"^(1(([35][0-9])|(47)|[8][01236789]))\d{8}$", Description = "手机（移动电话）号码" });
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined2", Regex = @"[\S]*", Description = "任意可见字符" });
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined3", Regex = @"^[^\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = "非中文" });
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined4", Regex = @"^[0-9a-zA-Z*/_-]*$", Description = @"请输入字母、数字,可包括：*/_-" });
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined5", Regex = @"^[\S\s]*$", Description = @"可输入任意字符" });
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined6", Regex = @"^(([1-9][\d]{0,4})|0).[0-9]{6}$", Description = @"12位数字,包括小数点和6位小数" });
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined7", Regex = @"^((\d{1,2}(\.\d{1,4})?)||(100(\.0{1,4})?))$", Description = @"不大于100的非负数,最长4位小数" });
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined8", Regex = @"^((0(\.\d{1,6})?)||(1(\.0{1,6})?))$", Description = @"不大于1的非负数,最长6位小数" });
                _validators.Add(new ValidatorItem { Id = "0", Code = "Predefined9", Regex = @"^[0-9]*$", Description = @"1开头可输入13位数字，2开头可输入16位数字" });

                _validators.Add(new ValidatorItem { Id = "205", Code = "reg1", Regex = @"^(\d{1,16}[\,|\-]{1})*\d{1,16}$", Description = @"请输入最多16位的数字，多组以，和-分隔" });
                _validators.Add(new ValidatorItem { Id = "206", Code = "reg2", Regex = @"^((?!.{4}CN.*)[A-Z0-9]{8})$|^((?!.{4}CN.*)[A-Z0-9]{11})$", Description = @"请输入8位或11位大写字母、数字，其中第五、六位不为CN" });
                _validators.Add(new ValidatorItem { Id = "207", Code = "reg54", Regex = @"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$", Description = @"请选择12或24小时制的时钟显示方式" });
                _validators.Add(new ValidatorItem { Id = "208", Code = "reg56", Regex = @"^[1-9]+[0-9]*$", Description = @"请输入以1到9开头的整数" });
                _validators.Add(new ValidatorItem { Id = "209", Code = "reg3", Regex = @"^([0-9a-zA-Z]{1,16}[\,|\-]{1})*[0-9a-zA-Z]{1,16}$", Description = @"请输入最多16位的字母或数字编号的组合，多个编号请以"","",""-""分隔" });
                _validators.Add(new ValidatorItem { Id = "210", Code = "reg5", Regex = @"^[0-9()\-+ ]*$", Description = @"请输入数字，可包含()-+或空格" });
                _validators.Add(new ValidatorItem { Id = "211", Code = "reg4", Regex = @"^[0-9\u2E80-\u9FFF_]*$", Description = @"请输入数字、中文，可包含_" });
                _validators.Add(new ValidatorItem { Id = "212", Code = "reg6", Regex = @"^[A-Za-z]*$", Description = @"请输入英文字母" });
                _validators.Add(new ValidatorItem { Id = "213", Code = "reg7", Regex = @"^[A-Za-z0-9().,\[\]'?\s\-+]*$", Description = @"请输入英文字符及标点的组合" });
                _validators.Add(new ValidatorItem { Id = "214", Code = "reg8", Regex = @"^[0-9A-Za-z]*$", Description = @"请输入大小写字母或数字" });
                _validators.Add(new ValidatorItem { Id = "215", Code = "reg66", Regex = @"^[0-9a-zA-Z]*[a-zA-Z]+[0-9a-zA-Z]*$", Description = @"请输入字母、数字，其中必含字母的组合" });
                _validators.Add(new ValidatorItem { Id = "216", Code = "reg16", Regex = @"^[a-zA-Z0-9\s]*$", Description = @"请输入字母、数字以及空白字符的组合" });
                _validators.Add(new ValidatorItem { Id = "217", Code = "reg17", Regex = @"^[a-zA-Z0-9 ]*$", Description = @"请输入大小写字母、数字，可包含空格" });
                _validators.Add(new ValidatorItem { Id = "218", Code = "reg9", Regex = @"^[a-zA-Z0-9-]*$", Description = @"请输入字母、数字，可包含-" });
                _validators.Add(new ValidatorItem { Id = "219", Code = "reg65", Regex = @"^[\.a-zA-Z\s,0-9]*$", Description = @"请输入英文大小写母、数字，可包含.和空格" });
                _validators.Add(new ValidatorItem { Id = "220", Code = "reg10", Regex = @"^[A-Za-z0-9. ]+$", Description = @"请输入大小写字母、数字，可包含.和空格" });
                _validators.Add(new ValidatorItem { Id = "221", Code = "reg11", Regex = @"^[A-Za-z0-9\/\[\]+]*$", Description = @"请输入大小写字母、数字，可包含/[]+" });
                _validators.Add(new ValidatorItem { Id = "222", Code = "reg14", Regex = @"^[A-Za-z0-9\/\-\[\]+.,?()']*$", Description = @"请输入字母、数字，可包含/-[]+.,?()'" });
                _validators.Add(new ValidatorItem { Id = "223", Code = "reg19", Regex = @"^[A-Za-z0-9\s\/\[\]+]{1,140}$", Description = @"请输入大小写字母、数字，可包含/[]+和空格" });
                _validators.Add(new ValidatorItem { Id = "224", Code = "reg15", Regex = @"^[A-Za-z0-9\/\-+?().,' ]+$", Description = @"请输入字母、数字，可包含/-+?().,'" });
                _validators.Add(new ValidatorItem { Id = "225", Code = "reg63", Regex = @"^[a-zA-Z0-9\/+\-?()\s.,']*$", Description = @"请输入字母、数字，可包含/-+?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "226", Code = "reg12", Regex = @"^[a-zA-Z]+[0-9]+([_,]*)$", Description = @"请输入字母、数字、特殊字符_、半角标点的组合，其中必须包含字母、数字" });
                _validators.Add(new ValidatorItem { Id = "227", Code = "reg13", Regex = @"(?=.*[a-zA-Z])^[0-9a-zA-Z_]*$", Description = @"请输入字母、数字、特殊字符的组合，其中必须包含字母" });
                _validators.Add(new ValidatorItem { Id = "228", Code = "reg18", Regex = @"^[A-Za-z0-9\s\-]+$", Description = @"请输入大小写字母、数字可包含""-""和空格" });
                _validators.Add(new ValidatorItem { Id = "229", Code = "reg20", Regex = @"^[a-zA-Z0-9\u4E00-\u9FFF]*$", Description = @"可输入字母、数字或中文" });
                _validators.Add(new ValidatorItem { Id = "230", Code = "reg21", Regex = @"^[a-zA-Z0-9\u2E80-\u9FFF\-\(\)]*$", Description = @"请输入字母、数字、中文，可包含()-" });
                _validators.Add(new ValidatorItem { Id = "231", Code = "reg22", Regex = @"^[0-9A-Za-z,.() \u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母、数字、中文，可包含,.()" });
                _validators.Add(new ValidatorItem { Id = "232", Code = "reg23", Regex = @"^[a-zA-Z0-9\u2E80-\u9FFF',\.\-\/\(\)]*$", Description = @"请输入字母、数字、中文，可包含',.-/()" });
                _validators.Add(new ValidatorItem { Id = "233", Code = "reg74", Regex = @"^[a-zA-Z0-9\u2E80-\u9FFF_]*$", Description = @"请输入字母、数字、中文，可包含_" });
                _validators.Add(new ValidatorItem { Id = "234", Code = "reg24", Regex = @"^[A-Z0-9]*$", Description = @"请输入大写字母或数字" });
                _validators.Add(new ValidatorItem { Id = "235", Code = "reg61", Regex = @"^[0-9\(\)\-]*$", Description = @"请输入电话号码，区号可以加()以及-分隔" });
                _validators.Add(new ValidatorItem { Id = "236", Code = "reg62", Regex = @"^[0-9 \-\(\)]*$", Description = @"请输入电话号码，区号可以加()以及-分隔" });
                _validators.Add(new ValidatorItem { Id = "237", Code = "reg25", Regex = @"^[^\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入全角字符" });
                _validators.Add(new ValidatorItem { Id = "238", Code = "reg26", Regex = @"^[^0-9\[\]\^\$\~\@\#\%\&\<\>\{\}\'""]+$", Description = @"请输入字母，以及非特殊字符[]^$~@#%&<>{}'""的组合" });
                _validators.Add(new ValidatorItem { Id = "239", Code = "reg27", Regex = @"^[^\uFF00-\uFFFF]*$", Description = @"请输入字母、数字以及半角字符的组合" });
                _validators.Add(new ValidatorItem { Id = "240", Code = "reg28", Regex = @"^[^\uFF00-\uFFFF\`\<\>\\\'\%\;\(\)\&\+\#\?\{\}\|\^\[\]\~\｀\＜\＞\＂\＇\％\；\（\）\＆\＋\＼\＃\？\｛\｝\｜\＾\［\］\～\?\《\》\‘\’\…\【\】]*$", Description = @"请输入字母、数字，以及非特殊字符` < > ' % ; ( ) & + \ # ? { } | ^ [ ] ~ ｀ ＜ ＞ ＂ ＇ ％ ； （ ） ＆ ＋ ＃ ？ ｛ ｝ ｜ ＾ ［ ］ ～ • 《 》   ‘ ’ …… … 【 】的组合" });
                _validators.Add(new ValidatorItem { Id = "241", Code = "reg29", Regex = @"^[^,'""{}_\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母、数字，以及非特殊字符,'""{}_的组合" });
                _validators.Add(new ValidatorItem { Id = "242", Code = "reg64", Regex = @"^[^\[\]^$\\~@#%￥&<>{}:'""]*$", Description = @"请输入中文、字母、数字，以及非特殊字符[]^$\~@#%￥&<>{}:'""的组合" });
                _validators.Add(new ValidatorItem { Id = "243", Code = "reg30", Regex = @"^[^\[\]\^\$\~@#%&<>\{\}:'""]*$", Description = @"请输入中文、字母或数字，不允许特殊字符[]^$~@#%&<>{}:'""" });
                _validators.Add(new ValidatorItem { Id = "244", Code = "reg31", Regex = @"^[^\[\]^$\\~@%&<>{}:'""\/]*$", Description = @"请输入由中文、字母、数字，以及非特殊字符[]^$~@%&<>{}:'""/的组合" });
                _validators.Add(new ValidatorItem { Id = "245", Code = "reg32", Regex = @"^[^\[\]^$\\~@#%&<>{}:'"";]*$", Description = @"请输入由中文、字母、数字，以及非特殊字符[]^$~@#%&<>{}:'"";的组合" });
                _validators.Add(new ValidatorItem { Id = "246", Code = "reg33", Regex = @"^[^\`\<\>\\\'\%\;\(\)\&\+\#\?\{\}\|\^\[\]\~\｀\＜\＞\＂\＇\％\；\（\）\＆\＋\＼\＃\？\｛\｝\｜\＾\［\］\～\?\《\》\‘\’\…\【\】\*\$ ]*$", Description = @"请输入由中文、字母、数字，以及非特殊字符空格` < > ' % ; ( ) & + \ # ? { } | ^ [ ] ~ ｀ ＜ ＞ ＂ ＇ ％ ； （ ） ＆ ＋ ＃ ？ ｛ ｝ ｜ ＾ ［ ］ ～ • 《 》   ‘ ’ …… … 【 】*$的组合" });
                _validators.Add(new ValidatorItem { Id = "247", Code = "reg34", Regex = @"^[^`~!@#$%^*_=\[\]{};,'""|\\:\-]*$", Description = @"请输入中文、字母、数字的组合" });
                _validators.Add(new ValidatorItem { Id = "248", Code = "reg36", Regex = @"^[^\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母、数字、特殊字符的组合" });
                _validators.Add(new ValidatorItem { Id = "249", Code = "reg37", Regex = @"^[^,'""\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母、数字，可包含除,'"" 以外的字符" });
                _validators.Add(new ValidatorItem { Id = "250", Code = "reg38", Regex = @"^[^,'""{}_\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母、数字、连字符-、数点.的组合" });
                _validators.Add(new ValidatorItem { Id = "251", Code = "reg39", Regex = @"^[^`~!@#$%^*_=\[\]{};,'""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母、数字、连字符-、数点.的组合" });
                _validators.Add(new ValidatorItem { Id = "252", Code = "reg40", Regex = @"^[^ `~!@#$%^*_=\[\]{}'""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母、数字、连字符-、数点.的组合" });
                _validators.Add(new ValidatorItem { Id = "253", Code = "reg41", Regex = @"^[^？，。；、]*$", Description = @"请输入非中文全角标点符号" });
                _validators.Add(new ValidatorItem { Id = "254", Code = "reg52", Regex = @"^([0-5][0-9]|[0-9])$", Description = @"请输入0~59之间的数字" });
                _validators.Add(new ValidatorItem { Id = "255", Code = "reg42", Regex = @"^[1-9]\d{0,7}(\.\d{1,2})?$|(?!^0.0$)(?!^0.00$)^0\.(\d{1,2})$", Description = @"请输入不超过8位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "256", Code = "reg43", Regex = @"^(?!^[0](\.{1}[0]{1,2}){0,1}$)(?:[1-9]{1}[0-9]{0,12}|[0]{1})(\.{1}[0-9]{1,2}){0,1}$", Description = @"请输入不超过13位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "257", Code = "reg44", Regex = @"^([-]{0,1}[1-9][0-9]{1,2}(,[0-9]{3})*(.[0-9]{0,1})?)$", Description = @"请输入包含一位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "258", Code = "reg45", Regex = @"^[1-9]\d{0,14}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$", Description = @"请输入不超过15位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "259", Code = "reg46", Regex = @"(?!^[-]?[0]*(\.0{1,4})?$)^[-]?(([1-9]\d*)|0)(\.\d{1,4})?$", Description = @"请输入金额，格式为+/- 9,999.00" });
                _validators.Add(new ValidatorItem { Id = "260", Code = "reg47", Regex = @"^\d{4}[\/]([0][1-9]|(1[0-2]))$", Description = @"请输入日期，格式为：yyyy/mm" });
                _validators.Add(new ValidatorItem { Id = "261", Code = "reg48", Regex = @"^\d{4}[\/]([0][1-9]|(1[0-2]))[\/](0[1-9]|([012]\d)|(3[01]))$", Description = @"请输入日期，格式为：yyyy/mm/dd" });
                _validators.Add(new ValidatorItem { Id = "262", Code = "reg49", Regex = @"^(?:(?!0000)[0-9]{4}([\-\/\.]?)(?:(?:0?[1-9]|1[0-2])([\-\/\.]?)(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])([\-\/\.]?)(?:29|30)|(?:0?[13578]|1[02])([\-\/\.]?)31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([\-\/\.]?)0?2([\-\/\.]?)29)$", Description = @"请输入日期，日期分隔符支持-、/或." });
                _validators.Add(new ValidatorItem { Id = "263", Code = "reg50", Regex = @"^(?:(?!0000)[0-9]{4}\/(?:(?:0?[1-9]|1[0-2])\/(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\/(?:29|30)|(?:0?[13578]|1[02])\/31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)\/0?2([\/]?)29)( ([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9]))$", Description = @"请输入时间，时间格式为：hh/mm/ss" });
                _validators.Add(new ValidatorItem { Id = "264", Code = "reg51", Regex = @"^\d{4}[\/\-\.]([0][1-9]|(1[0-2]))[\/\-\.]([1-9]|([012]\d)|(3[01]))([ \t\n\x0B\f\r])(([0-1]{1}[0-9]{1})|([2]{1}[0-4]{1}))([:])(([0-5]{1}[0-9]{1}|[6]{1}[0]{1}))([:])((([0-5]{1}[0-9]{1}|[6]{1}[0]{1})))$", Description = @"日期时间格式为（时分秒）-/." });
                _validators.Add(new ValidatorItem { Id = "265", Code = "reg55", Regex = @"^([1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}[0-9Xx]{1}|[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)$", Description = @"请输入您的身份证号，旧版身份证号码是15位，新版身份证号码是18位" });
                _validators.Add(new ValidatorItem { Id = "266", Code = "reg57", Regex = @"^[0-9]*$", Description = @"请输入0-9的数字" });
                _validators.Add(new ValidatorItem { Id = "267", Code = "reg58", Regex = @"^[1-9]*$", Description = @"请输入1-9的数字" });
                _validators.Add(new ValidatorItem { Id = "268", Code = "reg53", Regex = @"^([0-1][0-9]|2[0-3])$", Description = @"请输入0~23之间的数字" });
                _validators.Add(new ValidatorItem { Id = "269", Code = "reg59", Regex = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", Description = @"请输入正确的电子邮箱" });
                _validators.Add(new ValidatorItem { Id = "270", Code = "reg35", Regex = @"^[\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]+$", Description = @"请输入中文" });
                _validators.Add(new ValidatorItem { Id = "271", Code = "reg60", Regex = @"^[1-9]\d{0,7}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$", Description = @"请输入数字，不超过8位整数，包含2位小数" });
                _validators.Add(new ValidatorItem { Id = "273", Code = "reg68", Regex = @"^[1-9]\d*$|^0$", Description = @"请输入由0或者自然数组成的数字" });
                _validators.Add(new ValidatorItem { Id = "274", Code = "reg71", Regex = @"^[0-9 ]+$", Description = @"由数字和空格组成" });
                _validators.Add(new ValidatorItem { Id = "275", Code = "reg69", Regex = @"[A-Za-z]", Description = @"内容中请包括一个英文字母，大小写都可" });
                _validators.Add(new ValidatorItem { Id = "276", Code = "reg70", Regex = @"\d", Description = @"输入中请包含0-9的数字之一" });
                _validators.Add(new ValidatorItem { Id = "277", Code = "reg72", Regex = @"^\S*[!-~]{1,20}\S*$", Description = @"登录名为1-20位的字符，不能以空格开始和结束" });
                _validators.Add(new ValidatorItem { Id = "278", Code = "reg73", Regex = @"^((?![{}\[\],<>@$%&^()_+=0-9]+$)(?![{}\[\],<>@$%&^()_+=a-z]+$)(?![{}\[\],<>@$%&^()_+=A-Z]+$)(?![A-Z0-9]+$)(?![A-Za-z]+$)(?![a-z0-9]+$)[{}\[\],<>@$%&^()_+=0-9a-zA-Z]{6}|(?![{}\[\],<>@$%&^()_+=]+$)(?![0-9{}\[\],.<>@$%&^()_+=\\\/]+$)(?![a-z{}\[\],.<>@$%&^()_+=\\\/]+$)(?![A-Z{}\[\],.<>@$%&^()_+=\\\/]+$)[0-9a-zA-Z{}\[\],.<>@$%&^()_+=\\\/]{8,20})$", Description = @"新的登录名为1-20位的字符，不能以空格开始和结束" });
                _validators.Add(new ValidatorItem { Id = "279", Code = "reg67", Regex = @"(?=^[0-9a-zA-Z\x21-\x2f\x3a-\x40\x5b-\x60\x7b-\x7e]{8,20}$)(?=.*[0-9])(?=.*[a-zA-Z]).*$", Description = @"密码由8-20位长度的数字，英文字母和标点符号组成，请注意您密码大小写的区分" });
                _validators.Add(new ValidatorItem { Id = "280", Code = "reg75", Regex = @"^[^\u4E00-\u9FA5\[\]\^\$\\\~\@\#\%\￥\&\<\>\{\}\:\'""]*$", Description = @"请输入字母、数字，可包含除[]^$\~@#%￥&<>{}以外的字符" });
                _validators.Add(new ValidatorItem { Id = "281", Code = "reg76", Regex = @"^([1-9]\d{0,5}(\.[0-9]{1,4})?)$|(?!^0.0000$)^0\.(\d{4})$", Description = @"最多6位整数加4位小数" });
                _validators.Add(new ValidatorItem { Id = "282", Code = "reg77", Regex = @"^[1-9]\d{0,7}(\.\d{1,4})?$|(?!^0.0$)(?!^0.00$)(?!^0.000$)(?!^0.0000$)^0\.(\d{1,4})$", Description = @"请输入不超过8位整数，4位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "283", Code = "reg78", Regex = @"^[1-9]\d{0,9}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$", Description = @"请输入不超过10位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "284", Code = "reg79", Regex = @"^[1-9]\d{0,9}\.\d{4}$|^(?!0.0000)^0\.([0-9]{4})$", Description = @"请输入不超过10位整数，4位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "285", Code = "reg80", Regex = @"^[1-9]\d+$", Description = @"（双向宝人民币金买卖）人民币金仅支持整数，交易起点数量为10克，买卖必须是大于或等于10克的整克数量" });
                _validators.Add(new ValidatorItem { Id = "286", Code = "reg81", Regex = @"^(?:[1-9]\d+(\.[0-9])?|[1-9](\.[0-9])?)$", Description = @"（双向宝美元金买卖）美元金交易起点1盎司，最小计量单位0.1盎司" });
                _validators.Add(new ValidatorItem { Id = "287", Code = "reg82", Regex = @"^[1-9][0-9]*00$", Description = @"交易面额建议为100的整数倍" });
                _validators.Add(new ValidatorItem { Id = "288", Code = "reg83", Regex = @"^[1-9]\d{0,3}(\.\d{1,4})?$|(?!^0.0$)(?!^0.00$)(?!^0.000$)(?!^0.0000$)^0\.(\d{1,4})$", Description = @"请输入整数最长四位，小数最长四位的汇率" });
                _validators.Add(new ValidatorItem { Id = "289", Code = "reg84", Regex = @"^[1-9]\d{0,3}(\.\d{1,2})?$|(?!^0.0$)(?!^0.00$)^0\.(\d{1,2})$", Description = @"请输入整数最长四位，小数最长两位的汇率" });
                _validators.Add(new ValidatorItem { Id = "291", Code = "reg85", Regex = @"^[1-9]\d{0,14}(\.\d{1,2})?$|^0\.[1-9](\d)?$|^0\.\d[1-9]$", Description = @"请输入不超过15位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "292", Code = "reg86", Regex = @"^([0]{0,1}[1-9]{1}|(1[0-2]))\d{2}$", Description = @"银行卡有效期输入错误，请更正" });
                _validators.Add(new ValidatorItem { Id = "293", Code = "reg87", Regex = @"^[1-9]\d{0,11}(\.\d{1,2})?$|^0\.[1-9](\d)?$|^0\.\d[1-9]$", Description = @"请输入不超过12位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "294", Code = "reg88", Regex = @"^[1-9]\d{0,17}(\.\d{1,2})?$|^0\.[1-9](\d)?$|^0\.\d[1-9]$", Description = @"请输入不超过18位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "295", Code = "reg89", Regex = @"^[0-9\u2E80-\u9FFF ]*$", Description = @"请输入中文或数字" });
                _validators.Add(new ValidatorItem { Id = "296", Code = "reg90", Regex = @"^[!-~]{1,20}$", Description = @"请输入1-20位字符" });
                _validators.Add(new ValidatorItem { Id = "297", Code = "reg91", Regex = @"^[!-~]*[A-Za-z]+[!-~]*$", Description = @"请输入8-20位数字、字母或标点" });
                _validators.Add(new ValidatorItem { Id = "298", Code = "reg92", Regex = @"^[A-Z0-9\/ ]*$", Description = @"请输入大写字母、数字，可包含空格和/" });
                _validators.Add(new ValidatorItem { Id = "299", Code = "reg93", Regex = @"^[1-9]$|^[1-9]\d$|^[12]\d{2}$|^3[0-5]\d$|^36[0-6]$", Description = @"请输入1-366的整数" });
                _validators.Add(new ValidatorItem { Id = "300", Code = "reg94", Regex = @"((?=^[0-9a-zA-Z~!@#$%\^&\*\(\)_\+\-=\[\]\{\}\\\|;':"",\.\<\>\/\?]{8,20}$)((?=.*[0-9])(?=.*[a-zA-Z])|(?=.*[~!@#$%\^&\*\(\)_\+\-=\[\]\{\}\\\|;':"",\.\<\>\/\?])(?=.*[a-zA-Z])|(?=.*[0-9])(?=.*[~!@#$%\^&\*\(\)_\+\-=\[\]\{\}\\\|;':"",\.\<\>\/\?])).*$)|(^[0-9]{6}$)", Description = @"密码由8-20位长度的数字，英文字母和标点符号组成，请注意您密码大小写的区分（初始密码为6位数字）" });
                _validators.Add(new ValidatorItem { Id = "301", Code = "reg95", Regex = @"^[1-9]\d{0,11}.00$|^0.00$", Description = @"请输入不超过12位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "302", Code = "reg96", Regex = @"^[1-9]\d{0,6}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$", Description = @"请输入不超过7位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "303", Code = "reg97", Regex = @"^[1-9]\d{0,4}\.\d{4}$|(?!^0.0000$)^0\.(\d{4})$", Description = @"请输入不超过5位整数，4位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "304", Code = "reg98", Regex = @"^[a-zA-Z0-9\-_]*$", Description = @"请输入字母、数字，可包含-或_" });
                _validators.Add(new ValidatorItem { Id = "305", Code = "reg99", Regex = @"^50000.00$|^[1-4]{1}\d{0,4}\.\d{2}$|^[1-9]\d{0,3}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$", Description = @"请输入不超过5万元的金额，小数点后最多2位" });
                _validators.Add(new ValidatorItem { Id = "306", Code = "reg100", Regex = @"^[1-9]\d{0,14}$", Description = @"请输入不超过15位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "307", Code = "reg101", Regex = @"^[1-9]\d{0,14}(\.\d{1})?$|^0\.[1-9]$", Description = @"请输入不超过15位整数，1位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "308", Code = "reg102", Regex = @"^[1-9]\d{0,11}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$", Description = @"请输入大于0且不超过12位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "309", Code = "reg103", Regex = @"[\d]", Description = @"请输入数字" });
                _validators.Add(new ValidatorItem { Id = "310", Code = "reg104", Regex = @"[\w]", Description = @"请输入数字或字母" });
                _validators.Add(new ValidatorItem { Id = "311", Code = "reg105", Regex = @"^[^\[\]^$\\~@#%{}:,;!'""\u003C\u003E\u0026]*$", Description = @"请不要输入非法字符[]',^$\~:,;!@?#%&<>""" });
                _validators.Add(new ValidatorItem { Id = "312", Code = "reg106", Regex = @"^[A-Za-z0-9]{1,16}(-[A-Za-z0-9]{1,16})?(,[A-Za-z0-9]{1,16}(-[A-Za-z0-9]{1,16})?)*$", Description = @"请输入1-16位数字或字母，可包含逗号或-" });
                _validators.Add(new ValidatorItem { Id = "313", Code = "reg107", Regex = @"^[1-9]\d{0,3}(\.\d{1,2})?$|^10000(\.0{1,2})?$", Description = @"请输不超过10000的整数，2位小数的数字" });
                _validators.Add(new ValidatorItem { Id = "314", Code = "reg108", Regex = @"^[ A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母、数字、中文，可包含,;!?-./" });
                _validators.Add(new ValidatorItem { Id = "315", Code = "reg109", Regex = @"^\d{1,15}(-\d{1,15})?(,\d{1,15}(-\d{1,15})?)*$", Description = @"请输入客户申请号" });
                _validators.Add(new ValidatorItem { Id = "316", Code = "reg110", Regex = @"^\S+@\S+$", Description = @"请输入有效的Email地址" });
                _validators.Add(new ValidatorItem { Id = "317", Code = "reg111", Regex = @"^[^\[\]\^\$\\\~@#%&<>{}`\*]*$", Description = @"请输入中文、字母、数字，不可包含[]^$\~@#%&<>{}`*" });
                _validators.Add(new ValidatorItem { Id = "318", Code = "reg112", Regex = @"^[0-9]$|^[0-1][0-9]$|^2[0-3]$", Description = @"请输入0~23之间的数字" });
                _validators.Add(new ValidatorItem { Id = "319", Code = "reg114", Regex = @"(^[!-~]*[A-Za-z]+[!-~]*[0-9]+[!-~]*$)|(^[!-~]*[0-9]+[!-~]*[A-Za-z]+[!-~]*$)", Description = @"密码由数字、英文字母和标点符号组成，至少包括一个英文字母和一个数字，区分大小写" });
                _validators.Add(new ValidatorItem { Id = "320", Code = "reg115", Regex = @"^[a-zA-Z0-9\u2E80-\u9FFF ]*$", Description = @"请输入字母、数字、中文、空格的组合" });
                _validators.Add(new ValidatorItem { Id = "321", Code = "reg116", Regex = @"^[^ ]*$", Description = @"请不要输入空格" });
                _validators.Add(new ValidatorItem { Id = "322", Code = "reg113", Regex = @"^[^{}\[\]%'""""`~$^_|\\:\u0000-\u001F]*$", Description = @"收款人支持新疆名称" });
                _validators.Add(new ValidatorItem { Id = "323", Code = "reg117", Regex = @"^[-_0-9A-HJ-NP-Za-hj-np-z]*$", Description = @"请输入字母(不包含oOiI)、数字、特殊字符-_的组合" });
                _validators.Add(new ValidatorItem { Id = "324", Code = "reg118", Regex = @"^[^oOiI\{\}\[\]\%\'""""\`\~\$\^\|\:\u0000-\u001F\u0080-\u00FF]*$", Description = @"不允许范围: oOiI{}[]%'""`~$^_|:等" });
                _validators.Add(new ValidatorItem { Id = "325", Code = "reg500", Regex = @"^[!-~]*$", Description = @"请输入除空格外的键盘可输入字符" });
                _validators.Add(new ValidatorItem { Id = "326", Code = "reg501", Regex = @"^(([0-1]{1}[0-9]{1})|([2]{1}[0-3]{1}))$", Description = @"请输入正确的24小时制时间" });
                _validators.Add(new ValidatorItem { Id = "327", Code = "reg502", Regex = @"^[!-~]*$", Description = @"密码:必输，1-16位，除空格外的键盘可输入字符" });
                _validators.Add(new ValidatorItem { Id = "328", Code = "reg503", Regex = @"^([0-9A-Za-z+\/=]{28,44})$", Description = @"请输入数字、字母或特殊字符+/=" });
                _validators.Add(new ValidatorItem { Id = "329", Code = "reg504", Regex = @"^[0-9]{6}$", Description = @"请输入0-9的数字" });
                _validators.Add(new ValidatorItem { Id = "330", Code = "reg505", Regex = @"^[0-9A-Za-z+\/=]{12}$", Description = @"请输入数字或字母，可包含字符+/=" });
                _validators.Add(new ValidatorItem { Id = "331", Code = "reg506", Regex = @"^[!-~]*[A-Za-z]+[!-~]*$", Description = @"请输入除空格外的任意键盘可输入字符，至少包含一位字母" });
                _validators.Add(new ValidatorItem { Id = "332", Code = "reg507", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})-(0[13578]|1[02])-(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0[13456789]|1[012])-(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-02-(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-02-29))$", Description = @"日期格式：YYYY-MM-DD" });
                _validators.Add(new ValidatorItem { Id = "333", Code = "reg508", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})\/(0[13578]|1[02])\/(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})\/(0[13456789]|1[012])\/(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})\/02\/(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\/02\/29))$", Description = @"日期格式：YYYY/MM/DD" });
                _validators.Add(new ValidatorItem { Id = "334", Code = "reg509", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})\/(0[13578]|1[02])\/(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})\/(0[13456789]|1[012])\/(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})\/02\/(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\/02\/29))$", Description = @"日期格式：YYYY/MM/DD" });
                _validators.Add(new ValidatorItem { Id = "335", Code = "reg510", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})\/(0[13578]|1[02])\/(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})\/(0[13456789]|1[012])\/(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})\/02\/(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\/02\/29))$", Description = @"日期格式：YYYY/MM/DD" });
                _validators.Add(new ValidatorItem { Id = "336", Code = "reg511", Regex = @"^([0-1][0-9]|[2][0-3])([0-5][0-9])([0-5][0-9])$", Description = @"时间格式：HHmmss" });
                _validators.Add(new ValidatorItem { Id = "337", Code = "reg512", Regex = @"^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$", Description = @"时间格式：HH:mm:ss" });
                _validators.Add(new ValidatorItem { Id = "338", Code = "reg513", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})(0[13578]|1[02])(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})(0[13456789]|1[012])(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})02(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))0229))([0-1][0-9]|[2][0-3])([0-5][0-9])([0-5][0-9])$", Description = @"时间格式：YYYYMMddHHmmss" });
                _validators.Add(new ValidatorItem { Id = "339", Code = "reg514", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})-(0[13578]|1[02])-(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0[13456789]|1[012])-(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-02-(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-02-29)) ([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$", Description = @"时间格式：YYYY-MM-ddHH:mm:ss" });
                _validators.Add(new ValidatorItem { Id = "340", Code = "reg515", Regex = @"^(\d*|\d{1,3}(,\d{3})*)(\.\d{1,2})?$", Description = @"请输入不超过18位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "341", Code = "reg516", Regex = @"^(?!^[0](\.{1}[0]{1,2}){0,1}$)(?:[1-9]{1}[0-9]{0,12}|[0]{1})(\.{1}[0-9]{1,2}){0,1}$", Description = @"请输入不超过13位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "342", Code = "reg517", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", Description = @"请输入不超过13位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "343", Code = "reg518", Regex = @"^(?!^([0,]*)(\.0{1,2})?$)^((\d{1,3}(,\d{3}){0,4})|(\d(,\d{3}){5})|(\d{1,16}))(\.\d{1,2})?$", Description = @"请输入不超过16位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "344", Code = "reg519", Regex = @"^((\d{1,3}(,\d{3}){0,3})|(\d(,\d{3}){4}))(\.\d{1,2})?$", Description = @"请输入不超过13位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "345", Code = "reg520", Regex = @"(?!^[+-]?[0,]*(\.0{1,2})?$)^([+-]?((\d{1,3}(,\d{3}){0,3})|(\d(,\d{3}){4})|(\d{1,13})))(\.\d{1,2})?$", Description = @"请输入不超过13位整数，2位小数的金额，允许输入正负号" });
                _validators.Add(new ValidatorItem { Id = "346", Code = "reg521", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", Description = @"请输入不超过13位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "347", Code = "reg522", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,16}(\.\d{1,2})?$", Description = @"请输入不超过16位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "348", Code = "reg523", Regex = @"^(?!^0*(\.0{1,8})?$)^\d{1,10}(\.\d{1,8})?$", Description = @"请输入不超过10位整数，8位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "349", Code = "reg524", Regex = @"^(?!^0*(\.0{1,5})?$)^\d{1,10}(\.\d{1,5})?$", Description = @"请输入不超过10位整数，5位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "350", Code = "reg525", Regex = @"^[^\[\]^$\\~@#%{}:'""\u003C\u003E\u0026]*$", Description = @"不允许输入[]^$\~@#%&<>{}:'""" });
                _validators.Add(new ValidatorItem { Id = "351", Code = "reg526", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^&*_=[]{};""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "352", Code = "reg527", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^&*_=[]{};""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "353", Code = "reg528", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^&*_=[]{};""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "354", Code = "reg529", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^&*_=[]{};""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "355", Code = "reg530", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^&*_=[]{};""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "356", Code = "reg531", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^&*_=[]{};""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "357", Code = "reg532", Regex = @"^[ A-Za-z0-9'"",;!:\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，允许的字符包括'"",;!:?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "358", Code = "reg533", Regex = @"^[0-9A-Za-z+\/=\r\n]+$", Description = @"请输入字母或数字，允许的字符包括+/=回车及换行符" });
                _validators.Add(new ValidatorItem { Id = "359", Code = "reg534", Regex = @"^(-1|0|[1-9]\d*)$", Description = @"允许-1、0和正整数" });
                _validators.Add(new ValidatorItem { Id = "360", Code = "reg535", Regex = @"^([1-9]\d*[0]{2}(|\.[0]{1,2}))$", Description = @"100的整数倍、非空" });
                _validators.Add(new ValidatorItem { Id = "361", Code = "reg536", Regex = @"^([0-9]{1,16}|[0-9]{1,16}\.[0-9]{1,4})$", Description = @"请输入不超过16位整数，4位小数的数字" });
                _validators.Add(new ValidatorItem { Id = "362", Code = "reg537", Regex = @"^([0]{1}[1-9]{1})|([1-2]{1}[0-9]{1})|([3]{1}[0-1]{1})$", Description = @"日期格式：DD" });
                _validators.Add(new ValidatorItem { Id = "363", Code = "reg538", Regex = @"^\d+([ \-]\d+)*$", Description = @"请输入电话号码，允许-" });
                _validators.Add(new ValidatorItem { Id = "364", Code = "reg539", Regex = @"^\S+@\S+$", Description = @"请输入有效的Email地址" });
                _validators.Add(new ValidatorItem { Id = "365", Code = "reg540", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "366", Code = "reg541", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^&*_=[]{};""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "367", Code = "reg542", Regex = @"^[0-9A-Za-z]*[A-Za-z]+[0-9A-Za-z]*$", Description = @"请输入数字或字母，至少包含一位字母" });
                _validators.Add(new ValidatorItem { Id = "368", Code = "reg543", Regex = @"^(\d*|\d{1,3}(,\d{3})*)(\.\d{1,2})?$", Description = @"跨行无卡支付交易限额整数部分最大为13位" });
                _validators.Add(new ValidatorItem { Id = "369", Code = "reg544", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "370", Code = "reg545", Regex = @"^[A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含,;!?-./" });
                _validators.Add(new ValidatorItem { Id = "371", Code = "reg546", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()" });
                _validators.Add(new ValidatorItem { Id = "372", Code = "reg547", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()" });
                _validators.Add(new ValidatorItem { Id = "373", Code = "reg548", Regex = @"^(\(\d{3,4}\)|\d{3,4}-|\d{3,4}|\s)?\d{7,8}(\-\d{2,4})?$", Description = @"请输入电话，形如010-81111111-0001" });
                _validators.Add(new ValidatorItem { Id = "374", Code = "reg549", Regex = @"^\S+@\S+$", Description = @"请输入有效的Email地址" });
                _validators.Add(new ValidatorItem { Id = "376", Code = "reg551", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "379", Code = "reg554", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "380", Code = "reg555", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "381", Code = "reg556", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "382", Code = "reg557", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "383", Code = "reg558", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "385", Code = "reg560", Regex = @"^(?!^0)^\d{1,8}$", Description = @"请输入首位不为零的数字" });
                _validators.Add(new ValidatorItem { Id = "386", Code = "reg561", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})\/(0[13578]|1[02])\/(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})\/(0[13456789]|1[012])\/(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})\/02\/(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\/02\/29))$", Description = @"日期格式：YYYY/MM/DD" });
                _validators.Add(new ValidatorItem { Id = "387", Code = "reg562", Regex = @"^[^,'""{}_\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符,'""{}_" });
                _validators.Add(new ValidatorItem { Id = "388", Code = "reg563", Regex = @"^[^,'""{}_\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符,'""{}_" });
                _validators.Add(new ValidatorItem { Id = "390", Code = "reg565", Regex = @"^[^,'""{}_\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符,'""{}_" });
                _validators.Add(new ValidatorItem { Id = "391", Code = "reg566", Regex = @"^\S+@\S+$", Description = @"请输入有效的Email地址" });
                _validators.Add(new ValidatorItem { Id = "392", Code = "reg567", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})\/(0[13578]|1[02])\/(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})\/(0[13456789]|1[012])\/(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})\/02\/(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\/02\/29)) ([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$", Description = @"日期格式：YYYY/MM/dd HH:mm:ss" });
                _validators.Add(new ValidatorItem { Id = "393", Code = "reg568", Regex = @"^[^`<>""'%;()&+\\#\?{}\|^\[\]~｀＜＞＂＇％；（）＆＋＼＃？｛｝｜＾［］～·《》“”‘’……【】、]*$", Description = @"不允许字符`<>""'%;()&+\#?{}|^[]~" });
                _validators.Add(new ValidatorItem { Id = "394", Code = "reg569", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "395", Code = "reg570", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "396", Code = "reg571", Regex = @"^[A-Za-z]{1,3}$", Description = @"请输入字母" });
                _validators.Add(new ValidatorItem { Id = "397", Code = "reg572", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "398", Code = "reg573", Regex = @"^[0-9]*$", Description = @"请输入数字" });
                _validators.Add(new ValidatorItem { Id = "399", Code = "reg574", Regex = @"^[\(\)\+\ \-\d]+$", Description = @"请输入手机号，可包含()+-空格" });
                _validators.Add(new ValidatorItem { Id = "400", Code = "reg575", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "401", Code = "reg576", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "404", Code = "reg579", Regex = @"^(\d{15}|\d{18}|\d{17}[X|x])$", Description = @"请输入证件号码" });
                _validators.Add(new ValidatorItem { Id = "405", Code = "reg580", Regex = @"^[ A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含,;!?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "407", Code = "reg582", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "408", Code = "reg583", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "409", Code = "reg584", Regex = @"^[^\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许输入汉字" });
                _validators.Add(new ValidatorItem { Id = "410", Code = "reg585", Regex = @"^[ A-Za-z0-9',.()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.()和空格" });
                _validators.Add(new ValidatorItem { Id = "411", Code = "reg586", Regex = @"^[ A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含,;!?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "412", Code = "reg587", Regex = @"^[^\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许输入汉字" });
                _validators.Add(new ValidatorItem { Id = "413", Code = "reg588", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^&*_=[]{};""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "414", Code = "reg589", Regex = @"^[ A-Za-z0-9\/-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "415", Code = "reg590", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "416", Code = "reg591", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "417", Code = "reg592", Regex = @"^([0-9A-Za-z]{13})|([0-9A-Za-z]{15})$", Description = @"请输入13位或15位的数字或字母" });
                _validators.Add(new ValidatorItem { Id = "418", Code = "reg593", Regex = @"(?!^0*(\.0{1,2})?$)^\d{1,10}(\.\d{1,2})?$", Description = @"请输入不超过10位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "419", Code = "reg594", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})(0[13578]|1[02])(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})(0[13456789]|1[012])(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})02(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))0229))$", Description = @"日期格式：YYYYMMDD" });
                _validators.Add(new ValidatorItem { Id = "420", Code = "reg595", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026]*$", Description = @"不允许非法字符`~!@#$%^&*_=[]{};\""<>|\：-" });
                _validators.Add(new ValidatorItem { Id = "421", Code = "reg596", Regex = @"^([0-9A-Za-z]{10})|([0-9A-Za-z]{13})|([0-9A-Za-z]{15})$", Description = @"请输入10位，13位或15位数字或字母" });
                _validators.Add(new ValidatorItem { Id = "422", Code = "reg597", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "423", Code = "reg598", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "424", Code = "reg599", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "425", Code = "reg600", Regex = @"^[A-Z0-9]{8}([A-Z0-9]{3})?$", Description = @"请输入8位或11位的大写字母或数字" });
                _validators.Add(new ValidatorItem { Id = "426", Code = "reg601", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "427", Code = "reg602", Regex = @"^[\u4E00-\u9FA5]*$", Description = @"请输入中文" });
                _validators.Add(new ValidatorItem { Id = "428", Code = "reg603", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "429", Code = "reg604", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "430", Code = "reg605", Regex = @"^[\w]*$", Description = @"请输入数字或字母" });
                _validators.Add(new ValidatorItem { Id = "431", Code = "reg606", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "433", Code = "reg608", Regex = @"^\d{1,20}(-\d{1,20})?(,\d{1,20}(-\d{1,20})?)*$", Description = @"请输入1-20位数字，可输入多个，用英文逗号或-隔开" });
                _validators.Add(new ValidatorItem { Id = "434", Code = "reg609", Regex = @"^[A-Za-z0-9]{1,16}(-[A-Za-z0-9]{1,16})?(,[A-Za-z0-9]{1,16}(-[A-Za-z0-9]{1,16})?)*$", Description = @"请输入1-16位字母或数字，可输入多组，用英文逗号或-隔开" });
                _validators.Add(new ValidatorItem { Id = "435", Code = "reg610", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "436", Code = "reg611", Regex = @"^\S+@\S+$", Description = @"请输入有效的Email地址" });
                _validators.Add(new ValidatorItem { Id = "437", Code = "reg612", Regex = @"^\d+([ \-]\d+)*$", Description = @"请输入数字，可包含空格或-" });
                _validators.Add(new ValidatorItem { Id = "438", Code = "reg613", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "439", Code = "reg614", Regex = @"^[ A-Za-z0-9'"",;!:\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含字符'"",;!:?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "440", Code = "reg615", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})(0[13578]|1[02])(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})(0[13456789]|1[012])(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})02(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))0229))([0-1][0-9]|[2][0-3])([0-5][0-9])([0-5][0-9])$", Description = @"时间格式：YYYYMMddHHmmss" });
                _validators.Add(new ValidatorItem { Id = "441", Code = "reg616", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})(0[13578]|1[02])(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})(0[13456789]|1[012])(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})02(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))0229))([0-1][0-9]|[2][0-3])([0-5][0-9])([0-5][0-9])$", Description = @"时间格式：YYYYMMddHHmmss" });
                _validators.Add(new ValidatorItem { Id = "444", Code = "reg619", Regex = @"^(?!(\d{4}-\d{2}\/\d{2})?$|(\d{4}\/\d{2}-\d{2})?$)^((((1[6-9]|[2-9]\d)\d{2})[-\/](0[13578]|1[02])[-\/](0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})[-\/](0[13456789]|1[012])[-\/](0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})[-\/]02[-\/](0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))[-\/]02[-\/]29))$", Description = @"日期格式：YYYY/MM/dd或YYYY-MM-dd" });
                _validators.Add(new ValidatorItem { Id = "445", Code = "reg620", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "446", Code = "reg621", Regex = @"^([0-9A-Za-z]{10})|([0-9A-Za-z]{13})$", Description = @"请输入10位或13位的数字或字母" });
                _validators.Add(new ValidatorItem { Id = "448", Code = "reg623", Regex = @"^[1-9]{1}[0-9]{1,8}$", Description = @"请输入整数" });
                _validators.Add(new ValidatorItem { Id = "449", Code = "reg624", Regex = @"^[\u4E00-\u9FA5]*$", Description = @"请输入中文" });
                _validators.Add(new ValidatorItem { Id = "450", Code = "reg625", Regex = @"^[A-Za-z0-9\/\-\+\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-+?().,'" });
                _validators.Add(new ValidatorItem { Id = "451", Code = "reg626", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,12}(\.\d{1,2})?$", Description = @"请输入不超过12位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "452", Code = "reg627", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "453", Code = "reg628", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.\,\']*$", Description = @"请输入字母或数字，可包含/-[+]?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "454", Code = "reg629", Regex = @"^[A-Za-z0-9',.\-\/()]*$", Description = @"请输入数字或字母，可包含',.-/()" });
                _validators.Add(new ValidatorItem { Id = "455", Code = "reg630", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含字符',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "456", Code = "reg631", Regex = @"^[A-Za-z0-9',.\-\/()]*$", Description = @"请输入数字或字母，可包含',.-/()" });
                _validators.Add(new ValidatorItem { Id = "457", Code = "reg632", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "458", Code = "reg633", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "459", Code = "reg634", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "460", Code = "reg635", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "461", Code = "reg636", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "462", Code = "reg637", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,16}(\.\d{1,2})?$", Description = @"请输入不超过16位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "463", Code = "reg638", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})\/(0[13578]|1[02])\/(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})\/(0[13456789]|1[012])\/(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})\/02\/(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\/02\/29))$", Description = @"日期格式：YYYY/MM/DD" });
                _validators.Add(new ValidatorItem { Id = "464", Code = "reg639", Regex = @"^\d{1,15}(-\d{1,15})?(,\d{1,15}(-\d{1,15})?)*$", Description = @"请输入1-15位数字，可输入多组，用逗号和-隔开" });
                _validators.Add(new ValidatorItem { Id = "465", Code = "reg640", Regex = @"^[^{}\[\]\%\'""\u0000-\u001F]*$", Description = @"请输入字符，但不能包含{}[]%'""等" });
                _validators.Add(new ValidatorItem { Id = "466", Code = "reg641", Regex = @"^[ A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含,;!?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "467", Code = "reg642", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})\/(0[13578]|1[02])\/(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})\/(0[13456789]|1[012])\/(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})\/02\/(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\/02\/29)) ([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$", Description = @"时间格式：YYYY/MM/DD HH:MM:SS" });
                _validators.Add(new ValidatorItem { Id = "468", Code = "reg643", Regex = @"^\d{4}(?:0[1-9]|1[0-2])$", Description = @"日期格式：YYYYMM" });
                _validators.Add(new ValidatorItem { Id = "469", Code = "reg644", Regex = @"^((1[6-9]|[2-9]\d)\d{2})(0[123456789]|1[012])$", Description = @"日期格式：YYYYMM" });
                _validators.Add(new ValidatorItem { Id = "470", Code = "reg645", Regex = @"^([+-])?\d{1,16}(\.\d{1,2})?$", Description = @"请输入不超过16位整数，2位小数的金额，可带正负号" });
                _validators.Add(new ValidatorItem { Id = "471", Code = "reg646", Regex = @"^[^{}\[\]\%\'""\u0000-\u001F]*$", Description = @"请输入字符，但不能包含{}[]%'""等" });
                _validators.Add(new ValidatorItem { Id = "472", Code = "reg647", Regex = @"^[^{}\[\]\%\'""\u0000-\u001F]*$", Description = @"请输入字符，但不能包含{}[]%'""等" });
                _validators.Add(new ValidatorItem { Id = "473", Code = "reg648", Regex = @"^[^oOiI{}\[\]%'""`~$^_|\\:\u0000-\u001F\u0080-\u00FF]*$", Description = @"请输入字符，但不能包含oOiI{}[]%'""`~$^_|\:等" });
                _validators.Add(new ValidatorItem { Id = "474", Code = "reg649", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "475", Code = "reg650", Regex = @"^[ A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含,;!?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "476", Code = "reg651", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,12}(\.\d{1,2})?$", Description = @"请输入不超过12位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "477", Code = "reg652", Regex = @"^[A-Za-z0-9',.\-\/()]*$", Description = @"请输入数字或字母，可包含',.-/()" });
                _validators.Add(new ValidatorItem { Id = "478", Code = "reg653", Regex = @"^([1-9]\d{0,8})|1\d{9}|(2[1][0-4][0-7][0-4][0-8][0-3][0-6][0-4][0-7])|20\d{8}$", Description = @"请输入1-2147483647的数字" });
                _validators.Add(new ValidatorItem { Id = "479", Code = "reg654", Regex = @"^4\d{4}$", Description = @"请输入以4开头的5位数字" });
                _validators.Add(new ValidatorItem { Id = "480", Code = "reg655", Regex = @"^[0-9A-HJ-NP-Za-hj-np-z*\/-]*$", Description = @"请输入字母(不包含oOiI)或数字，可包含*/-" });
                _validators.Add(new ValidatorItem { Id = "481", Code = "reg656", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,11}(\.\d{1,2})?$", Description = @"请输入不超过11位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "482", Code = "reg657", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,11}(\.\d{1,2})?$", Description = @"请输入不超过11位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "483", Code = "reg658", Regex = @"^((((1[6-9]|[2-9]\d)\d{2})(0[13578]|1[02])(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})(0[13456789]|1[012])(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})02(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))0229))$", Description = @"日期格式：YYYYMMDD" });
                _validators.Add(new ValidatorItem { Id = "484", Code = "reg659", Regex = @"^[ A-Za-z0-9',;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',;!?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "486", Code = "reg661", Regex = @"^[ A-Za-z0-9',.()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母和数字，可包含',.()和空格" });
                _validators.Add(new ValidatorItem { Id = "487", Code = "reg662", Regex = @"^[^{}\[\]%'""`~$^_|\\:\u0000-\u001F\u0080-\u00FF]*$", Description = @"请输入字符，但不能包含:{}[]%'""`~$^_|\: 等" });
                _validators.Add(new ValidatorItem { Id = "488", Code = "reg663", Regex = @"^[0-9A-HJ-NP-Za-hj-np-z*\/-]*$", Description = @"请输入字母（不包含oOiI）或数字，可包含*/-" });
                _validators.Add(new ValidatorItem { Id = "489", Code = "reg664", Regex = @"^[^{}\[\]%'""`~$^_|\\:\u0000-\u001F\u0080-\u00FF]*$", Description = @"请输入字符，但不能包含{}[]%'""`~$^_|\: 等" });
                _validators.Add(new ValidatorItem { Id = "490", Code = "reg665", Regex = @"^[ A-Za-z0-9',;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',;!?-./或空格" });
                _validators.Add(new ValidatorItem { Id = "491", Code = "reg666", Regex = @"^[0-9A-Za-z*\/_-]*$", Description = @"请输入字母或数字，可包含*/_-" });
                _validators.Add(new ValidatorItem { Id = "492", Code = "reg667", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "493", Code = "reg668", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "494", Code = "reg669", Regex = @"^[0-9]{1,3}[\.]{1}[0-9]{1,3}[\.]{1}[0-9]{1,3}[\.]{1}[0-9]{1,3}$", Description = @"请输入IP地址" });
                _validators.Add(new ValidatorItem { Id = "497", Code = "reg672", Regex = @"^([a-zA-Z]+|[0-9]+[a-zA-Z]+)[a-zA-Z0-9]*$", Description = @"请输入字母或数字，至少包含一位字母" });
                _validators.Add(new ValidatorItem { Id = "498", Code = "reg673", Regex = @"^[^\[\]^$\\~@#%{}:'""\u003C\u003E\u0026]*$", Description = @"请输入字符，但不能包含[]^$\~@#%{}:'""等" });
                _validators.Add(new ValidatorItem { Id = "499", Code = "reg674", Regex = @"^([0-9]{15})|([0-9]{16})|([0-9]{19})$", Description = @"请输入15、16或19位数字" });
                _validators.Add(new ValidatorItem { Id = "502", Code = "reg677", Regex = @"^[A-Za-z0-9\u4E00-\u9FA5]*$", Description = @"请输入中文、字母或数字" });
                _validators.Add(new ValidatorItem { Id = "503", Code = "reg678", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,18}(\.\d{1,2})?$", Description = @"请输入不超过18位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "504", Code = "reg679", Regex = @"^[^{}\[\]%'""\u0000-\u001F]*$", Description = @"请输入字符，但不能包含{}[]%'""等" });
                _validators.Add(new ValidatorItem { Id = "505", Code = "reg680", Regex = @"^[^\[\]^$\\~@#%{}:'""\u003C\u003E\u0026]*$", Description = @"请输入字符，但不能包含[]$\~@#%{}:'""等" });
                _validators.Add(new ValidatorItem { Id = "506", Code = "reg681", Regex = @"^[^{}\[\]%'""\u0000-\u001F]*$", Description = @"请输入字符，但不能包含{}[]%'""等" });
                _validators.Add(new ValidatorItem { Id = "507", Code = "reg682", Regex = @"^\S+@\S+$", Description = @"请输入有效的Email地址" });
                _validators.Add(new ValidatorItem { Id = "508", Code = "reg683", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "509", Code = "reg684", Regex = @"^[ A-Za-z0-9'"",;!:\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含'"",;!:?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "510", Code = "reg685", Regex = @"^[^{}\[\]%'""`~$^_|\\:\u0000-\u001F]*$", Description = @"请输入字符，但不能包含{}[]%'""`~$^_|\:等" });
                _validators.Add(new ValidatorItem { Id = "511", Code = "reg686", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "512", Code = "reg687", Regex = @"^[-_0-9A-HJ-NP-Za-hj-np-z]*$", Description = @"请输入字母（不包括oiOI）或数字，可包含字符-_" });
                _validators.Add(new ValidatorItem { Id = "513", Code = "reg688", Regex = @"^[^oOiI{}\[\]%'""`~$^|\\:\u0000-\u001F\u0080-\u00FF]*$", Description = @"请输入字符，但不能包含oOiI{}[]%'""`~$^|\:等" });
                _validators.Add(new ValidatorItem { Id = "514", Code = "reg689", Regex = @"^([1-9]{1})([0-9]{1,3})?$", Description = @"请输入1-9999的任意数字" });
                _validators.Add(new ValidatorItem { Id = "515", Code = "reg119", Regex = @"^[1-9]\d{0,9}(\.\d{1,2})?$", Description = @"请输入不超过10位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "516", Code = "reg120", Regex = @"^(?:[1-9]\d{0,12}\.\d{1}$|^0\.([1-9]{1}))$", Description = @"请输入不超过13位整数，1位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "517", Code = "reg121", Regex = @"^[1-9]\d{0,10}(\.\d{1,2})?$|^0\.[1-9](\d)?$|^0\.\d[1-9]$", Description = @"请输入不超过11位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "518", Code = "reg122", Regex = @"^[^\[\]\^\$\~@#%&<>\{\}:\\'""【】￥……~《》\：\“\‘\”［］＾＄～＠＃％＆＜＞｛｝：\＼＇＂\nａ-ｚＡ-Ｚ０-９]*$", Description = @"请输入中文、半角字母、半角数字，不可包含[]^$\~@#%&<>{}:'""，不允许输入回车" });
                _validators.Add(new ValidatorItem { Id = "519", Code = "reg123", Regex = @"^[1-9]\d{0,17}(\.\d)?$|^0\.[1-9]$", Description = @"请输入不超过18位整数，1位小数的数字" });
                _validators.Add(new ValidatorItem { Id = "520", Code = "reg124", Regex = @"^[1-9]\d{0,14}\.\d{2}$|^0\.(\d{2})$", Description = @"请输入不超过15位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "521", Code = "reg125", Regex = @"^[0-9]{15}$|^[0-9]{16}$|^[0-9]{19}$", Description = @"请输入15、16或19位的银行卡卡号" });
                _validators.Add(new ValidatorItem { Id = "522", Code = "reg126", Regex = @"^[^\[\]^$\\~@#%&<>{}:'"";\uFF00-\uFFFF]*$", Description = @"请输入由中文、字母、数字，以及非特殊字符[]^$~@#%&<>{}:'"";的组合" });
                _validators.Add(new ValidatorItem { Id = "523", Code = "reg127", Regex = @"^[^a-zA-Zａ-ｚＡ-Ｚ]*$", Description = @"请输入中文、数字或标点符号" });
                _validators.Add(new ValidatorItem { Id = "524", Code = "reg128", Regex = @"^[a-zA-Zａ-ｚＡ-Ｚ,]*$", Description = @"只允许输入英文字符和英文半角逗号','" });
                _validators.Add(new ValidatorItem { Id = "525", Code = "reg129", Regex = @"^[^ａ-ｚＡ-Ｚ０-９\n]*$", Description = @"不允许输入全角英文、数字，不允许输入回车" });
                _validators.Add(new ValidatorItem { Id = "526", Code = "reg130", Regex = @"^[A-Z0-9\(\)\+\'\,\.\?\/ ]*$", Description = @"请输入大写字母、数字，可包含空格和()+',.?/" });
                _validators.Add(new ValidatorItem { Id = "527", Code = "reg131", Regex = @"^[!-~]*[a-zA-Z]+[!-~]*$", Description = @"用户名由数字，英文字母和标点符号组成，至少包括1位英文字母，区分大小写" });
                _validators.Add(new ValidatorItem { Id = "528", Code = "reg132", Regex = @"^[1-9]\d{0,11}$", Description = @"请输入大于等于1且不超过12位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "529", Code = "reg133", Regex = @"^[^\[\]\^\$\~@#%&<>\{\}\［\］\＾\＄\～＠＃％＆＜＞\｛\｝\n]*$", Description = @"请输入由中文、字母、数字，以及非特殊字符[]^$~@#%&<>{}的组合，不允许输入回车" });
                _validators.Add(new ValidatorItem { Id = "530", Code = "reg134", Regex = @"^[1-9]\d{0,11}\.\d{1}$|^0\.([1-9])$", Description = @"请输入不超过12位整数，1位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "531", Code = "reg135", Regex = @"^[a-zA-Z,]*$", Description = @"只允许输入英文字符和英文半角逗号','" });
                _validators.Add(new ValidatorItem { Id = "532", Code = "reg136", Regex = @"^[1-9]\d{0,14}$|^0$", Description = @"请输入不超过15位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "533", Code = "reg137", Regex = @"^[1-9]\d{0,12}\.\d{1}$|^0\.\d$", Description = @"金额最长13位整数+1位小数" });
                _validators.Add(new ValidatorItem { Id = "534", Code = "reg690", Regex = @"^\d*$", Description = @"请输入数字" });
                _validators.Add(new ValidatorItem { Id = "535", Code = "reg138", Regex = @"^[^\[\]^$\\~@#%￥&<>{}]*$", Description = @"请输入中文、字母、数字，以及非特殊字符[]^$\~@#%￥&<>{}的组合" });
                _validators.Add(new ValidatorItem { Id = "536", Code = "reg139", Regex = @"^[1-9]\d{0,11}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$|^0.00$", Description = @"请输入不超过12位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "537", Code = "reg140", Regex = @"^[^`~!@#$%\^\*_=\[\]{};,\'""\|\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母、数字，可包含除`~!@#$%^*_=[]{};,'""|:-以外的字符" });
                _validators.Add(new ValidatorItem { Id = "538", Code = "reg141", Regex = @"^[1-9][0-9]{0,12}00\.00$", Description = @"请输入不超过15位整数的金额，且为100的整数倍" });
                _validators.Add(new ValidatorItem { Id = "539", Code = "reg142", Regex = @"^[^\[\]\^\$\\\~@#%&<>\{\}:'""]*$", Description = @"请输入由中文、字母、数字，以及非特殊字符[]^$\~@#%&<>{}:'""的组合" });
                _validators.Add(new ValidatorItem { Id = "540", Code = "reg143", Regex = @"^[A-Z0-9\(\)\+',\.\?\/ ]*$", Description = @"请输入大写英文字母、数字，标点符号或空格" });
                _validators.Add(new ValidatorItem { Id = "541", Code = "reg144", Regex = @"^[!-~]*[a-zA-Z0-9]+[!-~]*$", Description = @"密码由数字、英文字母和标点符号组成，至少包括一个英文字母或一个数字，区分大小写" });
                _validators.Add(new ValidatorItem { Id = "542", Code = "reg145", Regex = @"^[1-9]\d{0,8}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$", Description = @"请输入数字，不超过9位整数，包含2位小数" });
                _validators.Add(new ValidatorItem { Id = "543", Code = "reg146", Regex = @"^[1-9]\d{0,11}$|^0$", Description = @"请输入不超过12位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "544", Code = "reg147", Regex = @"^[1-9]\d{0,11}(\.\d{1,2})?$|^0\.[1-9](\d)?$|^0\.\d[1-9]$|^0$|^0.0$|^0.00$", Description = @"请输入不超过12位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "545", Code = "reg148", Regex = @"^[1-9]\d{0,14}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$|^0.00$", Description = @"请输入不超过15位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "546", Code = "reg149", Regex = @"^[1-9]$|^[1-9]\d$", Description = @"请输入1-99的整数" });
                _validators.Add(new ValidatorItem { Id = "547", Code = "reg150", Regex = @"^[1-9]\d{0,11}.00$", Description = @"请输入不超过12位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "548", Code = "reg151", Regex = @"^[0-9]$|^[0-1][0-9]$|^2[0-3]$", Description = @"委托小时必须在0~23之间" });
                _validators.Add(new ValidatorItem { Id = "549", Code = "reg152", Regex = @"^[1-9]\d{0,12}\.\d{3}$|^0\.(\d{2}[1-9])$|^0\.([1-9]\d{2})$", Description = @"请输入不超过13位整数，3位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "550", Code = "reg153", Regex = @"^[1-9]\d{0,9}$", Description = @"请输入不超过10位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "551", Code = "reg154", Regex = @"^[!-~]*$", Description = @"请输入字母、数字以及半角字符的组合" });
                _validators.Add(new ValidatorItem { Id = "552", Code = "reg155", Regex = @"^[1-9]\d{0,13}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$", Description = @"请输入不超过14位整数，2位小数的金额，且不允许为0" });
                _validators.Add(new ValidatorItem { Id = "553", Code = "reg156", Regex = @"^[1-9]\d{0,13}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$|^0.00$", Description = @"请输入不超过14位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "554", Code = "reg157", Regex = @"^[0]?[1-9]$|^[1][0-2]$", Description = @"请输入“1”至“12”中任一个数值" });
                _validators.Add(new ValidatorItem { Id = "555", Code = "reg158", Regex = @"^[0]?[1-9]$|^[12][0-9]$|^[3][0]$", Description = @"请输入“1”至“30”中任一个数值" });
                _validators.Add(new ValidatorItem { Id = "556", Code = "reg159", Regex = @"^[1-9]\d{0,2}(\.\d{1,4})?$|(?!^0.0$)(?!^0.00$)(?!^0.000$)(?!^0.0000$)^0.\d{0,4}$", Description = @"汇率整数部分最长3位，小数最长4位" });
                _validators.Add(new ValidatorItem { Id = "557", Code = "reg160", Regex = @"^[1-9]\d{0,2}(\.\d{1,2})?$|^0.\d{0,1}[1-9]$", Description = @"汇率整数部分最长3位，小数最长2位" });
                _validators.Add(new ValidatorItem { Id = "558", Code = "reg161", Regex = @"^[1-9]\d{0,13}$", Description = @"请输入不超过14位整数的金额，且不允许为0" });
                _validators.Add(new ValidatorItem { Id = "559", Code = "reg162", Regex = @"^[1-9]\d{0,13}$|^0$", Description = @"请输入不超过14位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "560", Code = "reg163", Regex = @"^[0-9]{16}$|^[0-9]{19}$", Description = @"请输入0-9的数字，长度为16或19位" });
                _validators.Add(new ValidatorItem { Id = "561", Code = "reg691", Regex = @"^[A-Za-z0-9'""\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]{1,80}$", Description = @"请输入中文、字母或数字，可包含'""-./" });
                _validators.Add(new ValidatorItem { Id = "562", Code = "reg692", Regex = @"^[A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]{1,30}$", Description = @"请输入中文、字母或数字，可包含,;!?-./" });
                _validators.Add(new ValidatorItem { Id = "563", Code = "reg164", Regex = @"^[a-zA-Z0-9\u4E00-\u9FFF',\.\-\/\(\)’‘，。、（）?!"":;？！“”：； ]*$", Description = @"请输入字母、数字、中文，可包含',.-/()?!"":;" });
                _validators.Add(new ValidatorItem { Id = "564", Code = "reg693", Regex = @"(?!^0*(\.0{1,2})?$)^\d{1,14}(\.\d{1,2})?$", Description = @"请输入不超过14位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "565", Code = "reg165", Regex = @"^[!-~\u4E00-\u9FFF]*[\u4E00-\u9FFF]+[!-~\u4E00-\u9FFF]*$", Description = @"请至少输入一个中文字符，不支持全角字符和回车的录入" });
                _validators.Add(new ValidatorItem { Id = "566", Code = "reg694", Regex = @"(?!^0*(\.0{1,2})?$)^\d{1,14}(\.\d{1,2})?$", Description = @"请输入不超过14位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "567", Code = "reg695", Regex = @"^[^$\\]*$", Description = @"请输入字符，但不能包含\和$" });
                _validators.Add(new ValidatorItem { Id = "568", Code = "reg696", Regex = @"(^[!-~]*[A-Za-z]+[!-~]*[0-9]+[!-~]*$)|(^[!-~]*[0-9]+[!-~]*[A-Za-z]+[!-~]*$)", Description = @"请输入数字和字母的组合" });
                _validators.Add(new ValidatorItem { Id = "569", Code = "reg697", Regex = @"^[A-Za-z0-9]*$", Description = @"请输入字母或数字" });
                _validators.Add(new ValidatorItem { Id = "570", Code = "reg698", Regex = @"^[ A-Za-z0-9\/\-\[\+\]\?\(\)\.,']{1,8}-[ A-Za-z0-9\/\-\[\+\]\?\(\)\.,']{1}$", Description = @"请输入组织机构代码" });
                _validators.Add(new ValidatorItem { Id = "571", Code = "reg699", Regex = @"^[A-Za-z0-9',.\-\/()+{}:]*$", Description = @"请输入字母或数字，可包含',.-/()+{}:" });
                _validators.Add(new ValidatorItem { Id = "572", Code = "reg700", Regex = @"(?!^0*(\.0{1,2})?$)^\d{1,3}(\.\d{1,3})?$", Description = @"请输入不超过3位整数，3位小数的数字" });
                _validators.Add(new ValidatorItem { Id = "573", Code = "reg701", Regex = @"^[ A-Za-z0-9',.\+\{\}\?:\-\/\(\)\s\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含',.+{}?:-/()以及空白字符" });
                _validators.Add(new ValidatorItem { Id = "574", Code = "reg702", Regex = @"^[ A-Za-z0-9-(){}:.,'\s\?\+\/]*$", Description = @"请输入字母或数字，可包含-(){}:.,'?+/或空格" });
                _validators.Add(new ValidatorItem { Id = "575", Code = "reg703", Regex = @"^[B|C]{1}[0-9]{13}$", Description = @"请输入海关联系单号，14位字符，前面是以B或C开头" });
                _validators.Add(new ValidatorItem { Id = "576", Code = "reg704", Regex = @"^(01|02|03|04|05|06|07|08|09|10|11|12){1}(\d{5})$|^([0]{7})$", Description = @"请输入海关凭单号" });
                _validators.Add(new ValidatorItem { Id = "577", Code = "reg705", Regex = @"^[ A-Za-z0-9'\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，可包含'" });
                _validators.Add(new ValidatorItem { Id = "578", Code = "reg706", Regex = @"^\d{1,15}(,\d{1,15})*$", Description = @"请输入1-15位数字，可输入多组，用英文逗号隔开" });
                _validators.Add(new ValidatorItem { Id = "579", Code = "reg166", Regex = @"^[0-9a-zA-Z\u2E80-\u9FFF\.\-]*[a-zA-Z\u2E80-\u9FFF\.\-]+[0-9a-zA-Z\u2E80-\u9FFF\.\-]*$", Description = @"请输入字母、数字、中文，但不包含~`!@#$%^&*()_+{}[];:’<>,/?|”特殊字符或全数字" });
                _validators.Add(new ValidatorItem { Id = "580", Code = "reg707", Regex = @"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$", Description = @"时间格式：HH:mm" });
                _validators.Add(new ValidatorItem { Id = "581", Code = "reg167", Regex = @"^[a-zA-Z0-9\u2E80-\u9FFF\(\)]*$", Description = @"请输入字母、数字、中文，可包含()" });
                _validators.Add(new ValidatorItem { Id = "582", Code = "reg708", Regex = @"^([1-9]{1})([0-9]{1,3})?$", Description = @"请输入账户名称" });
                _validators.Add(new ValidatorItem { Id = "583", Code = "reg709", Regex = @"(?!^0*(\.0{1,2})?$)^\d{1,3}(\.\d{1,6})?$", Description = @"请输入不超过3位整数，6位小数的数字" });
                _validators.Add(new ValidatorItem { Id = "584", Code = "reg710", Regex = @"(?!^[+-]?d*(\.d{1,6})?$)^[+-]?\d{1,3}(\.\d{1,6})?$", Description = @"请输入不超过3位整数，6位小数的数字，可带正负号" });
                _validators.Add(new ValidatorItem { Id = "585", Code = "reg711", Regex = @"^((?!，|。|　)[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF])*$", Description = @"请输入中文、字母或数字，可包含',.-/()" });
                _validators.Add(new ValidatorItem { Id = "586", Code = "reg712", Regex = @"^((?!，|。|　)[ A-Za-z0-9',*.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF])*$", Description = @"请输入中文、字母或数字，可包含',*.-/()" });
                _validators.Add(new ValidatorItem { Id = "587", Code = "reg168", Regex = @"^[A-Z0-9\(\)\+:',.\/\? ]*$", Description = @"请输入大写字母、数字，可包含空格及()+:',./?标点符号" });
                _validators.Add(new ValidatorItem { Id = "588", Code = "reg713", Regex = @"^\d{1,15}(\.\d{1,2})?$", Description = @"请输入不超过15位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "589", Code = "reg714", Regex = @"^[1-9][0-9]{0,3}$", Description = @"请输入1-9999之间的数字" });
                _validators.Add(new ValidatorItem { Id = "590", Code = "reg715", Regex = @"^\d{1,15}(-\d{1,15})?(,\d{1,15}(-\d{1,15})?)*$", Description = @"请输入1-15位的数字，可输入多组，用英文逗号或-隔开" });
                _validators.Add(new ValidatorItem { Id = "591", Code = "reg716", Regex = @"^[^\[\]^$\\~@#%{}:'""\u003C\u003E\u0026]*$", Description = @"请输入字符，但不能包含[]^$\~@#%{}:'""等" });
                _validators.Add(new ValidatorItem { Id = "592", Code = "reg717", Regex = @"^[^{}\x26\x3c\[\]%'@#\>""~$^\\:\u0000-\u001F\u0080-\u00FF]*$", Description = @"请输入字符，但不能包含{}[]%'@#>""~$^\:等" });
                _validators.Add(new ValidatorItem { Id = "593", Code = "reg718", Regex = @"^[ A-Za-z0-9\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字" });
                _validators.Add(new ValidatorItem { Id = "594", Code = "reg719", Regex = @"^[1-9]\d{0,12}$", Description = @"请输入不超过13位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "595", Code = "reg169", Regex = @"^[^\[\]^$\\~@#%￥&<>{}:'""-]*$", Description = @"输入中文、字母、数字，以及非特殊字符[]^$\~@#%￥&<>{}:'""-的组合" });
                _validators.Add(new ValidatorItem { Id = "596", Code = "reg720", Regex = @"^[^`~!@#$%^*_=\[\]{};""|\\:\-\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"不允许汉字及非法字符`~!@#$%^*_=[]{};""|\:-" });
                _validators.Add(new ValidatorItem { Id = "597", Code = "reg721", Regex = @"^[^{}\[\]%'""`~$^_|\\:\u0000-\u001F\u0080-\u00FF]*$", Description = @"请输入字符，但不能包含{}[]%'""`~$^_|\:" });
                _validators.Add(new ValidatorItem { Id = "598", Code = "reg722", Regex = @"(?!^0*(\.0{1,2})?$)^\d{1,13}$", Description = @"请输入不超过13位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "599", Code = "reg723", Regex = @"(?!^0*(\.0{1,6})?$)^\d{1,1}(\.\d{1,6})?$", Description = @"请输入不超过1位整数，6位小数的数字" });
                _validators.Add(new ValidatorItem { Id = "600", Code = "reg724", Regex = @"^\d{1,3}(\.\d{1,1})?$", Description = @"请输入不超过3位整数，1位小数的贴现协议付息比例" });
                _validators.Add(new ValidatorItem { Id = "601", Code = "reg170", Regex = @"^[^\s\uFF00-\uFFFF]*$", Description = @"请输入字母、数字以及半角字符的组合，不允许输入空格" });
                _validators.Add(new ValidatorItem { Id = "602", Code = "reg725", Regex = @"(?!^[+-]?[0,]*(\.0{1,2})?$)^([+-]?((\d{1,3}(,\d{3}){0,3})|(\d(,\d{3}){4})|(\d{1,13})))(\.\d{1,2})?$", Description = @"请输入不超过13位整数，2位小数的金额，允许输入正负号" });
                _validators.Add(new ValidatorItem { Id = "603", Code = "reg726", Regex = @"^[a-zA-Z0-9-]*$", Description = @"请输入字母或数字，可包含-" });
                _validators.Add(new ValidatorItem { Id = "604", Code = "reg727", Regex = @"(?!^0*(\.0{1,4})?$)^\d{1,15}(\.\d{1,4})?$", Description = @"请输入不超过15位整数，4位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "605", Code = "reg728", Regex = @"(?!^0*(\.0{1,3})?$)^\d{1,18}(\.\d{1,3})?$", Description = @"请输入不超过18位整数，3位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "606", Code = "reg171", Regex = @"^[a-zA-Z]+[ ]{1}[a-zA-Z]+$", Description = @"请输入字母，中间有且只有一个空格" });
                _validators.Add(new ValidatorItem { Id = "607", Code = "reg729", Regex = @"(?!^[+-]{0,1}0*(\.0{1,2})?$)^[+-]{0,1}\d{1,14}(\.\d{1,2})?$", Description = @"请输入不超过14位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "608", Code = "reg730", Regex = @"^[a-zA-Z0-9\~\!\@\#\$\^\&\*\(\)_\+\`\-\=\\\|\;\:\,\.\/\<\>\?]*[0-9a-zA-Z]{1}$", Description = @"请输入数字，英文字符，但不能包含{}[]%'""" });
                _validators.Add(new ValidatorItem { Id = "609", Code = "reg731", Regex = @"^(([0-9]|[1-9]\d)(\.\d{1,2})?)$|^100(.0{1,2})?$", Description = @"请输入0.00-100.00之间的数" });
                _validators.Add(new ValidatorItem { Id = "610", Code = "reg732", Regex = @"^[1-9]+[0-9]*$", Description = @"请输入大于等于1的整数值" });
                _validators.Add(new ValidatorItem { Id = "611", Code = "reg733", Regex = @"^\d{1,14}(\.\d{1,2})?$|^0(\.0{1,2})?$", Description = @"请输入不超过14位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "612", Code = "reg734", Regex = @"^[1-9]\d{0,13}$|^0$", Description = @"请输入不超过14位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "613", Code = "reg735", Regex = @"(?!^0*(\.0{1,2})?$)^\d{1,14}(\.\d{1,2})?$", Description = @"请输入不超过14位整数，2位小数的金额，不允许输入负号" });
                _validators.Add(new ValidatorItem { Id = "614", Code = "reg736", Regex = @"^\d{1,3}(\.\d{1,2})?$", Description = @"请输入不超过3位整数，2位小数的数字" });
                _validators.Add(new ValidatorItem { Id = "615", Code = "reg737", Regex = @"^[0-9A-Za-z]{8}-[0-9A-Za-z]$", Description = @"请按格式XXXXXXXX-X输入数字或字母" });
                _validators.Add(new ValidatorItem { Id = "616", Code = "reg738", Regex = @"^[1-9]\d{0,9}$", Description = @"请输入不超过10位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "617", Code = "reg739", Regex = @"^[1-9]\d{0,10}$", Description = @"请输入不超过11位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "618", Code = "reg740", Regex = @"^[1-9]\d{0,11}$", Description = @"请输入不超过12位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "619", Code = "reg741", Regex = @"^[1-9]\d{0,13}$", Description = @"请输入不超过14位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "620", Code = "reg742", Regex = @"^[1-9]\d{0,14}$", Description = @"请输入不超过15位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "621", Code = "reg743", Regex = @"^[1-9]\d{0,15}$", Description = @"请输入不超过16位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "622", Code = "reg744", Regex = @"^[1-9]\d{0,17}$", Description = @"请输入不超过18位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "623", Code = "reg745", Regex = @"^[1-9]\d{0,19}$", Description = @"请输入不超过20位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "624", Code = "reg746", Regex = @"^[A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母和数字，可包含',.-/()" });
                _validators.Add(new ValidatorItem { Id = "625", Code = "reg747", Regex = @"^[+-]?[1-9]\d{0,12}(\.\d{1})?$|^[+-]?0\.[1-9]$", Description = @"请输入不超过13位整数，1位小数的金额，允许输入正负号" });
                _validators.Add(new ValidatorItem { Id = "626", Code = "reg748", Regex = @"(?!^0*(\.0{1,2})?$)(^[1-9]\d{0,6}(\.\d{1,2})?$|^0(\.\d{1,2})?$)", Description = @"请输入不超过7位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "627", Code = "reg749", Regex = @"^[1-9]\d{0,6}$", Description = @"请输入不超过7位整数的金额" });
                _validators.Add(new ValidatorItem { Id = "628", Code = "reg750", Regex = @"^[1-9]\d{0,13}(\.\d{1})?$|^0\.[1-9]$", Description = @"请输入不超过14位整数，1位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "629", Code = "reg751", Regex = @"^[+-]?[1-9]\d{0,12}$", Description = @"请输入不超过13位整数的金额，允许输入正负号" });
                _validators.Add(new ValidatorItem { Id = "630", Code = "reg752", Regex = @"^[+-]?[1-9]\d{0,13}(\.\d{1})?$|^[+-]?0\.[1-9]$", Description = @"请输入不超过14位整数，1位小数的金额，允许输入正负号" });
                _validators.Add(new ValidatorItem { Id = "631", Code = "reg753", Regex = @"^[+-]?[1-9]\d{0,13}$", Description = @"请输入不超过14位整数的金额，允许输入正负号" });
                _validators.Add(new ValidatorItem { Id = "632", Code = "reg754", Regex = @"^[1-9]\d{0,12}(\.\d{1,2})?$|^0(\.\d{1,2})?$", Description = @"请输入不超过13位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "633", Code = "reg755", Regex = @"^[1-9]\d{0,12}(\.\d{1})?$|^0\.[1-9]$", Description = @"请输入不超过13位整数，1位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "634", Code = "reg756", Regex = @"^(?!^0*(\.0{1,4})?$)^\d{1,3}(\.\d{1,4})?$", Description = @"请输入整数不超过100，小数不超过4位的数字" });
                _validators.Add(new ValidatorItem { Id = "635", Code = "reg172", Regex = @"^(?:[1-9]{1}[0-9]{0,12}|[0]{1})(\.{1}[0-9]{1,2}){0,1}$", Description = @"请输入不超过13位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "636", Code = "reg757", Regex = @"^[0-9\-()]*$", Description = @"请输入数字，可包含-()" });
                _validators.Add(new ValidatorItem { Id = "637", Code = "reg173", Regex = @"^((?!.{4}CN.*)[a-zA-Z0-9]{8})$|^((?!.{4}CN.*)[a-zA-Z0-9]{11})$", Description = @"请输入8位或11位字母、数字，其中第五、六位不为CN" });
                _validators.Add(new ValidatorItem { Id = "638", Code = "reg174", Regex = @"^(\d+[\,|\-]{1})*\d*$", Description = @"请输入数字，多个以，和-分隔" });
                _validators.Add(new ValidatorItem { Id = "639", Code = "reg758", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", Description = @"请输入不超过13位整数，2位小数的金额，且资金上收时调拨金额为正" });
                _validators.Add(new ValidatorItem { Id = "640", Code = "reg759", Regex = @"^[1-9]\d{0,12}(\.\d{1})?$|^0\.[1-9]$", Description = @"请输入不超过13位整数，1位小数的金额，且资金上收时调拨金额为正" });
                _validators.Add(new ValidatorItem { Id = "641", Code = "reg760", Regex = @"^[1-9]\d{0,12}$", Description = @"请输入不超过13位整数的金额，且资金上收时调拨金额为正" });
                _validators.Add(new ValidatorItem { Id = "642", Code = "reg761", Regex = @"^(?!^0*(\.0{1,2})?$)^[-]\d{1,13}(\.\d{1,2})?$", Description = @"请输入不超过13位整数，2位小数的金额，且资金下拨时调拨金额为负" });
                _validators.Add(new ValidatorItem { Id = "643", Code = "reg762", Regex = @"^[-][1-9]\d{0,12}(\.\d{1})?$|^[-]0\.[1-9]$", Description = @"请输入不超过13位整数，1位小数的金额，且资金下拨时调拨金额为负" });
                _validators.Add(new ValidatorItem { Id = "644", Code = "reg763", Regex = @"^[-][1-9]\d{0,12}$", Description = @"请输入不超过13位整数的金额，且资金下拨时调拨金额为负" });
                _validators.Add(new ValidatorItem { Id = "645", Code = "reg175", Regex = @"^[ A-Za-z0-9\-\(\)\.\,\'\s\?\+\/]*$", Description = @"请输入字母、数字，可包含-().,'?+/和空格" });
                _validators.Add(new ValidatorItem { Id = "646", Code = "reg176", Regex = @"^[ A-Z0-9\(\)\+\'\,\.\?\/\u4E00-\u9FFF]*$", Description = @"请输入中文、大写字母或数字，可包含空格和()+',.?/" });
                _validators.Add(new ValidatorItem { Id = "647", Code = "reg764", Regex = @"^[1-9]\d{0,11}(\.\d{1,2})?$|^0*(\.0{1,2})?$", Description = @"请输入不超过12位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "648", Code = "reg177", Regex = @"^[0-9]{12,17}$|^[0-9]{19}$", Description = @"请输入12-17位或19位数字" });
                _validators.Add(new ValidatorItem { Id = "649", Code = "reg765", Regex = @"^[ A-Za-z0-9',.()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*[\/]{1}[ A-Za-z0-9',.()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母和数字，可包含',.()/" });
                _validators.Add(new ValidatorItem { Id = "650", Code = "reg178", Regex = @"^[ A-Za-z0-9'"",;!:\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文、字母或数字，允许的字符包括'"",;!:?-./和空格" });
                _validators.Add(new ValidatorItem { Id = "651", Code = "reg179", Regex = @"^[^\[\]\^\$\~#%<>\{\}:'""]*$", Description = @"请输入中文、字母或数字，不允许特殊字符[]^$~#%<>{}" });
                _validators.Add(new ValidatorItem { Id = "652", Code = "reg180", Regex = @"^[A-Z]*$", Description = @"请输入大写字母" });
                _validators.Add(new ValidatorItem { Id = "653", Code = "reg181", Regex = @"^[^\[\]\^\$\~#%<>\{\}:\'""\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入字母或数字，不允许特殊字符[]^$~#%<>{}" });
                _validators.Add(new ValidatorItem { Id = "654", Code = "reg766", Regex = @"^[ A-Za-z0-9-_(){}:.,'\s\?\+\\\/]*$", Description = @"请输入字母或数字，可包含-_(){}:.,'?+\/" });
                _validators.Add(new ValidatorItem { Id = "655", Code = "reg182", Regex = @"^AU[0-9]{6}$", Description = @"请输入AU加6位数字" });
                _validators.Add(new ValidatorItem { Id = "656", Code = "reg183", Regex = @"^[!-~]{1,20}$", Description = @"登录名为1-20位的字符，不能以空格开始和结束" });
                _validators.Add(new ValidatorItem { Id = "657", Code = "reg184", Regex = @"^([0-9a-zA-Z]{1,16}[\,]{1})*[0-9a-zA-Z]{1,16}$", Description = @"请输入最多16位的字母或数字编号的组合，多个编号请以"",""分隔" });
                _validators.Add(new ValidatorItem { Id = "658", Code = "reg185", Regex = @"^(0|[1-9]\d{0,2}|1000)$", Description = @"请输入0到1000的整数" });
                _validators.Add(new ValidatorItem { Id = "659", Code = "reg767", Regex = @"^[a-zA-Z0-9\/+?()\s.,']*$", Description = @"请输入字母、数字，可包含/+?().,'和空格" });
                _validators.Add(new ValidatorItem { Id = "660", Code = "reg1000", Regex = @"^[0-9]*$", Description = @"请输入0-9的数字" });
                _validators.Add(new ValidatorItem { Id = "661", Code = "reg1001", Regex = @"^(?!^0*(\.0{1,2})?$)^\d{1,16}(\.\d{1,2})?$", Description = @"请输入不超过16位整数，2位小数的金额" });
                _validators.Add(new ValidatorItem { Id = "662", Code = "reg1002", Regex = @"^[0-9A-HJ-NP-Za-hj-np-z*\/-]*$", Description = @"请输入字母(不包含oOiI)或数字，允许特殊字符*/-" });
                _validators.Add(new ValidatorItem { Id = "663", Code = "reg1003", Regex = @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$", Description = @"请输入中文，字母或数字，可包含',.-/()和空格" });
                _validators.Add(new ValidatorItem { Id = "673", Code = "reg186", Regex = @"^[0][1-9]$|^[1][0-2]$", Description = @"请输入“01”至“12”中任一个数值" });
            }
        }

        public static string GetRegValueByCode(string regCode)
        {
            ValidatorList.EnsureValidators();
            var foundItem = _validators.Find(item => string.Equals(item.Code, regCode, StringComparison.CurrentCultureIgnoreCase));
            return foundItem == null ? string.Empty : foundItem.Regex;
        }
    }

    [Serializable]
    public class ValidatorItem
    {
        public string Id { get; internal set; }
        public string Code { get; internal set; }
        public string Regex { get; internal set; }
        public string Description { get; internal set; }
        public string E { get; internal set; }
        public string J { get; internal set; }
        public string K { get; internal set; }
        public string R { get; internal set; }
        public string F { get; internal set; }
        public string D { get; internal set; }
        public string T { get; internal set; }
        public string P { get; internal set; }
    }

    // ENTITIES的属性注入属性
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class DvValidatRuleAttribute : Attribute
    {
        // public bool IsDefault { get; set; } // 2014-08-05; added 默认配置项  // 2014-08-06 删除‘默认配置项’定义 -- 只注入1条属性时即为默认配置项；注入多条时需代码选择参与运算的配置项
        public int MinLength { get; set; }  // 最小长度
        public int MaxLength { get; set; } // 最大长度
        public string RegCode { get; set; } // 正则表达式约束
        public bool Required { get; set; } // 是否必填项
        public string CaseDescription { get; set; } // 约束项名称 (Attribute的名字)
    }

}

