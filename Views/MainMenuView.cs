namespace HighscoreConsole.Views
{
    public class MainMenuView
    {
        public void Display()
        {
            Clear();
            WriteLine("1. List highscores");
            WriteLine("2. List games");
            WriteLine("3. Exit");
        }
    }
}