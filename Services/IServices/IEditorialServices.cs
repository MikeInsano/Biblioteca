using BibliotecaBolonMiguel.Models.Domain;

namespace BibliotecaBolonMiguel.Services.IServices
{
    public interface IEditorialServices
    {
        public List<Editorial> ObtenerEditorial();
        public Editorial GetEditorialById(int id);
        public bool CrearEditorial(Editorial request);
        public bool UpdateEditorial(Editorial request);
        public bool DeleteEditorial(int id);
    }
}
