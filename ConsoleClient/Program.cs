using System;
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

            var manager = kernel.Get<IPersonManager>();

            var adults = manager.GetAllAdults();
            var children = manager.GetAllChildren();
            var statistic = manager.GetAgeStatistic();

            Console.WriteLine($"### Erwachsene ({statistic.AmountAdults}) ###");
            adults.ForEach(a => Console.WriteLine(a.Name));

            Console.WriteLine($"### Kinder ({statistic.AmountChilden}) ###");
            children.ForEach(c => Console.WriteLine(c.Name));

            Console.ReadKey();
        }
    }
}
