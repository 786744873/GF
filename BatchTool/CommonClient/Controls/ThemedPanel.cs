using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace CommonClient.Controls
{
    public partial class ThemedPanel : Panel
    {
        public ThemedPanel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this.MinimumSize = new Size { Width = 100, Height = 80 };
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.Cursor = Cursors.Hand;

            m_InnerICONPanel.BackColor = System.Drawing.Color.Transparent;
            m_InnerICONPanel.BackgroundImageLayout = ImageLayout.Center;
            m_InnerICONPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            m_InnerICONPanel.Width = 64;
            m_InnerICONPanel.Height = 44;
            m_InnerICONPanel.Location = new Point { X = (this.Width - m_InnerICONPanel.Width) / 2, Y = 5 };

            m_InnerDescLabel.Text = string.Empty;
            m_InnerDescLabel.TextAlign = ContentAlignment.MiddleCenter;
            m_InnerDescLabel.Location = new Point { X = 5, Y = (this.Width + 5 + m_InnerICONPanel.Height - m_InnerDescLabel.Height) / 2 };

            this.Controls.AddRange(new Control[] { m_InnerICONPanel, m_InnerDescLabel });

            this.SizeChanged += new EventHandler(ThemedPanel_SizeChanged);
            this.MouseHover += new EventHandler(ThemedPanel_MouseHover);
            m_InnerICONPanel.MouseHover += new EventHandler(ThemedPanel_MouseHover);
            m_InnerDescLabel.MouseHover += new EventHandler(ThemedPanel_MouseHover);
            this.MouseLeave += new EventHandler(ThemedPanel_MouseLeave);
            this.Click += new EventHandler(ThemedPanel_Click);
            m_InnerDescLabel.Click += new EventHandler(m_InnerI_Click);
            m_InnerICONPanel.Click += new EventHandler(m_InnerI_Click);

            EventClass.Instance.OnCheckedChangedEvent += new EventHandler<CheckedEventArgs>(ThemedPanel_CheckedChangedEvent);
        }

        void m_InnerI_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        void ThemedPanel_CheckedChangedEvent(object sender, CheckedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CheckedEventArgs>(ThemedPanel_CheckedChangedEvent), sender, e); }
            else
            {
                if (e.Container.Name != this.Parent.Name) return;
                SelectState = e.Owner.Name == this.Name ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        public ThemedPanel(IContainer container)
            : this()
        {
            container.Add(this);
        }

        Panel m_InnerICONPanel = new Panel();

        Label m_InnerDescLabel = new Label();

        private CheckState m_SelectState = CheckState.Unchecked;
        /// <summary>
        /// 选中状态
        /// </summary>
        [Browsable(true)]
        public CheckState SelectState
        {
            get { return m_SelectState; }
            set
            {
                m_SelectState = value;
                InitSelectState();
            }
        }

        private Image m_InnerImage = null;
        /// <summary>
        /// 内部图片
        /// </summary>
        [Browsable(true)]
        public Image InnerImage
        {
            get { return m_InnerImage; }
            set
            {
                m_InnerImage = value;
                InitInnerImage();
            }
        }

        private string m_InnerText = string.Empty;
        /// <summary>
        /// 内部说明
        /// </summary>
        [Browsable(true)]
        public string InnerText
        {
            get { return m_InnerText; }
            set
            {
                m_InnerText = value;
                InitInnerText();
            }
        }

        private void InitInnerText()
        {
            if (string.IsNullOrEmpty(m_InnerText))
            { m_InnerDescLabel.Text = m_InnerText; return; }

            m_InnerDescLabel.AutoSize = true;
            m_InnerDescLabel.Height = 12;
            m_InnerDescLabel.Text = m_InnerText;

            int topheight = m_InnerICONPanel.Height + m_InnerICONPanel.Location.Y;
            if (m_InnerDescLabel.Width > this.Width)
            {
                m_InnerDescLabel.AutoSize = false;
                m_InnerDescLabel.Width = this.Width - 10;
                m_InnerDescLabel.Height = 26;
                m_InnerDescLabel.Location = new Point { X = 5, Y = topheight + (this.Height - topheight - m_InnerDescLabel.Height) / 2 };
            }
            else
            {
                m_InnerDescLabel.Location = new Point { X = (this.Width - m_InnerDescLabel.Width) / 2, Y = topheight + (this.Height - topheight - m_InnerDescLabel.Height) / 2 };
            }
        }

        private void InitInnerImage()
        {
            m_InnerICONPanel.BackgroundImage = m_InnerImage;

            m_InnerICONPanel.Location = new Point { X = (this.Width - m_InnerICONPanel.Width) / 2, Y = 5 };
        }

        private void InitSelectState()
        {
            if (m_SelectState == CheckState.Checked)
                this.BackgroundImage = Properties.Resources.hoverBg;
            else this.BackgroundImage = null;
        }

        void ThemedPanel_SizeChanged(object sender, EventArgs e)
        {
            InitInnerText();
            InitInnerImage();
        }

        void ThemedPanel_MouseHover(object sender, EventArgs e)
        {
            if (null == this.BackgroundImage)
                this.BackgroundImage = Properties.Resources.hoverBg;
        }

        void ThemedPanel_MouseLeave(object sender, EventArgs e)
        {
            if (m_SelectState != CheckState.Checked)
                this.BackgroundImage = null;
        }

        void ThemedPanel_Click(object sender, EventArgs e)
        {
            EventClass.Instance.RequestCheckedChanged(this, this.Parent);
        }

        class EventClass
        {
            #region 单例
            private static object lock_obj = new object();
            private static EventClass m_instance;
            public static EventClass Instance
            {
                get
                {
                    if (null == m_instance)
                    {
                        lock (lock_obj)
                        {
                            if (null == m_instance)
                            {
                                lock (lock_obj)
                                {
                                    m_instance = new EventClass();
                                }
                            }
                        }
                    }
                    return m_instance;
                }
            }
            #endregion

            private event EventHandler<CheckedEventArgs> m_CheckedChangedEvent;

            public event EventHandler<CheckedEventArgs> OnCheckedChangedEvent
            {
                add { m_CheckedChangedEvent += value; }
                remove { m_CheckedChangedEvent -= value; }
            }

            public void RequestCheckedChanged(Control owner, Control parent)
            {
                if (m_CheckedChangedEvent != null)
                    m_CheckedChangedEvent(this, new CheckedEventArgs { Owner = owner, Container = parent });
            }
        }
    }

    public class CheckedEventArgs : EventArgs
    {
        private Control m_Owner;
        /// <summary>
        /// 所属控件
        /// </summary>
        public Control Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        private Control m_Container;
        /// <summary>
        /// 父级容器
        /// </summary>
        public Control Container
        {
            get { return m_Container; }
            set { m_Container = value; }
        }

        public CheckedEventArgs()
        {
            m_Owner = new Control();
            m_Container = new Control();
        }
    }
}
