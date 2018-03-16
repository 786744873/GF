using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;

namespace BOC_BATCH_TOOL
{
    public partial class frmCustomerInfoMgr : Form
    {
        public frmCustomerInfoMgr()
        {
            InitializeComponent();
            this.ShowIcon = false;

            tbCustomerNo.Text = SystemSettings.Instance.CustomerInfo.Group;
            tbSerialNo.Text = SystemSettings.Instance.CustomerInfo.Code;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                SystemSettings.Instance.CustomerInfo.Group = tbCustomerNo.Text.Trim();
                SystemSettings.Instance.CustomerInfo.Code = tbSerialNo.Text.Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool CheckData()
        {
            ResultData rd = new ResultData();
            rd = DataCheckCenter.Instance.CheckBarCustomerNo(tbCustomerNo, tbCustomerNo.Text.Trim(), lbCustomerNo.Text.Substring(0, lbCustomerNo.Text.Length - 1), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckBarSerilNo(tbSerialNo, tbSerialNo.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            return rd.Result;
        }
    }
}
