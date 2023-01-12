using System.Net.Http.Headers;
using System.Text.Json;

namespace GITBisectAtTheMovies.Models
{
    public class MovieData
    {
        private static readonly HttpClient _client;

        static MovieData()
        {
            _client = new HttpClient();
        }

        public static async Task<List<Movie>> GetMovies(string apiKey, string apiURL, string apiTop250, bool useAPI)
        {
            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrEmpty(apiURL) || string.IsNullOrWhiteSpace(apiTop250))
            {
                throw new ArgumentException("API Key and/or API URL or API route not set correctly");
            }

            var movies = new List<Movie>();

            if (useAPI)
            {
                
                _client.BaseAddress = new Uri($"{apiURL}{apiTop250}{apiKey}");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var movieData = await _client.GetStringAsync("");
                var allMovies = JsonSerializer.Deserialize<AllMovies>(movieData);
                if (allMovies?.items != null && allMovies.items.Any())
                {
                    movies = allMovies.items;
                }
            }
            else
            {
                //try to use the local file
                var fileData = File.ReadAllText(@"assets/imdbAPITop250MoviesTruncated.dat");
                var allMovies = JsonSerializer.Deserialize<AllMovies>(fileData);
                if (allMovies?.items != null && allMovies.items.Any())
                {
                    movies = allMovies.items;
                }
            }

            if (movies.Count == 0)
            {
                movies.Add(new Movie()
                {
                    id = "tt0111161",
                    rank = "1",
                    title = "The Shawshank Redemption",
                    fullTitle = "The Shawshank Redemption (1994)",
                    year = "1994",
                    image = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_Ratio0.6716_AL_.jpg",
                    crew = "Frank Darabont (dir.), Tim Robbins, Morgan Freeman",
                    imDbRating = "9.2",
                    imDbRatingCount = "2683217"
                });

            }
            return movies;
        }
    }
}
