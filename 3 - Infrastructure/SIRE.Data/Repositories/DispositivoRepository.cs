using Microsoft.EntityFrameworkCore;
using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using SIRE_API._3___Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIRE_API._3___Infrastructure.Repositories
{
    public class DispositivoRepository(ApplicationDbContext context) : IDispositivoRepository
    {
        private readonly ApplicationDbContext _context = context;

        // Método assíncrono para obter todos os dispositivos
        public async Task<List<Dispositivo>> GetAllAsync()
        {
            return await _context.Dispositivos.ToListAsync();
        }

        // Método assíncrono para obter um dispositivo por ID
        public async Task<Dispositivo> GetByIdAsync(int id)
        {
            var dispositivo = await _context.Dispositivos.FirstOrDefaultAsync(d => d.Id == id);
            return dispositivo ?? throw new KeyNotFoundException($"Dispositivo com o ID {id} não foi encontrado.");
        }


        // Método assíncrono para adicionar um dispositivo
        public async Task AddAsync(Dispositivo dispositivo)
        {
            await _context.Dispositivos.AddAsync(dispositivo);
            await _context.SaveChangesAsync();
        }

        // Método assíncrono para atualizar um dispositivo
        public async Task UpdateAsync(Dispositivo dispositivo)
        {
            _context.Dispositivos.Update(dispositivo);
            await _context.SaveChangesAsync();
        }

        // Método assíncrono para deletar um dispositivo
        public async Task DeleteAsync(int id)
        {
            var dispositivo = await _context.Dispositivos.FirstOrDefaultAsync(d => d.Id == id);
            if (dispositivo != null)
            {
                _context.Dispositivos.Remove(dispositivo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
