using System;
using SQLite;

namespace Booktracker
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string title { get; set; }
        public string autor { get; set; }
        public int pages { get; set; }
        public string genre { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int days { get; set; }
        public string startString { get; set; }
        public string endString { get; set; }
    }
}
