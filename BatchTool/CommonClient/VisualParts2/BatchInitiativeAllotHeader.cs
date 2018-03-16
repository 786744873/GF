using System;
using System.ComponentModel;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class BatchInitiativeAllotHeader : BaseUc
    {
        public BatchInitiativeAllotHeader()
        {
            InitializeComponent();
            dtpDate.MinDate = DateTime.Today;
            dtpDate.MaxDate = DateTime.Today.AddMonths(1);

            CommandCenter.OnInitiativeAllotEventHandler += new EventHandler<InitiativeAllotEventArgs>(CommandCenter_OnInitiativeAllotEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            SetRegex();
        }
        private void SetRegex()
        {

            tbCustomerNo.DvRegCode = "reg8";
            tbCustomerNo.DvMinLength = 0;
            tbCustomerNo.DvMaxLength = 16;

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

        void CommandCenter_OnInitiativeAllotEventHandler(object sender, InitiativeAllotEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<InitiativeAllotEventArgs>(CommandCenter_OnInitiativeAllotEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                if (e.Command == OperatorCommandType.New)
                {
                    dtpDate.Value = dtpDate.MinDate;
                    tbCustomerNo.Text = string.Empty;
                    this.errorProvider1.Clear();
                }
                else if (e.Command == OperatorCommandType.Open)
                {
                    tbCustomerNo.Text = e.BatchInfo.ProtecolNo;
                    try
                    {
                        dtpDate.Value = e.BatchInfo.TransferDatetime;
                    }
                    catch { }
                }
            }
        }

        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.InitiativeAllot == value)
                {
                    m_AppType = value;
                }
            }
        }
        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return CheckData(false); }
        }
        [Browsable(true)]
        public bool IsFileConvert { get; set; }

        [Browsable(false)]
        public BatchHeader BatchInfo
        {
            get
            {
                if (CheckData(false))
                    GetItem();
                return m_batchInfo;
            }
        }
        private BatchHeader m_batchInfo;

        private bool CheckData(bool flag)
        {
            ResultData rd = new ResultData { Result = true }; 
            //if (!string.IsNullOrEmpty(tbCustomerNo.Text))
            //{
            //    rd = DataCheckCenter.CheckCustomerNoInitiativeAllot(tbCustomerNo, tbCustomerNo.Text.Trim(), lbCustomNo.Text.Substring(0, lbCustomNo.Text.Length - 1), flag ? this.errorProvider1 : null);
            //}
            //else rd.Result = true;
            return rd.Result;
        }

        public bool CheckData()
        {
            return CheckData(true);
        }

        public void GetItem()
        {
            m_batchInfo = new BatchHeader();
            m_batchInfo.TransferDatetime = dtpDate.Value;
            m_batchInfo.ProtecolNo = tbCustomerNo.Text.Trim();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(BatchInitiativeAllotHeader), this);
        }
    }
}
