using AudreySpotifyApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace AudreySpotifyApp.ViewModels
{
    public class AlbumViewModel : INotifyPropertyChanged
    {
        private readonly SpotifyService _spotifyService;

        private string _albumName;
        private ImageSource _albumImage;
        private string _artistName;
        private string _releaseDate;
        private ObservableCollection<string> _trackList;

        public AlbumViewModel(SpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            LoadAlbumDataCommand = new Command(async () => await LoadAlbumDataAsync());
        }

        public string AlbumName
        {
            get => _albumName;
            set
            {
                _albumName = value;
                OnPropertyChanged();
            }
        }

        public ImageSource AlbumImage
        {
            get => _albumImage;
            set
            {
                _albumImage = value;
                OnPropertyChanged();
            }
        }

        public string ArtistName
        {
            get => _artistName;
            set
            {
                _artistName = value;
                OnPropertyChanged();
            }
        }

        public string ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
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

        public Command LoadAlbumDataCommand { get; }

        public async Task LoadAlbumDataAsync()
        {
            string albumId = "2fenSS68JI1h4Fo296JfGr"; 
            var album = await _spotifyService.GetAlbumAsync(albumId);

            AlbumName = album.Name;
            AlbumImage = ImageSource.FromUri(new Uri(album.Images[0].Url));
            ArtistName = album.Artists[0].Name;
            ReleaseDate = album.ReleaseDate;

            TrackList = new ObservableCollection<string>();
            foreach (var track in album.Tracks.Items)
            {
                TrackList.Add(track.Name);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
