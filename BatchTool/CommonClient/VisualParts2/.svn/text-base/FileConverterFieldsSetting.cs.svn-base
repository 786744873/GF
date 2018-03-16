using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;

namespace CommonClient.VisualParts2
{
    public partial class FileConverterFieldsSetting : BaseUc
    {
        public FileConverterFieldsSetting()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }

        ShowType st = ShowType.View;
        /// <summary>
        /// 界面显示方式
        /// </summary>
        [Browsable(true)]
        public ShowType ShowType
        {
            get { return st; }
            set
            {
                st = value;
                ChangeUI();
            }
        }
        AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 当前业务类型
        /// </summary>
        [Browsable(false)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        FunctionInSettingType m_FunType = FunctionInSettingType.Empty;
        /// <summary>
        /// 分支业务类型
        /// </summary>
        public FunctionInSettingType FunType
        {
            get { return m_FunType; }
            set { m_FunType = value; }
        }
        MappingsRelationSettings m_Mappings;
        /// <summary>
        /// 映射关系
        /// </summary>
        [Browsable(false)]
        public MappingsRelationSettings Mappings
        {
            get { return m_Mappings; }
            set
            {
                m_Mappings = value;
                InitData();
            }
        }
        int rowindex = 0;

        private void ChangeUI()
        {
            p_FileFields.Visible = st == VisualParts2.ShowType.Modify;
            lbDesc.Text = st == VisualParts2.ShowType.Modify ? "银行标准数据项规则描述" : "已设置的映射关系";
        }

        void InitData()
        {
            if (null == m_Mappings)
                dgv.DataSource = null;
            else
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                list.AddRange(m_Mappings.FieldsMappings);
                dgv.DataSource = null;
                dgv.DataSource = list;
                SetDesc();
            }
            dgv.Refresh();
        }

        public bool GetFieldsMapping()
        {
            bool IsNull = false;
            m_Mappings = new MappingsRelationSettings();
            List<KeyValuePair<string, string>> list = dgv.DataSource as List<KeyValuePair<string, string>>;
            if (null == list) return IsNull;
            foreach (KeyValuePair<string, string> kv in list)
            {
                m_Mappings.FieldsMappings.Add(kv.Key, kv.Value);
                if (!string.IsNullOrEmpty(kv.Value)) IsNull = true;
            }
            if (!IsNull) { MessageBoxPrime.Show(string.Format("{0}", "请设置映射关系", MultiLanguageConvertHelper.Settings_Convert_Data_Type), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return IsNull; }
            return IsNull;
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
            //if (gbInfoType.Visible && rbBatch.Checked)
            //{
            //    m_Mappings.BatchFieldsMappings[kv.Key] = str;
            //    list.AddRange(m_Mappings.BatchFieldsMappings);
            //}
            //else
            //{
            m_Mappings.FieldsMappings[kv.Key] = str;
            list.AddRange(m_Mappings.FieldsMappings);
            //}
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
                //if (gbInfoType.Visible && rbBatch.Checked)
                //{
                //    m_Mappings.BatchFieldsMappings[kv.Key] = string.Empty;
                //    list.AddRange(m_Mappings.BatchFieldsMappings);
                //}
                //else
                //{
                m_Mappings.FieldsMappings[kv.Key] = string.Empty;
                list.AddRange(m_Mappings.FieldsMappings);
                //}
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Rows[rowindex].Selected = true;
                SetDesc();
            }
        }

        private void SetDesc()
        {
            if (AppliableFunctionType._Empty != m_AppType)
            {
                MappingsRelationSettings mrs = SystemInit.GetMappingRelation(m_AppType);
                string[] fieldList = new string[mrs.FieldsMappings.Count];
                mrs.FieldsMappings.Keys.CopyTo(fieldList, 0);
                List<string> desList = SystemInit.GetRegexDescription(m_AppType); //SystemSettings.RegexDescriptions[m_AppType];
                if (fieldList.Length == dgv.Rows.Count && desList.Count == dgv.Rows.Count)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = string.Format("{0}{1}", desList[i].Contains("非必输") ? string.Empty : "*", fieldList[i]);
                        dgv.Rows[i].Cells[2].Value = desList[i];
                    }
                }
            }
            else
            {
                MappingsRelationSettings mrs = SystemInit.GetMappingRelation(m_FunType);
                string[] fieldList = new string[mrs.FieldsMappings.Count];
                mrs.FieldsMappings.Keys.CopyTo(fieldList, 0);
                List<string> desList = SystemInit.GetRegexDescription(m_FunType); //SystemSettings.RegexDescriptions[m_AppType];
                if (fieldList.Length == dgv.Rows.Count && desList.Count == dgv.Rows.Count)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = string.Format("{0}{1}", desList[i].Contains("非必输") ? string.Empty : "*", fieldList[i]);
                        dgv.Rows[i].Cells[2].Value = desList[i];
                    }
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            rowindex = e.RowIndex;
        }

        private void lboxFields_DoubleClick(object sender, EventArgs e)
        {
            MappingField();
        }

        public void LoadFiledsInFile(string filepath, string separatorStr, string startrowindex)
        {
            if (m_AppType == AppliableFunctionType._Empty && m_FunType == FunctionInSettingType.Empty)
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_Select_Business_Type, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (ofDialog.ShowDialog() != DialogResult.OK)
            //    return;

            //string filePath = ofDialog.FileName;
            if (!(filepath.ToLower().EndsWith(".txt")
                || filepath.ToLower().EndsWith(".csv")
                || filepath.ToLower().EndsWith(".xls")
                || filepath.ToLower().EndsWith(".xlsx")))
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Select_File_Agent, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
            }

            //查看当前文件是否被占用
            try
            {
                using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
            }
            catch (System.IO.IOException)
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_File_Is_Open_Please_Close_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
            }

            if (filepath.EndsWith(".txt") || filepath.EndsWith(".csv"))
            {
                if (separatorStr.Length == 0)
                {
                    //PreFileData(ofDialog.FileName);
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_MakeSure_SeparaterChar_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int rowindex = 1;
            try { rowindex = int.Parse(startrowindex); }
            catch { }
            List<string> list = MatchFile.MatchFileDataHelper.GetFileHeader(filepath, separatorStr, rowindex);
            lboxFields.Items.Clear();

            if (list.Count == 0) { MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_No_Table_Header, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }

            ResetFields(list);

            if (dgv.Rows.Count > 0)
            {
                rowindex = 0;
                this.dgv.Rows[0].Selected = true;
            }
        }

        public void ResetFields(List<string> list)
        {
            if (null == list)
            {
                dgv.DataSource = null;
                return;
            }
            List<KeyValuePair<string, string>> dicList = dgv.DataSource as List<KeyValuePair<string, string>>;

            List<string> tempSame = list.FindAll(o => dicList.FindIndex(d => d.Value == o) >= 0);
            List<string> temp = list.FindAll(o => !tempSame.Contains(o));
            lboxFields.Items.AddRange(temp.ToArray());

            List<KeyValuePair<string, string>> tempList = dicList.FindAll(o => !list.Contains(o.Value));
            if (tempList != null)
            {
                List<KeyValuePair<string, string>> resultList = new List<KeyValuePair<string, string>>();
                Dictionary<string, string> tempdic = new Dictionary<string, string>();
                //if (gbInfoType.Visible && rbBatch.Checked)
                //{
                //    tempdic = m_Mappings.BatchFieldsMappings;
                //}
                //else
                //{
                tempdic = m_Mappings.FieldsMappings;
                //}
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
                //if (gbInfoType.Visible && rbBatch.Checked)
                //{
                //    tempdic = m_Mappings.BatchFieldsMappings;
                //}
                //else
                //{
                tempdic = m_Mappings.FieldsMappings;
                //}

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
    }

    public enum ShowType
    {
        View = 1,
        Modify = 2,
    }
}
