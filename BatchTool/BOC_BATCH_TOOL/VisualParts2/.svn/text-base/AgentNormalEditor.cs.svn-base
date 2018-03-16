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
    public partial class AgentNormalEditor : BaseUc
    {
        public AgentNormalEditor()
        {
            InitializeComponent();
            InitData();

            CommandCenter.Instance.OnAgentNormalEventHandler += new EventHandler<AgentNormalEventArgs>(CommandCenter_OnAgentNormalEventHandler);
            CommandCenter.Instance.OnCardTypeChangedEventHandler += new EventHandler<CardTypeChangedEventArgs>(CommandCenter_OnCardTypeChangedEventHandler);
            CommandCenter.Instance.OnUseTypeChangedEventHandler += new EventHandler<UseTypeChangedEventArgs>(CommandCenter_OnUseTypeChangedEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            edtAmount.LostFocus += new EventHandler(edtAmount_LostFocus);
        }

        private void InitData()
        {
            cmbCertPaperType.Items.Clear();
            foreach (AgentNormalCertifyPaperType certifyPaperType in PrequisiteDataProvideNode.InitialProvide.AgentNormalCertifyPaperTypeList)
            {
                if (certifyPaperType == AgentNormalCertifyPaperType.Empty) continue;
                var value = EnumNameHelper<AgentTransferBankType>.GetEnumDescription(certifyPaperType);
                this.cmbCertPaperType.Items.Add(value);
            }
            this.cmbCertPaperType.Tag = PrequisiteDataProvideNode.InitialProvide.AgentNormalCertifyPaperTypeList.FindAll(o => o != AgentNormalCertifyPaperType.Empty);
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

        void CommandCenter_OnUseTypeChangedEventHandler(object sender, UseTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UseTypeChangedEventArgs>(CommandCenter_OnUseTypeChangedEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.AppType != m_AppType || m_AppType == AppliableFunctionType.AgentNormalIn) return;
                if (e.Command != OperatorCommandType.UseTypeChanged) return;
                if (e.UseType == AgentBusinessType.Salary)
                {
                    cbNotice.Text = string.Empty;
                    cbNotice.Items.Clear();
                    cbNotice.Items.Add(EnumNameHelper<AgentNormalFunctionType>.GetEnumDescription(AgentNormalFunctionType.A10));
                    cbNotice.Tag = new List<AgentNormalFunctionType> { AgentNormalFunctionType.A10 };
                    cbNotice.SelectedIndex = 0;
                    lbNotice.Visible = false;
                }
                else
                {
                    lbNotice.Visible = true;
                    cbNotice.Text = string.Empty;
                    cbNotice.Items.Clear();
                    foreach (AgentNormalFunctionType item in PrequisiteDataProvideNode.InitialProvide.AgentNormalFunctionTypeList)
                    {
                        if (item == AgentNormalFunctionType.A10 || item == AgentNormalFunctionType.Empty) continue;
                        var value = EnumNameHelper<AgentNormalFunctionType>.GetEnumDescription(item);
                        cbNotice.Items.Add(value);
                    }
                    cbNotice.Tag = PrequisiteDataProvideNode.InitialProvide.AgentNormalFunctionTypeList.FindAll(o => o != AgentNormalFunctionType.A10 && o != AgentNormalFunctionType.Empty);
                    cbNotice.SelectedIndex = -1;
                }
                //cbNotice.SelectedIndex = e.UseType == AgentBusinessType.Salary ? 0 : -1;
            }
        }

        void CommandCenter_OnCardTypeChangedEventHandler(object sender, CardTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CardTypeChangedEventArgs>(CommandCenter_OnCardTypeChangedEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.AppType != m_AppType) return;
                if (e.Command != OperatorCommandType.CardTypeChanged) return;
                edtAccount.Text = edtName.Text = edtBankNo.Text = edtBankName.Text = string.Empty;
                InitCardType(e.CardType);
                m_AgentCardType = e.CardType;
            }
        }

        private void InitCardType(AgentCardType cardType)
        {
            if (cardType == AgentCardType.OtherBankCard)
            {
                lbBankNo.Text = string.Format("{0}{1}", m_AppType == AppliableFunctionType.AgentNormalOut ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeOpenBankNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerOpenBankNo, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                edtBankName.Visible = lbBankName.Visible = false;
            }
            else
            {
                lbBankNo.Text = string.Format("{0}{1}", m_AppType == AppliableFunctionType.AgentNormalOut ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeBankLinkNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerBankLinkNo, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                btnQueryBankNo.Visible = true;
                edtBankName.Text = EnumNameHelper<AccountBankType>.GetEnumDescription(AccountBankType.BocAccount);
            }
            lbBankNo.AutoSize = true;
            edtBankName.Visible = lbBankName.Visible = cardType != AgentCardType.OtherBankCard;
            lbBankNo.Location = new Point { X = lbName.Location.X + lbName.Width - lbBankNo.Width, Y = lbBankNo.Location.Y };
            lbBankName.Location = new Point { X = lbName.Location.X + lbName.Width - lbBankName.Width, Y = lbBankName.Location.Y };
            if (lbBankNo.Location.X < 0)
            {
                lbBankNo.AutoSize = false;
                lbBankNo.Width = 110;
                lbBankNo.Height = 26;
                lbBankNo.Location = new Point { X = lbName.Location.X + lbName.Width - lbBankNo.Width, Y = lbBankNo.Location.Y };
            }
            else lbBankNo.AutoSize = true;
        }

        void CommandCenter_OnAgentNormalEventHandler(object sender, AgentNormalEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentNormalEventArgs>(CommandCenter_OnAgentNormalEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                if (OperatorCommandType.Reset == e.Command)
                { SetItem(null); }
                else if (OperatorCommandType.View == e.Command)
                { SetItem(e.AgentNormal); }
            }
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属功能模块
        /// AgentNormalIn-普通代收，AgentNormalOut-普通代发
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.AgentNormalIn == value || AppliableFunctionType.AgentNormalOut == value)
                {
                    m_AppType = value;
                    Init();
                }
            }
        }

        private void Init()
        {
            bool flag = AppliableFunctionType.AgentNormalOut == m_AppType;
            lbNotice.Visible = lbProtecolNo.Visible = txtProtecolNo.Visible = !flag;
            cbNotice.DropDownStyle = !flag ? ComboBoxStyle.Simple : ComboBoxStyle.DropDownList;
            lbAccount.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeAccount : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerAccount, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbName.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerName, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbBankNo.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeBankLinkNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerOpenBankNo, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbBankName.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeBankName : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerBankName, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbAmount.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Amount : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Amount, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbCertiCardType.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyCardType : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyCardType, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbCertiCardNo.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyNo, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");

            btnQueryAccount.Visible = m_AppType != AppliableFunctionType.AgentNormalIn;

            lbAmount.Location = new Point { X = lbName.Location.X + lbName.Width - lbAmount.Width, Y = lbAmount.Location.Y };
            lbCertiCardType.Location = new Point { X = lbName.Location.X + lbName.Width - lbCertiCardType.Width, Y = lbCertiCardType.Location.Y };
            lbCertiCardNo.Location = new Point { X = lbName.Location.X + lbName.Width - lbCertiCardNo.Width, Y = lbCertiCardNo.Location.Y };
            lbProtecolNo.Location = new Point { X = lbName.Location.X + lbName.Width - lbProtecolNo.Width, Y = lbProtecolNo.Location.Y };
        }

        [Browsable(false)]
        public AgentNormal AgentNormal
        {
            get
            {
                return m_AgentNormal;
            }
        }
        private AgentNormal m_AgentNormal;
        private AgentCardType m_AgentCardType = AgentCardType.MemoryCard;
        public bool CanAdd { get; set; }

        public bool CheckData()
        {
            ResultData rd = DataCheckCenter.Instance.CheckPayeeAccount(edtAccount, edtAccount.Text.Trim(), lbAccount.Text.Trim().Substring(0, lbAccount.Text.Length - 1),
                m_AgentCardType == AgentCardType.MemoryCard ? 22 : m_AgentCardType == AgentCardType.QCCCard ? 16 : m_AgentCardType == AgentCardType.OtherBankCard ? 35 : 0,
                m_AgentCardType == AgentCardType.QCCCard, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(edtName, edtName.Text.Trim(), lbName.Text.Trim().Substring(0, lbName.Text.Length - 1), m_AppType == AppliableFunctionType.AgentNormalIn ? 30 : 20, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (m_AgentCardType == AgentCardType.OtherBankCard)
            {
                rd = DataCheckCenter.Instance.CheckOpenBankName(edtBankNo, edtBankNo.Text.Trim(), lbBankName.Text.Substring(0, lbBankName.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            else
            {
                rd = DataCheckCenter.Instance.CheckLinkBankNo(edtBankNo, edtBankNo.Text.Trim(), lbBankNo.Text.Substring(0, lbBankNo.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (cmbCertPaperType.SelectedIndex == 1)
            {
                rd = DataCheckCenter.Instance.CheckCertifyCardNo(edtCertPaperNo, edtCertPaperNo.Text.Trim(), cmbCertPaperType.Text.Trim(), true, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            else if (cmbCertPaperType.SelectedIndex > 1)
            {
                rd = DataCheckCenter.Instance.CheckCertifyCardNo(edtCertPaperNo, edtCertPaperNo.Text, cmbCertPaperType.Text.Trim(), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckCash(edtAmount, edtAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), m_AppType == AppliableFunctionType.AgentNormalIn ? 14 : 15, false, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (m_AppType == AppliableFunctionType.AgentNormalOut)
            {
                if (this.cbNotice.SelectedIndex < 0)
                {
                    this.errorProvider1.SetError(cbNotice, string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.DesignMain_Please_Selection, "用途"));
                    return false;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(cbNotice.Text))
                {
                    rd = DataCheckCenter.Instance.CheckAddtion(cbNotice, cbNotice.Text, "笔信息用途", 80, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            if (!string.IsNullOrEmpty(txtProtecolNo.Text.Trim()))
            {
                rd = DataCheckCenter.Instance.CheckProtecolNo(txtProtecolNo, txtProtecolNo.Text.Trim(), lbProtecolNo.Text.Substring(0, lbProtecolNo.Text.Length - 1), 60, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return true;
        }

        public void GetItem()
        {
            m_AgentNormal = new Entities.AgentNormal();
            m_AgentNormal.AccountNo = edtAccount.Text.Trim();
            m_AgentNormal.AccountName = edtName.Text.Trim();
            if (m_AgentCardType != AgentCardType.OtherBankCard)
            {
                m_AgentNormal.BankNo = edtBankNo.Text.Trim();
                m_AgentNormal.BankName = edtBankName.Text.Trim();
            }
            else
            {
                m_AgentNormal.BankName = edtBankName.Text.Trim();
                m_AgentNormal.BankNo = edtBankNo.Text.Trim();
            }
            m_AgentNormal.Amount = edtAmount.Text.Trim().Replace(",", "");
            if (cmbCertPaperType.SelectedIndex >= 0)
                m_AgentNormal.CertifyPaperType = (cmbCertPaperType.Tag as List<AgentNormalCertifyPaperType>)[cmbCertPaperType.SelectedIndex];
            if (m_AppType == AppliableFunctionType.AgentNormalOut)
            {
                if (cbNotice.DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    if (cbNotice.SelectedIndex >= 0)
                        m_AgentNormal.UseType = (cbNotice.Tag as List<AgentNormalFunctionType>)[cbNotice.SelectedIndex];
                    else m_AgentNormal.UseType = AgentNormalFunctionType.Empty;
                }
            }
            else if (m_AppType == AppliableFunctionType.AgentNormalIn)
            {
                m_AgentNormal.UseType_In = cbNotice.Text;
            }
            m_AgentNormal.CertifyPaperNo = edtCertPaperNo.Text.Trim();
            m_AgentNormal.ProtecolNo = txtProtecolNo.Text.Trim();
            CanAdd = m_AppType != AppliableFunctionType.AgentNormalIn && !CommonInformations.Instance.IsExistPayeeInfo(new PayeeInfo { Account = m_AgentNormal.AccountNo, Name = m_AgentNormal.AccountName, OpenBankName = m_AgentNormal.BankName });
        }

        private void SetItem(AgentNormal an)
        {
            if (null == an)
            {
                edtAccount.Text = string.Empty;
                edtName.Text = string.Empty;
                edtBankNo.Text = string.Empty;
                edtBankName.Text = "中国银行";
                edtAmount.Text = string.Empty;
                cmbCertPaperType.SelectedIndex = -1;
                cmbCertPaperType.Text = string.Empty;
                edtCertPaperNo.Text = string.Empty;
                if (cbNotice.DropDownStyle == ComboBoxStyle.DropDownList)
                    cbNotice.SelectedIndex = cbNotice.Items.Count == 1 ? 0 : -1;
                cbNotice.Text = string.Empty;
                txtProtecolNo.Text = string.Empty;
                this.errorProvider1.Clear();
            }
            else
            {
                edtAccount.Text = an.AccountNo;
                edtName.Text = an.AccountName;
                edtAmount.Text = an.Amount.ToString();
                try
                {
                    cmbCertPaperType.SelectedItem =
                        cmbCertPaperType.Text =
                        EnumNameHelper<AgentNormalCertifyPaperType>.GetEnumDescription(an.CertifyPaperType);
                }
                catch { }
                edtCertPaperNo.Text = an.CertifyPaperNo;
                if (cbNotice.DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    cbNotice.Text = an.UseTypeString;
                    if (!string.IsNullOrEmpty(an.UseTypeString))
                        cbNotice.SelectedItem = an.UseTypeString;
                }
                else cbNotice.Text = an.UseType_In;
                txtProtecolNo.Text = an.ProtecolNo;
                edtBankNo.Text = an.BankNo;
                edtBankName.Text = an.BankName;
            }
            m_AgentNormal = an;
            FormatCash();
        }

        private void btnQueryBankNo_Click(object sender, EventArgs e)
        {
            if (m_AgentCardType != AgentCardType.OtherBankCard)
            {
                wndLinkBankNo wlbn = new wndLinkBankNo();
                if (wlbn.ShowDialog() == DialogResult.OK)
                {
                    edtBankNo.Text = wlbn.BankInfo.LinkID;
                    //edtBankName.Text = wlbn.BankInfo.BankName;
                }
                if (wlbn != null)
                    wlbn.Close();
            }
            else if (m_AgentCardType == AgentCardType.OtherBankCard)
            {
                wndOpenBankQuery frm = new wndOpenBankQuery();
                frm.IsOpenBank = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    edtBankNo.Text = frm.QueryDialogResult.Code;
                    edtBankName.Text = frm.QueryDialogResult.Name;
                }
                if (frm != null)
                    frm.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CommandCenter.Instance.ResolveShowPanel(OperatorCommandType.View, AppliableFunctionType._Empty, FunctionInSettingType.PayeeMg);
        }

        private void btnQueryAccount_Click(object sender, EventArgs e)
        {
            wndPayeeQuery frm = new wndPayeeQuery(m_AgentCardType == AgentCardType.Empty ? AccountBankType.Empty : (m_AgentCardType == AgentCardType.OtherBankCard ? AccountBankType.OtherBankAccount : AccountBankType.BocAccount));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                edtAccount.Text = frm.Payee.Account;
                edtName.Text = frm.Payee.Name;
                if (m_AgentCardType == AgentCardType.OtherBankCard)
                {
                    edtBankNo.Text = frm.Payee.CNAPSNo;
                    edtBankName.Text = frm.Payee.OpenBankName;
                }
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
            base.ApplyResource(typeof(AgentNormalEditor), this);

            Init();
            InitCardType(m_AgentCardType);
            InitData();

            List<AgentNormalFunctionType> list = cbNotice.Tag as List<AgentNormalFunctionType>;
            cbNotice.Items.Clear();
            if (null != list && list.Count > 0)
            {
                foreach (var item in list)
                {
                    cbNotice.Items.Add(EnumNameHelper<AgentNormalFunctionType>.GetEnumDescription(item));
                }
            }
        }
    }

}
