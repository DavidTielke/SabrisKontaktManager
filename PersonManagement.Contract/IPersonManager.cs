using System.Collections.Generic;
using System.Linq;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract.DataClasses;

namespace DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract
{
    public interface IPersonManager
    {
        IQueryable<Person> GetAllAdults();
        IQueryable<Person> GetAllChildren();
        AgeStatistic GetAgeStatistic();
        void Add(Person person);
    }
}
