using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotiIpt.Models;

namespace NotiIpt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// tabela Utilizadores
        /// </summary>
        public DbSet<Utilizadores> Utilizadores { get; set; }
        /// <summary>
        /// tabela Dados
        /// </summary>
        public DbSet<Dados> Dados { get; set; }
        /// <summary>
        /// tabela Fotos
        /// </summary>
        public DbSet<Fotos> Fotos { get; set; }
        /// <summary>
        /// tabela Categorias
        /// </summary>
        public DbSet<Categorias> Categorias { get; set; }
        /// <summary>
        /// tabela Noticias
        /// </summary>
        public DbSet<Noticias> Noticias { get; set; }

    }
}
