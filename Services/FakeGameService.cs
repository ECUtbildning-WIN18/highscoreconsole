using System;
using System.Collections.Generic;
using System.Linq;
using HighscoreConsole.Entities;

namespace HighscoreConsole.Services
{
    public class FakeGameService
    {
        private static readonly IEnumerable<Game> Games = GenerateFakeData();

        private static IEnumerable<Game> GenerateFakeData()
        {
            var games = new List<Game>
            {
                new Game { Id = 1, Title = "Tetris", Description = "Lorem ipsum dolor" },
                 new Game { Id = 2, Title = "Pac-Man", Description = "Lorem ipsum dolor" },
                 new Game { Id = 3, Title = "Astroids", Description = "Lorem ipsum dolor" }
            };

            return games;
        }

       public IEnumerable<Game> GetGames()
       {
           return Games;
       }
   }
}