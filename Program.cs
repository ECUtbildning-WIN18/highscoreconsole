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

                var selected = ReadKey(true);

                switch (selected.Key)
                {
                    case D1:

                        ListHighScoreView.Display(scoreService);

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
