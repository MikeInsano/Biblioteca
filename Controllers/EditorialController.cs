using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBolonMiguel.Controllers
{
    public class EditorialController : Controller
    {
        private readonly IEditorialServices _editorialServices;
        public EditorialController(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;
        }
        public IActionResult Index()
        {
            var editorial = _editorialServices.ObtenerEditorial();
            return View(editorial);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Editorial request)
        {
            _editorialServices.CrearEditorial(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editoril = _editorialServices.GetEditorialById(id);
            if (editoril == null)
            {
                return NotFound();
            }
            return View(editoril);
        }

        [HttpPost]
        public IActionResult Edit(Editorial request)
        {
            var result = _editorialServices.UpdateEditorial(request);
            if(!result) 
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _editorialServices.GetEditorialById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _editorialServices.DeleteEditorial(id);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
