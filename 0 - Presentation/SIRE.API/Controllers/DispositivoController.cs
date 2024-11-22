using Microsoft.AspNetCore.Mvc;
using SIRE_API._1___Application.DTOs;
using SIRE_API._1___Application.Services;
using SIRE_API._2___Domain.Entities;

namespace SIRE_API._0___Presentation.SIRE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController(DispositivoService dispositivoService) : ControllerBase
    {
        private readonly DispositivoService _dispositivoService = dispositivoService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispositivos = await _dispositivoService.GetDispositivo();
            return Ok(dispositivos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DispositivoDTO dispositivo)
        {
            await _dispositivoService.AddDispositivo(new Dispositivo
            {
                Nome = dispositivo.Nome,
                Tipo = dispositivo.Tipo,
                Serial = dispositivo.Serial,
                DataCadastro = dispositivo.DataCadastro
            });

            return CreatedAtAction(nameof(GetAll), null);
        }
    }
}
