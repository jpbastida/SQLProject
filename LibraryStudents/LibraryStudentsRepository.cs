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
    internal class LibraryStudentsRepository
    {
        internal List<Book> GetBooksList()
        {
            using (var contex = new LibraryEntities())
            {
                IQueryable<Book> result = (from b in contex.Books
                                           join bb in contex.BorrowedBooks on b.Id equals bb.BookId
                                           where bb.IsBorrowed == false
                                           select b
                                           ).Distinct();
                return result.ToList();
            }
        }

        internal List<Book> GetBorrowedBooksList()
        {
            using (var contex = new LibraryEntities())
            {
                IQueryable<Book> result = (from b in contex.Books
                                           join bb in contex.BorrowedBooks on b.Id equals bb.BookId
                                           where bb.IsBorrowed == true
                                           select b
                                           );
                return result.ToList();
            }
        }

        internal void BorrowBook(int id, string studentName)
        {
            using (var contex = new LibraryEntities())
            {
                var studentExist = contex.Students.SingleOrDefault(s => s.Name == studentName);
                if (studentExist == null)
                {
                    addStudent(studentName);
                }

                registerBorrowBook(id, studentName);
            }
        }

        private void registerBorrowBook(int bookId, string studentName)
        {
            using (var contex = new LibraryEntities())
            {
                var result = contex.Books.SingleOrDefault(b => b.Id == bookId);
                if (result != null)
                {
                    result.BorrowedTimes++;
                    contex.SaveChanges();
                }

                var student = contex.Students.SingleOrDefault(s => s.Name == studentName);
                addBorrowedBookRegister(bookId, student.Id);
            }
        }

        internal List<Book> BorrowedBookByStudent(string studentName)
        {
            using (var contex = new LibraryEntities())
            {
                IQueryable<Book> result = (from b in contex.Books
                                           join bb in contex.BorrowedBooks on b.Id equals bb.BookId
                                           join s in contex.Students on bb.StudentId equals s.Id
                                           where (s.Name == studentName && bb.IsBorrowed == true)
                                           select b
                                           );
                return result.ToList();
            }
        }

        internal List<HistorialInfo> GetHistorialList()
        {
            using (var contex = new LibraryEntities())
            {
                IQueryable<HistorialInfo> result = (from b in contex.Books
                                           join bb in contex.BorrowedBooks on b.Id equals bb.BookId
                                           join s in contex.Students on bb.StudentId equals s.Id
                                           select new HistorialInfo {
                                               BookId = b.Id,
                                               Title = b.Title,
                                               Author = b.Author,
                                               Genre = b.Genre,
                                               Year = (int)b.Year,
                                               StudentName = s.Name,
                                               TotalTimeBorrowed = (int)b.BorrowedTimes
                                           });
                return result.ToList();
            }
        }

        internal void returnBook(int bookId, string student)
        {
            using (var contex = new LibraryEntities())
            {
                var result = contex.BorrowedBooks.SingleOrDefault(bb => bb.BookId == bookId && bb.IsBorrowed == true);
                if (result != null)
                {
                    result.IsBorrowed = false;
                    contex.SaveChanges();
                }
            }
        }

        private void addBorrowedBookRegister(int bookId, int studentId)
        {
            BorrowedBook borrowBookResgister = new BorrowedBook()
            { BookId = bookId, StudentId = studentId, IsBorrowed = true };

            using (var contex = new LibraryEntities())
            {
                contex.BorrowedBooks.Add(borrowBookResgister);
                contex.SaveChanges();
            }
        }

        private void addStudent(string student)
        {
            using (var contex = new LibraryEntities())
            {
                Student newStudent = new Student() { Name = student };

                try
                {
                    contex.Students.Add(newStudent);
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
    }
}