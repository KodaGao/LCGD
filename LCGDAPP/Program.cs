using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCGD.APP
{
    static class Program
    {
        private static event SK.Common.SystemDelegate.SKDelegate.Del_InitSystem Event_InitSystem;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                SystemStaticInfo.CallConsoleHelper.Event_RuningMessage += CallConsoleHelper_Event_RuningMessage;

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (!SystemStaticInfo.SingleFormHelper.IsStartUniquely(Application.ProductName))
                    throw new Exception("��ǰϵͳ�Ѿ�������ֻ������һ��ϵͳʵ��");

                SystemStaticInfo.SysLog.RecordLogStart(SystemStaticInfo.APPPath);

                Event_InitSystem += Program_Event_InitSystem;
                //
                SK.Common.CoreForm.InitSplashScreenForm.ShowSplashScreen();
                //
                Event_InitSystem?.Invoke("������̨����...");
                //
                SystemStaticInfo.CallConsoleHelper.ConsoleRun(SystemStaticInfo.APPServerPath, SystemStaticInfo.APPServerName, "");
                Event_InitSystem?.Invoke("��̨�����������");
                //
                Event_InitSystem?.Invoke("��ʼ��������Ϣ...");
                //
                //SystemStaticInfo.CallConsoleHelper.ConsoleRun(SystemStaticInfo.APPServerPath, SystemStaticInfo.APPServerName, "");
                Event_InitSystem?.Invoke("��ʼ��������Ϣ���");
                ////
                //Event_InitSystem?.Invoke("��ʼ����ʱ��Դ...");
                //Event_InitSystem?.Invoke("��ʼ����ʱ��Դ���");
                ////
                //Event_InitSystem?.Invoke("��ʼ�����ݿ�...");
                //Event_InitSystem?.Invoke("��ʼ�����ݿ����");
                ////
                //Event_InitSystem?.Invoke("�������ݿ�...");
                //Event_InitSystem?.Invoke("�������ݿ����");


                Event_InitSystem?.Invoke("��ʼ��������...");
                SystemStaticInfo.BrowserForm = new SK.Chrome.BrowserFormChrome(SystemStaticInfo.SoftWareName, SystemStaticInfo.MainUrl);
                Application.Run(SystemStaticInfo.BrowserForm);

                SystemStaticInfo.BrowserForm.Event_SystemLoadFinish += BrowserForm_Event_SystemLoadFinish;
            }
            catch (Exception ex)
            {
                SystemStaticInfo.SysLog.RecordLogException(ex.Message);
                MessageBox.Show(string.Format("ϵͳ����ʧ�ܣ�������Ϣ����{0}����", ex.Message), "�쳣��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SystemStaticInfo.SysLog.RecordLogExit();
                SystemStaticInfo.CallConsoleHelper.ConsoleExit();
            }
        }

        private static void CallConsoleHelper_Event_RuningMessage(object sender, string MessageInfo)
        {
            SystemStaticInfo.SysLog.RecordLogRuning(MessageInfo);
            //SystemStaticInfo.SysLog.APPConsoleRuning(MessageInfo);
        }

        private static void BrowserForm_Event_SystemLoadFinish()
        {
            if (SK.Common.CoreForm.InitSplashScreenForm.Instance != null)
            {
                SK.Common.CoreForm.InitSplashScreenForm.Instance.BeginInvoke(new MethodInvoker(SK.Common.CoreForm.InitSplashScreenForm.Instance.Dispose));
                SK.Common.CoreForm.InitSplashScreenForm.Instance = null;
            }
        }

        private static void Program_Event_InitSystem(string Message)
        {
            SK.Common.CoreForm.InitSplashScreenForm.ShowRuningMessage(Message);
        }
    }
}