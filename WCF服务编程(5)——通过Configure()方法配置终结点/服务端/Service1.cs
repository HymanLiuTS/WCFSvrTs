using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 :BaseService, IService1
    {
        public new static void Configure(ServiceConfiguration config)
        {
            BaseService.Configgure(config);
            WSHttpBinding wsBinding = new WSHttpBinding();
            //config.AddServiceEndpoint(typeof(IService1), wsBinding, "");
            //config.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            //config.EnableProtocol(new WSHttpBinding()); 
            config.LoadFromConfiguration();

        }
        public void DoWork()
        {
            MessageBox.Show("我被调用了");
        }
    }
}
