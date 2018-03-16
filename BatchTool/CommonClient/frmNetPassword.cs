using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;

namespace CommonClient
{
    public partial class frmNetPassword : frmBase
    {
        public frmNetPassword()
        {
            InitializeComponent();
            this.ShowIcon = false;
            CommandCenter.OnEncryptionEventHandler += new EventHandler<EncryptionEventArgs>(CommandCenter_OnEncryptionEventHandler);
        }

        void CommandCenter_OnEncryptionEventHandler(object sender, EncryptionEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EncryptionEventArgs>(CommandCenter_OnEncryptionEventHandler), sender, e); }
            else
            {
                if (e.AppType != this.fileEncryptionSettings1.AppType || e.Command != EnumTypes.OperatorCommandType.Submit) return;
                if (!this.IsDisposed)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        AppliableFunctionType m_apptype;
        public AppliableFunctionType AppType { get { return m_apptype; } set { m_apptype = value; this.fileEncryptionSettings1.AppType = value; } }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
