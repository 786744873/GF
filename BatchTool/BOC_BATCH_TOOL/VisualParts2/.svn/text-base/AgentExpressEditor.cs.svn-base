using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.VisualParts;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;
using System.Text.RegularExpressions;

namespace BOC_BATCH_TOOL.VisualElements
{
    public partial class AgentExpressEditor : BaseUc
    {
        public AgentExpressEditor()
        {
            InitializeComponent();

            InitData();
            cmbPayeeAccountProvince.SelectedIndex = -1;
            cmbUsage.SelectedIndex = -1;
            this.Load += new EventHandler(AgentExpressEditor_Load);

            CommandCenter.Instance.OnAgentExpressEventHandler += new EventHandler<AgentExpressEventArgs>(CommandCenter_OnAgentExpressEventHandler);
            CommandCenter.Instance.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            edtAmount.LostFocus += new EventHandler(edtAmount_LostFocus);
            cmbPayeeCertPaperType.SelectedIndexChanged += new EventHandler(cmbPayeeCertPaperType_SelectedIndexChanged);
        }

        private void InitData()
        {
            cmbPayeeCertPaperType.Items.Clear();
            cmbPayeeCertPaperType.Items.Add(MultiLanguageConvertHelper.Instance.DesignMain_Please_Selection);
            foreach (AgentExpressCertifyPaperType certifyPaperType in PrequisiteDataProvideNode.InitialProvide.AgentExpressCertifyPaperTypeList)
            {
                if (certifyPaperType == AgentExpressCertifyPaperType.Empty) continue;
                var value = EnumNameHelper<AgentTransferBankType>.GetEnumDescription(certifyPaperType);
                this.cmbPayeeCertPaperType.Items.Add(value);
            }
            cmbPayeeCertPaperType.Tag = PrequisiteDataProvideNode.InitialProvide.AgentExpressCertifyPaperTypeList.FindAll(o => o != AgentExpressCertifyPaperType.Empty);

            cmbPayeeAccountProvince.Items.Clear();
            foreach (ChinaProvinceType chinaProvinceType in PrequisiteDataProvideNode.InitialProvide.ChinaProvinceTypeList)
            {
                if (chinaProvinceType == ChinaProvinceType.B0) continue;
                var value = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(chinaProvinceType);
                this.cmbPayeeAccountProvince.Items.Add(value);
            }
            cmbPayeeAccountProvince.Tag = PrequisiteDataProvideNode.InitialProvide.ChinaProvinceTypeList.FindAll(o => o != ChinaProvinceType.B0);

            cmbUsage.Items.Clear();
            List<AgentExpressFunctionType> templist = new List<AgentExpressFunctionType>();
            cmbUsage.Items.Add(EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(AgentExpressFunctionType.EV));
            templist.Add(AgentExpressFunctionType.EV);
            foreach (AgentExpressFunctionType agentExpressFunctionType in PrequisiteDataProvideNode.InitialProvide.AgentExpressFunctionTypeList)
            {
                if (agentExpressFunctionType == AgentExpressFunctionType.Empty || agentExpressFunctionType == AgentExpressFunctionType.EV) continue;
                if ((SystemSettings.Instance.CurrentVersion & VersionType.v405) != VersionType.v405 && (int)agentExpressFunctionType > 40) continue;
                var value = EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(agentExpressFunctionType);
                this.cmbUsage.Items.Add(value);
                templist.Add(agentExpressFunctionType);
            }
            cmbUsage.Tag = templist;
        }

        void cmbPayeeCertPaperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayeeCertPaperType.SelectedIndex > 0)
                edtCertPaperNo.ReadOnly = false;
            else edtCertPaperNo.ReadOnly = true;
        }

        void edtAmount_LostFocus(object sender, EventArgs e)
        {
            FormatCash();
        }

        private void FormatCash()
        {
            if (!string.IsNullOrEmpty(edtAmount.Text))
            {
                edtAmount.Text = DataConvertHelper.Instance.FormatCash(edtAmount.Text.Trim(), false);
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                ApplyResource();
            }
        }

        void CommandCenter_OnBankTypeChangedEventHandler(object sender, BankTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (e.Command == OperatorCommandType.BankTypeChanged)
                {
                    m_BankType = e.BankType;
                    ChangeUIShow();
                }
            }
        }

        void CommandCenter_OnAgentExpressEventHandler(object sender, AgentExpressEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentExpressEventArgs>(CommandCenter_OnAgentExpressEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                if (OperatorCommandType.Reset == e.Command)
                { SetItem(null); }
                else if (OperatorCommandType.View == e.Command)
                { SetItem(e.AgentExpress); }
            }
        }

        void AgentExpressEditor_Load(object sender, EventArgs e)
        {
            cmbPayeeCertPaperType.SelectedIndex = -1;
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属功能模块
        /// AgentExpressIn-快捷代收，AgentExpressOut-快捷代发
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.AgentExpressIn == value || AppliableFunctionType.AgentExpressOut == value || AppliableFunctionType.AgentExpressOut4Bar == value)
                {
                    m_AppType = value;
                    Init();
                }
            }
        }

        private void Init()
        {
            bool flag = m_AppType == AppliableFunctionType.AgentExpressOut || m_AppType == AppliableFunctionType.AgentExpressOut4Bar;
            lbProtecol.Visible = edtProtecolNo.Visible = !flag;
            lbAccount.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccount, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbProvince.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccountProvince : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccountProvince, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbCertiCardType.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyCardType, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbCertiCardNo.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyNo, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbName.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerName, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");

            btnQuery.Visible = m_AppType != AppliableFunctionType.AgentExpressIn;
            pbTip.Visible = m_AppType == AppliableFunctionType.AgentExpressOut;

            if (m_AppType == AppliableFunctionType.AgentExpressOut)
                CommandCenter.Instance.OnAgentExpressPurposeEventHandler += new EventHandler<AgentExpressPurposeEventArgs>(CommandCenter_OnAgentExpressPurposeEventHandler);

            if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
            {
                //label2.Visible = cmbUsage.Visible = false;
                lbProvince.Text = string.Format("收款行省行标识：");
            }
        }

        void CommandCenter_OnAgentExpressPurposeEventHandler(object sender, AgentExpressPurposeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentExpressPurposeEventArgs>(CommandCenter_OnAgentExpressPurposeEventHandler), sender, e); }
            else
            {
                if (e.Owner != m_AppType || e.Command != OperatorCommandType.UseTypeChanged) return;
                cmbUsage.Items.Clear();
                if (e.Purpose == AgentExpressFunctionType.EV)
                {
                    cmbUsage.Items.Add(EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(AgentExpressFunctionType.EV));
                    cmbUsage.Items.Add(EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(AgentExpressFunctionType.E8));
                    cmbUsage.Tag = new List<AgentExpressFunctionType> { AgentExpressFunctionType.EV, AgentExpressFunctionType.E8 };
                }
                else
                {
                    foreach (var item in PrequisiteDataProvideNode.InitialProvide.AgentExpressFunctionTypeList)
                    {
                        if (item == AgentExpressFunctionType.Empty || item == AgentExpressFunctionType.EV) continue;
                        cmbUsage.Items.Add(EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(item));
                    }
                    cmbUsage.Tag = PrequisiteDataProvideNode.InitialProvide.AgentExpressFunctionTypeList.FindAll(o => o != AgentExpressFunctionType.Empty && o != AgentExpressFunctionType.EV);
                }
            }
        }

        [Browsable(false)]
        public AgentExpress AgentExpress
        {
            get
            {
                return m_AgentExpress;
            }
        }
        private AgentExpress m_AgentExpress;

        private AgentTransferBankType m_BankType = AgentTransferBankType.Boc;
        private bool m_CanAdd = false;
        /// <summary>
        /// 是否需要添加
        /// </summary>
        public bool CanAdd
        {
            get { return m_CanAdd; }
        }

        public bool CheckData()
        {
            ResultData rd;
            if (m_BankType == AgentTransferBankType.Boc)
            {
                rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonAccount(edtAccount, edtAccount.Text.Trim(), lbAccount.Text.Trim().Substring(0, lbAccount.Text.Length - 1), 22, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            else if (m_BankType == AgentTransferBankType.Other)
            {
                rd = DataCheckCenter.Instance.CheckPayeeAccount(edtAccount, edtAccount.Text.Trim(), lbAccount.Text.Trim().Substring(0, lbAccount.Text.Length - 1), 25, false, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(edtName, edtName.Text.Trim(), lbName.Text.Trim().Substring(0, lbName.Text.Length - 1), 58, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckCash(edtAmount, edtAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 14, false, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (m_BankType == AgentTransferBankType.Boc)
            {
                if (cmbPayeeAccountProvince.SelectedIndex < 0)
                {
                    this.errorProvider1.SetError(cmbPayeeAccountProvince, string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.DesignMain_Please_Selection, lbProvince.Text.Substring(0, lbProvince.Text.Length - 1)));
                    return false;
                }
            }
            else if (m_BankType == AgentTransferBankType.Other)
            {
                if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
                {
                    if (!string.IsNullOrEmpty(tbOpenBankName.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckClearBankName(tbOpenBankName, tbOpenBankName.Text.Trim(), lbOpenBankName.Text.Substring(0, lbOpenBankName.Text.Length - 1), 80, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    else
                    {
                        this.errorProvider1.SetError(tbOpenBankName, string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, lbOpenBankName.Text.Substring(0, lbOpenBankName.Text.Length - 1)));
                        return false;
                    }
                    if (!string.IsNullOrEmpty(cmbPayeeAccountProvince.Text))
                    {
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(cmbPayeeAccountProvince, cmbPayeeAccountProvince.Text.Trim(), "开户行号", this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                }
                else
                {
                    rd = DataCheckCenter.Instance.CheckCNAPSNo(cmbPayeeAccountProvince, cmbPayeeAccountProvince.Text.Trim(), "开户行号", this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            if (cmbPayeeCertPaperType.SelectedIndex == 1)
            {
                rd = DataCheckCenter.Instance.CheckCertifyCardNo(edtCertPaperNo, edtCertPaperNo.Text.Trim(), cmbPayeeCertPaperType.Text.Trim(), true, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            else if (cmbPayeeCertPaperType.SelectedIndex > 1)
            {
                rd = DataCheckCenter.Instance.CheckCertifyCardNo(edtCertPaperNo, edtCertPaperNo.Text, cmbPayeeCertPaperType.Text.Trim(), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (edtProtecolNo.Visible)
            {
                if (m_BankType == AgentTransferBankType.Other || (m_BankType == AgentTransferBankType.Boc && !string.IsNullOrEmpty(edtProtecolNo.Text)))
                {
                    rd = DataCheckCenter.Instance.CheckProtecolNo(edtProtecolNo, edtProtecolNo.Text.Trim(), lbProtecol.Text.Trim().Substring(0, lbProtecol.Text.Length - 1), 60, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            return true;
        }

        public void GetItem()
        {
            m_AgentExpress = new Entities.AgentExpress();
            m_AgentExpress.AccountNo = edtAccount.Text.Trim();
            m_AgentExpress.AccountName = edtName.Text.Trim();
            m_AgentExpress.Amount = edtAmount.Text.Trim().Replace(",", "");
            try
            {
                if (m_BankType == AgentTransferBankType.Boc)
                    m_AgentExpress.Province = (cmbPayeeAccountProvince.Tag as List<ChinaProvinceType>)[cmbPayeeAccountProvince.SelectedIndex];
                else if (m_BankType == AgentTransferBankType.Other)
                {
                    m_AgentExpress.BankNo = cmbPayeeAccountProvince.Text.Trim();
                    if (null != this.Tag)
                        m_AgentExpress.BankName = (this.Tag as BOC_BATCH_TOOL.Types.CNAP).Name;
                }
            }
            catch { }
            if (cmbPayeeCertPaperType.SelectedIndex > 0)
                m_AgentExpress.CertifyPaperType = (cmbPayeeCertPaperType.Tag as List<AgentExpressCertifyPaperType>)[cmbPayeeCertPaperType.SelectedIndex - 1];
            m_AgentExpress.CertifyPaperNo = edtCertPaperNo.Text.Trim();
            m_AgentExpress.ProtecolNo = edtProtecolNo.Text.Trim();
            m_AgentExpress.UsageType = cmbUsage.SelectedIndex == -1 ? AgentExpressFunctionType.Empty : (cmbUsage.Tag as List<AgentExpressFunctionType>)[cmbUsage.SelectedIndex];
            if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
                m_AgentExpress.BankName = tbOpenBankName.Text.Trim();
            m_CanAdd = m_AppType != AppliableFunctionType.AgentExpressIn && !CommonInformations.Instance.IsExistPayeeInfo(new PayeeInfo { Account = m_AgentExpress.AccountNo, Name = m_AgentExpress.AccountName, OpenBankName = m_AgentExpress.BankName });
        }

        private void SetItem(AgentExpress ae)
        {
            if (null == ae)
            {
                edtAccount.Text =
                edtName.Text =
                edtAmount.Text =
                edtCertPaperNo.Text =
                tbOpenBankName.Text =
                edtProtecolNo.Text = string.Empty;
                if (m_BankType == AgentTransferBankType.Boc) cmbPayeeAccountProvince.SelectedIndex = -1;
                else if (m_BankType == AgentTransferBankType.Other) cmbPayeeAccountProvince.Text = string.Empty;
                cmbPayeeCertPaperType.SelectedIndex = -1;
                cmbUsage.SelectedIndex = -1;
                this.Tag = null;
                this.errorProvider1.Clear();
            }
            else
            {
                edtAccount.Text = ae.AccountNo;
                edtName.Text = ae.AccountName;
                edtAmount.Text = ae.Amount.ToString();
                try
                {
                    if (m_BankType == AgentTransferBankType.Boc)
                    {
                        if (ae.Province == ChinaProvinceType.B0) cmbPayeeAccountProvince.SelectedIndex = -1;
                        else cmbPayeeAccountProvince.SelectedItem = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(ae.Province);
                    }
                    else if (m_BankType == AgentTransferBankType.Other)
                    {
                        cmbPayeeAccountProvince.Text = ae.BankNo;
                        this.Tag = new BOC_BATCH_TOOL.Types.CNAP { Name = ae.BankName, Code = ae.BankNo };
                    }
                    if (ae.CertifyPaperType != AgentExpressCertifyPaperType.Empty)
                        cmbPayeeCertPaperType.SelectedItem = EnumNameHelper<AgentExpressCertifyPaperType>.GetEnumDescription(ae.CertifyPaperType);
                    else cmbPayeeCertPaperType.SelectedIndex = -1;
                }
                catch { }
                edtCertPaperNo.Text = ae.CertifyPaperNo;
                edtProtecolNo.Text = ae.ProtecolNo;
                cmbUsage.SelectedIndex = (cmbUsage.Tag as List<AgentExpressFunctionType>).FindIndex(o => o == ae.UsageType);
                if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
                    tbOpenBankName.Text = ae.BankName;
            }
            m_AgentExpress = ae;
            FormatCash();
        }

        private void ChangeUIShow()
        {
            tbOpenBankName.Text = string.Empty;
            lbProvince.AutoSize = true;
            lblProvince.Visible = true;
            //lblProvince.Visible = m_BankType == AgentTransferBankType.Boc;
            if (m_BankType == AgentTransferBankType.Boc)
            {
                lbProvince.Text = string.Format("{0}{1}", m_AppType == AppliableFunctionType.AgentExpressOut || m_AppType == AppliableFunctionType.AgentExpressOut4Bar ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccountProvince : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccountProvince, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                cmbPayeeAccountProvince.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPayeeAccountProvince.Enabled = true;
                cmbPayeeAccountProvince.SelectedIndex = 0;
                lblProtecolNo.Visible = false;
                //edtProtecolNo.ValidateRule.Required = false;
            }
            else if (m_BankType == AgentTransferBankType.Other)
            {
                lbProvince.Text = string.Format("{0}{1}", m_AppType == AppliableFunctionType.AgentExpressOut ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNo : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerOpenBankNo, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                cmbPayeeAccountProvince.DropDownStyle = ComboBoxStyle.Simple;
                cmbPayeeAccountProvince.Text = string.Empty;
                lblProtecolNo.Visible =
                    //edtProtecolNo.ValidateRule.Required =
                m_AppType == AppliableFunctionType.AgentExpressIn;
                lbProvince.Location = new Point(20, lblProvince.Location.Y);

                if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
                    lbProvince.Text = string.Format("收款行人行行号：");
                lblProvince.Visible = m_AppType != AppliableFunctionType.AgentExpressOut4Bar;
            }
            ResetUI();
            btnQueryBank.Visible = m_BankType == AgentTransferBankType.Other;
            lbProvince.Location = new Point { X = this.lbAmount.Location.X + lbAmount.Width - lbProvince.Width, Y = lblProvince.Location.Y };
            lbAccount.Location = new Point { X = this.lbAmount.Location.X + lbAmount.Width - lbAccount.Width, Y = lbAccount.Location.Y };
            lbCertiCardType.Location = new Point { X = this.lbAmount.Location.X + lbAmount.Width - lbCertiCardType.Width, Y = lbCertiCardType.Location.Y };
            lbCertiCardNo.Location = new Point { X = this.lbAmount.Location.X + lbAmount.Width - lbCertiCardNo.Width, Y = lbCertiCardNo.Location.Y };
            lbProtecol.Location = new Point { X = this.lbAmount.Location.X + lbAmount.Width - lbProtecol.Width, Y = lbProtecol.Location.Y };
            if (lbProvince.Location.X < 0)
            {
                lbProvince.AutoSize = false;
                lbProvince.Width = 120;
                lbProvince.Height = 26;
                lbProvince.Location = new Point { X = this.lbAmount.Location.X + lbAmount.Width - lbProvince.Width, Y = lblProvince.Location.Y };
            }
            p_Bar.Visible = m_AppType == AppliableFunctionType.AgentExpressOut4Bar && m_BankType == AgentTransferBankType.Other;
            cmbPayeeAccountProvince.Enabled = !p_Bar.Visible;
            btnQueryBank.Visible = m_AppType != AppliableFunctionType.AgentExpressOut4Bar && m_BankType == AgentTransferBankType.Other;
        }

        private void ResetUI()
        {
            edtAccount.Text = edtName.Text = string.Empty;
            if (m_BankType == AgentTransferBankType.Boc)
                cmbPayeeAccountProvince.SelectedIndex = -1;
            else if (m_BankType == AgentTransferBankType.Other)
                cmbPayeeAccountProvince.Text = string.Empty;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            wndPayeeQuery frm = new wndPayeeQuery(m_BankType == AgentTransferBankType.Boc ? AccountBankType.BocAccount : AccountBankType.OtherBankAccount);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PayeeInfo payee = frm.Payee;
                edtAccount.Text = payee.Account;
                edtName.Text = payee.Name;
                if (m_BankType == AgentTransferBankType.Other)
                {
                    cmbPayeeAccountProvince.Text = payee.CNAPSNo;
                    tbOpenBankName.Text = payee.OpenBankName;
                    this.Tag = new BOC_BATCH_TOOL.Types.CNAP { Name = payee.OpenBankName, Code = payee.CNAPSNo };
                }
            }
            if (frm != null)
                frm.Close();
        }

        private void llMsg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CommandCenter.Instance.ResolveShowPanel(OperatorCommandType.View, AppliableFunctionType._Empty, FunctionInSettingType.PayeeMg);
        }

        private void btnQueryBank_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery();
            frm.IsOpenBank = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cmbPayeeAccountProvince.Text = frm.QueryDialogResult.Code;
                this.Tag = frm.QueryDialogResult;
                if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
                    tbOpenBankName.Text = frm.QueryDialogResult.Name;
            }
            if (frm != null)
                frm.Close();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(AgentExpressEditor), this);

            Init();
            ChangeUIShow();
            InitData();
        }

        private void pibTip_MouseHover(object sender, EventArgs e)
        {
            if (m_AppType == AppliableFunctionType.AgentExpressOut)
                toolTip1.Show(MultiLanguageConvertHelper.Instance.Tips_Pyaee_6Numbers, pbTip);
        }
    }
}
