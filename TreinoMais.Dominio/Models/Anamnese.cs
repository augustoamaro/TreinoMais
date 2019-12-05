using System;
using System.Collections.Generic;
using System.Text;

namespace TreinoMais.Dominio.Models
{
    public class Anamnese
    {
        public int AnamneseId { get; set; }

        public string DoencaFamiliar { get; set; }
        public string MedicacaoUtilizada { get; set; }
        public string PraticaAtividadeFisica { get; set; }
        public string UtilizaMedicacao { get; set; }
        public string PossuiLesao { get; set; }
        public string TeveLesao { get; set; }
        public string Cirurgia { get; set; }
        public string DesconfortoCorpo { get; set; }
        public string PraticaMusculacao { get; set; }
        public string QuantoTempo { get; set; }
        public string Objetivo { get; set; }
        public string LocalTreino { get; set; }
        public string QuantidadeVezesTreino { get; set; }
        public string DiasDisponiveisTreino { get; set; }
        public string PeriodoTreino { get; set; }
        public string QuantidadeRefeicoes { get; set; }
        public byte[] PosturaFrente { get; set; }
        public byte[] PosturaLado { get; set; }
        public byte[] PosturaCostas { get; set; }
    }
}
