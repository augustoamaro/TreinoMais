using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Mapeamentos
{
    public class TreinoMap : IEntityTypeConfiguration<Treino>
    {
        public void Configure(EntityTypeBuilder<Treino> builder)
        {
            builder.HasKey(f => f.TreinoId);

            builder.Property(f => f.Nome).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Cadastro).IsRequired();
            builder.Property(f => f.Validade).IsRequired();

            builder.HasOne(f => f.Aluno).WithMany(f => f.Treinos).HasForeignKey(f => f.AlunoId);
            builder.HasMany(f => f.ListaExercicios).WithOne(f => f.Treino).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Treinos");
        }
    }
}
