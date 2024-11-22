using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIRE_API._2___Domain.Entities
{
    [Table("TB_DISPOSITIVO")]
    public class Dispositivo
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("TIPO")]
        public string Tipo { get; set; }

        [Column("SERIAL")]
        public string Serial { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
    }
}
