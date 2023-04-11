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
    public partial class AlbumPage : ContentPage
    {
        private readonly AlbumViewModel _albumViewModel; 
        
        public AlbumPage()
        {
            InitializeComponent();
            _albumViewModel = new AlbumViewModel(new SpotifyService()); 
            BindingContext = _albumViewModel;
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _albumViewModel.LoadAlbumDataAsync(); 
        }
    }
}