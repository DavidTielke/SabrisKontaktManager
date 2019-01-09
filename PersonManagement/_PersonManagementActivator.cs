using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.Core.Contract.Bootstrapping;
using CoCo.Core.Contract.Configuration;
using CoCo.Core.Contract.DependencyInjection;
using CoCo.Core.Contract.EventBrokerage;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract;

namespace DavidTielke.PersonManagerCoCo.Logic.PersonManagement
{
    public class PersonManagementActivator : IComponentActivator
    {
        public void Activating()
        {

        }

        public void Activated()
        {
        }

        public void RegisterMappings(IKernel kernel)
        {
            kernel.Register<IPersonManager, PersonManager>();
            kernel.RegisterConfiguration<PersonManagementConfiguration>();
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
        }

        public void Configure(IConfigurator config)
        {
        }
    }
}
