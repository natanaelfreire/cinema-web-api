using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebApi.Models
{
    [Table("filme_exibido_sala")]
    public class FilmeExibidoSala
    {
        [Column("id")]
        public int Id { get; set; }

        public Sala Sala { get; set; }

        [Column("id_sala")]
        public int SalaId { get; set; }

        public Filme Filme { get; set; }

        [Column("id_filme")]
        public int FilmeId { get; set; }

        [Column("horario")]
        public DateTime Horario { get; set; }
    }
}
