using static System.Console;

namespace HighscoreConsole.Views
{
    public static class StandardMessages
    {
        public static void DisplayAreYouSure()
        {
            Clear();

            WriteLine("Are you sure? Y/N");
        }
    }
}