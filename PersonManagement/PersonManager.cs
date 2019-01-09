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
        private readonly IRepository<Person> _repository;

        public PersonManager(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public IQueryable<Person> GetAllAdults() => _repository
            .Query
            .Where(p => p.Age >= 18);

        public IQueryable<Person> GetAllChildren() => _repository
            .Query
            .Where(p => p.Age < 18);

        public AgeStatistic GetAgeStatistic() => new AgeStatistic
        {
            AmountAdults = GetAllAdults().Count(),
            AmountChilden = GetAllChildren().Count()
        };
    }
}
