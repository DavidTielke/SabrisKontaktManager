using System.Collections.Generic;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract
{
    public interface IPersonRepository
    {
        List<Person> Query { get; }
    }
}
