using System.ComponentModel.DataAnnotations;

namespace NotiIpt.Models
{
    public class Dados
    {
        /// <summary>
        /// Chave Primária (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Data e hora
        /// </summary>
        public String DataHora { get; set; }
        /// <summary>
        /// Leitura de temperatura
        /// </summary>
        public float? Temperatura { get; set; }
        /// <summary>
        /// Leitura de Humidade
        /// </summary>
        public float? Humidade { get; set; }
        /// <summary>
        /// Estado do dia na sala
        /// </summary>
        public int? lumino { get; set; }
        /// <summary>
        /// Luz acesa na sala ou não
        /// </summary>
        public string? Luz { get; set; }
    }
}
