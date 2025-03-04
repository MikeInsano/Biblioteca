using BibliotecaBolonMiguel.Models.Domain;
using CloudinaryDotNet.Actions;

namespace BibliotecaBolonMiguel.Services.IServices
{
    public interface ILibroServices
    {
        public Task CrearLibro(Libro libro);
        public Task<ImageUploadResult?> UploadImageToCloudinary(IFormFile file);
        public Task<IEnumerable<Libro>> ObtenerLibros();
        public Task ActualizarLibros(Libro libro);
        public Task EliminarLibro(int id);
        public List<Autor> GetAutores();
        public List<Editorial> GetEditorial();
        public List<Genero> GetGeneros();
    }
}
