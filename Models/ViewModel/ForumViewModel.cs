namespace music_chat.Models.ViewModel
{

    /// <summary>
    /// Forum page view data
    /// </summary>
    public class ForumViewModel
    {

        public string? AuthorUsername { get; set; }

        public string? AuthorProfileImage { get; set; }

        public string? Content { get; set; }

        public DateTime timestamp { get; set; }

    }
}