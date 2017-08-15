using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Exceptions;
using TheTieSilincer.Models;

namespace TheTieSilincer.Support
{
    using TheTieSilincer.Models;

    public class GameService
   {
       

        public static void CreateCharacter(string name,string password)
        {
            using (var DbContext = new TheTieSilincerContext())
            {
                try
                {
                    PlayerDbEntity newPlayer = new PlayerDbEntity(name, password);
                    DbContext.Players.Add(newPlayer);

                    DbContext.SaveChanges();
                }
                catch (CustomRegisterException ex)
                {
                    
                    RegisterMenu.RegisterNewPlayer(ex.Message);

                }


            }

        }

       public static void CheckLogIn(string name, string password)
       {
           using (var DbContext = new TheTieSilincerContext())
           {
               var players = DbContext
                    .Players
                    .Where(x => x.Name == name && x.Password == password);

               try
               {
                   if (players.Count() == 0)
                   {
                       throw new InvalidNameAndPasswordMatchException();
                   }

                   PlayerDbEntity newPlayer = DbContext.Players.Where(x => x.Name == name && x.Password == password).First();

                }
                catch (CustomLogInException ex)
               {

                   RegisterMenu.LogIn(ex.Message);
                    
               }


           }
        }



        public static void GetNamesOfPlayers()
       {
           int num = 1;
           using (var DbContext = new TheTieSilincerContext())
           {
               Console.SetCursorPosition(5, 0);
                foreach (var player in DbContext.Players
                    .OrderByDescending(x=>x.Points)
                    .Take(10))
               {
                   Console.WriteLine($"{num}.{player.Name} - {player.Name}");
                   Console.SetCursorPosition(5,num);
                    num++;
               }


           }

       }

       
   }
}

