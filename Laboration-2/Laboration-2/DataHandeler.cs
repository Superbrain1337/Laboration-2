using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    class DataHandeler
    {
        private GameContext context;

        public DataHandeler()
        {
            context = new GameContext();
        }

        public void ClearDataBas()
        {

            context.Players.RemoveRange(context.Players);

            var two = from x in context.Levels
                      select x;


            foreach (var val in two)
            {
                context.Levels.Remove(val);
            }



            var tree = from x in context.Scores
                       select x;


            foreach (var val in tree)
            {
                context.Scores.Remove(val);
            }

            context.SaveChanges();
        }


        /// <summary>
        /// Kod för debug syfte
        /// </summary>
        public List<Level> GetLevels()
        {
            return context.Levels.ToList();
        }

        /// <summary>
        /// Kod för debug syfte
        /// </summary>
        public List<Player> GetPlayers()
        {
            return context.Players.ToList();

        }

        public Player GetPlayerByName(string name)
        {

            List<Player> temp = (from x in context.Players
                           where x.Name == name
                           select x).ToList();

            if(temp.Count != 0)
            {
                return temp[0];
            }
            else
            {
                return null;
            }
            
        }

        public Level GetLevelById(int levelId)
        {
            List<Level> temp = (from x in context.Levels
                                where x.LevelId == levelId
                                select x).ToList();

            if (temp.Count != 0)
            {
                return temp[0];
            }
            else
            {
                return null;
            }

            //return context.Levels.First(x => x.LevelId == levelId);
        }

        public Score GetScore(Player player,Level level)
        {
            List<Score> temp = (from x in player.Scores
                                where x.Levels == level
                                select x).ToList();

            if (temp.Count != 0)
            {
                return temp[0];
            }
            else
            {
                return null;
            }

            //return player.Scores.First(x => x.Levels == level);
        }

        public void SetPlayerScore(Player player, Level level, Score score, int numberOfMoves)
        {


            context.Scores.Remove(score);

            Score newScore = new Score();

            newScore.AmountOfMovesUsed = numberOfMoves;
            newScore.Levels = level;

            player.Scores.Add(newScore);

            context.SaveChanges();
        }

        public void AddNewMapToPlayerAndScore(Player player, Level level, int numberOfMoves)
        {
            Score s = new Score();

            s.Levels = level;
            s.AmountOfMovesUsed = numberOfMoves;

            player.Scores.Add(s);

            context.SaveChanges();
        }

        public void AddNewMap(string name,int maxMoves)
        {
            Level newLevle = new Level()
            {
                Name = name,
                AmountOfMoves = maxMoves,
                Players = new List<Player>()
            };

            context.Levels.Add(newLevle);
            context.SaveChanges();
        }

        public void AddNewPlayer(string name)
        {
            Player p = new Player();
            p.Name = name;
            p.Scores = new List<Score>();

            context.Players.Add(p);
            context.SaveChanges();
            
        }


    }
}
