using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIRE_API._2___Domain.Entities
{
    [Table("TB_RELATORIO")]
    public class Relatorio
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("TITULO")]
        public string? Titulo { get; set; }

        [Column("DESCRICAO")]
        public string? Descricao { get; set; }

        [Column("DATAGERACAO")]
        public DateTime DataGeracao { get; set; }
    }
}
