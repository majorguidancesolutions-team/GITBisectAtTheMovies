using GITBisectAtTheMovies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GITBisectAtTheMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration; 

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var md = new MovieData();
            var apiKey = _configuration["API:ImdbAPIKey"];
            var apiTop250 = _configuration["API:ImdbAPITop250"];
            var apiRoot = _configuration["API:ImdbAPIUrl"];

            //toggle to true to call directly to the API, false for use backup file
            bool useAPI = true;
            return View(await MovieData.GetMovies(apiKey, apiRoot, apiTop250, useAPI));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}