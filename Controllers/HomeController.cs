using Amazon.RDS;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using music_chat.Models;
using System.Diagnostics;

namespace music_chat.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAmazonS3 _amazonS3;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAmazonRDS _amazonRDS;
        private readonly AppDbContext _appDbContext;

        private HttpClient Client => _clientFactory.CreateClient("api");

        public HomeController(ILogger<HomeController> logger,
            IAmazonS3 amazonS3,
            IHttpClientFactory httpClientFactory,
            IAmazonRDS amazonRDS,
            AppDbContext appDbContext)
        {
            _logger = logger;
            _amazonS3 = amazonS3;
            _clientFactory = httpClientFactory;
            _amazonRDS = amazonRDS;
            _appDbContext = appDbContext;

        }

        /// <summary>
        /// Loads user data to view model
        /// </summary>
        /// <returns>Returns the homepage with a view model</returns>
        public IActionResult Index()
        {

            var accounts = _appDbContext.Accounts.Where(x => x.Username != "").Count();
            var logins = _appDbContext.Logins.Where(x => x.Email != "").Count();

            ViewData["account-count"] = "Number of accounts: " + accounts;
            ViewData["login-count"] = "Number of logins: " + logins;

            return View();
        }

        /// <summary>
        /// Returns the error page
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}