using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.CSV;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract;
using Ninject;

namespace DavidTielke.PersonManagerCoCo.DependencyInjection.Mappings
{
    public class KernelInitializer
    {
        public void Initialize(IKernel kernel)
        {
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<IPersonManager>().To<PersonManager>();
        }
    }
}
