using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaBolonMiguel.Models.Domain
{
    public class Libro
    {
        [Key]
        public int PkLibro { get; set; }
        public string Titulo { get; set; }

        [ForeignKey("Autores")]
        public int PkAutor { get; set; }
        public Autor Autores { get; set; }

        public string Descripcion { get; set; }
        public string Editorial { get; set; }

        [ForeignKey("Generos")]
        public int PkGenero { get; set; }
        public Genero Genero { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public string Imagen { get; set; }    
        public int Paginas { get; set; }
        public string OpenLibrary { get; set; }
        public int Isbn10 { get; set; }
        public int Isbn13 { get; set; }
        public string WorkId { get; set; }
        public string Idioma { get; set; }
    }
}
