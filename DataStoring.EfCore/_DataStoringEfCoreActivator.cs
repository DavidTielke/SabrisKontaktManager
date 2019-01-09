using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.Core.Contract.Bootstrapping;
using CoCo.Core.Contract.Configuration;
using CoCo.Core.Contract.DependencyInjection;
using CoCo.Core.Contract.EventBrokerage;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore
{
    public class DataStoringEfCoreActivator : IComponentActivator
    {
        public void Activating()
        {
        }

        public void Activated()
        {
        }

        public void RegisterMappings(IKernel kernel)
        {
            kernel.Register(typeof(IRepository<>), typeof(Repository<>));
            kernel.RegisterToSelf<PeopleContext>();
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
        }

        public void Configure(IConfigurator config)
        {
        }
    }
}
