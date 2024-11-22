using Microsoft.AspNetCore.Mvc;
using SIRE_API.Data;
using System.Threading.Tasks;

namespace SIRE_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectionTestController(DatabaseConnectionTester connectionTester) : ControllerBase
    {
        private readonly DatabaseConnectionTester _connectionTester = connectionTester;

        [HttpGet("test")]
        public async Task<IActionResult> TestConnection()
        {
            await _connectionTester.TestConnectionAsync();
            return Ok("Teste de conexão concluído. Verifique os logs para mais detalhes.");
        }
    }
}
