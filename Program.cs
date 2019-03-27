using System;
using System.Net.Http;
using HighscoreConsole.Services;
using HighscoreConsole.Views;
using static System.Console;
using static System.ConsoleKey;

namespace HighscoreConsole
{
    class Program
    {

        static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("https://localhost:5001/api/");

            var scoreService = new ScoreService(httpClient);
            var gameService = new GameService(httpClient);

            var isRunning = true;

            while (isRunning)
            {
                MainMenuView.Display();

                var selected = ReadKey(true);

                switch (selected.Key)
                {
                    case D1:

                        ListHighScoreView.Display(scoreService);

                        ReadKey(true);

                        break;
                    case D2:

                        Clear();
                        var getGamesTask = gameService.GetGamesAsync();

                        getGamesTask.Wait();

                        var games = getGamesTask.Result;

                        foreach (var game in games)
                        {
                            WriteLine($"{game.Id}\t\t{game.Title}");
                        }

                        WriteLine("ID> ");

                        var gameId = int.Parse(ReadLine());

                        var getGameByIdTask = gameService.GetGameByIdAsync(gameId);

                        getGameByIdTask.Wait();

                        var mygame = getGameByIdTask.Result;

                        WriteLine(mygame.Title);

                        ReadKey(true);

                        break;


                    case D3:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
