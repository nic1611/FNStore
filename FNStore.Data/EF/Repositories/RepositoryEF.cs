using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FNStore.Data.EF.Repositories
{
    public class RepositoryEF<T> : IRepository<T> where T : Entity
    {

        protected readonly FNStoreDataContext _ctx;
        public RepositoryEF(FNStoreDataContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<T> Get()
        {
            return _ctx.Set<T>().AsNoTracking().ToList();
        }

        public virtual T Get(int id)
        {
            return _ctx.Set<T>().AsNoTracking().FirstOrDefault(f => f.Id == id);
        }


        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            Save();
        }

        public virtual void Edit(T entity)
        {
            bool tracking = _ctx.Set<T>().Any(x => x.Id == entity.Id);
            if (!tracking)
            {
                System.Console.WriteLine("tracked");
                _ctx.Update<T>(entity);
            }

            _ctx.Entry<T>(entity).State = EntityState.Modified;

            Save();
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            Save();
        }

        protected void Save()
        {
            _ctx.SaveChanges();
        }


        public void Dispose()
        { }
    }
}
