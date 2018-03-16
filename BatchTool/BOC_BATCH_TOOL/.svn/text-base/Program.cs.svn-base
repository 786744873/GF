using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using CommonClient;

namespace BOC_BATCH_TOOL
{
    static class Program
    {
        public static Form MainForm { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            if (CheckSameProduct())
            {
                CommonClient.MessageBoxPrime.Show("软件已经在运行", "中国银行批量文件制作文件", MessageBoxButtonsEx.OK, MessageBoxIcon.Stop);
                Application.Exit(); return;
            }

            //if (args == null || args.Length == 0)
            //{
            //    Process app = new Process();
            //    app.StartInfo.Arguments = "checkupdate";
            //    app.StartInfo.FileName = "BOC_BATCH_TOOL.exe";
            //    app.StartInfo.CreateNoWindow = true;
            //    app.Start();
            //}
            //else
            //{
            try
            {
                CommonClient.SysCoach.SystemSettings.Init();
                CommonClient.SysCoach.SystemInit.CheckInit();
            }
            catch
            {
                CommonClient.SysCoach.SystemInit.Init();
            }
            finally
            {
                CommonClient.SysCoach.SystemSettings.CheckInit();
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                MainForm = Debugger.IsAttached ? new frmMain() { Visible = true, Enabled = true } : new frmMain { Visible = false, Enabled = false, WindowState = FormWindowState.Minimized };
                SplashFormController.Startup();
                Application.Run(MainForm);
            }
            catch (Exception ex) { }//MessageBoxPrime.Show(ex.Message, "中国银行批量文件制作文件", MessageBoxButtonsEx.OK, MessageBoxIcon.Error); }
            //}
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
        }

        private static bool CheckSameProduct()
        {
            List<Process> list = new List<Process>();
            list.AddRange(System.Diagnostics.Process.GetProcesses());
            return list.FindAll(o => { try { return o.MainModule.FileVersionInfo.ProductName.Equals(Application.ProductName); } catch { return false; } }).Count > 1;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }
    }
}
