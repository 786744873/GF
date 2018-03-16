using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CommonClient.Controls
{
    public class ButtonlikeEntrancePanel : Panel
    {
        public readonly List<ButtonlikeEntranceItem> BranchButtonItems = new List<ButtonlikeEntranceItem>();
        public Image HoverImage { get; set; }
        public Image ClickImage { get; set; }

        public ButtonlikeEntrancePanel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Name = "ButtonlikeEntrancePanel";
            this.Size = new System.Drawing.Size(882, 598);
            this.Paint += this.BranchSelectorPanel_Paint;
            this.SizeChanged += BranchSelectorPanel_SizeChanged;
            this.MouseMove += BranchSelectorPanel_MouseMove;
            this.Click += BranchSelectorPanel_Click;

            this.ResumeLayout(false);

        }

        private const int ArrayMarginLeft = 10;
        private const int ArrayMarginTop = 10;
        private const int ArrayMarginRight = 10;
        private const int ArrayMarginBottom = 10;
        private const int CellMarginVertical = 5;
        private const int CellMarginHorizan = 5;

        private const int ArrayColumnCount = 7;
        private const int ArrayRowCount = 5;

        private const int ElementPadding = 9;
        private const int HoverPosShift = 1;

        private Color ArrayBorderColor = SystemColors.ControlLight;
        private Color CellBorderColor = SystemColors.ControlLight;
        private Color BackgroundColor = SystemColors.Control;
        private Color CellBackgroundColor = SystemColors.Control;


        private Rectangle GetPaintingArea()
        {
            return new Rectangle(ArrayMarginLeft, ArrayMarginTop, this.Width - ArrayMarginRight - ArrayMarginLeft, this.Height - ArrayMarginBottom - ArrayMarginTop);
        }

        public void CalculateAndArrangeButtons()
        {
            foreach (ButtonlikeEntranceItem branchButtonItem in this.BranchButtonItems)
            {
                branchButtonItem.ParamRect.Reset();
            }
            var cellWidth = GetPaintingArea().Width / ArrayColumnCount;
            var cellHeight = GetPaintingArea().Height / ArrayRowCount;

            var allCount = 0;
            var y = ArrayMarginTop;
            for (int j = 0; j < ArrayRowCount; j++)
            {
                var x = ArrayMarginLeft;
                for (int i = 0; i < ArrayColumnCount; i++)
                {
                    if (allCount < this.BranchButtonItems.Count)
                    {
                        this.BranchButtonItems[allCount].ParamRect.Rectangle = new Rectangle { X = x, Y = y, Width = cellWidth, Height = cellHeight }; ;
                        this.BranchButtonItems[allCount].ParamRect.Rectangle.Offset(CellMarginHorizan / 2, CellMarginVertical / 2);
                        this.BranchButtonItems[allCount].ParamRect.Rectangle.Inflate(-CellMarginHorizan / 2, -CellMarginVertical / 2);
                    }
                    allCount++;

                    x += cellWidth;
                }
                y += cellHeight;
            }
        }

        public void BranchSelectorPanel_SizeChanged(object sender, EventArgs e)
        {
            CalculateAndArrangeButtons();
        }

        private void BranchSelectorPanel_Click(object sender, EventArgs e)
        {
            var internalPosition = this.PointToClient(Cursor.Position);
            foreach (ButtonlikeEntranceItem branchButtonItem in this.BranchButtonItems)
            {
                branchButtonItem.ParamRect.Checked = false;
                if (branchButtonItem.ParamRect.Rectangle.Contains(internalPosition))
                {
                    branchButtonItem.ParamRect.Checked = true;
                    if (!branchButtonItem.Disabled)
                        branchButtonItem.OnClick(e);
                }
            }
            this.Invalidate();
            Application.DoEvents();
        }

        private void BranchSelectorPanel_MouseMove(object sender, MouseEventArgs e)
        {
            var internalPosition = this.PointToClient(Cursor.Position);
            foreach (ButtonlikeEntranceItem branchButtonItem in this.BranchButtonItems)
            {
                branchButtonItem.ParamRect.Hovering = false;
                if (branchButtonItem.ParamRect.Rectangle.Contains(internalPosition))
                    branchButtonItem.ParamRect.Hovering = true;
            }
            this.Invalidate();
        }

        private void BranchSelectorPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.BranchButtonItems.Count == 0 || this.HoverImage == null || this.ClickImage == null)
            {
                using (Brush xBrush = new SolidBrush(Color.Red))
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Pink, 5), e.ClipRectangle);
                    e.Graphics.DrawString("Please assign 'BranchButtonItems' for '" + this.Name + "', and assign 'HoverImage, ClickImage' before your can use it", this.Font, xBrush, 10, 10);
                    return;
                }
            }

            using (Pen aPen = new Pen(ArrayBorderColor))
            {
                e.Graphics.DrawRectangle(aPen, GetPaintingArea());
            }

            var hoverShift = 0;
            using (Pen aPen = new Pen(CellBorderColor))
            {
                using (SolidBrush textBrush = new SolidBrush(SystemColors.WindowText))
                {
                    using (SolidBrush disabledTextBrush = new SolidBrush(SystemColors.ControlDarkDark))
                    {
                        foreach (ButtonlikeEntranceItem branchButtonItem in this.BranchButtonItems)
                        {
                            if (!branchButtonItem.Disabled)
                            {
                                if (branchButtonItem.ParamRect.Checked)
                                    e.Graphics.DrawImage(this.ClickImage, branchButtonItem.ParamRect.Rectangle);
                                else if (branchButtonItem.ParamRect.Hovering)
                                    e.Graphics.DrawImage(this.HoverImage, branchButtonItem.ParamRect.Rectangle);
                            }

                            hoverShift = branchButtonItem.ParamRect.Hovering && !branchButtonItem.Disabled ? 1 : 0;
                            e.Graphics.DrawRectangle(aPen, branchButtonItem.ParamRect.Rectangle);
                            var aImage = branchButtonItem.Image;
                            if (!branchButtonItem.Disabled)
                                e.Graphics.DrawImage(aImage, branchButtonItem.ParamRect.Rectangle.Left - hoverShift + (branchButtonItem.ParamRect.Rectangle.Width - aImage.Width) / 2, branchButtonItem.ParamRect.Rectangle.Top + ElementPadding, aImage.Width, aImage.Height);
                            else
                                ControlPaint.DrawImageDisabled(e.Graphics, aImage, branchButtonItem.ParamRect.Rectangle.Left - hoverShift + (branchButtonItem.ParamRect.Rectangle.Width - aImage.Width) / 2, branchButtonItem.ParamRect.Rectangle.Top + ElementPadding, SystemColors.ControlDarkDark);
                            var textRectangle = new Rectangle(branchButtonItem.ParamRect.Rectangle.Left + ElementPadding - hoverShift, branchButtonItem.ParamRect.Rectangle.Top + aImage.Height + ElementPadding, branchButtonItem.ParamRect.Rectangle.Width - ElementPadding * 2, branchButtonItem.ParamRect.Rectangle.Height - aImage.Height - ElementPadding * 2);
                            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                            if (!branchButtonItem.Disabled)
                                e.Graphics.DrawString(branchButtonItem.ButtonText, this.Font, textBrush, textRectangle, sf);
                            else
                                e.Graphics.DrawString(branchButtonItem.ButtonText, this.Font, disabledTextBrush, textRectangle, sf);
                        }
                    }
                }
            }
        }
    }

    public class ButtonlikeEntranceItem
    {
        public string ButtonText { get; set; }
        public Image Image { get; set; }
        public bool Disabled { get; set; }
        internal readonly ParamRectDescriptor ParamRect = new ParamRectDescriptor();
        public event OnBranchButtonItemClicked ButtonClicked;
        public object Tag { get; set; }

        internal void OnClick(EventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this, this);
        }

        internal class ParamRectDescriptor
        {
            public Rectangle Rectangle { get; set; }
            private bool _checked;
            public bool Checked
            {
                get { return _checked; }
                set
                {
                    if (_checked != value)
                    {
                        _checked = value;
                        NeedRefresh = true;
                    }
                }
            }

            private bool _hovering;
            public bool Hovering
            {
                get { return _hovering; }
                set
                {
                    if (_hovering != value)
                    {
                        _hovering = value;
                        NeedRefresh = true;
                    }
                }
            }

            internal void Reset()
            {
                this.Hovering = false;
                //this.Checked = false;
                this.Rectangle = new Rectangle();
                this.NeedRefresh = false;
            }

            private bool _needRefresh;
            public bool NeedRefresh { get { return this.Hovering || this.Checked || _needRefresh; } private set { _needRefresh = value; } }
        }
    }

    public delegate void OnBranchButtonItemClicked(object sender, ButtonlikeEntranceItem buttonItem);
}
