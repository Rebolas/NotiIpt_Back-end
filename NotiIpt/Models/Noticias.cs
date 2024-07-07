using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotiIpt.Models
{
    public class Noticias
    {
        /// <summary>
        /// Classe para descrever as Noticias existentes na redação
        /// </summary>
        public Noticias()
        {
            ListaAutores = new HashSet<Utilizadores>();
            ListaFotos = new HashSet<Fotos>();
        }
        /// <summary>
        /// Chave Primária (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Titulo da noticia
        /// </summary>
        public string? Titulo { get; set; }
        /// <summary>
        /// Texto da noticia
        /// </summary>
        public string? Texto { get; set; }
        /// <summary>
        /// Data em que a noticia foi publicada
        /// </summary>
        public DateTime DataEscrita { get; set; }

        /// <summary>
        /// Chave forasteira para categoria associada à noticia
        /// </summary>
        [Display(Name = "Categoria")]
        [ForeignKey(nameof(Categoria))]
        public int CategoriaFK  { get; set; }
        public Categorias Categoria { get; set; }
        /// <summary>
        /// Lista de autores associados a uma noticia
        /// </summary>
        public ICollection<Utilizadores> ListaAutores { get; set; }
        /// <summary>
        /// Lista de fotos associadas a uma noticia
        /// </summary>
        public ICollection<Fotos> ListaFotos { get; set; }

    }
}
