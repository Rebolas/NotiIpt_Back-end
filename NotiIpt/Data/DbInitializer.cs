using NotiIpt.Models;
using Microsoft.AspNetCore.Identity;
using NotiIpt.Data;


namespace Aulas.Data
{

    internal class DbInitializer
    {

        internal static async void Initialize(ApplicationDbContext dbContext)
        {

            /*
             * https://stackoverflow.com/questions/70581816/how-to-seed-data-in-net-core-6-with-entity-framework
             * 
             * https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#initialize-db-with-test-data
             * https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/data/ef-mvc/intro/samples/5cu/Program.cs
             * https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0300
             */


            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            // var auxiliar
            bool haAdicao = false;



            // Se não houver Cursos, cria-os
            var cursos = Array.Empty<Categorias>();
            if (!dbContext.Categorias.Any())
            {
                cursos = [
                   new Categorias{ Categoria="Musica"},
               new Categorias{ Categoria="Tecnologia"},
               new Categorias{ Categoria="Cultura"}
                //adicionar outros cursos
                ];
                await dbContext.Categorias.AddRangeAsync(cursos);
                haAdicao = true;
            }


            // Se não houver Utilizadores Identity, cria-os
            var users = Array.Empty<Utilizadores>();
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            if (!dbContext.Users.Any())
            {
                users = [
                   new Utilizadores{Nome="admin", Contacto="931313131",UserName="admin@mail.pt", NormalizedUserName="ADMIN@MAIL.PT",
               Email="admin@mail.pt",NormalizedEmail="ADMIN@MAIL.PT", EmailConfirmed=true,
               SecurityStamp="5ZPZEF6SBW7IU4M344XNLT4NN5RO4GRU", ConcurrencyStamp="c86d8254-dd50-44be-8561-d2d44d4bbb2f",
               PasswordHash=hasher.HashPassword(null,"*aA1234567") },
            new Utilizadores{Nome="jose", Contacto="921212121",UserName="email.sete@mail.pt", NormalizedUserName="EMAIL.SETE@MAIL.PT",
               Email="email.sete@mail.pt",NormalizedEmail="EMAIL.SETE@MAIL.PT", EmailConfirmed=true,
               SecurityStamp="TW49PF6SBW7IU4M344XNLT4NN5RO4GRU", ConcurrencyStamp="d8254c86-dd50-44be-8561-d2d44d4bbb2f",
               PasswordHash=hasher.HashPassword(null,"Aa0_aa") }
                   ];
                await dbContext.Users.AddRangeAsync(users);
                haAdicao = true;
            }


            try
            {
                if (haAdicao)
                {
                    // tornar persistentes os dados
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }
    }
}