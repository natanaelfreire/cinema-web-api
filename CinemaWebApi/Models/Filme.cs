using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebApi.Models
{
    [Table("filme")]
    public class Filme
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("diretor")]
        public string Diretor { get; set; }

        [Column("duracao_minutos")]
        public int DuracaoMinutos { get; set; }
    }
}
