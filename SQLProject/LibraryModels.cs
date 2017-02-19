using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProject
{
    class LibraryModels
    {
        internal void AddBook()
        {
            Book book = new Book();
            Console.WriteLine("Adding New Book...");
            Console.WriteLine();
            Console.Write("Enter Book's Title: ");
            book.Title = Console.ReadLine();
            Console.Write("Enter Book's Author: ");
            book.Author = Console.ReadLine();
            Console.Write("Enter Book's Genre: ");
            book.Genre = Console.ReadLine();
            Console.Write("Enter Book's Year: ");
            book.Year = int.Parse(Console.ReadLine());
            book.InInventory = true;
            book.BorrowedTimes = 0;
            LibraryRepository repository = new LibraryRepository();
            repository.AddBook(book);
            Console.WriteLine("Book added.");
            Console.WriteLine();
        }

        internal void DeleteBook()
        {
            Console.WriteLine("Deleting a Book...");
            Console.WriteLine();
            Console.Write("Enter Book's ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            LibraryRepository repository = new LibraryRepository();
            repository.DeleteBook(id);
            Console.WriteLine($"Book No. {id} is deleted.");
            Console.WriteLine();
        }

        internal void SearchByAuthor()
        {
            Console.WriteLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.WriteLine();
            LibraryRepository repository = new LibraryRepository();
            var booksByAuthor = repository.GetBooksListByAuthor(author);

            foreach (var book in booksByAuthor)
            {
                Console.WriteLine($" {book.Id} \t{book.Title}   \t{book.Year} \t{book.Author}");
            }
            Console.WriteLine();
        }

        internal void ShowAllBooks()
        {
            LibraryRepository repository = new LibraryRepository();
            var booksList = repository.GetBooksList();

            foreach (var book in booksList)
            {
                Console.WriteLine($" {book.Id} \t{book.Title}   \t{book.Year} \t{book.Author}");
            }
            Console.WriteLine();
        }

        internal void SearchByYear()
        {
            Console.WriteLine();
            Console.Write("Enter Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine();
            LibraryRepository repository = new LibraryRepository();
            var booksByYear = repository.GetBooksListByYear(year);

            foreach (var book in booksByYear)
            {
                Console.WriteLine($" {book.Id} \t{book.Title}   \t{book.Year} \t{book.Author}"); ;
            }
            Console.WriteLine();
        }

        internal void SearchByGenre()
        {
            Console.WriteLine();
            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();
            Console.WriteLine();
            LibraryRepository repository = new LibraryRepository();
            var booksByGenre = repository.GetBooksListByGenre(genre);

            foreach (var book in booksByGenre)
            {
                Console.WriteLine($" {book.Id} \t{book.Title}   \t{book.Year} \t{book.Author}");
            }
            Console.WriteLine();
        }
    }
}
