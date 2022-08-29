using Amazon.RDS;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using music_chat.Helpers;
using music_chat.Models;
using music_chat.Models.DTO;
using music_chat.Models.ResponseModel;
using music_chat.Models.ViewModel;
using Newtonsoft.Json;
using System.Text;

namespace music_chat.Controllers
{
    /// <summary>
    /// Spotify controller
    /// </summary>
    public class SpotifyController : Controller
    {

        private readonly ILogger<SpotifyController> _logger;
        private readonly IAmazonS3 _amazonS3;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAmazonRDS _amazonRDS;
        private readonly AppDbContext _appDbContext;
        private HttpClient Client => _clientFactory.CreateClient("api");

        public SpotifyController(ILogger<SpotifyController> logger,
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
        /// Returns the spotify.cshtml view
        /// </summary>
        /// <returns></returns>
        public IActionResult Spotify()
        {
            return View();
        }

        /// <summary>
        /// Starts the Spotify authentication process
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Authenticate()
        {
            return RedirectPermanent(SpotifyConstants.GetOAuthUri());
        }

        /// <summary>
        /// Handles the callback uri for Spotify authentication. The token will be extracted from the code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="error"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<IActionResult> Callback(string code, string error, string state)
        {

            var vm = new PlaybackViewModel();

            try
            {
                if(!string.IsNullOrEmpty(code))
                {
                    var token = await SpotifyConstants.GetAccessToken(code);
                    ViewBag.AccessToken = token.access_token;
                    ViewBag.RefreshToken = token.refresh_token;

                    HttpContext.Session.SetString("access_token", token.access_token);
                    HttpContext.Session.SetString("refresh_token", token.refresh_token);
                    ViewData["access_token"] = token.access_token;

                }

            }
            catch(Exception ex)
            {
                throw ex;
            }

            vm.accessToken = HttpContext.Session.GetString("access_token");

            return View("Spotify");
        }

        /// <summary>
        /// Search for tracks by input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SearchTracks(string input)
        {

            var vm = new PlaybackViewModel();

            var resultsModel = new TrackSearchResults();

            if(string.IsNullOrEmpty(input))
            {
                ModelState.AddModelError("EmptyForm", "Input must not be empty");
                return View("Spotify");
            }

            var data = new
            {
                q = input
            };

            using(var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("access_token"));

                using(var response = await client.GetAsync(SpotifyConstants.apiUrl + "search/?q=" + input + "&type=track&limit=10"))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();

                        vm = JsonConvert.DeserializeObject<PlaybackViewModel>(responseString);

                        vm!.resultsType = "tracks";

                    }

                }

            }

            vm.accessToken = HttpContext.Session.GetString("access_token");

            return View("Spotify", vm);

        }

        /// <summary>
        /// Search for albums by input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SearchAlbums(string input)
        {

            var vm = new PlaybackViewModel();
            var resultsModel = new TrackSearchResults();

            if(string.IsNullOrEmpty(input))
            {
                ModelState.AddModelError("EmptyForm", "Input must not be empty");
                return View("Spotify");
            }

            var data = new
            {
                q = input
            };

            using(var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("access_token"));

                using(var response = await client.GetAsync(SpotifyConstants.apiUrl + "search/?q=" + input + "&type=album&limit=10"))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();

                        vm = JsonConvert.DeserializeObject<PlaybackViewModel>(responseString);

                        vm!.resultsType = "albums";

                    }

                }

            }

            vm.accessToken = HttpContext.Session.GetString("access_token");

            return View("Spotify", vm);

        }

        /// <summary>
        /// Search for artists by input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SearchArtists(string input)
        {

            var vm = new PlaybackViewModel();

            var resultsModel = new TrackSearchResults();

            if(string.IsNullOrEmpty(input))
            {
                ModelState.AddModelError("EmptyForm", "Input must not be empty");
                return View("Spotify");
            }

            var data = new
            {
                q = input
            };

            using(var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("access_token"));

                using(var response = await client.GetAsync(SpotifyConstants.apiUrl + "search/?q=" + input + "&type=artist&limit=10"))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();

                        vm = JsonConvert.DeserializeObject<PlaybackViewModel>(responseString);

                        vm!.resultsType = "artists";

                    }

                }

            }

            foreach(var artist in vm.ArtistSearchResults.items)
            {
                if(artist.images == null)
                {
                    artist.images = null;
                }
                else if(artist.images.Length == 0)
                {
                    artist.images = null;
                }
            }

            vm.accessToken = HttpContext.Session.GetString("access_token");

            return View("Spotify", vm);

        }

        /// <summary>
        /// Suggest a song in the forum
        /// </summary>
        /// <param name="trackName"></param>
        /// <param name="id"></param>
        /// <param name="href"></param>
        /// <param name="uri"></param>
        /// <param name="albumName"></param>
        /// <param name="artistName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SuggestSong(string trackName, string id, string href, string uri, string albumName, string artistName)
        {

            await _appDbContext.Posts.AddAsync(new Post
            {
                Content = CreateSongSuggestionMessage(trackName, id, href, uri, albumName, artistName),
                timestamp = DateTime.UtcNow,
                AuthorUsername = HttpContext.Session.GetString("username"),
                AuthorProfileImage = HttpContext.Session.GetString("image"),
                date = DateTime.UtcNow.Date,
            });

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Forum", "Forum");
        }

        /// <summary>
        /// Suggest an artist in the forum
        /// </summary>
        /// <param name="artistName"></param>
        /// <param name="id"></param>
        /// <param name="href"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SuggestArtist(string artistName, string id, string href, string uri)
        {

            await _appDbContext.Posts.AddAsync(new Post
            {
                Content = CreateArtistSuggestionMessage(artistName, id, href, uri),
                timestamp = DateTime.UtcNow,
                AuthorUsername = HttpContext.Session.GetString("username"),
                AuthorProfileImage = HttpContext.Session.GetString("image"),
                date = DateTime.UtcNow.Date,
            });

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Forum", "Forum");
        }

        /// <summary>
        /// Suggest an album in the forum
        /// </summary>
        /// <param name="albumName"></param>
        /// <param name="artistName"></param>
        /// <param name="id"></param>
        /// <param name="href"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SuggestAlbum(string albumName, string artistName, string id, string href, string uri)
        {

            await _appDbContext.Posts.AddAsync(new Post
            {
                Content = CreateAlbumSuggestionMessage(albumName, artistName, id, href, uri),
                timestamp = DateTime.UtcNow,
                AuthorUsername = HttpContext.Session.GetString("username"),
                AuthorProfileImage = HttpContext.Session.GetString("image"),
                date = DateTime.UtcNow.Date,
            });

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Forum", "Forum");
        }

        /// <summary>
        /// Create the song suggestion message
        /// </summary>
        /// <param name="trackName"></param>
        /// <param name="id"></param>
        /// <param name="href"></param>
        /// <param name="uri"></param>
        /// <param name="albumName"></param>
        /// <param name="artistName"></param>
        /// <returns></returns>
        private string CreateSongSuggestionMessage(string trackName, string id, string href, string uri, string albumName, string artistName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("I have a song suggestion! Please listen to " + trackName + " by " + artistName + ".");

            return sb.ToString();

        }

        /// <summary>
        /// Create the artist suggestion message
        /// </summary>
        /// <param name="artistName"></param>
        /// <param name="id"></param>
        /// <param name="href"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        private string CreateArtistSuggestionMessage(string artistName, string id, string href, string uri)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("I have an artist suggestion! Please listen to music by " + artistName + ".");

            return sb.ToString();

        }

        /// <summary>
        /// Create the album suggestion message
        /// </summary>
        /// <param name="albumName"></param>
        /// <param name="artistName"></param>
        /// <param name="id"></param>
        /// <param name="href"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        private string CreateAlbumSuggestionMessage(string albumName, string artistName, string id, string href, string uri)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("I have an album suggestion! Please listen to " + albumName + " by " + artistName + ".");

            return sb.ToString();

        }

    }
}