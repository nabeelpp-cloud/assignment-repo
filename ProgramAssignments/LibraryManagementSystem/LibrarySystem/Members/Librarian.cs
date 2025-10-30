using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Members
{
    public class Librarian
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Librarian(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void DisplayLibrarian()
        {
            Console.WriteLine($"\nId : {Id}\nName : {Name}");
        }
    }
}
