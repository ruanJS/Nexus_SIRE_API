using SIRE_API._2___Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIRE_API._2___Domain.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<IEnumerable<Relatorio>> GetAllAsync();
        Task<Relatorio?> GetByIdAsync(int id);
        Task AddAsync(Relatorio relatorio);
    }
}
