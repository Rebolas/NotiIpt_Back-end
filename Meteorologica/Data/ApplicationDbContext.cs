using Meteorologica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meteorologica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){
        }

        public DbSet<Utilizadores> Utilizadores { get; set; }
        public DbSet<Dados> Dados { get; set; }
        public DbSet<Fotos> Fotos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
      
    }
}
