using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CommonClient.Types;
using CommonClient.Utilities;

namespace CommonClient.Controls
{
    public partial class LanguageListEditor : Form
    {
        private readonly IWindowsFormsEditorService _editorService;
        private readonly Container _components;
        private Control _hostControl;

        public string SelectedLanId { get; private set; }

        public LanguageListEditor(IWindowsFormsEditorService editorService, Control control)
        {
            InitializeComponent();
            this._hostControl = control;
            this._editorService = editorService;
            //this._components = _components;
            this.listView1.Items.Clear();
            foreach (TranslatingKeyAttribute attribute in LanguageList.LangList)
            {
                var newItem = this.listView1.Items.Add(attribute.LanKey);
                newItem.Tag = attribute;
                newItem.SubItems.Add(attribute.C);
                newItem.SubItems.Add(attribute.E);
            }
            this.label1.Text = string.Empty;
        }

        public void FindAndSelectItemByCnText(string cnText)
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                if (string.Equals((item.Tag as TranslatingKeyAttribute).C, cnText, StringComparison.CurrentCultureIgnoreCase))
                {
                    ListViewItem selectedItem = item;
                    this.listView1.FocusedItem = selectedItem;
                    var xIndex = this.listView1.Items.IndexOf(selectedItem);
                    this.listView1.Items[xIndex].Selected = true;
                    this.listView1.EnsureVisible(xIndex);
                    break;
                }
            }
        }

        public void FindAndSelectItemByLangKey(string langKey)
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                if (string.Equals((item.Tag as TranslatingKeyAttribute).LanKey, langKey, StringComparison.CurrentCultureIgnoreCase))
                {
                    ListViewItem selectedItem = item;
                    this.listView1.FocusedItem = selectedItem;
                    var xIndex = this.listView1.Items.IndexOf(selectedItem);
                    this.listView1.Items[xIndex].Selected = true;
                    this.listView1.EnsureVisible(xIndex);
                    break;
                }
            }
        }

        private void LblValidatorItems_Click(object sender, EventArgs e)
        {
            if (this.listView1.FocusedItem == null)
                return;
            var selectedKeyAttribute = (this.listView1.FocusedItem.Tag as TranslatingKeyAttribute);
            SelectedLanId = selectedKeyAttribute != null ? selectedKeyAttribute.LanKey : string.Empty;
            this._editorService.CloseDropDown();
        }

        private void LblValidatorItems_DoubleClick(object sender, EventArgs e)
        {
            this.btnOk.PerformClick();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void _btnQuickFind_Click(object sender, EventArgs e)
        {
            this._edtQuickFind.Text = string.Empty;
        }

        private Button btnClear;
        private TextBox _edtQuickFind;
        private Label _lblQuickFind;

        private void _edtQuickFind_TextChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in this.listView1.Items)
            {
                listViewItem.Selected = false;
            }

            var value = this._edtQuickFind.Text.Trim();
            if (string.IsNullOrEmpty(value))
                return;

            var hitCount = 0;
            foreach (ListViewItem item in this.listView1.Items)
            {
                var subHited = false;
                var xIndex = this.listView1.Items.IndexOf(item);
                if (item.Text.Contains(value))
                {
                    item.Selected = true;
                    this.listView1.EnsureVisible(xIndex);
                    subHited = true;
                }
                else
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (subItem.Text.Contains(value))
                        {
                            item.Selected = true;
                            this.listView1.EnsureVisible(xIndex);
                            subHited = true;
                        }
                    }
                }
                if (subHited)
                    hitCount++;
            }

            this.label1.Text = "Found match item(s) : " + hitCount;
        }
    }

}

