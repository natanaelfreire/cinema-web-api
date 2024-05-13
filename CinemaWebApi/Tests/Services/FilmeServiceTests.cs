using CinemaWebApi.DTOs;
using CinemaWebApi.Services.Interfaces;
using FakeItEasy;
using Xunit;

namespace CinemaWebApi.Tests.Services
{
    public class FilmeServiceTests
    {
        private readonly IFilmeService _filmeService;

        public FilmeServiceTests()
        {
            _filmeService = A.Fake<IFilmeService>();
        }

        [Fact]
        public async Task Post_CreateFilme()
        {
            await _filmeService.Create(new FilmeDTO { Diretor = "Nome Diretor", Nome = "Nome Filme", DuracaoMinutos = 120 });

            var exception = await Assert.ThrowsAsync<Exception>(async () => await _filmeService.Create(new FilmeDTO { Diretor = "Nome Diretor", Nome = "", DuracaoMinutos = 120 })) as Exception;

            Assert.Equal("Nome do filme não pode ser vazio", exception.Message);
        }

        [Fact]
        public async Task Get_AllFilmes()
        {
            var filmes = await _filmeService.GetAll();
        }
    }
}
