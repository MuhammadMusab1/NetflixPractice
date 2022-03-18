namespace NetfilxPractice.Models
{
    public abstract class Media // parent of Movie and Episode class
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public float Duration { get; set; }
    }
}

/*
use abstract classes as the base class of your movies and episodes,
and as the relationship break between Users and those objects
(if you want to create a relationship break there).
 */