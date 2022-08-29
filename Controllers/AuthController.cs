using Amazon.RDS;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Mvc;
using music_chat.Helpers;
using music_chat.Models;
using music_chat.Models.DTO;

namespace music_chat.Controllers
{

    /// <summary>
    /// Register and Login controller
    /// </summary>
    public class AuthController : Controller
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAmazonS3 _amazonS3;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAmazonRDS _amazonRDS;
        private readonly AppDbContext _appDbContext;
        private HttpClient Client => _clientFactory.CreateClient("api");

        public AuthController(ILogger<AuthController> logger,
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

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Renders the login form view
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Renders the register form view
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Logs user out by clearing session.
        /// </summary>
        /// <returns>Home view</returns>
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }

        /// <summary>
        /// Attempts to log user in with form data
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginRequest(string email, string password)
        {

            var account = _appDbContext.Logins.Where(x => x.Email == email && x.Password == password).FirstOrDefault();

            if(account == null)
            {
                return View("Login");

            }

            var user = _appDbContext.Accounts.Where(x => x.Id == account.AccountId).FirstOrDefault()!;

            HttpContext.Session.SetString("email", account.Email!);
            HttpContext.Session.SetString("account_id", account.AccountId.ToString());
            HttpContext.Session.SetString("image", user.ImageUrl!);
            HttpContext.Session.SetString("username", user.Username!);

            return RedirectToAction("Index", "Home");

        }

        /// <summary>
        /// Attempts to register a new user with form data
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterRequest(string email, string password, string username, IFormFile file)
        {

            string fileId = "";


                using(var memStream = new MemoryStream())
                {

                    file.CopyTo(memStream);

                    fileId = Guid.NewGuid().ToString() + ".jpg";

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = memStream,
                        Key = fileId,
                        BucketName = AWSConstants.AWS_BUCKET_NAME,
                        CannedACL = S3CannedACL.PublicRead,

                    };

                    var fTransferUtil = new TransferUtility(_amazonS3);
                    await fTransferUtil.UploadAsync(uploadRequest);

                }
          


            var account = _appDbContext.Logins.Where(x => x.Email == email).FirstOrDefault();

            var takenUsername = _appDbContext.Accounts.Where(x => x.Username == username).FirstOrDefault();

            if(account != null || takenUsername != null)
            {
                return View("Register");

            }

            try
            {
                await _appDbContext.Accounts.AddAsync(new Account
                {

                    ImageUrl = AWSConstants.S3_BUCKET_URL + fileId,
                    Username = username,

                });

                await _appDbContext.SaveChangesAsync();

                await _appDbContext.Logins.AddAsync(new Login
                {
                    AccountId = _appDbContext.Accounts.Where(x => x.Username == username).First().Id,
                    Email = email,
                    Password = password,
                });

                await _appDbContext.SaveChangesAsync();

            }
            catch(Exception e)
            {
                return View("Register");
            }

            return View("Login");

        }

    }
}