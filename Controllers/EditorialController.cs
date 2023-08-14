using BiblioMundo.DatosDB;
using BiblioMundo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblioMundo.Controllers
{
    public class EditorialController : Controller
    {
        private BibliotecaContext _context;

        public EditorialController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Editorial
        public async Task<IActionResult> Index()
        {
            var editoriales = await _context.Editoriales.ToListAsync();
            return View(editoriales);
        }

        // GET: Editorial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editoriales.FirstOrDefaultAsync(e => e.Id == id);

            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        // GET: Editorial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editorial/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] EditorialModel editorial)
        {
            if (ModelState.IsValid)
            {
                _context.Editoriales.Add(editorial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(editorial);
        }

        // GET: Editorial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editoriales.FindAsync(id);

            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        // POST: Editorial/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] EditorialModel editorial)
        {
            if (id != editorial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialExists(editorial.Id))
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

            return View(editorial);
        }

        // GET: Editorial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editoriales.FirstOrDefaultAsync(e => e.Id == id);

            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        // POST: Editorial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editorial = await _context.Editoriales.FindAsync(id);
            _context.Editoriales.Remove(editorial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialExists(int id)
        {
            return _context.Editoriales.Any(e => e.Id == id);
        }
    }
}
