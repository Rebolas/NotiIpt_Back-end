using System.ComponentModel.DataAnnotations;

namespace NotiIpt.Models
{
    public class Noticias
    {
        public Noticias()
        {
            ListaAutores = new HashSet<Utilizadores>();
            ListaFotos = new HashSet<Fotos>();
        }
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Texto { get; set; }
        public DateTime DataEscrita { get; set; }
        public ICollection<Utilizadores> ListaAutores { get; set; }
        public ICollection<Fotos> ListaFotos { get; set; }

    }
}
