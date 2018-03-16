using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.MatchFile;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL
{
    public partial class frmImportLocalFiles : Form
    {
        public frmImportLocalFiles()
        {
            InitializeComponent();

            foreach (UpdateFleType item in PrequisiteDataProvideNode.InitialProvide.UpdateFleTypeList)
            {
                if (item == UpdateFleType.Empty) continue;
                cmbFileType.Items.Add(EnumNameHelper<UpdateFleType>.GetEnumDescription(item));
            }
            cmbFileType.Tag = PrequisiteDataProvideNode.InitialProvide.UpdateFleTypeList.FindAll(o => o != UpdateFleType.Empty);

            cmbFileType.SelectedIndexChanged += new EventHandler(cmbFileType_SelectedIndexChanged);
        }

        void cmbFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFileType.SelectedIndex < 0)
            {
                m_FileType = UpdateFleType.Empty;
                return;
            }

            m_FileType = (cmbFileType.Tag as List<UpdateFleType>)[cmbFileType.SelectedIndex];
        }

        UpdateFleType m_FileType = UpdateFleType.Empty;

        public frmImportLocalFiles(UpdateFleType uft)
            : this()
        {
            if ((int)uft >= 0)
            {
                m_FileType = uft;
                cmbFileType.SelectedIndex = (int)m_FileType - 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (cmbFileType.SelectedIndex < 0 || string.IsNullOrEmpty(tbFilePath.Text.Trim())) return;

            string filepath = tbFilePath.Text.Trim();

            ResultData rd = UpdateFileHelper.Instance.Update(m_FileType, filepath);
            if (!rd.Result) MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBoxExHelper.Instance.Show("导入成功", CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSelectedFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = string.Format("{0}|*.zip", MultiLanguageConvertHelper.Instance.DesignMain_FileType_Zip);
            if (ofDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            tbFilePath.Text = ofDialog.FileName.ToLower().EndsWith(".zip") ? ofDialog.FileName : string.Empty;

            if (ofDialog != null)
                ofDialog.Dispose();
        }
    }
}
