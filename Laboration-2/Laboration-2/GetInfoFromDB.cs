using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    class GetInfoFromDB
    {
        public static  List<Level> GetListOfLevelsPlayerHasPlayed(GameContext context,string name)
        {

            // Hittar alla levels som spelaren har kört på 
            List<Level> playerQuearyDataLevels = (from x in context.Levels
                                    where x.Players.All(y => y.Name == name)
                                    select x).ToList();

            return playerQuearyDataLevels;
        }
    }
}
