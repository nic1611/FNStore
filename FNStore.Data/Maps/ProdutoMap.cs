using FNStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNStore.Data.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));
            //PK
            builder.HasKey(pk => pk.Id);

            //Colunas
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Preco)
                .HasColumnType("money");

            builder.Property(c => c.Qtde)
                .HasColumnName("Quantidade");

            builder.Property(c => c.TipoDeProdutoId);

            builder.Property(c => c.DataCadastro);

            //Relacionamento
            builder.HasOne(prod => prod.TipoDeProduto)
                .WithMany(tipo => tipo.Produtos)
                .HasForeignKey(fk => fk.TipoDeProdutoId);
        }
    }
}
