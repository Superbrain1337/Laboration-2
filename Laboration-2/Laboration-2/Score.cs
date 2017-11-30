using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int AmountOfMovesUsed { get; set; }
        public virtual Level Levels { get; set; }
    }
}
