// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using LibrarySystem;
using LibrarySystem.Books;
using LibrarySystem.Members;
using LibrarySystem.Transactions;

Console.WriteLine("\n=========Books===========");
Book book1 = new Book("The God of Small Things", "Arundhati Roy");
Book book2 = new Book("Wings of Fire", "A. P. J. Abdul Kalam");
int bookCount=Book.BookCount();
Console.WriteLine($"Total book count {bookCount}\t");

Console.WriteLine("Book Id\t\tBook Name\t\t\tAuther Name\n");
book1.BookDetails();
book2.BookDetails();

Journal journal1 = new Journal("Science Today", "National Science Foundation");
Journal journal2 = new Journal("Indian Literature Journal", "Sahitya Akademi");
int journalCount=Journal.JournalCount();
Console.WriteLine($"\nTotal journal count {journalCount}\t");

Console.WriteLine("Jounal Id\tJournal Name\t\t\tAuther Name\n");
journal1.JournalDetails();
journal2.JournalDetails();

Magazine magazine1 = new Magazine("National Geographic", "National Geographic Society");
Magazine magazine2 = new Magazine("Time", "Time USA, LLC");
int magazineCount=Magazine.MagazineCount();

Console.WriteLine($"\nTotal magazine count {magazineCount} \t");

Console.WriteLine("Magazine Id\tMagazine Name\t\t\tAuther Name\n");

magazine1.MagazineDetails();
magazine2.MagazineDetails();

Console.WriteLine("\n=========Memebrs===========");
Librarian librarian1 = new Librarian(1001, "Shinu");
librarian1.DisplayLibrarian();

Member member1 = new Member(2001, "Sonu");
member1.DisplayMember();



BorrowTransaction borrow1 = new BorrowTransaction(100, book1.Title, "20-10-2025");
ReturnTransaction return1 = new ReturnTransaction(200, book2.Title, "10-10-2025");
Console.WriteLine("\n=========Borrow Transaction===========");
borrow1.Transactions();
Console.WriteLine("\n=========Return Transaction===========");
return1.Transactions();



