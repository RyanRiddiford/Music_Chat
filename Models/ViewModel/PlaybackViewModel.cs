using music_chat.Models.ResponseModel;
using Newtonsoft.Json;

namespace music_chat.Models.ViewModel
{
    /// <summary>
    /// Spotify page view data
    /// </summary>
    public class PlaybackViewModel
    {

        [JsonProperty("tracks")]
        public TrackSearchResults? TrackSearchResults { get; set; }

        [JsonProperty("artists")]
        public ArtistSearchResults? ArtistSearchResults { get; set; }

        [JsonProperty("albums")]
        public AlbumSearchResults? AlbumSearchResults { get; set; }

        public string? accessToken { get; set; }

        public string? resultsType { get; set; }

    }
}