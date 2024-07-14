using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotiIpt.Models
{
    /// <summary>
    /// Classe para descrever os Utilizadores existentes na redação
    /// </summary>
    public class Utilizadores : IdentityUser
    {
        public Utilizadores()
        {
            this.DataInicio = DateTime.Now;
        }

        /// <summary>
        /// Nome do utilizador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(60)]
        public string Nome { get; set; }

        /// <summary>
        /// Contacto de telemovel do utilizador
        /// </summary>
        [Display(Name = "Telemóvel")]
        [StringLength(9)]
        [RegularExpression("9[1236][0-9]{7}", ErrorMessage = "o {0} só aceita 9 digitos")]
        public string Contacto { get; set; }
        /// <summary>
        /// Idade do utilizador
        /// </summary>
        [DataType(DataType.Date)] // informa a View de como deve tratar este atributo
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateOnly DataNascimento { get; set; }

        /// <summary>
        /// Data de registo do utilizador
        /// </summary>
        [Display(Name = "Data de criação")]
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// atributo para funcionar como FK
        /// no relacionamento entre a 
        /// base de dados do 'negócio' 
        /// e a base de dados da 'autenticação'
        /// </summary>
        [StringLength(40)]
        public string UserId { get; set; }
    }
}

