using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Mapeamentos
{
    public class AdministradoresMap : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.HasKey(a => a.AdministradorId);

            
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Senha).IsRequired();
            builder.HasMany(a => a.Professores).WithOne(a => a.Administrador).HasForeignKey(p => p.AdministradorId);
            builder.ToTable("Administradores");
          
        }
    }
}
