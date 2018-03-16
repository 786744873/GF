using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonClient.Contract;
using CommonClient.Controls;
using CommonClient.Utilities;
using CommonClient.VisualParts;

namespace BOC_App_Autotest
{
    [DesignTimeVisible(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_AUTOTEST", false, 999, "校验规则自动化测试", null, ModuleWorkSpaceType.AutoTestingModule)]
    public partial class MainView : _BaseModule
    {
        private IModuleWorkSpace _targetBusinessModule;
        private IModuleWorkSpace _topBusinessModule;
        public MainView()
        {
            InitializeComponent();
            var workArea = Screen.FromControl(this).WorkingArea;
            this.Location = new Point((workArea.Width - this.Width) / 2, (workArea.Height - this.Height) / 2);
        }

        private static readonly List<IDataValidateControl> ValidatorControls = new List<IDataValidateControl>();

        public override void Run(object parameter)
        {
            base.Run(parameter);
            LoadTargetFormValidators(parameter as IModuleWorkSpace);
            this.lblModuleName.Text = (parameter as IModuleWorkSpace).ModuleWorkSpaceInfoAttribute.BusinessName;
        }

        public void LoadTargetFormValidators(IModuleWorkSpace businessModule)
        {
            _targetBusinessModule = businessModule;
            if (_topBusinessModule != _targetBusinessModule)
            {
                _topBusinessModule = _targetBusinessModule;
                this.flowLayoutPanel1.Controls.Clear();
            }
            this.tvValidatorControls.Nodes.Clear();
            var aNode = this.tvValidatorControls.Nodes.Add("All Validator Controls");
            GoThroughValidatorsViaContainer((businessModule as ContainerControl), aNode);
            this.tvValidatorControls.ExpandAll();
        }

        private void GoThroughValidatorsViaContainer(Control control, TreeNode presenterNode)
        {
            if (control is IDataValidateEditor && control.Visible)
            {
                bool IsDropDown = false;
                if (control is ComboBox)
                {
                    var contr = control as ComboBox;
                    if (contr.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        IsDropDown = true;
                    }
                }
                if (!IsDropDown)
                {
                    var aEditor = control as IDataValidateEditor;
                    var newNode = presenterNode.Nodes.Add("Editor: " + (aEditor.DvLinkedLabel != null ? aEditor.DvLinkedLabel.Text : control.Name));
                    newNode.Name = aEditor.DvLinkedLabel != null ? aEditor.DvLinkedLabel.Text : control.Name;
                    newNode.ImageIndex = 1;
                    newNode.SelectedImageIndex = 1;
                    newNode.Tag = aEditor;
                    ValidatorControls.Add(aEditor);
                }
            }
            else if (control is IDataValidateButton && control.Visible)
            {
                var aButton = control as IDataValidateButton;
                var newNode = presenterNode.Nodes.Add("Button: " + (aButton.DvLinkedLabel != null ? aButton.DvLinkedLabel.Text : control.Text));
                newNode.Tag = aButton;
                ValidatorControls.Add(aButton);
            }
            else
            {
                if (control.HasChildren && control.Visible)
                {
                    var aNode = presenterNode.Nodes.Add("Container: " + control.Name + (!string.IsNullOrEmpty(control.Text) ? " - " + control.Text : string.Empty));
                    foreach (Control aControl in control.Controls)
                    {
                        GoThroughValidatorsViaContainer(aControl, aNode);
                    }
                }
            }
        }

        private void tvValidatorControls_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.edtObjectName.Text = string.Empty;
            this.edtObjectText.Text = string.Empty;
            this.edtLinkedLabel.Text = string.Empty;
            this.edtRegexCode.Text = string.Empty;
            this.edtRegexDesc.Text = string.Empty;
            this.edtRegexValue.Text = string.Empty;
            this.edtLengthLimit.Text = string.Empty;
            this.edtRequired.Text = string.Empty;

            if (e.Node.Tag as IDataValidateControl != null)
            {
                var aButton = e.Node.Tag as IDataValidateButton;
                if (aButton != null)
                {
                    this.edtObjectName.Text = (aButton as Control).Name;
                    this.edtObjectText.Text = (aButton as Control).Text;
                    this.edtLinkedLabel.Text = (aButton.DvLinkedLabel != null ? aButton.DvLinkedLabel.Text : string.Empty);
                    this.edtRegexCode.Text = string.Empty;
                    this.edtRegexDesc.Text = string.Empty;
                    this.edtRegexValue.Text = string.Empty;
                    this.edtLengthLimit.Text = string.Empty;
                    this.edtRequired.Text = string.Empty;
                    FlashControl(aButton as Control);
                }

                var aEditor = e.Node.Tag as IDataValidateEditor;
                if (aEditor != null)
                {
                    this.edtObjectName.Text = (aEditor as Control).Name;
                    this.edtObjectText.Text = (aEditor as Control).Text;
                    this.edtLinkedLabel.Text = (aEditor.DvLinkedLabel != null ? aEditor.DvLinkedLabel.Text : string.Empty);
                    var foundValidator = ValidatorList.Validators.Find(item => string.Equals(item.Code, aEditor.DvRegCode, StringComparison.CurrentCultureIgnoreCase));
                    this.edtRegexCode.Text = aEditor.DvValidator != null && foundValidator != null ? foundValidator.Code : string.Empty;
                    this.edtRegexDesc.Text = aEditor.DvValidator != null && foundValidator != null ? foundValidator.Description : string.Empty;
                    this.edtRegexValue.Text = aEditor.DvValidator != null && foundValidator != null ? foundValidator.Regex : string.Empty;
                    this.edtLengthLimit.Text = aEditor.DvMinLength + " - " + aEditor.DvMaxLength;
                    this.edtRequired.Text = aEditor.DvRequired ? "YES" : "no";
                    FlashControl(aEditor as Control);
                }
            }
        }

        private void FlashControl(Control aControl)
        {
            var savedColor = aControl.BackColor;
            for (int i = 0; i < 3; i++)
            {
                aControl.BackColor = Color.Orange;
                Application.DoEvents();
                Thread.Sleep(40);
                aControl.BackColor = Color.Lime;
                Application.DoEvents();
                Thread.Sleep(40);
            }
            aControl.BackColor = savedColor;
        }

        private void SaveDefineToFile()
        {
            this.saveFileDialog1.Filter = "XML文件(*.xml)|*.xml";
            if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var nodes = new List<EditorValidateStuffNode>();
                foreach (EditorValidateStuff control in this.flowLayoutPanel1.Controls)
                {
                    nodes.Add(control.GetStuffNodeFromUI());
                }
                LocalStorageHelper<List<EditorValidateStuffNode>>.SaveToText(nodes, this.saveFileDialog1.FileName);
            }
        }

        private void LoadDefineFile()
        {
            this.openFileDialog1.Filter = "XML文件(*.xml)|*.xml";
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.flowLayoutPanel1.Controls.Clear();
                var nodes = LocalStorageHelper<List<EditorValidateStuffNode>>.ReadFromText(this.openFileDialog1.FileName);
                foreach (EditorValidateStuffNode node in nodes)
                {
                    var stuff = new EditorValidateStuff { ElementName = node.ElementName, ValidValues = node.ValidValues, InvalidValues = node.InvalidValues };
                    this.flowLayoutPanel1.Controls.Add(stuff);
                }
            }
        }

        private void tvValidatorControls_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.tvValidatorControls.SelectedNode = e.Node;
            if (this.tvValidatorControls.SelectedNode != null && this.tvValidatorControls.SelectedNode.Tag != null)
            {
                var aControl = this.tvValidatorControls.SelectedNode.Tag as Control;
                var interfacedEditor = this.tvValidatorControls.SelectedNode.Tag as IDataValidateEditor;
                if (interfacedEditor.DvLinkedLabel == null) return;
                foreach (EditorValidateStuff control in this.flowLayoutPanel1.Controls)
                {
                    if (string.Equals(control.ElementName, interfacedEditor.DvLinkedLabel.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        control.Focus();
                        control.Select();
                        break;
                    }
                }
                if (aControl != null)
                    FlashControl(aControl);
            }
        }

        private void tvValidatorControls_MouseDown(object sender, MouseEventArgs e)
        {
            var aNode = this.tvValidatorControls.GetNodeAt(e.X, e.Y);
            this.tvValidatorControls.SelectedNode = aNode;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTargetFormValidators(this._targetBusinessModule);
        }

        private void miAddToValidation_Click(object sender, EventArgs e)
        {
            var sourceTreeView = (this.contextMenuStrip1.SourceControl as TreeView);
            if (sourceTreeView != null && sourceTreeView.SelectedNode != null && sourceTreeView.SelectedNode.Tag != null)
            {
                var interfacedEditor = sourceTreeView.SelectedNode.Tag as IDataValidateEditor;
                var controlEditor = sourceTreeView.SelectedNode.Tag as Control;
                if (interfacedEditor.DvLinkedLabel == null) return;
                EditorValidateStuff hittedEditorValidateStuff = null;
                foreach (EditorValidateStuff control in this.flowLayoutPanel1.Controls)
                {
                    if (interfacedEditor.DvLinkedLabel.Text == null) return;
                    if (string.Equals(control.ElementName, interfacedEditor.DvLinkedLabel.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        hittedEditorValidateStuff = control;
                        break;
                    }
                }

                if (hittedEditorValidateStuff == null)
                {

                    //  应首先判断DvLinkedLabel是否为空；另外判断文本是否为空最好用string.IsNullOrEmpty ...
                    if (interfacedEditor.DvLinkedLabel.Text == null) return;
                    var stuff = new EditorValidateStuff { ElementName = interfacedEditor.DvLinkedLabel.Text };
                    this.flowLayoutPanel1.Controls.Add(stuff);
                }
            }
        }

        private void tvValidatorControls_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.miAddToValidation.PerformClick();

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            this.LoadDefineFile();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            this.SaveDefineToFile();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int ICount = 1;
            foreach (EditorValidateStuff control in this.flowLayoutPanel1.Controls)
            {
                #region
                string strValidValues = string.Empty;
                string strInvalidValues = string.Empty;
                ICount = 0;
                //检验合格数据
                foreach (var str in control.ValidValues)
                {
                    ICount++;
                    TreeNode[] treeNode = tvValidatorControls.Nodes.Find(control.ElementName, true);
                    if (treeNode.Length == 0) return;
                    var aEditor = treeNode[0].Tag as IDataValidateEditor;
                    if (aEditor != null)
                    {
                        var foundValidator = ValidatorList.Validators.Find(item => string.Equals(item.Code, aEditor.DvRegCode, StringComparison.CurrentCultureIgnoreCase));
                        var strRegex = aEditor.DvValidator != null && foundValidator != null ? foundValidator.Regex : string.Empty;
                        if (foundValidator == null) continue;
                        if (!System.Text.RegularExpressions.Regex.IsMatch(str, strRegex))
                        {
                            strValidValues += ICount + ",";
                        }
                    }
                }
                ICount = 0;
                //检验不合格数据
                foreach (var str in control.InvalidValues)
                {
                    ICount++;
                    TreeNode[] treeNode = tvValidatorControls.Nodes.Find(control.ElementName, true);
                    if (treeNode.Length == 0) return;
                    var aEditor = treeNode[0].Tag as IDataValidateEditor;
                    if (aEditor != null)
                    {
                        var foundValidator = ValidatorList.Validators.Find(item => string.Equals(item.Code, aEditor.DvRegCode, StringComparison.CurrentCultureIgnoreCase));
                        var strRegex = aEditor.DvValidator != null && foundValidator != null ? foundValidator.Regex : string.Empty;
                        if (foundValidator == null) continue;
                        if (System.Text.RegularExpressions.Regex.IsMatch(str, strRegex))
                        {
                            strInvalidValues += ICount + ",";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(strValidValues) && strValidValues.LastIndexOf(",") > 0)
                {
                    strValidValues = "合法值第" + strValidValues.Substring(0, strValidValues.LastIndexOf(",")) + "行失败";
                }
                if (!string.IsNullOrEmpty(strInvalidValues) && strInvalidValues.LastIndexOf(",") > 0)
                {
                    strInvalidValues = "非合法值第" + strInvalidValues.Substring(0, strInvalidValues.LastIndexOf(",")) + "行失败";
                }
                string strregex = string.Empty;
                strregex += strValidValues + " " + strInvalidValues;
                if (strregex.Trim() == "") continue;
                FlashControl(control);
                Control[] ctr = control.Controls.Find("labRegex" + control.ElementName, false);
                if (ctr.Length != 0) ctr[0].Text = strregex;
                else
                {
                    Label lab = new Label();
                    lab.Name = "labRegex" + control.ElementName;
                    lab.Text = strregex;
                    lab.AutoSize = true;
                    lab.Location = new Point(x: control.ElementName.Length * 12 + 15, y: 8);
                    control.Controls.Add(lab);
                }
                #endregion
            }

        }

    }
}
