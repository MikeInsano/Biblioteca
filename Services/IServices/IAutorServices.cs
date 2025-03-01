using BibliotecaBolonMiguel.Models.Domain;
using CloudinaryDotNet.Actions;

namespace BibliotecaBolonMiguel.Services.IServices
{
    public interface IAutorServices
    {
        public Task CrearAutor(Autor autor);
        public Task<ImageUploadResult?> UploadImageToCloudinary(IFormFile file);
        public Task<IEnumerable<Autor>> ObtenerAutores();
        public Task ActualizarAutor(Autor autor);
        public Task EliminarAutor(int id);
    }
}
