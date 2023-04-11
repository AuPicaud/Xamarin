using AudreySpotifyApp.ViewModels;
using AudreySpotifyApp.Services;
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
    public partial class ArtistPage : ContentPage
    {
        private readonly ArtistViewModel _viewModel;

        public ArtistPage()
        {
            InitializeComponent();
            _viewModel = new ArtistViewModel(new SpotifyService());
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadArtistDataAsync();
        }
    }
}