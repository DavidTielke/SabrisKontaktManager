using System.Collections.Generic;
using System.Linq;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query { get; }
    }
}