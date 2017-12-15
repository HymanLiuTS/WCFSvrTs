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
            Uri tcpBaseAddress = new Uri(@"http://localhost:8001/");
            ServiceHost host = new ServiceHost(typeof(Service1));
            System.ServiceModel.Channels.Binding wsBinding = new WSHttpBinding();
            //host.AddServiceEndpoint(typeof(IService1), wsBinding, "http://localhost:8002/");
            host.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            host.Close();
        }
    }
}
