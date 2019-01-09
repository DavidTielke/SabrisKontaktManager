using System;
using System.Linq;
using CoCo.Core.Contract.Bootstrapping;
using CoCo.Core.Contract.EventBrokerage;
using DavidTielke.MBH.CrossCutting.CoCo.Core.NinjectAdapter;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract.Messages;
using DavidTielke.PersonManagerCoCo.DependencyInjection.Mappings;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract;
using Ninject;

namespace DavidTielke.PersonManagerCoCo.UI.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            new KernelInitializer().Initialize(kernel);

            var mykernel = new KernelAdapter(kernel);

            var bootstrapper = kernel.Get<IBootstrapper>();
            bootstrapper.ActivatedAll();
            bootstrapper.RegisterAllMappings(mykernel);

            var eventBroker = kernel.Get<IEventBroker>();
            eventBroker.Subscribe<EntityChangedMessage>(msg => Console.WriteLine($"Entität: {msg.Reason}"));

            var manager = kernel.Get<IPersonManager>();

            manager.Add(new Person
            {
                Name = "Nessi",
                Age = 2,
                FK_CategoryId = 2
            });

            var adults = manager.GetAllAdults().OrderBy(a => a.Name).ThenBy(a => a.Age);
            var children = manager.GetAllChildren();
            var statistic = manager.GetAgeStatistic();

            Console.WriteLine($"### Erwachsene ({statistic.AmountAdults}) ###");
            adults.ToList().ForEach(a => Console.WriteLine(a.Name));

            Console.WriteLine($"### Kinder ({statistic.AmountChilden}) ###");
            children.ToList().ForEach(c => Console.WriteLine($"{c.Name} - {c.Category.Name}"));

            Console.ReadKey();
        }
    }
}
