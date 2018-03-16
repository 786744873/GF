using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class BatchCommonItemPanel : BaseUc
    {
        public BatchCommonItemPanel()
        {
            InitializeComponent();
            Init();
            CommandCenter.Instance.OnCommonDataEventHandler += new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                ApplyResource();
                Init();
            }
        }

        private int original_index = -1;
        Dictionary<AppliableFunctionType, CommonFieldType> dic = new Dictionary<AppliableFunctionType, CommonFieldType>();

        void CommandCenter_OnCommonDataEventHandler(object sender, CommonDataEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler), new object[] { sender, e }); }
            else
            {
                if (OperatorCommandType.CommonFieldRequest == e.Command)
                {
                    if (this.cbAppType.SelectedIndex < 0)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_CommonData_Select_BusinessType, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    GetCurrentCommonFieldsList(this.original_index);
                    CommandCenter.Instance.ResolveCommonData(OperatorCommandType.CommonFieldResolve, dic);
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Submit_Succeed, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Init()
        {
            cbAppType.Items.Clear();
            this.cbAppType.Items.Add(EnumNameHelper<AgentTransferBankType>.GetEnumDescription(AppliableFunctionType.TransferWithIndiv));
            this.cbAppType.Items.Add(EnumNameHelper<AgentTransferBankType>.GetEnumDescription(AppliableFunctionType.TransferWithCorp));

            chbPayer.Tag = CommonFieldType.PayerInfo;
            chbDate.Tag = CommonFieldType.PaidDate;
            chbOrder.Tag = CommonFieldType.OperatorOrder;
            chbOrder.Tag = CommonFieldType.PayFeeNo;

            dic = SystemSettings.Instance.CommonFieldList;
            cbAppType.SelectedIndex = -1;
        }

        private void cbAppType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAppType.SelectedIndex < 0) return;
            AppliableFunctionType aft = (AppliableFunctionType)((int)Math.Pow(2, cbAppType.SelectedIndex));
            if (AppliableFunctionType.TransferWithIndiv == aft || AppliableFunctionType.TransferWithCorp == aft)
            {
                chbDate.Visible = chbOrder.Visible = chbPayer.Visible = chbPayFeeNo.Visible = true;
                if (original_index != cbAppType.SelectedIndex)
                {
                    GetCurrentCommonFieldsList(this.original_index);
                }
                original_index = cbAppType.SelectedIndex;
                SetItem();
            }
            else
            {
                chbDate.Visible = chbOrder.Visible = chbPayer.Visible = chbPayFeeNo.Visible = false;
            }
        }

        private void SetItem()
        {
            AppliableFunctionType aft = (AppliableFunctionType)((int)Math.Pow(2, this.original_index));
            if (!dic.ContainsKey(aft) || dic[aft] == CommonFieldType.Empty)
            {
                chbPayer.Checked =
                chbDate.Checked =
                chbOrder.Checked =
                chbPayFeeNo.Checked = false;
            }
            else
            {
                chbPayer.Checked = (dic[aft] & CommonFieldType.PayerInfo) == CommonFieldType.PayerInfo;
                chbDate.Checked = (dic[aft] & CommonFieldType.PaidDate) == CommonFieldType.PaidDate;
                chbOrder.Checked = (dic[aft] & CommonFieldType.OperatorOrder) == CommonFieldType.OperatorOrder;
                chbPayFeeNo.Checked = (dic[aft] & CommonFieldType.PayFeeNo) == CommonFieldType.PayFeeNo;
            }
        }

        private CommonFieldType GetCommonFields()
        {
            CommonFieldType cft = CommonFieldType.Empty;
            cft = chbPayer.Checked ? cft | CommonFieldType.PayerInfo : cft;
            cft = chbDate.Checked ? cft | CommonFieldType.PaidDate : cft;
            cft = chbOrder.Checked ? cft | CommonFieldType.OperatorOrder : cft;
            cft = chbPayFeeNo.Checked ? cft | CommonFieldType.PayFeeNo : cft;
            return cft;
        }

        private void GetCurrentCommonFieldsList(int o_index)
        {
            AppliableFunctionType aft = (AppliableFunctionType)((int)Math.Pow(2, o_index));
            if (!dic.ContainsKey(aft))
            {
                dic.Add(aft, CommonFieldType.Empty);
            }
            dic[aft] = GetCommonFields();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(BatchCommonItemPanel), this);

            Init();
        }
    }
}
