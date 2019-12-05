using System.Threading.Tasks;
using TreinoMais.AcessoDados.Interfaces;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Interfaces
{
    public interface ICategoriaExercicioRepositorio : IRepositorioGenerico<CategoriaExercicio>
    {
        Task<bool> CategoriaExiste(string categoria);
        Task<bool> CategoriaExiste(string categoria, int CategoriaExercicioId);
    }
}
