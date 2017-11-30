using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    class AllData
    {
        public List<Player> gameData = new List<Player>();
    }

    class Player
    {
        public Player(string name)
        {
            Name = name;

        }

        public string Name { get; set; }

        public void AddNewScore(Score a,Level b)
        {
            scoreList.Add(a);
            levelList.Add(b);
        }



        public List<Score> scoreList = new List<Score>();
        public List<Level> levelList = new List<Level>();

    }

    class Score
    {
        public Score(int score)
        {
            PlayerSore = score;
        }

        public int PlayerSore { get; set; }
    }

    class Level
    {
        public Level(string name, int maxMoves)
        {
            Name = name;
            MaxMoves = maxMoves;
        }

        public string Name { get; set; }
        public int MaxMoves { get; set; }
    }


}
