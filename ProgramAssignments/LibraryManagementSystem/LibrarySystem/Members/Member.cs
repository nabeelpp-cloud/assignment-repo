using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Members
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Member(int id,string name) 
        {
            Id = id;
            Name = name;
        }
        public void DisplayMember()
        {
            Console.WriteLine($"\nId : {Id}\nName : {Name}");
        }
    }
}
