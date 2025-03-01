using BibliotecaBolonMiguel.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBolonMiguel.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editorials { get; set; }

        //Semillas de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Miguel Bolon",
                    UserName = "Mikey",
                    Password = "chanchito",
                    FkRol = 1
                }
                );
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "Admin"
                }
                );
        }
    }
}
