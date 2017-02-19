using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace SQLProject
{
    class LibraryRepository : DbContext
    {
        internal List<Book> GetBooksListByYear(int year)
        {
            using (var contex = new LibraryEntities())
            {
                IQueryable<Book> query = contex.Books
                    .Where(b => b.Year == year)
                    .OrderBy(b => b.Id);

                return query.ToList();
            }
        }

        internal List<Book> GetBooksListByAuthor(string author)
        {
            using (var contex = new LibraryEntities())
            {
                IQueryable<Book> query = contex.Books
                    .Where(b => b.Author == author)
                    .OrderBy(b => b.Id);

                return query.ToList();
            }
        }

        internal List<Book> GetBooksList()
        {
            using (var contex = new LibraryEntities())
            {
                IQueryable<Book> query = contex.Books
                    .Where(b => b.InInventory == true)
                    .OrderBy(b => b.Id);

                return query.ToList();
            }
        }

        internal List<Book> GetBooksListByGenre(string genre)
        {
            using (var contex = new LibraryEntities())
            {
                IQueryable<Book> query = contex.Books
                    .Where(b => b.Genre == genre)
                    .OrderBy(b => b.Id);

                return query.ToList();
            }
        }

        internal void AddBook(Book book)
        {
            using (var contex = new LibraryEntities())
            {
                try
                {
                    contex.Books.Add(book);
                    contex.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }
        }

        internal void DeleteBook(int bookId)
        {
            using (var contex = new LibraryEntities())
            {
                var result = contex.Books.SingleOrDefault(b => b.Id == bookId);
                if (result != null)
                {
                    result.InInventory = false;
                    contex.SaveChanges();
                }
            }
        }
    }
}
