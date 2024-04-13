using System.ComponentModel.DataAnnotations;

namespace Meteorologica.Models
{
    public class Categorias
    {
        public Categorias()
        {
            ListaNoticias = new HashSet<Noticias>();
        }

        [Key]
        public int Id { get; set; }
        public String Categoria { get; set; }
        public ICollection<Noticias> ListaNoticias { get; set; }
    }
}

