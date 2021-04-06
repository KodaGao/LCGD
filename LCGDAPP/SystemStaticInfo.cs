using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LCGD.APP
{  
    public class SystemStaticInfo
    {
        /// <summary>
        /// 软件名称
        /// </summary>
        public static  string SoftWareName = "防爆机器人系统";

        /// <summary>
        /// 开发厂家
        /// </summary>
        public static string FactoryName = "SK";

        /// <summary>
        /// url
        /// </summary>
        /// 
        public static string MainUrl = "http://127.0.0.1:5000/swagger/index.html";
        //public static string MainUrl = string.Format(@"{0}\html-resources\index.html", AppDomain.CurrentDomain.BaseDirectory);


        /// <summary>
        /// 日志及调试
        /// </summary>
        public static SK.RecordLog.RecordLog SysLog = SK.RecordLog.RecordLog.CreateInstance() ;

        /// <summary>
        /// 调用控制台
        /// </summary>
        public static SK.Common.CallConsole CallConsoleHelper = new SK.Common.CallConsole();

        /// <summary>
        /// url
        /// </summary>
        public static string ConsoleUrl = string.Format(@"{0}\Server\LCGDServer.exe", AppDomain.CurrentDomain.BaseDirectory);

        public static string APPPath = string.Format(@"{0}", AppDomain.CurrentDomain.BaseDirectory);

        public static string APPServerPath = string.Format(@"{0}\Server\", AppDomain.CurrentDomain.BaseDirectory);

        public static string APPServerName = string.Format(@"{0}", "LCGDServer.exe");

        /// <summary>
        /// 基础判断
        /// </summary>
        public static SK.Common.SingleForm SingleFormHelper = new SK.Common.SingleForm();

        /// <summary>
        /// .Net Core 3.1 桌面程序,Chrome内核
        /// </summary>
        public static SK.Chrome.BrowserFormChrome BrowserForm;


    }
}
