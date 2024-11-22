using SIRE_API._2___Domain.Interfaces;
using SIRE_API._2___Domain.Entities;
using SIRE_API._3___Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SIRE_API._3___Infrastructure.Repositories
{
    public class ConsumoRepository(ApplicationDbContext context) : IConsumoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public IEnumerable<Consumo> GetAll()
        {
            return [.. _context.Consumos];
        }

        public async Task<IEnumerable<Consumo>> GetAllAsync()
        {
            return await _context.Consumos.ToListAsync(); // Certifique-se de que "Consumos" seja o nome correto do DbSet.
        }

        public void Add(Consumo consumo)
        {
            _context.Consumos.Add(consumo);
            _context.SaveChanges();
        }

        public async Task AddAsync(Consumo consumo)
        {
            await _context.Consumos.AddAsync(consumo);
            await _context.SaveChangesAsync();
        }
    }
}
