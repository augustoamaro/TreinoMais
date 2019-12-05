using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Mapeamentos
{
    class CategoriaExercicioMap : IEntityTypeConfiguration<CategoriaExercicio>
    {
        public void Configure(EntityTypeBuilder<CategoriaExercicio> builder)
        {
            builder.HasKey(ce => ce.CategoriaExercicioId);
            builder.Property(ce => ce.Nome).HasMaxLength(50).IsRequired();
            builder.HasMany(ce => ce.Exercicios).WithOne(ce => ce.CategoriaExercicio).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("CategoriasExercicios");
            
        }
    }
}
