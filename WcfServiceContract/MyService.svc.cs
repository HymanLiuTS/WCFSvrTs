using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MyService”。
    public class MyService : IMyContract, IService1
    {
        string IMyContract.MyMethod(string text)
        {
            return "Hello " + text;
        }

        public string MyOtherMethod(string text)
        {
            return "Can not call this method over wcf";
        }

        public string GetData(int data)
        {
            return data.ToString();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
