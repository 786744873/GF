using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.VisualParts;

namespace BOC_BATCH_TOOL.VisualElements
{
    public partial class ButtonPanel : BaseUc
    {
        public ButtonPanel()
        {
            InitializeComponent();
        }
        public event EventHandler ButtonNewClicked;

        public event EventHandler ButtonOpenClicked;

        public event EventHandler ButtonAddClicked;

        public event EventHandler ButtonEditClicked;

        public event EventHandler ButtonResetClicked;

        public event EventHandler ButtonSaveClicked;

        public event EventHandler ButtonSaveAsClicked;

        public event EventHandler ButtonDeleteClicked;

        public event EventHandler ButtonMergFromFileClicked;

        public event EventHandler ButtonMergErrorFileClicked;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ButtonAddClicked != null)
                ButtonAddClicked(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.ButtonEditClicked != null)
                ButtonEditClicked(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.ButtonResetClicked != null)
                ButtonResetClicked(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ButtonSaveClicked != null)
                ButtonSaveClicked(sender, e);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (this.ButtonSaveAsClicked != null)
                ButtonSaveAsClicked(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.ButtonDeleteClicked != null)
                ButtonDeleteClicked(sender, e);
        }

        private void btnImportFromFile_Click(object sender, EventArgs e)
        {
            if (this.ButtonMergFromFileClicked != null)
                ButtonMergFromFileClicked(sender, e);
        }

        private void btnMergError_Click(object sender, EventArgs e)
        {
            if (this.ButtonMergErrorFileClicked != null)
                ButtonMergErrorFileClicked(sender, e);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (null != ButtonOpenClicked)
                ButtonOpenClicked(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (null != ButtonNewClicked)
                ButtonNewClicked(sender, e);
        }
    }
}
