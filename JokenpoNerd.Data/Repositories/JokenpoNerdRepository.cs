using JokenpoNerd.Data.Context;
using JokenpoNerd.Data.Helpers;
using JokenpoNerd.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokenpoNerd.Data.Repositories
{
    public interface IJokenpoNerdRepository
    {
        Task<Regra> GetWinner(int opcao1, int opcao2);
    }

    public class JokenpoNerdRepository : IJokenpoNerdRepository
    {
        private readonly JokenpoNerdContext _dataContext;

        public JokenpoNerdRepository(JokenpoNerdContext dataContext)
        {
            _dataContext = dataContext;
        } 

        public async Task<Regra> GetWinner(int opcao1, int opcao2) => await _dataContext.Regras
            .Include(x => x.Vencedor)
            .SingleAsync(x => (x.OpcaoId1 == opcao1 && x.OpcaoId2 == opcao2) || (x.OpcaoId1 == opcao2 && x.OpcaoId2 == opcao1));
    }
}
