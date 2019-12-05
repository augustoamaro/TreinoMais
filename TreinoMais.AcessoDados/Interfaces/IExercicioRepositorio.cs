using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Interfaces
{
    public interface IExercicioRepositorio : IRepositorioGenerico<Exercicio>
    {
        new Task<IEnumerable<Exercicio>> PegarTodos();

        Task<bool> ExercicioExiste(string nome);
        Task<bool> ExercicioExiste(string nome, int ExericioId);
    }
}
