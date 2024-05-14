using System.ComponentModel.DataAnnotations;

namespace NotiIpt.Models
{
    public class Fotos
    {
        /// <summary>
        /// Classe para descrever as Fotos existentes na redação
        /// </summary>
        public Fotos() {
            ListaNoticias = new HashSet<Noticias>();
        }
        /// <summary>
        /// Chave Primária (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome da Foto
        /// </summary>
        public string? Nome { get; set; }
        /// <summary>
        /// Lista de Noticias associadas a cada foto
        /// </summary>
        public ICollection<Noticias> ListaNoticias { get; set; }
    }
}
