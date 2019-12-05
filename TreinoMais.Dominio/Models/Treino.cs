using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreinoMais.Dominio.Models
{
    public class Treino
    {
        public int TreinoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [Remote("TreinoExiste", "Treinos", AdditionalFields = "TreinoId")]
        public string Nome { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Validade { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public ICollection<ListaExercicio> ListaExercicios { get; set; }
    }
}
