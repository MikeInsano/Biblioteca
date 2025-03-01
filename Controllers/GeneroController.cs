using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBolonMiguel.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroServices _generoServices;
        public GeneroController(IGeneroServices generoServices)
        {
            _generoServices = generoServices;
        }
        public IActionResult Index()
        {
            var generos = _generoServices.ObtenerGeneros();
            return View(generos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Genero request)
        {
            _generoServices.CrearGenero(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var genero = _generoServices.GetGeneroById(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        [HttpPost]
        public IActionResult Edit(Genero request)
        {
            var result = _generoServices.UpdateGenero(request);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var genero = _generoServices.GetGeneroById(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        [HttpGet]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _generoServices.DeleteGenero(id);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
