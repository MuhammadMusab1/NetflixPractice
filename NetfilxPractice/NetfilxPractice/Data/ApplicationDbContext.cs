using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetfilxPractice.Models;

namespace NetfilxPractice.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //like this
            builder.Entity<Show>().HasKey(show => show.Id);
            builder.Entity<Movie>().HasKey(movie => movie.Id);
            builder.Entity<FavouriteUserShow>().HasKey(userShow => userShow.Id);

            //One to Many between Show and Episode(Movie)
            builder.Entity<Show>()
                .HasMany(show => show.Episodes)
                .WithOne(episode => episode.Show)
                .HasForeignKey(episode => episode.ShowId);

            //https://stackoverflow.com/questions/9437366/entity-framework-4-3-code-first-multiple-many-to-many-using-the-same-tables


            ////Many To Many For FavouriteList of Shows to User
            builder.Entity<FavouriteUserShow>()
                .HasOne(fUserShow => fUserShow.User)
                .WithMany(user => user.FavouriteShows)
                .HasForeignKey(userShow => userShow.UserId);

            builder.Entity<FavouriteUserShow>()
                .HasOne(userShow => userShow.FavouriteShow)
                .WithMany(show => show.FavouriteShows)
                .HasForeignKey(userShow => userShow.FavouriteShowId);

            ////Many to Many for the WatchList of shows to User
            builder.Entity<WatchUserShow>()
                .HasOne(wUserShow => wUserShow.User)
                .WithMany(user => user.WatchingShows)
                .HasForeignKey(wUserShow => wUserShow.UserId);

            builder.Entity<WatchUserShow>()
                .HasOne(wUserShow => wUserShow.WatchingShow)
                .WithMany(show => show.WatchingShows)
                .HasForeignKey(wUserShow => wUserShow.WatchingShowId);

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Episode> Episode { get; set;}
        public DbSet<Show> Show { get; set; }
        public DbSet<FavouriteUserShow> FavouriteUserShow { get; set; }
        public DbSet<WatchUserShow> WatchUserShow { get; set; }
    }
}