using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIRE_API._2___Domain.Entities
{
    public class Consumo
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; internal set; }
    }
}

