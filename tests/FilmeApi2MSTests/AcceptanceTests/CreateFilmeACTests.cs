using FilmeApi2.Dtos;
using FilmeApi2.Data;
using FilmeApi2.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;
using System;

namespace FilmeApi2MSTests.AcceptanceTests
{
    /// <summary>
    /// Essa classe de testes, representa a ideia do "Teste de Aceitação".
    /// Os testes de aceitação são testes que simulam o comportamento do usuário final.
    /// Então a ideia não é só testar uma unidade de código, e sim o comportamento do sistema como um todo.
    /// Eles são mais lentos que os testes unitários, mas são mais confiáveis.
    /// E fazem parte do ciclo de desenvolvimento de software.
    /// </summary>
    [TestClass]
    public class CreateFilmeACTests
    {

        [TestMethod]
        private IMapper GetAutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateMovie, Movie>();
            });

            return config.CreateMapper();
        }

        [TestMethod]
        public void CreateFilme_ShouldReturnSuccess_WhenMovieIsCreated()
        {
            // Arrange
            var filmeDto = new CreateMovie { Titulo = "Test Movie", Genero = "Action", Duracao = 120, Elenco = "Test Cast" };
            var mapper = GetAutoMapperConfiguration();
            var context = new Mock<IMovieContext>();

            context.Setup(c => c.Filmes.Add(It.IsAny<Movie>()));
            context.Setup(c => c.SaveChanges());

            var service = new MovieService(mapper, context.Object);

            // Act
            var result = service.CreateFilme(filmeDto);

            // Assert
            Assert.IsTrue(result.StatusCode == 200);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(filmeDto, result.Data);
        }

        [TestMethod]
        public void CreateFilme_ShouldReturnError_WhenExceptionOccurs()
        {
            // Arrange
            var filmeDto = new CreateMovie { Titulo = "Test Movie", Genero = "Action", Duracao = 120, Elenco = "Test Cast" };
            var mapper = GetAutoMapperConfiguration();
            var context = new Mock<IMovieContext>();

            context.Setup(c => c.Filmes.Add(It.IsAny<Movie>())).Throws(new Exception("Test exception"));
            context.Setup(c => c.SaveChanges());

            var service = new MovieService(mapper, context.Object);

            // Act
            var result = service.CreateFilme(filmeDto);

            // Assert
            Assert.IsFalse(result.StatusCode == 200);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Test exception", result.Message);
        }
    }
}
