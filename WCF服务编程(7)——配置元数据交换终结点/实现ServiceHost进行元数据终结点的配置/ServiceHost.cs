using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Diagnostics;

namespace WindowsFormsApplication14
{
    public class ServiceHost<T>:ServiceHost
    {
        public ServiceHost():base(typeof(T))
        {
            
        }

        public void EnableMetaDataExchange(bool enableHttpGet = true)
        {
            if (State == CommunicationState.Opened)
            {
                throw new InvalidOperationException("Host is alread opened");
            }
            ServiceMetadataBehavior metadataBehavior = this.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (metadataBehavior == null)
            {
                metadataBehavior = new ServiceMetadataBehavior();
                Description.Behaviors.Add(metadataBehavior);
                if (BaseAddresses.Any(uri => uri.Scheme == "http"))
                {
                    metadataBehavior.HttpGetEnabled = enableHttpGet;
                }
            }
            AddAllMexEndpoint();
        }

        public bool HasMexEndPoint
        {
            get
            {
                return Description.Endpoints.Any(endpoint => endpoint.Contract.ContractType == typeof(IMetadataExchange));
            }
        }

        public void AddAllMexEndpoint()
        {
            Debug.Assert(HasMexEndPoint == false);
            foreach (Uri baseAddress in BaseAddresses)
            {
                System.ServiceModel.Channels.Binding binding = null;
                switch (baseAddress.Scheme)
                {
                    case "net.tcp":
                        binding = MetadataExchangeBindings.CreateMexTcpBinding();
                        break;
                    case "net.pipe":
                        binding = MetadataExchangeBindings.CreateMexNamedPipeBinding();
                        break;
                    case "http":
                        binding = MetadataExchangeBindings.CreateMexHttpBinding();
                        break;
                    case "https":
                        binding = MetadataExchangeBindings.CreateMexHttpsBinding();
                        break;
                }
                if (binding != null)
                {
                    AddServiceEndpoint(typeof(IMetadataExchange), binding, "Mex");
                }
            }
        }
        
    }
}
