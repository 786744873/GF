using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CommonClient.VisualParts
{
    public partial class FileOperatePanel : BaseUc
    {
        public FileOperatePanel()
        {
            InitializeComponent();
            CommonClient.SysCoach.CommandCenter.OnLanguageChangedEventHandler += new EventHandler<SysCoach.LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, SysCoach.LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SysCoach.LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                //base.ApplyResource(typeof(FileOperatePanel), this);
            }
        }

        public void ShowBtnMatchError(bool flag)
        {
            btnMergError.Visible = flag;
        }

        public void ShowBtnPrint(bool flag)
        {
            btnPrint.Visible = flag;
            if (!btnMergError.Visible)
                btnPrint.Location = btnMergError.Location;
        }

        public event EventHandler ButtonNewClicked;

        public event EventHandler ButtonOpenClicked;

        public event EventHandler ButtonSaveClicked;

        public event EventHandler ButtonMergFromFileClicked;

        public event EventHandler ButtonMergErrorFileClicked;

        public event EventHandler ButtonPrintClicked;

        public event EventHandler ButtonDeleteClicked;

        public event EventHandler ButtonUpClicked;

        public event EventHandler ButtonDownClicked;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ButtonSaveClicked != null)
                ButtonSaveClicked(sender, e);
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

        private void btnImportFromFile_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show("通过该功能您可合并已打开文件与待合并的批量文件，单击保存可生成合并后的新建批量文件", btnImportFromFile);
        }

        private void btnMergError_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show("通过该功能您可打开并修改信息错配的批量文件，修改完成后，系统将取消颜色标注，单击保存可生成修改后的新建批量文件", btnMergError);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.ButtonPrintClicked != null)
                ButtonPrintClicked(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.ButtonDeleteClicked != null)
                ButtonDeleteClicked(sender, e);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.ButtonUpClicked != null)
                ButtonUpClicked(sender, e);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.ButtonDownClicked != null)
                ButtonDownClicked(sender, e);
        }
    }
}
