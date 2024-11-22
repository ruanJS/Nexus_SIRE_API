using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace SIRE_API._3___Infrastructure.Data
{
    public class DatabaseConnectionManager(IConfiguration configuration) : IDisposable
    {
        private readonly string _connectionString = configuration.GetConnectionString("OracleConnection")
                                ?? throw new InvalidOperationException("A string de conexão 'OracleConnection' não foi encontrada.");
        private OracleConnection? _connection;

        /// <summary>
        /// Abre a conexão com o banco de dados.
        /// </summary>
        public IDbConnection OpenConnection()
        {
            _connection ??= new OracleConnection(_connectionString);

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }

        /// <summary>
        /// Fecha a conexão e libera os recursos.
        /// </summary>
        void IDisposable.Dispose()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }

            // Supressão do finalizador
            GC.SuppressFinalize(this);
        }
    }

}
