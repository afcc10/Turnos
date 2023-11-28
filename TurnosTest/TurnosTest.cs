using Business.Contract;
using Business.Implement;
using Common.Utilities.Services;
using Crud_sqlLite.Controllers;
using DataAccess.Core.Implements;
using Microsoft.Extensions.Configuration;
using Models.Models;
using Moq;

namespace TurnosTest
{
    public class TurnosTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        public static IConfiguration Configuration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .Build();

            return config;
        }

        [Test]
        public void CrearTurnosSucces()
        {
            Mock<ITurnosServices> mock = new Mock<ITurnosServices>();
            mock.Setup(x => x.CrearTurno(new TurnosDto(), "Conection")).ReturnsAsync(new Response<bool>()
                                                                                        {
                                                                                            Status = true
                                                                                        });

            TurnosController turnosController = new(new TurnosServices(new TurnosRepository()), Configuration());

            Task<Response<bool>> response = turnosController.CrearTurno(new TurnosDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, IdServicio = 1});
            
            Assert.True(response.Result.Status);
        }
    }
}