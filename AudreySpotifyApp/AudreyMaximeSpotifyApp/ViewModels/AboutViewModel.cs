﻿using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AudreySpotifyApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "À propos";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            InvertColorsCommand = new Command(() => MessagingCenter.Send(this, "InvertColors"));
            NavigateToAboutPageCommand = new Command(NavigateToAboutPage);
            NavigateToArtistPageCommand = new Command(async () => await Shell.Current.GoToAsync("/ArtistPage"));
            NavigateToAlbumPageCommand = new Command(async () => await Shell.Current.GoToAsync("/AlbumPage"));
            NavigateToPlaylistPageCommand = new Command(async () => await Shell.Current.GoToAsync("/PlaylistPage"));

        }
        
        private async void NavigateToAboutPage()
        {
            await Shell.Current.GoToAsync("/AboutPage");
        }

        private async void NavigateToArtistPage()
        {
            await Shell.Current.GoToAsync("/ArtistPage");
        }
        
        private async void NavigateToAlbumPage()
        {
            await Shell.Current.GoToAsync("/AlbumPage");
        }
        
        private async void NavigateToPlaylistPage()
        {
            await Shell.Current.GoToAsync("/PlaylistPage");
        }

        public ICommand OpenWebCommand { get; }
        public ICommand InvertColorsCommand { get; }
        public ICommand NavigateToAboutPageCommand { get; }
        public ICommand NavigateToArtistPageCommand { get; }
        public ICommand NavigateToAlbumPageCommand { get; }
        public ICommand NavigateToPlaylistPageCommand { get; }
        
    }
}