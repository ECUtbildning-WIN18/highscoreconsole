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

            WriteLine("ID> ");
        }

        public void ListGameById(int id)
        {
            Clear();
            var getGameByIdTask = _service.GetGameByIdAsync(id);

            getGameByIdTask.Wait();

            var mygame = getGameByIdTask.Result;

            WriteLine($"Title: {mygame.Title}");
            WriteLine($"Description: {mygame.Description}");

            WriteLine("1. Update game");
            WriteLine("2. Remove game");
        }
    }
}