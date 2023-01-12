namespace GITBisectAtTheMovies.Models
{
    public class MovieData
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public MovieData()
        {
            GetMovies();
        }

        private void GetMovies() 
        {

            if (Movies == null || !Movies.Any())
            {
                Movies.Add(new Movie() { 
                    id = "1", crew = "Sam Neill, Jeff Goldblum, Laura Dern"
                    , fullTitle = "Jurassic Park (1993)", image = "", imDbRating = "9.4", imDbRatingCount = "10000"
                    , rank = "25", title = "Jurassic Park", year = "1993"
                });
            }
        }
    }
}
