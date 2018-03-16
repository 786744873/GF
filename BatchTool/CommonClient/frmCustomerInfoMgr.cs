using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.SysCoach;

namespace CommonClient
{
    public partial class frmCustomerInfoMgr : frmBase
    {
        public frmCustomerInfoMgr()
        {
            InitializeComponent();
            this.ShowIcon = false;

            tbCustomerNo.Text = SystemSettings.CustomerInfo.Group;
            tbSerialNo.Text = SystemSettings.CustomerInfo.Code;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                SystemSettings.CustomerInfo.Group = tbCustomerNo.Text.Trim();
                SystemSettings.CustomerInfo.Code = tbSerialNo.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool CheckData()
        {
            ResultData rd = new ResultData();
            rd = DataCheckCenter.CheckBarCustomerNo(tbCustomerNo, tbCustomerNo.Text.Trim(), lbCustomerNo.Text.Substring(0, lbCustomerNo.Text.Length - 1), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.CheckBarSerilNo(tbSerialNo, tbSerialNo.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            return rd.Result;
        }
    }
}
