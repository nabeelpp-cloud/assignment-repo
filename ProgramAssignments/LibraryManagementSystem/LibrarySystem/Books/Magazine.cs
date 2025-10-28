using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Books
{
    public class Magazine
    {
        public static int _id = 300;
        public string MagazineId;
        public string Title;
        public string AutherName;
        public Magazine(string title, string authName)
        {
            MagazineId = "Magazine " + _id;
            _id = _id + 1;
            Title = title;
            AutherName = authName;
        }
        public static int MagazineCount()
        {
            return _id - 99;
        }
        public void MagazineDetails()
        {
            Console.WriteLine($"{MagazineId}\t{Title}\t\t{AutherName}");
        }
    }
}
