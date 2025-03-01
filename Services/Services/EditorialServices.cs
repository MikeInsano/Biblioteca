using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;

namespace BibliotecaBolonMiguel.Services.Services
{
    public class EditorialServices : IEditorialServices
    {
        private readonly ApplicationDbContext _context;
        public EditorialServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Editorial> ObtenerEditorial()
        {
            return _context.Editorials.ToList();
        }
        public Editorial GetEditorialById(int id)
        {
            return _context.Editorials.Find(id);
        }
        public bool CrearEditorial(Editorial request)
        {
            _context.Editorials.Add(request);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateEditorial(Editorial request)
        {
            var editorial = _context.Editorials.Find(request.PkEditorial);
            if (editorial == null)
            {
                return false;
            } 
            editorial.Nombre = request.Nombre;
            _context.Editorials.Update(editorial);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteEditorial(int id)
        {
            var editorial = _context.Editorials.Find(id);
            if (editorial == null)
            {
                return false;
            }
            _context.Editorials.Remove(editorial);
            return _context.SaveChanges() > 0;
        }
    }
}
