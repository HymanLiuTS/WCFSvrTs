using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace WcfServiceContract
{
    [ServiceContract]
    internal interface IMyContract
    {
        [OperationContract]
        String MyMethod(string text);

        [OperationContract]
        string MyOtherMethod(string text);
    }   

}