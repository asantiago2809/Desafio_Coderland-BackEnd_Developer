using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaBackend.API.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Clase Controlador con el nombre solicitado en la prueba para obtener todas las marcas
    public class MarcasAutosController : ControllerBase
    {
        // Variable protegida para conexion a la bd postgres
        private readonly Data.DbContext _context;

        public MarcasAutosController(Data.DbContext context)
        {
            _context = context;
        }

        // endpoint para obtener todas las marcas de autos desde la base de datos.
        [HttpGet]
        public async Task<IActionResult> GetMarcasAutos()
        {
            var marcas = await _context.MarcasAutos.ToListAsync();
            return Ok(marcas);
        }
    }
}
