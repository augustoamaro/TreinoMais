using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Interfaces
{
    public interface ITreinoRepositorio : IRepositorioGenerico<Treino>
    {
        Task<IEnumerable<Treino>> PegarTodosTreinosPeloAlunoId(int id);
        Task<Treino> PegarTreinoPeloAlunoId(int id);
        Task<bool> TreinoExiste(string Nome);
        Task<bool> TreinoExiste(string Nome, int TreinoId);
    }
}
