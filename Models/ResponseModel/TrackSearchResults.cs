namespace music_chat.Models.ResponseModel
{
    /// <summary>
    /// Track search results model
    /// </summary>
    public class TrackSearchResults
    {

        public string? href { get; set; }

        public TrackItems[] items { get; set; }

        public int limit { get; set; }

        public string? next { get; set; }

        public int offset { get; set; }

        public string? previous { get; set; }

        public int total { get; set; }

    }
}