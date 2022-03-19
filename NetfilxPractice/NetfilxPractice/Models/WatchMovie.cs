﻿namespace NetfilxPractice.Models
{
    public class WatchMovie
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}