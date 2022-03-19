namespace NetfilxPractice.Models
{
    public class Episode : Movie
    {
        public string Title { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}
