namespace NetfilxPractice.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Duration { get; set; }
        public ICollection<FavouriteUserMovie> FavouriteMovies { get; set;}
        public ICollection<WatchUserMovie> WatchingMovies { get; set; }
        public Movie()//never used constructor (only did this to avoid this warings)
        {
            Title = "";
            Duration = 0;
            Id = 0;
            FavouriteMovies = new HashSet<FavouriteUserMovie>();
            WatchingMovies = new HashSet<WatchUserMovie>();
        }
        public Movie(string title, float duration)
        {
            Title = title;
            Duration = duration;
            FavouriteMovies = new HashSet<FavouriteUserMovie>();
            WatchingMovies = new HashSet<WatchUserMovie>();
        }
    }
}

/*
 I want you to design a analogue of Netflix 
in which we have Movies as the base class, 
and Episodes can inherit from them. 

You can also try having an abstract class for these, if you like.

Users (which have Identity) 
can have both a Favourites list AND a WatchList 
(if I really like a [Movie] or [Show], 
I can "favourite" it, if I just want to watch something later I can add it to my WatchList).

<---Favourite List ManyToMany--->
One User can have many favourite [Show]s
One Show can have many [User]s that have favourited it

One User can have many favourite [Movie]s
One Movie can have many [User]s that have favourited it

<---Watch List ManyToMany--->
One User can have many [Show]s in their WatchList
One Show can have many [User]s that have put it on their WatchList

One User can have many [Movie]s in their WatchList
One Movie can have many [User]s that have put it on their WatchList



Create a view that lets us see a list of movies, 
and 
episodes collected under their shows. 
They should all have buttons for adding them to a watchlist, or the favourites list. 

Also create a view of "My Shows" which lists all of the shows
that a user has a favourited or watch-listed episode of.
 
Seed at least one user, at least two instances of a Movie and 
and least five show episodes from two different shows.
 */