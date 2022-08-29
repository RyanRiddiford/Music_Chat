using Amazon.RDS;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using music_chat.Models;
using music_chat.Models.DTO;
using music_chat.Models.ViewModel;

namespace music_chat.Controllers
{

    /// <summary>
    /// Forum controller
    /// </summary>
    public class ForumController : Controller
    {

        private readonly ILogger<ForumController> _logger;
        private readonly IAmazonS3 _amazonS3;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAmazonRDS _amazonRDS;
        private readonly AppDbContext _appDbContext;
        private HttpClient Client => _clientFactory.CreateClient("api");

        public ForumController(ILogger<ForumController> logger,
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
        /// Returns the forum.cshtml view
        /// </summary>
        /// <returns></returns>
        public IActionResult Forum()
        {
            return View(GetTopPosts());
        }

        /// <summary>
        /// Fetches the top ten newest forum posts
        /// </summary>
        /// <returns></returns>
        private List<ForumViewModel> GetTopPosts()
        {
            List<ForumViewModel> posts = new List<ForumViewModel>();

            foreach(var post in _appDbContext.Posts.OrderByDescending(x => x.timestamp).Take(10).ToArray())
            {
                posts.Add(new ForumViewModel
                {
                    AuthorProfileImage = post.AuthorProfileImage,
                    AuthorUsername = post.AuthorUsername,
                    Content = post.Content,
                    timestamp = post.timestamp,
                });
            }

            return posts;
        }

        /// <summary>
        /// Attempts to create a new post
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostRequest(string content)
        {

            await _appDbContext.Posts.AddAsync(new Post
            {
                Content = content,
                timestamp = DateTime.UtcNow,
                AuthorUsername = HttpContext.Session.GetString("username"),
                AuthorProfileImage = HttpContext.Session.GetString("image"),
                date = DateTime.UtcNow.Date,
            });

            await _appDbContext.SaveChangesAsync();

            return View("Forum", GetTopPosts());

        }
    }
}