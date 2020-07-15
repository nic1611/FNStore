using FNStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FNStore.Data.Maps
{
    public class TipoDeProdutoMap : IEntityTypeConfiguration<TipoDeProduto>
    {
        public void Configure(EntityTypeBuilder<TipoDeProduto> builder)
        {
            //Table
            builder.ToTable(nameof(TipoDeProduto));

            //PK
            builder.HasKey(pk => pk.Id);

            //Columns
            builder.Property(c => c.Id)
                 .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.DataCadastro);
        }
    }
}
