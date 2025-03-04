using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaBolonMiguel.Models.Domain
{
    public class Libro
    {
        [Key]
        public int PkLibro { get; set; }
        public string Titulo { get; set; }

        [ForeignKey("Autor")]
        public int? PkAutor { get; set; }
        public Autor? Autor { get; set; }

        public string Descripcion { get; set; }

        [ForeignKey("Editorial")]
        public int? PkEditorial { get; set; }
        public Editorial? Editorial { get; set; }

        [ForeignKey("Genero")]
        public int? PkGenero { get; set; }
        public Genero? Genero { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public string? FotoUrl { get; set; }    
        public int Paginas { get; set; }
        public string OpenLibrary { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
        public string WorkId { get; set; }
        public string Idioma { get; set; }
    }
}
