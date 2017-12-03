using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    public class Level
    {
        public int LevelId { get; set; }
        public string Name { get; set; }
        public int AmountOfMoves { get; set; }
        public virtual IList<Player> Players { get; set; }
    }
}
