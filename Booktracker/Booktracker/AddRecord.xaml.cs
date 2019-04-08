using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;

namespace Booktracker
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddRecord : ContentPage
	{
		public AddRecord ()
		{
			InitializeComponent ();
		}


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(titleEntry.Text) || string.IsNullOrWhiteSpace(autorEntry.Text) || string.IsNullOrWhiteSpace(pageEntry.Text) || genrePicker.SelectedIndex == -1)
            {           
                await DisplayAlert("Error", "Füllen Sie bitte jedes Feld aus!", "Ok");
                return;
            }

            var book = new Book
            {
                title = titleEntry.Text,
                autor = autorEntry.Text,
                pages = int.Parse(pageEntry.Text),
                genre = genrePicker.SelectedItem.ToString(),
                start = startDate.Date,
                end = endDate.Date,
                days = (endDate.Date - startDate.Date).Days + 1
            };

            var fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            book.startString = startDate.Date.ToString("d", fmt);
            book.endString = endDate.Date.ToString("d", fmt);

            await BookDatabase.Instance.SaveBookAsync(book);

            await Navigation.PopAsync();
         
        }

    }
}
