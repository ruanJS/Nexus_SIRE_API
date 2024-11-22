using SIRE_API._1___Application.DTOs;
using SIRE_API._2___Domain.Interfaces;
using SIRE_API._2___Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIRE_API._1___Application.Services
{
    public class ConsumoService(IConsumoRepository consumoRepository)
    {
        private readonly IConsumoRepository _consumoRepository = consumoRepository;

        // Método para obter todos os consumos, retornando uma lista de DTOs
        public async Task<IEnumerable<ConsumoDTO>> GetAllConsumos()
        {
            // Recupera os dados do repositório e mapeia para DTOs
            var consumos = await _consumoRepository.GetAllAsync();

            return consumos.Select(c => new ConsumoDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Valor = c.Valor,
                Data = c.Data
            }).ToList(); // Materializa a consulta para evitar problemas de serialização.
        }


        // Método para adicionar um Consumo usando o ConsumoDTO
        public async Task AddConsumo(ConsumoDTO consumoDTO)
        {
            var consumo = new Consumo
            {
                Nome = consumoDTO.Nome,
                Valor = consumoDTO.Valor,
                Data = consumoDTO.Data
            };

            await _consumoRepository.AddAsync(consumo);
        }

        internal object? GetConsumo()
        {
            throw new NotImplementedException();
        }

        internal void AddConsumo(Consumo consumo)
        {
            throw new NotImplementedException();
        }
    }
}
