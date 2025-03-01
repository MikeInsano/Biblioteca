using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBolonMiguel.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorServices _autorServices;
        private readonly Cloudinary _cloudinary;

        public AutorController(IAutorServices autorServices, Cloudinary cloudinary)
        {
            _autorServices = autorServices;
            _cloudinary = cloudinary;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Autor autor, IFormFile foto)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }

            // Subir la imagen a Cloudinary 
            if (foto != null && foto.Length > 0)
            {
                var uploadResult = await _autorServices.UploadImageToCloudinary(foto);
                autor.FotoUrl = uploadResult?.SecureUrl.ToString() ?? "/images/default.jpg";
            }
            await _autorServices.CrearAutor(autor);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var autores = await _autorServices.ObtenerAutores();
            return View(autores);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var autor = await _autorServices.ObtenerAutores();
            var autorSeleccionado = autor.FirstOrDefault(a => a.PkAutor == id);
            if (autorSeleccionado == null) return NotFound();

            return View(autorSeleccionado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Autor autor, IFormFile? foto)
        {
            if (!ModelState.IsValid) return View(autor);

            if (foto != null && foto.Length > 0)
            {
                var uploadResult = await _autorServices.UploadImageToCloudinary(foto);
                if (uploadResult != null)
                {
                    autor.FotoUrl = uploadResult.SecureUrl.ToString();
                }
            }

            await _autorServices.ActualizarAutor(autor);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _autorServices.EliminarAutor(id);
            return Json(new { success = true });
        }
    }
}
