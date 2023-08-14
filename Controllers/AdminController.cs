using BiblioMundo.DatosDB;
using Microsoft.AspNetCore.Mvc;

namespace BiblioMundo.Controllers
{
    public class AdminController : Controller
    {
        private BibliotecaContext _context;

        public AdminController(BibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Otras acciones del controlador ...

        public IActionResult GetDashboardData()
        {
            var cantidadLibros = _context.Libros.Count();
            var cantidadPersonas = _context.Personas.Count();
            var cantidadPrestamos = _context.Prestamos.Count();
            var cantidadPrestamosPendientes = _context.Prestamos.Count(p => p.EstadoPrestamoId == 1);

            var data = new
            {
                CantidadLibros = cantidadLibros,
                CantidadPersonas = cantidadPersonas,
                CantidadPrestamos = cantidadPrestamos,
                CantidadPrestamosPendientes = cantidadPrestamosPendientes
            };

            return Json(data);
        }
    }
}
