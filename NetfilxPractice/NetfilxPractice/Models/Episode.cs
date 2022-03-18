namespace NetfilxPractice.Models
{
    public class Episode : Movie //inherits from Movie (Id, Duration, Title)
    { 
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public Episode() //never used constructor (only did this to avoid warings)
        {
            ShowId = 0;
            Duration = 0;
            Title = "";
            Show = new Show();
        }
        public Episode(string title, int duration, Show show)
        {
            Title = title;
            Show = show;
            ShowId = show.Id;
            Duration = duration;
        }
    }
}
