using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1,IService2
    {
        public void Show()
        {
            MessageBox.Show("");
        }

        public void DoWork()
        {
            MessageBox.Show("我被调用了");
        }

        public void DoOtherWork()
        {
            MessageBox.Show("我又被调用了");
        }
    }
}
