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
                    Id = 1, Description = "Dinosaurs", MPAARating = "PG-13", Title = "Jurassic Park", Year = 1993
                });
            }
        }
    }
}
