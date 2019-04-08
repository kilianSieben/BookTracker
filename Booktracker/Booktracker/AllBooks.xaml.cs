using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Booktracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllBooks : ContentPage
	{
		public AllBooks ()
		{
			InitializeComponent ();
            filterPicker.ItemsSource = new List<string>
            {
                Constants.readingDateAscending,
                Constants.readingDateDescending,
                Constants.numberOfPagesAscending,
                Constants.numberOfPagesDescending,
                Constants.genre,
                Constants.autor,
                Constants.title,
                Constants.readingTimeAscending,
                Constants.readingTimeDescending,


            };
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView2.ItemsSource = await BookDatabase.Instance.GetBooksAsync();

            if(filterPicker.SelectedIndex != -1)
            {
                FilterAction();
            }
        }

        private async void OnBookTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            var selectedItem = e.Item as Book;
            await Navigation.PushAsync(new BookDetails(selectedItem));
            
        }

        private async void FilterAction()
        {
            var temp = await BookDatabase.Instance.GetBooksAsync();
            if (filterPicker.SelectedItem.ToString() == Constants.readingDateAscending)
            {

                listView2.ItemsSource = temp.OrderBy(w => w.end);
            }
            if (filterPicker.SelectedItem.ToString() == Constants.readingDateDescending)
            {

                listView2.ItemsSource = temp.OrderByDescending(w => w.end);
            }
            if (filterPicker.SelectedItem.ToString() == Constants.numberOfPagesAscending)
            {

                listView2.ItemsSource = temp.OrderBy(w => w.pages);
            }
            if (filterPicker.SelectedItem.ToString() == Constants.numberOfPagesDescending)
            {

                listView2.ItemsSource = temp.OrderByDescending(w => w.pages);
            }
            if (filterPicker.SelectedItem.ToString() == Constants.genre)
            {

                listView2.ItemsSource = temp.OrderBy(w => w.genre);
            }
            if (filterPicker.SelectedItem.ToString() == Constants.autor)
            {

                listView2.ItemsSource = temp.OrderBy(w => w.autor);
            }
            if (filterPicker.SelectedItem.ToString() == Constants.title)
            {

                listView2.ItemsSource = temp.OrderBy(w => w.title);
            }
            if (filterPicker.SelectedItem.ToString() == Constants.readingTimeAscending)
            {

                listView2.ItemsSource = temp.OrderBy(w => w.days);
            }
            if (filterPicker.SelectedItem.ToString() == Constants.readingTimeDescending)
            {

                listView2.ItemsSource = temp.OrderByDescending(w => w.days);
            }

        }


        private void OnSelectedPickerItemChanged(object sender, EventArgs e)
        {
            FilterAction();
        }
    }
}