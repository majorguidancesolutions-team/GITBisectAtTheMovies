﻿namespace GITBisectAtTheMovies.Models
{
    public class AllMovies
    {
        public List<Movie> items { get; set; }
    }

    public class Movie
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string title { get; set; }
        public string fullTitle { get; set; }
        public string year { get; set; }
        public string image { get; set; }
        public string crew { get; set; }
        public string imDbRating { get; set; }
        public string imDbRatingCount { get; set; }
    }
}
