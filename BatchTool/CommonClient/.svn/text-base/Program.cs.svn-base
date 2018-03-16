using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using CommonClient;

namespace CommonClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            if (CheckSameProduct())
            {
                MessageBoxPrime.Show("软件已经在运行", "中行批量文件制作文件", MessageBoxButtonsEx.OK, MessageBoxIcon.Stop);
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
                SysCoach.SystemSettings.Init();
                //SysCoach.SystemInit.Instance.CheckInit();
            }
            catch
            {
                SysCoach.SystemInit.Init();
            }
            finally
            {
                SysCoach.SystemSettings.CheckInit();
            } try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            }
            catch (Exception ex) { }//MessageBoxPrime.Show(ex.Message, "中行批量文件制作文件", MessageBoxButtonsEx.OK, MessageBoxIcon.Error); }
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
