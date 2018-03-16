using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CommonClient.Utilities;

namespace CommonClient.Controls
{
    public class ThemedDataGridView : DataGridView
    {
        public Label NoDataLabel { get; private set; }

        public ThemedDataGridView()
        {
            this.NoDataLabel = new Label();
            this.Controls.Add(NoDataLabel);
            this.NoDataLabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoDataLabel.BackColor = SystemColors.Window;
            this.NoDataLabel.ForeColor = SystemColors.ControlLight;
            this.NoDataLabel.BorderStyle = BorderStyle.None;
            this.NoDataLabel.AutoSize = false;
            this.NoDataLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.NoDataLabel.Width = 382;
            this.NoDataLabel.Height = 64;
            this.NoDataLabel.Text = "未加载数据";//"No Data Loaded";
        }

        public new string Text
        {
            get { return this.NoDataLabel.Text; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    this.NoDataLabel.Text = value;
            }
        }

        public void ShowNoDataTip()
        {
            //重置NoDataLabel的前景色、背景色，解决多次频繁点击后背景色消失不掉的问题
            this.NoDataLabel.BackColor = SystemColors.Window;
            this.NoDataLabel.ForeColor = SystemColors.ControlLight;
            UIAnimation.Do(this.NoDataLabel, "BackColor", Color.Orange, new AnimationTypeFlash(2, 300));
            UIAnimation.Do(this.NoDataLabel, "ForeColor", SystemColors.Window, new AnimationTypeFlash(2, 300));
        }

        protected override void CreateHandle()
        {
            NoDataLabel.Parent = this;
            base.CreateHandle();
            //Row settings
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(216, 224, 229);
            this.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            this.DefaultCellStyle.BackColor = SystemColors.Window;
            this.DefaultCellStyle.ForeColor = SystemColors.WindowText;
            this.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.DefaultCellStyle.SelectionForeColor = SystemColors.WindowText;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.WindowText;
            this.RowHeadersVisible = false;
            this.RowHeadersWidth = 4;

            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersHeight = 35;

            this.EnableHeadersVisualStyles = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.DefaultCellStyle.SelectionBackColor = Color.Transparent;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    if (SelectedRows.Count == 1)
                        ClearSelection();

                    if (SelectionMode == DataGridViewSelectionMode.CellSelect && hitTestInfo.ColumnIndex >= 0)
                        this[hitTestInfo.ColumnIndex, hitTestInfo.RowIndex].Selected = true;
                    else if (SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                        this.Rows[hitTestInfo.RowIndex].Selected = true;
                }
            }
            base.OnMouseDown(e);
        }

        public bool Sortable
        {
            set
            {
                var sortMode = value ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable;
                foreach (DataGridViewColumn column in this.Columns)
                {
                    column.SortMode = sortMode;
                }
            }
        }

        public int? SelectedRowNumber
        {
            get
            {
                if (SelectionMode == DataGridViewSelectionMode.CellSelect)
                {
                    int? selectedRow = null;

                    foreach (DataGridViewCell cell in SelectedCells)
                    {
                        if (selectedRow.HasValue)
                        {
                            if (selectedRow.Value != cell.RowIndex)
                                return null;
                        }
                        else
                            selectedRow = cell.RowIndex;
                    }

                    return selectedRow;
                }

                if (SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                {
                    if (SelectedRows.Count != 1)
                        return null;
                    return SelectedRows[0].Index;
                }
                return null;
            }
        }


        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                var rowBounds = new Rectangle(0, e.RowBounds.Top, this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - this.HorizontalScrollingOffset + 1, e.RowBounds.Height);
                using (Brush backbrush = new LinearGradientBrush(rowBounds, this.Rows[e.RowIndex].DefaultCellStyle.BackColor, Color.LightGray, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(Brushes.White, rowBounds);
                    e.Graphics.FillRectangle(backbrush, rowBounds);
                }
            }
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            this.NoDataLabel.Left = (this.Width - this.NoDataLabel.Width) / 2;
            this.NoDataLabel.Top = (this.Height - this.NoDataLabel.Height) / 2;
        }

        //protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        //{
        //    base.OnDataBindingComplete(e);
        //    this.NoDataLabel.Visible = this.Rows.Count == 0;
        //}

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            base.OnCellEndEdit(e);
            this.NoDataLabel.Visible = this.Rows.Count == 0;
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            this.NoDataLabel.Visible = this.Rows.Count == 0;
        }

        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            base.OnRowsRemoved(e);
            this.NoDataLabel.Visible = this.Rows.Count == 0;
        }
    }
}
