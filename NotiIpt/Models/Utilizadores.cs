using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotiIpt.Models
{
    /// <summary>
    /// Classe para descrever os Utilizadores existentes na redação
    /// </summary>
    public class Utilizadores
    {
        /// <summary>
        /// Chave Primária (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome do utilizador
        /// </summary>
        [StringLength(100)]
        public string Nome { get; set; }

        /// <summary>
        /// Imagem de perfil do utilizador
        /// </summary>
        [Display(Name="Imagem de Perfil")] // altera o nome do atributo no ecrã
        [StringLength(50)] // define o tamanho máximo como 50 caracteres
        public String? ImagemPerf { get; set; }
        /// <summary>
        /// Email do utilizador
        /// </summary>
        public int Email { get; set; }
        /// <summary>
        /// Contacto de telemovel do utilizador
        /// </summary>
        public int Contacto { get; set; }
        /// <summary>
        /// Idade do utilizador
        /// </summary>
        public int Idade { get; set; }
        /// <summary>
        /// Tipo de utilizador
        /// </summary>
        public string? Tipo { get; set; }
        /// <summary>
        /// Data de registo do utilizador
        /// </summary>
        public DateTime DataInicio { get; set; }
    }
}
