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
            

            var isRunning = true;

            while (isRunning)
            {
                MainMenuView.Display();







                Clear();
                WriteLine("1. List highscores");
                WriteLine("2. List games");
                WriteLine("3. Exit");

                var selected = ReadKey(true);

                switch (selected.Key)
                {
                    case D1:
                        Clear();

                        var task = scoreService.GetHighscoresAsync();

                        task.Wait();

                        var highscores = task.Result;

                        foreach (var highscore in highscores)
                        {
                            WriteLine($"{highscore.Game.Title}\t\t{highscore.Player.Alias}\t\t{highscore.Points}");
                        }

                        ReadKey(true);

                        break;
                    case D2:
                        var gameView = new ListGamesView(httpClient);

                        gameView.ListGames();
                        
                        var gameId = int.Parse(ReadLine());

                        gameView.ListGameById(gameId);

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
