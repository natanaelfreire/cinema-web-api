using CinemaWebApi.Db;
using CinemaWebApi.DTOs;
using CinemaWebApi.Models;
using CinemaWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApi.Services.Implementations
{
    public class FilmeService : IFilmeService
    {
        private readonly Context _context;

        public FilmeService(Context context)
        {
            _context = context;
        }

        public async Task Create(FilmeDTO filmeDTO)
        {
            var filme = new Filme();

            filme.Nome = filmeDTO.Nome;
            filme.Diretor = filmeDTO.Diretor;
            filme.DuracaoMinutos = filmeDTO.DuracaoMinutos;

            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var filme = await _context.Filmes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (filme == null)
                throw new Exception("Filme não encontrado.");

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FilmeDTO>> GetAll(int? page, int? size)
        {
            int takes = size ?? 10;
            int skips = page != null ? (int)page * takes : 0;
            var filmes = await _context.Filmes.Skip(skips).Take(takes).ToListAsync();

            return filmes.Select(x => new FilmeDTO
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Diretor = x.Diretor,
                    DuracaoMinutos= x.DuracaoMinutos,
                })
                .ToList();
        }

        public async Task<FilmeDTO> GetById(int id)
        {
            var filme = await _context.Filmes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (filme == null)
                throw new Exception("Filme não encontrado.");

            return new FilmeDTO
            {
                Id = filme.Id,
                Nome = filme.Nome,
                Diretor = filme.Diretor,
                DuracaoMinutos = filme.DuracaoMinutos,
            };
        }

        public async Task Update(FilmeDTO filmeDTO)
        {
            var filme = await _context.Filmes.Where(x => x.Id == filmeDTO.Id).FirstOrDefaultAsync();

            if (filme == null)
                throw new Exception("Filme não encontrado.");

            filme.Nome = filmeDTO.Nome;
            filme.Diretor = filmeDTO.Diretor;
            filme.DuracaoMinutos = filmeDTO.DuracaoMinutos;

            await _context.SaveChangesAsync();
        }
    }
}
