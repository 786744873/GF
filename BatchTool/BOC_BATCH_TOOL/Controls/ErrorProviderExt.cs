using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;

namespace BOC_BATCH_TOOL.Controls
{
    public partial class ErrorProviderExt : ErrorProvider
    {
        public ErrorProviderExt()
        {
            InitializeComponent();
        }

        public ErrorProviderExt(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private ResultData m_resultData;

        public ResultData ResultData
        {
            get { return m_resultData; }
            set { m_resultData = value; }
        }
    }
}
