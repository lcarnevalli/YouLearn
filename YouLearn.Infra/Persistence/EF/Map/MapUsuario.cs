using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //throw new NotImplementedException();
            //onde crio o mapeamento para a tabela

            // nome da tabela
            builder.ToTable("Usuario");

            //colunas da tabela
            // chave primaria
            builder.HasKey(x => x.Id);
            
            //mapeando objetos de valor
            builder.OwnsOne<Nome>(x => x.Nome, cb =>
             {
                 cb.Property(x => x.PrimeiroNome).HasMaxLength(50).HasColumnName("PrimeiroNome").IsRequired();
                 cb.Property(x => x.UltimoNome).HasMaxLength(50).HasColumnName("UltimoNome").IsRequired();
             });
            builder.OwnsOne<Email>(x => x.Email, cb =>
            {
                cb.Property(x => x.Endereco).HasMaxLength(200).HasColumnName("Email").IsRequired();
            });
            builder.OwnsOne<Senha>(x => x.Senha, cb =>
            {
                cb.Property(x => x.ValorSenha).HasMaxLength(50).HasColumnName("Senha").IsRequired();
            });

        }
    }
}
