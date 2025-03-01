using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBolonMiguel.Services.Services
{
    public class UserServices : IUserServices

    {
        private readonly ApplicationDbContext _context;
        public UserServices(ApplicationDbContext context) 
        {
            _context = context;
        }

        public List<Usuario> ObtenerUsuario()
        {
            try
            {
                List<Usuario> result = _context.Usuarios.Include(x => x.Roles).ToList(); // Se manda a traer de la BD
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        public Usuario GetUserById(int id)
        {
            try
            {
                Usuario result = _context.Usuarios.Find(id);
                // Usuario result = _context.Usuarios.FirstOrDefault(x => x.PkUsuarioId == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        public bool CrearUsuario(Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Password = request.Password,
                    FkRol = request.FkRol,
                };

                _context.Usuarios.Add(usuario);
                int result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        public bool UpdateUser(Usuario request)
        {
            try
            {
                var usuario = _context.Usuarios.Find(request.PkUsuario);
                if(usuario == null)
                {
                    return false;
                }

                usuario.Nombre = request.Nombre;
                usuario.UserName = request.UserName;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                int result = _context.SaveChanges();

                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if(usuario == null)
                {
                    return false;
                }

                _context.Usuarios.Remove(usuario);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        public List<Rol> GetRoles()
        {
            try
            {
                return _context.Roles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error al obtener los roles: " + ex.Message);
            }
        }

    }
}