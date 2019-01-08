using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.CSV
{
    public class PersonRepository : IPersonRepository
    {
        public List<Person> Query => File
            .ReadAllLines("data.csv")
            .Select(l => l.Split(','))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2])
            })
            .ToList();
    }
}
