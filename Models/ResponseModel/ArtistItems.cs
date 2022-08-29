namespace music_chat.Models.ResponseModel
{
    /// <summary>
    /// Represents an artist from artist search results
    /// </summary>
    public class ArtistItems : IItems
    {

        public ArtistItems()
        {
            this.images = null;
        }

        public string? id { get; set; }

        public string? href { get; set; }

        public string? popularity { get; set; }

        public string? name { get; set; }

        public string? uri { get; set; }

        public ImageItem[]? images { get; set; }

    }
}