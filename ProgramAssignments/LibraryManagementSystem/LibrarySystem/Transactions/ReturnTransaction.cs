using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Transactions
{
    public class ReturnTransaction
    {
        public int Id { get; set; }
        public string BookName {  get; set; }
        public string Date {  get; set; }
        public ReturnTransaction(int id, string bookname, string date)
        {
            Id = id;
            BookName = bookname;
            Date = date;
        }
        public void Transactions()
        {
            Console.WriteLine($"Id : {Id}\nBook Name : {BookName}\nDate : {Date}");
        }
    }
}
