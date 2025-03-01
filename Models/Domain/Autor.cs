using System.ComponentModel.DataAnnotations;

namespace BibliotecaBolonMiguel.Models.Domain
{
    public class Autor
    {
        [Key]
        public int PkAutor { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string? FotoUrl { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
