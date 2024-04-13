namespace Meteorologica.Models
{
    public class Fotos
    {
        public Fotos() {
            ListaNoticias = new HashSet<Noticias>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }

        public ICollection<Noticias> ListaNoticias { get; set; }
    }
}
