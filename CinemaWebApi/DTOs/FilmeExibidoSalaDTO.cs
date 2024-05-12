using CinemaWebApi.Models;

namespace CinemaWebApi.DTOs
{
    public class FilmeExibidoSalaDTO
    {
        public int Id { get; set; }

        public Sala Sala { get; set; }

        public int SalaId { get; set; }

        public Filme Filme { get; set; }

        public int FilmeId { get; set; }

        public DateTime Horario { get; set; }
    }
}
