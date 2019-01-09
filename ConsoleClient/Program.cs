using System;
using System.Linq;
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
