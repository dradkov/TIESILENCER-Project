namespace TheTieSilincer.Support
{
    using System;

    public static class WelcomeMenu
    {
        public static void WelcomeScreen(int selectedButton = 0)
        {
            Console.Clear();
            Console.SetCursorPosition(46, 5);
            Console.Write("NEW GAME");

            Console.SetCursorPosition(46, 10);
            Console.Write("CREDITS");

            Console.SetCursorPosition(47, 15);
            Console.Write("SCORES");

            Console.SetCursorPosition(48, 20);
            Console.Write("EXIT");

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
            if (selectedButton == 3)
            {
                DrawBox(41, 18, 18, 4, '#', consolecolor);
            }
            else
            {
                DrawBox(41, 18, 18, 4, '#');
            }
            Console.SetCursorPosition(0, 0);
        }

        public static void Scores()
        {
            Console.Clear();
            Console.CursorVisible = false;



            GameService.GetNamesOfPlayers();

            var test = Console.ReadLine().Trim();
        }

        public static void LogIn()
        {

            Console.Clear();
            Console.CursorVisible = true;
            Console.Clear();
            Console.CursorVisible = true;
            DrawBox(35, 10, 30, 10, '@');
            Console.SetCursorPosition(45, 12);
            Console.Write("HERO NAME:");
            Console.SetCursorPosition(36, 15);
            Console.Write(new string('_', 28));
            Console.SetCursorPosition(39, 17);
            Console.Write("Press enter to start!");
            Console.SetCursorPosition(37, 14);
            var name = Console.ReadLine().Trim();
            var password = Console.ReadLine().Trim();

            Console.CursorVisible = false;
            GameService.CreateCharacter(name, "pass");
        }


       
        public static void Credits()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(45, 12);
            Console.Write("Yordan Karparov");
            Console.SetCursorPosition(45, 14);
            Console.Write("Valentin Parvanov");
            Console.SetCursorPosition(45, 16);
            Console.Write("Kristian Dimitrov");
            Console.SetCursorPosition(45, 18);
            Console.WriteLine("Dimitar Radkov");
            var test = Console.ReadLine().Trim();


        }

        public static void ShowHighscores()
        {
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