using Microsoft.EntityFrameworkCore;
using PruebaBackend.API.Controllers;
using PruebaBackend.API.Models;
using Microsoft.AspNetCore.Mvc;
using DbContext = PruebaBackend.API.Data.DbContext;

namespace PruebaBackend.API.Tests
{
    public class MarcasAutosControllerTests
    {
        [Fact]
        public async Task GetMarcasAutos_ReturnsAllMarcas()
        {
            // Usando el XUnit configuramos el entorno de pruebas y un conteto de base de datos en memoria acorde a lo solicitado en la prueba tecnica usando el InMemory del Entity Framework
            var options = new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new DbContext(options);
            context.MarcasAutos.AddRange(
                new MarcaAuto { Id = 1, Nombre = "Toyota" },
                new MarcaAuto { Id = 2, Nombre = "Ford" },
                new MarcaAuto { Id = 3, Nombre = "BMW" }
            );
            await context.SaveChangesAsync();

            var controller = new MarcasAutosController(context);
            var result = await controller.GetMarcasAutos();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var marcas = Assert.IsType<List<MarcaAuto>>(okResult.Value);
            Assert.Equal(3, marcas.Count);
        }
    }
}
