using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Booktracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookDetails : ContentPage
	{
        Book oneBook;
		public BookDetails(Book specificBook)
		{
            oneBook = specificBook;
            
			InitializeComponent ();
            listView.ItemsSource = new List<Book> { specificBook };
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Löschen?", "Möchten Sie diesen Eintrag löschen?", "Ja", "Nein");
            if (answer)
            {
                await BookDatabase.Instance.DeleteBookAsync(oneBook);
                await Navigation.PopAsync();
            }
            else
            {
                return;
            }
        }
    }
}