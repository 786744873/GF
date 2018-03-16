using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.MatchFile;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;

namespace CommonClient
{
    public partial class frmImportLocalFiles : frmBase
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

            ResultData rd = UpdateFileHelper.Update(m_FileType, filepath);
            if (!rd.Result) MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            else MessageBoxPrime.Show("导入成功", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
        }

        private void btnSelectedFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = string.Format("{0}|*.zip", MultiLanguageConvertHelper.DesignMain_FileType_Zip);
            if (ofDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            tbFilePath.Text = ofDialog.FileName.ToLower().EndsWith(".zip") ? ofDialog.FileName : string.Empty;

            if (ofDialog != null)
                ofDialog.Dispose();
        }
    }
}
