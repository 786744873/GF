using System;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class InitiativeAllotAccountEditor : BaseUc
    {
        public InitiativeAllotAccountEditor()
        {
            InitializeComponent();
            CommandCenter.OnInitiativeAllotAccountEventHandler += new EventHandler<InitiativeAllotAccountEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            SetRegex();
        }
        private void SetRegex()
        {
            edtAccount.DvRegCode = "reg646";
            edtAccount.DvMinLength = 1;
            edtAccount.DvMaxLength = 22;
            edtAccount.DvRequired = true;
            edtName.DvRegCode = "reg641";
            edtName.DvMinLength = 0;
            edtName.DvMaxLength = 76;
            edtName.DvRequired = false;

        }
        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(InitiativeAllotAccountEditor), this);
            }
        }

        void CommandCenter_OnInitiativeAllotAccountEventHandler(object sender, InitiativeAllotAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<InitiativeAllotAccountEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler), sender, e); }
            else
            {
                this.errorProvider1.Clear();
                if (e.Command == EnumTypes.OperatorCommandType.View)
                {
                    tbRowIndex.Text = e.RowIndex.ToString();
                    edtAccount.Text = e.InitiativeAllotAccount.Account;
                    edtName.Text = e.InitiativeAllotAccount.Name;
                }
                else if (e.Command == EnumTypes.OperatorCommandType.Delete
                    || e.Command == EnumTypes.OperatorCommandType.Reset)
                {
                    edtAccount.Text =
                    edtName.Text = string.Empty;
                }
            }
        }

        bool CheckData()
        {
            ResultData rd = new ResultData { Result = true }; 
            //rd = DataCheckCenter.CheckAccountExIA(edtAccount, edtAccount.Text.Trim(), lblAccount.Text.Substring(0, lblAccount.Text.Length - 1), 22, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (!string.IsNullOrEmpty(edtName.Text))
            //{
            //    rd = DataCheckCenter.CheckNameExIA(edtName, edtName.Text.Trim(), lblName.Text.Substring(0, lblName.Text.Length - 1), 76, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            return rd.Result;
        }

        private int GetRowIndex()
        {
            int index = 0;
            try
            {
                if (string.IsNullOrEmpty(tbRowIndex.Text)) index = int.MaxValue;
                index = int.Parse(tbRowIndex.Text.Trim());
                if (index < 0) index = int.MaxValue;
            }
            catch { index = int.MaxValue; }
            return index;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid()&&CheckData())
                CommandCenter.ResolveInitiativeAllotAccount(EnumTypes.OperatorCommandType.Submit, new InitiativeAllotAccount { Account = edtAccount.Text.Trim(), Name = edtName.Text.Trim() }, EnumTypes.AppliableFunctionType._Empty, GetRowIndex());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid() && CheckData())
                CommandCenter.ResolveInitiativeAllotAccount(EnumTypes.OperatorCommandType.Edit, new InitiativeAllotAccount { Account = edtAccount.Text.Trim(), Name = edtName.Text.Trim() }, EnumTypes.AppliableFunctionType._Empty, GetRowIndex());
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            edtAccount.Text =
            edtName.Text = string.Empty;
            this.errorProvider1.Clear();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }
    }
}
