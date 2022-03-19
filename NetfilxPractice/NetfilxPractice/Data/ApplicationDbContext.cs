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
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasKey(a => a.Id);
            builder.Entity<Movie>().HasKey(m => m.Id);
            builder.Entity<Show>().HasKey(s => s.Id);
            builder.Entity<FavouriteMovie>().HasKey(e => e.Id);
            builder.Entity<FavouriteShow>().HasKey(e => e.Id);
            builder.Entity<WatchMovie>().HasKey(e => e.Id);
            builder.Entity<WatchShow>().HasKey(e => e.Id);

            builder.Entity<Episode>().HasOne(e => e.Show).WithMany(s => s.Episodes).HasForeignKey(e => e.ShowId);
            // User Movie FavouriteMovie
            builder.Entity<ApplicationUser>().HasMany(a => a.FavouriteMovieList).WithOne(fm => fm.User).HasForeignKey(fm => fm.UserId);
            builder.Entity<Movie>().HasMany(m => m.FavouriteUsers).WithOne(fm => fm.Movie).HasForeignKey(fm => fm.MovieId);
            // User Show FavouriteShow
            builder.Entity<ApplicationUser>().HasMany(a => a.FavouriteShowList).WithOne(fs => fs.User).HasForeignKey(fs => fs.UserId);
            builder.Entity<Show>().HasMany(m => m.FavouriteUsers).WithOne(fs => fs.Show).HasForeignKey(fs => fs.ShowId);
            // User Movie WatchMovie
            builder.Entity<ApplicationUser>().HasMany(a => a.WatchMovieList).WithOne(wm => wm.User).HasForeignKey(wm => wm.UserId);
            builder.Entity<Movie>().HasMany(m => m.WatchUsers).WithOne(wm => wm.Movie).HasForeignKey(wm => wm.MovieId);
            // User Show WatchShow
            builder.Entity<ApplicationUser>().HasMany(a => a.WatchShowList).WithOne(ws => ws.User).HasForeignKey(ws => ws.UserId);
            builder.Entity<Show>().HasMany(m => m.FavouriteUsers).WithOne(ws => ws.Show).HasForeignKey(ws => ws.ShowId);

            /**builder.Entity<Show>().HasData(new Show
            {
                Id = 1,
                Title = "Cooking Time"
            });
            builder.Entity<Show>().HasData(new Show
            {
                Id=2,
                Title="Carton"
            });**/
        }

        public DbSet<ApplicationUser> Users { get; set;}
        public DbSet<Movie> Movies { get; set;}
        public DbSet<Episode> Episodes { get; set;}
        public DbSet<Show> Shows { get; set;}
        public DbSet<FavouriteMovie> FavouriteMovies { get; set;}
        public DbSet<FavouriteShow> FavouriteShows { get; set;}
        public DbSet<WatchMovie> WatchMovies { get; set;}
        public DbSet<WatchShow> WatchShows { get; set;}
    }
}