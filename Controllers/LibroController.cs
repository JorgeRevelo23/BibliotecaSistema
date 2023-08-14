using BiblioMundo.DatosDB;
using BiblioMundo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblioMundo.Controllers
{
    public class LibroController : Controller
    {
        private BibliotecaContext _context;

        public LibroController(BibliotecaContext context)
        {
            _context = context;
        }
        // GET: Libro
        public async Task<IActionResult> Index()
        {
            var libros = await _context.Libros.Include(l => l.Autor).Include(l => l.Categoria).Include(l => l.Editorial).ToListAsync();
            return View(libros);
        }

        // GET: Libro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.Include(l => l.Autor).Include(l => l.Categoria).Include(l => l.Editorial).FirstOrDefaultAsync(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libro/Create
        public IActionResult Create()
        {
            ViewBag.Autores = _context.Autores.ToList();
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Editoriales = _context.Editoriales.ToList();

            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,AutorId,CategoriaId,EditorialId,Ubicacion,Ejemplares,Estado")] LibroModel libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Autores = _context.Autores.ToList();
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Editoriales = _context.Editoriales.ToList();

            return View(libro);
        }

        // GET: Libro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            ViewBag.Autores = _context.Autores.ToList();
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Editoriales = _context.Editoriales.ToList();

            return View(libro);
        }

        // POST: Libro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AutorId,CategoriaId,EditorialId,Ubicacion,Ejemplares,Estado")] LibroModel libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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

            ViewBag.Autores = _context.Autores.ToList();
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Editoriales = _context.Editoriales.ToList();

            return View(libro);
        }

        // GET: Libro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.Include(l => l.Autor).Include(l => l.Categoria).Include(l => l.Editorial).FirstOrDefaultAsync(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
