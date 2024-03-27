using System.ComponentModel.DataAnnotations;

namespace Meteorologica.Models
{
    public class Utilizadores
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Email { get; set; }
        public int Contacto { get; set; }
        public int Idade { get; set; }
        public string? Tipo { get; set; }
        public DateTime DataInicio { get; set; }
    }
}
