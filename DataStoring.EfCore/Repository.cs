using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.Core.Contract.EventBrokerage;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract.DataClasses;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract.Messages;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore
{
    internal class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly PeopleContext _db;
        private readonly IEventBroker _eventBroker;

        public Repository(PeopleContext db,
            IEventBroker eventBroker)
        {
            _db = db;
            _eventBroker = eventBroker;
        }

        public IQueryable<TEntity> Query => _db.Set<TEntity>();
        public void Insert(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();

            _eventBroker.Raise(new EntityChangedMessage
            {
                Entity = entity,
                ChangedDate = DateTime.Now,
                Reason = ChangedReason.Inserted
            });
        }

        public void Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var entity = _db.Set<TEntity>().Find(id);

                if (entity == null)
                {
                    throw new IdNotFoundException($"Entity with id {id} was not found.");
                }
            }
            catch (Exception e) when (!(e is DataStoringException))
            {
                throw new DataStoringException($"Can't delete entity with id {id}", e);
            }
        }
    }
}
