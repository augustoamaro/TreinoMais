using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Mapeamentos
{
    public class ListaExercicioMap : IEntityTypeConfiguration<ListaExercicio>
    {
        public void Configure(EntityTypeBuilder<ListaExercicio> builder)
        {
            builder.HasKey(le => le.ListaExercicioId);

            builder.Property(le => le.Frequencia).IsRequired();
            builder.Property(le => le.Repeticoes).IsRequired();
            builder.Property(le => le.Carga).IsRequired();

            builder.HasOne(le => le.Exercicio).WithMany(le => le.ListaExercicios).HasForeignKey(le => le.ExercicioId);
            builder.HasOne(le => le.Treino).WithMany(le => le.ListaExercicios).HasForeignKey(le => le.TreinoId);

            builder.ToTable("ListasExercicios");
        }
    }
}
