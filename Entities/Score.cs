using System;

namespace HighscoreConsole.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
        public DateTime Date { get; set; }
        public int Points { get; set; }

        // public Score(int id, Player player, Game game, DateTime date, int points)
        // {
        //     Id = id;
        //     Player = player;
        //     Game = game;
        //     Date = date;
        //     Points = points;
        // }
    }
}