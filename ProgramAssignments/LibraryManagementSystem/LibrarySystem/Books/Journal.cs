using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Books
{
    public class Journal
    {
        public static int _id = 200;
        public string JournalId;
        public string Title;
        public string AutherName;
        public Journal(string title, string authName)
        {
            JournalId = "Journal " + _id;
            _id = _id + 1;
            Title = title;
            AutherName = authName;
        }
        public static int JournalCount()
        {
            return _id - 99;
        }
        public void JournalDetails()
        {
            Console.WriteLine($"{JournalId}\t{Title}\t\t{AutherName}");
        }
    }
}
