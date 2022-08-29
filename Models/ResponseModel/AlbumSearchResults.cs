namespace music_chat.Models.ResponseModel
{

    /// <summary>
    /// Album search results model
    /// </summary>
    public class AlbumSearchResults
    {

        public string? href { get; set; }

        public AlbumItems[] items { get; set; }

        public int limit { get; set; }

        public string? next { get; set; }

        public int offset { get; set; }

        public string? previous { get; set; }

        public int total { get; set; }

    }
}