using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;

namespace WindowsFormsApplication6
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Uri httpBaseAddress = new Uri(@"http://localhost:8001/");
            ServiceHost host = new ServiceHost(typeof(Service1), httpBaseAddress);
            WSHttpBinding wsBinding = new WSHttpBinding();
            wsBinding.TransactionFlow = true;
            //传递的字符串是app.config中默认的bingding名称
            WSHttpBinding wsBinding1 = new WSHttpBinding("WSHttpBinding_IService1");
            host.AddServiceEndpoint(typeof(IService1), wsBinding, "");
            //host.AddServiceEndpoint(typeof(IService1), wsBinding, "MyService");
            host.AddServiceEndpoint(typeof(IService1), wsBinding1, "http://localhost:8002/MyService");
            host.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            host.Close();
        }
    }
}
