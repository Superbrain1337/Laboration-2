using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        [Column("AmountOfMovesUsed", TypeName = "int")]
        public int AmountOfMovesUsed { get; set; }
        public virtual Level Levels { get; set; }
    }
}
