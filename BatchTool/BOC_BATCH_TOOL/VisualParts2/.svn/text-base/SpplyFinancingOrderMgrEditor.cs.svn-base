using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class SpplyFinancingOrderMgrEditor : BaseUc
    {
        public SpplyFinancingOrderMgrEditor()
        {
            InitializeComponent();
            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            CommandCenter.Instance.OnSpplyFinancingOrderEventHandler += new EventHandler<SpplyFinancingOrderEventArgs>(CommandCenter_OnSpplyFinancingOrderEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
                tbAmount.Text = DataConvertHelper.Instance.FormatCash(tbAmount.Text.Trim(), false);
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
            ResultData rd = new ResultData();
            rd = DataCheckCenter.Instance.CheckOrderNo(tbOrderNo, tbOrderNo.Text.Trim(), lbOrderNo.Text.Substring(0, lbOrderNo.Text.Length - 1), 70, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            return rd.Result;
        }
    }
}
