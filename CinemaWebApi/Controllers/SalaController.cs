using CinemaWebApi.DTOs;
using CinemaWebApi.Models;
using CinemaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;

        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = await _salaService.GetById(id);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery(Name = "page")] int? page, [FromQuery(Name = "size")] int? size)
        {
            try
            {
                var response = await _salaService.GetAll(page, size);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SalaDTO dto)
        {
            try
            {
                await _salaService.Create(dto);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _salaService.Delete(id);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] SalaDTO dto)
        {
            try
            {
                await _salaService.Update(dto);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{salaId}/AdicionaFilme/{filmeId}")]
        public async Task<ActionResult> AdicionaFilmeSala([FromRoute] int salaId, [FromRoute] int filmeId, [FromBody] DateTime horario)
        {
            try
            {
                await _salaService.AdicionarFilmeSala(salaId, filmeId, horario);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoverFilmeSala/{filmeSalaId}")]
        public async Task<ActionResult> RemoverFilmeSala(int filmeSalaId)
        {
            try
            {
                await _salaService.RemoverFilmeSala(filmeSalaId);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{salaId}/FilmesExibidos")]
        public async Task<ActionResult> FilmesExibidosSala(int salaId)
        {
            try
            {
                var lista = await _salaService.ListarFilmesExibidosPorSala(salaId);

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FilmesEmCartaz/{dia}")]
        public async Task<ActionResult> FilmesEmCartaz([FromRoute] DateTime dia)
        {
            try
            {
                var lista = await _salaService.FilmesEmCartaz(dia);

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
