using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Books
{
    public class Book
    {
        private static string _idPrefix;
        private static int _initialId;
        private static int _id;
        public string BookId { get; set; }
        public string Title {  get; set; }
        public string AuthorName { get; set; }

        static Book()
        {
            _idPrefix = "Book_";
            _initialId = 0;
            _id = _initialId;
        }
        public Book(string title,string authName) 
        {
            BookId = _idPrefix + _id;
            _id = _id + 1;
            Title = title;
            AuthorName = authName;
        }
        public static int BookCount()
        {
            return _id-(_initialId-1);
        }
        public void BookDetails()
        {
            Console.WriteLine($"{BookId}\t\t{Title}\t\t{AuthorName}");
        }
    }
}
