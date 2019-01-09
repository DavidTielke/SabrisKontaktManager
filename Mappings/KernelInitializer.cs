using CoCo.Configuration.Json;
using CoCo.Core.Contract.Bootstrapping;
using CoCo.Core.Contract.Configuration;
using CoCo.Core.Contract.EventBrokerage;
using DavidTielke.MBH.CrossCutting.CoCo.Core.Bootstrapping;
using DavidTielke.MBH.CrossCutting.CoCo.Core.Configuration;
using DavidTielke.MBH.CrossCutting.CoCo.Core.Configuration.ConfigObjects;
using DavidTielke.MBH.CrossCutting.CoCo.Core.EventBrokerage;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.CSV;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract;
using Ninject;

namespace DavidTielke.PersonManagerCoCo.DependencyInjection.Mappings
{
    public class KernelInitializer
    {
        public void Initialize(IKernel kernel)
        {
            // Bindings for Bootstrapper
            kernel.Bind<IBootstrapper>().To<Bootstrapper>().InSingletonScope();

            // Bindings for Configurator
            kernel.Bind<IConfigurator>().To<Configurator>().InSingletonScope();
            kernel.Bind<IConfigurationRepository>().To<DatabaseConfigurationRepository>();
            kernel.Bind<IConfigObjectProvider>().To<ConfigObjectProvider>();

            // Bindings for Event Aggregator
            kernel.Bind<IEventBroker>().To<EventBroker>().InSingletonScope();

            kernel.Bind<IComponentActivator>().To<PersonManagementActivator>();
            kernel.Bind<IComponentActivator>().To<DataStoringEfCoreActivator>();
        }
    }
}
