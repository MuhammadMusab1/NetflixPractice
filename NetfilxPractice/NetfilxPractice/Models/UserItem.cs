namespace NetfilxPractice.Models
{
    public class UserItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
