using Microsoft.EntityFrameworkCore;
using PruebaBackend.API.Models;
using EfDbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace PruebaBackend.API.Data
{
    // Nombre de la clase creado acorde a lo establecido en la prueba tecnica
    public class DbContext : EfDbContext
    {
        public DbSet<MarcaAuto> MarcasAutos { get; set; }

        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data pruebas para cargar la tabla con al menos tres ejemplos de marcas de autos.
            modelBuilder.Entity<MarcaAuto>().HasData(
                new MarcaAuto { Id = 1, Nombre = "Toyota" },
                new MarcaAuto { Id = 2, Nombre = "Ford" },
                new MarcaAuto { Id = 3, Nombre = "BMW" }
            );
        }
    }
}
