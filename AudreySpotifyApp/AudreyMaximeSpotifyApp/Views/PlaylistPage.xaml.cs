using AudreySpotifyApp.Services;
using AudreySpotifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AudreySpotifyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentPage
    {
        private readonly PlaylistViewModel _viewModel;

        public PlaylistPage()
        {
            InitializeComponent();
            _viewModel = new PlaylistViewModel(new SpotifyService());
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadPlaylistDataAsync();
        }
    }
}