using System.Net.Http;
using HighscoreConsole.Entities;
using HighscoreConsole.Services;
using static System.Console;
namespace HighscoreConsole.Views
{
    public class ListGamesView
    {
        private readonly HttpClient httpClient;

        private readonly GameService _service;

        public ListGamesView(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            _service = new GameService(httpClient);
        }
        
        public void ListGames()
        {
            Clear();
            var getGamesTask = _service.GetGamesAsync();

            getGamesTask.Wait();

            var games = getGamesTask.Result;

            foreach (var game in games)
            {
                WriteLine($"{game.Id}\t\t{game.Title}");
            }

            WriteLine("(E)xit");
            WriteLine("Press enter to type id. ID> ");
        }

        public Game ListGameById(int id)
        {
            Clear();
            var getGameByIdTask = _service.GetGameByIdAsync(id);

            getGameByIdTask.Wait();

            var mygame = getGameByIdTask.Result;

            
            WriteLine($"Title: {mygame.Title}");
            WriteLine($"Description: {mygame.Description}");

            WriteLine("(U) Update game");
            WriteLine("(R) Remove game");
            WriteLine("(E)xit");

            return mygame;
        }

        public void DisplayRemovedGame(Game game)
        {
            Clear();
            
            WriteLine($"You just removed {game.Title}");
            WriteLine("(Enter) ok");
        }

        public void DisplayUpdateGame()
        {
            Clear();
            
            WriteLine("New Title: ");
            WriteLine("New Description: /n/n");
            WriteLine("(Enter) ok");
        }
    }
}