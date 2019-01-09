using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly PeopleContext _db;

        public Repository(PeopleContext db)
        {
            _db = db;
        }

        public IQueryable<TEntity> Query => _db.Set<TEntity>();
    }
}
