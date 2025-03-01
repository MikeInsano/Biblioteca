using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBolonMiguel.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        public IActionResult Index()
        {
            var roles = _rolServices.ObtenerRoles();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Rol request)
        {
            _rolServices.CrearRol(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rol = _rolServices.GetRolById(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpPost]
        public IActionResult Edit(Rol request)
        {
            var result = _rolServices.UpdateRol(request);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var rol = _rolServices.GetRolById(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpGet]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _rolServices.DeleteRol(id);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
