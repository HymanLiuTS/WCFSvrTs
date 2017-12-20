using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Uri uri = new Uri("http://localhost:8001/Service1/");
            ServiceHost host = new ServiceHost(typeof(Service1),uri);
            //ServiceHost host1 = new ServiceHost(typeof(Service1));
            
            host.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            host.Close();
        }
    }
}
