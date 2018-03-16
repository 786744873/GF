using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.Types;
using CommonClient.Utilities;
using CommonClient.MatchFile;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;

namespace CommonClient
{
    public partial class wndOpenBankQuery : frmBase
    {
        public wndOpenBankQuery()
        {
            InitializeComponent();
            BankType = AccountBankType.Empty;
            dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            batchPagesPanel.GoToSomePageEventHandeler += new EventHandler<VisualParts.BatchPageEventArgs>(batchPagesPanel_GoToSomePageEventHandeler);
        }

        public wndOpenBankQuery(string bankName, string bankno = "")
            : this()
        {
            tbBankName.Text = bankName;
            tbNo.Text = bankno;
        }

        void batchPagesPanel_GoToSomePageEventHandeler(object sender, VisualParts.BatchPageEventArgs e)
        {
            if (e.CurrentPageNo == 0) { dgv.DataSource = null; return; }
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

        public EnumTypes.AppliableFunctionType AppType { get; set; }
        public bool IsOpenBank = false;
        public bool IsElecTicket = false;
        public AccountBankType BankType { get; set; }

        private void wndOpenBankQuery_Load(object sender, EventArgs e)
        {
            //if (Cnaps == null)
            //    Cnaps = DataFileHelper.GetCNAPS();

            //this.bindingSource1.DataSource = Cnaps;
            //var autoCompleteStringCollection = new AutoCompleteStringCollection();
            //foreach (CNAP cnap in Cnaps.Items)
            //{
            //    autoCompleteStringCollection.Add(cnap.Name);
            //    autoCompleteStringCollection.Add(cnap.Code);
            //}
            //this.cmbQuery.AutoCompleteCustomSource = autoCompleteStringCollection;
            //if (!string.IsNullOrEmpty(tbBankName.Text) || !string.IsNullOrEmpty(tbNo.Text))
                btnQuery.PerformClick();
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
                MessageBoxPrime.Show(string.Format("可能系统数据文件已损坏或已丢失，\r\n请从网银下载{0}文件进行本地更新",
                    IsOpenBank ? "CNAPS行号" : "清算行号"), CommonClient.SysCoach.CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return;
            }
            Cnaps = DataFileHelper.GetCNAPS(filepath, bankname, cnapsNo);
            if (BankType != AccountBankType.Empty && BankType != AccountBankType.OtherBankAccount)
                Cnaps.Items = Cnaps.Items.FindAll(o => o.Code.StartsWith(((int)BankType).ToString()));
            else if ((AppType == AppliableFunctionType.TransferWithCorp || AppType == AppliableFunctionType.TransferWithIndiv) && BankType == AccountBankType.OtherBankAccount)
                Cnaps.Items = Cnaps.Items.FindAll(o => PrequisiteDataProvideNode.InitialProvide.AccountBankTypeList.FindAll(p => (int)p > 100 && o.Code.StartsWith(((int)p).ToString())).Count == 0);
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
            if (e.ColumnIndex != 2 || e.RowIndex < 0) return;
            QueryDialogResult = (dgv.DataSource as List<CNAP>)[e.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}
