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
            string clientId = "clientId";
            string clientSecret = "clientSecret";
            var token = await GetAccessTokenAsync(clientId, clientSecret);

            var config = SpotifyClientConfig.CreateDefault();
            _spotifyClient = new SpotifyClient(config.WithToken(token.AccessToken));
        }
        
        public async Task<SearchResponse> SearchForTrackAsync(string trackName)
        {
            var searchRequest = new SearchRequest(SearchRequest.Types.Track, trackName);
            var searchResponse = await _spotifyClient.Search.Item(searchRequest);
            return searchResponse;
        }


        public async Task<FullArtist> GetArtistAsync(string artistId)
        {
            var artist = await _spotifyClient.Artists.Get(artistId);
            return artist;
        }
        
        public async Task<FullPlaylist> GetPlaylistAsync(string playlistId)
        {
            var playlist = await _spotifyClient.Playlists.Get(playlistId);
            return playlist;
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