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
                WriteLine($"{highscore.Game.Title}\t\t{highscore.Player.Alias}\t\t{highscore.Points}");
            }




            WriteLine("(E)xit");

            WriteLine("Id: ");


            //ID och enter ....ger annan view/metod



            //Read och Delete
        }
    }
}