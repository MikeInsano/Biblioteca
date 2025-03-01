using System.ComponentModel.DataAnnotations;

namespace BibliotecaBolonMiguel.Models.Domain
{
    public class Editorial
    {
        [Key]
        public int PkEditorial { get; set; }
        public string Nombre { get; set; }
    }
}
