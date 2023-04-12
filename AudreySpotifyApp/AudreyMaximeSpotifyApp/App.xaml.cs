using System;
using Xamarin.Forms;

namespace AudreySpotifyApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            var icon = ImageSource.FromResource("AudreySpotifyApp.Android\\Resources\\drawable\\LogoMusic.png");
            MainPage = new AppShell();
            MainPage.IconImageSource = icon;

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }
        
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            Console.WriteLine("Exception non gérée : " + exception?.Message);
        }
    }
}
