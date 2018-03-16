using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonClient
{
    public partial class frmVersion : frmBase
    {
        public frmVersion()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmVersion_Load);
        }

        void frmVersion_Load(object sender, EventArgs e)
        {
            label2.Text = string.Format("版本号：{0}", GetVersion());
        }

        private string GetVersion()
        {
            string version = string.Empty;
            System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                if (!assembly.FullName.Contains("CommonClient")) continue;
                List<string> list = new List<string>();
                list.AddRange(assembly.FullName.Split(new string[] { "," }, StringSplitOptions.None));
                version = list.Find(o => o.ToLower().Contains("version"));
                if (string.IsNullOrEmpty(version)) version = "1,0,0,0";
                else version = version.ToLower().Replace("version=", "");
                break;
            }
            return version;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
