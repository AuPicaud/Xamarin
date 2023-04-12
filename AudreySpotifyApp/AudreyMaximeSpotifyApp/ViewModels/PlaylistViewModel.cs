using AudreySpotifyApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using SpotifyAPI.Web;


namespace AudreySpotifyApp.ViewModels
{
    public class PlaylistViewModel : INotifyPropertyChanged
    {
        private readonly SpotifyService _spotifyService;

        private string _playlistName;
        private ImageSource _playlistImage;
        private string _ownerName;
        private ObservableCollection<string> _trackList;

        public PlaylistViewModel(SpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            LoadPlaylistDataCommand = new Command(async () => await LoadPlaylistDataAsync());
        }

        public string PlaylistName
        {
            get => _playlistName;
            set
            {
                _playlistName = value;
                OnPropertyChanged();
            }
        }

        public ImageSource PlaylistImage
        {
            get => _playlistImage;
            set
            {
                _playlistImage = value;
                OnPropertyChanged();
            }
        }

        public string OwnerName
        {
            get => _ownerName;
            set
            {
                _ownerName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> TrackList
        {
            get => _trackList;
            set
            {
                _trackList = value;
                OnPropertyChanged();
            }
        }

        public Command LoadPlaylistDataCommand { get; }

        public async Task LoadPlaylistDataAsync()
        {
            string playlistId = "6rqhFgbbKwnb9MLmUQDhG6"; 
            var playlist = await _spotifyService.GetPlaylistAsync(playlistId);

            PlaylistName = playlist.Name;
            PlaylistImage = ImageSource.FromUri(new Uri(playlist.Images[0].Url));
            OwnerName = playlist.Owner.DisplayName;

            TrackList = new ObservableCollection<string>();
            foreach (var playlistTrack in playlist.Tracks.Items)
            {
                if (playlistTrack.Track is FullTrack track)
                {
                    TrackList.Add(track.Name);
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
