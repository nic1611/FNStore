using FN.Store.UI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FN.Store.UI.Data
{
    public class FNStoreDataContext : DbContext
    {
        public FNStoreDataContext(
            DbContextOptions<FNStoreDataContext> options
            ) : base(options)
        {
            Database.EnsureCreated();
            //Produtos.AddRange(new List<Produto>(){
            //    new Produto(){Id=0, Nome="Picanha", Preco=98.9M, Qtde=2, Tipo="Alimento"},
            //    new Produto(){Id=0, Nome="Picanha", Preco=98.9M, Qtde=2, Tipo="Alimento"},
            //    new Produto(){Id=0, Nome="Picanha", Preco=98.9M, Qtde=2, Tipo="Alimento"},
            //});
            //SaveChanges();
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}