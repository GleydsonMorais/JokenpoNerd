using JokenpoNerd.Data.Context;
using JokenpoNerd.Data.Models.Logs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JokenpoNerd.Data.Repositories.Logs
{
    public interface ILogRepository
    {
        Task InsertLog(string opcao1, string opcao2, string mensagem);
    }

    public class LogRepository : ILogRepository
    {
        private readonly JokenpoNerdContext _dataContext;

        public LogRepository(JokenpoNerdContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task InsertLog(string opcao1, string opcao2, string mensagem)
        {
            await _dataContext.AddAsync(
            new Log()
            {
                Opcao1 = opcao1,
                Opcao2 = opcao2,
                Mensagem = mensagem,
                DtInclusao = DateTime.Now
            });
            await _dataContext.SaveChangesAsync();
        }
    }
}
