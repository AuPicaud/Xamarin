using System;
using Xamarin.Forms;

namespace AudreySpotifyApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            
        }
        
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            Console.WriteLine("Exception non gérée : " + exception?.Message);
        }
    }
}