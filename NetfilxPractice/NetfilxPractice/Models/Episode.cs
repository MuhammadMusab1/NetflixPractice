namespace NetfilxPractice.Models
{
    public class Episode : Movie //inherits from Movie (Id, Duration, Title)
    { 
        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}
