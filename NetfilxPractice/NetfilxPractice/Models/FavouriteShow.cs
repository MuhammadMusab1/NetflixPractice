namespace NetfilxPractice.Models
{
    public class FavouriteShow
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}
