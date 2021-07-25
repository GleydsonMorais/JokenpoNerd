using JokenpoNerd.Data.Context;
using JokenpoNerd.Data.Enums;
using JokenpoNerd.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokenpoNerd.Data
{
    public class JokenpoNerdSeeder
    {
        public static async Task Initialize(JokenpoNerdContext context)
        {
            await context.Database.MigrateAsync();

            if (!context.Opcoes.Any())
                await AdicionarOpcoesAsync(context);

            if (!context.Regras.Any())
                await AdicionarRegrasAsync(context);
        }

        private static async Task AdicionarOpcoesAsync(JokenpoNerdContext context)
        {
            var listOpcao = new List<Opcao>
            {
                new Opcao { Descricao = Enum.GetName(typeof(OpcaoEnum), (int)OpcaoEnum.Pedra), DtInclusao = DateTime.Now },
                new Opcao { Descricao = Enum.GetName(typeof(OpcaoEnum), (int)OpcaoEnum.Papel), DtInclusao = DateTime.Now },
                new Opcao { Descricao = Enum.GetName(typeof(OpcaoEnum), (int)OpcaoEnum.Tesoura), DtInclusao = DateTime.Now },
                new Opcao { Descricao = Enum.GetName(typeof(OpcaoEnum), (int)OpcaoEnum.Lagarto), DtInclusao = DateTime.Now },
                new Opcao { Descricao = Enum.GetName(typeof(OpcaoEnum), (int)OpcaoEnum.Spock), DtInclusao = DateTime.Now },
            };

            await context.AddRangeAsync(listOpcao);
            await context.SaveChangesAsync();
        }

        private static async Task AdicionarRegrasAsync(JokenpoNerdContext context)
        {
            var listRegras = new List<Regra>
            {
                new Regra { OpcaoId1 = (int)OpcaoEnum.Tesoura, OpcaoId2 = (int)OpcaoEnum.Papel, VencedorId = (int)OpcaoEnum.Tesoura, Descricao = "Tesoura corta papel.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Papel, OpcaoId2 = (int)OpcaoEnum.Pedra, VencedorId = (int)OpcaoEnum.Papel, Descricao = "Papel cobre pedra.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Pedra, OpcaoId2 = (int)OpcaoEnum.Lagarto, VencedorId = (int)OpcaoEnum.Pedra, Descricao = "Pedra esmaga lagarto.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Lagarto, OpcaoId2 = (int)OpcaoEnum.Spock, VencedorId = (int)OpcaoEnum.Lagarto, Descricao = "Lagarto envenena Spock.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Spock, OpcaoId2 = (int)OpcaoEnum.Tesoura, VencedorId = (int)OpcaoEnum.Spock, Descricao = "Spock quebra tesoura.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Tesoura, OpcaoId2 = (int)OpcaoEnum.Lagarto, VencedorId = (int)OpcaoEnum.Tesoura, Descricao = "Tesoura decapita lagarto.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Lagarto, OpcaoId2 = (int)OpcaoEnum.Papel, VencedorId = (int)OpcaoEnum.Lagarto, Descricao = "Lagarto come papel.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Papel, OpcaoId2 = (int)OpcaoEnum.Spock, VencedorId = (int)OpcaoEnum.Papel, Descricao = "Papel refuta Spock.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Spock, OpcaoId2 = (int)OpcaoEnum.Pedra, VencedorId = (int)OpcaoEnum.Spock, Descricao = "Spock vaporiza pedra.", DtInclusao = DateTime.Now  },
                new Regra { OpcaoId1 = (int)OpcaoEnum.Pedra, OpcaoId2 = (int)OpcaoEnum.Tesoura, VencedorId = (int)OpcaoEnum.Tesoura, Descricao = "Pedra esmaga tesoura.", DtInclusao = DateTime.Now  },
            };

            await context.AddRangeAsync(listRegras);
            await context.SaveChangesAsync();
        }
    }
}
