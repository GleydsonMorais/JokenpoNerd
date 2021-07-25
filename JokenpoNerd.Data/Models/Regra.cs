using System;
using System.Collections.Generic;
using System.Text;

namespace JokenpoNerd.Data.Models
{
    public class Regra
    {
        public int Id { get; set; }
        public int OpcaoId1 { get; set; }
        public int OpcaoId2 { get; set; }
        public int VencedorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInclusao { get; set; }

        public Opcao Opcao1 { get; set; }
        public Opcao Opcao2 { get; set; }
        public Opcao Vencedor { get; set; }
    }
}
