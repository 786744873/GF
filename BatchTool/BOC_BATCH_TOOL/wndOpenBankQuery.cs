using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Types;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.MatchFile;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL
{
    public partial class wndOpenBankQuery : Form
    {
        public wndOpenBankQuery()
        {
            InitializeComponent();
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            batchPagesPanel.GoToSomePageEventHandeler += new EventHandler<VisualParts.BatchPageEventArgs>(batchPagesPanel_GoToSomePageEventHandeler);
        }

        void batchPagesPanel_GoToSomePageEventHandeler(object sender, VisualParts.BatchPageEventArgs e)
        {
            if (e.CurrentPageNo == 0) { dgv.DataSource = null; return; }
            if (Cnaps.Items == null)
            { dgv.DataSource = null; }
            else if (Cnaps.Items.Count < e.PerPageRecordCount)
            {
                dgv.DataSource = Cnaps.Items;
            }
            else
            {
                List<CNAP> result = new List<CNAP>();
                result = Cnaps.Items.GetRange(e.StartRecordNo, e.ShowCount);
                dgv.DataSource = null;
                dgv.DataSource = result;
            }
            dgv.Refresh();
        }

        void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (hitInfo.RowIndex < 0) return;

            QueryDialogResult = (dgv.DataSource as List<CNAP>)[hitInfo.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public CNAPS Cnaps { get; private set; }
        public CNAP QueryDialogResult { get; set; }

        public EnumTypes.AppliableFunctionType AppType { get; set; }
        public bool IsOpenBank = false;
        public bool IsElecTicket = false;

        private void wndOpenBankQuery_Load(object sender, EventArgs e)
        {
            //if (Cnaps == null)
            //    Cnaps = DataFileHelper.Instance.GetCNAPS();

            //this.bindingSource1.DataSource = Cnaps;
            //var autoCompleteStringCollection = new AutoCompleteStringCollection();
            //foreach (CNAP cnap in Cnaps.Items)
            //{
            //    autoCompleteStringCollection.Add(cnap.Name);
            //    autoCompleteStringCollection.Add(cnap.Code);
            //}
            //this.cmbQuery.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string bankname = tbBankName.Text.Trim();
            string cnapsNo = tbNo.Text.Trim();
            string filepath = string.Empty;
            if (IsElecTicket) filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CNAPSET.XML");
            else if (IsOpenBank)
            {
                if (AppType == EnumTypes.AppliableFunctionType.AgentExpressOut4Bar)
                    filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CNAPSBarRMB.XML");
                else
                    filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CNAPS.XML");
            }
            else filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CNAPSC.XML");
            if (!System.IO.File.Exists(filepath))
            {
                MessageBoxExHelper.Instance.Show(string.Format("可能系统数据文件已损坏或已丢失，\r\n请从网银下载{0}文件进行本地更新",
                    IsElecTicket ? MultiLanguageConvertHelper.Instance.FrmMain_Update_File_ElecTicket : IsOpenBank ? MultiLanguageConvertHelper.Instance.FrmMain_Update_File_OpenBankCode : MultiLanguageConvertHelper.Instance.FrmMain_Update_File_ClearBankCode),
                    BOC_BATCH_TOOL.SysCoach.CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cnaps = DataFileHelper.Instance.GetCNAPS(filepath, bankname, cnapsNo);
            batchPagesPanel.Init(Cnaps.Items.Count);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show(MultiLanguageConvertHelper.Instance.Tips_Input_Multi_KeyChars, pbTip);
        }

    }
}
