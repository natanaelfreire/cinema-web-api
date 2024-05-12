using CinemaWebApi.Db;
using CinemaWebApi.DTOs;
using CinemaWebApi.Models;
using CinemaWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApi.Services.Implementations
{
    public class SalaService : ISalaService
    {
        private readonly Context _context;

        public SalaService(Context context)
        {
            _context = context;
        }

        public async Task AdicionarFilmeSala(int salaId, int filmeId, DateTime horario)
        {
            var filmeExibidoSala = new FilmeExibidoSala();

            filmeExibidoSala.SalaId = salaId;
            filmeExibidoSala.FilmeId = filmeId;
            filmeExibidoSala.Horario = horario;

            _context.FilmesExibidoSalas.Add(filmeExibidoSala);
            await _context.SaveChangesAsync();
        }

        public async Task Create(SalaDTO salaDTO)
        {
            var sala = new Sala();
            sala.Descricao = salaDTO.Descricao;
            sala.NumeroSala = salaDTO.NumeroSala;

            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var sala = await _context.Salas.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (sala == null)
                throw new Exception("Sala não encontrada");

            _context.Salas.Remove(sala);

            await _context.SaveChangesAsync();
        }

        public async Task<List<FilmeExibidoSalaDTO>> FilmesEmCartaz(DateTime dia)
        {
            var filmesSalas = await _context.FilmesExibidoSalas.Where(x => x.Horario.Date == dia.Date).ToListAsync();

            return filmesSalas.Select(x => new FilmeExibidoSalaDTO
                {
                    Id = x.Id,
                    Horario = x.Horario,
                    Filme = x.Filme,
                    FilmeId = x.FilmeId,
                    Sala = x.Sala,
                    SalaId = x.SalaId,
                })
                .ToList();
        }

        public async Task<List<SalaDTO>> GetAll(int? page = 0, int? size = 10)
        {
            int takes = size ?? 10;
            int skips = page != null ? (int)page * takes : 0;
            var salas = await _context.Salas.Skip(skips).Take(takes).ToListAsync();

            return salas.Select(x => new SalaDTO
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    NumeroSala = x.NumeroSala,
                })
                .ToList();
        }

        public async Task<SalaDTO> GetById(int id)
        {
            var sala = await _context.Salas.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (sala == null)
                throw new Exception("Sala não encontrada");

            return new SalaDTO
            {
                Id = sala.Id,
                Descricao = sala.Descricao,
                NumeroSala = sala.NumeroSala,
            };
        }

        public async Task<List<FilmeExibidoSalaDTO>> ListarFilmesExibidosPorSala(int salaId)
        {
            var filmesSalas = await _context.FilmesExibidoSalas.Where(x => x.SalaId == salaId).ToListAsync();

            return filmesSalas.Select(x => new FilmeExibidoSalaDTO
                {
                    Id = x.Id,
                    Horario = x.Horario,
                    Filme = x.Filme,
                    FilmeId = x.FilmeId,
                    Sala = x.Sala,
                    SalaId = x.SalaId,
                })
                .OrderByDescending(x => x.Horario.Date)
                .ToList();
        }

        public async Task RemoverFilmeSala(int filmeSalaId)
        {
            var filmeSala = await _context.FilmesExibidoSalas.Where(x => x.Id == filmeSalaId).FirstOrDefaultAsync();

            if (filmeSala == null)
                throw new Exception("Filme exibição na Sala não encontrado");

            _context.FilmesExibidoSalas.Remove(filmeSala);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SalaDTO salaDTO)
        {
            var sala = await _context.Salas.Where(x => x.Id == salaDTO.Id).FirstOrDefaultAsync();

            if (sala == null)
                throw new Exception("Sala não encontrada");

            sala.Descricao = salaDTO.Descricao;
            sala.NumeroSala = salaDTO.NumeroSala;

            await _context.SaveChangesAsync();
        }
    }
}
