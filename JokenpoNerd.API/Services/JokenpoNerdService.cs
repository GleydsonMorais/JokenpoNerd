using JokenpoNerd.API.Interfaces;
using JokenpoNerd.API.Utils;
using JokenpoNerd.Data.Enums;
using JokenpoNerd.Data.Helpers;
using JokenpoNerd.Data.Models.Logs;
using JokenpoNerd.Data.Repositories;
using JokenpoNerd.Data.Repositories.Logs;
using System;
using System.Threading.Tasks;

namespace JokenpoNerd.API.Services
{
    public class JokenpoNerdService : IJokenpoNerdService
    {
        private readonly IJokenpoNerdRepository _jokenpoNerdRepository;
        private readonly ILogRepository _logRepository;

        public JokenpoNerdService(IJokenpoNerdRepository jokenpoNerdRepository,
            ILogRepository logRepository)
        {
            _jokenpoNerdRepository = jokenpoNerdRepository;
            _logRepository = logRepository;
        }

        public async Task<QueryResult<string>> GetWinner(string opcao1, string opcao2)
        {
            string opcao1Format = FormatString.OpcaoToTitleCase(opcao1.ToLower());
            string opcao2Format = FormatString.OpcaoToTitleCase(opcao2.ToLower());

            if (!Enum.IsDefined(typeof(OpcaoEnum), opcao1Format))
            {
                await _logRepository.InsertLog(opcao1, opcao2, $"A opçao '{opcao1}' não é válida.");
                return new QueryResult<string>
                {
                    Succeeded = false,
                    Message = $"A opçao '{opcao1}' não é válida."
                };
            }

            if (!Enum.IsDefined(typeof(OpcaoEnum), opcao2Format))
            {
                await _logRepository.InsertLog(opcao1, opcao2, $"A opçao '{opcao2}' não é válida.");
                return new QueryResult<string>
                {
                    Succeeded = false,
                    Message = $"A opçao '{opcao2}' não é válida."
                };
            }

            if (opcao1Format.Equals(opcao2Format))
            {
                return new QueryResult<string>
                {
                    Succeeded = true,
                    Result = "Empate."
                };
            }

            var response = await _jokenpoNerdRepository.GetWinner((int)Enum.Parse(typeof(OpcaoEnum), opcao1Format), (int)Enum.Parse(typeof(OpcaoEnum), opcao2Format));
            return new QueryResult<string>
            {
                Succeeded = true,
                Result = response.Descricao
            };
        }
    }
}
