using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBolonMiguel.Services.Services
{
    public class LibroServices : ILibroServices
    {
        private readonly ApplicationDbContext _context;
        private readonly Cloudinary _cloudinary;

        public LibroServices(ApplicationDbContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        public async Task CrearLibro(Libro libro)
        {
            string logPath = "log.txt"; // Archivo donde se guardarán los mensajes

            try
            {
                File.AppendAllText(logPath, "Entró al método CrearLibro\n");

                // Depuración: Verifica los datos del libro
                File.AppendAllText(logPath, $"Datos del libro: Titulo={libro.Titulo}, PkAutor={libro.PkAutor}, PkEditorial={libro.PkEditorial}, PkGenero={libro.PkGenero}\n");

                _context.Libros.Add(libro);
                var cambios = await _context.SaveChangesAsync();

                File.AppendAllText(logPath, $"Cambios guardados: {cambios}\n");

                if (cambios == 0)
                {
                    File.AppendAllText(logPath, "⚠ No se guardaron cambios en la base de datos.\n");
                }
                else
                {
                    File.AppendAllText(logPath, "✅ Libro guardado con éxito.\n");
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(logPath, $"❌ Error al guardar el libro: {ex.Message}\n");
                throw;
            }
        }   


        public async Task<ImageUploadResult?> UploadImageToCloudinary(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "libros"
            };

            return await _cloudinary.UploadAsync(uploadParams);
        }

        public async Task<IEnumerable<Libro>> ObtenerLibros()
        {
            return await _context.Libros
                .Include(l => l.Autor)       // Cargar el autor
                .Include(l => l.Editorial)   // Cargar la editorial
                .Include(l => l.Genero)      // Cargar el género
                .ToListAsync();
        }

        public async Task ActualizarLibros(Libro libro)
        {
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if(libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }

        public List<Autor> GetAutores()
        {
            return _context.Autores.ToList();
        }
        public List<Editorial> GetEditorial()
        {
            return _context.Editorials.ToList();
        }
        public List<Genero> GetGeneros()
        {
            return _context.Generos.ToList();
        }
    }
}
