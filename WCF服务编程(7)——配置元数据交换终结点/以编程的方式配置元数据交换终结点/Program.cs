using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WindowsFormsApplication12
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(Service1));
            ServiceMetadataBehavior metadataBehavior;
            metadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (metadataBehavior == null)
            {
                metadataBehavior = new ServiceMetadataBehavior();
                host.Description.Behaviors.Add(metadataBehavior);
            }
            //以创建ServiceMetadataEndpoint对象的方式添加元数据终结点
            EndpointAddress address = new EndpointAddress("net.tcp://localhost:8001/service1/mex");
            System.ServiceModel.Channels.Binding binding = MetadataExchangeBindings.CreateMexTcpBinding();
            ServiceEndpoint endpoint = new ServiceMetadataEndpoint(binding,address);
            host.AddServiceEndpoint(endpoint);
            //以创建binding的形式部分元数据终结点
            //System.ServiceModel.Channels.Binding binding = MetadataExchangeBindings.CreateMexHttpBinding();
            //host.AddServiceEndpoint(typeof(IMetadataExchange), binding, "Mex");
            host.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            host.Close();
        }
    }
}
