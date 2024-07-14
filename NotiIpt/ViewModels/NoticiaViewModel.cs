using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotiIpt.Models
{
    public class NoticiaViewModel
    {
        public NoticiaViewModel(Noticias noticia)
        {
            this.Id = noticia.Id;
            this.Titulo = noticia.Titulo;
            this.DataEdicao = noticia.DataEdicao;
            this.CategoriaFK = noticia.CategoriaFK;
            this.Texto = noticia.Texto;
            this.DataEscrita = noticia.DataEscrita;
        } 
        /// <summary>
        /// Chave Primária (PK)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Titulo da noticia
        /// </summary>
        [Display(Name = "Título")]
        public string? Titulo { get; set; }
        /// <summary>
        /// Texto da noticia
        /// </summary>
        public string? Texto { get; set; }

        /// <summary>
        /// Data de Edição da noticia
        /// </summary>
        public DateTime? DataEdicao { get; set; }
        /// <summary>
        /// Data em que a noticia foi publicada
        /// </summary>
        [Display(Name = "Data de criação")]
        public DateTime DataEscrita { get; set; }

        /// <summary>
        /// Chave forasteira para categoria associada à noticia
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Categoria")]
        [ForeignKey(nameof(Categoria))]
        public int CategoriaFK { get; set; }
        public Categorias Categoria { get; set; }
        /// <summary>
        /// Lista de autores associados a uma noticia
        /// </summary>
        public ICollection<Utilizadores> ListaAutores { get; set; }
        /// <summary>
        /// Lista de fotos associadas a uma noticia
        /// </summary>
        public ICollection<string> ListaFotos { get; set; }
    }
}
