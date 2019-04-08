using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.IO;


namespace Booktracker
{
    public sealed class BookDatabase
    {
        private static readonly BookDatabase instance = new BookDatabase();
        readonly SQLiteAsyncConnection _database;


        static BookDatabase()
        {

        }

        private BookDatabase()
        {
            _database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Books.db3"));
            _database.CreateTableAsync<Book>().Wait();
        }

        public static BookDatabase Instance
        {
            get
            {
                return instance;
            }
        }

        public Task<List<Book>> GetBooksAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }




        public Task<Book> GetBookAsync(int id)
        {
            return _database.Table<Book>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveBookAsync(Book entry)
        {
            if (entry.ID != 0)
            {
                return _database.UpdateAsync(entry);
            }
            else
            {
                return _database.InsertAsync(entry);
            }


        }

        public Task<int> DeleteBookAsync(Book entry)
        {
            return _database.DeleteAsync(entry);
        }
    }
}
