using BiblioMundo.DatosDB;
using BiblioMundo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiblioMundo.Controllers
{
    public class AccountController : Controller
    {
        private BibliotecaContext _context;

        public AccountController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        //METODO PARA QUE MUESTRE EL FORMULARIO DE LOGIN
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PersonaModel persona)
        {
            if (!String.IsNullOrEmpty(persona.Correo.ToString()) && (!String.IsNullOrEmpty(persona.Clave.ToString())))
            {
                var cor = _context.Personas.SingleOrDefault(c =>
                c.Correo == persona.Correo
                &&
                c.Clave == persona.Clave
                );
                if (cor != null)
                {
                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    ViewBag.AlertMessage = "No se encuentra la persona ingresada";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
