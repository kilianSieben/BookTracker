using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Booktracker
{
    public class ReadingStats
    {
        public int NumberOfBooks { get; set; }
        public int NumberOfPages { get; set; }
        public string ThickestBook { get; set; }
        public int PagesPerDay { get; set; }
        public int ReadingTime { get; set; }
        public string FavouriteAuthor { get; set; }
        public string FavouriteGenre { get; set; }
      


    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Analysis : ContentPage
	{
        public List<string> yearList;
		public Analysis ()
		{
			InitializeComponent ();
            FillListView();

		}

        public async void FillListView()
        {
            var analysis = new ReadingStats();
            var temp = await BookDatabase.Instance.GetBooksAsync();

            analysis.NumberOfBooks = temp.Count();
            analysis.NumberOfPages = temp.Sum(x => x.pages);
            analysis.ThickestBook = temp.OrderByDescending(x => x.pages).Select(f => f.title).First();

           
            int tempDays = (DateTime.Now.Date - temp.OrderBy(x => x.start).Select(f => f.start).First().Date).Days + 1;
            analysis.PagesPerDay = temp.Sum(x => x.pages) / tempDays;
            analysis.ReadingTime = temp.Sum(x => x.days);

            var autorGroups = temp.GroupBy(x => x.autor).Select(group => new { autor = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).First();
            analysis.FavouriteAuthor = autorGroups.autor;

            var genreGroups = temp.GroupBy(x => x.genre).Select(group => new { genre = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).First();
            analysis.FavouriteGenre = genreGroups.genre;

            BindingContext = analysis;

        }

    }
}