using BibliotecaBolonMiguel.Models.Domain;

namespace BibliotecaBolonMiguel.Services.IServices
{
    public interface IUserServices
    {
        public List<Usuario> ObtenerUsuario();
        public bool CrearUsuario(Usuario request);
        public Usuario GetUserById(int id);
        public bool UpdateUser(Usuario request);
        public bool DeleteUser(int id);
        public List<Rol> GetRoles();
    }
}
