using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
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
            return _ctx.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _ctx.Set<T>().Find(id);
        }


        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            Save();
        }

        public void Edit(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            Save();
        }

        private void Save()
        {
            _ctx.SaveChanges();
        }


        public void Dispose()
        { }
    }
}
