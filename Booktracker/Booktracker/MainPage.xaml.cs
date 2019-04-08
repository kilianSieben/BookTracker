using System;
using Xamarin.Forms;

namespace Booktracker
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNeuerEintragClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecord());
        }

        private async void OnÜbersichtClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllBooks());
        }

        private async void OnAuswertungClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Analysis());
        }





    }
}
