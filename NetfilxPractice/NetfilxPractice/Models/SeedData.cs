using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetfilxPractice.Data;

namespace NetfilxPractice.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!context.Users.Any())
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();

                ApplicationUser firstUser = new ApplicationUser
                {
                    Email = "admin@123.com",
                    NormalizedEmail = "ADMIN@123.COM",
                    UserName = "admin@123.com",
                    NormalizedUserName = "ADMIN@123.COM",
                    EmailConfirmed = true,
                };

                var hashedPassword = passwordHasher.HashPassword(firstUser, "`1Qazxsw");
                firstUser.PasswordHash = hashedPassword;

                await userManager.CreateAsync(firstUser);
            }

            if (!context.Movies.Any())
            {
                List<Movie> newMovie = new List<Movie>()
                {
                    new Movie { Title="The Matrix",Length="120" },
                    new Movie { Title="The Avengers",Length="120" }
                };
                context.Movies.AddRange(newMovie);
            }

            

            context.SaveChanges();
        }
    }
}
