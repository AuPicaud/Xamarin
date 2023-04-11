using System;
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

        }

        public ICommand OpenWebCommand { get; }
        public ICommand InvertColorsCommand { get; }
        
        
    }
}