using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace BOC_BATCH_TOOL.Controls
{
    public enum SplitterState
    {
        Collapsed = 0,
        Expanding,
        Expanded,
        Collapsing
    }

    [ToolboxBitmap(typeof(SnapSplitter))]
    [Designer(typeof(CollapsibleSplitterDesigner))]
    public class SnapSplitter : Splitter
    {
        private bool _hot;
        private readonly Color _hotColor = Color.FromArgb(36, SystemColors.Highlight);
        private Control _controlToHide;
        private Rectangle _rr;
        private Form _parentForm;
        private bool _expandParentForm;
        private bool _isMouseDown;
        private bool _isMouseDownAndMove;

        private Border3DStyle _borderStyle = Border3DStyle.Flat;

        private readonly Timer _animationTimer;
        private int _controlWidth;
        private int _controlHeight;
        private int _parentFormWidth;
        private int _parentFormHeight;
        private SplitterState _currentState;
        private int _animationDelay = 20;
        private int _animationStep = 20;

        private static Image _ssLeft = Properties.Resources.ss_left;
        private static Image _ssRight = Properties.Resources.ss_right;
        private static Image _ssUp = Properties.Resources.ss_up;
        private static Image _ssDown = Properties.Resources.ss_down;


        [Bindable(true), Category("Collapsing Options"), DefaultValue("False")]
        public bool IsCollapsed
        {
            get
            {
                if (this._controlToHide != null)
                    return !this._controlToHide.Visible;
                return true;
            }
        }

        [Bindable(true), Category("Collapsing Options"), DefaultValue("")]
        public Control ControlToHide
        {
            get { return this._controlToHide; }
            set { this._controlToHide = value; }
        }

        [Bindable(true), Category("Collapsing Options"), DefaultValue("20")]
        public int AnimationDelay
        {
            get { return this._animationDelay; }
            set { this._animationDelay = value; }
        }

        [Bindable(true), Category("Collapsing Options"), DefaultValue("20"),
         Description("The amount of pixels moved in each animation step")]
        public int AnimationStep
        {
            get { return this._animationStep; }
            set { this._animationStep = value; }
        }

        [Bindable(true), Category("Collapsing Options"), DefaultValue("False")]
        public bool ExpandParentForm
        {
            get { return this._expandParentForm; }
            set { this._expandParentForm = value; }
        }

        [Bindable(true), Category("Collapsing Options"), DefaultValue("Border3DStyle.Flat")]
        public Border3DStyle BorderStyle3D
        {
            get { return this._borderStyle; }
            set
            {
                this._borderStyle = value;
                this.Invalidate();
            }
        }

        public void ToggleState()
        {
            this.ToggleSplitter();
        }


        public SnapSplitter()
        {
            this.Click += OnClick;
            this.Resize += OnResize;
            this.MouseLeave += OnMouseLeave;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;

            this._animationTimer = new Timer { Interval = _animationDelay };
            this._animationTimer.Tick += this.AnimationTimerTick;

            this.MinimumSize = new Size(20, 20);
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this._parentForm = this.FindForm();

            if (this._controlToHide != null)
            {
                if (this._controlToHide.Visible)
                    this._currentState = SplitterState.Expanded;
                else
                    this._currentState = SplitterState.Collapsed;
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.Invalidate();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this._controlToHide != null)
            {
                if (!this._hot && this._controlToHide.Visible)
                    base.OnMouseDown(e);
            }
            _isMouseDown = true;
        }

        private void OnResize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= _rr.X && e.X <= _rr.X + _rr.Width && e.Y >= _rr.Y && e.Y <= _rr.Y + _rr.Height)
            {
                if (!this._hot)
                {
                    this._hot = true;
                    this.Cursor = Cursors.Hand;
                    this.Invalidate();
                }
            }
            else
            {
                _isMouseDownAndMove = false;
                if (this._hot)
                {
                    this._hot = false;
                    this.Invalidate();
                }

                this.Cursor = Cursors.Default;

                if (_controlToHide != null)
                {
                    if (!_controlToHide.Visible)
                        this.Cursor = Cursors.Default;
                    else
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                            this.Cursor = Cursors.VSplit;
                        else
                            this.Cursor = Cursors.HSplit;
                        if (_isMouseDown)
                            _isMouseDownAndMove = true;
                    }
                }
            }
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            this._hot = false;
            this.Invalidate();
        }

        private void OnMouseUp(object sender, EventArgs e)
        {
            _isMouseDown = false;
            _isMouseDownAndMove = false;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (_controlToHide != null && _hot && _currentState != SplitterState.Collapsing && _currentState != SplitterState.Expanding)
            {
                if (!_isMouseDownAndMove)
                    ToggleSplitter();
            }
            _isMouseDown = false;
            _isMouseDownAndMove = false;
        }

        private void ToggleSplitter()
        {
            if (_currentState == SplitterState.Collapsing || _currentState == SplitterState.Expanding)
                return;

            _controlWidth = _controlToHide.Width;
            _controlHeight = _controlToHide.Height;

            if (_controlToHide.Visible)
            {
                _currentState = SplitterState.Collapsed;
                _controlToHide.Visible = false;
                if (_expandParentForm && _parentForm != null)
                {
                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        _parentForm.Width -= _controlToHide.Width;
                    else
                        _parentForm.Height -= _controlToHide.Height;
                }
            }
            else
            {
                _currentState = SplitterState.Expanded;
                _controlToHide.Visible = true;
                if (_expandParentForm && _parentForm != null)
                {
                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        _parentForm.Width += _controlToHide.Width;
                    else
                        _parentForm.Height += _controlToHide.Height;
                }
            }
        }


        private void AnimationTimerTick(object sender, EventArgs e)
        {
            switch (_currentState)
            {
                case SplitterState.Collapsing:

                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                    {
                        if (_controlToHide.Width > _animationStep)
                        {
                            if (_expandParentForm && _parentForm.WindowState != FormWindowState.Maximized && _parentForm != null)
                                _parentForm.Width -= _animationStep;
                            _controlToHide.Width -= _animationStep;
                        }
                        else
                        {
                            if (_expandParentForm && _parentForm.WindowState != FormWindowState.Maximized && _parentForm != null)
                                _parentForm.Width = _parentFormWidth;
                            _controlToHide.Visible = false;
                            _animationTimer.Enabled = false;
                            _controlToHide.Width = _controlWidth;
                            _currentState = SplitterState.Collapsed;
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        if (_controlToHide.Height > _animationStep)
                        {
                            if (_expandParentForm && _parentForm.WindowState != FormWindowState.Maximized && _parentForm != null)
                                _parentForm.Height -= _animationStep;
                            _controlToHide.Height -= _animationStep;
                        }
                        else
                        {
                            if (_expandParentForm && _parentForm.WindowState != FormWindowState.Maximized && _parentForm != null)
                                _parentForm.Height = _parentFormHeight;
                            _controlToHide.Visible = false;
                            _animationTimer.Enabled = false;
                            _controlToHide.Height = _controlHeight;
                            _currentState = SplitterState.Collapsed;
                            this.Invalidate();
                        }
                    }
                    break;

                case SplitterState.Expanding:

                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                    {
                        if (_controlToHide.Width < (_controlWidth - _animationStep))
                        {
                            if (_expandParentForm && _parentForm.WindowState != FormWindowState.Maximized && _parentForm != null)
                                _parentForm.Width += _animationStep;
                            _controlToHide.Width += _animationStep;
                        }
                        else
                        {
                            if (_expandParentForm && _parentForm.WindowState != FormWindowState.Maximized && _parentForm != null)
                                _parentForm.Width = _parentFormWidth;
                            _controlToHide.Width = _controlWidth;
                            _controlToHide.Visible = true;
                            _animationTimer.Enabled = false;
                            _currentState = SplitterState.Expanded;
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        if (_controlToHide.Height < (_controlHeight - _animationStep))
                        {
                            if (_expandParentForm && _parentForm.WindowState != FormWindowState.Maximized && _parentForm != null)
                                _parentForm.Height += _animationStep;
                            _controlToHide.Height += _animationStep;
                        }
                        else
                        {
                            if (_expandParentForm && _parentForm.WindowState != FormWindowState.Maximized && _parentForm != null)
                                _parentForm.Height = _parentFormHeight;
                            _controlToHide.Height = _controlHeight;
                            _controlToHide.Visible = true;
                            _animationTimer.Enabled = false;
                            _currentState = SplitterState.Expanded;
                            this.Invalidate();
                        }
                    }
                    break;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            var r = this.ClientRectangle;
            g.FillRectangle(new SolidBrush(this.BackColor), r);

            switch (this.Dock)
            {
                case DockStyle.Right:
                    {
                        _rr = new Rectangle(r.X, r.Y + ((r.Height - _ssLeft.Height) / 2), _ssLeft.Width, _ssLeft.Height);
                        var handleRect = new Rectangle(_rr.X + 1, _rr.Y, _ssLeft.Width, _ssLeft.Height);

                        if (this._currentState == SplitterState.Collapsed)
                            g.DrawImage(_ssRight, handleRect);
                        else if (this._currentState == SplitterState.Expanded)
                            g.DrawImage(_ssLeft, handleRect);

                        if (_hot)
                            g.FillRectangle(new SolidBrush(_hotColor), handleRect);
                    }
                    break;
                case DockStyle.Left:
                    {
                        _rr = new Rectangle(r.X, r.Y + ((r.Height - _ssLeft.Height) / 2), _ssLeft.Width, _ssLeft.Height);
                        var handleRect = new Rectangle(_rr.X + 1, _rr.Y, _ssLeft.Width, _ssLeft.Height);

                        if (this._currentState == SplitterState.Collapsed)
                            g.DrawImage(_ssLeft, handleRect);
                        else if (this._currentState == SplitterState.Expanded)
                            g.DrawImage(_ssRight, handleRect);

                        if (_hot)
                            g.FillRectangle(new SolidBrush(_hotColor), handleRect);
                    }
                    break;
                case DockStyle.Bottom:
                    {
                        _rr = new Rectangle(r.X + ((r.Width - _ssUp.Width) / 2), r.Y, _ssUp.Width, _ssUp.Height);
                        var handleRect = new Rectangle(_rr.X, _rr.Y + 1, _ssUp.Width, _ssUp.Height);

                        if (this._currentState == SplitterState.Collapsed)
                            g.DrawImage(_ssDown, handleRect);
                        else if (this._currentState == SplitterState.Expanded)
                            g.DrawImage(_ssUp, handleRect);

                        if (_hot)
                            g.FillRectangle(new SolidBrush(_hotColor), handleRect);
                    }
                    break;
                case DockStyle.Top:
                    {
                        _rr = new Rectangle(r.X + ((r.Width - _ssUp.Width) / 2), r.Y, _ssUp.Width, _ssUp.Height);
                        var handleRect = new Rectangle(_rr.X, _rr.Y + 1, _ssUp.Width, _ssUp.Height);

                        if (this._currentState == SplitterState.Collapsed)
                            g.DrawImage(_ssUp, handleRect);
                        else if (this._currentState == SplitterState.Expanded)
                            g.DrawImage(_ssDown, handleRect);

                        if (_hot)
                            g.FillRectangle(new SolidBrush(_hotColor), handleRect);
                    }
                    break;
                default:
                    throw new Exception("The Collapsible Splitter control cannot have the Filled or None Dockstyle property");
            }

            g.Dispose();
        }
    }


    public class CollapsibleSplitterDesigner : ControlDesigner
    {
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            properties.Remove("IsCollapsed");
            properties.Remove("BorderStyle");
            properties.Remove("Size");
        }
    }
}