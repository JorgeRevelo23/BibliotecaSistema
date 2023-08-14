using BiblioMundo.DatosDB;
using BiblioMundo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblioMundo.Controllers
{
    public class PrestamoController : Controller
    {
        private BibliotecaContext _context;

        public PrestamoController(BibliotecaContext context)
        {
            _context = context;
        }

        // Acción para mostrar la vista de consulta de préstamos
        public async Task<IActionResult> Index()
        {
            var prestamos = await _context.Prestamos
                .Include(p => p.EstadoPrestamo)
                .Include(p => p.Persona)
                .Include(p => p.Libro)
                .ToListAsync();

            return View(prestamos);
        }

        // Acción para mostrar detalles de un préstamo específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.EstadoPrestamo)
                .Include(p => p.Persona)
                .Include(p => p.Libro)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // Acción para mostrar el formulario de creación de préstamo
        public IActionResult Create()
        {
            ViewBag.EstadoPrestamo = _context.EstadoPrestamo.ToList();
            ViewBag.Personas = _context.Personas.ToList();
            ViewBag.Libros = _context.Libros.ToList();

            return View();
        }

        // Acción para procesar el formulario de creación de préstamo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EstadoPrestamoId,PersonaId,LibroId,FechaDevolucion,TextoFechaDevolucion,FechaConfirmacionDevolucion,TextoFechaConfirmacionDevolucion,EstadoEntregado,EstadoRecibido,Estado")] PrestamoModel prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.EstadoPrestamo = _context.EstadoPrestamo.ToList();
            ViewBag.Personas = _context.Personas.ToList();
            ViewBag.Libros = _context.Libros.ToList();

            return View(prestamo);
        }

        // Acción para mostrar el formulario de edición de préstamo
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            ViewBag.EstadoPrestamo = _context.EstadoPrestamo.ToList();
            ViewBag.Personas = _context.Personas.ToList();
            ViewBag.Libros = _context.Libros.ToList();

            return View(prestamo);
        }

        // Acción para procesar el formulario de edición de préstamo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstadoPrestamoId,PersonaId,LibroId,FechaDevolucion,TextoFechaDevolucion,FechaConfirmacionDevolucion,TextoFechaConfirmacionDevolucion,EstadoEntregado,EstadoRecibido,Estado")] PrestamoModel prestamo)
        {
            if (id != prestamo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.EstadoPrestamo = _context.EstadoPrestamo.ToList();
            ViewBag.Personas = _context.Personas.ToList();
            ViewBag.Libros = _context.Libros.ToList();

            return View(prestamo);
        }

        // Acción para mostrar el formulario de eliminación de préstamo
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.EstadoPrestamo)
                .Include(p => p.Persona)
                .Include(p => p.Libro)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // Acción para procesar la eliminación de préstamo
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar para verificar si un préstamo existe por su ID
        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.Id == id);
        }
    }
}
