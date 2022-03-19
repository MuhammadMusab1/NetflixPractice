namespace NetfilxPractice.Models
{
    public class WatchShow
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}
