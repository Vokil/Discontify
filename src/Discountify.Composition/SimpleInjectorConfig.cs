using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discountify.Composition
{
    public static class SimpleInjectorConfig
    {
        public SimpleInjectorConfig()
        {
        }

        public static Container Container { get; private set; }

        public static void Initialize()
        {
            Database.SetInitializer<SiteFactoryContext>(null);

            // Web API container configuration
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            Container.EnableHttpRequestMessageTracking(GlobalConfiguration.Configuration);
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
            Compose(Container);
        }
    }
}
