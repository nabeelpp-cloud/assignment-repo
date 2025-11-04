using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Books
{
    public class Journal
    {
        private static string _idPrefix;
        private static int _initialId;
        private static int _id;
        public string JournalId {  get; set; }
        public string Title {  get; set; }
        public string AuthorName {  get; set; }
        static Journal()
        {
            _initialId = 0;
            _idPrefix = "Journal_";
            _id = _initialId;
        }
        public Journal(string title, string authName)
        {
            JournalId = _idPrefix + _id;
            _id = _id + 1;
            Title = title;
            AuthorName = authName;
        }
        public static int JournalCount()
        {
            return _id - (_initialId-1);
        }
        public void JournalDetails()
        {
            Console.WriteLine($"{JournalId}\t{Title}\t\t{AuthorName}");
        }
    }
}
