using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Books
{
    public class Book
    {
        public static int _id = 100;
        public string BookId;
        public string Title;
        public string AutherName;
        public Book(string title,string authName) 
        {
            BookId = "Book " + _id;
            _id = _id + 1;
            Title = title;
            AutherName = authName;
        }
        public static int BookCount()
        {
            return _id-99;
        }
        public void BookDetails()
        {
            Console.WriteLine($"{BookId}\t{Title}\t\t{AutherName}");
        }
    }
}
