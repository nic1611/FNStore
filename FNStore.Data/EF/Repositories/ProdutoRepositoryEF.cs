using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNStore.Data.EF.Repositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(FNStoreDataContext ctx) : base(ctx)
        { }

        public IEnumerable<Produto> GetAll()
        {
           return _ctx.Produtos.Include(e => e.TipoDeProduto).ToList();
        }

        public IEnumerable<Produto> GetByNameContains(string contains)
        {
            return
                    //from p in _ctx.Produtos
                    //where p.Nome.Contains(contains)
                    //select p;

                    _ctx.Produtos.Where(p => p.Nome.Contains(contains));
        }
    }
}
