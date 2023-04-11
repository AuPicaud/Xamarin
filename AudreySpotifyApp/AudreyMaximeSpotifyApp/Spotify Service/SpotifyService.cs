using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace AudreySpotifyApp.Services
{
    public class SpotifyService
    {
        private static SpotifyClient _spotifyClient;

        public SpotifyService()
        {
            Task.Run(() => InitializeSpotifyClientAsync()).Wait();
        }

        private async Task InitializeSpotifyClientAsync()
        {
            string clientId = "clientid";
            string clientSecret = "idclietsecret";
            var token = await GetAccessTokenAsync(clientId, clientSecret);

            var config = SpotifyClientConfig.CreateDefault();
            _spotifyClient = new SpotifyClient(config.WithToken(token.AccessToken));
        }

        public async Task<FullArtist> GetArtistAsync(string artistId)
        {
            var artist = await _spotifyClient.Artists.Get(artistId);
            return artist;
        }
        
        public async Task<FullAlbum> GetAlbumAsync(string albumId)
        {
            var album = await _spotifyClient.Albums.Get(albumId);
            return album;
        }

        private async Task<ClientCredentialsTokenResponse> GetAccessTokenAsync(string clientId, string clientSecret)
        {
            var clientCredentials = new ClientCredentialsRequest(clientId, clientSecret);
            var token = await new OAuthClient().RequestToken(clientCredentials);
            return token;
        }
    }
}