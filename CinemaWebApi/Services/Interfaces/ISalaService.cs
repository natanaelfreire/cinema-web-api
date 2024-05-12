using CinemaWebApi.DTOs;

namespace CinemaWebApi.Services.Interfaces
{
    public interface ISalaService
    {
        Task Create(SalaDTO salaDTO);
        Task<List<SalaDTO>> GetAll(int? page = 0, int? size = 10);
        Task<SalaDTO> GetById(int id);
        Task Update(SalaDTO salaDTO);
        Task Delete(int id);
        Task AdicionarFilmeSala(int salaId, int filmeId, DateTime horario);
        Task RemoverFilmeSala(int filmeSalaId);
        Task<List<FilmeExibidoSalaDTO>> ListarFilmesExibidosPorSala(int salaId);
        Task<List<FilmeExibidoSalaDTO>> FilmesEmCartaz(DateTime dia);
    }
}
