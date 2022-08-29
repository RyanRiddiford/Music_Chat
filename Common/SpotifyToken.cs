namespace music_chat.Common
{

    /// <summary>
    /// Model for OAuth2 token provided by Spotify
    /// </summary>
    public class SpotifyToken
    {
        public string? access_token { get; set; }

        public string? token_type { get; set; }

        public string? expires_in { get; set; }

        public string? scope { get; set; }

        public string? refresh_token { get; set; }
    }
}