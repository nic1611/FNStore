using FNStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FNStore.Data.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Tabela
            builder.ToTable(nameof(Usuario));

            //PK
            builder.HasKey(pk => pk.Id);

            //Colunas
            builder.Property(c => c.Id)
                    .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

            builder.Property(c => c.Email)
                    .HasColumnType("varchar(80)")
                    .IsRequired()
                    .IsUnicode();

            builder.Property(c => c.Senha)
                .HasColumnType("char(88)")
                .IsRequired();

            builder.Property(c => c.DataCadastro);
        }
    }
}
