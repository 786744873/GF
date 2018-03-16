using System;
using System.ComponentModel;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class SpplyFinancingOrderMgrEditor : BaseUc
    {
        public SpplyFinancingOrderMgrEditor()
        {
            InitializeComponent();
            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            CommandCenter.OnSpplyFinancingOrderEventHandler += new EventHandler<SpplyFinancingOrderEventArgs>(CommandCenter_OnSpplyFinancingOrderEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            SetRegex();
        }
        private void SetRegex()
        {
            tbOrderNo.DvRegCode = "reg717";
            tbOrderNo.DvMinLength = 1;
            tbOrderNo.DvMaxLength = 70;
            //金额校验
            //tbAmount.DvRegCode = "reg43";
            //tbAmount.DvMinLength = 1;
            //tbAmount.DvMaxLength = 15;
            //rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;

        }
        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(SpplyFinancingOrderMgrEditor), this);
            }
        }

        void CommandCenter_OnSpplyFinancingOrderEventHandler(object sender, SpplyFinancingOrderEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SpplyFinancingOrderEventArgs>(CommandCenter_OnSpplyFinancingOrderEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.SpplyFinancingOrder);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbAmount.Text))
            {
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1);
                if (!rd.Result) return;
                tbAmount.Text = DataConvertHelper.FormatCash(tbAmount.Text.Trim(), false);
            }
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属功能模块
        /// PurchaserOrderMgr-，SellerOrderMgr-
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.PurchaserOrderMgr == value || AppliableFunctionType.SellerOrderMgr == value)
                {
                    m_AppType = value;
                }
            }
        }

        private SpplyFinancingOrder m_order;
        /// <summary>
        /// 订单信息
        /// </summary>
        public SpplyFinancingOrder Order
        {
            get { return m_order; }
            protected set { m_order = value; }
        }

        public void GetItem()
        {
            m_order = new SpplyFinancingOrder();
            m_order.OrderNo = tbOrderNo.Text.Trim();
            m_order.Amount = tbAmount.Text.Replace(",", "");
        }

        void SetItem(SpplyFinancingOrder item)
        {
            if (null == item)
            {
                tbOrderNo.Text = tbAmount.Text = string.Empty;
            }
            else
            {
                tbAmount.Text = item.Amount.ToString();
                tbOrderNo.Text = item.OrderNo;
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //rd = DataCheckCenter.CheckOrderNo(tbOrderNo, tbOrderNo.Text.Trim(), lbOrderNo.Text.Substring(0, lbOrderNo.Text.Length - 1), 70, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            rd.Result = rd.Result && DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1).Result;

            return rd.Result;
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(tbAmount.Text.Trim());
        }
    }
}
