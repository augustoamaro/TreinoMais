using System;
using System.Collections.Generic;
using System.Text;

namespace TreinoMais.Dominio.Models
{
    public class Administrador
    {
            public int AdministradorId { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public ICollection<Professor> Professores { get; set; }
    }


}

