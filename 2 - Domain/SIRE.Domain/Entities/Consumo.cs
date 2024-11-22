using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIRE_API._2___Domain.Entities
{
    [Table("TB_CONSUMOS")]
    public class Consumo
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("VALOR")]
        public double Valor { get; set; }

        [Column("DATACADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("DATA")]
        public DateTime Data { get; set; }

        [Column("NOME")]
        public string Nome { get; internal set; }
    }
}

