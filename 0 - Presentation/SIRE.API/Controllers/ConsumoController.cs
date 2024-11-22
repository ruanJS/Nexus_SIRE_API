using Microsoft.AspNetCore.Mvc;
using SIRE_API._1___Application.Services;
using SIRE_API._1___Application.DTOs;

namespace SIRE_API._0___Presentation.SIRE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumoController(ConsumoService consumoService) : ControllerBase
    {
        private readonly ConsumoService _consumoService = consumoService;

        // Método GET para obter todos os consumos
        [HttpGet]
        public IActionResult GetConsumos()
        {
            var consumos = _consumoService.GetAllConsumos();
            return Ok(consumos);
        }

        // Método POST para adicionar um novo consumo
        [HttpPost]
        public IActionResult AddConsumo([FromBody] ConsumoDTO consumoDTO)
        {
            _ = _consumoService.AddConsumo(consumoDTO);
            return CreatedAtAction(nameof(GetConsumos), new { id = consumoDTO.Id }, consumoDTO);
        }

    }
}
