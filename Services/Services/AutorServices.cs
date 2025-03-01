using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBolonMiguel.Services.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDbContext _context;
        private readonly Cloudinary _cloudinary;

        public AutorServices(ApplicationDbContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        public async Task CrearAutor(Autor autor)
        {
            try
            {
                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
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
                Folder = "autores"
            };

            return await _cloudinary.UploadAsync(uploadParams);
        }

        public async Task<IEnumerable<Autor>> ObtenerAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task ActualizarAutor(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
