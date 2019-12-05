using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.AcessoDados.Interfaces;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Repositorios
{
    public class ListaExercicioRepositorio : RepositorioGenerico<ListaExercicio>, IListaExercicioRepositorio
    {
        private readonly Contexto _contexto;

        public ListaExercicioRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> ExercicioExisteNoTreino(int exercicioId, int treinoId)
        {
            return await _contexto.ListaExercicios.AnyAsync(e => e.ExercicioId == exercicioId && e.TreinoId == treinoId);
        }
    }
}
