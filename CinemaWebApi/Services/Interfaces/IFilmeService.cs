using CinemaWebApi.DTOs;

namespace CinemaWebApi.Services.Interfaces
{
    public interface IFilmeService
    {
        Task<bool> Create(FilmeDTO filmeDTO);
        Task<List<FilmeDTO>> GetAll(int? page = 0, int? size = 10);
        Task<FilmeDTO> GetById(int id);
        Task Update(FilmeDTO filmeDTO);
        Task Delete(int id);
    }
}
