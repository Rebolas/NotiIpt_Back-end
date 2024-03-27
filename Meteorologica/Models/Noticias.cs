using System.ComponentModel.DataAnnotations;

namespace Meteorologica.Models
{
    public class Noticias
    {
        public Noticias()
        {
            ListaAutores = new HashSet<Utilizadores>();
        }
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Imagem { get; set; }
        public string? Texto { get; set; }
        public ICollection<Utilizadores> ListaAutores { get; set; }

    }
}
