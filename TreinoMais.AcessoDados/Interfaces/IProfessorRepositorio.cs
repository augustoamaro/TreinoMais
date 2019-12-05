using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Interfaces
{
    public interface IProfessorRepositorio : IRepositorioGenerico<Professor>
    {
        Task<bool> ProfessorExiste(string nome);
        Task<bool> ProfessorExiste(string Nomne, int ProfessorId);
    }
}
