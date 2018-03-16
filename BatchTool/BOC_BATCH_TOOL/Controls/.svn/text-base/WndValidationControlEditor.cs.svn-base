using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Types;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Controls
{
    public partial class ValidationControlRegexEditor : Form
    {
        public ValidationControlRegexEditor()
        {
            InitializeComponent();

            Result = new EditorValidateRule();
            this.cmbRegex.Items.AddRange(ConsistDefine.PreDefinedValidationItems().ToArray());
        }

        public void LoadInitData(EditorValidateRule oldRule)
        {
            this.cmbRegex.Items.Clear();

            this.edtMinLength.Value = oldRule.MinLength;
            this.edtMaxLength.Value = oldRule.MaxLength;

            this.cbRequired.Checked = oldRule.Required;

            foreach (RegexValidationItem rule in this.cmbRegex.Items)
            {
                if (string.Equals(oldRule.RegexValue, rule.RegexValue))
                {
                    this.cmbRegex.SelectedItem = rule;
                    this.lblDesc.Text = string.Format("CHS: {0} ; EN: {1}", rule.MessageZhcn, rule.MessageEnus);
                    break;
                }
            }
        }

        public static EditorValidateRule Result { get; private set; }

        private void cmbRegex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegex.SelectedItem != null)
            {
                var validationItem = (RegexValidationItem)cmbRegex.SelectedItem;
                Result.RegexValue = validationItem.RegexValue;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Result == null)
                Result = new EditorValidateRule();
            Result.MinLength = (int)this.edtMinLength.Value;
            Result.MaxLength = (int)this.edtMaxLength.Value;

            Result.Required = this.cbRequired.Checked;
            var validationItem = (RegexValidationItem)this.cmbRegex.SelectedItem;
            if (validationItem != null)
                Result.RegexValue = validationItem.RegexValue;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
