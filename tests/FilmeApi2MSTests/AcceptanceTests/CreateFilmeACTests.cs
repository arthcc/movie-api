using FilmeApi2.Dtos;
using FilmeApi2.Data;
using FilmeApi2.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;
using System;

namespace FilmeApi2MSTests.AcceptanceTests
{
    [TestClass]
    public class CreateFilmeACTests
    {

        [TestMethod]
        private IMapper GetAutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateFilmeDto, Filme>();
            });

            return config.CreateMapper();
        }

        [TestMethod]
        public void CreateFilme_ShouldReturnSuccess_WhenMovieIsCreated()
        {
            // Arrange
            var filmeDto = new CreateFilmeDto { Titulo = "Test Movie", Genero = "Action", Duracao = 120, Elenco = "Test Cast" };
            var mapper = GetAutoMapperConfiguration();
            var context = new Mock<IFilmeContext>();

            context.Setup(c => c.Filmes.Add(It.IsAny<Filme>()));
            context.Setup(c => c.SaveChanges());

            var service = new FilmeService(mapper, context.Object);

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
            var filmeDto = new CreateFilmeDto { Titulo = "Test Movie", Genero = "Action", Duracao = 120, Elenco = "Test Cast" };
            var mapper = GetAutoMapperConfiguration();
            var context = new Mock<IFilmeContext>();

            context.Setup(c => c.Filmes.Add(It.IsAny<Filme>())).Throws(new Exception("Test exception"));
            context.Setup(c => c.SaveChanges());

            var service = new FilmeService(mapper, context.Object);

            // Act
            var result = service.CreateFilme(filmeDto);

            // Assert
            Assert.IsFalse(result.StatusCode == 200);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Test exception", result.Message);
        }
    }
}
