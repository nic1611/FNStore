using FNStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNStore.Domain.Contracts.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IEnumerable<T> Get();
        T Get(int id);

        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);

    }
}
