using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLProject
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
            LibraryModels libraryModel = new LibraryModels();
            switch (optionMenu.Key)
            {
                case ConsoleKey.Escape:
                    Console.Clear();
                        return;
                case ConsoleKey.F1:
                    libraryModel.ShowAllBooks();
                    break;
                case ConsoleKey.F2:
                    libraryModel.SearchByAuthor();
                    break;
                case ConsoleKey.F3:
                    libraryModel.SearchByYear();
                    break;
                case ConsoleKey.F4:
                    libraryModel.SearchByGenre();
                    break;
                case ConsoleKey.F5:
                    libraryModel.AddBook();
                    break;
                case ConsoleKey.F6:
                    libraryModel.DeleteBook();
                    break;
                case ConsoleKey.F7:
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
            Console.Write(" F1 - Show Books' List | F2 - Search by Author | F3 - Search by Year | F4 - Search by Genre | F5 - Add Book | F6 - Erase Book | F7 - Exit   ");
        }
    }
}
