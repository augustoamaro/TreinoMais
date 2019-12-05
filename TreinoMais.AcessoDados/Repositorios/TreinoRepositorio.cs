using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.AcessoDados.Interfaces;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Repositorios
{
    public class TreinoRepositorio : RepositorioGenerico<Treino>, ITreinoRepositorio
    {
        public readonly Contexto _contexto;

        public TreinoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> TreinoExiste(string Nome)
        {
            return await _contexto.Treinos.AnyAsync(f => f.Nome == Nome);
        }

        public async Task<bool> TreinoExiste(string Nome, int TreinoId)
        {
            return await _contexto.Treinos.AnyAsync(f => f.Nome == Nome && f.TreinoId != TreinoId);
        }

        public async Task<Treino> PegarTreinoPeloAlunoId(int id)
        {
            return await _contexto.Treinos.Include(f => f.Aluno).FirstOrDefaultAsync(f => f.TreinoId == id);
        }

        public async Task<IEnumerable<Treino>> PegarTodosTreinosPeloAlunoId(int id)
        {
            return await _contexto.Treinos.Include(f => f.Aluno).ThenInclude(f => f.Objetivo).Where(f => f.AlunoId == id).ToListAsync();
        }
    }
}


//Verificar esse arquivo implementar a interface
