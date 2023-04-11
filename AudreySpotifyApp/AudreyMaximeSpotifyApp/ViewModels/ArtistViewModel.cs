using AudreySpotifyApp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
    
namespace AudreySpotifyApp.ViewModels
{
    public class ArtistViewModel : INotifyPropertyChanged
    {
        private readonly SpotifyService _spotifyService;
        private string _artistName;
        private ImageSource _artistImage;
        private string _artistGenres;
        private int _artistFollowers;
        private int _artistPopularity;

        public ArtistViewModel(SpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            LoadArtistDataCommand = new Command(async () => await LoadArtistDataAsync());
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

        public ImageSource ArtistImage
        {
            get => _artistImage;
            set
            {
                _artistImage = value;
                OnPropertyChanged();
            }
        }

        public string ArtistGenres
        {
            get => _artistGenres;
            set
            {
                _artistGenres = value;
                OnPropertyChanged();
            }
        }

        public int ArtistFollowers
        {
            get => _artistFollowers;
            set
            {
                _artistFollowers = value;
                OnPropertyChanged();
            }
        }

        public int ArtistPopularity
        {
            get => _artistPopularity;
            set
            {
                _artistPopularity = value;
                OnPropertyChanged();
            }
        }

        public Command LoadArtistDataCommand { get; }

        public async Task LoadArtistDataAsync()
        {
            string artistId = "4gzpq5DPGxSnKTe4SA8HAU";
            var artist = await _spotifyService.GetArtistAsync(artistId);
            ArtistName = artist.Name;
            ArtistImage = ImageSource.FromUri(new Uri(artist.Images[0].Url));
            ArtistGenres = string.Join(", ", artist.Genres);
            ArtistFollowers = artist.Followers.Total;
            ArtistPopularity = artist.Popularity;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
