using Microsoft.AspNetCore.Identity;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* Esta instrução importa tudo o que está pre-definido
             * na super classe
             */
            base.OnModelCreating(builder);

            /* Adição de dados à Base de Dados
             * Esta forma é PERSISTENTE, pelo que apenas deve ser utilizada em 
             * dados que perduram da fase de 'desenvolvimento' para a fase de 'produção'.
             * Implica efetuar um 'Add-Migration'
             * 
             * Atribuir valores às ROLES
             */
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "p", Name = "Funcionario", NormalizedName = "FUNCIONARIO" },
                new IdentityRole { Id = "admin", Name = "Admin", NormalizedName = "ADMIN" }
                );

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
