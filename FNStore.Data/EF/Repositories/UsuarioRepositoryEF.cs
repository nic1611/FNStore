using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using System.Linq;

namespace FNStore.Data.EF.Repositories
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(FNStoreDataContext ctx) : base(ctx)
        { }

        public Usuario Get(string email)
        {
            return _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }
    }
}
