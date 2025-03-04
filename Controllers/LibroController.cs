using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using BibliotecaBolonMiguel.Services.Services;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaBolonMiguel.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroServices _libroServices;
        private readonly Cloudinary _cloudinary;
        private readonly ApplicationDbContext _context;

        public LibroController(ILibroServices libroServices, Cloudinary cloudinary, ApplicationDbContext context)
        {
            _libroServices = libroServices;
            _cloudinary = cloudinary;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var libro = await _libroServices.ObtenerLibros();
            return View(libro);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Autores = new SelectList(_libroServices.GetAutores(), "PkAutor", "Nombre");
            ViewBag.Editorial = new SelectList(_libroServices.GetEditorial(), "PkEditorial", "Nombre");
            ViewBag.Generos = new SelectList(_libroServices.GetGeneros(), "PkGenero", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Libro libro, IFormFile? foto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Autores = new SelectList(_context.Autores, "Id", "Nombre");
                ViewBag.Editorial = new SelectList(_context.Editorials, "Id", "Nombre");
                ViewBag.Generos = new SelectList(_context.Generos, "Id", "Nombre");
                return View(libro);
            }

            // Verificar si se subió una imagen
            if (foto != null && foto.Length > 0)
            {
                var uploadResult = await _libroServices.UploadImageToCloudinary(foto);
                if (uploadResult != null)
                {
                    libro.FotoUrl = uploadResult.SecureUrl.ToString();
                }
            }

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Libro guardado con éxito";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var libros = await _libroServices.ObtenerLibros();
            if (libros == null || !libros.Any())
            {
                return NotFound(); // Evita que se intente acceder a un null
            }
            var libroSeleccionado = libros.FirstOrDefault(a => a.PkLibro == id);
            if (libroSeleccionado == null) return NotFound();

            return View(libroSeleccionado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Libro libro, IFormFile? foto)
        {
            if (!ModelState.IsValid) return View(libro);

            if (foto != null && foto.Length > 0)
            {
                var uploadResult = await _libroServices.UploadImageToCloudinary(foto);
                if (uploadResult != null)
                {
                    libro.FotoUrl = uploadResult.SecureUrl.ToString();
                }
            }

            await _libroServices.ActualizarLibros(libro);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _libroServices.EliminarLibro(id);
            return Json(new { success = true });
        }
    }
}
