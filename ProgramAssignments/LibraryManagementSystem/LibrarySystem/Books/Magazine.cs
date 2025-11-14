using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Books
{
    public class Magazine
    {
        private static string _idPrefix ;
        private static int _initialId;
        private static int _id;
        public string MagazineId {  get; set; }
        public string Title {  get; set; }
        public string AuthorName {  get; set; }
        static Magazine()
        {
            _idPrefix = "Magazine_";
            _initialId = 0;
            _id = _initialId;
        }
        public Magazine(string title, string authName)
        {
            MagazineId = _idPrefix + _id;
            _id = _id + 1;
            Title = title;
            AuthorName = authName;
        }
        public static int MagazineCount()
        {
            return _id - ( _initialId - 1);
        }
        public void MagazineDetails()
        {
            Console.WriteLine($"{MagazineId}\t{Title}\t\t{AuthorName}");
        }
    }
}
