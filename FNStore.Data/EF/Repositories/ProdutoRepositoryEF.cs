using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FNStore.Data.EF.Repositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(FNStoreDataContext ctx) : base(ctx)
        { }

        public IEnumerable<Produto> GetAll()
        {
           return _ctx.Produtos.Include(e => e.TipoDeProduto).AsNoTracking().ToList();
        }

        public IEnumerable<Produto> GetByNameContains(string contains)
        {
            return _ctx.Produtos.AsNoTracking().Where(p => p.Nome.Contains(contains));
        }
    }
}
