using System;
using System.Net.Http;
using HighscoreConsole.Entities;
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

                        var listHighScoreSelection = ReadKey(true);

                        if (listHighScoreSelection.Key != E)
                        {
                            var scoreId = Convert.ToInt32(ReadLine());
                            
                            var score = ListHighScoreView.DisplayById(scoreId, scoreService);

                            var listByIdSelection = ReadKey(true);
                            if (listByIdSelection.Key == R)
                            {
                               var task=  scoreService.DeleteHighscoreAsync(score.Id);
                               task.Wait();
                            }
                        }

                        break;
                    case D2:
                        
                        var gameView = new ListGamesView(httpClient);

                        gameView.ListGames();

                        var listGamesSelection = ReadKey(true);

                        if (listGamesSelection.Key != E)
                        {
                            var gameId = Convert.ToInt32(ReadLine());
                            
                            var game = gameView.ListGameById(gameId);

                            var listByIdSelection = ReadKey(true);
                            if (listByIdSelection.Key == R)
                            {
                                StandardMessages.DisplayAreYouSure();
                                var yesOrNo = ReadKey(true).Key;
                                if (yesOrNo == Y)
                                {
                                    var task = gameService.DeleteGameAsync(game.Id);
                                    task.Wait();
                                }
                            }

                            if (listByIdSelection.Key == U)
                            {
                                gameView.DisplayUpdateGame();
                                var newTitle = ReadLine();
                                var newDescription = ReadLine();

                                var task = gameService.PutGameAsync(game.Id,
                                    new Game {Description = newDescription, Title = newTitle, Id = game.Id});
                                task.Wait();

                                var newGameView = gameView.ListGameById(game.Id);
                                ReadKey(true);
                            }
                        }

                        break;


                    case D3:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
