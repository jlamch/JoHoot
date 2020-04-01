using System.Collections.Generic;

namespace Johoot.Data
{
    public class Game
    {
        public Quize Quize { get; set; }
        public int Pin { get; set; }
        public GameOptions GameOptions { get; set; }
        public List<Player> Players { get; set; }
        public object Board { get; set; }
        public long Id { get; set; }
    }

    public class GameOptions
    {
        public bool RandomOrderQuestions { get; set; }
        public bool RandomOrderAnswers { get; set; }
    }

    public class Player
    {
        public long Id { get; set; }
        public string Nick { get; set; }
        public List<int> Points { get; set; }
    }
}