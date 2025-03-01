using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaBolonMiguel.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices) 
        {
            _userServices = userServices;
        }
        public IActionResult Index()
        {
            var result = _userServices.ObtenerUsuario();
            return View(result);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Roles = new SelectList(_userServices.GetRoles(), "PkRol", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario request)
        {
            _userServices.CrearUsuario(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _userServices.GetUserById(id);
            ViewBag.Roles = new SelectList(_userServices.GetRoles(), "PkRol", "Nombre");
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Usuario request)
        {
            var result = _userServices.UpdateUser(request);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _userServices.DeleteUser(id);
            if (!result)
            {
                return Json(new { success = false });
            }
            return Json(new { success = true });
        }
    }
}
