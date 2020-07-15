using FNStore.Data.Maps;
using FNStore.Domain.Entities;
using FNStore.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FNStore.Data.EF
{
    public class FNStoreDataContext : DbContext
    {
        public FNStoreDataContext(
            DbContextOptions<FNStoreDataContext> options
            ) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //var alimento = new TipoDeProduto() { Nome = "Alimento" };

            //TipoDeProdutos.AddRange(new List<TipoDeProduto>()
            //{
            //    new TipoDeProduto() { Nome = "Eletrônico" },
            //    new TipoDeProduto() { Nome = "Limpeza" },
            //    new TipoDeProduto() { Nome = "Bebidas" },
            //    new TipoDeProduto() { Nome = "Instrumentos" },
            //    new TipoDeProduto() { Nome = "Ferragens" },
            //    new TipoDeProduto() { Nome = "Mecanico" },
            //    new TipoDeProduto() { Nome = "Outros" },
            //});
            //Produtos.AddRange(new List<Produto>(){
            //    new Produto(){Nome="Picanha", Preco=70.9M, Qtde=2, TipoDeProduto=alimento},
            //    new Produto(){Nome="Maça", Preco=1.9M, Qtde=2, TipoDeProduto=alimento},
            //    new Produto(){Nome="Banana", Preco=1.9M, Qtde=2, TipoDeProduto=alimento},
            //    new Produto(){Nome="Feijão", Preco=8.9M, Qtde=2, TipoDeProduto=alimento},
            //    new Produto(){Nome="Batata", Preco=2.9M, Qtde=2, TipoDeProduto=alimento},
            //});
            //Usuarios.Add(new Usuario() { Nome = "Nicolas", Email = "email@email.com", Senha = "123".Encrypt() });
            //SaveChanges();
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoDeProduto> TipoDeProdutos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TipoDeProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
