using System;
using System.Collections.Generic;
using System.Text;

namespace JokenpoNerd.Data.Models
{
    public class Opcao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInclusao { get; set; }

        public IList<Regra> RegrasOpcao1 { get; set; }
        public IList<Regra> RegrasOpcao2 { get; set; }
        public IList<Regra> RegrasVencedor { get; set; }
    }
}
