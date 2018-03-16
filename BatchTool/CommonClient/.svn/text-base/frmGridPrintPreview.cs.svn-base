using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CommonClient
{
    public partial class FrmGridPrintPreview : frmBase
    {
        public FrmGridPrintPreview()
        {
            InitializeComponent();
        }

        public static FrmGridPrintPreview GridPrintPreviewInstance { get; set; }

        public string DocumentTitle { get { return this.edtDocumentTitle.Text.Trim(); } set { this.edtDocumentTitle.Text = value; } }
        public bool PrintAllColumns { get { return this.cbPrintAllColumns.Checked; } set { this.cbPrintAllColumns.Checked = value; } }
        public bool FitToPaperWidth { get { return this.cbFitPaperWidth.Checked; } set { this.cbFitPaperWidth.Checked = value; } }
        public bool PrintDocumentTitle { get { return this.cbPrintDocumentTitle.Checked; } set { this.cbPrintDocumentTitle.Checked = value; } }
        public bool PrintDirection { get { return this.rbHorizontal.Checked; } set { this.rbHorizontal.Checked = value; this.rbVertical.Checked = !value; } }
        public List<string> SelectedColumns
        {
            get
            {
                var result = new List<string>();
                if (PrintAllColumns)
                    foreach (string item in this.clbColumns.Items)
                        result.Add(item);
                else
                    foreach (string item in this.clbColumns.CheckedItems)
                        result.Add(item);
                return result;
            }
            set
            {
                if (value.Count < clbColumns.Items.Count) cbPrintAllColumns.Checked = false;
                for (int i = 0; i < this.clbColumns.Items.Count; i++)
                {
                    this.clbColumns.SetItemChecked(i, false);
                }
                foreach (string s in value)
                {
                    var index = clbColumns.Items.IndexOf(s);
                    if (index > -1)
                        clbColumns.SetItemChecked(index, true);
                }
            }
        }

        private void cbPrintDocumentTitle_Click(object sender, EventArgs e)
        {
            lblDocumentTitle.Enabled = cbPrintDocumentTitle.Checked;
            edtDocumentTitle.Enabled = cbPrintDocumentTitle.Checked;
        }

        public static FrmGridPrintPreview CreatePrintDialog(IWin32Window owner, List<string> allColumns)
        {
            if (GridPrintPreviewInstance == null)
                GridPrintPreviewInstance = new FrmGridPrintPreview();

            bool flagchecked = GridPrintPreviewInstance.cbPrintAllColumns.Checked;
            GridPrintPreviewInstance.clbColumns.Items.Clear();
            foreach (string column in allColumns)
            {
                GridPrintPreviewInstance.clbColumns.Items.Add(column, flagchecked);
            }
            return GridPrintPreviewInstance;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbPrintAllColumns_CheckedChanged(object sender, EventArgs e)
        {
            this.clbColumns.Enabled = !cbPrintAllColumns.Checked;
            for (int i = 0; i < GridPrintPreviewInstance.clbColumns.Items.Count; i++)
            {
                GridPrintPreviewInstance.clbColumns.SetItemChecked(i, cbPrintAllColumns.Checked);
            }
        }
    }


    public class DataGridviewPrintHelper
    {
        private static StringFormat _strFormat;
        private static StringFormat _strFormatComboBox;
        private static Button _cellButton;
        private static CheckBox _cellCheckBox;
        private static ComboBox _cellComboBox;
        private static int _totalWidth;
        private static int _rowPos;
        private static bool _newPage;
        private static int _pageNo;
        private static readonly ArrayList ColumnLefts = new ArrayList();
        private static readonly ArrayList ColumnWidths = new ArrayList();
        private static readonly ArrayList ColumnTypes = new ArrayList();
        private static int _cellHeight;
        private static int _rowsPerPage;
        private static readonly System.Drawing.Printing.PrintDocument PrintDoc = new System.Drawing.Printing.PrintDocument();

        private static string _printTitle = string.Empty;
        private static DataGridView _dgv;
        private static List<string> _selectedColumns = new List<string>();
        private static readonly List<string> AvailableColumns = new List<string>();
        private static bool _printAllColumns = true;
        private static bool _fitToPageWidth = true;
        private static bool _printDocumentTitle = true;
        private static int _headerHeight = 0;
        private static string _otherInfo = string.Empty;

        public static void PrintDataGridView(IWin32Window owner, DataGridView dgv1, string totalinfo, List<string> selectedColumns)
        {
            try
            {
                _dgv = dgv1;
                AvailableColumns.Clear();
                foreach (DataGridViewColumn c in _dgv.Columns)
                {
                    if (!c.Visible)
                        continue;
                    AvailableColumns.Add(c.HeaderText);
                }

                var printSettingsDialog = FrmGridPrintPreview.CreatePrintDialog(owner, AvailableColumns);
                if (selectedColumns.Count > 0)
                    printSettingsDialog.SelectedColumns = selectedColumns;
                if (printSettingsDialog.ShowDialog() != DialogResult.OK)
                    return;

                _printTitle = printSettingsDialog.DocumentTitle;
                _printAllColumns = printSettingsDialog.PrintAllColumns;
                _fitToPageWidth = printSettingsDialog.FitToPaperWidth;
                _selectedColumns = printSettingsDialog.SelectedColumns;
                _printDocumentTitle = printSettingsDialog.PrintDocumentTitle;
                _otherInfo = totalinfo;
                PrintDoc.DefaultPageSettings.Landscape = printSettingsDialog.PrintDirection;

                _rowsPerPage = 0;

                var ppvw = new PrintPreviewDialog { Document = PrintDoc };

                PrintDoc.BeginPrint += PrintDocBeginPrint;
                PrintDoc.PrintPage += PrintDocPrintPage;
                if (ppvw.ShowDialog() != DialogResult.OK)
                {
                    PrintDoc.BeginPrint -= PrintDocBeginPrint;
                    PrintDoc.PrintPage -= PrintDocPrintPage;
                    return;
                }

                PrintDoc.Print();
                PrintDoc.BeginPrint -= PrintDocBeginPrint;
                PrintDoc.PrintPage -= PrintDocPrintPage;
            }
            catch (Exception ex)
            {
                MessageBoxPrime.Show(ex.Message, "Error", MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
            }
        }

        private static void PrintDocBeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                _strFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.None };
                _strFormatComboBox = new StringFormat { LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoWrap, Trimming = StringTrimming.EllipsisCharacter };

                ColumnLefts.Clear();
                ColumnWidths.Clear();
                ColumnTypes.Clear();
                _cellHeight = 0;
                _rowsPerPage = 0;

                _cellButton = new Button();
                _cellCheckBox = new CheckBox();
                _cellComboBox = new ComboBox();

                _totalWidth = 0;
                foreach (DataGridViewColumn gridCol in _dgv.Columns)
                {
                    if (!gridCol.Visible)
                        continue;
                    if (!_selectedColumns.Contains(gridCol.HeaderText))
                        continue;
                    _totalWidth += gridCol.Width;
                }
                _pageNo = 1;
                _newPage = true;
                _rowPos = 0;
            }
            catch (Exception ex)
            {
                MessageBoxPrime.Show(ex.Message, "Error", MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
            }
        }

        private static void PrintDocPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int tmpTop = e.MarginBounds.Top;
            int tmpLeft = e.MarginBounds.Left;

            try
            {
                if (_pageNo == 1)
                {
                    using (var aFont = new Font(_dgv.Font, FontStyle.Bold))
                    {
                        SizeF size = e.Graphics.MeasureString(_otherInfo, aFont);
                        e.Graphics.DrawString(_otherInfo, aFont, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(_printTitle, aFont, e.MarginBounds.Width).Height - 13);

                        tmpTop += (int)size.Height;
                    }
                    foreach (DataGridViewColumn gridCol in _dgv.Columns)
                    {
                        if (!gridCol.Visible)
                            continue;
                        if (!_selectedColumns.Contains(gridCol.HeaderText))
                            continue;

                        int tmpWidth;
                        if (_fitToPageWidth)
                            tmpWidth = (int)(Math.Floor((double)((double)gridCol.Width / (double)_totalWidth * (double)_totalWidth * ((double)e.MarginBounds.Width / (double)_totalWidth))));
                        else
                            tmpWidth = gridCol.Width;

                        //_headerHeight = (int)(e.Graphics.MeasureString(gridCol.HeaderText, gridCol.InheritedStyle.Font, tmpWidth).Height) + 11;
                        int tmpHeight = (int)(e.Graphics.MeasureString(gridCol.HeaderText, gridCol.InheritedStyle.Font, tmpWidth).Height) + 11;
                        if (tmpHeight > _headerHeight) _headerHeight = tmpHeight;

                        ColumnLefts.Add(tmpLeft);
                        ColumnWidths.Add(tmpWidth);
                        ColumnTypes.Add(gridCol.GetType());
                        tmpLeft += tmpWidth;
                    }
                }

                while (_rowPos <= _dgv.Rows.Count - 1)
                {
                    var gridRow = _dgv.Rows[_rowPos];
                    if (gridRow.IsNewRow) //|| (!_printAllColumns&& !gridRow.Selected))
                    {
                        _rowPos++;
                        continue;
                    }

                    _cellHeight = gridRow.Height;
                    //算行高
                    int j = 0;
                    foreach (DataGridViewCell cel in gridRow.Cells)
                    {
                        if (!cel.OwningColumn.Visible)
                            continue;
                        if (!_selectedColumns.Contains(cel.OwningColumn.HeaderText))
                            continue;

                        SizeF size = e.Graphics.MeasureString(cel.Value != null ? cel.Value.ToString() : string.Empty, gridRow.InheritedStyle.Font, (int)ColumnWidths[j]);
                        if (size.Height > _cellHeight) _cellHeight = (int)size.Height;
                        j++;
                    }

                    if (tmpTop + _cellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        DrawFooter(e, _rowsPerPage);
                        _newPage = true;
                        _pageNo++;
                        e.HasMorePages = true;
                        return;
                    }

                    int i;
                    if (_newPage)
                    {
                        if (_printDocumentTitle)
                        {
                            using (var aFont = new Font(_dgv.Font, FontStyle.Bold))
                            {
                                e.Graphics.DrawString(_printTitle, aFont, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(_printTitle, aFont, e.MarginBounds.Width).Height - 23);
                                var s = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                                e.Graphics.DrawString(s, aFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(s, aFont, e.MarginBounds.Width).Width), e.MarginBounds.Top - e.Graphics.MeasureString(_printTitle, aFont, e.MarginBounds.Width).Height - 23);
                            }
                        }

                        tmpTop = e.MarginBounds.Top;
                        i = 0;
                        foreach (DataGridViewColumn gridCol in _dgv.Columns)
                        {
                            if (!gridCol.Visible)
                                continue;
                            if (!_selectedColumns.Contains(gridCol.HeaderText))
                                continue;

                            e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlLight), new Rectangle((int)ColumnLefts[i], tmpTop, (int)ColumnWidths[i], _headerHeight));
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)ColumnLefts[i], tmpTop, (int)ColumnWidths[i], _headerHeight));
                            e.Graphics.DrawString(gridCol.HeaderText, gridCol.InheritedStyle.Font, SystemBrushes.WindowText, new RectangleF((int)ColumnLefts[i], tmpTop, (int)ColumnWidths[i], _headerHeight), _strFormat);
                            i++;
                        }
                        _newPage = false;
                        tmpTop += _headerHeight;
                    }

                    i = 0;
                    foreach (DataGridViewCell cel in gridRow.Cells)
                    {
                        if (!cel.OwningColumn.Visible)
                            continue;
                        if (!_selectedColumns.Contains(cel.OwningColumn.HeaderText))
                            continue;

                        if (((Type)ColumnTypes[i]).Name == "DataGridViewTextBoxColumn" || ((Type)ColumnTypes[i]).Name == "DataGridViewLinkColumn")
                        {
                            e.Graphics.DrawString(cel.Value != null ? cel.Value.ToString() : string.Empty, cel.InheritedStyle.Font, new SolidBrush(cel.InheritedStyle.ForeColor), new RectangleF((int)ColumnLefts[i], (float)tmpTop, (int)ColumnWidths[i], (float)_cellHeight), _strFormat);
                        }
                        else if (((Type)ColumnTypes[i]).Name == "DataGridViewButtonColumn")
                        {
                            _cellButton.Text = cel.Value.ToString();
                            _cellButton.Size = new Size((int)ColumnWidths[i], _cellHeight);
                            using (var bmp = new Bitmap(_cellButton.Width, _cellButton.Height))
                            {
                                _cellButton.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                                e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
                            }
                        }
                        else if (((Type)ColumnTypes[i]).Name == "DataGridViewCheckBoxColumn")
                        {
                            _cellCheckBox.Size = new Size(14, 14);
                            _cellCheckBox.Checked = (bool)cel.Value;
                            var bmp = new Bitmap((int)ColumnWidths[i], _cellHeight);
                            var tmpGraphics = Graphics.FromImage(bmp);
                            tmpGraphics.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));
                            _cellCheckBox.DrawToBitmap(bmp, new Rectangle((int)((bmp.Width - _cellCheckBox.Width) / 2), (int)((bmp.Height - _cellCheckBox.Height) / 2), _cellCheckBox.Width, _cellCheckBox.Height));
                            e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
                        }
                        else if (((Type)ColumnTypes[i]).Name == "DataGridViewComboBoxColumn")
                        {
                            _cellComboBox.Size = new Size((int)ColumnWidths[i], _cellHeight);
                            using (var bmp = new Bitmap(_cellComboBox.Width, _cellComboBox.Height))
                            {
                                _cellComboBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                                e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
                            }
                            e.Graphics.DrawString(cel.Value.ToString(), cel.InheritedStyle.Font, new SolidBrush(cel.InheritedStyle.ForeColor), new RectangleF((int)ColumnLefts[i] + 1, tmpTop, (int)ColumnWidths[i] - 16, _cellHeight), _strFormatComboBox);
                        }
                        else if (((Type)ColumnTypes[i]).Name == "DataGridViewImageColumn")
                        {
                            var celSize = new Rectangle((int)ColumnLefts[i], tmpTop, (int)ColumnWidths[i], _cellHeight);
                            var imgSize = ((Image)(cel.FormattedValue)).Size;
                            e.Graphics.DrawImage((Image)cel.FormattedValue, new Rectangle((int)ColumnLefts[i] + (int)((celSize.Width - imgSize.Width) / 2), tmpTop + (int)((celSize.Height - imgSize.Height) / 2), ((Image)(cel.FormattedValue)).Width, ((Image)(cel.FormattedValue)).Height));

                        }

                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)ColumnLefts[i], tmpTop, (int)ColumnWidths[i], _cellHeight));
                        i++;
                    }
                    tmpTop += _cellHeight;
                    _rowPos++;
                    if (_pageNo == 1)
                        _rowsPerPage++;
                }

                if (_rowsPerPage == 0)
                    return;
                DrawFooter(e, _rowsPerPage);
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBoxPrime.Show(ex.Message, "Error", MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
            }
        }

        private static void DrawFooter(System.Drawing.Printing.PrintPageEventArgs e, int RowsPerPage)
        {
            double cnt = 0;

            if (_printAllColumns)
            {
                if (_dgv.Rows[_dgv.Rows.Count - 1].IsNewRow)
                    cnt = _dgv.Rows.Count - 2; // When the DataGridView doesn't allow adding rows
                else
                    cnt = _dgv.Rows.Count;//- 1; // When the DataGridView allows adding rows
            }
            else
                cnt = _dgv.RowCount;//_dgv.SelectedRows.Count;

            var pageNum = _pageNo + " /  " + Math.Ceiling(cnt / RowsPerPage);

            e.Graphics.DrawString(pageNum, _dgv.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(pageNum, _dgv.Font, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + e.MarginBounds.Height + 31);
        }

        private static DataGridView CloneDataGridView(DataGridView datagridViewInput)
        {
            try
            {
                var resultDataGridView = new DataGridView();
                resultDataGridView.ColumnHeadersDefaultCellStyle = datagridViewInput.ColumnHeadersDefaultCellStyle.Clone();
                var dataGridViewCellStyle = datagridViewInput.RowsDefaultCellStyle.Clone();
                dataGridViewCellStyle.BackColor = datagridViewInput.DefaultCellStyle.BackColor;
                dataGridViewCellStyle.ForeColor = datagridViewInput.DefaultCellStyle.ForeColor;
                dataGridViewCellStyle.Font = datagridViewInput.DefaultCellStyle.Font;
                resultDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle;
                resultDataGridView.AlternatingRowsDefaultCellStyle = datagridViewInput.AlternatingRowsDefaultCellStyle.Clone();
                for (int i = 0; i < datagridViewInput.Columns.Count; i++)
                {
                    var dataGridViewColumn = datagridViewInput.Columns[i].Clone() as DataGridViewColumn;
                    if (dataGridViewColumn != null)
                    {
                        dataGridViewColumn.DisplayIndex = datagridViewInput.Columns[i].DisplayIndex;
                        if (dataGridViewColumn.CellType == null)
                            dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
                        resultDataGridView.Columns.Add(dataGridViewColumn);
                    }
                }
                foreach (DataGridViewRow var in datagridViewInput.Rows)
                {
                    var dataGridViewRow = var.Clone() as DataGridViewRow;
                    if (dataGridViewRow != null)
                    {
                        dataGridViewRow.DefaultCellStyle = var.DefaultCellStyle.Clone();
                        for (int i = 0; i < var.Cells.Count; i++)
                        {
                            dataGridViewRow.Cells[i].Value = var.Cells[i].Value;
                        }
                        if (var.Index % 2 == 0)
                            dataGridViewRow.DefaultCellStyle.BackColor = resultDataGridView.RowsDefaultCellStyle.BackColor;
                        resultDataGridView.Rows.Add(dataGridViewRow);
                    }
                }
                return resultDataGridView;
            }
            catch (Exception ex)
            {
                MessageBoxPrime.Show(ex.Message);
            }
            return null;
        }
    }
}
