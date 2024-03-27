using System.ComponentModel.DataAnnotations;

namespace Meteorologica.Models
{
    public class Dados
    {
        [Key]
        public DateTime DataHora { get; set; }
        public int Temperatura { get; set; }
        public int Humidade { get; set; }
        public string? EstadoDia { get; set; }
        public bool Luz { get; set; }
    }
}
