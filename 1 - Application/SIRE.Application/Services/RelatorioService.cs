using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIRE_API._1___Application.Services
{
    public class RelatorioService(IRelatorioRepository relatorioRepository)
    {
        private readonly IRelatorioRepository _relatorioRepository = relatorioRepository;

        public async Task<IEnumerable<Relatorio>> GetAllRelatoriosAsync()
        {
            return await _relatorioRepository.GetAllAsync();
        }

        public async Task<Relatorio> GetRelatorioByIdAsync(int id)
        {
            return await _relatorioRepository.GetByIdAsync(id);
        }

        public async Task AddRelatorioAsync(Relatorio relatorio)
        {
            await _relatorioRepository.AddAsync(relatorio);
        }
    }
}
