using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.Types;
using CommonClient.ConvertHelper;
using CommonClient.MatchFile;

namespace CommonClient
{
    public partial class frmOpenBankQuery : frmBase
    {
        public frmOpenBankQuery()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            this.Load += new EventHandler(frmOpenBankQuery_Load);
            dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            batchPagesPanel.GoToSomePageEventHandeler += new EventHandler<VisualParts.BatchPageEventArgs>(batchPagesPanel_GoToSomePageEventHandeler);
        }

        void frmOpenBankQuery_Load(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(tbBankName.Text) || !string.IsNullOrEmpty(tbNo.Text))
                btnQuery.PerformClick();
        }

        public frmOpenBankQuery(string bankName, string bankNo = "")
            : this()
        {
            tbBankName.Text = bankName;
            tbNo.Text = bankNo;
        }

        void batchPagesPanel_GoToSomePageEventHandeler(object sender, VisualParts.BatchPageEventArgs e)
        {
            if (e.CurrentPageNo == 0)
            {
                dgv.DataSource = null; return;
            }
            if (Cnaps.Items == null)
            { dgv.DataSource = null; }
            else if (Cnaps.Items.Count < e.PerPageRecordCount)
                dgv.DataSource = Cnaps.Items;
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

        public bool IsOpenBank = false;
        public EnumTypes.AppliableFunctionType AppType = EnumTypes.AppliableFunctionType._Empty;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string bankname = tbBankName.Text.Trim();
            string cnapsNo = tbNo.Text.Trim().ToUpper();
            string filepath = string.Empty;
            filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\BCS.xml");
            if (AppType == EnumTypes.AppliableFunctionType.TransferForeignMoney4Bar && IsOpenBank)
                filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\BCSBar.xml");
            if (AppType == EnumTypes.AppliableFunctionType.TransferOverCountry4Bar && IsOpenBank)
                filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CNAPSBarOE.xml");
            if (!System.IO.File.Exists(filepath))
            {
                MessageBoxPrime.Show("可能系统数据文件已损坏或已丢失", CommonClient.SysCoach.CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return;
            }
            Cnaps = DataFileHelper.GetCNAPS(filepath, bankname, cnapsNo);
            batchPagesPanel.Init(Cnaps.Items.Count);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show(MultiLanguageConvertHelper.Tips_Input_Multi_KeyChars, pbTip);
        }
        /// <summary>
        /// 行 选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3 || e.RowIndex < 0) return;
            QueryDialogResult = (dgv.DataSource as List<CNAP>)[e.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}
