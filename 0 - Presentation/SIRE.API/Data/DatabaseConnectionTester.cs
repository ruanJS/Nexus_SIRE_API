using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Threading.Tasks;

namespace SIRE_API.Data
{
    public class DatabaseConnectionTester(string connectionString, ILogger<DatabaseConnectionTester> logger)
    {
        private readonly string _connectionString = connectionString;
        private readonly ILogger<DatabaseConnectionTester> _logger = logger;

        public async Task TestConnectionAsync()
        {
            _logger.LogInformation("Iniciando teste de conexão com o banco de dados...");

            try
            {
                using var connection = new OracleConnection(_connectionString);
                _logger.LogInformation("Tentando abrir a conexão...");
                await connection.OpenAsync();
                _logger.LogInformation("Conexão bem-sucedida com o banco de dados!");
            }
            catch (OracleException ex)
            {
                _logger.LogError("Erro de conexão com o banco de dados.");
                _logger.LogError("Código do Erro: {ErrorCode}", ex.ErrorCode);
                _logger.LogError("Mensagem: {Message}", ex.Message);
                _logger.LogError("StackTrace: {StackTrace}", ex.StackTrace);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro inesperado ao testar a conexão.");
                _logger.LogError("Mensagem: {Message}", ex.Message);
                _logger.LogError("StackTrace: {StackTrace}", ex.StackTrace);
            }
            finally
            {
                _logger.LogInformation("Finalizando teste de conexão.");
            }
        }
    }
}
