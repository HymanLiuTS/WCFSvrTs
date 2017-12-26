using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;

namespace WindowsFormsApplication11
{
    static class Program
    {
        /// <summary>binding
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(Service1));

            host.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            host.Close();
        }
    }
}
