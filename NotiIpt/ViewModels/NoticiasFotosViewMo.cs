using NotiIpt.Models;

namespace NotiIpt.ViewModels
{
    public class NoticiasFotosViewMo
    {
        /// <summary>
        /// Nome do ficheiro que contém a Foto
        /// </summary>
        public string? Nome { get; set; }

        public Noticias Noticias { get; set; }
    }
}
