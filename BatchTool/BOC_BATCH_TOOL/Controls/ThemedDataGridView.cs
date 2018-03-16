using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace BOC_BATCH_TOOL.Controls
{
    public class ThemedDataGridView : DataGridView
    {
        protected override void CreateHandle()
        {
            base.CreateHandle();
            //Row settings
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.RowHeadersVisible = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(216, 224, 229);
            this.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            this.DefaultCellStyle.BackColor = SystemColors.Window;
            this.DefaultCellStyle.ForeColor = SystemColors.WindowText;
            this.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.DefaultCellStyle.SelectionForeColor = SystemColors.WindowText;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.WindowText;

            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

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
                if (!value)
                {
                    foreach (DataGridViewColumn column in this.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                else
                {
                    foreach (DataGridViewColumn column in this.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
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

    }
}
