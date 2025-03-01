using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;

namespace BibliotecaBolonMiguel.Services.Services
{
    public class GeneroServices : IGeneroServices
    {
        private readonly ApplicationDbContext _context;

        public GeneroServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Genero> ObtenerGeneros()
        {
            return _context.Generos.ToList();
        }
        public Genero GetGeneroById(int id)
        {
            return _context.Generos.Find(id);
        }
        public bool CrearGenero(Genero request)
        {
            _context.Generos.Add(request);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateGenero(Genero request)
        {
            var genero = _context.Generos.Find(request.PkGenero);
            if (genero == null)
            {
                return false;
            }
            genero.Nombre = request.Nombre;
            _context.Generos.Update(genero);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteGenero(int id)
        {
            var genero = _context.Generos.Find(id);
            if (genero == null)
            {
                return false;
            }
            _context.Generos.Remove(genero);
            return _context.SaveChanges() > 0;
        }
    }
}
