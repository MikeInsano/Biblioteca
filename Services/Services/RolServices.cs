using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;

namespace BibliotecaBolonMiguel.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;
        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Rol> ObtenerRoles()
        {
            return _context.Roles.ToList();
        }
        public Rol GetRolById(int id)
        {
            return _context.Roles.Find(id);
        }
        public bool CrearRol(Rol request)
        {
            _context.Roles.Add(request);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateRol(Rol request)
        {
            var rol = _context.Roles.Find(request.PkRol);
            if (rol == null)
            {
                return false;
            }

            rol.Nombre = request.Nombre;
            _context.Roles.Update(rol);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteRol(int id)
        {
            var rol = _context.Roles.Find(id);
            if (rol == null)
            {
                return false;
            }

            _context.Roles.Remove(rol);
            return _context.SaveChanges() > 0;
        }
    }
}
