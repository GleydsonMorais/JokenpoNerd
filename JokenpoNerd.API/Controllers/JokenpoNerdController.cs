using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokenpoNerd.API.Interfaces;
using JokenpoNerd.Data.Models.Logs;
using JokenpoNerd.Data.Repositories.Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokenpoNerd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokenpoNerdController : ControllerBase
    {
        private readonly IJokenpoNerdService _jokenpoNerdService;
        private readonly ILogRepository _logRepository;

        public JokenpoNerdController(IJokenpoNerdService jokenpoNerdService,
            ILogRepository logRepository)
        {
            _jokenpoNerdService = jokenpoNerdService;
            _logRepository = logRepository;
        }

        //GET: api/<JokenpoNerdController>/Opcao1/Opcao2
        [HttpGet("{opcao1}/{opcao2}")]
        public async Task<IActionResult> Get(string opcao1, string opcao2)
        {
            try
            {
                var result = await _jokenpoNerdService.GetWinner(opcao1, opcao2);
                if (result.Succeeded)
                    return Ok(result.Result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                await _logRepository.InsertLog(opcao1, opcao2, ex.Message);
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
