using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;

namespace CommonClient.VisualParts
{
    public partial class MenuControlPanel : BaseUc
    {
        public MenuControlPanel()
        {
            InitializeComponent();
            CommandCenter.OnMoveMenuEventHandler += new EventHandler<MoveMenuEventArgs>(CommandCenter_OnMoveMenuEventHandler);
            CommandCenter.OnShowPanelEventHandler += new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(MenuControlPanel), this);
                menuListPanel1.Width = this.Width - 78;
                pCPre.Location = new Point { X = this.Width - 75, Y = pCPre.Location.Y };
                pCBack.Location = new Point { X = this.Width - 58, Y = pCBack.Location.Y };
                pictureBox1.Location = new Point { X = this.Width - 37, Y = pictureBox1.Location.Y };
            }
        }

        void CommandCenter_OnShowPanelEventHandler(object sender, ShowPanelEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.Command == EnumTypes.OperatorCommandType.View)
                {
                    if (e.AppType == EnumTypes.AppliableFunctionType._Empty && e.BatchAppType != EnumTypes.FunctionInSettingType.BatchConvert)
                    {
                        pictureBox1.BackgroundImage = global::CommonClient.Properties.Resources.settingselectedbg;
                    }
                    else
                    {
                        pictureBox1.BackgroundImage = global::CommonClient.Properties.Resources.settingred;
                    }
                }
            }
        }

        void CommandCenter_OnMoveMenuEventHandler(object sender, MoveMenuEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<MoveMenuEventArgs>(CommandCenter_OnMoveMenuEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.Command == EnumTypes.OperatorCommandType.MoveMenuCallBack)
                {
                    if (e.Endposition <= menuListPanel1.Width)
                    {
                        pCBack.Enabled = pBack.Enabled = false;
                        pBack.BackgroundImage = global::CommonClient.Properties.Resources.grayright;
                    }
                    else if (e.Endposition > menuListPanel1.Width)
                    {
                        pCBack.Enabled = pBack.Enabled = true;
                        pBack.BackgroundImage = global::CommonClient.Properties.Resources.redright;
                    }

                    if (e.Startposition >= 0)
                    {
                        pCPre.Enabled = pPre.Enabled = false;
                        pPre.BackgroundImage = global::CommonClient.Properties.Resources.grayleft;
                    }
                    else if (e.Startposition < 0)
                    {
                        pCPre.Enabled = pPre.Enabled = true;
                        pPre.BackgroundImage = global::CommonClient.Properties.Resources.redleft;
                    }

                    pCBack.Visible = pCPre.Visible = pCPre.Enabled || pCBack.Enabled;
                }
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            CommandCenter.ResolveShowPanel(EnumTypes.OperatorCommandType.View, EnumTypes.AppliableFunctionType._Empty, EnumTypes.FunctionInSettingType.Empty);
        }

        private void pBack_Click(object sender, EventArgs e)
        {
            if (pBack.Enabled)
            {
                CommandCenter.ResolveMoveMenu(OperatorCommandType.MoveMenuRequest, 0, 0, 0, 0, 0, OperatorCommandType.MoveMenuReduce);
            }
        }

        private void pPre_Click(object sender, EventArgs e)
        {
            if (pPre.Enabled)
            {
                CommandCenter.ResolveMoveMenu(OperatorCommandType.MoveMenuRequest, 0, 0, menuListPanel1.Width, 0, 0, OperatorCommandType.MoveMenuRaise);
            }
        }
    }
}
