using HighscoreConsole.Entities;
using HighscoreConsole.Services;
using static System.Console;

namespace HighscoreConsole.Views
{
    public class ListHighScoreView
    {
        public static void Display(ScoreService scoreService)
        {
            Clear();

            var task = scoreService.GetHighscoresAsync();

            task.Wait();

            var highscores = task.Result;

            foreach (var highscore in highscores)
            {
                WriteLine($"{highscore.Id}\t\t {highscore.Game.Title}\t\t{highscore.Player.Alias}\t\t{highscore.Points}");
            }

            WriteLine("(E)xit");

            WriteLine("Press enter to search by id. ID> ");
        }

        public static Score DisplayById(int id, ScoreService scoreService)
        {
            Clear();

            var task = scoreService.GetHighScoreByIdAsync(id);

            task.Wait();

            var highscore = task.Result;

            WriteLine($"{highscore.Game.Title}\t\t{highscore.Player.Alias}\t\t{highscore.Points}");

            WriteLine("(R)emove");
            WriteLine("(E)xit");

            return task.Result;
        }
    }
}