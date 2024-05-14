using System.ComponentModel.DataAnnotations;

namespace NotiIpt.Models
{
    public class Dados
    {
        /// <summary>
        /// Chave Primária (PK)
        /// </summary>
        [Key]
        public DateTime DataHora { get; set; }
        /// <summary>
        /// Leitura de temperatura
        /// </summary>
        public int Temperatura { get; set; }
        /// <summary>
        /// Leitura de Humidade
        /// </summary>
        public int Humidade { get; set; }
        /// <summary>
        /// Estado do dia na sala
        /// </summary>
        public string? EstadoDia { get; set; }
        /// <summary>
        /// Luz acesa na sala ou não
        /// </summary>
        public bool Luz { get; set; }
    }
}
