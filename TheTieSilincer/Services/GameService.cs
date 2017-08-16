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
    using System.Data.Entity;
    using TheTieSilincer.Models;

    public class GameService
    {
        public static PlayerDbEntity currentPlayer = new PlayerDbEntity();

        public static void CreateCharacter(string name,string password)
        {
            using (var DbContext = new TheTieSilincerContext())
            {
                try
                {
                    PlayerDbEntity newPlayer = new PlayerDbEntity(name, password);
                    DbContext.Players.Add(newPlayer);

                    GameService.currentPlayer = newPlayer;

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

                   PlayerDbEntity Player = players.First();
                   GameService.currentPlayer = Player;

               }
                catch (CustomLogInException ex)
               {

                   RegisterMenu.LogIn(ex.Message);
                    
               }


           }
        }

        public static void SaveResultToDb(int points)
        {
            using (var DbContext = new TheTieSilincerContext())
            {
                Score score = new Score(points);
                
                score.PlayerDbId =currentPlayer.PlayerId;

                DbContext.Scores.Add(score);

                DbContext.SaveChanges();
                
            }


        }



        public static List<Score> GetNamesOfTop10Players()
       {
          
           using (var DbContext = new TheTieSilincerContext())
           {
              return DbContext
                   .Scores
               .Include(x => x.PlayerDb)
               .OrderByDescending(x => x.Points)
               .Take(10)
               .ToList();
               
           }

       }

       
   }
}

