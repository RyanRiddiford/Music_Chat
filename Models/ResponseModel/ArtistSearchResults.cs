namespace music_chat.Models.ResponseModel
{
    /// <summary>
    /// Artist search results model
    /// </summary>
    public class ArtistSearchResults
    {
        public string? href { get; set; }

        public ArtistItems[] items { get; set; }

        public int limit { get; set; }

        public string? next { get; set; }

        public int offset { get; set; }

        public string? previous { get; set; }

        public int total { get; set; }

    }
}