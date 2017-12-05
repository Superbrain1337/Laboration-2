using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }
        [Column("Name", TypeName = "nvarchar")]
        [StringLength(32)]
        [Required]
        public string Name { get; set; }
        [Column("AmountOfMoves", TypeName = "int")]
        [Required]
        public int AmountOfMoves { get; set; }
        public virtual IList<Player> Players { get; set; }
    }
}
