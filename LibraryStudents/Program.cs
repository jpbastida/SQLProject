using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudents
{
    class Program
    {
        static bool exit = false;

        static void Main(string[] args)
        {
            Console.WindowWidth = 145;
            ConsoleKeyInfo optionMenu;

            try
            {
                do
                {
                    Console.WriteLine();
                    ShowMenu();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Enter option: ");
                    optionMenu = Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine();
                    Menu(optionMenu);
                } while (!exit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Menu(ConsoleKeyInfo optionMenu)
        {
            LibraryStudentsModels libraryModel = new LibraryStudentsModels();

            switch (optionMenu.Key)
            {
                case ConsoleKey.Escape:
                    Console.Clear();
                    return;
                case ConsoleKey.F1:
                    libraryModel.borrowBook();
                    break;
                case ConsoleKey.F2:
                    libraryModel.returnBook();
                    break;
                case ConsoleKey.F3:
                    libraryModel.borrowedBooks();
                    break;
                case ConsoleKey.F4:
                    libraryModel.historialList();
                    break;
                case ConsoleKey.F5:
                    exit = true;
                    Console.WriteLine("Exit...!");
                    break;
                default:
                    Console.WriteLine("Wrong option."); ;
                    break;
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("      ---- BOOKS ----");
            Console.Write(" F1 - Borrow a book | F2 - Return a book | F3 - Borrowed books | F4 - Historial | F5 -Exit ");
        }
    }
}
