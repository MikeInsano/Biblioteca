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
        public DbSet<Libro> Libros { get; set; }

        //Semillas de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
               .HasOne(l => l.Autor)
               .WithOne(a => a.Libro)
               .HasForeignKey<Libro>(l => l.PkAutor);

            modelBuilder.Entity<Editorial>()
                .HasOne(e => e.Libro)
                .WithOne(l => l.Editorial)
                .HasForeignKey<Libro>(l => l.PkEditorial);

            modelBuilder.Entity<Genero>()
                .HasOne(g => g.Libro)
                .WithOne(l => l.Genero)
                .HasForeignKey<Libro>(l => l.PkGenero);


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
