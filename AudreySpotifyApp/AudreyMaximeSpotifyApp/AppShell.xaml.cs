using AudreySpotifyApp.ViewModels;
using AudreySpotifyApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AudreySpotifyApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ArtistPage), typeof(ArtistPage));
            Routing.RegisterRoute(nameof(AlbumPage), typeof(AlbumPage));
            Routing.RegisterRoute(nameof(PlaylistPage), typeof(PlaylistPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
