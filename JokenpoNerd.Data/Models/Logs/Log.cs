using System;
using System.Collections.Generic;
using System.Text;

namespace JokenpoNerd.Data.Models.Logs
{
    public class Log
    {
        public int Id { get; set; }
        public string Opcao1 { get; set; }
        public string Opcao2 { get; set; }
        public string Mensagem { get; set; }
        public DateTime DtInclusao { get; set; }
    }
}
