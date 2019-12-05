using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Interfaces
{
        public interface IListaExercicioRepositorio : IRepositorioGenerico<ListaExercicio>
        {
            Task<bool> ExercicioExisteNoTreino(int exercicioId, int treinoId);
        }
    
}
