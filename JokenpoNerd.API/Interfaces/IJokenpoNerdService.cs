using JokenpoNerd.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokenpoNerd.API.Interfaces
{
    public interface IJokenpoNerdService
    {
        Task<QueryResult<string>> GetWinner(string opcao1, string opcao2);
    }
}
