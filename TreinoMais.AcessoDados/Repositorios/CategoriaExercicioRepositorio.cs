using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TreinoMais.AcessoDados;
using TreinoMais.AcessoDados.Repositorios;
using TreinoMais.Dominio.Models;
using TreinoMais.AcessoDados.Interfaces;

namespace TreinoMais.AcessoDados.Repositorios
{
    public class CategoriaExercicioRepositorio : RepositorioGenerico<CategoriaExercicio>, ICategoriaExercicioRepositorio
    {
        private readonly Contexto _contexto;

        public CategoriaExercicioRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> CategoriaExiste(string categoria)
        {
            return await _contexto.CategoriasExercicios.AnyAsync(ce => ce.Nome == categoria);
        }

        public async Task<bool> CategoriaExiste(string categoria, int CategoriaExercicioId)
        {
            return await _contexto.CategoriasExercicios.AnyAsync(ce => ce.Nome == categoria && ce.CategoriaExercicioId != CategoriaExercicioId);
        }
    }
}
