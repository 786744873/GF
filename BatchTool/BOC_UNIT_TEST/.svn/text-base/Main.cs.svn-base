using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CommonClient;
using CommonClient.Controls;
using CommonClient.Entities;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.Utilities;

namespace BOC_UNIT_TEST
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnEntityCheck_Click(object sender, EventArgs e)
        {
            var an = new BatchHeader();
            an.Addtion = "0123456789_0123456789_0123456789_0123456789_0123456789_0123456789_0123456789_!@#$%^&*()";
            an.ProtecolNo = "0123456789_0123456789#@$%^&*(_";

            // 首先，校验一遍标准的字段注入：字段上面只注入了唯一一个校验Attribute
            var result = an.CheckStandardEntity();

            // 其次，按照当前业务需求，选择出相应的校验Attribute，然后对对应字段使用这个Attribute校验
            var customerAttr = an.GetEntityFieldRuleAttribute("ProtecolNo", "客户业务编号");
            var result2 = an.CheckEntityFieldByRuleAttribute("ProtecolNo", customerAttr);

            // 或者上面两行代码也可以写做下面一行代码
            result2 = an.CheckEntityFieldByRuleAttribute("ProtecolNo", "客户业务编号");

            // 只有标准校验和手工校验都通过才算校验通过
            if (result.Pass && result2.Pass)
                MessageBox.Show("实体值检查通过");
            else
            {
                // 下面是数据收集效果演示
                var sb = new StringBuilder();
                foreach (ValidationResult validationResult in result.Results)
                {
                    sb.AppendLine("FieldName: " + validationResult.FieldName + "      FieldValue: " + validationResult.FieldValue);
                    sb.AppendLine("ValidationMessage: " + validationResult.Message);
                    var xy = EnumListHelper<ValidateErrorType>.GetValueList();
                    foreach (ValidateErrorType errorType in xy)
                    {
                        if (errorType == (validationResult.ValidationDetail & errorType))
                        {
                            var description1 = EnumNameHelper<ValidateErrorType>.GetEnumDescription(errorType);
                            sb.AppendLine(description1);
                        }
                    }
                    sb.AppendLine("  ");
                }

                sb.AppendLine("FieldName: " + result2.FieldName + "      FieldValue: " + result2.FieldValue);
                sb.AppendLine("ValidationMessage: " + result2.Message);
                var xy2 = EnumListHelper<ValidateErrorType>.GetValueList();
                foreach (ValidateErrorType errorType in xy2)
                {
                    if (errorType == (result2.ValidationDetail & errorType))
                    {
                        var description1 = EnumNameHelper<ValidateErrorType>.GetEnumDescription(errorType);
                        sb.AppendLine(description1);
                    }
                }
                MessageBox.Show(sb.ToString());
            }

        }

        private void btnEnumName_Click(object sender, EventArgs e)
        {
            var nameList = EnumListHelper<AgentNormalCertifyPaperType>.GetNameList();
            var sb = new StringBuilder();
            foreach (string s in nameList)
            {
                sb.AppendLine(s);
            }
            MessageBoxPrime.Show(sb.ToString());
        }


        private void Main_Load(object sender, EventArgs e) 
        {
            //foreach (Entity entite in this.Entites)
            //{
            //    this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem(entite.Account) { Entity = entite });
            //}

            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2436243231451234") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2379543450643124") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2137494234652329") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2268435623459456") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2157345683235945") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2278598592341345") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2373563864721351") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2345684673245132") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2512362436584681") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2372356835234582") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2436243231451234") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2379543450643124") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2137494234652329") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2268435623459456") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2157345683235945") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2278598592341345") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2373563864721351") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2345684673245132") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2512362436584681") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2372356835234582") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2436243231451234") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2379543450643124") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2137494234652329") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2268435623459456") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2157345683235945") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2278598592341345") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2373563864721351") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2345684673245132") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2512362436584681") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
            this.ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem("2372356835234582") { Entity = new PayeeInfo { Account = "", Name = "", CNAPSNo = "" } });
        }

    }
}
