using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreinoMais.AcessoDados;
using TreinoMais.AcessoDados.Interfaces;
using TreinoMais.AcessoDados.Repositorios;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Repositorios
{
    public class AdministradorRepositorio : RepositorioGenerico<Administrador>, IAdministradorRepositorio
    {
        private readonly Contexto _contexto;

        public AdministradorRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public bool AdministradorExiste(string email, string senha)
        {
            return _contexto.Administradores.Any(a => a.Email == email && a.Senha == senha);
        }
        public Administrador PegarAdministrador(string email, string senha)
        {
            return _contexto.Administradores.FirstOrDefault(a => a.Email == email && a.Senha == senha);
        }
    }
}
