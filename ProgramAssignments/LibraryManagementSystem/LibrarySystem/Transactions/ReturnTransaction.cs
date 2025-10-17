using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Transactions
{
    public class ReturnTransaction
    {
        public int ID;
        public string BookName;
        public string Date;
        public ReturnTransaction(int id, string bookname, string date)
        {
            ID = id;
            BookName = bookname;
            Date = date;
        }
        public void Transactions()
        {
            Console.WriteLine($"Id : {ID}\nBook Name : {BookName}\nDate : {Date}");
        }
    }
}
