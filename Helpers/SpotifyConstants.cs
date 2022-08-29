using music_chat.Common;
using Newtonsoft.Json;

namespace music_chat.Helpers
{
    /// <summary>
    /// Contains helpers for Spotify Authentication and constants such as Spotify urls
    /// </summary>
    public static class SpotifyConstants
    {

        public static string[] scopes =
        {
"user-modify-playback-state",
"user-read-recently-played",
"user-read-playback-position",
"playlist-read-collaborative",
"app-remote-control",
"user-read-playback-state",
"user-read-email",
"streaming",
"user-top-read",
"playlist-modify-public",
"user-library-modify",
"user-follow-read",
"user-read-currently-playing",
"user-library-read",
"playlist-read-private",
"user-read-private",
"playlist-modify-private"
        };

        public static string clientID = "e183c30a8a7d43b4bb704a33f3f4182b";
        public static string clientSecret = "0352c6e9e78943eba1adc26e6ff27894";

        public static string redirect_uri = "https://ryan-riddiford.com/Spotify/Callback";

        public static string authUrl = "https://accounts.spotify.com/authorize";
        public static string tokenUrl = "https://accounts.spotify.com/api/token";
        public static string apiUrl = "https://api.spotify.com/v1/";

        public static string GetScope()
        {
            string scopeSelection = "";
            foreach(var scope in scopes)
            {
                scopeSelection += scope;

                if(!scope.Equals(scopes[scopes.Length - 1]))
                {
                    scopeSelection += " ";
                }
            }

            return scopeSelection;
        }

        public static string GetOAuthUri()
        {
            string uri = authUrl;

            uri += "?client_id=" + clientID;
            uri += "&redirect_uri=" + redirect_uri;
            uri += "&response_type=" + "code";
            uri += "&scope=" + GetScope();
            return uri;

        }

        public static async Task<SpotifyToken> GetAccessToken(string code)
        {

            SpotifyToken? token = null;

            var data = new[]
{
        new KeyValuePair<string, string>("code", code),
        new KeyValuePair<string, string>("client_id", clientID),
        new KeyValuePair<string, string>("client_secret", clientSecret),
        new KeyValuePair<string, string>("redirect_uri", redirect_uri),
        new KeyValuePair<string, string>("grant_type", "authorization_code"),

    };

            using(var client = new HttpClient())
            {

                var bytes = System.Text.Encoding.ASCII.GetBytes(clientID + ":" + clientSecret);

                var encodedBytes = System.Convert.ToBase64String(bytes);

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedBytes);

                var encodedData = new FormUrlEncodedContent(data);

                using(var response = await client.PostAsync(tokenUrl, encodedData))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        token = JsonConvert.DeserializeObject<SpotifyToken>(responseString)!;
                    }

                }

            }

            return token;

        }

    }
}