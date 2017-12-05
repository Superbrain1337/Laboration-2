using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Column("Name", TypeName = "nvarchar")]
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        public virtual IList<Score> Scores { get; set; }
    }
}
