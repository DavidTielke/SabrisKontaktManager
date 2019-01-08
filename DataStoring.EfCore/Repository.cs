using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore
{
    class Repository<TEntity> : IRepository<TEntity>
    {
        public List<TEntity> Query { get; }
    }
}
