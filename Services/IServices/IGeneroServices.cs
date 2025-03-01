using BibliotecaBolonMiguel.Models.Domain;

namespace BibliotecaBolonMiguel.Services.IServices
{
    public interface IGeneroServices
    {
        public List<Genero> ObtenerGeneros();
        public bool CrearGenero(Genero request);
        public Genero GetGeneroById(int id);
        public bool UpdateGenero(Genero request);
        public bool DeleteGenero(int id);
    }
}
