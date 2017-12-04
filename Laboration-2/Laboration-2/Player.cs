using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    public class Player
    {
        

        public int PlayerId { get; set; }
        public string Name { get; set; }
        public virtual IList<Score> Scores { get; set; }
    }
}
