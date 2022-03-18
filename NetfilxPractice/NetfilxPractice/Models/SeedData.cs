using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetfilxPractice.Data;

namespace NetfilxPractice.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            //Copy and paste from Lesson 1 of Advanced Topics in C#
            var context  = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if(!context.Users.Any()) //if no user are found in the database
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                ApplicationUser user1 = new ApplicationUser
                {
                    Email = "musab03@gmail.com",
                    NormalizedEmail = "MUSAB03@GMAIL.COM",
                    UserName = "musab03@gmail.com",
                    NormalizedUserName = "MUSAB03@GMAIL.COM",
                    EmailConfirmed = true,
                };
                var user1HashedPassword = passwordHasher.HashPassword(user1, "Yaqoob@12");
                user1.PasswordHash = user1HashedPassword;

                await userManager.CreateAsync(user1);
                //You might won't be able to login when you first add the user to the database
                //(try closing the application and running again)
            }
            if(!context.Movie.Any()) //if no movies are found in the database
            {
                Movie movie1 = new Movie("Ice Age 3", 70); //duration in minutes
                Movie movie2 = new Movie("Annable", 85); //duration in minutes

                context.Movie.Add(movie1);
                context.Movie.Add(movie2);
                context.SaveChanges();
            }
            if(!context.Show.Any())
            {
                Show show1 = new Show("Family Guy", "Comedy", 5);
                Show show2 = new Show("Peaky Blinder Season 6", "Thriller", 5);

                //Show1 Episodes
                Episode show1Ep1 = new Episode("Glen's Secret", 20, show1);
                Episode show1Ep2 = new Episode("Eat My Junk", 20, show1);
                Episode show1Ep3 = new Episode("Stewi's Date", 20, show1);
                Episode show1Ep4 = new Episode("Brian The Dog", 20, show1);
                Episode show1Ep5 = new Episode("Meg's Bully", 20, show1);

                show1.Episodes.Add(show1Ep1);
                show1.Episodes.Add(show1Ep2);
                show1.Episodes.Add(show1Ep3);
                show1.Episodes.Add(show1Ep4);
                show1.Episodes.Add(show1Ep5);

                //Show2 Episodes
                Episode show2Ep1 = new Episode("The Black Star", 55, show2);
                Episode show2Ep2 = new Episode("King's Servant", 55, show2);
                Episode show2Ep3 = new Episode("Heathens", 58, show2);
                Episode show2Ep4 = new Episode("Dangerous", 50, show2);
                Episode show2Ep5 = new Episode("The Company", 55, show2);

                show2.Episodes.Add(show2Ep1);
                show2.Episodes.Add(show2Ep2);
                show2.Episodes.Add(show2Ep3);
                show2.Episodes.Add(show2Ep4);
                show2.Episodes.Add(show2Ep5);

                //add all shows to context
                context.Show.Add(show1);
                context.Show.Add(show2);

                //add all episodes to context
                context.Episode.Add(show1Ep1);
                context.Episode.Add(show1Ep2);
                context.Episode.Add(show1Ep3);
                context.Episode.Add(show1Ep4);
                context.Episode.Add(show1Ep5);

                context.Episode.Add(show2Ep1);
                context.Episode.Add(show2Ep2);
                context.Episode.Add(show2Ep3);
                context.Episode.Add(show2Ep4);
                context.Episode.Add(show2Ep5);
                //add all episode to Episode DbSet
                context.Episode.Add(show1Ep1);
                context.Episode.Add(show1Ep2);
                context.Episode.Add(show1Ep3);
                context.Episode.Add(show1Ep4);
                context.Episode.Add(show1Ep5);

                context.Episode.Add(show2Ep1);
                context.Episode.Add(show2Ep2);
                context.Episode.Add(show2Ep3);
                context.Episode.Add(show2Ep4);
                context.Episode.Add(show2Ep5);

                context.SaveChanges();

            }
        }
    }
}

/*
Seed at least one user, at least two instances of a Movie and 
and least five show episodes from two different shows.
 */
