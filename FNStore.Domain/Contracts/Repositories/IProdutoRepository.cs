using FNStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNStore.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetByNameContains(string contains);
        IEnumerable<Produto> GetAll();
    }
}
