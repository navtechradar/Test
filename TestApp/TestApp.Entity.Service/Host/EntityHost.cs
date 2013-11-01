using System.ComponentModel.Composition;
using System.ServiceModel;
using TestApp.Entity.Service.Service;
using TestApp.Interfaces.Common;

namespace TestApp.Entity.Service.Host
{
    [Export(typeof(IServiceHost))]
    public class EntityHost : IServiceHost
    {
        private readonly ServiceHost _host;
        private readonly EntityService _service;

        public EntityHost()
        {
            _service = new EntityService();
            _host = new ServiceHost(_service);
        }

        public void Start()
        {
            _host.Open();
        }

        public void Stop()
        {
            if(_host.State != CommunicationState.Closed)
                _host.Close();
        }
    }
}
