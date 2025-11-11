using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BasicArrayListOperations
{
    public class ListOfCustomObjects
    {
        public void Question4()
        {
            //1.Create a class Book with properties: Title, Author, and Price.
            //2. Create a List<Book> and add at least 3 books.
            //3. Display all book details. 
            //4. Find and display the book with the highest price.
            //5. Remove a book by title.
            Book book1 = new Book("Kayar","Thakazhi",499.99);
            Book book2 = new Book("ABC", "EFG", 111.11);
            Book book3 = new Book("XYZ", "RRR", 190.90);
            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            Console.WriteLine("All books Details : \n");
            foreach (Book book in books) 
            {
                Console.WriteLine($"Title : {book.Title}");
                Console.WriteLine($"Author : {book.Author}");
                Console.WriteLine($"Price : {book.Price}");
                Console.WriteLine();
            }
            Console.WriteLine();


            var highestPrice = books.Max(x=>x.Price);
            var highestPricedBook= books.FirstOrDefault(x=>x.Price==highestPrice);
            if(highestPricedBook != null)
            {
                Console.WriteLine($"Highest Priced Book");
                Console.WriteLine($"Title : {highestPricedBook.Title}");
                Console.WriteLine($"Author : {highestPricedBook.Author}");
                Console.WriteLine($"Price : {highestPricedBook.Price}");
                Console.WriteLine();
            }

            books.Remove(books.FirstOrDefault(x=>x.Title=="Kayar"));
            Console.WriteLine();
            Console.WriteLine("After delting Kayar All books Details : \n");
            foreach (Book book in books)
            {
                Console.WriteLine($"Title : {book.Title}");
                Console.WriteLine($"Author : {book.Author}");
                Console.WriteLine($"Price : {book.Price}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    public class Book()
    {
        public string Title;
        public string Author;

        public double Price;

        public Book(string title, string author, double price):this()
        {
            Title = title;
            Author = author;
            Price = price;
        }
    }

}
