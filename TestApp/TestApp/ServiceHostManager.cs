using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Autofac;
using Autofac.Integration.Mef;
using TestApp.Interfaces.Common;

namespace TestApp
{
    public class ServiceHostManager : IProcess
    {
        private IContainer _container;

        private List<IServiceHost> _serviceHosts;

        public void Start()
        {
            LoadPlugins();
            _serviceHosts = _container.Resolve<IEnumerable<IServiceHost>>().ToList();
            _serviceHosts.ForEach(sh => sh.Start());
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        private void LoadPlugins()
        {
            var builder = new ContainerBuilder();
            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(new DirectoryCatalog("Plugins", "TestApp.*.dll"));
            builder.RegisterComposablePartCatalog(aggregateCatalog);
            _container = builder.Build();
        }
    }
}
