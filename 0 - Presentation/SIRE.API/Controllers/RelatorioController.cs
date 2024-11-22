using Microsoft.AspNetCore.Mvc;
using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIRE_API._1___Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController(IRelatorioRepository relatorioRepository) : ControllerBase
    {
        private readonly IRelatorioRepository _relatorioRepository = relatorioRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllRelatoriosAsync()
        {
            var relatorios = await _relatorioRepository.GetAllAsync();
            return Ok(relatorios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelatorio(int id)
        {
            try
            {
                var relatorio = await _relatorioRepository.GetByIdAsync(id);
                return Ok(relatorio);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRelatorio([FromBody] Relatorio relatorio)
        {
            await _relatorioRepository.AddAsync(relatorio);
            return CreatedAtAction(nameof(GetRelatorio), new { id = relatorio.Id }, relatorio);
        }
    }
}
