using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BOC_App_Autotest
{
    public partial class EditorValidateStuff : UserControl
    {
        public EditorValidateStuff()
        {
            InitializeComponent();
        }

        public string ElementName { get { return this.lblElementName.Text; } set { this.lblElementName.Text = value; } }
        public string[] ValidValues { get { return this.edtValidValues.Lines; } set { this.edtValidValues.Lines = value; } }
        public string[] InvalidValues { get { return this.edtInvalidValues.Lines; } set { this.edtInvalidValues.Lines = value; } }
        public void SetStuffNodeToUI(EditorValidateStuffNode node)
        {
            this.ElementName = node.ElementName;
            this.ValidValues = node.ValidValues;
            this.InvalidValues = node.InvalidValues;
        }

        public EditorValidateStuffNode GetStuffNodeFromUI()
        {
            var result = new EditorValidateStuffNode { ElementName = this.ElementName, ValidValues = this.ValidValues, InvalidValues = this.InvalidValues};
            return result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void edtValidValues_TextChanged(object sender, EventArgs e)
        {
            var values = new List<string>(this.edtValidValues.Lines);
            var count = values.FindAll(item => !string.IsNullOrEmpty(item.Trim())).Count;
            var length = 0;
            foreach (string value in values)
            {
                var xLength = value.Trim().Length;
                if (xLength > length)
                    length = xLength;
            }
            this.lblValidValueCount.Text = string.Format("共有 {0} 行值，并且长度最长的值为 {1} ", count, length);
        }

        private void edtInvalidValues_TextChanged(object sender, EventArgs e)
        {
            var values = new List<string>(this.edtInvalidValues.Lines);
            var count = values.FindAll(item => !string.IsNullOrEmpty(item.Trim())).Count;
            var length = 0;
            foreach (string value in values)
            {
                var xLength = value.Trim().Length;
                if (xLength > length)
                    length = xLength;
            }
            this.lblInvalidValueCount.Text = string.Format("共有 {0} 行值，并且长度最长的值为 {1} ", count, length);
        }
    }

    [Serializable]
    public class EditorValidateStuffNode
    {
        public string ElementName { get; set; }
        [XmlArrayItem("ValidValues")]
        public string[] ValidValues { get; set; }
        [XmlArrayItem("InvalidValues")]
        public string[] InvalidValues { get; set; }
    }
}
