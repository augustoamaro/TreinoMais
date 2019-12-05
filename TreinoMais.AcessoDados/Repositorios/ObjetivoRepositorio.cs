using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.AcessoDados.Interfaces;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Repositorios
{
    public class ObjetivoRepositorio : RepositorioGenerico<Objetivo>, IObjetivoRepositorio
    {
        private readonly Contexto _contexto;

        public ObjetivoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> ObjetivoExiste(string Nome)
        {
            return await _contexto.Objetivos.AnyAsync(o => o.Nome == Nome);
        }

        public async Task<bool> ObjetivoExiste(string Nome, int ObjetivoId)
        {
            return await _contexto.Objetivos.AnyAsync(o => o.Nome == Nome && o.ObjetivoId != ObjetivoId);
        }
    }
}
