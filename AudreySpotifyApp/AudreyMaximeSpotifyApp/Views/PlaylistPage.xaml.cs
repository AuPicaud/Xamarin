using AudreySpotifyApp.Services;
using AudreySpotifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SpotifyAPI.Web;

namespace AudreySpotifyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentPage
    {
        private readonly PlaylistViewModel _viewModel;
        private readonly SpotifyService _spotifyService;

        public PlaylistPage()
        {
            InitializeComponent();
            _spotifyService = new SpotifyService();
            _viewModel = new PlaylistViewModel(_spotifyService);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadPlaylistDataAsync();
        }

        private async void OnTrackTapped(object sender, ItemTappedEventArgs e)
        {
            var trackName = e.Item as string;
            if (string.IsNullOrEmpty(trackName))
                return;

            var searchResponse = await _spotifyService.SearchForTrackAsync(trackName);
            if (searchResponse.Tracks.Items.Count > 0)
            {
                var track = searchResponse.Tracks.Items[0];
                var uri = new Uri(track.ExternalUrls["spotify"]);
                await Launcher.OpenAsync(uri);
            }
        }



    }
}