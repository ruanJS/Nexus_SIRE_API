using SIRE_API._1___Application.DTOs;
using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIRE_API._1___Application.Services
{
    public class DispositivoService(IDispositivoRepository dispositivoRepository)
    {
        private readonly IDispositivoRepository _dispositivoRepository = dispositivoRepository;

        // Método assíncrono para obter todos os dispositivos
        public async Task<List<DispositivoDTO>> GetDispositivo()
        {
            var dispositivos = await _dispositivoRepository.GetAllAsync();
            var dispositivoDTOs = new List<DispositivoDTO>();

            foreach (var dispositivo in dispositivos)
            {
                dispositivoDTOs.Add(new DispositivoDTO
                {
                    Id = dispositivo.Id,
                    Nome = dispositivo.Nome,
                    Tipo = dispositivo.Tipo,
                    Serial = dispositivo.Serial,
                    DataCadastro = dispositivo.DataCadastro
                });
            }
            return dispositivoDTOs;
        }

        // Método assíncrono para adicionar um dispositivo
        public async Task AddDispositivo(Dispositivo dispositivo)
        {
            await _dispositivoRepository.AddAsync(dispositivo);
        }

        internal object GetAllDispositivos()
        {
            throw new NotImplementedException();
        }

        internal void AddDispositivo(DispositivoDTO dispositivoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
