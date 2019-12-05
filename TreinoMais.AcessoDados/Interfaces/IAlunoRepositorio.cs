using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Interfaces
{
    public interface IAlunoRepositorio : IRepositorioGenerico<Aluno>
    {
        new Task<IEnumerable<Aluno>> PegarTodos();

        new Task<IEnumerable<Aluno>> PegarTodos(int AdministradorId);

        string PegarNomeAlunoPeloId(int id);

        Task<Aluno> PegarDadosAlunoPeloId(int AlunoId);

        Task<bool> AlunoExiste(string NomeCompleto);

        Task<bool> AlunoExiste(string NomeCompleto, int AlunoId);
    }
}
