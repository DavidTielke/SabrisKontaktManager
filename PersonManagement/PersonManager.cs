using CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract.DataClasses;
using System.Linq;

namespace DavidTielke.PersonManagerCoCo.Logic.PersonManagement
{
    internal class PersonManager : IPersonManager
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonManagementConfiguration _config;

        public PersonManager(IRepository<Person> repository,
            PersonManagementConfiguration config)
        {
            _repository = repository;
            this._config = config;
            _config = config;
        }

        public IQueryable<Person> GetAllAdults()
        {
            return _repository.Query.Where(p => p.Age >= _config.AgeThreshold);
        }

        public IQueryable<Person> GetAllChildren()
        {
            return _repository.Query.Where(p => p.Age < _config.AgeThreshold);
        }

        public AgeStatistic GetAgeStatistic()
        {
            return new AgeStatistic
            {
                AmountAdults = GetAllAdults().Count(),
                AmountChilden = GetAllChildren().Count()
            };
        }

        public void Add(Person person) => _repository.Insert(person);
    }
}
