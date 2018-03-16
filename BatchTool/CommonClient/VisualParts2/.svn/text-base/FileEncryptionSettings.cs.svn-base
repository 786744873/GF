using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class FileEncryptionSettings : BaseUc
    {
        public FileEncryptionSettings()
        {
            InitializeComponent();
            CommandCenter.OnEncryptionEventHandler += new EventHandler<EncryptionEventArgs>(CommandCenter_OnEncryptionEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(FileEncryptionSettings), this);
                Init();
            }
        }

        void CommandCenter_OnEncryptionEventHandler(object sender, EncryptionEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EncryptionEventArgs>(CommandCenter_OnEncryptionEventHandler), sender, e); }
            else
            {
                if (e.AppType != m_appType) return;
                rbYes.Checked = e.IsSetPassword;
                rbNo.Checked = !rbYes.Checked;
                txtNewPWD.Text = txtEnSurePWD.Text = e.Password;
            }
        }

        /// <summary>
        /// 是否设置快捷代发加密密码
        /// </summary>
        public bool IsSetPWD
        {
            get
            {
                //if (rbYes.Checked)
                //{
                //if (string.IsNullOrEmpty(txtNewPWD.Text) || txtNewPWD.Text.Trim() != txtEnSurePWD.Text.Trim())
                //{
                //    rbYes.Checked = false;
                //    rbNo.Checked = true;
                //    txtNewPWD.Text = txtEnSurePWD.Text = string.Empty;
                //}
                m_IsSetPWD = rbYes.Checked;
                //}
                return m_IsSetPWD;
            }
        }
        /// <summary>
        /// 加密密码
        /// </summary>
        public string PWD
        {
            get
            {
                if (rbYes.Checked)
                {
                    if (string.IsNullOrEmpty(txtNewPWD.Text))
                    {
                        //rbYes.Checked = false;
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_FileEncryption_Input_Password, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        txtNewPWD.Text = txtEnSurePWD.Text = string.Empty;
                        m_PWD = string.Empty;
                    }
                    else if (txtNewPWD.Text.Trim() != txtEnSurePWD.Text.Trim())
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_FileEncryption_Password_Different, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        txtNewPWD.Text = txtEnSurePWD.Text = string.Empty;
                        m_PWD = string.Empty;
                    }
                    else
                    { m_PWD = txtNewPWD.Text.Trim(); }
                }
                else
                {
                    txtNewPWD.Text = txtEnSurePWD.Text = string.Empty;
                    m_PWD = string.Empty;
                }
                return m_PWD;
            }
        }

        private bool m_IsSetPWD = false;
        private string m_PWD = string.Empty;

        private AppliableFunctionType m_appType = AppliableFunctionType._Empty;
        /// <summary>
        /// 功能模块
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_appType; }
            set
            {
                if (value == AppliableFunctionType.AgentExpressOut || value == AppliableFunctionType.TransferOverCountry || value == AppliableFunctionType.TransferForeignMoney)
                {
                    m_appType = value;
                    Init();
                }
            }
        }

        private void Init()
        {
            lbGroupDescription.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Set_Password, CommonClient.Utilities.EnumNameHelper<AppliableFunctionType>.GetEnumDescription(m_appType) + (m_appType == AppliableFunctionType.AgentExpressOut ? "(工资类)" : string.Empty));

            rbYes.Checked = (m_appType == AppliableFunctionType.AgentExpressOut && SystemSettings.IsMatchPassword4ShortProxyOut)
                || (m_appType == AppliableFunctionType.TransferOverCountry && SystemSettings.IsMatchPassword4TransferOverCountry)
                || (m_appType == AppliableFunctionType.TransferForeignMoney && SystemSettings.IsMatchPassword4TransferForeignMoney);
            rbNo.Checked = !rbYes.Checked;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Name == rbYes.Name)
            {
                txtEnSurePWD.ReadOnly = txtNewPWD.ReadOnly = false;
            }
            else if ((sender as RadioButton).Name == rbNo.Name)
            {
                txtEnSurePWD.ReadOnly = txtNewPWD.ReadOnly = true;
                txtNewPWD.Text = txtEnSurePWD.Text = string.Empty;
            }
        }

        private void btnSaveEncryption_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            if (this.IsSetPWD)
            {
                if (string.IsNullOrEmpty(this.PWD))
                { this.errorProvider1.SetError(txtNewPWD, string.Format("{0}{1}", MultiLanguageConvertHelper.Information_Please_Input, label15.Text.Substring(0, label15.Text.Length - 1))); return; }
            }
            CommandCenter.ResolveEncryption(OperatorCommandType.Submit, this.IsSetPWD, this.PWD, m_appType);
            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
        }
    }
}
