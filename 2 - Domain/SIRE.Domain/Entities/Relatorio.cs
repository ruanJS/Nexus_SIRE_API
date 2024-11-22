using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIRE_API._2___Domain.Entities
{
    public class Relatorio
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataGeracao { get; set; }
    }
}
