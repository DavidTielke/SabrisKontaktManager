using System.Collections.Generic;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;
using DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract.DataClasses;

namespace DavidTielke.PersonManagerCoCo.Logic.PersonManagement.Contract
{
    public interface IPersonManager
    {
        List<Person> GetAllAdults();
        List<Person> GetAllChildren();
        AgeStatistic GetAgeStatistic();
    }
}
