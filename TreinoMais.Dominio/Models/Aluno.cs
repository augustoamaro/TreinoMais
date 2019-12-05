using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreinoMais.Dominio.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [Remote("AlunoExiste", "Alunos", AdditionalFields = "AlunoId")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(14, 100, ErrorMessage = "Idade inválida")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(14, 100, ErrorMessage = "Idade inválida")]
        public int Peso { get; set; }

        public int ObjetivoId { get; set; }
        public Objetivo Objetivo { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, 7, ErrorMessage = "Frequencia inválida")]
        public int FrequenciaSemanal { get; set; }

        public ICollection<Treino> Treinos { get; set; }

    }
}
