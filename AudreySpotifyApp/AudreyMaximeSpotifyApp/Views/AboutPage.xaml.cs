using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AudreySpotifyApp.ViewModels;

namespace AudreySpotifyApp.Views
{
    public partial class AboutPage : ContentPage
    {
        private AboutViewModel _viewModel;

        public AboutPage()
        {
            InitializeComponent();

            _viewModel = new AboutViewModel();
            BindingContext = new AboutViewModel();


            FillColorGrid();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AboutViewModel>(this, "InvertColors", sender => InvertColorGrid());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AboutViewModel>(this, "InvertColors");
        }

        private void FillColorGrid()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Color color;

                    if (row < 2)
                    {
                        color = (row + col) % 2 == 0 ? Color.FromHex("08b92d") : Color.White;
                    }
                    else
                    {
                        color = (row + col) % 2 == 0 ? Color.FromHex("11dff0") : Color.White;
                    }

                    var box = new BoxView { Color = color };
                    ColorGrid.Children.Add(box, col, row);
                }
            }
        }

        private void InvertColorGrid()
        {
            foreach (var child in ColorGrid.Children)
            {
                if (child is BoxView box)
                {
                    if (box.Color == Color.FromHex("11dff0"))
                    {
                        box.Color = Color.FromHex("08b92d");
                    }
                    else if (box.Color == Color.FromHex("08b92d"))
                    {
                        box.Color = Color.FromHex("11dff0");
                    }
                }
            }
        }
    }
}
