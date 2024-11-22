using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIRE_API._3___Infrastructure.Data;

namespace SIRE_API._3___Infrastructure.Repositories
{
    public class RelatorioRepository(ApplicationDbContext context) : IRelatorioRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Relatorio>> GetAllAsync()
        {
            return await _context.Relatorios.ToListAsync();
        }

        public async Task<Relatorio> GetByIdAsync(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            return relatorio switch
            {
                null => throw new KeyNotFoundException($"Relatório com ID {id} não foi encontrado."),
                _ => relatorio,
            };
        }

        public async Task AddAsync(Relatorio relatorio)
        {
            await _context.Relatorios.AddAsync(relatorio);
            await _context.SaveChangesAsync();
        }
    }
}
