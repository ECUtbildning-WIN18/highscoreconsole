using System;
using System.Collections.Generic;
using System.Linq;
using HighscoreConsole.Entities;

namespace HighscoreConsole.Services
{
    public class FakeScoreService
    {
        private static readonly IEnumerable<Score> Scores = GenerateFakeData();

        public static IEnumerable<Score> GenerateFakeData()
        {
            // Players
            var jane = new Player { Id = "1", Alias  = "Jane" };
            var john = new Player { Id = "1", Alias = "John" };
            
            // Games
            var tetris = new Game { Id = 1, Title = "Tetris", Description = "Lorem ipsum dolor" };
            var pacMan = new Game { Id = 2, Title = "Pac-Man", Description = "Lorem ipsum dolor" };
            var astroids = new Game { Id = 3, Title = "Astroids", Description = "Lorem ipsum dolor" };

            var scores = new List<Score>
            {
                // Jane
                new Score { Id = 1, Player = jane, Game = tetris, Date = new DateTime(2019,1,1), Points = 198120 },
                new Score { Id = 1, Player = jane, Game = pacMan, Date = new DateTime(2019,3,3), Points = 675943 },
                // John
                new Score { Id = 3, Player = john, Game = tetris, Date = new DateTime(2019,2,12), Points = 176345 },
                new Score { Id = 4, Player = john, Game = pacMan, Date = new DateTime(2019,2,12), Points = 898748 },
                new Score { Id = 4, Player = john, Game = astroids, Date = new DateTime(2019,3,1), Points = 1293293 }
            };

            return scores;
        }

       public IEnumerable<Score> GetHighscores()
       {
           var highscores = Scores.GroupBy(x => x.Game)
                                  .SelectMany(a => a.Where(b => b.Points == a.Max(c => c.Points)));

           return highscores;
       }
   }
}