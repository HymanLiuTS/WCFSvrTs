using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;

namespace WindowsFormsApplication3
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:8001/");
            //Uri httpBaseAddress = new Uri("http://localhost:8002/");

            ServiceHost host = new ServiceHost(typeof(MyService), tcpBaseAddress);
            //object state=1;
            //host.BeginOpen(TimeSpan.FromSeconds(5), call, state);

            //Uri httpBaseAddress1 = new Uri("http://localhost:8003/");
            //ServiceHost host1 = new ServiceHost(typeof(MyService));
            host.Open();
            //host1.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            host.Close();
            //host1.Close();
        }

        private static void call(IAsyncResult ar)
        {
            MessageBox.Show("Called");
        }
    }
}
