using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace LibraryStudents
{
    internal class LibraryStudentsModels
    {
        private static void ShowAllBooks()
        {
            LibraryStudentsRepository repository = new LibraryStudentsRepository();
            var booksList = repository.GetBooksList();

            foreach (var book in booksList)
            {
                Console.WriteLine($" {book.Id} \t{book.Title}   \t{book.Year} \t{book.Author}");
            }
            Console.WriteLine();
        }

        internal void borrowBook()
        {
            ShowAllBooks();
            Console.WriteLine();
            Console.WriteLine("Select a book to borrow...");
            Console.WriteLine();
            Console.Write("Enter your name: ");
            string studentName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter Book's ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            LibraryStudentsRepository repository = new LibraryStudentsRepository();
            repository.BorrowBook(id, studentName);
            Console.WriteLine($"Book No. {id} is borrowed by {studentName}.");
            Console.WriteLine();
        }

        internal void returnBook()
        {
            Console.WriteLine();
            Console.Write("Enter your name: ");
            string studentName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Borrowed books by {studentName}...");
            LibraryStudentsRepository repository = new LibraryStudentsRepository();
            var booksList = repository.BorrowedBookByStudent(studentName);
            Console.WriteLine();
            foreach (var book in booksList)
            {
                Console.WriteLine($" {book.Id} \t{book.Title}   \t{book.Year} \t{book.Author}");
            }
            Console.WriteLine();
            Console.Write("Enter Book's ID to return: ");
            int id = int.Parse(Console.ReadLine());
            repository.returnBook(id, studentName);
            Console.WriteLine();
            Console.WriteLine($"Book is returned.");
            Console.WriteLine();
        }

        internal void historialList()
        {
            Console.WriteLine();
            Console.WriteLine($"Historial list...");
            LibraryStudentsRepository repository = new LibraryStudentsRepository();
            var historialList = repository.GetHistorialList();
            Console.WriteLine();
            foreach (var book in historialList)
            {
                Console.WriteLine($" {book.BookId} \t{book.Title} \t\t{book.Genre} \t\t{book.Year} \t{book.Author} \tBorroed by: {book.StudentName} \tTotal time: {book.TotalTimeBorrowed}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        internal void borrowedBooks()
        {
            Console.WriteLine();
            Console.WriteLine($"Borrowed books list...");
            LibraryStudentsRepository repository = new LibraryStudentsRepository();
            var booksList = repository.GetBorrowedBooksList();
            Console.WriteLine();
            foreach (var book in booksList)
            {
                Console.WriteLine($" {book.Id} \t{book.Title}   \t{book.Year} \t{book.Author}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}