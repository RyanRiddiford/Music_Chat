namespace music_chat.Models.ResponseModel
{
    /// <summary>
    /// Represents a track from track search results
    /// </summary>
    public class TrackItems : IItems
    {

        public string? id { get; set; }

        public int duration_ms { get; set; }

        public string? href { get; set; }

        public string? uri { get; set; }

        public string? context_uri { get; set; }

        public string? name { get; set; }

        public ArtistItems[]? artists { get; set; }

        public AlbumItems? album { get; set; }

    }
}