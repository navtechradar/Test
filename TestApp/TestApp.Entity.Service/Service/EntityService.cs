using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using TestApp.Common.Entities;
using TestApp.Entity.Service.Interfaces;
using TestApp.Interfaces.Entities;

namespace TestApp.Entity.Service.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class EntityService : IEntityService
    {
        public static void Configure(ServiceConfiguration config)
        {
            var tcpAddr = new Uri("net.tcp://localhost:880/EntityService");
            //var se = new ServiceEndpoint(new ContractDescription("IEntityService"), new NetTcpBinding(), new EndpointAddress(tcpAddr));
            //config.AddServiceEndpoint(se);
            config.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
            config.AddServiceEndpoint(typeof (IEntityService), new NetTcpBinding(), tcpAddr);
        }

        public ITestAppEntity GetEntity(Guid uniqueKey)
        {
            //return new TestAppEntity();
            return new TestAppEntity();
        }

        public int GetId()
        {
            return 1;
        }
    }
}
