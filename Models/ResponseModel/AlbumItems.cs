namespace music_chat.Models.ResponseModel
{

    /// <summary>
    /// Represents an album from album search results
    /// </summary>
    public class AlbumItems : IItems
    {

        public string? href { get; set; }

        public ArtistItems[]? artists { get; set; }

        public string? uri { get; set; }

        public string? name { get; set; }

        public string? id { get; set; }

        public ImageItem[]? images { get; set; }

        public string? context_uri { get; set; }

    }
}