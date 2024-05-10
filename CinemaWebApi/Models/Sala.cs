using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebApi.Models
{
    [Table("sala")]
    public class Sala
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("numero_sala")]
        public int NumeroSala { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
