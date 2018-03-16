using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using CommonClient.SysCoach;

namespace CommonClient.Controls
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

        public ResultData ResultData { get; set; }

    }
}
