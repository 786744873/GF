using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using System.IO;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class BatchMappingItemsPanel : BaseUc
    {
        public BatchMappingItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            ofDialog.Filter = string.Format("{0}|*.txt|{1}|*.csv|{2}|*.xls;*.xlsx", MultiLanguageConvertHelper.DesignMain_FileType_TXT, MultiLanguageConvertHelper.DesignMain_FileType_CSV, MultiLanguageConvertHelper.DesignMain_FileType_Excel);

            CommandCenter.OnFieldMappingEventHandler += new EventHandler<FieldMappingEventArgs>(CommandCenter_OnFieldMappingEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(Instance_OnLanguageChangedEventHandler);
            this.SizeChanged += new EventHandler(BatchMappingItemsPanel_SizeChanged);
        }

        void BatchMappingItemsPanel_SizeChanged(object sender, EventArgs e)
        {
            dgv.Height = this.Height - 400 + 205;
            dgv.Width = this.Width - 980 + 660;
            lboxFields.Height = this.Height - 400 + 205;
            lboxFields.Location = new Point { X = this.Width - 15 - lboxFields.Width, Y = dgv.Location.Y };
            label3.Location = new Point { X = lboxFields.Location.X, Y = label19.Location.Y };
            btnSetting.Location = new Point { X = lboxFields.Location.X - 10 - btnSetting.Width, Y = btnSetting.Location.Y };
            btnCancel.Location = new Point { X = lboxFields.Location.X - 10 - btnCancel.Width, Y = btnCancel.Location.Y };
        }

        List<string> separactorCharList = new List<string> { ",", "|", ";", "&" };

        void Instance_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(Instance_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(BatchMappingItemsPanel), this);
            }
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        private FunctionInSettingType m_FunType = FunctionInSettingType.Empty;
        private MappingsRelationSettings m_Mappings;
        private int rowindex = 0;

        void CommandCenter_OnFieldMappingEventHandler(object sender, FieldMappingEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<FieldMappingEventArgs>(CommandCenter_OnFieldMappingEventHandler), new object[] { sender, e }); }
            else
            {
                try
                {
                    if (OperatorCommandType.MappingSettingRequest == e.Command)
                    {
                        if (CheckData())
                        {
                            GetItem();
                            CommandCenter.ResolveFieldMapping(OperatorCommandType.MappingSettingResolve, m_AppType, m_Mappings, m_FunType, FunctionInSettingType.MapSetting);
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (OperatorCommandType.View == e.Command && e.FunType == FunctionInSettingType.MapSetting)
                    {
                        MappingsRelationSettings mrs = SystemSettings.BatchMappingSettings.ContainsKey(e.AppType) ? SystemSettings.BatchMappingSettings[e.AppType] : null;
                        if (e.AppType == AppliableFunctionType._Empty)
                            mrs = SystemSettings.BatchSettingsMappingSettings.ContainsKey(e.BatchAppType) ? SystemSettings.BatchSettingsMappingSettings[e.BatchAppType] : null;
                        m_Mappings = e.Mappings;
                        m_AppType = e.AppType;
                        m_FunType = e.BatchAppType;
                        string str = string.Empty;
                        try
                        {
                            if (e.AppType != AppliableFunctionType._Empty)
                                str = CommonClient.Utilities.EnumNameHelper<AppliableFunctionType>.GetEnumDescription(m_AppType);
                            else
                                str = CommonClient.Utilities.EnumNameHelper<FunctionInSettingType>.GetEnumDescription(m_FunType);
                        }
                        catch { }
                        groupBox5.Text = str;
                        SetItem(mrs, true);
                    }
                }
                catch { }
            }
        }

        private bool CheckData()
        {
            ResultData rd = DataCheckCenter.CheckMaxCountPreOperator(tbMaxCount, tbMaxCount.Text.Trim(), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.CheckStartRowIndex(tbStartRowIndex, tbStartRowIndex.Text.Trim(), label5.Text.Substring(0, label5.Text.Length - 1), 5, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(tbSeparator.Text.Trim()))
            {
                rd = DataCheckCenter.CheckSeparator(tbSeparator, tbSeparator.Text, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return true;
        }

        private void GetItem()
        {
            m_Mappings.MaxCountPerOperation = int.Parse(tbMaxCount.Text.Trim());
            m_Mappings.SeperateChar = tbSeparator.Text;
            m_Mappings.StartRowIndex = int.Parse(tbStartRowIndex.Text.Trim());
            m_Mappings.BatchFieldsMappings = new Dictionary<string, string>();
            m_Mappings.FieldsMappings = new Dictionary<string, string>();
            if (AppliableFunctionType.AgentExpressIn == m_AppType
                   || AppliableFunctionType.AgentExpressOut == m_AppType
                   || AppliableFunctionType.AgentNormalIn == m_AppType
                   || AppliableFunctionType.AgentNormalOut == m_AppType)
            {
                //if (rbBatch.Checked)
                //{
                //    List<KeyValuePair<string, string>> list = dgv.DataSource as List<KeyValuePair<string, string>>;
                //    foreach (KeyValuePair<string, string> kv in list)
                //    {
                //        m_Mappings.BatchFieldsMappings.Add(kv.Key, kv.Value);
                //    }
                //}
                //else if (rbSingal.Checked)
                //{
                List<KeyValuePair<string, string>> list = dgv.DataSource as List<KeyValuePair<string, string>>;
                foreach (KeyValuePair<string, string> kv in list)
                {
                    m_Mappings.FieldsMappings.Add(kv.Key, kv.Value);
                }
                //}
            }
            else
            {
                List<KeyValuePair<string, string>> list = dgv.DataSource as List<KeyValuePair<string, string>>;
                foreach (KeyValuePair<string, string> kv in list)
                {
                    m_Mappings.FieldsMappings.Add(kv.Key, kv.Value);
                }
            }
        }

        private void SetItem(MappingsRelationSettings mrs, bool flag)
        {
            m_Mappings = mrs;
            if (flag)
            {
                lboxFields.Items.Clear();
                gbInfoType.Visible = rbBatch.Checked = rbSingal.Checked = false;
            }
            if (null == mrs)
            {
                tbMaxCount.Text = "0";
                tbStartRowIndex.Text = "0";
                tbSeparator.Text = string.Empty;
                dgv.DataSource = null;
            }
            else
            {
                if (null == mrs) mrs = new MappingsRelationSettings();
                tbMaxCount.Text = mrs.MaxCountPerOperation.ToString();
                tbSeparator.Text = string.IsNullOrEmpty(mrs.SeperateChar) ? string.Empty : mrs.SeperateChar;
                tbStartRowIndex.Text = mrs.StartRowIndex.ToString();
                //if (AppliableFunctionType.AgentExpressIn == m_AppType
                //    || AppliableFunctionType.AgentExpressOut == m_AppType
                //    || AppliableFunctionType.AgentNormalIn == m_AppType
                //    || AppliableFunctionType.AgentNormalOut == m_AppType)
                //{
                //    rbSingal.Checked = true;
                //}
                //else
                //{
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                list.AddRange(mrs.FieldsMappings);
                dgv.DataSource = null;
                dgv.DataSource = list;
                SetDesc();
                //}
            }
            dgv.Refresh();
        }

        private void SetDesc()
        {
            if (AppliableFunctionType._Empty != m_AppType)
            {
                MappingsRelationSettings mrs = SystemInit.GetMappingRelation(m_AppType);
                string[] fieldList = new string[mrs.FieldsMappings.Count];
                mrs.FieldsMappings.Keys.CopyTo(fieldList, 0);
                if (fieldList.Length == dgv.Rows.Count)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = fieldList[i];
                    }
                }

                List<string> desList = SystemInit.GetRegexDescription(m_AppType); //SystemSettings.RegexDescriptions[m_AppType];
                if (desList.Count == dgv.Rows.Count)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[2].Value = desList[i];
                    }
                }
            }
            else
            {
                MappingsRelationSettings mrs = SystemInit.GetMappingRelation(m_FunType);
                string[] fieldList = new string[mrs.FieldsMappings.Count];
                mrs.FieldsMappings.Keys.CopyTo(fieldList, 0);
                if (fieldList.Length == dgv.Rows.Count)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = fieldList[i];
                    }
                }

                List<string> desList = SystemInit.GetRegexDescription(m_FunType); //SystemSettings.RegexDescriptions[m_AppType];
                if (desList.Count == dgv.Rows.Count)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[2].Value = desList[i];
                    }
                }
            }
        }

        private void llTemplate_Click(object sender, EventArgs e)
        {
            if (m_AppType == AppliableFunctionType._Empty && m_FunType == FunctionInSettingType.Empty)
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_Select_Business_Type, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ofDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = ofDialog.FileName;
            if (!(filePath.ToLower().EndsWith(".txt")
                || filePath.ToLower().EndsWith(".csv")
                || filePath.ToLower().EndsWith(".xls")
                || filePath.ToLower().EndsWith(".xlsx")))
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Select_File_Agent, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            //查看当前文件是否被占用
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
            }
            catch (System.IO.IOException)
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_File_Is_Open_Please_Close_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (filePath.EndsWith(".txt") || filePath.EndsWith(".csv"))
            {
                if (tbSeparator.Text.Length == 0)
                {
                    //PreFileData(ofDialog.FileName);
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_MakeSure_SeparaterChar_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int rowindex = 1;
            try { rowindex = int.Parse(tbStartRowIndex.Text.Trim()); }
            catch { }
            List<string> list = MatchFile.MatchFileDataHelper.GetFileHeader(filePath, tbSeparator.Text.Trim(), rowindex);
            lboxFields.Items.Clear();

            if (list.Count == 0) { MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_No_Table_Header, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            ResetFields(list);

            if (dgv.Rows.Count > 0)
            {
                rowindex = 0;
                this.dgv.Rows[0].Selected = true;
            }
        }

        public void ResetFields(List<string> list)
        {
            List<KeyValuePair<string, string>> dicList = dgv.DataSource as List<KeyValuePair<string, string>>;

            List<string> tempSame = list.FindAll(o => dicList.FindIndex(d => d.Value == o) >= 0);
            List<string> temp = list.FindAll(o => !tempSame.Contains(o));
            lboxFields.Items.AddRange(temp.ToArray());

            List<KeyValuePair<string, string>> tempList = dicList.FindAll(o => !list.Contains(o.Value));
            if (tempList != null)
            {
                List<KeyValuePair<string, string>> resultList = new List<KeyValuePair<string, string>>();
                Dictionary<string, string> tempdic = new Dictionary<string, string>();
                if (gbInfoType.Visible && rbBatch.Checked)
                {
                    tempdic = m_Mappings.BatchFieldsMappings;
                }
                else
                {
                    tempdic = m_Mappings.FieldsMappings;
                }
                if (null == tempList) return;
                foreach (var item in tempList)
                {
                    tempdic[item.Key] = string.Empty;
                }

                foreach (var item in tempdic)
                {
                    resultList.Add(item);
                }

                dgv.DataSource = null;
                dgv.DataSource = resultList;

                rowindex = 0;
                if (rowindex >= list.Count)
                    rowindex = rowindex % list.Count;
                dgv.Rows[rowindex].Selected = true;
            }
            else if (null == tempList || tempList.Count == 0)
            {
                List<KeyValuePair<string, string>> resultList = new List<KeyValuePair<string, string>>();
                Dictionary<string, string> tempdic = new Dictionary<string, string>();
                if (gbInfoType.Visible && rbBatch.Checked)
                {
                    tempdic = m_Mappings.BatchFieldsMappings;
                }
                else
                {
                    tempdic = m_Mappings.FieldsMappings;
                }

                foreach (var item in tempdic)
                {
                    resultList.Add(new KeyValuePair<string, string>(item.Key, string.Empty));
                }

                dgv.DataSource = null;
                dgv.DataSource = resultList;

                rowindex++;
                if (rowindex >= list.Count)
                    rowindex = rowindex % list.Count;
                dgv.Rows[rowindex].Selected = true;
            }
            SetDesc();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            MappingField();
        }

        private void MappingField()
        {
            if (dgv.Rows.Count < 1 || lboxFields.SelectedIndex < 0) return;
            string str = string.Empty;
            foreach (var item in lboxFields.SelectedItems)
            {
                if (!string.IsNullOrEmpty(str)) str += ";";
                str += item.ToString();
            }
            KeyValuePair<string, string> kv = (dgv.DataSource as List<KeyValuePair<string, string>>)[rowindex];

            List<int> titles = new List<int>();
            foreach (var item in lboxFields.SelectedIndices)
            {
                titles.Add(int.Parse(item.ToString()));
            }
            foreach (var item in titles)
            {
                lboxFields.Items.RemoveAt(item);
            }

            if (null != kv.Value && !string.IsNullOrEmpty(kv.Value.ToString()))
                lboxFields.Items.AddRange(kv.Value.ToString().Split(';'));

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            if (gbInfoType.Visible && rbBatch.Checked)
            {
                m_Mappings.BatchFieldsMappings[kv.Key] = str;
                list.AddRange(m_Mappings.BatchFieldsMappings);
            }
            else
            {
                m_Mappings.FieldsMappings[kv.Key] = str;
                list.AddRange(m_Mappings.FieldsMappings);
            }
            dgv.DataSource = null;
            dgv.DataSource = list;

            rowindex++;
            if (rowindex >= list.Count)
                rowindex = rowindex % list.Count;
            if (rowindex < dgv.Rows.Count)
            {
                dgv.Rows[rowindex].Selected = true;
                if (rowindex > 1)
                    dgv.FirstDisplayedScrollingRowIndex = rowindex - 1;
            }

            SetDesc();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                KeyValuePair<string, string> kv = (dgv.DataSource as List<KeyValuePair<string, string>>)[rowindex];

                if (null != kv.Value && !string.IsNullOrEmpty(kv.Value.ToString()))
                    lboxFields.Items.AddRange(kv.Value.ToString().Split(';'));

                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                if (gbInfoType.Visible && rbBatch.Checked)
                {
                    m_Mappings.BatchFieldsMappings[kv.Key] = string.Empty;
                    list.AddRange(m_Mappings.BatchFieldsMappings);
                }
                else
                {
                    m_Mappings.FieldsMappings[kv.Key] = string.Empty;
                    list.AddRange(m_Mappings.FieldsMappings);
                }
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Rows[rowindex].Selected = true;
                SetDesc();
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> list;
            if (rbBatch.Checked)
            {
                #region
                if (dgv.Rows.Count > 0)
                {
                    list = dgv.DataSource as List<KeyValuePair<string, string>>;
                    foreach (KeyValuePair<string, string> kv in list)
                    {
                        if (m_Mappings.FieldsMappings.ContainsKey(kv.Key))
                            m_Mappings.FieldsMappings[kv.Key] = kv.Value;
                    }
                }

                list = new List<KeyValuePair<string, string>>();
                if (null != m_Mappings.BatchFieldsMappings)
                {
                    list.AddRange(m_Mappings.BatchFieldsMappings);
                    dgv.DataSource = list;
                }

                List<string> desList = SystemSettings.BatchRegexDescriptions[m_AppType];
                if (desList.Count == dgv.Rows.Count)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[2].Value = desList[i];
                    }
                }
                #endregion
            }
            else if (rbSingal.Checked)
            {
                #region
                if (dgv.Rows.Count > 0)
                {
                    list = dgv.DataSource as List<KeyValuePair<string, string>>;
                    foreach (KeyValuePair<string, string> kv in list)
                    {
                        if (m_Mappings.BatchFieldsMappings.ContainsKey(kv.Key))
                            m_Mappings.BatchFieldsMappings[kv.Key] = kv.Value;
                    }
                }

                list = new List<KeyValuePair<string, string>>();
                if (null != m_Mappings.FieldsMappings)
                {
                    list.AddRange(m_Mappings.FieldsMappings);
                    dgv.DataSource = null;
                    dgv.DataSource = list;
                    SetDesc();
                }

                List<string> desList = SystemSettings.RegexDescriptions[m_AppType];
                if (desList.Count == dgv.Rows.Count)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[2].Value = desList[i];
                    }
                }
                dgv.Refresh();
                #endregion
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            rowindex = e.RowIndex;
        }

        void AnalysisData()
        {
            List<char> list = new List<char>();
            list.AddRange(tbFileContent.Text.Trim().ToCharArray());
            int index = 0;
            int maxcount = 0;
            for (int i = 0; i < separactorCharList.Count; i++)
            {
                int count = list.FindAll(o => o.ToString() == separactorCharList[i]).Count;
                if (count > maxcount)
                {
                    maxcount = count;
                    index = i;
                }
            }

            if (maxcount > 0)
                tbSeparator.Text = separactorCharList[index];
            else tbSeparator.Text = string.Empty;
        }

        private void btnPreView_Click(object sender, EventArgs e)
        {
            string fileExtent = string.Empty;
            if (ofDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = ofDialog.FileName;
            if (!(filePath.ToLower().EndsWith(".txt")
                || filePath.ToLower().EndsWith(".csv")
                || filePath.ToLower().EndsWith(".xls")
                || filePath.ToLower().EndsWith(".xlsx")))
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Select_File_Agent, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            //查看当前文件是否被占用
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
            }
            catch (System.IO.IOException)
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_File_Is_Open_Please_Close_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (filePath.ToLower().EndsWith(".txt") || filePath.ToLower().EndsWith(".csv"))
            {
                if (string.IsNullOrEmpty(tbSeparator.Text.Trim()))
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_MakeSure_SeparaterChar_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            PreFileData(filePath);
        }

        private void PreFileData(string filepath)
        {
            if (string.IsNullOrEmpty(filepath.Trim())) return;

            List<string> filecontent = new List<string>();
            if (filepath.ToLower().EndsWith(".txt"))
                filecontent = CommonClient.FileIO.FileRWHelper.ReadTXTDocument(filepath);
            else if (filepath.ToLower().EndsWith(".csv"))
                filecontent = CommonClient.FileIO.FileRWHelper.ReadCSVFieldsData(filepath);
            else filecontent = CommonClient.FileIO.FileRWHelper.ReadExcelFieldsData(filepath, 3, 1);

            if (!string.IsNullOrEmpty(tbFileContent.Text)) tbFileContent.Text = string.Empty;
            if (filecontent.Count == 0)
            { tbFileContent.Text = "文件中无数据"; }
            else
            {
                string temp = string.Empty;
                for (int i = 0; i < filecontent.Count && i < 3; i++)
                {
                    temp += filecontent[i] + Environment.NewLine;
                }

                if (filepath.ToLower().EndsWith(".txt") || filepath.ToLower().EndsWith(".csv"))
                {
                    temp = temp.Replace(tbSeparator.Text, SysCoach.SystemSettings.BOCSeparator);
                }

                tbFileContent.Text = temp;

                //if (filepath.ToLower().EndsWith(".txt"))
                //    AnalysisData();
            }
        }

        private void lboxFields_DoubleClick(object sender, EventArgs e)
        {
            MappingField();
        }

        private void tbStartRowIndex_TextChanged(object sender, EventArgs e)
        {
            if (tbStartRowIndex.Text.Trim() == "1") return;
            if (!string.IsNullOrEmpty(tbStartRowIndex.Text.Trim()))
            {
                try { int index = int.Parse(tbStartRowIndex.Text.Trim()); }
                catch { tbStartRowIndex.Text = "1"; }
            }
            else tbStartRowIndex.Text = "1";
        }
    }
}
