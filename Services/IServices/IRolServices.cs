using BibliotecaBolonMiguel.Models.Domain;

namespace BibliotecaBolonMiguel.Services.IServices
{
    public interface IRolServices
    {
        public List<Rol> ObtenerRoles();
        public bool CrearRol(Rol request);
        public Rol GetRolById(int id);
        public bool UpdateRol(Rol request);
        public bool DeleteRol(int id);
    }
}
