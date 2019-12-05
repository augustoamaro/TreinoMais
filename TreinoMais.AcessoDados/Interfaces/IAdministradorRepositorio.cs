using System;
using System.Collections.Generic;
using System.Text;
using TreinoMais.AcessoDados.Interfaces;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Interfaces
{
    public interface IAdministradorRepositorio : IRepositorioGenerico<Administrador>
    {
        bool AdministradorExiste(string email, string senha);

        Administrador PegarAdministrador(string email, string senha);
    }
}
