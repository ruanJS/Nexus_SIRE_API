using SIRE_API._2___Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIRE_API._2___Domain.Interfaces
{
    public interface IDispositivoRepository
    {
        Task<List<Dispositivo>> GetAllAsync();
        Task<Dispositivo> GetByIdAsync(int id);
        Task AddAsync(Dispositivo dispositivo);
        Task UpdateAsync(Dispositivo dispositivo);
        Task DeleteAsync(int id);
    }
}
