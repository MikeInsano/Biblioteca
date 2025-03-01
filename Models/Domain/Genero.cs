using System.ComponentModel.DataAnnotations;

namespace BibliotecaBolonMiguel.Models.Domain
{
    public class Genero
    {
        [Key]
        public int PkGenero { get; set; }
        public string Nombre { get; set; }
    }
}