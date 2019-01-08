using System.Collections.Generic;
using System.Linq;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract.DataClasses;

namespace DavidTielke.PersonManagerCoCo.Logic.PersonManagement
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _repository;

        public PersonManager(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> GetAllAdults() => _repository
            .Query
            .Where(p => p.Age >= 18)
            .ToList();

        public List<Person> GetAllChildren() => _repository
            .Query
            .Where(p => p.Age < 18)
            .ToList();

        public AgeStatistic GetAgeStatistic() => new AgeStatistic
        {
            AmountAdults = GetAllAdults().Count(),
            AmountChilden = GetAllChildren().Count()
        };
    }
}
