using System.Collections.Generic;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract
{
    public interface IRepository<TEntity>
    {
        List<TEntity> Query { get; }
    }
}