using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTieSilincer.Support
{
    class RegisterMenu
    {
        public static void RegisterNewPlayer(string exceptionMessage="")
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.Clear();
            Console.CursorVisible = true;

            if (exceptionMessage != "")
            {

                Console.SetCursorPosition(30, 26);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(exceptionMessage);
                Console.ResetColor();
            }

            DrawBox(35, 8, 30, 14, '@');
            Console.SetCursorPosition(45, 10);
            Console.Write("Register");
            Console.SetCursorPosition(36, 12);
            Console.Write(new string('_', 28));
            Console.SetCursorPosition(37, 14);
            Console.Write($"Name:");
            Console.SetCursorPosition(37, 16);
            Console.Write($"Password:");
            Console.SetCursorPosition(36, 18);
            Console.Write(new string('_', 28));
            Console.SetCursorPosition(39, 20);
            Console.Write("Press enter to start!");

            Console.SetCursorPosition(43, 14);
            var name = Console.ReadLine().Trim();

            Console.SetCursorPosition(46, 16);
            var password = Console.ReadLine().Trim();

           

            Console.CursorVisible = false;
            GameService.CreateCharacter(name, password);
        }

        public static void LogIn(string exceptionMessage = "")
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.Clear();
            Console.CursorVisible = true;

            if (exceptionMessage != "")
            {

                Console.SetCursorPosition(30, 26);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(exceptionMessage);
                Console.ResetColor();
            }

            DrawBox(35, 8, 30, 14, '@');
            Console.SetCursorPosition(45, 10);
            Console.Write("LogIn");
            Console.SetCursorPosition(36, 12);
            Console.Write(new string('_', 28));
            Console.SetCursorPosition(37, 14);
            Console.Write($"Name:");
            Console.SetCursorPosition(37, 16);
            Console.Write($"Password:");
            Console.SetCursorPosition(36, 18);
            Console.Write(new string('_', 28));
            Console.SetCursorPosition(39, 20);
            Console.Write("Press enter to start!");

            Console.SetCursorPosition(43, 14);
            var name = Console.ReadLine().Trim();

            Console.SetCursorPosition(46, 16);
            var password = Console.ReadLine().Trim();
            
            Console.CursorVisible = false;
            GameService.CheckLogIn(name,password);

        }

        public static void LogInScreen(int selectedButton = 0)
        {
            Console.Clear();

            Console.SetCursorPosition(46, 5);
            Console.Write("Register");

            Console.SetCursorPosition(46, 10);
            Console.Write("LogIn");

            Console.SetCursorPosition(46, 15);
            Console.Write("Back");


            var consolecolor = ConsoleColor.Blue;
            if (selectedButton == 0)
            {
                DrawBox(41, 3, 18, 4, '#', consolecolor);
            }
            else
            {
                DrawBox(41, 3, 18, 4, '#');
            }
            if (selectedButton == 1)
            {
                DrawBox(41, 8, 18, 4, '#', consolecolor);
            }
            else
            {
                DrawBox(41, 8, 18, 4, '#');
            }
            if (selectedButton == 2)
            {
                DrawBox(41, 13, 18, 4, '#', consolecolor);
            }
            else
            {
                DrawBox(41, 13, 18, 4, '#');
            }
            Console.SetCursorPosition(0, 0);
        }


        private static void DrawBox(int col, int row, int width, int hight, char ch, ConsoleColor consolecolor = ConsoleColor.White)
        {
            Console.ForegroundColor = consolecolor;

            Console.SetCursorPosition(col, row);
            Console.Write(new string(ch, width));
            for (int i = 1; i < hight; i++)
            {
                Console.SetCursorPosition(col, row + i);
                Console.Write(ch);
            }
            Console.SetCursorPosition(col, row + hight);
            Console.Write(new string(ch, width));
            for (int i = 1; i < hight; i++)
            {
                Console.SetCursorPosition(col + width - 1, row + i);
                Console.Write(ch);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        
    }
}
