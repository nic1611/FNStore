using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;

namespace FNStore.Data.EF.Repositories
{
    public class TipoDeProdutoRepositoryEF : RepositoryEF<TipoDeProduto>, ITipoDeProdutoRepository
    {
        public TipoDeProdutoRepositoryEF(FNStoreDataContext ctx) : base(ctx)
        { }
    }
}
