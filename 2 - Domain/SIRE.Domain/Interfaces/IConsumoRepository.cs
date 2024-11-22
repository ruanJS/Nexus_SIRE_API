using SIRE_API._2___Domain.Entities;
using System.Collections.Generic;

namespace SIRE_API._2___Domain.Interfaces
{
    public interface IConsumoRepository
    {
        IEnumerable<Consumo> GetAll(); // Síncrono
        Task<IEnumerable<Consumo>> GetAllAsync(); // Assíncrono
        void Add(Consumo consumo); // Síncrono
        Task AddAsync(Consumo consumo); // Assíncrono
    }
}

